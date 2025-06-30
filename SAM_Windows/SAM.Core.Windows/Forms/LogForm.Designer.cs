
namespace SAM.Core.Windows.Forms
{
    partial class LogForm
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
            this.Button_Close = new System.Windows.Forms.Button();
            this.DataGridView_Main = new System.Windows.Forms.DataGridView();
            this.Column_MessageType = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column_Text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Main)).BeginInit();
            this.SuspendLayout();
            // 
            // Button_Close
            // 
            this.Button_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Close.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Button_Close.Location = new System.Drawing.Point(695, 513);
            this.Button_Close.Name = "Button_Close";
            this.Button_Close.Size = new System.Drawing.Size(75, 28);
            this.Button_Close.TabIndex = 8;
            this.Button_Close.Text = "Close";
            this.Button_Close.UseVisualStyleBackColor = true;
            // 
            // DataGridView_Main
            // 
            this.DataGridView_Main.AllowUserToAddRows = false;
            this.DataGridView_Main.AllowUserToDeleteRows = false;
            this.DataGridView_Main.AllowUserToResizeRows = false;
            this.DataGridView_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView_Main.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView_Main.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridView_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_Main.ColumnHeadersVisible = false;
            this.DataGridView_Main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_MessageType,
            this.Column_Text});
            this.DataGridView_Main.Location = new System.Drawing.Point(12, 12);
            this.DataGridView_Main.Name = "DataGridView_Main";
            this.DataGridView_Main.ReadOnly = true;
            this.DataGridView_Main.RowHeadersVisible = false;
            this.DataGridView_Main.RowHeadersWidth = 51;
            this.DataGridView_Main.RowTemplate.Height = 24;
            this.DataGridView_Main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_Main.Size = new System.Drawing.Size(758, 495);
            this.DataGridView_Main.TabIndex = 9;
            // 
            // Column_MessageType
            // 
            this.Column_MessageType.FillWeight = 10F;
            this.Column_MessageType.HeaderText = "Message Type";
            this.Column_MessageType.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Column_MessageType.MinimumWidth = 6;
            this.Column_MessageType.Name = "Column_MessageType";
            this.Column_MessageType.ReadOnly = true;
            // 
            // Column_Text
            // 
            this.Column_Text.FillWeight = 90F;
            this.Column_Text.HeaderText = "Text";
            this.Column_Text.MinimumWidth = 6;
            this.Column_Text.Name = "Column_Text";
            this.Column_Text.ReadOnly = true;
            // 
            // LogForm
            // 
            this.AcceptButton = this.Button_Close;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.Button_Close;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.DataGridView_Main);
            this.Controls.Add(this.Button_Close);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LogForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "LogForm";
            this.Load += new System.EventHandler(this.LogForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Button_Close;
        private System.Windows.Forms.DataGridView DataGridView_Main;
        private System.Windows.Forms.DataGridViewImageColumn Column_MessageType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Text;
    }
}