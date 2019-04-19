using System.Windows.Forms;
using Drawing;
using PhysX;

namespace WindowsFormsApp1
{
    public class MainForm : Form
    {
        private readonly IDrawer drawer;
        private readonly IGameMap map;

        public MainForm(IGameMap map, IDrawer drawer)
        {
            this.map = map;
            this.drawer = drawer;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            drawer.Draw(e.Graphics, map);
        }
    }
}