using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace SAM.Analytical.Windows.Forms
{
    public partial class SpacesForm : Form
    {
        public SpacesForm()
        {
            InitializeComponent();
        }

        public SpacesForm(IEnumerable<Space> spaces, AdjacencyCluster adjacencyCluster, ProfileLibrary profileLibrary)
        {
            InitializeComponent();

            SpacesControl_Main.AdjacencyCluster = adjacencyCluster;
            SpacesControl_Main.ProfileLibrary = profileLibrary;
            SpacesControl_Main.Spaces = spaces;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IEnumerable<Space> Spaces
        {
            get
            {
                return SpacesControl_Main.Spaces;
            }

            set
            {
                SpacesControl_Main.Spaces = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AdjacencyCluster AdjacencyCluster
        {
            get
            {
                return SpacesControl_Main.AdjacencyCluster;
            }
            set
            {
                SpacesControl_Main.AdjacencyCluster = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProfileLibrary ProfileLibrary
        {
            get
            {
                return SpacesControl_Main.ProfileLibrary;
            }
            set
            {
                SpacesControl_Main.ProfileLibrary = value;
            }
        }

        private void Button_Cancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

        private void Button_OK_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;

            Close();
        }
    }
}
