namespace PhysX
{
    public class Player : MovingBody
    {
        public Player(System.Drawing.Point position, Vector acceleration, Vector velocity, Vector? direction = null) : base(position, acceleration, velocity, direction)
        {
        }

        byte Health { get; set; } 
        
    }
}