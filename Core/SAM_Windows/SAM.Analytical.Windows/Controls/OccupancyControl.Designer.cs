
namespace SAM.Analytical.Windows.Controls
{
    partial class OccupancyControl
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
            this.CheckBox_InternalCondition = new System.Windows.Forms.CheckBox();
            this.Label_Occupancy_Unit = new System.Windows.Forms.Label();
            this.Label_Occupancy = new System.Windows.Forms.Label();
            this.TextBox_Occupancy = new System.Windows.Forms.TextBox();
            this.Label_AreaPerPerson_Unit = new System.Windows.Forms.Label();
            this.Label_AreaPerPerson = new System.Windows.Forms.Label();
            this.TextBox_AreaPerPerson = new System.Windows.Forms.TextBox();
            this.TextBox_CalculatedOccupancy = new System.Windows.Forms.TextBox();
            this.Label_CalculatedOccupancy = new System.Windows.Forms.Label();
            this.Label_CalculatedOccupancy_Unit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CheckBox_InternalCondition
            // 
            this.CheckBox_InternalCondition.AutoSize = true;
            this.CheckBox_InternalCondition.Location = new System.Drawing.Point(131, 35);
            this.CheckBox_InternalCondition.Name = "CheckBox_InternalCondition";
            this.CheckBox_InternalCondition.Size = new System.Drawing.Size(140, 21);
            this.CheckBox_InternalCondition.TabIndex = 0;
            this.CheckBox_InternalCondition.Text = "Internal Condition";
            this.CheckBox_InternalCondition.UseVisualStyleBackColor = true;
            this.CheckBox_InternalCondition.CheckedChanged += new System.EventHandler(this.CheckBox_InternalCondition_CheckedChanged);
            // 
            // Label_Occupancy_Unit
            // 
            this.Label_Occupancy_Unit.AutoSize = true;
            this.Label_Occupancy_Unit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Occupancy_Unit.Location = new System.Drawing.Point(78, 100);
            this.Label_Occupancy_Unit.Name = "Label_Occupancy_Unit";
            this.Label_Occupancy_Unit.Size = new System.Drawing.Size(24, 17);
            this.Label_Occupancy_Unit.TabIndex = 37;
            this.Label_Occupancy_Unit.Text = "[p]";
            // 
            // Label_Occupancy
            // 
            this.Label_Occupancy.AutoSize = true;
            this.Label_Occupancy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Occupancy.Location = new System.Drawing.Point(14, 77);
            this.Label_Occupancy.Name = "Label_Occupancy";
            this.Label_Occupancy.Size = new System.Drawing.Size(83, 17);
            this.Label_Occupancy.TabIndex = 36;
            this.Label_Occupancy.Text = "Occupancy:";
            // 
            // TextBox_Occupancy
            // 
            this.TextBox_Occupancy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_Occupancy.Location = new System.Drawing.Point(17, 97);
            this.TextBox_Occupancy.Name = "TextBox_Occupancy";
            this.TextBox_Occupancy.Size = new System.Drawing.Size(55, 22);
            this.TextBox_Occupancy.TabIndex = 35;
            this.TextBox_Occupancy.TextChanged += new System.EventHandler(this.TextBox_Occupancy_TextChanged);
            // 
            // Label_AreaPerPerson_Unit
            // 
            this.Label_AreaPerPerson_Unit.AutoSize = true;
            this.Label_AreaPerPerson_Unit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_AreaPerPerson_Unit.Location = new System.Drawing.Point(78, 35);
            this.Label_AreaPerPerson_Unit.Name = "Label_AreaPerPerson_Unit";
            this.Label_AreaPerPerson_Unit.Size = new System.Drawing.Size(47, 17);
            this.Label_AreaPerPerson_Unit.TabIndex = 34;
            this.Label_AreaPerPerson_Unit.Text = "[m2/p]";
            // 
            // Label_AreaPerPerson
            // 
            this.Label_AreaPerPerson.AutoSize = true;
            this.Label_AreaPerPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_AreaPerPerson.Location = new System.Drawing.Point(14, 12);
            this.Label_AreaPerPerson.Name = "Label_AreaPerPerson";
            this.Label_AreaPerPerson.Size = new System.Drawing.Size(117, 17);
            this.Label_AreaPerPerson.TabIndex = 33;
            this.Label_AreaPerPerson.Text = "Area Per Person:";
            // 
            // TextBox_AreaPerPerson
            // 
            this.TextBox_AreaPerPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_AreaPerPerson.Location = new System.Drawing.Point(17, 32);
            this.TextBox_AreaPerPerson.Name = "TextBox_AreaPerPerson";
            this.TextBox_AreaPerPerson.Size = new System.Drawing.Size(55, 22);
            this.TextBox_AreaPerPerson.TabIndex = 32;
            this.TextBox_AreaPerPerson.TextChanged += new System.EventHandler(this.TextBox_AreaPerPerson_TextChanged);
            // 
            // TextBox_CalculatedOccupancy
            // 
            this.TextBox_CalculatedOccupancy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_CalculatedOccupancy.Location = new System.Drawing.Point(17, 164);
            this.TextBox_CalculatedOccupancy.Name = "TextBox_CalculatedOccupancy";
            this.TextBox_CalculatedOccupancy.ReadOnly = true;
            this.TextBox_CalculatedOccupancy.Size = new System.Drawing.Size(55, 22);
            this.TextBox_CalculatedOccupancy.TabIndex = 35;
            // 
            // Label_CalculatedOccupancy
            // 
            this.Label_CalculatedOccupancy.AutoSize = true;
            this.Label_CalculatedOccupancy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_CalculatedOccupancy.Location = new System.Drawing.Point(14, 144);
            this.Label_CalculatedOccupancy.Name = "Label_CalculatedOccupancy";
            this.Label_CalculatedOccupancy.Size = new System.Drawing.Size(153, 17);
            this.Label_CalculatedOccupancy.TabIndex = 36;
            this.Label_CalculatedOccupancy.Text = "Calculated Occupancy:";
            // 
            // Label_CalculatedOccupancy_Unit
            // 
            this.Label_CalculatedOccupancy_Unit.AutoSize = true;
            this.Label_CalculatedOccupancy_Unit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_CalculatedOccupancy_Unit.Location = new System.Drawing.Point(78, 167);
            this.Label_CalculatedOccupancy_Unit.Name = "Label_CalculatedOccupancy_Unit";
            this.Label_CalculatedOccupancy_Unit.Size = new System.Drawing.Size(24, 17);
            this.Label_CalculatedOccupancy_Unit.TabIndex = 37;
            this.Label_CalculatedOccupancy_Unit.Text = "[p]";
            // 
            // OccupancyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Label_CalculatedOccupancy_Unit);
            this.Controls.Add(this.Label_Occupancy_Unit);
            this.Controls.Add(this.Label_CalculatedOccupancy);
            this.Controls.Add(this.TextBox_CalculatedOccupancy);
            this.Controls.Add(this.Label_Occupancy);
            this.Controls.Add(this.TextBox_Occupancy);
            this.Controls.Add(this.Label_AreaPerPerson_Unit);
            this.Controls.Add(this.Label_AreaPerPerson);
            this.Controls.Add(this.TextBox_AreaPerPerson);
            this.Controls.Add(this.CheckBox_InternalCondition);
            this.Name = "OccupancyControl";
            this.Size = new System.Drawing.Size(279, 208);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CheckBox_InternalCondition;
        private System.Windows.Forms.Label Label_Occupancy_Unit;
        private System.Windows.Forms.Label Label_Occupancy;
        private System.Windows.Forms.TextBox TextBox_Occupancy;
        private System.Windows.Forms.Label Label_AreaPerPerson_Unit;
        private System.Windows.Forms.Label Label_AreaPerPerson;
        private System.Windows.Forms.TextBox TextBox_AreaPerPerson;
        private System.Windows.Forms.TextBox TextBox_CalculatedOccupancy;
        private System.Windows.Forms.Label Label_CalculatedOccupancy;
        private System.Windows.Forms.Label Label_CalculatedOccupancy_Unit;
    }
}
