using SAM.Core;
using SAM.Core.Windows.Forms;
using System;
using System.Collections.Generic;
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
            this.materialLibrary = materialLibrary;
            this.construction = construction;
            this.constructionLibrary = constructionLibrary;

            InitializeComponent();

            MaterialLayersControl_Main.MaterialLibrary = materialLibrary;
        }

        private void ConstructionForm_Load(object sender, EventArgs e)
        {
            if(construction != null)
            {
                TextBox_Name.Text = construction.Name;

                MaterialLayersControl_Main.MaterialLayers = construction.ConstructionLayers?.ConvertAll(x => x as Architectural.MaterialLayer);
            }

            if(constructionLibrary == null)
            {
                Button_CopyFromConstruction.Visible = false;
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

            if(construction == null && constructionLibrary?.GetConstructions()?.Find(x => x.Name == TextBox_Name.Text) != null)
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

        private void ConstructionForm_KeyDown(object sender, KeyEventArgs e)
        {
            Query.JsonForm(Construction, this, e);
        }

        private void MaterialLayersControl_Main_Load(object sender, EventArgs e)
        {

        }

        private void Button_CopyFromConstruction_Click(object sender, EventArgs e)
        {
            List<Construction> constructions = constructionLibrary?.GetConstructions();
            if(constructions == null || constructions.Count == 0)
            {
                return;
            }

            using (ComboBoxForm<Construction> comboBoxForm = new ComboBoxForm<Construction>("Select Construction", constructions, (Construction x) => x?.Name))
            {
                if(comboBoxForm.ShowDialog(this) == DialogResult.OK)
                {
                    Construction construction = comboBoxForm.SelectedItem;
                    if(construction != null)
                    {
                        MaterialLayersControl_Main.MaterialLayers = construction.ConstructionLayers?.ConvertAll(x => x as Architectural.MaterialLayer);
                    }
                }
            }
        }
    }
}
