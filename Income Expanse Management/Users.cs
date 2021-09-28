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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\abhay\Documents\Expanse_db.mdf;Integrated Security=True;Connect Timeout=30");
        private void clear()
        {
            Unametb.Text = " ";
            UPhonetb.Text = " ";
            Upasswordtb.Text = " ";
            Uaddresstb.Text = " ";
        }
        private void Addbtn_Click(object sender, EventArgs e)
        {
            if(Unametb.Text==" " || UPhonetb.Text==" " || Upasswordtb.Text==" "|| Uaddresstb.Text==" ")
            {
                MessageBox.Show("Missing Information.");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into UserTbl(UName,UDob,UPhone,UPass,UAddress)values(@UN, @UD, @UP, @UPP, @UA)", Con);
                    cmd.Parameters.AddWithValue("@UN", Unametb.Text);
                    cmd.Parameters.AddWithValue("@UD", Udob.Value.Date);
                    cmd.Parameters.AddWithValue("@UP", UPhonetb.Text);
                    cmd.Parameters.AddWithValue("@UPP", Upasswordtb.Text);
                    cmd.Parameters.AddWithValue("@UA", Uaddresstb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Added Successfully..");
                    Con.Close();
                    clear();
                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Udob_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            this.Hide();
            l.Show();
        }
    }
}
