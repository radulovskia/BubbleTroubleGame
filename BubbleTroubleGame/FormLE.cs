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
            scene = new Scene();
            Invalidate();
            foreach (Ball ball in scene.balls)
                listBox1.Items.Add(ball);
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //scene.addBall(new Ball(10, new Point(e.X, e.Y)));
            } else if(e.Button == MouseButtons.Right)
            {
                //scene.Select(new Point(e.X, e.Y));
            }
            Invalidate();
        }

        private void FormLE_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panelGame_Paint(object sender, PaintEventArgs e)
        {
            scene.draw(e.Graphics);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ball ball = ((Ball)listBox1.SelectedItem);
            ball.Radius += 10;
            Rectangle rect = new Rectangle(ball.Center.X - ball.Radius, ball.Center.Y - ball.Radius, ball.Radius * 2, ball.Radius * 2);
            rect.Inflate(3, 3);
            scene.Highlight = rect;
            //listBox1.Items.Clear();
            //foreach (Ball ball1 in scene.balls)
            //    listBox1.Items.Add(ball1);
            Invalidate(true);
        }
        // ListBox gi ima site elementi sto mozat da bidat dodadeni, se otvara na tab
        // Move ke bide so middle mouse
        // Ke ima izbor za vrednosti vo zavisnost od sto e selektirano

    }
}
