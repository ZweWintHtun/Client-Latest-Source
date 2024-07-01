namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00010
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00010));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbDepositTransitions = new System.Windows.Forms.GroupBox();
            this.txtCommissions = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtCommunicationCharges = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblCommissions = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCommunicationCharges = new Ace.Windows.CXClient.Controls.CXC0003();
            this.chkInputIncomeAmount = new Ace.Windows.CXClient.Controls.CXC0008();
            this.chkPrintTransactions = new Ace.Windows.CXClient.Controls.CXC0008();
            this.gbMultiAccount = new System.Windows.Forms.GroupBox();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtNRC = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblCustNRC = new Ace.Windows.CXClient.Controls.CXC0003();
            this.butCalculate = new Ace.Windows.CXClient.Controls.CXC0007();
            this.butEnquiry = new Ace.Windows.CXClient.Controls.CXC0007();
            this.gvDepositInformation = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.colAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNRC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCommunicationCharges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCommissions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrint = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblDebitNarration = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtNarration = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblDebitAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.butAdd = new System.Windows.Forms.Button();
            this.txtTotalAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblTotalAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtName = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.txtVoucherNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblTransactionDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblGroupNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gbDepositTransitions.SuspendLayout();
            this.gbMultiAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDepositInformation)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDepositTransitions
            // 
            this.gbDepositTransitions.Controls.Add(this.txtCommissions);
            this.gbDepositTransitions.Controls.Add(this.txtCommunicationCharges);
            this.gbDepositTransitions.Controls.Add(this.lblCommissions);
            this.gbDepositTransitions.Controls.Add(this.lblCommunicationCharges);
            this.gbDepositTransitions.Location = new System.Drawing.Point(402, 163);
            this.gbDepositTransitions.Name = "gbDepositTransitions";
            this.gbDepositTransitions.Size = new System.Drawing.Size(289, 78);
            this.gbDepositTransitions.TabIndex = 11;
            this.gbDepositTransitions.TabStop = false;
            // 
            // txtCommissions
            // 
            this.txtCommissions.DecimalPlaces = 2;
            this.txtCommissions.IsSendTabOnEnter = true;
            this.txtCommissions.IsThousandSeperator = true;
            this.txtCommissions.Location = new System.Drawing.Point(161, 45);
            this.txtCommissions.MaxLength = 18;
            this.txtCommissions.Name = "txtCommissions";
            this.txtCommissions.Size = new System.Drawing.Size(111, 20);
            this.txtCommissions.TabIndex = 13;
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
            this.txtCommunicationCharges.Location = new System.Drawing.Point(161, 19);
            this.txtCommunicationCharges.MaxLength = 18;
            this.txtCommunicationCharges.Name = "txtCommunicationCharges";
            this.txtCommunicationCharges.Size = new System.Drawing.Size(111, 20);
            this.txtCommunicationCharges.TabIndex = 12;
            this.txtCommunicationCharges.Text = "0.00";
            this.txtCommunicationCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCommunicationCharges.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblCommissions
            // 
            this.lblCommissions.AutoSize = true;
            this.lblCommissions.Location = new System.Drawing.Point(13, 48);
            this.lblCommissions.Name = "lblCommissions";
            this.lblCommissions.Size = new System.Drawing.Size(73, 13);
            this.lblCommissions.TabIndex = 0;
            this.lblCommissions.Text = "Commissions :";
            // 
            // lblCommunicationCharges
            // 
            this.lblCommunicationCharges.AutoSize = true;
            this.lblCommunicationCharges.Location = new System.Drawing.Point(13, 22);
            this.lblCommunicationCharges.Name = "lblCommunicationCharges";
            this.lblCommunicationCharges.Size = new System.Drawing.Size(127, 13);
            this.lblCommunicationCharges.TabIndex = 0;
            this.lblCommunicationCharges.Text = "Communication Charges :";
            // 
            // chkInputIncomeAmount
            // 
            this.chkInputIncomeAmount.AutoSize = true;
            this.chkInputIncomeAmount.IsSendTabOnEnter = true;
            this.chkInputIncomeAmount.Location = new System.Drawing.Point(402, 140);
            this.chkInputIncomeAmount.Name = "chkInputIncomeAmount";
            this.chkInputIncomeAmount.Size = new System.Drawing.Size(127, 17);
            this.chkInputIncomeAmount.TabIndex = 10;
            this.chkInputIncomeAmount.Text = "Input Income Amount";
            this.chkInputIncomeAmount.UseVisualStyleBackColor = true;
            this.chkInputIncomeAmount.CheckedChanged += new System.EventHandler(this.chkInputIncomeAmount_CheckedChanged);
            // 
            // chkPrintTransactions
            // 
            this.chkPrintTransactions.AutoSize = true;
            this.chkPrintTransactions.IsSendTabOnEnter = true;
            this.chkPrintTransactions.Location = new System.Drawing.Point(697, 224);
            this.chkPrintTransactions.Name = "chkPrintTransactions";
            this.chkPrintTransactions.Size = new System.Drawing.Size(106, 17);
            this.chkPrintTransactions.TabIndex = 14;
            this.chkPrintTransactions.Text = "&Print Transaction";
            this.chkPrintTransactions.UseVisualStyleBackColor = true;
            // 
            // gbMultiAccount
            // 
            this.gbMultiAccount.BackColor = System.Drawing.SystemColors.Control;
            this.gbMultiAccount.Controls.Add(this.mtxtAccountNo);
            this.gbMultiAccount.Controls.Add(this.txtNRC);
            this.gbMultiAccount.Controls.Add(this.lblCustNRC);
            this.gbMultiAccount.Controls.Add(this.butCalculate);
            this.gbMultiAccount.Controls.Add(this.butEnquiry);
            this.gbMultiAccount.Controls.Add(this.gvDepositInformation);
            this.gbMultiAccount.Controls.Add(this.lblDebitNarration);
            this.gbMultiAccount.Controls.Add(this.txtNarration);
            this.gbMultiAccount.Controls.Add(this.lblDebitAccountNo);
            this.gbMultiAccount.Controls.Add(this.chkInputIncomeAmount);
            this.gbMultiAccount.Controls.Add(this.butAdd);
            this.gbMultiAccount.Controls.Add(this.chkPrintTransactions);
            this.gbMultiAccount.Controls.Add(this.gbDepositTransitions);
            this.gbMultiAccount.Controls.Add(this.txtTotalAmount);
            this.gbMultiAccount.Controls.Add(this.txtAmount);
            this.gbMultiAccount.Controls.Add(this.lblTotalAmount);
            this.gbMultiAccount.Controls.Add(this.lblAmount);
            this.gbMultiAccount.Controls.Add(this.txtName);
            this.gbMultiAccount.Controls.Add(this.lblName);
            this.gbMultiAccount.Controls.Add(this.cboCurrency);
            this.gbMultiAccount.Controls.Add(this.txtVoucherNo);
            this.gbMultiAccount.Controls.Add(this.lblCurrency);
            this.gbMultiAccount.Controls.Add(this.lblTransactionDate);
            this.gbMultiAccount.Controls.Add(this.cxC00031);
            this.gbMultiAccount.Controls.Add(this.lblGroupNo);
            this.gbMultiAccount.Location = new System.Drawing.Point(12, 37);
            this.gbMultiAccount.Name = "gbMultiAccount";
            this.gbMultiAccount.Size = new System.Drawing.Size(970, 524);
            this.gbMultiAccount.TabIndex = 0;
            this.gbMultiAccount.TabStop = false;
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(101, 79);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 3;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtNRC
            // 
            this.txtNRC.IsSendTabOnEnter = true;
            this.txtNRC.Location = new System.Drawing.Point(101, 140);
            this.txtNRC.MaxLength = 20;
            this.txtNRC.Name = "txtNRC";
            this.txtNRC.Size = new System.Drawing.Size(141, 20);
            this.txtNRC.TabIndex = 6;
            // 
            // lblCustNRC
            // 
            this.lblCustNRC.AutoSize = true;
            this.lblCustNRC.Location = new System.Drawing.Point(11, 143);
            this.lblCustNRC.Name = "lblCustNRC";
            this.lblCustNRC.Size = new System.Drawing.Size(36, 13);
            this.lblCustNRC.TabIndex = 0;
            this.lblCustNRC.Text = "NRC :";
            // 
            // butCalculate
            // 
            this.butCalculate.Image = global::Ace.Cbs.Tel.Vew.Properties.Resources.Money_Calculator;
            this.butCalculate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCalculate.Location = new System.Drawing.Point(265, 166);
            this.butCalculate.Name = "butCalculate";
            this.butCalculate.Size = new System.Drawing.Size(92, 30);
            this.butCalculate.TabIndex = 8;
            this.butCalculate.Text = "&Calculate";
            this.butCalculate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCalculate.UseVisualStyleBackColor = true;
            this.butCalculate.Click += new System.EventHandler(this.butCalculate_Click);
            // 
            // butEnquiry
            // 
            this.butEnquiry.Image = ((System.Drawing.Image)(resources.GetObject("butEnquiry.Image")));
            this.butEnquiry.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butEnquiry.Location = new System.Drawing.Point(265, 73);
            this.butEnquiry.Name = "butEnquiry";
            this.butEnquiry.Size = new System.Drawing.Size(74, 30);
            this.butEnquiry.TabIndex = 4;
            this.butEnquiry.Text = "&Enquiry";
            this.butEnquiry.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butEnquiry.UseVisualStyleBackColor = true;
            this.butEnquiry.Click += new System.EventHandler(this.butEnquiry_Click);
            // 
            // gvDepositInformation
            // 
            this.gvDepositInformation.AllowUserToAddRows = false;
            this.gvDepositInformation.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvDepositInformation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvDepositInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDepositInformation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEdit,
            this.colDelete,
            this.colAccountNo,
            this.colName,
            this.colNRC,
            this.colAmount,
            this.colCommunicationCharges,
            this.colCommissions,
            this.colPrint});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvDepositInformation.DefaultCellStyle = dataGridViewCellStyle5;
            this.gvDepositInformation.EnableHeadersVisualStyles = false;
            this.gvDepositInformation.IdTSList = null;
            this.gvDepositInformation.IsEscapeKey = false;
            this.gvDepositInformation.IsHeaderClick = false;
            this.gvDepositInformation.Location = new System.Drawing.Point(13, 247);
            this.gvDepositInformation.Name = "gvDepositInformation";
            this.gvDepositInformation.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvDepositInformation.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gvDepositInformation.RowHeadersWidth = 25;
            this.gvDepositInformation.ShowSerialNo = true;
            this.gvDepositInformation.Size = new System.Drawing.Size(944, 245);
            this.gvDepositInformation.TabIndex = 16;
            this.gvDepositInformation.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvDeposit_CellClick);
            this.gvDepositInformation.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gvDepositInformation_DataError);
            // 
            // colEdit
            // 
            this.colEdit.HeaderText = "";
            this.colEdit.Image = global::Ace.Cbs.Tel.Vew.Properties.Resources.edit;
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            this.colEdit.ToolTipText = "Edit";
            this.colEdit.Width = 30;
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "";
            this.colDelete.Image = global::Ace.Cbs.Tel.Vew.Properties.Resources.Delete_Main;
            this.colDelete.Name = "colDelete";
            this.colDelete.ReadOnly = true;
            this.colDelete.ToolTipText = "Delete";
            this.colDelete.Width = 30;
            // 
            // colAccountNo
            // 
            this.colAccountNo.DataPropertyName = "AccountNo";
            this.colAccountNo.HeaderText = "Account No";
            this.colAccountNo.Name = "colAccountNo";
            this.colAccountNo.ReadOnly = true;
            this.colAccountNo.Width = 150;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 150;
            // 
            // colNRC
            // 
            this.colNRC.DataPropertyName = "NRC";
            this.colNRC.HeaderText = "NRC";
            this.colNRC.Name = "colNRC";
            this.colNRC.ReadOnly = true;
            this.colNRC.Width = 150;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // colCommunicationCharges
            // 
            this.colCommunicationCharges.DataPropertyName = "CommunicationCharges";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colCommunicationCharges.DefaultCellStyle = dataGridViewCellStyle3;
            this.colCommunicationCharges.HeaderText = "Communication Charges";
            this.colCommunicationCharges.Name = "colCommunicationCharges";
            this.colCommunicationCharges.ReadOnly = true;
            this.colCommunicationCharges.Width = 150;
            // 
            // colCommissions
            // 
            this.colCommissions.DataPropertyName = "Commissions";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colCommissions.DefaultCellStyle = dataGridViewCellStyle4;
            this.colCommissions.HeaderText = "Commissions";
            this.colCommissions.Name = "colCommissions";
            this.colCommissions.ReadOnly = true;
            // 
            // colPrint
            // 
            this.colPrint.DataPropertyName = "IsPrintTransaction";
            this.colPrint.HeaderText = "Print";
            this.colPrint.Name = "colPrint";
            this.colPrint.ReadOnly = true;
            this.colPrint.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPrint.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colPrint.Width = 50;
            // 
            // lblDebitNarration
            // 
            this.lblDebitNarration.AutoSize = true;
            this.lblDebitNarration.Location = new System.Drawing.Point(11, 202);
            this.lblDebitNarration.Name = "lblDebitNarration";
            this.lblDebitNarration.Size = new System.Drawing.Size(56, 13);
            this.lblDebitNarration.TabIndex = 0;
            this.lblDebitNarration.Text = "Narration :";
            // 
            // txtNarration
            // 
            this.txtNarration.IsSendTabOnEnter = true;
            this.txtNarration.Location = new System.Drawing.Point(101, 199);
            this.txtNarration.MaxLength = 40;
            this.txtNarration.Multiline = true;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(175, 42);
            this.txtNarration.TabIndex = 9;
            // 
            // lblDebitAccountNo
            // 
            this.lblDebitAccountNo.AutoSize = true;
            this.lblDebitAccountNo.Location = new System.Drawing.Point(11, 82);
            this.lblDebitAccountNo.Name = "lblDebitAccountNo";
            this.lblDebitAccountNo.Size = new System.Drawing.Size(70, 13);
            this.lblDebitAccountNo.TabIndex = 0;
            this.lblDebitAccountNo.Text = "Account No :";
            // 
            // butAdd
            // 
            this.butAdd.CausesValidation = false;
            this.butAdd.Image = ((System.Drawing.Image)(resources.GetObject("butAdd.Image")));
            this.butAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAdd.Location = new System.Drawing.Point(897, 211);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(60, 30);
            this.butAdd.TabIndex = 15;
            this.butAdd.Text = "&Add";
            this.butAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.DecimalPlaces = 2;
            this.txtTotalAmount.IsSendTabOnEnter = true;
            this.txtTotalAmount.Location = new System.Drawing.Point(846, 498);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(111, 20);
            this.txtTotalAmount.TabIndex = 17;
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
            this.txtAmount.IsThousandSeperator = true;
            this.txtAmount.IsUseFloatingPoint = true;
            this.txtAmount.Location = new System.Drawing.Point(101, 169);
            this.txtAmount.MaxLength = 18;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(141, 20);
            this.txtAmount.TabIndex = 7;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(732, 501);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(76, 13);
            this.lblTotalAmount.TabIndex = 0;
            this.lblTotalAmount.Text = "Total Amount :";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(11, 172);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(49, 13);
            this.lblAmount.TabIndex = 0;
            this.lblAmount.Text = "Amount :";
            // 
            // txtName
            // 
            this.txtName.IsSendTabOnEnter = true;
            this.txtName.Location = new System.Drawing.Point(101, 110);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(141, 20);
            this.txtName.TabIndex = 5;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(11, 113);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name :";
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
            this.cboCurrency.Location = new System.Drawing.Point(101, 48);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 2;
            // 
            // txtVoucherNo
            // 
            this.txtVoucherNo.IsSendTabOnEnter = true;
            this.txtVoucherNo.Location = new System.Drawing.Point(101, 19);
            this.txtVoucherNo.MaxLength = 11;
            this.txtVoucherNo.Name = "txtVoucherNo";
            this.txtVoucherNo.Size = new System.Drawing.Size(115, 20);
            this.txtVoucherNo.TabIndex = 1;
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(11, 51);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 0;
            this.lblCurrency.Text = "Currency :";
            // 
            // lblTransactionDate
            // 
            this.lblTransactionDate.AutoSize = true;
            this.lblTransactionDate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblTransactionDate.Location = new System.Drawing.Point(857, 23);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Size = new System.Drawing.Size(89, 13);
            this.lblTransactionDate.TabIndex = 0;
            this.lblTransactionDate.Text = "Transaction Date";
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.cxC00031.Location = new System.Drawing.Point(756, 23);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(95, 13);
            this.cxC00031.TabIndex = 0;
            this.cxC00031.Text = "Transaction Date :";
            // 
            // lblGroupNo
            // 
            this.lblGroupNo.AutoSize = true;
            this.lblGroupNo.Location = new System.Drawing.Point(11, 22);
            this.lblGroupNo.Name = "lblGroupNo";
            this.lblGroupNo.Size = new System.Drawing.Size(70, 13);
            this.lblGroupNo.TabIndex = 0;
            this.lblGroupNo.Text = "Voucher No :";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(997, 31);
            this.tsbCRUD.TabIndex = 18;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // TLMVEW00010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 573);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.gbMultiAccount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00010";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deposit Entry";
            this.Load += new System.EventHandler(this.TLMVEW00010_Load);
            this.gbDepositTransitions.ResumeLayout(false);
            this.gbDepositTransitions.PerformLayout();
            this.gbMultiAccount.ResumeLayout(false);
            this.gbMultiAccount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDepositInformation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMultiAccount;
        private Ace.Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Ace.Windows.CXClient.Controls.CXC0001 txtVoucherNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Ace.Windows.CXClient.Controls.CXC0003 lblGroupNo;
        private Ace.Windows.CXClient.Controls.CXC0001 txtName;
        private Ace.Windows.CXClient.Controls.CXC0003 lblName;
        private Ace.Windows.CXClient.Controls.CXC0004 txtAmount;
        private Ace.Windows.CXClient.Controls.CXC0003 lblAmount;
        private System.Windows.Forms.GroupBox gbDepositTransitions;
        private Ace.Windows.CXClient.Controls.CXC0008 chkInputIncomeAmount;
        private Ace.Windows.CXClient.Controls.CXC0004 txtCommissions;
        private Ace.Windows.CXClient.Controls.CXC0008 chkPrintTransactions;
        private Ace.Windows.CXClient.Controls.CXC0004 txtCommunicationCharges;
        private Ace.Windows.CXClient.Controls.CXC0003 lblCommissions;
        private Ace.Windows.CXClient.Controls.CXC0003 lblCommunicationCharges;
        private Ace.Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.Button butAdd;
        private Ace.Windows.CXClient.Controls.CXC0003 lblDebitAccountNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblDebitNarration;
        private Ace.Windows.CXClient.Controls.CXC0001 txtNarration;
        private Ace.Windows.CXClient.Controls.CXC0004 txtTotalAmount;
        private Ace.Windows.CXClient.Controls.CXC0003 lblTotalAmount;
        Windows.CXClient.Controls.AceGridView gvDepositInformation;
        private Windows.CXClient.Controls.CXC0007 butEnquiry;
        private Windows.CXClient.Controls.CXC0007 butCalculate;
        private Windows.CXClient.Controls.CXC0001 txtNRC;
        private Windows.CXClient.Controls.CXC0003 lblCustNRC;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
        private System.Windows.Forms.DataGridViewImageColumn colDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNRC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCommunicationCharges;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCommissions;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colPrint;
        private Windows.CXClient.Controls.CXC0003 lblTransactionDate;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
    }
}