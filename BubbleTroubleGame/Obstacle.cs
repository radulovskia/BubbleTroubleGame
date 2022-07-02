using BubbleTroubleGame;
using System;
using System.Drawing;

public class Obstacle
{
    public Rectangle Bounds { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public Color color = Color.Maroon;

    public Obstacle(Point position, int width, int height)
    {
        this.Bounds = new Rectangle(position.X, position.Y, width, height);
    }
    public void draw(Graphics graphics)
    {
        Brush brush = new SolidBrush(color);
        graphics.FillRectangle(brush, Bounds);
    }

    public void Collide(Ball ball)
    {
        int front = ball.Center.X + ball.Radius;
        int back = ball.Center.X - ball.Radius;
        int bottom = ball.Center.Y + ball.Radius;
        int top = ball.Center.Y - ball.Radius;
        if (Bounds.Contains(front, ball.Center.Y))
        {
            ball.VelocityX *= -1;
            if (Bounds.Left - ball.Center.X - ball.Radius < 0)
            {
                ball.Center = new Point(Bounds.Left - ball.Radius, ball.Center.Y);
            } 
        }
        if (Bounds.Contains(back, ball.Center.Y))
        {
            ball.VelocityX *= -1;
            if (-Bounds.Right + ball.Center.X + ball.Radius < 0)
            {
                ball.Center = new Point(Bounds.Right - ball.Radius, ball.Center.Y);
            }
        }
        if (Bounds.Contains(ball.Center.X, top) || Bounds.Contains(ball.Center.X, bottom))
        {
            ball.VelocityY *= -1;
        }
    }
}
