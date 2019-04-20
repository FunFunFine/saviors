using System;
using System.Drawing;
using PhysX;

namespace Drawing
{
    public class Drawer : IDrawer
    {
        private readonly IPictureLibrary pictureLibrary;
        private Point start = new Point(0, 0);
        private int currentShaking = 0;

        private Point[] shaking =
        {
            new Point(4, 0),
            new Point(3, 3),
            new Point(0, 4),
            new Point(-3, 3),
            new Point(-4, 0),
            new Point(-3, -3),
            new Point(0, -4),
            new Point(3, -3), 
            //new Point(0, 2),

            //new Point(1, 3),
            //new Point(2, 4),

            //new Point(4, 4),

            //new Point(5, 3),
            //new Point(6, 2),

            //new Point(6, 0),

            //new Point(5,-1),
            //new Point(4,-2),

            //new Point(2,-2),

            //new Point(1,-1),
            //new Point(0, 0),
        };

        public int ImageSize { get; }

        public Drawer(IPictureLibrary pictureLibrary, int imageSize)
        {
            this.pictureLibrary = pictureLibrary;
            ImageSize = imageSize - 1;
        }

        public void Draw(Graphics graphics, IGameMap map)
        {
            var size = graphics.ClipBounds.Size;
            start = new Point((int) size.Width / 2, (int) size.Height / 2) - (Size) map.Player.Position
                + new Size(shaking[currentShaking].X * 1, shaking[currentShaking].Y * 1);
            currentShaking = (currentShaking + 1) % shaking.Length;

            foreach (var (tile, x, y) in map.Tiles.IterateDoubleArray())
            {
                graphics.DrawImage(pictureLibrary.GetTileImage(tile),
                    new Rectangle(start.Y + y * ImageSize, start.X + x * ImageSize, ImageSize, ImageSize));
            }

            var image = pictureLibrary.GetBodyImage(map.Player).Rotate(-map.Player.CurrentDirection.ToAngle());
            graphics.DrawImage(image,
                new Rectangle(start + (Size) map.Player.Position - new Size(ImageSize, ImageSize), 
                    new Size(ImageSize * 2, ImageSize * 2)));

            foreach (var body in map.Bodies)
            {
                var bodyImage = pictureLibrary.GetBodyImage(body).Rotate(body.CurrentDirection.ToAngle());
                graphics.DrawImage(bodyImage, new Rectangle(start + (Size) body.Position, new Size(ImageSize, ImageSize)));
            }
        }

        public void SetImage<T>(T body, Image image)
            where T : Body
        {
            pictureLibrary.SetBodyImage(body, image);
        }
    }
}