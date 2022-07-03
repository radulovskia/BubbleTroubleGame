using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTroubleGame
{
    [Serializable]
    public class Ball : Drawable
    {
        public static int WIDTH = 600;
        public static int HEIGHT = 480;
        private static double BASER = 7;
        private static double BASET = 5;
        private int radius;
        public int Radius {
            get { return radius; }
            set {
                radius = value > 5 ? value : 5;
            } }
        //public Point Center { get; set; }
        private Point center;
        public Point Center {
            get { return center; }
            set
            {
                if (value.X - Radius >= 0 && value.Y - Radius >= 0 && value.X + Radius <= 600 && value.Y + Radius <= 400)
                    center = value;
            } 
        }
        public Color Color { get; set; }
        public double VelocityX { get; set; } = 1;
        public double VelocityY { get; set; } = 1;
        public Ball(int Radius, Point Center, int direction, bool isPopped = false)
        {
            this.Radius=Radius;
            this.Center=Center;
            this.Color = GetColor();

            //Velocity and gravity are determined by multiple formulas
            //V=at h=5*r=at^(2)/2
            //Then the values are tweaked in order to suit the gamespeed
            //Maybe add a modifier here too?
            this.VelocityX = Radius / 15 < 1 ? 1 : Radius / 10;
            this.VelocityX *= direction;

            //Calculation for size modifier
            //Modifier modifies height
            double modifier = Math.Log10(Radius / BASER) / Math.Log10(2);
            modifier = Math.Pow(1.3, modifier);
            double t = modifier * BASER * BASET;
            double h = modifier * BASER * BASET * 2;

            this.Gravity = h * 2 / Math.Pow(t, 2);
            this.VelocityYMax = Gravity * t;

            //if the Ball is popped then it's children shoot upwards
            this.VelocityY = isPopped ? -VelocityYMax : 0;
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
            Brush brush = new SolidBrush(Color);
            g.FillEllipse(brush, Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);
            brush.Dispose();
        }
        public double VelocityYMax { get; set; }
        public double Gravity { get; set; } = 0.1;
        public void Move()
        {
            VelocityY = Math.Abs(VelocityY + Gravity) < VelocityYMax ? VelocityY + Gravity : VelocityYMax;
            Point next = new Point((int)(Center.X + VelocityX), (int)(Center.Y + VelocityY));
            next = Bounce(next);
            Center = next;
        }
        private Point Bounce(Point p)
        {
            int x = p.X;
            int y = p.Y;
            if (p.X - Radius <= 0)
            {
                VelocityX *= -1;
                x = -p.X + Radius;
            }
            else if (p.X + Radius >= WIDTH)
            {
                VelocityX *= -1;
                x = -p.X - Radius;
            }
            if (p.Y - Radius <= 0)
            {
                VelocityY *= -1;
                y = -p.Y + Radius;
            }
            else if (p.Y + Radius >= 350)
            {
                VelocityY *= -1;
                y = -p.Y - Radius;
            }
            return new Point(x, y);
        }
        public bool isHit(Harpoon harpoon)
        {
            int x = harpoon.startingX;
            int y = harpoon.currentY;
            //Distance to the line of the harpoon
            if (Math.Abs(x - Center.X) <= Radius && Center.Y >= y)
            {
                    return true;
            }
            //Distance to the harpoons edge
            if (Math.Sqrt(Math.Pow(x - Center.X, 2) + Math.Pow(y - Center.Y, 2)) <= Radius)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return "Ball " + Radius;
        }
    }
}
