using System.Drawing;

namespace PhysX
{
    public static class PointExtensions
    {
        public static Vector ToVector(this Point point) => new Vector(point.X, point.Y);
    }
}