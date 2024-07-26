using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SAM.Core.Windows.Forms
{
    public partial class MaterialForm : Form
    {
        public MaterialForm()
        {
            InitializeComponent();
        }

        public MaterialForm(IMaterial material, IEnumerable<Enum> enums = null)
        {
            InitializeComponent();

            IMaterial material_Temp = material;
            if (material == null)
            {
                material_Temp = Create.Material(this);
            }

            MaterialControl_Main.Material = material_Temp;
            MaterialControl_Main.Enums = enums?.ToList();
        }

        private void MaterialForm_Load(object sender, EventArgs e)
        {

        }

        public IMaterial Material
        {
            get
            {
                return MaterialControl_Main.Material;
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

        private void MaterialForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string link = "https://github.com/HoareLea/SAM/wiki/Construction#materials";

            IMaterial material = Material;
            if (material != null)
            {
                if(material is GasMaterial)
                {
                    link = "https://github.com/HoareLea/SAM/wiki/Construction#gas-material";
                }
                else if (material is TransparentMaterial)
                {
                    link = "https://github.com/HoareLea/SAM/wiki/Construction#transparent-material";
                }
                else if (material is OpaqueMaterial)
                {
                    link = "https://github.com/HoareLea/SAM/wiki/Construction#opaque-material";
                }
            }

            System.Diagnostics.Process.Start(link);
        }
    }
}
