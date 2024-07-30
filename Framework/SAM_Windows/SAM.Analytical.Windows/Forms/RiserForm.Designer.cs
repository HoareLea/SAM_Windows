
namespace SAM.Analytical.Windows.Forms
{
    partial class RiserForm
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
            this.TreeViewControl_Spaces = new SAM.Core.Windows.TreeViewControl();
            this.TextBoxControl_Name = new SAM.Core.Windows.TextBoxControl();
            this.SuspendLayout();
            // 
            // Button_OK
            // 
            this.Button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_OK.Location = new System.Drawing.Point(114, 463);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(75, 28);
            this.Button_OK.TabIndex = 8;
            this.Button_OK.Text = "OK";
            this.Button_OK.UseVisualStyleBackColor = true;
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Button_Cancel.Location = new System.Drawing.Point(195, 463);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(75, 28);
            this.Button_Cancel.TabIndex = 7;
            this.Button_Cancel.Text = "Cancel";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            // 
            // TreeViewControl_Spaces
            // 
            this.TreeViewControl_Spaces.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeViewControl_Spaces.Location = new System.Drawing.Point(12, 76);
            this.TreeViewControl_Spaces.Name = "TreeViewControl_Spaces";
            this.TreeViewControl_Spaces.Size = new System.Drawing.Size(258, 355);
            this.TreeViewControl_Spaces.TabIndex = 9;
            // 
            // TextBoxControl_Name
            // 
            this.TextBoxControl_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxControl_Name.Description = "Name:";
            this.TextBoxControl_Name.Location = new System.Drawing.Point(12, 13);
            this.TextBoxControl_Name.Name = "TextBoxControl_Name";
            this.TextBoxControl_Name.Size = new System.Drawing.Size(258, 57);
            this.TextBoxControl_Name.TabIndex = 10;
            // 
            // RiserForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(282, 503);
            this.Controls.Add(this.TextBoxControl_Name);
            this.Controls.Add(this.TreeViewControl_Spaces);
            this.Controls.Add(this.Button_OK);
            this.Controls.Add(this.Button_Cancel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RiserForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Riser";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Button_OK;
        private System.Windows.Forms.Button Button_Cancel;
        private Core.Windows.TreeViewControl TreeViewControl_Spaces;
        private Core.Windows.TextBoxControl TextBoxControl_Name;
    }
}