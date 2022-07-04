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
        private Scene scene;
        public Scene Scene {
            get
            {
                return scene;
            } 
            set
            {
                scene = value;
                lblP2.Visible = scene.TwoPlayers;
            } 
        }
        private bool twoPlayers;
        public FormGame(bool twoPlayers)
        {
            InitializeComponent();
            this.twoPlayers = twoPlayers;
            Scene = new Scene(twoPlayers);
            //Change the interval to control gamespeed
            timer1.Interval = 10;
            this.Height = 480;
            this.Width = 602;
            //this.FormBorderStyle = FormBorderStyle.None;
            BubbleTroubleGame.Scene.Height = this.Height;
            BubbleTroubleGame.Scene.Width = this.Width;
            timer1.Start();
            DoubleBuffered = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Scene.Draw(e.Graphics);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Scene.Tick();
            if (Scene.Balls.Count == 0 || (!twoPlayers && Scene.PlayerOne.IsDead) || (twoPlayers && Scene.PlayerOne.IsDead && Scene.PlayerTwo.IsDead))
            {
                timer1.Stop();
                panelEnd.Visible = Visible;
                panelEnd.Enabled = Enabled;
                if (Scene.Balls.Count == 0)
                    label1.Visible = Visible;
                else
                    label2.Visible = Visible;
            }
            if (moveLeft1)
                Scene.PlayerOne.Move(Scene.Width, "left");
            if (moveRight1)
                Scene.PlayerOne.Move(Scene.Width, "right");
            if (moveLeft2)
                Scene.PlayerTwo.Move(Scene.Width, "left");
            if (moveRight2)
                Scene.PlayerTwo.Move(Scene.Width, "right");
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
                Scene.PlayerOne.IsMoving = true;
                moveLeft1 = true;
            }
            if (e.KeyCode == Keys.D)
            {
                Scene.PlayerOne.IsMoving = true;
                moveRight1 = true;
            }
            if (e.KeyCode == Keys.W && !Scene.PlayerOne.IsDead)
            {
                if (!Scene.PlayerOne.IsShooting)
                {
                    Scene.PlayerOne.Harpoon.startingX = Scene.PlayerOne.Position + 24;
                }
                Scene.PlayerOne.IsShooting = true;
            }
            if (twoPlayers)
            {
                if (e.KeyCode == Keys.Left)
                {
                    Scene.PlayerTwo.IsMoving = true;
                    moveLeft2 = true;
                }
                if (e.KeyCode == Keys.Right)
                {
                    Scene.PlayerTwo.IsMoving = true;
                    moveRight2 = true;
                }
                if (e.KeyCode == Keys.Up && !Scene.PlayerTwo.IsDead)
                {
                    if (!Scene.PlayerTwo.IsShooting)
                    {
                        Scene.PlayerTwo.Harpoon.startingX = Scene.PlayerTwo.Position + 24;
                    }
                    Scene.PlayerTwo.IsShooting = true;
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
                Scene.PlayerOne.IsMoving = false;
            }
            if (e.KeyCode == Keys.D)
            {
                moveRight1 = false;
                Scene.PlayerOne.IsMoving = false;
            }
            if (twoPlayers)
            {
                if (e.KeyCode == Keys.Left)
                {
                    moveLeft2 = false;
                    Scene.PlayerTwo.IsMoving = false;
                }
                if (e.KeyCode == Keys.Right)
                {
                    moveRight2 = false;
                    Scene.PlayerTwo.IsMoving = false;
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
