using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Input;

namespace SAM.Core.Windows
{
    public static partial class EventHandler
    {
        public static void ControlText_NumberOnly(object sender, KeyPressEventArgs e)
        {
            string separator_String = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            char separator = '.';
            if (!string.IsNullOrWhiteSpace(separator_String))
                separator = separator_String.Trim()[0];

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != separator))
                e.Handled = true;

            // only allow one decimal point
            string text = (sender as Control)?.Text;
            if ((e.KeyChar == separator) && !string.IsNullOrWhiteSpace(text) && (text.IndexOf(separator) > -1))
                e.Handled = true;
        }

        public static void ControlText_NumberOnly(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9.-]+").IsMatch(e.Text);
        }

    }
}