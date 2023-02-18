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
    public partial class Professors : Form
    {
        public Professors()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\OneDrive\Documents\Unidb.mdf;Integrated Security=True;Connect Timeout=30");

        
        private void Professors_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void populate()
        {
            Con.Open();
            string query = "select* from ProfessorTb";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (PId.Text == "" || PName.Text == "" || PPoneTb.Text == "" || Address.Text=="" )
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into ProfessorTb values(" + PId.Text + ",'" + PName.Text + "','" + GenderCb.SelectedItem.ToString() + "','"+Date.Text+"','"+PPoneTb.Text+"','"+DepCb.SelectedItem.ToString()+"','"+Address.Text+"')", Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Professor Successfully Added");
                    Con.Close();
                    populate();

                }
            }
            catch
            {
                MessageBox.Show("Something Went Wrong");
            }
        }

        private void ProDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PId.Text = ProDGV.SelectedRows[0].Cells[0].Value.ToString();
            PName.Text = ProDGV.SelectedRows[0].Cells[1].Value.ToString();
            GenderCb.SelectedItem = ProDGV.SelectedRows[0].Cells[2].Value.ToString();
            PPoneTb.Text = ProDGV.SelectedRows[0].Cells[4].Value.ToString();
            DepCb.SelectedItem = ProDGV.SelectedRows[0].Cells[5].Value.ToString();
            Address.Text = ProDGV.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (PId.Text == "")
                {
                    MessageBox.Show("Enter The Professor's ID");
                }
                else
                {
                    Con.Open();
                    string query = "delete from ProfessorTb where Prof_Id= '" + PId.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Professor Deleted Successfull");
                    Con.Close();
                    populate();
                }
            }
            catch
            {
                MessageBox.Show("oops... Professor Not Deleted");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (PId.Text == "" || PName.Text == "" || Address.Text == "" || PPoneTb.Text=="")
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    Con.Open();
                    string query = "update ProfessorTb set Prof_Name = '" + PName.Text + "',Prof_Gender= '" + GenderCb.SelectedItem.ToString() + "', Prof_DOB='"+Date.Text+"', Prof_Phone='"+PPoneTb.Text+"', Prof_Dep='"+DepCb.SelectedItem.ToString()+"',Prof_Add='"+Address.Text+"' where Prof_Id='" + PId.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Professor Updated Successfully");
                    Con.Close();
                    populate();
                }
            }
            catch
            {
                MessageBox.Show("oops... Professor Not Updated");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Mainform home = new Mainform();
            home.Show();
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            PId.Clear();
            PName.Clear();
            PPoneTb.Clear();
            Address.Clear();
           
        }
    }
}
