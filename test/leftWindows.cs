using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace test
{
    public partial class leftWindows : Form
    {
        System.Timers.Timer leftTimer;
        int s = 30;


        //For Unique Random Number Generation
        int checkNumber = 0;
        private Random random;


        public leftWindows()
        {
            InitializeComponent();
            //For Random Number 
            random = new Random();
            //For Secondary Monitor
            //DisplayOnSecondaryMonitor();  //if
        }

        /*private void DisplayOnSecondaryMonitor()
        {
            Screen[] screens = Screen.AllScreens;

            //Checking if the secondary monitor is available or not
            if(screens.Length > 1)
            {
                Screen secondaryScreen = screens[1];

                this.WindowState = FormWindowState.Maximized;           //The form will be in maximized form
                this.Location = secondaryScreen.Bounds.Location;        //Location is on the Secondary Screen
            }
            else
            {
                this.StartPosition = FormStartPosition.CenterScreen;    //Start Position will contain CenterScreen Style
            }
        }*/    //if

        private void leftWindows_Load(object sender, EventArgs e)
        {
            this.panel1.BackColor = Color.FromArgb(157, 195, 230);
            leftTimer = new System.Timers.Timer();
            leftTimer.Interval = 1000;
            leftTimer.Elapsed += OnLeftTimerEvent;

            //just turn on the timer
            leftTimer.Start();

        }

        private void OnLeftTimerEvent(object sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                s -= 1;
                if(s < 0)
                {
                    s = 30;
                }
                if(s == 10)
                {
                    int uniqueNumber = GenerateUniqueRandomNumbers();
                    Form1.instance.altxt.Text = uniqueNumber.ToString();
                }
                label1.Text = String.Format("{0}", s.ToString().PadLeft(2, '0'));
            }));
        }

        //For Random Number generation
        private int GenerateUniqueRandomNumbers()
        {
            int number;
            do
            {
                number = random.Next(1, 1000); // Adjust the range as needed
            } while (number == checkNumber);

            checkNumber = number;
            return number;
        }



        private void leftWindows_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
