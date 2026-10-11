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
using System.Xml.Linq;

namespace supermarket
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            txtpassword.UseSystemPasswordChar = true;
        }

        private void chckPassword_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void chckPassword_CheckedChanged_1(object sender, EventArgs e)
        {
            txtpassword.UseSystemPasswordChar = !chckPassword.Checked;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new register().Show();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtusername.Text) ||
                string.IsNullOrWhiteSpace(txtpassword.Text))
            {
                MessageBox.Show("all field required", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=KaahinStoreDB;Integrated Security=true");

                SqlCommand cmd = new SqlCommand("select * from users where Username=@name and Password=@pass", conn);

                cmd.Parameters.AddWithValue("@name", txtusername.Text);
                cmd.Parameters.AddWithValue("@pass", txtpassword.Text);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("login success", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    new dashboard().Show();

                }
                else
                {
                    MessageBox.Show("username or password is failed", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
    
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
