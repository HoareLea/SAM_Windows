using System;
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

        public Space Space
        {
            get
            {
                return InternalConditionControl_Main.Space;
            }
        }

        public AdjacencyCluster AdjacencyCluster
        {
            get
            {
                return InternalConditionControl_Main.AdjacencyCluster;
            }
        }

        public ProfileLibrary ProfileLibrary
        {
            get
            {
                return InternalConditionControl_Main.ProfileLibrary;
            }
        }

        public bool UseColors
        {
            get
            {
                return InternalConditionControl_Main.UseColors;
            }

            set
            {
                InternalConditionControl_Main.UseColors = value;
            }
        }

    }
}
