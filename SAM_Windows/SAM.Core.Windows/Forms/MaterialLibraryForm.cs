using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SAM.Core.Windows.Forms
{
    public partial class MaterialLibraryForm : Form
    {
        private MaterialLibrary materialLibrary;
        private HashSet<Enum> enums;

        private IMaterial material_Selected;

        public MaterialLibraryForm()
        {
            InitializeComponent();
        }

        public MaterialLibraryForm(MaterialLibrary materialLibrary, IEnumerable<Enum> enums = null, IMaterial material_Selected = null)
        {
            InitializeComponent();

            if (materialLibrary != null)
            {
                this.materialLibrary = new MaterialLibrary(materialLibrary);
            }

            this.material_Selected = material_Selected;
            if(enums != null)
            {
                this.enums = new HashSet<Enum>();
                foreach(Enum @enum in enums)
                {
                    this.enums.Add(@enum);
                }
            }
        }

        private void MaterialLibraryForm_Load(object sender, EventArgs e)
        {
            if (materialLibrary == null)
            {
                materialLibrary = new MaterialLibrary("Material Library");
            }

            string uniqueId = materialLibrary?.GetUniqueId(material_Selected);

            List<IMaterial> constructions = materialLibrary?.GetMaterials();

            if (constructions != null)
            {
                int index = -1;
                foreach (IMaterial construction_Temp in constructions)
                {
                    DataGridViewRow dataGridViewRow = Add(construction_Temp);
                    if (uniqueId != null)
                    {
                        string uniqueId_Temp = materialLibrary?.GetUniqueId(construction_Temp);
                        if (uniqueId.Equals(uniqueId_Temp))
                        {
                            index = dataGridViewRow.Index;
                        }
                    }
                }

                if (index != -1)
                {
                    DataGridView_Materials.Rows[index].Selected = true;
                }
            }
        }

        private void TextBox_Search_TextChanged(object sender, EventArgs e)
        {
            List<string> uniqueIds = new List<string>();
            if (DataGridView_Materials.SelectedRows != null && DataGridView_Materials.SelectedRows.Count != 0)
            {
                foreach (DataGridViewRow dataGridViewRow in DataGridView_Materials.SelectedRows)
                {
                    string uniqueId_Temp = materialLibrary?.GetUniqueId(dataGridViewRow.Tag as IMaterial);
                    if (string.IsNullOrWhiteSpace(uniqueId_Temp))
                    {
                        continue;
                    }

                    uniqueIds.Add(uniqueId_Temp);
                }
            }

            DataGridView_Materials.Rows.Clear();

            List<IMaterial> materials = materialLibrary.GetMaterials();
            if (materials == null || materials.Count == 0)
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(TextBox_Search.Text))
            {
                Func<IMaterial, string> func = new Func<IMaterial, string>((IMaterial material) =>
                {
                    if (material == null)
                    {
                        return null;
                    }

                    string result = material.Name;
                    return result;
                });
                materials = materials.Search(TextBox_Search.Text, func);
            }

            foreach (IMaterial material_Temp in materials)
            {
                DataGridViewRow dataGridViewRow = Add(material_Temp);
                string uniqueId_Temp = materialLibrary?.GetUniqueId(material_Temp);
                dataGridViewRow.Selected = uniqueIds.Contains(uniqueId_Temp);
            }
        }

        private DataGridViewRow Add(IMaterial material)
        {
            if (material == null)
            {
                return null;
            }

            int index = -1;
            if (material is Material)
            {
                Material material_Temp = (Material)material;
                index = DataGridView_Materials.Rows.Add(material_Temp.DisplayName, material_Temp.Name, material_Temp.Description);
            }
            else
            {
                index = DataGridView_Materials.Rows.Add(null, material.Name, null);
            }

            if (index == -1)
            {
                return null;
            }

            DataGridView_Materials.Rows[index].Tag = material;

            return DataGridView_Materials.Rows[index];
        }

        private void DataGridView_Materials_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == -1 || e.RowIndex == -1)
            {
                return;
            }

            IMaterial material = DataGridView_Materials.Rows[e.RowIndex].Tag as IMaterial;
            if(material == null)
            {
                return;
            }

            using (MaterialForm materialForm = new MaterialForm(material, enums))
            {
                if(materialForm.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                material = materialForm.Material;
            }

            if(material == null)
            {
                return;
            }

            DataGridView_Materials.Rows.Remove(DataGridView_Materials.Rows[e.RowIndex]);
            DataGridViewRow dataGridViewRow = Add(material);
            DataGridView_Materials.Rows.Remove(dataGridViewRow);
            DataGridView_Materials.Rows.Insert(e.RowIndex, dataGridViewRow);

            materialLibrary.Add(material);
        }

        public MaterialLibrary MaterialLibrary
        {
            get
            {
                return new MaterialLibrary(materialLibrary);
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

        private void Button_Duplicate_Click(object sender, EventArgs e)
        {
            if (DataGridView_Materials.SelectedRows == null || DataGridView_Materials.SelectedRows.Count == 0)
            {
                return;
            }

            IMaterial material = DataGridView_Materials.SelectedRows[0].Tag as IMaterial;
            if (material == null)
            {
                return;
            }

            material = Modify.Duplicate(materialLibrary, material, this, enums);
            if(material != null)
            {
                Add(material);
            }
        }

        private void Button_Add_Click(object sender, EventArgs e)
        {
            IMaterial material = null;
            using (MaterialForm materialForm = new MaterialForm(material, enums))
            {
                if (materialForm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                material = materialForm.Material;
            }

            if (material == null)
            {
                return;
            }

            materialLibrary?.Add(material);
            Add(material);
        }

        private void Button_Remove_Click(object sender, EventArgs e)
        {
            if (DataGridView_Materials.SelectedRows == null || DataGridView_Materials.SelectedRows.Count == 0)
            {
                return;
            }

            foreach (DataGridViewRow dataGridViewRow in DataGridView_Materials.SelectedRows)
            {
                DataGridView_Materials.Rows.Remove(dataGridViewRow);

                IMaterial material = dataGridViewRow.Tag as IMaterial;
                materialLibrary.Remove(material);

            }
        }

        private void MaterialLibraryForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://github.com/HoareLea/SAM/wiki/Construction#materials");
        }
    }
}
