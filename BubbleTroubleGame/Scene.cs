using System;
using System.Collections.Generic;
using System.Drawing;

namespace BubbleTroubleGame
{
    [Serializable]
    public class Scene
    {
        public List<Ball> Balls { get; set; }
        public List<Obstacle> obstacles = new List<Obstacle>();
        public static int Height { get; set; }
        public static int Width { get; set; }
        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }
        private bool Second { get; set; }
        private bool Flag1 { get; set; } = false;
        private bool Flag2 { get; set; } = false;
        //TODO: REMOVE DEFAULT SCENE INIT
        public Scene(bool second = false)
        {
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
            //made it 7^n
            Balls = new List<Ball> { new Ball(7, new Point(150, 100), 1), new Ball(14, new Point(350, 50), -1), new Ball(28, new Point(200, 50), 1) };

        }
        public void Draw(Graphics graphics)
        {
            foreach(Ball ball in Balls)
            {
                ball.Draw(graphics);
            }
            foreach (Obstacle obstacle in obstacles)
                obstacle.Draw(graphics);
            
            PlayerOne.Draw(graphics);
            PlayerOne.DrawLives(graphics,"left");
            PlayerOne.Harpoon.Draw(graphics);
            if (Second)
            {
                PlayerTwo.Draw(graphics);
                PlayerTwo.DrawLives(graphics,"right");
                PlayerTwo.Harpoon.Draw(graphics);
            }

            Brush brush = new SolidBrush(Color.FromArgb(77, 0, 77));
            graphics.FillRectangle(brush, new Rectangle(0,350,Width,Height));
            brush.Dispose();

            DrawHighlight(graphics);
        }
        //Highlight
        public Rectangle Highlight { get; set; } = Rectangle.Empty;
        public String HighlightType = "Circle";
        private void DrawHighlight(Graphics graphics)
        {
            if (Highlight == Rectangle.Empty)
            {
                return;
            }

            if (HighlightType == "Circle")
            {
                Pen pen = new Pen(Color.Green, 2);
                graphics.DrawEllipse(pen, Highlight);
                pen.Dispose();
            }else if(HighlightType == "Rectangle")
            {
                Pen pen = new Pen(Color.Green, 2);
                graphics.DrawRectangle(pen, Highlight);
                pen.Dispose();
            }
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
                }
                if (Second && Balls.Count != 0)//bug when last ball destoryed in coop, the extra checker prevents that
                {
                    bool tsc2 = TickShootingCheck(PlayerTwo.Harpoon, Balls[i]);
                    if (tsc2 || PlayerTwo.Harpoon.currentY == 0)
                    {
                        PlayerTwo.IsShooting = false;
                        PlayerTwo.Harpoon = new Harpoon(PlayerTwo.Position);
                    }
                }
            }

            TickHarpoonGrow(PlayerOne, PlayerOne.Harpoon);
            if (PlayerOne.IsHit(Balls))
            {
                if (!Flag1)
                    PlayerOne.Lives--;
                Flag1 = true;
            }
            else
            {
                Flag1 = false;
            }
            if (Second)
            {
                TickHarpoonGrow(PlayerTwo, PlayerTwo.Harpoon);
                if (PlayerTwo.IsHit(Balls))
                {
                    if (!Flag2)
                        PlayerTwo.Lives--;
                    Flag2 = true;
                }
                else
                {
                    Flag2 = false;
                }
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

        //Everything below here is for the level editor

        //Dodatok za select
        public Object Select(Point p)
        {
            foreach (Obstacle obstacle in obstacles)
            {
                if (obstacle.Bounds.Contains(p))
                {
                    return obstacle;
                }
            }
            foreach (Ball ball in Balls)
            {
                if (Distance(p, ball.Center) <= ball.Radius)
                {
                    return ball;
                }
            }
            if (new Rectangle(PlayerOne.Position, 300, 50, 50).Contains(p))
                return PlayerOne;
            return null;
        }
        public double Distance(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }

        //Obstacle collisions
        private void Collide(Ball ball)
        {
            foreach (Obstacle obstacle in obstacles)
                obstacle.Collide(ball);
        }

        public void RemoveDrawable(Drawable selectedItem)
        {
            if (selectedItem is Ball)
            {
                Balls.Remove((Ball)selectedItem);
            }else if (selectedItem is Player)
            {
                
            }else if (selectedItem is Obstacle)
            {
                obstacles.Remove((Obstacle) selectedItem);
            }
        }
    }
}