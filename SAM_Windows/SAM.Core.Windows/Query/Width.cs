using System.Drawing;

namespace SAM.Core.Windows
{
    public static partial class Query
    {
        public static double Width(this string text, Font font, double height)
        {
            if (text == null || font == null || double.IsNaN(height) || height <= 0)
            {
                return double.NaN;
            }

            Size size = Size(text, font);
            if(size == null)
            {
                return double.NaN;
            }

            double factor = height / size.Height;

            return size.Width * factor;
        }
    }
}