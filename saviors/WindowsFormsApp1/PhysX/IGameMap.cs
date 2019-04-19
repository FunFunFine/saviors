namespace PhysX
{
    public interface IGameMap
    {
        Tile[,] Tiles { get; }

        Player Player { get; }

        Body[] Bodies { get;}


    }
}