using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            using (Forms.SearchForm<IMaterial> searchForm = new Forms.SearchForm<IMaterial>("Select Material", materials, (IMaterial x) => x.Name))
            {
                searchForm.Size = new Size(300, 400);
                searchForm.SearchText = name;
                if (searchForm.ShowDialog() != DialogResult.OK)
                {
                    return null;
                }

                result = searchForm.SelectedItems?.FirstOrDefault();
            }

            return result;
        }
    }
}