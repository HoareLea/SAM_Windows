using System;
using System.Windows.Forms;

namespace SAM.Core.Windows.Forms
{
    public partial class ProgressForm : Form
    {
        private string caption;
        private int maxLength = 50;
        
        public ProgressForm()
        {
            InitializeComponent();
        }

        public ProgressForm(string name, int max)
        {
            InitializeComponent();
            Text = name;

            ProgressBar_Main.Minimum = 0;
            ProgressBar_Main.Maximum = max;
            ProgressBar_Main.Step = 1;
            ProgressBar_Main.Value = 0;

            Show(new WindowHandle(System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle));
            
            Application.DoEvents();
        }

        private void SimpleProgressForm_Load(object sender, EventArgs e)
        {
            ProgressBar_Main.Refresh();
        }

        public void Update(string text, bool increment = true)
        {
            string text_Temp = text;
            if (text_Temp == null)
                text_Temp = string.Empty;

            if(increment)
            {
                ProgressBar_Main.PerformStep();
                caption = text_Temp;
                text_Temp = string.Empty;
            }

            text_Temp = caption + " [" + ProgressBar_Main.Value + "/" + ProgressBar_Main.Maximum + "] " + text_Temp;

            if (text_Temp.Length > maxLength)
                text_Temp = text_Temp.Substring(0, maxLength) + "...";

            Label_Description.Text = text_Temp;

            Refresh();
            BringToFront();
            Focus();
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
                return caption;
            }
            set
            {
                caption = value;
            }
        }
    }
}
