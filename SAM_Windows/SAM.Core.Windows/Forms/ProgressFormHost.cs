// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020-2026 Michal Dengusiak & Jakub Ziolkowski and contributors

using System;
using System.Threading;
using System.Windows.Forms;

namespace SAM.Core.Windows.Forms
{
    /// <summary>
    /// Hosts a <see cref="ProgressForm"/> on a dedicated UI thread running its own message loop, so the dialog
    /// keeps painting and its Cancel button keeps accepting clicks while the CALLING thread is blocked inside a
    /// long, uninterruptible call — a TAS COM simulate, say.
    /// <para>
    /// This exists because a Cancel button on the blocked thread's own form cannot be relied on. Windows ghosts
    /// a top-level window whose thread has not pumped for a few seconds (the "Not Responding" overlay) and
    /// silently discards clicks on the ghost, so the click is never queued and the later
    /// <see cref="Application.DoEvents"/> has nothing to deliver. The user clicks Cancel, sees nothing happen,
    /// and the run continues. Moving only the dialog to its own thread fixes that without moving any COM work.
    /// </para>
    /// <para>
    /// The job itself stays on the caller's thread and is NOT interrupted — cancellation is still cooperative
    /// and observed between steps. What changes is that the request is always recorded the instant it is made.
    /// </para>
    /// <para>
    /// Only the members on this class may be touched from the calling thread; they marshal onto the dialog's
    /// thread. <see cref="Dispose"/> closes the form and joins the thread.
    /// </para>
    /// </summary>
    public sealed class ProgressFormHost : IDisposable
    {
        private readonly Thread thread;
        private volatile ProgressForm progressForm;

        /// <summary>
        /// Volatile because the dialog thread reads it while starting up. The constructor's wait is bounded,
        /// so a caller can be handed the host — and finish the job and dispose it — before this thread has a
        /// window handle. Without this the thread would go on to open a topmost dialog that nothing is left to
        /// close, leaving it stranded over the host application for the rest of the session.
        /// </summary>
        private volatile bool disposed;

        /// <summary>
        /// Whatever killed the dialog thread, if anything. Rethrown by the constructor when it happened during
        /// startup; if it happened later, inside the message loop, the constructor has already returned and it
        /// is surfaced through <see cref="Exception"/> instead. Either way it is never allowed to escape the
        /// thread itself.
        /// </summary>
        private volatile Exception exception_Startup;

        /// <summary>
        /// Signalled when the dialog is up, and again when its thread exits. A field rather than a local
        /// disposed by the constructor: the dialog thread still signals it after <c>Application.Run</c>
        /// returns, and setting a disposed <see cref="ManualResetEventSlim"/> throws on a background thread
        /// with no catch above it, which takes the whole host process down. Disposed in
        /// <see cref="Dispose"/>, after the thread has been joined.
        /// </summary>
        private readonly ManualResetEventSlim manualResetEventSlim = new ManualResetEventSlim(false);

        private volatile bool shutdownCompleted;

        /// <summary>
        /// True once <see cref="Dispose"/> has both joined the dialog thread and established that no
        /// <see cref="CancelRequested"/> handler will run again. Only then is the caller's post-dispose
        /// cancellation check final: while either is outstanding the dialog thread is still live and a click
        /// it has queued can still be sitting unobserved, so a run that looks successful may not be one.
        /// <para>
        /// False before <see cref="Dispose"/> has run. Callers should read it after disposing and treat false
        /// as "the outcome of this run cannot be confirmed" rather than as success. No caller reads it yet —
        /// what the existing WinForms call sites should report on an unconfirmed shutdown is still open.
        /// </para>
        /// </summary>
        public bool ShutdownCompleted
        {
            get
            {
                return shutdownCompleted;
            }
        }

        /// <summary>
        /// Guards <see cref="cancelRequested"/> and <see cref="cancelRequested_Latched"/> together, so a
        /// subscription and a cancel arriving at the same moment cannot interleave into "latched, but the
        /// handler that was being added never heard about it".
        /// </summary>
        private readonly object cancelRequested_Lock = new object();

        /// <summary>
        /// True once the user has asked to cancel, whether or not anyone was listening at the time.
        /// </summary>
        private bool cancelRequested_Latched;

        // System-qualified: SAM.Core.Windows has its own EventHandler namespace that otherwise wins here.
        private System.EventHandler cancelRequested;

        /// <summary>
        /// Set at the very end of <see cref="Dispose"/>, after which no handler is ever invoked again. This
        /// matters when the dialog thread could NOT be joined: the caller is about to make its final token
        /// observation and then dispose the <c>CancellationTokenSource</c> its handler closes over, and
        /// <c>Cancel()</c> on a disposed source throws — on the dialog thread, killing it. Detaching means a
        /// click still in flight on a thread we failed to join is dropped rather than turned into an exception
        /// against state the caller has already torn down.
        /// </summary>
        private bool cancelRequested_Detached;

