using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BubbleTroubleGame.Properties;

namespace BubbleTroubleGame
{
    [Serializable]
    public class Player
    {
        //X value
        public int position { get; set; }

        public int lives { get; set; } = 5;

        public Image playerImg { get; set; }

        //first or second player
        public int playerId { get; set; }

        public bool isDead { get; set; }
        //change on keydown to true, on keyup to false
        public bool isMoving { get; set; }

        public bool isShooting { get; set; } = false;

        public Player(int position, int playerId)
        {
            this.position = position;
            this.playerId = playerId;
            this.isDead = false;
            if (playerId == 1)
                this.playerImg = Resources.p1back;
            else if (playerId == 2)
                this.playerImg = Resources.p2back;
        }

        public void Move(int sceneWidth, string direction)
        {
            if (direction == "right")
            {
                if (playerId == 1)
                    this.playerImg = Resources.p1right;
                if (playerId == 2)
                    this.playerImg = Resources.p2right;
                position += 2;
            }
            else
            {
                if (playerId == 1)
                    this.playerImg = Resources.p1left;
                if (playerId == 2)
                    this.playerImg = Resources.p2left;
                position -= 2;
            }
            if (position > sceneWidth)
                position = sceneWidth;
            if (position < 0)
                position = 0;
        }

        public void Draw(Graphics g)
        {
            if (isShooting)
            {
                if (playerId == 1)
                    playerImg = Resources.p1back;
                else
                    playerImg = Resources.p2back;
            }
            g.DrawImage(playerImg, position, 300, 50, 50);
        }
        
        public void isHit(List<Ball> balls)
        {
            foreach (Ball b in balls)
            {
                double ballX = b.Radius + b.Center.X;
                double ballY = b.Radius + b.Center.Y;
                double posX = position + 25;
                double posY = 360 + 25;
                double euclid = Math.Sqrt(Math.Pow(posX - ballX, 2) + Math.Pow(posY - ballY, 2));
                //20 is hitbox
                if (euclid <= Math.Pow(b.Radius + 20, 2))
                    lives--;
            }
        }

    }
}
