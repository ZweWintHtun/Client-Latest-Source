namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00003
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00003));
            this.txtVoucherNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblVoucherNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.rdoIncomeByCash = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoIncomeByTransfer = new Ace.Windows.CXClient.Controls.CXC0009();
            this.chkInputIncomeAmount = new Ace.Windows.CXClient.Controls.CXC0008();
            this.gbChargesInformation = new System.Windows.Forms.GroupBox();
            this.txtCommissions = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtCommunicationCharges = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblCommission = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCommunicationCharges = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gvTransferInformation = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.colAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNarration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVoucherType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChequeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsPrint = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.butCalculate = new Ace.Windows.CXClient.Controls.CXC0007();
            this.chkPrintTransaction = new Ace.Windows.CXClient.Controls.CXC0008();
            this.chkVIP = new Ace.Windows.CXClient.Controls.CXC0008();
            this.lblDebitDescription = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblDebitAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblDebitNarration = new Ace.Windows.CXClient.Controls.CXC0003();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtNarration = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblCheqeNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblDebitAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.gbTransfer = new System.Windows.Forms.GroupBox();
            this.lblTransactionDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gbIncomeType = new System.Windows.Forms.GroupBox();
            this.butEnquiry = new Ace.Windows.CXClient.Controls.CXC0007();
            this.butAdd = new Ace.Windows.CXClient.Controls.CXC0007();
            this.rdoDebit = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoCredit = new Ace.Windows.CXClient.Controls.CXC0009();
            this.txtChequeNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtDescription = new Ace.Windows.CXClient.Controls.CXC0001();
            this.gbChargesInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTransferInformation)).BeginInit();
            this.gbTransfer.SuspendLayout();
            this.gbIncomeType.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtVoucherNo
            // 
            this.txtVoucherNo.IsSendTabOnEnter = true;
            this.txtVoucherNo.Location = new System.Drawing.Point(103, 22);
            this.txtVoucherNo.Name = "txtVoucherNo";
            this.txtVoucherNo.Size = new System.Drawing.Size(141, 20);
            this.txtVoucherNo.TabIndex = 1;
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
            "USD",
            "FEC",
            "SGD"});
            this.cboCurrency.Location = new System.Drawing.Point(103, 53);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 1;
            // 
            // lblVoucherNo
            // 
            this.lblVoucherNo.AutoSize = true;
            this.lblVoucherNo.Location = new System.Drawing.Point(11, 25);
            this.lblVoucherNo.Name = "lblVoucherNo";
            this.lblVoucherNo.Size = new System.Drawing.Size(70, 13);
            this.lblVoucherNo.TabIndex = 0;
            this.lblVoucherNo.Text = "Voucher No :";
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(11, 56);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(58, 13);
            this.lblCurrency.TabIndex = 0;
            this.lblCurrency.Text = "Currency  :";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 50;
            // 
            // rdoIncomeByCash
            // 
            this.rdoIncomeByCash.AutoSize = true;
            this.rdoIncomeByCash.Checked = true;
            this.rdoIncomeByCash.IsSendTabOnEnter = true;
            this.rdoIncomeByCash.Location = new System.Drawing.Point(13, 15);
            this.rdoIncomeByCash.Name = "rdoIncomeByCash";
            this.rdoIncomeByCash.Size = new System.Drawing.Size(102, 17);
            this.rdoIncomeByCash.TabIndex = 10;
            this.rdoIncomeByCash.TabStop = true;
            this.rdoIncomeByCash.Text = "Inco&me By Cash";
            this.rdoIncomeByCash.UseVisualStyleBackColor = true;
            // 
            // rdoIncomeByTransfer
            // 
            this.rdoIncomeByTransfer.AutoSize = true;
            this.rdoIncomeByTransfer.IsSendTabOnEnter = true;
            this.rdoIncomeByTransfer.Location = new System.Drawing.Point(137, 15);
            this.rdoIncomeByTransfer.Name = "rdoIncomeByTransfer";
            this.rdoIncomeByTransfer.Size = new System.Drawing.Size(117, 17);
            this.rdoIncomeByTransfer.TabIndex = 11;
            this.rdoIncomeByTransfer.Text = "Income By &Transfer";
            this.rdoIncomeByTransfer.UseVisualStyleBackColor = true;
            // 
            // chkInputIncomeAmount
            // 
            this.chkInputIncomeAmount.AutoSize = true;
            this.chkInputIncomeAmount.IsSendTabOnEnter = true;
            this.chkInputIncomeAmount.Location = new System.Drawing.Point(404, 91);
            this.chkInputIncomeAmount.Name = "chkInputIncomeAmount";
            this.chkInputIncomeAmount.Size = new System.Drawing.Size(127, 17);
            this.chkInputIncomeAmount.TabIndex = 13;
            this.chkInputIncomeAmount.Text = "&Input Income Amount";
            this.chkInputIncomeAmount.UseVisualStyleBackColor = true;
            this.chkInputIncomeAmount.CheckedChanged += new System.EventHandler(this.chkInputIncomeAmount_CheckedChanged);
            // 
            // gbChargesInformation
            // 
            this.gbChargesInformation.Controls.Add(this.txtCommissions);
            this.gbChargesInformation.Controls.Add(this.txtCommunicationCharges);
            this.gbChargesInformation.Controls.Add(this.lblCommission);
            this.gbChargesInformation.Controls.Add(this.lblCommunicationCharges);
            this.gbChargesInformation.Location = new System.Drawing.Point(404, 113);
            this.gbChargesInformation.Name = "gbChargesInformation";
            this.gbChargesInformation.Size = new System.Drawing.Size(267, 71);
            this.gbChargesInformation.TabIndex = 17;
            this.gbChargesInformation.TabStop = false;
            // 
            // txtCommissions
            // 
            this.txtCommissions.DecimalPlaces = 2;
            this.txtCommissions.IsSendTabOnEnter = true;
            this.txtCommissions.IsThousandSeperator = true;
            this.txtCommissions.IsUseFloatingPoint = true;
            this.txtCommissions.Location = new System.Drawing.Point(143, 42);
            this.txtCommissions.MaxLength = 18;
            this.txtCommissions.Name = "txtCommissions";
            this.txtCommissions.Size = new System.Drawing.Size(111, 20);
            this.txtCommissions.TabIndex = 15;
            this.txtCommissions.Text = "0.00";
            this.txtCommissions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCommissions.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtCommunicationCharges
            // 
            this.txtCommunicationCharges.DecimalPlaces = 2;
            this.txtCommunicationCharges.IsSendTabOnEnter = true;
            this.txtCommunicationCharges.IsThousandSeperator = true;
            this.txtCommunicationCharges.IsUseFloatingPoint = true;
            this.txtCommunicationCharges.Location = new System.Drawing.Point(143, 15);
            this.txtCommunicationCharges.MaxLength = 18;
            this.txtCommunicationCharges.Name = "txtCommunicationCharges";
            this.txtCommunicationCharges.Size = new System.Drawing.Size(111, 20);
            this.txtCommunicationCharges.TabIndex = 14;
            this.txtCommunicationCharges.Text = "0.00";
            this.txtCommunicationCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCommunicationCharges.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblCommission
            // 
            this.lblCommission.AutoSize = true;
            this.lblCommission.Location = new System.Drawing.Point(10, 45);
            this.lblCommission.Name = "lblCommission";
            this.lblCommission.Size = new System.Drawing.Size(71, 13);
            this.lblCommission.TabIndex = 0;
            this.lblCommission.Text = "Commission : ";
            // 
            // lblCommunicationCharges
            // 
            this.lblCommunicationCharges.AutoSize = true;
            this.lblCommunicationCharges.Location = new System.Drawing.Point(10, 18);
            this.lblCommunicationCharges.Name = "lblCommunicationCharges";
            this.lblCommunicationCharges.Size = new System.Drawing.Size(128, 13);
            this.lblCommunicationCharges.TabIndex = 0;
            this.lblCommunicationCharges.Text = "Communaction Charges : ";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-2, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(984, 31);
            this.tsbCRUD.TabIndex = 23;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // gvTransferInformation
            // 
            this.gvTransferInformation.AllowUserToAddRows = false;
            this.gvTransferInformation.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvTransferInformation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvTransferInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTransferInformation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEdit,
            this.colDelete,
            this.colAccountNo,
            this.colDescription,
            this.colNarration,
            this.colVoucherType,
            this.colChequeNo,
            this.colAmount,
            this.colIsPrint});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvTransferInformation.DefaultCellStyle = dataGridViewCellStyle4;
            this.gvTransferInformation.EnableHeadersVisualStyles = false;
            this.gvTransferInformation.IdTSList = null;
            this.gvTransferInformation.IsEscapeKey = false;
            this.gvTransferInformation.IsHeaderClick = false;
            this.gvTransferInformation.Location = new System.Drawing.Point(14, 263);
            this.gvTransferInformation.Name = "gvTransferInformation";
            this.gvTransferInformation.ReadOnly = true;
            this.gvTransferInformation.RowHeadersWidth = 25;
            this.gvTransferInformation.ShowSerialNo = true;
            this.gvTransferInformation.Size = new System.Drawing.Size(928, 281);
            this.gvTransferInformation.TabIndex = 20;
            this.gvTransferInformation.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvTransferInformation_CellClick);
            this.gvTransferInformation.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gvTransferInformation_DataError);
            // 
            // colEdit
            // 
            this.colEdit.Description = "Edit";
            this.colEdit.HeaderText = "";
            this.colEdit.Image = global::Ace.Cbs.Tel.Vew.Properties.Resources.edit;
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            this.colEdit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colEdit.ToolTipText = "Edit";
            this.colEdit.Width = 30;
            // 
            // colDelete
            // 
            this.colDelete.Description = "Delete";
            this.colDelete.HeaderText = "";
            this.colDelete.Image = global::Ace.Cbs.Tel.Vew.Properties.Resources.Delete_Main;
            this.colDelete.Name = "colDelete";
            this.colDelete.ReadOnly = true;
            this.colDelete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDelete.ToolTipText = "Delete";
            this.colDelete.Width = 30;
            // 
            // colAccountNo
            // 
            this.colAccountNo.DataPropertyName = "AccountNo";
            this.colAccountNo.HeaderText = "Account No";
            this.colAccountNo.Name = "colAccountNo";
            this.colAccountNo.ReadOnly = true;
            this.colAccountNo.Width = 105;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 225;
            // 
            // colNarration
            // 
            this.colNarration.DataPropertyName = "Narration";
            this.colNarration.HeaderText = "Narration";
            this.colNarration.Name = "colNarration";
            this.colNarration.ReadOnly = true;
            this.colNarration.Width = 225;
            // 
            // colVoucherType
            // 
            this.colVoucherType.DataPropertyName = "VoucherType";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colVoucherType.DefaultCellStyle = dataGridViewCellStyle2;
            this.colVoucherType.HeaderText = "Voucher Type";
            this.colVoucherType.Name = "colVoucherType";
            this.colVoucherType.ReadOnly = true;
            this.colVoucherType.Width = 80;
            // 
            // colChequeNo
            // 
            this.colChequeNo.DataPropertyName = "ChequeNo";
            this.colChequeNo.HeaderText = "Cheque No";
            this.colChequeNo.Name = "colChequeNo";
            this.colChequeNo.ReadOnly = true;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // colIsPrint
            // 
            this.colIsPrint.DataPropertyName = "IsPrintTransaction";
            this.colIsPrint.HeaderText = "Print";
            this.colIsPrint.Name = "colIsPrint";
            this.colIsPrint.ReadOnly = true;
            this.colIsPrint.Visible = false;
            this.colIsPrint.Width = 50;
            // 
            // butCalculate
            // 
            this.butCalculate.Image = global::Ace.Cbs.Tel.Vew.Properties.Resources.Money_Calculator;
            this.butCalculate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCalculate.Location = new System.Drawing.Point(677, 49);
            this.butCalculate.Name = "butCalculate";
            this.butCalculate.Size = new System.Drawing.Size(92, 30);
            this.butCalculate.TabIndex = 12;
            this.butCalculate.Text = "&Calculate";
            this.butCalculate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCalculate.UseVisualStyleBackColor = true;
            this.butCalculate.Click += new System.EventHandler(this.butCalculate_Click);
            // 
            // chkPrintTransaction
            // 
            this.chkPrintTransaction.AutoSize = true;
            this.chkPrintTransaction.IsSendTabOnEnter = true;
            this.chkPrintTransaction.Location = new System.Drawing.Point(677, 167);
            this.chkPrintTransaction.Name = "chkPrintTransaction";
            this.chkPrintTransaction.Size = new System.Drawing.Size(106, 17);
            this.chkPrintTransaction.TabIndex = 16;
            this.chkPrintTransaction.Text = "&Print Transaction";
            this.chkPrintTransaction.UseVisualStyleBackColor = true;
            this.chkPrintTransaction.Visible = false;
            // 
            // chkVIP
            // 
            this.chkVIP.AutoSize = true;
            this.chkVIP.IsSendTabOnEnter = true;
            this.chkVIP.Location = new System.Drawing.Point(266, 55);
            this.chkVIP.Name = "chkVIP";
            this.chkVIP.Size = new System.Drawing.Size(90, 17);
            this.chkVIP.TabIndex = 3;
            this.chkVIP.Text = "VIP Customer";
            this.chkVIP.UseVisualStyleBackColor = true;
            // 
            // lblDebitDescription
            // 
            this.lblDebitDescription.AutoSize = true;
            this.lblDebitDescription.Location = new System.Drawing.Point(11, 122);
            this.lblDebitDescription.Name = "lblDebitDescription";
            this.lblDebitDescription.Size = new System.Drawing.Size(66, 13);
            this.lblDebitDescription.TabIndex = 0;
            this.lblDebitDescription.Text = "Description :";
            // 
            // lblDebitAccountNo
            // 
            this.lblDebitAccountNo.AutoSize = true;
            this.lblDebitAccountNo.Location = new System.Drawing.Point(11, 91);
            this.lblDebitAccountNo.Name = "lblDebitAccountNo";
            this.lblDebitAccountNo.Size = new System.Drawing.Size(70, 13);
            this.lblDebitAccountNo.TabIndex = 0;
            this.lblDebitAccountNo.Text = "Account No :";
            // 
            // lblDebitNarration
            // 
            this.lblDebitNarration.AutoSize = true;
            this.lblDebitNarration.Location = new System.Drawing.Point(401, 200);
            this.lblDebitNarration.Name = "lblDebitNarration";
            this.lblDebitNarration.Size = new System.Drawing.Size(56, 13);
            this.lblDebitNarration.TabIndex = 0;
            this.lblDebitNarration.Text = "Narration :";
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(103, 88);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 2;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtxtAccountNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtAccountNo_KeyPress);
            // 
            // txtNarration
            // 
            this.txtNarration.IsSendTabOnEnter = true;
            this.txtNarration.Location = new System.Drawing.Point(463, 197);
            this.txtNarration.MaxLength = 100;
            this.txtNarration.Multiline = true;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(320, 50);
            this.txtNarration.TabIndex = 18;
            // 
            // lblCheqeNo
            // 
            this.lblCheqeNo.AutoSize = true;
            this.lblCheqeNo.Location = new System.Drawing.Point(11, 200);
            this.lblCheqeNo.Name = "lblCheqeNo";
            this.lblCheqeNo.Size = new System.Drawing.Size(70, 13);
            this.lblCheqeNo.TabIndex = 0;
            this.lblCheqeNo.Text = "Cheque No. :";
            // 
            // lblDebitAmount
            // 
            this.lblDebitAmount.AutoSize = true;
            this.lblDebitAmount.Location = new System.Drawing.Point(11, 230);
            this.lblDebitAmount.Name = "lblDebitAmount";
            this.lblDebitAmount.Size = new System.Drawing.Size(49, 13);
            this.lblDebitAmount.TabIndex = 0;
            this.lblDebitAmount.Text = "Amount :";
            // 
            // txtAmount
            // 
            this.txtAmount.DecimalPlaces = 2;
            this.txtAmount.IsSendTabOnEnter = true;
            this.txtAmount.IsThousandSeperator = true;
            this.txtAmount.IsUseFloatingPoint = true;
            this.txtAmount.Location = new System.Drawing.Point(103, 227);
            this.txtAmount.MaxLength = 18;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(141, 20);
            this.txtAmount.TabIndex = 8;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // gbTransfer
            // 
            this.gbTransfer.Controls.Add(this.lblTransactionDate);
            this.gbTransfer.Controls.Add(this.cxC00031);
            this.gbTransfer.Controls.Add(this.gbIncomeType);
            this.gbTransfer.Controls.Add(this.butEnquiry);
            this.gbTransfer.Controls.Add(this.butCalculate);
            this.gbTransfer.Controls.Add(this.gbChargesInformation);
            this.gbTransfer.Controls.Add(this.butAdd);
            this.gbTransfer.Controls.Add(this.chkInputIncomeAmount);
            this.gbTransfer.Controls.Add(this.txtAmount);
            this.gbTransfer.Controls.Add(this.rdoDebit);
            this.gbTransfer.Controls.Add(this.rdoCredit);
            this.gbTransfer.Controls.Add(this.lblDebitAmount);
            this.gbTransfer.Controls.Add(this.txtChequeNo);
            this.gbTransfer.Controls.Add(this.lblDebitNarration);
            this.gbTransfer.Controls.Add(this.lblCheqeNo);
            this.gbTransfer.Controls.Add(this.txtDescription);
            this.gbTransfer.Controls.Add(this.txtNarration);
            this.gbTransfer.Controls.Add(this.chkPrintTransaction);
            this.gbTransfer.Controls.Add(this.cboCurrency);
            this.gbTransfer.Controls.Add(this.lblDebitDescription);
            this.gbTransfer.Controls.Add(this.chkVIP);
            this.gbTransfer.Controls.Add(this.txtVoucherNo);
            this.gbTransfer.Controls.Add(this.lblVoucherNo);
            this.gbTransfer.Controls.Add(this.lblDebitAccountNo);
            this.gbTransfer.Controls.Add(this.lblCurrency);
            this.gbTransfer.Controls.Add(this.mtxtAccountNo);
            this.gbTransfer.Controls.Add(this.gvTransferInformation);
            this.gbTransfer.Location = new System.Drawing.Point(12, 37);
            this.gbTransfer.Name = "gbTransfer";
            this.gbTransfer.Size = new System.Drawing.Size(958, 560);
            this.gbTransfer.TabIndex = 0;
            this.gbTransfer.TabStop = false;
            // 
            // lblTransactionDate
            // 
            this.lblTransactionDate.AutoSize = true;
            this.lblTransactionDate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblTransactionDate.Location = new System.Drawing.Point(885, 25);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Size = new System.Drawing.Size(0, 13);
            this.lblTransactionDate.TabIndex = 22;
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.cxC00031.Location = new System.Drawing.Point(783, 25);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(98, 13);
            this.cxC00031.TabIndex = 21;
            this.cxC00031.Text = "Transaction Date  :";
            // 
            // gbIncomeType
            // 
            this.gbIncomeType.Controls.Add(this.rdoIncomeByCash);
            this.gbIncomeType.Controls.Add(this.rdoIncomeByTransfer);
            this.gbIncomeType.Location = new System.Drawing.Point(404, 41);
            this.gbIncomeType.Name = "gbIncomeType";
            this.gbIncomeType.Size = new System.Drawing.Size(267, 43);
            this.gbIncomeType.TabIndex = 9;
            this.gbIncomeType.TabStop = false;
            // 
            // butEnquiry
            // 
            this.butEnquiry.Image = ((System.Drawing.Image)(resources.GetObject("butEnquiry.Image")));
            this.butEnquiry.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butEnquiry.Location = new System.Drawing.Point(266, 82);
            this.butEnquiry.Name = "butEnquiry";
            this.butEnquiry.Size = new System.Drawing.Size(74, 30);
            this.butEnquiry.TabIndex = 4;
            this.butEnquiry.Text = "&Enquiry";
            this.butEnquiry.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butEnquiry.UseVisualStyleBackColor = true;
            this.butEnquiry.Click += new System.EventHandler(this.butEnquiry_Click);
            // 
            // butAdd
            // 
            this.butAdd.CausesValidation = false;
            this.butAdd.Image = ((System.Drawing.Image)(resources.GetObject("butAdd.Image")));
            this.butAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAdd.Location = new System.Drawing.Point(882, 221);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(60, 30);
            this.butAdd.TabIndex = 19;
            this.butAdd.Text = "&Add";
            this.butAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // rdoDebit
            // 
            this.rdoDebit.AutoSize = true;
            this.rdoDebit.CausesValidation = false;
            this.rdoDebit.Checked = true;
            this.rdoDebit.IsSendTabOnEnter = true;
            this.rdoDebit.Location = new System.Drawing.Point(103, 172);
            this.rdoDebit.Name = "rdoDebit";
            this.rdoDebit.Size = new System.Drawing.Size(50, 17);
            this.rdoDebit.TabIndex = 5;
            this.rdoDebit.TabStop = true;
            this.rdoDebit.Text = "&Debit";
            this.rdoDebit.UseVisualStyleBackColor = true;
            this.rdoDebit.CheckedChanged += new System.EventHandler(this.rdoDebit_CheckedChanged);
            // 
            // rdoCredit
            // 
            this.rdoCredit.AutoSize = true;
            this.rdoCredit.CausesValidation = false;
            this.rdoCredit.IsSendTabOnEnter = true;
            this.rdoCredit.Location = new System.Drawing.Point(192, 172);
            this.rdoCredit.Name = "rdoCredit";
            this.rdoCredit.Size = new System.Drawing.Size(52, 17);
            this.rdoCredit.TabIndex = 6;
            this.rdoCredit.Text = "&Credit";
            this.rdoCredit.UseVisualStyleBackColor = true;
            this.rdoCredit.CheckedChanged += new System.EventHandler(this.rdoCredit_CheckedChanged);
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.IsSendTabOnEnter = true;
            this.txtChequeNo.Location = new System.Drawing.Point(103, 197);
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(141, 20);
            this.txtChequeNo.TabIndex = 7;
            this.txtChequeNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChequeNo_KeyPress);
            this.txtChequeNo.Validated += new System.EventHandler(this.txtChequeNo_Validated);
            // 
            // txtDescription
            // 
            this.txtDescription.IsSendTabOnEnter = true;
            this.txtDescription.Location = new System.Drawing.Point(103, 119);
            this.txtDescription.MaxLength = 40;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(237, 50);
            this.txtDescription.TabIndex = 8;
            // 
            // TLMVEW00003
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 608);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.gbTransfer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00003";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Transfer Entry";
            this.Load += new System.EventHandler(this.TLMVEW00003_Load);
            this.gbChargesInformation.ResumeLayout(false);
            this.gbChargesInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTransferInformation)).EndInit();
            this.gbTransfer.ResumeLayout(false);
            this.gbTransfer.PerformLayout();
            this.gbIncomeType.ResumeLayout(false);
            this.gbIncomeType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Ace.Windows.CXClient.Controls.CXC0006 txtVoucherNo;
        private Ace.Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Ace.Windows.CXClient.Controls.CXC0003 lblVoucherNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblCurrency;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private Ace.Windows.CXClient.Controls.CXC0009 rdoIncomeByCash;
        private Ace.Windows.CXClient.Controls.CXC0009 rdoIncomeByTransfer;
        private Ace.Windows.CXClient.Controls.CXC0008 chkInputIncomeAmount;
        private System.Windows.Forms.GroupBox gbChargesInformation;
        private Ace.Windows.CXClient.Controls.CXC0004 txtCommissions;
        private Ace.Windows.CXClient.Controls.CXC0004 txtCommunicationCharges;
        private Ace.Windows.CXClient.Controls.CXC0003 lblCommission;
        private Ace.Windows.CXClient.Controls.CXC0003 lblCommunicationCharges;
        private Ace.Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Ace.Windows.CXClient.Controls.AceGridView gvTransferInformation;
        private Ace.Windows.CXClient.Controls.CXC0007 butAdd;
        private Ace.Windows.CXClient.Controls.CXC0007 butEnquiry;
        private Ace.Windows.CXClient.Controls.CXC0007 butCalculate;
        private Ace.Windows.CXClient.Controls.CXC0008 chkPrintTransaction;
        private Ace.Windows.CXClient.Controls.CXC0008 chkVIP;
        private Ace.Windows.CXClient.Controls.CXC0003 lblDebitDescription;
        private Ace.Windows.CXClient.Controls.CXC0003 lblDebitAccountNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblDebitNarration;
        private Ace.Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Ace.Windows.CXClient.Controls.CXC0001 txtNarration;
        private Ace.Windows.CXClient.Controls.CXC0003 lblCheqeNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblDebitAmount;
        private Ace.Windows.CXClient.Controls.CXC0004 txtAmount;
        private System.Windows.Forms.GroupBox gbTransfer;
        private Ace.Windows.CXClient.Controls.CXC0001 txtDescription;
        private Ace.Windows.CXClient.Controls.CXC0009 rdoDebit;
        private Ace.Windows.CXClient.Controls.CXC0009 rdoCredit;
        private System.Windows.Forms.GroupBox gbIncomeType;
        private Windows.CXClient.Controls.CXC0006 txtChequeNo;
        private Windows.CXClient.Controls.CXC0003 lblTransactionDate;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
        private System.Windows.Forms.DataGridViewImageColumn colDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNarration;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVoucherType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChequeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsPrint;

    }
}