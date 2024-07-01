namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00014
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00014));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.butCalculate = new Ace.Windows.CXClient.Controls.CXC0007();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.rdoIncomeByTransfer = new System.Windows.Forms.RadioButton();
            this.rdoIncomeByCash = new System.Windows.Forms.RadioButton();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtGroupNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblGroupNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtChequeNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.mtxtAccountNo = new System.Windows.Forms.MaskedTextBox();
            this.lblAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCheque = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtNoOfPersonToSign = new Ace.Windows.CXClient.Controls.CXC0004();
            this.gbJoin = new System.Windows.Forms.GroupBox();
            this.gbJointType = new System.Windows.Forms.GroupBox();
            this.rdoJointTypeB = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoJointTypeA = new Ace.Windows.CXClient.Controls.CXC0009();
            this.lblNoOfPersonToSign = new Ace.Windows.CXClient.Controls.CXC0003();
            this.chkPrintTransactions = new System.Windows.Forms.CheckBox();
            this.butAdd = new System.Windows.Forms.Button();
            this.chkInputIncomeAmount = new System.Windows.Forms.CheckBox();
            this.gbOnlineInformation = new System.Windows.Forms.GroupBox();
            this.txtCommissions = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtCommunicationCharges = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblCommissions = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCommunicationCharges = new Ace.Windows.CXClient.Controls.CXC0003();
            this.chkVIPCustomer = new Ace.Windows.CXClient.Controls.CXC0008();
            this.txtTotalAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblTotalAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.butEnquiry = new System.Windows.Forms.Button();
            this.gvMultiAccountWithdrawl = new Ace.Windows.CXClient.Controls.AceGridView();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VIP = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colNOPSign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCommunicationCharges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCommissions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrint = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbWithdrawal = new System.Windows.Forms.GroupBox();
            this.lblTotalCharges = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtTotalCharges = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblTransactionDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gbJoin.SuspendLayout();
            this.gbJointType.SuspendLayout();
            this.gbOnlineInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMultiAccountWithdrawl)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbWithdrawal.SuspendLayout();
            this.SuspendLayout();
            // 
            // butCalculate
            // 
            this.butCalculate.Image = global::Ace.Cbs.Tel.Vew.Properties.Resources.Money_Calculator;
            this.butCalculate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCalculate.Location = new System.Drawing.Point(248, 118);
            this.butCalculate.Name = "butCalculate";
            this.butCalculate.Size = new System.Drawing.Size(90, 30);
            this.butCalculate.TabIndex = 8;
            this.butCalculate.Text = "&Calculate";
            this.butCalculate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCalculate.UseVisualStyleBackColor = true;
            this.butCalculate.Click += new System.EventHandler(this.butCalculate_Click);
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-3, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(988, 31);
            this.tsbCRUD.TabIndex = 1;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // rdoIncomeByTransfer
            // 
            this.rdoIncomeByTransfer.AutoSize = true;
            this.rdoIncomeByTransfer.Location = new System.Drawing.Point(114, 19);
            this.rdoIncomeByTransfer.Name = "rdoIncomeByTransfer";
            this.rdoIncomeByTransfer.Size = new System.Drawing.Size(117, 17);
            this.rdoIncomeByTransfer.TabIndex = 10;
            this.rdoIncomeByTransfer.Text = "Income By Transfer";
            this.rdoIncomeByTransfer.UseVisualStyleBackColor = true;
            // 
            // rdoIncomeByCash
            // 
            this.rdoIncomeByCash.AutoSize = true;
            this.rdoIncomeByCash.Checked = true;
            this.rdoIncomeByCash.Location = new System.Drawing.Point(6, 19);
            this.rdoIncomeByCash.Name = "rdoIncomeByCash";
            this.rdoIncomeByCash.Size = new System.Drawing.Size(102, 17);
            this.rdoIncomeByCash.TabIndex = 1;
            this.rdoIncomeByCash.TabStop = true;
            this.rdoIncomeByCash.Text = "Income By Cash";
            this.rdoIncomeByCash.UseVisualStyleBackColor = true;
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
            this.cboCurrency.Location = new System.Drawing.Point(89, 45);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 1;
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(6, 48);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 0;
            this.lblCurrency.Text = "Currency :";
            // 
            // txtGroupNo
            // 
            this.txtGroupNo.Enabled = false;
            this.txtGroupNo.IsSendTabOnEnter = true;
            this.txtGroupNo.Location = new System.Drawing.Point(89, 19);
            this.txtGroupNo.Name = "txtGroupNo";
            this.txtGroupNo.Size = new System.Drawing.Size(115, 20);
            this.txtGroupNo.TabIndex = 0;
            this.txtGroupNo.TabStop = false;
            // 
            // lblGroupNo
            // 
            this.lblGroupNo.AutoSize = true;
            this.lblGroupNo.Location = new System.Drawing.Point(6, 22);
            this.lblGroupNo.Name = "lblGroupNo";
            this.lblGroupNo.Size = new System.Drawing.Size(59, 13);
            this.lblGroupNo.TabIndex = 0;
            this.lblGroupNo.Text = "Group No :";
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.IsSendTabOnEnter = true;
            this.txtChequeNo.Location = new System.Drawing.Point(89, 98);
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(115, 20);
            this.txtChequeNo.TabIndex = 6;
            this.txtChequeNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.Location = new System.Drawing.Point(89, 72);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 3;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(6, 127);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(49, 13);
            this.lblAmount.TabIndex = 0;
            this.lblAmount.Text = "Amount :";
            // 
            // lblCheque
            // 
            this.lblCheque.AutoSize = true;
            this.lblCheque.Location = new System.Drawing.Point(6, 101);
            this.lblCheque.Name = "lblCheque";
            this.lblCheque.Size = new System.Drawing.Size(50, 13);
            this.lblCheque.TabIndex = 0;
            this.lblCheque.Text = "Cheque :";
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(6, 75);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(70, 13);
            this.lblAccountNo.TabIndex = 0;
            this.lblAccountNo.Text = "Account No :";
            // 
            // txtNoOfPersonToSign
            // 
            this.txtNoOfPersonToSign.DecimalPlaces = 0;
            this.txtNoOfPersonToSign.IsSendTabOnEnter = true;
            this.txtNoOfPersonToSign.Location = new System.Drawing.Point(89, 20);
            this.txtNoOfPersonToSign.Name = "txtNoOfPersonToSign";
            this.txtNoOfPersonToSign.ReadOnly = true;
            this.txtNoOfPersonToSign.Size = new System.Drawing.Size(105, 20);
            this.txtNoOfPersonToSign.TabIndex = 1005;
            this.txtNoOfPersonToSign.Text = "0";
            this.txtNoOfPersonToSign.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNoOfPersonToSign.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // gbJoin
            // 
            this.gbJoin.Controls.Add(this.gbJointType);
            this.gbJoin.Controls.Add(this.txtNoOfPersonToSign);
            this.gbJoin.Controls.Add(this.lblNoOfPersonToSign);
            this.gbJoin.Location = new System.Drawing.Point(9, 203);
            this.gbJoin.Name = "gbJoin";
            this.gbJoin.Size = new System.Drawing.Size(370, 55);
            this.gbJoin.TabIndex = 1000;
            this.gbJoin.TabStop = false;
            // 
            // gbJointType
            // 
            this.gbJointType.Controls.Add(this.rdoJointTypeB);
            this.gbJointType.Controls.Add(this.rdoJointTypeA);
            this.gbJointType.Location = new System.Drawing.Point(213, 10);
            this.gbJointType.Name = "gbJointType";
            this.gbJointType.Size = new System.Drawing.Size(146, 39);
            this.gbJointType.TabIndex = 0;
            this.gbJointType.TabStop = false;
            this.gbJointType.Text = "Joint Type";
            // 
            // rdoJointTypeB
            // 
            this.rdoJointTypeB.AutoCheck = false;
            this.rdoJointTypeB.AutoSize = true;
            this.rdoJointTypeB.IsSendTabOnEnter = true;
            this.rdoJointTypeB.Location = new System.Drawing.Point(81, 13);
            this.rdoJointTypeB.Name = "rdoJointTypeB";
            this.rdoJointTypeB.Size = new System.Drawing.Size(59, 17);
            this.rdoJointTypeB.TabIndex = 1004;
            this.rdoJointTypeB.TabStop = true;
            this.rdoJointTypeB.Text = "Type B";
            this.rdoJointTypeB.UseVisualStyleBackColor = true;
            // 
            // rdoJointTypeA
            // 
            this.rdoJointTypeA.AutoCheck = false;
            this.rdoJointTypeA.AutoSize = true;
            this.rdoJointTypeA.IsSendTabOnEnter = true;
            this.rdoJointTypeA.Location = new System.Drawing.Point(6, 13);
            this.rdoJointTypeA.Name = "rdoJointTypeA";
            this.rdoJointTypeA.Size = new System.Drawing.Size(59, 17);
            this.rdoJointTypeA.TabIndex = 1002;
            this.rdoJointTypeA.TabStop = true;
            this.rdoJointTypeA.Text = "Type A";
            this.rdoJointTypeA.UseVisualStyleBackColor = true;
            // 
            // lblNoOfPersonToSign
            // 
            this.lblNoOfPersonToSign.AutoSize = true;
            this.lblNoOfPersonToSign.Location = new System.Drawing.Point(6, 23);
            this.lblNoOfPersonToSign.Name = "lblNoOfPersonToSign";
            this.lblNoOfPersonToSign.Size = new System.Drawing.Size(75, 13);
            this.lblNoOfPersonToSign.TabIndex = 0;
            this.lblNoOfPersonToSign.Text = "No of Person :";
            // 
            // chkPrintTransactions
            // 
            this.chkPrintTransactions.AutoSize = true;
            this.chkPrintTransactions.Location = new System.Drawing.Point(669, 234);
            this.chkPrintTransactions.Name = "chkPrintTransactions";
            this.chkPrintTransactions.Size = new System.Drawing.Size(109, 17);
            this.chkPrintTransactions.TabIndex = 12;
            this.chkPrintTransactions.Text = "Print  Transaction";
            this.chkPrintTransactions.UseVisualStyleBackColor = true;
            // 
            // butAdd
            // 
            this.butAdd.CausesValidation = false;
            this.butAdd.Image = ((System.Drawing.Image)(resources.GetObject("butAdd.Image")));
            this.butAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAdd.Location = new System.Drawing.Point(852, 226);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(64, 30);
            this.butAdd.TabIndex = 13;
            this.butAdd.Text = "&Add";
            this.butAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // chkInputIncomeAmount
            // 
            this.chkInputIncomeAmount.AutoSize = true;
            this.chkInputIncomeAmount.Location = new System.Drawing.Point(393, 169);
            this.chkInputIncomeAmount.Name = "chkInputIncomeAmount";
            this.chkInputIncomeAmount.Size = new System.Drawing.Size(127, 17);
            this.chkInputIncomeAmount.TabIndex = 10;
            this.chkInputIncomeAmount.Text = "Input Income Amount";
            this.chkInputIncomeAmount.UseVisualStyleBackColor = true;
            this.chkInputIncomeAmount.CheckedChanged += new System.EventHandler(this.ckhInputIncomeAmount_CheckedChanged);
            // 
            // gbOnlineInformation
            // 
            this.gbOnlineInformation.Controls.Add(this.txtCommissions);
            this.gbOnlineInformation.Controls.Add(this.txtCommunicationCharges);
            this.gbOnlineInformation.Controls.Add(this.lblCommissions);
            this.gbOnlineInformation.Controls.Add(this.lblCommunicationCharges);
            this.gbOnlineInformation.Location = new System.Drawing.Point(393, 193);
            this.gbOnlineInformation.Name = "gbOnlineInformation";
            this.gbOnlineInformation.Size = new System.Drawing.Size(270, 65);
            this.gbOnlineInformation.TabIndex = 11;
            this.gbOnlineInformation.TabStop = false;
            // 
            // txtCommissions
            // 
            this.txtCommissions.DecimalPlaces = 0;
            this.txtCommissions.IsSendTabOnEnter = true;
            this.txtCommissions.Location = new System.Drawing.Point(150, 39);
            this.txtCommissions.Name = "txtCommissions";
            this.txtCommissions.Size = new System.Drawing.Size(111, 20);
            this.txtCommissions.TabIndex = 2;
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
            this.txtCommunicationCharges.DecimalPlaces = 0;
            this.txtCommunicationCharges.IsSendTabOnEnter = true;
            this.txtCommunicationCharges.Location = new System.Drawing.Point(150, 13);
            this.txtCommunicationCharges.Name = "txtCommunicationCharges";
            this.txtCommunicationCharges.Size = new System.Drawing.Size(111, 20);
            this.txtCommunicationCharges.TabIndex = 1;
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
            this.lblCommissions.Location = new System.Drawing.Point(6, 42);
            this.lblCommissions.Name = "lblCommissions";
            this.lblCommissions.Size = new System.Drawing.Size(73, 13);
            this.lblCommissions.TabIndex = 0;
            this.lblCommissions.Text = "Commissions :";
            // 
            // lblCommunicationCharges
            // 
            this.lblCommunicationCharges.AutoSize = true;
            this.lblCommunicationCharges.Location = new System.Drawing.Point(6, 16);
            this.lblCommunicationCharges.Name = "lblCommunicationCharges";
            this.lblCommunicationCharges.Size = new System.Drawing.Size(127, 13);
            this.lblCommunicationCharges.TabIndex = 0;
            this.lblCommunicationCharges.Text = "Communication Charges :";
            // 
            // chkVIPCustomer
            // 
            this.chkVIPCustomer.AutoSize = true;
            this.chkVIPCustomer.IsSendTabOnEnter = true;
            this.chkVIPCustomer.Location = new System.Drawing.Point(228, 47);
            this.chkVIPCustomer.Name = "chkVIPCustomer";
            this.chkVIPCustomer.Size = new System.Drawing.Size(43, 17);
            this.chkVIPCustomer.TabIndex = 2;
            this.chkVIPCustomer.Text = "VIP";
            this.chkVIPCustomer.UseVisualStyleBackColor = true;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.DecimalPlaces = 2;
            this.txtTotalAmount.IsSendTabOnEnter = true;
            this.txtTotalAmount.Location = new System.Drawing.Point(811, 488);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(105, 20);
            this.txtTotalAmount.TabIndex = 16;
            this.txtTotalAmount.Text = "0.00";
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(702, 491);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(76, 13);
            this.lblTotalAmount.TabIndex = 19;
            this.lblTotalAmount.Text = "Total Amount :";
            // 
            // butEnquiry
            // 
            this.butEnquiry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.butEnquiry.Image = global::Ace.Cbs.Tel.Vew.Properties.Resources.find1;
            this.butEnquiry.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.butEnquiry.Location = new System.Drawing.Point(257, 66);
            this.butEnquiry.Name = "butEnquiry";
            this.butEnquiry.Size = new System.Drawing.Size(81, 30);
            this.butEnquiry.TabIndex = 5;
            this.butEnquiry.Text = "&Enquiry";
            this.butEnquiry.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butEnquiry.UseVisualStyleBackColor = true;
            this.butEnquiry.Click += new System.EventHandler(this.butEnquiry_Click);
            // 
            // gvMultiAccountWithdrawl
            // 
            this.gvMultiAccountWithdrawl.AllowUserToAddRows = false;
            this.gvMultiAccountWithdrawl.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvMultiAccountWithdrawl.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvMultiAccountWithdrawl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvMultiAccountWithdrawl.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewImageColumn1,
            this.dataGridViewImageColumn2,
            this.dataGridViewTextBoxColumn1,
            this.colCheque,
            this.VIP,
            this.colNOPSign,
            this.dataGridViewTextBoxColumn3,
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
            this.gvMultiAccountWithdrawl.DefaultCellStyle = dataGridViewCellStyle5;
            this.gvMultiAccountWithdrawl.EnableHeadersVisualStyles = false;
            this.gvMultiAccountWithdrawl.IdTSList = null;
            this.gvMultiAccountWithdrawl.IsEscapeKey = false;
            this.gvMultiAccountWithdrawl.IsHeaderClick = false;
            this.gvMultiAccountWithdrawl.Location = new System.Drawing.Point(9, 264);
            this.gvMultiAccountWithdrawl.Name = "gvMultiAccountWithdrawl";
            this.gvMultiAccountWithdrawl.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvMultiAccountWithdrawl.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gvMultiAccountWithdrawl.RowHeadersWidth = 25;
            this.gvMultiAccountWithdrawl.ShowSerialNo = true;
            this.gvMultiAccountWithdrawl.Size = new System.Drawing.Size(907, 218);
            this.gvMultiAccountWithdrawl.TabIndex = 16;
            this.gvMultiAccountWithdrawl.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMultiAccountWithdrawlInformation_CellClick);
            this.gvMultiAccountWithdrawl.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gvMultiAccountWithdrawlInformation_DataError);
            this.gvMultiAccountWithdrawl.Leave += new System.EventHandler(this.gvMultiAccountWithdrawl_Leave);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::Ace.Cbs.Tel.Vew.Properties.Resources.Edit_Main;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.ToolTipText = "Edit";
            this.dataGridViewImageColumn1.Width = 30;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::Ace.Cbs.Tel.Vew.Properties.Resources.Delete_Main;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.ToolTipText = "Delete";
            this.dataGridViewImageColumn2.Width = 30;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "AccountNo";
            this.dataGridViewTextBoxColumn1.HeaderText = "Account No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // colCheque
            // 
            this.colCheque.DataPropertyName = "ChequeNo";
            this.colCheque.HeaderText = "Cheque";
            this.colCheque.Name = "colCheque";
            this.colCheque.ReadOnly = true;
            // 
            // VIP
            // 
            this.VIP.DataPropertyName = "IsVIP";
            this.VIP.HeaderText = "VIP";
            this.VIP.Name = "VIP";
            this.VIP.ReadOnly = true;
            this.VIP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.VIP.Width = 50;
            // 
            // colNOPSign
            // 
            this.colNOPSign.DataPropertyName = "NoOfPerSignJoinType";
            this.colNOPSign.HeaderText = "NOPSign/Type";
            this.colNOPSign.Name = "colNOPSign";
            this.colNOPSign.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Amount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn3.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // colCommunicationCharges
            // 
            this.colCommunicationCharges.DataPropertyName = "CommunicationCharges";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.colCommunicationCharges.DefaultCellStyle = dataGridViewCellStyle3;
            this.colCommunicationCharges.HeaderText = "Communication Charges";
            this.colCommunicationCharges.Name = "colCommunicationCharges";
            this.colCommunicationCharges.ReadOnly = true;
            this.colCommunicationCharges.Width = 150;
            // 
            // colCommissions
            // 
            this.colCommissions.DataPropertyName = "Commission";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.colCommissions.DefaultCellStyle = dataGridViewCellStyle4;
            this.colCommissions.HeaderText = "Commissions";
            this.colCommissions.Name = "colCommissions";
            this.colCommissions.ReadOnly = true;
            // 
            // colPrint
            // 
            this.colPrint.DataPropertyName = "PrintTransactionStatus";
            this.colPrint.FalseValue = "false";
            this.colPrint.HeaderText = "Print";
            this.colPrint.Name = "colPrint";
            this.colPrint.ReadOnly = true;
            this.colPrint.TrueValue = "true";
            this.colPrint.Width = 50;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoIncomeByCash);
            this.groupBox1.Controls.Add(this.rdoIncomeByTransfer);
            this.groupBox1.Location = new System.Drawing.Point(9, 150);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 47);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // gbWithdrawal
            // 
            this.gbWithdrawal.Controls.Add(this.lblTransactionDate);
            this.gbWithdrawal.Controls.Add(this.lblTotalCharges);
            this.gbWithdrawal.Controls.Add(this.cxC00031);
            this.gbWithdrawal.Controls.Add(this.txtTotalCharges);
            this.gbWithdrawal.Controls.Add(this.txtAmount);
            this.gbWithdrawal.Controls.Add(this.gvMultiAccountWithdrawl);
            this.gbWithdrawal.Controls.Add(this.butCalculate);
            this.gbWithdrawal.Controls.Add(this.txtTotalAmount);
            this.gbWithdrawal.Controls.Add(this.lblTotalAmount);
            this.gbWithdrawal.Controls.Add(this.groupBox1);
            this.gbWithdrawal.Controls.Add(this.lblGroupNo);
            this.gbWithdrawal.Controls.Add(this.butAdd);
            this.gbWithdrawal.Controls.Add(this.gbJoin);
            this.gbWithdrawal.Controls.Add(this.chkPrintTransactions);
            this.gbWithdrawal.Controls.Add(this.gbOnlineInformation);
            this.gbWithdrawal.Controls.Add(this.chkInputIncomeAmount);
            this.gbWithdrawal.Controls.Add(this.txtGroupNo);
            this.gbWithdrawal.Controls.Add(this.chkVIPCustomer);
            this.gbWithdrawal.Controls.Add(this.cboCurrency);
            this.gbWithdrawal.Controls.Add(this.mtxtAccountNo);
            this.gbWithdrawal.Controls.Add(this.lblCurrency);
            this.gbWithdrawal.Controls.Add(this.txtChequeNo);
            this.gbWithdrawal.Controls.Add(this.lblAccountNo);
            this.gbWithdrawal.Controls.Add(this.lblCheque);
            this.gbWithdrawal.Controls.Add(this.butEnquiry);
            this.gbWithdrawal.Controls.Add(this.lblAmount);
            this.gbWithdrawal.Location = new System.Drawing.Point(11, 37);
            this.gbWithdrawal.Name = "gbWithdrawal";
            this.gbWithdrawal.Size = new System.Drawing.Size(926, 550);
            this.gbWithdrawal.TabIndex = 0;
            this.gbWithdrawal.TabStop = false;
            // 
            // lblTotalCharges
            // 
            this.lblTotalCharges.AutoSize = true;
            this.lblTotalCharges.Location = new System.Drawing.Point(702, 517);
            this.lblTotalCharges.Name = "lblTotalCharges";
            this.lblTotalCharges.Size = new System.Drawing.Size(79, 13);
            this.lblTotalCharges.TabIndex = 0;
            this.lblTotalCharges.Text = "Total Charges :";
            // 
            // txtTotalCharges
            // 
            this.txtTotalCharges.DecimalPlaces = 2;
            this.txtTotalCharges.IsSendTabOnEnter = true;
            this.txtTotalCharges.Location = new System.Drawing.Point(811, 514);
            this.txtTotalCharges.Name = "txtTotalCharges";
            this.txtTotalCharges.ReadOnly = true;
            this.txtTotalCharges.Size = new System.Drawing.Size(105, 20);
            this.txtTotalCharges.TabIndex = 17;
            this.txtTotalCharges.Text = "0.00";
            this.txtTotalCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalCharges.Value = new decimal(new int[] {
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
            this.txtAmount.Location = new System.Drawing.Point(89, 124);
            this.txtAmount.MaxLength = 18;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(115, 20);
            this.txtAmount.TabIndex = 7;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblTransactionDate
            // 
            this.lblTransactionDate.AutoSize = true;
            this.lblTransactionDate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblTransactionDate.Location = new System.Drawing.Point(850, 16);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Size = new System.Drawing.Size(0, 13);
            this.lblTransactionDate.TabIndex = 10;
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.cxC00031.Location = new System.Drawing.Point(749, 16);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(95, 13);
            this.cxC00031.TabIndex = 9;
            this.cxC00031.Text = "Transaction Date :";
            // 
            // TLMVEW00014
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(984, 599);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.gbWithdrawal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00014";
            this.Text = "Withdrawal Entry";
            this.Load += new System.EventHandler(this.TLMVEW00014_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TLMVEW00014_KeyDown);
            this.gbJoin.ResumeLayout(false);
            this.gbJoin.PerformLayout();
            this.gbJointType.ResumeLayout(false);
            this.gbJointType.PerformLayout();
            this.gbOnlineInformation.ResumeLayout(false);
            this.gbOnlineInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMultiAccountWithdrawl)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbWithdrawal.ResumeLayout(false);
            this.gbWithdrawal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXC0007 butCalculate;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.RadioButton rdoIncomeByTransfer;
        private System.Windows.Forms.RadioButton rdoIncomeByCash;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Windows.CXClient.Controls.CXC0006 txtGroupNo;
        private Windows.CXClient.Controls.CXC0003 lblGroupNo;
        private Windows.CXClient.Controls.CXC0006 txtChequeNo;
        private System.Windows.Forms.MaskedTextBox mtxtAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblAmount;
        private Windows.CXClient.Controls.CXC0003 lblCheque;
        private Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Windows.CXClient.Controls.CXC0004 txtNoOfPersonToSign;
        private System.Windows.Forms.GroupBox gbJoin;
        private System.Windows.Forms.GroupBox gbJointType;
        private Windows.CXClient.Controls.CXC0009 rdoJointTypeB;
        private Windows.CXClient.Controls.CXC0009 rdoJointTypeA;
        private Windows.CXClient.Controls.CXC0003 lblNoOfPersonToSign;
        private System.Windows.Forms.CheckBox chkPrintTransactions;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.CheckBox chkInputIncomeAmount;
        private System.Windows.Forms.GroupBox gbOnlineInformation;
        private Windows.CXClient.Controls.CXC0004 txtCommissions;
        private Windows.CXClient.Controls.CXC0004 txtCommunicationCharges;
        private Windows.CXClient.Controls.CXC0003 lblCommissions;
        private Windows.CXClient.Controls.CXC0003 lblCommunicationCharges;
        private Windows.CXClient.Controls.CXC0008 chkVIPCustomer;
        private Windows.CXClient.Controls.CXC0004 txtTotalAmount;
        private Windows.CXClient.Controls.CXC0003 lblTotalAmount;
        private System.Windows.Forms.Button butEnquiry;
        private Windows.CXClient.Controls.AceGridView gvMultiAccountWithdrawl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbWithdrawal;
        private Windows.CXClient.Controls.CXC0004 txtAmount;
        private Windows.CXClient.Controls.CXC0003 lblTotalCharges;
        private Windows.CXClient.Controls.CXC0004 txtTotalCharges;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheque;
        private System.Windows.Forms.DataGridViewCheckBoxColumn VIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNOPSign;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCommunicationCharges;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCommissions;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colPrint;
        private Windows.CXClient.Controls.CXC0003 lblTransactionDate;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
    }
}