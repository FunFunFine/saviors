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
        private readonly Tile[,] tiles;

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
            var newPosition = (Position.ToVector() + Velocity).ToPoint();
            //tiles[newPosition.X / 64, newPosition.Y / 64] = Tile.Bottles;
            if (tiles[newPosition.X / 64, newPosition.Y / 64] == Tile.Wall)
            {
                return;
            }
            Position = newPosition;
        }
        


        public MovingBody(Point position, Size size, Vector acceleration, Vector? direction = null) : base(position, size, direction)
        {
            Acceleration = acceleration;
        }

        public MovingBody(Point position, Size size, Tile[,] tiles, Vector? direction = null) : base(position, size, direction)
        {
            Acceleration = Vector.Zero;
            Velocity = Vector.Zero;
            this.tiles = tiles;
        }
    }
}
