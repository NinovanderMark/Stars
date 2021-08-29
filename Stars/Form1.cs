using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stars
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
        }

        List<GfxStar> stars = new List<GfxStar>();

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            Cursor.Clip = this.Bounds;
            DrawTimer.Interval = 1000 / 60;

            InitStars();
        }

        private void InitStars()
        {
            Random random = new Random();
            Color newColor = Color.FromArgb(255,255,255);
            Point newLocation = new Point(0, 0);
            GfxStar.StarClasses newClass = GfxStar.StarClasses.A;

            for (int t = 0; t < 5000; t++)
            {
                newLocation.X = random.Next(0, this.Width);
                newLocation.Y = random.Next(0, this.Height);

                // Respects the distribution according to the Journal of the Royal Astronomical Society of Canada
                int classRandom = random.Next(0, 10000);
                if (classRandom < 1) { newClass = GfxStar.StarClasses.O; }
                else if (classRandom <= 13) { newClass = GfxStar.StarClasses.B; }
                else if (classRandom <= 60) { newClass = GfxStar.StarClasses.A; }
                else if (classRandom <= 300) { newClass = GfxStar.StarClasses.F; }
                else if (classRandom <= 760) { newClass = GfxStar.StarClasses.G; }
                else if (classRandom <= 1210) { newClass = GfxStar.StarClasses.K; }
                else { newClass = GfxStar.StarClasses.M; }

                stars.Add(new GfxStar(newLocation, newClass));
            }
        }

        private void DrawTimer_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Black);

            foreach (GfxStar star in stars)
            {
                star.Draw(e.Graphics);
            }
        }
    }
}
