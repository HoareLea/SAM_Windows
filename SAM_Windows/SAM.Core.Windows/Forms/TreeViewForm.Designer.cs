
namespace SAM.Core.Windows.Forms
{
    partial class TreeViewForm<T>
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
            this.TreeView_Main = new System.Windows.Forms.TreeView();
            this.Button_Cancel = new System.Windows.Forms.Button();
            this.Button_OK = new System.Windows.Forms.Button();
            this.Button_SelectNone = new System.Windows.Forms.Button();
            this.Button_SelectAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TreeView_Main
            // 
            this.TreeView_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeView_Main.CheckBoxes = true;
            this.TreeView_Main.Location = new System.Drawing.Point(12, 12);
            this.TreeView_Main.Name = "TreeView_Main";
            this.TreeView_Main.Size = new System.Drawing.Size(258, 320);
            this.TreeView_Main.TabIndex = 0;
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Button_Cancel.Location = new System.Drawing.Point(195, 413);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(75, 28);
            this.Button_Cancel.TabIndex = 1;
            this.Button_Cancel.Text = "Cancel";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // Button_OK
            // 
            this.Button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_OK.Location = new System.Drawing.Point(114, 413);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(75, 28);
            this.Button_OK.TabIndex = 2;
            this.Button_OK.Text = "OK";
            this.Button_OK.UseVisualStyleBackColor = true;
            this.Button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // Button_SelectNone
            // 
            this.Button_SelectNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button_SelectNone.Location = new System.Drawing.Point(113, 338);
            this.Button_SelectNone.Name = "Button_SelectNone";
            this.Button_SelectNone.Size = new System.Drawing.Size(95, 28);
            this.Button_SelectNone.TabIndex = 1;
            this.Button_SelectNone.Text = "Select None";
            this.Button_SelectNone.UseVisualStyleBackColor = true;
            this.Button_SelectNone.Click += new System.EventHandler(this.Button_SelectNone_Click);
            // 
            // Button_SelectAll
            // 
            this.Button_SelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button_SelectAll.Location = new System.Drawing.Point(12, 338);
            this.Button_SelectAll.Name = "Button_SelectAll";
            this.Button_SelectAll.Size = new System.Drawing.Size(95, 28);
            this.Button_SelectAll.TabIndex = 2;
            this.Button_SelectAll.Text = "Select All";
            this.Button_SelectAll.UseVisualStyleBackColor = true;
            this.Button_SelectAll.Click += new System.EventHandler(this.Button_SelectAll_Click);
            // 
            // TreeViewForm
            // 
            this.AcceptButton = this.Button_OK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.Button_Cancel;
            this.ClientSize = new System.Drawing.Size(282, 453);
            this.Controls.Add(this.Button_SelectAll);
            this.Controls.Add(this.Button_OK);
            this.Controls.Add(this.Button_SelectNone);
            this.Controls.Add(this.Button_Cancel);
            this.Controls.Add(this.TreeView_Main);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TreeViewForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "TreeViewForm";
            this.Load += new System.EventHandler(this.TreeViewForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView TreeView_Main;
        private System.Windows.Forms.Button Button_Cancel;
        private System.Windows.Forms.Button Button_OK;
        private System.Windows.Forms.Button Button_SelectNone;
        private System.Windows.Forms.Button Button_SelectAll;
    }
}