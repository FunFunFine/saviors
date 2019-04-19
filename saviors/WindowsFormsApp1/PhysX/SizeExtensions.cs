using System.Drawing;

namespace PhysX
{
    public static class SizeExtensions
    {
        public static Vector ToVector(this Size point) => new Vector(point.Width, point.Height);
    }
}