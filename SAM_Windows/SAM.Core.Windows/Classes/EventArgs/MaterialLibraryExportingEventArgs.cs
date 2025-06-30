namespace SAM.Core.Windows
{
    public class MaterialLibraryExportingEventArgs
    {
        public MaterialLibrary MaterialLibrary { get; set; } = null;
        public bool Handled { get; set; } = false;

        public MaterialLibraryExportingEventArgs()
        {

        }
    }
}
