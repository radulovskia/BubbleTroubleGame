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
            UpdateView();
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                scene.addBall(new Ball(new Point(e.X, e.Y), 10, 1, 0, 0));
            } else if(e.Button == MouseButtons.Right)
            {
                scene.Select(new Point(e.X, e.Y));
            }
            UpdateView();
        }
        public void UpdateView()
        {
            Bitmap bmp = new Bitmap(panelGame.Width, panelGame.Height);
            scene.draw(Graphics.FromImage(bmp));
            panelGame.CreateGraphics().Clear(Color.White);
            panelGame.CreateGraphics().DrawImageUnscaled(bmp, 0, 0);
        }
        // ListBox gi ima site elementi sto mozat da bidat dodadeni, se otvara na tab
        // Move ke bide so middle mouse
        // Ke ima izbor za vrednosti vo zavisnost od sto e selektirano
    }
}
