using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTroubleGame
{
    [Serializable]
    public class Harpoon : Drawable
    {
        //player position at time of shooting
        public int startingX { get; set; }
        //current progress of the bullet
        public int currentY { get; set; }
        //increment per tick
        public static readonly int projectileSpeed = 5;
        public Harpoon(int startingX)
        {
            this.startingX = startingX;
            this.currentY = 360;
        }
        //called on each timer tick
        public void Grow()
        {
            currentY -= projectileSpeed;
        }
        public void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 2);
            g.DrawLine(pen, startingX, 358, startingX, currentY);
            pen.Dispose();
        }

        public Harpoon(Harpoon harpoon)
        {
            this.startingX = harpoon.startingX;
            this.currentY = 360;
        }
    }
}
