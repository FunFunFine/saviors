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
            ImageSize = imageSize - 1;
        }


        public void Draw(Graphics graphics, IGameMap map)
        {
            foreach (var (tile, x, y) in map.Tiles.IterateDoubleArray())
            {
                graphics.DrawImageUnscaled(pictureLibrary.GetTileImage(tile),
                    new Rectangle(y * ImageSize, x * ImageSize, ImageSize, ImageSize));
            }

            foreach (var body in map.Bodies.With(map.Player))
            {
                var image = pictureLibrary.GetBodyImage(body).Rotate(body.CurrentDirection.ToAngle());
                graphics.DrawImageUnscaled(image, new Rectangle(body.Position, new Size(ImageSize, ImageSize)));
            }
        }
    }
}