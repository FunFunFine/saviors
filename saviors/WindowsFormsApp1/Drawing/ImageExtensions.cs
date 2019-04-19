using System.Drawing;
using System.Drawing.Drawing2D;

namespace Drawing
{
    public static class ImageExtensions
    {
        public static Image Rotate(this Image image, double angle)
        {
            var bmp = new Bitmap(image.Width, image.Height);

            using (var graphics = Graphics.FromImage(bmp))
            {
                var halfWidth = (float) bmp.Width / 2;
                var halfHeight = (float) bmp.Height / 2;

                graphics.TranslateTransform(halfWidth, halfHeight);

                graphics.RotateTransform((float) angle);

                graphics.TranslateTransform(-halfWidth, -halfHeight);

                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                graphics.DrawImage(image, new Point(0, 0));
            }

            return bmp;
        }
    }
}