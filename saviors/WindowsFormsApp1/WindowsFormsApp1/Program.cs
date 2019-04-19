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
                [Tile.Ground] = Image.FromFile(""),
                [Tile.Wall] = Image.FromFile("")
            };

            var bodies = new Dictionary<Type, Image>
            {

            };


            var pictureLibrary = new PictureLibrary(tiles, bodies, Image.FromFile(""));

            //Application.Run(new MainForm(, new Drawer(pictureLibrary)));
        }
    }
}
