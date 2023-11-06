using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace SAM.Core.Windows
{
    public partial class MaterialControl : UserControl
    {
        private IMaterial material;
        private HashSet<Enum> enums;

        public MaterialControl()
        {
            InitializeComponent();
        }

        public MaterialControl(IMaterial material, IEnumerable<Enum> enums = null)
        {
            InitializeComponent();

            this.material = material;

            if (enums != null)
            {
                this.enums = new HashSet<Enum>();
                foreach (Enum @enum in enums)
                {
                    this.enums.Add(@enum);
                }
            }
        }

        private void MaterialControl_Load(object sender, EventArgs e)
        {
            foreach(MaterialType materialType in Enum.GetValues(typeof(MaterialType)))
            {
                ComboBox_MaterialType.Items.Add(SAM.Core.Query.Description(materialType));
            }
            
            PropertyGrid_Parameters.HidePropertyPages();

            TextBox_ThermalConductivity.KeyPress += new KeyPressEventHandler(EventHandler.ControlText_NumberOnly);
            TextBox_SpecificHeatCapacity.KeyPress += new KeyPressEventHandler(EventHandler.ControlText_NumberOnly);
            TextBox_Density.KeyPress += new KeyPressEventHandler(EventHandler.ControlText_NumberOnly);

            LoadMaterial();
        }

        private void LoadMaterial()
        {
            TextBox_Name.Text = material?.Name;
            Material material_Temp = material as Material;
            if (material_Temp != null)
            {
                TextBox_DisplayName.Text = material_Temp.DisplayName;
                TextBox_Description.Text = material_Temp.Description;

                string value;

                value = double.IsNaN(material_Temp.ThermalConductivity) ? null : material_Temp.ThermalConductivity.ToString();
                TextBox_ThermalConductivity.Text = value;

                value = double.IsNaN(material_Temp.SpecificHeatCapacity) ? null : material_Temp.SpecificHeatCapacity.ToString();
                TextBox_SpecificHeatCapacity.Text = value;

                value = double.IsNaN(material_Temp.Density) ? null : material_Temp.Density.ToString();
                TextBox_Density.Text = value;

                ComboBox_MaterialType.Text = SAM.Core.Query.Description(Core.Query.MaterialType(material_Temp));
            }

            LoadParameters();
        }

        private void LoadParameters()
        {
            PropertyGrid_Parameters.SelectedObject = null;

            Material material_Temp = material as Material;
            if (material_Temp != null)
            {
                CustomParameters customParameters = Create.CustomParameters(material_Temp, enums?.ToArray());

                if (material_Temp is FluidMaterial)
                {
                    FluidMaterial fluidMaterial = (FluidMaterial)material_Temp;
                    CustomParameter customParameter = new CustomParameter("Dynamic Viscosity", "Dynamic Viscosity of Fluid [kg/(m*s)]", AccessType.ReadWrite, new Attributes.DoubleParameterValue(0), typeof(FluidMaterial).Assembly.Name(), fluidMaterial.DynamicViscosity);

                    customParameters?.Add(customParameter);
                }

                PropertyGrid_Parameters.SelectedObject = customParameters;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IMaterial Material
        {
            get
            {
                if (material == null)
                {
                    return null;
                }

                string name = TextBox_Name.Text;
                string displayName = TextBox_DisplayName.Text;
                string description = TextBox_Description.Text;
                if (!Core.Query.TryConvert(TextBox_ThermalConductivity.Text, out double thermalConductivity))
                {
                    thermalConductivity = double.NaN;
                }

                if (!Core.Query.TryConvert(TextBox_SpecificHeatCapacity.Text, out double specificHeatCapacity))
                {
                    specificHeatCapacity = double.NaN;
                }

                if (!Core.Query.TryConvert(TextBox_SpecificHeatCapacity.Text, out double density))
                {
                    density = double.NaN;
                }

                CustomParameters customParameters = PropertyGrid_Parameters.SelectedObject as CustomParameters;

                IMaterial result = null;
                switch (material.MaterialType())
                {
                    case MaterialType.Gas:

                        double dynamicViscosity = double.NaN;

                        CustomParameter customParameter = customParameters?.Cast<CustomParameter>().ToList().Find(x => x?.Name == "Dynamic Viscosity");
                        if(customParameter != null)
                        {
                            if (!Core.Query.TryConvert(customParameter.Value, out dynamicViscosity))
                            {
                                dynamicViscosity = double.NaN;
                            }
                        }

                        result = new GasMaterial(material.Guid, name, displayName, description, thermalConductivity, density, specificHeatCapacity, dynamicViscosity);
                        break;

                    case MaterialType.Opaque:
                        Material opaqueMaterial = (OpaqueMaterial)material;
                        result = new OpaqueMaterial(opaqueMaterial.Guid, name, displayName, description, thermalConductivity, density, specificHeatCapacity);
                        break;

                    case MaterialType.Transparent:
                        Material transparentMaterial = (TransparentMaterial)material;
                        result = new OpaqueMaterial(transparentMaterial.Guid, name, displayName, description, thermalConductivity, density, specificHeatCapacity);
                        break;

                    default:
                        return null;
                }

                if (result is SAMObject)
                {
                    ((SAMObject)result).SetValues(customParameters);
                }

                return result;
            }

            set
            {
                material = value;
                LoadMaterial();
            }
        }

        public List<Enum> Enums
        {
            get
            {
                return enums?.ToList();
            }
            set
            {
                enums = null;

                if(value != null)
                {
                    enums = new HashSet<Enum>();
                    foreach(Enum @enum in value)
                    {
                        enums.Add(@enum);
                    }
                }

                LoadParameters();
            }
        }

        public bool Enabled
        {
            set
            {
                TextBox_Name.Enabled = value;
                TextBox_DisplayName.Enabled = value;
                TextBox_Description.Enabled = value;
                TextBox_ThermalConductivity.Enabled = value;
                TextBox_SpecificHeatCapacity.Enabled = value;
                TextBox_Density.Enabled = value;
                PropertyGrid_Parameters.Enabled = value;
            }
        }
    }
}
