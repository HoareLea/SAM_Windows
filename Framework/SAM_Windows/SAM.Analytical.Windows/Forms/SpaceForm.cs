using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SAM.Analytical.Windows.Forms
{
    public partial class SpaceForm : Form
    {
        public SpaceForm()
        {
            InitializeComponent();
        }

        public SpaceForm(Space space, IEnumerable<Enum> enums = null)
        {
            InitializeComponent();

            SpaceControl_Main.Space = space;
            SpaceControl_Main.Enums = enums?.ToList();
        }

        public SpaceForm(Space space, ProfileLibrary profileLibrary, AdjacencyCluster adjacencyCluster, IEnumerable<Enum> enums = null)
        {
            InitializeComponent();

            SpaceControl_Main.ProfileLibrary = profileLibrary;
            SpaceControl_Main.AdjacencyCluster = adjacencyCluster;

            SpaceControl_Main.Space = space;
            SpaceControl_Main.Enums = enums?.ToList();
        }

        public Space Space
        {
            get
            {
                return SpaceControl_Main.Space;
            }
            set
            {
                SpaceControl_Main.Space = value;
            }
        }

        public ProfileLibrary ProfileLibrary
        {
            get
            {
                return SpaceControl_Main.ProfileLibrary;
            }
            set
            {
                SpaceControl_Main.ProfileLibrary = value;
            }
        }

        public AdjacencyCluster AdjacencyCluster
        {
            get
            {
                return SpaceControl_Main.AdjacencyCluster;
            }
            set
            {
                SpaceControl_Main.AdjacencyCluster = value;
            }
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            Close();
        }

        private void SpaceForm_KeyDown(object sender, KeyEventArgs e)
        {
            Query.JsonForm(Space, this, e);
        }
    }
}
