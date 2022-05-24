
namespace SAM.Core.Windows.Forms
{
    partial class MarqueeProgressForm
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
            this.ProgressBar_Main = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // ProgressBar_Main
            // 
            this.ProgressBar_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar_Main.Location = new System.Drawing.Point(9, 46);
            this.ProgressBar_Main.Margin = new System.Windows.Forms.Padding(4);
            this.ProgressBar_Main.MarqueeAnimationSpeed = 30;
            this.ProgressBar_Main.Name = "ProgressBar_Main";
            this.ProgressBar_Main.Size = new System.Drawing.Size(394, 35);
            this.ProgressBar_Main.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.ProgressBar_Main.TabIndex = 2;
            // 
            // MarqueeProgressForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(416, 94);
            this.ControlBox = false;
            this.Controls.Add(this.ProgressBar_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MarqueeProgressForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Loading";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar ProgressBar_Main;
    }
}