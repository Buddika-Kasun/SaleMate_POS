using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SaleMate_POS
{
    public partial class LoginFrm : Form
    {
        public string LoggedInUser { get; private set; }

        public LoginFrm()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            LoggedInUser = "Admin";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
