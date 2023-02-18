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
    public partial class Fees : Form
    {
        public Fees()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\OneDrive\Documents\Unidb.mdf;Integrated Security=True;Connect Timeout=30");
        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void updatestd()
        {
            Con.Open();
            string query = "update StudentTb set StdFees = " + AmountTb.Text + " where StdId=" + stdId.Text + ";";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            //MessageBox.Show("User Updated Successfully");
            Con.Close();
        }
        private void Fees_Load(object sender, EventArgs e)
        {
            populate();
        }
        private void populate()
        {
            Con.Open();
            string query = "select* from FeesTb";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            FeeDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (Num.Text == "" || stdName.Text == "" || AmountTb.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                   String date = PeriodDate.Value.Year.ToString();
                   Con.Open();
                   SqlCommand cmd = new SqlCommand("insert into FeesTb values(" + Num.Text + "," + stdId.Text + ",'" + stdName.Text + "','" + date + "'," + AmountTb.Text + ")",Con);
                   cmd.ExecuteNonQuery();
                   MessageBox.Show("Fees Successfully Added");
                   Con.Close();
                   populate();
                   updatestd();
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Mainform home = new Mainform();
            home.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

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
                    string query = "delete from FeesTb where FeesNum= '" + Num.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Fees Deleted Successfully");
                    Con.Close();
                    populate();
                }
            }
            catch
            {
                MessageBox.Show("oops... Fees Not Deleted");
            }
        }

        private void FeeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Num.Text = FeeDGV.SelectedRows[0].Cells[0].Value.ToString();
            stdId.Text = FeeDGV.SelectedRows[0].Cells[1].Value.ToString();
            stdName.Text = FeeDGV.SelectedRows[0].Cells[2].Value.ToString();
            AmountTb.Text = FeeDGV.SelectedRows[0].Cells[4].Value.ToString();

            if(printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void Num_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Num.Text == "" || stdId.Text == "" || stdName.Text == "")
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    Con.Open();
                    string query = "update FeesTb set FeesNum = '" + Num.Text + "',StdName= '" + stdName.Text + "',period='"+PeriodDate.Text+"',Amount='"+AmountTb.Text+"' where StdId='" + stdId.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Fees Updated Successfully");
                    Con.Close();
                    populate();
                }
            }
            catch
            {
                MessageBox.Show("oops... Fees Not Updated");
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("FEES RECEIPT", new Font("century", 25, FontStyle.Bold), Brushes.Red, new Point(230,80));
            e.Graphics.DrawString("Receipt NO:", new Font("century", 20, FontStyle.Bold), Brushes.Blue, new Point(80,300));
            e.Graphics.DrawString(FeeDGV.SelectedRows[0].Cells[0].Value.ToString(), new Font("century", 20, FontStyle.Bold), Brushes.Black, new Point(310, 300));
            e.Graphics.DrawString("Student No ", new Font("century", 20, FontStyle.Bold), Brushes.Blue, new Point(80, 400));
            e.Graphics.DrawString(FeeDGV.SelectedRows[0].Cells[1].Value.ToString(), new Font("century", 20, FontStyle.Bold), Brushes.Black, new Point(310, 400));
            e.Graphics.DrawString("Student Name:", new Font("century", 20, FontStyle.Bold), Brushes.Blue, new Point(80, 500));
            e.Graphics.DrawString(FeeDGV.SelectedRows[0].Cells[2].Value.ToString(), new Font("century", 20, FontStyle.Bold), Brushes.Black, new Point(310, 500));
            e.Graphics.DrawString("Student period:", new Font("century", 20, FontStyle.Bold), Brushes.Blue, new Point(80, 600));
            e.Graphics.DrawString(FeeDGV.SelectedRows[0].Cells[3].Value.ToString(), new Font("century", 20, FontStyle.Bold), Brushes.Black, new Point(310, 600));
            e.Graphics.DrawString("Amount:", new Font("century", 20, FontStyle.Bold), Brushes.Blue, new Point(80, 700));
            e.Graphics.DrawString("Rs:"+FeeDGV.SelectedRows[0].Cells[4].Value.ToString(), new Font("century", 20, FontStyle.Bold), Brushes.Black, new Point(310, 700));
            e.Graphics.DrawString("Vista University College", new Font("century", 25, FontStyle.Italic), Brushes.Blue, new Point(230, 800));
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Num.Clear();
            stdId.Clear();
            stdName.Clear();
            AmountTb.Clear();
        }
    }
}
