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
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.draw(e.Graphics);
        }
    }
}
