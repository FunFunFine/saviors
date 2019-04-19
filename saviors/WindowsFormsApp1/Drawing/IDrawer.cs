using System.Drawing;
using PhysX;

namespace Drawing
{
    public interface IDrawer
    {
        void Draw(Graphics graphics, IGameMap map);
    }
}