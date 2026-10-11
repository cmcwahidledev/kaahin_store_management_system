using supermarket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kaahin_store
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            new login().Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            new SalaryReport().Show(); this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            new Attendance().Show(); this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            new Employee().Show(); this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            new dashboard().Show(); this.Hide();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedItem.ToString() == "EMPLOYEE")
            {
                report_employee rpt = new report_employee();
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (guna2ComboBox1.SelectedItem.ToString() == "ATTENDENCE")
            {
                report_attendence rpt=new report_attendence();
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (guna2ComboBox1.SelectedItem.ToString() == "SALARYREPORT")
            {
                report_salaryReport rpt = new report_salaryReport();
                crystalReportViewer1.ReportSource = rpt;
            }
           
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            guna2ComboBox1.Items.Insert(0, "Choose select");
            guna2ComboBox1.SelectedIndex = 0;
        }
    }
}
