
namespace SAM.Analytical.Windows.Controls
{
    partial class MechanicalSystemControl
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
            this.TreeView_Main = new System.Windows.Forms.TreeView();
            this.TextBox_Id = new System.Windows.Forms.TextBox();
            this.ComboBox_MechanicalSystemType = new System.Windows.Forms.ComboBox();
            this.Label_MechanicalSystemType = new System.Windows.Forms.Label();
            this.Label_Id = new System.Windows.Forms.Label();
            this.TextBox_FullName = new System.Windows.Forms.TextBox();
            this.Label_FullName = new System.Windows.Forms.Label();
            this.SplitContainer_Main = new System.Windows.Forms.SplitContainer();
            this.PropertyGrid_Parameters = new System.Windows.Forms.PropertyGrid();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Main)).BeginInit();
            this.SplitContainer_Main.Panel1.SuspendLayout();
            this.SplitContainer_Main.Panel2.SuspendLayout();
            this.SplitContainer_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // TreeView_Main
            // 
            this.TreeView_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeView_Main.Location = new System.Drawing.Point(0, 0);
            this.TreeView_Main.Name = "TreeView_Main";
            this.TreeView_Main.Size = new System.Drawing.Size(250, 500);
            this.TreeView_Main.TabIndex = 0;
            // 
            // TextBox_Id
            // 
            this.TextBox_Id.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Id.Location = new System.Drawing.Point(108, 33);
            this.TextBox_Id.Name = "TextBox_Id";
            this.TextBox_Id.Size = new System.Drawing.Size(235, 22);
            this.TextBox_Id.TabIndex = 1;
            // 
            // ComboBox_MechanicalSystemType
            // 
            this.ComboBox_MechanicalSystemType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBox_MechanicalSystemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_MechanicalSystemType.FormattingEnabled = true;
            this.ComboBox_MechanicalSystemType.Location = new System.Drawing.Point(108, 3);
            this.ComboBox_MechanicalSystemType.Name = "ComboBox_MechanicalSystemType";
            this.ComboBox_MechanicalSystemType.Size = new System.Drawing.Size(235, 24);
            this.ComboBox_MechanicalSystemType.TabIndex = 2;
            // 
            // Label_MechanicalSystemType
            // 
            this.Label_MechanicalSystemType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_MechanicalSystemType.AutoSize = true;
            this.Label_MechanicalSystemType.Location = new System.Drawing.Point(8, 6);
            this.Label_MechanicalSystemType.Name = "Label_MechanicalSystemType";
            this.Label_MechanicalSystemType.Size = new System.Drawing.Size(94, 17);
            this.Label_MechanicalSystemType.TabIndex = 3;
            this.Label_MechanicalSystemType.Text = "System Type:";
            // 
            // Label_Id
            // 
            this.Label_Id.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Id.AutoSize = true;
            this.Label_Id.Location = new System.Drawing.Point(8, 36);
            this.Label_Id.Name = "Label_Id";
            this.Label_Id.Size = new System.Drawing.Size(73, 17);
            this.Label_Id.TabIndex = 4;
            this.Label_Id.Text = "System Id:";
            // 
            // TextBox_FullName
            // 
            this.TextBox_FullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_FullName.Location = new System.Drawing.Point(108, 61);
            this.TextBox_FullName.Name = "TextBox_FullName";
            this.TextBox_FullName.ReadOnly = true;
            this.TextBox_FullName.Size = new System.Drawing.Size(235, 22);
            this.TextBox_FullName.TabIndex = 1;
            // 
            // Label_FullName
            // 
            this.Label_FullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_FullName.AutoSize = true;
            this.Label_FullName.Location = new System.Drawing.Point(8, 64);
            this.Label_FullName.Name = "Label_FullName";
            this.Label_FullName.Size = new System.Drawing.Size(75, 17);
            this.Label_FullName.TabIndex = 4;
            this.Label_FullName.Text = "Full Name:";
            // 
            // SplitContainer_Main
            // 
            this.SplitContainer_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer_Main.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitContainer_Main.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer_Main.Name = "SplitContainer_Main";
            // 
            // SplitContainer_Main.Panel1
            // 
            this.SplitContainer_Main.Panel1.Controls.Add(this.TreeView_Main);
            this.SplitContainer_Main.Panel1MinSize = 100;
            // 
            // SplitContainer_Main.Panel2
            // 
            this.SplitContainer_Main.Panel2.Controls.Add(this.PropertyGrid_Parameters);
            this.SplitContainer_Main.Panel2.Controls.Add(this.Label_MechanicalSystemType);
            this.SplitContainer_Main.Panel2.Controls.Add(this.Label_FullName);
            this.SplitContainer_Main.Panel2.Controls.Add(this.TextBox_Id);
            this.SplitContainer_Main.Panel2.Controls.Add(this.Label_Id);
            this.SplitContainer_Main.Panel2.Controls.Add(this.TextBox_FullName);
            this.SplitContainer_Main.Panel2.Controls.Add(this.ComboBox_MechanicalSystemType);
            this.SplitContainer_Main.Panel2MinSize = 100;
            this.SplitContainer_Main.Size = new System.Drawing.Size(600, 500);
            this.SplitContainer_Main.SplitterDistance = 250;
            this.SplitContainer_Main.TabIndex = 5;
            // 
            // PropertyGrid_Parameters
            // 
            this.PropertyGrid_Parameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertyGrid_Parameters.Location = new System.Drawing.Point(11, 89);
            this.PropertyGrid_Parameters.Name = "PropertyGrid_Parameters";
            this.PropertyGrid_Parameters.Size = new System.Drawing.Size(332, 408);
            this.PropertyGrid_Parameters.TabIndex = 5;
            // 
            // MechanicalSystemControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.SplitContainer_Main);
            this.Name = "MechanicalSystemControl";
            this.Size = new System.Drawing.Size(600, 500);
            this.SplitContainer_Main.Panel1.ResumeLayout(false);
            this.SplitContainer_Main.Panel2.ResumeLayout(false);
            this.SplitContainer_Main.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Main)).EndInit();
            this.SplitContainer_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView TreeView_Main;
        private System.Windows.Forms.TextBox TextBox_Id;
        private System.Windows.Forms.ComboBox ComboBox_MechanicalSystemType;
        private System.Windows.Forms.Label Label_MechanicalSystemType;
        private System.Windows.Forms.Label Label_Id;
        private System.Windows.Forms.TextBox TextBox_FullName;
        private System.Windows.Forms.Label Label_FullName;
        private System.Windows.Forms.SplitContainer SplitContainer_Main;
        private System.Windows.Forms.PropertyGrid PropertyGrid_Parameters;
    }
}
