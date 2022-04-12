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

        private void Space_Load(object sender, EventArgs e)
        {

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
    }
}
