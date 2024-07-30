
namespace SAM.Core.Windows
{
    partial class AddressControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TextBox_Street = new System.Windows.Forms.TextBox();
            this.Label_Street = new System.Windows.Forms.Label();
            this.TextBox_City = new System.Windows.Forms.TextBox();
            this.Label_City = new System.Windows.Forms.Label();
            this.TextBox_PostalCode = new System.Windows.Forms.TextBox();
            this.Label_PostalCode = new System.Windows.Forms.Label();
            this.Label_Country = new System.Windows.Forms.Label();
            this.ComboBox_Country = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // TextBox_Street
            // 
            this.TextBox_Street.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Street.Location = new System.Drawing.Point(111, 9);
            this.TextBox_Street.Name = "TextBox_Street";
            this.TextBox_Street.Size = new System.Drawing.Size(186, 22);
            this.TextBox_Street.TabIndex = 0;
            // 
            // Label_Street
            // 
            this.Label_Street.AutoSize = true;
            this.Label_Street.Location = new System.Drawing.Point(17, 12);
            this.Label_Street.Name = "Label_Street";
            this.Label_Street.Size = new System.Drawing.Size(50, 17);
            this.Label_Street.TabIndex = 1;
            this.Label_Street.Text = "Street:";
            // 
            // TextBox_City
            // 
            this.TextBox_City.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_City.Location = new System.Drawing.Point(111, 37);
            this.TextBox_City.Name = "TextBox_City";
            this.TextBox_City.Size = new System.Drawing.Size(186, 22);
            this.TextBox_City.TabIndex = 1;
            // 
            // Label_City
            // 
            this.Label_City.AutoSize = true;
            this.Label_City.Location = new System.Drawing.Point(17, 40);
            this.Label_City.Name = "Label_City";
            this.Label_City.Size = new System.Drawing.Size(35, 17);
            this.Label_City.TabIndex = 1;
            this.Label_City.Text = "City:";
            // 
            // TextBox_PostalCode
            // 
            this.TextBox_PostalCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_PostalCode.Location = new System.Drawing.Point(111, 65);
            this.TextBox_PostalCode.Name = "TextBox_PostalCode";
            this.TextBox_PostalCode.Size = new System.Drawing.Size(186, 22);
            this.TextBox_PostalCode.TabIndex = 2;
            // 
            // Label_PostalCode
            // 
            this.Label_PostalCode.AutoSize = true;
            this.Label_PostalCode.Location = new System.Drawing.Point(17, 68);
            this.Label_PostalCode.Name = "Label_PostalCode";
            this.Label_PostalCode.Size = new System.Drawing.Size(88, 17);
            this.Label_PostalCode.TabIndex = 1;
            this.Label_PostalCode.Text = "Postal Code:";
            // 
            // Label_Country
            // 
            this.Label_Country.AutoSize = true;
            this.Label_Country.Location = new System.Drawing.Point(17, 96);
            this.Label_Country.Name = "Label_Country";
            this.Label_Country.Size = new System.Drawing.Size(61, 17);
            this.Label_Country.TabIndex = 1;
            this.Label_Country.Text = "Country:";
            // 
            // ComboBox_Country
            // 
            this.ComboBox_Country.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBox_Country.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Country.FormattingEnabled = true;
            this.ComboBox_Country.Location = new System.Drawing.Point(111, 93);
            this.ComboBox_Country.Name = "ComboBox_Country";
            this.ComboBox_Country.Size = new System.Drawing.Size(186, 24);
            this.ComboBox_Country.TabIndex = 3;
            // 
            // AddressControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.ComboBox_Country);
            this.Controls.Add(this.Label_Country);
            this.Controls.Add(this.Label_PostalCode);
            this.Controls.Add(this.Label_City);
            this.Controls.Add(this.Label_Street);
            this.Controls.Add(this.TextBox_PostalCode);
            this.Controls.Add(this.TextBox_City);
            this.Controls.Add(this.TextBox_Street);
            this.Name = "AddressControl";
            this.Size = new System.Drawing.Size(300, 124);
            this.Load += new System.EventHandler(this.AddressControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBox_Street;
        private System.Windows.Forms.Label Label_Street;
        private System.Windows.Forms.TextBox TextBox_City;
        private System.Windows.Forms.Label Label_City;
        private System.Windows.Forms.TextBox TextBox_PostalCode;
        private System.Windows.Forms.Label Label_PostalCode;
        private System.Windows.Forms.Label Label_Country;
        private System.Windows.Forms.ComboBox ComboBox_Country;
    }
}
