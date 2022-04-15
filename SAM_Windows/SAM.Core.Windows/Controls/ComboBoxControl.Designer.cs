
namespace SAM.Core.Windows
{
    partial class ComboBoxControl
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
            this.ComboBox_Main = new System.Windows.Forms.ComboBox();
            this.Label_Description = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ComboBox_Main
            // 
            this.ComboBox_Main.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBox_Main.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Main.FormattingEnabled = true;
            this.ComboBox_Main.Location = new System.Drawing.Point(3, 24);
            this.ComboBox_Main.Name = "ComboBox_Main";
            this.ComboBox_Main.Size = new System.Drawing.Size(191, 24);
            this.ComboBox_Main.TabIndex = 5;
            // 
            // Label_Description
            // 
            this.Label_Description.AutoSize = true;
            this.Label_Description.Location = new System.Drawing.Point(3, 4);
            this.Label_Description.Name = "Label_Description";
            this.Label_Description.Size = new System.Drawing.Size(0, 17);
            this.Label_Description.TabIndex = 6;
            // 
            // ComboBoxControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.Label_Description);
            this.Controls.Add(this.ComboBox_Main);
            this.Name = "ComboBoxControl";
            this.Size = new System.Drawing.Size(197, 54);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboBox_Main;
        private System.Windows.Forms.Label Label_Description;
    }
}
