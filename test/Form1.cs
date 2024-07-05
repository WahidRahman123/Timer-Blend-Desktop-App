using System;
using System.Collections.Generic; //For Unique random number generation
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Media;

namespace test
{
    public partial class Form1 : Form
    {
        System.Timers.Timer timer1;
        int h = 0, s = 0, m = 0;

        //For Alert Box Sound Player
        private SoundPlayer player;


        //Timer for Alert file:
        System.Timers.Timer alertTimer;
        int x;
        //Instances
        public static Form1 instance;
        public TextBox altxt;


        //reset variables
        int hr = 0, sr = 0, mr = 0;

        public Form1()
        {
            InitializeComponent();
            instance = this;
            altxt = alertText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            startBtn.Enabled = false;
            stopBtn.Enabled = true;
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            stopBtn.Enabled = false;
            startBtn.Enabled = true;
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            h = hr;
            s = sr;
            m = mr;
            if(!(h==0 && s==0 && m==0))
            {
                stopBtn.Enabled = false;
                startBtn.Enabled = true;
            }
            label1.Text = String.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
			
        }

        private void setTimerBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text.Trim()) && !string.IsNullOrEmpty(textBox2.Text.Trim()) && !string.IsNullOrEmpty(textBox3.Text.Trim()))
            {
                int hh = Convert.ToInt32(textBox1.Text);
                int mm = Convert.ToInt32(textBox3.Text);
                int ss = Convert.ToInt32(textBox2.Text);
                
                //if the setTimer value is set to 0 0 0
                if(hh==0 && mm==0 && ss==0)
                {
                    //MessageBox.Show("Enter valid times!!!");
                    h = 0;
                    m = 0;
                    s = 0;
                    label1.Text = String.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
                    startBtn.Enabled = false;
                    stopBtn.Enabled = false;
                    //reset variables
                    hr = 0;
                    mr = 0;
                    sr = 0;
                }

                else if (hh >= 0 && (mm >= 0 && mm <= 60) && (ss >= 0 && ss <= 60))
                {
                    startBtn.Enabled = true;
                    //stopBtn.Enabled = true;
                    h = hh;
                    m = mm;
                    s = ss;

                    //reset variables
                    hr = hh;
                    mr = mm;
                    sr = ss;
                    
                    label1.Text = String.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
                }
                else
                {
                    MessageBox.Show("Enter valid times!!!");
                }
            }
            else
            {
                MessageBox.Show("Fill the Empty Boxes!!!");
                //setTimerBtn.Enabled = false;
            }
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
                //To mute the annoying Ding sound
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if(e.KeyCode == Keys.Tab)
            {
                textBox3.Focus();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
                //To mute the annoying Ding sound
                e.Handled= true; 
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Tab)
            {
                textBox2.Focus();
            }
        }

        private void stopwatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Preventing Stopwatch multiple form opening
            sw form2 = Application.OpenForms.OfType<sw>().FirstOrDefault();

            if(form2 == null)
            {
                form2 = new sw();
                form2.Show();
            }
            else
            {
                //To have it in focus if it is already opened.
                form2.WindowState = FormWindowState.Normal;
                form2.Focus();
            }
            //form2.Show();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                setTimerBtn.Focus();
                //To mute the annoying Ding sound
                e.Handled = true;
                e.SuppressKeyPress= true;
            }
            else if (e.KeyCode == Keys.Tab)
            {
                setTimerBtn.Focus();
            }
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            alertText.Hide();
            ///Screen Setup Starts
            //For leftWindows Screen Setup
            Screen[] screens = Screen.AllScreens;
            if(screens.Length > 1)
            {
                Screen secondaryScreen = screens[1];

                leftWindows leftForm = new leftWindows
                {
                    StartPosition = FormStartPosition.Manual,
                    Location = secondaryScreen.WorkingArea.Location,
                    WindowState = FormWindowState.Maximized
                };

                //Show the secondary form on the secondary screen
                leftForm.Show();
            }
            else
            {
                // If no secondary screen found, it will be opened in the main window
                leftWindows leftForm = new leftWindows
                {
                    StartPosition = FormStartPosition.CenterScreen
                };

                // Show the secondary form
                leftForm.Show();
            }

            //For this Form Screen Setup
            this.StartPosition = FormStartPosition.Manual;
            this.Location = screens[0].WorkingArea.Location;
            this.WindowState = FormWindowState.Maximized;
            ///Screen Setup Ends


            //Default Focus TextBox
            this.ActiveControl = textBox1;
            textBox1.Focus();

            startBtn.Enabled = false;
            stopBtn.Enabled = false;
            //For the timer
            timer1 = new System.Timers.Timer();
            timer1.Interval = 1000;
            timer1.Elapsed += OnNewEvent;

            //For the Alert Timer
            alertTimer = new System.Timers.Timer();
            alertTimer.Interval = 1000;
            alertTimer.Elapsed += OnAlertTimerEvent;
        }

        Alert alert = new Alert();
        private void OnAlertTimerEvent(object sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                x--;
                
                //Alert Box
                Alert.instance.tlbl.Text = String.Format("{0}", x.ToString().PadLeft(2, '0'));

                if (x == 0)
                {
                    //Custom Alert Sound off
                    if (player != null)
                    {
                        player.Stop();
                    }


                    alert.Hide();  //if we use Stop, it destroy the alert object which creates unnecessary problems
                    Alert.instance.tlbl.Text = "10";
                    alertTimer.Stop();
                }

            }));
        }
        private void alertText_TextChanged(object sender, EventArgs e)
        {
            x = 10;
            alertTimer.Start();
            PlayCustomSound(); //Playing Custom Sounds

            alert.TopMost = true;
            alert.Show();
            
        }

        private void OnNewEvent(object sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                if(s >= -1 && m >= -1 && h >= -1)
                {
                    if (s != -1)
                    {
                        s -= 1;
                    }
                    if (s == -1)
                    {
                        s = 59;
                        m -= 1;
                    }
                    if (m == -1)
                    {
                        m = 59;
                        h -= 1;
                    }

                }

                label1.Text = String.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
                //throw new NotImplementedException();
            }));
        }

        //Custom Sound Playing Function
        private void PlayCustomSound()
        {
            string soundFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "alert.wav");
            player = new SoundPlayer(soundFilePath);
            player.Play();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Before Closing the Form, timer1 should be stopped.
            timer1.Stop();
            //To do it normally
            //Application.Exit();

            //But for the condition not to close the leftwindow normally, I have to use
            Environment.Exit(0);
        }
    }
}
