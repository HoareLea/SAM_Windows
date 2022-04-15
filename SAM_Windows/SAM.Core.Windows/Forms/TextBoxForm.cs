using System;
using System.Windows.Forms;

namespace SAM.Core.Windows.Forms
{
    public partial class TextBoxForm<T> : Form
    {
        public new event KeyPressEventHandler TextBoxKeyPress;
        
        public TextBoxForm()
        {
            InitializeComponent();
        }

        public TextBoxForm(string name, string description)
        {
            InitializeComponent();

            Text = name;
            TextBoxControl_Main.Description = description;
        }

        public T Value
        {
            get
            {
                return TextBoxControl_Main.GetValue<T>();
            }

            set
            {
                TextBoxControl_Main.SetValue(value);
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

        private void OnTextBoxKeyPress(KeyPressEventArgs e)
        {
            KeyPressEventHandler keyPressEventHandler;

            keyPressEventHandler = TextBoxKeyPress;
            if (keyPressEventHandler != null)
            {
                keyPressEventHandler(this, e);
            }
        }

        private void TextBoxForm_Load(object sender, EventArgs e)
        {
            TextBoxControl_Main.TextBoxKeyPress += TextBoxControl_Main_TextBoxKeyPress;
        }

        private void TextBoxControl_Main_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            OnTextBoxKeyPress(e);
        }
    }
}
