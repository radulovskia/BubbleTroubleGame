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
        public int Radius { get; set; }
        public Point Center { get; set; }
        public Color color { get; set; }
        public double VelocityX { get; set; } = -1;
        public double VelocityY { get; set; } = -1;
        //public double Angle { get; set; } should an angle be used?

        //Color for the ball could be randomly assigned with each breaking of it or have order of the colors accoring to the value
        //To be discussed
        public Ball(int Radius, Point Center)
        {
            this.Radius=Radius;
            this.Center=Center;
            this.color = GetRandomColor();
            
        }
        static Color[] colors = { Color.Blue}; // add more colors
        static Color GetRandomColor()
        {
            var random = new Random();
            return colors[random.Next(colors.Length)];
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
            if(Center.X+Radius >= width || Center.X-Radius <= 0)
            {
                VelocityX *= -1;
            }
            if (Center.Y + Radius >= height || Center.Y - Radius <= 0)
            {
                VelocityY *= -1;
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
    }
}
