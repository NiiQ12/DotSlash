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
using System.Text.RegularExpressions;

namespace SHS
{
    public partial class frmManageClients : Form
    {
        public frmManageClients()
        {
            InitializeComponent();
        }


        string firstIDValue;

        private void frmReport_Load(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(150, 0, 0, 0);

            btnUpdate.TabStop = false;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.FlatAppearance.BorderSize = 0;

            btnExit.TabStop = false;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;

            btnBack.TabStop = false;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;

            btnAddClient.TabStop = false;
            btnAddClient.FlatStyle = FlatStyle.Flat;
            btnAddClient.FlatAppearance.BorderSize = 0;

            ResetDataGrid();

            firstIDValue = dgvClients.Rows[0].Cells["IDNumber"].Value.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmMain form = new frmMain();
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

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            frmAddClient form = new frmAddClient();
            form.Show();

            FormState.PreviousPage = this;

            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataHandler.UpdateDB("Client");
        }

        string previousValue = "", newValue = "";

        private void dgvClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            previousValue = dgvClients.CurrentCell.Value.ToString();
        }

        private void dgvClients_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string currentColumn = dgvClients.Columns[dgvClients.CurrentCell.ColumnIndex].Name;

            newValue = dgvClients.CurrentCell.Value.ToString();

            if (newValue == null || newValue == "")
            {
                MessageBox.Show("The value can't be changed to null!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvClients.CurrentCell.Value = previousValue;
            }
            else if (currentColumn == "Name" && (!Regex.IsMatch(newValue, @"^[a-zA-Z ]+$") || newValue.Length > 50))
            {
                MessageBox.Show("Invalid name specified!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvClients.CurrentCell.Value = previousValue;
            }
            else if (currentColumn == "Surname" && (!Regex.IsMatch(newValue, @"^[a-zA-Z ]+$") || newValue.Length > 50))
            {
                MessageBox.Show("Invalid surname specified!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvClients.CurrentCell.Value = previousValue;
            }
            else if (currentColumn == "ContactNo" && (!newValue.All(char.IsDigit) || newValue.Length != 10))
            {
                MessageBox.Show("Invalid contact number specified!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvClients.CurrentCell.Value = previousValue;
            }
            else if (currentColumn == "Email" && (!newValue.Contains('.') || !newValue.Contains('@') || newValue.Length > 50))
            {
                MessageBox.Show("Invalid email specified!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvClients.CurrentCell.Value = previousValue;
            }
            
            dgvClients.Rows[0].Cells["IDNumber"].Value = firstIDValue;
        }

        private void ResetDataGrid()
        {
            dgvClients.DataSource = Client.GetClientDataTable();

            dgvClients.Columns["AddressID"].Visible = false;
            dgvClients.Columns["ClientID"].Visible = false;

            dgvClients.Columns["IDNumber"].Width = 85;
            dgvClients.Columns["Contract"].Width = 85;
            dgvClients.Columns["Name"].Width = 75;
            dgvClients.Columns["Surname"].Width = 75;
            dgvClients.Columns["ContactNo"].Width = 75;

            dgvClients.Columns["IDNumber"].ReadOnly = true;
            dgvClients.Columns["Contract"].ReadOnly = true;
        }

        private void frmManageClients_Activated(object sender, EventArgs e)
        {
            ResetDataGrid();
        }
    }
}
