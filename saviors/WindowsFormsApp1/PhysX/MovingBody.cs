using System.Drawing;

namespace PhysX
{
    

    public class MovingBody : Body
    {
        public  Vector Velocity { get; private set; }

        public  Vector Acceleration { get; private set; }

        public  MovingBody Move()
        {
            var velocity = 
        }

        public  Vector SpeedUp(Vector acceleration)
        {
            Acceleration += acceleration;
            return Acceleration;
        }

        public MovingBody(Point position, Vector acceleration,  Vector? direction = null) : base(position, direction)
        {
            Acceleration = acceleration;
            Velocity = velocity;
        }

        public MovingBody(Point position, Vector? direction = null) : base(position, direction)
        {
            Acceleration = Vector.Zero;
            Velocity = Vector.Zero;
        }
    }
}
