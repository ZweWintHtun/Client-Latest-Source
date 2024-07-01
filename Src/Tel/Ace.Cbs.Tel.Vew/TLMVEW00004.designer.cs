namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00004
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00004));
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gbDebit = new System.Windows.Forms.GroupBox();
            this.ntxtDebitFromAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.cboFrom = new Ace.Windows.CXClient.Controls.CXC0002();
            this.txtDebitEntryNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblDebitAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblDebitFrom = new Ace.Windows.CXClient.Controls.CXC0003();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdoDebitCounter = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoDebitVault = new Ace.Windows.CXClient.Controls.CXC0009();
            this.lblDebitEno = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gbCredit = new System.Windows.Forms.GroupBox();
            this.cboTo = new Ace.Windows.CXClient.Controls.CXC0002();
            this.ntxtCreditToAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblCreditAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCreditTo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdoCreditCounter = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoCreditVault = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoCreditBranch = new Ace.Windows.CXClient.Controls.CXC0009();
            this.txtCreditEntryNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblCreditEno = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblTransactionDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00037 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gbDebit.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbCredit.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
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
            this.cboCurrency.Items.AddRange(new object[] {
            "KYT",
            "SGD",
            "USD"});
            this.cboCurrency.Location = new System.Drawing.Point(108, 44);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 1;
            this.cboCurrency.Validating += new System.ComponentModel.CancelEventHandler(this.cboCurrency_Validating);
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(21, 47);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 0;
            this.lblCurrency.Text = "Currency :";
            // 
            // gbDebit
            // 
            this.gbDebit.Controls.Add(this.ntxtDebitFromAmount);
            this.gbDebit.Controls.Add(this.cboFrom);
            this.gbDebit.Controls.Add(this.txtDebitEntryNo);
            this.gbDebit.Controls.Add(this.lblDebitAmount);
            this.gbDebit.Controls.Add(this.lblDebitFrom);
            this.gbDebit.Controls.Add(this.groupBox3);
            this.gbDebit.Controls.Add(this.lblDebitEno);
            this.gbDebit.Location = new System.Drawing.Point(12, 71);
            this.gbDebit.Name = "gbDebit";
            this.gbDebit.Size = new System.Drawing.Size(336, 162);
            this.gbDebit.TabIndex = 2;
            this.gbDebit.TabStop = false;
            this.gbDebit.Text = "Debit Form";
            // 
            // ntxtDebitFromAmount
            // 
            this.ntxtDebitFromAmount.DecimalPlaces = 2;
            this.ntxtDebitFromAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ntxtDebitFromAmount.IsSendTabOnEnter = true;
            this.ntxtDebitFromAmount.IsThousandSeperator = true;
            this.ntxtDebitFromAmount.IsUseFloatingPoint = true;
            this.ntxtDebitFromAmount.Location = new System.Drawing.Point(96, 132);
            this.ntxtDebitFromAmount.MaxLength = 21;
            this.ntxtDebitFromAmount.Name = "ntxtDebitFromAmount";
            this.ntxtDebitFromAmount.Size = new System.Drawing.Size(111, 20);
            this.ntxtDebitFromAmount.TabIndex = 8;
            this.ntxtDebitFromAmount.Text = "0.00";
            this.ntxtDebitFromAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntxtDebitFromAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.ntxtDebitFromAmount.Leave += new System.EventHandler(this.ntxtDebitFromAmount_Leave);
            this.ntxtDebitFromAmount.Validated += new System.EventHandler(this.ntxtDebitFromAmount_Validated);
            // 
            // cboFrom
            // 
            this.cboFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFrom.DropDownHeight = 200;
            this.cboFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFrom.FormattingEnabled = true;
            this.cboFrom.IntegralHeight = false;
            this.cboFrom.IsSendTabOnEnter = true;
            this.cboFrom.Location = new System.Drawing.Point(96, 102);
            this.cboFrom.Name = "cboFrom";
            this.cboFrom.Size = new System.Drawing.Size(191, 21);
            this.cboFrom.TabIndex = 7;
            this.cboFrom.SelectedIndexChanged += new System.EventHandler(this.cboFrom_SelectedIndexChanged);
            this.cboFrom.Click += new System.EventHandler(this.cboFrom_Click);
            this.cboFrom.Validated += new System.EventHandler(this.cboFrom_Validated);
            // 
            // txtDebitEntryNo
            // 
            this.txtDebitEntryNo.IsSendTabOnEnter = true;
            this.txtDebitEntryNo.Location = new System.Drawing.Point(96, 27);
            this.txtDebitEntryNo.Name = "txtDebitEntryNo";
            this.txtDebitEntryNo.Size = new System.Drawing.Size(141, 20);
            this.txtDebitEntryNo.TabIndex = 3;
            this.txtDebitEntryNo.TabStop = false;
            // 
            // lblDebitAmount
            // 
            this.lblDebitAmount.AutoSize = true;
            this.lblDebitAmount.Location = new System.Drawing.Point(9, 135);
            this.lblDebitAmount.Name = "lblDebitAmount";
            this.lblDebitAmount.Size = new System.Drawing.Size(49, 13);
            this.lblDebitAmount.TabIndex = 0;
            this.lblDebitAmount.Text = "Amount :";
            // 
            // lblDebitFrom
            // 
            this.lblDebitFrom.AutoSize = true;
            this.lblDebitFrom.Location = new System.Drawing.Point(9, 105);
            this.lblDebitFrom.Name = "lblDebitFrom";
            this.lblDebitFrom.Size = new System.Drawing.Size(64, 13);
            this.lblDebitFrom.TabIndex = 0;
            this.lblDebitFrom.Text = "Debit From :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdoDebitCounter);
            this.groupBox3.Controls.Add(this.rdoDebitVault);
            this.groupBox3.Location = new System.Drawing.Point(12, 53);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(301, 34);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // rdoDebitCounter
            // 
            this.rdoDebitCounter.AutoSize = true;
            this.rdoDebitCounter.CausesValidation = false;
            this.rdoDebitCounter.IsSendTabOnEnter = true;
            this.rdoDebitCounter.Location = new System.Drawing.Point(174, 12);
            this.rdoDebitCounter.Name = "rdoDebitCounter";
            this.rdoDebitCounter.Size = new System.Drawing.Size(62, 17);
            this.rdoDebitCounter.TabIndex = 6;
            this.rdoDebitCounter.TabStop = true;
            this.rdoDebitCounter.Text = "Counter";
            this.rdoDebitCounter.UseVisualStyleBackColor = true;
            this.rdoDebitCounter.CheckedChanged += new System.EventHandler(this.rdoDebitCounter_CheckedChanged);
            // 
            // rdoDebitVault
            // 
            this.rdoDebitVault.AutoSize = true;
            this.rdoDebitVault.CausesValidation = false;
            this.rdoDebitVault.Checked = true;
            this.rdoDebitVault.IsSendTabOnEnter = true;
            this.rdoDebitVault.Location = new System.Drawing.Point(67, 11);
            this.rdoDebitVault.Name = "rdoDebitVault";
            this.rdoDebitVault.Size = new System.Drawing.Size(49, 17);
            this.rdoDebitVault.TabIndex = 5;
            this.rdoDebitVault.TabStop = true;
            this.rdoDebitVault.Text = "Vault";
            this.rdoDebitVault.UseVisualStyleBackColor = true;
            this.rdoDebitVault.CheckedChanged += new System.EventHandler(this.rdoDebitVault_CheckedChanged);
            // 
            // lblDebitEno
            // 
            this.lblDebitEno.AutoSize = true;
            this.lblDebitEno.Location = new System.Drawing.Point(9, 30);
            this.lblDebitEno.Name = "lblDebitEno";
            this.lblDebitEno.Size = new System.Drawing.Size(60, 13);
            this.lblDebitEno.TabIndex = 0;
            this.lblDebitEno.Text = "Debit Eno :";
            // 
            // gbCredit
            // 
            this.gbCredit.Controls.Add(this.cboTo);
            this.gbCredit.Controls.Add(this.ntxtCreditToAmount);
            this.gbCredit.Controls.Add(this.lblCreditAmount);
            this.gbCredit.Controls.Add(this.lblCreditTo);
            this.gbCredit.Controls.Add(this.groupBox4);
            this.gbCredit.Controls.Add(this.txtCreditEntryNo);
            this.gbCredit.Controls.Add(this.lblCreditEno);
            this.gbCredit.Location = new System.Drawing.Point(369, 71);
            this.gbCredit.Name = "gbCredit";
            this.gbCredit.Size = new System.Drawing.Size(342, 162);
            this.gbCredit.TabIndex = 15;
            this.gbCredit.TabStop = false;
            this.gbCredit.Text = "Credit Form";
            // 
            // cboTo
            // 
            this.cboTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTo.DropDownHeight = 200;
            this.cboTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTo.FormattingEnabled = true;
            this.cboTo.IntegralHeight = false;
            this.cboTo.IsSendTabOnEnter = true;
            this.cboTo.Location = new System.Drawing.Point(99, 103);
            this.cboTo.Name = "cboTo";
            this.cboTo.Size = new System.Drawing.Size(191, 21);
            this.cboTo.TabIndex = 13;
            // 
            // ntxtCreditToAmount
            // 
            this.ntxtCreditToAmount.DecimalPlaces = 2;
            this.ntxtCreditToAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ntxtCreditToAmount.IsSendTabOnEnter = true;
            this.ntxtCreditToAmount.IsThousandSeperator = true;
            this.ntxtCreditToAmount.IsUseFloatingPoint = true;
            this.ntxtCreditToAmount.Location = new System.Drawing.Point(99, 132);
            this.ntxtCreditToAmount.MaxLength = 21;
            this.ntxtCreditToAmount.Name = "ntxtCreditToAmount";
            this.ntxtCreditToAmount.Size = new System.Drawing.Size(111, 20);
            this.ntxtCreditToAmount.TabIndex = 14;
            this.ntxtCreditToAmount.Text = "0.00";
            this.ntxtCreditToAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntxtCreditToAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.ntxtCreditToAmount.Leave += new System.EventHandler(this.ntxtCreditToAmount_Leave);
            this.ntxtCreditToAmount.Validated += new System.EventHandler(this.ntxtCreditToAmount_Validated);
            // 
            // lblCreditAmount
            // 
            this.lblCreditAmount.AutoSize = true;
            this.lblCreditAmount.Location = new System.Drawing.Point(15, 135);
            this.lblCreditAmount.Name = "lblCreditAmount";
            this.lblCreditAmount.Size = new System.Drawing.Size(49, 13);
            this.lblCreditAmount.TabIndex = 0;
            this.lblCreditAmount.Text = "Amount :";
            // 
            // lblCreditTo
            // 
            this.lblCreditTo.AutoSize = true;
            this.lblCreditTo.Location = new System.Drawing.Point(15, 106);
            this.lblCreditTo.Name = "lblCreditTo";
            this.lblCreditTo.Size = new System.Drawing.Size(56, 13);
            this.lblCreditTo.TabIndex = 0;
            this.lblCreditTo.Text = "Credit To :";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdoCreditCounter);
            this.groupBox4.Controls.Add(this.rdoCreditVault);
            this.groupBox4.Controls.Add(this.rdoCreditBranch);
            this.groupBox4.Location = new System.Drawing.Point(18, 53);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(303, 34);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            // 
            // rdoCreditCounter
            // 
            this.rdoCreditCounter.AutoSize = true;
            this.rdoCreditCounter.CausesValidation = false;
            this.rdoCreditCounter.IsSendTabOnEnter = true;
            this.rdoCreditCounter.Location = new System.Drawing.Point(205, 11);
            this.rdoCreditCounter.Name = "rdoCreditCounter";
            this.rdoCreditCounter.Size = new System.Drawing.Size(62, 17);
            this.rdoCreditCounter.TabIndex = 12;
            this.rdoCreditCounter.TabStop = true;
            this.rdoCreditCounter.Text = "Counter";
            this.rdoCreditCounter.UseVisualStyleBackColor = true;
            this.rdoCreditCounter.CheckedChanged += new System.EventHandler(this.rdoCreditCounter_CheckedChanged);
            // 
            // rdoCreditVault
            // 
            this.rdoCreditVault.AutoSize = true;
            this.rdoCreditVault.CausesValidation = false;
            this.rdoCreditVault.IsSendTabOnEnter = true;
            this.rdoCreditVault.Location = new System.Drawing.Point(120, 11);
            this.rdoCreditVault.Name = "rdoCreditVault";
            this.rdoCreditVault.Size = new System.Drawing.Size(49, 17);
            this.rdoCreditVault.TabIndex = 11;
            this.rdoCreditVault.TabStop = true;
            this.rdoCreditVault.Text = "Vault";
            this.rdoCreditVault.UseVisualStyleBackColor = true;
            this.rdoCreditVault.CheckedChanged += new System.EventHandler(this.rdoCreditVault_CheckedChanged);
            // 
            // rdoCreditBranch
            // 
            this.rdoCreditBranch.AutoSize = true;
            this.rdoCreditBranch.CausesValidation = false;
            this.rdoCreditBranch.Checked = true;
            this.rdoCreditBranch.IsSendTabOnEnter = true;
            this.rdoCreditBranch.Location = new System.Drawing.Point(29, 11);
            this.rdoCreditBranch.Name = "rdoCreditBranch";
            this.rdoCreditBranch.Size = new System.Drawing.Size(59, 17);
            this.rdoCreditBranch.TabIndex = 10;
            this.rdoCreditBranch.TabStop = true;
            this.rdoCreditBranch.Text = "Branch";
            this.rdoCreditBranch.UseVisualStyleBackColor = true;
            this.rdoCreditBranch.CheckedChanged += new System.EventHandler(this.rdoCreditBranch_CheckedChanged);
            // 
            // txtCreditEntryNo
            // 
            this.txtCreditEntryNo.IsSendTabOnEnter = true;
            this.txtCreditEntryNo.Location = new System.Drawing.Point(99, 27);
            this.txtCreditEntryNo.Name = "txtCreditEntryNo";
            this.txtCreditEntryNo.Size = new System.Drawing.Size(141, 20);
            this.txtCreditEntryNo.TabIndex = 10;
            this.txtCreditEntryNo.TabStop = false;
            // 
            // lblCreditEno
            // 
            this.lblCreditEno.AutoSize = true;
            this.lblCreditEno.Location = new System.Drawing.Point(15, 30);
            this.lblCreditEno.Name = "lblCreditEno";
            this.lblCreditEno.Size = new System.Drawing.Size(62, 13);
            this.lblCreditEno.TabIndex = 0;
            this.lblCreditEno.Text = "Credit Eno :";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-2, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(726, 31);
            this.tsbCRUD.TabIndex = 17;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblTransactionDate
            // 
            this.lblTransactionDate.AutoSize = true;
            this.lblTransactionDate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblTransactionDate.Location = new System.Drawing.Point(629, 36);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Size = new System.Drawing.Size(0, 13);
            this.lblTransactionDate.TabIndex = 19;
            // 
            // cxC00037
            // 
            this.cxC00037.AutoSize = true;
            this.cxC00037.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.cxC00037.Location = new System.Drawing.Point(528, 36);
            this.cxC00037.Name = "cxC00037";
            this.cxC00037.Size = new System.Drawing.Size(95, 13);
            this.cxC00037.TabIndex = 18;
            this.cxC00037.Text = "Transaction Date :";
            // 
            // TLMVEW00004
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 251);
            this.Controls.Add(this.lblTransactionDate);
            this.Controls.Add(this.cxC00037);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.gbCredit);
            this.Controls.Add(this.gbDebit);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.lblCurrency);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TLMVEW00004";
            this.Text = "Vault Withdraw Denomination Entry";
            this.Load += new System.EventHandler(this.TLMVEW00004_Load);
            this.gbDebit.ResumeLayout(false);
            this.gbDebit.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbCredit.ResumeLayout(false);
            this.gbCredit.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ace.Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Ace.Windows.CXClient.Controls.CXC0003 lblCurrency;
        private System.Windows.Forms.GroupBox gbDebit;
        private Ace.Windows.CXClient.Controls.CXC0003 lblDebitFrom;
        private System.Windows.Forms.GroupBox groupBox3;
        private Ace.Windows.CXClient.Controls.CXC0009 rdoDebitCounter;
        private Ace.Windows.CXClient.Controls.CXC0009 rdoDebitVault;
        private Ace.Windows.CXClient.Controls.CXC0003 lblDebitEno;
        private System.Windows.Forms.GroupBox gbCredit;
        private Ace.Windows.CXClient.Controls.CXC0003 lblCreditTo;
        private System.Windows.Forms.GroupBox groupBox4;
        private Ace.Windows.CXClient.Controls.CXC0009 rdoCreditCounter;
        private Ace.Windows.CXClient.Controls.CXC0009 rdoCreditVault;
        private Ace.Windows.CXClient.Controls.CXC0009 rdoCreditBranch;
        private Ace.Windows.CXClient.Controls.CXC0006 txtCreditEntryNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblCreditEno;
        private Ace.Windows.CXClient.Controls.CXC0003 lblDebitAmount;
        private Ace.Windows.CXClient.Controls.CXC0003 lblCreditAmount;
        private Ace.Windows.CXClient.Controls.CXC0006 txtDebitEntryNo;
        private Ace.Windows.CXClient.Controls.CXC0002 cboFrom;
        private Ace.Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0004 ntxtDebitFromAmount;
        private Windows.CXClient.Controls.CXC0004 ntxtCreditToAmount;
        private Windows.CXClient.Controls.CXC0002 cboTo;
        private Windows.CXClient.Controls.CXC0003 lblTransactionDate;
        private Windows.CXClient.Controls.CXC0003 cxC00037;
    }
}