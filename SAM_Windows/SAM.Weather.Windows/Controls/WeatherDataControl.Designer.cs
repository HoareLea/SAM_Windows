
namespace SAM.Weather.Windows.Controls
{
    partial class WeatherDataControl
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Chart_Main = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.PropertyGrid_Main = new System.Windows.Forms.PropertyGrid();
            this.TextBox_Guid = new System.Windows.Forms.TextBox();
            this.Label_Guid = new System.Windows.Forms.Label();
            this.TextBox_Name = new System.Windows.Forms.TextBox();
            this.Label_Name = new System.Windows.Forms.Label();
            this.SplitContainer_Main = new System.Windows.Forms.SplitContainer();
            this.SplitContainer_Top = new System.Windows.Forms.SplitContainer();
            this.DataGridView_Main = new System.Windows.Forms.DataGridView();
            this.TabControl_Main = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Main)).BeginInit();
            this.SplitContainer_Main.Panel1.SuspendLayout();
            this.SplitContainer_Main.Panel2.SuspendLayout();
            this.SplitContainer_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Top)).BeginInit();
            this.SplitContainer_Top.Panel1.SuspendLayout();
            this.SplitContainer_Top.Panel2.SuspendLayout();
            this.SplitContainer_Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Main)).BeginInit();
            this.TabControl_Main.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Chart_Main
            // 
            this.Chart_Main.BackColor = System.Drawing.SystemColors.Control;
            chartArea2.Name = "ChartArea1";
            this.Chart_Main.ChartAreas.Add(chartArea2);
            this.Chart_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Chart_Main.Location = new System.Drawing.Point(3, 3);
            this.Chart_Main.Name = "Chart_Main";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Name = "Series1";
            this.Chart_Main.Series.Add(series2);
            this.Chart_Main.Size = new System.Drawing.Size(786, 226);
            this.Chart_Main.TabIndex = 19;
            this.Chart_Main.Click += new System.EventHandler(this.Chart_Main_Click);
            // 
            // PropertyGrid_Main
            // 
            this.PropertyGrid_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertyGrid_Main.Location = new System.Drawing.Point(15, 87);
            this.PropertyGrid_Main.Margin = new System.Windows.Forms.Padding(2);
            this.PropertyGrid_Main.Name = "PropertyGrid_Main";
            this.PropertyGrid_Main.Size = new System.Drawing.Size(359, 229);
            this.PropertyGrid_Main.TabIndex = 21;
            // 
            // TextBox_Guid
            // 
            this.TextBox_Guid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Guid.Location = new System.Drawing.Point(58, 41);
            this.TextBox_Guid.Margin = new System.Windows.Forms.Padding(2);
            this.TextBox_Guid.Name = "TextBox_Guid";
            this.TextBox_Guid.ReadOnly = true;
            this.TextBox_Guid.Size = new System.Drawing.Size(316, 22);
            this.TextBox_Guid.TabIndex = 24;
            this.TextBox_Guid.TabStop = false;
            // 
            // Label_Guid
            // 
            this.Label_Guid.AutoSize = true;
            this.Label_Guid.Location = new System.Drawing.Point(12, 44);
            this.Label_Guid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_Guid.Name = "Label_Guid";
            this.Label_Guid.Size = new System.Drawing.Size(42, 17);
            this.Label_Guid.TabIndex = 22;
            this.Label_Guid.Text = "Guid:";
            // 
            // TextBox_Name
            // 
            this.TextBox_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Name.Location = new System.Drawing.Point(57, 15);
            this.TextBox_Name.Margin = new System.Windows.Forms.Padding(2);
            this.TextBox_Name.Name = "TextBox_Name";
            this.TextBox_Name.Size = new System.Drawing.Size(317, 22);
            this.TextBox_Name.TabIndex = 20;
            // 
            // Label_Name
            // 
            this.Label_Name.AutoSize = true;
            this.Label_Name.Location = new System.Drawing.Point(11, 18);
            this.Label_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_Name.Name = "Label_Name";
            this.Label_Name.Size = new System.Drawing.Size(49, 17);
            this.Label_Name.TabIndex = 23;
            this.Label_Name.Text = "Name:";
            // 
            // SplitContainer_Main
            // 
            this.SplitContainer_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SplitContainer_Main.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer_Main.Margin = new System.Windows.Forms.Padding(5);
            this.SplitContainer_Main.Name = "SplitContainer_Main";
            this.SplitContainer_Main.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer_Main.Panel1
            // 
            this.SplitContainer_Main.Panel1.Controls.Add(this.SplitContainer_Top);
            // 
            // SplitContainer_Main.Panel2
            // 
            this.SplitContainer_Main.Panel2.Controls.Add(this.TabControl_Main);
            this.SplitContainer_Main.Size = new System.Drawing.Size(800, 600);
            this.SplitContainer_Main.SplitterDistance = 335;
            this.SplitContainer_Main.TabIndex = 25;
            // 
            // SplitContainer_Top
            // 
            this.SplitContainer_Top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer_Top.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer_Top.Name = "SplitContainer_Top";
            // 
            // SplitContainer_Top.Panel1
            // 
            this.SplitContainer_Top.Panel1.Controls.Add(this.PropertyGrid_Main);
            this.SplitContainer_Top.Panel1.Controls.Add(this.TextBox_Name);
            this.SplitContainer_Top.Panel1.Controls.Add(this.Label_Guid);
            this.SplitContainer_Top.Panel1.Controls.Add(this.TextBox_Guid);
            this.SplitContainer_Top.Panel1.Controls.Add(this.Label_Name);
            this.SplitContainer_Top.Panel1.Margin = new System.Windows.Forms.Padding(5);
            this.SplitContainer_Top.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // SplitContainer_Top.Panel2
            // 
            this.SplitContainer_Top.Panel2.Controls.Add(this.DataGridView_Main);
            this.SplitContainer_Top.Panel2.Margin = new System.Windows.Forms.Padding(5);
            this.SplitContainer_Top.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.SplitContainer_Top.Size = new System.Drawing.Size(800, 335);
            this.SplitContainer_Top.SplitterDistance = 391;
            this.SplitContainer_Top.TabIndex = 25;
            // 
            // DataGridView_Main
            // 
            this.DataGridView_Main.AllowUserToAddRows = false;
            this.DataGridView_Main.AllowUserToDeleteRows = false;
            this.DataGridView_Main.AllowUserToResizeRows = false;
            this.DataGridView_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView_Main.Location = new System.Drawing.Point(5, 5);
            this.DataGridView_Main.Name = "DataGridView_Main";
            this.DataGridView_Main.ReadOnly = true;
            this.DataGridView_Main.RowHeadersVisible = false;
            this.DataGridView_Main.RowHeadersWidth = 51;
            this.DataGridView_Main.RowTemplate.Height = 24;
            this.DataGridView_Main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_Main.Size = new System.Drawing.Size(395, 325);
            this.DataGridView_Main.TabIndex = 0;
            // 
            // TabControl_Main
            // 
            this.TabControl_Main.Controls.Add(this.tabPage1);
            this.TabControl_Main.Controls.Add(this.tabPage2);
            this.TabControl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl_Main.Location = new System.Drawing.Point(0, 0);
            this.TabControl_Main.Name = "TabControl_Main";
            this.TabControl_Main.SelectedIndex = 0;
            this.TabControl_Main.Size = new System.Drawing.Size(800, 261);
            this.TabControl_Main.TabIndex = 20;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Chart_Main);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 232);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 71);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // WeatherDataControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.SplitContainer_Main);
            this.Name = "WeatherDataControl";
            this.Size = new System.Drawing.Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Main)).EndInit();
            this.SplitContainer_Main.Panel1.ResumeLayout(false);
            this.SplitContainer_Main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Main)).EndInit();
            this.SplitContainer_Main.ResumeLayout(false);
            this.SplitContainer_Top.Panel1.ResumeLayout(false);
            this.SplitContainer_Top.Panel1.PerformLayout();
            this.SplitContainer_Top.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Top)).EndInit();
            this.SplitContainer_Top.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Main)).EndInit();
            this.TabControl_Main.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart Chart_Main;
        private System.Windows.Forms.PropertyGrid PropertyGrid_Main;
        private System.Windows.Forms.TextBox TextBox_Guid;
        private System.Windows.Forms.Label Label_Guid;
        private System.Windows.Forms.TextBox TextBox_Name;
        private System.Windows.Forms.Label Label_Name;
        private System.Windows.Forms.SplitContainer SplitContainer_Main;
        private System.Windows.Forms.SplitContainer SplitContainer_Top;
        private System.Windows.Forms.DataGridView DataGridView_Main;
        private System.Windows.Forms.TabControl TabControl_Main;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}
