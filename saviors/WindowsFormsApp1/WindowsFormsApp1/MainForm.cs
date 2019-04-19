using System;
using System.Drawing;
using System.Windows.Forms;
using Drawing;
using PhysX;

namespace WindowsFormsApp1
{
    public class MainForm : Form
    {
        private readonly IDrawer drawer;
        private readonly IGameMap map;
        private readonly Timer timer = new Timer();

        public MainForm(IGameMap map, IDrawer drawer)
        {
            this.map = map;
            this.drawer = drawer;

            ClientSize = new Size(map.Tiles.GetLength(0) * drawer.ImageSize, map.Tiles.GetLength(1) * drawer.ImageSize);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;

            timer.Interval = 30;
            timer.Tick += (sender, args) =>
            {
                Invalidate();
                map.Player.Update(1);
            };
            timer.Start();
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            drawer.Draw(e.Graphics, map);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    map.Player.Turn(-Math.PI / 4);
                    break;
                case Keys.Right:
                    map.Player.Turn(Math.PI / 4);
                    break;
                case Keys.Up:
                    map.Player.Move();
                    break;
            }
        }
    }
}