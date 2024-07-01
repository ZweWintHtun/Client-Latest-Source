namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00071
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00071));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.chkBeforeEditing = new Ace.Windows.CXClient.Controls.CXC0008();
            this.dtpRequireDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.cboCounterNo = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblRequireDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCounterNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.rdoMultiTransactions = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoNotesChange = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoPayment = new Ace.Windows.CXClient.Controls.CXC0009();
            this.gpCashDenomination = new System.Windows.Forms.GroupBox();
            this.rdoReceiptByCounter = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoReceiptRefund = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoReceipt = new Ace.Windows.CXClient.Controls.CXC0009();
            this.dgvCashDenomination = new System.Windows.Forms.DataGridView();
            this.gpCashDenomination.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashDenomination)).BeginInit();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-2, -1);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(498, 31);
            this.tsbCRUD.TabIndex = 11;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(27, 129);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 68;
            this.lblCurrency.Text = "Currency :";
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
            this.cboCurrency.Items.AddRange(new object[] {
            "KYT",
            "FEC",
            "EUR",
            "USD",
            "SGD"});
            this.cboCurrency.Location = new System.Drawing.Point(128, 126);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 7;
            // 
            // chkBeforeEditing
            // 
            this.chkBeforeEditing.AutoSize = true;
            this.chkBeforeEditing.IsSendTabOnEnter = true;
            this.chkBeforeEditing.Location = new System.Drawing.Point(30, 218);
            this.chkBeforeEditing.Name = "chkBeforeEditing";
            this.chkBeforeEditing.Size = new System.Drawing.Size(92, 17);
            this.chkBeforeEditing.TabIndex = 10;
            this.chkBeforeEditing.Text = "Before Editing";
            this.chkBeforeEditing.UseVisualStyleBackColor = true;
            // 
            // dtpRequireDate
            // 
            this.dtpRequireDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpRequireDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRequireDate.IsSendTabOnEnter = true;
            this.dtpRequireDate.Location = new System.Drawing.Point(128, 180);
            this.dtpRequireDate.Name = "dtpRequireDate";
            this.dtpRequireDate.Size = new System.Drawing.Size(115, 20);
            this.dtpRequireDate.TabIndex = 9;
            // 
            // cboCounterNo
            // 
            this.cboCounterNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCounterNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCounterNo.DropDownHeight = 200;
            this.cboCounterNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCounterNo.FormattingEnabled = true;
            this.cboCounterNo.IntegralHeight = false;
            this.cboCounterNo.IsSendTabOnEnter = true;
            this.cboCounterNo.Location = new System.Drawing.Point(128, 153);
            this.cboCounterNo.Name = "cboCounterNo";
            this.cboCounterNo.Size = new System.Drawing.Size(115, 21);
            this.cboCounterNo.TabIndex = 8;
            // 
            // lblRequireDate
            // 
            this.lblRequireDate.AutoSize = true;
            this.lblRequireDate.Location = new System.Drawing.Point(27, 184);
            this.lblRequireDate.Name = "lblRequireDate";
            this.lblRequireDate.Size = new System.Drawing.Size(82, 13);
            this.lblRequireDate.TabIndex = 63;
            this.lblRequireDate.Text = "Required Date :";
            // 
            // lblCounterNo
            // 
            this.lblCounterNo.AutoSize = true;
            this.lblCounterNo.Location = new System.Drawing.Point(27, 156);
            this.lblCounterNo.Name = "lblCounterNo";
            this.lblCounterNo.Size = new System.Drawing.Size(64, 13);
            this.lblCounterNo.TabIndex = 62;
            this.lblCounterNo.Text = "CounterNo :";
            // 
            // rdoMultiTransactions
            // 
            this.rdoMultiTransactions.AutoSize = true;
            this.rdoMultiTransactions.IsSendTabOnEnter = true;
            this.rdoMultiTransactions.Location = new System.Drawing.Point(222, 42);
            this.rdoMultiTransactions.Name = "rdoMultiTransactions";
            this.rdoMultiTransactions.Size = new System.Drawing.Size(111, 17);
            this.rdoMultiTransactions.TabIndex = 6;
            this.rdoMultiTransactions.Text = "Multi Transactions";
            this.rdoMultiTransactions.UseVisualStyleBackColor = true;
            this.rdoMultiTransactions.CheckedChanged += new System.EventHandler(this.rdoMultiTransactions_CheckedChanged);
            // 
            // rdoNotesChange
            // 
            this.rdoNotesChange.AutoSize = true;
            this.rdoNotesChange.IsSendTabOnEnter = true;
            this.rdoNotesChange.Location = new System.Drawing.Point(102, 42);
            this.rdoNotesChange.Name = "rdoNotesChange";
            this.rdoNotesChange.Size = new System.Drawing.Size(93, 17);
            this.rdoNotesChange.TabIndex = 5;
            this.rdoNotesChange.Text = "Notes Change";
            this.rdoNotesChange.UseVisualStyleBackColor = true;
            this.rdoNotesChange.CheckedChanged += new System.EventHandler(this.rdoNotesChange_CheckedChanged);
            // 
            // rdoPayment
            // 
            this.rdoPayment.AutoSize = true;
            this.rdoPayment.IsSendTabOnEnter = true;
            this.rdoPayment.Location = new System.Drawing.Point(19, 42);
            this.rdoPayment.Name = "rdoPayment";
            this.rdoPayment.Size = new System.Drawing.Size(66, 17);
            this.rdoPayment.TabIndex = 4;
            this.rdoPayment.Text = "Payment";
            this.rdoPayment.UseVisualStyleBackColor = true;
            this.rdoPayment.CheckedChanged += new System.EventHandler(this.rdoPayment_CheckedChanged);
            // 
            // gpCashDenomination
            // 
            this.gpCashDenomination.Controls.Add(this.rdoMultiTransactions);
            this.gpCashDenomination.Controls.Add(this.rdoNotesChange);
            this.gpCashDenomination.Controls.Add(this.rdoPayment);
            this.gpCashDenomination.Controls.Add(this.rdoReceiptByCounter);
            this.gpCashDenomination.Controls.Add(this.rdoReceiptRefund);
            this.gpCashDenomination.Controls.Add(this.rdoReceipt);
            this.gpCashDenomination.Location = new System.Drawing.Point(11, 38);
            this.gpCashDenomination.Name = "gpCashDenomination";
            this.gpCashDenomination.Size = new System.Drawing.Size(417, 73);
            this.gpCashDenomination.TabIndex = 0;
            this.gpCashDenomination.TabStop = false;
            this.gpCashDenomination.Text = "Cash Denomination";
            // 
            // rdoReceiptByCounter
            // 
            this.rdoReceiptByCounter.AutoSize = true;
            this.rdoReceiptByCounter.IsSendTabOnEnter = true;
            this.rdoReceiptByCounter.Location = new System.Drawing.Point(222, 19);
            this.rdoReceiptByCounter.Name = "rdoReceiptByCounter";
            this.rdoReceiptByCounter.Size = new System.Drawing.Size(176, 17);
            this.rdoReceiptByCounter.TabIndex = 3;
            this.rdoReceiptByCounter.Text = "Receipt(Withdrawal By Counter)";
            this.rdoReceiptByCounter.UseVisualStyleBackColor = true;
            this.rdoReceiptByCounter.CheckedChanged += new System.EventHandler(this.rdoReceiptByCounter_CheckedChanged);
            // 
            // rdoReceiptRefund
            // 
            this.rdoReceiptRefund.AutoSize = true;
            this.rdoReceiptRefund.IsSendTabOnEnter = true;
            this.rdoReceiptRefund.Location = new System.Drawing.Point(102, 19);
            this.rdoReceiptRefund.Name = "rdoReceiptRefund";
            this.rdoReceiptRefund.Size = new System.Drawing.Size(100, 17);
            this.rdoReceiptRefund.TabIndex = 2;
            this.rdoReceiptRefund.Text = "Receipt Refund";
            this.rdoReceiptRefund.UseVisualStyleBackColor = true;
            this.rdoReceiptRefund.CheckedChanged += new System.EventHandler(this.rdoReceiptRefund_CheckedChanged);
            // 
            // rdoReceipt
            // 
            this.rdoReceipt.AutoSize = true;
            this.rdoReceipt.Checked = true;
            this.rdoReceipt.IsSendTabOnEnter = true;
            this.rdoReceipt.Location = new System.Drawing.Point(19, 19);
            this.rdoReceipt.Name = "rdoReceipt";
            this.rdoReceipt.Size = new System.Drawing.Size(62, 17);
            this.rdoReceipt.TabIndex = 1;
            this.rdoReceipt.TabStop = true;
            this.rdoReceipt.Text = "Receipt";
            this.rdoReceipt.UseVisualStyleBackColor = true;
            this.rdoReceipt.CheckedChanged += new System.EventHandler(this.rdoReceipt_CheckedChanged);
            // 
            // dgvCashDenomination
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCashDenomination.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCashDenomination.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCashDenomination.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCashDenomination.Location = new System.Drawing.Point(250, 180);
            this.dgvCashDenomination.Name = "dgvCashDenomination";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCashDenomination.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCashDenomination.Size = new System.Drawing.Size(22, 19);
            this.dgvCashDenomination.TabIndex = 69;
            this.dgvCashDenomination.Visible = false;
            // 
            // TLMVEW00071
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 250);
            this.Controls.Add(this.dgvCashDenomination);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.lblCurrency);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.chkBeforeEditing);
            this.Controls.Add(this.dtpRequireDate);
            this.Controls.Add(this.cboCounterNo);
            this.Controls.Add(this.lblRequireDate);
            this.Controls.Add(this.lblCounterNo);
            this.Controls.Add(this.gpCashDenomination);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TLMVEW00071";
            this.Text = "Cash Denomination Listing";
            this.Load += new System.EventHandler(this.TLMVEW00071_Load);
            this.gpCashDenomination.ResumeLayout(false);
            this.gpCashDenomination.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashDenomination)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0008 chkBeforeEditing;
        private Windows.CXClient.Controls.CXC0005 dtpRequireDate;
        private Windows.CXClient.Controls.CXC0002 cboCounterNo;
        private Windows.CXClient.Controls.CXC0003 lblRequireDate;
        private Windows.CXClient.Controls.CXC0003 lblCounterNo;
        private Windows.CXClient.Controls.CXC0009 rdoMultiTransactions;
        private Windows.CXClient.Controls.CXC0009 rdoNotesChange;
        private Windows.CXClient.Controls.CXC0009 rdoPayment;
        private System.Windows.Forms.GroupBox gpCashDenomination;
        private Windows.CXClient.Controls.CXC0009 rdoReceiptByCounter;
        private Windows.CXClient.Controls.CXC0009 rdoReceiptRefund;
        private Windows.CXClient.Controls.CXC0009 rdoReceipt;
        private System.Windows.Forms.DataGridView dgvCashDenomination;
    }
}