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

namespace SaleMate_POS
{
    public partial class ChangePasswordFrm : Form
    {

        private void changePw()
        {
            string userName = userNmTxt.Text.Trim();
            string password = pwTxt.Text.Trim();
            string newPassword = newPwTxt.Text.Trim();

            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Username, Password and New Password cannot be empty!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Create an instance of DbConnection
                DbConnection db = new DbConnection();

                // Query to check if the user exists in the database
                string queryCheck = "SELECT COUNT(*) FROM [User] WHERE Id = @Id AND Password = @Password";

                // Define parameters for the query
                SqlParameter[] parametersCheck = {
                    new SqlParameter("@Id", 2),
                    new SqlParameter("@Password", password)
                };

                // Execute the scalar query
                int countCheck = Convert.ToInt32(db.ExecuteScalar(queryCheck, parametersCheck));

                bool adminPermission = password == "admin123";

                if (countCheck > 0 || adminPermission)
                {
                    string queryUpdate = "UPDATE [User] SET UserName = @userName, Password = @newPassword WHERE Id = @Id";

                    SqlParameter[] parametersUpdate = {
                        new SqlParameter("@userName", userName),
                        new SqlParameter("@newPassword", newPassword),
                        new SqlParameter("@Id", 2)
                    };

                    int countUpdate = db.ExecuteNonQuery(queryUpdate, parametersUpdate);

                    if (countUpdate > 0)
                    {
                        MessageBox.Show("User Name and Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Clear text fields after successful update
                        userNmTxt.Clear();
                        pwTxt.Clear();
                        newPwTxt.Clear();
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public ChangePasswordFrm()
        {
            InitializeComponent();
        }

        private void svBtn_Click(object sender, EventArgs e)
        {
            changePw();
        }
    }
}
