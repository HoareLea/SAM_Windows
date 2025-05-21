using System.Windows.Forms;
using System.Windows.Input;

namespace SAM.Core.Windows
{
    public static partial class EventHandler
    {
        public static void ControlText_IntegerOnly(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        public static void ControlText_IntegerOnly(object sender, TextCompositionEventArgs e)
        {
            if(e.Text != null)
            {
                foreach(char @char in e.Text)
                {
                    if(!char.IsDigit(@char))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

    }
}