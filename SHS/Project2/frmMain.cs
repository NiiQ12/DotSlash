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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (CallsForm.form == null)
            {
                CallsForm.form = new frmCalls();
            }

            CallsForm.form.Show();

            panel2.BackColor = Color.FromArgb(150, 0, 0, 0);

            btnManageOrders.TabStop = false;
            btnManageOrders.FlatStyle = FlatStyle.Flat;
            btnManageOrders.FlatAppearance.BorderSize = 0;

            btnManageProducts.TabStop = false;
            btnManageProducts.FlatStyle = FlatStyle.Flat;
            btnManageProducts.FlatAppearance.BorderSize = 0;

            btnManageClients.TabStop = false;
            btnManageClients.FlatStyle = FlatStyle.Flat;
            btnManageClients.FlatAppearance.BorderSize = 0;

            btnManageOperations.TabStop = false;
            btnManageOperations.FlatStyle = FlatStyle.Flat;
            btnManageOperations.FlatAppearance.BorderSize = 0;
            
            btnExit.TabStop = false;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;

            btnBack.TabStop = false;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;
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
            if (!frmCalls.onCall)
            {
                frmLogin form = new frmLogin();
                form.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Cannot log out while on a call!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            frmManageOrders form = new frmManageOrders();
            form.Show();
            
            this.Hide();
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            frmManageClients form = new frmManageClients();
            form.Show();
            
            this.Hide();
        }

        private void btnManageProducts_Click(object sender, EventArgs e)
        {
            frmManageProducts form = new frmManageProducts();
            form.Show();

            this.Hide();
        }

        private void btnManageOperations_Click(object sender, EventArgs e)
        {
            frmManageOperations form = new frmManageOperations();
            form.Show();

            this.Hide();
        }
    }
}
