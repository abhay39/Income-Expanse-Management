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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Users u = new Users();
            u.Show();
            this.Hide();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\abhay\Documents\Expanse_db.mdf;Integrated Security=True;Connect Timeout=30");
        public static string User;
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if(username.Text==""|| password.Text == "")
            {
                MessageBox.Show("Missing Information..");
            }
            else { 
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from UserTbl where UName = '" + username.Text + "' and UPass='" + password.Text+"'",Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString()== "1")
            {
                User = username.Text;
                Dashboard dh = new Dashboard();
                dh.Show();
                this.Hide();
                Con.Close();
            }
            else
            {
                MessageBox.Show("Wrong username or password!!");
                username.Text = "";
                password.Text = " ";
            }
            Con.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
