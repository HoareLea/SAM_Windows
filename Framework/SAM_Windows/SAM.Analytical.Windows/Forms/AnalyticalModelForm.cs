using SAM.Core.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SAM.Analytical.Windows.Forms
{
    public partial class AnalyticalModelForm : Form
    {
        private AnalyticalModel analyticalModel;
        private HashSet<Enum> enums;

        public AnalyticalModelForm()
        {
            InitializeComponent();
        }

        public AnalyticalModelForm(AnalyticalModel analyticalModel, IEnumerable<Enum> enums = null)
        {
            this.analyticalModel = analyticalModel;

            if (enums != null)
            {
                this.enums = new HashSet<Enum>();
                foreach (Enum @enum in enums)
                {
                    this.enums.Add(@enum);
                }
            }

            InitializeComponent();
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

        public AnalyticalModel AnalyticalModel
        {
            get
            {
                if(analyticalModel == null)
                {
                    return null;
                }

                AnalyticalModel result = new AnalyticalModel(TextBox_Name.Text, TextBox_Description.Text, analyticalModel.Location, analyticalModel.Address, analyticalModel.AdjacencyCluster, analyticalModel.MaterialLibrary, analyticalModel.ProfileLibrary);

                CustomParameters customParameters = PropertyGrid_Parameters.SelectedObject as CustomParameters;

                result.SetValues(customParameters);

                return result;
            }
        }

        private void AnalyticalModelForm_Load(object sender, EventArgs e)
        {
            TextBox_Name.Text = analyticalModel?.Name;
            TextBox_Description.Text = analyticalModel?.Description;
            TextBox_Guid.Text = analyticalModel?.Guid.ToString();
            
            PropertyGrid_Parameters.HidePropertyPages();

            CustomParameters customParameters = Core.Windows.Create.CustomParameters(analyticalModel, enums?.ToArray());
            PropertyGrid_Parameters.SelectedObject = customParameters;
        }
    }
}
