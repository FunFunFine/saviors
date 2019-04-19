using System.Drawing;
using static  System.Math;
namespace PhysX
{

    public static class Constants
    {
        public static int TileSize = 10;
        public static int Gravity = 5;
        public static int JumpSpeed = 40;
        public static int HorizontalSpeed = 4;

        public static int HorizontalAcceleration = 2;
        public static Size InflateSize = new Size(2, 2);
        public static readonly int DarknessSpeed = 3;
    }

    public class MovingBody : Body
    {
        public int Tension = 1;

        public  Vector Velocity { get; private set; }

        public  Vector Acceleration { get; private set; }

        public  MovingBody Move()
        {
            Move(CurrentDirection.Normalize);
            return this;
        }


        private Vector Update(int dt)
        {
            var oldSpeed = _speed;
            _speed += Acceleration * dt;
            return (oldSpeed + _speed) / 2 * dt;

        }
        public void UpdateT(int dt)
        {
            Velocity += (Acceleration*Tension) * dt;
            Position = (Position.ToVector() + Velocity * dt).ToPoint();
        }

        public void UpdatePosition(int dt) => Move(Update(dt));

        private void Move(Vector shift)
        {
            var xAmount = Abs(shift.X);
            var yAmount = Abs(shift.Y);
            var xShift = xAmount.Equals(0) ? 0 : shift.X / xAmount;
            var yShift = yAmount.Equals(0) ? 0 : shift.Y / yAmount;
            for (var i = 0; i < xAmount; i++)
            {
                    var p = Position;
                    p.X += (int)xShift;
                    Position = p;
            }

            for (var i = 0; i < yAmount; i++)
            {
                    var p = Position;
                    p.Y += (int)yShift;
                    Position = p;
            }
        }

        private Vector _speed = Vector.Zero;
        public  Vector SpeedUp(Vector acceleration)
        {
            Acceleration += acceleration;
            return Acceleration;
        }

        public MovingBody(Point position, Size size, Vector acceleration,  Vector? direction = null) : base(position,size, direction)
        {
            Acceleration = acceleration;
        }

        public MovingBody(Point position,Size size, Vector? direction = null) : base(position, size,direction)
        {
            Acceleration = Vector.Zero;
            Velocity = Vector.Zero;
        }
    }
}
