using System.ComponentModel;
using System.Windows.Forms;

namespace SAM.Core.Windows
{
    public partial class TextBoxControl : UserControl
    {
        public TextBoxControl()
        {
            InitializeComponent();
        }

        [Browsable(true), Category("Key")]
        public new event KeyPressEventHandler TextBoxKeyPress;

        [Description("Description for value"), Category("Data")]
        public string Description
        {
            get
            {
                return Label_Description.Text;
            }

            set
            {
                Label_Description.Text = value;
            }
        }

        public T GetValue<T>()
        {
            if (!Core.Query.TryConvert(TextBox_Main.Text, out T result))
            {
                return default;
            }

            return result;
        }

        public void SetValue<T>(T value)
        {
            TextBox_Main.Text = value?.ToString();
            TextBox_Main.SelectAll();

            TextBox_Main.KeyPress -= EventHandler.ControlText_NumberOnly;
            TextBox_Main.KeyPress -= EventHandler.ControlText_IntegerOnly;

            if (typeof(T) == typeof(int) || typeof(T) == typeof(long) || typeof(T) == typeof(short))
            {
                TextBox_Main.KeyPress += EventHandler.ControlText_IntegerOnly;
            }
            else if (Core.Query.IsNumeric(typeof(T)))
            {
                TextBox_Main.KeyPress += EventHandler.ControlText_NumberOnly;
            }
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

        private void TextBox_Main_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnTextBoxKeyPress(e);
        }
        
        private void TextBoxControl_Load(object sender, System.EventArgs e)
        {
            TextBox_Main.Focus();
        }
    }
}
