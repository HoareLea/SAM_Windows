using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SAM.Analytical.Windows.Forms
{
    public partial class RiserForm : Form
    {
        public RiserForm()
        {
            InitializeComponent();
        }

        public RiserForm(string riserName, IEnumerable<Space> spaces, MechanicalSystemCategory mechanicalSystemCategory = MechanicalSystemCategory.Undefined)
        {
            InitializeComponent();

            TextBoxControl_Name.SetValue(riserName);

            Func<Space, string> func = null;

            SpaceParameter? spaceParameter = Analytical.Query.RiserNameSpaceParameter(mechanicalSystemCategory);

            if(spaceParameter != null && spaceParameter.HasValue)
            {
                func = new Func<Space, string>((Space x) =>
                {
                    if (x == null)
                    {
                        return null;
                    }

                    if (!x.TryGetValue(spaceParameter.Value, out string result))
                    {
                        result = null;
                    }

                    if(string.IsNullOrWhiteSpace(result))
                    {
                        result = "???";
                    }

                    return result;
                });
            }

            TreeViewControl_Spaces.AddRange(spaces, (Space x) => string.IsNullOrWhiteSpace(x.Name) ? "???" : x.Name, func);
        }

        public string RiserName
        {
            get
            {
                return TextBoxControl_Name.GetValue<string>();
            }
        }

        public List<Space> Spaces
        {
            get
            {
                return TreeViewControl_Spaces.GetSelectedItems<Space>();
            }
        }
    }
}
