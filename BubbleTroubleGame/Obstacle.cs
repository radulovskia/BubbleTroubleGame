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
        double tmpVX = ball.VelocityX;
        double tmpVY = ball.VelocityY;
        int front = ball.Center.X + ball.Radius;
        int back = ball.Center.X - ball.Radius;
        int bottom = ball.Center.Y + ball.Radius;
        int top = ball.Center.Y - ball.Radius;
        int tmpX = ball.Center.X;
        int tmpY = ball.Center.Y;
        bool changed = false;
        if (Bounds.Contains(front, ball.Center.Y))
        {
            tmpVX *= -1;
            if (Bounds.Left - front <= 0)
            {
                //ball.Center = new Point(Bounds.Left - ball.Radius, ball.Center.Y);
                tmpX = Bounds.Left - ball.Radius;
            } 
        }else if (Bounds.Contains(back, ball.Center.Y))
        {
            tmpVX *= -1;
            if (-Bounds.Right + back <= 0)
            {
                //ball.Center = new Point(Bounds.Right + ball.Radius, ball.Center.Y);
                tmpX = Bounds.Right + ball.Radius;
            }
        }

        if (Bounds.Contains(ball.Center.X, bottom))
        {
            tmpVY = ball.VelocityYMax;
            tmpVY *= -1;
            if (Bounds.Top - bottom <= 0 && ! changed)
            {
                //ball.Center = new Point(ball.Center.X, Bounds.Top - ball.Radius);
                tmpY = Bounds.Top - ball.Radius;
            } 
        }else if (Bounds.Contains(ball.Center.X, top))
        {
            tmpVY *= -1;
            if (-Bounds.Bottom + top < 0 && !changed)
            {
                //ball.Center = new Point(ball.Center.X, Bounds.Bottom + ball.Radius + 1);
                tmpY = Bounds.Bottom + ball.Radius;
            } 
        }
        ball.Center = new Point(tmpX, tmpY);
        ball.VelocityX = tmpVX;
        ball.VelocityY = tmpVY;
    }
}
