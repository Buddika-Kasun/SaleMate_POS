using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaleMate_POS
{
    public partial class HomeFrm : Form
    {
        private string loggedInUser;

        private void showChildForm(object Form)
        {
            if (this.contentPnl.Controls.Count > 0)
            {
                this.contentPnl.Controls.RemoveAt(0);
            }

            Form form = Form as Form;

            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;

            this.contentPnl.Controls.Add(form);
            form.Show();
        }

        public HomeFrm(string username)
        {
            this.loggedInUser = username;
            InitializeComponent();
        }

        private void HomeFrm_Load(object sender, EventArgs e)
        {
            dateLbl.Text = DateTime.Now.ToString("yyyy-MM-dd"); // Output: 2023-10-05
        }

        private void goodRecBtn_Click(object sender, EventArgs e)
        {
            showChildForm(new GoodReceiptFrm());
        }

        private void allPurchBtn_Click(object sender, EventArgs e)
        {
            showChildForm(new AllPurchasesFrm());
        }

        private void saleItmBtn_Click(object sender, EventArgs e)
        {
            showChildForm(new SaleItemsFrm());
        }

        private void allSalesBtn_Click(object sender, EventArgs e)
        {
            showChildForm(new AllSalesFrm());
        }

        private void cngPwBtn_Click(object sender, EventArgs e)
        {
            showChildForm(new ChangePasswordFrm());
        }
    }
}
