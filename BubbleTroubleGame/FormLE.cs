using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BubbleTroubleGame
{
    public partial class FormLE : Form
    {
        public Scene scene;
        public FormLE()
        {
            InitializeComponent();
            scene = new Scene();
            Scene.Height = this.Height;
            Scene.Width = this.Width;
            this.DoubleBuffered = true;
            Invalidate();
            initScene();
            cbObjectType.SelectedIndex = 0;
            timer1.Start();
        }
        private void initScene()
        {
            var selected = listBox1.SelectedItem;
            listBox1.Items.Clear();
            foreach (Ball ball in scene.Balls)
                listBox1.Items.Add(ball);
            foreach (Obstacle obstacle in scene.Obstacles)
                listBox1.Items.Add(obstacle);
            listBox1.Items.Add(scene.PlayerOne);
            if(scene.TwoPlayers)
                listBox1.Items.Add(scene.PlayerTwo);
            listBox1.SelectedItem = selected;
        }

        private void FormLE_Paint(object sender, PaintEventArgs e)
        {
            this.Text = FileName; Bitmap bmp = new Bitmap(panelGame.Width, panelGame.Height);
            scene.Draw(Graphics.FromImage(bmp));
            e.Graphics.DrawImage(Image.FromFile("../../Resources/bg2.jpg"), 0, 27, panelGame.Width, panelGame.Height);
            e.Graphics.DrawImageUnscaled(bmp, 0, 27);
            panelGame.Visible = false;
        }

        private void panelGame_Paint(object sender, PaintEventArgs e)
        {
            //Bitmap bmp = new Bitmap(panelGame.Width, panelGame.Height);
            //scene.Draw(Graphics.FromImage(bmp));
            //e.Graphics.DrawImageUnscaled(bmp, 0, 0);
        }

        protected override CreateParams CreateParams { 
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        private String Type = "";
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setHighlight();
            changed = true;
        }
        //Context Setup
        private void setContext()
        {
            if (Type == "Ball")
            {
                lblContext1.Text = "Radius: ";
                lblContext1.Enabled = true;
                lblContext1.Visible = true; 
                numContext1.Enabled = true;
                numContext1.Visible = true;
                int tmp = ((Ball)listBox1.SelectedItem).Radius;
                numContext1.Maximum = 100;
                numContext1.Value = tmp;
                numContext1.Increment = 7;
                numContext2.Enabled = false;
                numContext2.Visible = false; 
                lblContext2.Enabled = false;
                lblContext2.Visible = false;
            }
            else if (Type == "Player")
            {
                lblContext1.Text = "Lives: ";
                lblContext1.Enabled = true;
                lblContext1.Visible = true;
                numContext1.Enabled = true;
                numContext1.Visible = true;
                int tmp = ((Player)listBox1.SelectedItem).Lives;
                numContext1.Maximum = 10;
                numContext1.Value = tmp;
                numContext1.Increment = 1;
                numContext2.Enabled = false;
                numContext2.Visible = false;
                lblContext2.Enabled = false;
                lblContext2.Visible = false;
            }
            else if (Type == "Obstacle")
            {
                Rectangle bounds = ((Obstacle)listBox1.SelectedItem).Bounds;
                lblContext1.Text = "Height: ";
                lblContext1.Enabled = true;
                lblContext1.Visible = true;
                numContext1.Enabled = true;
                numContext1.Visible = true;
                numContext1.Maximum = 1000;
                numContext1.Value = bounds.Height;
                numContext1.Increment = 5;
                lblContext2.Text = "Width: ";
                lblContext2.Enabled = true;
                lblContext2.Visible = true;
                numContext2.Enabled = true;
                numContext2.Visible = true;
                numContext2.Maximum = 1000;
                numContext2.Value = bounds.Width;
                numContext2.Increment = 5;
            }
            else
            {
                lblContext1.Enabled = false;
                lblContext1.Visible = false;
                numContext1.Enabled = false;
                numContext1.Visible = false;
                lblContext2.Enabled = false;
                lblContext2.Visible = false;
                numContext2.Enabled = false;
                numContext2.Visible = false;
            }
        }

        private void numContext1_ValueChanged(object sender, EventArgs e)
        {
            if (Type == "Ball")
            {
                ((Ball)listBox1.SelectedItem).Radius = (int)numContext1.Value;
            }
            else if (Type == "Player")
            {
                ((Player)listBox1.SelectedItem).Lives = (int)numContext1.Value;
            }
            else if (Type == "Obstacle")
            {
                Rectangle bounds = ((Obstacle)listBox1.SelectedItem).Bounds;
                ((Obstacle)listBox1.SelectedItem).Bounds = new Rectangle(bounds.X, bounds.Y, bounds.Width, (int)numContext1.Value);
            }
            setHighlight();
            initScene();
            changed = true;
        }

        private void numContext2_ValueChanged(object sender, EventArgs e)
        {
            if (Type == "Obstacle")
            {
                Rectangle bounds = ((Obstacle)listBox1.SelectedItem).Bounds;
                ((Obstacle)listBox1.SelectedItem).Bounds = new Rectangle(bounds.X, bounds.Y, (int)numContext2.Value, bounds.Height);
            }
            setHighlight();
            initScene();
            changed = true;
        }

        //Highlight
        private void setHighlight()
        {   
            if (testing)
            {
                listBox1.SelectedIndex = -1; 
                scene.Highlight = Rectangle.Empty;
                Type = "";
                setContext();
                return;
            }
            if (listBox1.SelectedItem is Ball)
            {
                Ball ball = ((Ball)listBox1.SelectedItem);
                Rectangle rect = new Rectangle(ball.Center.X - ball.Radius, ball.Center.Y - ball.Radius, ball.Radius * 2, ball.Radius * 2);
                rect.Inflate(3, 3);
                scene.Highlight = rect;
                Type = "Ball";
            }
            else if (listBox1.SelectedItem is Player)
            {
                Player player = (Player)listBox1.SelectedItem;
                Rectangle rect = new Rectangle(player.Position, 308, 50, 50);
                rect.Inflate(3, 3);
                scene.Highlight = rect;
                scene.HighlightType = "Circle";
                Type = "Player";
            }
            else if (listBox1.SelectedItem is Obstacle)
            {
                Obstacle obstacle = (Obstacle)listBox1.SelectedItem;
                Rectangle rect = obstacle.Bounds;
                rect.Inflate(3, 3);
                scene.Highlight = rect;
                scene.HighlightType = "Rectangle";
                Type = "Obstacle";
            }else if (listBox1.SelectedItem is null)
            {
                scene.Highlight = Rectangle.Empty;
                Type = "";
            }
            setContext();
        }
        //Mouse Controls
        //Add object and select
        private bool inBounds(Point p)
        {
            Rectangle bounds = new Rectangle(0, 27, panelGame.Width, panelGame.Height);
            return bounds.Contains(p);
        }
        private void FormLE_MouseClick(object sender, MouseEventArgs e)
        {
            if (!inBounds(e.Location) || testing)
                return;
            Point p = new Point(e.Location.X, e.Location.Y - 27);
            if (e.Button == MouseButtons.Left)
            {
                String type = cbObjectType.SelectedItem.ToString();
                if (type == "Ball")
                {
                    scene.Balls.Add(new Ball(7, p, 1));
                }
                else if (type == "Obstacle")
                {
                    scene.Obstacles.Add(new Obstacle(p, 100, 100));
                }
                else if (type == "Player" && !scene.TwoPlayers)
                {
                    scene.TwoPlayers = true;
                    scene.PlayerTwo = new Player(p.X, 2);
                }
                initScene();
            }
            else if (e.Button == MouseButtons.Right)
            {
                listBox1.SelectedItem = scene.Select(p);
            }
            changed = true;
        }
        //Draging
        private Point dragStart = Point.Empty;
        private bool dragging = false;
        private void FormLE_MouseDown(object sender, MouseEventArgs e)
        {
            if (!inBounds(e.Location))
                return;
            Point p = new Point(e.Location.X, e.Location.Y - 27);
            if (e.Button == MouseButtons.Middle)
            {
                dragStart = p;
                dragging = true;
                timer1.Start();
                this.Cursor = Cursors.Hand;
            }
        }

        private void FormLE_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                dragStart = Point.Empty;
                dragging = false;
                this.Cursor = Cursors.Default;
            }
        }

        private void FormLE_MouseMove(object sender, MouseEventArgs e)
        {
            if (!dragging)
                return; 
            
            if (!inBounds(e.Location))
                return;
            Point p = new Point(e.Location.X, e.Location.Y - 27);

            if (listBox1.SelectedItem is Ball)
            {
                Ball ball = ((Ball)listBox1.SelectedItem);
                ball.Center = new Point(ball.Center.X - (dragStart.X - p.X), ball.Center.Y - (dragStart.Y - p.Y));
                dragStart = p;
            }
            else if (listBox1.SelectedItem is Player)
            {
                Player player = (Player)listBox1.SelectedItem;
                player.Position = player.Position - (dragStart.X - p.X);
                dragStart = p;
            }
            else if (listBox1.SelectedItem is Obstacle)
            {
                Obstacle obstacle = (Obstacle)listBox1.SelectedItem;
                obstacle.Bounds = new Rectangle(
                    obstacle.Bounds.X - (dragStart.X - p.X),
                    obstacle.Bounds.Y - (dragStart.Y - p.Y),
                    obstacle.Bounds.Width, obstacle.Bounds.Height
                    );
                dragStart = p;
            }
            setHighlight();
            changed = true;
        }

        //Drawing scene
        private bool changed = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (changed)
            {
                changed = false;
                Invalidate(true);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(scene.Balls.Count == 0)
            {
                timer2.Stop();
                return;
            }
            scene.Tick();

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

        //Serialization
        private String FileName = "";
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String oldFileName = FileName;
            FileName = "";
            if (!SaveFile())
            {
                FileName = oldFileName;
            }
            else
            {
                changed = true;
            }
        }
        private bool SaveFile()
        {
            if (FileName == "")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "BubbleTroubleLevel File (*.btl)|*.btl";
                saveFileDialog.Title = "Save a BubbleTroubleLevel File";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileName = saveFileDialog.FileName;
                }
                else
                {
                    return false;
                }
            }
            FileStream fstream = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None);
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fstream, scene);
            fstream.Close();
            return true;
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "BubbleTroubleLevel File (*.btl)|*.btl";
            openFileDialog.Title = "Open a BubbleTroubleLevel File";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileName = openFileDialog.FileName;
            }
            FileStream fstream = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.None);
            IFormatter formatter = new BinaryFormatter();
            this.scene = (Scene) formatter.Deserialize(fstream);
            fstream.Close();
            initScene();
            changed = true;
        }

        //Keyboard Controls
        private bool testing = false;
        private void FormLE_KeyDown(object sender, KeyEventArgs e)
        {            
            if (testing)
            {
                PlayerControl(e);
            }
            else
            {
                if (e.KeyCode == Keys.Delete)
                {
                    scene.RemoveDrawable((Drawable)listBox1.SelectedItem);
                    listBox1.SelectedIndex = -1;
                    setContext();
                    initScene();
                    setHighlight();
                    changed = true;
                }
            }
        }

        private bool second;
        private bool moveRight1;
        private bool moveRight2;
        private bool moveLeft1;
        private bool moveLeft2;
        private void PlayerControl(KeyEventArgs e)
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
            if (second)
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
                        scene.PlayerOne.Harpoon.startingX = scene.PlayerTwo.Position + 24;
                    }
                    scene.PlayerTwo.IsShooting = true;
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                timer2.Enabled = !timer2.Enabled;
            }
            Invalidate();
        }

        private void FormLE_KeyUp(object sender, KeyEventArgs e)
        {
            if(testing)
                playerMoveKeyUp(e);
        }
        private void playerMoveKeyUp(KeyEventArgs e)
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
            if (second)
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new FormMainMenu();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }
        //Playtesting
        private Scene oldScene = null;
        private void btnPlayTest_Click(object sender, EventArgs e)
        {
            testing = !testing;
            if (testing)
            {
                oldScene = new Scene(scene);
                listBox1.Enabled = false;
                cbObjectType.Enabled = false;
                setHighlight();
                timer2.Enabled = true;
                timer2.Start();
                timer1.Stop();
                timer1.Enabled = false;
                btnPlayTest.Text = "STOP";
            }else
            {
                scene = oldScene;
                initScene();
                listBox1.Enabled = true;
                cbObjectType.Enabled = true;
                setHighlight();
                timer2.Enabled = false;
                timer2.Stop();
                timer1.Start();
                timer1.Enabled = true;
                btnPlayTest.Text = "PLAYTEST";
                changed = true;
            }
        }
    }
}
