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

        public double Velocity { get; set; } = -1;
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
            Brush brush = new SolidBrush(color);
            g.FillEllipse(brush, Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);
            brush.Dispose();
        }
        //add horizontal movement
        public void Move(int height)
        {
            if (Center.Y >= (height-Radius))
            {
                Velocity = -(Velocity);
            }
            if (Velocity > 0)
            {
                Center = new Point(Center.X, (int)(Center.Y - Velocity));
                if(Center.Y <=(0+Radius))
                {
                    Velocity = -(Velocity);
                }
                if (Center.Y <= (height - (Radius * 20)))
                {
                    Velocity = -(Velocity);
                }
            }
            else
            {
                Center = new Point(Center.X, (int)(Center.Y - Velocity));
            }
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
