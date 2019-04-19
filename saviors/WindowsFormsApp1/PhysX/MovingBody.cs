using System.Drawing;

namespace PhysX
{
    

    public class MovingBody : Body
    {
        public int Tension = 1;

        public  Vector Velocity { get; private set; }

        public  Vector Acceleration { get; private set; }

        public  MovingBody Move()
        {
            var velocity = CurrentDirection;
            SpeedUp(velocity.Normalize);
            return this;
        }

        public void Update(int dt)
        {
            Velocity += (Acceleration*Tension) * dt;
            Position = (Position.ToVector() + Velocity * dt).ToPoint();
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
