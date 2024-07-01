namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00053
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00053));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.grpLedgerByTransaction = new System.Windows.Forms.GroupBox();
            this.rdoOverDrawn = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoFixedDepoAccount = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoSavingAccount = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoCurrentAccount = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoAll = new Ace.Windows.CXClient.Controls.CXC0009();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gbSort = new System.Windows.Forms.GroupBox();
            this.rdoAmount = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoAccountNo = new Ace.Windows.CXClient.Controls.CXC0009();
            this.chkIsAllCurrency = new Ace.Windows.CXClient.Controls.CXC0008();
            this.grpLedgerByTransaction.SuspendLayout();
            this.gbSort.SuspendLayout();
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
            this.tsbCRUD.Size = new System.Drawing.Size(495, 31);
            this.tsbCRUD.TabIndex = 9;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick_1);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // grpLedgerByTransaction
            // 
            this.grpLedgerByTransaction.Controls.Add(this.rdoOverDrawn);
            this.grpLedgerByTransaction.Controls.Add(this.rdoFixedDepoAccount);
            this.grpLedgerByTransaction.Controls.Add(this.rdoSavingAccount);
            this.grpLedgerByTransaction.Controls.Add(this.rdoCurrentAccount);
            this.grpLedgerByTransaction.Controls.Add(this.rdoAll);
            this.grpLedgerByTransaction.Location = new System.Drawing.Point(15, 47);
            this.grpLedgerByTransaction.Name = "grpLedgerByTransaction";
            this.grpLedgerByTransaction.Size = new System.Drawing.Size(210, 151);
            this.grpLedgerByTransaction.TabIndex = 0;
            this.grpLedgerByTransaction.TabStop = false;
            this.grpLedgerByTransaction.Text = "Choose Transaction";
            // 
            // rdoOverDrawn
            // 
            this.rdoOverDrawn.AutoSize = true;
            this.rdoOverDrawn.IsSendTabOnEnter = true;
            this.rdoOverDrawn.Location = new System.Drawing.Point(12, 115);
            this.rdoOverDrawn.Name = "rdoOverDrawn";
            this.rdoOverDrawn.Size = new System.Drawing.Size(69, 17);
            this.rdoOverDrawn.TabIndex = 5;
            this.rdoOverDrawn.Text = "Overdraft";
            this.rdoOverDrawn.UseVisualStyleBackColor = true;
            // 
            // rdoFixedDepoAccount
            // 
            this.rdoFixedDepoAccount.AutoSize = true;
            this.rdoFixedDepoAccount.IsSendTabOnEnter = true;
            this.rdoFixedDepoAccount.Location = new System.Drawing.Point(12, 92);
            this.rdoFixedDepoAccount.Name = "rdoFixedDepoAccount";
            this.rdoFixedDepoAccount.Size = new System.Drawing.Size(132, 17);
            this.rdoFixedDepoAccount.TabIndex = 4;
            this.rdoFixedDepoAccount.Text = "Fixed Deposit Account";
            this.rdoFixedDepoAccount.UseVisualStyleBackColor = true;
            // 
            // rdoSavingAccount
            // 
            this.rdoSavingAccount.AutoSize = true;
            this.rdoSavingAccount.IsSendTabOnEnter = true;
            this.rdoSavingAccount.Location = new System.Drawing.Point(12, 69);
            this.rdoSavingAccount.Name = "rdoSavingAccount";
            this.rdoSavingAccount.Size = new System.Drawing.Size(101, 17);
            this.rdoSavingAccount.TabIndex = 3;
            this.rdoSavingAccount.Text = "Saving Account";
            this.rdoSavingAccount.UseVisualStyleBackColor = true;
            // 
            // rdoCurrentAccount
            // 
            this.rdoCurrentAccount.AutoSize = true;
            this.rdoCurrentAccount.IsSendTabOnEnter = true;
            this.rdoCurrentAccount.Location = new System.Drawing.Point(12, 46);
            this.rdoCurrentAccount.Name = "rdoCurrentAccount";
            this.rdoCurrentAccount.Size = new System.Drawing.Size(102, 17);
            this.rdoCurrentAccount.TabIndex = 2;
            this.rdoCurrentAccount.Text = "Current Account";
            this.rdoCurrentAccount.UseVisualStyleBackColor = true;
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.IsSendTabOnEnter = true;
            this.rdoAll.Location = new System.Drawing.Point(12, 23);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(36, 17);
            this.rdoAll.TabIndex = 1;
            this.rdoAll.Text = "All";
            this.rdoAll.UseVisualStyleBackColor = true;
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
            this.cboCurrency.Location = new System.Drawing.Point(301, 70);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 3;
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(240, 73);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 10;
            this.lblCurrency.Text = "Currency :";
            // 
            // gbSort
            // 
            this.gbSort.Controls.Add(this.rdoAmount);
            this.gbSort.Controls.Add(this.rdoAccountNo);
            this.gbSort.Location = new System.Drawing.Point(231, 97);
            this.gbSort.Name = "gbSort";
            this.gbSort.Size = new System.Drawing.Size(185, 63);
            this.gbSort.TabIndex = 4;
            this.gbSort.TabStop = false;
            this.gbSort.Text = "Sort By";
            // 
            // rdoAmount
            // 
            this.rdoAmount.AutoSize = true;
            this.rdoAmount.IsSendTabOnEnter = true;
            this.rdoAmount.Location = new System.Drawing.Point(104, 23);
            this.rdoAmount.Name = "rdoAmount";
            this.rdoAmount.Size = new System.Drawing.Size(61, 17);
            this.rdoAmount.TabIndex = 7;
            this.rdoAmount.Text = "Amount";
            this.rdoAmount.UseVisualStyleBackColor = true;
            // 
            // rdoAccountNo
            // 
            this.rdoAccountNo.AutoSize = true;
            this.rdoAccountNo.IsSendTabOnEnter = true;
            this.rdoAccountNo.Location = new System.Drawing.Point(10, 23);
            this.rdoAccountNo.Name = "rdoAccountNo";
            this.rdoAccountNo.Size = new System.Drawing.Size(82, 17);
            this.rdoAccountNo.TabIndex = 6;
            this.rdoAccountNo.Text = "Account No";
            this.rdoAccountNo.UseVisualStyleBackColor = true;
            // 
            // chkIsAllCurrency
            // 
            this.chkIsAllCurrency.AutoSize = true;
            this.chkIsAllCurrency.IsSendTabOnEnter = true;
            this.chkIsAllCurrency.Location = new System.Drawing.Point(243, 47);
            this.chkIsAllCurrency.Name = "chkIsAllCurrency";
            this.chkIsAllCurrency.Size = new System.Drawing.Size(79, 17);
            this.chkIsAllCurrency.TabIndex = 2;
            this.chkIsAllCurrency.Text = "AllCurrency";
            this.chkIsAllCurrency.UseVisualStyleBackColor = true;
            this.chkIsAllCurrency.CheckedChanged += new System.EventHandler(this.chkIsAllCurrency_CheckedChanged);
            // 
            // MNMVEW00053
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 219);
            this.Controls.Add(this.chkIsAllCurrency);
            this.Controls.Add(this.gbSort);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.lblCurrency);
            this.Controls.Add(this.grpLedgerByTransaction);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00053";
            this.Text = "Ledger Balance";
            this.Load += new System.EventHandler(this.MNMVEW00053_Load);
            this.grpLedgerByTransaction.ResumeLayout(false);
            this.grpLedgerByTransaction.PerformLayout();
            this.gbSort.ResumeLayout(false);
            this.gbSort.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox grpLedgerByTransaction;
        private Windows.CXClient.Controls.CXC0009 rdoOverDrawn;
        private Windows.CXClient.Controls.CXC0009 rdoFixedDepoAccount;
        private Windows.CXClient.Controls.CXC0009 rdoSavingAccount;
        private Windows.CXClient.Controls.CXC0009 rdoCurrentAccount;
        private Windows.CXClient.Controls.CXC0009 rdoAll;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0003 lblCurrency;
        private System.Windows.Forms.GroupBox gbSort;
        private Windows.CXClient.Controls.CXC0009 rdoAmount;
        private Windows.CXClient.Controls.CXC0009 rdoAccountNo;
        private Windows.CXClient.Controls.CXC0008 chkIsAllCurrency;
    }
}