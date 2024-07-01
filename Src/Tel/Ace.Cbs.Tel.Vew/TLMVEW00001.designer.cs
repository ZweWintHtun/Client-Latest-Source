namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00001
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00001));
            this.lblDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.txtNarration = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblNarration = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblVoucherNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gbDomesticInformation = new System.Windows.Forms.GroupBox();
            this.lblTransactionDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.rdoDebitVoucher = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoCreditVoucher = new Ace.Windows.CXClient.Controls.CXC0009();
            this.gbDescription = new System.Windows.Forms.GroupBox();
            this.lblDescription = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.mtxtVoucherNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblVoucherType = new System.Windows.Forms.Label();
            this.gbDomesticInformation.SuspendLayout();
            this.gbDescription.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(609, 22);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(0, 13);
            this.lblDate.TabIndex = 0;
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
            "USD",
            "FEC",
            "SGD"});
            this.cboCurrency.Location = new System.Drawing.Point(121, 53);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 0;
            // 
            // txtNarration
            // 
            this.txtNarration.IsSendTabOnEnter = true;
            this.txtNarration.Location = new System.Drawing.Point(119, 210);
            this.txtNarration.MaxLength = 100;
            this.txtNarration.Multiline = true;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(345, 42);
            this.txtNarration.TabIndex = 3;
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(17, 56);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 0;
            this.lblCurrency.Text = "Currency :";
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(17, 127);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(73, 13);
            this.lblAccountNo.TabIndex = 0;
            this.lblAccountNo.Text = "Account No. :";
            // 
            // lblNarration
            // 
            this.lblNarration.AutoSize = true;
            this.lblNarration.Location = new System.Drawing.Point(17, 211);
            this.lblNarration.Name = "lblNarration";
            this.lblNarration.Size = new System.Drawing.Size(56, 13);
            this.lblNarration.TabIndex = 0;
            this.lblNarration.Text = "Narration :";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(17, 261);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(0, 13);
            this.lblAmount.TabIndex = 0;
            // 
            // lblVoucherNo
            // 
            this.lblVoucherNo.AutoSize = true;
            this.lblVoucherNo.Location = new System.Drawing.Point(17, 26);
            this.lblVoucherNo.Name = "lblVoucherNo";
            this.lblVoucherNo.Size = new System.Drawing.Size(97, 13);
            this.lblVoucherNo.TabIndex = 0;
            this.lblVoucherNo.Text = "Cash Voucher No :";
            // 
            // gbDomesticInformation
            // 
            this.gbDomesticInformation.Controls.Add(this.lblVoucherType);
            this.gbDomesticInformation.Controls.Add(this.lblTransactionDate);
            this.gbDomesticInformation.Controls.Add(this.cxC00031);
            this.gbDomesticInformation.Controls.Add(this.mtxtAccountNo);
            this.gbDomesticInformation.Controls.Add(this.rdoDebitVoucher);
            this.gbDomesticInformation.Controls.Add(this.rdoCreditVoucher);
            this.gbDomesticInformation.Controls.Add(this.gbDescription);
            this.gbDomesticInformation.Controls.Add(this.txtAmount);
            this.gbDomesticInformation.Controls.Add(this.mtxtVoucherNo);
            this.gbDomesticInformation.Controls.Add(this.lblDate);
            this.gbDomesticInformation.Controls.Add(this.cboCurrency);
            this.gbDomesticInformation.Controls.Add(this.txtNarration);
            this.gbDomesticInformation.Controls.Add(this.lblCurrency);
            this.gbDomesticInformation.Controls.Add(this.lblAccountNo);
            this.gbDomesticInformation.Controls.Add(this.lblNarration);
            this.gbDomesticInformation.Controls.Add(this.lblAmount);
            this.gbDomesticInformation.Controls.Add(this.lblVoucherNo);
            this.gbDomesticInformation.Location = new System.Drawing.Point(13, 39);
            this.gbDomesticInformation.Name = "gbDomesticInformation";
            this.gbDomesticInformation.Size = new System.Drawing.Size(470, 297);
            this.gbDomesticInformation.TabIndex = 0;
            this.gbDomesticInformation.TabStop = false;
            this.gbDomesticInformation.Text = "Domestic Information";
            // 
            // lblTransactionDate
            // 
            this.lblTransactionDate.AutoSize = true;
            this.lblTransactionDate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblTransactionDate.Location = new System.Drawing.Point(401, 23);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Size = new System.Drawing.Size(0, 13);
            this.lblTransactionDate.TabIndex = 10;
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.cxC00031.Location = new System.Drawing.Point(300, 23);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(95, 13);
            this.cxC00031.TabIndex = 9;
            this.cxC00031.Text = "Transaction Date :";
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(121, 124);
            this.mtxtAccountNo.MaxLength = 6;
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(100, 20);
            this.mtxtAccountNo.TabIndex = 2;
            this.mtxtAccountNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtAccountNo_KeyPress);
            // 
            // rdoDebitVoucher
            // 
            this.rdoDebitVoucher.AutoSize = true;
            this.rdoDebitVoucher.IsSendTabOnEnter = true;
            this.rdoDebitVoucher.Location = new System.Drawing.Point(222, 90);
            this.rdoDebitVoucher.Name = "rdoDebitVoucher";
            this.rdoDebitVoucher.Size = new System.Drawing.Size(93, 17);
            this.rdoDebitVoucher.TabIndex = 1;
            this.rdoDebitVoucher.Text = "Debit Voucher";
            this.rdoDebitVoucher.UseVisualStyleBackColor = true;
            this.rdoDebitVoucher.CheckedChanged += new System.EventHandler(this.rdoDebitVoucher_CheckedChanged);
            // 
            // rdoCreditVoucher
            // 
            this.rdoCreditVoucher.AutoSize = true;
            this.rdoCreditVoucher.Checked = true;
            this.rdoCreditVoucher.IsSendTabOnEnter = true;
            this.rdoCreditVoucher.Location = new System.Drawing.Point(121, 90);
            this.rdoCreditVoucher.Name = "rdoCreditVoucher";
            this.rdoCreditVoucher.Size = new System.Drawing.Size(95, 17);
            this.rdoCreditVoucher.TabIndex = 1;
            this.rdoCreditVoucher.TabStop = true;
            this.rdoCreditVoucher.Text = "Credit Voucher";
            this.rdoCreditVoucher.UseVisualStyleBackColor = true;
            this.rdoCreditVoucher.CheckedChanged += new System.EventHandler(this.rdoCreditVoucher_CheckedChanged);
            // 
            // gbDescription
            // 
            this.gbDescription.Controls.Add(this.lblDescription);
            this.gbDescription.Location = new System.Drawing.Point(119, 150);
            this.gbDescription.Name = "gbDescription";
            this.gbDescription.Size = new System.Drawing.Size(231, 54);
            this.gbDescription.TabIndex = 6;
            this.gbDescription.TabStop = false;
            this.gbDescription.Text = "Description";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(10, 25);
            this.lblDescription.MaximumSize = new System.Drawing.Size(200, 50);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(0, 13);
            this.lblDescription.TabIndex = 0;
            // 
            // txtAmount
            // 
            this.txtAmount.DecimalPlaces = 2;
            this.txtAmount.IsSendTabOnEnter = true;
            this.txtAmount.IsThousandSeperator = true;
            this.txtAmount.IsUseFloatingPoint = true;
            this.txtAmount.Location = new System.Drawing.Point(119, 258);
            this.txtAmount.MaxLength = 18;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(111, 20);
            this.txtAmount.TabIndex = 4;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // mtxtVoucherNo
            // 
            this.mtxtVoucherNo.Enabled = false;
            this.mtxtVoucherNo.IsSendTabOnEnter = true;
            this.mtxtVoucherNo.Location = new System.Drawing.Point(121, 23);
            this.mtxtVoucherNo.Name = "mtxtVoucherNo";
            this.mtxtVoucherNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtVoucherNo.TabIndex = 6;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-2, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(496, 31);
            this.tsbCRUD.TabIndex = 5;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblVoucherType
            // 
            this.lblVoucherType.AutoSize = true;
            this.lblVoucherType.Location = new System.Drawing.Point(17, 94);
            this.lblVoucherType.Name = "lblVoucherType";
            this.lblVoucherType.Size = new System.Drawing.Size(80, 13);
            this.lblVoucherType.TabIndex = 11;
            this.lblVoucherType.Text = "Voucher Type :";
            // 
            // TLMVEW00001
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 348);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.gbDomesticInformation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TLMVEW00001";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Domestic Voucher Entry";
            this.Load += new System.EventHandler(this.TLMVEW00001_Load);
            this.Move += new System.EventHandler(this.TLMVEW00001_Move);
            this.gbDomesticInformation.ResumeLayout(false);
            this.gbDomesticInformation.PerformLayout();
            this.gbDescription.ResumeLayout(false);
            this.gbDescription.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Ace.Windows.CXClient.Controls.CXC0003 lblDate;
        private Ace.Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Ace.Windows.CXClient.Controls.CXC0001 txtNarration;
        private Ace.Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Ace.Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblNarration;
        private Ace.Windows.CXClient.Controls.CXC0003 lblAmount;
        private Ace.Windows.CXClient.Controls.CXC0003 lblVoucherNo;
        private System.Windows.Forms.GroupBox gbDomesticInformation;
        private Ace.Windows.CXClient.Controls.CXC0006 mtxtVoucherNo;
        private Ace.Windows.CXClient.Controls.CXC0004 txtAmount;
        private System.Windows.Forms.GroupBox gbDescription;
        private Ace.Windows.CXClient.Controls.CXC0003 lblDescription;
        private Ace.Windows.CXClient.Controls.CXC0009 rdoDebitVoucher;
        private Ace.Windows.CXClient.Controls.CXC0009 rdoCreditVoucher;
        private Ace.Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0001 mtxtAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblTransactionDate;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private System.Windows.Forms.Label lblVoucherType;
    }
}