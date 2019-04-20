using System.Drawing;

namespace PhysX
{
    public class Player : MovingBody
    {
        public Player(System.Drawing.Point position, Vector acceleration, Vector velocity, Vector? direction = null) : base(position, new Size(10, 10))
        {
        }

        public Player(Point position) : base(position, new Size(10, 10)) { }

        byte Health { get; set; }
    }
}