using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Management_System
{
    public partial class welcome : Form
    {
        public welcome()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        int startprogress = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startprogress += 1;
            ProgressBar1.Value = startprogress;
            if (ProgressBar1.Value == 100)
            {
                ProgressBar1.Value = 0;
                timer1.Stop();

                login log = new login();
                 log.Show();
                this.Hide();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void ProgressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
