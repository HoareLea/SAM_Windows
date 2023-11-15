using SAM.Core;

namespace SAM.Core.Windows
{
    public class MaterialLibraryImportingEventArgs
    {
        public MaterialLibrary MaterialLibrary { get; set; } = null;
        public bool Handled { get; set; } = false;

        public MaterialLibraryImportingEventArgs()
        {

        }
    }
}
