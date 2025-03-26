namespace SaleMate_POS
{
    partial class GoodReceiptFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.reciptNoTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.suplrTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.clearBtn = new System.Windows.Forms.Button();
            this.purchsBtn = new System.Windows.Forms.Button();
            this.totalValTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.purchGrid = new System.Windows.Forms.DataGridView();
            this.itemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.purchGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1141, 56);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 32);
            this.label4.TabIndex = 8;
            this.label4.Text = "Good Receipt";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.reciptNoTxt);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.suplrTxt);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1141, 133);
            this.panel2.TabIndex = 9;
            // 
            // reciptNoTxt
            // 
            this.reciptNoTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reciptNoTxt.Location = new System.Drawing.Point(667, 44);
            this.reciptNoTxt.Name = "reciptNoTxt";
            this.reciptNoTxt.ReadOnly = true;
            this.reciptNoTxt.Size = new System.Drawing.Size(108, 35);
            this.reciptNoTxt.TabIndex = 7;
            this.reciptNoTxt.Text = "0";
            this.reciptNoTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(513, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 29);
            this.label2.TabIndex = 6;
            this.label2.Text = "Receipt No";
            // 
            // suplrTxt
            // 
            this.suplrTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suplrTxt.Location = new System.Drawing.Point(136, 44);
            this.suplrTxt.Name = "suplrTxt";
            this.suplrTxt.Size = new System.Drawing.Size(308, 35);
            this.suplrTxt.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Supplier";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.clearBtn);
            this.panel3.Controls.Add(this.purchsBtn);
            this.panel3.Controls.Add(this.totalValTxt);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 464);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1141, 160);
            this.panel3.TabIndex = 10;
            // 
            // clearBtn
            // 
            this.clearBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearBtn.BackColor = System.Drawing.Color.Red;
            this.clearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.clearBtn.Location = new System.Drawing.Point(775, 77);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(140, 52);
            this.clearBtn.TabIndex = 11;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = false;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // purchsBtn
            // 
            this.purchsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.purchsBtn.BackColor = System.Drawing.Color.DarkBlue;
            this.purchsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purchsBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.purchsBtn.Location = new System.Drawing.Point(964, 77);
            this.purchsBtn.Name = "purchsBtn";
            this.purchsBtn.Size = new System.Drawing.Size(140, 52);
            this.purchsBtn.TabIndex = 10;
            this.purchsBtn.Text = "Purchase";
            this.purchsBtn.UseVisualStyleBackColor = false;
            this.purchsBtn.Click += new System.EventHandler(this.purchsBtn_Click);
            // 
            // totalValTxt
            // 
            this.totalValTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalValTxt.Location = new System.Drawing.Point(180, 27);
            this.totalValTxt.Name = "totalValTxt";
            this.totalValTxt.ReadOnly = true;
            this.totalValTxt.Size = new System.Drawing.Size(160, 35);
            this.totalValTxt.TabIndex = 9;
            this.totalValTxt.Text = "0.00";
            this.totalValTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 29);
            this.label3.TabIndex = 8;
            this.label3.Text = "Total Value";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.purchGrid);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 189);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1141, 275);
            this.panel4.TabIndex = 10;
            // 
            // purchGrid
            // 
            this.purchGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.purchGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.purchGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.purchGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.purchGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.purchGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.purchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.purchGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemName,
            this.qty,
            this.unitPrice,
            this.value,
            this.remove});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.purchGrid.DefaultCellStyle = dataGridViewCellStyle7;
            this.purchGrid.Location = new System.Drawing.Point(18, 0);
            this.purchGrid.Margin = new System.Windows.Forms.Padding(10);
            this.purchGrid.Name = "purchGrid";
            this.purchGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.purchGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.purchGrid.RowHeadersVisible = false;
            this.purchGrid.RowHeadersWidth = 62;
            this.purchGrid.RowTemplate.Height = 28;
            this.purchGrid.Size = new System.Drawing.Size(1086, 275);
            this.purchGrid.TabIndex = 0;
            this.purchGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.purchGrid_CellContentClick);
            this.purchGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.purchGrid_CellValueChanged);
            this.purchGrid.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.purchGrid_RowValidating);
            // 
            // itemName
            // 
            this.itemName.FillWeight = 50F;
            this.itemName.HeaderText = "Item Name";
            this.itemName.MinimumWidth = 8;
            this.itemName.Name = "itemName";
            // 
            // qty
            // 
            this.qty.FillWeight = 10F;
            this.qty.HeaderText = "Qty";
            this.qty.MinimumWidth = 8;
            this.qty.Name = "qty";
            // 
            // unitPrice
            // 
            this.unitPrice.FillWeight = 20F;
            this.unitPrice.HeaderText = "Unit Price";
            this.unitPrice.MinimumWidth = 8;
            this.unitPrice.Name = "unitPrice";
            // 
            // value
            // 
            this.value.FillWeight = 20F;
            this.value.HeaderText = "Value";
            this.value.MinimumWidth = 8;
            this.value.Name = "value";
            this.value.ReadOnly = true;
            // 
            // remove
            // 
            this.remove.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remove.DefaultCellStyle = dataGridViewCellStyle6;
            this.remove.FillWeight = 7F;
            this.remove.HeaderText = "";
            this.remove.MinimumWidth = 8;
            this.remove.Name = "remove";
            this.remove.Text = "X";
            this.remove.ToolTipText = "Delete row";
            this.remove.UseColumnTextForButtonValue = true;
            this.remove.Width = 40;
            // 
            // GoodReceiptFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 624);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "GoodReceiptFrm";
            this.Text = "GoodReceiptFrm";
            this.Load += new System.EventHandler(this.GoodReceiptFrm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GoodReceiptFrm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.purchGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox suplrTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox reciptNoTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox totalValTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button purchsBtn;
        private System.Windows.Forms.DataGridView purchGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn value;
        private System.Windows.Forms.DataGridViewButtonColumn remove;
    }
}