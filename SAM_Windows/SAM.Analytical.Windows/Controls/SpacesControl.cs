using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAM.Analytical.Windows.Controls
{
    public partial class SpacesControl : UserControl
    {
        private AdjacencyCluster adjacencyCluster;
        private ProfileLibrary profileLibrary;

        public SpacesControl()
        {
            InitializeComponent();
        }

        public SpacesControl(IEnumerable<Space> spaces, AdjacencyCluster adjacencyCluster, ProfileLibrary profileLibrary)
        {
            this.adjacencyCluster = adjacencyCluster;
            this.profileLibrary = profileLibrary;

            InitializeComponent();

            LoadSpaces(spaces);
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IEnumerable<Space> Spaces
        {
            get
            {
                List<Space> result = new List<Space>();
                foreach(DataGridViewRow dataGridViewRow in DataGridView_Main.Rows)
                {
                    if(dataGridViewRow.Tag is Space)
                    {
                        result.Add((Space)dataGridViewRow.Tag);
                    }
                }

                return result;
            }

            set
            {
                LoadSpaces(value);
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AdjacencyCluster AdjacencyCluster
        {
            get
            {
                return adjacencyCluster;
            }
            set
            {
                adjacencyCluster = value;
                LoadSpaces(Spaces);
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProfileLibrary ProfileLibrary
        {
            get
            {
                return profileLibrary;
            }
            set
            {
                profileLibrary = value;
                LoadSpaces(Spaces);
            }
        }

        private void LoadSpaces(IEnumerable<Space> spaces)
        {
            DataGridView_Main.Rows.Clear();

            if(spaces == null || spaces.Count() == 0)
            {
                return;
            }

            foreach(Space space in spaces)
            {
                if(space == null)
                {
                    continue;
                }

                Add(space);
            }
        }

        private DataGridViewRow Add(Space space)
        {

            int index = DataGridView_Main.Rows.Add();
            if(index == -1)
            {
                return null;
            }

            DataGridViewRow result = DataGridView_Main.Rows[index];
            result.Tag = space;
            UpdateValues(result);
            return result;
        }

        private void UpdateValues(DataGridViewRow dataGridViewRow)
        {
            Space space = dataGridViewRow?.Tag as Space;
            if (space == null)
            {
                return;
            }

            string spaceName = null;
            double? area = null;
            double? occupancy = null;

            string internalConditionName = null;
            double? areaPerPerson = null;

            string heatingProfileName = null;
            double? heatingDesignTemperature = null;

            string coolingProfileName = null;
            double? coolingDesignTemperature = null;

            string occupancyProfileName = null;
            double? occupancySensibleGainPerPerson = null;
            double? occupancyLatentGainPerPerson = null;
            double? occupancyLatentGainCalculated = null;
            double? occupancySensibleGainCalculated = null;

            string lightingProfileName = null;
            double? lightingGain = null;
            double? lightingGainPerArea = null;
            double? lightingGainCalculated = null;
            double? lightingLevel = null;

            string equipmentSensibleProfileName = null;
            double? equipmentSensibleGain = null;
            double? equipmentSensibleGainPerArea = null;
            double? equipmentSensibleGainCalculated = null;

            string equipmentLatentProfileName = null;
            double? equipmentLatentGain = null;
            double? equipmentLatentGainPerArea = null;
            double? equipmentLatentGainCalculated = null;

            string humidificationProfileName = null;
            double? humidification = null;

            string dehumidificationProfileName = null;
            double? dehumidification = null;

            string infiltrationProfileName = null;
            double? infiltration = null;

            string ventilationSystemTypeName = null;
            string heatingSystemTypeName = null;
            string coolingSystemTypeName = null;

            double @double;
            string @string;

            spaceName = space.Name;
            if (space.TryGetValue(SpaceParameter.Area, out @double))
            {
                area = Core.Query.Round(@double, Core.Tolerance.MacroDistance);
            }

            if (space.TryGetValue(SpaceParameter.Occupancy, out @double))
            {
                occupancy = Core.Query.Round(@double, Core.Tolerance.MacroDistance);
            }

            InternalCondition internalCondition = space.InternalCondition;
            if (internalCondition != null)
            {
                Profile profile = null;

                internalConditionName = internalCondition.Name;

                if (internalCondition.TryGetValue(InternalConditionParameter.AreaPerPerson, out @double))
                {
                    areaPerPerson = Core.Query.Round(@double, Core.Tolerance.MacroDistance);
                }

                //Heating

                if (internalCondition.TryGetValue(InternalConditionParameter.HeatingProfileName, out @string))
                {
                    heatingProfileName = @string;
                }

                @double = Analytical.Query.HeatingDesignTemperature(internalCondition, profileLibrary);
                if (!double.IsNaN(@double))
                {
                    heatingDesignTemperature = Core.Query.Round(@double, Core.Tolerance.MacroDistance);
                }

                //Cooling

                if (internalCondition.TryGetValue(InternalConditionParameter.CoolingProfileName, out @string))
                {
                    coolingProfileName = @string;
                }

                @double = Analytical.Query.CoolingDesignTemperature(internalCondition, profileLibrary);
                if (!double.IsNaN(@double))
                {
                    coolingDesignTemperature = Core.Query.Round(@double, Core.Tolerance.MacroDistance);
                }

                //Occupancy

                if (internalCondition.TryGetValue(InternalConditionParameter.OccupancyProfileName, out @string))
                {
                    occupancyProfileName = @string;
                }

                if (internalCondition.TryGetValue(InternalConditionParameter.OccupancySensibleGainPerPerson, out @double))
                {
                    occupancySensibleGainPerPerson = Core.Query.Round(@double, Core.Tolerance.MacroDistance);
                }

                if (internalCondition.TryGetValue(InternalConditionParameter.OccupancyLatentGainPerPerson, out @double))
                {
                    occupancyLatentGainPerPerson = Core.Query.Round(@double, Core.Tolerance.MacroDistance);
                }

                @double = Analytical.Query.OccupancyLatentGain(space);
                if (!double.IsNaN(@double))
                {
                    occupancyLatentGainCalculated = Core.Query.Round(@double, Core.Tolerance.MacroDistance);
                }

                @double = Analytical.Query.OccupancySensibleGain(space);
                if (!double.IsNaN(@double))
                {
                    occupancySensibleGainCalculated = Core.Query.Round(@double, Core.Tolerance.MacroDistance);
                }

                //Lighting

                if (internalCondition.TryGetValue(InternalConditionParameter.LightingProfileName, out @string))
                {
                    lightingProfileName = @string;
                }

                if (internalCondition.TryGetValue(InternalConditionParameter.LightingGain, out @double))
                {
                    lightingGain = Core.Query.Round(@double, Core.Tolerance.MacroDistance);
                }

                if (internalCondition.TryGetValue(InternalConditionParameter.LightingGainPerArea, out @double))
                {
                    lightingGainPerArea = Core.Query.Round(@double, Core.Tolerance.MacroDistance);
                }

                @double = Analytical.Query.CalculatedLightingGain(space);
                if (!double.IsNaN(@double))
                {
                    lightingGainCalculated = Core.Query.Round(@double, Core.Tolerance.MacroDistance);
                }

                if (internalCondition.TryGetValue(InternalConditionParameter.LightingLevel, out @double))
                {
                    lightingLevel = Core.Query.Round(@double, Core.Tolerance.MacroDistance);
                }

                //Equipment Sensible

                if (internalCondition.TryGetValue(InternalConditionParameter.EquipmentSensibleProfileName, out @string))
                {
                    equipmentSensibleProfileName = @string;
                }

                if (internalCondition.TryGetValue(InternalConditionParameter.EquipmentSensibleGain, out @double))
                {
                    equipmentSensibleGain = Core.Query.Round(@double, Core.Tolerance.MacroDistance);
                }

                if (internalCondition.TryGetValue(InternalConditionParameter.EquipmentSensibleGainPerArea, out @double))
                {
                    equipmentSensibleGainPerArea = Core.Query.Round(@double, Core.Tolerance.MacroDistance);
                }

                @double = Analytical.Query.CalculatedEquipmentSensibleGain(space);
                if (!double.IsNaN(@double))
                {
                    equipmentSensibleGainCalculated = Core.Query.Round(@double, Core.Tolerance.MacroDistance);
                }

                //Equipment Latent

                if (internalCondition.TryGetValue(InternalConditionParameter.EquipmentLatentProfileName, out @string))
                {
                    equipmentLatentProfileName = @string;
                }

                if (internalCondition.TryGetValue(InternalConditionParameter.EquipmentLatentGain, out @double))
                {
                    equipmentLatentGain = Core.Query.Round(@double, Core.Tolerance.MacroDistance);
                }

                if (internalCondition.TryGetValue(InternalConditionParameter.EquipmentLatentGainPerArea, out @double))
                {
                    equipmentLatentGainPerArea = Core.Query.Round(@double, Core.Tolerance.MacroDistance);
                }

                @double = Analytical.Query.CalculatedEquipmentLatentGain(space);
                if (!double.IsNaN(@double))
                {
                    equipmentLatentGainCalculated = Core.Query.Round(@double, Core.Tolerance.MacroDistance);
                }

                //Humidification

                if (internalCondition.TryGetValue(InternalConditionParameter.HumidificationProfileName, out @string))
                {
                    humidificationProfileName = @string;
                }

                profile = internalCondition.GetProfile(ProfileType.Humidification, profileLibrary);
                if (profile != null)
                {
                    @double = profile.MaxValue;
                    if (!double.IsNaN(@double))
                    {
                        humidification = Core.Query.Round(@double, Core.Tolerance.MacroDistance);
                    }
                }

                //Dehumidification

                if (internalCondition.TryGetValue(InternalConditionParameter.DehumidificationProfileName, out @string))
                {
                    dehumidificationProfileName = @string;
                }

                profile = internalCondition.GetProfile(ProfileType.Dehumidification, profileLibrary);
                if (profile != null)
                {
                    @double = profile.MaxValue;
                    if (!double.IsNaN(@double))
                    {
                        dehumidification = Core.Query.Round(@double, Core.Tolerance.MacroDistance);
                    }
                }

                //Equipment Latent

                if (internalCondition.TryGetValue(InternalConditionParameter.InfiltrationProfileName, out @string))
                {
                    infiltrationProfileName = @string;
                }

                if (internalCondition.TryGetValue(InternalConditionParameter.InfiltrationAirChangesPerHour, out @double))
                {
                    infiltration = Core.Query.Round(@double, Core.Tolerance.MacroDistance);
                }

                //VentilationSystem

                @string = internalCondition.GetSystemTypeName<VentilationSystemType>();
                if (!string.IsNullOrWhiteSpace(@string))
                {
                    ventilationSystemTypeName = @string;
                }

                //HeatingSystem

                @string = internalCondition.GetSystemTypeName<HeatingSystemType>();
                if (!string.IsNullOrWhiteSpace(@string))
                {
                    heatingSystemTypeName = @string;
                }

                //CoolingSystem

                @string = internalCondition.GetSystemTypeName<CoolingSystemType>();
                if (!string.IsNullOrWhiteSpace(@string))
                {
                    coolingSystemTypeName = @string;
                }
            }

            dataGridViewRow.Cells[0].Value = spaceName;
            dataGridViewRow.Cells[1].Value = area;
            dataGridViewRow.Cells[2].Value = occupancy;
            dataGridViewRow.Cells[3].Value = internalConditionName;
            dataGridViewRow.Cells[4].Value = areaPerPerson;
            dataGridViewRow.Cells[5].Value = heatingProfileName;
            dataGridViewRow.Cells[6].Value = heatingDesignTemperature;
            dataGridViewRow.Cells[7].Value = coolingProfileName;
            dataGridViewRow.Cells[8].Value = coolingDesignTemperature;
            dataGridViewRow.Cells[9].Value = occupancyProfileName;
            dataGridViewRow.Cells[10].Value = occupancySensibleGainPerPerson;
            dataGridViewRow.Cells[11].Value = occupancySensibleGainCalculated;
            dataGridViewRow.Cells[12].Value = occupancyLatentGainPerPerson;
            dataGridViewRow.Cells[13].Value = occupancyLatentGainCalculated;
            dataGridViewRow.Cells[14].Value = lightingProfileName;
            dataGridViewRow.Cells[15].Value = lightingGain;
            dataGridViewRow.Cells[16].Value = lightingGainPerArea;
            dataGridViewRow.Cells[17].Value = lightingGainCalculated;
            dataGridViewRow.Cells[18].Value = lightingLevel;
            dataGridViewRow.Cells[19].Value = equipmentSensibleProfileName;
            dataGridViewRow.Cells[20].Value = equipmentSensibleGain;
            dataGridViewRow.Cells[21].Value = equipmentSensibleGainPerArea;
            dataGridViewRow.Cells[22].Value = equipmentSensibleGainCalculated;
            dataGridViewRow.Cells[23].Value = equipmentLatentProfileName;
            dataGridViewRow.Cells[24].Value = equipmentLatentGain;
            dataGridViewRow.Cells[25].Value = equipmentLatentGainPerArea;
            dataGridViewRow.Cells[26].Value = equipmentLatentGainCalculated;
            dataGridViewRow.Cells[27].Value = humidificationProfileName;
            dataGridViewRow.Cells[28].Value = humidification;
            dataGridViewRow.Cells[29].Value = dehumidificationProfileName;
            dataGridViewRow.Cells[30].Value = dehumidification;
            dataGridViewRow.Cells[31].Value = infiltrationProfileName;
            dataGridViewRow.Cells[32].Value = infiltration;
            dataGridViewRow.Cells[33].Value = ventilationSystemTypeName;
            dataGridViewRow.Cells[34].Value = heatingSystemTypeName;
            dataGridViewRow.Cells[35].Value = coolingSystemTypeName;

            ApplyColors(dataGridViewRow);
        }

        private void ApplyColors(DataGridViewRow dataGridViewRow)
        {
            Color color_Modified = Color.LightYellow;
            Color color_Existing = Color.LightGreen;
            Color color_ReadOnly = SystemColors.Control;
            Color color_Error = Color.Tomato;

            if (dataGridViewRow == null)
            {
                return;
            }

            foreach (DataGridViewColumn dataGridViewColumn in dataGridViewRow.DataGridView.Columns)
            {
                dataGridViewRow.Cells[dataGridViewColumn.Index].Style.BackColor = Color.White;
            }

            dataGridViewRow.Cells["Column_HeatingDesignTemperature"].Style.BackColor = color_ReadOnly;
            dataGridViewRow.Cells["Column_CoolingDesignTemperature"].Style.BackColor = color_ReadOnly;
            dataGridViewRow.Cells["Column_OccupancySensibleGainCalculated"].Style.BackColor = color_ReadOnly;
            dataGridViewRow.Cells["Column_OccupancyLatentGainCalculated"].Style.BackColor = color_ReadOnly;
            dataGridViewRow.Cells["Column_LightingGainCalculated"].Style.BackColor = color_ReadOnly;
            dataGridViewRow.Cells["Column_EquipmentSensibleGainCalculated"].Style.BackColor = color_ReadOnly;
            dataGridViewRow.Cells["Column_EquipmentLatentGainCalculated"].Style.BackColor = color_ReadOnly;
            dataGridViewRow.Cells["Column_Humidification"].Style.BackColor = color_ReadOnly;
            dataGridViewRow.Cells["Column_Dehumidification"].Style.BackColor = color_ReadOnly;

            Space space = dataGridViewRow.Tag as Space;
            if (space == null)
            {
                return;
            }

            InternalCondition internalCondition = space.InternalCondition;
            if (internalCondition == null)
            {
                return;
            }
            InternalCondition internalCondition_Template = adjacencyCluster.GetInternalConditions(false, true)?.ToList().Find(x => x.Name == internalCondition.Name);
            if (internalCondition_Template == null && !string.IsNullOrEmpty(internalCondition.Name))
            {
                dataGridViewRow.Cells["Column_InternalConditionName"].Style.BackColor = color_Modified;
                return;
            }

            dataGridViewRow.Cells["Column_InternalConditionName"].Style.BackColor = color_Existing;

            Profile profile = null;

            double @double;
            double @double_Template;

            string @string;
            string @string_Template;

            if (!internalCondition_Template.TryGetValue(InternalConditionParameter.AreaPerPerson, out double_Template))
            {
                double_Template = double.NaN;
            }

            if (!Core.Query.TryConvert(dataGridViewRow.Cells["Column_AreaPerPerson"].Value, out @double))
            {
                @double = double.NaN;
            }

            if (!Core.Query.AlmostEqual(@double, double_Template, Core.Tolerance.Distance))
            {
                dataGridViewRow.Cells["Column_AreaPerPerson"].Style.BackColor = color_Modified;
            }

            if (!internalCondition_Template.TryGetValue(InternalConditionParameter.AreaPerPerson, out double_Template))
            {
                double_Template = double.NaN;
            }

            //Heating

            if (!Core.Query.TryConvert(dataGridViewRow.Cells["Column_HeatingProfileName"].Value, out @string))
            {
                @string = null;
            }

            @string = string.IsNullOrEmpty(@string) ? null : @string;

            if (@string != null)
            {
                profile = internalCondition.GetProfile(ProfileType.Heating, profileLibrary);
                if (profile == null)
                {
                    dataGridViewRow.Cells["Column_HeatingProfileName"].Style.BackColor = color_Error;
                }
                else
                {
                    if (!internalCondition_Template.TryGetValue(InternalConditionParameter.HeatingProfileName, out @string_Template))
                    {
                        @string_Template = null;
                    }

                    @string_Template = string.IsNullOrEmpty(string_Template) ? null : string_Template;
                    if (@string != string_Template)
                    {
                        dataGridViewRow.Cells["Column_HeatingProfileName"].Style.BackColor = color_Modified;
                        dataGridViewRow.Cells["Column_HeatingDesignTemperature"].Style.BackColor = color_Modified;
                    }

                }
            }

            //Cooling

            if (!Core.Query.TryConvert(dataGridViewRow.Cells["Column_CoolingProfileName"].Value, out @string))
            {
                @string = null;
            }

            @string = string.IsNullOrEmpty(@string) ? null : @string;

            if (@string != null)
            {
                profile = internalCondition.GetProfile(ProfileType.Cooling, profileLibrary);
                if (profile == null)
                {
                    dataGridViewRow.Cells["Column_CoolingProfileName"].Style.BackColor = color_Error;
                }
                else
                {
                    if (!internalCondition_Template.TryGetValue(InternalConditionParameter.CoolingProfileName, out @string_Template))
                    {
                        @string_Template = null;
                    }

                    @string_Template = string.IsNullOrEmpty(string_Template) ? null : string_Template;
                    if (@string != string_Template)
                    {
                        dataGridViewRow.Cells["Column_CoolingProfileName"].Style.BackColor = color_Modified;
                        dataGridViewRow.Cells["Column_CoolingDesignTemperature"].Style.BackColor = color_Modified;
                    }

                }
            }

            //Occupancy

            if (!Core.Query.TryConvert(dataGridViewRow.Cells["Column_OccupancyProfileName"].Value, out @string))
            {
                @string = null;
            }

            @string = string.IsNullOrEmpty(@string) ? null : @string;

            if (@string != null)
            {
                profile = internalCondition.GetProfile(ProfileType.Occupancy, profileLibrary);
                if (profile == null)
                {
                    dataGridViewRow.Cells["Column_OccupancyProfileName"].Style.BackColor = color_Error;
                }
                else
                {
                    if (!internalCondition_Template.TryGetValue(InternalConditionParameter.OccupancyProfileName, out @string_Template))
                    {
                        @string_Template = null;
                    }

                    @string_Template = string.IsNullOrEmpty(string_Template) ? null : string_Template;
                    if (@string != string_Template)
                    {
                        dataGridViewRow.Cells["Column_OccupancyProfileName"].Style.BackColor = color_Modified;
                    }

                }
            }

            if (!Core.Query.TryConvert(dataGridViewRow.Cells["Column_OccupancySensibleGainPerPerson"].Value, out @double))
            {
                @double = double.NaN;
            }

            if (!internalCondition_Template.TryGetValue(InternalConditionParameter.OccupancySensibleGainPerPerson, out double_Template))
            {
                double_Template = double.NaN;
            }

            if (!Core.Query.AlmostEqual(@double, double_Template, Core.Tolerance.Distance))
            {
                dataGridViewRow.Cells["Column_OccupancySensibleGainPerPerson"].Style.BackColor = color_Modified;
            }

            if (!Core.Query.TryConvert(dataGridViewRow.Cells["Column_OccupancyLatentGainPerPerson"].Value, out @double))
            {
                @double = double.NaN;
            }

            if (!internalCondition_Template.TryGetValue(InternalConditionParameter.OccupancyLatentGainPerPerson, out double_Template))
            {
                double_Template = double.NaN;
            }

            if (!Core.Query.AlmostEqual(@double, double_Template, Core.Tolerance.Distance))
            {
                dataGridViewRow.Cells["Column_OccupancyLatentGainPerPerson"].Style.BackColor = color_Modified;
            }

            //Lighting

            if (!Core.Query.TryConvert(dataGridViewRow.Cells["Column_LightingProfileName"].Value, out @string))
            {
                @string = null;
            }

            @string = string.IsNullOrEmpty(@string) ? null : @string;

            if (@string != null)
            {
                profile = internalCondition.GetProfile(ProfileType.Lighting, profileLibrary);
                if (profile == null)
                {
                    dataGridViewRow.Cells["Column_LightingProfileName"].Style.BackColor = color_Error;
                }
                else
                {
                    if (!internalCondition_Template.TryGetValue(InternalConditionParameter.LightingProfileName, out @string_Template))
                    {
                        @string_Template = null;
                    }

                    @string_Template = string.IsNullOrEmpty(string_Template) ? null : string_Template;
                    if (@string != string_Template)
                    {
                        dataGridViewRow.Cells["Column_LightingProfileName"].Style.BackColor = color_Modified;
                    }

                }
            }

            if (!Core.Query.TryConvert(dataGridViewRow.Cells["Column_LightingGain"].Value, out @double))
            {
                @double = double.NaN;
            }

            if (!internalCondition_Template.TryGetValue(InternalConditionParameter.LightingGain, out double_Template))
            {
                double_Template = double.NaN;
            }

            if (!Core.Query.AlmostEqual(@double, double_Template, Core.Tolerance.Distance))
            {
                dataGridViewRow.Cells["Column_LightingGain"].Style.BackColor = color_Modified;
            }

            if (!Core.Query.TryConvert(dataGridViewRow.Cells["Column_LightingGainPerArea"].Value, out @double))
            {
                @double = double.NaN;
            }

            if (!internalCondition_Template.TryGetValue(InternalConditionParameter.LightingGainPerArea, out double_Template))
            {
                double_Template = double.NaN;
            }

            if (!Core.Query.AlmostEqual(@double, double_Template, Core.Tolerance.Distance))
            {
                dataGridViewRow.Cells["Column_LightingGainPerArea"].Style.BackColor = color_Modified;
            }

            if (!Core.Query.TryConvert(dataGridViewRow.Cells["Column_LightingLevel"].Value, out @double))
            {
                @double = double.NaN;
            }

            if (!internalCondition_Template.TryGetValue(InternalConditionParameter.LightingLevel, out double_Template))
            {
                double_Template = double.NaN;
            }

            if (!Core.Query.AlmostEqual(@double, double_Template, Core.Tolerance.Distance))
            {
                dataGridViewRow.Cells["Column_LightingLevel"].Style.BackColor = color_Modified;
            }

            //Equipment Sensible

            if (!Core.Query.TryConvert(dataGridViewRow.Cells["Column_EquipmentSensibleProfileName"].Value, out @string))
            {
                @string = null;
            }

            @string = string.IsNullOrEmpty(@string) ? null : @string;

            if (@string != null)
            {
                profile = internalCondition.GetProfile(ProfileType.EquipmentSensible, profileLibrary);
                if (profile == null)
                {
                    dataGridViewRow.Cells["Column_EquipmentSensibleProfileName"].Style.BackColor = color_Error;
                }
                else
                {
                    if (!internalCondition_Template.TryGetValue(InternalConditionParameter.EquipmentSensibleProfileName, out @string_Template))
                    {
                        @string_Template = null;
                    }

                    @string_Template = string.IsNullOrEmpty(string_Template) ? null : string_Template;
                    if (@string != string_Template)
                    {
                        dataGridViewRow.Cells["Column_EquipmentSensibleProfileName"].Style.BackColor = color_Modified;
                    }

                }
            }

            if (!Core.Query.TryConvert(dataGridViewRow.Cells["Column_EquipmentSensibleGain"].Value, out @double))
            {
                @double = double.NaN;
            }

            if (!internalCondition_Template.TryGetValue(InternalConditionParameter.EquipmentSensibleGain, out double_Template))
            {
                double_Template = double.NaN;
            }

            if (!Core.Query.AlmostEqual(@double, double_Template, Core.Tolerance.Distance))
            {
                dataGridViewRow.Cells["Column_EquipmentSensibleGain"].Style.BackColor = color_Modified;
            }

            if (!Core.Query.TryConvert(dataGridViewRow.Cells["Column_EquipmentSensibleGainPerArea"].Value, out @double))
            {
                @double = double.NaN;
            }

            if (!internalCondition_Template.TryGetValue(InternalConditionParameter.EquipmentSensibleGainPerArea, out double_Template))
            {
                double_Template = double.NaN;
            }

            if (!Core.Query.AlmostEqual(@double, double_Template, Core.Tolerance.Distance))
            {
                dataGridViewRow.Cells["Column_EquipmentSensibleGainPerArea"].Style.BackColor = color_Modified;
            }

            //Equipment Latent

            if (!Core.Query.TryConvert(dataGridViewRow.Cells["Column_EquipmentLatentProfileName"].Value, out @string))
            {
                @string = null;
            }

            @string = string.IsNullOrEmpty(@string) ? null : @string;

            if (@string != null)
            {
                profile = internalCondition.GetProfile(ProfileType.EquipmentLatent, profileLibrary);
                if (profile == null)
                {
                    dataGridViewRow.Cells["Column_EquipmentLatentProfileName"].Style.BackColor = color_Error;
                }
                else
                {
                    if (!internalCondition_Template.TryGetValue(InternalConditionParameter.EquipmentLatentProfileName, out @string_Template))
                    {
                        @string_Template = null;
                    }

                    @string_Template = string.IsNullOrEmpty(string_Template) ? null : string_Template;
                    if (@string != string_Template)
                    {
                        dataGridViewRow.Cells["Column_EquipmentLatentProfileName"].Style.BackColor = color_Modified;
                    }

                }
            }

            if (!Core.Query.TryConvert(dataGridViewRow.Cells["Column_EquipmentLatentGain"].Value, out @double))
            {
                @double = double.NaN;
            }

            if (!internalCondition_Template.TryGetValue(InternalConditionParameter.EquipmentLatentGain, out double_Template))
            {
                double_Template = double.NaN;
            }

            if (!Core.Query.AlmostEqual(@double, double_Template, Core.Tolerance.Distance))
            {
                dataGridViewRow.Cells["Column_EquipmentLatentGain"].Style.BackColor = color_Modified;
            }

            if (!Core.Query.TryConvert(dataGridViewRow.Cells["Column_EquipmentLatentGainPerArea"].Value, out @double))
            {
                @double = double.NaN;
            }

            if (!internalCondition_Template.TryGetValue(InternalConditionParameter.EquipmentLatentGainPerArea, out double_Template))
            {
                double_Template = double.NaN;
            }

            if (!Core.Query.AlmostEqual(@double, double_Template, Core.Tolerance.Distance))
            {
                dataGridViewRow.Cells["Column_EquipmentLatentGainPerArea"].Style.BackColor = color_Modified;
            }

            //Humidification

            if (!Core.Query.TryConvert(dataGridViewRow.Cells["Column_HumidificationProfileName"].Value, out @string))
            {
                @string = null;
            }

            @string = string.IsNullOrEmpty(@string) ? null : @string;

            if (@string != null)
            {
                profile = internalCondition.GetProfile(ProfileType.Humidification, profileLibrary);
                if (profile == null)
                {
                    dataGridViewRow.Cells["Column_HumidificationProfileName"].Style.BackColor = color_Error;
                }
                else
                {
                    if (!internalCondition_Template.TryGetValue(InternalConditionParameter.HumidificationProfileName, out @string_Template))
                    {
                        @string_Template = null;
                    }

                    @string_Template = string.IsNullOrEmpty(string_Template) ? null : string_Template;
                    if (@string != string_Template)
                    {
                        dataGridViewRow.Cells["Column_HumidificationProfileName"].Style.BackColor = color_Modified;
                        dataGridViewRow.Cells["Column_Humidification"].Style.BackColor = color_Modified;
                    }

                }
            }

            //Dehumidification

            if (!Core.Query.TryConvert(dataGridViewRow.Cells["Column_DehumidificationProfileName"].Value, out @string))
            {
                @string = null;
            }

            @string = string.IsNullOrEmpty(@string) ? null : @string;

            if (@string != null)
            {
                profile = internalCondition.GetProfile(ProfileType.Dehumidification, profileLibrary);
                if (profile == null)
                {
                    dataGridViewRow.Cells["Column_DehumidificationProfileName"].Style.BackColor = color_Error;
                }
                else
                {
                    if (!internalCondition_Template.TryGetValue(InternalConditionParameter.DehumidificationProfileName, out @string_Template))
                    {
                        @string_Template = null;
                    }

                    @string_Template = string.IsNullOrEmpty(string_Template) ? null : string_Template;
                    if (@string != string_Template)
                    {
                        dataGridViewRow.Cells["Column_DehumidificationProfileName"].Style.BackColor = color_Modified;
                        dataGridViewRow.Cells["Column_Dehumidification"].Style.BackColor = color_Modified;
                    }

                }
            }

            //Infiltartion

            if (!Core.Query.TryConvert(dataGridViewRow.Cells["Column_InfiltrationProfileName"].Value, out @string))
            {
                @string = null;
            }

            @string = string.IsNullOrEmpty(@string) ? null : @string;

            if (@string != null)
            {
                profile = internalCondition.GetProfile(ProfileType.Infiltration, profileLibrary);
                if (profile == null)
                {
                    dataGridViewRow.Cells["Column_InfiltrationProfileName"].Style.BackColor = color_Error;
                }
                else
                {
                    if (!internalCondition_Template.TryGetValue(InternalConditionParameter.InfiltrationProfileName, out @string_Template))
                    {
                        @string_Template = null;
                    }

                    @string_Template = string.IsNullOrEmpty(string_Template) ? null : string_Template;
                    if (@string != string_Template)
                    {
                        dataGridViewRow.Cells["Column_InfiltrationProfileName"].Style.BackColor = color_Modified;
                    }

                }
            }

            if (!Core.Query.TryConvert(dataGridViewRow.Cells["Column_Infiltration"].Value, out @double))
            {
                @double = double.NaN;
            }

            if (!internalCondition_Template.TryGetValue(InternalConditionParameter.InfiltrationAirChangesPerHour, out double_Template))
            {
                double_Template = double.NaN;
            }

            if (!Core.Query.AlmostEqual(@double, double_Template, Core.Tolerance.Distance))
            {
                dataGridViewRow.Cells["Column_Infiltration"].Style.BackColor = color_Modified;
            }

            //VentilationSystem

            //TODO: Implement Check

            //HeatingSystem

            //TODO: Implement Check

            //CoolingSystem

            //TODO: Implement Check

        }

        private void DataGridView_Main_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Space space = DataGridView_Main.Rows[e.RowIndex].Tag as Space;
            if(space == null)
            {
                return;
            }

            using (Forms.InternalConditionForm internalConditionForm = new Forms.InternalConditionForm(space, profileLibrary, adjacencyCluster))
            {
                internalConditionForm.UseColors = true;
                if(internalConditionForm.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                adjacencyCluster = internalConditionForm.AdjacencyCluster;
                profileLibrary = internalConditionForm.ProfileLibrary;

                DataGridView_Main.Rows[e.RowIndex].Tag = internalConditionForm.Space;
                UpdateValues(DataGridView_Main.Rows[e.RowIndex]);
            }
        }
    }
}
