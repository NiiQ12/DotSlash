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
    public partial class frmManageOperations : Form
    {
        public frmManageOperations()
        {
            InitializeComponent();
        }



        private void frmManageOperations_Load(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(150, 0, 0, 0);

            btnBack.TabStop = false;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;

            btnExit.TabStop = false;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;

            btnInstallations.TabStop = false;
            btnInstallations.FlatStyle = FlatStyle.Flat;
            btnInstallations.FlatAppearance.BorderSize = 0;
            
            btnViewSchedule.TabStop = false;
            btnViewSchedule.FlatStyle = FlatStyle.Flat;
            btnViewSchedule.FlatAppearance.BorderSize = 0;

            btnMaintenances.TabStop = false;
            btnMaintenances.FlatStyle = FlatStyle.Flat;
            btnMaintenances.FlatAppearance.BorderSize = 0;

            btnCorrections.TabStop = false;
            btnCorrections.FlatStyle = FlatStyle.Flat;
            btnCorrections.FlatAppearance.BorderSize = 0;
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

        private void btnInstallations_Click(object sender, EventArgs e)
        {
            frmManageInstallations form = new frmManageInstallations();
            form.Show();

            this.Hide();
        }

        private void btnCorrections_Click(object sender, EventArgs e)
        {
            frmManageCorrections form = new frmManageCorrections();
            form.Show();

            this.Hide();
        }

        private void btnMaintenances_Click(object sender, EventArgs e)
        {
            frmManageMaintenances form = new frmManageMaintenances();
            form.Show();

            this.Hide();
        }

        private void btnViewSchedule_Click(object sender, EventArgs e)
        {
            frmViewSchedule form = new frmViewSchedule();
            form.Show();

            this.Hide();
        }
    }
}
