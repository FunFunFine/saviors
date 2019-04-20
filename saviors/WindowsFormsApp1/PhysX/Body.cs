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

        public  Vector CurrentDirection { get; private set; }

        public virtual Body Turn(double radians)
        {
            CurrentDirection = CurrentDirection.Rotate(radians);
            return this;
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