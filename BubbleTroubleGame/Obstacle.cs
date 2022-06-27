using System;
using System.Drawing;

public class Obstacle
{
    public int width { get; set; }
	public int height { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public Color color = Color.Maroon;

    public Obstacle(int width, int height)
    {
        this.width = width;
        this.height = height;
    }
    public void draw(Graphics graphics)
    {
        Brush brush = new SolidBrush(color);
        graphics.FillRectangle(brush, new Rectangle(X,Y,width,height));
    }
}
