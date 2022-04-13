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
                    DataGridView_Constructions.Rows[index].Selected = true;
                }
            }
        }

        private void Add(ProfileLibrary profileLibrary)
        {
            List<string> uniqueIds = new List<string>();
            if (DataGridView_Constructions.SelectedRows != null && DataGridView_Constructions.SelectedRows.Count != 0)
            {
                foreach (DataGridViewRow dataGridViewRow in DataGridView_Constructions.SelectedRows)
                {
                    string uniqueId_Temp = profileLibrary?.GetUniqueId(dataGridViewRow.Tag as Profile);
                    if (string.IsNullOrWhiteSpace(uniqueId_Temp))
                    {
                        continue;
                    }

                    uniqueIds.Add(uniqueId_Temp);
                }
            }

            DataGridView_Constructions.Rows.Clear();

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

            int index = DataGridView_Constructions.Rows.Add(name, Core.Query.Description(type));
            DataGridViewRow result = DataGridView_Constructions.Rows[index];
            if (result != null)
            {
                result.Tag = profile;
            }

            if(type != null)
            {
                Enum @type_Selected = Type;
                if(type_Selected != null)
                {
                    if (!type.Equals(type_Selected))
                    {
                        if(type is ProfileType)
                        {
                            result.Visible = false;
                        }
                        else if(type is ProfileGroup)
                        {
                            if(type_Selected is ProfileType)
                            {
                                if(!((ProfileGroup)type).Equals(((ProfileType)type_Selected).ProfileGroup()))
                                {
                                    result.Visible = false;
                                }
                            }
                            else
                            {
                                result.Visible = false;
                            }
                        }
                    }
                }
            }

            return result;
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

            (DataGridView_Constructions.Columns[1] as DataGridViewComboBoxColumn).DataSource = profileTypes;

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
                    Add(profileLibrary);
                }
                else if (value is ProfileType || value is ProfileGroup)
                {
                    string text = Core.Query.Description(value);
                    if (ComboBox_Type.Text != text)
                    {
                        ComboBox_Type.Text = text;
                        Add(profileLibrary);
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

        private void DataGridView_Constructions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public List<Profile> GetProfiles(bool selected = true)
        {
            IEnumerable<DataGridViewRow> dataGridViewRows = selected ? DataGridView_Constructions.SelectedRows?.Cast<DataGridViewRow>() : DataGridView_Constructions.Rows?.Cast<DataGridViewRow>();
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
                return DataGridView_Constructions.MultiSelect;
            }
            set
            {
                DataGridView_Constructions.MultiSelect = value;
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
                    DataGridView_Constructions.ReadOnly = false;
                }
                else
                {
                    Button_Add.Visible = false;
                    Button_Duplicate.Visible = false;
                    Button_Remove.Visible = false;
                    DataGridView_Constructions.ReadOnly = true;
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
                profileLibrary.GetProfiles().ForEach(x => result.Remove(x));

                GetProfiles(false)?.ForEach(x => result.Add(x));
                return result;
            }
        }

        private void Button_Add_Click(object sender, EventArgs e)
        {
            //ApertureConstruction apertureConstruction = null;
            //using (ApertureConstructionForm apertureConstructionForm = new ApertureConstructionForm(materialLibrary, apertureConstructionLibrary))
            //{
            //    if(apertureConstructionForm.ShowDialog() != DialogResult.OK)
            //    {
            //        return;
            //    }

            //    apertureConstruction = apertureConstructionForm.ApertureConstruction;
            //}

            //if(apertureConstruction == null)
            //{
            //    return;
            //}

            //apertureConstructionLibrary?.Add(apertureConstruction);
            //Add(apertureConstruction);
        }

        private void Button_Remove_Click(object sender, EventArgs e)
        {
            if (DataGridView_Constructions.SelectedRows == null || DataGridView_Constructions.SelectedRows.Count == 0)
            {
                return;
            }

            foreach(DataGridViewRow dataGridViewRow in DataGridView_Constructions.SelectedRows)
            {
                DataGridView_Constructions.Rows.Remove(dataGridViewRow);

                Profile profile = dataGridViewRow.Tag as Profile;
                profileLibrary.Remove(profile);

            }
        }

        private void Button_Duplicate_Click(object sender, EventArgs e)
        {
            //if (DataGridView_Constructions.SelectedRows == null || DataGridView_Constructions.SelectedRows.Count == 0)
            //{
            //    return;
            //}

            //Profile profile = DataGridView_Constructions.SelectedRows[0].Tag as Profile;
            //if(profile == null)
            //{
            //    return;
            //}

            //string name = (string.IsNullOrWhiteSpace(profile.Name) ? string.Empty : profile.Name).Trim();
            //string name_Temp = name;
            //int index = 1;
            //while(profileLibrary?.GetProfiles()?.Find(x => x.Name == name_Temp) != null)
            //{
            //    name_Temp = string.Format("{0} {1}", name, index.ToString());
            //    index++;
            //}
            //name = name_Temp;

            //profile = new ApertureConstruction(Guid.NewGuid(), profile, name);
            //using (ApertureConstructionForm apertureConstructionForm = new ApertureConstructionForm(materialLibrary, apertureConstructionLibrary, apertureConstruction))
            //{
            //    if(apertureConstructionForm.ShowDialog() != DialogResult.OK)
            //    {
            //        return;
            //    }

            //    apertureConstruction = apertureConstructionForm.ApertureConstruction;
            //}

            //if(apertureConstruction == null)
            //{
            //    return;
            //}

            //apertureConstructionLibrary?.Add(apertureConstruction);
            //Add(apertureConstruction);
        }

        private void DataGridView_Constructions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (DataGridView_Constructions.SelectedRows == null || DataGridView_Constructions.SelectedRows.Count == 0)
            //{
            //    return;
            //}

            //ApertureConstruction apertureConstruction = DataGridView_Constructions.SelectedRows[0].Tag as ApertureConstruction;
            //if (apertureConstruction == null)
            //{
            //    return;
            //}

            //using (ApertureConstructionForm constructionForm = new ApertureConstructionForm(materialLibrary, apertureConstructionLibrary, apertureConstruction))
            //{
            //    constructionForm.Enabled = Button_Add.Visible;
            //    if (constructionForm.ShowDialog() != DialogResult.OK)
            //    {
            //        return;
            //    }

            //    apertureConstruction = constructionForm.ApertureConstruction;
            //}

            //DataGridView_Constructions.SelectedRows[0].Tag = apertureConstruction;
            //DataGridView_Constructions.SelectedRows[0].Cells[0].Value = apertureConstruction.Name;
            //DataGridView_Constructions.SelectedRows[0].Cells[1].Value = Math.Round(apertureConstruction.MaxThickness(), 3);
        }

        private void TextBox_Search_TextChanged(object sender, EventArgs e)
        {
            Add(profileLibrary);
        }

        private void ApertureConstructionLibraryForm_KeyDown(object sender, KeyEventArgs e)
        {
            Query.JsonForm(profileLibrary, this, e);
        }

        private void Button_Import_Click(object sender, EventArgs e)
        {
            List<Profile> profiles = Query.Import<Profile>(owner: this);
            if(profiles == null)
            {
                return;
            }

            profiles.ForEach(x => profileLibrary?.Add(x));
            Add(profileLibrary);
        }

        private void ComboBox_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            Add(profileLibrary);
        }
    }
}
