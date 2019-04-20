using System.IO;
using System.Linq;

namespace PhysX
{
    public static class MapParser
    {
        public const char Wall = '#';
        public const char Ground = '-';
        public const char Pavement = '*';
        public const char Road = '=';
        public const char Door = '+';
        public const char Grass = 'g';

        public const char ShopSign = 'V';
        public const char PivoSign = 'P';
        public const char Bottles = 'B';

        public const char Win = 'W';
        public const char Trash = 'T';





        public static Tile[,] ParseFromFile(string filename)
        {
            var lines = File.ReadLines(filename).Select(x => x.ToList()).ToList();
            var height = lines.Count;
            var width = lines.First().Count;
            var tiles = new Tile[height, width];
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    switch (lines[i][j])
                    {
                        case Wall:
                            tiles[i, j] = Tile.Wall;
                            break;
                        case Ground:
                            tiles[i, j] = Tile.Ground;
                            break;
                        case Pavement:
                            tiles[i, j] = Tile.Pavement;
                            break;
                        case Road:
                            tiles[i, j] = Tile.Road;
                            break;
                        case Door:
                            tiles[i, j] = Tile.Door;
                            break;
                        case Grass:
                            tiles[i, j] = Tile.Grass;
                            break;
                        case PivoSign:
                            tiles[i, j] = Tile.BeerSign;
                            break;
                        case ShopSign:
                            tiles[i, j] = Tile.ShopSign;
                            break;
                        case Bottles:
                            tiles[i, j] = Tile.Bottles;
                            break;
                        case Win:
                            tiles[i, j] = Tile.Win;
                            break;
                        case Trash:
                            tiles[i, j] = Tile.Trash;
                            break;
                    }

                }
            }

            return tiles;

        }

        public static void Main()
        {
            var tiles = ParseFromFile("map.txt");
        }

    }
}