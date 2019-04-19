namespace PhysX
{
    public class GameMap : IGameMap
    {

        /// <inheritdoc />
        public Tile[,] Tiles { get; }

        /// <inheritdoc />
        public Player Player { get; }

        /// <inheritdoc />
        public Body[] Bodies { get; }

        public GameMap(Tile[,] tiles, Player player, Body[] bodies)
        {
            Tiles = tiles;
            Player = player;
            Bodies = bodies;
        }
    }
}