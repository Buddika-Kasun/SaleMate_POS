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
    public partial class ChangePasswordFrm : Form
    {

        private string logedInUser;

        private void changePw()
        {
            string userName = userNmTxt.Text.Trim();
            string password = pwTxt.Text.Trim();
            string newPassword = newPwTxt.Text.Trim();
            string cnfrmPassword = cnfrmPwTxt.Text.Trim();

            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(cnfrmPassword))
            {
                if(logedInUser != "admin" && string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("New Username, Current Password, New Password and Confirm Password cannot be empty!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                MessageBox.Show("New Username, New Password and Confirm Password cannot be empty!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != cnfrmPassword)
            {
                MessageBox.Show("New Password and Confirm Password do not match!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cnfrmPwTxt.Text = string.Empty;
                cnfrmPwTxt.Focus();
                return;
            }

            try
            {
                // Create an instance of DbConnection
                DbConnection db = new DbConnection();

                // Query to check if the user exists in the database
                //string queryCheck = "SELECT COUNT(*) FROM [User] WHERE Id = @Id AND Password = @Password";
                string queryCheck = "SELECT COUNT(*) FROM [User] WHERE Password = @Password";

                // Define parameters for the query
                SqlParameter[] parametersCheck = {
                    //new SqlParameter("@Id", 1),
                    new SqlParameter("@Password", password)
                };

                // Execute the scalar query
                int countCheck = Convert.ToInt32(db.ExecuteScalar(queryCheck, parametersCheck));

                if (countCheck > 0 || logedInUser == "admin")
                {
                    pwErrLbl.Visible = false;

                    string deleteQuery = "DELETE FROM [User];";

                    db.ExecuteNonQuery(deleteQuery);

                    //string queryUpdate = "UPDATE [User] SET UserName = @userName, Password = @newPassword WHERE Id = @Id";
                    string queryInsert = "INSERT [User] (UserName, Password) VALUES (@userName, @newPassword);";

                    SqlParameter[] parametersUpdate = {
                        new SqlParameter("@userName", userName),
                        new SqlParameter("@newPassword", newPassword),
                        //new SqlParameter("@Id", 1)
                    };

                    int countUpdate = db.ExecuteNonQuery(queryInsert, parametersUpdate);

                    if (countUpdate > 0)
                    {
                        MessageBox.Show("User Name and Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Clear text fields after successful update
                        userNmTxt.Clear();
                        pwTxt.Clear();
                        newPwTxt.Clear();
                        cnfrmPwTxt.Clear();
                        pwErrLbl.Visible = false;

                        Application.Restart();

                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("Password update failed. Please try again.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    // Invalid credentials
                    MessageBox.Show("Invalid current password.", "Change Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pwTxt.Focus();
                    pwErrLbl.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public ChangePasswordFrm(string user)
        {
            this.logedInUser = user;
            InitializeComponent();
        }

        private void svBtn_Click(object sender, EventArgs e)
        {
            changePw();
        }

        private void ChangePasswordFrm_Load(object sender, EventArgs e)
        {
            if(logedInUser == "admin")
            {
                pwLbl.Visible = false;
                pwTxt.Visible = false;
            }
        }

        private void userNmTxt_TextChanged(object sender, EventArgs e)
        {
            if (userNmTxt.Text == "admin")
            {
                MessageBox.Show("The username 'admin' is not allowed. Please choose a different username.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                userNmTxt.Text = string.Empty;
                userNmTxt.Focus();
                return;
            }
        }

        private void newPwTxt_Leave(object sender, EventArgs e)
        {
            if (newPwTxt.Text.Length != 0 && newPwTxt.Text.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                newPwTxt.Focus();
            }
        }

        private void showBtn_Click(object sender, EventArgs e)
        {
            if (showBtn.Text == "Show")
            {
                cnfrmPwTxt.UseSystemPasswordChar = false;
                showBtn.Text = "Hide";
            }
            else
            {
                cnfrmPwTxt.UseSystemPasswordChar = true;
                showBtn.Text = "Show";
            }
        }

        private void ChangePasswordFrm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                svBtn.PerformClick();
            }
        }
    }
}
