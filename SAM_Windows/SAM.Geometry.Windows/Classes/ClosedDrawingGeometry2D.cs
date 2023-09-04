using SAM.Geometry.Planar;
using System.Collections.Generic;
using System.Drawing;

namespace SAM.Geometry.Windows
{
    public class ClosedDrawingGeometry2D : DrawingGeometry2D
    {
        private Brush brush;

        public ClosedDrawingGeometry2D(Pen pen, Brush brush, IClosed2D closed2D)
            : base(pen, closed2D)
        {
            this.brush = brush;
        }

        public Brush Brush
        {
            get
            {
                return brush;
            }
        }

        public override bool Draw(Graphics graphics)
        {
            bool result = base.Draw(graphics);
            if (!result)
            {
                return result;
            }

            ISAMGeometry2D sAMGeometry2D = GetSAMGeometry2D<ISAMGeometry2D>();

            if (sAMGeometry2D is ISegmentable2D)
            {
                List<Point2D> point2Ds = (sAMGeometry2D as ISegmentable2D).GetPoints();
                if (point2Ds == null || point2Ds.Count <= 1)
                {
                    return false;
                }

                List<PointF> pointFs = new List<PointF>();
                foreach (Point2D point2D in point2Ds)
                {
                    if(point2D == null)
                    {
                        continue;
                    }

                    pointFs.Add(point2D.ToDrawing());
                }

                if(pointFs != null && pointFs.Count != 0)
                {
                    graphics.FillPolygon(brush, pointFs.ToArray());
                    return true;
                }
            }

            return false;
        }
    }
}
