using SAM.Geometry.Planar;
using System.Drawing;

namespace SAM.Geometry.Windows
{
    public interface IDrawingGeometry2D
    {
        Pen Pen { get; }

        bool Draw(Graphics graphics);

        T GetSAMGeometry2D<T>() where T : ISAMGeometry2D;

        IDrawingGeometry2D Clone();
    }
}
