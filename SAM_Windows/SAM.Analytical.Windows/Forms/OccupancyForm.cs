using System;
using System.Windows.Forms;

namespace SAM.Analytical.Windows.Forms
{
    public partial class OccupancyForm : Form
    {
        public OccupancyForm()
        {
            InitializeComponent();
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public Space Space
        {
            get
            {
                return occupancyControl_Main.Space;
            }

            set
            {
                occupancyControl_Main.Space = value;
            }
        }
    }
}
