using SAM.Core;
using SAM.Core.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Automation.Peers;
using System.Windows.Forms;

namespace SAM.Analytical.Windows.Forms
{
    public partial class ApertureConstructionLibraryForm : Form
    {
        public event ConstructionManagerExportingEventHandler ConstructionManagerExporting;
        public event ConstructionManagerImportingEventHandler ConstructionManagerImporting;

        private MaterialLibrary materialLibrary;
        private ApertureConstructionLibrary apertureConstructionLibrary;

        private ApertureConstruction apertureConstruction_Selected;

        public ApertureConstructionLibraryForm()
        {
            InitializeComponent();
        }

        public ApertureConstructionLibraryForm(MaterialLibrary materialLibrary, ApertureConstructionLibrary apertureConstructionLibrary)
        {
            InitializeComponent();

            this.apertureConstructionLibrary = apertureConstructionLibrary;
            this.materialLibrary = materialLibrary;
        }

        public ApertureConstructionLibraryForm(MaterialLibrary materialLibrary, ApertureConstructionLibrary apertureConstructionLibrary, ApertureConstruction apertureConstruction)
        {
            InitializeComponent();

            this.apertureConstructionLibrary = apertureConstructionLibrary;
            this.materialLibrary = materialLibrary;

            apertureConstruction_Selected = apertureConstruction;
        }

        private void ConstructionLibraryForm_Load(object sender, EventArgs e)
        {
            List<string> apertureTypes = new List<string>();
            foreach (ApertureType apertureType in Enum.GetValues(typeof(ApertureType)))
            {
                if (apertureType == ApertureType.Undefined)
                {
                    continue;
                }

                apertureTypes.Add(Core.Query.Description(apertureType));
            }

            (DataGridView_Constructions.Columns[3] as DataGridViewComboBoxColumn).DataSource = apertureTypes;

            SetApertureConstructionLibrary(apertureConstructionLibrary);

            DataGridView_Constructions.MouseClick += DataGridView_Constructions_MouseClick;
        }

        private void DataGridView_Constructions_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            int? currentMouseOverRow = DataGridView_Constructions.HitTest(e.X, e.Y)?.RowIndex;
            if (currentMouseOverRow == null || !currentMouseOverRow.HasValue || currentMouseOverRow.Value == -1)
            {
                return;
            }

            ContextMenu contextMenu = new ContextMenu();

            MenuItem menuItem = new MenuItem("Change Aperture Type");
            menuItem.Click += MenuItem_Click;
            contextMenu.MenuItems.Add(menuItem);

            contextMenu.Show(DataGridView_Constructions, new Point(e.X, e.Y));
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dataGridViewSelectedRowCollection = DataGridView_Constructions.SelectedRows;
            if (dataGridViewSelectedRowCollection == null || dataGridViewSelectedRowCollection.Count == 0)
            {
                return;
            }

            HashSet<ApertureType> apertureTypes = new HashSet<ApertureType>();
            foreach (DataGridViewRow dataGridViewRow in dataGridViewSelectedRowCollection)
            {
                ApertureConstruction apertureConstruction = dataGridViewRow.Tag as ApertureConstruction;
                if (apertureConstruction == null)
                {
                    continue;
                }

                apertureTypes.Add(apertureConstruction.ApertureType);
                if (apertureTypes.Count > 1)
                {
                    break;
                }
            }

            ApertureType apertureType = apertureTypes.Count > 1 ? ApertureType.Undefined : apertureTypes.First();
            using (ComboBoxForm<ApertureType> comboBoxForm = new ComboBoxForm<ApertureType>("Aperture Type", Enum.GetValues(typeof(ApertureType)).Cast<ApertureType>(), x => x == ApertureType.Undefined ? string.Empty : x.Description()))
            {
                comboBoxForm.SelectedItem = apertureType;
                if (comboBoxForm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                apertureType = comboBoxForm.SelectedItem;
            }

            foreach (DataGridViewRow dataGridViewRow in dataGridViewSelectedRowCollection)
            {
                ApertureConstruction apertureConstruction = dataGridViewRow.Tag as ApertureConstruction;
                if (apertureConstruction == null)
                {
                    continue;
                }

                apertureConstruction = new ApertureConstruction(apertureConstruction, apertureType);

                Add(apertureConstruction, dataGridViewRow.Index);
            }
        }

