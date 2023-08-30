using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace SAM.Core.Windows.Forms
{
    public partial class MarqueeProgressForm : Form
    {
        private readonly BackgroundWorker backgroundWorker = new BackgroundWorker();
        private List<Tuple<Action, string>> tuples;

        public MarqueeProgressForm(string name)
        {
            InitializeComponent();

            Text = name;

            ProgressBar_Main.Style = ProgressBarStyle.Marquee;
            ProgressBar_Main.MarqueeAnimationSpeed = 30;
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

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ProgressBar_Main.Style = ProgressBarStyle.Marquee;
            ProgressBar_Main.MarqueeAnimationSpeed = 30;

            if(tuples != null)
            {
                foreach(Tuple<Action, string> tuple in tuples)
                {
                    Text = tuple.Item2;
                    if(tuple.Item1 != null)
                    {
                        tuple.Item1.Invoke();
                    }
                }

                
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
