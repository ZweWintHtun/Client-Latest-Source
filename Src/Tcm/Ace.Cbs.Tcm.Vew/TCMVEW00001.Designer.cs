namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00001
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00001));
            this.gbDebitAccountInformation = new System.Windows.Forms.GroupBox();
            this.txtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtChequeNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.mtxtDebitAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblChequeNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblDebitAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gbCreditAccountInformation = new System.Windows.Forms.GroupBox();
            this.chkAutoRenewal = new Ace.Windows.CXClient.Controls.CXC0008();
            this.cboDuration = new Ace.Windows.CXClient.Controls.CXC0002();
            this.txtInterestRate = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtReceiptNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblInterestRate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.label3 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblReceiptNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gbRenewalType = new System.Windows.Forms.GroupBox();
            this.rdoOnlyPrinciple = new System.Windows.Forms.RadioButton();
            this.rdoBothPrincipleAndInterest = new System.Windows.Forms.RadioButton();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gbInterestTakenAccount = new System.Windows.Forms.GroupBox();
            this.mtxtInterestTakenAccount = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblInterestTakenAccount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gbDebitAccountInformation.SuspendLayout();
            this.gbCreditAccountInformation.SuspendLayout();
            this.gbRenewalType.SuspendLayout();
            this.gbInterestTakenAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDebitAccountInformation
            // 
            this.gbDebitAccountInformation.Controls.Add(this.txtAmount);
            this.gbDebitAccountInformation.Controls.Add(this.txtChequeNo);
            this.gbDebitAccountInformation.Controls.Add(this.mtxtDebitAccountNo);
            this.gbDebitAccountInformation.Controls.Add(this.lblAmount);
            this.gbDebitAccountInformation.Controls.Add(this.lblChequeNo);
            this.gbDebitAccountInformation.Controls.Add(this.lblDebitAccountNo);
            this.gbDebitAccountInformation.Location = new System.Drawing.Point(28, 46);
            this.gbDebitAccountInformation.Name = "gbDebitAccountInformation";
            this.gbDebitAccountInformation.Size = new System.Drawing.Size(444, 126);
            this.gbDebitAccountInformation.TabIndex = 0;
            this.gbDebitAccountInformation.TabStop = false;
            this.gbDebitAccountInformation.Text = "Debit Account Information";
            // 
            // txtAmount
            // 
            this.txtAmount.DecimalPlaces = 2;
            this.txtAmount.IsSendTabOnEnter = true;
            this.txtAmount.IsThousandSeperator = true;
            this.txtAmount.IsUseFloatingPoint = true;
            this.txtAmount.Location = new System.Drawing.Point(154, 80);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(111, 20);
            this.txtAmount.TabIndex = 3;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.IsSendTabOnEnter = true;
            this.txtChequeNo.Location = new System.Drawing.Point(154, 54);
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(111, 20);
            this.txtChequeNo.TabIndex = 2;
            this.txtChequeNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // mtxtDebitAccountNo
            // 
            this.mtxtDebitAccountNo.IsSendTabOnEnter = true;
            this.mtxtDebitAccountNo.Location = new System.Drawing.Point(154, 28);
            this.mtxtDebitAccountNo.Name = "mtxtDebitAccountNo";
            this.mtxtDebitAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtDebitAccountNo.TabIndex = 1;
            this.mtxtDebitAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(23, 83);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(49, 13);
            this.lblAmount.TabIndex = 0;
            this.lblAmount.Text = "Amount :";
            // 
            // lblChequeNo
            // 
            this.lblChequeNo.AutoSize = true;
            this.lblChequeNo.Location = new System.Drawing.Point(23, 57);
            this.lblChequeNo.Name = "lblChequeNo";
            this.lblChequeNo.Size = new System.Drawing.Size(70, 13);
            this.lblChequeNo.TabIndex = 0;
            this.lblChequeNo.Text = "Cheque No. :";
            // 
            // lblDebitAccountNo
            // 
            this.lblDebitAccountNo.AutoSize = true;
            this.lblDebitAccountNo.Location = new System.Drawing.Point(23, 31);
            this.lblDebitAccountNo.Name = "lblDebitAccountNo";
            this.lblDebitAccountNo.Size = new System.Drawing.Size(101, 13);
            this.lblDebitAccountNo.TabIndex = 0;
            this.lblDebitAccountNo.Text = "Debit Account No. :";
            // 
            // gbCreditAccountInformation
            // 
            this.gbCreditAccountInformation.Controls.Add(this.chkAutoRenewal);
            this.gbCreditAccountInformation.Controls.Add(this.cboDuration);
            this.gbCreditAccountInformation.Controls.Add(this.txtInterestRate);
            this.gbCreditAccountInformation.Controls.Add(this.txtReceiptNo);
            this.gbCreditAccountInformation.Controls.Add(this.mtxtAccountNo);
            this.gbCreditAccountInformation.Controls.Add(this.lblInterestRate);
            this.gbCreditAccountInformation.Controls.Add(this.label3);
            this.gbCreditAccountInformation.Controls.Add(this.lblReceiptNo);
            this.gbCreditAccountInformation.Controls.Add(this.lblAccountNo);
            this.gbCreditAccountInformation.Location = new System.Drawing.Point(28, 182);
            this.gbCreditAccountInformation.Name = "gbCreditAccountInformation";
            this.gbCreditAccountInformation.Size = new System.Drawing.Size(444, 178);
            this.gbCreditAccountInformation.TabIndex = 4;
            this.gbCreditAccountInformation.TabStop = false;
            this.gbCreditAccountInformation.Text = "Credit Account Information";
            // 
            // chkAutoRenewal
            // 
            this.chkAutoRenewal.AutoSize = true;
            this.chkAutoRenewal.IsSendTabOnEnter = true;
            this.chkAutoRenewal.Location = new System.Drawing.Point(26, 139);
            this.chkAutoRenewal.Name = "chkAutoRenewal";
            this.chkAutoRenewal.Size = new System.Drawing.Size(93, 17);
            this.chkAutoRenewal.TabIndex = 9;
            this.chkAutoRenewal.Text = "Auto Renewal";
            this.chkAutoRenewal.UseVisualStyleBackColor = true;
            this.chkAutoRenewal.CheckedChanged += new System.EventHandler(this.chkAutoRenewal_CheckedChanged);
            // 
            // cboDuration
            // 
            this.cboDuration.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboDuration.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDuration.DropDownHeight = 200;
            this.cboDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDuration.FormattingEnabled = true;
            this.cboDuration.IntegralHeight = false;
            this.cboDuration.IsSendTabOnEnter = true;
            this.cboDuration.Location = new System.Drawing.Point(154, 82);
            this.cboDuration.Name = "cboDuration";
            this.cboDuration.Size = new System.Drawing.Size(115, 21);
            this.cboDuration.TabIndex = 7;
            // 
            // txtInterestRate
            // 
            this.txtInterestRate.DecimalPlaces = 2;
            this.txtInterestRate.IsSendTabOnEnter = true;
            this.txtInterestRate.IsThousandSeperator = true;
            this.txtInterestRate.IsUseFloatingPoint = true;
            this.txtInterestRate.Location = new System.Drawing.Point(154, 109);
            this.txtInterestRate.Name = "txtInterestRate";
            this.txtInterestRate.Size = new System.Drawing.Size(111, 20);
            this.txtInterestRate.TabIndex = 8;
            this.txtInterestRate.Text = "0.00";
            this.txtInterestRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInterestRate.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtReceiptNo
            // 
            this.txtReceiptNo.IsSendTabOnEnter = true;
            this.txtReceiptNo.Location = new System.Drawing.Point(154, 56);
            this.txtReceiptNo.Name = "txtReceiptNo";
            this.txtReceiptNo.Size = new System.Drawing.Size(111, 20);
            this.txtReceiptNo.TabIndex = 6;
            this.txtReceiptNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(154, 30);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 5;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblInterestRate
            // 
            this.lblInterestRate.AutoSize = true;
            this.lblInterestRate.Location = new System.Drawing.Point(23, 112);
            this.lblInterestRate.Name = "lblInterestRate";
            this.lblInterestRate.Size = new System.Drawing.Size(74, 13);
            this.lblInterestRate.TabIndex = 0;
            this.lblInterestRate.Text = "Interest Rate :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Duration :";
            // 
            // lblReceiptNo
            // 
            this.lblReceiptNo.AutoSize = true;
            this.lblReceiptNo.Location = new System.Drawing.Point(23, 59);
            this.lblReceiptNo.Name = "lblReceiptNo";
            this.lblReceiptNo.Size = new System.Drawing.Size(70, 13);
            this.lblReceiptNo.TabIndex = 0;
            this.lblReceiptNo.Text = "Receipt No. :";
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(23, 33);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(73, 13);
            this.lblAccountNo.TabIndex = 0;
            this.lblAccountNo.Text = "Account No. :";
            // 
            // gbRenewalType
            // 
            this.gbRenewalType.Controls.Add(this.rdoOnlyPrinciple);
            this.gbRenewalType.Controls.Add(this.rdoBothPrincipleAndInterest);
            this.gbRenewalType.Location = new System.Drawing.Point(28, 370);
            this.gbRenewalType.Name = "gbRenewalType";
            this.gbRenewalType.Size = new System.Drawing.Size(444, 69);
            this.gbRenewalType.TabIndex = 10;
            this.gbRenewalType.TabStop = false;
            this.gbRenewalType.Text = "Renewal Type";
            // 
            // rdoOnlyPrinciple
            // 
            this.rdoOnlyPrinciple.AutoSize = true;
            this.rdoOnlyPrinciple.Location = new System.Drawing.Point(205, 29);
            this.rdoOnlyPrinciple.Name = "rdoOnlyPrinciple";
            this.rdoOnlyPrinciple.Size = new System.Drawing.Size(89, 17);
            this.rdoOnlyPrinciple.TabIndex = 12;
            this.rdoOnlyPrinciple.Text = "Only Principle";
            this.rdoOnlyPrinciple.UseVisualStyleBackColor = true;
            this.rdoOnlyPrinciple.CheckedChanged += new System.EventHandler(this.rdoOnlyPrinciple_CheckedChanged);
            // 
            // rdoBothPrincipleAndInterest
            // 
            this.rdoBothPrincipleAndInterest.AutoSize = true;
            this.rdoBothPrincipleAndInterest.Location = new System.Drawing.Point(25, 29);
            this.rdoBothPrincipleAndInterest.Name = "rdoBothPrincipleAndInterest";
            this.rdoBothPrincipleAndInterest.Size = new System.Drawing.Size(149, 17);
            this.rdoBothPrincipleAndInterest.TabIndex = 11;
            this.rdoBothPrincipleAndInterest.Text = "Both Principle and Interest";
            this.rdoBothPrincipleAndInterest.UseVisualStyleBackColor = true;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(739, 31);
            this.tsbCRUD.TabIndex = 15;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // gbInterestTakenAccount
            // 
            this.gbInterestTakenAccount.Controls.Add(this.mtxtInterestTakenAccount);
            this.gbInterestTakenAccount.Controls.Add(this.lblInterestTakenAccount);
            this.gbInterestTakenAccount.Location = new System.Drawing.Point(28, 443);
            this.gbInterestTakenAccount.Name = "gbInterestTakenAccount";
            this.gbInterestTakenAccount.Size = new System.Drawing.Size(444, 51);
            this.gbInterestTakenAccount.TabIndex = 13;
            this.gbInterestTakenAccount.TabStop = false;
            // 
            // mtxtInterestTakenAccount
            // 
            this.mtxtInterestTakenAccount.HidePromptOnLeave = true;
            this.mtxtInterestTakenAccount.IsSendTabOnEnter = true;
            this.mtxtInterestTakenAccount.Location = new System.Drawing.Point(177, 19);
            this.mtxtInterestTakenAccount.Name = "mtxtInterestTakenAccount";
            this.mtxtInterestTakenAccount.Size = new System.Drawing.Size(141, 20);
            this.mtxtInterestTakenAccount.TabIndex = 14;
            this.mtxtInterestTakenAccount.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblInterestTakenAccount
            // 
            this.lblInterestTakenAccount.AutoSize = true;
            this.lblInterestTakenAccount.Location = new System.Drawing.Point(25, 22);
            this.lblInterestTakenAccount.Name = "lblInterestTakenAccount";
            this.lblInterestTakenAccount.Size = new System.Drawing.Size(125, 13);
            this.lblInterestTakenAccount.TabIndex = 0;
            this.lblInterestTakenAccount.Text = "Interest Taken Account :";
            // 
            // TCMVEW00001
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 511);
            this.Controls.Add(this.gbInterestTakenAccount);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.gbRenewalType);
            this.Controls.Add(this.gbCreditAccountInformation);
            this.Controls.Add(this.gbDebitAccountInformation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TCMVEW00001";
            this.Text = "Fixed Deposit Transfer Entry";
            this.Load += new System.EventHandler(this.TCMVEW00001_Load);
            this.gbDebitAccountInformation.ResumeLayout(false);
            this.gbDebitAccountInformation.PerformLayout();
            this.gbCreditAccountInformation.ResumeLayout(false);
            this.gbCreditAccountInformation.PerformLayout();
            this.gbRenewalType.ResumeLayout(false);
            this.gbRenewalType.PerformLayout();
            this.gbInterestTakenAccount.ResumeLayout(false);
            this.gbInterestTakenAccount.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDebitAccountInformation;
        private Windows.CXClient.Controls.CXC0003 lblAmount;
        private Windows.CXClient.Controls.CXC0003 lblChequeNo;
        private Windows.CXClient.Controls.CXC0003 lblDebitAccountNo;
        private System.Windows.Forms.GroupBox gbCreditAccountInformation;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblInterestRate;
        private Windows.CXClient.Controls.CXC0003 label3;
        private Windows.CXClient.Controls.CXC0003 lblReceiptNo;
        private Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private System.Windows.Forms.GroupBox gbRenewalType;
        private System.Windows.Forms.RadioButton rdoOnlyPrinciple;
        private System.Windows.Forms.RadioButton rdoBothPrincipleAndInterest;
        private Windows.CXClient.Controls.CXC0006 mtxtDebitAccountNo;
        private Windows.CXClient.Controls.CXC0004 txtAmount;
        private Windows.CXClient.Controls.CXC0006 txtChequeNo;
        private Windows.CXClient.Controls.CXC0004 txtInterestRate;
        private Windows.CXClient.Controls.CXC0006 txtReceiptNo;
        private Windows.CXClient.Controls.CXC0002 cboDuration;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0008 chkAutoRenewal;
        private System.Windows.Forms.GroupBox gbInterestTakenAccount;
        private Windows.CXClient.Controls.CXC0006 mtxtInterestTakenAccount;
        private Windows.CXClient.Controls.CXC0003 lblInterestTakenAccount;

    }
}