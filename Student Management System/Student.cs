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
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\OneDrive\Documents\Unidb.mdf;Integrated Security=True;Connect Timeout=30");
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (stdId.Text == "")
                {
                    MessageBox.Show("Enter The Student's ID");
                }
                else
                {
                    Con.Open();
                    string query = "delete from StudentTb where StdId= '" + stdId.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Deleted Successfully");
                    Con.Close();
                    populate();
                }
            }
            catch
            {
                MessageBox.Show("oops... Student Not Deleted");
            }
        }
        private void populate()
        {
            Con.Open();
            string query = "select* from StudentTb";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            StuDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void noduelist()
        {
            Con.Open();
            string query = "select* from StudentTb where StdFees > "+0+"";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            StuDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (stdId.Text == "" || stdName.Text == "" || stdPhone.Text == "" || stdFee.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into StudentTb values(" + stdId.Text + ",'" + stdName.Text + "','" + GenderCb.SelectedItem.ToString() + "','" + Date.Text + "','" + stdPhone.Text + "','" + DepCb.SelectedItem.ToString() + "','" + stdFee.Text + "')", Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Successfully Added");
                    Con.Close();
                    populate();

                }
            }
            catch
            {
                MessageBox.Show("Something Went Wrong");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Student_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (stdId.Text == "" || stdName.Text == "" || stdPhone.Text == "" || stdFee.Text == "")
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    Con.Open();
                    string query = "update StudentTb set StdName = '" + stdName.Text + "',stdGender= '" + GenderCb.SelectedItem.ToString() + "', StdDOB='" + Date.Text + "', StdPhone='" + stdPhone.Text + "', StdDep='" + DepCb.SelectedItem.ToString() + "',StdFees='" + stdFee.Text + "' where StdId=" + stdId.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Updated Successfully");
                    Con.Close();
                    populate();
                }
            }
            catch
            {
                MessageBox.Show("oops... Student Not Updated");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StuDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            stdId.Text = StuDGV.SelectedRows[0].Cells[0].Value.ToString();
            stdName.Text = StuDGV.SelectedRows[0].Cells[1].Value.ToString();
            GenderCb.SelectedItem = StuDGV.SelectedRows[0].Cells[2].Value.ToString();
            Date.Text = StuDGV.SelectedRows[0].Cells[3].Value.ToString();
            stdPhone.Text = StuDGV.SelectedRows[0].Cells[4].Value.ToString();
            DepCb.SelectedItem = StuDGV.SelectedRows[0].Cells[5].Value.ToString();
            stdFee.Text = StuDGV.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Mainform home = new Mainform();
            home.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            noduelist();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void stdId_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            stdName.Clear();
            stdId.Clear();
            stdPhone.Clear();
            stdFee.Clear();
            stdFee.Clear();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
