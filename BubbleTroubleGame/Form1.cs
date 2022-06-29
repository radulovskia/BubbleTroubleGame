using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BubbleTroubleGame
{
    public partial class Form1 : Form
    {
        public Scene scene;
        public Form1()
        {
            InitializeComponent();
            scene = new Scene();
            timer1.Interval = 1;
            this.Height = 480;
            this.Width = 600;
            Scene.height = this.Height;
            Scene.width = this.Width;
            timer1.Start();
            DoubleBuffered = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.draw(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for(int i=0;i<scene.balls.Count;i++)
            {
                scene.balls[i].Move(360); // where the ground is
                if(scene.balls[i].isHit(scene.harpoon))
                {
                    int rad = scene.balls[i].Radius / 2;
                    if (rad >= 7)
                    {
                        Point cent = scene.balls[i].Center;
                        scene.balls.RemoveAt(i);
                        scene.balls.Add(new Ball(rad, new Point(cent.X + rad, cent.Y)));
                        scene.balls.Add(new Ball(rad, new Point(cent.X - rad, cent.Y)));
                        scene.harpoon = new Harpoon(scene.playerOne.position);
                        scene.playerOne.isShooting = false;
                    }
                    else
                    {
                        scene.balls.RemoveAt(i);
                    }
                }
            }
            if (scene.playerOne.isShooting)
            {
                scene.harpoon.Grow();
            }
            if (scene.harpoon.currentY == 0)
            {
                scene.harpoon = new Harpoon(scene.playerOne.position);
                scene.playerOne.isShooting = false;
            }
            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                scene.playerOne.isMoving = true;
                scene.playerOne.Move(Scene.width, "left");
            }
            if (e.KeyCode == Keys.D)
            {
                scene.playerOne.isMoving = true;
                scene.playerOne.Move(Scene.width, "right");
            }
            if (e.KeyCode == Keys.W)
            {
                scene.playerOne.isShooting = true;
                scene.harpoon.startingX=scene.playerOne.position+24;
            }
            Invalidate();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            scene.playerOne.isMoving = false;
            Invalidate();
        }
    }
}
