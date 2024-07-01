namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00013
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00013));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtLoanNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblDateDisplay = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblLoanNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtServiceCharges = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtCommitmentFees = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtInterest = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtType = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblServiceCharges = new Ace.Windows.CXClient.Controls.CXC0003();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPenlityFees = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtTotal = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtOutstandingChg = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtOutstandingInt = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblTotal = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblPenlityFees = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblOutstandingChg = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblOutstandingInt = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCommitmentFees = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblInterest = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblType = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.dgvLoanACClose = new System.Windows.Forms.DataGridView();
            this.CustName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoanACClose)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtLoanNo);
            this.panel1.Controls.Add(this.lblDateDisplay);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.lblLoanNo);
            this.panel1.Location = new System.Drawing.Point(12, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(553, 59);
            this.panel1.TabIndex = 0;
            // 
            // txtLoanNo
            // 
            this.txtLoanNo.IsSendTabOnEnter = true;
            this.txtLoanNo.Location = new System.Drawing.Point(99, 18);
            this.txtLoanNo.MaxLength = 15;
            this.txtLoanNo.Name = "txtLoanNo";
            this.txtLoanNo.Size = new System.Drawing.Size(121, 20);
            this.txtLoanNo.TabIndex = 1;
            this.txtLoanNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLoanNo_KeyPress);
            // 
            // lblDateDisplay
            // 
            this.lblDateDisplay.Enabled = false;
            this.lblDateDisplay.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblDateDisplay.Location = new System.Drawing.Point(459, 20);
            this.lblDateDisplay.Name = "lblDateDisplay";
            this.lblDateDisplay.Size = new System.Drawing.Size(86, 20);
            this.lblDateDisplay.TabIndex = 13;
            this.lblDateDisplay.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblDate.Location = new System.Drawing.Point(421, 24);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(39, 13);
            this.lblDate.TabIndex = 11;
            this.lblDate.Text = "Date : ";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLoanNo
            // 
            this.lblLoanNo.AutoSize = true;
            this.lblLoanNo.Location = new System.Drawing.Point(18, 24);
            this.lblLoanNo.Name = "lblLoanNo";
            this.lblLoanNo.Size = new System.Drawing.Size(54, 13);
            this.lblLoanNo.TabIndex = 12;
            this.lblLoanNo.Text = "Loan No.:";
            this.lblLoanNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtServiceCharges);
            this.panel2.Controls.Add(this.txtCommitmentFees);
            this.panel2.Controls.Add(this.txtInterest);
            this.panel2.Controls.Add(this.txtAmount);
            this.panel2.Controls.Add(this.txtAccountNo);
            this.panel2.Controls.Add(this.txtType);
            this.panel2.Controls.Add(this.lblServiceCharges);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.lblCommitmentFees);
            this.panel2.Controls.Add(this.lblInterest);
            this.panel2.Controls.Add(this.lblAmount);
            this.panel2.Controls.Add(this.lblType);
            this.panel2.Controls.Add(this.lblAccountNo);
            this.panel2.Location = new System.Drawing.Point(12, 107);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(312, 319);
            this.panel2.TabIndex = 12;
            // 
            // txtServiceCharges
            // 
            this.txtServiceCharges.DecimalPlaces = 0;
            this.txtServiceCharges.IsSendTabOnEnter = true;
            this.txtServiceCharges.IsThousandSeperator = true;
            this.txtServiceCharges.Location = new System.Drawing.Point(142, 141);
            this.txtServiceCharges.Name = "txtServiceCharges";
            this.txtServiceCharges.ReadOnly = true;
            this.txtServiceCharges.Size = new System.Drawing.Size(141, 20);
            this.txtServiceCharges.TabIndex = 22;
            this.txtServiceCharges.Text = "0.00";
            this.txtServiceCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtServiceCharges.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtCommitmentFees
            // 
            this.txtCommitmentFees.DecimalPlaces = 0;
            this.txtCommitmentFees.IsSendTabOnEnter = true;
            this.txtCommitmentFees.IsThousandSeperator = true;
            this.txtCommitmentFees.Location = new System.Drawing.Point(142, 115);
            this.txtCommitmentFees.Name = "txtCommitmentFees";
            this.txtCommitmentFees.ReadOnly = true;
            this.txtCommitmentFees.Size = new System.Drawing.Size(141, 20);
            this.txtCommitmentFees.TabIndex = 22;
            this.txtCommitmentFees.Text = "0.00";
            this.txtCommitmentFees.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCommitmentFees.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtInterest
            // 
            this.txtInterest.DecimalPlaces = 0;
            this.txtInterest.IsSendTabOnEnter = true;
            this.txtInterest.IsThousandSeperator = true;
            this.txtInterest.Location = new System.Drawing.Point(142, 89);
            this.txtInterest.Name = "txtInterest";
            this.txtInterest.ReadOnly = true;
            this.txtInterest.Size = new System.Drawing.Size(141, 20);
            this.txtInterest.TabIndex = 22;
            this.txtInterest.Text = "0.00";
            this.txtInterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInterest.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtAmount
            // 
            this.txtAmount.DecimalPlaces = 0;
            this.txtAmount.IsSendTabOnEnter = true;
            this.txtAmount.IsThousandSeperator = true;
            this.txtAmount.Location = new System.Drawing.Point(142, 63);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(141, 20);
            this.txtAmount.TabIndex = 22;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.Enabled = false;
            this.txtAccountNo.IsSendTabOnEnter = true;
            this.txtAccountNo.Location = new System.Drawing.Point(142, 11);
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.ReadOnly = true;
            this.txtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.txtAccountNo.TabIndex = 17;
            this.txtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtType
            // 
            this.txtType.Enabled = false;
            this.txtType.IsSendTabOnEnter = true;
            this.txtType.Location = new System.Drawing.Point(142, 37);
            this.txtType.Name = "txtType";
            this.txtType.ReadOnly = true;
            this.txtType.Size = new System.Drawing.Size(141, 20);
            this.txtType.TabIndex = 18;
            // 
            // lblServiceCharges
            // 
            this.lblServiceCharges.AutoSize = true;
            this.lblServiceCharges.Location = new System.Drawing.Point(17, 144);
            this.lblServiceCharges.Name = "lblServiceCharges";
            this.lblServiceCharges.Size = new System.Drawing.Size(91, 13);
            this.lblServiceCharges.TabIndex = 16;
            this.lblServiceCharges.Text = "Service Charges :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPenlityFees);
            this.groupBox1.Controls.Add(this.txtTotal);
            this.groupBox1.Controls.Add(this.txtOutstandingChg);
            this.groupBox1.Controls.Add(this.txtOutstandingInt);
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.lblPenlityFees);
            this.groupBox1.Controls.Add(this.lblOutstandingChg);
            this.groupBox1.Controls.Add(this.lblOutstandingInt);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.MenuText;
            this.groupBox1.Location = new System.Drawing.Point(18, 174);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 136);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Legal Informations";
            // 
            // txtPenlityFees
            // 
            this.txtPenlityFees.DecimalPlaces = 0;
            this.txtPenlityFees.IsSendTabOnEnter = true;
            this.txtPenlityFees.IsThousandSeperator = true;
            this.txtPenlityFees.Location = new System.Drawing.Point(124, 77);
            this.txtPenlityFees.Name = "txtPenlityFees";
            this.txtPenlityFees.ReadOnly = true;
            this.txtPenlityFees.Size = new System.Drawing.Size(141, 20);
            this.txtPenlityFees.TabIndex = 22;
            this.txtPenlityFees.Text = "0.00";
            this.txtPenlityFees.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPenlityFees.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtTotal
            // 
            this.txtTotal.DecimalPlaces = 0;
            this.txtTotal.IsSendTabOnEnter = true;
            this.txtTotal.IsThousandSeperator = true;
            this.txtTotal.Location = new System.Drawing.Point(124, 103);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(141, 20);
            this.txtTotal.TabIndex = 22;
            this.txtTotal.Text = "0.00";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotal.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtOutstandingChg
            // 
            this.txtOutstandingChg.DecimalPlaces = 0;
            this.txtOutstandingChg.IsSendTabOnEnter = true;
            this.txtOutstandingChg.IsThousandSeperator = true;
            this.txtOutstandingChg.Location = new System.Drawing.Point(124, 51);
            this.txtOutstandingChg.Name = "txtOutstandingChg";
            this.txtOutstandingChg.ReadOnly = true;
            this.txtOutstandingChg.Size = new System.Drawing.Size(141, 20);
            this.txtOutstandingChg.TabIndex = 22;
            this.txtOutstandingChg.Text = "0.00";
            this.txtOutstandingChg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOutstandingChg.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtOutstandingInt
            // 
            this.txtOutstandingInt.DecimalPlaces = 0;
            this.txtOutstandingInt.IsSendTabOnEnter = true;
            this.txtOutstandingInt.IsThousandSeperator = true;
            this.txtOutstandingInt.Location = new System.Drawing.Point(124, 25);
            this.txtOutstandingInt.Name = "txtOutstandingInt";
            this.txtOutstandingInt.ReadOnly = true;
            this.txtOutstandingInt.Size = new System.Drawing.Size(141, 20);
            this.txtOutstandingInt.TabIndex = 22;
            this.txtOutstandingInt.Text = "0.00";
            this.txtOutstandingInt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOutstandingInt.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTotal.Location = new System.Drawing.Point(16, 105);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(37, 13);
            this.lblTotal.TabIndex = 20;
            this.lblTotal.Text = "Total :";
            // 
            // lblPenlityFees
            // 
            this.lblPenlityFees.AutoSize = true;
            this.lblPenlityFees.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPenlityFees.Location = new System.Drawing.Point(16, 79);
            this.lblPenlityFees.Name = "lblPenlityFees";
            this.lblPenlityFees.Size = new System.Drawing.Size(74, 13);
            this.lblPenlityFees.TabIndex = 19;
            this.lblPenlityFees.Text = "Penalty Fees :";
            // 
            // lblOutstandingChg
            // 
            this.lblOutstandingChg.AutoSize = true;
            this.lblOutstandingChg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOutstandingChg.Location = new System.Drawing.Point(16, 53);
            this.lblOutstandingChg.Name = "lblOutstandingChg";
            this.lblOutstandingChg.Size = new System.Drawing.Size(112, 13);
            this.lblOutstandingChg.TabIndex = 18;
            this.lblOutstandingChg.Text = "Outstanding Charges :";
            // 
            // lblOutstandingInt
            // 
            this.lblOutstandingInt.AutoSize = true;
            this.lblOutstandingInt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOutstandingInt.Location = new System.Drawing.Point(15, 28);
            this.lblOutstandingInt.Name = "lblOutstandingInt";
            this.lblOutstandingInt.Size = new System.Drawing.Size(108, 13);
            this.lblOutstandingInt.TabIndex = 17;
            this.lblOutstandingInt.Text = "Outstanding Interest :";
            // 
            // lblCommitmentFees
            // 
            this.lblCommitmentFees.AutoSize = true;
            this.lblCommitmentFees.Location = new System.Drawing.Point(18, 118);
            this.lblCommitmentFees.Name = "lblCommitmentFees";
            this.lblCommitmentFees.Size = new System.Drawing.Size(96, 13);
            this.lblCommitmentFees.TabIndex = 16;
            this.lblCommitmentFees.Text = "Commitment Fees :";
            // 
            // lblInterest
            // 
            this.lblInterest.AutoSize = true;
            this.lblInterest.Location = new System.Drawing.Point(17, 93);
            this.lblInterest.Name = "lblInterest";
            this.lblInterest.Size = new System.Drawing.Size(48, 13);
            this.lblInterest.TabIndex = 15;
            this.lblInterest.Text = "Interest :";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(18, 67);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(49, 13);
            this.lblAmount.TabIndex = 14;
            this.lblAmount.Text = "Amount :";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(18, 41);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(37, 13);
            this.lblType.TabIndex = 13;
            this.lblType.Text = "Type :";
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(18, 15);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(70, 13);
            this.lblAccountNo.TabIndex = 12;
            this.lblAccountNo.Text = "Account No.:";
            // 
            // dgvLoanACClose
            // 
            this.dgvLoanACClose.AllowUserToAddRows = false;
            this.dgvLoanACClose.AllowUserToDeleteRows = false;
            this.dgvLoanACClose.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoanACClose.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustName});
            this.dgvLoanACClose.Enabled = false;
            this.dgvLoanACClose.Location = new System.Drawing.Point(330, 107);
            this.dgvLoanACClose.Name = "dgvLoanACClose";
            this.dgvLoanACClose.ReadOnly = true;
            this.dgvLoanACClose.Size = new System.Drawing.Size(235, 319);
            this.dgvLoanACClose.TabIndex = 13;
            // 
            // CustName
            // 
            this.CustName.DataPropertyName = "Name";
            this.CustName.HeaderText = "Name[s]";
            this.CustName.Name = "CustName";
            this.CustName.ReadOnly = true;
            this.CustName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CustName.Width = 190;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(575, 31);
            this.tsbCRUD.TabIndex = 2;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // LOMVEW00013
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 440);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.dgvLoanACClose);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LOMVEW00013";
            this.Text = "Loan Account Close";
            this.Load += new System.EventHandler(this.LOMVEW00013_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LOMVEW00013_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoanACClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Windows.CXClient.Controls.CXC0003 lblDate;
        private Windows.CXClient.Controls.CXC0003 lblLoanNo;
        private Windows.CXClient.Controls.CXC0003 lblDateDisplay;
        private System.Windows.Forms.Panel panel2;
        private Windows.CXClient.Controls.CXC0003 lblCommitmentFees;
        private Windows.CXClient.Controls.CXC0003 lblInterest;
        private Windows.CXClient.Controls.CXC0003 lblAmount;
        private Windows.CXClient.Controls.CXC0003 lblType;
        private Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private Windows.CXClient.Controls.CXC0003 lblOutstandingChg;
        private Windows.CXClient.Controls.CXC0003 lblOutstandingInt;
        private Windows.CXClient.Controls.CXC0003 lblTotal;
        private Windows.CXClient.Controls.CXC0003 lblPenlityFees;
        private System.Windows.Forms.DataGridView dgvLoanACClose;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0006 txtType;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustName;
        private Windows.CXClient.Controls.CXC0006 txtAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblServiceCharges;
        private Windows.CXClient.Controls.CXC0004 txtServiceCharges;
        private Windows.CXClient.Controls.CXC0004 txtCommitmentFees;
        private Windows.CXClient.Controls.CXC0004 txtInterest;
        private Windows.CXClient.Controls.CXC0004 txtAmount;
        private Windows.CXClient.Controls.CXC0004 txtPenlityFees;
        private Windows.CXClient.Controls.CXC0004 txtTotal;
        private Windows.CXClient.Controls.CXC0004 txtOutstandingChg;
        private Windows.CXClient.Controls.CXC0004 txtOutstandingInt;
        private Windows.CXClient.Controls.CXC0001 txtLoanNo;

    }
}