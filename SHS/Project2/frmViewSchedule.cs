using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;

namespace SHS
{
    public partial class frmViewSchedule : Form
    {
        public frmViewSchedule()
        {
            InitializeComponent();
        }
        
        string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        private void frmViewSchedule_Load(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(150, 0, 0, 0);
            label10.BackColor = Color.FromArgb(0, 0, 0, 0);

            btnBack.TabStop = false;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;

            btnExit.TabStop = false;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;

            //---DAYS
            int[] days = new int[31];

            for (int i = 0; i < days.Length; i++)
            {
                days[i] = i + 1;
            }

            foreach (int day in days)
            {
                cbxDay.Items.Add(day);
            }
            //---
            
            //---MONTHS
            foreach (string month in months)
            {
                cbxMonth.Items.Add(month);
            }
            //---
            
            //---YEARS
            int[] years = new int[5];

            for (int i = 0; i < years.Length; i++)
            {
                years[i] = 2016 + i;
            }

            foreach (int year in years)
            {
                cbxYear.Items.Add(year);
            }
            //---

            cbxDay.SelectedItem = DateTime.Now.Day;
            cbxMonth.SelectedItem = DateTime.Now.ToString("MMMM");
            cbxYear.SelectedItem = DateTime.Now.Year;
            
            ResetDataSet();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmManageOperations form = new frmManageOperations();
            form.Show();

            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (!frmCalls.onCall)
            {
                Environment.Exit(0);
            }
            else
            {
                MessageBox.Show("Application cannot exit while on a call!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetDataSet()
        {
            if ((cbxDay.SelectedIndex != -1) && (cbxMonth.SelectedIndex != -1) && (cbxYear.SelectedIndex != -1))
            {
                int monthNo = 0;

                for (int i = 0; i < months.Length; i++)
                {
                    if (cbxMonth.SelectedItem.ToString() == months[i])
                    {
                        monthNo = i + 1;
                    }
                }

                string month = monthNo.ToString();
                string day = cbxDay.SelectedItem.ToString();

                if (month.Length == 1)
                {
                    month = "0" + month;
                }

                if (day.Length == 1)
                {
                    day = "0" + day;
                }

                string strDate = cbxYear.SelectedItem + "-" + month + "-" + day;

                List<Schedule> schedule = Schedule.GetScheduleFromDB(strDate);

                dgvSchedule.DataSource = schedule;
                dgvSchedule.Columns["Type"].DisplayIndex = 0;
                dgvSchedule.Columns["DateOfOperation"].DisplayIndex = 4;
                dgvSchedule.Columns["Technician"].Width = 120;
                dgvSchedule.Columns["Priority"].Visible = false;
            }            
        }

        private void cbxDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetDataSet();
        }

        private void cbxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetDataSet();
        }

        private void cbxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetDataSet();
        }
    }
}
