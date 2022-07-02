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
        private bool second;
        public Form1(bool second)
        {
            InitializeComponent();
            this.second = second;
            scene = new Scene(second);
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
            if (scene.balls.Count == 0 || (!second && scene.playerOne.isDead) || (second && scene.playerOne.isDead && scene.playerTwo.isDead))
                timer1.Stop();
            if (moveLeft1)
                scene.playerOne.Move(Scene.width, "left");
            if (moveRight1)
                scene.playerOne.Move(Scene.width, "right");
            if (moveLeft2)
                scene.playerTwo.Move(Scene.width, "left");
            if (moveRight2)
                scene.playerTwo.Move(Scene.width, "right");
            Invalidate();
        }
        private bool moveRight1;
        private bool moveRight2;
        private bool moveLeft1;
        private bool moveLeft2;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                scene.playerOne.isMoving = true;
                moveLeft1 = true;
            }
            if (e.KeyCode == Keys.D)
            {
                scene.playerOne.isMoving = true;
                moveRight1 = true;
            }
            if (e.KeyCode == Keys.W && !scene.playerOne.isDead)
            {
                if (!scene.playerOne.isShooting)
                {
                    scene.harpoon1.startingX = scene.playerOne.position + 24;
                }
                scene.playerOne.isShooting = true;
            }
            if (second)
            {
                if (e.KeyCode == Keys.Left)
                {
                    scene.playerTwo.isMoving = true;
                    moveLeft2 = true;
                }
                if (e.KeyCode == Keys.Right)
                {
                    scene.playerTwo.isMoving = true;
                    moveRight2 = true;
                }
                if (e.KeyCode == Keys.Up && !scene.playerTwo.isDead)
                {
                    if (!scene.playerTwo.isShooting)
                    {
                        scene.harpoon2.startingX = scene.playerTwo.position + 24;
                    }
                    scene.playerTwo.isShooting = true;
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                panelPauseMenu.Visible = !panelPauseMenu.Visible;
                panelPauseMenu.Enabled = !panelPauseMenu.Enabled;
                timer1.Enabled = !timer1.Enabled;
            }
            Invalidate();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                moveLeft1 = false;
                scene.playerOne.isMoving = false;
            }
            if (e.KeyCode == Keys.D)
            {
                moveRight1 = false;
                scene.playerOne.isMoving = false;
            }
            if (second)
            {
                if (e.KeyCode == Keys.Left)
                {
                    moveLeft2 = false;
                    scene.playerTwo.isMoving = false;
                }
                if (e.KeyCode == Keys.Right)
                {
                    moveRight2 = false;
                    scene.playerTwo.isMoving = false;
                }
            }
            Invalidate();
        }

        private void btnLvlEditor_Click(object sender, EventArgs e)
        {
            Form form = new FormLE();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            panelPauseMenu.Visible = !panelPauseMenu.Visible;
            panelPauseMenu.Enabled = !panelPauseMenu.Enabled;
            timer1.Enabled = !timer1.Enabled;
        }

        private void btnExitToMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new MainMenu();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void btnExitToDesktop_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
