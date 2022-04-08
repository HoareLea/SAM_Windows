using SAM.Core.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace SAM.Analytical.Windows
{
    public partial class InternalConditionControl : UserControl
    {
        private ProfileLibrary profileLibrary;

        private InternalCondition internalCondition;
        private HashSet<Enum> enums;

        public InternalConditionControl()
        {
            InitializeComponent();
        }

        public InternalConditionControl(InternalCondition internalCondition, ProfileLibrary profileLibrary = null, IEnumerable<Enum> enums = null)
        {
            this.internalCondition = internalCondition;
            this.profileLibrary = profileLibrary;

            if(enums != null)
            {
                this.enums = new HashSet<Enum>();
                foreach(Enum @enum in enums)
                {
                    this.enums.Add(@enum);
                }
            }
        }

        private void InternalConditionControl_Load(object sender, EventArgs e)
        {
            LoadInternalCondition();
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public InternalCondition InternalCondition
        {
            get
            {
                return internalCondition;
            }
            set
            {
                internalCondition = value;
                LoadInternalCondition();
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

            CustomParameters customParameters = Core.Windows.Create.CustomParameters(internalCondition, enums?.ToArray());

            PropertyGrid_Main.SelectedObject = customParameters;
        }

        private void LoadInternalCondition()
        {
            TextBox_Name.Text = internalCondition?.Name;

            LoadParameters();
        }


    }
}
