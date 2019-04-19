using System;
using System.Drawing;
using PhysX;

namespace Drawing
{
    public class Drawer : IDrawer
    {
        private readonly IPictureLibrary pictureLibrary;

        public int ImageSize { get; }

        public Drawer(IPictureLibrary pictureLibrary, int imageSize)
        {
            this.pictureLibrary = pictureLibrary;
            ImageSize = imageSize;
        }


        public void Draw(Graphics graphics, IGameMap map)
        {
            foreach (var (tile, x, y) in map.Tiles.IterateDoubleArray())
            {
                graphics.DrawImage(pictureLibrary.GetTileImage(tile),
                    new Rectangle(y * ImageSize, x * ImageSize, ImageSize, ImageSize));
            }

            foreach (var body in map.Bodies.With(map.Player))
            {
                Console.WriteLine($"{body.Position} {body.CurrentDirection.ToAngle()}");
                var image = pictureLibrary.GetBodyImage(body).Rotate(body.CurrentDirection.ToAngle());
                graphics.DrawImage(image, new Rectangle(body.Position, new Size(ImageSize, ImageSize)));
                graphics.DrawImage(image.Rotate(Math.PI / 2), new Rectangle(body.Position + new Size(20, 20), new Size(ImageSize, ImageSize)));
            }
        }
    }
}