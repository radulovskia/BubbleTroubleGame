using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTroubleGame
{
    [Serializable]
    public class Ball
    {
        public static int WIDTH = 600;
        public static int HEIGHT = 480;
        private int radius;
        public int Radius {
            get { return radius; }
            set {
                radius = value > 10 ? value : 10;
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
        public Color color { get; set; }
        public double VelocityX { get; set; } = 1;
        public double VelocityY { get; set; } = 1;
        //public double Angle { get; set; } should an angle be used?

        public Ball(int Radius, Point Center, int direction, bool isPopped = false)
        {
            this.Radius=Radius;
            this.Center=Center;
            this.color = GetColor();
            //this.VelocityX = direction;

            //Velocity and gravity are determined by multiple formulas
            //V=at h=5*r=at^(2)/2
            //Then the values are tweaked in order to suit the gamespeed
            this.VelocityX = Radius / 15 < 1 ? 1 : Radius / 10;
            this.VelocityX *= direction; 
            double t = Radius / 2 * 7;
            double h = Radius * 7;
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
            Brush brush = new SolidBrush(color);
            g.FillEllipse(brush, Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);
            brush.Dispose();
        }
        //add horizontal movement
        /*
        public void Move(int height, int width)
        {
            if (Radius * 15 >= height)
            {
                if (Center.X + Radius >= width || Center.X - Radius <= 0)
                {
                    VelocityX *= -1;
                }
                if (Center.Y + Radius >= height || Center.Y - Radius <= 0)
                {
                    VelocityY *= -1;
                }
            }
            else
            {
                if (VelocityY < 0 && ((Center.Y) <= Radius * 20))
                {
                    if (Center.X + Radius >= width || Center.X - Radius <= 0)
                    {
                        VelocityX *= -1;
                    }
                    if (Center.Y + Radius >= height || Center.Y - Radius <= height - Radius * 15 || Center.Y - Radius <= 0)
                    {
                        VelocityY *= -1;
                    }
                }
                else
                {
                    if (Center.X + Radius >= width || Center.X - Radius <= 0)
                    {
                        VelocityX *= -1;
                    }
                    if (Center.Y + Radius >= height || Center.Y - Radius <= 0)
                    {
                        VelocityY *= -1;
                    }
                }
            }
            Center = new Point((int)(Center.X + VelocityX),(int)(Center.Y + VelocityY));
        }
        */
        public double VelocityYMax { get; set; }
        public double Gravity { get; set; } = 0.1;
        public void Move(int height, int width)
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
        /*
        public bool isHit(Harpoon harpoon)
        {
            for(int i=350;i>harpoon.currentY;i--)
            {
                if(Math.Sqrt(Math.Pow(harpoon.startingX - (Center.X), 2) + Math.Pow(i - (Center.Y), 2)) <= Radius)
                {
                    return true;
                }
            }
            return false;
        }
        */
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
