using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SAM.Core.Windows.Forms
{
    public partial class MarqueeProgressForm : Form
    {
        private readonly BackgroundWorker backgroundWorker = new BackgroundWorker();
        private Action action;

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

            Text = name;

            this.action = action;

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

            if(action != null)
            {
                action.Invoke();
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

        public static void Show(string name, Action action, IWin32Window owner)
        {
            using (MarqueeProgressForm marqueeProgressForm = new MarqueeProgressForm(name, action))
            {
                if (marqueeProgressForm.ShowDialog(owner) == DialogResult.OK)
                {

                }
            }
        }
    }
}
