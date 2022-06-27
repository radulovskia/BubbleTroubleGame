using System;
using System.Collections.Generic;
using System.Drawing;

namespace BubbleTroubleGame
{
    public class Scene
    {
        public List<Ball> balls { get; set; }
        public static int height { get; set; } //decide
        public static int width { get; set; } //decide
        public Player playerOne { get; set; }
        public Scene()
        {
            balls = new List<Ball>();
            playerOne = new Player(240,1);
        }
        public void draw(Graphics graphics)
        {
            foreach(Ball ball in balls)
            {
                ball.Draw(graphics);
            }
            playerOne.Draw(graphics);
        }
    }
}