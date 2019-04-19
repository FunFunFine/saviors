namespace PhysX
{
    public interface IGameMap
    {
        Tile[,] Tiles { get; }

        IPlayer Player { get; }

        IBody[] Bodies { get;}


    }
}