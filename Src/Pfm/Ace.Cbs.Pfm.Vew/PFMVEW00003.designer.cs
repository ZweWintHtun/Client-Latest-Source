namespace Ace.Cbs.Pfm.Vew
{
    partial class PFMVEW00003
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PFMVEW00003));
            this.cxcliC0011 = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gbJoint = new System.Windows.Forms.GroupBox();
            this.gvCustomer = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colCustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNRC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.butCheque = new Ace.Windows.CXClient.Controls.CXC0007();
            this.gbLinkAccountInformation = new System.Windows.Forms.GroupBox();
            this.mtxtDebitLinkAccount = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblLinkLimit = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblDebitLinkAccount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtLinkLimit = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtName = new Ace.Windows.CXClient.Controls.CXC0001();
            this.pbSignature = new Ace.Windows.CXClient.Controls.CXC0010();
            this.lblSignature = new Ace.Windows.CXClient.Controls.CXC0003();
            this.pbPhoto = new Ace.Windows.CXClient.Controls.CXC0010();
            this.lblPhoto = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gbJoinType = new System.Windows.Forms.GroupBox();
            this.rdoTypeB = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoTypeA = new Ace.Windows.CXClient.Controls.CXC0009();
            this.lblReceiptNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.butReceipt = new Ace.Windows.CXClient.Controls.CXC0007();
            this.lblTo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblChequeSerialNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtFromChequeNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblChequeBookNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtReceiptNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtChequeBookNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtToChequeNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblNoOfPersonToSign = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtNoPersonSign = new Ace.Windows.CXClient.Controls.CXC0004();
            this.butAddCustomers = new Ace.Windows.CXClient.Controls.CXC0007();
            this.gbPersonalData = new System.Windows.Forms.GroupBox();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gbJoint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).BeginInit();
            this.gbLinkAccountInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSignature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            this.gbJoinType.SuspendLayout();
            this.gbPersonalData.SuspendLayout();
            this.SuspendLayout();
            // 
            // cxcliC0011
            // 
            this.cxcliC0011.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cxcliC0011.BackColor = System.Drawing.Color.PowderBlue;
            this.cxcliC0011.Location = new System.Drawing.Point(0, 0);
            this.cxcliC0011.Name = "cxcliC0011";
            this.cxcliC0011.PrintButtonCauseValidation = true;
            this.cxcliC0011.Size = new System.Drawing.Size(935, 34);
            this.cxcliC0011.TabIndex = 97;
            this.cxcliC0011.SaveButtonClick += new System.EventHandler(this.cxcliC0011_SaveButtonClick);
            this.cxcliC0011.CancelButtonClick += new System.EventHandler(this.cxcliC0011_CancelButtonClick);
            this.cxcliC0011.ExitButtonClick += new System.EventHandler(this.cxcliC0011_ExitButtonClick);
            // 
            // gbJoint
            // 
            this.gbJoint.Controls.Add(this.gvCustomer);
            this.gbJoint.Controls.Add(this.butCheque);
            this.gbJoint.Controls.Add(this.gbLinkAccountInformation);
            this.gbJoint.Controls.Add(this.pbSignature);
            this.gbJoint.Controls.Add(this.lblSignature);
            this.gbJoint.Controls.Add(this.pbPhoto);
            this.gbJoint.Controls.Add(this.lblPhoto);
            this.gbJoint.Controls.Add(this.gbJoinType);
            this.gbJoint.Controls.Add(this.lblReceiptNo);
            this.gbJoint.Controls.Add(this.butReceipt);
            this.gbJoint.Controls.Add(this.lblTo);
            this.gbJoint.Controls.Add(this.lblChequeSerialNo);
            this.gbJoint.Controls.Add(this.txtFromChequeNo);
            this.gbJoint.Controls.Add(this.lblChequeBookNo);
            this.gbJoint.Controls.Add(this.txtReceiptNo);
            this.gbJoint.Controls.Add(this.txtChequeBookNo);
            this.gbJoint.Controls.Add(this.txtToChequeNo);
            this.gbJoint.Controls.Add(this.lblNoOfPersonToSign);
            this.gbJoint.Controls.Add(this.txtNoPersonSign);
            this.gbJoint.Controls.Add(this.butAddCustomers);
            this.gbJoint.Controls.Add(this.gbPersonalData);
            this.gbJoint.Location = new System.Drawing.Point(12, 37);
            this.gbJoint.Name = "gbJoint";
            this.gbJoint.Size = new System.Drawing.Size(911, 537);
            this.gbJoint.TabIndex = 96;
            this.gbJoint.TabStop = false;
            this.gbJoint.Text = "groupBox1";
            // 
            // gvCustomer
            // 
            this.gvCustomer.AllowUserToAddRows = false;
            this.gvCustomer.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gvCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCustomerId,
            this.colName,
            this.colNRC,
            this.colDelete});
            this.gvCustomer.EnableHeadersVisualStyles = false;
            this.gvCustomer.IdTSList = null;
            this.gvCustomer.IsEscapeKey = false;
            this.gvCustomer.IsHeaderClick = false;
            this.gvCustomer.Location = new System.Drawing.Point(16, 112);
            this.gvCustomer.Name = "gvCustomer";
            this.gvCustomer.RowHeadersWidth = 25;
            this.gvCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvCustomer.ShowSerialNo = false;
            this.gvCustomer.Size = new System.Drawing.Size(803, 176);
            this.gvCustomer.TabIndex = 3;
            this.gvCustomer.TabStop = false;
            this.gvCustomer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvCustomer_CellClick);
            this.gvCustomer.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gvCustomer_DataError);
            // 
            // colCustomerId
            // 
            this.colCustomerId.DataPropertyName = "CustomerId";
            this.colCustomerId.HeaderText = "Customer Id";
            this.colCustomerId.Name = "colCustomerId";
            this.colCustomerId.ReadOnly = true;
            this.colCustomerId.Width = 200;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 350;
            // 
            // colNRC
            // 
            this.colNRC.DataPropertyName = "NRC";
            this.colNRC.HeaderText = "NRC";
            this.colNRC.Name = "colNRC";
            this.colNRC.ReadOnly = true;
            this.colNRC.Width = 150;
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "";
            this.colDelete.Image = global::Ace.Cbs.Pfm.Vew.Properties.Resources.cancel_01;
            this.colDelete.Name = "colDelete";
            this.colDelete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDelete.ToolTipText = "Delete";
            this.colDelete.Width = 30;
            // 
            // butCheque
            // 
            this.butCheque.Image = ((System.Drawing.Image)(resources.GetObject("butCheque.Image")));
            this.butCheque.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCheque.Location = new System.Drawing.Point(742, 298);
            this.butCheque.Name = "butCheque";
            this.butCheque.Size = new System.Drawing.Size(76, 24);
            this.butCheque.TabIndex = 6;
            this.butCheque.Text = "Che&que";
            this.butCheque.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCheque.UseVisualStyleBackColor = true;
            this.butCheque.Click += new System.EventHandler(this.butCheque_Click);
            // 
            // gbLinkAccountInformation
            // 
            this.gbLinkAccountInformation.Controls.Add(this.mtxtDebitLinkAccount);
            this.gbLinkAccountInformation.Controls.Add(this.lblLinkLimit);
            this.gbLinkAccountInformation.Controls.Add(this.lblName);
            this.gbLinkAccountInformation.Controls.Add(this.lblDebitLinkAccount);
            this.gbLinkAccountInformation.Controls.Add(this.txtLinkLimit);
            this.gbLinkAccountInformation.Controls.Add(this.txtName);
            this.gbLinkAccountInformation.Location = new System.Drawing.Point(601, 363);
            this.gbLinkAccountInformation.Name = "gbLinkAccountInformation";
            this.gbLinkAccountInformation.Size = new System.Drawing.Size(303, 87);
            this.gbLinkAccountInformation.TabIndex = 6;
            this.gbLinkAccountInformation.TabStop = false;
            this.gbLinkAccountInformation.Text = "Link Account Information";
            // 
            // mtxtDebitLinkAccount
            // 
            this.mtxtDebitLinkAccount.Enabled = false;
            this.mtxtDebitLinkAccount.HidePromptOnLeave = true;
            this.mtxtDebitLinkAccount.IsSendTabOnEnter = true;
            this.mtxtDebitLinkAccount.Location = new System.Drawing.Point(116, 14);
            this.mtxtDebitLinkAccount.Mask = "999-999-999999999";
            this.mtxtDebitLinkAccount.Name = "mtxtDebitLinkAccount";
            this.mtxtDebitLinkAccount.Size = new System.Drawing.Size(141, 20);
            this.mtxtDebitLinkAccount.TabIndex = 0;
            this.mtxtDebitLinkAccount.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtxtDebitLinkAccount.Validating += new System.ComponentModel.CancelEventHandler(this.mtxtDebitLinkAccount_Validating);
            // 
            // lblLinkLimit
            // 
            this.lblLinkLimit.AutoSize = true;
            this.lblLinkLimit.Location = new System.Drawing.Point(8, 62);
            this.lblLinkLimit.Name = "lblLinkLimit";
            this.lblLinkLimit.Size = new System.Drawing.Size(57, 13);
            this.lblLinkLimit.TabIndex = 11;
            this.lblLinkLimit.Text = "Link Limit :";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(8, 38);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 13);
            this.lblName.TabIndex = 11;
            this.lblName.Text = "Name :";
            // 
            // lblDebitLinkAccount
            // 
            this.lblDebitLinkAccount.AutoSize = true;
            this.lblDebitLinkAccount.Location = new System.Drawing.Point(8, 16);
            this.lblDebitLinkAccount.Name = "lblDebitLinkAccount";
            this.lblDebitLinkAccount.Size = new System.Drawing.Size(104, 13);
            this.lblDebitLinkAccount.TabIndex = 11;
            this.lblDebitLinkAccount.Text = "Debit Link Account :";
            // 
            // txtLinkLimit
            // 
            this.txtLinkLimit.DecimalPlaces = 2;
            this.txtLinkLimit.Enabled = false;
            this.txtLinkLimit.IsSendTabOnEnter = true;
            this.txtLinkLimit.Location = new System.Drawing.Point(116, 60);
            this.txtLinkLimit.MaxLength = 18;
            this.txtLinkLimit.Name = "txtLinkLimit";
            this.txtLinkLimit.Size = new System.Drawing.Size(111, 20);
            this.txtLinkLimit.TabIndex = 0;
            this.txtLinkLimit.Text = "0.00";
            this.txtLinkLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLinkLimit.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.Control;
            this.txtName.Enabled = false;
            this.txtName.IsSendTabOnEnter = true;
            this.txtName.Location = new System.Drawing.Point(116, 37);
            this.txtName.MaxLength = 30;
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(176, 20);
            this.txtName.TabIndex = 0;
            this.txtName.TabStop = false;
            // 
            // pbSignature
            // 
            this.pbSignature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSignature.Location = new System.Drawing.Point(315, 365);
            this.pbSignature.Name = "pbSignature";
            this.pbSignature.Size = new System.Drawing.Size(280, 159);
            this.pbSignature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSignature.TabIndex = 114;
            this.pbSignature.TabStop = false;
            // 
            // lblSignature
            // 
            this.lblSignature.AutoSize = true;
            this.lblSignature.Location = new System.Drawing.Point(249, 365);
            this.lblSignature.Name = "lblSignature";
            this.lblSignature.Size = new System.Drawing.Size(58, 13);
            this.lblSignature.TabIndex = 112;
            this.lblSignature.Text = "Signature :";
            // 
            // pbPhoto
            // 
            this.pbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPhoto.Location = new System.Drawing.Point(64, 363);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(163, 159);
            this.pbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPhoto.TabIndex = 113;
            this.pbPhoto.TabStop = false;
            // 
            // lblPhoto
            // 
            this.lblPhoto.AutoSize = true;
            this.lblPhoto.Location = new System.Drawing.Point(17, 363);
            this.lblPhoto.Name = "lblPhoto";
            this.lblPhoto.Size = new System.Drawing.Size(41, 13);
            this.lblPhoto.TabIndex = 111;
            this.lblPhoto.Text = "Photo :";
            // 
            // gbJoinType
            // 
            this.gbJoinType.Controls.Add(this.rdoTypeB);
            this.gbJoinType.Controls.Add(this.rdoTypeA);
            this.gbJoinType.Location = new System.Drawing.Point(16, 294);
            this.gbJoinType.Name = "gbJoinType";
            this.gbJoinType.Size = new System.Drawing.Size(138, 42);
            this.gbJoinType.TabIndex = 3;
            this.gbJoinType.TabStop = false;
            this.gbJoinType.Text = "Joint Type";
            // 
            // rdoTypeB
            // 
            this.rdoTypeB.AutoSize = true;
            this.rdoTypeB.Checked = true;
            this.rdoTypeB.IsSendTabOnEnter = true;
            this.rdoTypeB.Location = new System.Drawing.Point(73, 16);
            this.rdoTypeB.Name = "rdoTypeB";
            this.rdoTypeB.Size = new System.Drawing.Size(59, 17);
            this.rdoTypeB.TabIndex = 8;
            this.rdoTypeB.TabStop = true;
            this.rdoTypeB.Text = "Type B";
            this.rdoTypeB.UseVisualStyleBackColor = true;
            // 
            // rdoTypeA
            // 
            this.rdoTypeA.AutoSize = true;
            this.rdoTypeA.IsSendTabOnEnter = true;
            this.rdoTypeA.Location = new System.Drawing.Point(6, 16);
            this.rdoTypeA.Name = "rdoTypeA";
            this.rdoTypeA.Size = new System.Drawing.Size(59, 17);
            this.rdoTypeA.TabIndex = 7;
            this.rdoTypeA.Text = "Type A";
            this.rdoTypeA.UseVisualStyleBackColor = true;
            // 
            // lblReceiptNo
            // 
            this.lblReceiptNo.AutoSize = true;
            this.lblReceiptNo.Location = new System.Drawing.Point(225, 340);
            this.lblReceiptNo.Name = "lblReceiptNo";
            this.lblReceiptNo.Size = new System.Drawing.Size(67, 13);
            this.lblReceiptNo.TabIndex = 109;
            this.lblReceiptNo.Text = "Receipt No :";
            // 
            // butReceipt
            // 
            this.butReceipt.Image = ((System.Drawing.Image)(resources.GetObject("butReceipt.Image")));
            this.butReceipt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butReceipt.Location = new System.Drawing.Point(477, 337);
            this.butReceipt.Name = "butReceipt";
            this.butReceipt.Size = new System.Drawing.Size(76, 24);
            this.butReceipt.TabIndex = 5;
            this.butReceipt.Text = "&Receipt";
            this.butReceipt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butReceipt.UseVisualStyleBackColor = true;
            this.butReceipt.Click += new System.EventHandler(this.butReceipt_Click);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(737, 331);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(14, 13);
            this.lblTo.TabIndex = 107;
            this.lblTo.Text = "~";
            // 
            // lblChequeSerialNo
            // 
            this.lblChequeSerialNo.AutoSize = true;
            this.lblChequeSerialNo.Location = new System.Drawing.Point(569, 331);
            this.lblChequeSerialNo.Name = "lblChequeSerialNo";
            this.lblChequeSerialNo.Size = new System.Drawing.Size(96, 13);
            this.lblChequeSerialNo.TabIndex = 101;
            this.lblChequeSerialNo.Text = "Cheque Serial No :";
            // 
            // txtFromChequeNo
            // 
            this.txtFromChequeNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtFromChequeNo.Enabled = false;
            this.txtFromChequeNo.IsSendTabOnEnter = true;
            this.txtFromChequeNo.Location = new System.Drawing.Point(671, 327);
            this.txtFromChequeNo.MaxLength = 8;
            this.txtFromChequeNo.Name = "txtFromChequeNo";
            this.txtFromChequeNo.ReadOnly = true;
            this.txtFromChequeNo.Size = new System.Drawing.Size(58, 20);
            this.txtFromChequeNo.TabIndex = 0;
            this.txtFromChequeNo.TabStop = false;
            // 
            // lblChequeBookNo
            // 
            this.lblChequeBookNo.AutoSize = true;
            this.lblChequeBookNo.Location = new System.Drawing.Point(567, 305);
            this.lblChequeBookNo.Name = "lblChequeBookNo";
            this.lblChequeBookNo.Size = new System.Drawing.Size(98, 13);
            this.lblChequeBookNo.TabIndex = 102;
            this.lblChequeBookNo.Text = "Cheque Book  No :";
            // 
            // txtReceiptNo
            // 
            this.txtReceiptNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtReceiptNo.IsSendTabOnEnter = true;
            this.txtReceiptNo.Location = new System.Drawing.Point(349, 337);
            this.txtReceiptNo.MaxLength = 6;
            this.txtReceiptNo.Name = "txtReceiptNo";
            this.txtReceiptNo.ReadOnly = true;
            this.txtReceiptNo.Size = new System.Drawing.Size(115, 20);
            this.txtReceiptNo.TabIndex = 0;
            this.txtReceiptNo.TabStop = false;
            // 
            // txtChequeBookNo
            // 
            this.txtChequeBookNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtChequeBookNo.Enabled = false;
            this.txtChequeBookNo.IsSendTabOnEnter = true;
            this.txtChequeBookNo.Location = new System.Drawing.Point(671, 302);
            this.txtChequeBookNo.MaxLength = 7;
            this.txtChequeBookNo.Name = "txtChequeBookNo";
            this.txtChequeBookNo.ReadOnly = true;
            this.txtChequeBookNo.Size = new System.Drawing.Size(58, 20);
            this.txtChequeBookNo.TabIndex = 0;
            this.txtChequeBookNo.TabStop = false;
            // 
            // txtToChequeNo
            // 
            this.txtToChequeNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtToChequeNo.Enabled = false;
            this.txtToChequeNo.IsSendTabOnEnter = true;
            this.txtToChequeNo.Location = new System.Drawing.Point(758, 327);
            this.txtToChequeNo.MaxLength = 8;
            this.txtToChequeNo.Name = "txtToChequeNo";
            this.txtToChequeNo.ReadOnly = true;
            this.txtToChequeNo.Size = new System.Drawing.Size(58, 20);
            this.txtToChequeNo.TabIndex = 0;
            this.txtToChequeNo.TabStop = false;
            // 
            // lblNoOfPersonToSign
            // 
            this.lblNoOfPersonToSign.AutoSize = true;
            this.lblNoOfPersonToSign.Location = new System.Drawing.Point(225, 312);
            this.lblNoOfPersonToSign.Name = "lblNoOfPersonToSign";
            this.lblNoOfPersonToSign.Size = new System.Drawing.Size(116, 13);
            this.lblNoOfPersonToSign.TabIndex = 99;
            this.lblNoOfPersonToSign.Text = "No. Of Person to Sign :";
            // 
            // txtNoPersonSign
            // 
            this.txtNoPersonSign.DecimalPlaces = 0;
            this.txtNoPersonSign.IsSendTabOnEnter = true;
            this.txtNoPersonSign.Location = new System.Drawing.Point(347, 308);
            this.txtNoPersonSign.MaxLength = 1;
            this.txtNoPersonSign.Name = "txtNoPersonSign";
            this.txtNoPersonSign.Size = new System.Drawing.Size(105, 20);
            this.txtNoPersonSign.TabIndex = 4;
            this.txtNoPersonSign.Text = "0";
            this.txtNoPersonSign.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNoPersonSign.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // butAddCustomers
            // 
            this.butAddCustomers.Image = ((System.Drawing.Image)(resources.GetObject("butAddCustomers.Image")));
            this.butAddCustomers.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.butAddCustomers.Location = new System.Drawing.Point(722, 79);
            this.butAddCustomers.Name = "butAddCustomers";
            this.butAddCustomers.Size = new System.Drawing.Size(97, 24);
            this.butAddCustomers.TabIndex = 2;
            this.butAddCustomers.Text = "&Add Customer";
            this.butAddCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butAddCustomers.UseVisualStyleBackColor = true;
            this.butAddCustomers.Click += new System.EventHandler(this.butAddCustomer_Click);
            // 
            // gbPersonalData
            // 
            this.gbPersonalData.Controls.Add(this.mtxtAccountNo);
            this.gbPersonalData.Controls.Add(this.cboCurrency);
            this.gbPersonalData.Controls.Add(this.lblAccountNo);
            this.gbPersonalData.Controls.Add(this.lblCurrency);
            this.gbPersonalData.Location = new System.Drawing.Point(16, 19);
            this.gbPersonalData.Name = "gbPersonalData";
            this.gbPersonalData.Size = new System.Drawing.Size(325, 74);
            this.gbPersonalData.TabIndex = 0;
            this.gbPersonalData.TabStop = false;
            this.gbPersonalData.Text = "Personal Data";
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.BackColor = System.Drawing.SystemColors.Window;
            this.mtxtAccountNo.Enabled = false;
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(154, 20);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.ReadOnly = true;
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 0;
            this.mtxtAccountNo.TabStop = false;
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
            this.cboCurrency.Location = new System.Drawing.Point(154, 46);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 1;
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(46, 24);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(70, 13);
            this.lblAccountNo.TabIndex = 0;
            this.lblAccountNo.Text = "Account No :";
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(46, 51);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 0;
            this.lblCurrency.Text = "Currency :";
            // 
            // PFMVEW00003
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 639);
            this.Controls.Add(this.gbJoint);
            this.Controls.Add(this.cxcliC0011);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PFMVEW00003";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PFMVEW00003";
            this.Load += new System.EventHandler(this.PFMVEW00003_Load);
            this.gbJoint.ResumeLayout(false);
            this.gbJoint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).EndInit();
            this.gbLinkAccountInformation.ResumeLayout(false);
            this.gbLinkAccountInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSignature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            this.gbJoinType.ResumeLayout(false);
            this.gbJoinType.PerformLayout();
            this.gbPersonalData.ResumeLayout(false);
            this.gbPersonalData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Ace.Windows.CXClient.Controls.CXCLIC001 cxcliC0011;
        private System.Windows.Forms.GroupBox gbJoint;
        private Ace.Windows.CXClient.Controls.CXC0007 butCheque;
        private System.Windows.Forms.GroupBox gbLinkAccountInformation;
        private Ace.Windows.CXClient.Controls.CXC0006 mtxtDebitLinkAccount;
        private Ace.Windows.CXClient.Controls.CXC0003 lblLinkLimit;
        private Ace.Windows.CXClient.Controls.CXC0003 lblName;
        private Ace.Windows.CXClient.Controls.CXC0003 lblDebitLinkAccount;
        private Ace.Windows.CXClient.Controls.CXC0004 txtLinkLimit;
        private Ace.Windows.CXClient.Controls.CXC0001 txtName;
        private Ace.Windows.CXClient.Controls.CXC0010 pbSignature;
        private Ace.Windows.CXClient.Controls.CXC0003 lblSignature;
        private Ace.Windows.CXClient.Controls.CXC0010 pbPhoto;
        private Ace.Windows.CXClient.Controls.CXC0003 lblPhoto;
        private System.Windows.Forms.GroupBox gbJoinType;
        private Ace.Windows.CXClient.Controls.CXC0009 rdoTypeB;
        private Ace.Windows.CXClient.Controls.CXC0009 rdoTypeA;
        private Ace.Windows.CXClient.Controls.CXC0003 lblReceiptNo;
        private Ace.Windows.CXClient.Controls.CXC0007 butReceipt;
        private Ace.Windows.CXClient.Controls.CXC0003 lblTo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblChequeSerialNo;
        private Ace.Windows.CXClient.Controls.CXC0001 txtFromChequeNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblChequeBookNo;
        private Ace.Windows.CXClient.Controls.CXC0001 txtReceiptNo;
        private Ace.Windows.CXClient.Controls.CXC0001 txtChequeBookNo;
        private Ace.Windows.CXClient.Controls.CXC0001 txtToChequeNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblNoOfPersonToSign;
        private Ace.Windows.CXClient.Controls.CXC0004 txtNoPersonSign;
        private Ace.Windows.CXClient.Controls.CXC0007 butAddCustomers;
        private System.Windows.Forms.GroupBox gbPersonalData;
        private Ace.Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Ace.Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Ace.Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Windows.CXClient.Controls.AceGridView gvCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNRC;
        private System.Windows.Forms.DataGridViewImageColumn colDelete;
    }
}