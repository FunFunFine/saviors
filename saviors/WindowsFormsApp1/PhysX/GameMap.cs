namespace PhysX
{
    class GameMap : IGameMap
    {
        public Tile[,] Tiles { get; }

        public IPlayer Player { get; }

        public IBody[] Bodies { get; }

        public GameMap(Tile[,] tiles, IPlayer player, IBody[] bodies)
        {
            Tiles = tiles;
            Player = player;
            Bodies = bodies;
        }
    }
}