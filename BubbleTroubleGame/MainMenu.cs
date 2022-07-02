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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new Form1(false);
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void LE_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form2 = new FormLE();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form2 = new Form1(true);
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }
    }
}
