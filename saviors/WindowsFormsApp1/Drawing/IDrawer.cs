using System.Drawing;
using PhysX;

namespace Drawing
{
    public interface IDrawer
    {
        int ImageSize { get; }

        void Draw(Graphics graphics, IGameMap map);
    }
}