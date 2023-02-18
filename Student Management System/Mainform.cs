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
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Professors pro = new Professors();
            pro.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student std = new Student();
            std.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Fees payment = new Fees();
            payment.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Departments dep = new Departments();
            dep.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UserForm us = new UserForm();
            us.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            login lg = new login();
            lg.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Dashboard db = new Dashboard();
            db.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {
           
        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            lblUser.Text = userlogin.userName;
        }
    }
}
