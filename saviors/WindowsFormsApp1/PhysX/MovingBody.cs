using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using static System.Math;
namespace PhysX
{
    public enum State
    {
        MovingDown, Standing, MovingRight, MovingLeft, AtFloor, MovingUp
    }

    public class MovingBody: Body
    {

        public MovingBody(Point position,Size size, Map map = null) : base(position, size)
        {
            State = State.Standing;
            Map = map;
        }

        private Vector horizontalAcceleration = Vector.Zero;
        private Vector verticalAcceleration = Vector.Zero;

        private Vector Update(int dt)
        {
            var oldSpeed = Velocity;
            if (Velocity.X == 0)
                horizontalAcceleration = Vector.Zero;
            if (Velocity.Y == 0 )
                verticalAcceleration = Vector.Zero;
            Velocity += (horizontalAcceleration + verticalAcceleration) * dt;
            return (oldSpeed + Velocity) / 2 * dt;

        }

        public void Move()
        {
              acceleration = Constants.Acceleration*CurrentDirection;
              Velocity += -Constants.Speed * CurrentDirection;
        }

        private Vector acceleration = Vector.Zero;
        public void MoveUp()
        {
            if (State == State.MovingUp)
                return;
            verticalAcceleration = new Vector(0, Constants.Acceleration);
            Velocity += new Vector(0, -Constants.Speed);
        }
        public void MoveDown()
        {
            if (State == State.MovingDown)
                return;
            verticalAcceleration = new Vector(0, -Constants.Acceleration);
            Velocity += new Vector(0, Constants.Speed);
        }

        public void MoveRight()
        {
            if (State == State.MovingRight)
                return;
            horizontalAcceleration = new Vector(-Constants.Acceleration, 0);
            Velocity += new Vector(Constants.Speed, 0);

        }

        public void MoveLeft()
        {
            if (State == State.MovingLeft)
                return;
            horizontalAcceleration = new Vector(Constants.Acceleration, 0);
            Velocity += new Vector(-Constants.Speed, 0);
        }

        public void UpdatePosition(int dt) => Move(Update(dt));

        public void Move(Vector shift)
        {
//            var xAmount = Math.Abs(shift.X);
//            var yAmount = Math.Abs(shift.Y);
//            var xShift = xAmount == 0 ? 0 : shift.X / xAmount;
//            var yShift = yAmount == 0 ? 0 : shift.Y / yAmount;

            Position = (Position.ToVector() + shift).ToPoint();
            /*for (var i = 0; i < xAmount; i++)
            {
                if (!(xShift > 0 ? RightIntersection : LeftIntersection))
                {

                    State = xShift > 0 ? State.MovingRight : State.MovingLeft;
                    Position.X += xShift;

                }
                else
                {
                    Velocity = new Vector(0, Velocity.Y);
                    State = State.Standing;
                    break;
                }

            }

            for (var i = 0; i < yAmount; i++)
            {
                if (!(yShift > 0 ? BottomIntersection : TopIntersection))
                {
                    State = State.MovingDown;
                    var p = Position;
                    p.Y += (int)yShift;
                }
                else
                {
                    Velocity = new Vector(Velocity.X, 0);
                    //State = BottomIntersection ? State.Standing : State.AtFloor;
                    break;
                }
            }*/
        }

        public Vector Velocity { get; private protected set; } = Vector.Zero;

        public State State;

        protected readonly Map Map;

    }


    public static class Constants
    {
        public const int Speed = 2;
        public const int Acceleration = 2;
    }

    public class MovingBody1 : Body
    {                     
        public const int SpeedUp = 5;

        public int Tension = 1;

        public Vector Velocity { get; private set; }

        public Vector Acceleration { get; private set; }

        public void Move()
        {
            if (Velocity.Equals(Vector.Zero))
            {
                Velocity = CurrentDirection * SpeedUp;
            }
            else
            {
                var projection = SpeedUp * CurrentDirection * (CurrentDirection * Velocity);
                Velocity += projection;
            }
        }

        private Vector ApplyAcceleration()
        {
            if (Velocity.Equals(Vector.Zero))
                return Velocity;

            var acceleration = -1 * SpeedUp * 0.4 * Velocity;
            Velocity += acceleration;
            return Velocity;
        }
        public void UpdatePosition(int dt) => Move(ApplyAcceleration());

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


        public MovingBody1(Point position, Size size, Vector acceleration, Vector? direction = null) : base(position, size, direction)
        {
            Acceleration = acceleration;
        }

        public MovingBody1(Point position, Size size, Vector? direction = null) : base(position, size, direction)
        {
            Acceleration = Vector.Zero;
            Velocity = Vector.Zero;
        }
    }
}
