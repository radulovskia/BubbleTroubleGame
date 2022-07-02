using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTroubleGame
{
    public class Ball2
    {
        public static int WIDTH = 600;
        public static int HEIGHT = 480;
        public int Radius { get; set; }
        //public Point Center { get; set; }
        private Point center;
        public Point Center
        {
            get { return center; }
            set
            {
                if (value.X - Radius >= 0 && value.Y - Radius >= 0 && value.X + Radius <= 600 && value.Y + Radius <= 400)
                    center = value;
            }
        }
        public Color color { get; set; }
        public double VelocityX { get; set; } = 1;
        public double VelocityY { get; set; } = 1;
        public double VelocityYMax { get; set; } = 1;
        public double Gravity { get; set; } = 0.01;
        //public double Angle { get; set; } should an angle be used?

        //Color for the ball could be randomly assigned with each breaking of it or have order of the colors accoring to the value
        //To be discussed
        public Ball2(int Radius, Point Center, double VelocityX)
        {
            this.Radius = Radius;
            this.Center = Center;
            this.color = GetColor();
            this.VelocityX = VelocityX;
        }
        static Color[] colors = { Color.LightSeaGreen, Color.DarkOrange, Color.Magenta, Color.BlueViolet, Color.PaleGoldenrod }; // add more colors
        public Color GetColor()
        {
            if (Radius <= 7)
            {
                return colors[0];
            }
            else if (Radius <= 14)
            {
                return colors[1];
            }
            else if (Radius <= 21)
            {
                return colors[2];
            }
            else if (Radius <= 32)
            {
                return colors[3];
            }
            else
            {
                return colors[4];
            }
        }
        public void Draw(Graphics g)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Brush brush = new SolidBrush(color);
            g.FillEllipse(brush, Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);
            brush.Dispose();
        }
        //add horizontal movement
        public void Move(int height, int width)
        {
            VelocityY = VelocityY + Gravity < VelocityYMax ? VelocityY + Gravity : VelocityYMax;
            Point next = new Point((int)(Center.X + VelocityX), (int)(Center.Y + VelocityY));
            next = Bounce(next);
            Center = next;
        }
        private Point Bounce(Point p)
        {
            int x = p.X;
            int y = p.Y;
            if(p.X - Radius <= 0)
            {
                VelocityX *= -1;
                x = - p.X + Radius;
            }else if(p.X + Radius >= WIDTH) {
                VelocityX *= -1;
                x = - p.X - Radius;
            }
            if (p.Y - Radius <= 0)
            {
                VelocityY *= -1;
                y = -p.Y + Radius;
            }
            else if (p.Y + Radius >= HEIGHT)
            {
                VelocityY *= -1;
                y = -p.Y - Radius;
            }
            return new Point(x, y);
        }
        public bool isHit(Harpoon harpoon)
        {
            for (int i = 310; i > harpoon.currentY; i--)
            {
                if (Math.Sqrt(Math.Pow(harpoon.startingX - (Center.X), 2) + Math.Pow(i - (Center.Y), 2)) <= Radius)
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            return "Ball " + Radius;
        }
    }
}
