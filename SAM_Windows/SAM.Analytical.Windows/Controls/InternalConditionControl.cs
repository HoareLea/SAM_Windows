using System.Windows.Forms;

namespace SAM.Analytical.Windows.Controls
{
    public partial class InternalConditionControl : UserControl
    {
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
                return @object as Space;
            }

            set
            {
                @object = value;
                LoadObject();
            }
        }

        public InternalCondition InternalCondition
        {
            get
            {
                if(@object is Space)
                {
                    return ((Space)@object).InternalCondition;
                }

                return @object as InternalCondition;
            }

            set
            {
                @object = value;
                LoadObject();
            }
        }

        public ProfileLibrary ProfileLibrary
        {
            get
            {
                return profileLibrary;
            }

            set
            {
                profileLibrary = value;
                LoadObject();
            }
        }

        public AdjacencyCluster AdjacencyCluster
        {
            get
            {
                return adjacencyCluster;
            }
            set
            {
                adjacencyCluster = value;
                LoadObject();
            }
        }

        private void LoadObject()
        {
            InternalCondition internalCondition = @object as InternalCondition;
            if(internalCondition == null)
            {
                internalCondition = (@object as Space)?.InternalCondition;
            }

            Space space = @object as Space;

            if(space == null)
            {
                Button_Select.Visible = false;
                Button_Create.Visible = false;
                TextBox_Occupancy_SensibleGain.Visible = false;
                Label_Occupancy_SensibleGain_W.Visible = false;
                TextBox_Occupancy_LatentGain.Visible = false;
                Label_Occupancy_LatentGain_W.Visible = false;
                TextBox_Equipment_SensibleGain.Visible = false;
                TextBox_Equipment_SensibleGain_W.Visible = false;
                TextBox_Equipment_LatentGain.Visible = false;
                Label_Equipment_LatentGain_W.Visible = false;

                Label_SupplyUnit_AirFlow.Visible = false;
                TextBox_SupplyUnit_AirFlow.Visible = false;
                Label_ExhaustUnit_AirFlow.Visible = false;
                TextBox_ExhaustUnit_AirFlow.Visible = false;
            }
            else
            {
                Button_Select.Visible = true;
                Button_Create.Visible = true;
                TextBox_Occupancy_SensibleGain.Visible = true;
                Label_Occupancy_SensibleGain_W.Visible = true;
                TextBox_Occupancy_LatentGain.Visible = true;
                Label_Occupancy_LatentGain_W.Visible = true;
                TextBox_Equipment_SensibleGain.Visible = true;
                TextBox_Equipment_SensibleGain_W.Visible = true;
                TextBox_Equipment_LatentGain.Visible = true;
                Label_Equipment_LatentGain_W.Visible = true;

                Label_SupplyUnit_AirFlow.Visible = true;
                TextBox_SupplyUnit_AirFlow.Visible = true;
                Label_ExhaustUnit_AirFlow.Visible = true;
                TextBox_ExhaustUnit_AirFlow.Visible = true;
            }

            TextBox_Name.Text = null;
            TextBox_AreaPerPerson.Text = null;

            TextBox_Infiltration_ProfileName.Text = null;
            TextBox_Infiltration_ProfileGuid.Text = null;
            TextBox_Infiltration.Text = null;

            TextBox_Occupancy_ProfileName.Text = null;
            TextBox_Occupancy_ProfileGuid.Text = null;
            TextBox_Occupancy_SensibleGainPerArea.Text = null;
            TextBox_Occupancy_SensibleGain.Text = null;
            TextBox_Occupancy_LatentGainPerArea.Text = null;
            TextBox_Occupancy_LatentGain.Text = null;

            TextBox_Equipment_SensibleProfileName.Text = null;
            TextBox_Equipment_SensibleProfileGuid.Text = null;
            TextBox_Equipment_SensibleGain.Text = null;
            TextBox_Equipment_SensibleGainPerArea.Text = null;

            TextBox_Equipment_LatentProfileName.Text = null;
            TextBox_Equipment_LatentProfileGuid.Text = null;
            TextBox_Equipment_LatentGain.Text = null;
            TextBox_Equipment_LatentGainPerArea.Text = null;

            TextBox_Lighting_ProfileName.Text = null;
            TextBox_Lighting_ProfileGuid.Text = null;
            TextBox_Lighting_Gain.Text = null;
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


            if (InternalCondition != null)
            {
                TextBox_Name.Text = internalCondition.Name;

                double @double = double.NaN;
                string @string = null;
                Profile profile = null;

                if (internalCondition.TryGetValue(InternalConditionParameter.AreaPerPerson, out @double) && !double.IsNaN(@double))
                {
                    TextBox_AreaPerPerson.Text = @double.ToString();
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
                    TextBox_Infiltration.Text = @double.ToString();
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
                    TextBox_Occupancy_SensibleGainPerArea.Text = @double.ToString();
                }

                if (space!= null)
                {
                    @double = Analytical.Query.OccupancySensibleGain(space);
                    if(!double.IsNaN(@double))
                    {
                        TextBox_Occupancy_SensibleGain.Text = @double.ToString();
                    }
                }

                if (internalCondition.TryGetValue(InternalConditionParameter.OccupancyLatentGainPerPerson, out @double) && !double.IsNaN(@double))
                {
                    TextBox_Occupancy_LatentGainPerArea.Text = @double.ToString();
                }

                if (space != null)
                {
                    @double = Analytical.Query.OccupancyLatentGain(space);
                    if (!double.IsNaN(@double))
                    {
                        TextBox_Occupancy_LatentGain.Text = @double.ToString();
                    }
                }

                //Equipment

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
                    TextBox_Equipment_SensibleGainPerArea.Text = @double.ToString();
                }

                if (space != null)
                {
                    @double = Analytical.Query.CalculatedEquipmentSensibleGain(space);
                    if (!double.IsNaN(@double))
                    {
                        TextBox_Equipment_SensibleGain.Text = @double.ToString();
                    }
                }

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
                    TextBox_Equipment_LatentGainPerArea.Text = @double.ToString();
                }

                if (space != null)
                {
                    @double = Analytical.Query.CalculatedEquipmentLatentGain(space);
                    if (!double.IsNaN(@double))
                    {
                        TextBox_Equipment_LatentGain.Text = @double.ToString();
                    }
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
                    TextBox_Lighting_Gain.Text = @double.ToString();
                }

                if (internalCondition.TryGetValue(InternalConditionParameter.LightingLevel, out @double) && !double.IsNaN(@double))
                {
                    TextBox_Lighting_Level.Text = @double.ToString();
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
                    TextBox_Heating_DesignTemperature.Text = @double.ToString();
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
                    TextBox_Cooling_DesignTemperature.Text = @double.ToString();
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
                    if(!double.IsNaN(@double))
                    {
                        TextBox_Humidity.Text = @double.ToString();
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
                        TextBox_Dehumidity.Text = @double.ToString();
                    }
                }

                //VentilationSystem

                @string = internalCondition.GetSystemTypeName<VentilationSystemType>();
                if(!string.IsNullOrWhiteSpace(@string))
                {
                    TextBox_VentilationSystem_Name.Text = @string;
                    VentilationSystem ventilationSystem = null;
                    if (space != null)
                    {
                        ventilationSystem = adjacencyCluster?.GetRelatedObjects<VentilationSystem>(space)?.Find(x => x.Name == @string);
                    }

                    if(ventilationSystem == null)
                    {
                        adjacencyCluster?.GetObject((VentilationSystem x) => x.Name == @string);
                    }

                    if(ventilationSystem != null)
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

                if(space != null)
                {
                    @double = Analytical.Query.SupplyAirFlow(space);
                    if(!double.IsNaN(@double))
                    {
                        TextBox_SupplyUnit_AirFlow.Text = @double.ToString();
                    }

                    @double = Analytical.Query.ExhaustAirFlow(space);
                    if (!double.IsNaN(@double))
                    {
                        TextBox_ExhaustUnit_AirFlow.Text = @double.ToString();
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

                    if(heatingSystem != null)
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
        }

        private void InternalConditionControl_Load(object sender, System.EventArgs e)
        {
            TextBox_AreaPerPerson.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_NumberOnly);
            
            TextBox_Infiltration.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_NumberOnly);
            
            TextBox_Occupancy_SensibleGain.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_NumberOnly);
            TextBox_Occupancy_LatentGain.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_NumberOnly);
            TextBox_Occupancy_SensibleGainPerArea.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_NumberOnly);
            TextBox_Occupancy_LatentGainPerArea.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_NumberOnly);

            TextBox_Lighting_Gain.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_NumberOnly);
            TextBox_Lighting_Level.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_NumberOnly);

            TextBox_Heating_DesignTemperature.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_NumberOnly);
            
            TextBox_Cooling_DesignTemperature.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_NumberOnly);

            TextBox_Humidity.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_NumberOnly);

            TextBox_Dehumidity.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_NumberOnly);

            TextBox_SupplyUnit_AirFlow.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_NumberOnly);

            TextBox_ExhaustUnit_AirFlow.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_NumberOnly);
        }
    }
}
