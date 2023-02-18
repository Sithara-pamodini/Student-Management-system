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
    public partial class Departments : Form
    {
        public Departments()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\OneDrive\Documents\Unidb.mdf;Integrated Security=True;Connect Timeout=30");

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void populate()
        {
            Con.Open();
            string query = "select* from DepartmentTb1";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DepartmentDGV.DataSource = ds.Tables[0];
            Con.Close();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (DepNameTb.Text == "" || DepDescTb.Text == "" || DepDurationTb.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into DepartmentTb1 values('" + DepNameTb.Text + "','" + DepDescTb.Text + "','" + DepDurationTb.Text + "')", Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Department Successfully Added");
                    Con.Close();
                    populate();

                }
            }
            catch
            {
                MessageBox.Show("Something Went Wrong");
            }
        }

        private void Departments_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void DepDurationTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (DepNameTb.Text == "")
                {
                    MessageBox.Show("Enter The Department Name");
                }
                else
                {
                    Con.Open();
                    string query = "delete from DepartmentTb1 where DepName= '" + DepNameTb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Department Deleted Successfull");
                    Con.Close();
                    populate();
                }
            }
            catch
            {
                MessageBox.Show("oops... Department Not Deleted");
            }
        }

        private void DepartmentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DepNameTb.Text = DepartmentDGV.SelectedRows[0].Cells[0].Value.ToString();
            DepDescTb.Text = DepartmentDGV.SelectedRows[0].Cells[1].Value.ToString();
            DepDurationTb.Text = DepartmentDGV.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (DepNameTb.Text == "" || DepDescTb.Text == "" || DepDurationTb.Text == "")
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    Con.Open();
                    string query = "update DepartmentTb1 set DepDescription = '" + DepDescTb.Text + "',DepDuration= " + DepDurationTb.Text + " where DepName='" + DepNameTb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Department Updated Successfully");
                    Con.Close();
                    populate();
                }
            }
            catch
            {
                MessageBox.Show("oops... Department Not Updated");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Mainform home = new Mainform();
            home.Show();
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DepDescTb.Clear();
            DepDurationTb.Clear();
            DepNameTb.Clear();
            
        }
    }
}
