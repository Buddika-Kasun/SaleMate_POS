using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaleMate_POS
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
            //Application.Run(new LoginFrm());

            LoginFrm loginForm = new LoginFrm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Retrieve the logged-in username from the login form
                string loggedInUser = loginForm.LoggedInUser;

                // If login is successful, show the HomeFrm and make it the main form
                Application.Run(new HomeFrm(loggedInUser));
            }
        }
    }
}
