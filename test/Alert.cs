using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net.Http.Headers;
using System.Timers; //For Rounded Corners

namespace test
{
    public partial class Alert : Form
    {
        //Rounded Corner Declaration Starts
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
            (
                int nLeftRect,
                int nTopRect,
                int nRightRect,
                int nBottomRect,
                int nWidthEllipse,
                int nHeightEllipse
            );
        //Rounded Corner Declaration Ends

        //For the timer
        /*System.Timers.Timer alTimer;
        int m;*/


        //Instance Creation
        public static Alert instance;
        public Label tlbl;

        public Alert()
        {
            InitializeComponent();
            //Instance fixing
            instance = this;
            tlbl = timerLabel;

            //Round Corners
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void Alert_Load(object sender, EventArgs e)
        {
            
        }


        //Dragging portion starts.
        private bool drag = false;
        private Point pt = new Point(0, 0);

        private void Alert_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void Alert_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            pt = new Point(e.X, e.Y);
        }

        private void Alert_MouseMove(object sender, MouseEventArgs e)
        {
            if(drag)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.pt.X, p.Y - this.pt.Y);
            }
        }
        //Dragging Portion Ends


        //Form Shadow Starts
        private const int CS_DropShadow = 0x00020000;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = CS_DropShadow;
                return cp;
            }
        }

        
        //Form Shadow Ends
    }
}
