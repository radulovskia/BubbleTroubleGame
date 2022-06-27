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
        public int radius { get; set; }
        public Point Center { get; set; }
        public int Value { get; set; }

        //Velocity and angle could be used later in the definition of the levels
        public double Velocity { get; set; }
        public double Angle { get; set; }

        //Color for the ball could be randomly assigned with each breaking of it or have order of the colors accoring to the value
        //To be discussed
        static Color[] colors = { Color.Red, Color.Maroon,Color.MintCream };
        static Color GetRandomColor()
        {
            var random = new Random();
            return colors[random.Next(colors.Length)];
        }

        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(GetRandomColor());
            g.FillEllipse(brush, Center.X - radius, Center.Y - radius, radius * 2, radius * 2);
            brush.Dispose();
        }
        public void Move(int left, int top, int width, int height)
        {
           //to be defined
        }
        public void isHit()
        {
            //is hit by a harpoon element
            //disappearance of the ball
            //could return its value cut by half in order to aid the creation of the new ones? Maybe a new function?
        }
    }
}
