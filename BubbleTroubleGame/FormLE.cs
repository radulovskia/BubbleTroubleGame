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
    public partial class FormLE : Form
    {
        public Scene scene;
        public FormLE()
        {
            InitializeComponent();
            scene = new Scene(true);
            this.DoubleBuffered = true;
            Invalidate();
            foreach (Ball ball in scene.balls)
                listBox1.Items.Add(ball);
            listBox1.Items.Add(scene.playerOne);
            timer1.Start();
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                scene.balls.Add(new Ball(10, new Point(e.X, e.Y), 0));
            } else if(e.Button == MouseButtons.Right)
            {
                //scene.Select(new Point(e.X, e.Y));
            }
            changed = true;
        }

        private void FormLE_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panelGame_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.Clear(Color.White);
            Bitmap bmp = new Bitmap(panelGame.Width, panelGame.Height);
            scene.draw(Graphics.FromImage(bmp));
            e.Graphics.DrawImageUnscaled(bmp, 0, 0);

            //scene.draw(e.Graphics);
        }

        protected override CreateParams CreateParams { 
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setHighlight();
            changed = true;
        }
        private void setHighlight()
        {
            if (listBox1.SelectedItem is Ball)
            {
                Ball ball = ((Ball)listBox1.SelectedItem);
                Rectangle rect = new Rectangle(ball.Center.X - ball.Radius, ball.Center.Y - ball.Radius, ball.Radius * 2, ball.Radius * 2);
                rect.Inflate(3, 3);
                scene.Highlight = rect;
                //listBox1.Items.Clear();
                //foreach (Ball ball1 in scene.balls)
                //    listBox1.Items.Add(ball1);
            }
            else if (listBox1.SelectedItem is Player)
            {
                Player player = (Player)listBox1.SelectedItem;
                Rectangle rect = new Rectangle(player.position, 300, 50, 50);
                rect.Inflate(3, 3);
                scene.Highlight = rect;
            }
        }
        private Point dragStart = Point.Empty;
        private bool dragging = false;
        private void panelGame_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Middle)
            {
                dragStart = e.Location;
                dragging = true;
                timer1.Start();
                this.Cursor = Cursors.Hand;
            }
        }

        private void panelGame_MouseMove(object sender, MouseEventArgs e)
        {
            if (!dragging)
                return;
            if (listBox1.SelectedItem is Ball)
            {
                Ball ball = ((Ball)listBox1.SelectedItem);
                ball.Center = new Point(ball.Center.X - (dragStart.X - e.Location.X), ball.Center.Y - (dragStart.Y - e.Location.Y));
                dragStart = e.Location;
            }
            else if (listBox1.SelectedItem is Player)
            {
                Player player = (Player)listBox1.SelectedItem;
                Rectangle rect = new Rectangle(player.position, 300, 50, 50);
                rect.Inflate(3, 3);
                scene.Highlight = rect;
            }
            setHighlight();
            changed = true;
        }

        private void panelGame_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                dragStart = Point.Empty;
                dragging = false;
                this.Cursor = Cursors.Default;
            }
        }
        private bool changed = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (changed)
            {
                changed = false;
                Invalidate(true);
            }
        }
        // ListBox gi ima site elementi sto mozat da bidat dodadeni, se otvara na tab
        // Move ke bide so middle mouse
        // Ke ima izbor za vrednosti vo zavisnost od sto e selektirano

    }
}
