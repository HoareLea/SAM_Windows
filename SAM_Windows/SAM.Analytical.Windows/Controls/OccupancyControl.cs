using System.Windows.Forms;

namespace SAM.Analytical.Windows.Controls
{
    public partial class OccupancyControl : UserControl
    {
        private Space space;

        public OccupancyControl()
        {
            InitializeComponent();

            TextBox_AreaPerPerson.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_NumberOnly);

            TextBox_Occupancy.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_NumberOnly);
        }

        public Space Space
        {
            get
            {
                return GetSpace();
            }

            set
            {
                SetSpace(value);
            }
        }

        private Space GetSpace()
        {
            if(space == null)
            {
                return null;
            }

            Space result = new Space(space);

            double occupancy = double.NaN;
            if(!Core.Query.TryConvert(TextBox_CalculatedOccupancy.Text, out occupancy) || double.IsNaN(occupancy))
            {
                occupancy = double.NaN;
            }

            result.UpdateOccupancy(occupancy);
            return result;
        }

        private void SetSpace(Space space)
        {
            this.space = space;

            CheckBox_InternalCondition.Enabled = false;
            CheckBox_InternalCondition.Checked = false;

            TextBox_AreaPerPerson.Enabled = false;
            Label_AreaPerPerson.Enabled = false;
            Label_AreaPerPerson_Unit.Enabled = false;

            TextBox_Occupancy.Enabled = false;
            Label_Occupancy.Enabled = false;
            Label_Occupancy_Unit.Enabled = false;

            TextBox_AreaPerPerson.Text = string.Empty;
            TextBox_Occupancy.Text = string.Empty;

            if (space == null)
            {
                return;
            }

            InternalCondition internalCondition = space.InternalCondition;
            if(internalCondition != null)
            {
                CheckBox_InternalCondition.Enabled = true;
            }

            TextBox_Occupancy.Enabled = true;
            Label_Occupancy.Enabled = true;
            Label_Occupancy_Unit.Enabled = true;

            if (space.TryGetValue(SpaceParameter.Area, out double area) && !double.IsNaN(area) && area > 0)
            {
                TextBox_AreaPerPerson.Enabled = true;
                Label_AreaPerPerson.Enabled = true;
                Label_AreaPerPerson_Unit.Enabled = true;
            }

            if (!space.TryGetValue(SpaceParameter.Occupancy, out double occupancy) || double.IsNaN(occupancy))
            {
                return;
            }

            TextBox_Occupancy.Text = occupancy.ToString();
        }

        private void UpdateCalculatedOccupancy()
        {
            TextBox_CalculatedOccupancy.Text = null;

            if(string.IsNullOrWhiteSpace(TextBox_AreaPerPerson.Text) && string.IsNullOrWhiteSpace(TextBox_Occupancy.Text))
            {
                return;
            }

            double calculatedOccupancy = double.NaN;
            if(Core.Query.TryConvert(TextBox_AreaPerPerson.Text, out double areaPerPerson) && !double.IsNaN(areaPerPerson))
            {
                if (space.TryGetValue(SpaceParameter.Area, out double area) && !double.IsNaN(area) && area > 0)
                {
                    calculatedOccupancy = area / areaPerPerson;
                }
            }

            if (Core.Query.TryConvert(TextBox_Occupancy.Text, out double occupancy) && !double.IsNaN(occupancy))
            {
                if(double.IsNaN(calculatedOccupancy))
                {
                    calculatedOccupancy = 0;
                }

                calculatedOccupancy += occupancy;
            }

            if(double.IsNaN(calculatedOccupancy))
            {
                return;
            }

            TextBox_CalculatedOccupancy.Text = Core.Query.Round(calculatedOccupancy, Core.Tolerance.MacroDistance).ToString();
        }

        private void TextBox_Occupancy_TextChanged(object sender, System.EventArgs e)
        {
            UpdateCalculatedOccupancy();
        }

        private void TextBox_AreaPerPerson_TextChanged(object sender, System.EventArgs e)
        {
            UpdateCalculatedOccupancy();
        }

        private void CheckBox_InternalCondition_CheckedChanged(object sender, System.EventArgs e)
        {
            if(CheckBox_InternalCondition.Checked)
            {
                TextBox_AreaPerPerson.Enabled = false;
                Label_AreaPerPerson.Enabled = false;
                Label_AreaPerPerson_Unit.Enabled = false;

                InternalCondition internalCondition = space?.InternalCondition;
                if(internalCondition != null)
                {
                    if(internalCondition.TryGetValue(InternalConditionParameter.AreaPerPerson, out double areaPerPerson) && !double.IsNaN(areaPerPerson))
                    {
                        TextBox_AreaPerPerson.Text = Core.Query.Round(areaPerPerson, Core.Tolerance.MacroDistance).ToString();
                    }
                }
            }
            else
            {
                TextBox_AreaPerPerson.Enabled = true;
                Label_AreaPerPerson.Enabled = true;
                Label_AreaPerPerson_Unit.Enabled = true;
            }
        }
    }
}
