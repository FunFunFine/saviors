using System.Drawing;
using System.Runtime.Remoting.Messaging;

namespace PhysX
{

    public class Body 
    {
        public Body(Point position, Vector? direction = null)
        {
            Position = position;
            CurrentDirection = direction ?? new Vector(0,-1);
        }
        public virtual Body Destroy() => new Trash(Position, CurrentDirection);

        public  Vector CurrentDirection { get; }

        public  Body Turn(double radians)
        {
            return new Body(Position,CurrentDirection.Rotate(radians));
        }

        public  Point Position { get; private set; }
    }

    public class Trash : Body
    {
        public Trash(Point position, Vector? direction = null) : base(position, direction)
        {
        }

        public override Body Destroy() => this;
    }

}