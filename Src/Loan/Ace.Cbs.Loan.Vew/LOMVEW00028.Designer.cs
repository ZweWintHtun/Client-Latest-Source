namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00028
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00028));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gvLegalODRepayment = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDRCR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblLoanNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblDrAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblLegalDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCurrentBalance = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblDepositAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtDepositAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtCurrentBalance = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtTypeOfLoan = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtLegalDate = new Ace.Windows.CXClient.Controls.CXC0001();
            this.gbNames = new System.Windows.Forms.GroupBox();
            this.lstNames = new System.Windows.Forms.ListBox();
            this.lblDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblStatus = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblStatusDesp = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtLoanNo = new Ace.Windows.CXClient.Controls.CXC0001();
            ((System.ComponentModel.ISupportInitialize)(this.gvLegalODRepayment)).BeginInit();
            this.gbNames.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-2, -2);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(519, 31);
            this.tsbCRUD.TabIndex = 4;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // gvLegalODRepayment
            // 
            this.gvLegalODRepayment.AllowUserToAddRows = false;
            this.gvLegalODRepayment.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvLegalODRepayment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvLegalODRepayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvLegalODRepayment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAccountNo,
            this.colDescription,
            this.colAmount,
            this.colDRCR});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvLegalODRepayment.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvLegalODRepayment.EnableHeadersVisualStyles = false;
            this.gvLegalODRepayment.IdTSList = null;
            this.gvLegalODRepayment.IsEscapeKey = false;
            this.gvLegalODRepayment.IsHeaderClick = false;
            this.gvLegalODRepayment.Location = new System.Drawing.Point(12, 222);
            this.gvLegalODRepayment.Name = "gvLegalODRepayment";
            this.gvLegalODRepayment.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvLegalODRepayment.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gvLegalODRepayment.RowHeadersWidth = 25;
            this.gvLegalODRepayment.ShowSerialNo = true;
            this.gvLegalODRepayment.Size = new System.Drawing.Size(491, 195);
            this.gvLegalODRepayment.TabIndex = 100;
            // 
            // colAccountNo
            // 
            this.colAccountNo.DataPropertyName = "AcctNo";
            this.colAccountNo.HeaderText = "Account No";
            this.colAccountNo.Name = "colAccountNo";
            this.colAccountNo.ReadOnly = true;
            this.colAccountNo.Width = 125;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "LoansDesp";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 150;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "SAmt";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Width = 125;
            // 
            // colDRCR
            // 
            this.colDRCR.DataPropertyName = "Name";
            this.colDRCR.HeaderText = "Dr / Cr";
            this.colDRCR.Name = "colDRCR";
            this.colDRCR.ReadOnly = true;
            this.colDRCR.Width = 50;
            // 
            // lblLoanNo
            // 
            this.lblLoanNo.AutoSize = true;
            this.lblLoanNo.Location = new System.Drawing.Point(14, 43);
            this.lblLoanNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLoanNo.Name = "lblLoanNo";
            this.lblLoanNo.Size = new System.Drawing.Size(57, 13);
            this.lblLoanNo.TabIndex = 10;
            this.lblLoanNo.Text = "Loan No. :";
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(14, 67);
            this.lblAccountNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(73, 13);
            this.lblAccountNo.TabIndex = 20;
            this.lblAccountNo.Text = "Account No. :";
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.Location = new System.Drawing.Point(14, 91);
            this.cxC00032.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(87, 13);
            this.cxC00032.TabIndex = 40;
            this.cxC00032.Text = "Dr Account No. :";
            // 
            // lblDrAccountNo
            // 
            this.lblDrAccountNo.AutoSize = true;
            this.lblDrAccountNo.Location = new System.Drawing.Point(14, 116);
            this.lblDrAccountNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDrAccountNo.Name = "lblDrAccountNo";
            this.lblDrAccountNo.Size = new System.Drawing.Size(76, 13);
            this.lblDrAccountNo.TabIndex = 50;
            this.lblDrAccountNo.Text = "Type of Loan :";
            // 
            // lblLegalDate
            // 
            this.lblLegalDate.AutoSize = true;
            this.lblLegalDate.Location = new System.Drawing.Point(16, 142);
            this.lblLegalDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLegalDate.Name = "lblLegalDate";
            this.lblLegalDate.Size = new System.Drawing.Size(65, 13);
            this.lblLegalDate.TabIndex = 60;
            this.lblLegalDate.Text = "Legal Date :";
            // 
            // lblCurrentBalance
            // 
            this.lblCurrentBalance.AutoSize = true;
            this.lblCurrentBalance.Location = new System.Drawing.Point(16, 169);
            this.lblCurrentBalance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurrentBalance.Name = "lblCurrentBalance";
            this.lblCurrentBalance.Size = new System.Drawing.Size(89, 13);
            this.lblCurrentBalance.TabIndex = 70;
            this.lblCurrentBalance.Text = "Current Balance :";
            // 
            // lblDepositAmount
            // 
            this.lblDepositAmount.AutoSize = true;
            this.lblDepositAmount.Location = new System.Drawing.Point(17, 196);
            this.lblDepositAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDepositAmount.Name = "lblDepositAmount";
            this.lblDepositAmount.Size = new System.Drawing.Size(88, 13);
            this.lblDepositAmount.TabIndex = 80;
            this.lblDepositAmount.Text = "Deposit Amount :";
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.Enabled = false;
            this.txtAccountNo.IsSendTabOnEnter = true;
            this.txtAccountNo.Location = new System.Drawing.Point(120, 64);
            this.txtAccountNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.Size = new System.Drawing.Size(135, 20);
            this.txtAccountNo.TabIndex = 0;
            this.txtAccountNo.TabStop = false;
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(120, 88);
            this.mtxtAccountNo.Margin = new System.Windows.Forms.Padding(2);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(135, 20);
            this.mtxtAccountNo.TabIndex = 2;
            // 
            // txtDepositAmount
            // 
            this.txtDepositAmount.DecimalPlaces = 2;
            this.txtDepositAmount.IsSendTabOnEnter = true;
            this.txtDepositAmount.IsThousandSeperator = true;
            this.txtDepositAmount.IsUseFloatingPoint = true;
            this.txtDepositAmount.Location = new System.Drawing.Point(120, 193);
            this.txtDepositAmount.Margin = new System.Windows.Forms.Padding(2);
            this.txtDepositAmount.MaxLength = 18;
            this.txtDepositAmount.Name = "txtDepositAmount";
            this.txtDepositAmount.Size = new System.Drawing.Size(135, 20);
            this.txtDepositAmount.TabIndex = 3;
            this.txtDepositAmount.Text = "0.00";
            this.txtDepositAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDepositAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtCurrentBalance
            // 
            this.txtCurrentBalance.BackColor = System.Drawing.SystemColors.Window;
            this.txtCurrentBalance.DecimalPlaces = 2;
            this.txtCurrentBalance.Enabled = false;
            this.txtCurrentBalance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCurrentBalance.IsSendTabOnEnter = true;
            this.txtCurrentBalance.IsThousandSeperator = true;
            this.txtCurrentBalance.IsUseFloatingPoint = true;
            this.txtCurrentBalance.Location = new System.Drawing.Point(120, 166);
            this.txtCurrentBalance.Margin = new System.Windows.Forms.Padding(2);
            this.txtCurrentBalance.MaxLength = 18;
            this.txtCurrentBalance.Name = "txtCurrentBalance";
            this.txtCurrentBalance.Size = new System.Drawing.Size(135, 20);
            this.txtCurrentBalance.TabIndex = 0;
            this.txtCurrentBalance.Text = "0.00";
            this.txtCurrentBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCurrentBalance.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtTypeOfLoan
            // 
            this.txtTypeOfLoan.Enabled = false;
            this.txtTypeOfLoan.IsSendTabOnEnter = true;
            this.txtTypeOfLoan.Location = new System.Drawing.Point(120, 113);
            this.txtTypeOfLoan.Name = "txtTypeOfLoan";
            this.txtTypeOfLoan.Size = new System.Drawing.Size(135, 20);
            this.txtTypeOfLoan.TabIndex = 0;
            // 
            // txtLegalDate
            // 
            this.txtLegalDate.Enabled = false;
            this.txtLegalDate.IsSendTabOnEnter = true;
            this.txtLegalDate.Location = new System.Drawing.Point(120, 139);
            this.txtLegalDate.Name = "txtLegalDate";
            this.txtLegalDate.Size = new System.Drawing.Size(135, 20);
            this.txtLegalDate.TabIndex = 0;
            // 
            // gbNames
            // 
            this.gbNames.Controls.Add(this.lstNames);
            this.gbNames.Location = new System.Drawing.Point(300, 53);
            this.gbNames.Name = "gbNames";
            this.gbNames.Size = new System.Drawing.Size(203, 138);
            this.gbNames.TabIndex = 110;
            this.gbNames.TabStop = false;
            this.gbNames.Text = "Name[s]";
            // 
            // lstNames
            // 
            this.lstNames.DataSource = this.lstNames.CustomTabOffsets;
            this.lstNames.Enabled = false;
            this.lstNames.FormattingEnabled = true;
            this.lstNames.Location = new System.Drawing.Point(14, 19);
            this.lstNames.Name = "lstNames";
            this.lstNames.Size = new System.Drawing.Size(177, 108);
            this.lstNames.TabIndex = 0;
            this.lstNames.TabStop = false;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblDate.Location = new System.Drawing.Point(439, 36);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(36, 13);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Date :";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblDate.Click += new System.EventHandler(this.lblDate_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(311, 198);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(43, 13);
            this.lblStatus.TabIndex = 80;
            this.lblStatus.Text = "Status :";
            // 
            // lblStatusDesp
            // 
            this.lblStatusDesp.AutoSize = true;
            this.lblStatusDesp.Location = new System.Drawing.Point(358, 198);
            this.lblStatusDesp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatusDesp.Name = "lblStatusDesp";
            this.lblStatusDesp.Size = new System.Drawing.Size(10, 13);
            this.lblStatusDesp.TabIndex = 90;
            this.lblStatusDesp.Text = "-";
            // 
            // txtLoanNo
            // 
            this.txtLoanNo.IsSendTabOnEnter = true;
            this.txtLoanNo.Location = new System.Drawing.Point(120, 39);
            this.txtLoanNo.MaxLength = 15;
            this.txtLoanNo.Name = "txtLoanNo";
            this.txtLoanNo.Size = new System.Drawing.Size(135, 20);
            this.txtLoanNo.TabIndex = 1;
            this.txtLoanNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLoanNo_KeyPress);
            // 
            // LOMVEW00028
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 428);
            this.Controls.Add(this.txtLoanNo);
            this.Controls.Add(this.lblStatusDesp);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.gbNames);
            this.Controls.Add(this.txtLegalDate);
            this.Controls.Add(this.txtTypeOfLoan);
            this.Controls.Add(this.txtCurrentBalance);
            this.Controls.Add(this.txtDepositAmount);
            this.Controls.Add(this.mtxtAccountNo);
            this.Controls.Add(this.txtAccountNo);
            this.Controls.Add(this.lblDepositAmount);
            this.Controls.Add(this.lblCurrentBalance);
            this.Controls.Add(this.lblLegalDate);
            this.Controls.Add(this.lblDrAccountNo);
            this.Controls.Add(this.cxC00032);
            this.Controls.Add(this.lblAccountNo);
            this.Controls.Add(this.lblLoanNo);
            this.Controls.Add(this.gvLegalODRepayment);
            this.Controls.Add(this.tsbCRUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LOMVEW00028";
            this.Text = "Legal Loan Deposit Entry (OverDraft)";
            this.Load += new System.EventHandler(this.LOMVEW00028_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LOMVEW00028_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gvLegalODRepayment)).EndInit();
            this.gbNames.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.AceGridView gvLegalODRepayment;
        private Windows.CXClient.Controls.CXC0003 lblLoanNo;
        private Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private Windows.CXClient.Controls.CXC0003 lblDrAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblLegalDate;
        private Windows.CXClient.Controls.CXC0003 lblCurrentBalance;
        private Windows.CXClient.Controls.CXC0003 lblDepositAmount;
        private Windows.CXClient.Controls.CXC0006 txtAccountNo;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Windows.CXClient.Controls.CXC0004 txtDepositAmount;
        private Windows.CXClient.Controls.CXC0004 txtCurrentBalance;
        private Windows.CXClient.Controls.CXC0001 txtTypeOfLoan;
        private Windows.CXClient.Controls.CXC0001 txtLegalDate;
        private System.Windows.Forms.GroupBox gbNames;
        private System.Windows.Forms.ListBox lstNames;
        private Windows.CXClient.Controls.CXC0003 lblDate;
        private Windows.CXClient.Controls.CXC0003 lblStatus;
        private Windows.CXClient.Controls.CXC0003 lblStatusDesp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDRCR;
        private Windows.CXClient.Controls.CXC0001 txtLoanNo;
    }
}