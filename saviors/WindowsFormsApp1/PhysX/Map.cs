using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace PhysX
{
    public class Map : IGameMap
    {

        /// <inheritdoc />
        public Tile[,] Tiles { get; }

        /// <inheritdoc />
        public Player Player { get; }

        /// <inheritdoc />
        public Body[] Bodies { get; }

        public int TileSize { get; }

        public Map(Tile[,] tiles, Player player, Body[] bodies, int tileSize = 0)
        {
            Tiles = tiles;
            Player = player;
            Player.Map = this;
            Bodies = bodies;
            TileSize = tileSize;
        }
        public IEnumerable<Vector> Intersections(Rectangle rectangle) => TilesUnderRectangle(rectangle).Where(p => Tiles[(int)p.X, (int)p.Y] == Tile.Wall);
        public IEnumerable<Vector> TilesUnderRectangle(Rectangle rectangle)
        {
            var xMax = ConvertToTiles(rectangle.Right);
            var yMax = ConvertToTiles(rectangle.Bottom);
            for (var x = ConvertToTiles(rectangle.Left); x <= xMax; x++)
                for (var y = ConvertToTiles(rectangle.Top); y <= yMax; y++)
                    yield return new Vector(x, y);
        }
        private int ConvertToTiles(int coordinate) => coordinate / TileSize;
        public Vector ConvertToTiles(Vector point) => new Vector(ConvertToTiles((int)point.X), ConvertToTiles((int)point.Y));




    }
}