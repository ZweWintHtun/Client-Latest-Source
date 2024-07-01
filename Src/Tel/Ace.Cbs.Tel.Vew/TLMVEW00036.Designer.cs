namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00036
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00036));
            this.chkReversal = new Ace.Windows.CXClient.Controls.CXC0008();
            this.gbDayBook = new System.Windows.Forms.GroupBox();
            this.rdoDealer = new Ace.Windows.CXClient.Controls.CXC0009();
            this.gbBranch = new System.Windows.Forms.GroupBox();
            this.cboBranchNo = new Ace.Windows.CXClient.Controls.AceMultiColumnsComboBox();
            this.lblBranch = new Ace.Windows.CXClient.Controls.CXC0003();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoSourceCurrency = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoHomeCurrency = new Ace.Windows.CXClient.Controls.CXC0009();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gbSortBy = new System.Windows.Forms.GroupBox();
            this.rdoAccountNO = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoTime = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoDomestic = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoPersonalLoan = new Ace.Windows.CXClient.Controls.CXC0009();
            this.gpDateInfo = new System.Windows.Forms.GroupBox();
            this.rdoSettlementDate = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoTransactionDate = new Ace.Windows.CXClient.Controls.CXC0009();
            this.dtpRequiredDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.lblRequiredDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.rdoHirePurchase = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoBusinessLoan = new Ace.Windows.CXClient.Controls.CXC0009();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gbDayBook.SuspendLayout();
            this.gbBranch.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbSortBy.SuspendLayout();
            this.gpDateInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkReversal
            // 
            this.chkReversal.AutoSize = true;
            this.chkReversal.IsSendTabOnEnter = true;
            this.chkReversal.Location = new System.Drawing.Point(16, 318);
            this.chkReversal.Name = "chkReversal";
            this.chkReversal.Size = new System.Drawing.Size(93, 17);
            this.chkReversal.TabIndex = 15;
            this.chkReversal.Text = "With Reversal";
            this.chkReversal.UseVisualStyleBackColor = true;
            // 
            // gbDayBook
            // 
            this.gbDayBook.Controls.Add(this.rdoDealer);
            this.gbDayBook.Controls.Add(this.gbBranch);
            this.gbDayBook.Controls.Add(this.groupBox1);
            this.gbDayBook.Controls.Add(this.chkReversal);
            this.gbDayBook.Controls.Add(this.gbSortBy);
            this.gbDayBook.Controls.Add(this.rdoDomestic);
            this.gbDayBook.Controls.Add(this.rdoPersonalLoan);
            this.gbDayBook.Controls.Add(this.gpDateInfo);
            this.gbDayBook.Controls.Add(this.rdoHirePurchase);
            this.gbDayBook.Controls.Add(this.rdoBusinessLoan);
            this.gbDayBook.Location = new System.Drawing.Point(10, 43);
            this.gbDayBook.Name = "gbDayBook";
            this.gbDayBook.Size = new System.Drawing.Size(698, 374);
            this.gbDayBook.TabIndex = 17;
            this.gbDayBook.TabStop = false;
            this.gbDayBook.Text = "Current Day Book";
            // 
            // rdoDealer
            // 
            this.rdoDealer.AutoSize = true;
            this.rdoDealer.IsSendTabOnEnter = true;
            this.rdoDealer.Location = new System.Drawing.Point(463, 24);
            this.rdoDealer.Name = "rdoDealer";
            this.rdoDealer.Size = new System.Drawing.Size(106, 17);
            this.rdoDealer.TabIndex = 95;
            this.rdoDealer.Text = "Dealer Day Book";
            this.rdoDealer.UseVisualStyleBackColor = true;
            // 
            // gbBranch
            // 
            this.gbBranch.Controls.Add(this.cboBranchNo);
            this.gbBranch.Controls.Add(this.lblBranch);
            this.gbBranch.Location = new System.Drawing.Point(133, 317);
            this.gbBranch.Name = "gbBranch";
            this.gbBranch.Size = new System.Drawing.Size(329, 51);
            this.gbBranch.TabIndex = 94;
            this.gbBranch.TabStop = false;
            this.gbBranch.Text = "Branch";
            // 
            // cboBranchNo
            // 
            this.cboBranchNo.AutoComplete = false;
            this.cboBranchNo.AutoDropdown = false;
            this.cboBranchNo.BackColorEven = System.Drawing.Color.White;
            this.cboBranchNo.BackColorOdd = System.Drawing.Color.White;
            this.cboBranchNo.ColumnNames = "";
            this.cboBranchNo.ColumnWidthDefault = 150;
            this.cboBranchNo.ColumnWidths = "25,200";
            this.cboBranchNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboBranchNo.FormattingEnabled = true;
            this.cboBranchNo.LinkedColumnIndex = 0;
            this.cboBranchNo.LinkedTextBox = null;
            this.cboBranchNo.Location = new System.Drawing.Point(131, 19);
            this.cboBranchNo.Name = "cboBranchNo";
            this.cboBranchNo.Size = new System.Drawing.Size(115, 21);
            this.cboBranchNo.TabIndex = 93;
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Location = new System.Drawing.Point(29, 22);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(50, 13);
            this.lblBranch.TabIndex = 0;
            this.lblBranch.Text = "Branch : ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoSourceCurrency);
            this.groupBox1.Controls.Add(this.rdoHomeCurrency);
            this.groupBox1.Controls.Add(this.cboCurrency);
            this.groupBox1.Controls.Add(this.lblCurrency);
            this.groupBox1.Location = new System.Drawing.Point(16, 145);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 85);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Currency";
            // 
            // rdoSourceCurrency
            // 
            this.rdoSourceCurrency.AutoSize = true;
            this.rdoSourceCurrency.IsSendTabOnEnter = true;
            this.rdoSourceCurrency.Location = new System.Drawing.Point(160, 21);
            this.rdoSourceCurrency.Name = "rdoSourceCurrency";
            this.rdoSourceCurrency.Size = new System.Drawing.Size(104, 17);
            this.rdoSourceCurrency.TabIndex = 14;
            this.rdoSourceCurrency.Text = "Source Currency";
            this.rdoSourceCurrency.UseVisualStyleBackColor = true;
            this.rdoSourceCurrency.CheckedChanged += new System.EventHandler(this.rdoSourceCurrency_CheckedChanged);
            // 
            // rdoHomeCurrency
            // 
            this.rdoHomeCurrency.AutoSize = true;
            this.rdoHomeCurrency.Checked = true;
            this.rdoHomeCurrency.IsSendTabOnEnter = true;
            this.rdoHomeCurrency.Location = new System.Drawing.Point(32, 21);
            this.rdoHomeCurrency.Name = "rdoHomeCurrency";
            this.rdoHomeCurrency.Size = new System.Drawing.Size(98, 17);
            this.rdoHomeCurrency.TabIndex = 13;
            this.rdoHomeCurrency.TabStop = true;
            this.rdoHomeCurrency.Text = "Home Currency";
            this.rdoHomeCurrency.UseVisualStyleBackColor = true;
            this.rdoHomeCurrency.CheckedChanged += new System.EventHandler(this.rdoHomeCurrency_CheckedChanged);
            // 
            // cboCurrency
            // 
            this.cboCurrency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCurrency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCurrency.DropDownHeight = 200;
            this.cboCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrency.FormattingEnabled = true;
            this.cboCurrency.IntegralHeight = false;
            this.cboCurrency.IsSendTabOnEnter = true;
            this.cboCurrency.Location = new System.Drawing.Point(131, 53);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 11;
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(29, 56);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(58, 13);
            this.lblCurrency.TabIndex = 0;
            this.lblCurrency.Text = "Currency : ";
            // 
            // gbSortBy
            // 
            this.gbSortBy.Controls.Add(this.rdoAccountNO);
            this.gbSortBy.Controls.Add(this.rdoTime);
            this.gbSortBy.Location = new System.Drawing.Point(16, 247);
            this.gbSortBy.Name = "gbSortBy";
            this.gbSortBy.Size = new System.Drawing.Size(329, 50);
            this.gbSortBy.TabIndex = 12;
            this.gbSortBy.TabStop = false;
            this.gbSortBy.Text = "Sort By";
            // 
            // rdoAccountNO
            // 
            this.rdoAccountNO.AutoSize = true;
            this.rdoAccountNO.IsSendTabOnEnter = true;
            this.rdoAccountNO.Location = new System.Drawing.Point(160, 22);
            this.rdoAccountNO.Name = "rdoAccountNO";
            this.rdoAccountNO.Size = new System.Drawing.Size(82, 17);
            this.rdoAccountNO.TabIndex = 14;
            this.rdoAccountNO.Text = "Account No";
            this.rdoAccountNO.UseVisualStyleBackColor = true;
            this.rdoAccountNO.CheckedChanged += new System.EventHandler(this.rdoAccountNO_CheckedChanged);
            // 
            // rdoTime
            // 
            this.rdoTime.AutoSize = true;
            this.rdoTime.Checked = true;
            this.rdoTime.IsSendTabOnEnter = true;
            this.rdoTime.Location = new System.Drawing.Point(32, 22);
            this.rdoTime.Name = "rdoTime";
            this.rdoTime.Size = new System.Drawing.Size(48, 17);
            this.rdoTime.TabIndex = 13;
            this.rdoTime.TabStop = true;
            this.rdoTime.Text = "Time";
            this.rdoTime.UseVisualStyleBackColor = true;
            this.rdoTime.CheckedChanged += new System.EventHandler(this.rdoTime_CheckedChanged);
            // 
            // rdoDomestic
            // 
            this.rdoDomestic.AutoSize = true;
            this.rdoDomestic.IsSendTabOnEnter = true;
            this.rdoDomestic.Location = new System.Drawing.Point(573, 24);
            this.rdoDomestic.Name = "rdoDomestic";
            this.rdoDomestic.Size = new System.Drawing.Size(119, 17);
            this.rdoDomestic.TabIndex = 4;
            this.rdoDomestic.Text = "Domestic Day Book";
            this.rdoDomestic.UseVisualStyleBackColor = true;
            // 
            // rdoPersonalLoan
            // 
            this.rdoPersonalLoan.AutoSize = true;
            this.rdoPersonalLoan.IsSendTabOnEnter = true;
            this.rdoPersonalLoan.Location = new System.Drawing.Point(314, 24);
            this.rdoPersonalLoan.Name = "rdoPersonalLoan";
            this.rdoPersonalLoan.Size = new System.Drawing.Size(143, 17);
            this.rdoPersonalLoan.TabIndex = 3;
            this.rdoPersonalLoan.Text = "Personal Loan Day Book";
            this.rdoPersonalLoan.UseVisualStyleBackColor = true;
            // 
            // gpDateInfo
            // 
            this.gpDateInfo.Controls.Add(this.rdoSettlementDate);
            this.gpDateInfo.Controls.Add(this.rdoTransactionDate);
            this.gpDateInfo.Controls.Add(this.dtpRequiredDate);
            this.gpDateInfo.Controls.Add(this.lblRequiredDate);
            this.gpDateInfo.Location = new System.Drawing.Point(16, 50);
            this.gpDateInfo.Name = "gpDateInfo";
            this.gpDateInfo.Size = new System.Drawing.Size(329, 81);
            this.gpDateInfo.TabIndex = 6;
            this.gpDateInfo.TabStop = false;
            this.gpDateInfo.Text = "Date";
            // 
            // rdoSettlementDate
            // 
            this.rdoSettlementDate.AutoSize = true;
            this.rdoSettlementDate.IsSendTabOnEnter = true;
            this.rdoSettlementDate.Location = new System.Drawing.Point(160, 19);
            this.rdoSettlementDate.Name = "rdoSettlementDate";
            this.rdoSettlementDate.Size = new System.Drawing.Size(101, 17);
            this.rdoSettlementDate.TabIndex = 8;
            this.rdoSettlementDate.Text = "Settlement Date";
            this.rdoSettlementDate.UseVisualStyleBackColor = true;
            // 
            // rdoTransactionDate
            // 
            this.rdoTransactionDate.AutoSize = true;
            this.rdoTransactionDate.Checked = true;
            this.rdoTransactionDate.IsSendTabOnEnter = true;
            this.rdoTransactionDate.Location = new System.Drawing.Point(32, 19);
            this.rdoTransactionDate.Name = "rdoTransactionDate";
            this.rdoTransactionDate.Size = new System.Drawing.Size(107, 17);
            this.rdoTransactionDate.TabIndex = 7;
            this.rdoTransactionDate.TabStop = true;
            this.rdoTransactionDate.Text = "Transaction Date";
            this.rdoTransactionDate.UseVisualStyleBackColor = true;
            // 
            // dtpRequiredDate
            // 
            this.dtpRequiredDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpRequiredDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRequiredDate.IsSendTabOnEnter = true;
            this.dtpRequiredDate.Location = new System.Drawing.Point(131, 52);
            this.dtpRequiredDate.Name = "dtpRequiredDate";
            this.dtpRequiredDate.Size = new System.Drawing.Size(115, 20);
            this.dtpRequiredDate.TabIndex = 5;
            this.dtpRequiredDate.Validating += new System.ComponentModel.CancelEventHandler(this.dtpRequiredDate_Validating);
            // 
            // lblRequiredDate
            // 
            this.lblRequiredDate.AutoSize = true;
            this.lblRequiredDate.Location = new System.Drawing.Point(29, 55);
            this.lblRequiredDate.Name = "lblRequiredDate";
            this.lblRequiredDate.Size = new System.Drawing.Size(85, 13);
            this.lblRequiredDate.TabIndex = 0;
            this.lblRequiredDate.Text = "Required Date : ";
            // 
            // rdoHirePurchase
            // 
            this.rdoHirePurchase.AutoSize = true;
            this.rdoHirePurchase.IsSendTabOnEnter = true;
            this.rdoHirePurchase.Location = new System.Drawing.Point(166, 24);
            this.rdoHirePurchase.Name = "rdoHirePurchase";
            this.rdoHirePurchase.Size = new System.Drawing.Size(142, 17);
            this.rdoHirePurchase.TabIndex = 2;
            this.rdoHirePurchase.Text = "Hire Purchase Day Book";
            this.rdoHirePurchase.UseVisualStyleBackColor = true;
            // 
            // rdoBusinessLoan
            // 
            this.rdoBusinessLoan.AutoSize = true;
            this.rdoBusinessLoan.Checked = true;
            this.rdoBusinessLoan.IsSendTabOnEnter = true;
            this.rdoBusinessLoan.Location = new System.Drawing.Point(16, 24);
            this.rdoBusinessLoan.Name = "rdoBusinessLoan";
            this.rdoBusinessLoan.Size = new System.Drawing.Size(144, 17);
            this.rdoBusinessLoan.TabIndex = 1;
            this.rdoBusinessLoan.TabStop = true;
            this.rdoBusinessLoan.Text = "Business Loan Day Book";
            this.rdoBusinessLoan.UseVisualStyleBackColor = true;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-2, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(724, 31);
            this.tsbCRUD.TabIndex = 18;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // TLMVEW00036
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 439);
            this.Controls.Add(this.gbDayBook);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00036";
            this.Text = "Ledger Day Book";
            this.Load += new System.EventHandler(this.TLMVEW00036_Load);
            this.gbDayBook.ResumeLayout(false);
            this.gbDayBook.PerformLayout();
            this.gbBranch.ResumeLayout(false);
            this.gbBranch.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbSortBy.ResumeLayout(false);
            this.gbSortBy.PerformLayout();
            this.gpDateInfo.ResumeLayout(false);
            this.gpDateInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXC0008 chkReversal;
        private System.Windows.Forms.GroupBox gbDayBook;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private System.Windows.Forms.GroupBox gbSortBy;
        private Windows.CXClient.Controls.CXC0009 rdoAccountNO;
        private Windows.CXClient.Controls.CXC0009 rdoTime;
        private Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Windows.CXClient.Controls.CXC0009 rdoDomestic;
        private Windows.CXClient.Controls.CXC0009 rdoPersonalLoan;
        private System.Windows.Forms.GroupBox gpDateInfo;
        private Windows.CXClient.Controls.CXC0009 rdoSettlementDate;
        private Windows.CXClient.Controls.CXC0009 rdoTransactionDate;
        private Windows.CXClient.Controls.CXC0009 rdoHirePurchase;
        private Windows.CXClient.Controls.CXC0009 rdoBusinessLoan;
        private Windows.CXClient.Controls.CXC0003 lblRequiredDate;
        private Windows.CXClient.Controls.CXC0005 dtpRequiredDate;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox groupBox1;
        private Windows.CXClient.Controls.CXC0009 rdoSourceCurrency;
        private Windows.CXClient.Controls.CXC0009 rdoHomeCurrency;
        private System.Windows.Forms.GroupBox gbBranch;
        private Windows.CXClient.Controls.AceMultiColumnsComboBox cboBranchNo;
        private Windows.CXClient.Controls.CXC0003 lblBranch;
        private Windows.CXClient.Controls.CXC0009 rdoDealer;
    }
}