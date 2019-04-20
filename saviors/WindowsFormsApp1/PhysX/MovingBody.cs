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

        public Vector Velocity { get; set; }

        public Vector Acceleration { get; set; }

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

        public virtual bool Update()
        {
            var width = tiles.GetLength(0);
            var height = tiles.GetLength(1);
            var newPosition = (Position.ToVector() + Velocity).ToPoint();
            var x = newPosition.X / 64;
            var y = newPosition.Y / 64;
            Console.WriteLine($"{x}, {y}, {width}, {height}");
            if (x < 1 || y < 1 || x >= width - 1 || y >= height - 1 || tiles[x, y] == Tile.Wall)
            {
                return false;
            }
            Position = newPosition;
            return true;
        }

        public MovingBody(Point position, Size size, Tile[,] tiles, Vector? direction = null) : base(position, size, direction)
        {
            Acceleration = Vector.Zero;
            Velocity = Vector.Zero;
            this.tiles = tiles;
        }
    }
}
