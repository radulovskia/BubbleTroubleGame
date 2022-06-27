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
        public int currentY { get; set; } = 150;
        //increment per tick
        public readonly int projectileSpeed = 5;
        public Harpoon (int startingX)
        {
            this.startingX = startingX;
        }
        //called on each timer tick
        public void Grow()
        {
            currentY += projectileSpeed;
        }
        public void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.Gray, 3);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            //assuming 150 is ground level for the player
            g.DrawLine(pen, startingX, 150, startingX, currentY);
            pen.Dispose();
        }
    }
}
