using SAM.Analytical.Windows.Forms;
using SAM.Core.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace SAM.Analytical.Windows
{
    public partial class SpaceControl : UserControl
    {
        private AdjacencyCluster adjacencyCluster;
        private ProfileLibrary profileLibrary;
        private HashSet<Enum> enums;

        private Space space;

        public SpaceControl()
        {
            InitializeComponent();
        }

        public SpaceControl(Space space, ProfileLibrary profileLibrary = null)
        {
            InitializeComponent();

            if(space != null)
            {
                this.space = new Space(space);
            }

            if(profileLibrary != null)
            {
                this.profileLibrary = new ProfileLibrary(profileLibrary);
            }

        }

        private void SpaceControl_Load(object sender, EventArgs e)
        {
            PropertyGrid_Main.HidePropertyPages();
        }


        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Space Space
        {
            get
            {
                return GetSpace();
            }
            set
            {
                space = value;
                LoadSpace();
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProfileLibrary ProfileLibrary
        {
            get
            {
                return profileLibrary;
            }
            set
            {
                profileLibrary = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        public List<Enum> Enums
        {
            get
            {
                return enums?.ToList();
            }
            set
            {
                enums = null;

                if (value != null)
                {
                    enums = new HashSet<Enum>();
                    foreach (Enum @enum in value)
                    {
                        enums.Add(@enum);
                    }
                }

                LoadParameters();
            }
        }

        private void LoadParameters()
        {
            PropertyGrid_Main.SelectedObject = null;

            CustomParameters customParameters = Core.Windows.Create.CustomParameters(space, enums?.ToArray());

            PropertyGrid_Main.SelectedObject = customParameters;
        }

        private void LoadSpace()
        {
            TextBox_Name.Text = space?.Name;
            TextBox_Guid.Text = space?.Guid.ToString();
            TextBox_InternalCondition.Text = space?.InternalCondition?.Name;

            LoadParameters();
        }

        private Space GetSpace()
        {
            if(space == null)
            {
                return null;
            }

            Space result = new Space(space, TextBox_Name.Text, space.Location);

            CustomParameters customParameters = PropertyGrid_Main.SelectedObject as CustomParameters;

            result.SetValues(customParameters);

            return result;
        }

        private void Button_ModifyInternalCondition_Click(object sender, EventArgs e)
        {
            if(space == null)
            {
                return;
            }

            using (InternalConditionForm internalConditionForm = new InternalConditionForm(new Space(space), profileLibrary, adjacencyCluster))
            {
                internalConditionForm.UseColors = true;
                if (internalConditionForm.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                adjacencyCluster = internalConditionForm.AdjacencyCluster;
                profileLibrary = internalConditionForm.ProfileLibrary;

                space.InternalCondition = internalConditionForm.InternalCondition;
                Space = internalConditionForm.Space;
            }
        }

        private void Button_RemoveInternalCondition_Click(object sender, EventArgs e)
        {
            if (space == null)
            {
                return;
            }

            Space space_Temp = new Space(space);

            space_Temp.InternalCondition = null;
            Space = space_Temp;
        }

        private void Button_Occupancy_Click(object sender, EventArgs e)
        {
            Space space = GetSpace();
            if(space == null)
            {
                return;
            }

            using (OccupancyForm occupancyForm = new OccupancyForm())
            {
                occupancyForm.Space = space;
                if (occupancyForm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                Space = occupancyForm.Space;
            }
        }
    }
}
