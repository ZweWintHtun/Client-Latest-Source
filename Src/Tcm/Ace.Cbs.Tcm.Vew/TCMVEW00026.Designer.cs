namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00026
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00026));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gpBranchInfo = new System.Windows.Forms.GroupBox();
            this.chkBranch = new Ace.Windows.CXClient.Controls.CXC0008();
            this.lblBranchNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboBranch = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblBranch = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gpDateInfo = new System.Windows.Forms.GroupBox();
            this.rdoSettlementDate = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoTransactionDate = new Ace.Windows.CXClient.Controls.CXC0009();
            this.dtpDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.lblDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gbCurrencyInfo = new System.Windows.Forms.GroupBox();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.rdoSourceCurrency = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoHomeCurrency = new Ace.Windows.CXClient.Controls.CXC0009();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.chkByHomeCurrency = new Ace.Windows.CXClient.Controls.CXC0008();
            this.chkWithReversal = new Ace.Windows.CXClient.Controls.CXC0008();
            this.gpBranchInfo.SuspendLayout();
            this.gpDateInfo.SuspendLayout();
            this.gbCurrencyInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, -2);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(498, 31);
            this.tsbCRUD.TabIndex = 8;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // gpBranchInfo
            // 
            this.gpBranchInfo.Controls.Add(this.chkBranch);
            this.gpBranchInfo.Controls.Add(this.lblBranchNo);
            this.gpBranchInfo.Controls.Add(this.cboBranch);
            this.gpBranchInfo.Controls.Add(this.lblBranch);
            this.gpBranchInfo.Location = new System.Drawing.Point(12, 41);
            this.gpBranchInfo.Name = "gpBranchInfo";
            this.gpBranchInfo.Size = new System.Drawing.Size(314, 75);
            this.gpBranchInfo.TabIndex = 112;
            this.gpBranchInfo.TabStop = false;
            this.gpBranchInfo.Text = "Branch";
            // 
            // chkBranch
            // 
            this.chkBranch.AutoSize = true;
            this.chkBranch.IsSendTabOnEnter = true;
            this.chkBranch.Location = new System.Drawing.Point(30, 18);
            this.chkBranch.Name = "chkBranch";
            this.chkBranch.Size = new System.Drawing.Size(77, 17);
            this.chkBranch.TabIndex = 116;
            this.chkBranch.Text = "All Branch.";
            this.chkBranch.UseVisualStyleBackColor = true;
            this.chkBranch.Visible = false;
            this.chkBranch.CheckedChanged += new System.EventHandler(this.chkBranch_CheckedChanged);
            // 
            // lblBranchNo
            // 
            this.lblBranchNo.AutoSize = true;
            this.lblBranchNo.Location = new System.Drawing.Point(84, 42);
            this.lblBranchNo.Name = "lblBranchNo";
            this.lblBranchNo.Size = new System.Drawing.Size(65, 13);
            this.lblBranchNo.TabIndex = 115;
            this.lblBranchNo.Text = "lblBranchNo";
            this.lblBranchNo.Visible = false;
            // 
            // cboBranch
            // 
            this.cboBranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBranch.DropDownHeight = 200;
            this.cboBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBranch.FormattingEnabled = true;
            this.cboBranch.IntegralHeight = false;
            this.cboBranch.IsSendTabOnEnter = true;
            this.cboBranch.Location = new System.Drawing.Point(83, 38);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(141, 21);
            this.cboBranch.TabIndex = 1;
            this.cboBranch.Visible = false;
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Location = new System.Drawing.Point(27, 41);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(50, 13);
            this.lblBranch.TabIndex = 0;
            this.lblBranch.Text = "Branch : ";
            // 
            // gpDateInfo
            // 
            this.gpDateInfo.Controls.Add(this.rdoSettlementDate);
            this.gpDateInfo.Controls.Add(this.rdoTransactionDate);
            this.gpDateInfo.Controls.Add(this.dtpDate);
            this.gpDateInfo.Controls.Add(this.lblDate);
            this.gpDateInfo.Location = new System.Drawing.Point(12, 124);
            this.gpDateInfo.Name = "gpDateInfo";
            this.gpDateInfo.Size = new System.Drawing.Size(314, 92);
            this.gpDateInfo.TabIndex = 113;
            this.gpDateInfo.TabStop = false;
            this.gpDateInfo.Text = "Date";
            // 
            // rdoSettlementDate
            // 
            this.rdoSettlementDate.AutoSize = true;
            this.rdoSettlementDate.IsSendTabOnEnter = true;
            this.rdoSettlementDate.Location = new System.Drawing.Point(150, 19);
            this.rdoSettlementDate.Name = "rdoSettlementDate";
            this.rdoSettlementDate.Size = new System.Drawing.Size(101, 17);
            this.rdoSettlementDate.TabIndex = 116;
            this.rdoSettlementDate.TabStop = true;
            this.rdoSettlementDate.Text = "Settlement Date";
            this.rdoSettlementDate.UseVisualStyleBackColor = true;
            // 
            // rdoTransactionDate
            // 
            this.rdoTransactionDate.AutoSize = true;
            this.rdoTransactionDate.Checked = true;
            this.rdoTransactionDate.IsSendTabOnEnter = true;
            this.rdoTransactionDate.Location = new System.Drawing.Point(31, 19);
            this.rdoTransactionDate.Name = "rdoTransactionDate";
            this.rdoTransactionDate.Size = new System.Drawing.Size(107, 17);
            this.rdoTransactionDate.TabIndex = 115;
            this.rdoTransactionDate.TabStop = true;
            this.rdoTransactionDate.Text = "Transaction Date";
            this.rdoTransactionDate.UseVisualStyleBackColor = true;
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.IsSendTabOnEnter = true;
            this.dtpDate.Location = new System.Drawing.Point(100, 52);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(115, 20);
            this.dtpDate.TabIndex = 2;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(27, 56);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(67, 13);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Enter Date : ";
            // 
            // gbCurrencyInfo
            // 
            this.gbCurrencyInfo.Controls.Add(this.cboCurrency);
            this.gbCurrencyInfo.Controls.Add(this.rdoSourceCurrency);
            this.gbCurrencyInfo.Controls.Add(this.rdoHomeCurrency);
            this.gbCurrencyInfo.Controls.Add(this.lblCurrency);
            this.gbCurrencyInfo.Location = new System.Drawing.Point(10, 224);
            this.gbCurrencyInfo.Name = "gbCurrencyInfo";
            this.gbCurrencyInfo.Size = new System.Drawing.Size(316, 86);
            this.gbCurrencyInfo.TabIndex = 114;
            this.gbCurrencyInfo.TabStop = false;
            this.gbCurrencyInfo.Text = "Currency";
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
            this.cboCurrency.Location = new System.Drawing.Point(111, 55);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 5;
            // 
            // rdoSourceCurrency
            // 
            this.rdoSourceCurrency.AutoSize = true;
            this.rdoSourceCurrency.IsSendTabOnEnter = true;
            this.rdoSourceCurrency.Location = new System.Drawing.Point(152, 23);
            this.rdoSourceCurrency.Name = "rdoSourceCurrency";
            this.rdoSourceCurrency.Size = new System.Drawing.Size(104, 17);
            this.rdoSourceCurrency.TabIndex = 4;
            this.rdoSourceCurrency.TabStop = true;
            this.rdoSourceCurrency.Text = "Source Currency";
            this.rdoSourceCurrency.UseVisualStyleBackColor = true;
            // 
            // rdoHomeCurrency
            // 
            this.rdoHomeCurrency.AutoSize = true;
            this.rdoHomeCurrency.IsSendTabOnEnter = true;
            this.rdoHomeCurrency.Location = new System.Drawing.Point(30, 23);
            this.rdoHomeCurrency.Name = "rdoHomeCurrency";
            this.rdoHomeCurrency.Size = new System.Drawing.Size(98, 17);
            this.rdoHomeCurrency.TabIndex = 3;
            this.rdoHomeCurrency.TabStop = true;
            this.rdoHomeCurrency.Text = "Home Currency";
            this.rdoHomeCurrency.UseVisualStyleBackColor = true;
            this.rdoHomeCurrency.CheckedChanged += new System.EventHandler(this.rdoHomeCurrency_CheckedChanged);
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(27, 55);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(58, 13);
            this.lblCurrency.TabIndex = 0;
            this.lblCurrency.Text = "Currency : ";
            // 
            // chkByHomeCurrency
            // 
            this.chkByHomeCurrency.AutoSize = true;
            this.chkByHomeCurrency.IsSendTabOnEnter = true;
            this.chkByHomeCurrency.Location = new System.Drawing.Point(12, 345);
            this.chkByHomeCurrency.Name = "chkByHomeCurrency";
            this.chkByHomeCurrency.Size = new System.Drawing.Size(114, 17);
            this.chkByHomeCurrency.TabIndex = 7;
            this.chkByHomeCurrency.Text = "By Home Currency";
            this.chkByHomeCurrency.UseVisualStyleBackColor = true;
            // 
            // chkWithReversal
            // 
            this.chkWithReversal.AutoSize = true;
            this.chkWithReversal.IsSendTabOnEnter = true;
            this.chkWithReversal.Location = new System.Drawing.Point(12, 322);
            this.chkWithReversal.Name = "chkWithReversal";
            this.chkWithReversal.Size = new System.Drawing.Size(93, 17);
            this.chkWithReversal.TabIndex = 6;
            this.chkWithReversal.Text = "With Reversal";
            this.chkWithReversal.UseVisualStyleBackColor = true;
            // 
            // TCMVEW00026
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 371);
            this.Controls.Add(this.chkByHomeCurrency);
            this.Controls.Add(this.chkWithReversal);
            this.Controls.Add(this.gbCurrencyInfo);
            this.Controls.Add(this.gpDateInfo);
            this.Controls.Add(this.gpBranchInfo);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TCMVEW00026";
            this.Text = "Clean Cash Scroll";
            this.Load += new System.EventHandler(this.TCMVEW00026_Load);
            this.gpBranchInfo.ResumeLayout(false);
            this.gpBranchInfo.PerformLayout();
            this.gpDateInfo.ResumeLayout(false);
            this.gpDateInfo.PerformLayout();
            this.gbCurrencyInfo.ResumeLayout(false);
            this.gbCurrencyInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox gpBranchInfo;
        private Windows.CXClient.Controls.CXC0002 cboBranch;
        private Windows.CXClient.Controls.CXC0003 lblBranch;
        private System.Windows.Forms.GroupBox gpDateInfo;
        private Windows.CXClient.Controls.CXC0005 dtpDate;
        private Windows.CXClient.Controls.CXC0003 lblDate;
        private System.Windows.Forms.GroupBox gbCurrencyInfo;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0009 rdoSourceCurrency;
        private Windows.CXClient.Controls.CXC0009 rdoHomeCurrency;
        private Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Windows.CXClient.Controls.CXC0008 chkByHomeCurrency;
        private Windows.CXClient.Controls.CXC0008 chkWithReversal;
        private Windows.CXClient.Controls.CXC0009 rdoSettlementDate;
        private Windows.CXClient.Controls.CXC0009 rdoTransactionDate;
        private Windows.CXClient.Controls.CXC0003 lblBranchNo;
        private Windows.CXClient.Controls.CXC0008 chkBranch;
    }
}