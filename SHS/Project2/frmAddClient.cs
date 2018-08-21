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
    public partial class frmAddClient : Form
    {
        public frmAddClient()
        {
            InitializeComponent();
        }

        private void frmSearchStudent_Load(object sender, EventArgs e)
        {
            helpProvider1.SetShowHelp(this.txtID, true);
            helpProvider1.SetShowHelp(this.txtName, true);
            helpProvider1.SetShowHelp(this.txtSurname, true);
            helpProvider1.SetShowHelp(this.txtEmailAddress, true);
            helpProvider1.SetShowHelp(this.txtContactNumber, true);
            helpProvider1.SetShowHelp(this.txtStreet, true);
            helpProvider1.SetShowHelp(this.txtPort, true);
            helpProvider1.SetShowHelp(this.txtCity, true);
            helpProvider1.SetShowHelp(this.txtSuburb, true);

            panel2.BackColor = Color.FromArgb(150, 0, 0, 0);

            btnAddClient.TabStop = false;
            btnAddClient.FlatStyle = FlatStyle.Flat;
            btnAddClient.FlatAppearance.BorderSize = 0;

            btnExit.TabStop = false;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;

            btnBack.TabStop = false;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;

            string[] priority = { "A", "B", "C", "D" };

            for (int i = 0; i < Client.maintenancePlans.Count(); i++)
            {
                cbxMaintenance.Items.Add(Client.maintenancePlans[i]);
            }

            for (int i = 0; i < priority.Count(); i++)
            {
                cbxPriority.Items.Add(priority[i]);
            }

            UnableContract();
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            Address address = null;
            address = new Address(txtCity.Text, txtSuburb.Text, txtStreet.Text, txtPort.Text);

            Client client = new Client();

            if (chkContract.Checked == true)
            {
                string maintenancePlan = null;
                char priority = '\0';

                maintenancePlan = cbxMaintenance.Text.ToString();
                
                if (cbxPriority.Text != string.Empty)
                {
                    priority = char.Parse(cbxPriority.Text);
                }
                else
                {
                    priority = '\0';
                }

                client = new Client(txtID.Text, null, txtName.Text, txtSurname.Text, txtContactNumber.Text, txtEmailAddress.Text, address, maintenancePlan, priority);
            }
            else
            {
                client = new Client(txtID.Text, null, txtName.Text, txtSurname.Text, txtContactNumber.Text, txtEmailAddress.Text, address, null);
            }

            if (_ValidationMethods.isValid)
            {
                if (client.SaveClientToDB())
                {
                    if (FormState.PreviousPage.GetType().ToString() == "SHS.frmAddOrder")
                    {
                        frmAddOrder form = new frmAddOrder(client.ID);
                        form.Show();
                    }
                    else
                    {
                        FormState.PreviousPage.Show();
                    }

                    this.Hide();
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormState.PreviousPage.Show();

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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkContract.Checked == true)
            {
                EnableContract();
            }
            else
            {
                UnableContract();
            }
        }

        public void EnableContract()
        {
            cbxMaintenance.Enabled = true;
            cbxPriority.Enabled = true;
            panel20.BackColor = Color.FromArgb(0, 130, 130);
            panel19.BackColor = Color.FromArgb(0, 130, 130);
            label12.ForeColor = Color.White;
            label11.ForeColor = Color.White;
            panel22.BackColor = Color.White;
            panel21.BackColor = Color.White;
        }

        public void UnableContract()
        {
            cbxMaintenance.Enabled = false;
            cbxPriority.Enabled = false;
            cbxMaintenance.SelectedIndex = -1;
            cbxPriority.SelectedIndex = -1;
            panel20.BackColor = Color.FromArgb(80, 130, 130);
            panel19.BackColor = Color.FromArgb(80, 130, 130);
            label12.ForeColor = Color.LightGray;
            label11.ForeColor = Color.LightGray;
            panel22.BackColor = Color.LightGray;
            panel21.BackColor = Color.LightGray;
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000;
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(this.label1, "13 Digit ID Number (No Spaces)");
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000;
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(this.label6, "10 Digit Contact Number (No Spaces or Special Characters)");
        }

        ErrorProvider errorProvider = new ErrorProvider();

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                e.Cancel = true;
                txtName.Focus();
                errorProvider.SetError(txtName, "Please enter a name!");
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtID_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                e.Cancel = true;
                txtID.Focus();
                errorProvider.SetError(txtID, "Please enter an ID!");
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtSurname_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSurname.Text))
            {
                e.Cancel = true;
                txtSurname.Focus();
                errorProvider.SetError(txtSurname, "Please enter a surname!");
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtContactNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtContactNumber.Text))
            {
                e.Cancel = true;
                txtContactNumber.Focus();
                errorProvider.SetError(txtContactNumber, "Please enter a contact number!");
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtEmailAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmailAddress.Text))
            {
                e.Cancel = true;
                txtEmailAddress.Focus();
                errorProvider.SetError(txtEmailAddress, "Please enter an email address!");
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtCity_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCity.Text))
            {
                e.Cancel = true;
                txtCity.Focus();
                errorProvider.SetError(txtCity, "Please enter a city!");
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtStreet_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtStreet.Text))
            {
                e.Cancel = true;
                txtStreet.Focus();
                errorProvider.SetError(txtStreet, "Please enter a street!");
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtSuburb_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSuburb.Text))
            {
                e.Cancel = true;
                txtSuburb.Focus();
                errorProvider.SetError(txtSuburb, "Please enter a suburb!");
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtPort_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPort.Text))
            {
                e.Cancel = true;
                txtPort.Focus();
                errorProvider.SetError(txtPort, "Please enter a port!");
            }
            else
            {
                errorProvider.Clear();
            }
        }
    }
}
