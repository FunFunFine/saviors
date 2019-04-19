using System;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace PhysX
{
    public struct Vector
    {
        public readonly int X;
        public readonly int Y;

        public Vector(int x, int y)
        {
            Y = y;
            X = x;
        }
        public Point ToPoint() => new Point(X, Y);

        public static Vector Zero => new Vector(0, 0);

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var v = (Vector)obj;
            return Equals(v);

        }

        public override string ToString() => $"{X}, {Y}";

        private bool Equals(Vector other) => X == other.X && Y == other.Y;

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public static Vector operator /(Vector vector, int a) => new Vector(vector.X / a, vector.Y / a);

        public static Vector operator +(Vector a, Vector b) => new Vector(a.X + b.X, a.Y + b.Y);
        public static Vector operator *(Vector a, int b) => new Vector(a.X * b, a.Y * b);
        public static Vector operator *(int b, Vector a) => a * b;

    }
}
