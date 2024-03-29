﻿
namespace SAM.Analytical.Windows.Forms
{
    partial class ConstructionForm
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
            this.Label_Name = new System.Windows.Forms.Label();
            this.TextBox_Name = new System.Windows.Forms.TextBox();
            this.Button_OK = new System.Windows.Forms.Button();
            this.Button_Cancel = new System.Windows.Forms.Button();
            this.MaterialLayersControl_Main = new SAM.Architectural.Windows.MaterialLayersControl();
            this.Button_CopyFromConstruction = new System.Windows.Forms.Button();
            this.TextBox_Description = new System.Windows.Forms.TextBox();
            this.Label_Description = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Label_Name
            // 
            this.Label_Name.AutoSize = true;
            this.Label_Name.Location = new System.Drawing.Point(12, 25);
            this.Label_Name.Name = "Label_Name";
            this.Label_Name.Size = new System.Drawing.Size(47, 16);
            this.Label_Name.TabIndex = 0;
            this.Label_Name.Text = "Name:";
            // 
            // TextBox_Name
            // 
            this.TextBox_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Name.Location = new System.Drawing.Point(96, 22);
            this.TextBox_Name.Name = "TextBox_Name";
            this.TextBox_Name.Size = new System.Drawing.Size(374, 22);
            this.TextBox_Name.TabIndex = 1;
            // 
            // Button_OK
            // 
            this.Button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_OK.Location = new System.Drawing.Point(314, 413);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(75, 28);
            this.Button_OK.TabIndex = 4;
            this.Button_OK.Text = "OK";
            this.Button_OK.UseVisualStyleBackColor = true;
            this.Button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Button_Cancel.Location = new System.Drawing.Point(395, 413);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(75, 28);
            this.Button_Cancel.TabIndex = 3;
            this.Button_Cancel.Text = "Cancel";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // MaterialLayersControl_Main
            // 
            this.MaterialLayersControl_Main.Location = new System.Drawing.Point(12, 76);
            this.MaterialLayersControl_Main.MinimumSize = new System.Drawing.Size(350, 300);
            this.MaterialLayersControl_Main.Name = "MaterialLayersControl_Main";
            this.MaterialLayersControl_Main.Size = new System.Drawing.Size(458, 305);
            this.MaterialLayersControl_Main.TabIndex = 9;
            this.MaterialLayersControl_Main.Load += new System.EventHandler(this.MaterialLayersControl_Main_Load);
            // 
            // Button_CopyFromConstruction
            // 
            this.Button_CopyFromConstruction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button_CopyFromConstruction.Location = new System.Drawing.Point(15, 413);
            this.Button_CopyFromConstruction.Name = "Button_CopyFromConstruction";
            this.Button_CopyFromConstruction.Size = new System.Drawing.Size(174, 28);
            this.Button_CopyFromConstruction.TabIndex = 10;
            this.Button_CopyFromConstruction.Text = "Copy From Construction";
            this.Button_CopyFromConstruction.UseVisualStyleBackColor = true;
            this.Button_CopyFromConstruction.Click += new System.EventHandler(this.Button_CopyFromConstruction_Click);
            // 
            // TextBox_Description
            // 
            this.TextBox_Description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Description.Location = new System.Drawing.Point(96, 48);
            this.TextBox_Description.Name = "TextBox_Description";
            this.TextBox_Description.Size = new System.Drawing.Size(374, 22);
            this.TextBox_Description.TabIndex = 12;
            // 
            // Label_Description
            // 
            this.Label_Description.AutoSize = true;
            this.Label_Description.Location = new System.Drawing.Point(12, 51);
            this.Label_Description.Name = "Label_Description";
            this.Label_Description.Size = new System.Drawing.Size(78, 16);
            this.Label_Description.TabIndex = 11;
            this.Label_Description.Text = "Description:";
            // 
            // ConstructionForm
            // 
            this.AcceptButton = this.Button_OK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.Button_Cancel;
            this.ClientSize = new System.Drawing.Size(482, 453);
            this.Controls.Add(this.TextBox_Description);
            this.Controls.Add(this.Label_Description);
            this.Controls.Add(this.Button_CopyFromConstruction);
            this.Controls.Add(this.MaterialLayersControl_Main);
            this.Controls.Add(this.Button_OK);
            this.Controls.Add(this.Button_Cancel);
            this.Controls.Add(this.TextBox_Name);
            this.Controls.Add(this.Label_Name);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 500);
            this.Name = "ConstructionForm";
            this.ShowIcon = false;
            this.Text = "Construction";
            this.Load += new System.EventHandler(this.ConstructionForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConstructionForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_Name;
        private System.Windows.Forms.TextBox TextBox_Name;
        private System.Windows.Forms.Button Button_OK;
        private System.Windows.Forms.Button Button_Cancel;
        private Architectural.Windows.MaterialLayersControl MaterialLayersControl_Main;
        private System.Windows.Forms.Button Button_CopyFromConstruction;
        private System.Windows.Forms.TextBox TextBox_Description;
        private System.Windows.Forms.Label Label_Description;
    }
}