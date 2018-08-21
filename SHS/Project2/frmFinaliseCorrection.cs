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
    public partial class frmFinaliseCorrection : Form
    {
        int correctionID, orderID;
        string productCode, date;

        public frmFinaliseCorrection(int correctionID, int orderID, string productCode, string date)
        {
            InitializeComponent();

            this.correctionID = correctionID;
            this.orderID = orderID;
            this.productCode = productCode;
            this.date = date;
        }

        private void frmFinaliseCorrection_Load(object sender, EventArgs e)
        {
            helpProvider1.SetShowHelp(this.txtCost, true);

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

        private void btnFinalise_Click(object sender, EventArgs e)
        {
            decimal price;

            if (txtCost.Text != null && txtCost.Text != "")
            {
                price = decimal.Parse(txtCost.Text);

                int startHours = int.Parse(txtStartTimeHours.Text);
                int startMinutes = int.Parse(txtStartTimeMinutes.Text);
                int endHours = int.Parse(txtEndTimeHours.Text);
                int endMinutes = int.Parse(txtEndTimeMinutes.Text);

                DateTime dateOfCorrection = new DateTime(int.Parse(date.Substring(0, 4)), int.Parse(date.Substring(5, 2)), int.Parse(date.Substring(8, 2)));

                TimeSpan ts = new TimeSpan(startHours, startMinutes, 0);
                dateOfCorrection = dateOfCorrection.Date + ts;

                Correction correction = new Correction(correctionID, orderID, productCode, cbxTechnicianID.Text, dateOfCorrection, 0, price, null);


                if (correction.CalculateDuration(startHours, startMinutes, endHours, endMinutes))
                {
                    correction.FinaliseCorrection();

                    frmManageCorrections form = new frmManageCorrections();
                    form.Show();

                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Please enter a price!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((sender as TextBox).Text.Length == 0 && (e.KeyChar == '0'))
            {
                e.Handled = true;
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Only allow one decimal point
            if ((sender as TextBox).Text.IndexOf('.') > -1)
            {
                if (((e.KeyChar == '.') || ((sender as TextBox).Text.Length > (sender as TextBox).Text.IndexOf('.') + 2)) && (e.KeyChar != '\b'))
                {
                    e.Handled = true;
                }
            }

            if ((sender as TextBox).Text.Length >= 10 && (e.KeyChar != '\b'))
            {
                e.Handled = true;
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

        ErrorProvider errorProvider = new ErrorProvider();

        private void txtCost_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCost.Text))
            {
                e.Cancel = true;
                txtCost.Focus();
                errorProvider.SetError(txtCost, "Please enter a cost!");
            }
            else
            {
                errorProvider.Clear();
            }
        }
    }
}
