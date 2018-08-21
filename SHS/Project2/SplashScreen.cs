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
    public partial class frmSplashScreen : Form
    {
        public static Timer t;

        public frmSplashScreen()
        {
            InitializeComponent();
        }

        private void frmSplashScreen_Shown(object sender, EventArgs e)
        {
            t = new Timer();
            t.Interval = 1000;
            t.Tick += new EventHandler(OnTimerEvent);
            t.Start();
        }

        private void OnTimerEvent(object sender, EventArgs e)
        {
            t.Stop();

            frmLogin login = new frmLogin();
            login.Show();
                         
            this.Hide();
        }
    }
}
