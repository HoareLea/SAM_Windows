using System;

namespace SAM.Core.Windows
{
    public class HintedTextBox : System.Windows.Forms.TextBox
    {
        private System.Drawing.Color defaultColor;
        private string hint;

        public string Hint
        {
            get
            {
                return hint;
            }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    // change style   
                    ForeColor = System.Drawing.Color.Gray;
                    // Add text
                    hint = value;
                    Text = value;
                }
            }
        }
        public HintedTextBox()
        {
            // get default color of text
            defaultColor = ForeColor;
            // Add event handler for when the control gets focus
            GotFocus += (object sender, EventArgs e) =>
            {
                Text = string.Empty;
                ForeColor = defaultColor;
            };

            // add event handling when focus is lost
            LostFocus += (object sender, EventArgs e) => {
                if (string.IsNullOrEmpty(Text) || Text == Hint)
                {
                    ForeColor = System.Drawing.Color.Gray;
                    Text = Hint;
                }
                else
                {
                    ForeColor = defaultColor;
                }
            };
        }
    }
}

