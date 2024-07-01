namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00013
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00013));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.mtxtReceiptNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.ntxtInterestRate = new Ace.Windows.CXClient.Controls.CXC0004();
            this.ntxtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.gbInterestTakenAccount = new System.Windows.Forms.GroupBox();
            this.mtxtInterestTakenAccount = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblInterestTakenAccount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.chkAutoRenewal = new Ace.Windows.CXClient.Controls.CXC0008();
            this.gbRenewalType = new System.Windows.Forms.GroupBox();
            this.rdoOnlyPrinciple = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoBothPrincipleandInterest = new Ace.Windows.CXClient.Controls.CXC0009();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboDurationDesp = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblDuration = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblInterestRate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblReceiptNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gbInterestTakenAccount.SuspendLayout();
            this.gbRenewalType.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-2, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(498, 31);
            this.tsbCRUD.TabIndex = 12;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.DeleteButtonClick += new System.EventHandler(this.tsbCRUD_DeleteButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // mtxtReceiptNo
            // 
            this.mtxtReceiptNo.IsSendTabOnEnter = true;
            this.mtxtReceiptNo.Location = new System.Drawing.Point(112, 69);
            this.mtxtReceiptNo.Name = "mtxtReceiptNo";
            this.mtxtReceiptNo.Size = new System.Drawing.Size(115, 20);
            this.mtxtReceiptNo.TabIndex = 2;
            this.mtxtReceiptNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtxtReceiptNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtReceiptNo_KeyPress);
            // 
            // ntxtInterestRate
            // 
            this.ntxtInterestRate.DecimalPlaces = 2;
            this.ntxtInterestRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ntxtInterestRate.IsSendTabOnEnter = true;
            this.ntxtInterestRate.IsThousandSeperator = true;
            this.ntxtInterestRate.IsUseFloatingPoint = true;
            this.ntxtInterestRate.Location = new System.Drawing.Point(112, 148);
            this.ntxtInterestRate.MaxLength = 18;
            this.ntxtInterestRate.Name = "ntxtInterestRate";
            this.ntxtInterestRate.ReadOnly = true;
            this.ntxtInterestRate.Size = new System.Drawing.Size(115, 20);
            this.ntxtInterestRate.TabIndex = 5;
            this.ntxtInterestRate.Text = "0.00";
            this.ntxtInterestRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntxtInterestRate.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
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
            this.ntxtAmount.Size = new System.Drawing.Size(115, 20);
            this.ntxtAmount.TabIndex = 3;
            this.ntxtAmount.Text = "0.00";
            this.ntxtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntxtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // gbInterestTakenAccount
            // 
            this.gbInterestTakenAccount.Controls.Add(this.mtxtInterestTakenAccount);
            this.gbInterestTakenAccount.Controls.Add(this.lblInterestTakenAccount);
            this.gbInterestTakenAccount.Location = new System.Drawing.Point(15, 264);
            this.gbInterestTakenAccount.Name = "gbInterestTakenAccount";
            this.gbInterestTakenAccount.Size = new System.Drawing.Size(301, 51);
            this.gbInterestTakenAccount.TabIndex = 10;
            this.gbInterestTakenAccount.TabStop = false;
            // 
            // mtxtInterestTakenAccount
            // 
            this.mtxtInterestTakenAccount.HidePromptOnLeave = true;
            this.mtxtInterestTakenAccount.IsSendTabOnEnter = true;
            this.mtxtInterestTakenAccount.Location = new System.Drawing.Point(147, 17);
            this.mtxtInterestTakenAccount.Name = "mtxtInterestTakenAccount";
            this.mtxtInterestTakenAccount.Size = new System.Drawing.Size(141, 20);
            this.mtxtInterestTakenAccount.TabIndex = 11;
            this.mtxtInterestTakenAccount.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblInterestTakenAccount
            // 
            this.lblInterestTakenAccount.AutoSize = true;
            this.lblInterestTakenAccount.Location = new System.Drawing.Point(10, 20);
            this.lblInterestTakenAccount.Name = "lblInterestTakenAccount";
            this.lblInterestTakenAccount.Size = new System.Drawing.Size(125, 13);
            this.lblInterestTakenAccount.TabIndex = 0;
            this.lblInterestTakenAccount.Text = "Interest Taken Account :";
            // 
            // chkAutoRenewal
            // 
            this.chkAutoRenewal.AutoSize = true;
            this.chkAutoRenewal.IsSendTabOnEnter = true;
            this.chkAutoRenewal.Location = new System.Drawing.Point(15, 181);
            this.chkAutoRenewal.Name = "chkAutoRenewal";
            this.chkAutoRenewal.Size = new System.Drawing.Size(93, 17);
            this.chkAutoRenewal.TabIndex = 6;
            this.chkAutoRenewal.Text = "Auto Renewal";
            this.chkAutoRenewal.UseVisualStyleBackColor = true;
            this.chkAutoRenewal.CheckedChanged += new System.EventHandler(this.chkAutoRenewal_CheckedChanged);
            // 
            // gbRenewalType
            // 
            this.gbRenewalType.Controls.Add(this.rdoOnlyPrinciple);
            this.gbRenewalType.Controls.Add(this.rdoBothPrincipleandInterest);
            this.gbRenewalType.Location = new System.Drawing.Point(15, 208);
            this.gbRenewalType.Name = "gbRenewalType";
            this.gbRenewalType.Size = new System.Drawing.Size(301, 51);
            this.gbRenewalType.TabIndex = 7;
            this.gbRenewalType.TabStop = false;
            this.gbRenewalType.Text = "Renewal Type";
            // 
            // rdoOnlyPrinciple
            // 
            this.rdoOnlyPrinciple.AutoSize = true;
            this.rdoOnlyPrinciple.IsSendTabOnEnter = true;
            this.rdoOnlyPrinciple.Location = new System.Drawing.Point(202, 22);
            this.rdoOnlyPrinciple.Name = "rdoOnlyPrinciple";
            this.rdoOnlyPrinciple.Size = new System.Drawing.Size(83, 17);
            this.rdoOnlyPrinciple.TabIndex = 9;
            this.rdoOnlyPrinciple.Text = "Only Priciple";
            this.rdoOnlyPrinciple.UseVisualStyleBackColor = true;
            this.rdoOnlyPrinciple.CheckedChanged += new System.EventHandler(this.rdoOnlyPrinciple_CheckedChanged);
            // 
            // rdoBothPrincipleandInterest
            // 
            this.rdoBothPrincipleandInterest.AutoSize = true;
            this.rdoBothPrincipleandInterest.Checked = true;
            this.rdoBothPrincipleandInterest.IsSendTabOnEnter = true;
            this.rdoBothPrincipleandInterest.Location = new System.Drawing.Point(14, 22);
            this.rdoBothPrincipleandInterest.Name = "rdoBothPrincipleandInterest";
            this.rdoBothPrincipleandInterest.Size = new System.Drawing.Size(149, 17);
            this.rdoBothPrincipleandInterest.TabIndex = 8;
            this.rdoBothPrincipleandInterest.TabStop = true;
            this.rdoBothPrincipleandInterest.Text = "Both Principle and Interest";
            this.rdoBothPrincipleandInterest.UseVisualStyleBackColor = true;
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.HidePromptOnLeave = true;
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(112, 43);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 1;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(12, 45);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(70, 13);
            this.lblAccountNo.TabIndex = 0;
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
            this.cboDurationDesp.Location = new System.Drawing.Point(112, 121);
            this.cboDurationDesp.Name = "cboDurationDesp";
            this.cboDurationDesp.Size = new System.Drawing.Size(115, 21);
            this.cboDurationDesp.TabIndex = 4;
            this.cboDurationDesp.SelectedIndexChanged += new System.EventHandler(this.cboDurationDesp_SelectedIndexChanged);
            this.cboDurationDesp.Validated += new System.EventHandler(this.cboDurationDesp_Validated);
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(12, 126);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(53, 13);
            this.lblDuration.TabIndex = 0;
            this.lblDuration.Text = "Duration :";
            // 
            // lblInterestRate
            // 
            this.lblInterestRate.AutoSize = true;
            this.lblInterestRate.Location = new System.Drawing.Point(12, 152);
            this.lblInterestRate.Name = "lblInterestRate";
            this.lblInterestRate.Size = new System.Drawing.Size(74, 13);
            this.lblInterestRate.TabIndex = 0;
            this.lblInterestRate.Text = "Interest Rate :";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(12, 100);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(49, 13);
            this.lblAmount.TabIndex = 0;
            this.lblAmount.Text = "Amount :";
            // 
            // lblReceiptNo
            // 
            this.lblReceiptNo.AutoSize = true;
            this.lblReceiptNo.Location = new System.Drawing.Point(12, 73);
            this.lblReceiptNo.Name = "lblReceiptNo";
            this.lblReceiptNo.Size = new System.Drawing.Size(67, 13);
            this.lblReceiptNo.TabIndex = 0;
            this.lblReceiptNo.Text = "Receipt No :";
            // 
            // TCMVEW00013
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 329);
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
            this.Controls.Add(this.tsbCRUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TCMVEW00013";
            this.Text = "Fixed Deposit Receipt Editing";
            this.Load += new System.EventHandler(this.TCMVEW00013_Load);
            this.Move += new System.EventHandler(this.TCMVEW00013_Move);
            this.gbInterestTakenAccount.ResumeLayout(false);
            this.gbInterestTakenAccount.PerformLayout();
            this.gbRenewalType.ResumeLayout(false);
            this.gbRenewalType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0006 mtxtReceiptNo;
        private Windows.CXClient.Controls.CXC0004 ntxtInterestRate;
        private Windows.CXClient.Controls.CXC0004 ntxtAmount;
        private System.Windows.Forms.GroupBox gbInterestTakenAccount;
        private Windows.CXClient.Controls.CXC0006 mtxtInterestTakenAccount;
        private Windows.CXClient.Controls.CXC0003 lblInterestTakenAccount;
        private Windows.CXClient.Controls.CXC0008 chkAutoRenewal;
        private System.Windows.Forms.GroupBox gbRenewalType;
        private Windows.CXClient.Controls.CXC0009 rdoOnlyPrinciple;
        private Windows.CXClient.Controls.CXC0009 rdoBothPrincipleandInterest;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Windows.CXClient.Controls.CXC0002 cboDurationDesp;
        private Windows.CXClient.Controls.CXC0003 lblDuration;
        private Windows.CXClient.Controls.CXC0003 lblInterestRate;
        private Windows.CXClient.Controls.CXC0003 lblAmount;
        private Windows.CXClient.Controls.CXC0003 lblReceiptNo;
    }
}