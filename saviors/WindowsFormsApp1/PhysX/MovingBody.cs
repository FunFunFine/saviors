using System.Drawing;

namespace PhysX
{
    

    public class MovingBody : Body
    {
        public  Vector Velocity { get; private set; }

        public  Vector Acceleration { get; private set; }

        public  MovingBody Move()
        {
            return default;
        }

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
