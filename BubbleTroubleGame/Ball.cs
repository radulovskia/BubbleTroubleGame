using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTroubleGame
{
    public class Ball
    {
        public static int WIDTH = 600;
        public static int HEIGHT = 480;
        public int Radius { get; set; }
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

        //Color for the ball could be randomly assigned with each breaking of it or have order of the colors accoring to the value
        //To be discussed
        public Ball(int Radius, Point Center,double VelocityX)
        {
            this.Radius=Radius;
            this.Center=Center;
            this.color = GetColor();
            this.VelocityX= VelocityX;
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
        public bool isHit(Harpoon harpoon)
        {
            for(int i=310;i>harpoon.currentY;i--)
            {
                if(Math.Sqrt(Math.Pow(harpoon.startingX - (Center.X), 2) + Math.Pow(i - (Center.Y), 2)) <= Radius)
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
