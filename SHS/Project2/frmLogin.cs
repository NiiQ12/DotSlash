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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            helpProvider1.SetShowHelp(this.txtPassword, true);
            helpProvider1.SetShowHelp(this.txtUsername, true);

            if (CallsForm.form != null)
            {
                CallsForm.form.Hide();
            }

            panel2.BackColor = Color.FromArgb(150, 0, 0, 0);
            label3.BackColor = Color.FromArgb(0, 0, 0, 0);

            btnLogin.TabStop = false;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;

            btnExit.TabStop = false;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login(txtUsername.Text, txtPassword.Text);

            if (login.ValidateLoginDetails())
            {
                frmMain form = new frmMain();
                form.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username/password specified!");

                txtUsername.Clear();
                txtPassword.Clear();

                txtUsername.Focus();
            }
        }

        ErrorProvider errorProvider = new ErrorProvider();

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                e.Cancel = true;
                txtUsername.Focus();
                errorProvider.SetError(txtUsername, "Please enter a username!");
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel = true;
                txtPassword.Focus();
                errorProvider.SetError(txtPassword, "Please enter a password!");
            }
            else
            {
                errorProvider.Clear();
            }
        }
    }
}
