using System;
using System.Data.SqlClient;
using System.IO;
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

            // Ensure database is moved to a persistent location before launching the application
            MoveDatabaseIfNeeded();

            // Retrieve connection string from your persistent location
            string persistentDirectoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SaleMate");
            string persistentDbPath = Path.Combine(persistentDirectoryPath, "SaleMateDB.mdf");

            string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;
                                            AttachDbFilename={persistentDbPath};
                                            Integrated Security=True;
                                            Connect Timeout=30;";

            // Set connection string in MyDBConnection
            DbConnection.SetConnectionString(connectionString);

            // Test database connection and only proceed if successful
            if (TestDatabaseConnection())
            {
                // If the connection is successful, proceed with the login form
                LoginFrm loginForm = new LoginFrm();
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    string loggedInUser = loginForm.LoggedInUser;
                    Application.Run(new HomeFrm(loggedInUser));
                }
            }
            else
            {
                // If connection fails, show an error message and exit
                MessageBox.Show("Database connection failed. The application will now exit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        /// <summary>
        /// Checks if the database exists in the application directory and moves it to a persistent location.
        /// </summary>
        private static void MoveDatabaseIfNeeded()
        {
            string appDbPath = Path.Combine(Application.StartupPath, "SaleMateDB.mdf");
            string persistentDirectoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SaleMate");
            string persistentDbPath = Path.Combine(persistentDirectoryPath, "SaleMateDB.mdf");

            try
            {
                if (!Directory.Exists(persistentDirectoryPath))
                {
                    Directory.CreateDirectory(persistentDirectoryPath);
                }

                // Check if the database exists in the application directory
                if (File.Exists(appDbPath) && !File.Exists(persistentDbPath))
                {
                    File.Copy(appDbPath, persistentDbPath, true);
                }
            }
            catch (Exception ex)
            {
                // Log error (you can show a message here if needed)
            }
        }

        /// <summary>
        /// Checks database connection and returns true if successful.
        /// </summary>
        public static bool TestDatabaseConnection()
        {
            // Create an instance of DbConnection
            DbConnection dbConnection = new DbConnection();

            // Get the connection string using the instance
            string cns = dbConnection.GetConnectionString();

            if (!string.IsNullOrEmpty(cns))
            {
                try
                {
                    // Attempt to open a connection to the database
                    using (SqlConnection connection = new SqlConnection(cns))
                    {
                        connection.Open();  // Attempt to connect to the database
                        return true; // If successful, return true
                    }
                }
                catch (SqlException)
                {
                    // If there's an error, return false
                    return false;
                }
            }
            else
            {
                // If connection string is null or empty, return false
                return false;
            }
        }
    }
}
