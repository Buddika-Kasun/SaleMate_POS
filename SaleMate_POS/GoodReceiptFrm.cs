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
    }
}
