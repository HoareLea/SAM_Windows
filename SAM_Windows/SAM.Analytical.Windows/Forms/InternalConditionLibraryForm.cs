using SAM.Core;
using SAM.Core.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SAM.Analytical.Windows.Forms
{
    public partial class InternalConditionLibraryForm : Form
    {
        private ProfileLibrary profileLibrary;
        private InternalConditionLibrary internalConditionLibrary;
        private AdjacencyCluster adjacencyCluster;

        private InternalCondition internalCondition_Selected;

        public InternalConditionLibraryForm()
        {
            InitializeComponent();
        }

        public InternalConditionLibraryForm(InternalConditionLibrary internalConditionLibrary, ProfileLibrary profileLibrary, AdjacencyCluster adjacencyCluster = null, InternalCondition internalCondition = null)
        {
            InitializeComponent();

            this.internalConditionLibrary = internalConditionLibrary;
            this.profileLibrary = profileLibrary;
            this.adjacencyCluster = adjacencyCluster;

            internalCondition_Selected = internalCondition;
        }

        private void ConstructionLibraryForm_Load(object sender, EventArgs e)
        {

            if (internalConditionLibrary == null)
            {
                internalConditionLibrary = new InternalConditionLibrary("Internal Condition Library");
            }

            string uniqueId = internalConditionLibrary?.GetUniqueId(internalCondition_Selected);

            List<InternalCondition> internalConditions = internalConditionLibrary?.GetInternalConditions();

            if (internalConditions != null)
            {
                internalConditions.Sort((x, y) => x.Name.CompareTo(y.Name));

                int index = -1;
                foreach (InternalCondition internalCondition_Temp in internalConditions)
                {
                    DataGridViewRow dataGridViewRow = Add(internalCondition_Temp);
                    if (uniqueId != null)
                    {
                        string uniqueId_Temp = internalConditionLibrary?.GetUniqueId(internalCondition_Temp);
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

        private void Add(InternalConditionLibrary internalConditionLibrary)
        {
            List<string> uniqueIds = new List<string>();
            if (DataGridView_Constructions.SelectedRows != null && DataGridView_Constructions.SelectedRows.Count != 0)
            {
                foreach (DataGridViewRow dataGridViewRow in DataGridView_Constructions.SelectedRows)
                {
                    string uniqueId_Temp = internalConditionLibrary?.GetUniqueId(dataGridViewRow.Tag as InternalCondition);
                    if (string.IsNullOrWhiteSpace(uniqueId_Temp))
                    {
                        continue;
                    }

                    uniqueIds.Add(uniqueId_Temp);
                }
            }

            DataGridView_Constructions.Rows.Clear();

            List<InternalCondition> internalConditions = internalConditionLibrary.GetInternalConditions();
            if (internalConditions == null || internalConditions.Count == 0)
            {
                return;
            }

            internalConditions.Sort((x, y) => x.Name.CompareTo(y.Name));

            if (!string.IsNullOrWhiteSpace(TextBox_Search.Text))
            {
                Func<InternalCondition, string> func = new Func<InternalCondition, string>((InternalCondition x) =>
                {
                    if (x == null)
                    {
                        return null;
                    }

                    string result = x.Name;

                    return result;
                });
                internalConditions = internalConditions.Search(TextBox_Search.Text, func);
            }

            foreach (InternalCondition internalCondition_Temp in internalConditions)
            {
                DataGridViewRow dataGridViewRow = Add(internalCondition_Temp);
                string uniqueId_Temp = internalConditionLibrary?.GetUniqueId(internalCondition_Temp);
                dataGridViewRow.Selected = uniqueIds.Contains(uniqueId_Temp);
            }
        }

        private DataGridViewRow Add(InternalCondition internalCondition)
        {
            if (internalCondition == null)
            {
                return null;
            }

            string name = internalCondition.Name;

            int index = DataGridView_Constructions.Rows.Add(name);
            DataGridViewRow result = DataGridView_Constructions.Rows[index];
            if (result != null)
            {
                result.Tag = internalCondition;
            }

            return result;
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

        public List<InternalCondition> GetInternalConditions(bool selected = true)
        {
            IEnumerable<DataGridViewRow> dataGridViewRows = selected ? DataGridView_Constructions.SelectedRows?.Cast<DataGridViewRow>() : DataGridView_Constructions.Rows?.Cast<DataGridViewRow>();
            if (dataGridViewRows == null)
            {
                return null;
            }
            List<InternalCondition> result = new List<InternalCondition>();
            foreach (DataGridViewRow dataGridViewRow in dataGridViewRows)
            {
                InternalCondition internalCondition = dataGridViewRow.Tag as InternalCondition;
                if (internalCondition == null)
                {
                    continue;
                }

                internalCondition = new InternalCondition(internalCondition);

                result.Add(internalCondition);
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

        public InternalConditionLibrary InternalConditionLibrary
        {
            get
            {
                if(internalConditionLibrary == null)
                {
                    return null;
                }

                InternalConditionLibrary result = new InternalConditionLibrary(internalConditionLibrary);
                internalConditionLibrary.GetInternalConditions().ForEach(x => result.Remove(x));

                GetInternalConditions(false)?.ForEach(x => result.Add(x));
                return result;
            }
        }

        public ProfileLibrary ProfileLibrary
        {
            get
            {
                return profileLibrary;
            }
        }

        public AdjacencyCluster AdjacencyCluster
        {
            get
            {
                if(adjacencyCluster == null)
                {
                    return null;
                }

                AdjacencyCluster result = new AdjacencyCluster(adjacencyCluster);
                List<InternalCondition> internalCondtions = GetInternalConditions(false);
                if (internalCondtions != null)
                {
                    foreach(InternalCondition internalCondition in internalCondtions)
                    {
                        result.AddObject(internalCondition);
                    }
                }

                return result;
            }
        }

        private void Button_Add_Click(object sender, EventArgs e)
        {
            InternalCondition internalCondition = null;
            using (InternalConditionForm internalConditionForm = new InternalConditionForm(internalCondition, profileLibrary, adjacencyCluster))
            {
                if(internalConditionForm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                internalCondition = internalConditionForm.InternalCondition;
            }

            if(internalCondition == null)
            {
                return;
            }

            internalConditionLibrary?.Add(internalCondition);
            Add(internalCondition);
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

                InternalCondition internalCondition = dataGridViewRow.Tag as InternalCondition;
                internalConditionLibrary.Remove(internalCondition);

            }
        }

        private void Button_Duplicate_Click(object sender, EventArgs e)
        {
            if (DataGridView_Constructions.SelectedRows == null || DataGridView_Constructions.SelectedRows.Count == 0)
            {
                return;
            }

            InternalCondition internalCondition = DataGridView_Constructions.SelectedRows[0].Tag as InternalCondition;
            if(internalCondition == null)
            {
                return;
            }

            string name = (string.IsNullOrWhiteSpace(internalCondition.Name) ? string.Empty : internalCondition.Name).Trim();
            string name_Temp = name;
            int index = 1;
            while(internalConditionLibrary?.GetInternalConditions()?.Find(x => x.Name == name_Temp) != null)
            {
                name_Temp = string.Format("{0} {1}", name, index.ToString());
                index++;
            }
            name = name_Temp;

            internalCondition = new InternalCondition(name, Guid.NewGuid(), internalCondition);
            using (InternalConditionForm internalConditionForm = new InternalConditionForm(internalCondition, profileLibrary, adjacencyCluster))
            {
                if(internalConditionForm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                internalCondition = internalConditionForm.InternalCondition;
            }

            if(internalCondition == null)
            {
                return;
            }

            internalConditionLibrary?.Add(internalCondition);
            Add(internalCondition);
        }

        private void DataGridView_Constructions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridView_Constructions.SelectedRows == null || DataGridView_Constructions.SelectedRows.Count == 0)
            {
                return;
            }

            InternalCondition internalCondition = DataGridView_Constructions.SelectedRows[0].Tag as InternalCondition;
            if (internalCondition == null)
            {
                return;
            }

            using (InternalConditionForm internalConditionForm = new InternalConditionForm(internalCondition, profileLibrary, adjacencyCluster))
            {
                internalConditionForm.Enabled = Button_Add.Visible;
                if (internalConditionForm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                internalCondition = internalConditionForm.InternalCondition;
            }

            DataGridView_Constructions.SelectedRows[0].Tag = internalCondition;
            DataGridView_Constructions.SelectedRows[0].Cells[0].Value = internalCondition?.Name;
        }

        private void TextBox_Search_TextChanged(object sender, EventArgs e)
        {
            Add(internalConditionLibrary);
        }

        private void ApertureConstructionLibraryForm_KeyDown(object sender, KeyEventArgs e)
        {
            Query.JsonForm(internalConditionLibrary, this, e);
        }

        private void Button_Import_Click(object sender, EventArgs e)
        {
            if(adjacencyCluster == null)
            {
                List<InternalCondition> internalConditions = Query.Import<InternalCondition>(owner: this);
                if (internalConditions == null || internalConditions.Count == 0)
                {
                    return;
                }

                foreach (InternalCondition internalCondition in internalConditions)
                {
                    internalConditionLibrary.Add(internalCondition);
                }
            }
            else
            {
                AnalyticalModel analyticalModel = new AnalyticalModel(Guid.NewGuid(), "Temporary AnalyticalModel");
                analyticalModel = Query.Import<InternalCondition>(analyticalModel, true, this);
                if(analyticalModel != null)
                {
                    IEnumerable<InternalCondition> internalConditions = analyticalModel.GetInternalConditions();
                    if(internalConditions != null)
                    {
                        foreach (InternalCondition internalCondition in internalConditions)
                        {
                            internalConditionLibrary.Add(internalCondition);
                        }
                    }

                    List<Profile> profiles = analyticalModel.ProfileLibrary?.GetProfiles();
                    if(profiles != null)
                    {
                        foreach (Profile profile in profiles)
                        {
                            profileLibrary?.Add(profile);
                        }
                    }
                }
            }

            Add(internalConditionLibrary);
        }

        private void Button_Export_Click(object sender, EventArgs e)
        {
            List<InternalCondition> internalConditions = GetInternalConditions(false);
            if(internalConditions == null || internalConditions.Count == 0)
            {
                return;
            }

            string path = null;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;
                if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                path = saveFileDialog.FileName;
            }

            string name = System.IO.Path.GetFileNameWithoutExtension(path);

            InternalConditionLibrary internalConditionLibrary = new InternalConditionLibrary(name);
            internalConditions.ForEach(x => internalConditionLibrary.Add(x));

            bool result = Core.Convert.ToFile(internalConditionLibrary, path);
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
