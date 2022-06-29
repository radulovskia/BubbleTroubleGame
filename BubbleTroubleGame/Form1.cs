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
            foreach(Ball b in scene.balls)
            {
                b.Move(this.Height);
            }
            Invalidate();
        }
    }
}
