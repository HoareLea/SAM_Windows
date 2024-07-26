
namespace SAM.Core.Windows
{
    partial class LocationControl
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
            this.TextBox_Longitude = new System.Windows.Forms.TextBox();
            this.Label_Longitude = new System.Windows.Forms.Label();
            this.TextBox_Latitude = new System.Windows.Forms.TextBox();
            this.Label_Latitude = new System.Windows.Forms.Label();
            this.TextBox_Elevation = new System.Windows.Forms.TextBox();
            this.Label_Elevation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TextBox_Longitude
            // 
            this.TextBox_Longitude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Longitude.Location = new System.Drawing.Point(111, 9);
            this.TextBox_Longitude.Name = "TextBox_Longitude";
            this.TextBox_Longitude.Size = new System.Drawing.Size(186, 22);
            this.TextBox_Longitude.TabIndex = 0;
            // 
            // Label_Longitude
            // 
            this.Label_Longitude.AutoSize = true;
            this.Label_Longitude.Location = new System.Drawing.Point(17, 12);
            this.Label_Longitude.Name = "Label_Longitude";
            this.Label_Longitude.Size = new System.Drawing.Size(75, 17);
            this.Label_Longitude.TabIndex = 1;
            this.Label_Longitude.Text = "Longitude:";
            // 
            // TextBox_Latitude
            // 
            this.TextBox_Latitude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Latitude.Location = new System.Drawing.Point(111, 37);
            this.TextBox_Latitude.Name = "TextBox_Latitude";
            this.TextBox_Latitude.Size = new System.Drawing.Size(186, 22);
            this.TextBox_Latitude.TabIndex = 1;
            // 
            // Label_Latitude
            // 
            this.Label_Latitude.AutoSize = true;
            this.Label_Latitude.Location = new System.Drawing.Point(17, 40);
            this.Label_Latitude.Name = "Label_Latitude";
            this.Label_Latitude.Size = new System.Drawing.Size(63, 17);
            this.Label_Latitude.TabIndex = 1;
            this.Label_Latitude.Text = "Latitude:";
            // 
            // TextBox_Elevation
            // 
            this.TextBox_Elevation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Elevation.Location = new System.Drawing.Point(111, 65);
            this.TextBox_Elevation.Name = "TextBox_Elevation";
            this.TextBox_Elevation.Size = new System.Drawing.Size(186, 22);
            this.TextBox_Elevation.TabIndex = 2;
            // 
            // Label_Elevation
            // 
            this.Label_Elevation.AutoSize = true;
            this.Label_Elevation.Location = new System.Drawing.Point(17, 68);
            this.Label_Elevation.Name = "Label_Elevation";
            this.Label_Elevation.Size = new System.Drawing.Size(70, 17);
            this.Label_Elevation.TabIndex = 1;
            this.Label_Elevation.Text = "Elevation:";
            // 
            // LocationControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.Label_Elevation);
            this.Controls.Add(this.Label_Latitude);
            this.Controls.Add(this.Label_Longitude);
            this.Controls.Add(this.TextBox_Elevation);
            this.Controls.Add(this.TextBox_Latitude);
            this.Controls.Add(this.TextBox_Longitude);
            this.Name = "LocationControl";
            this.Size = new System.Drawing.Size(300, 95);
            this.Load += new System.EventHandler(this.LocationControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBox_Longitude;
        private System.Windows.Forms.Label Label_Longitude;
        private System.Windows.Forms.TextBox TextBox_Latitude;
        private System.Windows.Forms.Label Label_Latitude;
        private System.Windows.Forms.TextBox TextBox_Elevation;
        private System.Windows.Forms.Label Label_Elevation;
    }
}
