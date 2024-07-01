namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00066
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00066));
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.rdoAmount = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoOverDrawn = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoAccountNo = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoPersonalLoans = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoSourceCurrency = new Ace.Windows.CXClient.Controls.CXC0009();
            this.gbSort = new System.Windows.Forms.GroupBox();
            this.rdoHirePurchase = new Ace.Windows.CXClient.Controls.CXC0009();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.rdoAll = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoHomeCurrency = new Ace.Windows.CXClient.Controls.CXC0009();
            this.grpLedgerByTransaction = new System.Windows.Forms.GroupBox();
            this.rdoBusinessLoans = new Ace.Windows.CXClient.Controls.CXC0009();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.rdoDealerAccount = new Ace.Windows.CXClient.Controls.CXC0009();
            this.gbSort.SuspendLayout();
            this.grpLedgerByTransaction.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(247, 158);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 0;
            this.lblCurrency.Text = "Currency :";
            // 
            // rdoAmount
            // 
            this.rdoAmount.AutoSize = true;
            this.rdoAmount.IsSendTabOnEnter = true;
            this.rdoAmount.Location = new System.Drawing.Point(104, 23);
            this.rdoAmount.Name = "rdoAmount";
            this.rdoAmount.Size = new System.Drawing.Size(61, 17);
            this.rdoAmount.TabIndex = 12;
            this.rdoAmount.Text = "Amount";
            this.rdoAmount.UseVisualStyleBackColor = true;
            this.rdoAmount.CheckedChanged += new System.EventHandler(this.rdoSortingType_CheckedChanged);
            // 
            // rdoOverDrawn
            // 
            this.rdoOverDrawn.AutoSize = true;
            this.rdoOverDrawn.IsSendTabOnEnter = true;
            this.rdoOverDrawn.Location = new System.Drawing.Point(27, 188);
            this.rdoOverDrawn.Name = "rdoOverDrawn";
            this.rdoOverDrawn.Size = new System.Drawing.Size(79, 17);
            this.rdoOverDrawn.TabIndex = 5;
            this.rdoOverDrawn.Text = "OverDrawn";
            this.rdoOverDrawn.UseVisualStyleBackColor = true;
            this.rdoOverDrawn.CheckedChanged += new System.EventHandler(this.rdoTransaction_CheckedChanged);
            // 
            // rdoAccountNo
            // 
            this.rdoAccountNo.AutoSize = true;
            this.rdoAccountNo.IsSendTabOnEnter = true;
            this.rdoAccountNo.Location = new System.Drawing.Point(10, 23);
            this.rdoAccountNo.Name = "rdoAccountNo";
            this.rdoAccountNo.Size = new System.Drawing.Size(82, 17);
            this.rdoAccountNo.TabIndex = 11;
            this.rdoAccountNo.Text = "Account No";
            this.rdoAccountNo.UseVisualStyleBackColor = true;
            this.rdoAccountNo.CheckedChanged += new System.EventHandler(this.rdoSortingType_CheckedChanged);
            // 
            // rdoPersonalLoans
            // 
            this.rdoPersonalLoans.AutoSize = true;
            this.rdoPersonalLoans.IsSendTabOnEnter = true;
            this.rdoPersonalLoans.Location = new System.Drawing.Point(26, 124);
            this.rdoPersonalLoans.Name = "rdoPersonalLoans";
            this.rdoPersonalLoans.Size = new System.Drawing.Size(98, 17);
            this.rdoPersonalLoans.TabIndex = 4;
            this.rdoPersonalLoans.Text = "Personal Loans";
            this.rdoPersonalLoans.UseVisualStyleBackColor = true;
            this.rdoPersonalLoans.CheckedChanged += new System.EventHandler(this.rdoTransaction_CheckedChanged);
            // 
            // rdoSourceCurrency
            // 
            this.rdoSourceCurrency.AutoSize = true;
            this.rdoSourceCurrency.IsSendTabOnEnter = true;
            this.rdoSourceCurrency.Location = new System.Drawing.Point(358, 128);
            this.rdoSourceCurrency.Name = "rdoSourceCurrency";
            this.rdoSourceCurrency.Size = new System.Drawing.Size(104, 17);
            this.rdoSourceCurrency.TabIndex = 8;
            this.rdoSourceCurrency.TabStop = true;
            this.rdoSourceCurrency.Text = "Source Currency";
            this.rdoSourceCurrency.UseVisualStyleBackColor = true;
            this.rdoSourceCurrency.CheckedChanged += new System.EventHandler(this.rdoCurrencyType_CheckedChanged);
            // 
            // gbSort
            // 
            this.gbSort.Controls.Add(this.rdoAmount);
            this.gbSort.Controls.Add(this.rdoAccountNo);
            this.gbSort.Location = new System.Drawing.Point(249, 203);
            this.gbSort.Name = "gbSort";
            this.gbSort.Size = new System.Drawing.Size(210, 63);
            this.gbSort.TabIndex = 10;
            this.gbSort.TabStop = false;
            this.gbSort.Text = "Sort By";
            // 
            // rdoHirePurchase
            // 
            this.rdoHirePurchase.AutoSize = true;
            this.rdoHirePurchase.IsSendTabOnEnter = true;
            this.rdoHirePurchase.Location = new System.Drawing.Point(26, 91);
            this.rdoHirePurchase.Name = "rdoHirePurchase";
            this.rdoHirePurchase.Size = new System.Drawing.Size(92, 17);
            this.rdoHirePurchase.TabIndex = 3;
            this.rdoHirePurchase.Text = "Hire Purchase";
            this.rdoHirePurchase.UseVisualStyleBackColor = true;
            this.rdoHirePurchase.CheckedChanged += new System.EventHandler(this.rdoTransaction_CheckedChanged);
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
            this.cboCurrency.Location = new System.Drawing.Point(308, 155);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 9;
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.IsSendTabOnEnter = true;
            this.rdoAll.Location = new System.Drawing.Point(27, 23);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(36, 17);
            this.rdoAll.TabIndex = 1;
            this.rdoAll.Text = "All";
            this.rdoAll.UseVisualStyleBackColor = true;
            this.rdoAll.CheckedChanged += new System.EventHandler(this.rdoTransaction_CheckedChanged);
            // 
            // rdoHomeCurrency
            // 
            this.rdoHomeCurrency.AutoSize = true;
            this.rdoHomeCurrency.IsSendTabOnEnter = true;
            this.rdoHomeCurrency.Location = new System.Drawing.Point(249, 129);
            this.rdoHomeCurrency.Name = "rdoHomeCurrency";
            this.rdoHomeCurrency.Size = new System.Drawing.Size(98, 17);
            this.rdoHomeCurrency.TabIndex = 8;
            this.rdoHomeCurrency.TabStop = true;
            this.rdoHomeCurrency.Text = "Home Currency";
            this.rdoHomeCurrency.UseVisualStyleBackColor = true;
            this.rdoHomeCurrency.CheckedChanged += new System.EventHandler(this.rdoCurrencyType_CheckedChanged);
            // 
            // grpLedgerByTransaction
            // 
            this.grpLedgerByTransaction.Controls.Add(this.rdoDealerAccount);
            this.grpLedgerByTransaction.Controls.Add(this.rdoOverDrawn);
            this.grpLedgerByTransaction.Controls.Add(this.rdoPersonalLoans);
            this.grpLedgerByTransaction.Controls.Add(this.rdoHirePurchase);
            this.grpLedgerByTransaction.Controls.Add(this.rdoBusinessLoans);
            this.grpLedgerByTransaction.Controls.Add(this.rdoAll);
            this.grpLedgerByTransaction.Location = new System.Drawing.Point(13, 47);
            this.grpLedgerByTransaction.Name = "grpLedgerByTransaction";
            this.grpLedgerByTransaction.Size = new System.Drawing.Size(210, 219);
            this.grpLedgerByTransaction.TabIndex = 1;
            this.grpLedgerByTransaction.TabStop = false;
            this.grpLedgerByTransaction.Text = "Choose Transaction";
            // 
            // rdoBusinessLoans
            // 
            this.rdoBusinessLoans.AutoSize = true;
            this.rdoBusinessLoans.IsSendTabOnEnter = true;
            this.rdoBusinessLoans.Location = new System.Drawing.Point(26, 57);
            this.rdoBusinessLoans.Name = "rdoBusinessLoans";
            this.rdoBusinessLoans.Size = new System.Drawing.Size(99, 17);
            this.rdoBusinessLoans.TabIndex = 2;
            this.rdoBusinessLoans.Text = "Business Loans";
            this.rdoBusinessLoans.UseVisualStyleBackColor = true;
            this.rdoBusinessLoans.CheckedChanged += new System.EventHandler(this.rdoTransaction_CheckedChanged);
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-2, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(506, 31);
            this.tsbCRUD.TabIndex = 14;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(336, 83);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(115, 20);
            this.dtpEndDate.TabIndex = 7;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(336, 53);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(115, 20);
            this.dtpStartDate.TabIndex = 6;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(246, 86);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(58, 13);
            this.lblEndDate.TabIndex = 0;
            this.lblEndDate.Text = "End Date :";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(246, 56);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(61, 13);
            this.lblStartDate.TabIndex = 0;
            this.lblStartDate.Text = "Start Date :";
            // 
            // rdoDealerAccount
            // 
            this.rdoDealerAccount.AutoSize = true;
            this.rdoDealerAccount.IsSendTabOnEnter = true;
            this.rdoDealerAccount.Location = new System.Drawing.Point(27, 157);
            this.rdoDealerAccount.Name = "rdoDealerAccount";
            this.rdoDealerAccount.Size = new System.Drawing.Size(99, 17);
            this.rdoDealerAccount.TabIndex = 6;
            this.rdoDealerAccount.Text = "Dealer Account";
            this.rdoDealerAccount.UseVisualStyleBackColor = true;
            // 
            // TCMVEW00066
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 285);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.lblCurrency);
            this.Controls.Add(this.rdoSourceCurrency);
            this.Controls.Add(this.gbSort);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.rdoHomeCurrency);
            this.Controls.Add(this.grpLedgerByTransaction);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TCMVEW00066";
            this.Text = "Ledger Balance By Transaction";
            this.Load += new System.EventHandler(this.TCMVEW00066_Load);
            this.gbSort.ResumeLayout(false);
            this.gbSort.PerformLayout();
            this.grpLedgerByTransaction.ResumeLayout(false);
            this.grpLedgerByTransaction.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Windows.CXClient.Controls.CXC0009 rdoAmount;
        private Windows.CXClient.Controls.CXC0009 rdoOverDrawn;
        private Windows.CXClient.Controls.CXC0009 rdoAccountNo;
        private Windows.CXClient.Controls.CXC0009 rdoPersonalLoans;
        private Windows.CXClient.Controls.CXC0009 rdoSourceCurrency;
        private System.Windows.Forms.GroupBox gbSort;
        private Windows.CXClient.Controls.CXC0009 rdoHirePurchase;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0009 rdoAll;
        private Windows.CXClient.Controls.CXC0009 rdoHomeCurrency;
        private System.Windows.Forms.GroupBox grpLedgerByTransaction;
        private Windows.CXClient.Controls.CXC0009 rdoBusinessLoans;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private Windows.CXClient.Controls.CXC0009 rdoDealerAccount;
    }
}