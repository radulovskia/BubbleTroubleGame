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
        public List<Point> linePoints { get; set; }
        public Point startingPoint { get; set; }
        public Pen pen { get; set; }
        public readonly int projectileSpeed = 10;
        public int timerTicks { get; set; }
        public Harpoon()
        {
            linePoints = new List<Point>();
            timerTicks = 0;
        }
        public void Grow()
        {

        }
    }
}
