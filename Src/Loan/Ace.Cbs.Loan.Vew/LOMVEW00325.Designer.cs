namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00325
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00325));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gdvAccountInfo = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDebitCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblVoucherDate2 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblVoucherDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblEntryNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtSanctionAmount = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblLoanNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblSanctionAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtCurrency = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtLoanNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtEntryNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvAccountInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-3, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(681, 31);
            this.tsbCRUD.TabIndex = 13;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gdvAccountInfo);
            this.groupBox1.Controls.Add(this.lblVoucherDate2);
            this.groupBox1.Controls.Add(this.lblVoucherDate);
            this.groupBox1.Controls.Add(this.lblEntryNo);
            this.groupBox1.Controls.Add(this.txtSanctionAmount);
            this.groupBox1.Controls.Add(this.lblLoanNo);
            this.groupBox1.Controls.Add(this.lblSanctionAmount);
            this.groupBox1.Controls.Add(this.txtCurrency);
            this.groupBox1.Controls.Add(this.txtLoanNo);
            this.groupBox1.Controls.Add(this.txtEntryNo);
            this.groupBox1.Controls.Add(this.lblCurrency);
            this.groupBox1.Location = new System.Drawing.Point(4, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(661, 391);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
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
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gdvAccountInfo.DefaultCellStyle = dataGridViewCellStyle6;
            this.gdvAccountInfo.Enabled = false;
            this.gdvAccountInfo.EnableHeadersVisualStyles = false;
            this.gdvAccountInfo.IdTSList = null;
            this.gdvAccountInfo.IsEscapeKey = false;
            this.gdvAccountInfo.IsHeaderClick = false;
            this.gdvAccountInfo.Location = new System.Drawing.Point(6, 138);
            this.gdvAccountInfo.Name = "gdvAccountInfo";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gdvAccountInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.gdvAccountInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.gdvAccountInfo.ShowSerialNo = false;
            this.gdvAccountInfo.Size = new System.Drawing.Size(649, 234);
            this.gdvAccountInfo.TabIndex = 1;
            // 
            // colAccountNo
            // 
            this.colAccountNo.DataPropertyName = "CreditAccountNo1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colAccountNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.colAccountNo.HeaderText = "     Account No";
            this.colAccountNo.Name = "colAccountNo";
            this.colAccountNo.Width = 110;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "BankAccountDescription";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colDescription.DefaultCellStyle = dataGridViewCellStyle3;
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 280;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "CreditAmount1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.Width = 125;
            // 
            // colDebitCredit
            // 
            this.colDebitCredit.DataPropertyName = "CreditDescription2";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colDebitCredit.DefaultCellStyle = dataGridViewCellStyle5;
            this.colDebitCredit.HeaderText = " Debit\\Credit";
            this.colDebitCredit.Name = "colDebitCredit";
            this.colDebitCredit.Width = 90;
            // 
            // lblVoucherDate2
            // 
            this.lblVoucherDate2.AutoSize = true;
            this.lblVoucherDate2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblVoucherDate2.Location = new System.Drawing.Point(563, 23);
            this.lblVoucherDate2.Name = "lblVoucherDate2";
            this.lblVoucherDate2.Size = new System.Drawing.Size(70, 13);
            this.lblVoucherDate2.TabIndex = 4;
            this.lblVoucherDate2.Text = "VoucherDate";
            // 
            // lblVoucherDate
            // 
            this.lblVoucherDate.AutoSize = true;
            this.lblVoucherDate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblVoucherDate.Location = new System.Drawing.Point(479, 23);
            this.lblVoucherDate.Name = "lblVoucherDate";
            this.lblVoucherDate.Size = new System.Drawing.Size(79, 13);
            this.lblVoucherDate.TabIndex = 3;
            this.lblVoucherDate.Text = "Voucher Date :";
            // 
            // lblEntryNo
            // 
            this.lblEntryNo.AutoSize = true;
            this.lblEntryNo.Location = new System.Drawing.Point(18, 23);
            this.lblEntryNo.Name = "lblEntryNo";
            this.lblEntryNo.Size = new System.Drawing.Size(57, 13);
            this.lblEntryNo.TabIndex = 0;
            this.lblEntryNo.Text = "Entry No. :";
            // 
            // txtSanctionAmount
            // 
            this.txtSanctionAmount.Enabled = false;
            this.txtSanctionAmount.IsSendTabOnEnter = true;
            this.txtSanctionAmount.Location = new System.Drawing.Point(122, 101);
            this.txtSanctionAmount.Name = "txtSanctionAmount";
            this.txtSanctionAmount.Size = new System.Drawing.Size(138, 20);
            this.txtSanctionAmount.TabIndex = 12;
            this.txtSanctionAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblLoanNo
            // 
            this.lblLoanNo.AutoSize = true;
            this.lblLoanNo.Location = new System.Drawing.Point(18, 52);
            this.lblLoanNo.Name = "lblLoanNo";
            this.lblLoanNo.Size = new System.Drawing.Size(57, 13);
            this.lblLoanNo.TabIndex = 0;
            this.lblLoanNo.Text = "Loan No. :";
            // 
            // lblSanctionAmount
            // 
            this.lblSanctionAmount.AutoSize = true;
            this.lblSanctionAmount.Location = new System.Drawing.Point(18, 104);
            this.lblSanctionAmount.Name = "lblSanctionAmount";
            this.lblSanctionAmount.Size = new System.Drawing.Size(94, 13);
            this.lblSanctionAmount.TabIndex = 0;
            this.lblSanctionAmount.Text = "Sanction Amount :";
            // 
            // txtCurrency
            // 
            this.txtCurrency.Enabled = false;
            this.txtCurrency.IsSendTabOnEnter = true;
            this.txtCurrency.Location = new System.Drawing.Point(122, 75);
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.Size = new System.Drawing.Size(138, 20);
            this.txtCurrency.TabIndex = 11;
            // 
            // txtLoanNo
            // 
            this.txtLoanNo.AcceptsTab = true;
            this.txtLoanNo.IsSendTabOnEnter = true;
            this.txtLoanNo.Location = new System.Drawing.Point(122, 49);
            this.txtLoanNo.MaxLength = 15;
            this.txtLoanNo.Multiline = true;
            this.txtLoanNo.Name = "txtLoanNo";
            this.txtLoanNo.Size = new System.Drawing.Size(138, 20);
            this.txtLoanNo.TabIndex = 0;
            this.txtLoanNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLoanNo_KeyDown);
            this.txtLoanNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLoanNo_KeyPress);
            // 
            // txtEntryNo
            // 
            this.txtEntryNo.Enabled = false;
            this.txtEntryNo.IsSendTabOnEnter = true;
            this.txtEntryNo.Location = new System.Drawing.Point(122, 23);
            this.txtEntryNo.Name = "txtEntryNo";
            this.txtEntryNo.Size = new System.Drawing.Size(138, 20);
            this.txtEntryNo.TabIndex = 10;
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(18, 78);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 0;
            this.lblCurrency.Text = "Currency :";
            // 
            // LOMVEW00325
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 439);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsbCRUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00325";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Personal Loans Voucher Entry";
            this.Load += new System.EventHandler(this.LOMVEW00325_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvAccountInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox groupBox1;
        private Windows.CXClient.Controls.CXC0003 lblVoucherDate2;
        private Windows.CXClient.Controls.CXC0003 lblVoucherDate;
        private Windows.CXClient.Controls.CXC0003 lblEntryNo;
        private Windows.CXClient.Controls.CXC0001 txtSanctionAmount;
        private Windows.CXClient.Controls.CXC0003 lblLoanNo;
        private Windows.CXClient.Controls.CXC0003 lblSanctionAmount;
        private Windows.CXClient.Controls.CXC0001 txtCurrency;
        private Windows.CXClient.Controls.CXC0001 txtLoanNo;
        private Windows.CXClient.Controls.CXC0001 txtEntryNo;
        private Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Windows.CXClient.Controls.AceGridView gdvAccountInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDebitCredit;
    }
}