using System.Linq;
using System.Windows.Forms;

namespace SAM.Core.Windows
{
    public static partial class Modify
    {
        public static void HidePropertyPages(this PropertyGrid propertyGrid)
        {
            ToolStripItemCollection toolStripItemCollection = propertyGrid?.Controls.OfType<ToolStrip>().FirstOrDefault()?.Items;
            if(toolStripItemCollection == null || toolStripItemCollection.Count == 0)
            {
                return;
            }
            
            if (toolStripItemCollection.Count >= 2 &&
                toolStripItemCollection[toolStripItemCollection.Count - 1] is ToolStripButton &&
                toolStripItemCollection[toolStripItemCollection.Count - 2] is ToolStripSeparator)
            {
                toolStripItemCollection[toolStripItemCollection.Count - 1].Visible = false;
                toolStripItemCollection[toolStripItemCollection.Count - 2].Visible = false;
            }
        }

    }
}