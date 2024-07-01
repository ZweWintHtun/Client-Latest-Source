namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00092
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00092));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.txtLoanNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gbRepayment = new System.Windows.Forms.GroupBox();
            this.txtPenalities = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtTotalInterest = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblPenaltiesCode = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtRepaymentAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.cboPenalties = new Ace.Windows.CXClient.Controls.AceMultiColumnsComboBox();
            this.lblInterestCode = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblPenalties = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblRepaymentAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboLoanAcctNo = new Ace.Windows.CXClient.Controls.AceMultiColumnsComboBox();
            this.cboInterestAccNo = new Ace.Windows.CXClient.Controls.AceMultiColumnsComboBox();
            this.txtVrNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblTotalInterest = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblVrNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblRepaymentNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtRepaymentNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtTotalOutstanding = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtAccountNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblTotalOutstanding = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtDateTime = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gvLoanRepaymentList = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvColAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvColDebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvColCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvColDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkFullSettlement = new Ace.Windows.CXClient.Controls.CXC0008();
            this.lblName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gbRepayment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLoanRepaymentList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, -1);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(635, 31);
            this.tsbCRUD.TabIndex = 9;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // txtLoanNo
            // 
            this.txtLoanNo.IsSendTabOnEnter = true;
            this.txtLoanNo.Location = new System.Drawing.Point(141, 64);
            this.txtLoanNo.MaxLength = 15;
            this.txtLoanNo.Name = "txtLoanNo";
            this.txtLoanNo.Size = new System.Drawing.Size(121, 20);
            this.txtLoanNo.TabIndex = 1;
            this.txtLoanNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLoanNo_KeyPress);
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(15, 68);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(57, 13);
            this.cxC00031.TabIndex = 0;
            this.cxC00031.Text = "Loan No. :";
            // 
            // gbRepayment
            // 
            this.gbRepayment.Controls.Add(this.txtPenalities);
            this.gbRepayment.Controls.Add(this.txtTotalInterest);
            this.gbRepayment.Controls.Add(this.lblPenaltiesCode);
            this.gbRepayment.Controls.Add(this.cxC00032);
            this.gbRepayment.Controls.Add(this.txtRepaymentAmount);
            this.gbRepayment.Controls.Add(this.cboPenalties);
            this.gbRepayment.Controls.Add(this.lblInterestCode);
            this.gbRepayment.Controls.Add(this.lblPenalties);
            this.gbRepayment.Controls.Add(this.lblRepaymentAmount);
            this.gbRepayment.Controls.Add(this.cboLoanAcctNo);
            this.gbRepayment.Controls.Add(this.cboInterestAccNo);
            this.gbRepayment.Controls.Add(this.txtVrNo);
            this.gbRepayment.Controls.Add(this.lblTotalInterest);
            this.gbRepayment.Controls.Add(this.lblVrNo);
            this.gbRepayment.Controls.Add(this.txtLoanNo);
            this.gbRepayment.Controls.Add(this.cxC00031);
            this.gbRepayment.Controls.Add(this.lblRepaymentNo);
            this.gbRepayment.Controls.Add(this.txtRepaymentNo);
            this.gbRepayment.Controls.Add(this.txtTotalOutstanding);
            this.gbRepayment.Controls.Add(this.lblAccountNo);
            this.gbRepayment.Controls.Add(this.txtAccountNo);
            this.gbRepayment.Controls.Add(this.lblTotalOutstanding);
            this.gbRepayment.Location = new System.Drawing.Point(5, 41);
            this.gbRepayment.Name = "gbRepayment";
            this.gbRepayment.Size = new System.Drawing.Size(335, 298);
            this.gbRepayment.TabIndex = 7;
            this.gbRepayment.TabStop = false;
            // 
            // txtPenalities
            // 
            this.txtPenalities.DecimalPlaces = 2;
            this.txtPenalities.Enabled = false;
            this.txtPenalities.IsSendTabOnEnter = true;
            this.txtPenalities.IsThousandSeperator = true;
            this.txtPenalities.Location = new System.Drawing.Point(141, 234);
            this.txtPenalities.Name = "txtPenalities";
            this.txtPenalities.Size = new System.Drawing.Size(141, 20);
            this.txtPenalities.TabIndex = 7;
            this.txtPenalities.Text = "0.00";
            this.txtPenalities.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPenalities.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtTotalInterest
            // 
            this.txtTotalInterest.DecimalPlaces = 2;
            this.txtTotalInterest.Enabled = false;
            this.txtTotalInterest.IsSendTabOnEnter = true;
            this.txtTotalInterest.IsThousandSeperator = true;
            this.txtTotalInterest.Location = new System.Drawing.Point(141, 185);
            this.txtTotalInterest.Name = "txtTotalInterest";
            this.txtTotalInterest.Size = new System.Drawing.Size(141, 20);
            this.txtTotalInterest.TabIndex = 4;
            this.txtTotalInterest.Text = "0.00";
            this.txtTotalInterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalInterest.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtTotalInterest.Leave += new System.EventHandler(this.txtTotalInterest_Leave);
            // 
            // lblPenaltiesCode
            // 
            this.lblPenaltiesCode.AutoSize = true;
            this.lblPenaltiesCode.Location = new System.Drawing.Point(16, 260);
            this.lblPenaltiesCode.Name = "lblPenaltiesCode";
            this.lblPenaltiesCode.Size = new System.Drawing.Size(84, 13);
            this.lblPenaltiesCode.TabIndex = 13;
            this.lblPenaltiesCode.Text = "Penalties Code :";
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.Location = new System.Drawing.Point(15, 116);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(81, 13);
            this.cxC00032.TabIndex = 11;
            this.cxC00032.Text = "Account Code :";
            // 
            // txtRepaymentAmount
            // 
            this.txtRepaymentAmount.DecimalPlaces = 2;
            this.txtRepaymentAmount.IsSendTabOnEnter = true;
            this.txtRepaymentAmount.IsThousandSeperator = true;
            this.txtRepaymentAmount.Location = new System.Drawing.Point(141, 161);
            this.txtRepaymentAmount.Name = "txtRepaymentAmount";
            this.txtRepaymentAmount.Size = new System.Drawing.Size(141, 20);
            this.txtRepaymentAmount.TabIndex = 3;
            this.txtRepaymentAmount.Text = "0.00";
            this.txtRepaymentAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRepaymentAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // cboPenalties
            // 
            this.cboPenalties.AutoComplete = false;
            this.cboPenalties.AutoDropdown = false;
            this.cboPenalties.BackColorEven = System.Drawing.Color.White;
            this.cboPenalties.BackColorOdd = System.Drawing.Color.White;
            this.cboPenalties.ColumnNames = "";
            this.cboPenalties.ColumnWidthDefault = 150;
            this.cboPenalties.ColumnWidths = "50,180";
            this.cboPenalties.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboPenalties.FormattingEnabled = true;
            this.cboPenalties.LinkedColumnIndex = 0;
            this.cboPenalties.LinkedTextBox = null;
            this.cboPenalties.Location = new System.Drawing.Point(141, 258);
            this.cboPenalties.Name = "cboPenalties";
            this.cboPenalties.Size = new System.Drawing.Size(180, 21);
            this.cboPenalties.TabIndex = 8;
            this.cboPenalties.SelectedIndexChanged += new System.EventHandler(this.cboPenalties_SelectedIndexChanged);
            // 
            // lblInterestCode
            // 
            this.lblInterestCode.AutoSize = true;
            this.lblInterestCode.Location = new System.Drawing.Point(16, 212);
            this.lblInterestCode.Name = "lblInterestCode";
            this.lblInterestCode.Size = new System.Drawing.Size(76, 13);
            this.lblInterestCode.TabIndex = 12;
            this.lblInterestCode.Text = "Interest Code :";
            // 
            // lblPenalties
            // 
            this.lblPenalties.AutoSize = true;
            this.lblPenalties.Location = new System.Drawing.Point(16, 236);
            this.lblPenalties.Name = "lblPenalties";
            this.lblPenalties.Size = new System.Drawing.Size(56, 13);
            this.lblPenalties.TabIndex = 5;
            this.lblPenalties.Text = "Penalties :";
            // 
            // lblRepaymentAmount
            // 
            this.lblRepaymentAmount.AutoSize = true;
            this.lblRepaymentAmount.Location = new System.Drawing.Point(16, 164);
            this.lblRepaymentAmount.Name = "lblRepaymentAmount";
            this.lblRepaymentAmount.Size = new System.Drawing.Size(109, 13);
            this.lblRepaymentAmount.TabIndex = 9;
            this.lblRepaymentAmount.Text = "Repayment Amount  :";
            // 
            // cboLoanAcctNo
            // 
            this.cboLoanAcctNo.AutoComplete = false;
            this.cboLoanAcctNo.AutoDropdown = false;
            this.cboLoanAcctNo.BackColorEven = System.Drawing.Color.White;
            this.cboLoanAcctNo.BackColorOdd = System.Drawing.Color.White;
            this.cboLoanAcctNo.ColumnNames = "";
            this.cboLoanAcctNo.ColumnWidthDefault = 150;
            this.cboLoanAcctNo.ColumnWidths = "50,180";
            this.cboLoanAcctNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboLoanAcctNo.FormattingEnabled = true;
            this.cboLoanAcctNo.LinkedColumnIndex = 0;
            this.cboLoanAcctNo.LinkedTextBox = null;
            this.cboLoanAcctNo.Location = new System.Drawing.Point(141, 112);
            this.cboLoanAcctNo.Name = "cboLoanAcctNo";
            this.cboLoanAcctNo.Size = new System.Drawing.Size(180, 21);
            this.cboLoanAcctNo.TabIndex = 2;
            // 
            // cboInterestAccNo
            // 
            this.cboInterestAccNo.AutoComplete = false;
            this.cboInterestAccNo.AutoDropdown = false;
            this.cboInterestAccNo.BackColorEven = System.Drawing.Color.White;
            this.cboInterestAccNo.BackColorOdd = System.Drawing.Color.White;
            this.cboInterestAccNo.ColumnNames = "";
            this.cboInterestAccNo.ColumnWidthDefault = 150;
            this.cboInterestAccNo.ColumnWidths = "50,180";
            this.cboInterestAccNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboInterestAccNo.FormattingEnabled = true;
            this.cboInterestAccNo.LinkedColumnIndex = 0;
            this.cboInterestAccNo.LinkedTextBox = null;
            this.cboInterestAccNo.Location = new System.Drawing.Point(141, 209);
            this.cboInterestAccNo.Name = "cboInterestAccNo";
            this.cboInterestAccNo.Size = new System.Drawing.Size(180, 21);
            this.cboInterestAccNo.TabIndex = 6;
            this.cboInterestAccNo.SelectedIndexChanged += new System.EventHandler(this.cboInterestAccNo_SelectedIndexChanged);
            // 
            // txtVrNo
            // 
            this.txtVrNo.IsSendTabOnEnter = true;
            this.txtVrNo.Location = new System.Drawing.Point(141, 40);
            this.txtVrNo.MaxLength = 15;
            this.txtVrNo.Name = "txtVrNo";
            this.txtVrNo.Size = new System.Drawing.Size(121, 20);
            this.txtVrNo.TabIndex = 0;
            this.txtVrNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVrNo_KeyPress);
            // 
            // lblTotalInterest
            // 
            this.lblTotalInterest.AutoSize = true;
            this.lblTotalInterest.Location = new System.Drawing.Point(15, 188);
            this.lblTotalInterest.Name = "lblTotalInterest";
            this.lblTotalInterest.Size = new System.Drawing.Size(78, 13);
            this.lblTotalInterest.TabIndex = 0;
            this.lblTotalInterest.Text = "Total Interest  :";
            // 
            // lblVrNo
            // 
            this.lblVrNo.AutoSize = true;
            this.lblVrNo.Location = new System.Drawing.Point(16, 44);
            this.lblVrNo.Name = "lblVrNo";
            this.lblVrNo.Size = new System.Drawing.Size(37, 13);
            this.lblVrNo.TabIndex = 3;
            this.lblVrNo.Text = "Vr No:";
            // 
            // lblRepaymentNo
            // 
            this.lblRepaymentNo.AutoSize = true;
            this.lblRepaymentNo.Location = new System.Drawing.Point(15, 20);
            this.lblRepaymentNo.Name = "lblRepaymentNo";
            this.lblRepaymentNo.Size = new System.Drawing.Size(87, 13);
            this.lblRepaymentNo.TabIndex = 0;
            this.lblRepaymentNo.Text = "Repayment No. :";
            // 
            // txtRepaymentNo
            // 
            this.txtRepaymentNo.Enabled = false;
            this.txtRepaymentNo.IsSendTabOnEnter = true;
            this.txtRepaymentNo.Location = new System.Drawing.Point(141, 16);
            this.txtRepaymentNo.MaxLength = 15;
            this.txtRepaymentNo.Name = "txtRepaymentNo";
            this.txtRepaymentNo.ReadOnly = true;
            this.txtRepaymentNo.Size = new System.Drawing.Size(121, 20);
            this.txtRepaymentNo.TabIndex = 16;
            // 
            // txtTotalOutstanding
            // 
            this.txtTotalOutstanding.DecimalPlaces = 0;
            this.txtTotalOutstanding.Enabled = false;
            this.txtTotalOutstanding.IsSendTabOnEnter = true;
            this.txtTotalOutstanding.IsThousandSeperator = true;
            this.txtTotalOutstanding.Location = new System.Drawing.Point(141, 137);
            this.txtTotalOutstanding.Name = "txtTotalOutstanding";
            this.txtTotalOutstanding.ReadOnly = true;
            this.txtTotalOutstanding.Size = new System.Drawing.Size(141, 20);
            this.txtTotalOutstanding.TabIndex = 5;
            this.txtTotalOutstanding.Text = "14.00";
            this.txtTotalOutstanding.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalOutstanding.Value = new decimal(new int[] {
            1400,
            0,
            0,
            131072});
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(15, 92);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(76, 13);
            this.lblAccountNo.TabIndex = 0;
            this.lblAccountNo.Text = "Account No.  :";
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.Enabled = false;
            this.txtAccountNo.IsSendTabOnEnter = true;
            this.txtAccountNo.Location = new System.Drawing.Point(141, 88);
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.ReadOnly = true;
            this.txtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.txtAccountNo.TabIndex = 15;
            // 
            // lblTotalOutstanding
            // 
            this.lblTotalOutstanding.AutoSize = true;
            this.lblTotalOutstanding.Location = new System.Drawing.Point(15, 140);
            this.lblTotalOutstanding.Name = "lblTotalOutstanding";
            this.lblTotalOutstanding.Size = new System.Drawing.Size(100, 13);
            this.lblTotalOutstanding.TabIndex = 0;
            this.lblTotalOutstanding.Text = "Total Outstanding  :";
            // 
            // txtDateTime
            // 
            this.txtDateTime.AutoSize = true;
            this.txtDateTime.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.txtDateTime.Location = new System.Drawing.Point(391, 61);
            this.txtDateTime.Name = "txtDateTime";
            this.txtDateTime.Size = new System.Drawing.Size(10, 13);
            this.txtDateTime.TabIndex = 11;
            this.txtDateTime.Text = "-";
            // 
            // gvLoanRepaymentList
            // 
            this.gvLoanRepaymentList.AllowUserToAddRows = false;
            this.gvLoanRepaymentList.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvLoanRepaymentList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvLoanRepaymentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvLoanRepaymentList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.gvLoanRepaymentList.DefaultCellStyle = dataGridViewCellStyle4;
            this.gvLoanRepaymentList.Enabled = false;
            this.gvLoanRepaymentList.EnableHeadersVisualStyles = false;
            this.gvLoanRepaymentList.IdTSList = null;
            this.gvLoanRepaymentList.IsEscapeKey = false;
            this.gvLoanRepaymentList.IsHeaderClick = false;
            this.gvLoanRepaymentList.Location = new System.Drawing.Point(5, 345);
            this.gvLoanRepaymentList.Name = "gvLoanRepaymentList";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvLoanRepaymentList.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gvLoanRepaymentList.RowHeadersWidth = 25;
            this.gvLoanRepaymentList.ShowSerialNo = false;
            this.gvLoanRepaymentList.Size = new System.Drawing.Size(614, 170);
            this.gvLoanRepaymentList.TabIndex = 5;
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
            this.gvColAccountNo.DataPropertyName = "Code";
            this.gvColAccountNo.HeaderText = "Account No.";
            this.gvColAccountNo.Name = "gvColAccountNo";
            this.gvColAccountNo.ReadOnly = true;
            this.gvColAccountNo.Width = 120;
            // 
            // gvColDebit
            // 
            this.gvColDebit.DataPropertyName = "Description";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.gvColDebit.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvColDebit.HeaderText = "Debit";
            this.gvColDebit.Name = "gvColDebit";
            this.gvColDebit.ReadOnly = true;
            // 
            // gvColCredit
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.gvColCredit.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvColCredit.HeaderText = "Credit";
            this.gvColCredit.Name = "gvColCredit";
            // 
            // gvColDescription
            // 
            this.gvColDescription.HeaderText = "Description";
            this.gvColDescription.Name = "gvColDescription";
            this.gvColDescription.Width = 250;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblDate.Location = new System.Drawing.Point(346, 61);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(36, 13);
            this.lblDate.TabIndex = 10;
            this.lblDate.Text = "Date :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkFullSettlement);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Location = new System.Drawing.Point(346, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 175);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Name (s)";
            // 
            // chkFullSettlement
            // 
            this.chkFullSettlement.AutoSize = true;
            this.chkFullSettlement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFullSettlement.IsSendTabOnEnter = true;
            this.chkFullSettlement.Location = new System.Drawing.Point(58, 146);
            this.chkFullSettlement.Name = "chkFullSettlement";
            this.chkFullSettlement.Size = new System.Drawing.Size(95, 17);
            this.chkFullSettlement.TabIndex = 100;
            this.chkFullSettlement.Text = "Full Settlement";
            this.chkFullSettlement.UseVisualStyleBackColor = true;
            this.chkFullSettlement.Visible = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(24, 198);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 13);
            this.lblName.TabIndex = 22;
            // 
            // LOMVEW00092
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 525);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbRepayment);
            this.Controls.Add(this.txtDateTime);
            this.Controls.Add(this.gvLoanRepaymentList);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00092";
            this.Text = "Seasonal Loans Repayment Entry";
            this.Load += new System.EventHandler(this.LOMVEW00092_Load);
            this.gbRepayment.ResumeLayout(false);
            this.gbRepayment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLoanRepaymentList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0001 txtLoanNo;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private System.Windows.Forms.GroupBox gbRepayment;
        private Windows.CXClient.Controls.CXC0003 lblRepaymentNo;
        private Windows.CXClient.Controls.CXC0001 txtRepaymentNo;
        private Windows.CXClient.Controls.CXC0004 txtTotalOutstanding;
        private Windows.CXClient.Controls.CXC0003 lblTotalInterest;
        private Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Windows.CXClient.Controls.CXC0001 txtAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblTotalOutstanding;
        private Windows.CXClient.Controls.CXC0003 txtDateTime;
        private Windows.CXClient.Controls.AceGridView gvLoanRepaymentList;
        private Windows.CXClient.Controls.CXC0003 lblDate;
        private Windows.CXClient.Controls.CXC0001 txtVrNo;
        private Windows.CXClient.Controls.CXC0003 lblVrNo;
        private Windows.CXClient.Controls.CXC0003 lblPenalties;
        private System.Windows.Forms.GroupBox groupBox1;
        private Windows.CXClient.Controls.CXC0008 chkFullSettlement;
        private Windows.CXClient.Controls.CXC0003 lblName;
        private Windows.CXClient.Controls.AceMultiColumnsComboBox cboLoanAcctNo;
        private Windows.CXClient.Controls.AceMultiColumnsComboBox cboInterestAccNo;
        private Windows.CXClient.Controls.AceMultiColumnsComboBox cboPenalties;
        private Windows.CXClient.Controls.CXC0004 txtRepaymentAmount;
        private Windows.CXClient.Controls.CXC0003 lblRepaymentAmount;
        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private Windows.CXClient.Controls.CXC0003 lblInterestCode;
        private Windows.CXClient.Controls.CXC0003 lblPenaltiesCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvColAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvColDebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvColCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvColDescription;
        private Windows.CXClient.Controls.CXC0004 txtTotalInterest;
        private Windows.CXClient.Controls.CXC0004 txtPenalities;
    }
}