        private void SetApertureConstructionLibrary(ApertureConstructionLibrary apertureConstructionLibrary)
        {
            this.apertureConstructionLibrary = apertureConstructionLibrary;

            if (this.apertureConstructionLibrary == null)
            {
                this.apertureConstructionLibrary = new ApertureConstructionLibrary("Aperture Construction Library");
            }

            DataGridView_Constructions.Rows.Clear();

            string uniqueId = this.apertureConstructionLibrary?.GetUniqueId(apertureConstruction_Selected);

            List<ApertureConstruction> apertureConstructions = this.apertureConstructionLibrary?.GetApertureConstructions();

            if (apertureConstructions != null)
            {
                int index = -1;
                foreach (ApertureConstruction construction_Temp in apertureConstructions)
                {
                    DataGridViewRow dataGridViewRow = Add(construction_Temp);
                    if (uniqueId != null)
                    {
                        string uniqueId_Temp = this.apertureConstructionLibrary?.GetUniqueId(construction_Temp);
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

        private void Add(ApertureConstructionLibrary apertureConstructionLibrary)
        {
            List<string> uniqueIds = new List<string>();
            if (DataGridView_Constructions.SelectedRows != null && DataGridView_Constructions.SelectedRows.Count != 0)
            {
                foreach (DataGridViewRow dataGridViewRow in DataGridView_Constructions.SelectedRows)
                {
                    string uniqueId_Temp = apertureConstructionLibrary?.GetUniqueId(dataGridViewRow.Tag as ApertureConstruction);
                    if (string.IsNullOrWhiteSpace(uniqueId_Temp))
                    {
                        continue;
                    }

                    uniqueIds.Add(uniqueId_Temp);
                }
            }

            DataGridView_Constructions.Rows.Clear();

            List<ApertureConstruction> apertureConstructions = apertureConstructionLibrary.GetApertureConstructions();
            if (apertureConstructions == null || apertureConstructions.Count == 0)
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(TextBox_Search.Text))
            {
                Func<ApertureConstruction, string> func = new Func<ApertureConstruction, string>((ApertureConstruction apertureConstruction) =>
                {
                    if (apertureConstruction == null)
                    {
                        return null;
                    }

                    string result = apertureConstruction.Name;

                    ApertureType apertureType = apertureConstruction.ApertureType;
                    if (apertureType != ApertureType.Undefined)
                    {
                        result = result == null ? Core.Query.Description(apertureType) : string.Format("{0} {1}", result, Core.Query.Description(apertureType));
                    }

                    return result;
                });
                apertureConstructions = apertureConstructions.Search(TextBox_Search.Text, func);
            }

            foreach (ApertureConstruction apertureConstruction_Temp in apertureConstructions)
            {
                DataGridViewRow dataGridViewRow = Add(apertureConstruction_Temp);
                string uniqueId_Temp = apertureConstructionLibrary?.GetUniqueId(apertureConstruction_Temp);
                dataGridViewRow.Selected = uniqueIds.Contains(uniqueId_Temp);
            }
        }

        private DataGridViewRow Add(ApertureConstruction apertureConstruction, int index = -1)
        {
            if (apertureConstruction == null)
            {
                return null;
            }

            string name = apertureConstruction.Name;
            double thickness = Math.Round(apertureConstruction.MaxThickness(), 3);

            if(!apertureConstruction.TryGetValue(ApertureConstructionParameter.Description, out string description))
            {
                description = null;
            }

            if(index == -1)
            {
                index = DataGridView_Constructions.Rows.Add();
            }

            DataGridViewRow result = DataGridView_Constructions.Rows[index];
            if (result != null)
            {
                result.Cells[0].Value = name;
                result.Cells[1].Value = description;
                result.Cells[2].Value = thickness;
                result.Cells[3].Value = Core.Query.Description(apertureConstruction.ApertureType);

                result.Tag = apertureConstruction;
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

        public List<ApertureConstruction> GetApertureConstructions(bool selected = true)
        {
            IEnumerable<DataGridViewRow> dataGridViewRows = selected ? DataGridView_Constructions.SelectedRows?.Cast<DataGridViewRow>() : DataGridView_Constructions.Rows?.Cast<DataGridViewRow>();
            if (dataGridViewRows == null)
            {
                return null;
            }
            List<ApertureConstruction> result = new List<ApertureConstruction>();
            foreach (DataGridViewRow dataGridViewRow in dataGridViewRows)
            {
                ApertureConstruction apertureConstruction = dataGridViewRow.Tag as ApertureConstruction;
                if (apertureConstruction == null)
                {
                    continue;
                }

                string value;

                value = dataGridViewRow.Cells[3].Value as string;
                ApertureType apertureType = Core.Query.Enum<ApertureType>(value);
                
                apertureConstruction = new ApertureConstruction(apertureConstruction, apertureType);

                value = dataGridViewRow.Cells[1].Value as string;
                if(string.IsNullOrEmpty(value))
                {
                    apertureConstruction.RemoveValue(ApertureConstructionParameter.Description);
                }
                else
                {
                    apertureConstruction.SetValue(ApertureConstructionParameter.Description, value);
                }

                result.Add(apertureConstruction);
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

        public ApertureConstructionLibrary ApertureConstructionLibrary
        {
            get
            {
                if(apertureConstructionLibrary == null)
                {
                    return null;
                }

                ApertureConstructionLibrary result = new ApertureConstructionLibrary(apertureConstructionLibrary);
                apertureConstructionLibrary.GetApertureConstructions().ForEach(x => result.Remove(x));

                GetApertureConstructions(false)?.ForEach(x => result.Add(x));
                return result;
            }
        }

        private void Button_Add_Click(object sender, EventArgs e)
        {
            ApertureConstruction apertureConstruction = null;
            using (ApertureConstructionForm apertureConstructionForm = new ApertureConstructionForm(materialLibrary, apertureConstructionLibrary))
            {
                if(apertureConstructionForm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                apertureConstruction = apertureConstructionForm.ApertureConstruction;
            }

            if(apertureConstruction == null)
            {
                return;
            }

            apertureConstructionLibrary?.Add(apertureConstruction);
            Add(apertureConstruction);
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

                ApertureConstruction apertureConstruction = dataGridViewRow.Tag as ApertureConstruction;
                apertureConstructionLibrary.Remove(apertureConstruction);

            }
        }

        private void Button_Duplicate_Click(object sender, EventArgs e)
        {
            if (DataGridView_Constructions.SelectedRows == null || DataGridView_Constructions.SelectedRows.Count == 0)
            {
                return;
            }

            ApertureConstruction apertureConstruction = DataGridView_Constructions.SelectedRows[0].Tag as ApertureConstruction;
            if(apertureConstruction == null)
            {
                return;
            }

            string name = (string.IsNullOrWhiteSpace(apertureConstruction.Name) ? string.Empty : apertureConstruction.Name).Trim();
            string name_Temp = name;
            int index = 1;
            while(apertureConstructionLibrary?.GetApertureConstructions()?.Find(x => x.Name == name_Temp) != null)
            {
                name_Temp = string.Format("{0} {1}", name, index.ToString());
                index++;
            }
            name = name_Temp;

            apertureConstruction = new ApertureConstruction(Guid.NewGuid(), apertureConstruction, name);
            using (ApertureConstructionForm apertureConstructionForm = new ApertureConstructionForm(materialLibrary, apertureConstructionLibrary, apertureConstruction))
            {
                if(apertureConstructionForm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                apertureConstruction = apertureConstructionForm.ApertureConstruction;
            }

            if(apertureConstruction == null)
            {
                return;
            }

            apertureConstructionLibrary?.Add(apertureConstruction);
            Add(apertureConstruction);
        }

        private void DataGridView_Constructions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridView_Constructions.SelectedRows == null || DataGridView_Constructions.SelectedRows.Count == 0)
            {
                return;
            }

            ApertureConstruction apertureConstruction = DataGridView_Constructions.SelectedRows[0].Tag as ApertureConstruction;
            if (apertureConstruction == null)
            {
                return;
            }

            using (ApertureConstructionForm constructionForm = new ApertureConstructionForm(materialLibrary, apertureConstructionLibrary, apertureConstruction))
            {
                constructionForm.Enabled = Button_Add.Visible;
                if (constructionForm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                apertureConstruction = constructionForm.ApertureConstruction;
            }

            DataGridView_Constructions.SelectedRows[0].Tag = apertureConstruction;
            DataGridView_Constructions.SelectedRows[0].Cells[0].Value = apertureConstruction.Name;
            if(!apertureConstruction.TryGetValue(ApertureConstructionParameter.Description, out string description))
            {
                description = null;
            }

            DataGridView_Constructions.SelectedRows[0].Cells[1].Value = description;
            DataGridView_Constructions.SelectedRows[0].Cells[2].Value = Math.Round(apertureConstruction.MaxThickness(), 3);
        }

        private void TextBox_Search_TextChanged(object sender, EventArgs e)
        {
            Add(apertureConstructionLibrary);
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

        private void ApertureConstructionLibraryForm_KeyDown(object sender, KeyEventArgs e)
        {
            Query.JsonForm(ApertureConstructionLibrary, this, e);
        }

        private void Button_Import_Click(object sender, EventArgs e)
        {
            ConstructionManager constructionManager = null;
            bool handled = false;

            if (ConstructionManagerImporting != null)
            {
                ConstructionManagerImportingEventArgs constructionManagerImportingEventArgs = new ConstructionManagerImportingEventArgs();

                ConstructionManagerImporting.Invoke(sender, constructionManagerImportingEventArgs);

                if (constructionManagerImportingEventArgs.Handled)
                {
                    handled = true;
                    constructionManager = constructionManagerImportingEventArgs.ConstructionManager;
                }
            }

            if (!handled)
            {
                AnalyticalModel analyticalModel = new AnalyticalModel(Guid.NewGuid(), "Temporary AnalyticalModel");
                Func<IJSAMObject, bool> func = new Func<IJSAMObject, bool>(x => { return x is Material || x is Construction; });

                analyticalModel = Query.Import(analyticalModel, func, new ImportOptions(), this);
                constructionManager = analyticalModel?.ConstructionManager;

                using (TreeViewForm<ApertureConstruction> treeViewForm = new TreeViewForm<ApertureConstruction>("Select", constructionManager?.ApertureConstructions, x => string.IsNullOrWhiteSpace(x?.Name) ? "???" : x.Name))
                {
                    if (treeViewForm.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    constructionManager = constructionManager.Filter(apertureConstructions: treeViewForm.SelectedItems, removeUnusedMaterials: true);
                }
            }

            IEnumerable<ApertureConstruction> apertureConstructions = constructionManager?.ApertureConstructions;
            if (apertureConstructions == null || apertureConstructions.Count() == 0)
            {
                MessageBox.Show("Constructions could not be imported.");
                return;
            }

            if (materialLibrary == null)
            {
                materialLibrary = new MaterialLibrary("MaterialLibrary");
            }

            constructionManager.Materials?.ForEach(x => materialLibrary.Add(x));


            if (apertureConstructionLibrary == null)
            {
                apertureConstructionLibrary = new ApertureConstructionLibrary("ApertureConstructionLibrary");
            }

            foreach (ApertureConstruction apertureConstruction in apertureConstructions)
            {
                apertureConstructionLibrary.Add(apertureConstruction);

            }

            SetApertureConstructionLibrary(apertureConstructionLibrary);
        }

        private void Button_Export_Click(object sender, EventArgs e)
        {
            List<ApertureConstruction> apertureConstructions = GetApertureConstructions(false);
            if (apertureConstructions == null || apertureConstructions.Count == 0)
            {
                return;
            }

            ApertureConstructionLibrary apertureConstructionLibrary = new ApertureConstructionLibrary("ApertureConstructionLibrary");
            apertureConstructions.ForEach(x => apertureConstructionLibrary.Add(x));

            MaterialLibrary materialLibrary_Temp = materialLibrary == null ? null : new MaterialLibrary(materialLibrary);

            ConstructionManager constructionManager = new ConstructionManager(apertureConstructionLibrary, null, materialLibrary);

            if (ConstructionManagerExporting != null)
            {
                ConstructionManagerExportingEventArgs constructionManagerExportingEventArgs = new ConstructionManagerExportingEventArgs();
                constructionManagerExportingEventArgs.ConstructionManager = constructionManager;

                ConstructionManagerExporting.Invoke(sender, constructionManagerExportingEventArgs);

                if (constructionManagerExportingEventArgs.Handled)
                {
                    return;
                }
            }

            string path = null;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;
                if (materialLibrary == null || materialLibrary.GetMaterials() == null)
                {
                    saveFileDialog.FileName = "SAM_ApertureConstructionLibrary_CustomVer00.json";
                }
                else
                {
                    saveFileDialog.FileName = "SAM_ConstructionManager_CustomVer00.json";
                }

                if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                path = saveFileDialog.FileName;
            }

            bool result = false;

            if (materialLibrary == null || materialLibrary.GetMaterials() == null)
            {
                result = Core.Convert.ToFile(apertureConstructionLibrary, path);
            }
            else
            {
                result = Core.Convert.ToFile(constructionManager, path);
            }

            if (result)
            {
                MessageBox.Show("Data exported successfully.");
            }
            else
            {
                MessageBox.Show("Data could not be exported.");
            }
        }
    }
}
