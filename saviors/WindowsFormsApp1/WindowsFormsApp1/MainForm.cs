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
        private bool isAlive = true;
        private bool isWin = false;
        //private SoundPlayer player = new SoundPlayer();

        public MainForm(IGameMap map, IDrawer drawer)
        {
            this.map = map;
            this.drawer = drawer;

            BackgroundImage = Properties.Resources.neon_beer;
            

            WindowState = FormWindowState.Maximized;

            timer.Interval = 30;
            timer.Tick += (sender, args) =>
            {
                Invalidate();
                try
                {
                    if (!map.Player.Update())
                        drawer.SetImage(map.Player, Properties.Resources.dead);
                }
                catch (WinException e)
                {
                    if (!isWin)
                        drawer.SetImage(map.Player, Properties.Resources.drink);
                    isWin = true;
                }
            };
            timer.Start();
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ImageAnimator.UpdateFrames();
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            drawer.Draw(e.Graphics, map);
            if (isWin)
                e.Graphics.DrawString("WIN!!!", new Font("Arial", 320), Brushes.Green, 100, 100);
            if (isAlive)
                e.Graphics.DrawString(map.Player.Health.ToString(), new Font("Arial", 50), Brushes.Purple, 0, 0);
            if (!isAlive)
                e.Graphics.DrawString("WASTED", new Font("Arial", 320), Brushes.Red, 0, 100);
            if (map.Player.Health <= 0 && isAlive)
            {
                isAlive = false;
                drawer.SetImage(map.Player, Properties.Resources.blood);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (!isAlive || isWin)
                return;
            if (map.Player.isLying)
            {
                Task.Run(() => drawer.SetImage(map.Player, Properties.Resources.respawn))
                    .ContinueWith(t => Task.Delay(1500).Wait())
                    .ContinueWith(t => drawer.SetImage(map.Player, Properties.Resources.walk));
                map.Player.isLying = false;
                return;
            }
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
                    map.Player.Velocity = Vector.Zero;
                    Task.Run(() => drawer.SetImage(map.Player, Properties.Resources.smoke))
                        .ContinueWith(t => Task.Delay(1900).Wait())
                        .ContinueWith(t =>
                        {
                            if (isAlive)
                                drawer.SetImage(map.Player, Properties.Resources.walk);
                        });
                    break;
                case Keys.D:
                    map.Player.Velocity = new Vector(map.Player.Velocity.X * 2, map.Player.Velocity.Y * 2);
                    Task.Run(() => drawer.SetImage(map.Player, Properties.Resources.drink))
                        .ContinueWith(t => Task.Delay(1400).Wait())
                        .ContinueWith(t =>
                        {
                            if (isAlive)
                                drawer.SetImage(map.Player, Properties.Resources.walk);
                        });
                    break;
            }
        }
    }
}