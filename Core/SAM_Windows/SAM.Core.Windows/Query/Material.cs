using System.Collections.Generic;
using System.Windows.Forms;

namespace SAM.Core.Windows
{
    public static partial class Query
    {
        public static IMaterial Material(this MaterialLibrary materialLibrary, string name = null)
        {
            if (materialLibrary == null)
            {
                return null;
            }

            List<IMaterial> materials = materialLibrary.GetMaterials();
            materials?.Sort((x, y) => x.Name.CompareTo(y.Name));

            IMaterial result = null;
            using (Forms.SelectMaterialForm selectMaterialForm = new Forms.SelectMaterialForm(materials, Core.Query.Enums(typeof(IMaterial))))
            {
                //selectMaterialForm.Size = new Size(300, 400);
                selectMaterialForm.SearchText = name;
                if (selectMaterialForm.ShowDialog() != DialogResult.OK)
                {
                    return null;
                }

                result = selectMaterialForm.Material;
            }

            return result;
        }
    }
}