using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTroubleGame
{
    public class Harpoon
    {
        //player position at time of shooting
        public int startingX { get; set; }
        //current progress of the bullet
        public int currentY { get; set; }
        //increment per tick
        public readonly int projectileSpeed = 5;
        public Harpoon(int startingX)
        {
            this.startingX = startingX;
            this.currentY = 350;
        }
        //called on each timer tick
        public void Grow()
        {
            currentY -= projectileSpeed;
        }
        public void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 2);
            g.DrawLine(pen, startingX, 350, startingX, currentY);
            pen.Dispose();
        }
    }
}
