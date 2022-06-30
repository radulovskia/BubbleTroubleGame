using System;
using System.Collections.Generic;
using System.Drawing;

namespace BubbleTroubleGame
{
    public class Scene
    {
        public List<Ball> balls { get; set; }
        public static int height { get; set; }
        public static int width { get; set; }
        public Player playerOne { get; set; }
        public Harpoon harpoon { get; set; }
        public Scene()
        {
            //ball.Y cannot be less that radius
            balls = new List<Ball> { new Ball(7,new Point(150,100),1), new Ball(25, new Point(350, 50),-1) , new Ball(20, new Point(200, 50),1) };
            playerOne = new Player(240,1);
            harpoon = new Harpoon(240);
        }
        public void draw(Graphics graphics)
        {
            foreach(Ball ball in balls)
            {
                ball.Draw(graphics);
            }
            playerOne.Draw(graphics);
            harpoon.Draw(graphics);
            Brush brush = new SolidBrush(Color.FromArgb(77, 0, 77));
            graphics.FillRectangle(brush, new Rectangle(0,350,width,height));
            if (Highlight != Rectangle.Empty)
            {
                Pen pen = new Pen(Color.Green, 2);
                graphics.DrawEllipse(pen, Highlight);
                pen.Dispose();
            }
        }
        public void tick()
        {
            for(int i=0;i<balls.Count;i++)
            {
                balls[i].Move(height-130,width); // where the ground is
                if(balls[i].isHit(harpoon))
                {
                    int rad = balls[i].Radius / 2;
                    if (rad >= 7)
                    {
                        Point cent = balls[i].Center;
                        balls.RemoveAt(i);
                        balls.Add(new Ball(rad, new Point(cent.X + rad, cent.Y), 1));
                        balls.Add(new Ball(rad, new Point(cent.X - rad, cent.Y) ,-1));
                        playerOne.isShooting = false;
                    }
                    else
                    {
                        balls.RemoveAt(i);
                    }
                    playerOne.isShooting = false;
                    harpoon = new Harpoon(playerOne.position);
                }
            }
            if (playerOne.isShooting)
            {
                harpoon.Grow();
            }
            if (harpoon.currentY == 0)
            {
                harpoon = new Harpoon(playerOne.position);
                playerOne.isShooting = false;
            }
        }

        public Rectangle Highlight { get; set; } = Rectangle.Empty;
    }
}