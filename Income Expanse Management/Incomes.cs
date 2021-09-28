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
    public partial class Incomes : Form
    {
        public Incomes()
        {
            InitializeComponent();
            GetTotlInc();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            ViewIncome ic = new ViewIncome();
            ic.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Dashboard ic = new Dashboard();
            ic.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\abhay\Documents\Expanse_db.mdf;Integrated Security=True;Connect Timeout=30");
        public void clear()
        {
            Incname.Text = "";
            incamount.Text = "";
            incdesc.Text = "";
            inccat.SelectedIndex = 0;
        }
        private void incsave_Click(object sender, EventArgs e)
        {
            if (Incname.Text == " " || incamount.Text == " " || incdesc.Text == " " || inccat.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information.");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into IncomeTbl(IncName,IncAmt,IncCat,IncDate,IncDes,IncUser)values(@IN,@IA,@IC,@ID,@IDS,@IU)", Con);
                    cmd.Parameters.AddWithValue("@IN", Incname.Text);
                    cmd.Parameters.AddWithValue("@IA", incamount.Text);
                    cmd.Parameters.AddWithValue("@IC", inccat.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ID", incdate.Value.Date);
                    cmd.Parameters.AddWithValue("@IDS", incdesc.Text);
                    cmd.Parameters.AddWithValue("@IU", Login.User);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Income Added Successfully..");
                    GetTotlInc();
                    Con.Close();
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            ViewExpanses ic = new ViewExpanses();
            ic.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Expanse ic = new Expanse();
            ic.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }
        private void GetTotlInc()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Sum(IncAmt) from IncomeTbl where IncUser = '" + Login.User + "'", Con);
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
    
