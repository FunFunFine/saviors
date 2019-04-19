using System.Drawing;
using PhysX;

namespace Drawing
{
    public class Drawer : IDrawer
    {
        private readonly IPictureLibrary pictureLibrary;

        public Drawer(IPictureLibrary pictureLibrary)
        {
            this.pictureLibrary = pictureLibrary;
        }

        public void Draw(Graphics graphics, IGameMap map)
        {
            foreach (var (tile, x, y) in map.Tiles.IterateDoubleArray())
                graphics.DrawImage(pictureLibrary.GetTileImage(tile), new Point(x, y));

            foreach (var body in map.Bodies.With(map.Player))
            {
                var image = pictureLibrary.GetBodyImage(body).Rotate(body.CurrentDirection.ToAngle());
                graphics.DrawImage(image, body.Position);
            }
        }
    }
}
