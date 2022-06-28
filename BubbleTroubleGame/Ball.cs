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
        public int Value { get; set; }

        //Velocity and angle could be used later in the definition of the levels
        public double Velocity { get; set; }
        public double Angle { get; set; }

        public bool isAlive { get; set; }

        //Color for the ball could be randomly assigned with each breaking of it or have order of the colors accoring to the value
        //To be discussed
        public Ball(int Radius, Point Center, int Value)
        {
            this.Radius=Radius;
            this.Center=Center;
            this.Value=Value;
            isAlive=true;
        }
        static Color[] colors = { Color.Red, Color.Maroon,Color.MintCream };
        static Color GetRandomColor()
        {
            var random = new Random();
            return colors[random.Next(colors.Length)];
        }

        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(GetRandomColor());
            g.FillEllipse(brush, Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);
            brush.Dispose();
        }
        public void Move()
        {
           //to be defined
        }
        public int isHit()
        {
            //when hit returns its value halved in order to create the new balls
            if(!isAlive)
            {
                return Value/2;
            }
            return 0;
        }
        public void bounce()
        {
            
        }
    }
}
