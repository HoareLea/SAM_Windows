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

            foreach(Construction construction in constructionLibrary.GetConstructions())
            {
                Add(construction);
            }
        }

        private bool Add(Construction construction)
        {
            if(construction == null)
            {
                return false;
            }

            string name = construction.Name;
            double thickness = Math.Round(construction.GetThickness(), 3);

            PanelType panelType = PanelType.Undefined;
            if(construction.TryGetValue(ConstructionParameter.DefaultPanelType, out string panelTypeString))
            {
                panelType = Core.Query.Enum<PanelType>(panelTypeString);
            }

            string defaultType = panelType == PanelType.Undefined ? string.Empty : Core.Query.Description(panelType);

            int index = DataGridView_Constructions.Rows.Add(name, thickness, defaultType);
            DataGridView_Constructions.Rows[index].Tag = construction;
            return true;
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
            if(dataGridViewRows == null)
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

        public ConstructionLibrary ConstructionLibrary
        {
            get
            {
                if(constructionLibrary == null)
                {
                    return null;
                }

                ConstructionLibrary result = new ConstructionLibrary(constructionLibrary);

                GetConstructions(false)?.ForEach(x => result.Add(x));
                return result;
            }
        }

        private void Button_Add_Click(object sender, EventArgs e)
        {
            Construction construction = null;
            using (ConstructionForm constructionForm = new ConstructionForm(materialLibrary))
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

            construction = new Construction(Guid.NewGuid(), construction, ((string.IsNullOrWhiteSpace(construction.Name) ? string.Empty : construction.Name) + " 1").Trim());
            using (ConstructionForm constructionForm = new ConstructionForm(materialLibrary, construction))
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

            using (ConstructionForm constructionForm = new ConstructionForm(materialLibrary, construction))
            {
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
    }
}
