// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020-2026 Michal Dengusiak & Jakub Ziolkowski and contributors

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace SAM.Core.Windows.Forms
{
    public partial class MarqueeProgressForm : Form
    {
        private readonly BackgroundWorker backgroundWorker = new BackgroundWorker();
        private List<Tuple<Action, string>> tuples;

        /// <summary>Runs from construction; a marquee has no step to measure, so this is the whole stage.</summary>
        private readonly Stopwatch stopwatch = Stopwatch.StartNew();

        private string description;

        /// <summary>Whether a <see cref="Note"/> is currently set, and so whether the form is grown for it.</summary>
        private bool noted;

        /// <summary>
        /// The thread that constructed the form, which for a WinForms form is the thread that owns it. See
        /// <see cref="SetText"/> for why this is used instead of <c>InvokeRequired</c>.
        /// </summary>
        private readonly int ownerThreadId = Thread.CurrentThread.ManagedThreadId;

        /// <summary>
        /// A title the worker set before the handle existed, so it could not be posted. Read and written under
        /// <see cref="textLock"/> by <see cref="SetText"/> and <see cref="OnHandleCreated"/>.
        /// </summary>
        private string text_Pending;

        /// <summary>
        /// Whether <see cref="text_Pending"/> holds an update, tracked separately from its value because a null
        /// title is a legitimate update - a tuple may carry one, and on the owning thread it blanks the caption.
        /// Treating null as "nothing pending" would leave the previous action's title on screen instead.
        /// </summary>
        private bool text_PendingSet;

        /// <summary>
        /// Guards <see cref="text_Pending"/> against the publish/consume interleaving described in
        /// <see cref="SetText"/>.
        /// </summary>
        private readonly object textLock = new object();

        /// <summary>Designer height, used while no <see cref="Note"/> is set (the default).</summary>
        private const int CollapsedClientHeight = 94;

        /// <summary>Height needed to fit the two-line note above the bar.</summary>
        private const int NotedClientHeight = 114;

        /// <summary>Progress bar top in the collapsed layout (the original designer position).</summary>
        private const int ProgressBarTopCollapsed = 46;

        /// <summary>Progress bar top once the note is shown.</summary>
        private const int ProgressBarTopNoted = 66;

        public MarqueeProgressForm(string name)
        {
            InitializeComponent();

            Text = name;

            ProgressBar_Main.Style = ProgressBarStyle.Marquee;
            ProgressBar_Main.MarqueeAnimationSpeed = 30;
        }

        /// <summary>
        /// Main line shown above the bar. Setting it also starts the elapsed readout appended to it, so a
        /// caller that leaves it null gets the original bar-only form with no timer running.
        /// </summary>
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                Timer_Elapsed.Enabled = !string.IsNullOrEmpty(description);
                UpdateDescription();
            }
        }

        /// <summary>
        /// Secondary grey text under <see cref="Description"/> — use it to say that the stage cannot be
        /// cancelled. Setting it grows the form to fit two wrapped lines; left empty (the default) the form
        /// keeps its original height, so callers that do not set it are unchanged.
        /// </summary>
        public string Note
        {
            get
            {
                return Label_Note.Text;
            }
            set
            {
                string text = value ?? string.Empty;
                bool value_Noted = text.Length != 0;

                Label_Note.Text = text;

                // Tracked in a field rather than read back from Label_Note.Visible: on a form that has not
                // been shown yet that getter reports effective visibility (false), so a set-then-clear round
                // trip would early-return here and leave the form expanded.
                if (noted == value_Noted)
                {
                    return;
                }

                noted = value_Noted;
                Label_Note.Visible = value_Noted;
                ProgressBar_Main.Top = noted ? ProgressBarTopNoted : ProgressBarTopCollapsed;
                ClientSize = new System.Drawing.Size(ClientSize.Width, noted ? NotedClientHeight : CollapsedClientHeight);
            }
        }

        /// <summary>Total time this form has been up, i.e. how long the uninterruptible call has run.</summary>
        public TimeSpan Elapsed
        {
            get
            {
                return stopwatch.Elapsed;
            }
        }

        private void Timer_Elapsed_Tick(object sender, EventArgs e)
        {
            UpdateDescription();
        }

        private void UpdateDescription()
        {
            // No description means no caller opted in, so leave the label blank rather than showing a bare
            // elapsed time on a form that never had any text.
            Label_Description.Text = string.IsNullOrEmpty(description)
                ? string.Empty
                : description + " | total " + Query.Duration(stopwatch.Elapsed);
        }

        public MarqueeProgressForm(string name, Action action)
        {
            InitializeComponent();
            
            if(action != null)
            {
                tuples = new List<Tuple<Action, string>>() { new Tuple<Action, string>(action, name) };
            }

            if(tuples != null && tuples.Count != 0)
            {
                Text = tuples[0].Item2;
            }

            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;

            backgroundWorker.RunWorkerAsync();
        }

        public MarqueeProgressForm(IEnumerable<Tuple<Action, string>> actions)
        {
            InitializeComponent();

            tuples = actions == null ? null : new List<Tuple<Action, string>>(actions);


            if (tuples != null && tuples.Count != 0)
            {
                Text = tuples[0].Item2;
            }

            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;

            backgroundWorker.RunWorkerAsync();
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgressBar_Main.Style = ProgressBarStyle.Continuous;
            ProgressBar_Main.MarqueeAnimationSpeed = 0;

            Close();
        }

        /// <summary>
        /// Runs on a thread-pool thread, so nothing here may touch a control directly. It previously assigned
        /// ProgressBar_Main.Style, MarqueeAnimationSpeed and Text from this thread, which is an illegal
        /// cross-thread control access - undefined at best, an InvalidOperationException at worst.
        /// <para>
        /// The two progress-bar assignments are simply gone: the designer and every constructor already put the
        /// bar in marquee mode, so they were redundant as well as unsafe. The title still changes per action,
        /// now marshalled through <see cref="SetText"/>.
        /// </para>
        /// </summary>
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (tuples == null)
            {
                return;
            }

            foreach (Tuple<Action, string> tuple in tuples)
            {
                SetText(tuple.Item2);

                if (tuple.Item1 != null)
                {
                    tuple.Item1.Invoke();
                }
            }
        }

        /// <summary>
        /// Sets the window title from whichever thread the work is running on. The owning thread is compared by
        /// id captured at construction rather than through
        /// <see cref="System.Windows.Forms.Control.InvokeRequired"/>, which reports false while the handle does
        /// not exist yet and would let the assignment happen cross-thread anyway.
        /// <para>
        /// An update arriving before the handle exists cannot be posted, so it is held in
        /// <see cref="text_Pending"/> and applied by <see cref="OnHandleCreated"/>. Dropping it instead would
        /// leave the dialog showing the first action's title for the whole of a later one - with a fast first
        /// action the worker can easily reach the second before <c>ShowDialog</c> creates the handle.
        /// </para>
        /// </summary>
        private void SetText(string text)
        {
            if (Thread.CurrentThread.ManagedThreadId == ownerThreadId)
            {
                Text = text;
                return;
            }

            try
            {
                if (IsDisposed)
                {
                    return;
                }

                // Locked against OnHandleCreated. Unsynchronized, the two could interleave so that neither
                // applies the title: this thread reads IsHandleCreated false, the UI thread then runs
                // OnHandleCreated and finds nothing pending, and only afterwards does this thread publish -
                // stranding the value with nobody left to consume it. Inside the lock the handle cannot be
                // created between the test and the publish, and OnHandleCreated always observes a handle, so
                // exactly one of the two paths takes the title.
                lock (textLock)
                {
                    if (!IsHandleCreated)
                    {
                        text_Pending = text;
                        text_PendingSet = true;
                        return;
                    }
                }

                // Posted outside the lock: no need to hold it across a cross-thread post.
                BeginInvoke(new Action(() => Text = text));
            }
            catch (InvalidAsynchronousStateException)
            {
                // the form's thread has gone away mid-run; there is nothing left to update
            }
            catch (ObjectDisposedException)
            {
                // same
            }
        }

        /// <summary>
        /// Applies whatever title the worker set while there was no handle to post to. Runs on the owning
        /// thread, so the assignment is safe here.
        /// </summary>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            // base first, so IsHandleCreated is already true inside the lock: a worker that gets the lock after
            // this point sees the handle and posts instead of publishing a value nothing would read.
            string text_Pending_Temp;
            bool text_PendingSet_Temp;
            lock (textLock)
            {
                text_Pending_Temp = text_Pending;
                text_PendingSet_Temp = text_PendingSet;
                text_Pending = null;
                text_PendingSet = false;
            }

            if (text_PendingSet_Temp)
            {
                Text = text_Pending_Temp;
            }
        }

        public static void Show(string name, Action action)
        {
            using (MarqueeProgressForm marqueeProgressForm = new MarqueeProgressForm(name, action))
            {
                if (marqueeProgressForm.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }

        public static void Show(IEnumerable<Tuple<Action, string>> actions)
        {
            using (MarqueeProgressForm marqueeProgressForm = new MarqueeProgressForm(actions))
            {
                if (marqueeProgressForm.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }

        public static void Show(string name, Action action, IWin32Window owner)
        {
            using (MarqueeProgressForm marqueeProgressForm = new MarqueeProgressForm(name, action))
            {
                if (marqueeProgressForm.ShowDialog(owner) == DialogResult.OK)
                {

                }
            }
        }

        public static void Show(IEnumerable<Tuple<Action, string>> actions, IWin32Window owner)
        {
            using (MarqueeProgressForm marqueeProgressForm = new MarqueeProgressForm(actions))
            {
                if (marqueeProgressForm.ShowDialog(owner) == DialogResult.OK)
                {

                }
            }
        }
    }
}
