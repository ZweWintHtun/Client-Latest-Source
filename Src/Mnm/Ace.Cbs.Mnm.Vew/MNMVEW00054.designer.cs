namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00054
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00054));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.rdoSourceCurrency = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoHomeCurrency = new Ace.Windows.CXClient.Controls.CXC0009();
            this.grpSelectDate = new System.Windows.Forms.GroupBox();
            this.dtpEndDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.dtpStartDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.lblEndPeriod = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblStartPeriod = new Ace.Windows.CXClient.Controls.CXC0003();
            this.rdoSettlementDate = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoTransactionDate = new Ace.Windows.CXClient.Controls.CXC0009();
            this.txtAccountDescription = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblAccountDescription = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboAccountCode = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAccountCode = new Ace.Windows.CXClient.Controls.CXC0003();
            this.grpLedgerByTransaction = new System.Windows.Forms.GroupBox();
            this.grpSelectDate.SuspendLayout();
            this.grpLedgerByTransaction.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(484, 31);
            this.tsbCRUD.TabIndex = 8;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
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
            this.cboCurrency.Location = new System.Drawing.Point(122, 96);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(121, 21);
            this.cboCurrency.TabIndex = 1;
            // 
            // rdoSourceCurrency
            // 
            this.rdoSourceCurrency.AutoSize = true;
            this.rdoSourceCurrency.IsSendTabOnEnter = true;
            this.rdoSourceCurrency.Location = new System.Drawing.Point(149, 21);
            this.rdoSourceCurrency.Name = "rdoSourceCurrency";
            this.rdoSourceCurrency.Size = new System.Drawing.Size(104, 17);
            this.rdoSourceCurrency.TabIndex = 2;
            this.rdoSourceCurrency.Text = "Source Currency";
            this.rdoSourceCurrency.UseVisualStyleBackColor = true;
            this.rdoSourceCurrency.CheckedChanged += new System.EventHandler(this.rdoSourceCurrency_CheckedChanged);
            // 
            // rdoHomeCurrency
            // 
            this.rdoHomeCurrency.AutoSize = true;
            this.rdoHomeCurrency.Checked = true;
            this.rdoHomeCurrency.IsSendTabOnEnter = true;
            this.rdoHomeCurrency.Location = new System.Drawing.Point(22, 21);
            this.rdoHomeCurrency.Name = "rdoHomeCurrency";
            this.rdoHomeCurrency.Size = new System.Drawing.Size(98, 17);
            this.rdoHomeCurrency.TabIndex = 0;
            this.rdoHomeCurrency.TabStop = true;
            this.rdoHomeCurrency.Text = "Home Currency";
            this.rdoHomeCurrency.UseVisualStyleBackColor = true;
            this.rdoHomeCurrency.CheckedChanged += new System.EventHandler(this.rdoHomeCurrency_CheckedChanged);
            // 
            // grpSelectDate
            // 
            this.grpSelectDate.Controls.Add(this.dtpEndDate);
            this.grpSelectDate.Controls.Add(this.dtpStartDate);
            this.grpSelectDate.Controls.Add(this.lblEndPeriod);
            this.grpSelectDate.Controls.Add(this.lblStartPeriod);
            this.grpSelectDate.Controls.Add(this.rdoSettlementDate);
            this.grpSelectDate.Controls.Add(this.rdoTransactionDate);
            this.grpSelectDate.Location = new System.Drawing.Point(16, 185);
            this.grpSelectDate.Name = "grpSelectDate";
            this.grpSelectDate.Size = new System.Drawing.Size(267, 123);
            this.grpSelectDate.TabIndex = 3;
            this.grpSelectDate.TabStop = false;
            this.grpSelectDate.Text = "Select Date :";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.IsSendTabOnEnter = true;
            this.dtpEndDate.Location = new System.Drawing.Point(107, 84);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(115, 20);
            this.dtpEndDate.TabIndex = 7;
            this.dtpEndDate.Value = new System.DateTime(2014, 1, 9, 0, 0, 0, 0);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.IsSendTabOnEnter = true;
            this.dtpStartDate.Location = new System.Drawing.Point(107, 57);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(115, 20);
            this.dtpStartDate.TabIndex = 6;
            this.dtpStartDate.Value = new System.DateTime(2014, 1, 9, 0, 0, 0, 0);
            // 
            // lblEndPeriod
            // 
            this.lblEndPeriod.AutoSize = true;
            this.lblEndPeriod.Location = new System.Drawing.Point(15, 88);
            this.lblEndPeriod.Name = "lblEndPeriod";
            this.lblEndPeriod.Size = new System.Drawing.Size(86, 13);
            this.lblEndPeriod.TabIndex = 0;
            this.lblEndPeriod.Text = "End Period        :";
            // 
            // lblStartPeriod
            // 
            this.lblStartPeriod.AutoSize = true;
            this.lblStartPeriod.Location = new System.Drawing.Point(15, 61);
            this.lblStartPeriod.Name = "lblStartPeriod";
            this.lblStartPeriod.Size = new System.Drawing.Size(86, 13);
            this.lblStartPeriod.TabIndex = 0;
            this.lblStartPeriod.Text = "Start Period       :";
            // 
            // rdoSettlementDate
            // 
            this.rdoSettlementDate.AutoSize = true;
            this.rdoSettlementDate.IsSendTabOnEnter = true;
            this.rdoSettlementDate.Location = new System.Drawing.Point(145, 26);
            this.rdoSettlementDate.Name = "rdoSettlementDate";
            this.rdoSettlementDate.Size = new System.Drawing.Size(101, 17);
            this.rdoSettlementDate.TabIndex = 5;
            this.rdoSettlementDate.Text = "Settlement Date";
            this.rdoSettlementDate.UseVisualStyleBackColor = true;
            // 
            // rdoTransactionDate
            // 
            this.rdoTransactionDate.AutoSize = true;
            this.rdoTransactionDate.Checked = true;
            this.rdoTransactionDate.IsSendTabOnEnter = true;
            this.rdoTransactionDate.Location = new System.Drawing.Point(18, 26);
            this.rdoTransactionDate.Name = "rdoTransactionDate";
            this.rdoTransactionDate.Size = new System.Drawing.Size(107, 17);
            this.rdoTransactionDate.TabIndex = 4;
            this.rdoTransactionDate.TabStop = true;
            this.rdoTransactionDate.Text = "Transaction Date";
            this.rdoTransactionDate.UseVisualStyleBackColor = true;
            // 
            // txtAccountDescription
            // 
            this.txtAccountDescription.Enabled = false;
            this.txtAccountDescription.IsSendTabOnEnter = true;
            this.txtAccountDescription.Location = new System.Drawing.Point(122, 151);
            this.txtAccountDescription.Name = "txtAccountDescription";
            this.txtAccountDescription.Size = new System.Drawing.Size(175, 20);
            this.txtAccountDescription.TabIndex = 5;
            // 
            // lblAccountDescription
            // 
            this.lblAccountDescription.AutoSize = true;
            this.lblAccountDescription.Location = new System.Drawing.Point(13, 154);
            this.lblAccountDescription.Name = "lblAccountDescription";
            this.lblAccountDescription.Size = new System.Drawing.Size(133, 13);
            this.lblAccountDescription.TabIndex = 0;
            this.lblAccountDescription.Text = "Account Description:         ";
            // 
            // cboAccountCode
            // 
            this.cboAccountCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboAccountCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAccountCode.DropDownHeight = 200;
            this.cboAccountCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccountCode.FormattingEnabled = true;
            this.cboAccountCode.IntegralHeight = false;
            this.cboAccountCode.IsSendTabOnEnter = true;
            this.cboAccountCode.Location = new System.Drawing.Point(122, 123);
            this.cboAccountCode.Name = "cboAccountCode";
            this.cboAccountCode.Size = new System.Drawing.Size(121, 21);
            this.cboAccountCode.TabIndex = 2;
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(13, 99);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 0;
            this.lblCurrency.Text = "Currency :";
            // 
            // lblAccountCode
            // 
            this.lblAccountCode.AutoSize = true;
            this.lblAccountCode.Location = new System.Drawing.Point(13, 126);
            this.lblAccountCode.Name = "lblAccountCode";
            this.lblAccountCode.Size = new System.Drawing.Size(81, 13);
            this.lblAccountCode.TabIndex = 0;
            this.lblAccountCode.Text = "Account Code :";
            // 
            // grpLedgerByTransaction
            // 
            this.grpLedgerByTransaction.Controls.Add(this.rdoHomeCurrency);
            this.grpLedgerByTransaction.Controls.Add(this.rdoSourceCurrency);
            this.grpLedgerByTransaction.Location = new System.Drawing.Point(16, 35);
            this.grpLedgerByTransaction.Name = "grpLedgerByTransaction";
            this.grpLedgerByTransaction.Size = new System.Drawing.Size(281, 52);
            this.grpLedgerByTransaction.TabIndex = 0;
            this.grpLedgerByTransaction.TabStop = false;
            // 
            // MNMVEW00054
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 334);
            this.Controls.Add(this.grpLedgerByTransaction);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.grpSelectDate);
            this.Controls.Add(this.txtAccountDescription);
            this.Controls.Add(this.lblAccountDescription);
            this.Controls.Add(this.cboAccountCode);
            this.Controls.Add(this.lblCurrency);
            this.Controls.Add(this.lblAccountCode);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00054";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sub-Ledger (Domestic)";
            this.Load += new System.EventHandler(this.MNMVEW00054_Load);
            this.grpSelectDate.ResumeLayout(false);
            this.grpSelectDate.PerformLayout();
            this.grpLedgerByTransaction.ResumeLayout(false);
            this.grpLedgerByTransaction.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0009 rdoSourceCurrency;
        private Windows.CXClient.Controls.CXC0009 rdoHomeCurrency;
        private System.Windows.Forms.GroupBox grpSelectDate;
        private Windows.CXClient.Controls.CXC0009 rdoSettlementDate;
        private Windows.CXClient.Controls.CXC0009 rdoTransactionDate;
        private Windows.CXClient.Controls.CXC0001 txtAccountDescription;
        private Windows.CXClient.Controls.CXC0003 lblAccountDescription;
        private Windows.CXClient.Controls.CXC0002 cboAccountCode;
        private Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Windows.CXClient.Controls.CXC0003 lblAccountCode;
        private Windows.CXClient.Controls.CXC0005 dtpEndDate;
        private Windows.CXClient.Controls.CXC0005 dtpStartDate;
        private Windows.CXClient.Controls.CXC0003 lblEndPeriod;
        private Windows.CXClient.Controls.CXC0003 lblStartPeriod;
        private System.Windows.Forms.GroupBox grpLedgerByTransaction;
    }
}