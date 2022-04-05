using SAM.Core;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SAM.Architectural.Windows.Forms
{
    public partial class MaterialLayersForm : Form
    {
        private MaterialLibrary materialLibrary;

        public MaterialLayersForm()
        {
            InitializeComponent();
        }

        public MaterialLayersForm(MaterialLibrary materialLibrary, IEnumerable<MaterialLayer> materialLayers = null)
        {
            InitializeComponent();

            this.materialLibrary = materialLibrary;

            if (materialLayers != null)
            {
                MaterialLayersControl_Main.MaterialLayers = new List<MaterialLayer>(materialLayers);
            }
        }

        public List<MaterialLayer> MaterialLayers
        {
            get
            {
                return MaterialLayersControl_Main.MaterialLayers;
            }
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            List<MaterialLayer> materialLayers = MaterialLayers;
            if(materialLayers == null || materialLayers.Count == 0)
            {
                MessageBox.Show("Provide valid layers");
                return;
            }
            
            DialogResult = DialogResult.OK;

            Close();
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

        public bool Enabled
        {
            set
            {
                MaterialLayersControl_Main.Enabled = value;
            }
        }
    }
}
