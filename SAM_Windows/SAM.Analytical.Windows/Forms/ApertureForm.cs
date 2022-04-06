using SAM.Core;
using SAM.Core.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SAM.Analytical.Windows.Forms
{
    public partial class ApertureForm : Form
    {
        private ApertureConstructionLibrary apertureConstructionLibrary;
        private MaterialLibrary materialLibrary;

        private Aperture aperture;
        private HashSet<Enum> enums;

        public ApertureForm()
        {
            InitializeComponent();
        }

        public ApertureForm(Aperture aperture, MaterialLibrary materialLibrary, ApertureConstructionLibrary apertureConstructionLibrary = null, IEnumerable<Enum> enums = null)
        {
            InitializeComponent();

            this.apertureConstructionLibrary = apertureConstructionLibrary == null ? null : new ApertureConstructionLibrary(apertureConstructionLibrary);
            this.materialLibrary = materialLibrary == null? null : new MaterialLibrary(materialLibrary);

            this.aperture = aperture;
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
                ComboBox_ApertureType.Items.Add(Core.Query.Description(panelType));
            }

            if (aperture != null)
            {
                TextBox_Name.Text = aperture?.Name;
                CustomParameters customParameters = Core.Windows.Create.CustomParameters(aperture, enums?.ToArray());

                TextBox_Guid.Text = aperture.Guid.ToString();
                TextBox_Construction.Text = aperture.ApertureConstruction?.Name;

                ComboBox_ApertureType.Text = Core.Query.Description(aperture.ApertureType());

                PropertyGrid_Parameters.SelectedObject = customParameters;

                TextBox_Area.Text = Math.Round(aperture.GetArea(), 1).ToString();
            }

            if(apertureConstructionLibrary == null)
            {
                Button_SelectConstruction.Visible = false;
            }


        }

        public Aperture Aperture
        {
            get
            {
                if(aperture == null)
                {
                    return null;
                }

                Aperture result = new Aperture(aperture);

                CustomParameters customParameters = PropertyGrid_Parameters.SelectedObject as CustomParameters;

                result.SetValues(customParameters);
                return result;
            }
        }

        public ApertureConstructionLibrary ApertureConstructionLibrary
        {
            get
            {
                return apertureConstructionLibrary;
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
            ApertureConstruction apertureConstruction = null;
            using (ApertureConstructionLibraryForm apertureConstructionLibraryForm = new ApertureConstructionLibraryForm(materialLibrary, apertureConstructionLibrary))
            {
                if(apertureConstructionLibraryForm.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                apertureConstruction = apertureConstructionLibraryForm.GetApertureConstructions(true)?.FirstOrDefault();
                apertureConstructionLibrary = apertureConstructionLibraryForm.ApertureConstructionLibrary;

            }

            if(apertureConstruction == null)
            {
                return;
            }

            aperture = new Aperture(aperture, apertureConstruction);

            TextBox_Name.Text = aperture.Name;
            TextBox_Construction.Text = apertureConstruction.Name;
        }
    }
}
