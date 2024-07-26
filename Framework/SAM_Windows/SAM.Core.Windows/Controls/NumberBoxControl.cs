using System.Windows.Forms;

namespace SAM.Core.Windows
{
    public partial class NumberBoxControl : System.Windows.Forms.UserControl
    {
        private string string_NaN = string.Empty;

        private string string_PositiveInfinity = string.Empty;

        private string string_NegativeInfinity = string.Empty;

        private double tolerance = Core.Tolerance.MacroDistance;

        public event System.EventHandler ValueChanged;

        public NumberBoxControl()
        {
            InitializeComponent();

            TextBox_Main.KeyPress += new KeyPressEventHandler(EventHandler.ControlText_NumberOnly);
            TextBox_Main.TextChanged += new System.EventHandler(HintedTextBox_Main_TextChanged);

            TextBox_Main.TextAlign = HorizontalAlignment.Right; 
        }

        private void HintedTextBox_Main_TextChanged(object sender, System.EventArgs e)
        {
            ValueChanged.Invoke(this, e);
        }

        public string String_NaN
        {
            get
            {
                return string_NaN;
            }

            set
            {
                string_NaN = value;
            }
        }

        public string String_PositiveInfinity
        {
            get
            {
                return string_PositiveInfinity;
            }

            set
            {
                string_PositiveInfinity = value;
            }
        }

        public string String_NegativeInfinity
        {
            get
            {
                return string_NegativeInfinity;
            }

            set
            {
                string_NegativeInfinity = value;
            }
        }

        public double Tolerance
        {
            get
            {
                return tolerance;
            }

            set
            {
                tolerance = value;
            }
        }

        public double Value
        {
            get
            {
                return GetValue();
            }

            set
            {
                SetValue(value);
            }
        }

        public HorizontalAlignment HorizontalAlignment
        {
            get
            {
                return TextBox_Main.TextAlign;
            }

            set
            {
                TextBox_Main.TextAlign = value;
            }
        }

        public double GetValue()
        {
            string text = TextBox_Main.Text;
            if(string.IsNullOrEmpty(text))
            {
                return double.NaN;
            }

            if (string_NaN != null && text == string_NaN)
            {
                return double.NaN;
            }

            if(text == double.NaN.ToString())
            {
                return double.NaN;
            }

            if (string_PositiveInfinity != null && text == string_PositiveInfinity)
            {
                return double.PositiveInfinity;
            }

            if (text == double.PositiveInfinity.ToString())
            {
                return double.PositiveInfinity;
            }

            if (string_NegativeInfinity != null && text == string_NegativeInfinity)
            {
                return double.NegativeInfinity;
            }

            if (text == double.NegativeInfinity.ToString())
            {
                return double.NegativeInfinity;
            }

            if (!Core.Query.TryConvert(TextBox_Main.Text, out double result))
            {
                return double.NaN;
            }

            if(!(TextBox_Main.Tag is double))
            {
                return result;
            }

            double value = (double)TextBox_Main.Tag;
            if(double.IsNaN(value) || double.IsInfinity(value))
            {
                return result;
            }

            if (result.AlmostEqual(value, tolerance))
            {
                return value;
            }

            return result;
        }

        public void SetValue(double value)
        {
            TextBox_Main.Tag = value;
            
            if(double.IsNaN(value))
            {
                TextBox_Main.Text = string_NaN != null ? string_NaN : value.ToString();
                return;
            }

            if (double.IsPositiveInfinity(value))
            {
                TextBox_Main.Text = string_PositiveInfinity != null ? string_PositiveInfinity : value.ToString();
                return;
            }

            if (double.IsNegativeInfinity(value))
            {
                TextBox_Main.Text = string_NegativeInfinity != null ? string_NegativeInfinity : value.ToString();
                return;
            }

            double displayValue = Core.Query.Round(value, tolerance);

            TextBox_Main.Text = displayValue.ToString();
        }
    }
}
