using System;
using System.Collections.Generic;
using System.Drawing;

namespace BubbleTroubleGame
{
    [Serializable]
    public class Scene
    {
        public List<Ball> Balls { get; set; }
        public static int Height { get; set; }
        public static int Width { get; set; }
        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }
        //public Harpoon Harpoon1 { get; set; }
        //public Harpoon Harpoon2 { get; set; }
        private bool Second { get; set; }
        private bool Flag1 { get; set; } = false;
        private bool Flag2 { get; set; } = false;

        public Scene(bool second)
        {
            //ball.Y cannot be less that radius
            this.Second = second;
            initTest();

            if (!second)
            {
                PlayerOne = new Player(240, 1);
            }
            else
            {
                PlayerOne = new Player(300, 1);
                PlayerTwo = new Player(180, 2);
            }
        }
        private void initTest()
        {
            //made it a multiple of 7
            Balls = new List<Ball> { new Ball(7, new Point(150, 100), 1), new Ball(14, new Point(350, 50), -1), new Ball(28, new Point(200, 50), 1) };
            //obstacles.Add(new Obstacle(new Point(300, 200), 100, 50));
        }
        public void Draw(Graphics graphics)
        {
            foreach (Ball ball in Balls)
            {
                ball.Draw(graphics);
            }
            PlayerOne.Draw(graphics);
            PlayerOne.DrawLives(graphics, "left");
            PlayerOne.Harpoon.Draw(graphics);
            if (Second)
            {
                PlayerTwo.Draw(graphics);
                PlayerTwo.DrawLives(graphics, "right");
                PlayerTwo.Harpoon.Draw(graphics);
            }
            Brush brush = new SolidBrush(Color.FromArgb(77, 0, 77));
            graphics.FillRectangle(brush, new Rectangle(0, 350, Width, Height));
            DrawHighlight(graphics);
            foreach (Obstacle obstacle in Obstacles)
                obstacle.Draw(graphics);
        }
        
        public void Tick()
        {
            for (int i = 0; i < Balls.Count; i++)
            {
                Balls[i].Move(Height - 130, Width); // where the ground is
                Collide(Balls[i]);
                bool tsc1 = TickShootingCheck(PlayerOne.Harpoon, Balls[i]);//avoid 2 function calls
                if (tsc1 || PlayerOne.Harpoon.currentY == 0)
                {
                    PlayerOne.IsShooting = false;
                    PlayerOne.Harpoon = new Harpoon(PlayerOne.Position);
                    break;
                }
                if (Second && Balls.Count != 0)//bug when last ball destoryed in coop, the extra checker prevents that
                {
                    bool tsc2 = TickShootingCheck(PlayerTwo.Harpoon, Balls[i]);
                    if (tsc2 || PlayerTwo.Harpoon.currentY == 0)
                    {
                        PlayerTwo.IsShooting = false;
                        PlayerTwo.Harpoon = new Harpoon(PlayerTwo.Position);
                        break;
                    }
                }
            }
        
            TickHarpoonGrow(PlayerOne, PlayerOne.Harpoon);
            Flag1 = HitCheck(PlayerOne, Balls, Flag1);
            
            if (Second)
            {
                TickHarpoonGrow(PlayerTwo, PlayerTwo.Harpoon);
                Flag2 = HitCheck(PlayerTwo, Balls, Flag2);
            }
        }
        //Harpoon Logic
        private bool TickShootingCheck(Harpoon harpoon, Ball ball)
        {
            if (ball.isHit(harpoon))
            {
                Balls.Remove(ball);
                int rad = ball.Radius / 2;
                if (rad >= 7)
                {
                    Point cent = ball.Center;
                    Balls.Add(new Ball(rad, new Point(cent.X + rad, cent.Y), 1, true));
                    Balls.Add(new Ball(rad, new Point(cent.X - rad, cent.Y), -1, true));
                }
                return true;
            }
            return false;
        }
        private void TickHarpoonGrow(Player player, Harpoon harpoon)
        {
            if (player.IsShooting)
            {
                harpoon.Grow();
            }
        }

        private bool HitCheck(Player player, List<Ball> balls, bool flag)
        {
            if (player.IsHit(balls))
            {
                if (!flag)
                    player.Lives--;
                return true;
            }
            return false;
        }

        //Everything below here is for the level editor
        public Rectangle Highlight { get; set; } = Rectangle.Empty;
        public String HighlightType { get; set; } = "Circle";
        private void DrawHighlight(Graphics graphics)
        {
            if (Highlight == Rectangle.Empty)
                return;
            if (HighlightType == "Circle")
            {
                Pen pen = new Pen(Color.Green, 2);
                graphics.DrawEllipse(pen, Highlight);
                pen.Dispose();
            }
            else if (HighlightType == "Rectangle")
            {
                Pen pen = new Pen(Color.Green, 2);
                graphics.DrawRectangle(pen, Highlight);
                pen.Dispose();
            }
        }

        //Dodatok za select
        public Object Select(Point p)
        {
            foreach (Obstacle obstacle in Obstacles)
            {
                if (obstacle.Bounds.Contains(p))
                {
                    return obstacle;
                }
            }foreach (Ball ball in Balls)
            {
                if (Distance(p, ball.Center) <= ball.Radius)
                {
                    return ball;
                }
            }
            if (new Rectangle(PlayerOne.Position, 300, 50, 50).Contains(p))
                return PlayerOne;
            if (new Rectangle(PlayerTwo.Position, 300, 50, 50).Contains(p))
                return PlayerTwo;
            return null;
        }
        public double Distance(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }
        //Obstacles
        public List<Obstacle> Obstacles { get; set; } = new List<Obstacle>();
        private void Collide(Ball ball)
        {
            foreach (Obstacle obstacle in Obstacles)
                obstacle.Collide(ball);
        }

        internal void RemoveDrawable(Drawable selectedItem)
        {
            if(selectedItem is Ball)
            {
                Balls.Remove((Ball)selectedItem);
            }
            else if(selectedItem is Player)
            { 

            }
            if(selectedItem is Obstacle)
            {
                Obstacles.Remove((Obstacle)selectedItem);
            }
        }
    }
}