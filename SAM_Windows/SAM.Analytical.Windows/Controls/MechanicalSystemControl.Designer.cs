
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
            this.SuspendLayout();
            // 
            // TreeView_Main
            // 
            this.TreeView_Main.Location = new System.Drawing.Point(3, 3);
            this.TreeView_Main.Name = "TreeView_Main";
            this.TreeView_Main.Size = new System.Drawing.Size(279, 494);
            this.TreeView_Main.TabIndex = 0;
            // 
            // TextBox_Id
            // 
            this.TextBox_Id.Location = new System.Drawing.Point(388, 51);
            this.TextBox_Id.Name = "TextBox_Id";
            this.TextBox_Id.Size = new System.Drawing.Size(209, 22);
            this.TextBox_Id.TabIndex = 1;
            // 
            // ComboBox_MechanicalSystemType
            // 
            this.ComboBox_MechanicalSystemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_MechanicalSystemType.FormattingEnabled = true;
            this.ComboBox_MechanicalSystemType.Location = new System.Drawing.Point(388, 21);
            this.ComboBox_MechanicalSystemType.Name = "ComboBox_MechanicalSystemType";
            this.ComboBox_MechanicalSystemType.Size = new System.Drawing.Size(209, 24);
            this.ComboBox_MechanicalSystemType.TabIndex = 2;
            // 
            // Label_MechanicalSystemType
            // 
            this.Label_MechanicalSystemType.AutoSize = true;
            this.Label_MechanicalSystemType.Location = new System.Drawing.Point(288, 24);
            this.Label_MechanicalSystemType.Name = "Label_MechanicalSystemType";
            this.Label_MechanicalSystemType.Size = new System.Drawing.Size(94, 17);
            this.Label_MechanicalSystemType.TabIndex = 3;
            this.Label_MechanicalSystemType.Text = "System Type:";
            // 
            // Label_Id
            // 
            this.Label_Id.AutoSize = true;
            this.Label_Id.Location = new System.Drawing.Point(288, 54);
            this.Label_Id.Name = "Label_Id";
            this.Label_Id.Size = new System.Drawing.Size(73, 17);
            this.Label_Id.TabIndex = 4;
            this.Label_Id.Text = "System Id:";
            // 
            // TextBox_FullName
            // 
            this.TextBox_FullName.Location = new System.Drawing.Point(388, 79);
            this.TextBox_FullName.Name = "TextBox_FullName";
            this.TextBox_FullName.ReadOnly = true;
            this.TextBox_FullName.Size = new System.Drawing.Size(209, 22);
            this.TextBox_FullName.TabIndex = 1;
            // 
            // Label_FullName
            // 
            this.Label_FullName.AutoSize = true;
            this.Label_FullName.Location = new System.Drawing.Point(288, 82);
            this.Label_FullName.Name = "Label_FullName";
            this.Label_FullName.Size = new System.Drawing.Size(75, 17);
            this.Label_FullName.TabIndex = 4;
            this.Label_FullName.Text = "Full Name:";
            // 
            // MechanicalSystemControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.Label_FullName);
            this.Controls.Add(this.Label_Id);
            this.Controls.Add(this.Label_MechanicalSystemType);
            this.Controls.Add(this.ComboBox_MechanicalSystemType);
            this.Controls.Add(this.TextBox_FullName);
            this.Controls.Add(this.TextBox_Id);
            this.Controls.Add(this.TreeView_Main);
            this.Name = "MechanicalSystemControl";
            this.Size = new System.Drawing.Size(600, 500);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView TreeView_Main;
        private System.Windows.Forms.TextBox TextBox_Id;
        private System.Windows.Forms.ComboBox ComboBox_MechanicalSystemType;
        private System.Windows.Forms.Label Label_MechanicalSystemType;
        private System.Windows.Forms.Label Label_Id;
        private System.Windows.Forms.TextBox TextBox_FullName;
        private System.Windows.Forms.Label Label_FullName;
    }
}
