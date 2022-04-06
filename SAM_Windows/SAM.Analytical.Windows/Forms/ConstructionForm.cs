using SAM.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SAM.Analytical.Windows.Forms
{
    public partial class ConstructionForm : Form
    {
        private ConstructionLibrary constructionLibrary;
        private MaterialLibrary materialLibrary;
        private Construction construction;

        public ConstructionForm()
        {
            InitializeComponent();
        }

        public ConstructionForm(MaterialLibrary materialLibrary, ConstructionLibrary constructionLibrary = null, Construction construction = null)
        {
            InitializeComponent();

            this.materialLibrary = materialLibrary;
            this.construction = construction;
            this.constructionLibrary = constructionLibrary;

            MaterialLayersControl_Main.Enabled = materialLibrary != null;
        }

        private void ConstructionForm_Load(object sender, EventArgs e)
        {
            if(construction != null)
            {
                TextBox_Name.Text = construction.Name;

                MaterialLayersControl_Main.MaterialLayers = construction.ConstructionLayers?.ConvertAll(x => x as Architectural.MaterialLayer);
            }
        }

        public List<ConstructionLayer> ConstructionLayers
        {
            get
            {
                return MaterialLayersControl_Main.ConstructionLayers();
            }
        }

        public Construction Construction
        {
            get
            {
                Construction result = null;
                if (construction != null)
                {
                    result =  new Construction(construction, ConstructionLayers);
                    result = new Construction(result.Guid, result, TextBox_Name.Text);
                }

                if(result == null)
                {
                    result = new Construction(TextBox_Name.Text, ConstructionLayers);
                }

                return result;
            }
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(TextBox_Name.Text))
            {
                MessageBox.Show("Provide valid name");
                return;
            }

            if(constructionLibrary?.GetConstructions()?.Find(x => x.Name == TextBox_Name.Text) != null)
            {
                MessageBox.Show("Construction with the same name already exists. Provide different name");
                return;
            }

            List<ConstructionLayer> constructionLayers = ConstructionLayers;
            if(constructionLayers == null || constructionLayers.Count == 0)
            {
                MessageBox.Show("Provide valid construction layers");
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

        private void DataGridView_Layers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button_Modify_Click(object sender, EventArgs e)
        {
            if(materialLibrary == null)
            {
                return;
            }
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
