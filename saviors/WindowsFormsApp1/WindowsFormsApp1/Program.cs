using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Drawing;
using PhysX;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var tiles = new Dictionary<Tile, Image>
            {
                [Tile.Ground] = Properties.Resources.floor,
                [Tile.Wall] = Properties.Resources.brick,
                [Tile.Pavement] = Properties.Resources.trotuar,
                [Tile.Road] = Properties.Resources.road,
                [Tile.Grass] = Properties.Resources.grass,
                [Tile.BeerSign] = Properties.Resources.neon_beer,
                [Tile.ShopSign] = Properties.Resources.neon_store,
                [Tile.Bottles] = Properties.Resources.bottles
            };

            var bodies = new Dictionary<Type, Image>
            {
                [typeof(Player)] = Properties.Resources.walk
            };


            var pictureLibrary = new PictureLibrary(tiles, bodies, new Bitmap(32, 32));

            var map = new GameMap(MapParser.ParseFromFile("map.txt"), new Player(new Point(300, 200)), new Body[0]);

            Application.Run(new MainForm(map, new Drawer(pictureLibrary, 64)));
        }
    }
}
