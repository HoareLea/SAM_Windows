
namespace SAM.Analytical.Windows
{
    partial class SpaceControl
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
            this.PropertyGrid_Main = new System.Windows.Forms.PropertyGrid();
            this.TextBox_Name = new System.Windows.Forms.TextBox();
            this.Label_Name = new System.Windows.Forms.Label();
            this.Label_Guid = new System.Windows.Forms.Label();
            this.TextBox_Guid = new System.Windows.Forms.TextBox();
            this.Label_InternalCondition = new System.Windows.Forms.Label();
            this.TextBox_InternalCondition = new System.Windows.Forms.TextBox();
            this.Button_ModifyInternalCondition = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PropertyGrid_Main
            // 
            this.PropertyGrid_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertyGrid_Main.Location = new System.Drawing.Point(2, 111);
            this.PropertyGrid_Main.Margin = new System.Windows.Forms.Padding(2);
            this.PropertyGrid_Main.Name = "PropertyGrid_Main";
            this.PropertyGrid_Main.Size = new System.Drawing.Size(352, 262);
            this.PropertyGrid_Main.TabIndex = 2;
            // 
            // TextBox_Name
            // 
            this.TextBox_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Name.Location = new System.Drawing.Point(46, 2);
            this.TextBox_Name.Margin = new System.Windows.Forms.Padding(2);
            this.TextBox_Name.Name = "TextBox_Name";
            this.TextBox_Name.Size = new System.Drawing.Size(310, 22);
            this.TextBox_Name.TabIndex = 0;
            // 
            // Label_Name
            // 
            this.Label_Name.AutoSize = true;
            this.Label_Name.Location = new System.Drawing.Point(0, 5);
            this.Label_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_Name.Name = "Label_Name";
            this.Label_Name.Size = new System.Drawing.Size(49, 17);
            this.Label_Name.TabIndex = 3;
            this.Label_Name.Text = "Name:";
            // 
            // Label_Guid
            // 
            this.Label_Guid.AutoSize = true;
            this.Label_Guid.Location = new System.Drawing.Point(1, 31);
            this.Label_Guid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_Guid.Name = "Label_Guid";
            this.Label_Guid.Size = new System.Drawing.Size(42, 17);
            this.Label_Guid.TabIndex = 3;
            this.Label_Guid.Text = "Guid:";
            // 
            // TextBox_Guid
            // 
            this.TextBox_Guid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Guid.Location = new System.Drawing.Point(47, 28);
            this.TextBox_Guid.Margin = new System.Windows.Forms.Padding(2);
            this.TextBox_Guid.Name = "TextBox_Guid";
            this.TextBox_Guid.ReadOnly = true;
            this.TextBox_Guid.Size = new System.Drawing.Size(309, 22);
            this.TextBox_Guid.TabIndex = 4;
            this.TextBox_Guid.TabStop = false;
            // 
            // Label_InternalCondition
            // 
            this.Label_InternalCondition.AutoSize = true;
            this.Label_InternalCondition.Location = new System.Drawing.Point(1, 56);
            this.Label_InternalCondition.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_InternalCondition.Name = "Label_InternalCondition";
            this.Label_InternalCondition.Size = new System.Drawing.Size(122, 17);
            this.Label_InternalCondition.TabIndex = 3;
            this.Label_InternalCondition.Text = "Internal Condition:";
            // 
            // TextBox_InternalCondition
            // 
            this.TextBox_InternalCondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_InternalCondition.Location = new System.Drawing.Point(127, 54);
            this.TextBox_InternalCondition.Margin = new System.Windows.Forms.Padding(2);
            this.TextBox_InternalCondition.Name = "TextBox_InternalCondition";
            this.TextBox_InternalCondition.ReadOnly = true;
            this.TextBox_InternalCondition.Size = new System.Drawing.Size(229, 22);
            this.TextBox_InternalCondition.TabIndex = 4;
            this.TextBox_InternalCondition.TabStop = false;
            // 
            // Button_ModifyInternalCondition
            // 
            this.Button_ModifyInternalCondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_ModifyInternalCondition.Location = new System.Drawing.Point(127, 80);
            this.Button_ModifyInternalCondition.Margin = new System.Windows.Forms.Padding(2);
            this.Button_ModifyInternalCondition.Name = "Button_ModifyInternalCondition";
            this.Button_ModifyInternalCondition.Size = new System.Drawing.Size(229, 27);
            this.Button_ModifyInternalCondition.TabIndex = 1;
            this.Button_ModifyInternalCondition.Text = "Modify Internal Condition";
            this.Button_ModifyInternalCondition.UseVisualStyleBackColor = true;
            this.Button_ModifyInternalCondition.Click += new System.EventHandler(this.Button_ModifyInternalCondition_Click);
            // 
            // SpaceControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.Button_ModifyInternalCondition);
            this.Controls.Add(this.PropertyGrid_Main);
            this.Controls.Add(this.TextBox_InternalCondition);
            this.Controls.Add(this.Label_InternalCondition);
            this.Controls.Add(this.TextBox_Guid);
            this.Controls.Add(this.Label_Guid);
            this.Controls.Add(this.TextBox_Name);
            this.Controls.Add(this.Label_Name);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SpaceControl";
            this.Size = new System.Drawing.Size(356, 381);
            this.Load += new System.EventHandler(this.SpaceControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PropertyGrid PropertyGrid_Main;
        private System.Windows.Forms.TextBox TextBox_Name;
        private System.Windows.Forms.Label Label_Name;
        private System.Windows.Forms.Label Label_Guid;
        private System.Windows.Forms.TextBox TextBox_Guid;
        private System.Windows.Forms.Label Label_InternalCondition;
        private System.Windows.Forms.TextBox TextBox_InternalCondition;
        private System.Windows.Forms.Button Button_ModifyInternalCondition;
    }
}
