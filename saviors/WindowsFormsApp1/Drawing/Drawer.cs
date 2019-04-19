using System;
using System.Drawing;
using PhysX;

namespace Drawing
{
    public class Drawer : IDrawer
    {
        private readonly IPictureLibrary pictureLibrary;
        private readonly int imageSize;

        public Drawer(IPictureLibrary pictureLibrary, int imageSize)
        {
            this.pictureLibrary = pictureLibrary;
            this.imageSize = imageSize;
        }

        public void Draw(Graphics graphics, IGameMap map)
        {
            foreach (var (tile, x, y) in map.Tiles.IterateDoubleArray())
            {
                graphics.DrawImage(pictureLibrary.GetTileImage(tile),
                    new Rectangle(y * imageSize, x * imageSize, imageSize, imageSize));
            }

            foreach (var body in map.Bodies.With(map.Player))
            {
                Console.WriteLine($"{body.Position}, {body.Size}");
                var image = pictureLibrary.GetBodyImage(body).Rotate(body.CurrentDirection.ToAngle());
                graphics.DrawImage(image, new Rectangle(body.Position, new Size(imageSize, imageSize)));
            }
        }
    }
}