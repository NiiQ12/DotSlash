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

    public partial class frmManageCorrections : Form
    {
        public frmManageCorrections()
        {
            InitializeComponent();
        }

        private void frmManageCorrections_Load(object sender, EventArgs e)
        {
            string[] typesOfCorrections = { "ALL CORRECTIONS", "COMPLETED CORRECTIONS", "SCHEDULED CORRECTIONS" };

            panel2.BackColor = Color.FromArgb(150, 0, 0, 0);
            label10.BackColor = Color.FromArgb(0, 0, 0, 0);

            btnExit.TabStop = false;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;

            btnBack.TabStop = false;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;

            btnCancel.TabStop = false;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;

            btnServiceTicket.TabStop = false;
            btnServiceTicket.FlatStyle = FlatStyle.Flat;
            btnServiceTicket.FlatAppearance.BorderSize = 0;

            btnFinalise.TabStop = false;
            btnFinalise.FlatStyle = FlatStyle.Flat;
            btnFinalise.FlatAppearance.BorderSize = 0;

            for (int i = 0; i < typesOfCorrections.Length; i++)
            {
                cbxTypesOfCorrections.Items.Add(typesOfCorrections[i].ToString());
            }
            
            cbxTypesOfCorrections.SelectedItem = cbxTypesOfCorrections.Items[0];

            ResetCorrectionsDataGrid(CorrectionType.ALL);
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

        private void btnServiceTicket_Click(object sender, EventArgs e)
        {
            if (frmCalls.onCall)
            {
                frmServiceTicket form = new frmServiceTicket();
                form.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("A service ticket can only be logged while on a call!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void btnFinalise_Click(object sender, EventArgs e)
        {
            int correctionID = int.Parse(dgvCorrections.SelectedRows[0].Cells["ID"].Value.ToString());
            int orderID = int.Parse(dgvCorrections.SelectedRows[0].Cells["OrderID"].Value.ToString());
            string productCode = dgvCorrections.SelectedRows[0].Cells["ProductCode"].Value.ToString();
            string date = dgvCorrections.SelectedRows[0].Cells["StartDateTimeOfOperation"].Value.ToString();

            frmFinaliseCorrection form = new frmFinaliseCorrection(correctionID, orderID, productCode, date);
            form.Show();

            this.Hide();
        }

        private void cbxTypesOfCorrections_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetCorrectionsDataGrid((CorrectionType)cbxTypesOfCorrections.SelectedIndex);
        }

        public void ResetCorrectionsDataGrid(CorrectionType typeOfCorrection)
        {
            dgvCorrections.DataSource = Correction.GetCorrections(typeOfCorrection);

            dgvCorrections.Columns["ServiceTicketID"].Visible = false;
            dgvCorrections.Columns["Cost"].DisplayIndex = 7;
            dgvCorrections.Columns["ID"].Width = 30;
            dgvCorrections.Columns["ID"].DisplayIndex = 0;
            dgvCorrections.Columns["OrderID"].Width = 50;
            dgvCorrections.Columns["ProductCode"].Width = 80;
            dgvCorrections.Columns["Cost"].Width = 70;
            dgvCorrections.Columns["Duration"].Width = 70;
            dgvCorrections.Columns["StartDateTimeOfOperation"].HeaderText = "StartDate";
        }

        private void dgvCorrections_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCorrections.Rows[dgvCorrections.CurrentCell.RowIndex].Cells["TechnicianID"].Value.ToString() == null || dgvCorrections.Rows[dgvCorrections.CurrentCell.RowIndex].Cells["TechnicianID"].Value.ToString() == "")
            {
                int year = int.Parse(dgvCorrections.Rows[dgvCorrections.CurrentCell.RowIndex].Cells["StartDateTimeOfOperation"].Value.ToString().Substring(0, 4));
                int month = int.Parse(dgvCorrections.Rows[dgvCorrections.CurrentCell.RowIndex].Cells["StartDateTimeOfOperation"].Value.ToString().Substring(5, 2));
                int day = int.Parse(dgvCorrections.Rows[dgvCorrections.CurrentCell.RowIndex].Cells["StartDateTimeOfOperation"].Value.ToString().Substring(8, 2));

                DateTime selectedDate = new DateTime(year, month, day);

                if (selectedDate <= DateTime.Now)
                {
                    btnFinalise.Enabled = true;
                    btnCancel.Enabled = false;
                }
                else
                {
                    btnFinalise.Enabled = false;
                    btnCancel.Enabled = true;
                }
            }
            else
            {
                btnFinalise.Enabled = false;
                btnCancel.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            string correctionID = dgvCorrections.CurrentRow.Cells["ID"].Value.ToString();

            Correction.DeleteCorrectionFromDB(correctionID);

            MessageBox.Show("Correction " + correctionID + " has been successfully removed from the database!", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ResetCorrectionsDataGrid((CorrectionType)cbxTypesOfCorrections.SelectedIndex);
        }
    }
}
