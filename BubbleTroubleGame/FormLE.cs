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
        // ListBox gi ima site elementi sto mozat da bidat dodadeni, se otvara na tab
        // Move ke bide so middle mouse
        // Ke ima izbor za vrednosti vo zavisnost od sto e selektirano

    }
}
