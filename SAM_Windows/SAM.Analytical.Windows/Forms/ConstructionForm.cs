using SAM.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SAM.Analytical.Windows.Forms
{
    public partial class ConstructionForm : Form
    {
        private MaterialLibrary materialLibrary;
        private Construction construction;

        public ConstructionForm()
        {
            InitializeComponent();
        }

        public ConstructionForm(MaterialLibrary materialLibrary, Construction construction = null)
        {
            InitializeComponent();

            this.materialLibrary = materialLibrary;
            this.construction = construction;

            if(materialLibrary == null)
            {
                Button_Add.Enabled = false;
            }
        }

        private void ConstructionForm_Load(object sender, EventArgs e)
        {
            if(construction != null)
            {
                TextBox_Name.Text = construction.Name;

                List<ConstructionLayer> constructionLayers = construction.ConstructionLayers;
                if(constructionLayers != null)
                {
                    foreach(ConstructionLayer constructionLayer in constructionLayers)
                    {
                        Add(constructionLayer.Name, constructionLayer.Thickness);
                    }
                }
            }
        }

        private bool Add(string name, double thickness)
        {
            if(name == null)
            {
                return false;
            }

            DataGridView_Layers.Rows.Add(name, thickness);
            return true;
        }

        public List<ConstructionLayer> ConstructionLayers
        {
            get
            {
                if(DataGridView_Layers?.Rows == null)
                {
                    return null;
                }

                List<ConstructionLayer> result = new List<ConstructionLayer>();
                foreach(DataGridViewRow dataGridViewRow in DataGridView_Layers.Rows)
                {
                    if(!Core.Query.TryConvert(dataGridViewRow.Cells[1].Value, out double thickness))
                    {
                        continue;
                    }

                    ConstructionLayer constructionLayer = new ConstructionLayer(dataGridViewRow.Cells[0].Value as string, thickness);
                    if(constructionLayer != null)
                    {
                        result.Add(constructionLayer);
                    }
                }

                return result;
            }
        }

        public Construction Construction
        {
            get
            {
                Construction result = null;
                if (construction != null)
                {
                    result =  new Construction(construction, ConstructionLayers);
                    result = new Construction(result, TextBox_Name.Text);
                }

                if(result == null)
                {
                    result = new Construction(TextBox_Name.Text, ConstructionLayers);
                }

                return result;
            }
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(TextBox_Name.Text))
            {
                MessageBox.Show("Provide valid name");
                return;
            }

            List<ConstructionLayer> constructionLayers = ConstructionLayers;
            if(constructionLayers == null || constructionLayers.Count == 0)
            {
                MessageBox.Show("Provide valid construction layers");
                return;
            }
            
            DialogResult = DialogResult.OK;

            Close();
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

        private void Button_Add_Click(object sender, EventArgs e)
        {
            IMaterial material = GetMaterial();
            if (material == null)
            {
                return;
            }

            if(!material.TryGetValue(MaterialParameter.DefaultThickness, out double thickness))
            {
                thickness = 0.1;
            }

            Add(material.Name, thickness);
        }

        private IMaterial GetMaterial(string name = null)
        {
            if (materialLibrary == null)
            {
                return null;
            }

            List<IMaterial> materials = materialLibrary.GetMaterials();
            materials?.Sort((x, y) => x.Name.CompareTo(y.Name));

            IMaterial result = null;
            using (Core.Windows.Forms.SearchForm<IMaterial> searchForm = new Core.Windows.Forms.SearchForm<IMaterial>("Select Material", materials, (IMaterial x) => x.Name))
            {
                searchForm.Size = new System.Drawing.Size(300, 400);
                searchForm.SearchText = name;
                if (searchForm.ShowDialog() != DialogResult.OK)
                {
                    return null;
                }

                result = searchForm.SelectedItems?.FirstOrDefault();
            }

            return result;
        }

        private void DataGridView_Layers_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_NumberOnly);
            if (DataGridView_Layers.CurrentCell.ColumnIndex == 1)
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.KeyPress += new KeyPressEventHandler(Core.Windows.EventHandler.ControlText_NumberOnly);
                }
            }
        }

        private void DataGridView_Layers_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button_Remove_Click(object sender, EventArgs e)
        {
            if(DataGridView_Layers.SelectedRows == null || DataGridView_Layers.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridView_Layers.SelectedRows.Cast<DataGridViewRow>().ToList().ForEach(x => DataGridView_Layers.Rows.Remove(x));
        }

        private void Button_Up_Click(object sender, EventArgs e)
        {
            Move(true);
        }

        private void Button_Down_Click(object sender, EventArgs e)
        {
            Move(false);
        }

        private void Move(bool up = true)
        {
            if (DataGridView_Layers.SelectedRows == null || DataGridView_Layers.SelectedRows.Count == 0)
            {
                return;
            }

            List<DataGridViewRow> dataGridViewRows = DataGridView_Layers.SelectedRows.Cast<DataGridViewRow>().ToList();
            dataGridViewRows.Sort((x, y) => y.Index.CompareTo(x.Index));

            foreach (DataGridViewRow dataGridViewRow in dataGridViewRows)
            {
                int index = dataGridViewRow.Index;

                if (up && index == 0)
                {
                    continue;
                }

                if(!up && index == DataGridView_Layers.Rows.Count - 1)
                {
                    continue;
                }

                DataGridView_Layers.Rows.RemoveAt(index);

                int index_New = up ? index - 1 : index + 1;
                DataGridView_Layers.Rows.Insert(index_New, dataGridViewRow);
            }

            DataGridView_Layers.Rows.Cast<DataGridViewRow>().ToList().ForEach(x => x.Selected = false);
            dataGridViewRows.ForEach(x => x.Selected = true);
        }

        private void DataGridView_Layers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                IMaterial material = GetMaterial();
                if (material != null)
                {
                    DataGridView_Layers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = material.Name;
                }
            }
        }

        private void DataGridView_Layers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button_Modify_Click(object sender, EventArgs e)
        {
            if(materialLibrary == null)
            {
                return;
            }
        }
    }
}
