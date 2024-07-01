namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00021
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00021));
            this.gbClearingVoucher = new System.Windows.Forms.GroupBox();
            this.txtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtNarration = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblNarration = new Ace.Windows.CXClient.Controls.CXC0003();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gvClearingVoucher = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVoucherType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNarration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.butSwitch = new System.Windows.Forms.Button();
            this.txtDescription = new Ace.Windows.CXClient.Controls.CXC0001();
            this.gbVoucherType = new System.Windows.Forms.GroupBox();
            this.rdoCredit = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoDebit = new Ace.Windows.CXClient.Controls.CXC0009();
            this.lblDescription = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtVoucherNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblVoucherNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gbClearingVoucher.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvClearingVoucher)).BeginInit();
            this.gbVoucherType.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbClearingVoucher
            // 
            this.gbClearingVoucher.Controls.Add(this.txtAmount);
            this.gbClearingVoucher.Controls.Add(this.txtNarration);
            this.gbClearingVoucher.Controls.Add(this.lblAccountNo);
            this.gbClearingVoucher.Controls.Add(this.lblNarration);
            this.gbClearingVoucher.Controls.Add(this.mtxtAccountNo);
            this.gbClearingVoucher.Controls.Add(this.lblAmount);
            this.gbClearingVoucher.Controls.Add(this.cboCurrency);
            this.gbClearingVoucher.Controls.Add(this.lblCurrency);
            this.gbClearingVoucher.Controls.Add(this.gvClearingVoucher);
            this.gbClearingVoucher.Controls.Add(this.butSwitch);
            this.gbClearingVoucher.Controls.Add(this.txtDescription);
            this.gbClearingVoucher.Controls.Add(this.gbVoucherType);
            this.gbClearingVoucher.Controls.Add(this.lblDescription);
            this.gbClearingVoucher.Controls.Add(this.txtVoucherNo);
            this.gbClearingVoucher.Controls.Add(this.lblVoucherNo);
            this.gbClearingVoucher.Location = new System.Drawing.Point(12, 37);
            this.gbClearingVoucher.Name = "gbClearingVoucher";
            this.gbClearingVoucher.Size = new System.Drawing.Size(768, 522);
            this.gbClearingVoucher.TabIndex = 0;
            this.gbClearingVoucher.TabStop = false;
            this.gbClearingVoucher.Text = "Clearing Voucher";
            // 
            // txtAmount
            // 
            this.txtAmount.DecimalPlaces = 2;
            this.txtAmount.IsSendTabOnEnter = true;
            this.txtAmount.Location = new System.Drawing.Point(393, 53);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(111, 20);
            this.txtAmount.TabIndex = 6;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtNarration
            // 
            this.txtNarration.IsSendTabOnEnter = true;
            this.txtNarration.Location = new System.Drawing.Point(393, 84);
            this.txtNarration.MaxLength = 40;
            this.txtNarration.Multiline = true;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(175, 42);
            this.txtNarration.TabIndex = 7;
            this.txtNarration.Validated += new System.EventHandler(this.txtNarration_Validated);
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(20, 53);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(67, 13);
            this.lblAccountNo.TabIndex = 26;
            this.lblAccountNo.Text = "AccountNo :";
            // 
            // lblNarration
            // 
            this.lblNarration.AutoSize = true;
            this.lblNarration.Location = new System.Drawing.Point(314, 84);
            this.lblNarration.Name = "lblNarration";
            this.lblNarration.Size = new System.Drawing.Size(56, 13);
            this.lblNarration.TabIndex = 42;
            this.lblNarration.Text = "Narration :";
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(107, 53);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 3;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtxtAccountNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtAccountNo_KeyPress);
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(314, 51);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(49, 13);
            this.lblAmount.TabIndex = 41;
            this.lblAmount.Text = "Amount :";
            // 
            // cboCurrency
            // 
            this.cboCurrency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboCurrency.DropDownHeight = 200;
            this.cboCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrency.FormattingEnabled = true;
            this.cboCurrency.IntegralHeight = false;
            this.cboCurrency.IsSendTabOnEnter = true;
            this.cboCurrency.Location = new System.Drawing.Point(107, 23);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 2;
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(20, 23);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(58, 13);
            this.lblCurrency.TabIndex = 40;
            this.lblCurrency.Text = "Currency  :";
            // 
            // gvClearingVoucher
            // 
            this.gvClearingVoucher.AllowUserToAddRows = false;
            this.gvClearingVoucher.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvClearingVoucher.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvClearingVoucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvClearingVoucher.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAccountNo,
            this.colDescription,
            this.colVoucherType,
            this.colCurrency,
            this.colAmount,
            this.colNarration});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvClearingVoucher.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvClearingVoucher.EnableHeadersVisualStyles = false;
            this.gvClearingVoucher.IdTSList = null;
            this.gvClearingVoucher.IsEscapeKey = false;
            this.gvClearingVoucher.IsHeaderClick = false;
            this.gvClearingVoucher.Location = new System.Drawing.Point(20, 208);
            this.gvClearingVoucher.Name = "gvClearingVoucher";
            this.gvClearingVoucher.RowHeadersWidth = 25;
            this.gvClearingVoucher.ShowSerialNo = true;
            this.gvClearingVoucher.Size = new System.Drawing.Size(731, 272);
            this.gvClearingVoucher.TabIndex = 11;
            // 
            // colAccountNo
            // 
            this.colAccountNo.DataPropertyName = "AccountNo";
            this.colAccountNo.HeaderText = "Account   No";
            this.colAccountNo.Name = "colAccountNo";
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 125;
            // 
            // colVoucherType
            // 
            this.colVoucherType.DataPropertyName = "VoucherType";
            this.colVoucherType.HeaderText = "Voucher Type";
            this.colVoucherType.Name = "colVoucherType";
            // 
            // colCurrency
            // 
            this.colCurrency.DataPropertyName = "CurrencyCode";
            this.colCurrency.HeaderText = "Currency";
            this.colCurrency.Name = "colCurrency";
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            // 
            // colNarration
            // 
            this.colNarration.DataPropertyName = "Narration";
            this.colNarration.HeaderText = "Narration";
            this.colNarration.Name = "colNarration";
            this.colNarration.Width = 150;
            // 
            // butSwitch
            // 
            this.butSwitch.Image = ((System.Drawing.Image)(resources.GetObject("butSwitch.Image")));
            this.butSwitch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSwitch.Location = new System.Drawing.Point(676, 172);
            this.butSwitch.Name = "butSwitch";
            this.butSwitch.Size = new System.Drawing.Size(75, 30);
            this.butSwitch.TabIndex = 9;
            this.butSwitch.Text = "&Switch";
            this.butSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butSwitch.UseVisualStyleBackColor = true;
            this.butSwitch.Click += new System.EventHandler(this.butSwitch_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.IsSendTabOnEnter = true;
            this.txtDescription.Location = new System.Drawing.Point(107, 84);
            this.txtDescription.MaxLength = 40;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(175, 42);
            this.txtDescription.TabIndex = 4;
            // 
            // gbVoucherType
            // 
            this.gbVoucherType.Controls.Add(this.rdoCredit);
            this.gbVoucherType.Controls.Add(this.rdoDebit);
            this.gbVoucherType.Location = new System.Drawing.Point(23, 141);
            this.gbVoucherType.Name = "gbVoucherType";
            this.gbVoucherType.Size = new System.Drawing.Size(265, 45);
            this.gbVoucherType.TabIndex = 33;
            this.gbVoucherType.TabStop = false;
            this.gbVoucherType.Text = "Voucher Type";
            // 
            // rdoCredit
            // 
            this.rdoCredit.AutoSize = true;
            this.rdoCredit.IsSendTabOnEnter = true;
            this.rdoCredit.Location = new System.Drawing.Point(133, 18);
            this.rdoCredit.Name = "rdoCredit";
            this.rdoCredit.Size = new System.Drawing.Size(52, 17);
            this.rdoCredit.TabIndex = 8;
            this.rdoCredit.Text = "Credit";
            this.rdoCredit.UseVisualStyleBackColor = true;
            // 
            // rdoDebit
            // 
            this.rdoDebit.AutoSize = true;
            this.rdoDebit.Checked = true;
            this.rdoDebit.IsSendTabOnEnter = true;
            this.rdoDebit.Location = new System.Drawing.Point(30, 19);
            this.rdoDebit.Name = "rdoDebit";
            this.rdoDebit.Size = new System.Drawing.Size(50, 17);
            this.rdoDebit.TabIndex = 8;
            this.rdoDebit.TabStop = true;
            this.rdoDebit.Text = "Debit";
            this.rdoDebit.UseVisualStyleBackColor = true;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(20, 84);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(66, 13);
            this.lblDescription.TabIndex = 27;
            this.lblDescription.Text = "Description :";
            // 
            // txtVoucherNo
            // 
            this.txtVoucherNo.Enabled = false;
            this.txtVoucherNo.IsSendTabOnEnter = true;
            this.txtVoucherNo.Location = new System.Drawing.Point(393, 20);
            this.txtVoucherNo.Mask = "999-999-9999999";
            this.txtVoucherNo.Name = "txtVoucherNo";
            this.txtVoucherNo.Size = new System.Drawing.Size(141, 20);
            this.txtVoucherNo.TabIndex = 5;
            this.txtVoucherNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtVoucherNo.UseWaitCursor = true;
            // 
            // lblVoucherNo
            // 
            this.lblVoucherNo.AutoSize = true;
            this.lblVoucherNo.Location = new System.Drawing.Point(314, 23);
            this.lblVoucherNo.Name = "lblVoucherNo";
            this.lblVoucherNo.Size = new System.Drawing.Size(67, 13);
            this.lblVoucherNo.TabIndex = 25;
            this.lblVoucherNo.Text = "VoucherNo :";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(2, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(997, 31);
            this.tsbCRUD.TabIndex = 10;
            this.tsbCRUD.NewButtonClick += new System.EventHandler(this.tsbCRUD_NewButtonClick);
            this.tsbCRUD.EditButtonClick += new System.EventHandler(this.tsbCRUD_EditButtonClick);
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // TLMVEW00021
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 571);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.gbClearingVoucher);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00021";
            this.Text = "Clearing Voucher Entry";
            this.Load += new System.EventHandler(this.TLMVEW00021_Load);
            this.gbClearingVoucher.ResumeLayout(false);
            this.gbClearingVoucher.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvClearingVoucher)).EndInit();
            this.gbVoucherType.ResumeLayout(false);
            this.gbVoucherType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbClearingVoucher;
        private System.Windows.Forms.Button butSwitch;
        private Windows.CXClient.Controls.CXC0001 txtDescription;
        private System.Windows.Forms.GroupBox gbVoucherType;
        private Windows.CXClient.Controls.CXC0009 rdoCredit;
        private Windows.CXClient.Controls.CXC0009 rdoDebit;
        private Windows.CXClient.Controls.CXC0003 lblDescription;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Windows.CXClient.Controls.CXC0006 txtVoucherNo;
        private Windows.CXClient.Controls.CXC0003 lblVoucherNo;
        private Windows.CXClient.Controls.AceGridView gvClearingVoucher;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0004 txtAmount;
        private Windows.CXClient.Controls.CXC0001 txtNarration;
        private Windows.CXClient.Controls.CXC0003 lblNarration;
        private Windows.CXClient.Controls.CXC0003 lblAmount;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0003 lblCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVoucherType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNarration;

    }
}