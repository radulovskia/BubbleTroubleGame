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
            scene.tick();
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
