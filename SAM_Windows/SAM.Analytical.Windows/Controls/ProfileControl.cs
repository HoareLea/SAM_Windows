using LiveCharts;
using LiveCharts.Wpf;
using SAM.Analytical.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SAM.Analytical.Windows.Controls
{
    public partial class ProfileControl : UserControl
    {
        private ProfileLibrary profileLibrary;
        private Profile profile;

        public ProfileControl()
        {
            InitializeComponent();
        }

        public ProfileControl(Profile profile)
        {
            this.profile = profile;
        }

        private void ProfileControl_Load(object sender, EventArgs e)
        {
            CartesianChart_Yearly.Hoverable = false;
            CartesianChart_Yearly.DisableAnimations = true;
            CartesianChart_Yearly.DataTooltip = null;
        }

        private void UpdateProfileValues(Profile profile)
        {
            profile.C

            foreach(DataGridViewRow dataGridViewRow in DataGridView_Values.Rows)
            {
                profile.
            }

        }

        private void LoadProfile()
        {
            TextBox_Name.Text = null;
            DataGridView_Values.Rows.Clear();
            CartesianChart_Profile.Series.Clear();
            CartesianChart_Yearly.Series.Clear();

            if (profile != null)
            {
                TextBox_Name.Text = profile.Name;
                Enum @enum = profile.ProfileType;
                if ((ProfileType)@enum == ProfileType.Undefined)
                {
                    @enum = profile.ProfileGroup;
                }

                if (ComboBox_Category.Items == null || ComboBox_Category.Items.Count == 0)
                {
                    Query.CategoryEnums()?.ForEach(x => ComboBox_Category.Items.Add(Core.Query.Description(x)));
                }

                ComboBox_Category.Text = Core.Query.Description(@enum);

                StepLineSeries stepLineSeries = null;

                stepLineSeries = new StepLineSeries();
                stepLineSeries.PointGeometry = null;
                stepLineSeries.Values = new ChartValues<double>(profile.GetValues());
                stepLineSeries.Name = "Profile";
                CartesianChart_Profile.Series.Add(stepLineSeries);

                stepLineSeries = new StepLineSeries();
                stepLineSeries.PointGeometry = null;
                stepLineSeries.Values = new ChartValues<double>(profile.GetYearlyValues());
                CartesianChart_Yearly.Series.Add(stepLineSeries);

                DataGridView_Values.Rows.Clear();
                int min = profile.Min;
                int max = profile.Max;
                if (min != -1 && max != -1)
                {
                    for (int i = min; i < max + 1; i++)
                    {
                        if (!profile.TryGetValue(i, out Profile profile_Temp, out double value))
                        {
                            continue;
                        }

                        int index = DataGridView_Values.Rows.Add(i, profile_Temp?.Name, value);
                        if (index == -1)
                        {
                            continue;
                        }

                        DataGridView_Values.Rows[index].Tag = profile_Temp;
                    }
                }
            }
        }

        public Profile Profile
        {
            get
            {
                string category = ComboBox_Category.Text;

                Profile result = profile == null ? new Profile(TextBox_Name.Name, category) : new Profile(profile.Guid, profile, category);
                UpdateProfileValues(result);

                return result;
            }

            set
            {
                profile = value;
                LoadProfile();
            }
        }

        private void Button_SetValue_Click(object sender, EventArgs e)
        {
            int count = 1;
            int startIndex = 0;
            double? value = null;

            IEnumerable<DataGridViewRow> dataGridViewRows = DataGridView_Values.SelectedRows != null && DataGridView_Values.SelectedRows.Count != 0 ? DataGridView_Values.SelectedRows.Cast<DataGridViewRow>() : DataGridView_Values.Rows?.Cast<DataGridViewRow>();
            if (dataGridViewRows != null && dataGridViewRows.Count() != 0)
            {
                count = 0;
                startIndex = int.MaxValue;
                HashSet<double> values = new HashSet<double>();
                foreach (DataGridViewRow dataGridViewRow in DataGridView_Values.SelectedRows)
                {
                    if (!Core.Query.TryConvert(dataGridViewRow.Cells["Column_Index"].Value, out int startIndex_Temp))
                    {
                        continue;
                    }

                    if (startIndex_Temp < startIndex)
                    {
                        startIndex = startIndex_Temp;
                    }

                    count++;

                    if (!Core.Query.TryConvert(dataGridViewRow.Cells["Column_Value"].Value, out double value_Temp))
                    {
                        continue;
                    }

                    values.Add(value_Temp);
                }

                if (values != null && values.Count == 1)
                {
                    value = values.ToList()[0];
                }
            }

            using (SetProfileValueForm setProfileValueForm = new SetProfileValueForm(startIndex, count, value))
            {
                if (setProfileValueForm.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                count = setProfileValueForm.Count;
                startIndex = setProfileValueForm.StartIndex;
                value = setProfileValueForm.Value;
            }

            if (value == null || !value.HasValue)
            {
                return;
            }

            List<int> indexes = new List<int>();
            for (int i = 0; i < count; i++)
            {
                indexes.Add(startIndex + i);
            }

            foreach(DataGridViewRow dataGridViewRow in DataGridView_Values.Rows)
            {
                if (!Core.Query.TryConvert(dataGridViewRow.Cells["Column_Index"].Value, out int index))
                {
                    continue;
                }

                if(indexes.Contains(index))
                {
                    dataGridViewRow.Cells["Column_Value"].Value = value;
                    indexes.Remove(index);
                }

                if(indexes.Count == 0)
                {
                    break;
                }
            }

            if(indexes.Count == 0)
            {
                return;
            }

            foreach(int index in indexes)
            {
                DataGridView_Values.Rows.Add(index, null, value);
            }

        }
    }
}
