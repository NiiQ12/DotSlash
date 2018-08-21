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
    public partial class frmServiceTicket : Form
    {
        public frmServiceTicket()
        {
            InitializeComponent();
        }

        private void frmServiceTicket_Load(object sender, EventArgs e)
        {
            helpProvider1.SetShowHelp(this.txtDescription, true);

            panel2.BackColor = Color.FromArgb(150, 0, 0, 0);

            btnExit.TabStop = false;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;

            btnBack.TabStop = false;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;

            btnLogServiceTicket.TabStop = false;
            btnLogServiceTicket.FlatStyle = FlatStyle.Flat;
            btnLogServiceTicket.FlatAppearance.BorderSize = 0;

            txtAdministratorID.Text = Login.loggedInAdministratorID;

            ResetClientComboBox();
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmManageCorrections form = new frmManageCorrections();
            form.Show();

            this.Hide();
        }
                
        private void cbxClientID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string clientID = cbxClientID.SelectedItem.ToString();
            ResetOrderComboBox(clientID);
            
            string orderID = "";

            if (cbxOrderID.SelectedItem != null)
            {
                orderID = cbxOrderID.SelectedItem.ToString();
            }

            ResetProductComboBox(orderID);
        }

        private void cbxOrderID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string orderID = cbxOrderID.SelectedItem.ToString();
            ResetProductComboBox(orderID);
        }

        public void ResetClientComboBox()
        {
            cbxClientID.Items.Clear();

            List<Client> clients = Client.GetClients();

            foreach (Client client in clients)
            {
                cbxClientID.Items.Add(client.ID);
            }
        }

        public void ResetOrderComboBox(string clientID)
        {
            cbxOrderID.Items.Clear();

            List<string> orderIDs = Order.GetClientOrderIDs(clientID);

            foreach (string orderID in orderIDs)
            {
                cbxOrderID.Items.Add(orderID);
            }
        }

        public void ResetProductComboBox(string orderID)
        {
            cbxProductCode.Items.Clear();

            List<string> productCodes = Product.GetOrderProductCodes(orderID);

            foreach (string productCode in productCodes)
            {
                cbxProductCode.Items.Add(productCode);
            }
        }

        private void btnLogServiceTicket_Click(object sender, EventArgs e)
        {
            Correction.days = 1;

            _ValidationMethods.Reset();

            if (cbxClientID.Text == null || cbxClientID.Text == "")
            {
                _ValidationMethods.AddToInvalidFields("Client ID");
            }

            if (cbxOrderID.Text == null || cbxOrderID.Text == "")
            {
                _ValidationMethods.AddToInvalidFields("Order ID");
            }

            if (cbxProductCode.Text == null || cbxProductCode.Text == "")
            {
                _ValidationMethods.AddToInvalidFields("Product Code");
            }

            ServiceTicket serviceTicket = new ServiceTicket(DataHandler.lastCallLogID, txtDescription.Text);
            
            if (_ValidationMethods.isValid)
            {
                serviceTicket.SaveServiceTicketToDB();

                Correction correction = new Correction(0, int.Parse(cbxOrderID.Text), cbxProductCode.Text, null, DateTime.MinValue, null, null, null);

                correction.SaveCorrectionToDB();

                frmManageCorrections form = new frmManageCorrections();
                form.Show();

                this.Hide();
            }
        }

        private void label8_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000;
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(this.label8, "Choose Client ID Before Selecting Order ID");
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000;
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(this.label8, "Choose Order ID First Before Selecting Product Code");
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000;
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(this.label5, "Max 100 Characters");
        }

        ErrorProvider errorProvider = new ErrorProvider();

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                e.Cancel = true;
                txtDescription.Focus();
                errorProvider.SetError(txtDescription, "Please enter a description!");
            }
            else
            {
                errorProvider.Clear();
            }
        }
    }
}
