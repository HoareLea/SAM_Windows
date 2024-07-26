using SAM.Core;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SAM.Analytical.Windows.Forms
{
    public partial class ApertureConstructionForm : Form
    {
        private MaterialLibrary materialLibrary;

        private ApertureConstructionLibrary apertureConstructionLibrary;
        private ApertureConstruction apertureConstruction;

        public ApertureConstructionForm()
        {
            InitializeComponent();
        }

        public ApertureConstructionForm(MaterialLibrary materialLibrary, ApertureConstructionLibrary apertureConstructionLibrary = null, ApertureConstruction apertureConstruction = null)
        {
            this.materialLibrary = materialLibrary;
            this.apertureConstruction = apertureConstruction;
            this.apertureConstructionLibrary = apertureConstructionLibrary;

            InitializeComponent();

            MaterialLayersControl_Pane.MaterialLibrary = materialLibrary;
            MaterialLayersControl_Frame.MaterialLibrary = materialLibrary;
        }

        private void ApertureConstructionForm_Load(object sender, EventArgs e)
        {
            foreach(ApertureType apertureType in Enum.GetValues(typeof(ApertureType)))
            {
                if(apertureType == ApertureType.Undefined)
                {
                    continue;
                }

                ComboBox_ApertureType.Items.Add(Core.Query.Description(apertureType));
            }

            ComboBox_ApertureType.SelectedIndex = 0;
            
            
            if(apertureConstruction != null)
            {
                TextBox_Name.Text = apertureConstruction.Name;

                MaterialLayersControl_Pane.MaterialLayers = apertureConstruction.PaneConstructionLayers?.ConvertAll(x => (Architectural.MaterialLayer)x);
                MaterialLayersControl_Frame.MaterialLayers = apertureConstruction.FrameConstructionLayers?.ConvertAll(x => (Architectural.MaterialLayer)x);

                ComboBox_ApertureType.Text = Core.Query.Description(apertureConstruction.ApertureType);

                if(apertureConstruction.TryGetValue(ApertureConstructionParameter.Description, out string description))
                {
                    TextBox_Description.Text = description;
                }
            }
        }


        public List<ConstructionLayer> PaneConstructionLayers
        {
            get
            {

                return MaterialLayersControl_Pane?.ConstructionLayers();
            }
        }

        public List<ConstructionLayer> FrameConstructionLayers
        {
            get
            {

                return MaterialLayersControl_Frame?.ConstructionLayers();
            }
        }

        public ApertureConstruction ApertureConstruction
        {
            get
            {
                ApertureConstruction result = null;
                if (apertureConstruction != null)
                {
                    result =  new ApertureConstruction(apertureConstruction, PaneConstructionLayers, FrameConstructionLayers);
                    result = new ApertureConstruction(result.Guid, result, TextBox_Name.Text);
                }

                if(result == null)
                {
                    result = new ApertureConstruction(Guid.NewGuid(), TextBox_Name.Text, Core.Query.Enum<ApertureType>(ComboBox_ApertureType.Text), PaneConstructionLayers, FrameConstructionLayers);
                }

                string description = TextBox_Description.Text;
                if(string.IsNullOrEmpty(description))
                {
                    result.RemoveValue(ApertureConstructionParameter.Description);
                }
                else
                {
                    result.SetValue(ApertureConstructionParameter.Description, description);
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

            //if(apertureConstructionLibrary?.GetApertureConstructions()?.Find(x => x.Name == TextBox_Name.Text) != null)
            //{
            //    MessageBox.Show("Construction with the same name already exists. Provide different name");
            //    return;
            //}

            List<ConstructionLayer> constructionLayers = PaneConstructionLayers;
            if(constructionLayers == null || constructionLayers.Count == 0)
            {
                MessageBox.Show("Provide valid pane construction layers");
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
                if(materialLibrary != null)
                {
                    MaterialLayersControl_Pane.Enabled = value;
                    MaterialLayersControl_Frame.Enabled = value;
                }

                ComboBox_ApertureType.Enabled = value;
                TextBox_Name.Enabled = value;
                TextBox_Description.Enabled = value;
            }
        }

        private void ApertureConstructionForm_KeyDown(object sender, KeyEventArgs e)
        {
            Query.JsonForm(ApertureConstruction, this, e);
        }
    }
}
