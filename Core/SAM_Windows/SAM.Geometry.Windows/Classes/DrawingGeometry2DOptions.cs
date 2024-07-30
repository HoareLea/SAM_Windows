namespace SAM.Geometry.Windows
{
    public class DrawingGeometry2DOptions
    {
        public bool ZoomToFit { get; set; }
        public int Offset { get; set; }

        public DrawingGeometry2DOptions()
        {
            ZoomToFit = false;
            Offset = 10;
        }

        public DrawingGeometry2DOptions(bool zoomToFit, int offset)
        {
            ZoomToFit = zoomToFit;
            Offset = offset;
        }
    }
}
