using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Student_Management_System
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\OneDrive\Documents\Unidb.mdf;Integrated Security=True;Connect Timeout=30");
        private void Dashboard_Load(object sender, EventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda1 = new SqlDataAdapter("select count(*) from StudentTb ",Con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            Stdlbl.Text = dt1.Rows[0][0].ToString();

            SqlDataAdapter sda2 = new SqlDataAdapter("select count(*) from ProfessorTb ", Con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            Prolbl.Text = dt2.Rows[0][0].ToString();

            SqlDataAdapter sda3 = new SqlDataAdapter("select count(*) from FeesTb ", Con);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            Feelbl.Text = "Rs:" +Convert.ToInt32 (dt3.Rows[0][0].ToString())*25000;

            SqlDataAdapter sda4 = new SqlDataAdapter("select count(*) from DepartmentTb1 ", Con);
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);
            Deplbl.Text = dt4.Rows[0][0].ToString();
            Con.Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Mainform home = new Mainform();
            home.Show();
            this.Hide();
        }
    }
}
