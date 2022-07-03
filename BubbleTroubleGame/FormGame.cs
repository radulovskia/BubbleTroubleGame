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
    public partial class FormGame : Form
    {
        public Scene scene;
        private bool twoPlayers;
        public FormGame(bool twoPlayers)
        {
            InitializeComponent();
            this.twoPlayers = twoPlayers;
            scene = new Scene(twoPlayers);
            //Change the interval to control gamespeed
            timer1.Interval = 10;
            this.Height = 480;
            this.Width = 602;
            //this.FormBorderStyle = FormBorderStyle.None;
            Scene.Height = this.Height;
            Scene.Width = this.Width;
            timer1.Start();
            DoubleBuffered = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.Draw(e.Graphics);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            scene.Tick();
            if (scene.Balls.Count == 0 || (!twoPlayers && scene.PlayerOne.IsDead) || (twoPlayers && scene.PlayerOne.IsDead && scene.PlayerTwo.IsDead))
            {
                timer1.Stop();
                panelEnd.Visible = Visible;
                panelEnd.Enabled = Enabled;
                if (scene.Balls.Count == 0)
                    label1.Visible = Visible;
                else
                    label2.Visible = Visible;
            }
            if (moveLeft1)
                scene.PlayerOne.Move(Scene.Width, "left");
            if (moveRight1)
                scene.PlayerOne.Move(Scene.Width, "right");
            if (moveLeft2)
                scene.PlayerTwo.Move(Scene.Width, "left");
            if (moveRight2)
                scene.PlayerTwo.Move(Scene.Width, "right");
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
                scene.PlayerOne.IsMoving = true;
                moveLeft1 = true;
            }
            if (e.KeyCode == Keys.D)
            {
                scene.PlayerOne.IsMoving = true;
                moveRight1 = true;
            }
            if (e.KeyCode == Keys.W && !scene.PlayerOne.IsDead)
            {
                if (!scene.PlayerOne.IsShooting)
                {
                    scene.PlayerOne.Harpoon.startingX = scene.PlayerOne.Position + 24;
                }
                scene.PlayerOne.IsShooting = true;
            }
            if (twoPlayers)
            {
                if (e.KeyCode == Keys.Left)
                {
                    scene.PlayerTwo.IsMoving = true;
                    moveLeft2 = true;
                }
                if (e.KeyCode == Keys.Right)
                {
                    scene.PlayerTwo.IsMoving = true;
                    moveRight2 = true;
                }
                if (e.KeyCode == Keys.Up && !scene.PlayerTwo.IsDead)
                {
                    if (!scene.PlayerTwo.IsShooting)
                    {
                        scene.PlayerTwo.Harpoon.startingX = scene.PlayerTwo.Position + 24;
                    }
                    scene.PlayerTwo.IsShooting = true;
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
                scene.PlayerOne.IsMoving = false;
            }
            if (e.KeyCode == Keys.D)
            {
                moveRight1 = false;
                scene.PlayerOne.IsMoving = false;
            }
            if (twoPlayers)
            {
                if (e.KeyCode == Keys.Left)
                {
                    moveLeft2 = false;
                    scene.PlayerTwo.IsMoving = false;
                }
                if (e.KeyCode == Keys.Right)
                {
                    moveRight2 = false;
                    scene.PlayerTwo.IsMoving = false;
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
            var form2 = new FormMainMenu();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void btnExitToDesktop_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new FormMainMenu();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }
    }
}
