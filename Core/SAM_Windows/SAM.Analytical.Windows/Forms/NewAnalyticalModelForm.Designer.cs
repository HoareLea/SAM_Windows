
namespace SAM.Analytical.Windows.Forms
{
    partial class NewAnalyticalModelForm
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
            this.ComboBoxControl_Template = new SAM.Core.Windows.ComboBoxControl();
            this.TextBoxControl_ProjectName = new SAM.Core.Windows.TextBoxControl();
            this.SuspendLayout();
            // 
            // Button_OK
            // 
            this.Button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_OK.Location = new System.Drawing.Point(114, 138);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(75, 28);
            this.Button_OK.TabIndex = 8;
            this.Button_OK.Text = "OK";
            this.Button_OK.UseVisualStyleBackColor = true;
            this.Button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Button_Cancel.Location = new System.Drawing.Point(195, 138);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(75, 28);
            this.Button_Cancel.TabIndex = 7;
            this.Button_Cancel.Text = "Cancel";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // ComboBoxControl_Template
            // 
            this.ComboBoxControl_Template.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxControl_Template.Description = "Template";
            this.ComboBoxControl_Template.Location = new System.Drawing.Point(12, 63);
            this.ComboBoxControl_Template.Name = "ComboBoxControl_Template";
            this.ComboBoxControl_Template.Size = new System.Drawing.Size(258, 57);
            this.ComboBoxControl_Template.TabIndex = 10;
            // 
            // TextBoxControl_ProjectName
            // 
            this.TextBoxControl_ProjectName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxControl_ProjectName.Description = "Project Name";
            this.TextBoxControl_ProjectName.Location = new System.Drawing.Point(12, 7);
            this.TextBoxControl_ProjectName.Name = "TextBoxControl_ProjectName";
            this.TextBoxControl_ProjectName.Size = new System.Drawing.Size(258, 53);
            this.TextBoxControl_ProjectName.TabIndex = 9;
            // 
            // NewAnalyticalModelForm
            // 
            this.AcceptButton = this.Button_OK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.Button_Cancel;
            this.ClientSize = new System.Drawing.Size(282, 178);
            this.Controls.Add(this.ComboBoxControl_Template);
            this.Controls.Add(this.TextBoxControl_ProjectName);
            this.Controls.Add(this.Button_OK);
            this.Controls.Add(this.Button_Cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewAnalyticalModelForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "New Analytical Model";
            this.Load += new System.EventHandler(this.NewAnalyticalModelForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Button_OK;
        private System.Windows.Forms.Button Button_Cancel;
        private Core.Windows.TextBoxControl TextBoxControl_ProjectName;
        private Core.Windows.ComboBoxControl ComboBoxControl_Template;
    }
}