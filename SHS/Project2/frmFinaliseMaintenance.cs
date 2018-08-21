using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHS
{
    public partial class frmFinaliseMaintenance : Form
    {
        int maintenanceID, orderID;
        string productCode, date;

        public frmFinaliseMaintenance(int maintenanceID, int orderID, string productCode, string date)
        {
            InitializeComponent();

            this.maintenanceID = maintenanceID;
            this.orderID = orderID;
            this.productCode = productCode;
            this.date = date;
        }

        private void frmFinaliseMaintenance_Load(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(150, 0, 0, 0);

            btnBack.TabStop = false;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;

            btnExit.TabStop = false;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;

            btnFinalise.TabStop = false;
            btnFinalise.FlatStyle = FlatStyle.Flat;
            btnFinalise.FlatAppearance.BorderSize = 0;

            txtOrderID.Text = orderID.ToString();
            txtProductCode.Text = productCode;
            txtStartDate.Text = date.Substring(0, 10);
            txtEndDate.Text = date.Substring(0, 10);

            List<Technician> technicians = Technician.GetTechnicians();

            foreach (Technician technician in technicians)
            {
                cbxTechnicianID.Items.Add(technician.ID);
            }

            cbxTechnicianID.SelectedIndex = 0;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmManageMaintenances form = new frmManageMaintenances();
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

        private void btnFinalise_Click(object sender, EventArgs e)
        {
            int startHours = int.Parse(txtStartTimeHours.Text);
            int startMinutes = int.Parse(txtStartTimeMinutes.Text);
            int endHours = int.Parse(txtEndTimeHours.Text);
            int endMinutes = int.Parse(txtEndTimeMinutes.Text);

            DateTime dateOfMaintenance = new DateTime(int.Parse(date.Substring(0, 4)), int.Parse(date.Substring(5, 2)), int.Parse(date.Substring(8, 2)));

            TimeSpan ts = new TimeSpan(startHours, startMinutes, 0);
            dateOfMaintenance = dateOfMaintenance.Date + ts;

            Maintenance maintenance = new Maintenance(maintenanceID, orderID, productCode, cbxTechnicianID.Text, dateOfMaintenance, 0);

            if (maintenance.CalculateDuration(startHours, startMinutes, endHours, endMinutes))
            {
                maintenance.FinaliseMaintenance();

                frmManageMaintenances form = new frmManageMaintenances();
                form.Show();

                this.Hide();
            }
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }

            if ((sender as TextBox).Text.Length >= 2 && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtStartTimeHours_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnKeyPress(sender, e);
        }

        private void txtStartTimeMinutes_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnKeyPress(sender, e);
        }

        private void txtEndTimeHours_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnKeyPress(sender, e);
        }

        private void txtEndTimeMinutes_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnKeyPress(sender, e);
        }
    }
}
