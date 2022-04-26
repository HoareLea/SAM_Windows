using System.Collections.Generic;
using System.Windows.Forms;

namespace SAM.Analytical.Windows.Controls
{
    public partial class MechanicalSystemControl : UserControl
    {
        private AdjacencyCluster adjacencyCluster;

        private MechanicalSystem mechanicalSystem;

        public MechanicalSystemControl()
        {
            InitializeComponent();
        }

        public MechanicalSystem MechanicalSystem
        {
            get
            {
                return GetMechanicalSystem();
            }

            set
            {
                mechanicalSystem = value;
                LoadMechanicalSystem(mechanicalSystem);
            }
        }

        public AdjacencyCluster AdjacencyCluster
        {
            get
            {
                return adjacencyCluster;
            }

            set
            {
                adjacencyCluster = value;

            }
        }

        private void LoadMechanicalSystem(MechanicalSystem mechanicalSystem)
        {
            TreeNode treeNode = TreeView_Main.Nodes.Add(string.IsNullOrWhiteSpace(mechanicalSystem?.FullName) ? "???" : mechanicalSystem.FullName);
            treeNode.Tag = typeof(MechanicalSystem);

            SpaceParameter? spaceParameter = null;
            if(mechanicalSystem is VentilationSystem)
            {
                spaceParameter = SpaceParameter.VentilationRiserName;
            }
            else if (mechanicalSystem is CoolingSystem)
            {
                spaceParameter = SpaceParameter.CoolingRiserName;
            }
            else if (mechanicalSystem is HeatingSystem)
            {
                spaceParameter = SpaceParameter.HeatingRiserName;
            }

            SortedDictionary<string, List<Space>> dictionary = new SortedDictionary<string, List<Space>>();
            if(adjacencyCluster != null)
            {
                List<Space> spaces = adjacencyCluster.GetRelatedObjects<Space>(mechanicalSystem);
                if(spaces != null)
                {
                    string riserName = null;
                    foreach (Space space in spaces)
                    {
                        if (!space.TryGetValue(spaceParameter, out riserName))
                        {
                            riserName = null;
                        }

                        if (string.IsNullOrEmpty(riserName))
                        {
                            riserName = "???";
                        }
                    }

                    if(!dictionary.TryGetValue(riserName, out List<Space> spaces_Temp))
                    {
                        spaces_Temp = new List<Space>();
                        dictionary[riserName] = spaces_Temp;
                    }
                }
            }

            foreach(KeyValuePair<string, List<Space>> keyValuePair in dictionary)
            {
                TreeNode treeNode_Riser = treeNode.Nodes.Add(keyValuePair.Key);
                foreach(Space space in keyValuePair.Value)
                {
                    string name = string.IsNullOrWhiteSpace(space.Name) ? "???" : space.Name;

                    TreeNode treeNode_Space = treeNode_Riser.Nodes.Add(space.Name);
                    treeNode_Space.Tag = space;
                }
            }
        }

        private MechanicalSystem GetMechanicalSystem()
        {
            MechanicalSystem result = null;

            if(mechanicalSystem is VentilationSystem)
            {
                result = new VentilationSystem(mechanicalSystem.Guid,TextBox_Id.Text, (VentilationSystem)MechanicalSystem);
            }
            else if(mechanicalSystem is CoolingSystem)
            {
                result = new CoolingSystem(mechanicalSystem.Guid, TextBox_Id.Text, (CoolingSystem)MechanicalSystem);
            }
            else if (mechanicalSystem is HeatingSystem)
            {
                result = new HeatingSystem(mechanicalSystem.Guid, TextBox_Id.Text, (HeatingSystem)MechanicalSystem);
            }

            return result;
        }
    }
}
