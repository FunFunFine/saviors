﻿using System.Drawing;
using static System.Math;

namespace PhysX
{
    public struct Vector
    {
        public double X { get; }
        public double Y { get; }

        public Vector(double x, double y)
        {
            Y = y;
            X = x;
        }

        public Vector Normalize => (X.Equals(0)&&Y.Equals(0))? Zero :new Vector(X / Length, Y / Length);

        public Vector Rotate(double angle) =>
            new Vector(X * Cos(angle) - Y * Sin(angle), X * Sin(angle) + Y * Cos(angle));

        public double Length => Sqrt(X * X + Y * Y);
        public Point ToPoint() => new Point((int) X, (int) Y);

        public static Vector Zero => new Vector(0, 0);

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var v = (Vector) obj;
            return Equals(v);
        }

        public override string ToString() => $"{X}, {Y}";

        private bool Equals(Vector other) => (X, Y).Equals((other.X, other.Y));

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) X * 397) ^ (int) Y;
            }
        }

        public static Vector operator /(Vector vector, int a) => new Vector(vector.X / a, vector.Y / a);

        public static Vector operator +(Vector a, Vector b) => new Vector(a.X + b.X, a.Y + b.Y);
        public static Vector operator -(Vector a, Vector b) => new Vector(a.X - b.X, a.Y - b.Y);
        public static bool operator ==(Vector a, Vector b) => a.Equals(b);

        public static bool operator !=(Vector a, Vector b) => !(a == b);

        public static double operator *(Vector a, Vector b) => a.X * b.X + a.Y * b.Y;
        public static Vector operator *(Vector a, int b) => new Vector(a.X * b, a.Y * b);
        public static Vector operator *(Vector a, double b) => new Vector(a.X * b, a.Y * b);
        public static Vector operator *(double b, Vector a) => new Vector(a.X * b, a.Y * b);
        public static Vector operator *(int b, Vector a) => a * b;
    }
}
