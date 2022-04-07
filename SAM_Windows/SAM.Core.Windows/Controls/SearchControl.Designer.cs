
namespace SAM.Core.Windows
{
    partial class SearchControl
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
            this.ListBox_Texts = new System.Windows.Forms.ListBox();
            this.TextBox_Text = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ListBox_Texts
            // 
            this.ListBox_Texts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBox_Texts.FormattingEnabled = true;
            this.ListBox_Texts.ItemHeight = 16;
            this.ListBox_Texts.Location = new System.Drawing.Point(3, 31);
            this.ListBox_Texts.Name = "ListBox_Texts";
            this.ListBox_Texts.Size = new System.Drawing.Size(194, 260);
            this.ListBox_Texts.TabIndex = 3;
            this.ListBox_Texts.SelectedIndexChanged += new System.EventHandler(this.ListBox_Texts_SelectedIndexChanged);
            this.ListBox_Texts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_Texts_MouseDoubleClick);
            // 
            // TextBox_Text
            // 
            this.TextBox_Text.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Text.Location = new System.Drawing.Point(3, 3);
            this.TextBox_Text.Name = "TextBox_Text";
            this.TextBox_Text.Size = new System.Drawing.Size(194, 22);
            this.TextBox_Text.TabIndex = 2;
            this.TextBox_Text.TextChanged += new System.EventHandler(this.TextBox_Text_TextChanged);
            this.TextBox_Text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_Text_KeyDown);
            // 
            // SearchControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.ListBox_Texts);
            this.Controls.Add(this.TextBox_Text);
            this.Name = "SearchControl";
            this.Size = new System.Drawing.Size(200, 300);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListBox_Texts;
        private System.Windows.Forms.TextBox TextBox_Text;
    }
}
