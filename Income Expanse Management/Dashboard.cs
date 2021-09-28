using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Income_Expanse_Management
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            GetTotlInc();
            GetTotlTrn();
            GetTotlExp();
            GetTotlExpTrn();
            GetTranDate();
            GetInTranDate();
            GetMaxExp();
            GetMaxInc();
            GetMinExp();
            GetMinInc();
            GetBalance();
            GetMaxExpCat();
            GetMaxIncCat();
            user();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\abhay\Documents\Expanse_db.mdf;Integrated Security=True;Connect Timeout=30");
        private void GetTotlInc()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Sum(IncAmt) from IncomeTbl where IncUser = '" + Login.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                inc = Convert.ToInt32(dt.Rows[0][0].ToString());
                totolincblc.Text = "Rs." + dt.Rows[0][0].ToString();
                Con.Close();
            }
            catch(Exception ex)
            {
                Con.Close();
            }
        }
        private void GetTotlTrn()
        {
            try
            {

            
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from IncomeTbl where IncUser = '" + Login.User + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            numinclbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
            }catch(Exception ex)
            {
                Con.Close();
            }
        }
        private void GetTotlExpTrn()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from ExpenseTbl where EmUser = '" + Login.User + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            exptrnlbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void GetTotlExp()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Sum(EmpAmt) from ExpenseTbl where EmUser = '" + Login.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                exp = Convert.ToInt32(dt.Rows[0][0].ToString());
                ttlexp.Text = "Rs." + dt.Rows[0][0].ToString();
                Con.Close();
            }catch(Exception ex)
            {
                Con.Close();
            }
            
        }
        int inc, exp;
        private void GetBalance()
        {
            double bal = inc - exp;
            balance.Text = "Rs." + bal;
            
        }
        private void GetTranDate()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Max(EmpDate) from ExpenseTbl where EmUser = '" + Login.User + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            expdate.Text = "Last Tran Date:" + dt.Rows[0][0].ToString();
            lastexp.Text = dt.Rows[0][0].ToString();
            Con.Close();
        } 
        private void GetInTranDate()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Max(IncDate) from IncomeTbl where IncUser = '" + Login.User + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            indate.Text ="Last Tran Date:"+dt.Rows[0][0].ToString();
            lastinc.Text =dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void GetMaxExpCat()
        {
            try
            {
                Con.Open();
                String InnerQuery = "select Max(EmpAmt) from ExpenseTbl";
                DataTable dt1 = new DataTable();
                SqlDataAdapter sda1 = new SqlDataAdapter(InnerQuery, Con);
                sda1.Fill(dt1);
                String Query = "select EmpCat from ExpenseTbl where EmpAmt = '" + dt1.Rows[0][0].ToString() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                bestexp.Text = dt.Rows[0][0].ToString();
                Con.Close();
            }catch(Exception ex)
            {
                Con.Close();
            }
            
        }
        private void GetMaxIncCat()
        {
            try
            {
                Con.Open();
                String InnerQuery = "select Max(IncAmt) from IncomeTbl";
                DataTable dt1 = new DataTable();
                SqlDataAdapter sda1 = new SqlDataAdapter(InnerQuery, Con);
                sda1.Fill(dt1);
                String Query = "select IncCat from IncomeTbl where IncAmt = '" + dt1.Rows[0][0].ToString() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                bestinc.Text = dt.Rows[0][0].ToString();
                Con.Close();
            }catch(Exception ex)
            {
                Con.Close();
            }
            
        }
        private void GetMaxInc()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Max(IncAmt) from IncomeTbl where IncUser = '" + Login.User + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            maxincome.Text ="Rs."+dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void GetMaxExp()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Max(EmpAmt) from ExpenseTbl where EmUser = '" + Login.User + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            maxexpense.Text ="Rs."+dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void GetMinInc()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Min(IncAmt) from IncomeTbl where IncUser = '" + Login.User + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            minimumincome.Text ="Rs."+dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void GetMinExp()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Min(EmpAmt) from ExpenseTbl where EmUser = '" + Login.User + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            minimumexpans.Text ="Rs."+dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void inclbl_Click(object sender, EventArgs e)
        {
            Incomes ic = new Incomes();
            ic.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Expanse ic = new Expanse();
            ic.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ViewIncome ic = new ViewIncome();
            ic.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            ViewExpanses ic = new ViewExpanses();
            ic.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }
        private void user()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select UName from UserTbl where UName = '" + Login.User + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ur.Text ="User: "+dt.Rows[0][0].ToString();
            Con.Close();
        }
    }
}
