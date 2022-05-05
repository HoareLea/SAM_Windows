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
            if (profile == null)
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
                if (profile_DataGridViewRow == null)
                {
                    profile_Temp = null;
                    profile.Add(index, value);
                }
                else if (profile_Temp == profile_DataGridViewRow)
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
                if (values != null)
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        series.Points.Add(values[i], i);
                    }
                }

                DataGridView_Values.Rows.Clear();
                int min = profile.Min;
                int max = profile.Max;

                double minValue = double.MaxValue;
                double maxValue = double.MinValue;
                if (min != -1 && max != -1)
                {
                    for (int i = min; i < max + 1; i++)
                    {
                        if (!profile.TryGetValue(i, out Profile profile_Temp, out double value))
                        {
                            continue;
                        }

                        int index = DataGridView_Values.Rows.Add(i, value, profile_Temp?.Name);
                        if (index == -1)
                        {
                            continue;
                        }

                        if (value > maxValue)
                        {
                            maxValue = value;
                        }

                        if(value < minValue)
                        {
                            minValue = value;
                        }

                        DataGridView_Values.Rows[index].Tag = profile_Temp;
                    }
                }

                TextBox_MaxValue.Text = maxValue != double.MinValue ? maxValue.ToString() : string.Empty;
                TextBox_MinValue.Text = minValue != double.MaxValue ? minValue.ToString() : string.Empty;

                Profile[] profiles = profile.GetProfiles();
                DataGridView_Values.Columns[2].Visible = profiles != null && profiles.Length != 0;
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
            if (profile == null)
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

                if (!setProfileValueForm.Append)
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
            if (DataGridView_Values.SelectedRows == null || DataGridView_Values.SelectedRows.Count == 0)
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

            if (startIndex + count - 1 == profile.Max)
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
            if (profiles == null)
            {
                return;
            }

            profiles.RemoveAll(x => x.Guid == profile.Guid);

            if (profiles.Count == 0)
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
                if (setProfileForm.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                profile_ToBeAdded = setProfileForm.Profile;

                if (!setProfileForm.Append)
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

        private void ToolStripMenuItem_Copy_Click(object sender, EventArgs e)
        {
            DataObject dataObject = DataGridView_Values.GetClipboardContent();
            Clipboard.SetDataObject(dataObject);
        }

        private void ToolStripMenuItem_Paste_Click(object sender, EventArgs e)
        {
            string text = Clipboard.GetText();
            if (string.IsNullOrWhiteSpace(text))
            {
                return;
            }

            string[] lines = text.Split('\n');
            if (lines == null || lines.Length == 0)
            {
                return;
            }

            Profile profile = Profile;

            int startIndex = 0;
            if (DataGridView_Values.SelectedRows != null && DataGridView_Values.SelectedRows.Count != 0)
            {
                if (Core.Query.TryConvert(DataGridView_Values.SelectedRows[DataGridView_Values.SelectedRows.Count - 1].Cells[0].Value, out int startIndex_Temp))
                {
                    startIndex = startIndex_Temp;
                }
            }

            bool updated = false;
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                string[] stringValues = line.Split('\t');
                if (stringValues == null || stringValues.Length == 0)
                {
                    continue;
                }

                int index = -1;
                double value = double.NaN; ;
                if (stringValues.Length == 1)
                {
                    if (Core.Query.TryConvert(stringValues[0], out value))
                    {
                        index = startIndex + i;
                    }
                }
                else
                {
                    if (Core.Query.TryConvert(stringValues[0], out index))
                    {
                        if (Core.Query.TryConvert(stringValues[1], out value))
                        {

                        }
                    }
                }

                if (index == -1 || double.IsNaN(value))
                {
                    continue;
                }

                if (profile.Update(index, value))
                {
                    updated = true;
                }
            }

            if (updated)
            {
                LoadProfile(profile);
            }

        }

        private void ToolStripMenuItem_SelectAll_Click(object sender, EventArgs e)
        {
            DataGridView_Values.SelectAll();
        }

        private void DataGridView_Values_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_NumberOnly);
            DataGridView_Values.CellValueChanged -= new DataGridViewCellEventHandler(this.DataGridView_Values_CellValueChanged);
            if (DataGridView_Values.CurrentCell.ColumnIndex == 1)
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_NumberOnly);
                    DataGridView_Values.CellValueChanged += new DataGridViewCellEventHandler(this.DataGridView_Values_CellValueChanged);
                }
            }
        }

        private void DataGridView_Values_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView_Values.CellValueChanged -= new DataGridViewCellEventHandler(this.DataGridView_Values_CellValueChanged);

            if (!Core.Query.TryConvert(DataGridView_Values.Rows[e.RowIndex].Cells[0].Value, out int index))
            {
                return;
            }

            if (!Core.Query.TryConvert(DataGridView_Values.Rows[e.RowIndex].Cells[1].Value, out double value))
            {
                return;
            }


            Profile profile = Profile;
            if(profile.Update(index, value))
            {
                LoadProfile(profile);
            }
        }
    }
}
