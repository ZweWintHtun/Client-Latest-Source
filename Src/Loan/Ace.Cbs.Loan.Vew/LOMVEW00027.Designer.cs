namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00027
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00027));
            this.lblLoanNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCurrentBal = new Ace.Windows.CXClient.Controls.CXC0003();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtCurrentBalance = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtRepaymentAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblRepaymentAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lstNames = new System.Windows.Forms.ListBox();
            this.gpNames = new System.Windows.Forms.GroupBox();
            this.txtLoanNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.colDRCR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvLoanRepayment = new Ace.Windows.CXClient.Controls.AceGridView();
            this.gpNames.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLoanRepayment)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLoanNo
            // 
            this.lblLoanNo.AutoSize = true;
            this.lblLoanNo.Location = new System.Drawing.Point(19, 60);
            this.lblLoanNo.Name = "lblLoanNo";
            this.lblLoanNo.Size = new System.Drawing.Size(57, 13);
            this.lblLoanNo.TabIndex = 0;
            this.lblLoanNo.Text = "Loan No. :";
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(19, 86);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(73, 13);
            this.lblAccountNo.TabIndex = 0;
            this.lblAccountNo.Text = "Account No. :";
            // 
            // lblCurrentBal
            // 
            this.lblCurrentBal.AutoSize = true;
            this.lblCurrentBal.Location = new System.Drawing.Point(19, 112);
            this.lblCurrentBal.Name = "lblCurrentBal";
            this.lblCurrentBal.Size = new System.Drawing.Size(89, 13);
            this.lblCurrentBal.TabIndex = 0;
            this.lblCurrentBal.Text = "Current Balance :";
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.Enabled = false;
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(135, 83);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 0;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtCurrentBalance
            // 
            this.txtCurrentBalance.DecimalPlaces = 2;
            this.txtCurrentBalance.Enabled = false;
            this.txtCurrentBalance.IsSendTabOnEnter = true;
            this.txtCurrentBalance.IsThousandSeperator = true;
            this.txtCurrentBalance.IsUseFloatingPoint = true;
            this.txtCurrentBalance.Location = new System.Drawing.Point(135, 109);
            this.txtCurrentBalance.MaxLength = 18;
            this.txtCurrentBalance.Name = "txtCurrentBalance";
            this.txtCurrentBalance.Size = new System.Drawing.Size(141, 20);
            this.txtCurrentBalance.TabIndex = 0;
            this.txtCurrentBalance.Text = "0.00";
            this.txtCurrentBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCurrentBalance.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtRepaymentAmount
            // 
            this.txtRepaymentAmount.DecimalPlaces = 2;
            this.txtRepaymentAmount.IsSendTabOnEnter = true;
            this.txtRepaymentAmount.IsThousandSeperator = true;
            this.txtRepaymentAmount.IsUseFloatingPoint = true;
            this.txtRepaymentAmount.Location = new System.Drawing.Point(135, 135);
            this.txtRepaymentAmount.MaxLength = 18;
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
            // lblRepaymentAmount
            // 
            this.lblRepaymentAmount.AutoSize = true;
            this.lblRepaymentAmount.Location = new System.Drawing.Point(19, 138);
            this.lblRepaymentAmount.Name = "lblRepaymentAmount";
            this.lblRepaymentAmount.Size = new System.Drawing.Size(106, 13);
            this.lblRepaymentAmount.TabIndex = 2;
            this.lblRepaymentAmount.Text = "Repayment Amount :";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-2, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(511, 31);
            this.tsbCRUD.TabIndex = 4;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblDate.Location = new System.Drawing.Point(415, 35);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(36, 13);
            this.lblDate.TabIndex = 26;
            this.lblDate.Text = "Date :";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lstNames
            // 
            this.lstNames.FormattingEnabled = true;
            this.lstNames.Location = new System.Drawing.Point(12, 19);
            this.lstNames.Name = "lstNames";
            this.lstNames.Size = new System.Drawing.Size(170, 108);
            this.lstNames.TabIndex = 0;
            // 
            // gpNames
            // 
            this.gpNames.Controls.Add(this.lstNames);
            this.gpNames.Location = new System.Drawing.Point(303, 50);
            this.gpNames.Name = "gpNames";
            this.gpNames.Size = new System.Drawing.Size(193, 138);
            this.gpNames.TabIndex = 28;
            this.gpNames.TabStop = false;
            this.gpNames.Text = "Name(s)";
            // 
            // txtLoanNo
            // 
            this.txtLoanNo.IsSendTabOnEnter = true;
            this.txtLoanNo.Location = new System.Drawing.Point(135, 57);
            this.txtLoanNo.MaxLength = 15;
            this.txtLoanNo.Name = "txtLoanNo";
            this.txtLoanNo.Size = new System.Drawing.Size(141, 20);
            this.txtLoanNo.TabIndex = 1;
            this.txtLoanNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLoanNo_KeyDown);
            this.txtLoanNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLoanNo_KeyPress);
            // 
            // colDRCR
            // 
            this.colDRCR.DataPropertyName = "Name";
            this.colDRCR.HeaderText = "Dr / Cr";
            this.colDRCR.Name = "colDRCR";
            this.colDRCR.ReadOnly = true;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "SAmt";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "LoansDesp";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 150;
            // 
            // colAccountNo
            // 
            this.colAccountNo.DataPropertyName = "AcctNo";
            this.colAccountNo.HeaderText = "Account No";
            this.colAccountNo.Name = "colAccountNo";
            this.colAccountNo.ReadOnly = true;
            // 
            // gvLoanRepayment
            // 
            this.gvLoanRepayment.AllowUserToAddRows = false;
            this.gvLoanRepayment.CausesValidation = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvLoanRepayment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvLoanRepayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvLoanRepayment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.gvLoanRepayment.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvLoanRepayment.EnableHeadersVisualStyles = false;
            this.gvLoanRepayment.IdTSList = null;
            this.gvLoanRepayment.IsEscapeKey = false;
            this.gvLoanRepayment.IsHeaderClick = false;
            this.gvLoanRepayment.Location = new System.Drawing.Point(8, 195);
            this.gvLoanRepayment.Name = "gvLoanRepayment";
            this.gvLoanRepayment.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvLoanRepayment.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gvLoanRepayment.RowHeadersWidth = 25;
            this.gvLoanRepayment.ShowSerialNo = true;
            this.gvLoanRepayment.Size = new System.Drawing.Size(488, 192);
            this.gvLoanRepayment.TabIndex = 25;
            this.gvLoanRepayment.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gvLoanRepayment_DataError);
            // 
            // LOMVEW00027
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 408);
            this.Controls.Add(this.txtLoanNo);
            this.Controls.Add(this.gpNames);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.gvLoanRepayment);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.lblRepaymentAmount);
            this.Controls.Add(this.txtRepaymentAmount);
            this.Controls.Add(this.txtCurrentBalance);
            this.Controls.Add(this.mtxtAccountNo);
            this.Controls.Add(this.lblCurrentBal);
            this.Controls.Add(this.lblAccountNo);
            this.Controls.Add(this.lblLoanNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LOMVEW00027";
            this.Text = "Legal Loan Deposit Entry (Loan) ";
            this.Load += new System.EventHandler(this.LOMVEW00027_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LOMVEW00027_KeyDown);
            this.gpNames.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvLoanRepayment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0003 lblLoanNo;
        private Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblCurrentBal;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Windows.CXClient.Controls.CXC0004 txtCurrentBalance;
        private Windows.CXClient.Controls.CXC0004 txtRepaymentAmount;
        private Windows.CXClient.Controls.CXC0003 lblRepaymentAmount;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0003 lblDate;
        private System.Windows.Forms.ListBox lstNames;
        private System.Windows.Forms.GroupBox gpNames;
        private Windows.CXClient.Controls.CXC0001 txtLoanNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDRCR;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountNo;
        private Windows.CXClient.Controls.AceGridView gvLoanRepayment;
    }
}