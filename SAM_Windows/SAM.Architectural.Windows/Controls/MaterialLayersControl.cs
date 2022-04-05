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
        private List<MaterialLayer> materialLayers;

        public MaterialLayersControl()
        {
            InitializeComponent();
        }

        public MaterialLayersControl(MaterialLibrary materialLibrary, IEnumerable<MaterialLayer> materialLayers = null)
        {
            InitializeComponent();

            this.materialLibrary = materialLibrary;
            if(materialLayers != null)
            {
                this.materialLayers = new List<MaterialLayer>(materialLayers);
            }
        }

        public List<MaterialLayer> MaterialLayers
        {
            get
            {
                return null;
            }
        }
    }
}
