using System;
using System.Collections.Generic;
using System.Drawing;

namespace BubbleTroubleGame
{
    public class Scene
    {
        public List<Ball> balls { get; set; }
        public static int height { get; set; } //decide
        public static int width { get; set; }//decide
        public Player playerOne { get; set; }
        public Harpoon harpoon { get; set; }
        public Scene()
        {
            balls = new List<Ball> { new Ball(7,new Point(100,100)), new Ball(12, new Point(40, 20)) , new Ball(20, new Point(20, 50)) };
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
            Brush brush = new SolidBrush(Color.SaddleBrown);
            graphics.FillRectangle(brush, new Rectangle(0,350,width,height));
        }
    }
}