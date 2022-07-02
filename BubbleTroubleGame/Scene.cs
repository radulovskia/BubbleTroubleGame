using System;
using System.Collections.Generic;
using System.Drawing;

namespace BubbleTroubleGame
{   
    [Serializable]
    public class Scene
    {
        public List<Ball> balls { get; set; }
        public static int height { get; set; }
        public static int width { get; set; }
        public Player playerOne { get; set; }
        public Player playerTwo { get; set; }
        public Harpoon harpoon1 { get; set; }
        public Harpoon harpoon2 { get; set; }
        private bool second { get; set; }
        public Scene(bool second)
        {
            //ball.Y cannot be less that radius
            this.second = second;
            //made it a multiple of 7
            balls = new List<Ball> { new Ball(7,new Point(150,100),1), new Ball(14, new Point(350, 50),-1) , new Ball(28, new Point(200, 50),1) };

            if (!second)
            {
                playerOne = new Player(240, 1);
                harpoon1 = new Harpoon(240);
            }
            else
            {
                playerOne = new Player(300, 1);
                playerTwo = new Player(180, 2);
                harpoon1 = new Harpoon(300);
                harpoon2 = new Harpoon(180);
            }
            //obstacles.Add(new Obstacle(new Point(300, 300), 100, 50));
        }
        public void draw(Graphics graphics)
        {
            foreach(Ball ball in balls)
            {
                ball.Draw(graphics);
            }
            playerOne.Draw(graphics);
            harpoon1.Draw(graphics);
            if (second)
            {
                playerTwo.Draw(graphics);
                harpoon2.Draw(graphics);
            }
            Brush brush = new SolidBrush(Color.FromArgb(77, 0, 77));
            graphics.FillRectangle(brush, new Rectangle(0,350,width,height));
            if (Highlight != Rectangle.Empty)
            {
                Pen pen = new Pen(Color.Green, 2);
                graphics.DrawEllipse(pen, Highlight);
                pen.Dispose();
            }
            foreach (Obstacle obstacle in obstacles)
                obstacle.draw(graphics);
        }
        private bool tickShootingCheck(Harpoon harpoon, Ball ball)
        {
            if (ball.isHit(harpoon))
            {
                int rad = ball.Radius / 2;
                if (rad >= 7)
                {
                    Point cent = ball.Center;   
                    balls.Add(new Ball(rad, new Point(cent.X + rad, cent.Y), 1, true));
                    balls.Add(new Ball(rad, new Point(cent.X - rad, cent.Y), -1, true));
                }
                return true;
            }
            return false;
        }
        private void tickHarpoonGrow(Player player, Harpoon harpoon)
        {
            if (player.isShooting)
            {
                harpoon.Grow();
            }
        }
        public void tick()
        {
            if (balls.Count != 0)
            {
                for (int i = 0; i < balls.Count; i++)
                {
                    balls[i].Move(height - 130, width); // where the ground is
                    Collide();
                    bool tsc1 = tickShootingCheck(harpoon1, balls[i]);//avoid 2 function calls
                    if (tsc1 || harpoon1.currentY == 0)
                    {
                        if (tsc1)
                            balls.RemoveAt(i);
                        playerOne.isShooting = false;
                        harpoon1 = new Harpoon(playerOne.position);
                    }
                    if (second)
                    {
                        bool tsc2 = tickShootingCheck(harpoon2, balls[i]);
                        if (tsc2 || harpoon2.currentY == 0)
                        {
                            if (tsc2)
                                balls.RemoveAt(i);
                            playerTwo.isShooting = false;
                            harpoon2 = new Harpoon(playerTwo.position);
                        }
                    }
                }
            }
            tickHarpoonGrow(playerOne, harpoon1);
            if (second)
                tickHarpoonGrow(playerTwo, harpoon2);   
        }
        public Rectangle Highlight { get; set; } = Rectangle.Empty;

        //Dodatok za select
        public Object Select(Point p)
        {
            foreach (Ball ball in balls)
            {
                if (Distance(p, ball.Center) <= ball.Radius)
                {
                    return ball;
                }
            }
            if (new Rectangle(playerOne.position, 300, 50, 50).Contains(p))
                return playerOne;
            return null;
        }
        public double Distance(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }
        //Obstacles
        public List<Obstacle> obstacles = new List<Obstacle>();
        private void Collide()
        {
            foreach (Obstacle obstacle in obstacles)
                foreach (Ball ball in balls)
                    obstacle.Collide(ball);
        }
    }
}