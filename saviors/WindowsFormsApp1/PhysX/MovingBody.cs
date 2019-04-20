using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using static System.Math;
namespace PhysX
{
    public enum State
    {
        MovingDown, Standing, MovingRight, MovingLeft, AtFloor, MovingUp, Moving
    }

    
    public class MovingBody : Body
    {
        public const int SpeedUp = 5;

        public int Tension = 1;

        public Vector Velocity { get; private set; }

        public Vector Acceleration { get; private set; }

        /// <inheritdoc />
        public override Body Turn(double radians)
        {
            base.Turn(radians);
            Velocity = Velocity.Rotate(radians);
            return this ;
        }

        public void Move()
        {
            var resultVelocity = Velocity.Normalize + CurrentDirection.Normalize;
            Acceleration = -1 * resultVelocity * SpeedUp/3 ;
            Velocity = resultVelocity * SpeedUp;
        }

        public void Update()
        {
            Position = (Position.ToVector() + Velocity).ToPoint();
        }
        


        public MovingBody(Point position, Size size, Vector acceleration, Vector? direction = null) : base(position, size, direction)
        {
            Acceleration = acceleration;
        }

        public MovingBody(Point position, Size size, Vector? direction = null) : base(position, size, direction)
        {
            Acceleration = Vector.Zero;
            Velocity = Vector.Zero;
        }
    }
}
