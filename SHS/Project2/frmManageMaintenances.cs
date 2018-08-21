using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;

namespace SHS
{
    public partial class frmManageMaintenances : Form
    {
        public frmManageMaintenances()
        {
            InitializeComponent();
        }

        private void frmManageMaintenances_Load(object sender, EventArgs e)
        {
            string[] typesOfMaintenances = { "ALL MAINTENANCES", "COMPLETED MAINTENANCES", "SCHEDULED MAINTENANCES" };

            panel2.BackColor = Color.FromArgb(150, 0, 0, 0);
            label10.BackColor = Color.FromArgb(0, 0, 0, 0);

            btnBack.TabStop = false;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;

            btnExit.TabStop = false;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;

            btnFinalise.TabStop = false;
            btnFinalise.FlatStyle = FlatStyle.Flat;
            btnFinalise.FlatAppearance.BorderSize = 0;
            
            for (int i = 0; i < typesOfMaintenances.Length; i++)
            {
                cbxTypesOfMaintenances.Items.Add(typesOfMaintenances[i].ToString());
            }

            cbxTypesOfMaintenances.SelectedItem = cbxTypesOfMaintenances.Items[0];

            ResetMaintenancesDataGrid(MaintenanceType.ALL);
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

        private void btnFinaliseMaintenance_Click(object sender, EventArgs e)
        {
            int maintenanceID = int.Parse(dgvMaintenances.SelectedRows[0].Cells["ID"].Value.ToString());
            int orderID = int.Parse(dgvMaintenances.SelectedRows[0].Cells["OrderID"].Value.ToString());
            string productCode = dgvMaintenances.SelectedRows[0].Cells["ProductCode"].Value.ToString();
            string date = dgvMaintenances.SelectedRows[0].Cells["StartDateTimeOfOperation"].Value.ToString();

            frmFinaliseMaintenance form = new frmFinaliseMaintenance(maintenanceID, orderID, productCode, date);
            form.Show();

            this.Hide();
        }

        private void cbxTypesOfMaintenances_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetMaintenancesDataGrid((MaintenanceType)cbxTypesOfMaintenances.SelectedIndex);
        }

        public void ResetMaintenancesDataGrid(MaintenanceType typeOfMaintenance)
        {
            dgvMaintenances.DataSource = Maintenance.GetMaintenances(typeOfMaintenance);

            dgvMaintenances.Columns["ID"].Width = 30;
            dgvMaintenances.Columns["OrderID"].Width = 80;
            dgvMaintenances.Columns["ProductCode"].Width = 100;
            dgvMaintenances.Columns["Duration"].Width = 70;
            dgvMaintenances.Columns["StartDateTimeOfOperation"].HeaderText = "StartDate";
        }

        private void dgvMaintenances_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMaintenances.Rows[dgvMaintenances.CurrentCell.RowIndex].Cells["TechnicianID"].Value.ToString() == null || dgvMaintenances.Rows[dgvMaintenances.CurrentCell.RowIndex].Cells["TechnicianID"].Value.ToString() == "")
            {
                int year = int.Parse(dgvMaintenances.Rows[dgvMaintenances.CurrentCell.RowIndex].Cells["StartDateTimeOfOperation"].Value.ToString().Substring(0, 4));
                int month = int.Parse(dgvMaintenances.Rows[dgvMaintenances.CurrentCell.RowIndex].Cells["StartDateTimeOfOperation"].Value.ToString().Substring(5, 2));
                int day = int.Parse(dgvMaintenances.Rows[dgvMaintenances.CurrentCell.RowIndex].Cells["StartDateTimeOfOperation"].Value.ToString().Substring(8, 2));

                DateTime selectedDate = new DateTime(year, month, day);

                if (selectedDate <= DateTime.Now)
                {
                    btnFinalise.Enabled = true;
                }
                else
                {
                    btnFinalise.Enabled = false;
                }
            }
            else
            {
                btnFinalise.Enabled = false;
            }
        }
    }
}
