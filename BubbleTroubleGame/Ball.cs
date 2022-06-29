﻿using System;
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

        public double Velocity { get; set; } = -1;
        //public double Angle { get; set; } should an angle be used?

        public bool isAlive { get; set; }

        //Color for the ball could be randomly assigned with each breaking of it or have order of the colors accoring to the value
        //To be discussed
        public Ball(int Radius, Point Center)
        {
            this.Radius=Radius;
            this.Center=Center;
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
        public void Move(int height)
        {
            if (Center.Y >= (height-(Radius*2)))
            {
                Velocity = -(Velocity);
            }
            if (Velocity > 0)
            {
                Center = new Point(Center.X, (int)(Center.Y - Velocity));
                if (Center.Y <= (height - (Radius * Radius)))
                {
                    Velocity = -(Velocity);
                }
            }
            else
            {
                Center = new Point(Center.X, (int)(Center.Y - Velocity));
            }
        }
        public int isHit()
        {
            //when hit returns its value halved in order to create the new balls
            if(!isAlive)
            {
                return Radius/2;
            }
            return 0;
        }
    }
}
