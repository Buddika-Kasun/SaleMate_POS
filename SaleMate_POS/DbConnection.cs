using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class DbConnection
{
    // Private field to store the database connection string
    private readonly string _connectionString;

    public string GetConnectionString()
    {
        return _connectionString;
    }

    // Constructor to initialize the connection string from App.config
    public DbConnection()
    {
        //_connectionString = ConfigurationManager.ConnectionStrings["SaleMate_POS.Properties.Settings.cn"]?.ConnectionString;
        _connectionString = ConfigurationManager.ConnectionStrings["SaleMate_POS.Properties.Settings.cns"]?.ConnectionString;

        if (string.IsNullOrEmpty(_connectionString))
        {
            throw new InvalidOperationException("Database connection string not found in App.config.");
        }
    }

    // Method to execute a query and return a data reader
    public SqlDataReader ExecuteQuery(string query, SqlParameter[] parameters = null)
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                //return cmd.ExecuteReader(); // Returns a data reader for result sets
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error executing query: {ex.Message}", ex);
            }
        }
    }

    // Method to execute a non-query (e.g., INSERT, UPDATE, DELETE)
    public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                return cmd.ExecuteNonQuery(); // Returns the number of rows affected
            }
            catch (Exception ex)
            {
                throw new Exception($"Error executing non-query: {ex.Message}", ex);
            }
        }
    }

    // Method to get a single scalar value (e.g., COUNT(*))
    public object ExecuteScalar(string query, SqlParameter[] parameters = null)
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                return cmd.ExecuteScalar(); // Returns a single value
            }
            catch (Exception ex)
            {
                throw new Exception($"Error executing scalar query: {ex.Message}", ex);
            }
        }
    }
}