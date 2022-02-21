using System;
using System.Windows.Forms;

namespace SAM.Core.Windows
{
    public partial class SimpleProgressForm : Form
    {
        private string pCaption;
        private int pMaxLength = 50;
        
        public SimpleProgressForm()
        {
            InitializeComponent();
        }

        public SimpleProgressForm(string WindowName, string Caption, int Max)
        {
            InitializeComponent();
            Text = WindowName;
            pCaption = Caption;

            ProgressBar_Main.Minimum = 0;
            ProgressBar_Main.Maximum = Max;
            ProgressBar_Main.Step = 1;
            ProgressBar_Main.Value = 0;

            Show(new WindowHandle(System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle));
            
            Application.DoEvents();
        }

        public SimpleProgressForm(string WindowName, string Caption)
        {
            InitializeComponent();
            Text = WindowName;
            pCaption = Caption;

            ProgressBar_Main.Minimum = 0;
            ProgressBar_Main.Maximum = 100;
            ProgressBar_Main.Step = 1;
            ProgressBar_Main.Value = 0;

            ProgressBar_Main.Style = ProgressBarStyle.Marquee;

            Show(new WindowHandle(System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle));

            Application.DoEvents();
        }

        private void SimpleProgressForm_Load(object sender, EventArgs e)
        {
            ProgressBar_Main.Refresh();
        }

        public void Increment(string Text)
        {
            string aText = Text;
            if (aText == null)
                aText = string.Empty;

            if (ProgressBar_Main.Style != ProgressBarStyle.Marquee)
            {
                ProgressBar_Main.PerformStep();
                aText = pCaption + " [" + ProgressBar_Main.Value + "/" + ProgressBar_Main.Maximum + "] " + aText;
            }
            else
            {
                aText = pCaption + " [...] " + aText;
            }

            if (aText.Length > pMaxLength)
                aText = aText.Substring(0, pMaxLength) + "...";

            Label_Description.Text = aText;

            this.Refresh();
            this.BringToFront();
            this.Focus();
            Application.DoEvents();
        }

        private void SimpleProgressForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
        }

        public string Caption
        {
            get
            {
                return pCaption;
            }
            set
            {
                pCaption = value;
            }
        }
    }
}
