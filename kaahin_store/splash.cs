using supermarket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kaahin_store
{
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            guna2ProgressBar2.Width += 5;
            if(guna2ProgressBar2.Width >= 570)
            {
                timer1.Stop();
                this.Hide();
                new login().Show();
            }
        }
    }
}
