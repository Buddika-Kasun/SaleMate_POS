namespace SaleMate_POS
{
    partial class LoginFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginFrm));
            this.usrNmLbl = new System.Windows.Forms.Label();
            this.pwLbl = new System.Windows.Forms.Label();
            this.userNmTxt = new System.Windows.Forms.TextBox();
            this.pwTxt = new System.Windows.Forms.TextBox();
            this.loginBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.errLbl = new System.Windows.Forms.Label();
            this.showBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usrNmLbl
            // 
            this.usrNmLbl.AutoSize = true;
            this.usrNmLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usrNmLbl.Location = new System.Drawing.Point(114, 154);
            this.usrNmLbl.Name = "usrNmLbl";
            this.usrNmLbl.Size = new System.Drawing.Size(144, 29);
            this.usrNmLbl.TabIndex = 1;
            this.usrNmLbl.Text = "User Name";
            // 
            // pwLbl
            // 
            this.pwLbl.AutoSize = true;
            this.pwLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwLbl.Location = new System.Drawing.Point(114, 214);
            this.pwLbl.Name = "pwLbl";
            this.pwLbl.Size = new System.Drawing.Size(128, 29);
            this.pwLbl.TabIndex = 2;
            this.pwLbl.Text = "Password";
            // 
            // userNmTxt
            // 
            this.userNmTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNmTxt.Location = new System.Drawing.Point(317, 151);
            this.userNmTxt.Name = "userNmTxt";
            this.userNmTxt.Size = new System.Drawing.Size(317, 35);
            this.userNmTxt.TabIndex = 3;
            // 
            // pwTxt
            // 
            this.pwTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwTxt.Location = new System.Drawing.Point(317, 211);
            this.pwTxt.Name = "pwTxt";
            this.pwTxt.Size = new System.Drawing.Size(224, 35);
            this.pwTxt.TabIndex = 4;
            this.pwTxt.UseSystemPasswordChar = true;
            // 
            // loginBtn
            // 
            this.loginBtn.BackColor = System.Drawing.Color.DarkBlue;
            this.loginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.loginBtn.Location = new System.Drawing.Point(317, 317);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(151, 49);
            this.loginBtn.TabIndex = 5;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = false;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(247, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(269, 32);
            this.label4.TabIndex = 8;
            this.label4.Text = "Login to Sale Mate";
            // 
            // errLbl
            // 
            this.errLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.errLbl.AutoSize = true;
            this.errLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errLbl.ForeColor = System.Drawing.Color.Red;
            this.errLbl.Location = new System.Drawing.Point(70, 272);
            this.errLbl.Name = "errLbl";
            this.errLbl.Size = new System.Drawing.Size(626, 22);
            this.errLbl.TabIndex = 11;
            this.errLbl.Text = "*Forgot you user name or password? Log in with an admin account to reset it.\r\n";
            this.errLbl.Visible = false;
            // 
            // showBtn
            // 
            this.showBtn.Location = new System.Drawing.Point(561, 211);
            this.showBtn.Name = "showBtn";
            this.showBtn.Size = new System.Drawing.Size(73, 42);
            this.showBtn.TabIndex = 12;
            this.showBtn.Text = "Show";
            this.showBtn.UseVisualStyleBackColor = true;
            this.showBtn.Click += new System.EventHandler(this.showBtn_Click);
            // 
            // LoginFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 450);
            this.Controls.Add(this.showBtn);
            this.Controls.Add(this.errLbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.pwTxt);
            this.Controls.Add(this.userNmTxt);
            this.Controls.Add(this.pwLbl);
            this.Controls.Add(this.usrNmLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "LoginFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginFrm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usrNmLbl;
        private System.Windows.Forms.Label pwLbl;
        private System.Windows.Forms.TextBox userNmTxt;
        private System.Windows.Forms.TextBox pwTxt;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label errLbl;
        private System.Windows.Forms.Button showBtn;
    }
}

