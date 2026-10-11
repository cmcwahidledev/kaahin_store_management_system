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
using System.Xml.Linq;

namespace kaahin_store
{
    public partial class SalaryReport : Form
    {
        public SalaryReport()
        {
            InitializeComponent();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            new Attendance().Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            new Employee().Show();
            this.Hide();
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

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            new Reports().Show(); this.Hide();
        }

        void srt()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=KaahinStoreDB;Integrated Security=true");

            SqlDataAdapter da = new SqlDataAdapter("select * from SalaryReport", conn);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtempid.Text) ||
                string.IsNullOrWhiteSpace(txtmname.Text) ||
                string.IsNullOrWhiteSpace(txtpresent.Text) ||
                string.IsNullOrWhiteSpace(txtnetsalary.Text))
            {
                MessageBox.Show("all field required", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=KaahinStoreDB;Integrated Security=true");

                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into SalaryReport(EmployeeId, MonthName, TotalPresent, TotalAbsent, TotalLate, NetSalary)values(@empID, @mname, @present, @absent, @late, @nsalary)", conn);

                cmd.Parameters.AddWithValue("@empID", txtempid.Text);
                cmd.Parameters.AddWithValue("@mname", txtmname.Text);
                cmd.Parameters.AddWithValue("@present", txtpresent.Text);
                cmd.Parameters.AddWithValue("@absent", txtabsent.Text);
                cmd.Parameters.AddWithValue("@late", txtlate.Text);
                cmd.Parameters.AddWithValue("@nsalary",txtnetsalary.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("SalaryReport saved successfully", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                srt();
                conn.Close();

                txtempid.Clear();
                txtmname.Clear();
                txtpresent.Clear();
                txtabsent.Clear();
                txtlate.Clear();
                txtnetsalary.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            srt();
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    txtempid.Text = row.Cells["EmployeeId"].Value.ToString();
                    txtmname.Text = row.Cells["MonthName"].Value.ToString();
                    txtpresent.Text = row.Cells["TotalPresent"].Value.ToString();
                    txtabsent.Text = row.Cells["TotalAbsent"].Value.ToString();
                    txtlate.Text = row.Cells["TotalLate"].Value.ToString();
                    txtnetsalary.Text = row.Cells["NetSalary"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SalaryReport_Load(object sender, EventArgs e)
        {
            srt();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=KaahinStoreDB;Integrated Security=true");


                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["SalaryId"].Value);


                SqlCommand cmd = new SqlCommand("delete from SalaryReport where SalaryId=@id", conn);

                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("delete SalaryReport success", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                srt();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtempid.Text) ||
                string.IsNullOrWhiteSpace(txtmname.Text) ||
                string.IsNullOrWhiteSpace(txtpresent.Text) ||
                string.IsNullOrWhiteSpace(txtnetsalary.Text))
            {
                MessageBox.Show("all field required", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=KaahinStoreDB;Integrated Security=true");


                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["SalaryId"].Value);
 

                SqlCommand cmd = new SqlCommand("update SalaryReport set EmployeeId=@empID ,MonthName=@mname, TotalPresent=@present, TotalAbsent=@absent, TotalLate=@late, NetSalary=@nsalary where SalaryId=@ID", conn);

                cmd.Parameters.AddWithValue("@empID", txtempid.Text);
                cmd.Parameters.AddWithValue("@mname", txtmname.Text);
                cmd.Parameters.AddWithValue("@present", txtpresent.Text);
                cmd.Parameters.AddWithValue("@absent", txtabsent.Text);
                cmd.Parameters.AddWithValue("@late", txtlate.Text);
                cmd.Parameters.AddWithValue("@nsalary", txtnetsalary.Text);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update salaryReport success", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                srt();


                txtempid.Clear();
                txtmname.Clear();
                txtpresent.Clear();
                txtabsent.Clear();
                txtlate.Clear();
                txtnetsalary.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=KaahinStoreDB;Integrated Security=true");

            SqlCommand cmd = new SqlCommand("select * from salaryReport where SalaryId='" + txtsearch.Text + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
