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
    public class Player : Drawable
    {
        //X value
        private int position;
        public int Position { 
            get { return position; }
            set {
                position = value > 0 && value < 600 - 50 ? value: position;
            } }
        public Harpoon Harpoon { get; set; }

        public int Lives { get; set; } = 5;
        private static Image Heart { get; set; } = Resources.heart_final_copy;
        private static Image Heart2 { get; set; } = Resources.heart_final_copy2;
        public Image PlayerImg { get; set; }

        //first or second player
        public int PlayerId { get; set; }

        public bool IsDead { get; set; }
        //change on keydown to true, on keyup to false
        public bool IsMoving { get; set; }

        public bool IsShooting { get; set; } = false;

        public Player(int position, int playerId)
        {
            this.Position = position;
            this.Harpoon = new Harpoon(position);
            this.PlayerId = playerId;
            this.IsDead = false;
            if (playerId == 1)
                this.PlayerImg = Resources.p1back;
            else if (playerId == 2)
                this.PlayerImg = Resources.p2back;
        }

        public void Move(int sceneWidth, string direction)
        {
            if (IsDead)
                return;
            if (direction == "right")
            {
                if (PlayerId == 1)
                    this.PlayerImg = Resources.p1right;
                if (PlayerId == 2)
                    this.PlayerImg = Resources.p2right;
                Position += 2;
            }
            else
            {
                if (PlayerId == 1)
                    this.PlayerImg = Resources.p1left;
                if (PlayerId == 2)
                    this.PlayerImg = Resources.p2left;
                Position -= 2;
            }
        }

        public void Draw(Graphics g)
        {
            if (IsDead)
            {
                PlayerImg = Resources.rip;
            }
            if (IsShooting)
            {
                if (PlayerId == 1)
                    PlayerImg = Resources.p1back;
                else
                    PlayerImg = Resources.p2back;
            }
            g.DrawImage(PlayerImg, Position, 310, 50, 50);
        }
        public void DrawLives(Graphics g, string direction)
        {
            int spaceLeft = 0;
            int spaceRight = 560;
            if (direction == "left")
            {
                for (int i = 0; i < Lives; i++)
                {
                    g.DrawImage(Heart,spaceLeft, 20,15,15);
                    //g.DrawImage(Heart, spaceLeft, 358 + 10, 15, 15);
                    spaceLeft += 30;
                }
            }
            else
            {
                for (int i = 0; i < Lives; i++)
                {
                    g.DrawImage(Heart2, spaceRight, 20,15,15);
                    //g.DrawImage(Heart, spaceRight, 358 + 10,15,15);
                    spaceRight -= 30;
                }
            }
        }
        
        public bool IsHit(List<Ball> balls)
        {
            foreach (Ball b in balls)
            {
                double posX = Position + 25;
                double posY = 325;
                double euclid = Math.Pow(posX - b.Center.X, 2) + Math.Pow(posY - b.Center.Y, 2);                
                if (euclid <= Math.Pow(b.Radius + 25, 2))
                {
                    if(Lives == 0)
                        IsDead=true;
                    return true;
                }
            }
            return false;
        }

        public Player(Player player)
        {
            Position = player.Position;
            Harpoon = new Harpoon(player.Harpoon);
            Lives = player.Lives;
            PlayerImg = player.PlayerImg;
            PlayerId = player.PlayerId;
            IsDead = player.IsDead;
            IsMoving = player.IsMoving;
            IsShooting = player.IsShooting;
        }
    }
}
