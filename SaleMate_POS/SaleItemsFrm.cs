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
    public partial class SaleItemsFrm : Form
    {

        private void genSalesNo()
        {
            try
            {
                DbConnection db = new DbConnection();

                string queryLastSalesNo = "SELECT ISNULL(MAX(SaleNo), 0) AS LastSalesNo FROM [SalesHeader];";

                object result = db.ExecuteScalar(queryLastSalesNo);

                int lastSalesNo = result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;

                int newSalesNo = lastSalesNo + 1;
                saleNoTxt.Text = newSalesNo.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void calGridValue(DataGridViewCellEventArgs e)
        {
            // Ensure the changed cell is in either the "qty" or "unitPrice" column
            if (e.RowIndex >= 0 &&
                (e.ColumnIndex == salesGrid.Columns["qty"].Index || e.ColumnIndex == salesGrid.Columns["unitPrice"].Index))
            {
                // Get the row being edited
                DataGridViewRow row = salesGrid.Rows[e.RowIndex];

                // Get cell values as strings
                string qtyText = row.Cells["qty"].Value?.ToString().Trim();
                string unitPriceText = row.Cells["unitPrice"].Value?.ToString().Trim();

                decimal qty = 0, unitPrice = 0;
                bool isQtyValid = decimal.TryParse(qtyText, out qty) && qty >= 0;
                bool isUnitPriceValid = decimal.TryParse(unitPriceText, out unitPrice) && unitPrice >= 0;

                // Validate input
                if (!string.IsNullOrEmpty(qtyText) && !isQtyValid)
                {
                    MessageBox.Show("Please enter a valid non-negative number for Qty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    row.Cells["qty"].Value = string.Empty;
                }

                if (!string.IsNullOrEmpty(unitPriceText) && !isUnitPriceValid)
                {
                    MessageBox.Show("Please enter a valid non-negative number for Unit Price.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    row.Cells["unitPrice"].Value = string.Empty;
                }

                // Calculate value only if both qty and unitPrice are valid
                if (isQtyValid && isUnitPriceValid)
                {
                    decimal value = qty * unitPrice;
                    row.Cells["value"].Value = value.ToString("F2"); // Format to 2 decimal places
                }
                else
                {
                    row.Cells["value"].Value = string.Empty; // Clear value if input is invalid
                }
            }

            calTotalValue();

        }

        // Function to calculate and update the total value
        private void calTotalValue()
        {

            decimal total = 0;

            // Ensure "value" column exists before summing values
            if (salesGrid.Columns.Contains("value"))
            {
                foreach (DataGridViewRow row in salesGrid.Rows)
                {
                    if (row.Cells["value"].Value != null && decimal.TryParse(row.Cells["value"].Value?.ToString(), out decimal rowValue))
                    {
                        total += rowValue;
                    }
                }
            }

            totalValTxt.Text = total.ToString("F2"); // Format to 2 decimal places
        }

        private void clearAll()
        {
            cstmrTxt.Text = string.Empty;
            salesGrid.Rows.Clear();
            totalValTxt.Text = "0.00";

            genSalesNo();
        }

        private void insertSale()
        {
            // Validate supplier field
            if (string.IsNullOrWhiteSpace(cstmrTxt.Text))
            {
                MessageBox.Show("Customer field cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate that at least one row exists in the grid
            if (salesGrid.Rows.Count == 0 || salesGrid.Rows.Cast<DataGridViewRow>().All(row => row.IsNewRow))
            {
                MessageBox.Show("At least one item must be added to the grid before submitting.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Create database connection object
                DbConnection db = new DbConnection();

                // Get total value from totalValTxt
                if (!decimal.TryParse(totalValTxt.Text, out decimal totalValue))
                {
                    MessageBox.Show("Invalid total value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get current date in dd/MM/yyyy format
                //string currentDate = DateTime.Now.ToString("dd/MM/yyyy");
                DateTime currentDate = DateTime.Now.Date;

                // Insert into saleHeader table
                string insertHeaderQuery = "INSERT INTO [SalesHeader] (SaleNo, Customer, TotalValue, Date) VALUES (@saleNo, @customer, @totalValue, @currentDate)";
                SqlParameter[] headerParams =
                {
                    new SqlParameter("@saleNo", saleNoTxt.Text),
                    new SqlParameter("@customer", cstmrTxt.Text),
                    new SqlParameter("@totalValue", totalValue),
                    new SqlParameter("@currentDate", currentDate)
                };
                db.ExecuteNonQuery(insertHeaderQuery, headerParams);

                // Insert each row into saleGrid table
                int rowNo = 1;
                foreach (DataGridViewRow row in salesGrid.Rows)
                {
                    if (row.IsNewRow) continue; // Skip empty new row

                    string itemName = row.Cells["itemName"].Value?.ToString();
                    if (!decimal.TryParse(row.Cells["qty"].Value?.ToString(), out decimal qty)) qty = 0;
                    if (!decimal.TryParse(row.Cells["unitPrice"].Value?.ToString(), out decimal unitPrice)) unitPrice = 0;
                    if (!decimal.TryParse(row.Cells["value"].Value?.ToString(), out decimal value)) value = 0;

                    string insertGridQuery = "INSERT INTO [SalesGrid] (SaleNo, RowNo, ItemName, Qty, UnitPrice, Value) VALUES (@saleNo, @rowNo, @itemName, @qty, @unitPrice, @value)";
                    SqlParameter[] gridParams =
                    {
                        new SqlParameter("@saleNo", saleNoTxt.Text),
                        new SqlParameter("@rowNo", rowNo),
                        new SqlParameter("@itemName", itemName),
                        new SqlParameter("@qty", qty),
                        new SqlParameter("@unitPrice", unitPrice),
                        new SqlParameter("@value", value)
                    };
                    db.ExecuteNonQuery(insertGridQuery, gridParams);

                    rowNo++; // Increment row number for each row
                }

                MessageBox.Show("Sale recorded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearAll(); // Clear form after submission
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while saving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public SaleItemsFrm()
        {
            InitializeComponent();
        }

        private void SaleItemsFrm_Load(object sender, EventArgs e)
        {
            genSalesNo();
        }

        private void salesGrid_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Ensure the row is not the new row
            if (salesGrid.Rows[e.RowIndex].IsNewRow) return;

            DataGridViewRow row = salesGrid.Rows[e.RowIndex];

            // Get cell values
            string itemName = row.Cells["itemName"].Value?.ToString().Trim();
            string qtyText = row.Cells["qty"].Value?.ToString().Trim();
            string unitPriceText = row.Cells["unitPrice"].Value?.ToString().Trim();

            // Validate required fields
            if (string.IsNullOrEmpty(itemName) || string.IsNullOrEmpty(qtyText) || string.IsNullOrEmpty(unitPriceText))
            {
                
                MessageBox.Show("Please fill all fields before moving to the next row.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true; // Prevent moving to the next row
            }
        }

        private void salesGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            calGridValue(e);
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear all fields?", "Confirm Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                clearAll();
            }
        }

        private void saleBtn_Click(object sender, EventArgs e)
        {
            insertSale();
        }

        private void salesGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (salesGrid.Columns[e.ColumnIndex].Name == "remove" && e.RowIndex >= 0)
            {
                if (salesGrid.Rows[e.RowIndex].IsNewRow)
                {
                    MessageBox.Show("New row can't delete.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Are you sure to delete this record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    salesGrid.Rows.RemoveAt(e.RowIndex);
                    calTotalValue();
                }
            }
        }

        private void SaleItemsFrm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                saleBtn.PerformClick();
            }

            if ((e.KeyCode == Keys.Delete))
            {
                clearBtn.PerformClick();
            }
        }
    }
}