        /// <summary>
        /// Raised on the dialog's thread when the user clicks Cancel, so a handler must be safe to call from a
        /// thread other than the one running the job. Cancelling a <c>CancellationTokenSource</c> is.
        /// <para>
        /// Latching rather than a plain field-like event, because the window is clickable before the caller
        /// can subscribe: the constructor returns as soon as the dialog is up, and only then does the caller
        /// get to attach its handler. A click landing in that gap would invoke a null handler list and be
        /// thrown away — the dialog would record the cancellation and nothing would act on it. Subscribing
        /// after the fact therefore fires immediately if a cancel has already been recorded.
        /// </para>
        /// <para>
        /// Handlers must be safe to run on the subscribing thread as well as the dialog's, since that
        /// catch-up call happens inline on whichever thread subscribes.
        /// </para>
        /// </summary>
        public event System.EventHandler CancelRequested
        {
            add
            {
                // The catch-up invoke happens under the lock, like every other invoke on this class - see
                // RaiseCancelRequested for why that is what makes Dispose's quiescence guarantee real.
                lock (cancelRequested_Lock)
                {
                    if (cancelRequested_Detached)
                    {
                        return;
                    }

                    cancelRequested += value;

                    if (cancelRequested_Latched)
                    {
                        value?.Invoke(this, EventArgs.Empty);
                    }
                }
            }

            remove
            {
                lock (cancelRequested_Lock)
                {
                    cancelRequested -= value;
                }
            }
        }

