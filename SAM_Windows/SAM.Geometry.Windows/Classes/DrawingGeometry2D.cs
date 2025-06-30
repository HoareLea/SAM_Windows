using SAM.Geometry.Planar;
using System.Collections.Generic;
using System.Drawing;

namespace SAM.Geometry.Windows
{
    public class DrawingGeometry2D : IDrawingGeometry2D
    {
        private ISAMGeometry2D sAMGeometry2D;
        private Pen pen;

        public DrawingGeometry2D(DrawingGeometry2D drawingGeometry2D)
        {
            if (drawingGeometry2D != null)
            {
                sAMGeometry2D = drawingGeometry2D.sAMGeometry2D;
                pen = drawingGeometry2D.pen;
            }
        }

        public DrawingGeometry2D(Pen pen, IClosed2D closed2D)
        {
            this.pen = pen;
            sAMGeometry2D = closed2D?.Clone() as IClosed2D;
        }

        public Pen Pen
        {
            get
            {
                return pen;
            }
        }

        public IDrawingGeometry2D Clone()
        {
            return new DrawingGeometry2D(this);
        }

        public virtual bool Draw(Graphics graphics)
        {
            if(graphics == null)
            {
                return false;
            }

            if(sAMGeometry2D is ISegmentable2D)
            {
                List<Segment2D> segment2Ds = (sAMGeometry2D as ISegmentable2D).GetSegments();
                if(segment2Ds == null || segment2Ds.Count <= 1)
                {
                    return false;
                }

                foreach(Segment2D segment2D in segment2Ds)
                {
                    Point2D point2D_1 = segment2D?[0];
                    if(point2D_1 == null)
                    {
                        continue;
                    }

                    Point2D point2D_2 = segment2D?[1];
                    if (point2D_2 == null)
                    {
                        continue;
                    }

                    graphics.DrawLine(pen, point2D_1.ToDrawing(), point2D_2.ToDrawing());
                }

                return true;
            }

            return false;
        }

        public X GetSAMGeometry2D<X>() where X : ISAMGeometry2D
        {
            if(sAMGeometry2D is X)
            {
                return (X)(object)sAMGeometry2D;
            }

            return default;
        }

    }
}
