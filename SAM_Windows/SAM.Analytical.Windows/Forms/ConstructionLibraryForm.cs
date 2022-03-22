using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAM.Analytical.Windows.Forms
{
    public partial class ConstructionLibraryForm : Form
    {
        private ConstructionLibrary constructionLibrary;

        public ConstructionLibraryForm()
        {
            InitializeComponent();
        }

        public ConstructionLibraryForm(ConstructionLibrary constructionLibrary)
        {
            InitializeComponent();

            this.constructionLibrary = constructionLibrary;
        }

        private void ConstructionLibraryForm_Load(object sender, EventArgs e)
        {

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
    }
}
