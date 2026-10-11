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

namespace supermarket
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
            txtpassword.UseSystemPasswordChar = true;
        }

        private void chckPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtpassword.UseSystemPasswordChar = !chckPassword.Checked;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new login().Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtusername.Text) || 
                string.IsNullOrWhiteSpace(txtemail.Text) ||
                string.IsNullOrWhiteSpace(txtpassword.Text))
            {
                MessageBox.Show("all field required", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=KaahinStoreDB;Integrated Security=true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Users(Username, Email, Password)values(@username, @email, @password)", conn);

                cmd.Parameters.AddWithValue("@username", txtusername.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@password", txtpassword.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Register successfully", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();

                txtusername.Clear();
                txtemail.Clear();
                txtpassword.Clear();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("User already exists", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void register_Load(object sender, EventArgs e)
        {

        }
    }
}
