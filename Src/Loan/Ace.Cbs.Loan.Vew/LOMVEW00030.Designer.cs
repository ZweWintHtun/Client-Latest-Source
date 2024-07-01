namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00030
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00030));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblLastRepaymentNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblNewRepaymentAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtLastRepaymentNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.gvAccountList = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvColAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvColDebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvColCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvColDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotalInterest = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gbRepayment = new System.Windows.Forms.GroupBox();
            this.txtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtLastRepaymentAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtAfterNewRepaymentSanctionAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtAfterLastRepaymentSanctionAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtBeforeLastRepaymentSanctionAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblAfterNewPayment = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAfterLastRepayment = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblBeforeLastRepayment = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblLastRepaymentAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtLoanNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtTotalInterest = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtNewRepaymentAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtDateTime = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblDate = new Ace.Windows.CXClient.Controls.CXC0003();
            ((System.ComponentModel.ISupportInitialize)(this.gvAccountList)).BeginInit();
            this.gbRepayment.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(636, 31);
            this.tsbCRUD.TabIndex = 20;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblLastRepaymentNo
            // 
            this.lblLastRepaymentNo.AutoSize = true;
            this.lblLastRepaymentNo.Location = new System.Drawing.Point(15, 73);
            this.lblLastRepaymentNo.Name = "lblLastRepaymentNo";
            this.lblLastRepaymentNo.Size = new System.Drawing.Size(113, 13);
            this.lblLastRepaymentNo.TabIndex = 21;
            this.lblLastRepaymentNo.Text = "Last Repayment No.  :";
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(15, 49);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(73, 13);
            this.lblAccountNo.TabIndex = 23;
            this.lblAccountNo.Text = "Account No. :";
            // 
            // lblNewRepaymentAmount
            // 
            this.lblNewRepaymentAmount.AutoSize = true;
            this.lblNewRepaymentAmount.Location = new System.Drawing.Point(15, 244);
            this.lblNewRepaymentAmount.Name = "lblNewRepaymentAmount";
            this.lblNewRepaymentAmount.Size = new System.Drawing.Size(134, 13);
            this.lblNewRepaymentAmount.TabIndex = 26;
            this.lblNewRepaymentAmount.Text = "New Repayment Amount  :";
            // 
            // txtLastRepaymentNo
            // 
            this.txtLastRepaymentNo.Enabled = false;
            this.txtLastRepaymentNo.IsSendTabOnEnter = true;
            this.txtLastRepaymentNo.Location = new System.Drawing.Point(166, 70);
            this.txtLastRepaymentNo.MaxLength = 3;
            this.txtLastRepaymentNo.Name = "txtLastRepaymentNo";
            this.txtLastRepaymentNo.Size = new System.Drawing.Size(121, 20);
            this.txtLastRepaymentNo.TabIndex = 27;
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
            this.gvAccountList.EnableHeadersVisualStyles = false;
            this.gvAccountList.IdTSList = null;
            this.gvAccountList.IsEscapeKey = false;
            this.gvAccountList.IsHeaderClick = false;
            this.gvAccountList.Location = new System.Drawing.Point(10, 342);
            this.gvAccountList.Name = "gvAccountList";
            this.gvAccountList.ReadOnly = true;
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
            this.gvAccountList.Size = new System.Drawing.Size(601, 170);
            this.gvAccountList.TabIndex = 33;
            // 
            // colTS
            // 
            this.colTS.DataPropertyName = "TS";
            this.colTS.HeaderText = "TS";
            this.colTS.Name = "colTS";
            this.colTS.ReadOnly = true;
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
            this.gvColDebit.Width = 110;
            // 
            // gvColCredit
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.gvColCredit.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvColCredit.HeaderText = "Credit";
            this.gvColCredit.Name = "gvColCredit";
            this.gvColCredit.ReadOnly = true;
            this.gvColCredit.Width = 110;
            // 
            // gvColDescription
            // 
            this.gvColDescription.HeaderText = "Description";
            this.gvColDescription.Name = "gvColDescription";
            this.gvColDescription.ReadOnly = true;
            this.gvColDescription.Width = 200;
            // 
            // lblTotalInterest
            // 
            this.lblTotalInterest.AutoSize = true;
            this.lblTotalInterest.Location = new System.Drawing.Point(14, 271);
            this.lblTotalInterest.Name = "lblTotalInterest";
            this.lblTotalInterest.Size = new System.Drawing.Size(78, 13);
            this.lblTotalInterest.TabIndex = 34;
            this.lblTotalInterest.Text = "Total Interest  :";
            // 
            // gbRepayment
            // 
            this.gbRepayment.Controls.Add(this.txtAccountNo);
            this.gbRepayment.Controls.Add(this.txtLastRepaymentAmount);
            this.gbRepayment.Controls.Add(this.groupBox2);
            this.gbRepayment.Controls.Add(this.lblLastRepaymentAmount);
            this.gbRepayment.Controls.Add(this.txtLoanNo);
            this.gbRepayment.Controls.Add(this.cxC00031);
            this.gbRepayment.Controls.Add(this.txtTotalInterest);
            this.gbRepayment.Controls.Add(this.lblLastRepaymentNo);
            this.gbRepayment.Controls.Add(this.txtNewRepaymentAmount);
            this.gbRepayment.Controls.Add(this.txtLastRepaymentNo);
            this.gbRepayment.Controls.Add(this.lblTotalInterest);
            this.gbRepayment.Controls.Add(this.lblAccountNo);
            this.gbRepayment.Controls.Add(this.lblNewRepaymentAmount);
            this.gbRepayment.Location = new System.Drawing.Point(10, 37);
            this.gbRepayment.Name = "gbRepayment";
            this.gbRepayment.Size = new System.Drawing.Size(339, 294);
            this.gbRepayment.TabIndex = 0;
            this.gbRepayment.TabStop = false;
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.Enabled = false;
            this.txtAccountNo.IsSendTabOnEnter = true;
            this.txtAccountNo.Location = new System.Drawing.Point(166, 45);
            this.txtAccountNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.Size = new System.Drawing.Size(135, 20);
            this.txtAccountNo.TabIndex = 108;
            this.txtAccountNo.TabStop = false;
            // 
            // txtLastRepaymentAmount
            // 
            this.txtLastRepaymentAmount.DecimalPlaces = 0;
            this.txtLastRepaymentAmount.Enabled = false;
            this.txtLastRepaymentAmount.IsSendTabOnEnter = true;
            this.txtLastRepaymentAmount.Location = new System.Drawing.Point(166, 95);
            this.txtLastRepaymentAmount.Name = "txtLastRepaymentAmount";
            this.txtLastRepaymentAmount.Size = new System.Drawing.Size(141, 20);
            this.txtLastRepaymentAmount.TabIndex = 107;
            this.txtLastRepaymentAmount.Text = "0.00";
            this.txtLastRepaymentAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLastRepaymentAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtAfterNewRepaymentSanctionAmount);
            this.groupBox2.Controls.Add(this.txtAfterLastRepaymentSanctionAmount);
            this.groupBox2.Controls.Add(this.txtBeforeLastRepaymentSanctionAmount);
            this.groupBox2.Controls.Add(this.lblAfterNewPayment);
            this.groupBox2.Controls.Add(this.lblAfterLastRepayment);
            this.groupBox2.Controls.Add(this.lblBeforeLastRepayment);
            this.groupBox2.Location = new System.Drawing.Point(6, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 103);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sanction Amount";
            // 
            // txtAfterNewRepaymentSanctionAmount
            // 
            this.txtAfterNewRepaymentSanctionAmount.DecimalPlaces = 0;
            this.txtAfterNewRepaymentSanctionAmount.Enabled = false;
            this.txtAfterNewRepaymentSanctionAmount.IsSendTabOnEnter = true;
            this.txtAfterNewRepaymentSanctionAmount.Location = new System.Drawing.Point(160, 70);
            this.txtAfterNewRepaymentSanctionAmount.Name = "txtAfterNewRepaymentSanctionAmount";
            this.txtAfterNewRepaymentSanctionAmount.Size = new System.Drawing.Size(141, 20);
            this.txtAfterNewRepaymentSanctionAmount.TabIndex = 108;
            this.txtAfterNewRepaymentSanctionAmount.Text = "0.00";
            this.txtAfterNewRepaymentSanctionAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAfterNewRepaymentSanctionAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtAfterLastRepaymentSanctionAmount
            // 
            this.txtAfterLastRepaymentSanctionAmount.DecimalPlaces = 0;
            this.txtAfterLastRepaymentSanctionAmount.Enabled = false;
            this.txtAfterLastRepaymentSanctionAmount.IsSendTabOnEnter = true;
            this.txtAfterLastRepaymentSanctionAmount.Location = new System.Drawing.Point(160, 45);
            this.txtAfterLastRepaymentSanctionAmount.Name = "txtAfterLastRepaymentSanctionAmount";
            this.txtAfterLastRepaymentSanctionAmount.Size = new System.Drawing.Size(141, 20);
            this.txtAfterLastRepaymentSanctionAmount.TabIndex = 107;
            this.txtAfterLastRepaymentSanctionAmount.Text = "0.00";
            this.txtAfterLastRepaymentSanctionAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAfterLastRepaymentSanctionAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtBeforeLastRepaymentSanctionAmount
            // 
            this.txtBeforeLastRepaymentSanctionAmount.DecimalPlaces = 0;
            this.txtBeforeLastRepaymentSanctionAmount.Enabled = false;
            this.txtBeforeLastRepaymentSanctionAmount.IsSendTabOnEnter = true;
            this.txtBeforeLastRepaymentSanctionAmount.Location = new System.Drawing.Point(160, 20);
            this.txtBeforeLastRepaymentSanctionAmount.Name = "txtBeforeLastRepaymentSanctionAmount";
            this.txtBeforeLastRepaymentSanctionAmount.Size = new System.Drawing.Size(141, 20);
            this.txtBeforeLastRepaymentSanctionAmount.TabIndex = 106;
            this.txtBeforeLastRepaymentSanctionAmount.Text = "0.00";
            this.txtBeforeLastRepaymentSanctionAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBeforeLastRepaymentSanctionAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblAfterNewPayment
            // 
            this.lblAfterNewPayment.AutoSize = true;
            this.lblAfterNewPayment.Location = new System.Drawing.Point(19, 74);
            this.lblAfterNewPayment.Name = "lblAfterNewPayment";
            this.lblAfterNewPayment.Size = new System.Drawing.Size(117, 13);
            this.lblAfterNewPayment.TabIndex = 105;
            this.lblAfterNewPayment.Text = "After New Repayment :";
            // 
            // lblAfterLastRepayment
            // 
            this.lblAfterLastRepayment.AutoSize = true;
            this.lblAfterLastRepayment.Location = new System.Drawing.Point(19, 49);
            this.lblAfterLastRepayment.Name = "lblAfterLastRepayment";
            this.lblAfterLastRepayment.Size = new System.Drawing.Size(115, 13);
            this.lblAfterLastRepayment.TabIndex = 104;
            this.lblAfterLastRepayment.Text = "After Last Repayment :";
            // 
            // lblBeforeLastRepayment
            // 
            this.lblBeforeLastRepayment.AutoSize = true;
            this.lblBeforeLastRepayment.Location = new System.Drawing.Point(19, 23);
            this.lblBeforeLastRepayment.Name = "lblBeforeLastRepayment";
            this.lblBeforeLastRepayment.Size = new System.Drawing.Size(124, 13);
            this.lblBeforeLastRepayment.TabIndex = 103;
            this.lblBeforeLastRepayment.Text = "Before Last Repayment :";
            // 
            // lblLastRepaymentAmount
            // 
            this.lblLastRepaymentAmount.AutoSize = true;
            this.lblLastRepaymentAmount.Location = new System.Drawing.Point(15, 98);
            this.lblLastRepaymentAmount.Name = "lblLastRepaymentAmount";
            this.lblLastRepaymentAmount.Size = new System.Drawing.Size(132, 13);
            this.lblLastRepaymentAmount.TabIndex = 101;
            this.lblLastRepaymentAmount.Text = "Last Repayment Amount  :";
            // 
            // txtLoanNo
            // 
            this.txtLoanNo.IsSendTabOnEnter = true;
            this.txtLoanNo.Location = new System.Drawing.Point(166, 20);
            this.txtLoanNo.MaxLength = 15;
            this.txtLoanNo.Name = "txtLoanNo";
            this.txtLoanNo.Size = new System.Drawing.Size(121, 20);
            this.txtLoanNo.TabIndex = 1;
            this.txtLoanNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLoanNo_KeyPress);
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(15, 24);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(60, 13);
            this.cxC00031.TabIndex = 74;
            this.cxC00031.Text = "Loan No.  :";
            // 
            // txtTotalInterest
            // 
            this.txtTotalInterest.DecimalPlaces = 0;
            this.txtTotalInterest.Enabled = false;
            this.txtTotalInterest.IsSendTabOnEnter = true;
            this.txtTotalInterest.Location = new System.Drawing.Point(166, 266);
            this.txtTotalInterest.Name = "txtTotalInterest";
            this.txtTotalInterest.ReadOnly = true;
            this.txtTotalInterest.Size = new System.Drawing.Size(141, 20);
            this.txtTotalInterest.TabIndex = 73;
            this.txtTotalInterest.Text = "0.00";
            this.txtTotalInterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalInterest.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtNewRepaymentAmount
            // 
            this.txtNewRepaymentAmount.DecimalPlaces = 0;
            this.txtNewRepaymentAmount.Enabled = false;
            this.txtNewRepaymentAmount.IsSendTabOnEnter = true;
            this.txtNewRepaymentAmount.Location = new System.Drawing.Point(166, 241);
            this.txtNewRepaymentAmount.Name = "txtNewRepaymentAmount";
            this.txtNewRepaymentAmount.Size = new System.Drawing.Size(141, 20);
            this.txtNewRepaymentAmount.TabIndex = 72;
            this.txtNewRepaymentAmount.Text = "0.00";
            this.txtNewRepaymentAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNewRepaymentAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Location = new System.Drawing.Point(355, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 245);
            this.groupBox1.TabIndex = 37;
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
            this.txtDateTime.Location = new System.Drawing.Point(540, 57);
            this.txtDateTime.Name = "txtDateTime";
            this.txtDateTime.Size = new System.Drawing.Size(10, 13);
            this.txtDateTime.TabIndex = 39;
            this.txtDateTime.Text = "-";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblDate.Location = new System.Drawing.Point(495, 57);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(36, 13);
            this.lblDate.TabIndex = 38;
            this.lblDate.Text = "Date :";
            // 
            // LOMVEW00030
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 521);
            this.Controls.Add(this.txtDateTime);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbRepayment);
            this.Controls.Add(this.gvAccountList);
            this.Controls.Add(this.tsbCRUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LOMVEW00030";
            this.Text = "LOMVEW00030";
            this.Load += new System.EventHandler(this.LOMVEW00030_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LOMVEW00025_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gvAccountList)).EndInit();
            this.gbRepayment.ResumeLayout(false);
            this.gbRepayment.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0003 lblLastRepaymentNo;
        private Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblNewRepaymentAmount;
        private Windows.CXClient.Controls.CXC0001 txtLastRepaymentNo;
        private Windows.CXClient.Controls.AceGridView gvAccountList;
        private Windows.CXClient.Controls.CXC0003 lblTotalInterest;
        private System.Windows.Forms.GroupBox gbRepayment;
        private System.Windows.Forms.GroupBox groupBox1;
        private Windows.CXClient.Controls.CXC0003 lblName;
        private Windows.CXClient.Controls.CXC0004 txtNewRepaymentAmount;
        private Windows.CXClient.Controls.CXC0004 txtTotalInterest;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0001 txtLoanNo;
        private Windows.CXClient.Controls.CXC0003 lblLastRepaymentAmount;
        private Windows.CXClient.Controls.CXC0004 txtLastRepaymentAmount;
        private Windows.CXClient.Controls.CXC0003 txtDateTime;
        private Windows.CXClient.Controls.CXC0003 lblDate;
        private System.Windows.Forms.GroupBox groupBox2;
        private Windows.CXClient.Controls.CXC0004 txtAfterNewRepaymentSanctionAmount;
        private Windows.CXClient.Controls.CXC0004 txtAfterLastRepaymentSanctionAmount;
        private Windows.CXClient.Controls.CXC0004 txtBeforeLastRepaymentSanctionAmount;
        private Windows.CXClient.Controls.CXC0003 lblAfterNewPayment;
        private Windows.CXClient.Controls.CXC0003 lblAfterLastRepayment;
        private Windows.CXClient.Controls.CXC0003 lblBeforeLastRepayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvColAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvColDebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvColCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvColDescription;
        private Windows.CXClient.Controls.CXC0006 txtAccountNo;
    }
}