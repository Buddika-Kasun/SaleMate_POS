namespace SaleMate_POS
{
    partial class ChangePasswordFrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.pwLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.userNmTxt = new System.Windows.Forms.TextBox();
            this.pwTxt = new System.Windows.Forms.TextBox();
            this.newPwTxt = new System.Windows.Forms.TextBox();
            this.svBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cnfrmPwTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pwErrLbl = new System.Windows.Forms.Label();
            this.showBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(164, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "New User Name";
            // 
            // pwLbl
            // 
            this.pwLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pwLbl.AutoSize = true;
            this.pwLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwLbl.Location = new System.Drawing.Point(164, 203);
            this.pwLbl.Name = "pwLbl";
            this.pwLbl.Size = new System.Drawing.Size(221, 29);
            this.pwLbl.TabIndex = 1;
            this.pwLbl.Text = "Current Password";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(164, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "New Password";
            // 
            // userNmTxt
            // 
            this.userNmTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userNmTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNmTxt.Location = new System.Drawing.Point(446, 130);
            this.userNmTxt.Name = "userNmTxt";
            this.userNmTxt.Size = new System.Drawing.Size(308, 35);
            this.userNmTxt.TabIndex = 1;
            this.userNmTxt.TextChanged += new System.EventHandler(this.userNmTxt_TextChanged);
            // 
            // pwTxt
            // 
            this.pwTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pwTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwTxt.Location = new System.Drawing.Point(446, 200);
            this.pwTxt.Name = "pwTxt";
            this.pwTxt.Size = new System.Drawing.Size(308, 35);
            this.pwTxt.TabIndex = 2;
            // 
            // newPwTxt
            // 
            this.newPwTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newPwTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPwTxt.Location = new System.Drawing.Point(446, 284);
            this.newPwTxt.Name = "newPwTxt";
            this.newPwTxt.PasswordChar = '*';
            this.newPwTxt.Size = new System.Drawing.Size(308, 35);
            this.newPwTxt.TabIndex = 3;
            this.newPwTxt.UseSystemPasswordChar = true;
            this.newPwTxt.Leave += new System.EventHandler(this.newPwTxt_Leave);
            // 
            // svBtn
            // 
            this.svBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.svBtn.BackColor = System.Drawing.Color.DarkBlue;
            this.svBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.svBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.svBtn.Location = new System.Drawing.Point(614, 435);
            this.svBtn.Name = "svBtn";
            this.svBtn.Size = new System.Drawing.Size(140, 52);
            this.svBtn.TabIndex = 5;
            this.svBtn.Text = "Save";
            this.svBtn.UseVisualStyleBackColor = false;
            this.svBtn.Click += new System.EventHandler(this.svBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(260, 32);
            this.label4.TabIndex = 7;
            this.label4.Text = "Change Password";
            // 
            // cnfrmPwTxt
            // 
            this.cnfrmPwTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cnfrmPwTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cnfrmPwTxt.Location = new System.Drawing.Point(446, 358);
            this.cnfrmPwTxt.Name = "cnfrmPwTxt";
            this.cnfrmPwTxt.Size = new System.Drawing.Size(308, 35);
            this.cnfrmPwTxt.TabIndex = 4;
            this.cnfrmPwTxt.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(164, 361);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(226, 29);
            this.label5.TabIndex = 8;
            this.label5.Text = "Confirm Password";
            // 
            // pwErrLbl
            // 
            this.pwErrLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pwErrLbl.AutoSize = true;
            this.pwErrLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwErrLbl.ForeColor = System.Drawing.Color.Red;
            this.pwErrLbl.Location = new System.Drawing.Point(165, 241);
            this.pwErrLbl.Name = "pwErrLbl";
            this.pwErrLbl.Size = new System.Drawing.Size(589, 22);
            this.pwErrLbl.TabIndex = 10;
            this.pwErrLbl.Text = "*Forgot you password? Log in with an admin account to reset  password.\r\n";
            this.pwErrLbl.Visible = false;
            // 
            // showBtn
            // 
            this.showBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.showBtn.Location = new System.Drawing.Point(772, 359);
            this.showBtn.Name = "showBtn";
            this.showBtn.Size = new System.Drawing.Size(73, 42);
            this.showBtn.TabIndex = 13;
            this.showBtn.Text = "Show";
            this.showBtn.UseVisualStyleBackColor = true;
            this.showBtn.Click += new System.EventHandler(this.showBtn_Click);
            // 
            // ChangePasswordFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 545);
            this.Controls.Add(this.showBtn);
            this.Controls.Add(this.pwErrLbl);
            this.Controls.Add(this.cnfrmPwTxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.svBtn);
            this.Controls.Add(this.newPwTxt);
            this.Controls.Add(this.pwTxt);
            this.Controls.Add(this.userNmTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pwLbl);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "ChangePasswordFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangePasswordFrm";
            this.Load += new System.EventHandler(this.ChangePasswordFrm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChangePasswordFrm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label pwLbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox userNmTxt;
        private System.Windows.Forms.TextBox pwTxt;
        private System.Windows.Forms.TextBox newPwTxt;
        private System.Windows.Forms.Button svBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cnfrmPwTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label pwErrLbl;
        private System.Windows.Forms.Button showBtn;
    }
}