using System.Collections.Generic;
using System.Windows.Forms;

namespace SAM.Analytical.Windows.Forms
{
    public partial class SetProfileForm : Form
    {
        public SetProfileForm()
        {
            InitializeComponent();
        }

        public SetProfileForm(int startIndex, IEnumerable<Profile> profiles)
        {
            InitializeComponent();

            TextBoxControl_StartIndex.SetValue(startIndex);

            ComboBoxControl_Profile.AddRange(profiles, new System.Func<Profile, string>((Profile x) => x?.Name));
        }

        public int StartIndex
        {
            get
            {

                return TextBoxControl_StartIndex.GetValue<int>();
            }

            set
            {
                TextBoxControl_StartIndex.SetValue(value);
            }
        }

        public bool Append
        {
            get
            {
                return CheckBox_Append.Checked;
            }

            set
            {
                CheckBox_Append.Checked = value;
            }
        }

        public Profile Profile
        {
            get
            {
                return ComboBoxControl_Profile.GetSelectedItem<Profile>();
            }

            set
            {
                ComboBoxControl_Profile.SetSelectedItem(value);
            }
        }

        private void SetProfileForm_Load(object sender, System.EventArgs e)
        {
        }

        private void Button_OK_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;

            Close();
        }

        private void Button_Cancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

        private void CheckBox_Append_CheckedChanged(object sender, System.EventArgs e)
        {
            TextBoxControl_StartIndex.Enabled = !CheckBox_Append.Checked;
        }
    }
}
