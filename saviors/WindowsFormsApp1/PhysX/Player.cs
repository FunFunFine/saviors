using System.Drawing;

namespace PhysX
{
    public class Player : MovingBody
    {
        public Player(Point position, Tile[,] tiles) : base(position, new Size(10, 10), tiles) { }

        public double Health { get; set; } = 100;

        public override bool Update()
        {
            var result = base.Update();
            if (!result && Velocity.Length > 9)
            {
                Health -= 1 * Velocity.Length;
                Velocity = Vector.Zero;
                isLying = true;
            }
            return result;
        }
    }
}