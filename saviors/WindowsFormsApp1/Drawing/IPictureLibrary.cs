using System.Drawing;
using PhysX;

namespace Drawing
{
    public interface IPictureLibrary
    {
        Image GetTileImage(Tile tile);

        Image GetBodyImage<T>(T body)
            where T : IBody;
    }
}