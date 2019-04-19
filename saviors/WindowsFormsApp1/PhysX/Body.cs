using System.Drawing;
using System.Runtime.Remoting.Messaging;

namespace PhysX
{

    public class Body 
    {
        public virtual Size Size { get; private set; }

        public Body(Point position, Size size, Vector? direction = null)
        {
            Position = position;
            Size = size;
            CurrentDirection = (direction ?? new Vector(0,-1)).Normalize;
        }
        public virtual Body Destroy() => new Trash(Position, Size,CurrentDirection);

        public  Vector CurrentDirection { get; }

        public  Body Turn(double radians)
        {
            return new Body(Position,new Size(10,10),CurrentDirection.Rotate(radians));
        }

        public  Point Position { get; private protected set; }
    }

    public class Trash : Body
    {
        public Trash(Point position, Size size,Vector? direction = null) : base(position,size,  direction)
        {
        }

        public override Body Destroy() => this;
    }

}