namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00035
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00035));
            this.gpBranchInfo = new System.Windows.Forms.GroupBox();
            this.chkBranch = new Ace.Windows.CXClient.Controls.CXC0008();
            this.lblBranchNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboBranchNo = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblBranch = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gpDateInfo = new System.Windows.Forms.GroupBox();
            this.dtpRequiredDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.rdoSettlementDate = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoTransactionDate = new Ace.Windows.CXClient.Controls.CXC0009();
            this.lblDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gbCurrencyInfo = new System.Windows.Forms.GroupBox();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.rdoSourceCur = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoHomeCur = new Ace.Windows.CXClient.Controls.CXC0009();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.chkReversal = new Ace.Windows.CXClient.Controls.CXC0008();
            this.chkByHomeCur = new Ace.Windows.CXClient.Controls.CXC0008();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gpBranchInfo.SuspendLayout();
            this.gpDateInfo.SuspendLayout();
            this.gbCurrencyInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpBranchInfo
            // 
            this.gpBranchInfo.Controls.Add(this.chkBranch);
            this.gpBranchInfo.Controls.Add(this.lblBranchNo);
            this.gpBranchInfo.Controls.Add(this.cboBranchNo);
            this.gpBranchInfo.Controls.Add(this.lblBranch);
            this.gpBranchInfo.Location = new System.Drawing.Point(12, 37);
            this.gpBranchInfo.Name = "gpBranchInfo";
            this.gpBranchInfo.Size = new System.Drawing.Size(345, 81);
            this.gpBranchInfo.TabIndex = 0;
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
            this.lblBranchNo.Location = new System.Drawing.Point(113, 46);
            this.lblBranchNo.Name = "lblBranchNo";
            this.lblBranchNo.Size = new System.Drawing.Size(65, 13);
            this.lblBranchNo.TabIndex = 17;
            this.lblBranchNo.Text = "lblBranchNo";
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
            this.cboBranchNo.Location = new System.Drawing.Point(116, 43);
            this.cboBranchNo.Name = "cboBranchNo";
            this.cboBranchNo.Size = new System.Drawing.Size(141, 21);
            this.cboBranchNo.TabIndex = 2;
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Location = new System.Drawing.Point(27, 45);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(87, 13);
            this.lblBranch.TabIndex = 0;
            this.lblBranch.Text = "Source Branch : ";
            // 
            // gpDateInfo
            // 
            this.gpDateInfo.Controls.Add(this.dtpRequiredDate);
            this.gpDateInfo.Controls.Add(this.rdoSettlementDate);
            this.gpDateInfo.Controls.Add(this.rdoTransactionDate);
            this.gpDateInfo.Controls.Add(this.lblDate);
            this.gpDateInfo.Location = new System.Drawing.Point(12, 124);
            this.gpDateInfo.Name = "gpDateInfo";
            this.gpDateInfo.Size = new System.Drawing.Size(345, 90);
            this.gpDateInfo.TabIndex = 3;
            this.gpDateInfo.TabStop = false;
            this.gpDateInfo.Text = "Date";
            // 
            // dtpRequiredDate
            // 
            this.dtpRequiredDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpRequiredDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRequiredDate.IsSendTabOnEnter = true;
            this.dtpRequiredDate.Location = new System.Drawing.Point(116, 52);
            this.dtpRequiredDate.Name = "dtpRequiredDate";
            this.dtpRequiredDate.Size = new System.Drawing.Size(115, 20);
            this.dtpRequiredDate.TabIndex = 5;
            // 
            // rdoSettlementDate
            // 
            this.rdoSettlementDate.AutoSize = true;
            this.rdoSettlementDate.IsSendTabOnEnter = true;
            this.rdoSettlementDate.Location = new System.Drawing.Point(149, 23);
            this.rdoSettlementDate.Name = "rdoSettlementDate";
            this.rdoSettlementDate.Size = new System.Drawing.Size(101, 17);
            this.rdoSettlementDate.TabIndex = 4;
            this.rdoSettlementDate.TabStop = true;
            this.rdoSettlementDate.Text = "Settlement Date";
            this.rdoSettlementDate.UseVisualStyleBackColor = true;
            // 
            // rdoTransactionDate
            // 
            this.rdoTransactionDate.AutoSize = true;
            this.rdoTransactionDate.Checked = true;
            this.rdoTransactionDate.IsSendTabOnEnter = true;
            this.rdoTransactionDate.Location = new System.Drawing.Point(30, 23);
            this.rdoTransactionDate.Name = "rdoTransactionDate";
            this.rdoTransactionDate.Size = new System.Drawing.Size(107, 17);
            this.rdoTransactionDate.TabIndex = 3;
            this.rdoTransactionDate.TabStop = true;
            this.rdoTransactionDate.Text = "Transaction Date";
            this.rdoTransactionDate.UseVisualStyleBackColor = true;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(27, 58);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(67, 13);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Enter Date : ";
            // 
            // gbCurrencyInfo
            // 
            this.gbCurrencyInfo.Controls.Add(this.cboCurrency);
            this.gbCurrencyInfo.Controls.Add(this.rdoSourceCur);
            this.gbCurrencyInfo.Controls.Add(this.rdoHomeCur);
            this.gbCurrencyInfo.Controls.Add(this.lblCurrency);
            this.gbCurrencyInfo.Location = new System.Drawing.Point(12, 220);
            this.gbCurrencyInfo.Name = "gbCurrencyInfo";
            this.gbCurrencyInfo.Size = new System.Drawing.Size(345, 90);
            this.gbCurrencyInfo.TabIndex = 6;
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
            this.cboCurrency.Location = new System.Drawing.Point(116, 55);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 8;
            // 
            // rdoSourceCur
            // 
            this.rdoSourceCur.AutoSize = true;
            this.rdoSourceCur.IsSendTabOnEnter = true;
            this.rdoSourceCur.Location = new System.Drawing.Point(149, 23);
            this.rdoSourceCur.Name = "rdoSourceCur";
            this.rdoSourceCur.Size = new System.Drawing.Size(104, 17);
            this.rdoSourceCur.TabIndex = 7;
            this.rdoSourceCur.TabStop = true;
            this.rdoSourceCur.Text = "Source Currency";
            this.rdoSourceCur.UseVisualStyleBackColor = true;
            // 
            // rdoHomeCur
            // 
            this.rdoHomeCur.AutoSize = true;
            this.rdoHomeCur.IsSendTabOnEnter = true;
            this.rdoHomeCur.Location = new System.Drawing.Point(30, 23);
            this.rdoHomeCur.Name = "rdoHomeCur";
            this.rdoHomeCur.Size = new System.Drawing.Size(98, 17);
            this.rdoHomeCur.TabIndex = 6;
            this.rdoHomeCur.TabStop = true;
            this.rdoHomeCur.Text = "Home Currency";
            this.rdoHomeCur.UseVisualStyleBackColor = true;
            this.rdoHomeCur.CheckedChanged += new System.EventHandler(this.rdoHomeCur_CheckedChanged);
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(27, 58);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(58, 13);
            this.lblCurrency.TabIndex = 0;
            this.lblCurrency.Text = "Currency : ";
            // 
            // chkReversal
            // 
            this.chkReversal.AutoSize = true;
            this.chkReversal.IsSendTabOnEnter = true;
            this.chkReversal.Location = new System.Drawing.Point(12, 323);
            this.chkReversal.Name = "chkReversal";
            this.chkReversal.Size = new System.Drawing.Size(93, 17);
            this.chkReversal.TabIndex = 9;
            this.chkReversal.Text = "With Reversal";
            this.chkReversal.UseVisualStyleBackColor = true;
            // 
            // chkByHomeCur
            // 
            this.chkByHomeCur.AutoSize = true;
            this.chkByHomeCur.IsSendTabOnEnter = true;
            this.chkByHomeCur.Location = new System.Drawing.Point(12, 346);
            this.chkByHomeCur.Name = "chkByHomeCur";
            this.chkByHomeCur.Size = new System.Drawing.Size(114, 17);
            this.chkByHomeCur.TabIndex = 10;
            this.chkByHomeCur.Text = "By Home Currency";
            this.chkByHomeCur.UseVisualStyleBackColor = true;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-2, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(497, 31);
            this.tsbCRUD.TabIndex = 11;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // TLMVEW00035
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 376);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.chkByHomeCur);
            this.Controls.Add(this.chkReversal);
            this.Controls.Add(this.gbCurrencyInfo);
            this.Controls.Add(this.gpDateInfo);
            this.Controls.Add(this.gpBranchInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00035";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bank Cash Scroll";
            this.Load += new System.EventHandler(this.TLMVEW00035_Load);
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

        private System.Windows.Forms.GroupBox gpBranchInfo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblBranch;
        private System.Windows.Forms.GroupBox gpDateInfo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblDate;
        private Ace.Windows.CXClient.Controls.CXC0009 rdoSettlementDate;
        private Ace.Windows.CXClient.Controls.CXC0009 rdoTransactionDate;
        private System.Windows.Forms.GroupBox gbCurrencyInfo;
        private Ace.Windows.CXClient.Controls.CXC0009 rdoSourceCur;
        private Ace.Windows.CXClient.Controls.CXC0009 rdoHomeCur;
        private Ace.Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Ace.Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Ace.Windows.CXClient.Controls.CXC0008 chkReversal;
        private Ace.Windows.CXClient.Controls.CXC0008 chkByHomeCur;
        private Ace.Windows.CXClient.Controls.CXC0002 cboBranchNo;
        private Ace.Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Ace.Windows.CXClient.Controls.CXC0005 dtpRequiredDate;
        private Windows.CXClient.Controls.CXC0003 lblBranchNo;
        private Windows.CXClient.Controls.CXC0008 chkBranch;
    }
}