using BubbleTroubleGame;
using System;
using System.Drawing;

[Serializable]
public class Obstacle : Drawable
{
    public Rectangle Bounds { get; set; }
    public Color color = Color.Maroon;

    public Obstacle(Point position, int width, int height)
    {
        this.Bounds = new Rectangle(position.X, position.Y, width, height);
    }
    public void Draw(Graphics graphics)
    {
        Brush brush = new SolidBrush(color);
        graphics.FillRectangle(brush, Bounds);
    }

    public void Collide(Ball ball)
    {
        double tmpVX = ball.VelocityX;
        double tmpVY = ball.VelocityY;

        int front = ball.Center.X + ball.Radius + (int)tmpVX;
        int back = ball.Center.X - ball.Radius + (int)tmpVX;
        int bottom = ball.Center.Y + ball.Radius + (int)tmpVY;
        int top = ball.Center.Y - ball.Radius + (int)tmpVY;
        int tmpX = ball.Center.X;
        int tmpY = ball.Center.Y;
        bool changed = false;
        Point TL = new Point(Bounds.X, Bounds.Y);
        Point TR = new Point(Bounds.X + Bounds.Width, Bounds.Y);
        Point BL = new Point(Bounds.X, Bounds.Y + Bounds.Height);
        Point BR = new Point(Bounds.X + Bounds.Width, Bounds.Y + Bounds.Height);



        if (Bounds.Contains(front, ball.Center.Y))
        {
            tmpVX *= -1;
            if (Bounds.Left - front <= 0)
            {
                ball.Center = new Point(Bounds.Left - ball.Radius, ball.Center.Y);
                tmpX = Bounds.Left - ball.Radius;
            }
            changed = true;
        }
        else if (Bounds.Contains(back, ball.Center.Y))
        {
            tmpVX *= -1;
            if (-Bounds.Right + back <= 0)
            {
                ball.Center = new Point(Bounds.Right + ball.Radius, ball.Center.Y);
                tmpX = Bounds.Right + ball.Radius;
            }
            changed = true;
        }

        if (Bounds.Contains(ball.Center.X, bottom))
        {
            tmpVY = ball.VelocityYMax;
            tmpVY *= -1;
            if (Bounds.Top - bottom <= 0 && !changed)
            {
                ball.Center = new Point(ball.Center.X, Bounds.Top - ball.Radius);
                tmpY = Bounds.Top - ball.Radius;
            }
            changed = true;
        }
        else if (Bounds.Contains(ball.Center.X, top))
        {
            tmpVY *= -1;
            if (-Bounds.Bottom + top < 0 && !changed)
            {
                ball.Center = new Point(ball.Center.X, Bounds.Bottom + ball.Radius + 1);
                tmpY = Bounds.Bottom + ball.Radius;
            }
            changed = true;
        }
        int rad2 = ball.Radius * ball.Radius;
        if (!changed && tmpVY != 0)
        {
            if(Distance2(ball.Center, TR) < rad2)
            {
                if (tmpVX < 0)
                    tmpVX *= -1;
                tmpVY *= -1;
            }else if(Distance2(ball.Center, TL) < rad2)
            {
                if (tmpVX > 0)
                    tmpVX *= -1;
                tmpVY *= -1;
            }else if(Distance2(ball.Center, BL) < rad2)
            {
                if (tmpVX > 0)
                    tmpVX *= -1;
                tmpVY *= -1;
            }else if(Distance2(ball.Center, BR) < rad2)
            {
                if (tmpVX < 0)
                    tmpVX *= -1;
                tmpVY *= -1;
            }
        }


        ball.Center = new Point(tmpX, tmpY);
        ball.VelocityX = tmpVX;
        ball.VelocityY = tmpVY;
    }
    private double Distance(Point a, Point b)
    {
        return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
    }

    private double Distance2(Point a, Point b)
    {
        return Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2);
    }

    public override string ToString()
    {
        return "Obstacle " + Bounds.Height + " " + Bounds.Width;
    }

    public Obstacle(Obstacle obstacle)
    {
        int x = obstacle.Bounds.X;
        int y = obstacle.Bounds.Y;
        this.Bounds = new Rectangle(x, y, obstacle.Bounds.Width, obstacle.Bounds.Height);
    }
}
