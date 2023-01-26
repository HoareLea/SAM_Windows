using System.Windows.Forms;

namespace SAM.Core.Windows
{
    public static partial class EventHandler
    {
        public static void ControlText_IntegerOnly(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

    }
}