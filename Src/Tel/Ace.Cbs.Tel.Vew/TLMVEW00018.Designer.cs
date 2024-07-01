namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00018
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00018));
            this.chkVIPCustomer = new System.Windows.Forms.CheckBox();
            this.gvCustomer = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colRegisterNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDrawerBank = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNrc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhoneNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCommission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIBLChanges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemitAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.txtGroupNo = new System.Windows.Forms.TextBox();
            this.lblGroupNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gbPaymentDetail = new System.Windows.Forms.GroupBox();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblSourceBr = new Ace.Windows.CXClient.Controls.CXC0003();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.grpIncome = new System.Windows.Forms.GroupBox();
            this.rdoNoIncome = new System.Windows.Forms.RadioButton();
            this.rdoIncome = new System.Windows.Forms.RadioButton();
            this.txtChequeNo = new System.Windows.Forms.MaskedTextBox();
            this.butContinue = new System.Windows.Forms.Button();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblTotalAmt = new Ace.Windows.CXClient.Controls.CXC0003();
            this.butEnquiry = new System.Windows.Forms.Button();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCheque = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtTotalAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtName = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblNrcNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtNRC = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblAddress = new Ace.Windows.CXClient.Controls.CXC0003();
            this.chkTakeIncome = new System.Windows.Forms.CheckBox();
            this.lblPhoneNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtPhone = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtAddress = new Ace.Windows.CXClient.Controls.CXC0001();
            this.grpDrawing = new System.Windows.Forms.GroupBox();
            this.rdoIncomeByCash = new System.Windows.Forms.RadioButton();
            this.rdoIncomeByTransfer = new System.Windows.Forms.RadioButton();
            this.txtNarration = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblNarration = new Ace.Windows.CXClient.Controls.CXC0003();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).BeginInit();
            this.gbPaymentDetail.SuspendLayout();
            this.grpIncome.SuspendLayout();
            this.grpDrawing.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkVIPCustomer
            // 
            this.chkVIPCustomer.AutoSize = true;
            this.chkVIPCustomer.Location = new System.Drawing.Point(248, 21);
            this.chkVIPCustomer.Name = "chkVIPCustomer";
            this.chkVIPCustomer.Size = new System.Drawing.Size(43, 17);
            this.chkVIPCustomer.TabIndex = 1;
            this.chkVIPCustomer.Text = "VIP";
            this.chkVIPCustomer.UseVisualStyleBackColor = true;
            this.chkVIPCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkVIPCustomer_KeyDown);
            // 
            // gvCustomer
            // 
            this.gvCustomer.AllowUserToDeleteRows = false;
            this.gvCustomer.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRegisterNo,
            this.colDrawerBank,
            this.colAccountNo,
            this.colName,
            this.colNrc,
            this.colAddress,
            this.colPhoneNo,
            this.colAmount,
            this.colCommission,
            this.colIBLChanges,
            this.colRemitAmount,
            this.colDelete});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvCustomer.DefaultCellStyle = dataGridViewCellStyle7;
            this.gvCustomer.EnableHeadersVisualStyles = false;
            this.gvCustomer.IdTSList = null;
            this.gvCustomer.IsEscapeKey = false;
            this.gvCustomer.IsHeaderClick = false;
            this.gvCustomer.Location = new System.Drawing.Point(11, 297);
            this.gvCustomer.Name = "gvCustomer";
            this.gvCustomer.RowHeadersWidth = 29;
            this.gvCustomer.ShowSerialNo = true;
            this.gvCustomer.Size = new System.Drawing.Size(1110, 293);
            this.gvCustomer.TabIndex = 15;
            this.gvCustomer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvCustomer_CellClick);
            this.gvCustomer.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvCustomer_CellLeave);
            this.gvCustomer.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gvCustomer_CellValidating);
            this.gvCustomer.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gvCustomer_EditingControlShowing);
            this.gvCustomer.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.gvCustomer_RowsRemoved);
            this.gvCustomer.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gvCustomer_RowValidating);
            // 
            // colRegisterNo
            // 
            this.colRegisterNo.DataPropertyName = "RegisterNo";
            this.colRegisterNo.HeaderText = "Register No.";
            this.colRegisterNo.MaxInputLength = 20;
            this.colRegisterNo.Name = "colRegisterNo";
            this.colRegisterNo.ReadOnly = true;
            this.colRegisterNo.Width = 80;
            // 
            // colDrawerBank
            // 
            this.colDrawerBank.DataPropertyName = "Dbank";
            this.colDrawerBank.HeaderText = "Drawer Bank";
            this.colDrawerBank.Name = "colDrawerBank";
            // 
            // colAccountNo
            // 
            this.colAccountNo.DataPropertyName = "ToAccountNo";
            dataGridViewCellStyle2.Format = "&&&-999-999999999";
            dataGridViewCellStyle2.NullValue = null;
            this.colAccountNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.colAccountNo.HeaderText = "Account No.";
            this.colAccountNo.MaxInputLength = 15;
            this.colAccountNo.Name = "colAccountNo";
            // 
            // colName
            // 
            this.colName.DataPropertyName = "ToName";
            this.colName.HeaderText = "Name";
            this.colName.MaxInputLength = 50;
            this.colName.Name = "colName";
            this.colName.Width = 150;
            // 
            // colNrc
            // 
            this.colNrc.DataPropertyName = "ToNRC";
            this.colNrc.HeaderText = "NRC";
            this.colNrc.MaxInputLength = 50;
            this.colNrc.Name = "colNrc";
            this.colNrc.Width = 140;
            // 
            // colAddress
            // 
            this.colAddress.DataPropertyName = "ToAddress";
            this.colAddress.HeaderText = "Address";
            this.colAddress.MaxInputLength = 300;
            this.colAddress.Name = "colAddress";
            this.colAddress.Width = 200;
            // 
            // colPhoneNo
            // 
            this.colPhoneNo.DataPropertyName = "ToPhoneNo";
            this.colPhoneNo.HeaderText = "Phone No.";
            this.colPhoneNo.MaxInputLength = 50;
            this.colPhoneNo.Name = "colPhoneNo";
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "ToAmount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.colAmount.HeaderText = "Amount";
            this.colAmount.MaxInputLength = 50;
            this.colAmount.Name = "colAmount";
            this.colAmount.Width = 80;
            // 
            // colCommission
            // 
            this.colCommission.DataPropertyName = "Commission";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.colCommission.DefaultCellStyle = dataGridViewCellStyle4;
            this.colCommission.HeaderText = "Commission";
            this.colCommission.MaxInputLength = 50;
            this.colCommission.Name = "colCommission";
            this.colCommission.ReadOnly = true;
            this.colCommission.Width = 80;
            // 
            // colIBLChanges
            // 
            this.colIBLChanges.DataPropertyName = "TelexCharges";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.colIBLChanges.DefaultCellStyle = dataGridViewCellStyle5;
            this.colIBLChanges.HeaderText = "IBL Charges";
            this.colIBLChanges.MaxInputLength = 50;
            this.colIBLChanges.Name = "colIBLChanges";
            this.colIBLChanges.ReadOnly = true;
            this.colIBLChanges.Width = 80;
            // 
            // colRemitAmount
            // 
            this.colRemitAmount.DataPropertyName = "RemitAmount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.colRemitAmount.DefaultCellStyle = dataGridViewCellStyle6;
            this.colRemitAmount.HeaderText = "Remit Amount";
            this.colRemitAmount.MaxInputLength = 100;
            this.colRemitAmount.Name = "colRemitAmount";
            this.colRemitAmount.ReadOnly = true;
            this.colRemitAmount.Width = 80;
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "";
            this.colDelete.Image = global::Ace.Cbs.Tel.Vew.Properties.Resources.Delete_Main;
            this.colDelete.Name = "colDelete";
            this.colDelete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDelete.Width = 30;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.CausesValidation = false;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(1234, 31);
            this.tsbCRUD.TabIndex = 19;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // txtGroupNo
            // 
            this.txtGroupNo.Enabled = false;
            this.txtGroupNo.Location = new System.Drawing.Point(116, 19);
            this.txtGroupNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtGroupNo.MaxLength = 11;
            this.txtGroupNo.Name = "txtGroupNo";
            this.txtGroupNo.Size = new System.Drawing.Size(115, 20);
            this.txtGroupNo.TabIndex = 0;
            // 
            // lblGroupNo
            // 
            this.lblGroupNo.AutoSize = true;
            this.lblGroupNo.Location = new System.Drawing.Point(24, 22);
            this.lblGroupNo.Name = "lblGroupNo";
            this.lblGroupNo.Size = new System.Drawing.Size(59, 13);
            this.lblGroupNo.TabIndex = 0;
            this.lblGroupNo.Text = "Group No :";
            // 
            // gbPaymentDetail
            // 
            this.gbPaymentDetail.Controls.Add(this.cxC00031);
            this.gbPaymentDetail.Controls.Add(this.lblSourceBr);
            this.gbPaymentDetail.Controls.Add(this.mtxtAccountNo);
            this.gbPaymentDetail.Controls.Add(this.cboCurrency);
            this.gbPaymentDetail.Controls.Add(this.grpIncome);
            this.gbPaymentDetail.Controls.Add(this.txtChequeNo);
            this.gbPaymentDetail.Controls.Add(this.butContinue);
            this.gbPaymentDetail.Controls.Add(this.lblCurrency);
            this.gbPaymentDetail.Controls.Add(this.lblTotalAmt);
            this.gbPaymentDetail.Controls.Add(this.butEnquiry);
            this.gbPaymentDetail.Controls.Add(this.lblAccountNo);
            this.gbPaymentDetail.Controls.Add(this.lblCheque);
            this.gbPaymentDetail.Controls.Add(this.txtTotalAmount);
            this.gbPaymentDetail.Controls.Add(this.lblName);
            this.gbPaymentDetail.Controls.Add(this.txtName);
            this.gbPaymentDetail.Controls.Add(this.lblNrcNo);
            this.gbPaymentDetail.Controls.Add(this.txtNRC);
            this.gbPaymentDetail.Controls.Add(this.lblAddress);
            this.gbPaymentDetail.Controls.Add(this.chkTakeIncome);
            this.gbPaymentDetail.Controls.Add(this.lblPhoneNo);
            this.gbPaymentDetail.Controls.Add(this.txtPhone);
            this.gbPaymentDetail.Controls.Add(this.txtAddress);
            this.gbPaymentDetail.Controls.Add(this.grpDrawing);
            this.gbPaymentDetail.Controls.Add(this.txtNarration);
            this.gbPaymentDetail.Controls.Add(this.lblNarration);
            this.gbPaymentDetail.Controls.Add(this.lblGroupNo);
            this.gbPaymentDetail.Controls.Add(this.txtGroupNo);
            this.gbPaymentDetail.Controls.Add(this.gvCustomer);
            this.gbPaymentDetail.Controls.Add(this.chkVIPCustomer);
            this.gbPaymentDetail.Location = new System.Drawing.Point(10, 37);
            this.gbPaymentDetail.Name = "gbPaymentDetail";
            this.gbPaymentDetail.Size = new System.Drawing.Size(1132, 605);
            this.gbPaymentDetail.TabIndex = 0;
            this.gbPaymentDetail.TabStop = false;
            this.gbPaymentDetail.Text = "    ";
            this.gbPaymentDetail.Enter += new System.EventHandler(this.gbPaymentDetail_Enter);
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cxC00031.Location = new System.Drawing.Point(905, 20);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(55, 13);
            this.cxC00031.TabIndex = 22;
            this.cxC00031.Text = "Branch :";
            // 
            // lblSourceBr
            // 
            this.lblSourceBr.AutoSize = true;
            this.lblSourceBr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSourceBr.Location = new System.Drawing.Point(966, 20);
            this.lblSourceBr.Name = "lblSourceBr";
            this.lblSourceBr.Size = new System.Drawing.Size(143, 13);
            this.lblSourceBr.TabIndex = 22;
            this.lblSourceBr.Text = "Source Branch            :";
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(116, 92);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 2;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
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
            this.cboCurrency.Location = new System.Drawing.Point(116, 119);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 4;
            this.cboCurrency.Validated += new System.EventHandler(this.cboCurrency_Validated);
            // 
            // grpIncome
            // 
            this.grpIncome.Controls.Add(this.rdoNoIncome);
            this.grpIncome.Controls.Add(this.rdoIncome);
            this.grpIncome.Location = new System.Drawing.Point(116, 42);
            this.grpIncome.Name = "grpIncome";
            this.grpIncome.Size = new System.Drawing.Size(176, 41);
            this.grpIncome.TabIndex = 0;
            this.grpIncome.TabStop = false;
            this.grpIncome.Text = "Income";
            // 
            // rdoNoIncome
            // 
            this.rdoNoIncome.AutoSize = true;
            this.rdoNoIncome.Location = new System.Drawing.Point(93, 14);
            this.rdoNoIncome.Name = "rdoNoIncome";
            this.rdoNoIncome.Size = new System.Drawing.Size(77, 17);
            this.rdoNoIncome.TabIndex = 1;
            this.rdoNoIncome.Text = "No Income";
            this.rdoNoIncome.UseVisualStyleBackColor = true;
            this.rdoNoIncome.CheckedChanged += new System.EventHandler(this.Income_CheckedChanged);
            this.rdoNoIncome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdoNoIncome_KeyDown);
            // 
            // rdoIncome
            // 
            this.rdoIncome.AutoSize = true;
            this.rdoIncome.Checked = true;
            this.rdoIncome.Location = new System.Drawing.Point(6, 14);
            this.rdoIncome.Name = "rdoIncome";
            this.rdoIncome.Size = new System.Drawing.Size(60, 17);
            this.rdoIncome.TabIndex = 2;
            this.rdoIncome.TabStop = true;
            this.rdoIncome.Text = "Income";
            this.rdoIncome.UseVisualStyleBackColor = true;
            this.rdoIncome.CheckedChanged += new System.EventHandler(this.Income_CheckedChanged);
            this.rdoIncome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdoIncome_KeyDown);
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.Location = new System.Drawing.Point(500, 264);
            this.txtChequeNo.Mask = "99999999";
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(111, 20);
            this.txtChequeNo.TabIndex = 13;
            this.txtChequeNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtChequeNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChequeNo_KeyDown);
            // 
            // butContinue
            // 
            this.butContinue.Location = new System.Drawing.Point(1028, 258);
            this.butContinue.Name = "butContinue";
            this.butContinue.Size = new System.Drawing.Size(76, 30);
            this.butContinue.TabIndex = 14;
            this.butContinue.Text = "&Continue";
            this.butContinue.UseVisualStyleBackColor = true;
            this.butContinue.Click += new System.EventHandler(this.butContinue_Click);
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(24, 122);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 0;
            this.lblCurrency.Text = "Currency :";
            // 
            // lblTotalAmt
            // 
            this.lblTotalAmt.AutoSize = true;
            this.lblTotalAmt.Location = new System.Drawing.Point(396, 208);
            this.lblTotalAmt.Name = "lblTotalAmt";
            this.lblTotalAmt.Size = new System.Drawing.Size(76, 13);
            this.lblTotalAmt.TabIndex = 0;
            this.lblTotalAmt.Text = "Total Amount :";
            // 
            // butEnquiry
            // 
            this.butEnquiry.Image = global::Ace.Cbs.Tel.Vew.Properties.Resources.find1;
            this.butEnquiry.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butEnquiry.Location = new System.Drawing.Point(272, 86);
            this.butEnquiry.Name = "butEnquiry";
            this.butEnquiry.Size = new System.Drawing.Size(81, 30);
            this.butEnquiry.TabIndex = 3;
            this.butEnquiry.Text = "&Enquiry";
            this.butEnquiry.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butEnquiry.UseVisualStyleBackColor = true;
            this.butEnquiry.Click += new System.EventHandler(this.butEnquiry_Click);
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(24, 95);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(70, 13);
            this.lblAccountNo.TabIndex = 0;
            this.lblAccountNo.Text = "Account No :";
            // 
            // lblCheque
            // 
            this.lblCheque.AutoSize = true;
            this.lblCheque.Location = new System.Drawing.Point(396, 267);
            this.lblCheque.Name = "lblCheque";
            this.lblCheque.Size = new System.Drawing.Size(67, 13);
            this.lblCheque.TabIndex = 0;
            this.lblCheque.Text = "Cheque No :";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.DecimalPlaces = 2;
            this.txtTotalAmount.IsSendTabOnEnter = true;
            this.txtTotalAmount.IsThousandSeperator = true;
            this.txtTotalAmount.IsUseFloatingPoint = true;
            this.txtTotalAmount.Location = new System.Drawing.Point(500, 205);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(111, 20);
            this.txtTotalAmount.TabIndex = 11;
            this.txtTotalAmount.Text = "0.00";
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(24, 148);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name :";
            // 
            // txtName
            // 
            this.txtName.IsSendTabOnEnter = true;
            this.txtName.Location = new System.Drawing.Point(116, 145);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(175, 20);
            this.txtName.TabIndex = 5;
            // 
            // lblNrcNo
            // 
            this.lblNrcNo.AutoSize = true;
            this.lblNrcNo.Location = new System.Drawing.Point(24, 177);
            this.lblNrcNo.Name = "lblNrcNo";
            this.lblNrcNo.Size = new System.Drawing.Size(53, 13);
            this.lblNrcNo.TabIndex = 0;
            this.lblNrcNo.Text = "NRC No :";
            // 
            // txtNRC
            // 
            this.txtNRC.IsSendTabOnEnter = true;
            this.txtNRC.Location = new System.Drawing.Point(116, 174);
            this.txtNRC.Name = "txtNRC";
            this.txtNRC.Size = new System.Drawing.Size(175, 20);
            this.txtNRC.TabIndex = 6;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(24, 208);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(51, 13);
            this.lblAddress.TabIndex = 0;
            this.lblAddress.Text = "Address :";
            // 
            // chkTakeIncome
            // 
            this.chkTakeIncome.AutoSize = true;
            this.chkTakeIncome.Location = new System.Drawing.Point(399, 238);
            this.chkTakeIncome.Name = "chkTakeIncome";
            this.chkTakeIncome.Size = new System.Drawing.Size(193, 17);
            this.chkTakeIncome.TabIndex = 12;
            this.chkTakeIncome.Text = "Take Income from Drawing Amount";
            this.chkTakeIncome.UseVisualStyleBackColor = true;
            this.chkTakeIncome.CheckedChanged += new System.EventHandler(this.chkTakeIncome_CheckedChanged);
            this.chkTakeIncome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkTakeIncome_KeyDown);
            // 
            // lblPhoneNo
            // 
            this.lblPhoneNo.AutoSize = true;
            this.lblPhoneNo.Location = new System.Drawing.Point(24, 267);
            this.lblPhoneNo.Name = "lblPhoneNo";
            this.lblPhoneNo.Size = new System.Drawing.Size(61, 13);
            this.lblPhoneNo.TabIndex = 0;
            this.lblPhoneNo.Text = "Phone No :";
            // 
            // txtPhone
            // 
            this.txtPhone.IsSendTabOnEnter = true;
            this.txtPhone.Location = new System.Drawing.Point(116, 264);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(175, 20);
            this.txtPhone.TabIndex = 8;
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // txtAddress
            // 
            this.txtAddress.IsSendTabOnEnter = true;
            this.txtAddress.Location = new System.Drawing.Point(116, 205);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(175, 50);
            this.txtAddress.TabIndex = 7;
            // 
            // grpDrawing
            // 
            this.grpDrawing.Controls.Add(this.rdoIncomeByCash);
            this.grpDrawing.Controls.Add(this.rdoIncomeByTransfer);
            this.grpDrawing.Location = new System.Drawing.Point(500, 86);
            this.grpDrawing.Name = "grpDrawing";
            this.grpDrawing.Size = new System.Drawing.Size(175, 50);
            this.grpDrawing.TabIndex = 9;
            this.grpDrawing.TabStop = false;
            this.grpDrawing.Text = "Drawing Income";
            // 
            // rdoIncomeByCash
            // 
            this.rdoIncomeByCash.AutoSize = true;
            this.rdoIncomeByCash.Checked = true;
            this.rdoIncomeByCash.Location = new System.Drawing.Point(6, 19);
            this.rdoIncomeByCash.Name = "rdoIncomeByCash";
            this.rdoIncomeByCash.Size = new System.Drawing.Size(64, 17);
            this.rdoIncomeByCash.TabIndex = 11;
            this.rdoIncomeByCash.TabStop = true;
            this.rdoIncomeByCash.Text = "By Cash";
            this.rdoIncomeByCash.UseVisualStyleBackColor = true;
            this.rdoIncomeByCash.CheckedChanged += new System.EventHandler(this.IncomeCheckBox_CheckedChanged);
            // 
            // rdoIncomeByTransfer
            // 
            this.rdoIncomeByTransfer.AutoSize = true;
            this.rdoIncomeByTransfer.Location = new System.Drawing.Point(90, 19);
            this.rdoIncomeByTransfer.Name = "rdoIncomeByTransfer";
            this.rdoIncomeByTransfer.Size = new System.Drawing.Size(79, 17);
            this.rdoIncomeByTransfer.TabIndex = 12;
            this.rdoIncomeByTransfer.Text = "By Transfer";
            this.rdoIncomeByTransfer.UseVisualStyleBackColor = true;
            this.rdoIncomeByTransfer.CheckedChanged += new System.EventHandler(this.IncomeCheckBox_CheckedChanged);
            // 
            // txtNarration
            // 
            this.txtNarration.IsSendTabOnEnter = true;
            this.txtNarration.Location = new System.Drawing.Point(500, 144);
            this.txtNarration.Multiline = true;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(175, 50);
            this.txtNarration.TabIndex = 10;
            // 
            // lblNarration
            // 
            this.lblNarration.AutoSize = true;
            this.lblNarration.Location = new System.Drawing.Point(396, 148);
            this.lblNarration.Name = "lblNarration";
            this.lblNarration.Size = new System.Drawing.Size(56, 13);
            this.lblNarration.TabIndex = 0;
            this.lblNarration.Text = "Narration :";
            // 
            // TLMVEW00018
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 654);
            this.Controls.Add(this.gbPaymentDetail);
            this.Controls.Add(this.tsbCRUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TLMVEW00018";
            this.Text = "Drawing Remittance";
            this.Load += new System.EventHandler(this.frmTLMVEW00018_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).EndInit();
            this.gbPaymentDetail.ResumeLayout(false);
            this.gbPaymentDetail.PerformLayout();
            this.grpIncome.ResumeLayout(false);
            this.grpIncome.PerformLayout();
            this.grpDrawing.ResumeLayout(false);
            this.grpDrawing.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkVIPCustomer;
        private Ace.Windows.CXClient.Controls.AceGridView gvCustomer;
        private Ace.Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.TextBox txtGroupNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblGroupNo;
        private System.Windows.Forms.GroupBox gbPaymentDetail;
        private System.Windows.Forms.RadioButton rdoIncome;
        private System.Windows.Forms.RadioButton rdoNoIncome;
        private System.Windows.Forms.MaskedTextBox txtChequeNo;
        private System.Windows.Forms.Button butContinue;
        private Ace.Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Ace.Windows.CXClient.Controls.CXC0003 lblTotalAmt;
        private System.Windows.Forms.Button butEnquiry;
        private Ace.Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblCheque;
        private Ace.Windows.CXClient.Controls.CXC0004 txtTotalAmount;
        private Ace.Windows.CXClient.Controls.CXC0003 lblName;
        private Ace.Windows.CXClient.Controls.CXC0001 txtName;
        private Ace.Windows.CXClient.Controls.CXC0003 lblNrcNo;
        private Ace.Windows.CXClient.Controls.CXC0001 txtNRC;
        private Ace.Windows.CXClient.Controls.CXC0003 lblAddress;
        private System.Windows.Forms.CheckBox chkTakeIncome;
        private Ace.Windows.CXClient.Controls.CXC0003 lblPhoneNo;
        private Ace.Windows.CXClient.Controls.CXC0001 txtPhone;
        private Ace.Windows.CXClient.Controls.CXC0001 txtAddress;
        private System.Windows.Forms.GroupBox grpDrawing;
        private System.Windows.Forms.RadioButton rdoIncomeByCash;
        private System.Windows.Forms.RadioButton rdoIncomeByTransfer;
        private Ace.Windows.CXClient.Controls.CXC0001 txtNarration;
        private Ace.Windows.CXClient.Controls.CXC0003 lblNarration;
        private System.Windows.Forms.GroupBox grpIncome;
        private System.Windows.Forms.DataGridViewTextBoxColumn coklPhoneNo;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblSourceBr;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegisterNo;
        private System.Windows.Forms.DataGridViewComboBoxColumn colDrawerBank;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNrc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhoneNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCommission;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIBLChanges;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemitAmount;
        private System.Windows.Forms.DataGridViewImageColumn colDelete;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
    }
}