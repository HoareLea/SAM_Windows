using System;
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

        public List<MechanicalSystemType> MechanicalSystemTypes
        {
            get
            {
                MechanicalSystemType mechanicalSystemType = mechanicalSystem?.Type;

                List<MechanicalSystemType> result = adjacencyCluster?.GetMechanicalSystemTypes<MechanicalSystemType>();
                if (result == null)
                {
                    result = new List<MechanicalSystemType>();
                }

                if (mechanicalSystemType != null && result.Find(x => x.Name == mechanicalSystemType.Name) == null)
                {
                    result.Add(mechanicalSystemType);
                }

                return result;
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
            TreeView_Main.Nodes.Clear();

            TreeNode treeNode = TreeView_Main.Nodes.Add(string.IsNullOrWhiteSpace(mechanicalSystem?.FullName) ? "???" : mechanicalSystem.FullName);
            treeNode.Tag = typeof(MechanicalSystem);

            ContextMenuStrip contextMenuStrip_MechanicalSystem = new ContextMenuStrip();
            treeNode.ContextMenuStrip = contextMenuStrip_MechanicalSystem;
            contextMenuStrip_MechanicalSystem.Tag = typeof(MechanicalSystem);

            ToolStripMenuItem toolStripMenuItem_AddRiser = new ToolStripMenuItem() { Text = "Add Riser" };
            toolStripMenuItem_AddRiser.Click += ToolStripMenuItem_Material_AddRiser_Click;
            contextMenuStrip_MechanicalSystem.Items.Add(toolStripMenuItem_AddRiser);

            SpaceParameter? spaceParameter = Analytical.Query.RiserNameSpaceParameter(mechanicalSystem);

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

                ContextMenuStrip contextMenuStrip_Riser = new ContextMenuStrip();
                treeNode_Riser.ContextMenuStrip = contextMenuStrip_Riser;
                contextMenuStrip_Riser.Tag = keyValuePair.Key;

                ToolStripMenuItem toolStripMenuItem_RemoveRiser = new ToolStripMenuItem() { Text = "Remove" };
                toolStripMenuItem_RemoveRiser.Click += ToolStripMenuItem_Material_RemoveRiser_Click;
                contextMenuStrip_Riser.Items.Add(toolStripMenuItem_RemoveRiser);

                ToolStripMenuItem toolStripMenuItem_AddSpace = new ToolStripMenuItem() { Text = "Add Space" };
                toolStripMenuItem_AddSpace.Click += ToolStripMenuItem_Material_AddSpace_Click;
                contextMenuStrip_Riser.Items.Add(toolStripMenuItem_AddSpace);

                foreach (Space space in keyValuePair.Value)
                {
                    string name = string.IsNullOrWhiteSpace(space.Name) ? "???" : space.Name;

                    TreeNode treeNode_Space = treeNode_Riser.Nodes.Add(space.Name);
                    treeNode_Space.Tag = space;

                    ContextMenuStrip contextMenuStrip_Space = new ContextMenuStrip();
                    treeNode_Space.ContextMenuStrip = contextMenuStrip_Space;
                    contextMenuStrip_Space.Tag = space;

                    ToolStripMenuItem toolStripMenuItem_RemoveSpace = new ToolStripMenuItem() { Text = "Remove" };
                    toolStripMenuItem_RemoveSpace.Click += ToolStripMenuItem_Material_RemoveSpace_Click;
                    contextMenuStrip_Space.Items.Add(toolStripMenuItem_RemoveSpace);
                }
            }

            List<MechanicalSystemType> mechanicalSystemTypes = MechanicalSystemTypes;
            mechanicalSystemTypes?.Sort((x, y) => x.Name.CompareTo(y.Name));

            string selectedName = ComboBox_MechanicalSystemType.Text;

            ComboBox_MechanicalSystemType.Items.Clear();
            mechanicalSystemTypes.ForEach(x => ComboBox_MechanicalSystemType.Items.Add(x.Name));

            if(string.IsNullOrWhiteSpace(selectedName))
            {
                selectedName = mechanicalSystem?.Type?.Name;
            }

            ComboBox_MechanicalSystemType.Text = selectedName;

            TextBox_FullName.Text = mechanicalSystem?.FullName;
            TextBox_Id.Text = mechanicalSystem?.Id;

        }

        private void ToolStripMenuItem_Material_RemoveSpace_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ToolStripMenuItem_Material_AddSpace_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ToolStripMenuItem_Material_RemoveRiser_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ToolStripMenuItem_Material_AddRiser_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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
