using SAM.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SAM.Analytical.Windows.Forms
{
    public partial class ConstructionLibraryForm : Form
    {
        private MaterialLibrary materialLibrary;
        private ConstructionLibrary constructionLibrary;

        private Construction construction_Selected;

        public ConstructionLibraryForm()
        {
            InitializeComponent();
        }

        public ConstructionLibraryForm(MaterialLibrary materialLibrary, ConstructionLibrary constructionLibrary)
        {
            InitializeComponent();

            this.constructionLibrary = constructionLibrary;
            this.materialLibrary = materialLibrary;
        }

        public ConstructionLibraryForm(MaterialLibrary materialLibrary, ConstructionLibrary constructionLibrary, Construction construction)
        {
            InitializeComponent();

            this.constructionLibrary = constructionLibrary;
            this.materialLibrary = materialLibrary;

            construction_Selected = construction;
        }

        private void ConstructionLibraryForm_Load(object sender, EventArgs e)
        {
            List<string> panelTypes = new List<string>();
            panelTypes.Add(string.Empty);
            foreach (PanelType panelType in Enum.GetValues(typeof(PanelType)))
            {
                if (panelType == PanelType.Undefined)
                {
                    continue;
                }

                panelTypes.Add(Core.Query.Description(panelType));
            }

            (DataGridView_Constructions.Columns[2] as DataGridViewComboBoxColumn).DataSource = panelTypes;

            if (constructionLibrary == null)
            {
                constructionLibrary = new ConstructionLibrary("Construction Library");
            }

            string uniqueId = constructionLibrary?.GetUniqueId(construction_Selected);

            List<Construction> constructions = constructionLibrary?.GetConstructions();

            if (constructions != null)
            {
                int index = -1;
                foreach (Construction construction_Temp in constructions)
                {
                    DataGridViewRow dataGridViewRow = Add(construction_Temp);
                    if (uniqueId != null)
                    {
                        string uniqueId_Temp = constructionLibrary?.GetUniqueId(construction_Temp);
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

            if (materialLibrary == null || materialLibrary.GetMaterials() == null)
            {
                Button_Materials.Visible = false;
                Button_Add.Visible = false;
            }
        }

        private void Add(ConstructionLibrary constructionLibrary)
        {
            List<string> uniqueIds = new List<string>();
            if (DataGridView_Constructions.SelectedRows != null && DataGridView_Constructions.SelectedRows.Count != 0)
            {
                foreach (DataGridViewRow dataGridViewRow in DataGridView_Constructions.SelectedRows)
                {
                    string uniqueId_Temp = constructionLibrary?.GetUniqueId(dataGridViewRow.Tag as Construction);
                    if (string.IsNullOrWhiteSpace(uniqueId_Temp))
                    {
                        continue;
                    }

                    uniqueIds.Add(uniqueId_Temp);
                }
            }

            DataGridView_Constructions.Rows.Clear();

            List<Construction> constructions = constructionLibrary.GetConstructions();
            if (constructions == null || constructions.Count == 0)
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(TextBox_Search.Text))
            {
                Func<Construction, string> func = new Func<Construction, string>((Construction construction) =>
                {
                    if (construction == null)
                    {
                        return null;
                    }

                    string result = construction.Name;

                    if (construction.TryGetValue(ConstructionParameter.DefaultPanelType, out string panelTypeString) && !string.IsNullOrWhiteSpace(panelTypeString))
                    {
                        PanelType panelType = Core.Query.Enum<PanelType>(panelTypeString);
                        if (panelType != PanelType.Undefined)
                        {
                            result = result == null ? Core.Query.Description(panelType) : string.Format("{0} {1}", result, Core.Query.Description(panelType));
                        }
                    }

                    return result;
                });
                constructions = constructions.Search(TextBox_Search.Text, func);
            }

            foreach (Construction construction_Temp in constructions)
            {
                DataGridViewRow dataGridViewRow = Add(construction_Temp);
                string uniqueId_Temp = constructionLibrary?.GetUniqueId(construction_Temp);
                dataGridViewRow.Selected = uniqueIds.Contains(uniqueId_Temp);
            }
        }

        private DataGridViewRow Add(Construction construction)
        {
            if (construction == null)
            {
                return null;
            }

            string name = construction.Name;
            double thickness = Math.Round(construction.GetThickness(), 3);

            PanelType panelType = PanelType.Undefined;
            if (construction.TryGetValue(ConstructionParameter.DefaultPanelType, out string panelTypeString))
            {
                panelType = Core.Query.Enum<PanelType>(panelTypeString);
            }

            string defaultType = panelType == PanelType.Undefined ? string.Empty : Core.Query.Description(panelType);

            int index = DataGridView_Constructions.Rows.Add(name, thickness, defaultType);
            DataGridViewRow result = DataGridView_Constructions.Rows[index];
            if (result != null)
            {
                result.Tag = construction;
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

        public List<Construction> GetConstructions(bool selected = true)
        {
            IEnumerable<DataGridViewRow> dataGridViewRows = selected ? DataGridView_Constructions.SelectedRows?.Cast<DataGridViewRow>() : DataGridView_Constructions.Rows?.Cast<DataGridViewRow>();
            if (dataGridViewRows == null)
            {
                return null;
            }
            List<Construction> result = new List<Construction>();
            foreach (DataGridViewRow dataGridViewRow in dataGridViewRows)
            {
                Construction construction = dataGridViewRow.Tag as Construction;
                if (construction == null)
                {
                    continue;
                }

                string value = dataGridViewRow.Cells[2].Value as string;
                PanelType panelType = Core.Query.Enum<PanelType>(value);

                if (panelType == PanelType.Undefined)
                {
                    construction.RemoveValue(ConstructionParameter.DefaultPanelType);
                }
                else
                {
                    construction.SetValue(ConstructionParameter.DefaultPanelType, panelType);
                }

                result.Add(construction);
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

        public bool MaterialsButtonVisible
        {
            get
            {
                return Button_Materials.Visible;
            }
            set
            {
                Button_Materials.Visible = value;
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

        public ConstructionLibrary ConstructionLibrary
        {
            get
            {
                if(constructionLibrary == null)
                {
                    return null;
                }

                ConstructionLibrary result = new ConstructionLibrary(constructionLibrary);
                constructionLibrary.GetConstructions().ForEach(x => result.Remove(x));

                GetConstructions(false)?.ForEach(x => result.Add(x));
                return result;
            }
        }

        private void Button_Add_Click(object sender, EventArgs e)
        {
            Construction construction = null;
            using (ConstructionForm constructionForm = new ConstructionForm(materialLibrary, constructionLibrary))
            {
                if(constructionForm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                construction = constructionForm.Construction;
            }

            if(construction == null)
            {
                return;
            }

            constructionLibrary?.Add(construction);
            Add(construction);
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

                Construction construction = dataGridViewRow.Tag as Construction;
                constructionLibrary.Remove(construction);

            }
        }

        private void Button_Duplicate_Click(object sender, EventArgs e)
        {
            if (DataGridView_Constructions.SelectedRows == null || DataGridView_Constructions.SelectedRows.Count == 0)
            {
                return;
            }

            Construction construction = DataGridView_Constructions.SelectedRows[0].Tag as Construction;
            if(construction == null)
            {
                return;
            }

            string name = (string.IsNullOrWhiteSpace(construction.Name) ? string.Empty : construction.Name).Trim();
            string name_Temp = name;
            int index = 1;
            while(constructionLibrary?.GetConstructions()?.Find(x => x.Name == name_Temp) != null)
            {
                name_Temp = string.Format("{0} {1}", name, index.ToString());
                index++;
            }
            name = name_Temp;

            construction = new Construction(Guid.NewGuid(), construction, name);
            using (ConstructionForm constructionForm = new ConstructionForm(materialLibrary, constructionLibrary, construction))
            {
                if(constructionForm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                construction = constructionForm.Construction;
            }

            if(construction == null)
            {
                return;
            }

            constructionLibrary?.Add(construction);
            Add(construction);
        }

        private void DataGridView_Constructions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridView_Constructions.SelectedRows == null || DataGridView_Constructions.SelectedRows.Count == 0)
            {
                return;
            }

            Construction construction = DataGridView_Constructions.SelectedRows[0].Tag as Construction;
            if (construction == null)
            {
                return;
            }

            using (ConstructionForm constructionForm = new ConstructionForm(materialLibrary, constructionLibrary, construction))
            {
                constructionForm.Enabled = Button_Add.Visible;
                if (constructionForm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                construction = constructionForm.Construction;
            }

            DataGridView_Constructions.SelectedRows[0].Tag = construction;
            DataGridView_Constructions.SelectedRows[0].Cells[0].Value = construction.Name;
            DataGridView_Constructions.SelectedRows[0].Cells[1].Value = Math.Round(construction.GetThickness(), 3);
        }

        private void TextBox_Search_TextChanged(object sender, EventArgs e)
        {
            Add(constructionLibrary);
        }

        private void Button_Materials_Click(object sender, EventArgs e)
        {
            using (Core.Windows.Forms.MaterialLibraryForm materialLibraryForm = new Core.Windows.Forms.MaterialLibraryForm(materialLibrary, Core.Query.Enums(typeof(OpaqueMaterialParameter), typeof(TransparentMaterialParameter))))
            {
                if (materialLibraryForm.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                materialLibrary = materialLibraryForm.MaterialLibrary;
            }
        }

        private void ConstructionLibraryForm_KeyDown(object sender, KeyEventArgs e)
        {
            Query.JsonForm(ConstructionLibrary, this, e);
        }
    }
}
