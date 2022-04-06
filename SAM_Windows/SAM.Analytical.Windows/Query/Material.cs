using SAM.Architectural;
using System.Collections.Generic;

namespace SAM.Analytical.Windows
{
    public static partial class Query
    {
        public static List<ConstructionLayer> ConstructionLayers(this Architectural.Windows.MaterialLayersControl materialLayersControl)
        {
            List<MaterialLayer> materialLayers = materialLayersControl?.MaterialLayers;
            if(materialLayers == null)
            {
                return null;
            }

            List<ConstructionLayer> result = new List<ConstructionLayer>();
            foreach(MaterialLayer materialLayer in materialLayers)
            {
                ConstructionLayer constructionLayer = new ConstructionLayer(materialLayer.Name, materialLayer.Thickness);
                result.Add(constructionLayer);
            }

            return result;
        }
    }
}