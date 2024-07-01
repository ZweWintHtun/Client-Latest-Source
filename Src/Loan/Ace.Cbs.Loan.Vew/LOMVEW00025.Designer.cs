namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00025
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00025));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblTotalOutstanding = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblRepaymentAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtAccountNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtTypeOfSecurity = new Ace.Windows.CXClient.Controls.CXC0001();
            this.gvAccountList = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvColAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvColDebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvColCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvColDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblInterestOnSamt = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gbRepayment = new System.Windows.Forms.GroupBox();
            this.butEnquiry = new Ace.Windows.CXClient.Controls.CXC0007();
            this.txtActualCusGetAmt = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblActualCusGetAmt = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtRepaymentAmountEncode = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtRepaymentAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.gbJoinType = new System.Windows.Forms.GroupBox();
            this.rdoDecrease = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoIncrease = new Ace.Windows.CXClient.Controls.CXC0009();
            this.lblBLType = new Ace.Windows.CXClient.Controls.CXC0003();
            this.dtpCurSAmtDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.lblCurrentSanDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtOutstandingInt = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblOutstandingInterest = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtTotalAmt = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblTotalAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtLateFee = new Ace.Windows.CXClient.Controls.CXC0004();
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtLoanNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtInterestOnSamt = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtTotalOutstanding = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtRepaymentNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.chkFullSettlement = new Ace.Windows.CXClient.Controls.CXC0008();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtDateTime = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.chkServiceCharges = new Ace.Windows.CXClient.Controls.CXC0008();
            this.chkEditDocAmt = new System.Windows.Forms.CheckBox();
            this.txtDocumentFee = new Ace.Windows.CXClient.Controls.CXC0004();
            this.label2 = new System.Windows.Forms.Label();
            this.gpLimitIncrease = new System.Windows.Forms.GroupBox();
            this.txtRate = new Ace.Windows.CXClient.Controls.CXC0004();
            this.label1 = new System.Windows.Forms.Label();
            this.chkEdit = new System.Windows.Forms.CheckBox();
            this.cxC00033 = new Ace.Windows.CXClient.Controls.CXC0003();
            ((System.ComponentModel.ISupportInitialize)(this.gvAccountList)).BeginInit();
            this.gbRepayment.SuspendLayout();
            this.gbJoinType.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gpLimitIncrease.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(1, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(627, 31);
            this.tsbCRUD.TabIndex = 11;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(15, 53);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(76, 13);
            this.lblAccountNo.TabIndex = 0;
            this.lblAccountNo.Text = "Account No.  :";
            // 
            // lblTotalOutstanding
            // 
            this.lblTotalOutstanding.AutoSize = true;
            this.lblTotalOutstanding.Location = new System.Drawing.Point(15, 104);
            this.lblTotalOutstanding.Name = "lblTotalOutstanding";
            this.lblTotalOutstanding.Size = new System.Drawing.Size(100, 13);
            this.lblTotalOutstanding.TabIndex = 0;
            this.lblTotalOutstanding.Text = "Total Outstanding  :";
            // 
            // lblRepaymentAmount
            // 
            this.lblRepaymentAmount.AutoSize = true;
            this.lblRepaymentAmount.Location = new System.Drawing.Point(15, 200);
            this.lblRepaymentAmount.Name = "lblRepaymentAmount";
            this.lblRepaymentAmount.Size = new System.Drawing.Size(116, 13);
            this.lblRepaymentAmount.TabIndex = 0;
            this.lblRepaymentAmount.Text = "Limit Change Amount  :";
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.Enabled = false;
            this.txtAccountNo.IsSendTabOnEnter = true;
            this.txtAccountNo.Location = new System.Drawing.Point(140, 49);
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.ReadOnly = true;
            this.txtAccountNo.Size = new System.Drawing.Size(121, 20);
            this.txtAccountNo.TabIndex = 0;
            // 
            // txtTypeOfSecurity
            // 
            this.txtTypeOfSecurity.Enabled = false;
            this.txtTypeOfSecurity.IsSendTabOnEnter = true;
            this.txtTypeOfSecurity.Location = new System.Drawing.Point(140, 74);
            this.txtTypeOfSecurity.Name = "txtTypeOfSecurity";
            this.txtTypeOfSecurity.ReadOnly = true;
            this.txtTypeOfSecurity.Size = new System.Drawing.Size(121, 20);
            this.txtTypeOfSecurity.TabIndex = 0;
            // 
            // gvAccountList
            // 
            this.gvAccountList.AllowUserToAddRows = false;
            this.gvAccountList.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvAccountList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvAccountList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAccountList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTS,
            this.gvColAccountNo,
            this.gvColDebit,
            this.gvColCredit,
            this.gvColDescription});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvAccountList.DefaultCellStyle = dataGridViewCellStyle4;
            this.gvAccountList.Enabled = false;
            this.gvAccountList.EnableHeadersVisualStyles = false;
            this.gvAccountList.IdTSList = null;
            this.gvAccountList.IsEscapeKey = false;
            this.gvAccountList.IsHeaderClick = false;
            this.gvAccountList.Location = new System.Drawing.Point(10, 425);
            this.gvAccountList.Name = "gvAccountList";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvAccountList.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gvAccountList.RowHeadersWidth = 25;
            this.gvAccountList.ShowSerialNo = false;
            this.gvAccountList.Size = new System.Drawing.Size(605, 181);
            this.gvAccountList.TabIndex = 10;
            // 
            // colTS
            // 
            this.colTS.DataPropertyName = "TS";
            this.colTS.HeaderText = "TS";
            this.colTS.Name = "colTS";
            this.colTS.Visible = false;
            // 
            // gvColAccountNo
            // 
            this.gvColAccountNo.DataPropertyName = "CreditAccountNo1";
            this.gvColAccountNo.HeaderText = "Account No.";
            this.gvColAccountNo.Name = "gvColAccountNo";
            this.gvColAccountNo.ReadOnly = true;
            this.gvColAccountNo.Width = 120;
            // 
            // gvColDebit
            // 
            this.gvColDebit.DataPropertyName = "DebitAmount1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.gvColDebit.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvColDebit.HeaderText = "Debit";
            this.gvColDebit.Name = "gvColDebit";
            this.gvColDebit.ReadOnly = true;
            this.gvColDebit.Width = 115;
            // 
            // gvColCredit
            // 
            this.gvColCredit.DataPropertyName = "CreditAmount1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.gvColCredit.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvColCredit.HeaderText = "Credit";
            this.gvColCredit.Name = "gvColCredit";
            this.gvColCredit.Width = 115;
            // 
            // gvColDescription
            // 
            this.gvColDescription.DataPropertyName = "BankAccountDescription";
            this.gvColDescription.HeaderText = "Description";
            this.gvColDescription.Name = "gvColDescription";
            this.gvColDescription.Width = 225;
            // 
            // lblInterestOnSamt
            // 
            this.lblInterestOnSamt.AutoSize = true;
            this.lblInterestOnSamt.Location = new System.Drawing.Point(15, 253);
            this.lblInterestOnSamt.Name = "lblInterestOnSamt";
            this.lblInterestOnSamt.Size = new System.Drawing.Size(102, 13);
            this.lblInterestOnSamt.TabIndex = 0;
            this.lblInterestOnSamt.Text = "Interest on Sanction";
            // 
            // gbRepayment
            // 
            this.gbRepayment.Controls.Add(this.butEnquiry);
            this.gbRepayment.Controls.Add(this.txtActualCusGetAmt);
            this.gbRepayment.Controls.Add(this.lblActualCusGetAmt);
            this.gbRepayment.Controls.Add(this.txtRepaymentAmountEncode);
            this.gbRepayment.Controls.Add(this.txtRepaymentAmount);
            this.gbRepayment.Controls.Add(this.txtTypeOfSecurity);
            this.gbRepayment.Controls.Add(this.gbJoinType);
            this.gbRepayment.Controls.Add(this.lblBLType);
            this.gbRepayment.Controls.Add(this.dtpCurSAmtDate);
            this.gbRepayment.Controls.Add(this.lblCurrentSanDate);
            this.gbRepayment.Controls.Add(this.txtOutstandingInt);
            this.gbRepayment.Controls.Add(this.lblOutstandingInterest);
            this.gbRepayment.Controls.Add(this.txtTotalAmt);
            this.gbRepayment.Controls.Add(this.lblTotalAmount);
            this.gbRepayment.Controls.Add(this.txtLateFee);
            this.gbRepayment.Controls.Add(this.cxC00032);
            this.gbRepayment.Controls.Add(this.txtLoanNo);
            this.gbRepayment.Controls.Add(this.cxC00031);
            this.gbRepayment.Controls.Add(this.txtInterestOnSamt);
            this.gbRepayment.Controls.Add(this.txtTotalOutstanding);
            this.gbRepayment.Controls.Add(this.lblInterestOnSamt);
            this.gbRepayment.Controls.Add(this.lblAccountNo);
            this.gbRepayment.Controls.Add(this.lblRepaymentAmount);
            this.gbRepayment.Controls.Add(this.txtAccountNo);
            this.gbRepayment.Controls.Add(this.lblTotalOutstanding);
            this.gbRepayment.Controls.Add(this.txtRepaymentNo);
            this.gbRepayment.Location = new System.Drawing.Point(10, 35);
            this.gbRepayment.Name = "gbRepayment";
            this.gbRepayment.Size = new System.Drawing.Size(367, 379);
            this.gbRepayment.TabIndex = 0;
            this.gbRepayment.TabStop = false;
            // 
            // butEnquiry
            // 
            this.butEnquiry.Image = ((System.Drawing.Image)(resources.GetObject("butEnquiry.Image")));
            this.butEnquiry.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butEnquiry.Location = new System.Drawing.Point(278, 44);
            this.butEnquiry.Name = "butEnquiry";
            this.butEnquiry.Size = new System.Drawing.Size(74, 30);
            this.butEnquiry.TabIndex = 106;
            this.butEnquiry.Text = "&Enquiry";
            this.butEnquiry.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butEnquiry.UseVisualStyleBackColor = true;
            this.butEnquiry.Click += new System.EventHandler(this.butEnquiry_Click);
            // 
            // txtActualCusGetAmt
            // 
            this.txtActualCusGetAmt.DecimalPlaces = 0;
            this.txtActualCusGetAmt.Enabled = false;
            this.txtActualCusGetAmt.IsSendTabOnEnter = true;
            this.txtActualCusGetAmt.IsThousandSeperator = true;
            this.txtActualCusGetAmt.Location = new System.Drawing.Point(140, 353);
            this.txtActualCusGetAmt.Name = "txtActualCusGetAmt";
            this.txtActualCusGetAmt.ReadOnly = true;
            this.txtActualCusGetAmt.Size = new System.Drawing.Size(141, 20);
            this.txtActualCusGetAmt.TabIndex = 105;
            this.txtActualCusGetAmt.Text = "0.00";
            this.txtActualCusGetAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtActualCusGetAmt.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtActualCusGetAmt.Visible = false;
            // 
            // lblActualCusGetAmt
            // 
            this.lblActualCusGetAmt.AutoSize = true;
            this.lblActualCusGetAmt.Enabled = false;
            this.lblActualCusGetAmt.Location = new System.Drawing.Point(15, 350);
            this.lblActualCusGetAmt.Name = "lblActualCusGetAmt";
            this.lblActualCusGetAmt.Size = new System.Drawing.Size(87, 26);
            this.lblActualCusGetAmt.TabIndex = 104;
            this.lblActualCusGetAmt.Text = "Actual Customer \r\nGet Amount  :";
            this.lblActualCusGetAmt.Visible = false;
            // 
            // txtRepaymentAmountEncode
            // 
            this.txtRepaymentAmountEncode.DecimalPlaces = 2;
            this.txtRepaymentAmountEncode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRepaymentAmountEncode.IsSendTabOnEnter = true;
            this.txtRepaymentAmountEncode.IsThousandSeperator = true;
            this.txtRepaymentAmountEncode.Location = new System.Drawing.Point(140, 197);
            this.txtRepaymentAmountEncode.Name = "txtRepaymentAmountEncode";
            this.txtRepaymentAmountEncode.PasswordChar = '*';
            this.txtRepaymentAmountEncode.Size = new System.Drawing.Size(141, 20);
            this.txtRepaymentAmountEncode.TabIndex = 102;
            this.txtRepaymentAmountEncode.Text = "0.00";
            this.txtRepaymentAmountEncode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRepaymentAmountEncode.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtRepaymentAmountEncode.Leave += new System.EventHandler(this.txtRepaymentAmountEncode_Leave);
            // 
            // txtRepaymentAmount
            // 
            this.txtRepaymentAmount.DecimalPlaces = 2;
            this.txtRepaymentAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRepaymentAmount.IsSendTabOnEnter = true;
            this.txtRepaymentAmount.IsThousandSeperator = true;
            this.txtRepaymentAmount.Location = new System.Drawing.Point(140, 197);
            this.txtRepaymentAmount.Name = "txtRepaymentAmount";
            this.txtRepaymentAmount.Size = new System.Drawing.Size(141, 20);
            this.txtRepaymentAmount.TabIndex = 103;
            this.txtRepaymentAmount.Text = "0.00";
            this.txtRepaymentAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRepaymentAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtRepaymentAmount.Leave += new System.EventHandler(this.txtRepaymentAmount_Leave);
            // 
            // gbJoinType
            // 
            this.gbJoinType.Controls.Add(this.rdoDecrease);
            this.gbJoinType.Controls.Add(this.rdoIncrease);
            this.gbJoinType.Location = new System.Drawing.Point(18, 134);
            this.gbJoinType.Name = "gbJoinType";
            this.gbJoinType.Size = new System.Drawing.Size(263, 48);
            this.gbJoinType.TabIndex = 101;
            this.gbJoinType.TabStop = false;
            this.gbJoinType.Text = "Limit Change State";
            // 
            // rdoDecrease
            // 
            this.rdoDecrease.AutoSize = true;
            this.rdoDecrease.Checked = true;
            this.rdoDecrease.IsSendTabOnEnter = true;
            this.rdoDecrease.Location = new System.Drawing.Point(147, 20);
            this.rdoDecrease.Name = "rdoDecrease";
            this.rdoDecrease.Size = new System.Drawing.Size(110, 17);
            this.rdoDecrease.TabIndex = 3;
            this.rdoDecrease.TabStop = true;
            this.rdoDecrease.Text = "Decrease Amount";
            this.rdoDecrease.UseVisualStyleBackColor = true;
            this.rdoDecrease.Click += new System.EventHandler(this.rdoDecrease_Click);
            // 
            // rdoIncrease
            // 
            this.rdoIncrease.AutoSize = true;
            this.rdoIncrease.IsSendTabOnEnter = true;
            this.rdoIncrease.Location = new System.Drawing.Point(12, 21);
            this.rdoIncrease.Name = "rdoIncrease";
            this.rdoIncrease.Size = new System.Drawing.Size(105, 17);
            this.rdoIncrease.TabIndex = 2;
            this.rdoIncrease.Text = "Increase Amount";
            this.rdoIncrease.UseVisualStyleBackColor = true;
            this.rdoIncrease.Click += new System.EventHandler(this.rdoIncrease_Click);
            // 
            // lblBLType
            // 
            this.lblBLType.AutoSize = true;
            this.lblBLType.Location = new System.Drawing.Point(15, 77);
            this.lblBLType.Name = "lblBLType";
            this.lblBLType.Size = new System.Drawing.Size(76, 13);
            this.lblBLType.TabIndex = 13;
            this.lblBLType.Text = "Type of Loan :";
            // 
            // dtpCurSAmtDate
            // 
            this.dtpCurSAmtDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpCurSAmtDate.Enabled = false;
            this.dtpCurSAmtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCurSAmtDate.IsSendTabOnEnter = true;
            this.dtpCurSAmtDate.Location = new System.Drawing.Point(140, 223);
            this.dtpCurSAmtDate.Name = "dtpCurSAmtDate";
            this.dtpCurSAmtDate.Size = new System.Drawing.Size(121, 20);
            this.dtpCurSAmtDate.TabIndex = 12;
            // 
            // lblCurrentSanDate
            // 
            this.lblCurrentSanDate.AutoSize = true;
            this.lblCurrentSanDate.Location = new System.Drawing.Point(15, 227);
            this.lblCurrentSanDate.Name = "lblCurrentSanDate";
            this.lblCurrentSanDate.Size = new System.Drawing.Size(118, 13);
            this.lblCurrentSanDate.TabIndex = 11;
            this.lblCurrentSanDate.Text = "Current Sanction Date :";
            // 
            // txtOutstandingInt
            // 
            this.txtOutstandingInt.DecimalPlaces = 0;
            this.txtOutstandingInt.IsSendTabOnEnter = true;
            this.txtOutstandingInt.IsThousandSeperator = true;
            this.txtOutstandingInt.Location = new System.Drawing.Point(140, 302);
            this.txtOutstandingInt.Name = "txtOutstandingInt";
            this.txtOutstandingInt.ReadOnly = true;
            this.txtOutstandingInt.Size = new System.Drawing.Size(141, 20);
            this.txtOutstandingInt.TabIndex = 10;
            this.txtOutstandingInt.Text = "0.00";
            this.txtOutstandingInt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOutstandingInt.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblOutstandingInterest
            // 
            this.lblOutstandingInterest.AutoSize = true;
            this.lblOutstandingInterest.Location = new System.Drawing.Point(15, 305);
            this.lblOutstandingInterest.Name = "lblOutstandingInterest";
            this.lblOutstandingInterest.Size = new System.Drawing.Size(102, 13);
            this.lblOutstandingInterest.TabIndex = 9;
            this.lblOutstandingInterest.Text = "Outstanding Interest";
            // 
            // txtTotalAmt
            // 
            this.txtTotalAmt.DecimalPlaces = 0;
            this.txtTotalAmt.IsSendTabOnEnter = true;
            this.txtTotalAmt.IsThousandSeperator = true;
            this.txtTotalAmt.Location = new System.Drawing.Point(140, 327);
            this.txtTotalAmt.Name = "txtTotalAmt";
            this.txtTotalAmt.ReadOnly = true;
            this.txtTotalAmt.Size = new System.Drawing.Size(141, 20);
            this.txtTotalAmt.TabIndex = 6;
            this.txtTotalAmt.Text = "0.00";
            this.txtTotalAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalAmt.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(15, 330);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(79, 13);
            this.lblTotalAmount.TabIndex = 5;
            this.lblTotalAmount.Text = "Total Amount  :";
            // 
            // txtLateFee
            // 
            this.txtLateFee.DecimalPlaces = 0;
            this.txtLateFee.IsSendTabOnEnter = true;
            this.txtLateFee.IsThousandSeperator = true;
            this.txtLateFee.Location = new System.Drawing.Point(140, 276);
            this.txtLateFee.Name = "txtLateFee";
            this.txtLateFee.ReadOnly = true;
            this.txtLateFee.Size = new System.Drawing.Size(141, 20);
            this.txtLateFee.TabIndex = 4;
            this.txtLateFee.Text = "0.00";
            this.txtLateFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLateFee.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.Location = new System.Drawing.Point(15, 279);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(94, 13);
            this.cxC00032.TabIndex = 3;
            this.cxC00032.Text = "Late Fee Amount :";
            // 
            // txtLoanNo
            // 
            this.txtLoanNo.IsSendTabOnEnter = true;
            this.txtLoanNo.Location = new System.Drawing.Point(140, 23);
            this.txtLoanNo.MaxLength = 15;
            this.txtLoanNo.Name = "txtLoanNo";
            this.txtLoanNo.Size = new System.Drawing.Size(121, 20);
            this.txtLoanNo.TabIndex = 1;
            this.txtLoanNo.TextChanged += new System.EventHandler(this.txtLoanNo_TextChanged);
            this.txtLoanNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLoanNo_KeyPress);
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(15, 26);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(57, 13);
            this.cxC00031.TabIndex = 0;
            this.cxC00031.Text = "Loan No. :";
            // 
            // txtInterestOnSamt
            // 
            this.txtInterestOnSamt.DecimalPlaces = 0;
            this.txtInterestOnSamt.Enabled = false;
            this.txtInterestOnSamt.IsSendTabOnEnter = true;
            this.txtInterestOnSamt.IsThousandSeperator = true;
            this.txtInterestOnSamt.Location = new System.Drawing.Point(140, 250);
            this.txtInterestOnSamt.Name = "txtInterestOnSamt";
            this.txtInterestOnSamt.ReadOnly = true;
            this.txtInterestOnSamt.Size = new System.Drawing.Size(141, 20);
            this.txtInterestOnSamt.TabIndex = 0;
            this.txtInterestOnSamt.Text = "0.00";
            this.txtInterestOnSamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInterestOnSamt.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtTotalOutstanding
            // 
            this.txtTotalOutstanding.DecimalPlaces = 0;
            this.txtTotalOutstanding.Enabled = false;
            this.txtTotalOutstanding.IsSendTabOnEnter = true;
            this.txtTotalOutstanding.IsThousandSeperator = true;
            this.txtTotalOutstanding.Location = new System.Drawing.Point(140, 101);
            this.txtTotalOutstanding.Name = "txtTotalOutstanding";
            this.txtTotalOutstanding.ReadOnly = true;
            this.txtTotalOutstanding.Size = new System.Drawing.Size(141, 20);
            this.txtTotalOutstanding.TabIndex = 0;
            this.txtTotalOutstanding.Text = "0.00";
            this.txtTotalOutstanding.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalOutstanding.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtRepaymentNo
            // 
            this.txtRepaymentNo.Enabled = false;
            this.txtRepaymentNo.IsSendTabOnEnter = true;
            this.txtRepaymentNo.Location = new System.Drawing.Point(140, 23);
            this.txtRepaymentNo.MaxLength = 3;
            this.txtRepaymentNo.Name = "txtRepaymentNo";
            this.txtRepaymentNo.ReadOnly = true;
            this.txtRepaymentNo.Size = new System.Drawing.Size(121, 20);
            this.txtRepaymentNo.TabIndex = 7;
            this.txtRepaymentNo.Visible = false;
            // 
            // chkFullSettlement
            // 
            this.chkFullSettlement.AutoSize = true;
            this.chkFullSettlement.Enabled = false;
            this.chkFullSettlement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFullSettlement.IsSendTabOnEnter = true;
            this.chkFullSettlement.Location = new System.Drawing.Point(379, 450);
            this.chkFullSettlement.Name = "chkFullSettlement";
            this.chkFullSettlement.Size = new System.Drawing.Size(95, 17);
            this.chkFullSettlement.TabIndex = 100;
            this.chkFullSettlement.Text = "Full Settlement";
            this.chkFullSettlement.UseVisualStyleBackColor = true;
            this.chkFullSettlement.Visible = false;
            this.chkFullSettlement.CheckedChanged += new System.EventHandler(this.chkFullSettlement_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Location = new System.Drawing.Point(392, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 107);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Name (s)";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(15, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 13);
            this.lblName.TabIndex = 22;
            // 
            // txtDateTime
            // 
            this.txtDateTime.AutoSize = true;
            this.txtDateTime.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.txtDateTime.Location = new System.Drawing.Point(555, 45);
            this.txtDateTime.Name = "txtDateTime";
            this.txtDateTime.Size = new System.Drawing.Size(10, 13);
            this.txtDateTime.TabIndex = 5;
            this.txtDateTime.Text = "-";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblDate.Location = new System.Drawing.Point(454, 45);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(95, 13);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Transaction Date :";
            // 
            // chkServiceCharges
            // 
            this.chkServiceCharges.AutoSize = true;
            this.chkServiceCharges.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkServiceCharges.IsSendTabOnEnter = true;
            this.chkServiceCharges.Location = new System.Drawing.Point(12, 36);
            this.chkServiceCharges.Name = "chkServiceCharges";
            this.chkServiceCharges.Size = new System.Drawing.Size(121, 30);
            this.chkServiceCharges.TabIndex = 5;
            this.chkServiceCharges.Text = "Please check to get\r\n service charges";
            this.chkServiceCharges.UseVisualStyleBackColor = true;
            this.chkServiceCharges.CheckedChanged += new System.EventHandler(this.chkServiceCharges_CheckedChanged);
            // 
            // chkEditDocAmt
            // 
            this.chkEditDocAmt.AutoSize = true;
            this.chkEditDocAmt.Location = new System.Drawing.Point(12, 85);
            this.chkEditDocAmt.Name = "chkEditDocAmt";
            this.chkEditDocAmt.Size = new System.Drawing.Size(83, 17);
            this.chkEditDocAmt.TabIndex = 6;
            this.chkEditDocAmt.Text = "Edit Amount";
            this.chkEditDocAmt.UseVisualStyleBackColor = true;
            this.chkEditDocAmt.CheckedChanged += new System.EventHandler(this.chkEditDocAmt_CheckedChanged);
            // 
            // txtDocumentFee
            // 
            this.txtDocumentFee.DecimalPlaces = 0;
            this.txtDocumentFee.IsSendTabOnEnter = true;
            this.txtDocumentFee.IsThousandSeperator = true;
            this.txtDocumentFee.Location = new System.Drawing.Point(121, 102);
            this.txtDocumentFee.Name = "txtDocumentFee";
            this.txtDocumentFee.Size = new System.Drawing.Size(90, 20);
            this.txtDocumentFee.TabIndex = 7;
            this.txtDocumentFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDocumentFee.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDocumentFee.Leave += new System.EventHandler(this.txtDocumentFee_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 104;
            this.label2.Text = "Documentation Fee :";
            // 
            // gpLimitIncrease
            // 
            this.gpLimitIncrease.Controls.Add(this.txtRate);
            this.gpLimitIncrease.Controls.Add(this.label1);
            this.gpLimitIncrease.Controls.Add(this.chkEdit);
            this.gpLimitIncrease.Controls.Add(this.cxC00033);
            this.gpLimitIncrease.Controls.Add(this.chkEditDocAmt);
            this.gpLimitIncrease.Controls.Add(this.txtDocumentFee);
            this.gpLimitIncrease.Controls.Add(this.chkServiceCharges);
            this.gpLimitIncrease.Controls.Add(this.label2);
            this.gpLimitIncrease.Location = new System.Drawing.Point(392, 178);
            this.gpLimitIncrease.Name = "gpLimitIncrease";
            this.gpLimitIncrease.Size = new System.Drawing.Size(223, 236);
            this.gpLimitIncrease.TabIndex = 23;
            this.gpLimitIncrease.TabStop = false;
            this.gpLimitIncrease.Text = "Limit Increase";
            this.gpLimitIncrease.Visible = false;
            // 
            // txtRate
            // 
            this.txtRate.DecimalPlaces = 0;
            this.txtRate.IsSendTabOnEnter = true;
            this.txtRate.Location = new System.Drawing.Point(121, 164);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(90, 20);
            this.txtRate.TabIndex = 9;
            this.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRate.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtRate.Enter += new System.EventHandler(this.txtRate_Enter);
            this.txtRate.Leave += new System.EventHandler(this.txtRate_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 107;
            this.label1.Text = "Loan Interest Rate :";
            // 
            // chkEdit
            // 
            this.chkEdit.AutoSize = true;
            this.chkEdit.Location = new System.Drawing.Point(12, 147);
            this.chkEdit.Name = "chkEdit";
            this.chkEdit.Size = new System.Drawing.Size(70, 17);
            this.chkEdit.TabIndex = 8;
            this.chkEdit.Text = "Edit Rate";
            this.chkEdit.UseVisualStyleBackColor = true;
            this.chkEdit.CheckedChanged += new System.EventHandler(this.chkEdit_CheckedChanged);
            // 
            // cxC00033
            // 
            this.cxC00033.AutoSize = true;
            this.cxC00033.Location = new System.Drawing.Point(15, 20);
            this.cxC00033.Name = "cxC00033";
            this.cxC00033.Size = new System.Drawing.Size(0, 13);
            this.cxC00033.TabIndex = 22;
            // 
            // LOMVEW00025
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 619);
            this.Controls.Add(this.gvAccountList);
            this.Controls.Add(this.gpLimitIncrease);
            this.Controls.Add(this.txtDateTime);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbRepayment);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.chkFullSettlement);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LOMVEW00025";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Business Loan Repayment Entry";
            this.Load += new System.EventHandler(this.LOMVEW00025_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LOMVEW00025_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gvAccountList)).EndInit();
            this.gbRepayment.ResumeLayout(false);
            this.gbRepayment.PerformLayout();
            this.gbJoinType.ResumeLayout(false);
            this.gbJoinType.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpLimitIncrease.ResumeLayout(false);
            this.gpLimitIncrease.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblTotalOutstanding;
        private Windows.CXClient.Controls.CXC0003 lblRepaymentAmount;
        private Windows.CXClient.Controls.CXC0001 txtAccountNo;
        private Windows.CXClient.Controls.CXC0001 txtTypeOfSecurity;
        private Windows.CXClient.Controls.AceGridView gvAccountList;
        private Windows.CXClient.Controls.CXC0003 lblInterestOnSamt;
        private System.Windows.Forms.GroupBox gbRepayment;
        private System.Windows.Forms.GroupBox groupBox1;
        private Windows.CXClient.Controls.CXC0003 lblName;
        private Windows.CXClient.Controls.CXC0004 txtTotalOutstanding;
        private Windows.CXClient.Controls.CXC0004 txtInterestOnSamt;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0008 chkFullSettlement;
        private Windows.CXClient.Controls.CXC0003 txtDateTime;
        private Windows.CXClient.Controls.CXC0003 lblDate;
        private Windows.CXClient.Controls.CXC0004 txtTotalAmt;
        private Windows.CXClient.Controls.CXC0003 lblTotalAmount;
        private Windows.CXClient.Controls.CXC0004 txtLateFee;
        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private Windows.CXClient.Controls.CXC0001 txtLoanNo;
        private Windows.CXClient.Controls.CXC0001 txtRepaymentNo;
        private Windows.CXClient.Controls.CXC0004 txtOutstandingInt;
        private Windows.CXClient.Controls.CXC0003 lblOutstandingInterest;
        private Windows.CXClient.Controls.CXC0005 dtpCurSAmtDate;
        private Windows.CXClient.Controls.CXC0003 lblCurrentSanDate;
        private System.Windows.Forms.GroupBox gbJoinType;
        private Windows.CXClient.Controls.CXC0009 rdoDecrease;
        private Windows.CXClient.Controls.CXC0009 rdoIncrease;
        private Windows.CXClient.Controls.CXC0003 lblBLType;
        private Windows.CXClient.Controls.CXC0008 chkServiceCharges;
        private System.Windows.Forms.CheckBox chkEditDocAmt;
        private Windows.CXClient.Controls.CXC0004 txtDocumentFee;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gpLimitIncrease;
        private Windows.CXClient.Controls.CXC0003 cxC00033;
        private System.Windows.Forms.CheckBox chkEdit;
        private Windows.CXClient.Controls.CXC0004 txtRate;
        private System.Windows.Forms.Label label1;
        private Windows.CXClient.Controls.CXC0004 txtRepaymentAmountEncode;
        private Windows.CXClient.Controls.CXC0004 txtRepaymentAmount;
        private Windows.CXClient.Controls.CXC0004 txtActualCusGetAmt;
        private Windows.CXClient.Controls.CXC0003 lblActualCusGetAmt;
        private Windows.CXClient.Controls.CXC0007 butEnquiry;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvColAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvColDebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvColCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvColDescription;
    }
}