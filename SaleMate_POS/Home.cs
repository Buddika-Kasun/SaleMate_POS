using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

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

        public void ChangBtnClr(object sender)
        {
            // Define the buttons you want to manage
            Button[] btns = { goodRecBtn, allPurchBtn, allSalesBtn, saleItmBtn, cngPwBtn };

            // Loop through each button
            foreach (Button btn in btns)
            {
                if (btn == (Button)sender) // Check if the current button matches the clicked button
                {
                    btn.BackColor = SystemColors.HotTrack; // Set background color to blue
                    btn.ForeColor = SystemColors.InactiveBorder;
                }
                else
                {
                    btn.BackColor = SystemColors.InactiveBorder; // Set background color to white
                    btn.ForeColor = SystemColors.InfoText;
                }
            }
        }

        public HomeFrm(string username)
        {
            this.loggedInUser = username;
            InitializeComponent();
        }

        private void HomeFrm_Load(object sender, EventArgs e)
        {
            userNameLbl.Text = loggedInUser;
            dateLbl.Text = DateTime.Now.ToString("yyyy-MM-dd"); // Output: 2023-10-05

            if(loggedInUser == "admin")
            {
                panel3.Visible = false;
                panel4.Visible = false;
            }

            showChildForm(new DashboardFrm());
        }

        private void goodRecBtn_Click(object sender, EventArgs e)
        {
            showChildForm(new GoodReceiptFrm());
            ChangBtnClr(goodRecBtn);
        }

        private void allPurchBtn_Click(object sender, EventArgs e)
        {
            showChildForm(new AllPurchasesFrm());
            ChangBtnClr(allPurchBtn);
        }

        private void saleItmBtn_Click(object sender, EventArgs e)
        {
            showChildForm(new SaleItemsFrm());
            ChangBtnClr(saleItmBtn);
        }

        private void allSalesBtn_Click(object sender, EventArgs e)
        {
            showChildForm(new AllSalesFrm());
            ChangBtnClr(allSalesBtn);
        }

        private void cngPwBtn_Click(object sender, EventArgs e)
        {
            showChildForm(new ChangePasswordFrm(loggedInUser));
            ChangBtnClr(cngPwBtn);
        }
    }
}
