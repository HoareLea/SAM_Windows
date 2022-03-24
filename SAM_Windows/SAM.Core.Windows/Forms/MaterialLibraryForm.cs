using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SAM.Core.Windows.Forms
{
    public partial class MaterialLibraryForm : Form
    {
        private MaterialLibrary materialLibrary;

        private IMaterial material_Selected;

        public MaterialLibraryForm()
        {
            InitializeComponent();
        }

        public MaterialLibraryForm(MaterialLibrary materialLibrary, IMaterial material_Selected = null)
        {
            InitializeComponent();

            this.materialLibrary = materialLibrary;
            this.material_Selected = material_Selected;
        }

        private void MaterialLibraryForm_Load(object sender, EventArgs e)
        {

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

            return DataGridView_Materials.Rows[index];
        }
    }
}
