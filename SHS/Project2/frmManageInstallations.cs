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
    public partial class frmManageInstallations : Form
    {
        public frmManageInstallations()
        {
            InitializeComponent();
        }

        private void frmManageInstallations_Load(object sender, EventArgs e)
        {
            string[] typesOfInstallations = { "ALL INSTALLATIONS", "COMPLETED INSTALLATIONS", "SCHEDULED INSTALLATIONS" };

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
            
            for (int i = 0; i < typesOfInstallations.Length; i++)
            {
                cbxTypesOfInstallations.Items.Add(typesOfInstallations[i].ToString());
            }

            cbxTypesOfInstallations.SelectedItem = cbxTypesOfInstallations.Items[0];

            ResetInstallationsDataGrid(InstallationType.ALL);
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

        private void btnFinaliseInstallation_Click(object sender, EventArgs e)
        {
            int installationID = int.Parse(dgvInstallations.SelectedRows[0].Cells["ID"].Value.ToString());
            int orderID = int.Parse(dgvInstallations.SelectedRows[0].Cells["OrderID"].Value.ToString());
            string productCode = dgvInstallations.SelectedRows[0].Cells["ProductCode"].Value.ToString();
            string date = dgvInstallations.SelectedRows[0].Cells["StartDateTimeOfOperation"].Value.ToString();

            frmFinaliseInstallation form = new frmFinaliseInstallation(installationID, orderID, productCode, date);
            form.Show();

            this.Hide();
        }

        private void cbxTypesOfInstallations_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetInstallationsDataGrid((InstallationType)cbxTypesOfInstallations.SelectedIndex);
        }

        public void ResetInstallationsDataGrid(InstallationType typeOfInstallation)
        {
            dgvInstallations.DataSource = Installation.GetInstallations(typeOfInstallation);

            dgvInstallations.Columns["Cost"].DisplayIndex = 6;
            dgvInstallations.Columns["ID"].Width = 30;
            dgvInstallations.Columns["OrderID"].Width = 50;
            dgvInstallations.Columns["ProductCode"].Width = 80;
            dgvInstallations.Columns["Cost"].Width = 50;
            dgvInstallations.Columns["Duration"].Width = 70;
            dgvInstallations.Columns["StartDateTimeOfOperation"].HeaderText = "StartDate";
        }

        private void dgvInstallations_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvInstallations.Rows[dgvInstallations.CurrentCell.RowIndex].Cells["TechnicianID"].Value.ToString() == null || dgvInstallations.Rows[dgvInstallations.CurrentCell.RowIndex].Cells["TechnicianID"].Value.ToString() == "")
            {
                int year = int.Parse(dgvInstallations.Rows[dgvInstallations.CurrentCell.RowIndex].Cells["StartDateTimeOfOperation"].Value.ToString().Substring(0, 4));
                int month = int.Parse(dgvInstallations.Rows[dgvInstallations.CurrentCell.RowIndex].Cells["StartDateTimeOfOperation"].Value.ToString().Substring(5, 2));
                int day = int.Parse(dgvInstallations.Rows[dgvInstallations.CurrentCell.RowIndex].Cells["StartDateTimeOfOperation"].Value.ToString().Substring(8, 2));

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
