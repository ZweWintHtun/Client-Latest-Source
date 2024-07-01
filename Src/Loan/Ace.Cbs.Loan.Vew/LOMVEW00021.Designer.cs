namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00021
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00021));
            this.tlspCommon = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.txtLoanNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblLonaNo = new System.Windows.Forms.Label();
            this.chkLegalSuitCase = new Ace.Windows.CXClient.Controls.CXC0008();
            this.txtLawyer = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtAdvanceType = new Ace.Windows.CXClient.Controls.CXC0001();
            this.ntxtServiceCharges = new Ace.Windows.CXClient.Controls.CXC0004();
            this.ntxtExtraCharges = new Ace.Windows.CXClient.Controls.CXC0004();
            this.ntxtIntRate = new Ace.Windows.CXClient.Controls.CXC0004();
            this.ntxtInt = new Ace.Windows.CXClient.Controls.CXC0004();
            this.ntxtSanctionAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.ntxtLedgerBal = new Ace.Windows.CXClient.Controls.CXC0004();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblCaseLawyer = new System.Windows.Forms.Label();
            this.lblExtraCharges = new System.Windows.Forms.Label();
            this.lblServiceCharges = new System.Windows.Forms.Label();
            this.lblInt = new System.Windows.Forms.Label();
            this.lblIntRate = new System.Windows.Forms.Label();
            this.lblLedgerBal = new System.Windows.Forms.Label();
            this.lblSanctionAmount = new System.Windows.Forms.Label();
            this.lblActype = new System.Windows.Forms.Label();
            this.lblAccountNo = new System.Windows.Forms.Label();
            this.grpLegalEditting = new System.Windows.Forms.GroupBox();
            this.grpLegalEditting.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlspCommon
            // 
            this.tlspCommon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tlspCommon.BackColor = System.Drawing.Color.PowderBlue;
            this.tlspCommon.Location = new System.Drawing.Point(0, -1);
            this.tlspCommon.Name = "tlspCommon";
            this.tlspCommon.PrintButtonCauseValidation = true;
            this.tlspCommon.Size = new System.Drawing.Size(554, 31);
            this.tlspCommon.TabIndex = 13;
            this.tlspCommon.SaveButtonClick += new System.EventHandler(this.tlspCommon_SaveButtonClick);
            this.tlspCommon.CancelButtonClick += new System.EventHandler(this.tlspCommon_CancelButtonClick);
            this.tlspCommon.ExitButtonClick += new System.EventHandler(this.tlspCommon_ExitButtonClick);
            // 
            // txtLoanNo
            // 
            this.txtLoanNo.IsSendTabOnEnter = true;
            this.txtLoanNo.Location = new System.Drawing.Point(116, 20);
            this.txtLoanNo.MaxLength = 15;
            this.txtLoanNo.Name = "txtLoanNo";
            this.txtLoanNo.Size = new System.Drawing.Size(121, 20);
            this.txtLoanNo.TabIndex = 1;
            this.txtLoanNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLoanNo_KeyPress);
            // 
            // lblLonaNo
            // 
            this.lblLonaNo.AutoSize = true;
            this.lblLonaNo.Location = new System.Drawing.Point(18, 23);
            this.lblLonaNo.Name = "lblLonaNo";
            this.lblLonaNo.Size = new System.Drawing.Size(79, 13);
            this.lblLonaNo.TabIndex = 14;
            this.lblLonaNo.Text = "Enter Loan No.";
            // 
            // chkLegalSuitCase
            // 
            this.chkLegalSuitCase.AutoSize = true;
            this.chkLegalSuitCase.Checked = true;
            this.chkLegalSuitCase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLegalSuitCase.Enabled = false;
            this.chkLegalSuitCase.IsSendTabOnEnter = true;
            this.chkLegalSuitCase.Location = new System.Drawing.Point(21, 162);
            this.chkLegalSuitCase.Name = "chkLegalSuitCase";
            this.chkLegalSuitCase.Size = new System.Drawing.Size(100, 17);
            this.chkLegalSuitCase.TabIndex = 33;
            this.chkLegalSuitCase.Text = "Legal Suit Case";
            this.chkLegalSuitCase.UseVisualStyleBackColor = true;
            // 
            // txtLawyer
            // 
            this.txtLawyer.IsSendTabOnEnter = true;
            this.txtLawyer.Location = new System.Drawing.Point(378, 124);
            this.txtLawyer.Name = "txtLawyer";
            this.txtLawyer.Size = new System.Drawing.Size(121, 20);
            this.txtLawyer.TabIndex = 34;
            this.txtLawyer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLawyer_KeyPress);
            // 
            // txtAdvanceType
            // 
            this.txtAdvanceType.IsSendTabOnEnter = true;
            this.txtAdvanceType.Location = new System.Drawing.Point(116, 72);
            this.txtAdvanceType.Name = "txtAdvanceType";
            this.txtAdvanceType.Size = new System.Drawing.Size(121, 20);
            this.txtAdvanceType.TabIndex = 22;
            // 
            // ntxtServiceCharges
            // 
            this.ntxtServiceCharges.DecimalPlaces = 2;
            this.ntxtServiceCharges.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ntxtServiceCharges.IsSendTabOnEnter = true;
            this.ntxtServiceCharges.IsThousandSeperator = true;
            this.ntxtServiceCharges.IsUseFloatingPoint = true;
            this.ntxtServiceCharges.Location = new System.Drawing.Point(116, 124);
            this.ntxtServiceCharges.MaxLength = 21;
            this.ntxtServiceCharges.Name = "ntxtServiceCharges";
            this.ntxtServiceCharges.Size = new System.Drawing.Size(121, 20);
            this.ntxtServiceCharges.TabIndex = 30;
            this.ntxtServiceCharges.TabStop = false;
            this.ntxtServiceCharges.Text = "0.00";
            this.ntxtServiceCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntxtServiceCharges.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // ntxtExtraCharges
            // 
            this.ntxtExtraCharges.DecimalPlaces = 2;
            this.ntxtExtraCharges.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ntxtExtraCharges.IsSendTabOnEnter = true;
            this.ntxtExtraCharges.IsThousandSeperator = true;
            this.ntxtExtraCharges.IsUseFloatingPoint = true;
            this.ntxtExtraCharges.Location = new System.Drawing.Point(378, 98);
            this.ntxtExtraCharges.MaxLength = 21;
            this.ntxtExtraCharges.Name = "ntxtExtraCharges";
            this.ntxtExtraCharges.Size = new System.Drawing.Size(121, 20);
            this.ntxtExtraCharges.TabIndex = 32;
            this.ntxtExtraCharges.TabStop = false;
            this.ntxtExtraCharges.Text = "0.00";
            this.ntxtExtraCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntxtExtraCharges.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // ntxtIntRate
            // 
            this.ntxtIntRate.DecimalPlaces = 2;
            this.ntxtIntRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ntxtIntRate.IsSendTabOnEnter = true;
            this.ntxtIntRate.IsThousandSeperator = true;
            this.ntxtIntRate.IsUseFloatingPoint = true;
            this.ntxtIntRate.Location = new System.Drawing.Point(116, 98);
            this.ntxtIntRate.MaxLength = 21;
            this.ntxtIntRate.Name = "ntxtIntRate";
            this.ntxtIntRate.Size = new System.Drawing.Size(121, 20);
            this.ntxtIntRate.TabIndex = 26;
            this.ntxtIntRate.Text = "0.00";
            this.ntxtIntRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntxtIntRate.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // ntxtInt
            // 
            this.ntxtInt.DecimalPlaces = 2;
            this.ntxtInt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ntxtInt.IsSendTabOnEnter = true;
            this.ntxtInt.IsThousandSeperator = true;
            this.ntxtInt.IsUseFloatingPoint = true;
            this.ntxtInt.Location = new System.Drawing.Point(378, 72);
            this.ntxtInt.MaxLength = 21;
            this.ntxtInt.Name = "ntxtInt";
            this.ntxtInt.Size = new System.Drawing.Size(121, 20);
            this.ntxtInt.TabIndex = 28;
            this.ntxtInt.TabStop = false;
            this.ntxtInt.Text = "0.00";
            this.ntxtInt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntxtInt.Value = new decimal(new int[] {
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
            this.ntxtSanctionAmount.Location = new System.Drawing.Point(378, 46);
            this.ntxtSanctionAmount.MaxLength = 21;
            this.ntxtSanctionAmount.Name = "ntxtSanctionAmount";
            this.ntxtSanctionAmount.Size = new System.Drawing.Size(121, 20);
            this.ntxtSanctionAmount.TabIndex = 24;
            this.ntxtSanctionAmount.Text = "0.00";
            this.ntxtSanctionAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntxtSanctionAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // ntxtLedgerBal
            // 
            this.ntxtLedgerBal.DecimalPlaces = 2;
            this.ntxtLedgerBal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ntxtLedgerBal.IsSendTabOnEnter = true;
            this.ntxtLedgerBal.IsThousandSeperator = true;
            this.ntxtLedgerBal.IsUseFloatingPoint = true;
            this.ntxtLedgerBal.Location = new System.Drawing.Point(378, 20);
            this.ntxtLedgerBal.MaxLength = 21;
            this.ntxtLedgerBal.Name = "ntxtLedgerBal";
            this.ntxtLedgerBal.Size = new System.Drawing.Size(121, 20);
            this.ntxtLedgerBal.TabIndex = 20;
            this.ntxtLedgerBal.Text = "0.00";
            this.ntxtLedgerBal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntxtLedgerBal.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.BackColor = System.Drawing.SystemColors.Window;
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(116, 46);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.ReadOnly = true;
            this.mtxtAccountNo.Size = new System.Drawing.Size(121, 20);
            this.mtxtAccountNo.TabIndex = 18;
            // 
            // lblCaseLawyer
            // 
            this.lblCaseLawyer.AutoSize = true;
            this.lblCaseLawyer.Location = new System.Drawing.Point(269, 127);
            this.lblCaseLawyer.Name = "lblCaseLawyer";
            this.lblCaseLawyer.Size = new System.Drawing.Size(103, 13);
            this.lblCaseLawyer.TabIndex = 31;
            this.lblCaseLawyer.Text = "Legal Case Lawyer :";
            // 
            // lblExtraCharges
            // 
            this.lblExtraCharges.AutoSize = true;
            this.lblExtraCharges.Location = new System.Drawing.Point(270, 101);
            this.lblExtraCharges.Name = "lblExtraCharges";
            this.lblExtraCharges.Size = new System.Drawing.Size(79, 13);
            this.lblExtraCharges.TabIndex = 29;
            this.lblExtraCharges.Text = "Extra Charges :";
            // 
            // lblServiceCharges
            // 
            this.lblServiceCharges.AutoSize = true;
            this.lblServiceCharges.Location = new System.Drawing.Point(18, 127);
            this.lblServiceCharges.Name = "lblServiceCharges";
            this.lblServiceCharges.Size = new System.Drawing.Size(94, 13);
            this.lblServiceCharges.TabIndex = 27;
            this.lblServiceCharges.Text = "Service Charges. :";
            // 
            // lblInt
            // 
            this.lblInt.AutoSize = true;
            this.lblInt.Location = new System.Drawing.Point(270, 75);
            this.lblInt.Name = "lblInt";
            this.lblInt.Size = new System.Drawing.Size(48, 13);
            this.lblInt.TabIndex = 25;
            this.lblInt.Text = "Interest :";
            // 
            // lblIntRate
            // 
            this.lblIntRate.AutoSize = true;
            this.lblIntRate.Location = new System.Drawing.Point(18, 101);
            this.lblIntRate.Name = "lblIntRate";
            this.lblIntRate.Size = new System.Drawing.Size(77, 13);
            this.lblIntRate.TabIndex = 23;
            this.lblIntRate.Text = "Interest Rate. :";
            // 
            // lblLedgerBal
            // 
            this.lblLedgerBal.AutoSize = true;
            this.lblLedgerBal.Location = new System.Drawing.Point(270, 23);
            this.lblLedgerBal.Name = "lblLedgerBal";
            this.lblLedgerBal.Size = new System.Drawing.Size(88, 13);
            this.lblLedgerBal.TabIndex = 21;
            this.lblLedgerBal.Text = "Ledger Balance :";
            // 
            // lblSanctionAmount
            // 
            this.lblSanctionAmount.AutoSize = true;
            this.lblSanctionAmount.Location = new System.Drawing.Point(270, 49);
            this.lblSanctionAmount.Name = "lblSanctionAmount";
            this.lblSanctionAmount.Size = new System.Drawing.Size(94, 13);
            this.lblSanctionAmount.TabIndex = 19;
            this.lblSanctionAmount.Text = "Sanction Amount :";
            // 
            // lblActype
            // 
            this.lblActype.AutoSize = true;
            this.lblActype.Location = new System.Drawing.Point(18, 76);
            this.lblActype.Name = "lblActype";
            this.lblActype.Size = new System.Drawing.Size(89, 13);
            this.lblActype.TabIndex = 17;
            this.lblActype.Text = "Advance  Type. :";
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(18, 49);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(73, 13);
            this.lblAccountNo.TabIndex = 16;
            this.lblAccountNo.Text = "Account No. :";
            // 
            // grpLegalEditting
            // 
            this.grpLegalEditting.Controls.Add(this.lblLonaNo);
            this.grpLegalEditting.Controls.Add(this.chkLegalSuitCase);
            this.grpLegalEditting.Controls.Add(this.txtLoanNo);
            this.grpLegalEditting.Controls.Add(this.txtLawyer);
            this.grpLegalEditting.Controls.Add(this.lblAccountNo);
            this.grpLegalEditting.Controls.Add(this.txtAdvanceType);
            this.grpLegalEditting.Controls.Add(this.lblActype);
            this.grpLegalEditting.Controls.Add(this.ntxtServiceCharges);
            this.grpLegalEditting.Controls.Add(this.lblSanctionAmount);
            this.grpLegalEditting.Controls.Add(this.ntxtExtraCharges);
            this.grpLegalEditting.Controls.Add(this.lblLedgerBal);
            this.grpLegalEditting.Controls.Add(this.ntxtIntRate);
            this.grpLegalEditting.Controls.Add(this.lblIntRate);
            this.grpLegalEditting.Controls.Add(this.ntxtInt);
            this.grpLegalEditting.Controls.Add(this.lblInt);
            this.grpLegalEditting.Controls.Add(this.ntxtSanctionAmount);
            this.grpLegalEditting.Controls.Add(this.lblServiceCharges);
            this.grpLegalEditting.Controls.Add(this.ntxtLedgerBal);
            this.grpLegalEditting.Controls.Add(this.lblExtraCharges);
            this.grpLegalEditting.Controls.Add(this.mtxtAccountNo);
            this.grpLegalEditting.Controls.Add(this.lblCaseLawyer);
            this.grpLegalEditting.Location = new System.Drawing.Point(12, 36);
            this.grpLegalEditting.Name = "grpLegalEditting";
            this.grpLegalEditting.Size = new System.Drawing.Size(524, 194);
            this.grpLegalEditting.TabIndex = 1;
            this.grpLegalEditting.TabStop = false;
            // 
            // LOMVEW00021
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 244);
            this.Controls.Add(this.grpLegalEditting);
            this.Controls.Add(this.tlspCommon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LOMVEW00021";
            this.Text = "LOMVEW00021";
            this.Load += new System.EventHandler(this.LOMVEW00021_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LOMVEW00021_KeyDown);
            this.grpLegalEditting.ResumeLayout(false);
            this.grpLegalEditting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tlspCommon;
        private Windows.CXClient.Controls.CXC0001 txtLoanNo;
        private System.Windows.Forms.Label lblLonaNo;
        private Windows.CXClient.Controls.CXC0008 chkLegalSuitCase;
        private Windows.CXClient.Controls.CXC0001 txtLawyer;
        private Windows.CXClient.Controls.CXC0001 txtAdvanceType;
        private Windows.CXClient.Controls.CXC0004 ntxtServiceCharges;
        private Windows.CXClient.Controls.CXC0004 ntxtExtraCharges;
        private Windows.CXClient.Controls.CXC0004 ntxtIntRate;
        private Windows.CXClient.Controls.CXC0004 ntxtInt;
        private Windows.CXClient.Controls.CXC0004 ntxtSanctionAmount;
        private Windows.CXClient.Controls.CXC0004 ntxtLedgerBal;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private System.Windows.Forms.Label lblCaseLawyer;
        private System.Windows.Forms.Label lblExtraCharges;
        private System.Windows.Forms.Label lblServiceCharges;
        private System.Windows.Forms.Label lblInt;
        private System.Windows.Forms.Label lblIntRate;
        private System.Windows.Forms.Label lblLedgerBal;
        private System.Windows.Forms.Label lblSanctionAmount;
        private System.Windows.Forms.Label lblActype;
        private System.Windows.Forms.Label lblAccountNo;
        private System.Windows.Forms.GroupBox grpLegalEditting;
    }
}