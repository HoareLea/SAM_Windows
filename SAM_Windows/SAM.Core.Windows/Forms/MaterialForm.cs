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
                    TextBox_ThermalConductivity.Text = material_Temp.ThermalConductivity.ToString();
                    TextBox_SpecificHeatCapacity.Text = material_Temp.SpecificHeatCapacity.ToString();
                    TextBox_Density.Text = material_Temp.Density.ToString();

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
                return null;
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
