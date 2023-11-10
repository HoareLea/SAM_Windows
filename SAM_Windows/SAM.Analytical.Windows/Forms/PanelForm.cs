using SAM.Core;
using SAM.Core.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SAM.Analytical.Windows.Forms
{
    public partial class PanelForm : Form
    {
        private ConstructionLibrary constructionLibrary;
        private MaterialLibrary materialLibrary;

        private Panel panel;
        private HashSet<Enum> enums;

        public PanelForm()
        {
            InitializeComponent();
        }

        public PanelForm(Panel panel, MaterialLibrary materialLibrary, ConstructionLibrary constructionLibrary = null, IEnumerable<Enum> enums = null)
        {
            InitializeComponent();

            this.constructionLibrary = constructionLibrary == null ? null : new ConstructionLibrary(constructionLibrary);
            this.materialLibrary = materialLibrary == null? null : new MaterialLibrary(materialLibrary);

            this.panel = panel;
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

            foreach (PanelType panelType in Enum.GetValues(typeof(PanelType)))
            {
                ComboBox_PanelType.Items.Add(Core.Query.Description(panelType));
            }

            if (panel != null)
            {
                TextBox_Name.Text = panel?.Name;
                CustomParameters customParameters = Core.Windows.Create.CustomParameters(panel, enums?.ToArray());

                TextBox_Guid.Text = panel.Guid.ToString();
                TextBox_Construction.Text = panel.Construction?.Name;

                ComboBox_PanelType.Text = Core.Query.Description(panel.PanelType);

                PropertyGrid_Parameters.SelectedObject = customParameters;

                TextBox_Area.Text = Math.Round(panel.GetArea(), 1).ToString();
                TextBox_NetArea.Text = Math.Round(panel.GetAreaNet(), 1).ToString();

                Range<double> elevationRange = panel.GetElevationRange();
                if(elevationRange != null)
                {
                    TextBox_MinElevation.Text = Math.Round(elevationRange.Min, 2).ToString();
                    TextBox_MaxElevation.Text = Math.Round(elevationRange.Max, 2).ToString();
                }

            }

            if(constructionLibrary == null)
            {
                Button_SelectConstruction.Visible = false;
            }


        }

        public Panel Panel
        {
            get
            {
                if(panel == null)
                {
                    return null;
                }

                PanelType panelType = Core.Query.Enum<PanelType>(ComboBox_PanelType.Text);

                Panel result = Create.Panel(panel, panelType);

                CustomParameters customParameters = PropertyGrid_Parameters.SelectedObject as CustomParameters;

                result.SetValues(customParameters);
                return result;
            }
        }

        public ConstructionLibrary ConstructionLibrary
        {
            get
            {
                return constructionLibrary;
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

        private void Button_SelectConstruction_Click(object sender, EventArgs e)
        {
            Construction construction = null;
            using (ConstructionLibraryForm constructionLibraryForm = new ConstructionLibraryForm(materialLibrary, constructionLibrary))
            {
                constructionLibraryForm.Text = "Constructions";
                if(constructionLibraryForm.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                construction = constructionLibraryForm.GetConstructions(true)?.FirstOrDefault();
                constructionLibrary = constructionLibraryForm.ConstructionLibrary;

            }

            if(construction == null)
            {
                return;
            }

            panel = Create.Panel(panel, construction);

            TextBox_Name.Text = panel.Name;
            TextBox_Construction.Text = construction.Name;
            ComboBox_PanelType.Text = construction.PanelType().Description();
        }

        private void PanelForm_KeyDown(object sender, KeyEventArgs e)
        {
            Query.JsonForm(Panel, this, e);
        }
    }
}
