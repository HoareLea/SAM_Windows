namespace SAM.Analytical.Windows
{
    public class ConstructionManagerImportingEventArgs
    {
        public ConstructionManager ConstructionManager { get; set; } = null;
        public bool Handled { get; set; } = false;

        public ConstructionManagerImportingEventArgs()
        {

        }
    }
}
