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
                [Tile.Bottles] = Properties.Resources.bottles,
                [Tile.Door] = Properties.Resources.door,
                [Tile.Win] = Properties.Resources.Win
            };

            var bodies = new Dictionary<Type, Image>
            {
                [typeof(Player)] = Properties.Resources.dead
        };

            var pictureLibrary = new PictureLibrary(tiles, bodies, new Bitmap(32, 32));

            var tilesArrary = MapParser.ParseFromFile("map.txt");
            var map = new Map(tilesArrary, new Player(new Point(1000, 1000), tilesArrary), new Body[0]);

            Application.Run(new MainForm(map, new Drawer(pictureLibrary, 64)));
        }
    }
}