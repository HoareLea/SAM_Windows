using System;
using System.Windows.Forms;

namespace SAM.Core.Windows.Forms
{
    public partial class MaterialForm : Form
    {
        private IMaterial material;

        public MaterialForm()
        {
            InitializeComponent();
        }

        public MaterialForm(Material material)
        {

        }

        private void MaterialForm_Load(object sender, EventArgs e)
        {
            
            
            //PropertyGrid_Parameters.SelectedObject 
        }
    }
}
