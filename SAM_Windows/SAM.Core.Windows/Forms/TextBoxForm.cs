using System;
using System.Windows.Forms;

namespace SAM.Core.Windows.Forms
{
    public partial class TextBoxForm<T> : Form
    {
        public TextBoxForm()
        {
            InitializeComponent();

            if (Core.Query.IsNumeric(typeof(T)))
            {
                TextBox_Value.KeyPress += EventHandler.ControlText_NumberOnly;
            }
        }

        public TextBoxForm(string name, string description)
        {
            InitializeComponent();

            Text = name;
            Label_Description.Text = description;

            if(Core.Query.IsNumeric(typeof(T)))
            {
                TextBox_Value.KeyPress += EventHandler.ControlText_NumberOnly;
            }
        }

        public T Value
        {
            get
            {
                if(!Core.Query.TryConvert(TextBox_Value.Text, out T result))
                {
                    return default;
                }

                return result;
            }

            set
            {
                TextBox_Value.Text = value?.ToString();
                TextBox_Value.SelectAll();
            }
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
    }
}
