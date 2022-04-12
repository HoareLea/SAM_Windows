using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAM.Analytical.Windows.Forms
{
    public partial class InternalConditionForm : Form
    {
        public InternalConditionForm()
        {
            InitializeComponent();
        }

        public InternalConditionForm(InternalCondition internalCondition, ProfileLibrary profileLibrary = null, AdjacencyCluster adjacencyCluster = null)
        {
            InitializeComponent();

            InternalConditionControl_Main.ProfileLibrary = profileLibrary;
            InternalConditionControl_Main.AdjacencyCluster = adjacencyCluster;
            InternalConditionControl_Main.InternalCondition = internalCondition;
        }

        public InternalConditionForm(Space space, ProfileLibrary profileLibrary = null, AdjacencyCluster adjacencyCluster = null)
        {
            InitializeComponent();

            InternalConditionControl_Main.ProfileLibrary = profileLibrary;
            InternalConditionControl_Main.AdjacencyCluster = adjacencyCluster;
            InternalConditionControl_Main.Space = space;
        }

        private void InternalConditionForm_Load(object sender, EventArgs e)
        {

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

        public InternalCondition InternalCondition
        {
            get
            {
                return InternalConditionControl_Main.InternalCondition;
            }
        }
    }
}
