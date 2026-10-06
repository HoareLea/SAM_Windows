// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors

using System;
using System.Threading;
using System.Windows.Forms;
using SAM.Core.Windows.Forms;

namespace SAM.Core.Windows
{
    public static partial class Modify
    {
        /// <summary>
        /// Runs <paramref name="action"/> on a dedicated STA thread while a modal marquee animates, and joins
        /// that thread before returning. Use this for a single, uninterruptible COM call (e.g. a TAS simulate)
        /// that would otherwise freeze the UI with no sign of activity.
        /// <para>
        /// The worker is STA because TAS COM is apartment-affine — a thread-pool/<see cref="System.ComponentModel.BackgroundWorker"/>
        /// thread is MTA and is NOT safe for it. The COM object must be created, used and released entirely on
        /// the worker; only plain values may come back (through captured locals).
        /// </para>
        /// <para>
        /// The form is shown with <see cref="Form.ShowDialog(IWin32Window)"/> so the animation is driven by a
        /// real modal message loop (rather than a manual <see cref="Application.DoEvents"/> pump, which would
        /// let the user re-enter the host application mid-call). The worker starts from the form's
        /// <see cref="Form.Shown"/> event and closes the form via <see cref="Control.BeginInvoke(Delegate)"/>
        /// when it finishes; the thread is then joined, so nothing is ever orphaned and no re-solve is needed.
        /// </para>
        /// <para>
        /// The work CANNOT be cancelled: an in-flight COM call is not interruptible. The caller still blocks
        /// until completion — the only gain over calling inline is an animated, responsive indicator. Any
        /// exception from <paramref name="action"/> is rethrown to the caller.
        /// </para>
        /// </summary>
        /// <param name="name">Window title and main line, shown to the user with a running total time.</param>
        /// <param name="action">The work to run on the STA thread.</param>
        /// <param name="note">
        /// Optional second line. Defaults to a note saying the stage cannot be cancelled — which is the whole
        /// point of this helper, and the thing users otherwise have no way of knowing while they wait.
        /// </param>
        public static void RunOnStaThread(string name, Action action, string note = null)
        {
            if (action == null)
            {
                return;
            }

            Exception captured = null;

            using (MarqueeProgressForm marqueeProgressForm = new MarqueeProgressForm(name))
            {
                marqueeProgressForm.Description = name;
                marqueeProgressForm.Note = note ?? "This stage cannot be cancelled - it must finish before the run stops.";

                bool finished = false;

                Thread thread = new Thread(() =>
                {
                    try
                    {
                        action();
                    }
                    catch (Exception exception)
                    {
                        captured = exception;
                    }
                    finally
                    {
                        finished = true;

                        // Hand back to the UI thread to end the modal loop. The handle exists because the
                        // worker is only started from Shown.
                        try
                        {
                            if (marqueeProgressForm.IsHandleCreated)
                            {
                                marqueeProgressForm.BeginInvoke(new Action(marqueeProgressForm.Close));
                            }
                        }
                        catch (Exception)
                        {
                            // the form is already closing/disposed — the modal loop is ending anyway
                        }
                    }
                })
                {
                    IsBackground = true,
                    Name = "sam-sta-worker",
                };

                thread.SetApartmentState(ApartmentState.STA);

                // Start only once the modal message loop is running, so the close-via-BeginInvoke below can
                // never be raised before there is a loop to end.
                marqueeProgressForm.Shown += (s, e) => thread.Start();

                // The form has no ControlBox, but block any other user-initiated close (e.g. Alt+F4) so the
                // modal loop cannot end while the uninterruptible COM call is still running.
                marqueeProgressForm.FormClosing += (s, e) =>
                {
                    if (!finished && e.CloseReason == CloseReason.UserClosing)
                    {
                        e.Cancel = true;
                    }
                };

                marqueeProgressForm.ShowDialog(new WindowHandle(System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle));

                // By here the worker has signalled completion; this joins an already-finished thread.
                thread.Join();
            }

            if (captured != null)
            {
                // Rethrow preserving the worker's original stack trace (a plain `throw captured` would reset
                // it to this line and lose where inside the COM call it actually failed).
                System.Runtime.ExceptionServices.ExceptionDispatchInfo.Capture(captured).Throw();
            }
        }
    }
}
