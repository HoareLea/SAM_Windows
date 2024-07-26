using System;
using System.Windows.Forms;

namespace SAM.Analytical.Windows.Forms
{
    public partial class MechanicalSystemForm : Form
    {
        public MechanicalSystemForm()
        {
            InitializeComponent();
        }

        public MechanicalSystemForm(MechanicalSystem mechanicalSystem, AdjacencyCluster adjacencyCluster)
        {
            InitializeComponent();

            MechanicalSystemControl_Main.AdjacencyCluster = adjacencyCluster;
            MechanicalSystemControl_Main.MechanicalSystem = mechanicalSystem;
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

        private void MechanicalSystemForm_Load(object sender, EventArgs e)
        {

        }

        public MechanicalSystem MechanicalSystem
        {
            get
            {
                return MechanicalSystemControl_Main.MechanicalSystem;
            }

            set
            {
                MechanicalSystemControl_Main.MechanicalSystem = value;
            }
        }

        public AdjacencyCluster AdjacencyCluster
        {
            get
            {
                return MechanicalSystemControl_Main.AdjacencyCluster;
            }

            set
            {
                MechanicalSystemControl_Main.AdjacencyCluster = value;
            }
        }
    }
}
