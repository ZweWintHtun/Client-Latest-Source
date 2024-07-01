namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00446
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00446));
            this.mtxtAcctNo = new System.Windows.Forms.MaskedTextBox();
            this.lblAccountNo = new System.Windows.Forms.Label();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTotalSanctionAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.cxC000314 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtIncreaseSanctionAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.cxC000313 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.dtpNewExpiredDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.cxC000311 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtServiceCharges = new Ace.Windows.CXClient.Controls.CXC0004();
            this.chkEditServiceCharges = new System.Windows.Forms.CheckBox();
            this.cxC000310 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.chkEditDuration = new System.Windows.Forms.CheckBox();
            this.txtExtendDuration = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtNewInterestRate = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtOutstandingLoanAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtFirstSanctionAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtDocFee = new Ace.Windows.CXClient.Controls.CXC0004();
            this.chkEditDocFee = new System.Windows.Forms.CheckBox();
            this.cxC00039 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.chkEditRate = new System.Windows.Forms.CheckBox();
            this.cxC00038 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00037 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtOldInterestRate = new Ace.Windows.CXClient.Controls.CXC0001();
            this.cxC00036 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.dtpLastExpiredDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.cxC00034 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.dtpRegisterDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.cxC00035 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtLNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.cxC00033 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gpCustomerName = new System.Windows.Forms.GroupBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblTransactionDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC000312 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.groupBox1.SuspendLayout();
            this.gpCustomerName.SuspendLayout();
            this.SuspendLayout();
            // 
            // mtxtAcctNo
            // 
            this.mtxtAcctNo.Location = new System.Drawing.Point(159, 25);
            this.mtxtAcctNo.Name = "mtxtAcctNo";
            this.mtxtAcctNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAcctNo.TabIndex = 0;
            this.mtxtAcctNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtxtAcctNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtxtAcctNo_KeyDown);
            this.mtxtAcctNo.Leave += new System.EventHandler(this.mtxtAcctNo_Leave);
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAccountNo.Location = new System.Drawing.Point(83, 28);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(70, 13);
            this.lblAccountNo.TabIndex = 3;
            this.lblAccountNo.Text = "Account No :";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(774, 31);
            this.tsbCRUD.TabIndex = 6;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTotalSanctionAmount);
            this.groupBox1.Controls.Add(this.cxC000314);
            this.groupBox1.Controls.Add(this.txtIncreaseSanctionAmount);
            this.groupBox1.Controls.Add(this.cxC000313);
            this.groupBox1.Controls.Add(this.dtpNewExpiredDate);
            this.groupBox1.Controls.Add(this.cxC000311);
            this.groupBox1.Controls.Add(this.txtServiceCharges);
            this.groupBox1.Controls.Add(this.chkEditServiceCharges);
            this.groupBox1.Controls.Add(this.cxC000310);
            this.groupBox1.Controls.Add(this.chkEditDuration);
            this.groupBox1.Controls.Add(this.txtExtendDuration);
            this.groupBox1.Controls.Add(this.txtNewInterestRate);
            this.groupBox1.Controls.Add(this.txtOutstandingLoanAmount);
            this.groupBox1.Controls.Add(this.txtFirstSanctionAmount);
            this.groupBox1.Controls.Add(this.txtDocFee);
            this.groupBox1.Controls.Add(this.chkEditDocFee);
            this.groupBox1.Controls.Add(this.cxC00039);
            this.groupBox1.Controls.Add(this.chkEditRate);
            this.groupBox1.Controls.Add(this.cxC00038);
            this.groupBox1.Controls.Add(this.cxC00037);
            this.groupBox1.Controls.Add(this.txtOldInterestRate);
            this.groupBox1.Controls.Add(this.cxC00036);
            this.groupBox1.Controls.Add(this.dtpLastExpiredDate);
            this.groupBox1.Controls.Add(this.cxC00034);
            this.groupBox1.Controls.Add(this.cxC00032);
            this.groupBox1.Controls.Add(this.cxC00031);
            this.groupBox1.Controls.Add(this.dtpRegisterDate);
            this.groupBox1.Controls.Add(this.cxC00035);
            this.groupBox1.Controls.Add(this.txtLNo);
            this.groupBox1.Controls.Add(this.cxC00033);
            this.groupBox1.Controls.Add(this.gpCustomerName);
            this.groupBox1.Controls.Add(this.mtxtAcctNo);
            this.groupBox1.Controls.Add(this.lblAccountNo);
            this.groupBox1.Location = new System.Drawing.Point(12, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(748, 370);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // txtTotalSanctionAmount
            // 
            this.txtTotalSanctionAmount.DecimalPlaces = 2;
            this.txtTotalSanctionAmount.IsSendTabOnEnter = true;
            this.txtTotalSanctionAmount.IsThousandSeperator = true;
            this.txtTotalSanctionAmount.IsUseFloatingPoint = true;
            this.txtTotalSanctionAmount.Location = new System.Drawing.Point(159, 250);
            this.txtTotalSanctionAmount.MaxLength = 18;
            this.txtTotalSanctionAmount.Name = "txtTotalSanctionAmount";
            this.txtTotalSanctionAmount.ReadOnly = true;
            this.txtTotalSanctionAmount.Size = new System.Drawing.Size(141, 20);
            this.txtTotalSanctionAmount.TabIndex = 106;
            this.txtTotalSanctionAmount.Text = "0.00";
            this.txtTotalSanctionAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalSanctionAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // cxC000314
            // 
            this.cxC000314.AutoSize = true;
            this.cxC000314.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cxC000314.Location = new System.Drawing.Point(32, 253);
            this.cxC000314.Name = "cxC000314";
            this.cxC000314.Size = new System.Drawing.Size(121, 13);
            this.cxC000314.TabIndex = 132;
            this.cxC000314.Text = "Total Sanction Amount :";
            // 
            // txtIncreaseSanctionAmount
            // 
            this.txtIncreaseSanctionAmount.DecimalPlaces = 2;
            this.txtIncreaseSanctionAmount.IsSendTabOnEnter = true;
            this.txtIncreaseSanctionAmount.IsThousandSeperator = true;
            this.txtIncreaseSanctionAmount.IsUseFloatingPoint = true;
            this.txtIncreaseSanctionAmount.Location = new System.Drawing.Point(159, 221);
            this.txtIncreaseSanctionAmount.MaxLength = 18;
            this.txtIncreaseSanctionAmount.Name = "txtIncreaseSanctionAmount";
            this.txtIncreaseSanctionAmount.ReadOnly = true;
            this.txtIncreaseSanctionAmount.Size = new System.Drawing.Size(141, 20);
            this.txtIncreaseSanctionAmount.TabIndex = 105;
            this.txtIncreaseSanctionAmount.Text = "0.00";
            this.txtIncreaseSanctionAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIncreaseSanctionAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // cxC000313
            // 
            this.cxC000313.AutoSize = true;
            this.cxC000313.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cxC000313.Location = new System.Drawing.Point(15, 224);
            this.cxC000313.Name = "cxC000313";
            this.cxC000313.Size = new System.Drawing.Size(138, 13);
            this.cxC000313.TabIndex = 130;
            this.cxC000313.Text = "Increase Sanction Amount :";
            // 
            // dtpNewExpiredDate
            // 
            this.dtpNewExpiredDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpNewExpiredDate.Enabled = false;
            this.dtpNewExpiredDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNewExpiredDate.IsSendTabOnEnter = true;
            this.dtpNewExpiredDate.Location = new System.Drawing.Point(159, 158);
            this.dtpNewExpiredDate.Name = "dtpNewExpiredDate";
            this.dtpNewExpiredDate.Size = new System.Drawing.Size(121, 20);
            this.dtpNewExpiredDate.TabIndex = 103;
            // 
            // cxC000311
            // 
            this.cxC000311.AutoSize = true;
            this.cxC000311.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cxC000311.Location = new System.Drawing.Point(52, 158);
            this.cxC000311.Name = "cxC000311";
            this.cxC000311.Size = new System.Drawing.Size(99, 13);
            this.cxC000311.TabIndex = 129;
            this.cxC000311.Text = "Next Expired Date :";
            // 
            // txtServiceCharges
            // 
            this.txtServiceCharges.DecimalPlaces = 2;
            this.txtServiceCharges.IsSendTabOnEnter = true;
            this.txtServiceCharges.IsThousandSeperator = true;
            this.txtServiceCharges.IsUseFloatingPoint = true;
            this.txtServiceCharges.Location = new System.Drawing.Point(456, 159);
            this.txtServiceCharges.MaxLength = 18;
            this.txtServiceCharges.Name = "txtServiceCharges";
            this.txtServiceCharges.ReadOnly = true;
            this.txtServiceCharges.Size = new System.Drawing.Size(141, 20);
            this.txtServiceCharges.TabIndex = 109;
            this.txtServiceCharges.Text = "0.00";
            this.txtServiceCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtServiceCharges.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // chkEditServiceCharges
            // 
            this.chkEditServiceCharges.AutoSize = true;
            this.chkEditServiceCharges.Location = new System.Drawing.Point(603, 162);
            this.chkEditServiceCharges.Name = "chkEditServiceCharges";
            this.chkEditServiceCharges.Size = new System.Drawing.Size(125, 17);
            this.chkEditServiceCharges.TabIndex = 4;
            this.chkEditServiceCharges.Text = "Edit Service Charges";
            this.chkEditServiceCharges.UseVisualStyleBackColor = true;
            this.chkEditServiceCharges.CheckedChanged += new System.EventHandler(this.chkEditServiceCharges_CheckedChanged);
            // 
            // cxC000310
            // 
            this.cxC000310.AutoSize = true;
            this.cxC000310.Location = new System.Drawing.Point(356, 162);
            this.cxC000310.Name = "cxC000310";
            this.cxC000310.Size = new System.Drawing.Size(94, 13);
            this.cxC000310.TabIndex = 126;
            this.cxC000310.Text = "Service Charges : ";
            // 
            // chkEditDuration
            // 
            this.chkEditDuration.AutoSize = true;
            this.chkEditDuration.Location = new System.Drawing.Point(562, 96);
            this.chkEditDuration.Name = "chkEditDuration";
            this.chkEditDuration.Size = new System.Drawing.Size(87, 17);
            this.chkEditDuration.TabIndex = 2;
            this.chkEditDuration.Text = "Edit Duration";
            this.chkEditDuration.UseVisualStyleBackColor = true;
            this.chkEditDuration.CheckedChanged += new System.EventHandler(this.chkEditDuration_CheckedChanged);
            // 
            // txtExtendDuration
            // 
            this.txtExtendDuration.CausesValidation = false;
            this.txtExtendDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtExtendDuration.IsSendTabOnEnter = true;
            this.txtExtendDuration.Location = new System.Drawing.Point(456, 94);
            this.txtExtendDuration.Name = "txtExtendDuration";
            this.txtExtendDuration.ReadOnly = true;
            this.txtExtendDuration.Size = new System.Drawing.Size(100, 20);
            this.txtExtendDuration.TabIndex = 107;
            this.txtExtendDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtExtendDuration.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtExtendDuration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtExtendDuration_KeyPress);
            this.txtExtendDuration.Leave += new System.EventHandler(this.txtExtendDuration_Leave);
            // 
            // txtNewInterestRate
            // 
            this.txtNewInterestRate.DecimalPlaces = 2;
            this.txtNewInterestRate.IsSendTabOnEnter = true;
            this.txtNewInterestRate.IsThousandSeperator = true;
            this.txtNewInterestRate.IsUseFloatingPoint = true;
            this.txtNewInterestRate.Location = new System.Drawing.Point(456, 221);
            this.txtNewInterestRate.MaxLength = 18;
            this.txtNewInterestRate.Name = "txtNewInterestRate";
            this.txtNewInterestRate.ReadOnly = true;
            this.txtNewInterestRate.Size = new System.Drawing.Size(100, 20);
            this.txtNewInterestRate.TabIndex = 111;
            this.txtNewInterestRate.Text = "0.00";
            this.txtNewInterestRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNewInterestRate.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtOutstandingLoanAmount
            // 
            this.txtOutstandingLoanAmount.DecimalPlaces = 2;
            this.txtOutstandingLoanAmount.IsSendTabOnEnter = true;
            this.txtOutstandingLoanAmount.IsThousandSeperator = true;
            this.txtOutstandingLoanAmount.IsUseFloatingPoint = true;
            this.txtOutstandingLoanAmount.Location = new System.Drawing.Point(159, 281);
            this.txtOutstandingLoanAmount.MaxLength = 18;
            this.txtOutstandingLoanAmount.Name = "txtOutstandingLoanAmount";
            this.txtOutstandingLoanAmount.ReadOnly = true;
            this.txtOutstandingLoanAmount.Size = new System.Drawing.Size(141, 20);
            this.txtOutstandingLoanAmount.TabIndex = 105;
            this.txtOutstandingLoanAmount.Text = "0.00";
            this.txtOutstandingLoanAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOutstandingLoanAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtFirstSanctionAmount
            // 
            this.txtFirstSanctionAmount.DecimalPlaces = 2;
            this.txtFirstSanctionAmount.IsSendTabOnEnter = true;
            this.txtFirstSanctionAmount.IsThousandSeperator = true;
            this.txtFirstSanctionAmount.IsUseFloatingPoint = true;
            this.txtFirstSanctionAmount.Location = new System.Drawing.Point(159, 191);
            this.txtFirstSanctionAmount.MaxLength = 18;
            this.txtFirstSanctionAmount.Name = "txtFirstSanctionAmount";
            this.txtFirstSanctionAmount.ReadOnly = true;
            this.txtFirstSanctionAmount.Size = new System.Drawing.Size(141, 20);
            this.txtFirstSanctionAmount.TabIndex = 104;
            this.txtFirstSanctionAmount.Text = "0.00";
            this.txtFirstSanctionAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFirstSanctionAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtDocFee
            // 
            this.txtDocFee.DecimalPlaces = 2;
            this.txtDocFee.IsSendTabOnEnter = true;
            this.txtDocFee.IsThousandSeperator = true;
            this.txtDocFee.IsUseFloatingPoint = true;
            this.txtDocFee.Location = new System.Drawing.Point(456, 127);
            this.txtDocFee.MaxLength = 18;
            this.txtDocFee.Name = "txtDocFee";
            this.txtDocFee.ReadOnly = true;
            this.txtDocFee.Size = new System.Drawing.Size(141, 20);
            this.txtDocFee.TabIndex = 108;
            this.txtDocFee.Text = "0.00";
            this.txtDocFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDocFee.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // chkEditDocFee
            // 
            this.chkEditDocFee.AutoSize = true;
            this.chkEditDocFee.Location = new System.Drawing.Point(603, 129);
            this.chkEditDocFee.Name = "chkEditDocFee";
            this.chkEditDocFee.Size = new System.Drawing.Size(122, 17);
            this.chkEditDocFee.TabIndex = 3;
            this.chkEditDocFee.Text = "Edit Document Fees";
            this.chkEditDocFee.UseVisualStyleBackColor = true;
            this.chkEditDocFee.CheckedChanged += new System.EventHandler(this.chkEditDocFee_CheckedChanged);
            // 
            // cxC00039
            // 
            this.cxC00039.AutoSize = true;
            this.cxC00039.Location = new System.Drawing.Point(364, 130);
            this.cxC00039.Name = "cxC00039";
            this.cxC00039.Size = new System.Drawing.Size(86, 13);
            this.cxC00039.TabIndex = 118;
            this.cxC00039.Text = "Document Fee : ";
            // 
            // chkEditRate
            // 
            this.chkEditRate.AutoSize = true;
            this.chkEditRate.Location = new System.Drawing.Point(562, 223);
            this.chkEditRate.Name = "chkEditRate";
            this.chkEditRate.Size = new System.Drawing.Size(70, 17);
            this.chkEditRate.TabIndex = 5;
            this.chkEditRate.Text = "Edit Rate";
            this.chkEditRate.UseVisualStyleBackColor = true;
            this.chkEditRate.CheckedChanged += new System.EventHandler(this.chkEditRate_CheckedChanged);
            // 
            // cxC00038
            // 
            this.cxC00038.AutoSize = true;
            this.cxC00038.Location = new System.Drawing.Point(348, 224);
            this.cxC00038.Name = "cxC00038";
            this.cxC00038.Size = new System.Drawing.Size(102, 13);
            this.cxC00038.TabIndex = 115;
            this.cxC00038.Text = "New Interest Rate : ";
            // 
            // cxC00037
            // 
            this.cxC00037.AutoSize = true;
            this.cxC00037.Location = new System.Drawing.Point(358, 97);
            this.cxC00037.Name = "cxC00037";
            this.cxC00037.Size = new System.Drawing.Size(92, 13);
            this.cxC00037.TabIndex = 113;
            this.cxC00037.Text = "Extend Duration : ";
            // 
            // txtOldInterestRate
            // 
            this.txtOldInterestRate.IsSendTabOnEnter = true;
            this.txtOldInterestRate.Location = new System.Drawing.Point(456, 190);
            this.txtOldInterestRate.MaxLength = 15;
            this.txtOldInterestRate.Name = "txtOldInterestRate";
            this.txtOldInterestRate.ReadOnly = true;
            this.txtOldInterestRate.Size = new System.Drawing.Size(100, 20);
            this.txtOldInterestRate.TabIndex = 110;
            this.txtOldInterestRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cxC00036
            // 
            this.cxC00036.AutoSize = true;
            this.cxC00036.Location = new System.Drawing.Point(354, 193);
            this.cxC00036.Name = "cxC00036";
            this.cxC00036.Size = new System.Drawing.Size(96, 13);
            this.cxC00036.TabIndex = 111;
            this.cxC00036.Text = "Old Interest Rate : ";
            // 
            // dtpLastExpiredDate
            // 
            this.dtpLastExpiredDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpLastExpiredDate.Enabled = false;
            this.dtpLastExpiredDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLastExpiredDate.IsSendTabOnEnter = true;
            this.dtpLastExpiredDate.Location = new System.Drawing.Point(159, 126);
            this.dtpLastExpiredDate.Name = "dtpLastExpiredDate";
            this.dtpLastExpiredDate.Size = new System.Drawing.Size(121, 20);
            this.dtpLastExpiredDate.TabIndex = 102;
            // 
            // cxC00034
            // 
            this.cxC00034.AutoSize = true;
            this.cxC00034.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cxC00034.Location = new System.Drawing.Point(54, 126);
            this.cxC00034.Name = "cxC00034";
            this.cxC00034.Size = new System.Drawing.Size(97, 13);
            this.cxC00034.TabIndex = 107;
            this.cxC00034.Text = "Last Expired Date :";
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cxC00032.Location = new System.Drawing.Point(17, 284);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(136, 13);
            this.cxC00032.TabIndex = 109;
            this.cxC00032.Text = "Outstanding Loan Amount :";
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cxC00031.Location = new System.Drawing.Point(34, 193);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(119, 13);
            this.cxC00031.TabIndex = 107;
            this.cxC00031.Text = "First Sanction Amount : ";
            // 
            // dtpRegisterDate
            // 
            this.dtpRegisterDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpRegisterDate.Enabled = false;
            this.dtpRegisterDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRegisterDate.IsSendTabOnEnter = true;
            this.dtpRegisterDate.Location = new System.Drawing.Point(159, 93);
            this.dtpRegisterDate.Name = "dtpRegisterDate";
            this.dtpRegisterDate.Size = new System.Drawing.Size(121, 20);
            this.dtpRegisterDate.TabIndex = 101;
            // 
            // cxC00035
            // 
            this.cxC00035.AutoSize = true;
            this.cxC00035.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cxC00035.Location = new System.Drawing.Point(73, 93);
            this.cxC00035.Name = "cxC00035";
            this.cxC00035.Size = new System.Drawing.Size(78, 13);
            this.cxC00035.TabIndex = 105;
            this.cxC00035.Text = "Register Date :";
            // 
            // txtLNo
            // 
            this.txtLNo.IsSendTabOnEnter = true;
            this.txtLNo.Location = new System.Drawing.Point(159, 61);
            this.txtLNo.MaxLength = 15;
            this.txtLNo.Name = "txtLNo";
            this.txtLNo.ReadOnly = true;
            this.txtLNo.Size = new System.Drawing.Size(141, 20);
            this.txtLNo.TabIndex = 100;
            // 
            // cxC00033
            // 
            this.cxC00033.AutoSize = true;
            this.cxC00033.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cxC00033.Location = new System.Drawing.Point(97, 64);
            this.cxC00033.Name = "cxC00033";
            this.cxC00033.Size = new System.Drawing.Size(54, 13);
            this.cxC00033.TabIndex = 103;
            this.cxC00033.Text = "Loan No :";
            // 
            // gpCustomerName
            // 
            this.gpCustomerName.Controls.Add(this.lblCustomerName);
            this.gpCustomerName.Location = new System.Drawing.Point(344, 17);
            this.gpCustomerName.Name = "gpCustomerName";
            this.gpCustomerName.Size = new System.Drawing.Size(384, 64);
            this.gpCustomerName.TabIndex = 106;
            this.gpCustomerName.TabStop = false;
            this.gpCustomerName.Text = "Name(s)";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(14, 22);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(0, 13);
            this.lblCustomerName.TabIndex = 0;
            // 
            // lblTransactionDate
            // 
            this.lblTransactionDate.AutoSize = true;
            this.lblTransactionDate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblTransactionDate.Location = new System.Drawing.Point(696, 42);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Size = new System.Drawing.Size(0, 13);
            this.lblTransactionDate.TabIndex = 131;
            // 
            // cxC000312
            // 
            this.cxC000312.AutoSize = true;
            this.cxC000312.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.cxC000312.Location = new System.Drawing.Point(595, 42);
            this.cxC000312.Name = "cxC000312";
            this.cxC000312.Size = new System.Drawing.Size(95, 13);
            this.cxC000312.TabIndex = 130;
            this.cxC000312.Text = "Transaction Date :";
            // 
            // LOMVEW00446
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 440);
            this.Controls.Add(this.lblTransactionDate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cxC000312);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00446";
            this.Text = "Business Loan Limit Extend Entry (Manual)";
            this.Load += new System.EventHandler(this.LOMVEW00446_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpCustomerName.ResumeLayout(false);
            this.gpCustomerName.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mtxtAcctNo;
        private System.Windows.Forms.Label lblAccountNo;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gpCustomerName;
        private Windows.CXClient.Controls.CXC0001 txtLNo;
        private Windows.CXClient.Controls.CXC0003 cxC00033;
        private Windows.CXClient.Controls.CXC0005 dtpRegisterDate;
        private Windows.CXClient.Controls.CXC0003 cxC00035;
        private Windows.CXClient.Controls.CXC0005 dtpLastExpiredDate;
        private Windows.CXClient.Controls.CXC0003 cxC00034;
        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0003 cxC00038;
        private Windows.CXClient.Controls.CXC0003 cxC00037;
        private Windows.CXClient.Controls.CXC0001 txtOldInterestRate;
        private Windows.CXClient.Controls.CXC0003 cxC00036;
        private System.Windows.Forms.CheckBox chkEditRate;
        private System.Windows.Forms.CheckBox chkEditDocFee;
        private Windows.CXClient.Controls.CXC0003 cxC00039;
        private Windows.CXClient.Controls.CXC0004 txtDocFee;
        private Windows.CXClient.Controls.CXC0004 txtOutstandingLoanAmount;
        private Windows.CXClient.Controls.CXC0004 txtFirstSanctionAmount;
        private Windows.CXClient.Controls.CXC0004 txtNewInterestRate;
        private Windows.CXClient.Controls.CXC0006 txtExtendDuration;
        private System.Windows.Forms.CheckBox chkEditDuration;
        private Windows.CXClient.Controls.CXC0004 txtServiceCharges;
        private System.Windows.Forms.CheckBox chkEditServiceCharges;
        private Windows.CXClient.Controls.CXC0003 cxC000310;
        private Windows.CXClient.Controls.CXC0005 dtpNewExpiredDate;
        private Windows.CXClient.Controls.CXC0003 cxC000311;
        private System.Windows.Forms.Label lblCustomerName;
        private Windows.CXClient.Controls.CXC0003 lblTransactionDate;
        private Windows.CXClient.Controls.CXC0003 cxC000312;
        private Windows.CXClient.Controls.CXC0004 txtTotalSanctionAmount;
        private Windows.CXClient.Controls.CXC0003 cxC000314;
        private Windows.CXClient.Controls.CXC0004 txtIncreaseSanctionAmount;
        private Windows.CXClient.Controls.CXC0003 cxC000313;
    }
}