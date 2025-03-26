using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SaleMate_POS
{
    public partial class LoginFrm : Form
    {
        public string LoggedInUser { get; private set; }

        private string adminUserName = "admin";
        private string adminPassword = "123";

        private void login()
        {
            errLbl.Visible = false;

            string userName = userNmTxt.Text.Trim();
            string password = pwTxt.Text.Trim();

            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and Password cannot be empty!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Create an instance of DbConnection
                DbConnection db = new DbConnection();

                // Query to check if the user exists in the database
                string query = "SELECT COUNT(*) FROM [User] WHERE UserName = @UserName AND Password = @Password";

                // Define parameters for the query
                SqlParameter[] parameters = {
                    new SqlParameter("@UserName", userName),
                    new SqlParameter("@Password", password)
                };

                // Execute the scalar query
                int count = Convert.ToInt32(db.ExecuteScalar(query, parameters));

                if (count > 0 || (userName == adminUserName && password == adminPassword))
                {
                    // Login successful
                    LoggedInUser = userName; // Store the logged-in user
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    // Invalid credentials
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errLbl.Visible = true;
                    userNmTxt.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public LoginFrm()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            login();
        }

        private void showBtn_Click(object sender, EventArgs e)
        {
            if(showBtn.Text == "Show")
            {
                pwTxt.UseSystemPasswordChar = false;
                showBtn.Text = "Hide";
            }
            else
            {
                pwTxt.UseSystemPasswordChar = true;
                showBtn.Text = "Show";
            }
        }
    }
}
