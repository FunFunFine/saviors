using System;
using PhysX;

namespace Drawing
{
    public static class VectorExtensions
    {
        public static double ToAngle(this Vector vector) => Math.Atan2(vector.Y, vector.X) / Math.PI * 180;
    }
}