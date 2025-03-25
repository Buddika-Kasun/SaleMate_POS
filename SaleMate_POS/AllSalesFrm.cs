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
    public partial class AllSalesFrm : Form
    {

        public void getMinDates()
        {
            try
            {
                DbConnection db = new DbConnection();

                string query = "SELECT MIN(Date) AS MinDate FROM [SalesHeader];";

                object result = db.ExecuteScalar(query);

                if (result != null && result != DBNull.Value)
                {
                    DateTime minDate = Convert.ToDateTime(result);
                    fromDate.Value = minDate; // Assuming fromDate is a DateTimePicker
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadGrid(DateTime fromDate, DateTime toDate)
        {
            try
            {
                DbConnection db = new DbConnection();
                string connectionString = db.GetConnectionString();

                string query = @"
            SELECT 
                sh.SaleNo AS 'Sale No', 
                sh.Customer, 
                CONVERT(varchar, sh.Date, 103) AS Date, 
                sg.ItemName AS 'Item Name', 
                sg.Qty, 
                sg.UnitPrice AS 'Unit Price', 
                sg.Value 
            FROM [SalesHeader] sh 
            INNER JOIN [SalesGrid] sg ON sh.SaleNo = sg.SaleNo 
            WHERE sh.Date BETWEEN @fromDate AND @toDate;";

                string totalQuery = @"
            SELECT SUM(sg.Value) 
            FROM [SalesHeader] sh 
            INNER JOIN [SalesGrid] sg ON sh.SaleNo = sg.SaleNo 
            WHERE sh.Date BETWEEN @fromDate AND @toDate;";


                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@fromDate", fromDate);
                        cmd.Parameters.AddWithValue("@toDate", toDate);

                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            if (dt.Rows.Count == 0)
                            {
                                MessageBox.Show("No purchases found for the selected date range.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            allSalesGrid.DataSource = dt;
                            allSalesGrid.Refresh();
                        }
                    }

                    using (SqlCommand totalCmd = new SqlCommand(totalQuery, conn))
                    {
                        totalCmd.Parameters.AddWithValue("@fromDate", fromDate);
                        totalCmd.Parameters.AddWithValue("@toDate", toDate);

                        object totalResult = totalCmd.ExecuteScalar();
                        decimal totalValue = (totalResult != DBNull.Value) ? Convert.ToDecimal(totalResult) : 0;

                        subValTxt.Text = totalValue.ToString("N2"); // Format to 2 decimal places
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadGrifFromSaleNo()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(saleNoTxt.Text))
                {
                    MessageBox.Show("Please enter a Sale No for search.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Try to parse the receipt number
                if (!int.TryParse(saleNoTxt.Text, out int saleNo))
                {
                    MessageBox.Show("Invalid Sale No. Please enter a numeric value.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    saleNoTxt.Text = string.Empty;
                    return;
                }

                DbConnection db = new DbConnection();
                string connectionString = db.GetConnectionString();

                string query = @"
            SELECT 
                sh.SaleNo AS 'Sale No', 
                sh.Customer, 
                CONVERT(varchar, sh.Date, 103) AS Date, 
                sg.ItemName AS 'Item Name', 
                sg.Qty, 
                sg.UnitPrice AS 'Unit Price', 
                sg.Value 
            FROM [SalesHeader] sh 
            INNER JOIN [SalesGrid] sg ON sh.SaleNo = sg.SaleNo 
            WHERE sh.SaleNo = @saleNo;";

                string totalQuery = @"
            SELECT SUM(sg.Value) 
            FROM [SalesHeader] sh 
            INNER JOIN [SalesGrid] sg ON sh.SaleNo = sg.SaleNo 
            WHERE sh.SaleNo = @saleNo;";


                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@saleNo", saleNo);

                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            if (dt.Rows.Count == 0)
                            {
                                MessageBox.Show("No purchases found for the entered Sale No.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            allSalesGrid.DataSource = dt;
                            allSalesGrid.Refresh();
                        }
                    }

                    using (SqlCommand totalCmd = new SqlCommand(totalQuery, conn))
                    {
                        totalCmd.Parameters.AddWithValue("@saleNo", saleNo);

                        object totalResult = totalCmd.ExecuteScalar();
                        decimal totalValue = (totalResult != DBNull.Value) ? Convert.ToDecimal(totalResult) : 0;

                        subValTxt.Text = totalValue.ToString("N2"); // Format to 2 decimal places
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public AllSalesFrm()
        {
            InitializeComponent();
        }

        private void AllSalesFrm_Load(object sender, EventArgs e)
        {
            getMinDates();
            loadGrid(fromDate.Value, DateTime.Now.Date);
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            loadGrid(fromDate.Value, toDate.Value);
        }

        private void srchRecBtn_Click(object sender, EventArgs e)
        {
            loadGrifFromSaleNo();
        }
    }
}
