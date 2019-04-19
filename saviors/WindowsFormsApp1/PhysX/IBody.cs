using System.Drawing;

namespace PhysX
{
    public interface IBody
    {
        IBody Destroy();

        Vector CurrentDirection { get; }

        IPlayer Turn(double radians);

        Point Position { get; }

    }
}