
namespace SAM.Analytical.Windows.Forms
{
    partial class SetProfileForm
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
            this.ComboBoxControl_Profile = new SAM.Core.Windows.ComboBoxControl();
            this.TextBoxControl_StartIndex = new SAM.Core.Windows.TextBoxControl();
            this.CheckBox_Append = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Button_OK
            // 
            this.Button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_OK.Location = new System.Drawing.Point(64, 133);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(75, 28);
            this.Button_OK.TabIndex = 10;
            this.Button_OK.Text = "OK";
            this.Button_OK.UseVisualStyleBackColor = true;
            this.Button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Button_Cancel.Location = new System.Drawing.Point(145, 133);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(75, 28);
            this.Button_Cancel.TabIndex = 9;
            this.Button_Cancel.Text = "Cancel";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // ComboBoxControl_Profile
            // 
            this.ComboBoxControl_Profile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxControl_Profile.Description = "Profile:";
            this.ComboBoxControl_Profile.Location = new System.Drawing.Point(8, 69);
            this.ComboBoxControl_Profile.Name = "ComboBoxControl_Profile";
            this.ComboBoxControl_Profile.Size = new System.Drawing.Size(212, 54);
            this.ComboBoxControl_Profile.TabIndex = 13;
            // 
            // TextBoxControl_StartIndex
            // 
            this.TextBoxControl_StartIndex.Description = "Start Index:";
            this.TextBoxControl_StartIndex.Location = new System.Drawing.Point(8, 11);
            this.TextBoxControl_StartIndex.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxControl_StartIndex.Name = "TextBoxControl_StartIndex";
            this.TextBoxControl_StartIndex.Size = new System.Drawing.Size(119, 53);
            this.TextBoxControl_StartIndex.TabIndex = 14;
            // 
            // CheckBox_Append
            // 
            this.CheckBox_Append.AutoSize = true;
            this.CheckBox_Append.Location = new System.Drawing.Point(133, 40);
            this.CheckBox_Append.Name = "CheckBox_Append";
            this.CheckBox_Append.Size = new System.Drawing.Size(79, 21);
            this.CheckBox_Append.TabIndex = 15;
            this.CheckBox_Append.Text = "Append";
            this.CheckBox_Append.UseVisualStyleBackColor = true;
            this.CheckBox_Append.CheckedChanged += new System.EventHandler(this.CheckBox_Append_CheckedChanged);
            // 
            // SetProfileForm
            // 
            this.AcceptButton = this.Button_OK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.Button_Cancel;
            this.ClientSize = new System.Drawing.Size(232, 173);
            this.Controls.Add(this.CheckBox_Append);
            this.Controls.Add(this.TextBoxControl_StartIndex);
            this.Controls.Add(this.ComboBoxControl_Profile);
            this.Controls.Add(this.Button_OK);
            this.Controls.Add(this.Button_Cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetProfileForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Value";
            this.Load += new System.EventHandler(this.SetProfileForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_OK;
        private System.Windows.Forms.Button Button_Cancel;
        private Core.Windows.ComboBoxControl ComboBoxControl_Profile;
        private Core.Windows.TextBoxControl TextBoxControl_StartIndex;
        private System.Windows.Forms.CheckBox CheckBox_Append;
    }
}