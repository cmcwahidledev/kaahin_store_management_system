using kaahin_store;
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
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }
        void empl()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=KaahinStoreDB;Integrated Security=true");

            SqlDataAdapter da = new SqlDataAdapter("select * from Employees", conn);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void guna2Button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            new login().Show();
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            emp();
            empl();
            pre();
            late();
        }
        private void emp()
        {

            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=KaahinStoreDB;Integrated Security=true");

            SqlCommand cmd = new SqlCommand("select count(*)from Employees", conn);
            conn.Open();
            object result = cmd.ExecuteScalar();
            if (result != DBNull.Value)
            {
                lblemp.Text = result.ToString();
            }
            else
            {
                lblemp.Text = "0";
            }
            conn.Close();
        }
        private void pre()
        {

            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=KaahinStoreDB;Integrated Security=true");

            SqlCommand cmd = new SqlCommand("select sum(TotalPresent)from SalaryReport", conn);
            conn.Open();
            object result = cmd.ExecuteScalar();
            if (result != DBNull.Value)
            {
                lblpre.Text = result.ToString();
            }
            else
            {
                lblpre.Text = "0";
            }
            conn.Close();
        }
        private void late()
        {

            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=KaahinStoreDB;Integrated Security=true");

            SqlCommand cmd = new SqlCommand("select sum(TotalLate)from SalaryReport", conn);
            conn.Open();
            object result = cmd.ExecuteScalar();
            if (result != DBNull.Value)
            {
                lbllate.Text = result.ToString();
            }
            else
            {
                lbllate.Text = "0";
            }
            conn.Close();
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            new Employee().Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            empl();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            new Attendance().Show(); this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            new SalaryReport().Show();
            this.Hide();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            new Reports().Show(); this.Hide();
        }
    }
}
