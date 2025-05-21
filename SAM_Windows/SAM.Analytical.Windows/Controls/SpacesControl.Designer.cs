
namespace SAM.Analytical.Windows.Controls
{
    partial class SpacesControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGridView_Main = new System.Windows.Forms.DataGridView();
            this.Column_SpaceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Occupancy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_InternalConditionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_AreaPerPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_HeatingProfileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_HeatingDesignTemperature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_CoolingProfileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_CoolingDesignTemperature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_OccupancyProfileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_OccupancySensibleGainPerPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_OccupancySensibleGainCalculated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_OccupancyLatentGainPerPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_OccupancyLatentGainCalculated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_LightingProfileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_LightingGain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_LightingGainPerArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_LightingGainCalculated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_LightingLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEquipmentSensibleProfileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_EquipmentSensibleGain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_EquipmentSensibleGainPerArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_EquipmentSensibleGainCalculated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_EquipmentLatentProfileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_EquipmentLatentGain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_EquipmentLatentGainPerArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_EquipmentLatentGainCalculated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_HumidificationProfileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Humidification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_DehumidificationProfileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Dehumidification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_InfiltrationProfileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Infiltration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_VentilationSystemTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_HeatingSystemTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_CoolingSystemTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Main)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridView_Main
            // 
            this.DataGridView_Main.AllowUserToAddRows = false;
            this.DataGridView_Main.AllowUserToDeleteRows = false;
            this.DataGridView_Main.AllowUserToResizeRows = false;
            this.DataGridView_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView_Main.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.DataGridView_Main.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DataGridView_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_Main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_SpaceName,
            this.Column_Area,
            this.Column_Occupancy,
            this.Column_InternalConditionName,
            this.Column_AreaPerPerson,
            this.Column_HeatingProfileName,
            this.Column_HeatingDesignTemperature,
            this.Column_CoolingProfileName,
            this.Column_CoolingDesignTemperature,
            this.Column_OccupancyProfileName,
            this.Column_OccupancySensibleGainPerPerson,
            this.Column_OccupancySensibleGainCalculated,
            this.Column_OccupancyLatentGainPerPerson,
            this.Column_OccupancyLatentGainCalculated,
            this.Column_LightingProfileName,
            this.Column_LightingGain,
            this.Column_LightingGainPerArea,
            this.Column_LightingGainCalculated,
            this.Column_LightingLevel,
            this.ColumnEquipmentSensibleProfileName,
            this.Column_EquipmentSensibleGain,
            this.Column_EquipmentSensibleGainPerArea,
            this.Column_EquipmentSensibleGainCalculated,
            this.Column_EquipmentLatentProfileName,
            this.Column_EquipmentLatentGain,
            this.Column_EquipmentLatentGainPerArea,
            this.Column_EquipmentLatentGainCalculated,
            this.Column_HumidificationProfileName,
            this.Column_Humidification,
            this.Column_DehumidificationProfileName,
            this.Column_Dehumidification,
            this.Column_InfiltrationProfileName,
            this.Column_Infiltration,
            this.Column_VentilationSystemTypeName,
            this.Column_HeatingSystemTypeName,
            this.Column_CoolingSystemTypeName});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView_Main.DefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView_Main.Location = new System.Drawing.Point(3, 0);
            this.DataGridView_Main.MultiSelect = false;
            this.DataGridView_Main.Name = "DataGridView_Main";
            this.DataGridView_Main.ReadOnly = true;
            this.DataGridView_Main.RowHeadersVisible = false;
            this.DataGridView_Main.RowHeadersWidth = 51;
            this.DataGridView_Main.RowTemplate.Height = 24;
            this.DataGridView_Main.Size = new System.Drawing.Size(1286, 584);
            this.DataGridView_Main.TabIndex = 0;
            this.DataGridView_Main.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_Main_CellDoubleClick);
            // 
            // Column_SpaceName
            // 
            this.Column_SpaceName.HeaderText = "Space Name";
            this.Column_SpaceName.MinimumWidth = 6;
            this.Column_SpaceName.Name = "Column_SpaceName";
            this.Column_SpaceName.ReadOnly = true;
            this.Column_SpaceName.Width = 109;
            // 
            // Column_Area
            // 
            this.Column_Area.HeaderText = "Area [m2]";
            this.Column_Area.MinimumWidth = 6;
            this.Column_Area.Name = "Column_Area";
            this.Column_Area.ReadOnly = true;
            this.Column_Area.Width = 91;
            // 
            // Column_Occupancy
            // 
            this.Column_Occupancy.HeaderText = "Occupancy [p]";
            this.Column_Occupancy.MinimumWidth = 6;
            this.Column_Occupancy.Name = "Column_Occupancy";
            this.Column_Occupancy.ReadOnly = true;
            this.Column_Occupancy.Width = 118;
            // 
            // Column_InternalConditionName
            // 
            this.Column_InternalConditionName.HeaderText = "Internal Condition Name";
            this.Column_InternalConditionName.MinimumWidth = 6;
            this.Column_InternalConditionName.Name = "Column_InternalConditionName";
            this.Column_InternalConditionName.ReadOnly = true;
            this.Column_InternalConditionName.Width = 138;
            // 
            // Column_AreaPerPerson
            // 
            this.Column_AreaPerPerson.HeaderText = "Area per Person [m2/p]";
            this.Column_AreaPerPerson.MinimumWidth = 6;
            this.Column_AreaPerPerson.Name = "Column_AreaPerPerson";
            this.Column_AreaPerPerson.ReadOnly = true;
            this.Column_AreaPerPerson.Width = 133;
            // 
            // Column_HeatingProfileName
            // 
            this.Column_HeatingProfileName.HeaderText = "Heating Profile Name";
            this.Column_HeatingProfileName.MinimumWidth = 6;
            this.Column_HeatingProfileName.Name = "Column_HeatingProfileName";
            this.Column_HeatingProfileName.ReadOnly = true;
            this.Column_HeatingProfileName.Width = 123;
            // 
            // Column_HeatingDesignTemperature
            // 
            this.Column_HeatingDesignTemperature.HeaderText = "Heating Design Temperature [C]";
            this.Column_HeatingDesignTemperature.MinimumWidth = 6;
            this.Column_HeatingDesignTemperature.Name = "Column_HeatingDesignTemperature";
            this.Column_HeatingDesignTemperature.ReadOnly = true;
            this.Column_HeatingDesignTemperature.Width = 219;
            // 
            // Column_CoolingProfileName
            // 
            this.Column_CoolingProfileName.HeaderText = "Cooling Profile Name";
            this.Column_CoolingProfileName.MinimumWidth = 6;
            this.Column_CoolingProfileName.Name = "Column_CoolingProfileName";
            this.Column_CoolingProfileName.ReadOnly = true;
            this.Column_CoolingProfileName.Width = 121;
            // 
            // Column_CoolingDesignTemperature
            // 
            this.Column_CoolingDesignTemperature.HeaderText = "Cooling Design Temperature [C]";
            this.Column_CoolingDesignTemperature.MinimumWidth = 6;
            this.Column_CoolingDesignTemperature.Name = "Column_CoolingDesignTemperature";
            this.Column_CoolingDesignTemperature.ReadOnly = true;
            this.Column_CoolingDesignTemperature.Width = 217;
            // 
            // Column_OccupancyProfileName
            // 
            this.Column_OccupancyProfileName.HeaderText = "Occupancy Profile Name";
            this.Column_OccupancyProfileName.MinimumWidth = 6;
            this.Column_OccupancyProfileName.Name = "Column_OccupancyProfileName";
            this.Column_OccupancyProfileName.ReadOnly = true;
            this.Column_OccupancyProfileName.Width = 143;
            // 
            // Column_OccupancySensibleGainPerPerson
            // 
            this.Column_OccupancySensibleGainPerPerson.HeaderText = "Occupancy Sensible Gain [W/p]";
            this.Column_OccupancySensibleGainPerPerson.MinimumWidth = 6;
            this.Column_OccupancySensibleGainPerPerson.Name = "Column_OccupancySensibleGainPerPerson";
            this.Column_OccupancySensibleGainPerPerson.ReadOnly = true;
            this.Column_OccupancySensibleGainPerPerson.Width = 186;
            // 
            // Column_OccupancySensibleGainCalculated
            // 
            this.Column_OccupancySensibleGainCalculated.HeaderText = "Space Occupancy Sensible Gain [W]";
            this.Column_OccupancySensibleGainCalculated.MinimumWidth = 6;
            this.Column_OccupancySensibleGainCalculated.Name = "Column_OccupancySensibleGainCalculated";
            this.Column_OccupancySensibleGainCalculated.ReadOnly = true;
            this.Column_OccupancySensibleGainCalculated.Width = 195;
            // 
            // Column_OccupancyLatentGainPerPerson
            // 
            this.Column_OccupancyLatentGainPerPerson.HeaderText = "Occupancy Latent Gain [W/p]";
            this.Column_OccupancyLatentGainPerPerson.MinimumWidth = 6;
            this.Column_OccupancyLatentGainPerPerson.Name = "Column_OccupancyLatentGainPerPerson";
            this.Column_OccupancyLatentGainPerPerson.ReadOnly = true;
            this.Column_OccupancyLatentGainPerPerson.Width = 173;
            // 
            // Column_OccupancyLatentGainCalculated
            // 
            this.Column_OccupancyLatentGainCalculated.HeaderText = "Space Occupancy Latent Gain [W]";
            this.Column_OccupancyLatentGainCalculated.MinimumWidth = 6;
            this.Column_OccupancyLatentGainCalculated.Name = "Column_OccupancyLatentGainCalculated";
            this.Column_OccupancyLatentGainCalculated.ReadOnly = true;
            this.Column_OccupancyLatentGainCalculated.Width = 182;
            // 
            // Column_LightingProfileName
            // 
            this.Column_LightingProfileName.HeaderText = "Lighting Profile Name";
            this.Column_LightingProfileName.MinimumWidth = 6;
            this.Column_LightingProfileName.Name = "Column_LightingProfileName";
            this.Column_LightingProfileName.ReadOnly = true;
            this.Column_LightingProfileName.Width = 124;
            // 
            // Column_LightingGain
            // 
            this.Column_LightingGain.HeaderText = "Lighting Gain [W]";
            this.Column_LightingGain.MinimumWidth = 6;
            this.Column_LightingGain.Name = "Column_LightingGain";
            this.Column_LightingGain.ReadOnly = true;
            this.Column_LightingGain.Width = 115;
            // 
            // Column_LightingGainPerArea
            // 
            this.Column_LightingGainPerArea.HeaderText = "Lighting Gain [W/m2]";
            this.Column_LightingGainPerArea.MinimumWidth = 6;
            this.Column_LightingGainPerArea.Name = "Column_LightingGainPerArea";
            this.Column_LightingGainPerArea.ReadOnly = true;
            this.Column_LightingGainPerArea.Width = 115;
            // 
            // Column_LightingGainCalculated
            // 
            this.Column_LightingGainCalculated.HeaderText = "Space Lighting Gain [W]";
            this.Column_LightingGainCalculated.MinimumWidth = 6;
            this.Column_LightingGainCalculated.Name = "Column_LightingGainCalculated";
            this.Column_LightingGainCalculated.ReadOnly = true;
            this.Column_LightingGainCalculated.Width = 154;
            // 
            // Column_LightingLevel
            // 
            this.Column_LightingLevel.HeaderText = "Lighting Level [lux]";
            this.Column_LightingLevel.MinimumWidth = 6;
            this.Column_LightingLevel.Name = "Column_LightingLevel";
            this.Column_LightingLevel.ReadOnly = true;
            this.Column_LightingLevel.Width = 118;
            // 
            // ColumnEquipmentSensibleProfileName
            // 
            this.ColumnEquipmentSensibleProfileName.HeaderText = "Equipment Sensible Profile Name";
            this.ColumnEquipmentSensibleProfileName.MinimumWidth = 6;
            this.ColumnEquipmentSensibleProfileName.Name = "Column_EquipmentSensibleProfileName";
            this.ColumnEquipmentSensibleProfileName.ReadOnly = true;
            this.ColumnEquipmentSensibleProfileName.Width = 191;
            // 
            // Column_EquipmentSensibleGain
            // 
            this.Column_EquipmentSensibleGain.HeaderText = "Equipment Sensible Gain [W]";
            this.Column_EquipmentSensibleGain.MinimumWidth = 6;
            this.Column_EquipmentSensibleGain.Name = "Column_EquipmentSensibleGain";
            this.Column_EquipmentSensibleGain.ReadOnly = true;
            this.Column_EquipmentSensibleGain.Width = 152;
            // 
            // Column_EquipmentSensibleGainPerArea
            // 
            this.Column_EquipmentSensibleGainPerArea.HeaderText = "Equipment Sensible Gain [W/m2]";
            this.Column_EquipmentSensibleGainPerArea.MinimumWidth = 6;
            this.Column_EquipmentSensibleGainPerArea.Name = "Column_EquipmentSensibleGainPerArea";
            this.Column_EquipmentSensibleGainPerArea.ReadOnly = true;
            this.Column_EquipmentSensibleGainPerArea.Width = 182;
            // 
            // Column_EquipmentSensibleGainCalculated
            // 
            this.Column_EquipmentSensibleGainCalculated.HeaderText = "Space Equipment Sensible Gain [W]";
            this.Column_EquipmentSensibleGainCalculated.MinimumWidth = 6;
            this.Column_EquipmentSensibleGainCalculated.Name = "Column_EquipmentSensibleGainCalculated";
            this.Column_EquipmentSensibleGainCalculated.ReadOnly = true;
            this.Column_EquipmentSensibleGainCalculated.Width = 191;
            // 
            // Column_EquipmentLatentProfileName
            // 
            this.Column_EquipmentLatentProfileName.HeaderText = "Equipment Latent Profile Name";
            this.Column_EquipmentLatentProfileName.MinimumWidth = 6;
            this.Column_EquipmentLatentProfileName.Name = "Column_EquipmentLatentProfileName";
            this.Column_EquipmentLatentProfileName.ReadOnly = true;
            this.Column_EquipmentLatentProfileName.Width = 179;
            // 
            // Column_EquipmentLatentGain
            // 
            this.Column_EquipmentLatentGain.HeaderText = "Equipment Latent Gain [W]";
            this.Column_EquipmentLatentGain.MinimumWidth = 6;
            this.Column_EquipmentLatentGain.Name = "Column_EquipmentLatentGain";
            this.Column_EquipmentLatentGain.ReadOnly = true;
            this.Column_EquipmentLatentGain.Width = 139;
            // 
            // Column_EquipmentLatentGainPerArea
            // 
            this.Column_EquipmentLatentGainPerArea.HeaderText = "Equipment Latent Gain [W/m2]";
            this.Column_EquipmentLatentGainPerArea.MinimumWidth = 6;
            this.Column_EquipmentLatentGainPerArea.Name = "Column_EquipmentLatentGainPerArea";
            this.Column_EquipmentLatentGainPerArea.ReadOnly = true;
            this.Column_EquipmentLatentGainPerArea.Width = 170;
            // 
            // Column_EquipmentLatentGainCalculated
            // 
            this.Column_EquipmentLatentGainCalculated.HeaderText = "Space Equipment Latent Gain [W]";
            this.Column_EquipmentLatentGainCalculated.MinimumWidth = 6;
            this.Column_EquipmentLatentGainCalculated.Name = "Column_EquipmentLatentGainCalculated";
            this.Column_EquipmentLatentGainCalculated.ReadOnly = true;
            this.Column_EquipmentLatentGainCalculated.Width = 179;
            // 
            // Column_HumidificationProfileName
            // 
            this.Column_HumidificationProfileName.HeaderText = "Humidification Profile Name";
            this.Column_HumidificationProfileName.MinimumWidth = 6;
            this.Column_HumidificationProfileName.Name = "Column_HumidificationProfileName";
            this.Column_HumidificationProfileName.ReadOnly = true;
            this.Column_HumidificationProfileName.Width = 158;
            // 
            // Column_Humidification
            // 
            this.Column_Humidification.HeaderText = "Humidification [-]";
            this.Column_Humidification.MinimumWidth = 6;
            this.Column_Humidification.Name = "Column_Humidification";
            this.Column_Humidification.ReadOnly = true;
            this.Column_Humidification.Width = 130;
            // 
            // Column_DehumidificationProfileName
            // 
            this.Column_DehumidificationProfileName.HeaderText = "Dehumidification Profile Name";
            this.Column_DehumidificationProfileName.MinimumWidth = 6;
            this.Column_DehumidificationProfileName.Name = "Column_DehumidificationProfileName";
            this.Column_DehumidificationProfileName.ReadOnly = true;
            this.Column_DehumidificationProfileName.Width = 172;
            // 
            // Column_Dehumidification
            // 
            this.Column_Dehumidification.HeaderText = "Dehumidification [-]";
            this.Column_Dehumidification.MinimumWidth = 6;
            this.Column_Dehumidification.Name = "Column_Dehumidification";
            this.Column_Dehumidification.ReadOnly = true;
            this.Column_Dehumidification.Width = 145;
            // 
            // Column_InfiltrationProfileName
            // 
            this.Column_InfiltrationProfileName.HeaderText = "Infiltration Profile Name";
            this.Column_InfiltrationProfileName.MinimumWidth = 6;
            this.Column_InfiltrationProfileName.Name = "Column_InfiltrationProfileName";
            this.Column_InfiltrationProfileName.ReadOnly = true;
            this.Column_InfiltrationProfileName.Width = 134;
            // 
            // Column_Infiltration
            // 
            this.Column_Infiltration.HeaderText = "Infiltration [ACH]";
            this.Column_Infiltration.MinimumWidth = 6;
            this.Column_Infiltration.Name = "Column_Infiltration";
            this.Column_Infiltration.ReadOnly = true;
            this.Column_Infiltration.Width = 127;
            // 
            // Column_VentilationSystemTypeName
            // 
            this.Column_VentilationSystemTypeName.HeaderText = "Ventilation System Type Name";
            this.Column_VentilationSystemTypeName.MinimumWidth = 6;
            this.Column_VentilationSystemTypeName.Name = "Column_VentilationSystemTypeName";
            this.Column_VentilationSystemTypeName.ReadOnly = true;
            this.Column_VentilationSystemTypeName.Width = 176;
            // 
            // Column_HeatingSystemTypeName
            // 
            this.Column_HeatingSystemTypeName.HeaderText = "Heating System Type Name";
            this.Column_HeatingSystemTypeName.MinimumWidth = 6;
            this.Column_HeatingSystemTypeName.Name = "Column_HeatingSystemTypeName";
            this.Column_HeatingSystemTypeName.ReadOnly = true;
            this.Column_HeatingSystemTypeName.Width = 161;
            // 
            // Column_CoolingSystemTypeName
            // 
            this.Column_CoolingSystemTypeName.HeaderText = "Cooling System Type Name";
            this.Column_CoolingSystemTypeName.MinimumWidth = 6;
            this.Column_CoolingSystemTypeName.Name = "Column_CoolingSystemTypeName";
            this.Column_CoolingSystemTypeName.ReadOnly = true;
            this.Column_CoolingSystemTypeName.Width = 159;
            // 
            // SpacesControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.DataGridView_Main);
            this.Name = "SpacesControl";
            this.Size = new System.Drawing.Size(1292, 635);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridView_Main;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_OccupancyLatentGain;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_SpaceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Area;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Occupancy;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_InternalConditionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_AreaPerPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_HeatingProfileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_HeatingDesignTemperature;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_CoolingProfileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_CoolingDesignTemperature;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_OccupancyProfileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_OccupancySensibleGainPerPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_OccupancySensibleGainCalculated;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_OccupancyLatentGainPerPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_OccupancyLatentGainCalculated;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_LightingProfileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_LightingGain;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_LightingGainPerArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_LightingGainCalculated;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_LightingLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEquipmentSensibleProfileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_EquipmentSensibleGain;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_EquipmentSensibleGainPerArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_EquipmentSensibleGainCalculated;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_EquipmentLatentProfileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_EquipmentLatentGain;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_EquipmentLatentGainPerArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_EquipmentLatentGainCalculated;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_HumidificationProfileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Humidification;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_DehumidificationProfileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Dehumidification;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_InfiltrationProfileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Infiltration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_VentilationSystemTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_HeatingSystemTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_CoolingSystemTypeName;
    }
}
