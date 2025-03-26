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
    public partial class GoodReceiptFrm : Form
    {

        private void genRcptNo()
        {
            try
            {
                DbConnection db = new DbConnection();

                string queryLastRcptNo = "SELECT ISNULL(MAX(ReceiptNo), 0) AS LastReceiptNo FROM [PurchaseHeader];";

                object result = db.ExecuteScalar(queryLastRcptNo);

                int lastRcptNo = result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;

                int newRcptNo = lastRcptNo + 1;
                reciptNoTxt.Text = newRcptNo.ToString();
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
                (e.ColumnIndex == purchGrid.Columns["qty"].Index || e.ColumnIndex == purchGrid.Columns["unitPrice"].Index))
            {
                // Get the row being edited
                DataGridViewRow row = purchGrid.Rows[e.RowIndex];

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
            if (purchGrid.Columns.Contains("value"))
            {
                foreach (DataGridViewRow row in purchGrid.Rows)
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
            suplrTxt.Text = string.Empty;
            purchGrid.Rows.Clear();
            totalValTxt.Text = "0.00";

            genRcptNo();
        }

        private void insertPurch()
        {
            // Validate supplier field
            if (string.IsNullOrWhiteSpace(suplrTxt.Text))
            {
                MessageBox.Show("Supplier field cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate that at least one row exists in the grid
            if (purchGrid.Rows.Count == 0 || purchGrid.Rows.Cast<DataGridViewRow>().All(row => row.IsNewRow))
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
                string insertHeaderQuery = "INSERT INTO [PurchaseHeader] (ReceiptNo, Supplier, TotalValue, Date) VALUES (@receiptNo, @supplier, @totalValue, @currentDate)";
                SqlParameter[] headerParams =
                {
                    new SqlParameter("@receiptNo", reciptNoTxt.Text),
                    new SqlParameter("@supplier", suplrTxt.Text),
                    new SqlParameter("@totalValue", totalValue),
                    new SqlParameter("@currentDate", currentDate)
                };
                db.ExecuteNonQuery(insertHeaderQuery, headerParams);

                // Insert each row into saleGrid table
                int rowNo = 1;
                foreach (DataGridViewRow row in purchGrid.Rows)
                {
                    if (row.IsNewRow) continue; // Skip empty new row

                    string itemName = row.Cells["itemName"].Value?.ToString();
                    if (!decimal.TryParse(row.Cells["qty"].Value?.ToString(), out decimal qty)) qty = 0;
                    if (!decimal.TryParse(row.Cells["unitPrice"].Value?.ToString(), out decimal unitPrice)) unitPrice = 0;
                    if (!decimal.TryParse(row.Cells["value"].Value?.ToString(), out decimal value)) value = 0;

                    string insertGridQuery = "INSERT INTO [PurchaseGrid] (ReceiptNo, RowNo, ItemName, Qty, UnitPrice, Value) VALUES (@receiptNo, @rowNo, @itemName, @qty, @unitPrice, @value)";
                    SqlParameter[] gridParams =
                    {
                        new SqlParameter("@receiptNo", reciptNoTxt.Text),
                        new SqlParameter("@rowNo", rowNo),
                        new SqlParameter("@itemName", itemName),
                        new SqlParameter("@qty", qty),
                        new SqlParameter("@unitPrice", unitPrice),
                        new SqlParameter("@value", value)
                    };
                    db.ExecuteNonQuery(insertGridQuery, gridParams);

                    rowNo++; // Increment row number for each row
                }

                MessageBox.Show("Purchase recorded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearAll(); // Clear form after submission
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while saving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public GoodReceiptFrm()
        {
            InitializeComponent();
        }

        private void GoodReceiptFrm_Load(object sender, EventArgs e)
        {
            genRcptNo();
        }

        private void purchGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            calGridValue(e);
        }

        private void purchGrid_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Ensure the row is not the new row
            if (purchGrid.Rows[e.RowIndex].IsNewRow) return;

            DataGridViewRow row = purchGrid.Rows[e.RowIndex];

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

        private void clearBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear all fields?", "Confirm Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                clearAll();
            }
        }

        private void purchsBtn_Click(object sender, EventArgs e)
        {
            insertPurch();
        }

        private void purchGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (purchGrid.Columns[e.ColumnIndex].Name == "remove" && e.RowIndex >= 0)
            {
                if (purchGrid.Rows[e.RowIndex].IsNewRow)
                {
                    MessageBox.Show("New row can't delete.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Are you sure to delete this record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    purchGrid.Rows.RemoveAt(e.RowIndex);
                    calTotalValue();
                }
            }
        }
    }
}