        /// <summary>
        /// Records the cancellation and notifies whoever is listening, at most once. Called only from the
        /// dialog thread. <see cref="Dispose"/>'s safety net deliberately does NOT route through here: it
        /// raises inline, under the single bounded acquisition it already makes, because a second unbounded
        /// acquisition from the caller thread cannot be made safe — see there.
        /// </summary>
        private void RaiseCancelRequested()
        {
            // Handlers are invoked INSIDE the lock, deliberately, and this is the whole teardown handshake:
            // Dispose acquires the same lock to detach, so it cannot return while a handler is still running,
            // and no handler can start once it has. Capturing the delegate under the lock and invoking outside
            // it - the obvious shape - does NOT achieve that: clearing the field cannot revoke a delegate a
            // stalled thread has already copied into a local, so Dispose could return, the caller could
            // dispose the CancellationTokenSource its handler closes over, and the handler could then run
            // against it.
            //
            // Safe to hold across caller code because nothing Dispose does while waiting on this lock depends
            // on this thread: the input drain and the Join both complete before it is attempted, and the
            // single acquisition it then makes is a bounded TryEnter - so a handler that never returns costs
            // Dispose two seconds and a reported failure to quiesce, not a deadlock.
            lock (cancelRequested_Lock)
            {
                if (cancelRequested_Latched || cancelRequested_Detached)
                {
                    return;
                }

                cancelRequested_Latched = true;

                // No catch around this. Swallowing here would span the whole multicast: it would silently eat
                // a genuine failure from any subscriber, skip every subscriber after the one that threw, and
                // hide it from both the dialog thread's outer catch and the Exception property.
                cancelRequested?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <param name="name">Window title.</param>
        /// <param name="max">Number of steps the progress bar counts to.</param>
        /// <param name="cancellable">Shows the Cancel button and the note line.</param>
        /// <param name="note">Initial note text; see <see cref="ProgressForm.Note"/>.</param>
        public ProgressFormHost(string name, int max, bool cancellable, string note)
        {
            thread = new Thread(() =>
            {
                ProgressForm progressForm_Temp = null;

                // Everything on this thread is inside the try, construction included: an exception escaping a
                // raw thread terminates the process under the default .NET policy, and a progress dialog must
                // never be able to take the host application down. Constructing the form can throw on its own
                // (a negative max, for one), which happens before any of the code below runs.
                try
                {
                    progressForm_Temp = new ProgressForm(name, max, false)
                    {
                        // Not owned by the host application's main window: an owner must live on the same
                        // thread as the owned form, and this one deliberately does not. TopMost keeps it in
                        // front of the frozen host instead.
                        TopMost = true,
                        StartPosition = FormStartPosition.CenterScreen,
                        OwnsMessageLoop = true,
                        Cancellable = cancellable,
                    };

                    progressForm_Temp.Note = note;
                    progressForm_Temp.CancelRequested += (s, e) => RaiseCancelRequested();

                    progressForm_Temp.Load += (s, e) =>
                    {
                        Release();

                        // Disposed between the check below and getting a handle: close now that there is a
                        // loop to close. Together with that check this leaves no window in which the dialog
                        // can open and stay open.
                        if (disposed)
                        {
                            progressForm_Temp.Close();
                        }
                    };

                    // Set before the loop starts so the caller never sees a null form once it is released.
                    progressForm = progressForm_Temp;

                    // Already disposed while this thread was starting up: never open the window at all.
                    if (!disposed)
                    {
                        Application.Run(progressForm_Temp);
                    }
                }
                catch (Exception exception)
                {
                    exception_Startup = exception;
                }
                finally
                {
                    // Release the caller even if the form failed before Load, rather than making it wait out
                    // the timeout below.
                    Release();

                    if (progressForm_Temp != null)
                    {
                        progressForm_Temp.Dispose();
                    }
                }
            })
            {
                IsBackground = true,
                Name = "sam-progress-ui",
            };

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

            // Bounded: a dialog that will not come up must never hold up the job it is reporting on.
            manualResetEventSlim.Wait(5000);

            if (exception_Startup != null)
            {
                // The dialog never came up, so hand the caller a failure rather than a live-looking host that
                // silently reports nothing. Construction failed, so nothing will call Dispose - clean up here.
                disposed = true;
                thread.Join(5000);
                manualResetEventSlim.Dispose();

                // Rethrow preserving the original stack, so the real cause is not replaced by this line.
                System.Runtime.ExceptionServices.ExceptionDispatchInfo.Capture(exception_Startup).Throw();
            }
        }

        /// <summary>
        /// Signals the readiness event, tolerating a Dispose that has already run — the thread signals once
        /// more on its way out, and if a join timed out that can land after disposal. An unhandled exception
        /// on this thread would terminate the host process, so it is swallowed deliberately.
        /// </summary>
        private void Release()
        {
            try
            {
                manualResetEventSlim.Set();
            }
            catch (ObjectDisposedException)
            {
            }
        }

        /// <summary>
        /// Non-null when something went wrong with the dialog itself: either its thread died of an exception
        /// raised inside its message loop after the constructor had already returned, or <see cref="Dispose"/>
        /// could not join that thread — or quiesce its handlers — within their timeouts. The job the dialog was
        /// reporting on is unaffected either way, which is why this is reported rather than thrown.
        /// <para>
        /// A failed join is worth checking for, not just logging: it is the one case where a Cancel click can
        /// still be lost, because a thread that will not shut down cannot be asked what the user did.
        /// </para>
        /// </summary>
        public Exception Exception
        {
            get
            {
                return exception_Startup;
            }
        }

        /// <summary>True once the user has clicked Cancel. Safe to read from the job's thread.</summary>
        public bool CancellationRequested
        {
            get
            {
                ProgressForm progressForm_Temp = progressForm;

                return progressForm_Temp != null && progressForm_Temp.CancellationRequested;
            }
        }

        /// <summary>Number of steps the progress bar counts to; set it once the count is known.</summary>
        public int Max
        {
            set
            {
                ProgressForm progressForm_Temp = progressForm;
                if (progressForm_Temp != null)
                {
                    progressForm_Temp.Max = value;
                }
            }
        }

        /// <summary>Note under the main line — say what Cancel can and cannot interrupt at this stage.</summary>
        public string Note
        {
            set
            {
                ProgressForm progressForm_Temp = progressForm;
                if (progressForm_Temp != null)
                {
                    progressForm_Temp.Note = value;
                }
            }
        }

        /// <summary>Advances the bar and shows <paramref name="description"/> as the current step.</summary>
        public void Update(string description, bool increment = true)
        {
            ProgressForm progressForm_Temp = progressForm;
            if (progressForm_Temp != null)
            {
                progressForm_Temp.Update(description, increment);
            }
        }

        public void Dispose()
        {
            if (disposed)
            {
                return;
            }

            disposed = true;

            ProgressForm progressForm_Temp = progressForm;
            if (progressForm_Temp != null)
            {
                try
                {
                    if (progressForm_Temp.IsHandleCreated && !progressForm_Temp.IsDisposed)
                    {
                        // Let input the user has already generated - a Cancel click above all - be dispatched
                        // before the form is closed. This is the WinForms form of the same failure the
                        // dispatcher twin fixes with priorities, and the mechanism is different enough to be
                        // worth stating: GetMessage hands back SENT messages, then POSTED messages, and only
                        // then INPUT. Control.BeginInvoke posts, so a bare BeginInvoke(Close) is retrieved
                        // ahead of a WM_LBUTTONUP already sitting in the input queue and tears the window down
                        // over the top of the click - the run then reports success after the user asked it to
                        // stop, which is precisely the failure this class exists to prevent, one layer down.
                        // Application.DoEvents drains input as well as posted work, so pumping before closing
                        // gets the click processed and latched.
                        //
                        // Drain and close are ONE callback, deliberately. Splitting them into two posts is
                        // what an earlier revision did, and it opened a worse hole than it closed: DoEvents
                        // dispatches whatever input is queued, so a title-bar-X or Alt+F4 sitting in that
                        // queue closes AND disposes the form, and the second post then throws
                        // InvalidOperationException - out of a Dispose that callers run from a finally,
                        // replacing the job's own exception and skipping the join and the quiescence
                        // handshake below. Running both on the dialog thread removes the gap entirely, and
                        // the IsDisposed check is reliable there because nothing else can close the form
                        // behind our back on the thread that owns it.
                        //
                        // No bounded wait on this post: closing the form ends Application.Run, which ends the
                        // thread, so the Join below already bounds the whole thing. Anything DoEvents throws
                        // is captured by WinForms in the IAsyncResult and dropped, which is the right trade
                        // here - a diagnostic lost is better than an exception out of a finally.
                        progressForm_Temp.BeginInvoke(new Action(() =>
                        {
                            Application.DoEvents();

                            if (!progressForm_Temp.IsDisposed)
                            {
                                progressForm_Temp.Close();
                            }
                        }));
                    }
                }
                catch (System.ComponentModel.InvalidAsynchronousStateException)
                {
                    // the thread is already gone
                }
                catch (ObjectDisposedException)
                {
                    // same
                }
                catch (InvalidOperationException)
                {
                    // The handle went away between the check above and the post - the user closing the dialog
                    // by hand is enough to do it. Listed separately even though ObjectDisposedException
                    // derives from it, because BeginInvoke throws the plain base type when no suitable handle
                    // remains, and catching only the derived one lets that escape.
                }
            }

            // Bounded for the same reason as the startup wait: a stuck dialog thread must not hang the host.
            bool joined = thread == null || thread.Join(5000);

            // The teardown handshake AND the safety-net raise, under one bounded acquisition.
            //
            // Taking this lock waits out any handler currently running on the dialog thread, and setting the
            // detached flag under it stops another starting - so once this block completes, no handler will
            // ever run again and the caller can dispose the CancellationTokenSource its handler closes over
            // without the dialog thread throwing ObjectDisposedException against it.
            //
            // TryEnter rather than lock: a handler that never returns must not hang the host. Failing to take
            // it is the one case where quiescence cannot be established, and it is reported rather than
            // pretended away.
            //
            // The safety net has to live INSIDE this same acquisition rather than before it. A handler still
            // running on a dialog thread the join failed to reach is holding this lock, and a separate
            // RaiseCancelRequested call from here would wait on it unbounded - never reaching the TryEnter
            // that exists precisely to bound that wait, and deadlocking Dispose instead of timing out.
            bool quiesced = Monitor.TryEnter(cancelRequested_Lock, 2000);
            if (quiesced)
            {
                try
                {
                    // Last line of defence, and the reason the caller's "dispose, then observe the token"
                    // ordering is airtight rather than just narrower. Once the thread is joined the dialog is
                    // finished with: whatever the user did has either been forwarded already or is recorded in
                    // the form's own volatile flag, which outlives it. Raising here converts that flag into the
                    // cancel the caller is about to look for. The latch check keeps a click that was forwarded
                    // normally from firing twice.
                    if (progressForm_Temp != null && progressForm_Temp.CancellationRequested && !cancelRequested_Latched)
                    {
                        cancelRequested_Latched = true;

                        // Caught here, unlike the raise on the dialog thread, for a reason specific to this
                        // call site: callers invoke Dispose from a finally, so an exception thrown out of it
                        // would replace whatever the job was already failing with. Recorded and surfaced
                        // through Exception instead - visible, but not masking the primary fault.
                        try
                        {
                            cancelRequested?.Invoke(this, EventArgs.Empty);
                        }
                        catch (Exception exception)
                        {
                            if (exception_Startup == null)
                            {
                                exception_Startup = exception;
                            }
                        }
                    }

                    cancelRequested = null;
                    cancelRequested_Detached = true;
                }
                finally
                {
                    Monitor.Exit(cancelRequested_Lock);
                }
            }

            shutdownCompleted = joined && quiesced;

            if (!shutdownCompleted && exception_Startup == null)
            {
                exception_Startup = joined
                    ? new TimeoutException("A ProgressFormHost.CancelRequested handler did not return within 2 seconds, so the dialog could not be quiesced.")
                    : new TimeoutException("The progress dialog thread did not shut down within 5 seconds; a cancellation made in that window may have been lost.");
            }

            progressForm = null;

            // After the join, so the dialog thread cannot still be signalling it. Release() covers the case
            // where that join timed out and the thread is somehow still alive.
            manualResetEventSlim.Dispose();
        }
    }
}
