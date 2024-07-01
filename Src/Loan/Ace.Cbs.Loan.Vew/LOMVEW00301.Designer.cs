namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00301
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00301));
            this.tlspCommon = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLoanNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.ntxtQuarterAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.ntxtRate = new Ace.Windows.CXClient.Controls.CXC0004();
            this.ntxtSanctionAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblQuarterAmount = new System.Windows.Forms.Label();
            this.lblRate = new System.Windows.Forms.Label();
            this.lblSanctionAmount = new System.Windows.Forms.Label();
            this.lblAccountNo = new System.Windows.Forms.Label();
            this.lblLonaNo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
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
            this.tlspCommon.Size = new System.Drawing.Size(484, 31);
            this.tlspCommon.TabIndex = 4;
            this.tlspCommon.SaveButtonClick += new System.EventHandler(this.tlspCommon_SaveButtonClick);
            this.tlspCommon.CancelButtonClick += new System.EventHandler(this.tlspCommon_CancelButtonClick);
            this.tlspCommon.ExitButtonClick += new System.EventHandler(this.tlspCommon_ExitButtonClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLoanNo);
            this.groupBox1.Controls.Add(this.ntxtQuarterAmount);
            this.groupBox1.Controls.Add(this.ntxtRate);
            this.groupBox1.Controls.Add(this.ntxtSanctionAmount);
            this.groupBox1.Controls.Add(this.mtxtAccountNo);
            this.groupBox1.Controls.Add(this.lblQuarterAmount);
            this.groupBox1.Controls.Add(this.lblRate);
            this.groupBox1.Controls.Add(this.lblSanctionAmount);
            this.groupBox1.Controls.Add(this.lblAccountNo);
            this.groupBox1.Controls.Add(this.lblLonaNo);
            this.groupBox1.Location = new System.Drawing.Point(12, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 156);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // txtLoanNo
            // 
            this.txtLoanNo.IsSendTabOnEnter = true;
            this.txtLoanNo.Location = new System.Drawing.Point(124, 19);
            this.txtLoanNo.MaxLength = 15;
            this.txtLoanNo.Name = "txtLoanNo";
            this.txtLoanNo.Size = new System.Drawing.Size(121, 20);
            this.txtLoanNo.TabIndex = 15;
            this.txtLoanNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLoanNo_KeyPress);
            // 
            // ntxtQuarterAmount
            // 
            this.ntxtQuarterAmount.DecimalPlaces = 2;
            this.ntxtQuarterAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ntxtQuarterAmount.IsSendTabOnEnter = true;
            this.ntxtQuarterAmount.IsThousandSeperator = true;
            this.ntxtQuarterAmount.IsUseFloatingPoint = true;
            this.ntxtQuarterAmount.Location = new System.Drawing.Point(124, 123);
            this.ntxtQuarterAmount.MaxLength = 21;
            this.ntxtQuarterAmount.Name = "ntxtQuarterAmount";
            this.ntxtQuarterAmount.Size = new System.Drawing.Size(142, 20);
            this.ntxtQuarterAmount.TabIndex = 7;
            this.ntxtQuarterAmount.Text = "0.00";
            this.ntxtQuarterAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntxtQuarterAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // ntxtRate
            // 
            this.ntxtRate.DecimalPlaces = 2;
            this.ntxtRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ntxtRate.IsSendTabOnEnter = true;
            this.ntxtRate.IsThousandSeperator = true;
            this.ntxtRate.IsUseFloatingPoint = true;
            this.ntxtRate.Location = new System.Drawing.Point(124, 71);
            this.ntxtRate.MaxLength = 21;
            this.ntxtRate.Name = "ntxtRate";
            this.ntxtRate.Size = new System.Drawing.Size(121, 20);
            this.ntxtRate.TabIndex = 11;
            this.ntxtRate.Text = "0.00";
            this.ntxtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntxtRate.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // ntxtSanctionAmount
            // 
            this.ntxtSanctionAmount.DecimalPlaces = 2;
            this.ntxtSanctionAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ntxtSanctionAmount.IsSendTabOnEnter = true;
            this.ntxtSanctionAmount.IsThousandSeperator = true;
            this.ntxtSanctionAmount.IsUseFloatingPoint = true;
            this.ntxtSanctionAmount.Location = new System.Drawing.Point(124, 97);
            this.ntxtSanctionAmount.MaxLength = 21;
            this.ntxtSanctionAmount.Name = "ntxtSanctionAmount";
            this.ntxtSanctionAmount.Size = new System.Drawing.Size(141, 20);
            this.ntxtSanctionAmount.TabIndex = 9;
            this.ntxtSanctionAmount.Text = "0.00";
            this.ntxtSanctionAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntxtSanctionAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.BackColor = System.Drawing.SystemColors.Window;
            this.mtxtAccountNo.Enabled = false;
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(124, 45);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.ReadOnly = true;
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 8;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblQuarterAmount
            // 
            this.lblQuarterAmount.AutoSize = true;
            this.lblQuarterAmount.Location = new System.Drawing.Point(16, 126);
            this.lblQuarterAmount.Name = "lblQuarterAmount";
            this.lblQuarterAmount.Size = new System.Drawing.Size(87, 13);
            this.lblQuarterAmount.TabIndex = 12;
            this.lblQuarterAmount.Text = "Interest Amount :";
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Location = new System.Drawing.Point(16, 75);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(36, 13);
            this.lblRate.TabIndex = 13;
            this.lblRate.Text = "Rate :";
            // 
            // lblSanctionAmount
            // 
            this.lblSanctionAmount.AutoSize = true;
            this.lblSanctionAmount.Location = new System.Drawing.Point(16, 101);
            this.lblSanctionAmount.Name = "lblSanctionAmount";
            this.lblSanctionAmount.Size = new System.Drawing.Size(94, 13);
            this.lblSanctionAmount.TabIndex = 10;
            this.lblSanctionAmount.Text = "Sanction Amount :";
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(16, 48);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(73, 13);
            this.lblAccountNo.TabIndex = 6;
            this.lblAccountNo.Text = "Account No. :";
            // 
            // lblLonaNo
            // 
            this.lblLonaNo.AutoSize = true;
            this.lblLonaNo.Location = new System.Drawing.Point(16, 22);
            this.lblLonaNo.Name = "lblLonaNo";
            this.lblLonaNo.Size = new System.Drawing.Size(62, 13);
            this.lblLonaNo.TabIndex = 4;
            this.lblLonaNo.Text = "Loans No. :";
            // 
            // LOMVEW00301
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 206);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tlspCommon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00301";
            this.Text = "Farm Loan Interest Editting";
            this.Load += new System.EventHandler(this.LOMVEW00301_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LOMVEW00301_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tlspCommon;
        private System.Windows.Forms.GroupBox groupBox1;
        private Windows.CXClient.Controls.CXC0001 txtLoanNo;
        private Windows.CXClient.Controls.CXC0004 ntxtQuarterAmount;
        private Windows.CXClient.Controls.CXC0004 ntxtRate;
        private Windows.CXClient.Controls.CXC0004 ntxtSanctionAmount;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private System.Windows.Forms.Label lblQuarterAmount;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.Label lblSanctionAmount;
        private System.Windows.Forms.Label lblAccountNo;
        private System.Windows.Forms.Label lblLonaNo;
    }
}