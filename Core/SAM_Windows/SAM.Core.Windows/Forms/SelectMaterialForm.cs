using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SAM.Core.Windows.Forms
{
    public partial class SelectMaterialForm : Form
    {
        private List<IMaterial> materials;
        
        public SelectMaterialForm()
        {
            InitializeComponent();
        }

        public SelectMaterialForm(IEnumerable<IMaterial> materials, IEnumerable<Enum> enums = null)
        {
            this.materials = materials?.ToList();

            InitializeComponent();

            MaterialControl_Main.Enums = enums?.ToList();
        }

        private void SelectMaterialForm_Load(object sender, EventArgs e)
        {
            MaterialControl_Main.Enabled = false;

            SearchControl_Main.SelectionMode = SelectionMode.One;
            SearchControl_Main.SearchObjectWrapper = Core.Create.SearchObjectWrapper(materials, (IMaterial x) => x.Name, false);
            SearchControl_Main.SelectedIndexChanged += new System.EventHandler(ListBox_Texts_SelectedIndexChanged);

            SearchControl_Main.SearchText = SearchControl_Main.SearchText;
        }

        public IMaterial Material
        {
            get
            {
                return MaterialControl_Main.Material;
            }
        }

        public string SearchText
        {
            get
            {
                return SearchControl_Main.SearchText;
            }

            set
            {
                SearchControl_Main.SearchText = value;
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

        private void ListBox_Texts_SelectedIndexChanged(object sender, EventArgs e)
        {
            IMaterial material = SearchControl_Main.GetSelectedItems<IMaterial>()?.FirstOrDefault();
            MaterialControl_Main.Material = material;
        }

        private void SelectMaterialForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
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
