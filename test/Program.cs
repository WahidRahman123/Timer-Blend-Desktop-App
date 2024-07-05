using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /*//Creating instances of forms
            Form1 f1 = new Form1();
            leftWindows lw1 = new leftWindows();
            //Alert a = new Alert(); 

            //Show both forms
            f1.Show();
            lw1.Show();
            //a.Show();
            //Run the application message in loop*/
            Application.Run(new Form1());
        }
    }
}
