using SAM.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SAM.Analytical.Windows.Forms
{
    public partial class ProfileLibraryForm : Form
    {
        private ProfileLibrary profileLibrary;

        private Profile profile_Selected;

        public ProfileLibraryForm()
        {
            InitializeComponent();
            AddTypes();
        }

        public ProfileLibraryForm(ProfileLibrary profileLibrary)
        {
            InitializeComponent();

            this.profileLibrary = profileLibrary;

            AddTypes();
        }

        public ProfileLibraryForm(ProfileLibrary profileLibrary, Profile profile)
        {
            InitializeComponent();

            this.profileLibrary = profileLibrary;

            profile_Selected = profile;

            AddTypes();
        }

        private void ProfileLibraryForm_Load(object sender, EventArgs e)
        {
            if (profileLibrary == null)
            {
                profileLibrary = new ProfileLibrary("Profile Library");
            }

            string uniqueId = profileLibrary?.GetUniqueId(profile_Selected);

            List<Profile> profiles = profileLibrary?.GetProfiles();

            if (profiles != null)
            {
                DataGridView_Profiles.Rows.Clear();

                int index = -1;
                foreach (Profile profile_Temp in profiles)
                {
                    DataGridViewRow dataGridViewRow = Add(profile_Temp);
                    if (uniqueId != null)
                    {
                        string uniqueId_Temp = profileLibrary?.GetUniqueId(profile_Temp);
                        if (uniqueId.Equals(uniqueId_Temp))
                        {
                            index = dataGridViewRow.Index;
                        }
                    }
                }

                if (index != -1)
                {
                    DataGridView_Profiles.Rows[index].Selected = true;
                }
            }
        }

        private void SetProfileLibrary(ProfileLibrary profileLibrary)
        {
            List<string> uniqueIds = new List<string>();
            if (DataGridView_Profiles.SelectedRows != null && DataGridView_Profiles.SelectedRows.Count != 0)
            {
                foreach (DataGridViewRow dataGridViewRow in DataGridView_Profiles.SelectedRows)
                {
                    string uniqueId_Temp = profileLibrary?.GetUniqueId(dataGridViewRow.Tag as Profile);
                    if (string.IsNullOrWhiteSpace(uniqueId_Temp))
                    {
                        continue;
                    }

                    uniqueIds.Add(uniqueId_Temp);
                }
            }

            DataGridView_Profiles.Rows.Clear();

            List<Profile> profiles = profileLibrary.GetProfiles();
            if (profiles == null || profiles.Count == 0)
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(TextBox_Search.Text))
            {
                Func<Profile, string> func = new Func<Profile, string>((Profile profile) =>
                {
                    if (profile == null)
                    {
                        return null;
                    }

                    List<string> values = new List<string>();
                    if (!string.IsNullOrWhiteSpace(profile.Name))
                    {
                        values.Add(profile.Name);
                    }


                    if(!string.IsNullOrWhiteSpace(profile.Category))
                    {
                        values.Add(profile.Category);
                    }

                    return string.Join(" ", values);
                });
                profiles = profiles.Search(TextBox_Search.Text, func);
            }

            foreach (Profile profile_Temp in profiles)
            {
                DataGridViewRow dataGridViewRow = Add(profile_Temp);
                string uniqueId_Temp = profileLibrary?.GetUniqueId(profile_Temp);
                dataGridViewRow.Selected = uniqueIds.Contains(uniqueId_Temp);
            }
        }

        private DataGridViewRow Add(Profile profile)
        {
            if (profile == null)
            {
                return null;
            }

            string name = profile.Name;

            Enum type = null;
            type = profile.ProfileType;
            if((ProfileType)type == ProfileType.Undefined)
            {
                type = profile.ProfileGroup;
            }

            int index = DataGridView_Profiles.Rows.Add(name, Core.Query.Description(type));
            DataGridViewRow result = DataGridView_Profiles.Rows[index];
            if (result != null)
            {
                result.Tag = profile;
                result.Visible = IsValid(profile);
            }

            return result;
        }

        private bool IsValid(Profile profile)
        {
            if(profile == null)
            {
                return false;
            }

            Enum type = null;
            type = profile.ProfileType;
            if ((ProfileType)type == ProfileType.Undefined)
            {
                type = profile.ProfileGroup;
            }

            if(type == null)
            {
                return true;
            }

            Enum @type_Selected = Type;
            if (type_Selected != null)
            {
                if (!type.Equals(type_Selected))
                {
                    if (type_Selected is ProfileType)
                    {
                        if(!(type is ProfileGroup))
                        {
                            return false;
                        }

                        ProfileGroup profileGroup = (ProfileGroup)type;
                        ProfileType profileType = (ProfileType)type_Selected;
                        if (!profileGroup.Equals(profileType.ProfileGroup()))
                        {
                            return false;
                        }

                    }
                    else if (type_Selected is ProfileGroup)
                    {
                        if (type is ProfileType)
                        {
                            if (!((ProfileGroup)type_Selected).Equals(((ProfileType)type).ProfileGroup()))
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private void AddTypes()
        {
            List<string> profileTypes = new List<string>();
            foreach (ProfileType profileType in Enum.GetValues(typeof(ProfileType)))
            {
                if (profileType == ProfileType.Undefined)
                {
                    continue;
                }

                profileTypes.Add(Core.Query.Description(profileType));
            }

            foreach (ProfileGroup profileGroup in Enum.GetValues(typeof(ProfileGroup)))
            {
                if (profileGroup == ProfileGroup.Undefined)
                {
                    continue;
                }

                profileTypes.Add(Core.Query.Description(profileGroup));
            }

            (DataGridView_Profiles.Columns[1] as DataGridViewComboBoxColumn).DataSource = profileTypes;

            profileTypes = new List<string>(profileTypes);
            profileTypes.Insert(0, string.Empty);
            ComboBox_Type.DataSource = profileTypes;
            ComboBox_Type.Text = string.Empty;
        }

        public Enum Type
        {
            get
            {
                if (string.IsNullOrWhiteSpace(ComboBox_Type.Text))
                {
                    return null;
                }

                Enum result = Core.Query.Enum<ProfileType>(ComboBox_Type.Text);
                if ((ProfileType)result == ProfileType.Undefined)
                {
                    result = Core.Query.Enum<ProfileGroup>(ComboBox_Type.Text);
                }

                return result;
            }

            set
            {
                if (value == null && ComboBox_Type.Text != string.Empty)
                {
                    ComboBox_Type.Text = string.Empty;
                    SetProfileLibrary(profileLibrary);
                }
                else if (value is ProfileType || value is ProfileGroup)
                {
                    string text = Core.Query.Description(value);
                    if (ComboBox_Type.Text != text)
                    {
                        ComboBox_Type.Text = text;
                        SetProfileLibrary(profileLibrary);
                    }
                }
            }
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            Close();
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

        private void DataGridView_Profiles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public List<Profile> GetProfiles(bool selected = true)
        {
            IEnumerable<DataGridViewRow> dataGridViewRows = selected ? DataGridView_Profiles.SelectedRows?.Cast<DataGridViewRow>() : DataGridView_Profiles.Rows?.Cast<DataGridViewRow>();
            if (dataGridViewRows == null)
            {
                return null;
            }
            List<Profile> result = new List<Profile>();
            foreach (DataGridViewRow dataGridViewRow in dataGridViewRows)
            {
                Profile profile = dataGridViewRow.Tag as Profile;
                if (profile == null)
                {
                    continue;
                }

                string value = dataGridViewRow.Cells[1].Value as string;
                profile = new Profile(profile.Guid, profile, value);

                result.Add(profile);
            }

            return result;
        }

        public bool MultiSelect
        {
            get
            {
                return DataGridView_Profiles.MultiSelect;
            }
            set
            {
                DataGridView_Profiles.MultiSelect = value;
            }
        }

        public bool TypeEnabled
        {
            get
            {
                return ComboBox_Type.Enabled;
            }

            set
            {
                ComboBox_Type.Enabled = value;
            }
        }

        public bool Enabled
        {
            set
            {
                if(value)
                {
                    Button_Add.Visible = true;
                    Button_Duplicate.Visible = true;
                    Button_Remove.Visible = true;
                    DataGridView_Profiles.ReadOnly = false;
                }
                else
                {
                    Button_Add.Visible = false;
                    Button_Duplicate.Visible = false;
                    Button_Remove.Visible = false;
                    DataGridView_Profiles.ReadOnly = true;
                }
            }
        }

        public ProfileLibrary ProfileLibrary
        {
            get
            {
                if(profileLibrary == null)
                {
                    return null;
                }

                ProfileLibrary result = new ProfileLibrary(profileLibrary);
                profileLibrary.GetProfiles()?.ForEach(x => result.Remove(x));

                GetProfiles(false)?.ForEach(x => result.Add(x));
                return result;
            }
        }

        private void Button_Add_Click(object sender, EventArgs e)
        {
            Profile profile = null;
            using (ProfileForm profileForm = new ProfileForm(profile))
            {
                profileForm.ProfileLibrary = ProfileLibrary;
                profileForm.Category = ComboBox_Type.Text;
                if (profileForm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                profile = profileForm.Profile;
                profileLibrary = profileForm.ProfileLibrary;
            }

            if (profile == null)
            {
                return;
            }

            profileLibrary?.Add(profile);
            SetProfileLibrary(profileLibrary);

            string uniqueId = profileLibrary?.GetUniqueId(profile);
            if(!string.IsNullOrWhiteSpace(uniqueId))
            {
                foreach (DataGridViewRow dataGridViewRow in DataGridView_Profiles.Rows)
                {
                    string uniqueId_Temp = profileLibrary?.GetUniqueId(dataGridViewRow.Tag as Profile);
                    if (string.IsNullOrWhiteSpace(uniqueId_Temp))
                    {
                        continue;
                    }

                    if(uniqueId_Temp == uniqueId)
                    {
                        dataGridViewRow.Selected = true;
                        break;
                    }
                }
            }

        }

        private void Button_Remove_Click(object sender, EventArgs e)
        {
            if (DataGridView_Profiles.SelectedRows == null || DataGridView_Profiles.SelectedRows.Count == 0)
            {
                return;
            }

            foreach(DataGridViewRow dataGridViewRow in DataGridView_Profiles.SelectedRows)
            {
                DataGridView_Profiles.Rows.Remove(dataGridViewRow);

                Profile profile = dataGridViewRow.Tag as Profile;
                profileLibrary.Remove(profile);

            }

            SetProfileLibrary(profileLibrary);
        }

        private void Button_Duplicate_Click(object sender, EventArgs e)
        {
            if (DataGridView_Profiles.SelectedRows == null || DataGridView_Profiles.SelectedRows.Count == 0)
            {
                return;
            }

            Profile profile = DataGridView_Profiles.SelectedRows[0].Tag as Profile;
            if (profile == null)
            {
                return;
            }

            string name = (string.IsNullOrWhiteSpace(profile.Name) ? string.Empty : profile.Name).Trim();
            string name_Temp = name;
            int index = 1;
            while (profileLibrary?.GetProfiles()?.Find(x => x.Name == name_Temp) != null)
            {
                name_Temp = string.Format("{0} {1}", name, index.ToString());
                index++;
            }
            name = name_Temp;

            profile = new Profile(Guid.NewGuid(), profile, name, profile.Category);
            using (ProfileForm profileForm = new ProfileForm(profile))
            {
                profileForm.ProfileLibrary = ProfileLibrary;

                if (profileForm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                profile = profileForm.Profile;
                profileLibrary = profileForm.ProfileLibrary;
            }

            if (profile == null)
            {
                return;
            }

            profileLibrary?.Add(profile);
            SetProfileLibrary(profileLibrary);
        }

        private void DataGridView_Profiles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridView_Profiles.SelectedRows == null || DataGridView_Profiles.SelectedRows.Count == 0)
            {
                return;
            }

            Profile profile = DataGridView_Profiles.SelectedRows[0].Tag as Profile;
            if (profile == null)
            {
                return;
            }

            string uniqueId = ProfileLibrary?.GetUniqueId(profile);

            using (ProfileForm profileForm = new ProfileForm(new Profile(profile)))
            {
                profileForm.ProfileLibrary = ProfileLibrary;
                if (profileForm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                profile = profileForm.Profile;
                profileLibrary = profileForm.ProfileLibrary;
            }

            if(string.IsNullOrWhiteSpace(uniqueId))
            {
                profileLibrary?.Add(profile);
            }
            else
            {
                profileLibrary?.Replace(uniqueId, profile);
            }

            SetProfileLibrary(profileLibrary);
        }

        private void TextBox_Search_TextChanged(object sender, EventArgs e)
        {
            SetProfileLibrary(profileLibrary);
        }

        private void ProfileLibraryForm_KeyDown(object sender, KeyEventArgs e)
        {
            Query.JsonForm(profileLibrary, this, e);
        }

        private void Button_Import_Click(object sender, EventArgs e)
        {
            Func<Profile, bool> func = null;
            if(!ComboBox_Type.Enabled)
            {
                func = new Func<Profile, bool>((Profile x) =>
                {
                    return IsValid(x);
                });
            }

            List<Profile> profiles = Query.Import(func: func, owner: this);
            if(profiles == null)
            {
                return;
            }

            profiles.ForEach(x => profileLibrary?.Add(x));
            SetProfileLibrary(profileLibrary);
        }

        private void ComboBox_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetProfileLibrary(profileLibrary);
        }

        private void Button_Export_Click(object sender, EventArgs e)
        {
            List<Profile> profiles = GetProfiles(false);
            if (profiles == null || profiles.Count == 0)
            {
                return;
            }

            string path = null;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.FileName = "SAM_ProfileLibrary_CustomVer00.json";
                if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                path = saveFileDialog.FileName;
            }

            string name = System.IO.Path.GetFileNameWithoutExtension(path);

            ProfileLibrary profileLibrary = new ProfileLibrary(name);
            profiles.ForEach(x => profileLibrary.Add(x));

            bool result = Core.Convert.ToFile(profileLibrary, path);
            if (result)
            {
                MessageBox.Show("Library exported successfully.");
            }
            else
            {
                MessageBox.Show("Library could not be exported.");
            }
        }
    }
}
