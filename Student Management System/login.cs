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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\OneDrive\Documents\Unidb.mdf;Integrated Security=True;Connect Timeout=30");
        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            Mainform home = new Mainform();                
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from UserTb where userName='"+mskUName.Text+"' and password='"+mskpass.Text+"'",Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows[0][0].ToString() == "1")
            {
                userlogin.userName = mskUName.Text;
                home.Show();
                this.Hide();
                Con.Close();
            }
            else
            {
                MessageBox.Show("Invalid UserName Or Password");
            }
            Con.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void mskUName_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void CBshowpw_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void cbShowpass_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowpass.Checked)
            {
                mskpass.UseSystemPasswordChar = true;
            }
            else
            {
                mskpass.UseSystemPasswordChar = false;
            }
        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            mskUName.Clear();
            mskpass.Clear();
        }
    }
}
