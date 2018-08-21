using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2
{
    public partial class frmStudentPicture : Form
    {
        public frmStudentPicture()
        {
            InitializeComponent();
        }

        private void frmStudentPicture_Load(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(150, 0, 0, 0);

            btnBack.TabStop = false;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;

            btnExit.TabStop = false;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;

            string fileName = DataHandler.GetFileName();
            var image = Image.FromFile(@fileName);

            pbxPicture.Image = image;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmSearchStudent form = new frmSearchStudent();
            form.Show();

            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
