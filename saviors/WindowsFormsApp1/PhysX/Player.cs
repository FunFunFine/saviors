using System.Drawing;

namespace PhysX
{
    public class Player : MovingBody
    {
        public Player(Point position, Tile[,] tiles) : base(position, new Size(10, 10), tiles) { }

        byte Health { get; set; } 
        
    }
}