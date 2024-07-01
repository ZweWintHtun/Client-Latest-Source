namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00024
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00024));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblLoanNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtLoanNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblSanctionAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtSanctionAmount = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblEntryNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtEntryNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblVoucherDate2 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblVoucherDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPartialAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblEnterSanctionAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.rdoFull = new System.Windows.Forms.RadioButton();
            this.rdoPartial = new System.Windows.Forms.RadioButton();
            this.gdvAccountInfo = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDebitCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCurrency = new Ace.Windows.CXClient.Controls.CXC0001();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvAccountInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-4, -1);
            this.tsbCRUD.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(961, 38);
            this.tsbCRUD.TabIndex = 10;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblLoanNo
            // 
            this.lblLoanNo.AutoSize = true;
            this.lblLoanNo.Location = new System.Drawing.Point(24, 75);
            this.lblLoanNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLoanNo.Name = "lblLoanNo";
            this.lblLoanNo.Size = new System.Drawing.Size(74, 17);
            this.lblLoanNo.TabIndex = 0;
            this.lblLoanNo.Text = "Loan No. :";
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(24, 112);
            this.lblCurrency.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(73, 17);
            this.lblCurrency.TabIndex = 0;
            this.lblCurrency.Text = "Currency :";
            // 
            // txtLoanNo
            // 
            this.txtLoanNo.IsSendTabOnEnter = true;
            this.txtLoanNo.Location = new System.Drawing.Point(163, 71);
            this.txtLoanNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLoanNo.MaxLength = 15;
            this.txtLoanNo.Name = "txtLoanNo";
            this.txtLoanNo.Size = new System.Drawing.Size(183, 22);
            this.txtLoanNo.TabIndex = 1;
            this.txtLoanNo.TextChanged += new System.EventHandler(this.txtLoanNo_TextChanged);
            this.txtLoanNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLoanNo_KeyDown);
            this.txtLoanNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLoanNo_KeyPress);
            // 
            // lblSanctionAmount
            // 
            this.lblSanctionAmount.AutoSize = true;
            this.lblSanctionAmount.Location = new System.Drawing.Point(24, 146);
            this.lblSanctionAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSanctionAmount.Name = "lblSanctionAmount";
            this.lblSanctionAmount.Size = new System.Drawing.Size(123, 17);
            this.lblSanctionAmount.TabIndex = 0;
            this.lblSanctionAmount.Text = "Sanction Amount :";
            // 
            // txtSanctionAmount
            // 
            this.txtSanctionAmount.Enabled = false;
            this.txtSanctionAmount.IsSendTabOnEnter = true;
            this.txtSanctionAmount.Location = new System.Drawing.Point(163, 143);
            this.txtSanctionAmount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSanctionAmount.Name = "txtSanctionAmount";
            this.txtSanctionAmount.Size = new System.Drawing.Size(183, 22);
            this.txtSanctionAmount.TabIndex = 0;
            // 
            // lblEntryNo
            // 
            this.lblEntryNo.AutoSize = true;
            this.lblEntryNo.Location = new System.Drawing.Point(24, 39);
            this.lblEntryNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEntryNo.Name = "lblEntryNo";
            this.lblEntryNo.Size = new System.Drawing.Size(75, 17);
            this.lblEntryNo.TabIndex = 0;
            this.lblEntryNo.Text = "Entry No. :";
            // 
            // txtEntryNo
            // 
            this.txtEntryNo.Enabled = false;
            this.txtEntryNo.IsSendTabOnEnter = true;
            this.txtEntryNo.Location = new System.Drawing.Point(163, 36);
            this.txtEntryNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEntryNo.Name = "txtEntryNo";
            this.txtEntryNo.Size = new System.Drawing.Size(183, 22);
            this.txtEntryNo.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblEntryNo);
            this.groupBox1.Controls.Add(this.lblVoucherDate2);
            this.groupBox1.Controls.Add(this.lblVoucherDate);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.gdvAccountInfo);
            this.groupBox1.Controls.Add(this.txtSanctionAmount);
            this.groupBox1.Controls.Add(this.lblLoanNo);
            this.groupBox1.Controls.Add(this.lblSanctionAmount);
            this.groupBox1.Controls.Add(this.txtCurrency);
            this.groupBox1.Controls.Add(this.txtLoanNo);
            this.groupBox1.Controls.Add(this.txtEntryNo);
            this.groupBox1.Controls.Add(this.lblCurrency);
            this.groupBox1.Location = new System.Drawing.Point(11, 38);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(937, 459);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblVoucherDate2
            // 
            this.lblVoucherDate2.AutoSize = true;
            this.lblVoucherDate2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblVoucherDate2.Location = new System.Drawing.Point(787, 36);
            this.lblVoucherDate2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVoucherDate2.Name = "lblVoucherDate2";
            this.lblVoucherDate2.Size = new System.Drawing.Size(91, 17);
            this.lblVoucherDate2.TabIndex = 4;
            this.lblVoucherDate2.Text = "VoucherDate";
            // 
            // lblVoucherDate
            // 
            this.lblVoucherDate.AutoSize = true;
            this.lblVoucherDate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblVoucherDate.Location = new System.Drawing.Point(669, 36);
            this.lblVoucherDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVoucherDate.Name = "lblVoucherDate";
            this.lblVoucherDate.Size = new System.Drawing.Size(107, 17);
            this.lblVoucherDate.TabIndex = 3;
            this.lblVoucherDate.Text = "Voucher Date  :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPartialAmount);
            this.groupBox2.Controls.Add(this.lblEnterSanctionAmount);
            this.groupBox2.Controls.Add(this.rdoFull);
            this.groupBox2.Controls.Add(this.rdoPartial);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(384, 65);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(381, 102);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Please Select Voucher Type";
            this.groupBox2.Visible = false;
            // 
            // txtPartialAmount
            // 
            this.txtPartialAmount.DecimalPlaces = 0;
            this.txtPartialAmount.IsSendTabOnEnter = true;
            this.txtPartialAmount.IsThousandSeperator = true;
            this.txtPartialAmount.Location = new System.Drawing.Point(151, 64);
            this.txtPartialAmount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPartialAmount.Name = "txtPartialAmount";
            this.txtPartialAmount.Size = new System.Drawing.Size(187, 22);
            this.txtPartialAmount.TabIndex = 3;
            this.txtPartialAmount.Text = "0.00";
            this.txtPartialAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPartialAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtPartialAmount.Leave += new System.EventHandler(this.txtPartialAmount_Leave);
            // 
            // lblEnterSanctionAmount
            // 
            this.lblEnterSanctionAmount.AutoSize = true;
            this.lblEnterSanctionAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnterSanctionAmount.Location = new System.Drawing.Point(35, 68);
            this.lblEnterSanctionAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEnterSanctionAmount.Name = "lblEnterSanctionAmount";
            this.lblEnterSanctionAmount.Size = new System.Drawing.Size(108, 17);
            this.lblEnterSanctionAmount.TabIndex = 42;
            this.lblEnterSanctionAmount.Text = "Partial Amount :";
            // 
            // rdoFull
            // 
            this.rdoFull.AutoSize = true;
            this.rdoFull.Checked = true;
            this.rdoFull.Location = new System.Drawing.Point(40, 33);
            this.rdoFull.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoFull.Name = "rdoFull";
            this.rdoFull.Size = new System.Drawing.Size(51, 21);
            this.rdoFull.TabIndex = 2;
            this.rdoFull.TabStop = true;
            this.rdoFull.Text = "Full";
            this.rdoFull.UseVisualStyleBackColor = true;
            this.rdoFull.CheckedChanged += new System.EventHandler(this.rdoPartial_CheckedChanged);
            // 
            // rdoPartial
            // 
            this.rdoPartial.AutoSize = true;
            this.rdoPartial.Location = new System.Drawing.Point(159, 34);
            this.rdoPartial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoPartial.Name = "rdoPartial";
            this.rdoPartial.Size = new System.Drawing.Size(69, 21);
            this.rdoPartial.TabIndex = 2;
            this.rdoPartial.Text = "Partial";
            this.rdoPartial.UseVisualStyleBackColor = true;
            this.rdoPartial.CheckedChanged += new System.EventHandler(this.rdoPartial_CheckedChanged);
            // 
            // gdvAccountInfo
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gdvAccountInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gdvAccountInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvAccountInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAccountNo,
            this.colDescription,
            this.colAmount,
            this.colDebitCredit});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gdvAccountInfo.DefaultCellStyle = dataGridViewCellStyle3;
            this.gdvAccountInfo.Enabled = false;
            this.gdvAccountInfo.EnableHeadersVisualStyles = false;
            this.gdvAccountInfo.IdTSList = null;
            this.gdvAccountInfo.IsEscapeKey = false;
            this.gdvAccountInfo.IsHeaderClick = false;
            this.gdvAccountInfo.Location = new System.Drawing.Point(28, 191);
            this.gdvAccountInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gdvAccountInfo.Name = "gdvAccountInfo";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gdvAccountInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gdvAccountInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.gdvAccountInfo.ShowSerialNo = false;
            this.gdvAccountInfo.Size = new System.Drawing.Size(880, 245);
            this.gdvAccountInfo.TabIndex = 0;
            // 
            // colAccountNo
            // 
            this.colAccountNo.DataPropertyName = "CreditAccountNo1";
            this.colAccountNo.HeaderText = "Account No.";
            this.colAccountNo.Name = "colAccountNo";
            this.colAccountNo.Width = 120;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "BankAccountDescription";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 300;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "CreditAmount1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.Width = 120;
            // 
            // colDebitCredit
            // 
            this.colDebitCredit.DataPropertyName = "CreditDescription2";
            this.colDebitCredit.HeaderText = "Debit\\Credit";
            this.colDebitCredit.Name = "colDebitCredit";
            this.colDebitCredit.Width = 70;
            // 
            // txtCurrency
            // 
            this.txtCurrency.Enabled = false;
            this.txtCurrency.IsSendTabOnEnter = true;
            this.txtCurrency.Location = new System.Drawing.Point(163, 107);
            this.txtCurrency.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.Size = new System.Drawing.Size(183, 22);
            this.txtCurrency.TabIndex = 0;
            // 
            // LOMVEW00024
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 512);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsbCRUD);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LOMVEW00024";
            this.Text = "Loan Voucher Entry";
            this.Load += new System.EventHandler(this.LOMVEW00024_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvAccountInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0003 lblLoanNo;
        private Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Windows.CXClient.Controls.CXC0001 txtLoanNo;
        private Windows.CXClient.Controls.CXC0003 lblSanctionAmount;
        private Windows.CXClient.Controls.CXC0001 txtSanctionAmount;
        private Windows.CXClient.Controls.CXC0003 lblEntryNo;
        private Windows.CXClient.Controls.CXC0001 txtEntryNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private Windows.CXClient.Controls.AceGridView gdvAccountInfo;
        private Windows.CXClient.Controls.CXC0001 txtCurrency;
        private Windows.CXClient.Controls.CXC0003 lblVoucherDate2;
        private Windows.CXClient.Controls.CXC0003 lblVoucherDate;
        private System.Windows.Forms.GroupBox groupBox2;
        private Windows.CXClient.Controls.CXC0004 txtPartialAmount;
        private Windows.CXClient.Controls.CXC0003 lblEnterSanctionAmount;
        private System.Windows.Forms.RadioButton rdoFull;
        private System.Windows.Forms.RadioButton rdoPartial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDebitCredit;
    }
}