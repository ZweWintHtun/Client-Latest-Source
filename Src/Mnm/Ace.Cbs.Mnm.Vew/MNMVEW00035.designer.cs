namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00035
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00035));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gbDate = new System.Windows.Forms.GroupBox();
            this.rdoSettlementDate = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoTransactionDate = new Ace.Windows.CXClient.Controls.CXC0009();
            this.dtpDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.lblEnterDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboBranchNo = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.chkWithReversal = new Ace.Windows.CXClient.Controls.CXC0008();
            this.rdoSourceCurrency = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoHomeCurrency = new Ace.Windows.CXClient.Controls.CXC0009();
            this.gpBranchInfo = new System.Windows.Forms.GroupBox();
            this.chkBranch = new Ace.Windows.CXClient.Controls.CXC0008();
            this.lblBranchNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gbCurrencyInfo = new System.Windows.Forms.GroupBox();
            this.gbDate.SuspendLayout();
            this.gpBranchInfo.SuspendLayout();
            this.gbCurrencyInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.CausesValidation = false;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, -1);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(497, 31);
            this.tsbCRUD.TabIndex = 8;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // gbDate
            // 
            this.gbDate.Controls.Add(this.rdoSettlementDate);
            this.gbDate.Controls.Add(this.rdoTransactionDate);
            this.gbDate.Controls.Add(this.dtpDate);
            this.gbDate.Controls.Add(this.lblEnterDate);
            this.gbDate.Location = new System.Drawing.Point(12, 122);
            this.gbDate.Name = "gbDate";
            this.gbDate.Size = new System.Drawing.Size(345, 83);
            this.gbDate.TabIndex = 0;
            this.gbDate.TabStop = false;
            // 
            // rdoSettlementDate
            // 
            this.rdoSettlementDate.AutoSize = true;
            this.rdoSettlementDate.IsSendTabOnEnter = true;
            this.rdoSettlementDate.Location = new System.Drawing.Point(135, 18);
            this.rdoSettlementDate.Name = "rdoSettlementDate";
            this.rdoSettlementDate.Size = new System.Drawing.Size(101, 17);
            this.rdoSettlementDate.TabIndex = 1;
            this.rdoSettlementDate.TabStop = true;
            this.rdoSettlementDate.Text = "Settlement Date";
            this.rdoSettlementDate.UseVisualStyleBackColor = true;
            // 
            // rdoTransactionDate
            // 
            this.rdoTransactionDate.AutoSize = true;
            this.rdoTransactionDate.IsSendTabOnEnter = true;
            this.rdoTransactionDate.Location = new System.Drawing.Point(6, 18);
            this.rdoTransactionDate.Name = "rdoTransactionDate";
            this.rdoTransactionDate.Size = new System.Drawing.Size(107, 17);
            this.rdoTransactionDate.TabIndex = 0;
            this.rdoTransactionDate.TabStop = true;
            this.rdoTransactionDate.Text = "Transaction Date";
            this.rdoTransactionDate.UseVisualStyleBackColor = true;
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.IsSendTabOnEnter = true;
            this.dtpDate.Location = new System.Drawing.Point(121, 45);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(121, 20);
            this.dtpDate.TabIndex = 1;
            this.dtpDate.Value = new System.DateTime(2014, 1, 9, 15, 15, 29, 0);
            // 
            // lblEnterDate
            // 
            this.lblEnterDate.AutoSize = true;
            this.lblEnterDate.Location = new System.Drawing.Point(26, 48);
            this.lblEnterDate.Name = "lblEnterDate";
            this.lblEnterDate.Size = new System.Drawing.Size(64, 13);
            this.lblEnterDate.TabIndex = 8;
            this.lblEnterDate.Text = "Enter Date :";
            // 
            // cboBranchNo
            // 
            this.cboBranchNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboBranchNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBranchNo.DropDownHeight = 200;
            this.cboBranchNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBranchNo.FormattingEnabled = true;
            this.cboBranchNo.IntegralHeight = false;
            this.cboBranchNo.IsSendTabOnEnter = true;
            this.cboBranchNo.Location = new System.Drawing.Point(121, 39);
            this.cboBranchNo.Name = "cboBranchNo";
            this.cboBranchNo.Size = new System.Drawing.Size(121, 21);
            this.cboBranchNo.TabIndex = 3;
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(13, 57);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 8;
            this.lblCurrency.Text = "Currency :";
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
            this.cboCurrency.Location = new System.Drawing.Point(108, 54);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(121, 21);
            this.cboCurrency.TabIndex = 6;
            // 
            // chkWithReversal
            // 
            this.chkWithReversal.AutoSize = true;
            this.chkWithReversal.IsSendTabOnEnter = true;
            this.chkWithReversal.Location = new System.Drawing.Point(21, 308);
            this.chkWithReversal.Name = "chkWithReversal";
            this.chkWithReversal.Size = new System.Drawing.Size(93, 17);
            this.chkWithReversal.TabIndex = 7;
            this.chkWithReversal.Text = "With Reversal";
            this.chkWithReversal.UseVisualStyleBackColor = true;
            // 
            // rdoSourceCurrency
            // 
            this.rdoSourceCurrency.AutoSize = true;
            this.rdoSourceCurrency.IsSendTabOnEnter = true;
            this.rdoSourceCurrency.Location = new System.Drawing.Point(136, 27);
            this.rdoSourceCurrency.Name = "rdoSourceCurrency";
            this.rdoSourceCurrency.Size = new System.Drawing.Size(104, 17);
            this.rdoSourceCurrency.TabIndex = 4;
            this.rdoSourceCurrency.TabStop = true;
            this.rdoSourceCurrency.Text = "Source Currency";
            this.rdoSourceCurrency.UseVisualStyleBackColor = true;
            this.rdoSourceCurrency.CheckedChanged += new System.EventHandler(this.rdoSourceCurrency_CheckedChanged);
            // 
            // rdoHomeCurrency
            // 
            this.rdoHomeCurrency.AutoSize = true;
            this.rdoHomeCurrency.IsSendTabOnEnter = true;
            this.rdoHomeCurrency.Location = new System.Drawing.Point(15, 27);
            this.rdoHomeCurrency.Name = "rdoHomeCurrency";
            this.rdoHomeCurrency.Size = new System.Drawing.Size(98, 17);
            this.rdoHomeCurrency.TabIndex = 5;
            this.rdoHomeCurrency.TabStop = true;
            this.rdoHomeCurrency.Text = "Home Currency";
            this.rdoHomeCurrency.UseVisualStyleBackColor = true;
            this.rdoHomeCurrency.CheckedChanged += new System.EventHandler(this.rdoHomeCurrency_CheckedChanged);
            // 
            // gpBranchInfo
            // 
            this.gpBranchInfo.Controls.Add(this.chkBranch);
            this.gpBranchInfo.Controls.Add(this.lblBranchNo);
            this.gpBranchInfo.Controls.Add(this.cxC00031);
            this.gpBranchInfo.Controls.Add(this.cboBranchNo);
            this.gpBranchInfo.Location = new System.Drawing.Point(12, 40);
            this.gpBranchInfo.Name = "gpBranchInfo";
            this.gpBranchInfo.Size = new System.Drawing.Size(345, 81);
            this.gpBranchInfo.TabIndex = 9;
            this.gpBranchInfo.TabStop = false;
            this.gpBranchInfo.Text = "Branch";
            // 
            // chkBranch
            // 
            this.chkBranch.AutoSize = true;
            this.chkBranch.IsSendTabOnEnter = true;
            this.chkBranch.Location = new System.Drawing.Point(30, 20);
            this.chkBranch.Name = "chkBranch";
            this.chkBranch.Size = new System.Drawing.Size(77, 17);
            this.chkBranch.TabIndex = 1;
            this.chkBranch.Text = "All Branch.";
            this.chkBranch.UseVisualStyleBackColor = true;
            this.chkBranch.Visible = false;
            this.chkBranch.CheckedChanged += new System.EventHandler(this.chkBranch_CheckedChanged);
            // 
            // lblBranchNo
            // 
            this.lblBranchNo.AutoSize = true;
            this.lblBranchNo.Location = new System.Drawing.Point(124, 43);
            this.lblBranchNo.Name = "lblBranchNo";
            this.lblBranchNo.Size = new System.Drawing.Size(65, 13);
            this.lblBranchNo.TabIndex = 17;
            this.lblBranchNo.Text = "lblBranchNo";
            this.lblBranchNo.Visible = false;
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(27, 45);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(87, 13);
            this.cxC00031.TabIndex = 0;
            this.cxC00031.Text = "Source Branch : ";
            // 
            // gbCurrencyInfo
            // 
            this.gbCurrencyInfo.Controls.Add(this.rdoHomeCurrency);
            this.gbCurrencyInfo.Controls.Add(this.rdoSourceCurrency);
            this.gbCurrencyInfo.Controls.Add(this.cboCurrency);
            this.gbCurrencyInfo.Controls.Add(this.lblCurrency);
            this.gbCurrencyInfo.Location = new System.Drawing.Point(11, 208);
            this.gbCurrencyInfo.Name = "gbCurrencyInfo";
            this.gbCurrencyInfo.Size = new System.Drawing.Size(346, 90);
            this.gbCurrencyInfo.TabIndex = 10;
            this.gbCurrencyInfo.TabStop = false;
            this.gbCurrencyInfo.Text = "Currency";
            // 
            // MNMVEW00035
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 343);
            this.Controls.Add(this.gbCurrencyInfo);
            this.Controls.Add(this.gpBranchInfo);
            this.Controls.Add(this.chkWithReversal);
            this.Controls.Add(this.gbDate);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00035";
            this.Text = "Transfer Scroll Listing";
            this.Load += new System.EventHandler(this.MNMVEW00035_Load);
            this.gbDate.ResumeLayout(false);
            this.gbDate.PerformLayout();
            this.gpBranchInfo.ResumeLayout(false);
            this.gpBranchInfo.PerformLayout();
            this.gbCurrencyInfo.ResumeLayout(false);
            this.gbCurrencyInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox gbDate;
        private Windows.CXClient.Controls.CXC0009 rdoSettlementDate;
        private Windows.CXClient.Controls.CXC0009 rdoTransactionDate;
        private Windows.CXClient.Controls.CXC0003 lblEnterDate;
        private Windows.CXClient.Controls.CXC0005 dtpDate;
        private Windows.CXClient.Controls.CXC0002 cboBranchNo;
        private Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0008 chkWithReversal;
        private Windows.CXClient.Controls.CXC0009 rdoSourceCurrency;
        private Windows.CXClient.Controls.CXC0009 rdoHomeCurrency;
        private System.Windows.Forms.GroupBox gpBranchInfo;
        private Windows.CXClient.Controls.CXC0008 chkBranch;
        private Windows.CXClient.Controls.CXC0003 lblBranchNo;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private System.Windows.Forms.GroupBox gbCurrencyInfo;
    }
}