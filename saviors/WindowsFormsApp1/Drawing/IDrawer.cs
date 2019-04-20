using System.Drawing;
using PhysX;

namespace Drawing
{
    public interface IDrawer
    {
        void Draw(Graphics graphics, IGameMap map);

        void SetImage<T>(T body, Image image)
            where T : Body;
    }
}