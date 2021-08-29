using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stars
{
    class GfxStar
    {
        private Point location;
        private StarClasses starClass;

        public enum StarClasses { M, K, G, F, A, B, O };

        public GfxStar(Point location, StarClasses starClass)
        {
            this.location = location;
            this.starClass = starClass;
        }

        public Point Location
        {
            get { return location; }
            set { this.Location = value; }
        }

        public Color GetColor()
        {
            switch (starClass)
            {
                case StarClasses.O:
                    return Color.FromArgb(58, 144, 255);
                case StarClasses.B:
                    return Color.FromArgb(81, 173, 255);
                case StarClasses.A:
                    return Color.FromArgb(138, 239, 247);
                case StarClasses.F:
                    return Color.FromArgb(203, 255, 242);
                case StarClasses.G:
                    return Color.FromArgb(232, 255, 167);
                case StarClasses.K:
                    return Color.FromArgb(255, 218, 52);
                case StarClasses.M:
                    return Color.FromArgb(255, 73, 0);
                default:
                    return Color.Brown;
            }
        }

        public int GetSize()
        {
            switch (starClass)
            {
                case StarClasses.O:
                    return 12;
                case StarClasses.B:
                    return 6;
                case StarClasses.A:
                    return 3;
                case StarClasses.F:
                    return 2;
                case StarClasses.G:
                    return 2;
                case StarClasses.K:
                    return 2;
                default:
                    return 1;
            }
        }

        public void SetClass(StarClasses starClass)
        {
            this.starClass = starClass;
        }

        public void Draw(Graphics graphics)
        {
            SolidBrush brush = new SolidBrush(GetColor());
            int size = GetSize();
            if (size > 4)
                graphics.FillEllipse(brush, Location.X, Location.Y, size, size);
            else
                graphics.FillRectangle(brush, Location.X, Location.Y, size, size);
        }
    }
}
