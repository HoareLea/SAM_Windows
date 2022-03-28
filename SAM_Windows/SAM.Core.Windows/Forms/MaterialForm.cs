using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SAM.Core.Windows.Forms
{
    public partial class MaterialForm : Form
    {
        private IMaterial material;
        private HashSet<Enum> enums;

        public MaterialForm()
        {
            InitializeComponent();
        }

        public MaterialForm(IMaterial material, IEnumerable<Enum> enums = null)
        {
            InitializeComponent();

            this.material = material;
            if(this.material == null)
            {
                using (ComboBoxForm<MaterialType> comboBoxForm = new ComboBoxForm<MaterialType>("Select Material Type", Enum.GetValues(typeof(MaterialType)).Cast<MaterialType>().ToList().FindAll(x => x != MaterialType.Undefined)))
                {
                    DialogResult dialogResult = comboBoxForm.ShowDialog(this);
                    if (dialogResult != DialogResult.OK)
                    {
                        DialogResult = dialogResult;
                        Close();
                    }

                    switch(comboBoxForm.SelectedItem)
                    {
                        case MaterialType.Gas:
                            this.material = new GasMaterial(Guid.NewGuid(), "Gas Material", "Gas Material", null, 0, 0, 0, 0);
                            break;

                        case MaterialType.Opaque:
                            this.material = new OpaqueMaterial("Opaque Material", null, "Opaque Material", null, 0, 0, 0);
                            break;

                        case MaterialType.Transparent:
                            this.material = new TransparentMaterial("Opaque Material", null, "Opaque Material", null, 0, 0, 0);
                            break;
                    }
                }
            }

            if(enums != null)
            {
                this.enums = new HashSet<Enum>();
                foreach(Enum @enum in enums)
                {
                    this.enums.Add(@enum);
                }
            }
        }

        private void MaterialForm_Load(object sender, EventArgs e)
        {
            PropertyGrid_Parameters.HidePropertyPages();

            if (material != null)
            {
                TextBox_Name.Text = material?.Name;
                Material material_Temp = material as Material;
                if(material_Temp != null)
                {
                    CustomParameters customParameters = Create.CustomParameters(material_Temp, enums?.ToArray());

                    TextBox_DisplayName.Text = material_Temp.DisplayName;
                    TextBox_Description.Text = material_Temp.Description;

                    string value;

                    value = double.IsNaN(material_Temp.ThermalConductivity) ? null : material_Temp.ThermalConductivity.ToString();
                    TextBox_ThermalConductivity.Text = value;

                    value = double.IsNaN(material_Temp.SpecificHeatCapacity) ? null : material_Temp.SpecificHeatCapacity.ToString();
                    TextBox_SpecificHeatCapacity.Text = value;

                    value = double.IsNaN(material_Temp.Density) ? null : material_Temp.Density.ToString();
                    TextBox_Density.Text = value;

                    CustomParameter customParameter = null;
                    if (material_Temp is FluidMaterial)
                    {
                        FluidMaterial fluidMaterial = (FluidMaterial)material_Temp;
                        customParameter = new CustomParameter("Dynamic Viscosity", "Dynamic Viscosity of Fluid [kg/(m*s)]", AccessType.ReadWrite, new Attributes.DoubleParameterValue(0), typeof(FluidMaterial).Assembly.Name(), fluidMaterial.DynamicViscosity);

                        customParameters?.Add(customParameter);
                    }

                    PropertyGrid_Parameters.SelectedObject = customParameters;
                }
            }

            TextBox_ThermalConductivity.KeyPress += new KeyPressEventHandler(EventHandler.ControlText_NumberOnly);
            TextBox_SpecificHeatCapacity.KeyPress += new KeyPressEventHandler(EventHandler.ControlText_NumberOnly);
            TextBox_Density.KeyPress += new KeyPressEventHandler(EventHandler.ControlText_NumberOnly);
        }

        public IMaterial Material
        {
            get
            {
                if(material == null)
                {
                    return null;
                }

                string name = TextBox_Name.Text;
                string displayName = TextBox_DisplayName.Text;
                string description = TextBox_Description.Text;
                if(!Core.Query.TryConvert(TextBox_ThermalConductivity.Text, out double thermalConductivity))
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
                switch(material.MaterialType())
                {
                    case MaterialType.Gas:
                        
                        CustomParameter customParameter = customParameters.Cast<CustomParameter>().ToList().Find(x => x?.Name == "Dynamic Viscosity");
                        if (!Core.Query.TryConvert(customParameter.Value, out double dynamicViscosity))
                        {
                            dynamicViscosity = double.NaN;
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

                if(result is SAMObject)
                {
                    ((SAMObject)result).SetValues(customParameters);
                }

                return result;
            }
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            Close();
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }
    }
}
