using System;
using System.Windows.Forms;

namespace SAM.Core.Windows.Forms
{
    public partial class LogForm : Form
    {
        private Log log;
        
        public LogForm()
        {
            InitializeComponent();
        }

        public LogForm(Log log)
        {
            InitializeComponent();

            this.log = log;
        }

        private void LoadLog()
        {
            DataGridView_Main.Rows.Clear();

            if (log == null)
            {
                return;
            }

            foreach(LogRecord logRecord in log)
            {
                DataGridView_Main.Rows.Add(logRecord.LogRecordType.Bitmap(), logRecord.Text);
            }
        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            LoadLog();
        }
    }
}
