namespace PhysX
{
    public interface IMovingBody: IBody
    {
        IPlayer Move();

        Vector Velocity { get; }

        Vector Acceleration { get; }

        Vector SpeedUp(Vector dv);

    }
}