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
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void UNameTb_TextChanged(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\OneDrive\Documents\Unidb.mdf;Integrated Security=True;Connect Timeout=30");
        private void UserForm_Load(object sender, EventArgs e)
        {
            populate();
        }
        private void populate()
        {
            Con.Open();
            string query = "select* from UserTb";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            UserDGV.DataSource = ds.Tables[0];
            Con.Close();
            
        }
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if(UIdTb.Text== "" || UnameTb.Text=="" || UpassTb.Text=="" )
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into UserTb values("+ UIdTb.Text + ",'"+UnameTb.Text +"','"+UpassTb.Text+"')", Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Successfully Added");
                    Con.Close();
                    populate(); 

                }
            }
            catch
            {
                MessageBox.Show("Something Went Wrong!");
            }
        }

        private void UserDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UIdTb.Text = UserDGV.SelectedRows[0].Cells[0].Value.ToString();
            UnameTb.Text = UserDGV.SelectedRows[0].Cells[1].Value.ToString();
            UpassTb.Text = UserDGV.SelectedRows[0].Cells[2].Value.ToString();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(UIdTb.Text =="")
                {
                    MessageBox.Show("Enter The User Name");
                }
                else
                {
                    Con.Open();
                    string query = "delete from UserTb where UserId= " + UIdTb.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Deleted Successfull");
                    Con.Close();
                    populate();
                }
            }
            catch
            {
                MessageBox.Show("oops... User Not Deleted");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (UIdTb.Text == "" || UnameTb.Text == "" || UpassTb.Text == "")
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    Con.Open();
                    string query = "update UserTb set UserName = '"+UnameTb.Text+"',password= '"+UpassTb.Text+"' where UserId="+UIdTb.Text+";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Updated Successfully");
                    Con.Close();
                    populate();
                }
            }
            catch
            {
                MessageBox.Show("oops... User Not Edited");
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
            UIdTb.Clear();
            UnameTb.Clear();
            UpassTb.Clear();
           
        }
    }
}
