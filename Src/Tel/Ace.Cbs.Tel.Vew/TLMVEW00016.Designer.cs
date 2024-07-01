namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00016
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00016));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gbPaymentDetail = new System.Windows.Forms.GroupBox();
            this.lblTransactionDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00037 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtPaymentOrderNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.gvPaymentOrder = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colPaymentOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBudgetYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegisterNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrencyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.butAdd = new Ace.Windows.CXClient.Controls.CXC0007();
            this.txtTotalAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.txtBudgetYear = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtRegisterNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtGroupNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.cxC00036 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00035 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00034 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00033 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblVoucherNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gbPaymentDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPaymentOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.CausesValidation = false;
            this.tsbCRUD.Location = new System.Drawing.Point(1, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(736, 31);
            this.tsbCRUD.TabIndex = 4;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // gbPaymentDetail
            // 
            this.gbPaymentDetail.Controls.Add(this.lblTransactionDate);
            this.gbPaymentDetail.Controls.Add(this.cxC00037);
            this.gbPaymentDetail.Controls.Add(this.txtPaymentOrderNo);
            this.gbPaymentDetail.Controls.Add(this.gvPaymentOrder);
            this.gbPaymentDetail.Controls.Add(this.butAdd);
            this.gbPaymentDetail.Controls.Add(this.txtTotalAmount);
            this.gbPaymentDetail.Controls.Add(this.txtAmount);
            this.gbPaymentDetail.Controls.Add(this.cboCurrency);
            this.gbPaymentDetail.Controls.Add(this.txtBudgetYear);
            this.gbPaymentDetail.Controls.Add(this.txtRegisterNo);
            this.gbPaymentDetail.Controls.Add(this.txtGroupNo);
            this.gbPaymentDetail.Controls.Add(this.cxC00036);
            this.gbPaymentDetail.Controls.Add(this.cxC00035);
            this.gbPaymentDetail.Controls.Add(this.cxC00034);
            this.gbPaymentDetail.Controls.Add(this.cxC00033);
            this.gbPaymentDetail.Controls.Add(this.cxC00032);
            this.gbPaymentDetail.Controls.Add(this.cxC00031);
            this.gbPaymentDetail.Controls.Add(this.lblVoucherNo);
            this.gbPaymentDetail.Location = new System.Drawing.Point(8, 37);
            this.gbPaymentDetail.Name = "gbPaymentDetail";
            this.gbPaymentDetail.Size = new System.Drawing.Size(713, 430);
            this.gbPaymentDetail.TabIndex = 0;
            this.gbPaymentDetail.TabStop = false;
            // 
            // lblTransactionDate
            // 
            this.lblTransactionDate.AutoSize = true;
            this.lblTransactionDate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblTransactionDate.Location = new System.Drawing.Point(638, 16);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Size = new System.Drawing.Size(0, 13);
            this.lblTransactionDate.TabIndex = 14;
            // 
            // cxC00037
            // 
            this.cxC00037.AutoSize = true;
            this.cxC00037.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.cxC00037.Location = new System.Drawing.Point(537, 16);
            this.cxC00037.Name = "cxC00037";
            this.cxC00037.Size = new System.Drawing.Size(95, 13);
            this.cxC00037.TabIndex = 13;
            this.cxC00037.Text = "Transaction Date :";
            // 
            // txtPaymentOrderNo
            // 
            this.txtPaymentOrderNo.IsSendTabOnEnter = true;
            this.txtPaymentOrderNo.Location = new System.Drawing.Point(124, 80);
            this.txtPaymentOrderNo.MaxLength = 16;
            this.txtPaymentOrderNo.Name = "txtPaymentOrderNo";
            this.txtPaymentOrderNo.Size = new System.Drawing.Size(141, 20);
            this.txtPaymentOrderNo.TabIndex = 1;
            this.txtPaymentOrderNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPaymentOrderNo_KeyPress);
            // 
            // gvPaymentOrder
            // 
            this.gvPaymentOrder.AllowUserToAddRows = false;
            this.gvPaymentOrder.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gvPaymentOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvPaymentOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPaymentOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPaymentOrderNo,
            this.colBudgetYear,
            this.colRegisterNo,
            this.colAmount,
            this.colCurrencyCode,
            this.colEdit,
            this.colDelete});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvPaymentOrder.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvPaymentOrder.EnableHeadersVisualStyles = false;
            this.gvPaymentOrder.IdTSList = null;
            this.gvPaymentOrder.IsEscapeKey = false;
            this.gvPaymentOrder.IsHeaderClick = false;
            this.gvPaymentOrder.Location = new System.Drawing.Point(15, 200);
            this.gvPaymentOrder.Name = "gvPaymentOrder";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvPaymentOrder.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gvPaymentOrder.RowHeadersWidth = 25;
            this.gvPaymentOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvPaymentOrder.ShowSerialNo = false;
            this.gvPaymentOrder.Size = new System.Drawing.Size(677, 214);
            this.gvPaymentOrder.TabIndex = 3;
            this.gvPaymentOrder.TabStop = false;
            this.gvPaymentOrder.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvPaymentOrder_CellClick);
            this.gvPaymentOrder.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gvPaymentOrder_DataError);
            // 
            // colPaymentOrderNo
            // 
            this.colPaymentOrderNo.DataPropertyName = "PaymentOrderNo";
            this.colPaymentOrderNo.HeaderText = "Dealer Payment No";
            this.colPaymentOrderNo.Name = "colPaymentOrderNo";
            this.colPaymentOrderNo.ReadOnly = true;
            this.colPaymentOrderNo.Width = 150;
            // 
            // colBudgetYear
            // 
            this.colBudgetYear.DataPropertyName = "BudgetYear";
            this.colBudgetYear.HeaderText = "Budget Year";
            this.colBudgetYear.Name = "colBudgetYear";
            this.colBudgetYear.ReadOnly = true;
            this.colBudgetYear.Width = 110;
            // 
            // colRegisterNo
            // 
            this.colRegisterNo.DataPropertyName = "RegisterNo";
            this.colRegisterNo.HeaderText = "Register No";
            this.colRegisterNo.Name = "colRegisterNo";
            this.colRegisterNo.ReadOnly = true;
            this.colRegisterNo.Width = 120;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Width = 110;
            // 
            // colCurrencyCode
            // 
            this.colCurrencyCode.DataPropertyName = "CurrencyCode";
            this.colCurrencyCode.HeaderText = "CurrencyCode";
            this.colCurrencyCode.Name = "colCurrencyCode";
            this.colCurrencyCode.ReadOnly = true;
            // 
            // colEdit
            // 
            this.colEdit.HeaderText = "";
            this.colEdit.Image = global::Ace.Cbs.Tel.Vew.Properties.Resources.edit;
            this.colEdit.Name = "colEdit";
            this.colEdit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colEdit.ToolTipText = "Edit";
            this.colEdit.Width = 30;
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "";
            this.colDelete.Image = global::Ace.Cbs.Tel.Vew.Properties.Resources.Delete_Main;
            this.colDelete.Name = "colDelete";
            this.colDelete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDelete.ToolTipText = "Delete";
            this.colDelete.Width = 30;
            // 
            // butAdd
            // 
            this.butAdd.Image = ((System.Drawing.Image)(resources.GetObject("butAdd.Image")));
            this.butAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAdd.Location = new System.Drawing.Point(632, 159);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(60, 30);
            this.butAdd.TabIndex = 3;
            this.butAdd.Text = "&Add";
            this.butAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.DecimalPlaces = 2;
            this.txtTotalAmount.IsSendTabOnEnter = true;
            this.txtTotalAmount.Location = new System.Drawing.Point(124, 137);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(111, 20);
            this.txtTotalAmount.TabIndex = 6;
            this.txtTotalAmount.TabStop = false;
            this.txtTotalAmount.Text = "0.00";
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtAmount
            // 
            this.txtAmount.DecimalPlaces = 2;
            this.txtAmount.IsSendTabOnEnter = true;
            this.txtAmount.Location = new System.Drawing.Point(124, 108);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(111, 20);
            this.txtAmount.TabIndex = 5;
            this.txtAmount.TabStop = false;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
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
            this.cboCurrency.Location = new System.Drawing.Point(124, 45);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 0;
            // 
            // txtBudgetYear
            // 
            this.txtBudgetYear.IsSendTabOnEnter = true;
            this.txtBudgetYear.Location = new System.Drawing.Point(370, 77);
            this.txtBudgetYear.Name = "txtBudgetYear";
            this.txtBudgetYear.ReadOnly = true;
            this.txtBudgetYear.Size = new System.Drawing.Size(83, 20);
            this.txtBudgetYear.TabIndex = 8;
            this.txtBudgetYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtRegisterNo
            // 
            this.txtRegisterNo.IsSendTabOnEnter = true;
            this.txtRegisterNo.Location = new System.Drawing.Point(124, 164);
            this.txtRegisterNo.Name = "txtRegisterNo";
            this.txtRegisterNo.Size = new System.Drawing.Size(141, 20);
            this.txtRegisterNo.TabIndex = 4;
            this.txtRegisterNo.Visible = false;
            // 
            // txtGroupNo
            // 
            this.txtGroupNo.IsSendTabOnEnter = true;
            this.txtGroupNo.Location = new System.Drawing.Point(124, 13);
            this.txtGroupNo.Name = "txtGroupNo";
            this.txtGroupNo.Size = new System.Drawing.Size(115, 20);
            this.txtGroupNo.TabIndex = 0;
            this.txtGroupNo.TabStop = false;
            // 
            // cxC00036
            // 
            this.cxC00036.AutoSize = true;
            this.cxC00036.Location = new System.Drawing.Point(12, 48);
            this.cxC00036.Name = "cxC00036";
            this.cxC00036.Size = new System.Drawing.Size(55, 13);
            this.cxC00036.TabIndex = 0;
            this.cxC00036.Text = "Currency :";
            // 
            // cxC00035
            // 
            this.cxC00035.AutoSize = true;
            this.cxC00035.Location = new System.Drawing.Point(12, 80);
            this.cxC00035.Name = "cxC00035";
            this.cxC00035.Size = new System.Drawing.Size(105, 13);
            this.cxC00035.TabIndex = 0;
            this.cxC00035.Text = "Dealer Payment No :";
            // 
            // cxC00034
            // 
            this.cxC00034.AutoSize = true;
            this.cxC00034.Location = new System.Drawing.Point(12, 167);
            this.cxC00034.Name = "cxC00034";
            this.cxC00034.Size = new System.Drawing.Size(69, 13);
            this.cxC00034.TabIndex = 0;
            this.cxC00034.Text = "Register No :";
            this.cxC00034.Visible = false;
            // 
            // cxC00033
            // 
            this.cxC00033.AutoSize = true;
            this.cxC00033.Location = new System.Drawing.Point(12, 111);
            this.cxC00033.Name = "cxC00033";
            this.cxC00033.Size = new System.Drawing.Size(49, 13);
            this.cxC00033.TabIndex = 0;
            this.cxC00033.Text = "Amount :";
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.Location = new System.Drawing.Point(12, 140);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(76, 13);
            this.cxC00032.TabIndex = 0;
            this.cxC00032.Text = "Total Amount :";
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(292, 80);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(72, 13);
            this.cxC00031.TabIndex = 0;
            this.cxC00031.Text = "Budget Year :";
            // 
            // lblVoucherNo
            // 
            this.lblVoucherNo.AutoSize = true;
            this.lblVoucherNo.Location = new System.Drawing.Point(12, 16);
            this.lblVoucherNo.Name = "lblVoucherNo";
            this.lblVoucherNo.Size = new System.Drawing.Size(70, 13);
            this.lblVoucherNo.TabIndex = 0;
            this.lblVoucherNo.Text = "Voucher No :";
            // 
            // TLMVEW00016
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 476);
            this.Controls.Add(this.gbPaymentDetail);
            this.Controls.Add(this.tsbCRUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00016";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dealer Payment Outstanding Refund By Cash Entry";
            this.Load += new System.EventHandler(this.TLMVEW00016_Load);
            this.gbPaymentDetail.ResumeLayout(false);
            this.gbPaymentDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPaymentOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox gbPaymentDetail;
        private Windows.CXClient.Controls.CXC0003 lblVoucherNo;
        private Windows.CXClient.Controls.CXC0003 cxC00036;
        private Windows.CXClient.Controls.CXC0003 cxC00035;
        private Windows.CXClient.Controls.CXC0003 cxC00034;
        private Windows.CXClient.Controls.CXC0003 cxC00033;
        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0006 txtGroupNo;
        private Windows.CXClient.Controls.CXC0006 txtRegisterNo;
        private Windows.CXClient.Controls.CXC0006 txtBudgetYear;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0004 txtTotalAmount;
        private Windows.CXClient.Controls.CXC0004 txtAmount;
        private Windows.CXClient.Controls.CXC0007 butAdd;
        private Windows.CXClient.Controls.AceGridView gvPaymentOrder;
        private Windows.CXClient.Controls.CXC0001 txtPaymentOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaymentOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBudgetYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegisterNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrencyCode;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
        private System.Windows.Forms.DataGridViewImageColumn colDelete;
        private Windows.CXClient.Controls.CXC0003 lblTransactionDate;
        private Windows.CXClient.Controls.CXC0003 cxC00037;
    }
}