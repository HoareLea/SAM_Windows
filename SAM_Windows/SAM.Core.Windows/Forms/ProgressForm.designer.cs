namespace SAM.Core.Windows.Forms
{
    partial class ProgressForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Label_Description = new System.Windows.Forms.Label();
            this.ProgressBar_Main = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // Label_Description
            // 
            this.Label_Description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Description.Location = new System.Drawing.Point(16, 19);
            this.Label_Description.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Description.Name = "Label_Description";
            this.Label_Description.Size = new System.Drawing.Size(391, 21);
            this.Label_Description.TabIndex = 0;
            this.Label_Description.Text = "Waiting...";
            // 
            // ProgressBar_Main
            // 
            this.ProgressBar_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar_Main.Location = new System.Drawing.Point(13, 50);
            this.ProgressBar_Main.Margin = new System.Windows.Forms.Padding(4);
            this.ProgressBar_Main.Name = "ProgressBar_Main";
            this.ProgressBar_Main.Size = new System.Drawing.Size(394, 35);
            this.ProgressBar_Main.TabIndex = 1;
            // 
            // SimpleProgressForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(420, 98);
            this.ControlBox = false;
            this.Controls.Add(this.ProgressBar_Main);
            this.Controls.Add(this.Label_Description);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SimpleProgressForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Loading";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SimpleProgressForm_FormClosing);
            this.Load += new System.EventHandler(this.SimpleProgressForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Label_Description;
        private System.Windows.Forms.ProgressBar ProgressBar_Main;
    }
}