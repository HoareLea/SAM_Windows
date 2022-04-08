using SAM.Core.Windows.Forms;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SAM.Core.Windows
{
    public static partial class Create
    {
        public static IMaterial Material(IWin32Window owner = null)
        {
            IMaterial result = null;

            using (ComboBoxForm<MaterialType> comboBoxForm = new ComboBoxForm<MaterialType>("Select Material Type", Enum.GetValues(typeof(MaterialType)).Cast<MaterialType>().ToList().FindAll(x => x != MaterialType.Undefined)))
            {
                DialogResult dialogResult = comboBoxForm.ShowDialog(owner);
                if (dialogResult != DialogResult.OK)
                {
                    return null;
                }

                switch (comboBoxForm.SelectedItem)
                {
                    case MaterialType.Gas:
                        result = new GasMaterial(Guid.NewGuid(), "Gas Material", "Gas Material", null, 0, 0, 0, 0);
                        break;

                    case MaterialType.Opaque:
                        result = new OpaqueMaterial("Opaque Material", null, "Opaque Material", null, 0, 0, 0);
                        break;

                    case MaterialType.Transparent:
                        result = new TransparentMaterial("Opaque Material", null, "Opaque Material", null, 0, 0, 0);
                        break;
                }
            }

            return result;
        }
    }
}
