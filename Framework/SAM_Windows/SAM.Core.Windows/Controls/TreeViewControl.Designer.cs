
namespace SAM.Core.Windows
{
    partial class TreeViewControl
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
            this.Button_SelectAll = new System.Windows.Forms.Button();
            this.Button_SelectNone = new System.Windows.Forms.Button();
            this.TreeView_Main = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // Button_SelectAll
            // 
            this.Button_SelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button_SelectAll.Location = new System.Drawing.Point(3, 469);
            this.Button_SelectAll.Name = "Button_SelectAll";
            this.Button_SelectAll.Size = new System.Drawing.Size(95, 28);
            this.Button_SelectAll.TabIndex = 5;
            this.Button_SelectAll.Text = "Select All";
            this.Button_SelectAll.UseVisualStyleBackColor = true;
            this.Button_SelectAll.Click += new System.EventHandler(this.Button_SelectAll_Click);
            // 
            // Button_SelectNone
            // 
            this.Button_SelectNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button_SelectNone.Location = new System.Drawing.Point(104, 469);
            this.Button_SelectNone.Name = "Button_SelectNone";
            this.Button_SelectNone.Size = new System.Drawing.Size(95, 28);
            this.Button_SelectNone.TabIndex = 4;
            this.Button_SelectNone.Text = "Select None";
            this.Button_SelectNone.UseVisualStyleBackColor = true;
            this.Button_SelectNone.Click += new System.EventHandler(this.Button_SelectNone_Click);
            // 
            // TreeView_Main
            // 
            this.TreeView_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeView_Main.CheckBoxes = true;
            this.TreeView_Main.Location = new System.Drawing.Point(3, 3);
            this.TreeView_Main.Name = "TreeView_Main";
            this.TreeView_Main.Size = new System.Drawing.Size(294, 460);
            this.TreeView_Main.TabIndex = 3;
            // 
            // TreeViewControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.Button_SelectAll);
            this.Controls.Add(this.Button_SelectNone);
            this.Controls.Add(this.TreeView_Main);
            this.Name = "TreeViewControl";
            this.Size = new System.Drawing.Size(300, 500);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Button_SelectAll;
        private System.Windows.Forms.Button Button_SelectNone;
        private System.Windows.Forms.TreeView TreeView_Main;
    }
}
