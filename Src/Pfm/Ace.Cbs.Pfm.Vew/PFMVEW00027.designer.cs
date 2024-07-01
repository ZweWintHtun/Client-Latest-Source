namespace Ace.Cbs.Pfm.Vew
{
    partial class PFMVEW00027
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PFMVEW00027));
            this.tlspCommon = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboDurationDesp = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblDuration = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblInterestRate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblReceiptNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.rdoOnlyPrinciple = new Ace.Windows.CXClient.Controls.CXC0009();
            this.chkAutoRenewal = new Ace.Windows.CXClient.Controls.CXC0008();
            this.rdoBothPrincipleandInterest = new Ace.Windows.CXClient.Controls.CXC0009();
            this.gbRenewalType = new System.Windows.Forms.GroupBox();
            this.gbInterestTakenAccount = new System.Windows.Forms.GroupBox();
            this.mtxtInterestTakenAccount = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblInterestTakenAccount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.ntxtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.ntxtInterestRate = new Ace.Windows.CXClient.Controls.CXC0004();
            this.mtxtReceiptNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.gbRenewalType.SuspendLayout();
            this.gbInterestTakenAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlspCommon
            // 
            this.tlspCommon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tlspCommon.BackColor = System.Drawing.Color.PowderBlue;
            this.tlspCommon.Location = new System.Drawing.Point(0, 0);
            this.tlspCommon.Name = "tlspCommon";
            this.tlspCommon.PrintButtonCauseValidation = true;
            this.tlspCommon.Size = new System.Drawing.Size(393, 29);
            this.tlspCommon.TabIndex = 8;
            this.tlspCommon.SaveButtonClick += new System.EventHandler(this.tlspCommon_SaveButtonClick);
            this.tlspCommon.CancelButtonClick += new System.EventHandler(this.tlspCommon_CancelButtonClick);
            this.tlspCommon.ExitButtonClick += new System.EventHandler(this.tlspCommon_ExitButtonClick);
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.HidePromptOnLeave = true;
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(112, 39);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 0;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(12, 41);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(70, 13);
            this.lblAccountNo.TabIndex = 61;
            this.lblAccountNo.Text = "Account No :";
            // 
            // cboDurationDesp
            // 
            this.cboDurationDesp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboDurationDesp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDurationDesp.DropDownHeight = 200;
            this.cboDurationDesp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDurationDesp.FormattingEnabled = true;
            this.cboDurationDesp.IntegralHeight = false;
            this.cboDurationDesp.IsSendTabOnEnter = true;
            this.cboDurationDesp.Items.AddRange(new object[] {
            "Select One",
            "3",
            "4"});
            this.cboDurationDesp.Location = new System.Drawing.Point(112, 123);
            this.cboDurationDesp.Name = "cboDurationDesp";
            this.cboDurationDesp.Size = new System.Drawing.Size(115, 21);
            this.cboDurationDesp.TabIndex = 3;
            this.cboDurationDesp.Validated += new System.EventHandler(this.cboDurationDesp_Validated);
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(12, 125);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(53, 13);
            this.lblDuration.TabIndex = 59;
            this.lblDuration.Text = "Duration :";
            // 
            // lblInterestRate
            // 
            this.lblInterestRate.AutoSize = true;
            this.lblInterestRate.Location = new System.Drawing.Point(12, 156);
            this.lblInterestRate.Name = "lblInterestRate";
            this.lblInterestRate.Size = new System.Drawing.Size(74, 13);
            this.lblInterestRate.TabIndex = 55;
            this.lblInterestRate.Text = "Interest Rate :";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(12, 98);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(49, 13);
            this.lblAmount.TabIndex = 54;
            this.lblAmount.Text = "Amount :";
            // 
            // lblReceiptNo
            // 
            this.lblReceiptNo.AutoSize = true;
            this.lblReceiptNo.Location = new System.Drawing.Point(12, 70);
            this.lblReceiptNo.Name = "lblReceiptNo";
            this.lblReceiptNo.Size = new System.Drawing.Size(67, 13);
            this.lblReceiptNo.TabIndex = 53;
            this.lblReceiptNo.Text = "Receipt No :";
            // 
            // rdoOnlyPrinciple
            // 
            this.rdoOnlyPrinciple.AutoSize = true;
            this.rdoOnlyPrinciple.IsSendTabOnEnter = true;
            this.rdoOnlyPrinciple.Location = new System.Drawing.Point(209, 22);
            this.rdoOnlyPrinciple.Name = "rdoOnlyPrinciple";
            this.rdoOnlyPrinciple.Size = new System.Drawing.Size(83, 17);
            this.rdoOnlyPrinciple.TabIndex = 1;
            this.rdoOnlyPrinciple.TabStop = true;
            this.rdoOnlyPrinciple.Text = "Only Priciple";
            this.rdoOnlyPrinciple.UseVisualStyleBackColor = true;
            this.rdoOnlyPrinciple.CheckedChanged += new System.EventHandler(this.rdoOnlyPrinciple_CheckedChanged);
            // 
            // chkAutoRenewal
            // 
            this.chkAutoRenewal.AutoSize = true;
            this.chkAutoRenewal.IsSendTabOnEnter = true;
            this.chkAutoRenewal.Location = new System.Drawing.Point(15, 187);
            this.chkAutoRenewal.Name = "chkAutoRenewal";
            this.chkAutoRenewal.Size = new System.Drawing.Size(93, 17);
            this.chkAutoRenewal.TabIndex = 5;
            this.chkAutoRenewal.Text = "Auto Renewal";
            this.chkAutoRenewal.UseVisualStyleBackColor = true;
            this.chkAutoRenewal.CheckedChanged += new System.EventHandler(this.chkAutoRenewal_CheckedChanged);
            // 
            // rdoBothPrincipleandInterest
            // 
            this.rdoBothPrincipleandInterest.AutoSize = true;
            this.rdoBothPrincipleandInterest.IsSendTabOnEnter = true;
            this.rdoBothPrincipleandInterest.Location = new System.Drawing.Point(17, 22);
            this.rdoBothPrincipleandInterest.Name = "rdoBothPrincipleandInterest";
            this.rdoBothPrincipleandInterest.Size = new System.Drawing.Size(149, 17);
            this.rdoBothPrincipleandInterest.TabIndex = 0;
            this.rdoBothPrincipleandInterest.TabStop = true;
            this.rdoBothPrincipleandInterest.Text = "Both Principle and Interest";
            this.rdoBothPrincipleandInterest.UseVisualStyleBackColor = true;
            this.rdoBothPrincipleandInterest.CheckedChanged += new System.EventHandler(this.rdoBothPrincipleandInterest_CheckedChanged);
            // 
            // gbRenewalType
            // 
            this.gbRenewalType.Controls.Add(this.rdoOnlyPrinciple);
            this.gbRenewalType.Controls.Add(this.rdoBothPrincipleandInterest);
            this.gbRenewalType.Location = new System.Drawing.Point(15, 217);
            this.gbRenewalType.Name = "gbRenewalType";
            this.gbRenewalType.Size = new System.Drawing.Size(311, 51);
            this.gbRenewalType.TabIndex = 6;
            this.gbRenewalType.TabStop = false;
            this.gbRenewalType.Text = "Renewal Type";
            // 
            // gbInterestTakenAccount
            // 
            this.gbInterestTakenAccount.Controls.Add(this.mtxtInterestTakenAccount);
            this.gbInterestTakenAccount.Controls.Add(this.lblInterestTakenAccount);
            this.gbInterestTakenAccount.Location = new System.Drawing.Point(15, 273);
            this.gbInterestTakenAccount.Name = "gbInterestTakenAccount";
            this.gbInterestTakenAccount.Size = new System.Drawing.Size(311, 51);
            this.gbInterestTakenAccount.TabIndex = 7;
            this.gbInterestTakenAccount.TabStop = false;
            // 
            // mtxtInterestTakenAccount
            // 
            this.mtxtInterestTakenAccount.HidePromptOnLeave = true;
            this.mtxtInterestTakenAccount.IsSendTabOnEnter = true;
            this.mtxtInterestTakenAccount.Location = new System.Drawing.Point(152, 17);
            this.mtxtInterestTakenAccount.Name = "mtxtInterestTakenAccount";
            this.mtxtInterestTakenAccount.Size = new System.Drawing.Size(141, 20);
            this.mtxtInterestTakenAccount.TabIndex = 62;
            this.mtxtInterestTakenAccount.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblInterestTakenAccount
            // 
            this.lblInterestTakenAccount.AutoSize = true;
            this.lblInterestTakenAccount.Location = new System.Drawing.Point(15, 20);
            this.lblInterestTakenAccount.Name = "lblInterestTakenAccount";
            this.lblInterestTakenAccount.Size = new System.Drawing.Size(125, 13);
            this.lblInterestTakenAccount.TabIndex = 0;
            this.lblInterestTakenAccount.Text = "Interest Taken Account :";
            // 
            // ntxtAmount
            // 
            this.ntxtAmount.DecimalPlaces = 2;
            this.ntxtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ntxtAmount.IsSendTabOnEnter = true;
            this.ntxtAmount.IsThousandSeperator = true;
            this.ntxtAmount.IsUseFloatingPoint = true;
            this.ntxtAmount.Location = new System.Drawing.Point(112, 95);
            this.ntxtAmount.MaxLength = 21;
            this.ntxtAmount.Name = "ntxtAmount";
            this.ntxtAmount.Size = new System.Drawing.Size(111, 20);
            this.ntxtAmount.TabIndex = 2;
            this.ntxtAmount.Text = "0.00";
            this.ntxtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntxtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // ntxtInterestRate
            // 
            this.ntxtInterestRate.DecimalPlaces = 2;
            this.ntxtInterestRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ntxtInterestRate.IsSendTabOnEnter = true;
            this.ntxtInterestRate.IsThousandSeperator = true;
            this.ntxtInterestRate.IsUseFloatingPoint = true;
            this.ntxtInterestRate.Location = new System.Drawing.Point(112, 153);
            this.ntxtInterestRate.MaxLength = 18;
            this.ntxtInterestRate.Name = "ntxtInterestRate";
            this.ntxtInterestRate.ReadOnly = true;
            this.ntxtInterestRate.Size = new System.Drawing.Size(111, 20);
            this.ntxtInterestRate.TabIndex = 4;
            this.ntxtInterestRate.Text = "0.00";
            this.ntxtInterestRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntxtInterestRate.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // mtxtReceiptNo
            // 
            this.mtxtReceiptNo.IsSendTabOnEnter = true;
            this.mtxtReceiptNo.Location = new System.Drawing.Point(112, 67);
            this.mtxtReceiptNo.Name = "mtxtReceiptNo";
            this.mtxtReceiptNo.Size = new System.Drawing.Size(115, 20);
            this.mtxtReceiptNo.TabIndex = 62;
            this.mtxtReceiptNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // PFMVEW00027
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 338);
            this.Controls.Add(this.mtxtReceiptNo);
            this.Controls.Add(this.ntxtInterestRate);
            this.Controls.Add(this.ntxtAmount);
            this.Controls.Add(this.gbInterestTakenAccount);
            this.Controls.Add(this.chkAutoRenewal);
            this.Controls.Add(this.gbRenewalType);
            this.Controls.Add(this.mtxtAccountNo);
            this.Controls.Add(this.lblAccountNo);
            this.Controls.Add(this.cboDurationDesp);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.lblInterestRate);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblReceiptNo);
            this.Controls.Add(this.tlspCommon);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PFMVEW00027";
            this.Text = "Receipt Entry";
            this.Load += new System.EventHandler(this.PFMVEW00027_Load);
            this.Move += new System.EventHandler(this.PFMVEW00027_Move);
            this.gbRenewalType.ResumeLayout(false);
            this.gbRenewalType.PerformLayout();
            this.gbInterestTakenAccount.ResumeLayout(false);
            this.gbInterestTakenAccount.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ace.Windows.CXClient.Controls.CXCLIC001 tlspCommon;
        private Ace.Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Ace.Windows.CXClient.Controls.CXC0002 cboDurationDesp;
        private Ace.Windows.CXClient.Controls.CXC0003 lblDuration;
        private Ace.Windows.CXClient.Controls.CXC0003 lblInterestRate;
        private Ace.Windows.CXClient.Controls.CXC0003 lblAmount;
        private Ace.Windows.CXClient.Controls.CXC0003 lblReceiptNo;
        private Ace.Windows.CXClient.Controls.CXC0009 rdoOnlyPrinciple;
        private Ace.Windows.CXClient.Controls.CXC0008 chkAutoRenewal;
        private Ace.Windows.CXClient.Controls.CXC0009 rdoBothPrincipleandInterest;
        private System.Windows.Forms.GroupBox gbRenewalType;
        private System.Windows.Forms.GroupBox gbInterestTakenAccount;
        private Ace.Windows.CXClient.Controls.CXC0003 lblInterestTakenAccount;
        private Windows.CXClient.Controls.CXC0004 ntxtAmount;
        private Windows.CXClient.Controls.CXC0004 ntxtInterestRate;
        private Ace.Windows.CXClient.Controls.CXC0006 mtxtInterestTakenAccount;
        private Ace.Windows.CXClient.Controls.CXC0006 mtxtReceiptNo;
    }
}