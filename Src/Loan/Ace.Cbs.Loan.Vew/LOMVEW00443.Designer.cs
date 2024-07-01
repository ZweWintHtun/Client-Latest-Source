namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00443
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00443));
            this.dtpStartDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.cboRequiredType = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblAcctNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.chkWithoutReversal = new System.Windows.Forms.CheckBox();
            this.chkWithReversal = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboVoucherStatus = new Ace.Windows.CXClient.Controls.CXC0002();
            this.OptSettleDate = new System.Windows.Forms.RadioButton();
            this.cxC00035 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OptTransDate = new System.Windows.Forms.RadioButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblFromDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblToDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.dtpEndDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.cxC00033 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboBranch = new Ace.Windows.CXClient.Controls.CXC0002();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.IsSendTabOnEnter = true;
            this.dtpStartDate.Location = new System.Drawing.Point(153, 118);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(124, 20);
            this.dtpStartDate.TabIndex = 197;
            // 
            // cboRequiredType
            // 
            this.cboRequiredType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboRequiredType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRequiredType.DropDownHeight = 200;
            this.cboRequiredType.FormattingEnabled = true;
            this.cboRequiredType.IntegralHeight = false;
            this.cboRequiredType.IsSendTabOnEnter = true;
            this.cboRequiredType.Items.AddRange(new object[] {
            "ALL",
            "AccountNo"});
            this.cboRequiredType.Location = new System.Drawing.Point(121, 19);
            this.cboRequiredType.Name = "cboRequiredType";
            this.cboRequiredType.Size = new System.Drawing.Size(124, 21);
            this.cboRequiredType.TabIndex = 8;
            this.cboRequiredType.SelectedIndexChanged += new System.EventHandler(this.cboRequiredType_SelectedIndexChanged);
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.Location = new System.Drawing.Point(27, 22);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(80, 13);
            this.cxC00032.TabIndex = 187;
            this.cxC00032.Text = "Account Type :";
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(121, 49);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(179, 20);
            this.mtxtAccountNo.TabIndex = 9;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblAcctNo
            // 
            this.lblAcctNo.AutoSize = true;
            this.lblAcctNo.Location = new System.Drawing.Point(27, 49);
            this.lblAcctNo.Name = "lblAcctNo";
            this.lblAcctNo.Size = new System.Drawing.Size(70, 13);
            this.lblAcctNo.TabIndex = 190;
            this.lblAcctNo.Text = "Account No :";
            // 
            // chkWithoutReversal
            // 
            this.chkWithoutReversal.AutoSize = true;
            this.chkWithoutReversal.Checked = true;
            this.chkWithoutReversal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWithoutReversal.Location = new System.Drawing.Point(29, 24);
            this.chkWithoutReversal.Name = "chkWithoutReversal";
            this.chkWithoutReversal.Size = new System.Drawing.Size(108, 17);
            this.chkWithoutReversal.TabIndex = 10;
            this.chkWithoutReversal.Text = "Without Reversal";
            this.chkWithoutReversal.UseVisualStyleBackColor = true;
            this.chkWithoutReversal.Click += new System.EventHandler(this.chkWithoutReversal_Click);
            // 
            // chkWithReversal
            // 
            this.chkWithReversal.AutoSize = true;
            this.chkWithReversal.Location = new System.Drawing.Point(147, 24);
            this.chkWithReversal.Name = "chkWithReversal";
            this.chkWithReversal.Size = new System.Drawing.Size(96, 17);
            this.chkWithReversal.TabIndex = 11;
            this.chkWithReversal.Text = "With Reversal ";
            this.chkWithReversal.UseVisualStyleBackColor = true;
            this.chkWithReversal.Click += new System.EventHandler(this.chkWithReversal_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkWithoutReversal);
            this.groupBox2.Controls.Add(this.chkWithReversal);
            this.groupBox2.Location = new System.Drawing.Point(33, 367);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(330, 53);
            this.groupBox2.TabIndex = 206;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reversal Type";
            // 
            // cboVoucherStatus
            // 
            this.cboVoucherStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboVoucherStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboVoucherStatus.DropDownHeight = 200;
            this.cboVoucherStatus.FormattingEnabled = true;
            this.cboVoucherStatus.IntegralHeight = false;
            this.cboVoucherStatus.IsSendTabOnEnter = true;
            this.cboVoucherStatus.Items.AddRange(new object[] {
            "ALL",
            "Credit",
            "Debit"});
            this.cboVoucherStatus.Location = new System.Drawing.Point(153, 183);
            this.cboVoucherStatus.Name = "cboVoucherStatus";
            this.cboVoucherStatus.Size = new System.Drawing.Size(124, 21);
            this.cboVoucherStatus.TabIndex = 199;
            // 
            // OptSettleDate
            // 
            this.OptSettleDate.AutoSize = true;
            this.OptSettleDate.Location = new System.Drawing.Point(142, 21);
            this.OptSettleDate.Name = "OptSettleDate";
            this.OptSettleDate.Size = new System.Drawing.Size(101, 17);
            this.OptSettleDate.TabIndex = 7;
            this.OptSettleDate.TabStop = true;
            this.OptSettleDate.Text = "Settlement Date";
            this.OptSettleDate.UseVisualStyleBackColor = true;
            this.OptSettleDate.Click += new System.EventHandler(this.OptSettleDate_Click);
            // 
            // cxC00035
            // 
            this.cxC00035.AutoSize = true;
            this.cxC00035.Location = new System.Drawing.Point(59, 186);
            this.cxC00035.Name = "cxC00035";
            this.cxC00035.Size = new System.Drawing.Size(86, 13);
            this.cxC00035.TabIndex = 207;
            this.cxC00035.Text = "Voucher Stauts :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboRequiredType);
            this.groupBox3.Controls.Add(this.cxC00032);
            this.groupBox3.Controls.Add(this.mtxtAccountNo);
            this.groupBox3.Controls.Add(this.lblAcctNo);
            this.groupBox3.Location = new System.Drawing.Point(33, 281);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(330, 79);
            this.groupBox3.TabIndex = 205;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Account Type";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.OptSettleDate);
            this.groupBox1.Controls.Add(this.OptTransDate);
            this.groupBox1.Location = new System.Drawing.Point(32, 219);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 53);
            this.groupBox1.TabIndex = 204;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date Type";
            // 
            // OptTransDate
            // 
            this.OptTransDate.AutoSize = true;
            this.OptTransDate.Location = new System.Drawing.Point(29, 21);
            this.OptTransDate.Name = "OptTransDate";
            this.OptTransDate.Size = new System.Drawing.Size(107, 17);
            this.OptTransDate.TabIndex = 6;
            this.OptTransDate.TabStop = true;
            this.OptTransDate.Text = "Transaction Date";
            this.OptTransDate.UseVisualStyleBackColor = true;
            this.OptTransDate.Click += new System.EventHandler(this.OptTransDate_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cboCurrency
            // 
            this.cboCurrency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCurrency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCurrency.DropDownHeight = 200;
            this.cboCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrency.FormattingEnabled = true;
            this.cboCurrency.IntegralHeight = false;
            this.cboCurrency.IsSendTabOnEnter = true;
            this.cboCurrency.Location = new System.Drawing.Point(153, 83);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(124, 21);
            this.cboCurrency.TabIndex = 196;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(59, 122);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(61, 13);
            this.lblFromDate.TabIndex = 203;
            this.lblFromDate.Text = "Start Date :";
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(59, 154);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(58, 13);
            this.lblToDate.TabIndex = 202;
            this.lblToDate.Text = "End Date :";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.IsSendTabOnEnter = true;
            this.dtpEndDate.Location = new System.Drawing.Point(153, 151);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(124, 20);
            this.dtpEndDate.TabIndex = 198;
            // 
            // cxC00033
            // 
            this.cxC00033.AutoSize = true;
            this.cxC00033.Location = new System.Drawing.Point(59, 86);
            this.cxC00033.Name = "cxC00033";
            this.cxC00033.Size = new System.Drawing.Size(55, 13);
            this.cxC00033.TabIndex = 201;
            this.cxC00033.Text = "Currency :";
            // 
            // cboBranch
            // 
            this.cboBranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBranch.DropDownHeight = 200;
            this.cboBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBranch.FormattingEnabled = true;
            this.cboBranch.IntegralHeight = false;
            this.cboBranch.IsSendTabOnEnter = true;
            this.cboBranch.Location = new System.Drawing.Point(153, 50);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(124, 21);
            this.cboBranch.TabIndex = 195;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(611, 31);
            this.tsbCRUD.TabIndex = 208;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(59, 50);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(75, 13);
            this.cxC00031.TabIndex = 200;
            this.cxC00031.Text = "Branch Code :";
            // 
            // LOMVEW00443
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 447);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cboVoucherStatus);
            this.Controls.Add(this.cxC00035);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.cxC00033);
            this.Controls.Add(this.cboBranch);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.cxC00031);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00443";
            this.Text = "Transfer Transaction Listing";
            this.Load += new System.EventHandler(this.LOMVEW00443_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0005 dtpStartDate;
        private Windows.CXClient.Controls.CXC0002 cboRequiredType;
        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblAcctNo;
        private System.Windows.Forms.CheckBox chkWithoutReversal;
        private System.Windows.Forms.CheckBox chkWithReversal;
        private System.Windows.Forms.GroupBox groupBox2;
        private Windows.CXClient.Controls.CXC0002 cboVoucherStatus;
        private System.Windows.Forms.RadioButton OptSettleDate;
        private Windows.CXClient.Controls.CXC0003 cxC00035;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton OptTransDate;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0003 lblFromDate;
        private Windows.CXClient.Controls.CXC0003 lblToDate;
        private Windows.CXClient.Controls.CXC0005 dtpEndDate;
        private Windows.CXClient.Controls.CXC0003 cxC00033;
        private Windows.CXClient.Controls.CXC0002 cboBranch;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
    }
}