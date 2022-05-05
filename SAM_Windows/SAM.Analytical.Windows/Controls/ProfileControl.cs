using SAM.Analytical.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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
            InitializeComponent();

            this.profile = profile;
        }

        private void ProfileControl_Load(object sender, EventArgs e)
        {
            Button_SetProfile.Enabled = profileLibrary != null;
        }

        private void UpdateProfileValues(Profile profile)
        {
            if(profile == null)
            {
                return;
            }

            Profile profile_Temp = null;
            foreach (DataGridViewRow dataGridViewRow in DataGridView_Values.Rows)
            {
                if (!Core.Query.TryConvert(dataGridViewRow.Cells["Column_Index"]?.Value, out int index))
                {
                    continue;
                }

                if (!Core.Query.TryConvert(dataGridViewRow.Cells["Column_Value"]?.Value, out double value))
                {
                    continue;
                }

                Profile profile_DataGridViewRow = dataGridViewRow.Tag as Profile;
                if(profile_DataGridViewRow == null)
                {
                    profile_Temp = null;
                    profile.Add(index, value);
                }
                else if(profile_Temp == profile_DataGridViewRow)
                {
                    continue;
                }
                else
                {
                    profile_Temp = profile_DataGridViewRow;
                }
            }

        }

        private void LoadProfile(Profile profile)
        {
            TextBox_Name.Text = null;
            DataGridView_Values.Rows.Clear();

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

                Chart_Main.Series.Clear();

                Series series = Chart_Main.Series.Add(profile.Name);
                Chart_Main.ChartAreas[series.ChartArea].AxisX.IsMarginVisible = false;
                Chart_Main.ChartAreas[series.ChartArea].AxisX.Interval = 1;
                Chart_Main.ChartAreas[series.ChartArea].AxisX.LabelStyle.IsStaggered = false;
                Chart_Main.ChartAreas[series.ChartArea].AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
                Chart_Main.ChartAreas[series.ChartArea].AxisX.InterlacedColor = System.Drawing.Color.LightGray;
                Chart_Main.ChartAreas[series.ChartArea].AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
                Chart_Main.ChartAreas[series.ChartArea].AxisY.InterlacedColor = System.Drawing.Color.LightGray;

                Chart_Main.ChartAreas[series.ChartArea].AxisX.LabelStyle.Font = Font;
                Chart_Main.ChartAreas[series.ChartArea].AxisY.LabelStyle.Font = Font;

                double[] values = profile.GetDailyValues();
                if(values != null)
                {
                    for(int i =0; i < values.Length; i++)
                    {
                        series.Points.Add(values[i], i);
                    }
                }

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
                LoadProfile(profile);
            }
        }

        public ProfileLibrary ProfileLibrary
        {
            get
            {
                return profileLibrary;
            }

            set
            {
                profileLibrary = value;
                Button_SetProfile.Enabled = profileLibrary != null;
            }
        }

        private void Button_SetValue_Click(object sender, EventArgs e)
        {
            Profile profile = Profile;
            if(profile == null)
            {
                return;
            }

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
                value = setProfileValueForm.Value;

                if(!setProfileValueForm.Append)
                {
                    startIndex = setProfileValueForm.StartIndex;
                }
                else
                {
                    startIndex = profile.Max + 1;
                }
                
            }

            if (value == null || !value.HasValue)
            {
                return;
            }

            profile.Update(startIndex, count, value.Value);

            LoadProfile(profile);
        }

        private void Button_Remove_Click(object sender, EventArgs e)
        {
            if(DataGridView_Values.SelectedRows == null || DataGridView_Values.SelectedRows.Count == 0)
            {
                return;
            }

            Profile profile = Profile;
            if (profile == null)
            {
                return;
            }

            int count = 1;
            int startIndex = 0;

            IEnumerable<DataGridViewRow> dataGridViewRows = DataGridView_Values.SelectedRows.Cast<DataGridViewRow>();
            if (dataGridViewRows != null && dataGridViewRows.Count() != 0)
            {
                count = 0;
                startIndex = int.MaxValue;
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
                }
            }

            if(startIndex + count - 1 == profile.Max)
            {
                profile.Remove(count);
            }
            else
            {
                profile.Update(startIndex, count, 0);
            }

            LoadProfile(profile);
        }

        private void Button_SetProfile_Click(object sender, EventArgs e)
        {
            if (DataGridView_Values.SelectedRows == null || DataGridView_Values.SelectedRows.Count == 0)
            {
                return;
            }

            List<Profile> profiles = profileLibrary?.GetProfiles(profile.ProfileGroup, true);
            if(profiles == null)
            {
                return;
            }

            profiles.RemoveAll(x => x.Guid == profile.Guid);

            if(profiles.Count == 0)
            {
                return;
            }

            int startIndex = int.MaxValue;
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
            }

            Profile profile_ToBeAdded = null;

            using (SetProfileForm setProfileForm = new SetProfileForm(startIndex, profiles))
            {
                if(setProfileForm.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                profile_ToBeAdded = setProfileForm.Profile;

                if(!setProfileForm.Append)
                {
                    startIndex = setProfileForm.StartIndex;
                }
                else
                {
                    startIndex = profile.Max + 1;
                }

            }

            profile.Update(startIndex, profile_ToBeAdded);

            LoadProfile(profile);
        }
    }
}
