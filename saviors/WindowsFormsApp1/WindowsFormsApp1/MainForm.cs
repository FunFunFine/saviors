using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Media;
using System.Threading.Tasks;
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
        //private SoundPlayer player = new SoundPlayer();

        public MainForm(IGameMap map, IDrawer drawer)
        {
            this.map = map;
            this.drawer = drawer;

            WindowState = FormWindowState.Maximized;

            timer.Interval = 30;
            timer.Tick += (sender, args) =>
            {
                Invalidate();
                map.Player.Update();
            };
            timer.Start();
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ImageAnimator.UpdateFrames();
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            drawer.Draw(e.Graphics, map);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    map.Player.Turn(Math.PI / 16);
                    break;
                case Keys.Right:
                    map.Player.Turn(-Math.PI / 16);
                    break;
                case Keys.Up:
                    map.Player.Move();
                    break;
                case Keys.P:
                    Task.Run(() => drawer.SetImage(map.Player, Properties.Resources.smoke))
                        .ContinueWith(t => Task.Delay(1900).Wait())
                        .ContinueWith(t => drawer.SetImage(map.Player, Properties.Resources.walk));
                    break;
                case Keys.D:
                    Task.Run(() => drawer.SetImage(map.Player, Properties.Resources.drink))
                        .ContinueWith(t => Task.Delay(1400).Wait())
                        .ContinueWith(t => drawer.SetImage(map.Player, Properties.Resources.walk));
                    break;
            }
        }
    }
}