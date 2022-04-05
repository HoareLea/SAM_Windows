using SAM.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAM.Architectural.Windows
{
    public partial class MaterialLayersControl : UserControl
    {
        private MaterialLibrary materialLibrary;

        public MaterialLayersControl()
        {
            InitializeComponent();
        }

        public MaterialLayersControl(MaterialLibrary materialLibrary)
        {
            InitializeComponent();

            this.materialLibrary = materialLibrary;
        }

        private void MaterialLayersControl_Load(object sender, EventArgs e)
        {
            if (materialLibrary == null)
            {
                Button_Add.Enabled = false;
            }
        }

        private void Button_Up_Click(object sender, EventArgs e)
        {
            Move(true);
        }

        private void Button_Down_Click(object sender, EventArgs e)
        {
            Move(false);
        }

        private void Button_Add_Click(object sender, EventArgs e)
        {
            IMaterial material = Core.Windows.Query.Material(materialLibrary);
            if (material == null)
            {
                return;
            }

            if (!material.TryGetValue(MaterialParameter.DefaultThickness, out double thickness) || double.IsNaN(thickness) || thickness <= 0)
            {
                thickness = 0.1;
            }

            Add(material.Name, thickness);
        }

        private void Button_Remove_Click(object sender, EventArgs e)
        {
            if (DataGridView_Layers.SelectedRows == null || DataGridView_Layers.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridView_Layers.SelectedRows.Cast<DataGridViewRow>().ToList().ForEach(x => DataGridView_Layers.Rows.Remove(x));
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

        private void DataGridView_Layers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                IMaterial material = Core.Windows.Query.Material(materialLibrary);
                if (material != null)
                {
                    DataGridView_Layers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = material.Name;
                }
            }
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

                if (!up && index == DataGridView_Layers.Rows.Count - 1)
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

        private bool Add(string name, double thickness)
        {
            if (name == null)
            {
                return false;
            }

            DataGridView_Layers.Rows.Add(name, thickness);
            return true;
        }

        public bool Enabled
        {
            set
            {
                DataGridView_Layers.CellDoubleClick -= new DataGridViewCellEventHandler(DataGridView_Layers_CellDoubleClick);

                if (value)
                {
                    Button_Add.Visible = true;
                    Button_Remove.Visible = true;
                    Button_Up.Enabled = true;
                    Button_Down.Enabled = true;
                    DataGridView_Layers.ReadOnly = false;
                    DataGridView_Layers.CellDoubleClick += new DataGridViewCellEventHandler(DataGridView_Layers_CellDoubleClick);

                }
                else
                {
                    Button_Add.Visible = false;
                    Button_Remove.Visible = false;
                    Button_Up.Enabled = false;
                    Button_Down.Enabled = false;
                    DataGridView_Layers.ReadOnly = true;
                }
            }
        }

        public List<MaterialLayer> MaterialLayers
        {
            get
            {
                if(DataGridView_Layers?.Rows == null)
                {
                    return null;
                }

                List<MaterialLayer> result = new List<MaterialLayer>();
                foreach(DataGridViewRow dataGridViewRow in DataGridView_Layers.Rows)
                {
                    if (!Core.Query.TryConvert(dataGridViewRow.Cells[1].Value, out double thickness))
                    {
                        continue;
                    }

                    MaterialLayer materialLayer = new MaterialLayer(dataGridViewRow.Cells[0].Value as string, thickness);
                    if (materialLayer != null)
                    {
                        result.Add(materialLayer);
                    }
                }

                return result;
            }

            set
            {
                DataGridView_Layers.Rows.Clear();

                if(value != null)
                {
                    foreach (MaterialLayer materialLayer in value)
                    {
                        Add(materialLayer.Name, materialLayer.Thickness);
                    }
                }
            }
        }

    }
}
