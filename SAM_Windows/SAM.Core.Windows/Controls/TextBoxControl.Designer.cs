
namespace SAM.Core.Windows
{
    partial class TextBoxControl
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
            this.TextBox_Main = new System.Windows.Forms.TextBox();
            this.Label_Description = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TextBox_Main
            // 
            this.TextBox_Main.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Main.Location = new System.Drawing.Point(3, 28);
            this.TextBox_Main.Name = "TextBox_Main";
            this.TextBox_Main.Size = new System.Drawing.Size(191, 22);
            this.TextBox_Main.TabIndex = 0;
            this.TextBox_Main.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_Main_KeyPress);
            // 
            // Label_Description
            // 
            this.Label_Description.AutoSize = true;
            this.Label_Description.Location = new System.Drawing.Point(3, 2);
            this.Label_Description.Name = "Label_Description";
            this.Label_Description.Size = new System.Drawing.Size(0, 17);
            this.Label_Description.TabIndex = 1;
            // 
            // TextBoxControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.Label_Description);
            this.Controls.Add(this.TextBox_Main);
            this.Name = "TextBoxControl";
            this.Size = new System.Drawing.Size(197, 57);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBox_Main;
        private System.Windows.Forms.Label Label_Description;
    }
}
