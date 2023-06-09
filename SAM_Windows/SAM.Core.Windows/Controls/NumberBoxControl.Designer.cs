
namespace SAM.Core.Windows
{
    partial class NumberBoxControl
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
            this.SuspendLayout();
            // 
            // HintedTextBox_Main
            // 
            this.TextBox_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_Main.Location = new System.Drawing.Point(0, 0);
            this.TextBox_Main.Name = "HintedTextBox_Main";
            this.TextBox_Main.Size = new System.Drawing.Size(100, 22);
            this.TextBox_Main.TabIndex = 0;
            // 
            // NumberBoxControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.TextBox_Main);
            this.Name = "NumberBoxControl";
            this.Size = new System.Drawing.Size(100, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBox_Main;
    }
}
