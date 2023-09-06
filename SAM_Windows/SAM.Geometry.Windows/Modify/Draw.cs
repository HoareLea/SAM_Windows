using SAM.Geometry.Planar;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SAM.Geometry.Windows
{
    public static partial class Modify
    {
        public static void Draw<T>(this PictureBox pictureBox, IEnumerable<T> drawingGeometry2Ds, DrawingGeometry2DOptions drawingGeometry2DOptions = null) where T : IDrawingGeometry2D
        {
            if (drawingGeometry2Ds == null || pictureBox == null)
            {
                return;
            }

            DrawingGeometry2DOptions drawingObjectUIDrawOptions_Temp = drawingGeometry2DOptions;
            if (drawingObjectUIDrawOptions_Temp == null)
            {
                drawingObjectUIDrawOptions_Temp = new DrawingGeometry2DOptions();
            }

            if (pictureBox.Image != null)
            {
                pictureBox.Image.Dispose();
            }

            List<T> drawingGeometry2Ds_Temp = new List<T>(drawingGeometry2Ds);

            if (drawingObjectUIDrawOptions_Temp.ZoomToFit)
            {
                int width = pictureBox.Width;
                int height = pictureBox.Height;

                BoundingBox2D boundingBox2D = null;
                foreach (T drawingGeometry2D in drawingGeometry2Ds)
                {
                    ISAMGeometry2D sAMGeometry2D = drawingGeometry2D.GetSAMGeometry2D<ISAMGeometry2D>();
                    if (sAMGeometry2D is IBoundable2D)
                    {
                        BoundingBox2D boundingBox2D_Temp = ((IBoundable2D)sAMGeometry2D).GetBoundingBox();
                        if (boundingBox2D == null)
                            boundingBox2D = boundingBox2D_Temp;
                        else
                            boundingBox2D.Include(boundingBox2D_Temp);
                    }
                }

                if (boundingBox2D != null)
                {
                    Point2D point2D_Centroid_PictureBox = new Point2D(width / 2, height / 2);
                    Point2D point2D_Centroid_BoundingBox = boundingBox2D.GetCentroid();

                    Vector2D vector2D = new Vector2D(point2D_Centroid_BoundingBox, point2D_Centroid_PictureBox);

                    double factor_Width = (width - drawingObjectUIDrawOptions_Temp.Offset) / boundingBox2D.Width;
                    double factor_Height = (height - drawingObjectUIDrawOptions_Temp.Offset) / boundingBox2D.Height;
                    double factor = System.Math.Min(factor_Height, factor_Width);

                    for (int i = 0; i < drawingGeometry2Ds_Temp.Count; i++)
                    {
                        ISAMGeometry2D sAMGeometry2D = drawingGeometry2Ds_Temp[i].GetSAMGeometry2D<ISAMGeometry2D>();

                        if (sAMGeometry2D is IBoundable2D)
                        {
                            IBoundable2D boundable2D = (IBoundable2D)sAMGeometry2D.Clone();
                            boundable2D = boundable2D.Scale(point2D_Centroid_BoundingBox, factor) as IBoundable2D;
                            boundable2D = boundable2D.Move(vector2D);

                            if(drawingGeometry2Ds_Temp[i] is ClosedDrawingGeometry2D)
                            {
                                ClosedDrawingGeometry2D closedDrawingGeometry2D = (ClosedDrawingGeometry2D)(object)drawingGeometry2Ds_Temp[i];

                                drawingGeometry2Ds_Temp[i] = (T)(object)(new ClosedDrawingGeometry2D(closedDrawingGeometry2D.Pen, closedDrawingGeometry2D.Brush, (IClosed2D)(object)boundable2D));
                            }
                            else if(drawingGeometry2Ds_Temp[i] is DrawingGeometry2D)
                            {
                                DrawingGeometry2D drawingGeometry2D = (DrawingGeometry2D)(object)drawingGeometry2Ds_Temp[i];

                                drawingGeometry2Ds_Temp[i] = (T)(object)(new DrawingGeometry2D(drawingGeometry2D.Pen, (IClosed2D)(object)boundable2D));
                            }
                        }
                    }
                }
            }

            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(pictureBox.Width, pictureBox.Size.Height);
            System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap);

            foreach (T drawingGeometry2D in drawingGeometry2Ds_Temp)
            {
                drawingGeometry2D.Draw(graphics);
            }


            graphics.Dispose();

            pictureBox.Image = bitmap;
        }
    }
}