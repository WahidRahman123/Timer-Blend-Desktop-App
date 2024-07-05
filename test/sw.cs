using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace test
{
    public partial class sw : Form
    {
        System.Timers.Timer swTimer;
        int swh, swm, sws;

        private void swStart_Click(object sender, EventArgs e)
        {
            swTimer.Start();
            swStart.Enabled = false;
            swStop.Enabled = true;
        }

        private void swStop_Click(object sender, EventArgs e)
        {
            swTimer.Stop();
            swStart.Enabled = true;
            swStop.Enabled = false;
        }

        private void swReset_Click(object sender, EventArgs e)
        {
            swTimer.Stop();
            swh = 0;
            swm = 0;
            sws = 0;
            swlabel.Text = "00:00:00";
            swStart.Enabled = true;
            swStop.Enabled = false;
        }

        

        public sw()
        {
            InitializeComponent();
        }

        private void sw_Load(object sender, EventArgs e)
        {
            //For Maximized Window while opening.
            this.WindowState = FormWindowState.Maximized;

            swStart.Enabled = true;
            swStop.Enabled = false;

            //Object Creation
            swTimer = new System.Timers.Timer();
            swTimer.Interval = 1000;
            swTimer.Elapsed += OnSWTimerEvent;
        }

        private void OnSWTimerEvent(object sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                sws += 1;
                if(sws == 60)
                {
                    sws = 0;
                    swm += 1;
                }
                if(swm == 60)
                {
                    swm = 0;
                    swh += 1;
                }
                swlabel.Text = String.Format("{0}:{1}:{2}", swh.ToString().PadLeft(2, '0'), swm.ToString().PadLeft(2, '0'), sws.ToString().PadLeft(2, '0'));
            }));
        }
        private void sw_FormClosing(object sender, FormClosingEventArgs e)
        {
            swTimer.Stop();
        }
    }
}
