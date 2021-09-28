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

namespace Income_Expanse_Management
{
    public partial class Expanse : Form
    {
        public Expanse()
        {
            InitializeComponent();
            GetTotlExp();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Dashboard ic = new Dashboard();
            ic.Show();
            this.Hide();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\abhay\Documents\Expanse_db.mdf;Integrated Security=True;Connect Timeout=30");
        public void clear()
        {
            expname.Text = "";
            expamt.Text = "";
            expdesc.Text = "";
            expcat.SelectedIndex = 0;
        }
        private void expbtn_Click(object sender, EventArgs e)
        {
            if (expname.Text == " " || expamt.Text == " " || expdesc.Text == " " || expcat.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information.");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into ExpenseTbl(EmpName,EmpAmt,EmpCat,EmpDate,EmpDes,EmUser)values(@EN,@EA,@EC,@ED,@EDS,@EU)", Con);
                    cmd.Parameters.AddWithValue("@EN", expname.Text);
                    cmd.Parameters.AddWithValue("@EA", expamt.Text);
                    cmd.Parameters.AddWithValue("@EC", expcat.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ED", expdate.Value.Date);
                    cmd.Parameters.AddWithValue("@EDS", expdesc.Text);
                    cmd.Parameters.AddWithValue("@EU", Login.User);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Expanse Added Successfully..");
                    GetTotlExp();
                    Con.Close();
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            ViewExpanses ic = new ViewExpanses();
            ic.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ViewIncome ic = new ViewIncome();
            ic.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Incomes ic = new Incomes();
            ic.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }
        private void GetTotlExp()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Sum(EmpAmt) from ExpenseTbl where EmUser = '" + Login.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Amount.Text = "Rs." + dt.Rows[0][0].ToString();
                Con.Close();
            }
            catch (Exception ex)
            {
                Con.Close();
            }
        }
    }
}

