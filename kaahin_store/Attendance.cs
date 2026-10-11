using Microsoft.SqlServer.Server;
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
    public partial class Attendance : Form
    {
        public Attendance()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            new Employee().Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            new dashboard().Show(); this.Hide();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            new login().Show(); this.Hide();
        }

        private void Attendance_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            comstatus.Items.Insert(0, "Status");
            comstatus.SelectedIndex = 0;
            att();
        }

        private void hireDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
        }
        void att()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=KaahinStoreDB;Integrated Security=true");

            SqlDataAdapter da = new SqlDataAdapter("select * from Attendance", conn);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtempid.Text) ||
    string.IsNullOrWhiteSpace(comstatus.Text))
            {
                MessageBox.Show("all field required", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=KaahinStoreDB;Integrated Security=true");

                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Attendance(EmployeeId, AttendanceDate, CheckIn, CheckOut, Status)values(@empID, @attDate, @checkIn, @checkOut, @status)", conn);

                cmd.Parameters.AddWithValue("@empID", txtempid.Text);
                cmd.Parameters.AddWithValue("@attDate", DateTime.Parse(dateEmp.Text));
                cmd.Parameters.AddWithValue("@checkIn", DateTime.Parse(checkIn.Text));
                cmd.Parameters.AddWithValue("@checkOut", DateTime.Parse(checkOut.Text));
                cmd.Parameters.AddWithValue("@status",comstatus.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("attendence saved successfully", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                att();
                conn.Close();

                txtempid.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            att();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=KaahinStoreDB;Integrated Security=true");


                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["AttendanceId"].Value);


                SqlCommand cmd = new SqlCommand("delete from Attendance where AttendanceId=@id", conn);

                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("delete Attendance success", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                att();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=KaahinStoreDB;Integrated Security=true");

            SqlCommand cmd = new SqlCommand("select * from Attendance where AttendanceId='" + txtsearch.Text + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=KaahinStoreDB;Integrated Security=true");


                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["AttendanceId"].Value);


                SqlCommand cmd = new SqlCommand("update Attendance set EmployeeId=@empId ,AttendanceDate=@attDate, CheckIn=@CheckIn, CheckOut=@CheckOut, Status=@Status where AttendanceId=@ID", conn);

                cmd.Parameters.AddWithValue("@empId", txtempid.Text);
                cmd.Parameters.AddWithValue("@attDate", DateTime.Parse(dateEmp.Text));
                cmd.Parameters.AddWithValue("@CheckIn", DateTime.Parse(checkIn.Text));
                cmd.Parameters.AddWithValue("@CheckOut", DateTime.Parse(checkOut.Text));
                cmd.Parameters.AddWithValue("@Status", comstatus.Text);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update employee success", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                att();


                txtempid.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
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
