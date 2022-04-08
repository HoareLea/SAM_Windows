
namespace SAM.Core.Windows.Forms
{
    partial class AddressAndLocationForm
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
            this.Button_OK = new System.Windows.Forms.Button();
            this.Button_Cancel = new System.Windows.Forms.Button();
            this.GroupBox_Address = new System.Windows.Forms.GroupBox();
            this.AddressControl_Main = new SAM.Core.Windows.AddressControl();
            this.GroupBox_Location = new System.Windows.Forms.GroupBox();
            this.LocationControl_Main = new SAM.Core.Windows.LocationControl();
            this.GroupBox_Address.SuspendLayout();
            this.GroupBox_Location.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button_OK
            // 
            this.Button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_OK.Location = new System.Drawing.Point(214, 323);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(75, 28);
            this.Button_OK.TabIndex = 2;
            this.Button_OK.Text = "OK";
            this.Button_OK.UseVisualStyleBackColor = true;
            this.Button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Button_Cancel.Location = new System.Drawing.Point(295, 323);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(75, 28);
            this.Button_Cancel.TabIndex = 3;
            this.Button_Cancel.Text = "Cancel";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // GroupBox_Address
            // 
            this.GroupBox_Address.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox_Address.Controls.Add(this.AddressControl_Main);
            this.GroupBox_Address.Location = new System.Drawing.Point(12, 12);
            this.GroupBox_Address.Name = "GroupBox_Address";
            this.GroupBox_Address.Size = new System.Drawing.Size(358, 157);
            this.GroupBox_Address.TabIndex = 9;
            this.GroupBox_Address.TabStop = false;
            this.GroupBox_Address.Text = "Address";
            // 
            // AddressControl_Main
            // 
            this.AddressControl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddressControl_Main.Location = new System.Drawing.Point(3, 18);
            this.AddressControl_Main.Name = "AddressControl_Main";
            this.AddressControl_Main.Size = new System.Drawing.Size(352, 136);
            this.AddressControl_Main.TabIndex = 0;
            // 
            // GroupBox_Location
            // 
            this.GroupBox_Location.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox_Location.Controls.Add(this.LocationControl_Main);
            this.GroupBox_Location.Location = new System.Drawing.Point(12, 175);
            this.GroupBox_Location.Name = "GroupBox_Location";
            this.GroupBox_Location.Size = new System.Drawing.Size(358, 127);
            this.GroupBox_Location.TabIndex = 10;
            this.GroupBox_Location.TabStop = false;
            this.GroupBox_Location.Text = "Location";
            // 
            // LocationControl_Main
            // 
            this.LocationControl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LocationControl_Main.Name = "LocationControl_Main";
            this.LocationControl_Main.Size = new System.Drawing.Size(352, 106);
            this.LocationControl_Main.TabIndex = 1;
            // 
            // AddressAndLocationForm
            // 
            this.AcceptButton = this.Button_OK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.Button_Cancel;
            this.ClientSize = new System.Drawing.Size(382, 363);
            this.Controls.Add(this.GroupBox_Location);
            this.Controls.Add(this.GroupBox_Address);
            this.Controls.Add(this.Button_OK);
            this.Controls.Add(this.Button_Cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddressAndLocationForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Address And Location";
            this.GroupBox_Address.ResumeLayout(false);
            this.GroupBox_Location.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Button_OK;
        private System.Windows.Forms.Button Button_Cancel;
        private System.Windows.Forms.GroupBox GroupBox_Address;
        private AddressControl AddressControl_Main;
        private System.Windows.Forms.GroupBox GroupBox_Location;
        private LocationControl LocationControl_Main;
    }
}