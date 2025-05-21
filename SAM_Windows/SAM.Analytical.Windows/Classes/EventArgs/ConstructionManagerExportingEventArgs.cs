namespace SAM.Analytical.Windows
{
    public class ConstructionManagerExportingEventArgs
    {
        public ConstructionManager ConstructionManager { get; set; } = null;
        public bool Handled { get; set; } = false;

        public ConstructionManagerExportingEventArgs()
        {

        }
    }
}
