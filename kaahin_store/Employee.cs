using supermarket;
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

namespace kaahin_store
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            new dashboard().Show();
            this.Hide();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            new login().Show();
            this.Hide();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            emp();
        }
        void emp()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=KaahinStoreDB;Integrated Security=true");

            SqlDataAdapter da = new SqlDataAdapter("select * from Employees", conn);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtname.Text) ||
   string.IsNullOrWhiteSpace(txtphone.Text) ||
   string.IsNullOrWhiteSpace(txtpos.Text) ||
    string.IsNullOrWhiteSpace(txtsalary.Text))
            {
                MessageBox.Show("all field required", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=KaahinStoreDB;Integrated Security=true");

                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Employees(Fullname, Phone, Position, Salary, HireDate)values(@name, @phone, @pos, @salary, @hireDate)", conn);

                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@phone", txtphone.Text);
                cmd.Parameters.AddWithValue("@pos", txtpos.Text);
                cmd.Parameters.AddWithValue("@salary", txtsalary.Text);
                cmd.Parameters.AddWithValue("@hireDate", DateTime.Parse( hireDate.Text));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Employee saved successfully", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                emp();
                conn.Close();

                txtname.Clear();
                txtphone.Clear();
                txtpos.Clear();
                txtsalary.Clear();
            }
            catch (SqlException ex)
            {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            emp();
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    txtname.Text = row.Cells["FullName"].Value.ToString();
                    txtpos.Text = row.Cells["Position"].Value.ToString();
                    txtphone.Text = row.Cells["Phone"].Value.ToString();
                    txtsalary.Text = row.Cells["Salary"].Value.ToString();
                   hireDate.Text = row.Cells["HireDate"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=KaahinStoreDB;Integrated Security=true");


                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["EmployeeId"].Value);


                SqlCommand cmd = new SqlCommand("delete from Employees where EmployeeId=@id", conn);

                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("delete Employee success", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                emp();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtname.Text) ||
string.IsNullOrWhiteSpace(txtphone.Text) ||
string.IsNullOrWhiteSpace(txtpos.Text) ||
string.IsNullOrWhiteSpace(txtsalary.Text))
            {
                MessageBox.Show("all field required", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=KaahinStoreDB;Integrated Security=true");


                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["EmployeeId"].Value);


                SqlCommand cmd = new SqlCommand("update Employees set Fullname=@name ,Phone=@phone, Position=@pos, Salary=@salary, HireDate=@hireDate where EmployeeId=@ID", conn);

                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@Phone", txtphone.Text);
                cmd.Parameters.AddWithValue("@pos", txtpos.Text);
                cmd.Parameters.AddWithValue("@salary", txtsalary.Text);
                cmd.Parameters.AddWithValue("@hireDate", DateTime.Parse(hireDate.Text));
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update employee success", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                emp();


                txtname.Clear();
                txtphone.Clear();
                txtpos.Clear();
                txtsalary.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=KaahinStoreDB;Integrated Security=true");

            SqlCommand cmd = new SqlCommand("select * from Employees where EmployeeId='" + txtsearch.Text + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

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
