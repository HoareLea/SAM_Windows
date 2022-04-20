using System;
using System.Windows.Forms;

namespace SAM.Analytical.Windows.Forms
{
    public partial class ProfileForm : Form
    {
        public ProfileForm()
        {
            InitializeComponent();
        }

        public ProfileForm(Profile profile)
        {
            InitializeComponent();

            ProfileControl_Main.Profile = profile;
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            Close();
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {

        }
    }
}
