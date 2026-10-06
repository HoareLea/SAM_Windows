// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors

using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SAM.Core.Windows.Forms
{
    public partial class ProgressForm : Form
    {
        private string caption;
        private string detail = string.Empty;
        private int maxLength = 80;
        private readonly Stopwatch stopwatch = Stopwatch.StartNew();

        /// <summary>
        /// Requested cancellability. Tracked separately from <c>Button_Cancel.Visible</c>, whose getter
        /// reports *effective* visibility: on a form that has not been shown yet it reads false even after
        /// being set true, so using it as the backing store would make a true-then-false round trip leave the
        /// button enabled and the form expanded.
        /// </summary>
        private bool cancellable;

        /// <summary>
        /// Volatile because it is written on the thread that owns this form and read by the worker thread
        /// running the job (see <see cref="ProgressFormHost"/>).
        /// </summary>
        private volatile bool cancellationRequested;

        /// <summary>Designer height, used when the Cancel button is hidden (the default).</summary>
        private const int CollapsedClientHeight = 98;

        /// <summary>Height needed to show the two-line note and the Cancel button.</summary>
        private const int CancellableClientHeight = 170;

        /// <summary>Progress bar top in the collapsed layout (the original designer position).</summary>
        private const int ProgressBarTopCollapsed = 50;

        /// <summary>Progress bar top when expanded, leaving room for the two-line note above it.</summary>
        private const int ProgressBarTopExpanded = 82;

        /// <summary>Time spent in the current step; restarted on each increment.</summary>
        private readonly Stopwatch stepStopwatch = Stopwatch.StartNew();

        /// <summary>
        /// The thread that constructed the form, which for a WinForms form is the thread that owns it. See
        /// <see cref="TryInvoke"/> for why this is used instead of <c>InvokeRequired</c>.
        /// </summary>
        private readonly int ownerThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;

        /// <summary>
        /// Raised on the thread that owns this form when the user clicks Cancel. With
        /// <see cref="ProgressFormHost"/> that is the form's own UI thread, so a handler must be safe to call
        /// from a thread other than the one running the job — cancelling a <c>CancellationTokenSource</c> is.
        /// </summary>
        public event System.EventHandler CancelRequested;

        public ProgressForm()
        {
            InitializeComponent();
        }

        public ProgressForm(string name, int max)
            : this(name)
        {
            ProgressBar_Main.Maximum = max;
        }

        public ProgressForm(string name)
        {
            InitializeComponent();
            Text = name;

            ProgressBar_Main.Minimum = 0;
            //ProgressBar_Main.Maximum = max;
            ProgressBar_Main.Step = 1;
            ProgressBar_Main.Value = 0;

            Show(new WindowHandle(System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle));

            Application.DoEvents();
        }

        /// <summary>
        /// <paramref name="show"/> false builds the form without showing it, for a caller that will run it in
        /// a message loop of its own (see <see cref="ProgressFormHost"/>). The other constructors show it
        /// modelessly over the host application, which is what every existing caller expects.
        /// </summary>
        public ProgressForm(string name, int max, bool show)
        {
            InitializeComponent();
            Text = name;

            ProgressBar_Main.Minimum = 0;
            ProgressBar_Main.Maximum = max;
            ProgressBar_Main.Step = 1;
            ProgressBar_Main.Value = 0;

            if (show)
            {
                Show(new WindowHandle(System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle));

                Application.DoEvents();
            }
        }

        /// <summary>
        /// Set by <see cref="ProgressFormHost"/> when this form runs its own message loop on its own thread.
        /// <see cref="Update"/> then skips the <see cref="Application.DoEvents"/> pump and the focus grab —
        /// the loop is already pumping, and a background dialog must not steal focus from the host
        /// application on every step — and a timer keeps the elapsed times ticking between steps, so the
        /// dialog visibly stays alive through a stage that runs for minutes.
        /// </summary>
        public bool OwnsMessageLoop
        {
            get
            {
                return Timer_Elapsed.Enabled;
            }
            set
            {
                Timer_Elapsed.Enabled = value;
            }
        }

        /// <summary>
        /// Posts <paramref name="action"/> to the thread that owns this form and returns true, or returns
        /// false when the caller is already on that thread. Posted rather than sent, so a worker thread
        /// reporting progress is never blocked waiting on the UI.
        /// <para>
        /// The owning thread is the one that constructed the form, compared by id rather than through
        /// <see cref="System.Windows.Forms.Control.InvokeRequired"/>: that property returns false while the
        /// handle does not exist yet, which would run the body on the calling thread and touch controls
        /// across threads. A cross-thread call arriving before the handle exists is dropped instead — one
        /// missed progress line, rather than corrupted state.
        /// </para>
        /// </summary>
        private bool TryInvoke(Action action)
        {
            if (System.Threading.Thread.CurrentThread.ManagedThreadId == ownerThreadId)
            {
                return false;
            }

            try
            {
                if (IsHandleCreated && !IsDisposed)
                {
                    BeginInvoke(action);
                }
            }
            catch (System.ComponentModel.InvalidAsynchronousStateException)
            {
                // the form's thread has gone away mid-run; there is nothing left to report to
            }
            catch (ObjectDisposedException)
            {
                // same
            }

            return true;
        }

        /// <summary>
        /// Opt-in: shows the Cancel button and grows the form to fit it. Off by default, and the form keeps
        /// its original height, so existing callers of this shared form are visually unchanged. Callers that
        /// set this should honour <see cref="CancellationRequested"/> (or subscribe to
        /// <see cref="CancelRequested"/>) between steps.
        /// </summary>
        public bool Cancellable
        {
            get
            {
                return cancellable;
            }
            set
            {
                if (TryInvoke(() => Cancellable = value))
                {
                    return;
                }

                if (cancellable == value)
                {
                    return;
                }

                cancellable = value;
                Button_Cancel.Visible = value;
                Label_Note.Visible = value;
                ProgressBar_Main.Top = value ? ProgressBarTopExpanded : ProgressBarTopCollapsed;
                ClientSize = new System.Drawing.Size(ClientSize.Width, value ? CancellableClientHeight : CollapsedClientHeight);
            }
        }

        /// <summary>
        /// Secondary text under the main line while <see cref="Cancellable"/> is set — use it to say what the
        /// Cancel button can and cannot interrupt. Ignored visually when the form is not cancellable.
        /// </summary>
        public string Note
        {
            get
            {
                return Label_Note.Text;
            }
            set
            {
                if (TryInvoke(() => Note = value))
                {
                    return;
                }

                if (string.Equals(Label_Note.Text, value, StringComparison.Ordinal))
                {
                    return;
                }

                Label_Note.Text = value ?? string.Empty;
            }
        }

        /// <summary>True once the user has clicked Cancel. Safe to read from any thread.</summary>
        public bool CancellationRequested
        {
            get
            {
                return cancellationRequested;
            }
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            cancellationRequested = true;
            Button_Cancel.Enabled = false;
            Label_Description.Text = "Cancelling... (finishing current step) | total " + Query.Duration(stopwatch.Elapsed);
            Label_Note.Text = "The current stage cannot be interrupted - it must finish before the run stops.";
            Refresh();
            CancelRequested?.Invoke(this, System.EventArgs.Empty);

            if (!OwnsMessageLoop)
            {
                Application.DoEvents();
            }
        }

        public string Caption
        {
            get
            {
                return caption;
            }
            set
            {
                caption = value;
            }
        }

        public int Max
        {
            get
            {
                return ProgressBar_Main.Maximum;
            }

            set
            {
                if (TryInvoke(() => Max = value))
                {
                    return;
                }

                ProgressBar_Main.Maximum = value;
            }
        }

        public void Update(string text, bool increment = true)
        {
            if (TryInvoke(() => Update(text, increment)))
            {
                return;
            }

            string text_Temp = text;
            if (text_Temp == null)
                text_Temp = string.Empty;

            if (increment)
            {
                ProgressBar_Main.PerformStep();
                caption = text_Temp;
                text_Temp = string.Empty;
                stepStopwatch.Restart();
            }

            detail = text_Temp;

            // Once the user has asked to cancel, keep the "Cancelling..." message on screen rather than
            // overwriting it with the next step's caption; still pump messages so the form stays responsive.
            if (cancellationRequested)
            {
                if (!OwnsMessageLoop)
                {
                    Application.DoEvents();
                }

                return;
            }

            RenderDescription();

            Refresh();

            if (!OwnsMessageLoop)
            {
                // BringToFront keeps the dialog visible above the host window. Focus() used to follow it, which
                // seized the keyboard on every single step: alt-tab away from a long import and it dragged you
                // back, keystroke by keystroke. Being on top is what a progress dialog needs; taking the
                // keyboard is not.
                BringToFront();
                Application.DoEvents();
            }
        }

        /// <summary>
        /// Only runs while <see cref="OwnsMessageLoop"/> is set, and only re-renders the times — a stage that
        /// takes minutes would otherwise leave a frozen clock on screen and look indistinguishable from a hang.
        /// </summary>
        private void Timer_Elapsed_Tick(object sender, EventArgs e)
        {
            if (cancellationRequested)
            {
                return;
            }

            RenderDescription();
        }

        private void RenderDescription()
        {
            // Both times carry explicit units (see Query.Duration) so the number can never be misread as
            // mm:ss vs hh:mm, and "step"/"total" name which is which.
            //
            // The step time is only shown when a message loop of our own is refreshing it. Every caller
            // announces a step and then does the work synchronously, so without that timer the step clock is
            // read immediately after being restarted and reads "0s" for the entire stage - a permanent zero
            // is worse than no number at all.
            string times = OwnsMessageLoop
                ? "step " + Query.Duration(stepStopwatch.Elapsed) + " | total " + Query.Duration(stopwatch.Elapsed)
                : "total " + Query.Duration(stopwatch.Elapsed);

            // Counter and times lead so a long caption cannot push them out of the fixed-width label; the
            // caption and any detail are what get ellipsised. maxLength is only a coarse guard against
            // pathological strings - actual overflow is handled width-aware by Label_Description.AutoEllipsis.
            string text = "[" + ProgressBar_Main.Value + "/" + ProgressBar_Main.Maximum + "] " + times + " | " + caption + " " + detail;

            if (text.Length > maxLength)
                text = text.Substring(0, maxLength);

            Label_Description.Text = text;
        }

        private void SimpleProgressForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Deliberately empty. This used to Thread.Sleep(1000), which blocked the thread that owns the form
            // for a second on every single close - so every SAM operation that shows a progress dialog paid a
            // second it did not need, and with ProgressFormHost it also delayed the join that tears the dialog
            // thread down. Sleeping a UI thread from a FormClosing handler achieves nothing that a caller
            // wanting a visible pause could not do on its own.
        }

        private void SimpleProgressForm_Load(object sender, EventArgs e)
        {
            ProgressBar_Main.Refresh();
        }
    }
}
