using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace SAM.Analytical.Windows.Controls
{
    public partial class InternalConditionControl : UserControl
    {
        private bool useColors = false;

        private AdjacencyCluster adjacencyCluster;
        private ProfileLibrary profileLibrary;
        private object @object;

        public InternalConditionControl()
        {
            InitializeComponent();
        }

        public InternalConditionControl(ProfileLibrary profileLibrary, Space space)
        {
            InitializeComponent();

            this.profileLibrary = profileLibrary;
            @object = space;
        }

        public InternalConditionControl(ProfileLibrary profileLibrary, InternalCondition internalCondition)
        {
            InitializeComponent();

            this.profileLibrary = profileLibrary;
            @object = internalCondition;
        }

        public Space Space
        {
            get
            {
                Space space = @object as Space;
                if (space == null)
                {
                    return null;
                }

                space.InternalCondition = GetInternalCondition();
                return space;
            }

            set
            {
                @object = value;
                LoadInternalCondition(value?.InternalCondition);
            }
        }

        public bool UseColors
        {
            get
            {
                return useColors;
            }

            set
            {
                useColors = value;
                ApplyColors();
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public InternalCondition InternalCondition
        {
            get
            {
                return GetInternalCondition();
            }

            set
            {
                @object = value;
                LoadInternalCondition(value);
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
                LoadInternalCondition(@object is InternalCondition ? (InternalCondition)@object : (@object as Space)?.InternalCondition);
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
                LoadInternalCondition(@object is InternalCondition ? (InternalCondition)@object : (@object as Space)?.InternalCondition);
            }
        }

        private void LoadInternalCondition(InternalCondition internalCondition)
        {
            InternalCondition internalCondition_Template = internalCondition == null ? null : adjacencyCluster?.GetInternalConditions(false, true)?.ToList().Find(x => x.Name == internalCondition.Name);

            Space space = @object as Space;

            if (profileLibrary == null)
            {
                Button_HeatingProfile.Enabled = false;
                Button_CoolingProfile.Enabled = false;
                Button_OccupancyProfile.Enabled = false;
                Button_LightingProfile.Enabled = false;
                Button_EquipmentSensibleProfile.Enabled = false;
                Button_EquipmentLatentProfile.Enabled = false;
                Button_HumidificationProfile.Enabled = false;
                Button_DehumidificationProfile.Enabled = false;
            }
            else
            {
                Button_HeatingProfile.Enabled = true;
                Button_CoolingProfile.Enabled = true;
                Button_OccupancyProfile.Enabled = true;
                Button_LightingProfile.Enabled = true;
                Button_EquipmentSensibleProfile.Enabled = true;
                Button_EquipmentLatentProfile.Enabled = true;
                Button_HumidificationProfile.Enabled = true;
                Button_DehumidificationProfile.Enabled = true;
            }

            if (space == null)
            {
                Button_Select.Visible = false;
                Button_Create.Visible = false;
                Button_Reset.Visible = false;
                TextBox_Occupancy_SensibleGain_Calculated.Visible = false;
                Label_Occupancy_SensibleGain_W.Visible = false;
                TextBox_Occupancy_LatentGain_Calculated.Visible = false;
                Label_Occupancy_LatentGain_W.Visible = false;
                TextBox_Equipment_SensibleGainCalculated.Visible = false;
                Label_Equipment_SensibleGainCalculated_W.Visible = false;
                TextBox_Equipment_LatentGainCalculated.Visible = false;
                Label_Equipment_LatentGainCalculated_W.Visible = false;

                Label_SupplyUnit_AirFlow.Visible = false;
                TextBox_SupplyUnit_AirFlow.Visible = false;
                Label_ExhaustUnit_AirFlow.Visible = false;
                TextBox_ExhaustUnit_AirFlow.Visible = false;
            }
            else
            {
                Button_Select.Visible = true;
                Button_Create.Visible = true;
                Button_Reset.Visible = true;
                TextBox_Occupancy_SensibleGain_Calculated.Visible = true;
                Label_Occupancy_SensibleGain_W.Visible = true;
                TextBox_Occupancy_LatentGain_Calculated.Visible = true;
                Label_Occupancy_LatentGain_W.Visible = true;
                TextBox_Equipment_SensibleGainCalculated.Visible = true;
                Label_Equipment_SensibleGainCalculated_W.Visible = true;
                TextBox_Equipment_LatentGainCalculated.Visible = true;
                Label_Equipment_LatentGainCalculated_W.Visible = true;

                Label_SupplyUnit_AirFlow.Visible = true;
                TextBox_SupplyUnit_AirFlow.Visible = true;
                Label_ExhaustUnit_AirFlow.Visible = true;
                TextBox_ExhaustUnit_AirFlow.Visible = true;
            }

            Button_Reset.Enabled = internalCondition_Template != null;

            TextBox_Name.Text = null;
            TextBox_AreaPerPerson.Text = null;

            TextBox_Infiltration_ProfileName.Text = null;
            TextBox_Infiltration_ProfileGuid.Text = null;
            TextBox_Infiltration.Text = null;

            TextBox_Occupancy_ProfileName.Text = null;
            TextBox_Occupancy_ProfileGuid.Text = null;
            TextBox_Occupancy_SensibleGainPerPerson.Text = null;
            TextBox_Occupancy_LatentGainPerPerson.Text = null;

            TextBox_Equipment_SensibleProfileName.Text = null;
            TextBox_Equipment_SensibleProfileGuid.Text = null;
            TextBox_Equipment_SensibleGainPerArea.Text = null;
            TextBox_Equipment_SensibleGain.Text = null;

            TextBox_Equipment_LatentProfileName.Text = null;
            TextBox_Equipment_LatentProfileGuid.Text = null;
            TextBox_Equipment_LatentGainPerArea.Text = null;
            TextBox_Equipment_LatentGain.Text = null;

            TextBox_Lighting_ProfileName.Text = null;
            TextBox_Lighting_ProfileGuid.Text = null;
            TextBox_Lighting_Gain.Text = null;
            TextBox_Lighting_GainPerArea.Text = null;
            TextBox_Lighting_Level.Text = null;

            TextBox_Heating_ProfileName.Text = null;
            TextBox_Heating_ProfileGuid.Text = null;
            TextBox_Heating_DesignTemperature.Text = null;

            TextBox_Cooling_ProfileName.Text = null;
            TextBox_Cooling_ProfileGuid.Text = null;
            TextBox_Cooling_DesignTemperature.Text = null;

            TextBox_Humidity_ProfileName.Text = null;
            TextBox_Humidity_ProfileGuid.Text = null;
            TextBox_Humidity.Text = null;

            TextBox_Dehumidity_ProfileName.Text = null;
            TextBox_Dehumidity_ProfileGuid.Text = null;
            TextBox_Dehumidity.Text = null;

            TextBox_VentilationSystem_Name.Text = null;
            TextBox_VentilationSystem_Guid.Text = null;

            TextBox_SupplyUnit_Name.Text = null;
            TextBox_SupplyUnit_AirFlow.Text = null;

            TextBox_ExhaustUnit_Name.Text = null;
            TextBox_ExhaustUnit_AirFlow.Text = null;

            TextBox_SupplyUnit_AirFlow.Text = null;
            TextBox_ExhaustUnit_AirFlow.Text = null;


            if (internalCondition != null)
            {
                TextBox_Name.Text = internalCondition.Name;

                double @double = double.NaN;
                string @string = null;
                Profile profile = null;

                if (internalCondition.TryGetValue(InternalConditionParameter.AreaPerPerson, out @double) && !double.IsNaN(@double))
                {
                    TextBox_AreaPerPerson.Text = Core.Query.Round(@double, Core.Tolerance.MacroDistance).ToString();
                }

                //Infiltration

                if (internalCondition.TryGetValue(InternalConditionParameter.InfiltrationProfileName, out @string) && !string.IsNullOrWhiteSpace(@string))
                {
                    TextBox_Infiltration_ProfileName.Text = @string;
                }

                profile = internalCondition.GetProfile(ProfileType.Infiltration, profileLibrary);
                if (profile != null)
                {
                    TextBox_Infiltration_ProfileGuid.Text = profile.Guid.ToString();
                }

                if (internalCondition.TryGetValue(InternalConditionParameter.InfiltrationAirChangesPerHour, out @double) && !double.IsNaN(@double))
                {
                    TextBox_Infiltration.Text = Core.Query.Round(@double, Core.Tolerance.MacroDistance).ToString();
                }

                //Occupancy

                if (internalCondition.TryGetValue(InternalConditionParameter.OccupancyProfileName, out @string) && !string.IsNullOrWhiteSpace(@string))
                {
                    TextBox_Occupancy_ProfileName.Text = @string;
                }

                profile = internalCondition.GetProfile(ProfileType.Occupancy, profileLibrary);
                if (profile != null)
                {
                    TextBox_Occupancy_ProfileGuid.Text = profile.Guid.ToString();
                }

                if (internalCondition.TryGetValue(InternalConditionParameter.OccupancySensibleGainPerPerson, out @double) && !double.IsNaN(@double))
                {
                    TextBox_Occupancy_SensibleGainPerPerson.Text = Core.Query.Round(@double, Core.Tolerance.MacroDistance).ToString();
                }

                if (internalCondition.TryGetValue(InternalConditionParameter.OccupancyLatentGainPerPerson, out @double) && !double.IsNaN(@double))
                {
                    TextBox_Occupancy_LatentGainPerPerson.Text = Core.Query.Round(@double, Core.Tolerance.MacroDistance).ToString();
                }

                if (space != null)
                {
                    @double = Analytical.Query.OccupancyLatentGain(space);
                    if (!double.IsNaN(@double))
                    {
                        TextBox_Occupancy_LatentGain_Calculated.Text = Core.Query.Round(@double, Core.Tolerance.MacroDistance).ToString();
                    }
                }

                //Equipment Sensible

                if (internalCondition.TryGetValue(InternalConditionParameter.EquipmentSensibleProfileName, out @string) && !string.IsNullOrWhiteSpace(@string))
                {
                    TextBox_Equipment_SensibleProfileName.Text = @string;
                }

                profile = internalCondition.GetProfile(ProfileType.EquipmentSensible, profileLibrary);
                if (profile != null)
                {
                    TextBox_Equipment_SensibleProfileGuid.Text = profile.Guid.ToString();
                }

                if (internalCondition.TryGetValue(InternalConditionParameter.EquipmentSensibleGainPerArea, out @double) && !double.IsNaN(@double))
                {
                    TextBox_Equipment_SensibleGainPerArea.Text = Core.Query.Round(@double, Core.Tolerance.MacroDistance).ToString();
                }

                if (internalCondition.TryGetValue(InternalConditionParameter.EquipmentSensibleGain, out @double) && !double.IsNaN(@double))
                {
                    TextBox_Equipment_SensibleGain.Text = Core.Query.Round(@double, Core.Tolerance.MacroDistance).ToString();
                }

                //Equipment Latent

                if (internalCondition.TryGetValue(InternalConditionParameter.EquipmentLatentProfileName, out @string) && !string.IsNullOrWhiteSpace(@string))
                {
                    TextBox_Equipment_LatentProfileName.Text = @string;
                }

                profile = internalCondition.GetProfile(ProfileType.EquipmentLatent, profileLibrary);
                if (profile != null)
                {
                    TextBox_Equipment_LatentProfileGuid.Text = profile.Guid.ToString();
                }

                if (internalCondition.TryGetValue(InternalConditionParameter.EquipmentLatentGainPerArea, out @double) && !double.IsNaN(@double))
                {
                    TextBox_Equipment_LatentGainPerArea.Text = Core.Query.Round(@double, Core.Tolerance.MacroDistance).ToString();
                }

                if (internalCondition.TryGetValue(InternalConditionParameter.EquipmentLatentGain, out @double) && !double.IsNaN(@double))
                {
                    TextBox_Equipment_LatentGain.Text = Core.Query.Round(@double, Core.Tolerance.MacroDistance).ToString();
                }

                //Lighting

                if (internalCondition.TryGetValue(InternalConditionParameter.LightingProfileName, out @string) && !string.IsNullOrWhiteSpace(@string))
                {
                    TextBox_Lighting_ProfileName.Text = @string;
                }

                profile = internalCondition.GetProfile(ProfileType.Lighting, profileLibrary);
                if (profile != null)
                {
                    TextBox_Lighting_ProfileGuid.Text = profile.Guid.ToString();
                }

                if (internalCondition.TryGetValue(InternalConditionParameter.LightingGain, out @double) && !double.IsNaN(@double))
                {
                    TextBox_Lighting_Gain.Text = Core.Query.Round(@double, Core.Tolerance.MacroDistance).ToString();
                }

                if (internalCondition.TryGetValue(InternalConditionParameter.LightingGainPerArea, out @double) && !double.IsNaN(@double))
                {
                    TextBox_Lighting_GainPerArea.Text = Core.Query.Round(@double, Core.Tolerance.MacroDistance).ToString();
                }

                if (internalCondition.TryGetValue(InternalConditionParameter.LightingLevel, out @double) && !double.IsNaN(@double))
                {
                    TextBox_Lighting_Level.Text = Core.Query.Round(@double, Core.Tolerance.MacroDistance).ToString();
                }

                //Heating

                if (internalCondition.TryGetValue(InternalConditionParameter.HeatingProfileName, out @string) && !string.IsNullOrWhiteSpace(@string))
                {
                    TextBox_Heating_ProfileName.Text = @string;
                }

                profile = internalCondition.GetProfile(ProfileType.Heating, profileLibrary);
                if (profile != null)
                {
                    TextBox_Heating_ProfileGuid.Text = profile.Guid.ToString();
                }

                @double = Analytical.Query.HeatingDesignTemperature(internalCondition, profileLibrary);
                if (!double.IsNaN(@double))
                {
                    TextBox_Heating_DesignTemperature.Text = Core.Query.Round(@double, Core.Tolerance.MacroDistance).ToString();
                }

                //Cooling

                if (internalCondition.TryGetValue(InternalConditionParameter.CoolingProfileName, out @string) && !string.IsNullOrWhiteSpace(@string))
                {
                    TextBox_Cooling_ProfileName.Text = @string;
                }

                profile = internalCondition.GetProfile(ProfileType.Cooling, profileLibrary);
                if (profile != null)
                {
                    TextBox_Cooling_ProfileGuid.Text = profile.Guid.ToString();
                }

                @double = Analytical.Query.CoolingDesignTemperature(internalCondition, profileLibrary);
                if (!double.IsNaN(@double))
                {
                    TextBox_Cooling_DesignTemperature.Text = Core.Query.Round(@double, Core.Tolerance.MacroDistance).ToString();
                }

                //Humidity

                if (internalCondition.TryGetValue(InternalConditionParameter.HumidificationProfileName, out @string) && !string.IsNullOrWhiteSpace(@string))
                {
                    TextBox_Humidity_ProfileName.Text = @string;
                }

                profile = internalCondition.GetProfile(ProfileType.Humidification, profileLibrary);
                if (profile != null)
                {
                    TextBox_Humidity_ProfileGuid.Text = profile.Guid.ToString();
                    @double = profile.MaxValue;
                    if (!double.IsNaN(@double))
                    {
                        TextBox_Humidity.Text = Core.Query.Round(@double, Core.Tolerance.MacroDistance).ToString();
                    }
                }

                //Dehumidity

                if (internalCondition.TryGetValue(InternalConditionParameter.DehumidificationProfileName, out @string) && !string.IsNullOrWhiteSpace(@string))
                {
                    TextBox_Dehumidity_ProfileName.Text = @string;
                }

                profile = internalCondition.GetProfile(ProfileType.Dehumidification, profileLibrary);
                if (profile != null)
                {
                    TextBox_Dehumidity_ProfileGuid.Text = profile.Guid.ToString();
                    @double = profile.MaxValue;
                    if (!double.IsNaN(@double))
                    {
                        TextBox_Dehumidity.Text = Core.Query.Round(@double, Core.Tolerance.MacroDistance).ToString();
                    }
                }

                //VentilationSystem

                @string = internalCondition.GetSystemTypeName<VentilationSystemType>();
                if (!string.IsNullOrWhiteSpace(@string))
                {
                    TextBox_VentilationSystem_Name.Text = @string;
                    VentilationSystem ventilationSystem = null;
                    if (space != null)
                    {
                        ventilationSystem = adjacencyCluster?.GetRelatedObjects<VentilationSystem>(space)?.Find(x => x.Name == @string);
                    }

                    if (ventilationSystem == null)
                    {
                        adjacencyCluster?.GetObject((VentilationSystem x) => x.Name == @string);
                    }

                    if (ventilationSystem != null)
                    {
                        TextBox_VentilationSystem_Guid.Text = ventilationSystem.Guid.ToString();

                        if (ventilationSystem.TryGetValue(VentilationSystemParameter.SupplyUnitName, out @string))
                        {
                            TextBox_SupplyUnit_Name.Text = @string;
                        }

                        if (ventilationSystem.TryGetValue(VentilationSystemParameter.ExhaustUnitName, out @string))
                        {
                            TextBox_ExhaustUnit_Name.Text = @string;
                        }
                    }
                }

                if (space != null)
                {
                    @double = Analytical.Query.SupplyAirFlow(space);
                    if (!double.IsNaN(@double))
                    {
                        TextBox_SupplyUnit_AirFlow.Text = Core.Query.Round(@double, Core.Tolerance.MacroDistance).ToString();
                    }

                    @double = Analytical.Query.ExhaustAirFlow(space);
                    if (!double.IsNaN(@double))
                    {
                        TextBox_ExhaustUnit_AirFlow.Text = Core.Query.Round(@double, Core.Tolerance.MacroDistance).ToString();
                    }
                }

                //Heating System

                @string = internalCondition.GetSystemTypeName<HeatingSystemType>();
                if (!string.IsNullOrWhiteSpace(@string))
                {
                    TextBox_HeatingSystem_Name.Text = @string;
                    HeatingSystem heatingSystem = null;
                    if (space != null)
                    {
                        heatingSystem = adjacencyCluster?.GetRelatedObjects<HeatingSystem>(space)?.Find(x => x.Name == @string);
                    }

                    if (heatingSystem == null)
                    {
                        adjacencyCluster?.GetObject((HeatingSystem x) => x.Name == @string);
                    }

                    if (heatingSystem != null)
                    {
                        TextBox_HeatingSystem_Guid.Text = heatingSystem.Guid.ToString();
                    }
                }

                //Cooling System

                @string = internalCondition.GetSystemTypeName<CoolingSystemType>();
                if (!string.IsNullOrWhiteSpace(@string))
                {
                    TextBox_CoolingSystem_Name.Text = @string;
                    CoolingSystem coolingSystem = null;
                    if (space != null)
                    {
                        coolingSystem = adjacencyCluster?.GetRelatedObjects<CoolingSystem>(space)?.Find(x => x.Name == @string);
                    }

                    if (coolingSystem == null)
                    {
                        adjacencyCluster?.GetObject((CoolingSystem x) => x.Name == @string);
                    }

                    if (coolingSystem != null)
                    {
                        TextBox_CoolingSystem_Guid.Text = coolingSystem.Guid.ToString();
                    }
                }
            }

            ApplyColors();
        }

        private InternalCondition GetInternalCondition()
        {
            InternalCondition result = null;

            if (@object is Space)
            {
                result = ((Space)@object).InternalCondition;
            }
            else
            {
                result = @object as InternalCondition;
            }

            result = result == null ? new InternalCondition(TextBox_Name.Text) : new InternalCondition(TextBox_Name.Text, result);

            double @double;

            if (Core.Query.TryConvert(TextBox_AreaPerPerson.Text, out @double))
            {
                result.SetValue(InternalConditionParameter.AreaPerPerson, @double);
            }
            else
            {
                result.RemoveValue(InternalConditionParameter.AreaPerPerson);
            }

            if (TextBox_Heating_ProfileName.Text != null)
            {
                result.SetValue(InternalConditionParameter.HeatingProfileName, TextBox_Heating_ProfileName.Text);
            }
            else
            {
                result.RemoveValue(InternalConditionParameter.HeatingProfileName);
            }

            if (TextBox_Cooling_ProfileName.Text != null)
            {
                result.SetValue(InternalConditionParameter.CoolingProfileName, TextBox_Cooling_ProfileName.Text);
            }
            else
            {
                result.RemoveValue(InternalConditionParameter.CoolingProfileName);
            }

            if (TextBox_Occupancy_ProfileName.Text != null)
            {
                result.SetValue(InternalConditionParameter.OccupancyProfileName, TextBox_Occupancy_ProfileName.Text);
            }
            else
            {
                result.RemoveValue(InternalConditionParameter.OccupancyProfileName);
            }

            if (Core.Query.TryConvert(TextBox_Occupancy_SensibleGainPerPerson.Text, out @double))
            {
                result.SetValue(InternalConditionParameter.OccupancySensibleGainPerPerson, @double);
            }
            else
            {
                result.RemoveValue(InternalConditionParameter.OccupancySensibleGainPerPerson);
            }

            if (Core.Query.TryConvert(TextBox_Occupancy_LatentGainPerPerson.Text, out @double))
            {
                result.SetValue(InternalConditionParameter.OccupancyLatentGainPerPerson, @double);
            }
            else
            {
                result.RemoveValue(InternalConditionParameter.OccupancyLatentGainPerPerson);
            }

            if (TextBox_Lighting_ProfileName.Text != null)
            {
                result.SetValue(InternalConditionParameter.LightingProfileName, TextBox_Lighting_ProfileName.Text);
            }
            else
            {
                result.RemoveValue(InternalConditionParameter.LightingProfileName);
            }

            if (Core.Query.TryConvert(TextBox_Lighting_Gain.Text, out @double))
            {
                result.SetValue(InternalConditionParameter.LightingGain, @double);
            }
            else
            {
                result.RemoveValue(InternalConditionParameter.LightingGain);
            }

            if (Core.Query.TryConvert(TextBox_Lighting_GainPerArea.Text, out @double))
            {
                result.SetValue(InternalConditionParameter.LightingGainPerArea, @double);
            }
            else
            {
                result.RemoveValue(InternalConditionParameter.LightingGainPerArea);
            }

            if (Core.Query.TryConvert(TextBox_Lighting_Level.Text, out @double))
            {
                result.SetValue(InternalConditionParameter.LightingLevel, @double);
            }
            else
            {
                result.RemoveValue(InternalConditionParameter.LightingLevel);
            }

            if (TextBox_Equipment_SensibleProfileName.Text != null)
            {
                result.SetValue(InternalConditionParameter.EquipmentSensibleProfileName, TextBox_Equipment_SensibleProfileName.Text);
            }
            else
            {
                result.RemoveValue(InternalConditionParameter.EquipmentSensibleProfileName);
            }

            if (Core.Query.TryConvert(TextBox_Equipment_SensibleGainPerArea.Text, out @double))
            {
                result.SetValue(InternalConditionParameter.EquipmentSensibleGainPerArea, @double);
            }
            else
            {
                result.RemoveValue(InternalConditionParameter.EquipmentSensibleGainPerArea);
            }

            if (Core.Query.TryConvert(TextBox_Equipment_SensibleGain.Text, out @double))
            {
                result.SetValue(InternalConditionParameter.EquipmentSensibleGain, @double);
            }
            else
            {
                result.RemoveValue(InternalConditionParameter.EquipmentSensibleGain);
            }

            if (TextBox_Equipment_LatentProfileName.Text != null)
            {
                result.SetValue(InternalConditionParameter.EquipmentLatentProfileName, TextBox_Equipment_LatentProfileName.Text);
            }
            else
            {
                result.RemoveValue(InternalConditionParameter.EquipmentLatentProfileName);
            }

            if (Core.Query.TryConvert(TextBox_Equipment_LatentGainPerArea.Text, out @double))
            {
                result.SetValue(InternalConditionParameter.EquipmentLatentGainPerArea, @double);
            }
            else
            {
                result.RemoveValue(InternalConditionParameter.EquipmentLatentGainPerArea);
            }

            if (Core.Query.TryConvert(TextBox_Equipment_LatentGain.Text, out @double))
            {
                result.SetValue(InternalConditionParameter.EquipmentLatentGain, @double);
            }
            else
            {
                result.RemoveValue(InternalConditionParameter.EquipmentLatentGain);
            }

            if (TextBox_Humidity_ProfileName.Text != null)
            {
                result.SetValue(InternalConditionParameter.HumidificationProfileName, TextBox_Humidity_ProfileName.Text);
            }
            else
            {
                result.RemoveValue(InternalConditionParameter.HumidificationProfileName);
            }

            if (TextBox_Dehumidity_ProfileName.Text != null)
            {
                result.SetValue(InternalConditionParameter.DehumidificationProfileName, TextBox_Dehumidity_ProfileName.Text);
            }
            else
            {
                result.RemoveValue(InternalConditionParameter.DehumidificationProfileName);
            }

            if (TextBox_Infiltration_ProfileName.Text != null)
            {
                result.SetValue(InternalConditionParameter.InfiltrationProfileName, TextBox_Infiltration_ProfileName.Text);
            }
            else
            {
                result.RemoveValue(InternalConditionParameter.InfiltrationProfileName);
            }

            if (Core.Query.TryConvert(TextBox_Infiltration.Text, out @double))
            {
                result.SetValue(InternalConditionParameter.InfiltrationAirChangesPerHour, @double);
            }
            else
            {
                result.RemoveValue(InternalConditionParameter.InfiltrationAirChangesPerHour);
            }

            if (TextBox_VentilationSystem_Name.Text != null)
            {
                result.SetValue(InternalConditionParameter.VentilationSystemTypeName, TextBox_VentilationSystem_Name.Text);
            }
            else
            {
                result.RemoveValue(InternalConditionParameter.VentilationSystemTypeName);
            }

            if (TextBox_HeatingSystem_Name.Text != null)
            {
                result.SetValue(InternalConditionParameter.HeatingSystemTypeName, TextBox_HeatingSystem_Name.Text);
            }
            else
            {
                result.RemoveValue(InternalConditionParameter.HeatingSystemTypeName);
            }

            if (TextBox_CoolingSystem_Name.Text != null)
            {
                result.SetValue(InternalConditionParameter.CoolingSystemTypeName, TextBox_CoolingSystem_Name.Text);
            }
            else
            {
                result.RemoveValue(InternalConditionParameter.CoolingSystemTypeName);
            }

            return result;
        }

        private void ApplyColors()
        {
            List<TextBox> textBoxes = Core.Windows.Query.Controls<TextBox>(this);
            if (textBoxes != null)
            {
                textBoxes.ForEach(x => x.BackColor = x.ReadOnly ? System.Drawing.SystemColors.Control : System.Drawing.Color.White);
            }

            if (!UseColors)
            {
                return;
            }

            System.Drawing.Color color_Modified = System.Drawing.Color.LightYellow;
            System.Drawing.Color color_Existing = System.Drawing.Color.LightGreen;

            bool reset = false;

            if (string.IsNullOrWhiteSpace(TextBox_Name.Text))
            {
                return;
            }

            InternalCondition internalCondition_Template = adjacencyCluster?.GetInternalConditions(false, true)?.ToList().Find(x => x.Name == TextBox_Name.Text);

            if (TextBox_Name?.Text == internalCondition_Template?.Name)
            {
                TextBox_Name.BackColor = color_Existing;
            }
            else
            {
                TextBox_Name.BackColor = color_Modified;
            }

            if (internalCondition_Template == null)
            {
                return;
            }

            double @double;
            double double_Template;

            string @string;
            string string_Template;

            //Area Per Person

            if (!internalCondition_Template.TryGetValue(InternalConditionParameter.AreaPerPerson, out double_Template))
            {
                double_Template = double.NaN;
            }

            if (!Core.Query.TryConvert(TextBox_AreaPerPerson.Text, out @double))
            {
                @double = double.NaN;
            }

            if (!Core.Query.AlmostEqual(@double, double_Template, Core.Tolerance.Distance))
            {
                TextBox_AreaPerPerson.BackColor = color_Modified;
                reset = true;
            }

            //Heating

            if (!internalCondition_Template.TryGetValue(InternalConditionParameter.HeatingProfileName, out string_Template))
            {
                string_Template = null;
            }

            string_Template = string.IsNullOrEmpty(string_Template) ? null : string_Template;
            @string = string.IsNullOrEmpty(TextBox_Heating_ProfileName.Text) ? null : TextBox_Heating_ProfileName.Text;

            if (@string != string_Template)
            {
                TextBox_Heating_ProfileName.BackColor = color_Modified;
                TextBox_Heating_ProfileGuid.BackColor = color_Modified;
                TextBox_Heating_DesignTemperature.BackColor = color_Modified;
                reset = true;
            }

            //Cooling

            if (!internalCondition_Template.TryGetValue(InternalConditionParameter.CoolingProfileName, out string_Template))
            {
                string_Template = null;
            }

            string_Template = string.IsNullOrEmpty(string_Template) ? null : string_Template;
            @string = string.IsNullOrEmpty(TextBox_Cooling_ProfileName.Text) ? null : TextBox_Cooling_ProfileName.Text;

            if (@string != string_Template)
            {
                TextBox_Cooling_ProfileName.BackColor = color_Modified;
                TextBox_Cooling_ProfileGuid.BackColor = color_Modified;
                TextBox_Cooling_DesignTemperature.BackColor = color_Modified;
                reset = true;
            }

            //Occupancy

            if (!internalCondition_Template.TryGetValue(InternalConditionParameter.OccupancyProfileName, out string_Template))
            {
                string_Template = null;
            }

            string_Template = string.IsNullOrEmpty(string_Template) ? null : string_Template;
            @string = string.IsNullOrEmpty(TextBox_Occupancy_ProfileName.Text) ? null : TextBox_Occupancy_ProfileName.Text;

            if (@string != string_Template)
            {
                TextBox_Occupancy_ProfileName.BackColor = color_Modified;
                TextBox_Occupancy_ProfileGuid.BackColor = color_Modified;
                reset = true;
            }

            if (!internalCondition_Template.TryGetValue(InternalConditionParameter.OccupancySensibleGainPerPerson, out double_Template))
            {
                double_Template = double.NaN;
            }

            if (!Core.Query.TryConvert(TextBox_Occupancy_SensibleGainPerPerson.Text, out @double))
            {
                @double = double.NaN;
            }

            if (!Core.Query.AlmostEqual(@double, double_Template, Core.Tolerance.Distance))
            {
                TextBox_Occupancy_SensibleGainPerPerson.BackColor = color_Modified;
                reset = true;
            }

            if (!internalCondition_Template.TryGetValue(InternalConditionParameter.OccupancyLatentGainPerPerson, out double_Template))
            {
                double_Template = double.NaN;
            }

            if (!Core.Query.TryConvert(TextBox_Occupancy_LatentGainPerPerson.Text, out @double))
            {
                @double = double.NaN;
            }

            if (!Core.Query.AlmostEqual(@double, double_Template, Core.Tolerance.Distance))
            {
                TextBox_Occupancy_LatentGainPerPerson.BackColor = color_Modified;
                reset = true;
            }

            //Lighting

            if (!internalCondition_Template.TryGetValue(InternalConditionParameter.LightingProfileName, out string_Template))
            {
                string_Template = null;
            }

            string_Template = string.IsNullOrEmpty(string_Template) ? null : string_Template;
            @string = string.IsNullOrEmpty(TextBox_Lighting_ProfileName.Text) ? null : TextBox_Lighting_ProfileName.Text;

            if (@string != string_Template)
            {
                TextBox_Lighting_ProfileName.BackColor = color_Modified;
                TextBox_Lighting_ProfileGuid.BackColor = color_Modified;
                reset = true;
            }

            if (!internalCondition_Template.TryGetValue(InternalConditionParameter.LightingGain, out double_Template))
            {
                double_Template = double.NaN;
            }

            if (!Core.Query.TryConvert(TextBox_Lighting_Gain.Text, out @double))
            {
                @double = double.NaN;
            }

            if (!Core.Query.AlmostEqual(@double, double_Template, Core.Tolerance.Distance))
            {
                TextBox_Lighting_Gain.BackColor = color_Modified;
                reset = true;
            }

            if (!internalCondition_Template.TryGetValue(InternalConditionParameter.LightingGainPerArea, out double_Template))
            {
                double_Template = double.NaN;
            }

            if (!Core.Query.TryConvert(TextBox_Lighting_GainPerArea.Text, out @double))
            {
                @double = double.NaN;
            }

            if (!Core.Query.AlmostEqual(@double, double_Template, Core.Tolerance.Distance))
            {
                TextBox_Lighting_GainPerArea.BackColor = color_Modified;
                reset = true;
            }

            if (!internalCondition_Template.TryGetValue(InternalConditionParameter.LightingLevel, out double_Template))
            {
                double_Template = double.NaN;
            }

            if (!Core.Query.TryConvert(TextBox_Lighting_Level.Text, out @double))
            {
                @double = double.NaN;
            }

            if (!Core.Query.AlmostEqual(@double, double_Template, Core.Tolerance.Distance))
            {
                TextBox_Lighting_Level.BackColor = color_Modified;
                reset = true;
            }

            //Equipment Sensible

            if (!internalCondition_Template.TryGetValue(InternalConditionParameter.EquipmentSensibleProfileName, out string_Template))
            {
                string_Template = null;
            }

            string_Template = string.IsNullOrEmpty(string_Template) ? null : string_Template;
            @string = string.IsNullOrEmpty(TextBox_Equipment_SensibleProfileName.Text) ? null : TextBox_Equipment_SensibleProfileName.Text;

            if (@string != string_Template)
            {
                TextBox_Equipment_SensibleProfileName.BackColor = color_Modified;
                TextBox_Equipment_SensibleProfileGuid.BackColor = color_Modified;
                reset = true;
            }

            if (!internalCondition_Template.TryGetValue(InternalConditionParameter.EquipmentSensibleGainPerArea, out double_Template))
            {
                double_Template = double.NaN;
            }

            if (!Core.Query.TryConvert(TextBox_Equipment_SensibleGainPerArea.Text, out @double))
            {
                @double = double.NaN;
            }

            if (!Core.Query.AlmostEqual(@double, double_Template, Core.Tolerance.Distance))
            {
                TextBox_Equipment_SensibleGainPerArea.BackColor = color_Modified;
                reset = true;
            }

            if (!internalCondition_Template.TryGetValue(InternalConditionParameter.EquipmentSensibleGain, out double_Template))
            {
                double_Template = double.NaN;
            }

            if (!Core.Query.TryConvert(TextBox_Equipment_SensibleGain.Text, out @double))
            {
                @double = double.NaN;
            }

            if (!Core.Query.AlmostEqual(@double, double_Template, Core.Tolerance.Distance))
            {
                TextBox_Equipment_SensibleGain.BackColor = color_Modified;
                reset = true;
            }

            //Equipment Latent

            if (!internalCondition_Template.TryGetValue(InternalConditionParameter.EquipmentLatentProfileName, out string_Template))
            {
                string_Template = null;
            }

            string_Template = string.IsNullOrEmpty(string_Template) ? null : string_Template;
            @string = string.IsNullOrEmpty(TextBox_Equipment_LatentProfileName.Text) ? null : TextBox_Equipment_LatentProfileName.Text;

            if (@string != string_Template)
            {
                TextBox_Equipment_LatentProfileName.BackColor = color_Modified;
                TextBox_Equipment_LatentProfileGuid.BackColor = color_Modified;
                reset = true;
            }

            if (!internalCondition_Template.TryGetValue(InternalConditionParameter.EquipmentLatentGainPerArea, out double_Template))
            {
                double_Template = double.NaN;
            }

            if (!Core.Query.TryConvert(TextBox_Equipment_LatentGainPerArea.Text, out @double))
            {
                @double = double.NaN;
            }

            if (!Core.Query.AlmostEqual(@double, double_Template, Core.Tolerance.Distance))
            {
                TextBox_Equipment_LatentGainPerArea.BackColor = color_Modified;
                reset = true;
            }

            if (!internalCondition_Template.TryGetValue(InternalConditionParameter.EquipmentLatentGain, out double_Template))
            {
                double_Template = double.NaN;
            }

            if (!Core.Query.TryConvert(TextBox_Equipment_LatentGain.Text, out @double))
            {
                @double = double.NaN;
            }

            if (!Core.Query.AlmostEqual(@double, double_Template, Core.Tolerance.Distance))
            {
                TextBox_Equipment_LatentGain.BackColor = color_Modified;
                reset = true;
            }

            //Humidification

            if (!internalCondition_Template.TryGetValue(InternalConditionParameter.HumidificationProfileName, out string_Template))
            {
                string_Template = null;
            }

            string_Template = string.IsNullOrEmpty(string_Template) ? null : string_Template;
            @string = string.IsNullOrEmpty(TextBox_Humidity_ProfileName.Text) ? null : TextBox_Humidity_ProfileName.Text;

            if (@string != string_Template)
            {
                TextBox_Humidity_ProfileName.BackColor = color_Modified;
                TextBox_Humidity_ProfileGuid.BackColor = color_Modified;
                TextBox_Humidity.BackColor = color_Modified;
                reset = true;
            }

            //Dehumidification

            if (!internalCondition_Template.TryGetValue(InternalConditionParameter.DehumidificationProfileName, out string_Template))
            {
                string_Template = null;
            }

            string_Template = string.IsNullOrEmpty(string_Template) ? null : string_Template;
            @string = string.IsNullOrEmpty(TextBox_Dehumidity_ProfileName.Text) ? null : TextBox_Dehumidity_ProfileName.Text;

            if (@string != string_Template)
            {
                TextBox_Dehumidity_ProfileName.BackColor = color_Modified;
                TextBox_Dehumidity_ProfileGuid.BackColor = color_Modified;
                TextBox_Dehumidity.BackColor = color_Modified;
                reset = true;
            }

            if (!internalCondition_Template.TryGetValue(InternalConditionParameter.InfiltrationProfileName, out string_Template))
            {
                string_Template = null;
            }

            //Infiltration

            string_Template = string.IsNullOrEmpty(string_Template) ? null : string_Template;
            @string = string.IsNullOrEmpty(TextBox_Infiltration_ProfileName.Text) ? null : TextBox_Infiltration_ProfileName.Text;

            if (!string.IsNullOrWhiteSpace(@string) && !string.IsNullOrWhiteSpace(string_Template) && @string != string_Template)
            {
                TextBox_Infiltration_ProfileName.BackColor = color_Modified;
                TextBox_Infiltration_ProfileGuid.BackColor = color_Modified;
                reset = true;
            }

            if (!internalCondition_Template.TryGetValue(InternalConditionParameter.InfiltrationAirChangesPerHour, out double_Template))
            {
                double_Template = double.NaN;
            }

            if (!Core.Query.TryConvert(TextBox_Infiltration.Text, out @double))
            {
                @double = double.NaN;
            }

            if (!Core.Query.AlmostEqual(@double, double_Template, Core.Tolerance.Distance))
            {
                TextBox_Infiltration.BackColor = color_Modified;
                reset = true;
            }

            //Ventilation System

            if (!internalCondition_Template.TryGetValue(InternalConditionParameter.VentilationSystemTypeName, out string_Template))
            {
                string_Template = null;
            }

            string_Template = string.IsNullOrEmpty(string_Template) ? null : string_Template;
            @string = string.IsNullOrEmpty(TextBox_VentilationSystem_Name.Text) ? null : TextBox_VentilationSystem_Name.Text;

            if (@string != string_Template)
            {
                TextBox_VentilationSystem_Name.BackColor = color_Modified;
                TextBox_VentilationSystem_Guid.BackColor = color_Modified;
                reset = true;
            }

            //Heating System

            if (!internalCondition_Template.TryGetValue(InternalConditionParameter.HeatingSystemTypeName, out string_Template))
            {
                string_Template = null;
            }

            string_Template = string.IsNullOrEmpty(string_Template) ? null : string_Template;
            @string = string.IsNullOrEmpty(TextBox_HeatingSystem_Name.Text) ? null : TextBox_HeatingSystem_Name.Text;

            if (@string != string_Template)
            {
                TextBox_HeatingSystem_Name.BackColor = color_Modified;
                TextBox_HeatingSystem_Guid.BackColor = color_Modified;
                reset = true;
            }

            //Cooling System

            if (!internalCondition_Template.TryGetValue(InternalConditionParameter.CoolingSystemTypeName, out string_Template))
            {
                string_Template = null;
            }

            string_Template = string.IsNullOrEmpty(string_Template) ? null : string_Template;
            @string = string.IsNullOrEmpty(TextBox_CoolingSystem_Name.Text) ? null : TextBox_CoolingSystem_Name.Text;

            if (@string != string_Template)
            {
                TextBox_CoolingSystem_Name.BackColor = color_Modified;
                TextBox_CoolingSystem_Guid.BackColor = color_Modified;
                reset = true;
            }

            Button_Reset.Enabled = reset;

        }

        private void InternalConditionControl_Load(object sender, System.EventArgs e)
        {
            TextBox_AreaPerPerson.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_NumberOnly);

            TextBox_Infiltration.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_NumberOnly);

            TextBox_Occupancy_SensibleGain_Calculated.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_NumberOnly);
            TextBox_Occupancy_LatentGain_Calculated.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_NumberOnly);
            TextBox_Occupancy_SensibleGainPerPerson.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_NumberOnly);
            TextBox_Occupancy_LatentGainPerPerson.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_NumberOnly);
            
            TextBox_Equipment_SensibleGain.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_NumberOnly);
            TextBox_Equipment_LatentGain.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_NumberOnly);
            TextBox_Equipment_SensibleGainPerArea.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_NumberOnly);
            TextBox_Equipment_LatentGainPerArea.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_NumberOnly);

            TextBox_Lighting_Gain.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_NumberOnly);
            TextBox_Lighting_GainPerArea.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_NumberOnly);
            TextBox_Lighting_Level.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_NumberOnly);


            TextBox_Name.TextChanged += TextBox_TextChanged;

            TextBox_AreaPerPerson.TextChanged += TextBox_TextChanged;

            TextBox_Heating_ProfileName.TextChanged += TextBox_TextChanged;

            TextBox_Cooling_ProfileName.TextChanged += TextBox_TextChanged;

            TextBox_Occupancy_ProfileName.TextChanged += TextBox_TextChanged;

            TextBox_Lighting_ProfileName.TextChanged += TextBox_TextChanged;
            TextBox_Lighting_Gain.TextChanged += TextBox_TextChanged;
            TextBox_Lighting_GainPerArea.TextChanged += TextBox_TextChanged;
            TextBox_Lighting_Level.TextChanged += TextBox_TextChanged;

            //TextBox_Occupancy_SensibleGain_Calculated.TextChanged += TextBox_TextChanged;
            TextBox_Occupancy_SensibleGainPerPerson.TextChanged += TextBox_TextChanged;
            //TextBox_Occupancy_LatentGain_Calculated.TextChanged += TextBox_TextChanged;
            TextBox_Occupancy_LatentGainPerPerson.TextChanged += TextBox_TextChanged;

            TextBox_Equipment_SensibleProfileName.TextChanged += TextBox_TextChanged;
            //TextBox_Equipment_SensibleGainCalculated.TextChanged += TextBox_TextChanged;
            TextBox_Equipment_SensibleGainPerArea.TextChanged += TextBox_TextChanged;
            TextBox_Equipment_SensibleGain.TextChanged += TextBox_TextChanged;

            TextBox_Equipment_LatentProfileName.TextChanged += TextBox_TextChanged;
            //TextBox_Equipment_LatentGainCalculated.TextChanged += TextBox_TextChanged;
            TextBox_Equipment_LatentGainPerArea.TextChanged += TextBox_TextChanged;
            TextBox_Equipment_LatentGain.TextChanged += TextBox_TextChanged;

            TextBox_Humidity_ProfileName.TextChanged += TextBox_TextChanged;
            TextBox_Dehumidity_ProfileName.TextChanged += TextBox_TextChanged;

            TextBox_Infiltration_ProfileName.TextChanged += TextBox_TextChanged;
            TextBox_Infiltration.TextChanged += TextBox_TextChanged;

            TextBox_VentilationSystem_Name.TextChanged += TextBox_TextChanged;
            TextBox_HeatingSystem_Name.TextChanged += TextBox_TextChanged;
            TextBox_CoolingSystem_Name.TextChanged += TextBox_TextChanged;

            TextBox_SupplyUnit_Name.TextChanged += TextBox_TextChanged;
            TextBox_ExhaustUnit_Name.TextChanged += TextBox_TextChanged;
        }

        private void TextBox_TextChanged(object sender, System.EventArgs e)
        {
            ApplyColors();
        }

        private void Button_Select_Click(object sender, System.EventArgs e)
        {
            InternalConditionLibrary internalConditionLibrary = new InternalConditionLibrary("Internal Condition Library");
            adjacencyCluster?.GetInternalConditions(false, true)?.ToList().ForEach(x => internalConditionLibrary.Add(x));

            using (Forms.InternalConditionLibraryForm internalConditionForm = new Forms.InternalConditionLibraryForm(internalConditionLibrary, profileLibrary, adjacencyCluster, InternalCondition))
            {
                if (internalConditionForm.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                profileLibrary = internalConditionForm.ProfileLibrary;
                adjacencyCluster = internalConditionForm.AdjacencyCluster;

                Space space = Space;
                if (space != null)
                {
                    space.InternalCondition = internalConditionForm.GetInternalConditions(true)?.FirstOrDefault();
                    Space = space;
                }
                else
                {
                    InternalCondition = internalConditionForm.GetInternalConditions(true)?.FirstOrDefault();
                }
            }
        }

        private void Button_Reset_Click(object sender, System.EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to reset values", "Reset", MessageBoxButtons.YesNo);
            if(dialogResult != DialogResult.Yes)
            {
                return;
            }

            InternalCondition internalCondition_Template = adjacencyCluster?.GetInternalConditions(false, true)?.ToList().Find(x => x.Name == TextBox_Name.Text);
            if (internalCondition_Template == null)
            {
                return;
            }

            LoadInternalCondition(internalCondition_Template);
        }

        private void Button_HeatingProfile_Click(object sender, System.EventArgs e)
        {
            Profile profile = Modify.SelectProfile(profileLibrary, ProfileGroup.Thermostat);
            if (profile == null)
            {
                return;
            }

            TextBox_Heating_ProfileName.Text = profile.Name;
            TextBox_Heating_ProfileGuid.Text = profile.Guid.ToString();

            InternalCondition internalCondition = GetInternalCondition();

            double @double = Analytical.Query.HeatingDesignTemperature(internalCondition, profileLibrary);
            TextBox_Heating_DesignTemperature.Text = double.IsNaN(@double) ? null : Core.Query.Round(@double, Core.Tolerance.MacroDistance).ToString();
        }

        private void Button_CoolingProfile_Click(object sender, System.EventArgs e)
        {
            Profile profile = Modify.SelectProfile(profileLibrary, ProfileGroup.Thermostat);
            if (profile == null)
            {
                return;
            }

            TextBox_Cooling_ProfileName.Text = profile.Name;
            TextBox_Cooling_ProfileGuid.Text = profile.Guid.ToString();

            InternalCondition internalCondition = GetInternalCondition();

            double @double = Analytical.Query.CoolingDesignTemperature(internalCondition, profileLibrary);
            TextBox_Cooling_DesignTemperature.Text = double.IsNaN(@double) ? null : Core.Query.Round(@double, Core.Tolerance.MacroDistance).ToString();
        }

        private void Button_OccupancyProfile_Click(object sender, System.EventArgs e)
        {
            Profile profile = Modify.SelectProfile(profileLibrary, ProfileGroup.Gain);
            if (profile == null)
            {
                return;
            }

            TextBox_Occupancy_ProfileName.Text = profile.Name;
            TextBox_Occupancy_ProfileGuid.Text = profile.Guid.ToString();

            InternalCondition internalCondition = GetInternalCondition();

            double value;

            if (!internalCondition.TryGetValue(InternalConditionParameter.OccupancyLatentGainPerPerson, out value))
            {
                value = double.NaN;
            }

            TextBox_Occupancy_LatentGainPerPerson.Text = double.IsNaN(value) ? null : Core.Query.Round(value, Core.Tolerance.MacroDistance).ToString();

            if (!internalCondition.TryGetValue(InternalConditionParameter.OccupancySensibleGainPerPerson, out value))
            {
                value = double.NaN;
            }

            TextBox_Occupancy_SensibleGainPerPerson.Text = double.IsNaN(value) ? null : Core.Query.Round(value, Core.Tolerance.MacroDistance).ToString();

        }

        private void Button_LightingProfile_Click(object sender, System.EventArgs e)
        {
            Profile profile = Modify.SelectProfile(profileLibrary, ProfileGroup.Gain);
            if (profile == null)
            {
                return;
            }

            TextBox_Lighting_ProfileName.Text = profile.Name;
            TextBox_Lighting_ProfileGuid.Text = profile.Guid.ToString();

            InternalCondition internalCondition = GetInternalCondition();

            double value;

            if (!internalCondition.TryGetValue(InternalConditionParameter.LightingGain, out value))
            {
                value = double.NaN;
            }

            TextBox_Lighting_Gain.Text = double.IsNaN(value) ? null : Core.Query.Round(value, Core.Tolerance.MacroDistance).ToString();

            if (!internalCondition.TryGetValue(InternalConditionParameter.LightingLevel, out value))
            {
                value = double.NaN;
            }

            TextBox_Lighting_Level.Text = double.IsNaN(value) ? null : Core.Query.Round(value, Core.Tolerance.MacroDistance).ToString();
        }

        private void Button_EquipmentSensibleProfile_Click(object sender, System.EventArgs e)
        {
            Profile profile = Modify.SelectProfile(profileLibrary, ProfileGroup.Gain);
            if (profile == null)
            {
                return;
            }

            TextBox_Equipment_SensibleProfileName.Text = profile.Name;
            TextBox_Equipment_SensibleProfileGuid.Text = profile.Guid.ToString();

            InternalCondition internalCondition = GetInternalCondition();

            double value;

            if (!internalCondition.TryGetValue(InternalConditionParameter.EquipmentSensibleGainPerArea, out value))
            {
                value = double.NaN;
            }

            TextBox_Equipment_SensibleGainPerArea.Text = double.IsNaN(value) ? null : Core.Query.Round(value, Core.Tolerance.MacroDistance).ToString();

            if (!internalCondition.TryGetValue(InternalConditionParameter.EquipmentSensibleGain, out value))
            {
                value = double.NaN;
            }

            TextBox_Equipment_SensibleGain.Text = double.IsNaN(value) ? null : Core.Query.Round(value, Core.Tolerance.MacroDistance).ToString();
        }

        private void Button_EquipmentLatentProfile_Click(object sender, System.EventArgs e)
        {
            Profile profile = Modify.SelectProfile(profileLibrary, ProfileGroup.Gain);
            if (profile == null)
            {
                return;
            }

            TextBox_Equipment_LatentProfileName.Text = profile.Name;
            TextBox_Equipment_LatentProfileGuid.Text = profile.Guid.ToString();

            InternalCondition internalCondition = GetInternalCondition();

            double value;

            if (!internalCondition.TryGetValue(InternalConditionParameter.EquipmentLatentGainPerArea, out value))
            {
                value = double.NaN;
            }

            TextBox_Equipment_LatentGainPerArea.Text = double.IsNaN(value) ? null : Core.Query.Round(value, Core.Tolerance.MacroDistance).ToString();

            if (!internalCondition.TryGetValue(InternalConditionParameter.EquipmentLatentGain, out value))
            {
                value = double.NaN;
            }

            TextBox_Equipment_LatentGain.Text = double.IsNaN(value) ? null : Core.Query.Round(value, Core.Tolerance.MacroDistance).ToString();
        }

        private void Button_HumidificationProfile_Click(object sender, System.EventArgs e)
        {
            Profile profile = Modify.SelectProfile(profileLibrary, ProfileGroup.Humidistat);
            if (profile == null)
            {
                return;
            }

            TextBox_Humidity_ProfileName.Text = profile.Name;
            TextBox_Humidity_ProfileGuid.Text = profile.Guid.ToString();

            double @double = profile.MaxValue;
            if (!double.IsNaN(@double))
            {
                TextBox_Humidity.Text = Core.Query.Round(@double, Core.Tolerance.MacroDistance).ToString();
            }
        }

        private void Button_DehumidificationProfile_Click(object sender, System.EventArgs e)
        {
            Profile profile = Modify.SelectProfile(profileLibrary, ProfileGroup.Humidistat);
            if (profile == null)
            {
                return;
            }

            TextBox_Dehumidity_ProfileName.Text = profile.Name;
            TextBox_Dehumidity_ProfileGuid.Text = profile.Guid.ToString();

            double @double = profile.MinValue;
            if (!double.IsNaN(@double))
            {
                TextBox_Dehumidity.Text = Core.Query.Round(@double, Core.Tolerance.MacroDistance).ToString();
            }
        }

        private void Button_InfiltrationProfile_Click(object sender, System.EventArgs e)
        {
            Profile profile = Modify.SelectProfile(profileLibrary, ProfileGroup.Gain);
            if (profile == null)
            {
                return;
            }

            TextBox_Infiltration_ProfileName.Text = profile.Name;
            TextBox_Infiltration_ProfileGuid.Text = profile.Guid.ToString();

            InternalCondition internalCondition = GetInternalCondition();

            double value;

            if (!internalCondition.TryGetValue(InternalConditionParameter.InfiltrationAirChangesPerHour, out value))
            {
                value = double.NaN;
            }

            TextBox_Infiltration.Text = double.IsNaN(value) ? null : Core.Query.Round(value, Core.Tolerance.MacroDistance).ToString();
        }

        private void TextBox_Equipment_SensibleGainPerArea_TextChanged(object sender, System.EventArgs e)
        {
            Space space = Space;
            if(space == null)
            {
                return;
            }

            space = new Space(space);
            space.InternalCondition = GetInternalCondition();

            double @double = Analytical.Query.CalculatedEquipmentSensibleGain(space);
            TextBox_Equipment_SensibleGainCalculated.Text = double.IsNaN(@double) ? null : Core.Query.Round(@double, Core.Tolerance.MacroDistance).ToString();
        }

        private void TextBox_Equipment_SensibleGain_TextChanged(object sender, System.EventArgs e)
        {
            Space space = Space;
            if (space == null)
            {
                return;
            }

            space = new Space(space);
            space.InternalCondition = GetInternalCondition();

            double @double = Analytical.Query.CalculatedEquipmentSensibleGain(space);
            TextBox_Equipment_SensibleGainCalculated.Text = double.IsNaN(@double) ? null : Core.Query.Round(@double, Core.Tolerance.MacroDistance).ToString();
        }

        private void TextBox_Equipment_LatentGainPerArea_TextChanged(object sender, System.EventArgs e)
        {
            Space space = Space;
            if (space == null)
            {
                return;
            }

            space = new Space(space);
            space.InternalCondition = GetInternalCondition();

            double @double = Analytical.Query.CalculatedEquipmentLatentGain(space);
            TextBox_Equipment_LatentGainCalculated.Text = double.IsNaN(@double) ? null : Core.Query.Round(@double, Core.Tolerance.MacroDistance).ToString();
        }

        private void TextBox_Equipment_LatentGain_TextChanged(object sender, System.EventArgs e)
        {
            Space space = Space;
            if (space == null)
            {
                return;
            }

            space = new Space(space);
            space.InternalCondition = GetInternalCondition();

            double @double = Analytical.Query.CalculatedEquipmentLatentGain(space);
            TextBox_Equipment_LatentGainCalculated.Text = double.IsNaN(@double) ? null : Core.Query.Round(@double, Core.Tolerance.MacroDistance).ToString();
        }

        private void TextBox_Lighting_GainPerArea_TextChanged(object sender, System.EventArgs e)
        {
            Space space = Space;
            if (space == null)
            {
                return;
            }

            space = new Space(space);
            space.InternalCondition = GetInternalCondition();

            double @double = Analytical.Query.CalculatedLightingGain(space);
            TextBox_Lighting_GainCalculated.Text = double.IsNaN(@double) ? null : Core.Query.Round(@double, Core.Tolerance.MacroDistance).ToString();
        }

        private void TextBox_Lighting_Gain_TextChanged(object sender, System.EventArgs e)
        {
            Space space = Space;
            if (space == null)
            {
                return;
            }

            space = new Space(space);
            space.InternalCondition = GetInternalCondition();

            double @double = Analytical.Query.CalculatedLightingGain(space);
            TextBox_Lighting_GainCalculated.Text = double.IsNaN(@double) ? null : Core.Query.Round(@double, Core.Tolerance.MacroDistance).ToString();
        }

        private void TextBox_AreaPerPerson_TextChanged(object sender, System.EventArgs e)
        {
            Space space = Space;
            if (space == null)
            {
                return;
            }

            space = new Space(space);
            space.InternalCondition = GetInternalCondition();

            double @double;

            @double = Analytical.Query.OccupancySensibleGain(space);

            TextBox_Occupancy_SensibleGain_Calculated.Text = double.IsNaN(@double) ? null : Core.Query.Round(@double, Core.Tolerance.MacroDistance).ToString();

            @double = Analytical.Query.OccupancyLatentGain(space);

            TextBox_Occupancy_LatentGain_Calculated.Text = double.IsNaN(@double) ? null : Core.Query.Round(@double, Core.Tolerance.MacroDistance).ToString();
        }

        private void TextBox_Occupancy_SensibleGainPerPerson_TextChanged(object sender, System.EventArgs e)
        {
            Space space = Space;
            if (space == null)
            {
                return;
            }

            space = new Space(space);
            space.InternalCondition = GetInternalCondition();

            double @double;

            @double = Analytical.Query.OccupancySensibleGain(space);

            TextBox_Occupancy_SensibleGain_Calculated.Text = double.IsNaN(@double) ? null : Core.Query.Round(@double, Core.Tolerance.MacroDistance).ToString();

            @double = Analytical.Query.OccupancyLatentGain(space);

            TextBox_Occupancy_LatentGain_Calculated.Text = double.IsNaN(@double) ? null : Core.Query.Round(@double, Core.Tolerance.MacroDistance).ToString();
        }

        private void TextBox_Occupancy_LatentGainPerPerson_TextChanged(object sender, System.EventArgs e)
        {
            Space space = Space;
            if (space == null)
            {
                return;
            }

            space = new Space(space);
            space.InternalCondition = GetInternalCondition();

            double @double;

            @double = Analytical.Query.OccupancySensibleGain(space);

            TextBox_Occupancy_SensibleGain_Calculated.Text = double.IsNaN(@double) ? null : Core.Query.Round(@double, Core.Tolerance.MacroDistance).ToString();

            @double = Analytical.Query.OccupancyLatentGain(space);

            TextBox_Occupancy_LatentGain_Calculated.Text = double.IsNaN(@double) ? null : Core.Query.Round(@double, Core.Tolerance.MacroDistance).ToString();
        }
    }
}
