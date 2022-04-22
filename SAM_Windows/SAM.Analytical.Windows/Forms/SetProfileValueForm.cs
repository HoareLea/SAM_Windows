using System.Windows.Forms;

namespace SAM.Analytical.Windows.Forms
{
    public partial class SetProfileValueForm : Form
    {
        public SetProfileValueForm()
        {
            InitializeComponent();

            TextBox_Value.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_NumberOnly);
            TextBox_StartIndex.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_IntegerOnly);
            TextBox_Count.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_IntegerOnly);
        }

        public SetProfileValueForm(int startIndex, int count, double? value)
        {
            InitializeComponent();

            TextBox_Value.Text = value == null || !value.HasValue ? null :value.Value.ToString();
            TextBox_StartIndex.Text = startIndex.ToString();
            TextBox_Count.Text = count.ToString();
        }

        public int StartIndex
        {
            get
            {
                if (!Core.Query.TryConvert(TextBox_StartIndex.Text, out int value))
                {
                    return -1;
                }

                return value;
            }

            set
            {
                TextBox_StartIndex.Text = value.ToString();
            }
        }

        public int Count
        {
            get
            {
                if (!Core.Query.TryConvert(TextBox_Count.Text, out int value))
                {
                    return -1;
                }

                return value;
            }

            set
            {
                TextBox_Count.Text = value.ToString();
            }
        }

        public double? Value
        {
            get
            {
                if (!Core.Query.TryConvert(TextBox_Value.Text, out double value))
                {
                    return null;
                }

                return value;
            }

            set
            {
                TextBox_Value.Text = value.ToString();
            }
        }

        private void SetProfileValueForm_Load(object sender, System.EventArgs e)
        {
            TextBox_Value.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_NumberOnly);
            TextBox_StartIndex.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_IntegerOnly);
            TextBox_Count.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_IntegerOnly);
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

        private void CheckBox_Append_CheckedChanged(object sender, System.EventArgs e)
        {
            TextBox_StartIndex.Enabled = !CheckBox_Append.Checked;
            Label_StartIndex.Enabled = !CheckBox_Append.Checked;
        }
    }
}
