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

        public Rectangle LeftScanner => new Rectangle(MainRectangle.Left - 1, MainRectangle.Top, 1, MainRectangle.Height);
        public Rectangle RightScanner => new Rectangle(MainRectangle.Right, MainRectangle.Top, 1, MainRectangle.Height);
        public Rectangle TopScanner => new Rectangle(MainRectangle.Left, MainRectangle.Top - 1, MainRectangle.Width, 1);
        public Rectangle BottomScanner => new Rectangle(MainRectangle.Left, MainRectangle.Bottom, MainRectangle.Width, 1);


        public Map Map { get; set; }

        public  IEnumerable<Vector> TilesUnderRectangle(Rectangle rectangle)
        {
            var xMax = ConvertToTiles(rectangle.Right);
            var yMax = ConvertToTiles(rectangle.Bottom);
            for (var x = ConvertToTiles(rectangle.Left); x <= xMax; x++)
                for (var y = ConvertToTiles(rectangle.Top); y <= yMax; y++)
                    yield return new Vector(x, y);
        }
        private  int ConvertToTiles(int coordinate) => coordinate / TileSize;

        public  Vector ConvertToTiles(Vector point) => new Vector(ConvertToTiles((int)point.X), ConvertToTiles((int)point.Y));
        private IEnumerable<Vector> TopIntersectedTiles => Map.Intersections(TopScanner);
        public IEnumerable<Vector> BottomIntersectedTiles => Map.Intersections(BottomScanner);
        private IEnumerable<Vector> RightIntersectedTiles => Map.Intersections(RightScanner);
        private IEnumerable<Vector> LeftIntersectedTiles => Map.Intersections(LeftScanner);

        protected IEnumerable<Vector> AllIntersectedTiles => TopIntersectedTiles.Concat(BottomIntersectedTiles)
                                                                                .Concat(RightIntersectedTiles)
                                                                                .Concat(LeftIntersectedTiles);

        private bool TopIntersection => TopIntersectedTiles.Any();
        private bool RightIntersection => RightIntersectedTiles.Any();
        private bool BottomIntersection => BottomIntersectedTiles.Any();
        private bool LeftIntersection => LeftIntersectedTiles.Any();


        public Size Size { get; }
        public int TileSize { get; }

        public Rectangle MainRectangle => new Rectangle(new Point(Position.X+Size.Width/2,Position.Y+Size.Height/2),Size);
        public void Move()
        {
            var resultVelocity = Velocity.Normalize + CurrentDirection.Normalize;
            Velocity = resultVelocity * SpeedUp;
        }

        public void Update()
        {
            //Position = (Position.ToVector() + Velocity).ToPoint();
            var shift = Velocity;
            var xAmount = Math.Abs(shift.X);
            var yAmount = Math.Abs(shift.Y);
            var xShift = xAmount == 0 ? 0 : shift.X / xAmount;
            var yShift = yAmount == 0 ? 0 : shift.Y / yAmount;
            for (var i = 0; i < xAmount; i++)
            {
                if (!(xShift > 0 ? RightIntersection : LeftIntersection))
                {
                    var p = Position;
                    p.X += (int)xShift;
                    Position = p;

                }
                else
                {
                    Velocity = new Vector(0, 0);
                    break;
                }

            }

            for (var i = 0; i < yAmount; i++)
            {
                if (!(yShift > 0 ? BottomIntersection : TopIntersection))
                {
                    var p = Position;
                    p.Y += (int)yShift;
                    Position = p;
                }
                else
                {
                    Velocity = new Vector(0, 0);
                    break;
                }
            }
        }

        public void Stop()
        {
            Velocity = Vector.Zero;
        }

        public MovingBody(Point position, Size size, Vector acceleration, int tileSize, Vector? direction = null) : base(position, size, direction)
        {
            Acceleration = acceleration;
            TileSize = tileSize;
            Size = size;
        }

        public MovingBody(Point position, Size size, Vector? direction = null, int tileSize = 0) : base(position, size, direction)
        {
            Acceleration = Vector.Zero;
            Velocity = Vector.Zero;
            Size = size;
            TileSize = tileSize;
        }
    }
}
