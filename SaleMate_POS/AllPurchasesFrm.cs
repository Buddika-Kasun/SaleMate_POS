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
    public partial class AllPurchasesFrm : Form
    {

        public void getMinDates()
        {
            try
            {
                DbConnection db = new DbConnection();

                string query = "SELECT MIN(Date) AS MinDate FROM [PurchaseHeader];";

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
                ph.ReceiptNo AS 'Receipt No', 
                ph.Supplier, 
                CONVERT(varchar, ph.Date, 103) AS Date, 
                pg.ItemName AS 'Item Name', 
                pg.Qty, 
                pg.UnitPrice AS 'Unit Price', 
                pg.Value 
            FROM [PurchaseHeader] ph 
            INNER JOIN [PurchaseGrid] pg ON ph.ReceiptNo = pg.ReceiptNo 
            WHERE ph.Date BETWEEN @fromDate AND @toDate;";

                string totalQuery = @"
            SELECT SUM(pg.Value) 
            FROM [PurchaseHeader] ph 
            INNER JOIN [PurchaseGrid] pg ON ph.ReceiptNo = pg.ReceiptNo 
            WHERE ph.Date BETWEEN @fromDate AND @toDate;";

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

                            allPurchGrid.DataSource = dt;
                            allPurchGrid.Refresh();
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

        private void loadGridFromRecNo()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(recNoTxt.Text))
                {
                    MessageBox.Show("Please enter a Receipt No for search.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Try to parse the receipt number
                if (!int.TryParse(recNoTxt.Text, out int recNo))
                {
                    MessageBox.Show("Invalid Receipt No. Please enter a numeric value.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    recNoTxt.Text = string.Empty;
                    return;
                }

                DbConnection db = new DbConnection();
                string connectionString = db.GetConnectionString();

                string query = @"
            SELECT 
                ph.ReceiptNo AS 'Receipt No', 
                ph.Supplier, 
                CONVERT(varchar, ph.Date, 103) AS Date, 
                pg.ItemName AS 'Item Name', 
                pg.Qty, 
                pg.UnitPrice AS 'Unit Price', 
                pg.Value 
            FROM [PurchaseHeader] ph 
            INNER JOIN [PurchaseGrid] pg ON ph.ReceiptNo = pg.ReceiptNo 
            WHERE ph.ReceiptNo = @recNo;";

                string totalQuery = @"
            SELECT SUM(pg.Value) 
            FROM [PurchaseHeader] ph 
            INNER JOIN [PurchaseGrid] pg ON ph.ReceiptNo = pg.ReceiptNo 
            WHERE ph.ReceiptNo = @recNo;";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@recNo", recNo);

                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            if (dt.Rows.Count == 0)
                            {
                                MessageBox.Show("No purchases found for the enterd Receipt No.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            allPurchGrid.DataSource = dt;
                            allPurchGrid.Refresh();
                        }
                    }

                    using (SqlCommand totalCmd = new SqlCommand(totalQuery, conn))
                    {
                        totalCmd.Parameters.AddWithValue("@recNo", recNo);

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

        public AllPurchasesFrm()
        {
            InitializeComponent();
        }

        private void AllPurchasesFrm_Load(object sender, EventArgs e)
        {
            getMinDates();
            loadGrid(fromDate.Value,DateTime.Now.Date);
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            loadGrid(fromDate.Value,toDate.Value);
        }

        private void srchRecBtn_Click(object sender, EventArgs e)
        {
            loadGridFromRecNo();
        }
    }
}
