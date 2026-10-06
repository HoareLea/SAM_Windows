// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020-2026 Michal Dengusiak & Jakub Ziolkowski and contributors

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace SAM.Core.Windows.WPF
{
    /// <summary>
    /// WPF replacement for the WinForms SAM.Core.Windows.Forms.ProgressForm: a determinate,
    /// step-based progress dialog shown non-modally on the calling (UI) thread and advanced via
    /// <see cref="Update"/>. Mirrors the original public surface (the (name) / (name, max)
    /// constructors, Caption, Max and Update). Implements IDisposable (Dispose closes the window) so
    /// existing <c>using (...)</c> call sites keep working.
    /// <para>
    /// Shown on the caller's thread it can only report progress between steps, and a step that blocks the
    /// dispatcher for more than a few seconds gets ghosted by Windows — see <see cref="ProgressWindowHost"/>,
    /// which runs this window on a dispatcher thread of its own so its Cancel button keeps working.
    /// </para>
    /// </summary>
    public partial class ProgressWindow : System.Windows.Window, IDisposable
    {
        private string caption;
        private string detail = string.Empty;
        private const int maxLength = 80;

        /// <summary>Time since the dialog opened.</summary>
        private readonly Stopwatch stopwatch = Stopwatch.StartNew();

        /// <summary>Time spent in the current step; restarted on each increment.</summary>
        private readonly Stopwatch stepStopwatch = Stopwatch.StartNew();

        /// <summary>
        /// Requested cancellability. A field rather than reading <c>Button_Cancel.Visibility</c> back, so the
        /// no-change early-out below compares what was asked for. (The WinForms twin has no choice here:
        /// <c>Control.Visible</c> reports *effective* visibility and reads false on a form that has not been
        /// shown, so a true-then-false round trip would strand it expanded. A WPF DependencyProperty does not
        /// have that failure mode, but a dedicated field is still the clearer thing to compare against.)
        /// </summary>
        private bool cancellable;

        /// <summary>
        /// Volatile because it is written on the thread that owns this window and read by the worker thread
        /// running the job (see <see cref="ProgressWindowHost"/>).
        /// </summary>
        private volatile bool cancellationRequested;

        /// <summary>Ticks the elapsed times while <see cref="OwnsMessageLoop"/> is set; see below.</summary>
        private readonly DispatcherTimer dispatcherTimer;

        /// <summary>
        /// Raised on the thread that owns this window when the user clicks Cancel. With
        /// <see cref="ProgressWindowHost"/> that is the window's own dispatcher thread, so a handler must be
        /// safe to call from a thread other than the one running the job — cancelling a
        /// <c>CancellationTokenSource</c> is.
        /// </summary>
        public event System.EventHandler CancelRequested;

        public ProgressWindow()
        {
            InitializeComponent();

            dispatcherTimer = CreateTimer();
        }

        public ProgressWindow(string name)
        {
            InitializeComponent();

            dispatcherTimer = CreateTimer();

            Title = name;

            ProgressBar_Main.Minimum = 0;
            ProgressBar_Main.Value = 0;

            Show();

            DoEvents();
        }

        public ProgressWindow(string name, int max)
            : this(name)
        {
            ProgressBar_Main.Maximum = max;
        }

        /// <summary>
        /// <paramref name="show"/> false builds the window without showing it, for a caller that will run it
        /// in a dispatcher loop of its own (see <see cref="ProgressWindowHost"/>). The other constructors show
        /// it modelessly on the calling thread, which is what every existing caller expects.
        /// </summary>
        public ProgressWindow(string name, int max, bool show)
        {
            InitializeComponent();

            dispatcherTimer = CreateTimer();

            Title = name;

            ProgressBar_Main.Minimum = 0;
            ProgressBar_Main.Maximum = max;
            ProgressBar_Main.Value = 0;

            if (show)
            {
                Show();

                DoEvents();
            }
        }

        /// <summary>
        /// Bound explicitly to this window's dispatcher rather than <c>Dispatcher.CurrentDispatcher</c>. They
        /// are the same thread today — every constructor runs on the owning thread — but tying the timer to
        /// the window it updates makes that independent of where construction happens.
        /// </summary>
        private DispatcherTimer CreateTimer()
        {
            DispatcherTimer result = new DispatcherTimer(DispatcherPriority.Normal, Dispatcher)
            {
                Interval = TimeSpan.FromSeconds(1)
            };

            result.Tick += DispatcherTimer_Tick;

            return result;
        }

        /// <summary>
        /// Set by <see cref="ProgressWindowHost"/> when this window runs its own dispatcher loop on its own
        /// thread. <see cref="Update"/> then skips the <see cref="DoEvents"/> pump and the <c>Activate</c>
        /// call — the loop is already pumping, and a background dialog must not steal focus from the host
        /// application on every step — and a timer keeps the elapsed times ticking between steps, so the
        /// dialog visibly stays alive through a stage that runs for minutes.
        /// </summary>
        public bool OwnsMessageLoop
        {
            get
            {
                return dispatcherTimer.IsEnabled;
            }
            set
            {
                dispatcherTimer.IsEnabled = value;
            }
        }

        /// <summary>
        /// Posts <paramref name="action"/> to the thread that owns this window and returns true, or returns
        /// false when the caller is already on that thread. Posted rather than sent, so a worker thread
        /// reporting progress is never blocked waiting on the UI.
        /// <para>
        /// <see cref="DispatcherObject.CheckAccess"/> is reliable from construction onwards — a WPF
        /// DispatcherObject is bound to its thread the moment it is created — so unlike the WinForms twin
        /// there is no window-handle race to work around here. What can still happen is the dispatcher being
        /// shut down under a post that is already on its way, which is what the catch covers.
        /// </para>
        /// </summary>
        private bool TryInvoke(Action action)
        {
            if (Dispatcher.CheckAccess())
            {
                return false;
            }

            try
            {
                if (!Dispatcher.HasShutdownStarted)
                {
                    Dispatcher.BeginInvoke(DispatcherPriority.Normal, action);
                }
            }
            catch (System.ComponentModel.InvalidAsynchronousStateException)
            {
                // the window's thread has gone away mid-run; there is nothing left to report to
            }
            catch (ObjectDisposedException)
            {
                // same
            }
            catch (TaskCanceledException)
            {
                // BeginInvoke on a dispatcher that shut down between the check above and the post
            }

            return true;
        }

        /// <summary>
        /// Opt-in: shows the Cancel button and the note line, growing the window to fit them. Off by default,
        /// so existing callers of this shared dialog are visually unchanged. Callers that set this should
        /// honour <see cref="CancellationRequested"/> (or subscribe to <see cref="CancelRequested"/>) between
        /// steps.
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

                Visibility visibility = value ? Visibility.Visible : Visibility.Collapsed;

                Button_Cancel.Visibility = visibility;
                Label_Note.Visibility = visibility;
            }
        }

        /// <summary>
        /// Secondary text under the main line while <see cref="Cancellable"/> is set — use it to say what the
        /// Cancel button can and cannot interrupt. Ignored visually when the dialog is not cancellable.
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

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            cancellationRequested = true;
            Button_Cancel.IsEnabled = false;
            Label_Description.Text = "Cancelling... (finishing current step) | total " + SAM.Core.Windows.Query.Duration(stopwatch.Elapsed);
            Label_Note.Text = "The current stage cannot be interrupted - it must finish before the run stops.";

            CancelRequested?.Invoke(this, System.EventArgs.Empty);

            if (!OwnsMessageLoop)
            {
                DoEvents();
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
                return (int)ProgressBar_Main.Maximum;
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

            string text_Temp = text ?? string.Empty;

            if (increment)
            {
                ProgressBar_Main.Value = Math.Min(ProgressBar_Main.Value + 1, ProgressBar_Main.Maximum);
                caption = text_Temp;
                text_Temp = string.Empty;
                stepStopwatch.Restart();
            }

            detail = text_Temp;

            // Once the user has asked to cancel, keep the "Cancelling..." message on screen rather than
            // overwriting it with the next step's caption; still pump so the dialog stays responsive.
            if (cancellationRequested)
            {
                if (!OwnsMessageLoop)
                {
                    DoEvents();
                }

                return;
            }

            RenderDescription();

            if (!OwnsMessageLoop)
            {
                Activate();

                DoEvents();
            }
        }

        /// <summary>
        /// Only runs while <see cref="OwnsMessageLoop"/> is set, and only re-renders the times — a stage that
        /// takes minutes would otherwise leave a frozen clock on screen and look indistinguishable from a hang.
        /// </summary>
        private void DispatcherTimer_Tick(object sender, EventArgs e)
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
            // The step time is only shown when a dispatcher loop of our own is refreshing it. Every caller
            // announces a step and then does the work synchronously, so without that timer the step clock is
            // read immediately after being restarted and reads "0s" for the entire stage - a permanent zero
            // is worse than no number at all.
            string times = OwnsMessageLoop
                ? "step " + SAM.Core.Windows.Query.Duration(stepStopwatch.Elapsed) + " | total " + SAM.Core.Windows.Query.Duration(stopwatch.Elapsed)
                : "total " + SAM.Core.Windows.Query.Duration(stopwatch.Elapsed);

            // Counter and times lead so a long caption cannot push them out of the label; the caption and any
            // detail are what get ellipsised. maxLength is only a coarse guard against pathological strings -
            // actual overflow is handled width-aware by Label_Description's TextTrimming.
            string text = "[" + (int)ProgressBar_Main.Value + "/" + (int)ProgressBar_Main.Maximum + "] " + times + " | " + caption + " " + detail;

            if (text.Length > maxLength)
            {
                text = text.Substring(0, maxLength);
            }

            Label_Description.Text = text;
        }

        public void Dispose()
        {
            // Marshal first: DispatcherTimer.IsEnabled has thread affinity of its own and throws when set
            // from off-thread, so it cannot be touched ahead of this check.
            if (TryInvoke(Dispose))
            {
                return;
            }

            // Stopping the timer before the close keeps a queued tick from running against a window that is
            // on its way out.
            dispatcherTimer.IsEnabled = false;

            Close();
        }

        /// <summary>WPF equivalent of Application.DoEvents: pump the dispatcher queue down to Background priority so the dialog repaints between steps.</summary>
        private static void DoEvents()
        {
            DispatcherFrame frame = new DispatcherFrame();
            Dispatcher.CurrentDispatcher.BeginInvoke(
                DispatcherPriority.Background,
                new DispatcherOperationCallback(f =>
                {
                    ((DispatcherFrame)f).Continue = false;
                    return null;
                }),
                frame);
            Dispatcher.PushFrame(frame);
        }
    }
}
