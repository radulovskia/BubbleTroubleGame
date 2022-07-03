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
    public partial class FormMainMenu : Form
    {
        public FormMainMenu()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new FormGame(false);
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
            Form form2 = new FormGame(true);
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form2 = new FormLevelMenu();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }
    }
}
