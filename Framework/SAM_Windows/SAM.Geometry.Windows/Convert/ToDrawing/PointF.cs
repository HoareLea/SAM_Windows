using SAM.Geometry.Planar;
using System.Drawing;

namespace SAM.Geometry.Windows
{
    public static partial class Convert
    {
        public static PointF ToDrawing(this Point2D point2D)
        {
            if (point2D == null)
            {
                return PointF.Empty;
            }

            return new PointF(System.Convert.ToSingle(point2D.X), System.Convert.ToSingle(point2D.Y));
        }
    }
}