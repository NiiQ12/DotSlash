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
    public partial class frmCalls : Form
    {
        public static bool onCall;

        public frmCalls()
        {
            InitializeComponent();
        }

        private void frmCalls_Load(object sender, EventArgs e)
        {
            btnStartCall.TabStop = false;
            btnStartCall.FlatStyle = FlatStyle.Flat;
            btnStartCall.FlatAppearance.BorderSize = 0;

            btnEndCall.TabStop = false;
            btnEndCall.FlatStyle = FlatStyle.Flat;
            btnEndCall.FlatAppearance.BorderSize = 0;

            btnEndCall.Enabled = false;
        }

        Timer t;
        CallLog callLog;

        private void btnStartCall_Click(object sender, EventArgs e)
        {
            lblHours.Text = "00";
            lblMinutes.Text = "00";
            lblSeconds.Text = "00";

            onCall = true;
            btnStartCall.Enabled = false;
            btnEndCall.Enabled = true;

            callLog = new CallLog(DateTime.Now, null);
            callLog.StartCallLog();

            t = new Timer();
            t.Interval = 1000;
            t.Tick += new EventHandler(t_Tick);
            t.Start();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            int hours = int.Parse(lblHours.Text);
            int minutes = int.Parse(lblMinutes.Text);
            int seconds = int.Parse(lblSeconds.Text);

            seconds++;

            if (seconds == 60)
            {
                seconds = 0;

                minutes++;

                if (minutes == 60)
                {
                    minutes = 0;

                    hours++;
                }
            }

            string strHours = hours.ToString();
            string strMinutes = minutes.ToString();
            string strSeconds = seconds.ToString();

            if (hours < 10)
            {
                strHours = "0" + strHours;
            }

            if (minutes < 10)
            {
                strMinutes = "0" + strMinutes;
            }

            if (seconds < 10)
            {
                strSeconds = "0" + strSeconds;
            }

            lblHours.Text = strHours;
            lblMinutes.Text = strMinutes;
            lblSeconds.Text = strSeconds;
        }

        private void btnEndCall_Click(object sender, EventArgs e)
        {
            int hours = int.Parse(lblHours.Text);
            int minutes = int.Parse(lblMinutes.Text);
            int seconds = int.Parse(lblSeconds.Text);

            t.Stop();

            callLog.EndCallLog();

            onCall = false;
            btnEndCall.Enabled = false;

            t = new Timer();
            t.Interval = 3000;
            t.Tick += new EventHandler(t_EndOfTick);
            t.Start();
        }

        private void t_EndOfTick(object sender, EventArgs e)
        {
            t.Stop();

            lblHours.Text = "00";
            lblMinutes.Text = "00";
            lblSeconds.Text = "00";

            btnStartCall.Enabled = true;
        }
    }
}
