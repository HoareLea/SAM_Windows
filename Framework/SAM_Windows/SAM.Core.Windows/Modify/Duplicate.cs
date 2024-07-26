using SAM.Core.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SAM.Core.Windows
{
    public static partial class Modify
    {
        public static IMaterial Duplicate(this MaterialLibrary materialLibrary, IMaterial material, IWin32Window owner = null, IEnumerable<Enum> enums = null)
        {
            if(materialLibrary == null || material == null)
            {
                return null;
            }

            string name = (string.IsNullOrWhiteSpace(material.Name) ? string.Empty : material.Name).Trim();
            string name_Temp = name;
            int index = 1;
            while (materialLibrary?.GetMaterials()?.Find(x => x.Name == name_Temp) != null)
            {
                name_Temp = string.Format("{0} {1}", name, index.ToString());
                index++;
            }
            name = name_Temp;

            material = Core.Create.Material(material as Material, name, name, null);
            if (material == null)
            {
                MessageBox.Show("Material cannot be duplicated");
                return null;
            }

            using (MaterialForm materialForm = new MaterialForm(material, enums))
            {
                if (materialForm.ShowDialog(owner) != DialogResult.OK)
                {
                    return null;
                }

                material = materialForm.Material;
            }

            if (material == null)
            {
                return null;
            }

            materialLibrary?.Add(material);

            return material;
        }

    }
}