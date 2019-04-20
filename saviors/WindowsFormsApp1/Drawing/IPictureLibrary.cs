using System.Drawing;
using PhysX;

namespace Drawing
{
    public interface IPictureLibrary
    {
        Image GetTileImage(Tile tile);

        Image GetBodyImage<T>(T body)
            where T : Body;

        void SetBodyImage<T>(T body, Image image)
            where T : Body;
    }
}