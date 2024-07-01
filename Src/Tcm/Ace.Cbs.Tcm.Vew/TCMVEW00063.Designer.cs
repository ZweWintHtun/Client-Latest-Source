namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00063
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00063));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAccountName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboDepositCode = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblTypeOfDeposit = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblDepositCodeDesp = new Ace.Windows.CXClient.Controls.CXC0003();
            this.dgvDep_TLFInformation = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvcSrNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcQuota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcAccumulateAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNameFortxtName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtName = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblQuota = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblQuantity = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtAccumulateAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAccumulateAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.butAdd = new System.Windows.Forms.Button();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtTotalAccumulateAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtQuantity = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtQuota = new Ace.Windows.CXClient.Controls.CXC0004();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDep_TLFInformation)).BeginInit();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.CausesValidation = false;
            this.tsbCRUD.Location = new System.Drawing.Point(0, -2);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(1483, 31);
            this.tsbCRUD.TabIndex = 3;
            this.tsbCRUD.TabStop = false;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(122, 69);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 1;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(16, 72);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(70, 13);
            this.lblAccountNo.TabIndex = 5;
            this.lblAccountNo.Text = "Account No :";
            // 
            // lblAccountName
            // 
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.Location = new System.Drawing.Point(364, 73);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(84, 13);
            this.lblAccountName.TabIndex = 5;
            this.lblAccountName.Text = "AccountName : ";
            // 
            // cboDepositCode
            // 
            this.cboDepositCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboDepositCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDepositCode.DropDownHeight = 200;
            this.cboDepositCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepositCode.FormattingEnabled = true;
            this.cboDepositCode.IntegralHeight = false;
            this.cboDepositCode.IsSendTabOnEnter = true;
            this.cboDepositCode.Location = new System.Drawing.Point(122, 98);
            this.cboDepositCode.Name = "cboDepositCode";
            this.cboDepositCode.Size = new System.Drawing.Size(141, 21);
            this.cboDepositCode.TabIndex = 2;
            this.cboDepositCode.SelectedIndexChanged += new System.EventHandler(this.cboDepositCode_SelectedIndexChanged);
            // 
            // lblTypeOfDeposit
            // 
            this.lblTypeOfDeposit.AutoSize = true;
            this.lblTypeOfDeposit.Location = new System.Drawing.Point(16, 101);
            this.lblTypeOfDeposit.Name = "lblTypeOfDeposit";
            this.lblTypeOfDeposit.Size = new System.Drawing.Size(90, 13);
            this.lblTypeOfDeposit.TabIndex = 5;
            this.lblTypeOfDeposit.Text = "Type Of Deposit :";
            // 
            // lblDepositCodeDesp
            // 
            this.lblDepositCodeDesp.AutoSize = true;
            this.lblDepositCodeDesp.Location = new System.Drawing.Point(373, 101);
            this.lblDepositCodeDesp.Name = "lblDepositCodeDesp";
            this.lblDepositCodeDesp.Size = new System.Drawing.Size(0, 13);
            this.lblDepositCodeDesp.TabIndex = 5;
            // 
            // dgvDep_TLFInformation
            // 
            this.dgvDep_TLFInformation.AllowUserToAddRows = false;
            this.dgvDep_TLFInformation.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvDep_TLFInformation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDep_TLFInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDep_TLFInformation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEdit,
            this.colDelete,
            this.dgvcSrNo,
            this.dgvcName,
            this.dgvcQuota,
            this.dgvcQuantity,
            this.dgvcAmount,
            this.dgvcAccumulateAmount});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDep_TLFInformation.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDep_TLFInformation.EnableHeadersVisualStyles = false;
            this.dgvDep_TLFInformation.IdTSList = null;
            this.dgvDep_TLFInformation.IsEscapeKey = false;
            this.dgvDep_TLFInformation.IsHeaderClick = false;
            this.dgvDep_TLFInformation.Location = new System.Drawing.Point(19, 251);
            this.dgvDep_TLFInformation.Name = "dgvDep_TLFInformation";
            this.dgvDep_TLFInformation.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDep_TLFInformation.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDep_TLFInformation.RowHeadersWidth = 25;
            this.dgvDep_TLFInformation.ShowSerialNo = true;
            this.dgvDep_TLFInformation.Size = new System.Drawing.Size(936, 245);
            this.dgvDep_TLFInformation.TabIndex = 17;
            this.dgvDep_TLFInformation.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDep_TLFInformation_CellClick);
            this.dgvDep_TLFInformation.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDep_TLFInformation_DataError);
            // 
            // colEdit
            // 
            this.colEdit.HeaderText = "";
            this.colEdit.Image = global::Ace.Cbs.Tcm.Vew.Properties.Resources.edit;
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            this.colEdit.ToolTipText = "Edit";
            this.colEdit.Width = 30;
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "";
            this.colDelete.Image = global::Ace.Cbs.Tcm.Vew.Properties.Resources.Delete_Main;
            this.colDelete.Name = "colDelete";
            this.colDelete.ReadOnly = true;
            this.colDelete.ToolTipText = "Delete";
            this.colDelete.Width = 30;
            // 
            // dgvcSrNo
            // 
            this.dgvcSrNo.DataPropertyName = "SrNo";
            this.dgvcSrNo.HeaderText = "Sr.No.";
            this.dgvcSrNo.Name = "dgvcSrNo";
            this.dgvcSrNo.ReadOnly = true;
            this.dgvcSrNo.Width = 45;
            // 
            // dgvcName
            // 
            this.dgvcName.DataPropertyName = "NAME";
            this.dgvcName.HeaderText = "Name";
            this.dgvcName.Name = "dgvcName";
            this.dgvcName.ReadOnly = true;
            this.dgvcName.Width = 250;
            // 
            // dgvcQuota
            // 
            this.dgvcQuota.DataPropertyName = "QUOTANO";
            this.dgvcQuota.HeaderText = "Quota";
            this.dgvcQuota.Name = "dgvcQuota";
            this.dgvcQuota.ReadOnly = true;
            // 
            // dgvcQuantity
            // 
            this.dgvcQuantity.DataPropertyName = "Quantity";
            this.dgvcQuantity.HeaderText = "Quantity";
            this.dgvcQuantity.Name = "dgvcQuantity";
            this.dgvcQuantity.ReadOnly = true;
            // 
            // dgvcAmount
            // 
            this.dgvcAmount.DataPropertyName = "AMOUNT";
            this.dgvcAmount.HeaderText = "Amount";
            this.dgvcAmount.Name = "dgvcAmount";
            this.dgvcAmount.ReadOnly = true;
            this.dgvcAmount.Width = 150;
            // 
            // dgvcAccumulateAmount
            // 
            this.dgvcAccumulateAmount.DataPropertyName = "AccumulateAmount";
            this.dgvcAccumulateAmount.HeaderText = "AccumulateAmount";
            this.dgvcAccumulateAmount.Name = "dgvcAccumulateAmount";
            this.dgvcAccumulateAmount.ReadOnly = true;
            this.dgvcAccumulateAmount.Width = 200;
            // 
            // lblNameFortxtName
            // 
            this.lblNameFortxtName.AutoSize = true;
            this.lblNameFortxtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameFortxtName.Location = new System.Drawing.Point(21, 131);
            this.lblNameFortxtName.Name = "lblNameFortxtName";
            this.lblNameFortxtName.Size = new System.Drawing.Size(44, 13);
            this.lblNameFortxtName.TabIndex = 5;
            this.lblNameFortxtName.Text = "Name : ";
            // 
            // txtName
            // 
            this.txtName.IsSendTabOnEnter = true;
            this.txtName.Location = new System.Drawing.Point(122, 128);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(231, 20);
            this.txtName.TabIndex = 3;
            // 
            // lblQuota
            // 
            this.lblQuota.AutoSize = true;
            this.lblQuota.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuota.Location = new System.Drawing.Point(21, 160);
            this.lblQuota.Name = "lblQuota";
            this.lblQuota.Size = new System.Drawing.Size(42, 13);
            this.lblQuota.TabIndex = 5;
            this.lblQuota.Text = "Quota :";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(224, 160);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(52, 13);
            this.lblQuantity.TabIndex = 5;
            this.lblQuantity.Text = "Quantity :";
            // 
            // txtAmount
            // 
            this.txtAmount.DecimalPlaces = 2;
            this.txtAmount.IsSendTabOnEnter = true;
            this.txtAmount.IsThousandSeperator = true;
            this.txtAmount.IsUseFloatingPoint = true;
            this.txtAmount.Location = new System.Drawing.Point(122, 186);
            this.txtAmount.MaxLength = 18;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(231, 20);
            this.txtAmount.TabIndex = 6;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtAccumulateAmount
            // 
            this.txtAccumulateAmount.DecimalPlaces = 2;
            this.txtAccumulateAmount.Enabled = false;
            this.txtAccumulateAmount.IsSendTabOnEnter = true;
            this.txtAccumulateAmount.IsThousandSeperator = true;
            this.txtAccumulateAmount.IsUseFloatingPoint = true;
            this.txtAccumulateAmount.Location = new System.Drawing.Point(122, 215);
            this.txtAccumulateAmount.MaxLength = 18;
            this.txtAccumulateAmount.Name = "txtAccumulateAmount";
            this.txtAccumulateAmount.Size = new System.Drawing.Size(231, 20);
            this.txtAccumulateAmount.TabIndex = 7;
            this.txtAccumulateAmount.Text = "0.00";
            this.txtAccumulateAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAccumulateAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(22, 189);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(49, 13);
            this.lblAmount.TabIndex = 5;
            this.lblAmount.Text = "Amount :";
            // 
            // lblAccumulateAmount
            // 
            this.lblAccumulateAmount.AutoSize = true;
            this.lblAccumulateAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccumulateAmount.Location = new System.Drawing.Point(16, 218);
            this.lblAccumulateAmount.Name = "lblAccumulateAmount";
            this.lblAccumulateAmount.Size = new System.Drawing.Size(105, 13);
            this.lblAccumulateAmount.TabIndex = 5;
            this.lblAccumulateAmount.Text = "AccumulateAmount :";
            // 
            // butAdd
            // 
            this.butAdd.Image = ((System.Drawing.Image)(resources.GetObject("butAdd.Image")));
            this.butAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAdd.Location = new System.Drawing.Point(888, 209);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(67, 30);
            this.butAdd.TabIndex = 9;
            this.butAdd.Text = "&Add";
            this.butAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(16, 42);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 5;
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
            this.cboCurrency.Location = new System.Drawing.Point(122, 39);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(88, 21);
            this.cboCurrency.TabIndex = 0;
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cxC00031.Location = new System.Drawing.Point(638, 176);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(132, 13);
            this.cxC00031.TabIndex = 5;
            this.cxC00031.Text = "Total AccumulateAmount :";
            // 
            // txtTotalAccumulateAmount
            // 
            this.txtTotalAccumulateAmount.DecimalPlaces = 2;
            this.txtTotalAccumulateAmount.Enabled = false;
            this.txtTotalAccumulateAmount.IsSendTabOnEnter = true;
            this.txtTotalAccumulateAmount.IsThousandSeperator = true;
            this.txtTotalAccumulateAmount.IsUseFloatingPoint = true;
            this.txtTotalAccumulateAmount.Location = new System.Drawing.Point(776, 173);
            this.txtTotalAccumulateAmount.MaxLength = 18;
            this.txtTotalAccumulateAmount.Name = "txtTotalAccumulateAmount";
            this.txtTotalAccumulateAmount.Size = new System.Drawing.Size(179, 20);
            this.txtTotalAccumulateAmount.TabIndex = 7;
            this.txtTotalAccumulateAmount.Text = "0.00";
            this.txtTotalAccumulateAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalAccumulateAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtQuantity
            // 
            this.txtQuantity.DecimalPlaces = 2;
            this.txtQuantity.IsSendTabOnEnter = true;
            this.txtQuantity.IsThousandSeperator = true;
            this.txtQuantity.IsUseFloatingPoint = true;
            this.txtQuantity.Location = new System.Drawing.Point(282, 157);
            this.txtQuantity.MaxLength = 18;
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(71, 20);
            this.txtQuantity.TabIndex = 6;
            this.txtQuantity.Text = "0.00";
            this.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQuantity.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtQuota
            // 
            this.txtQuota.DecimalPlaces = 2;
            this.txtQuota.IsSendTabOnEnter = true;
            this.txtQuota.IsThousandSeperator = true;
            this.txtQuota.IsUseFloatingPoint = true;
            this.txtQuota.Location = new System.Drawing.Point(122, 157);
            this.txtQuota.MaxLength = 18;
            this.txtQuota.Name = "txtQuota";
            this.txtQuota.Size = new System.Drawing.Size(88, 20);
            this.txtQuota.TabIndex = 6;
            this.txtQuota.Text = "0.00";
            this.txtQuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQuota.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // TCMVEW00063
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 507);
            this.Controls.Add(this.butAdd);
            this.Controls.Add(this.txtTotalAccumulateAmount);
            this.Controls.Add(this.txtAccumulateAmount);
            this.Controls.Add(this.txtQuota);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.dgvDep_TLFInformation);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.cboDepositCode);
            this.Controls.Add(this.lblCurrency);
            this.Controls.Add(this.lblTypeOfDeposit);
            this.Controls.Add(this.lblDepositCodeDesp);
            this.Controls.Add(this.cxC00031);
            this.Controls.Add(this.lblNameFortxtName);
            this.Controls.Add(this.lblAccumulateAmount);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblQuota);
            this.Controls.Add(this.lblAccountName);
            this.Controls.Add(this.lblAccountNo);
            this.Controls.Add(this.mtxtAccountNo);
            this.Controls.Add(this.tsbCRUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TCMVEW00063";
            this.Text = "Group Cash Deposit";
            this.Load += new System.EventHandler(this.TCMVEW00063_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDep_TLFInformation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblAccountName;
        private Windows.CXClient.Controls.CXC0002 cboDepositCode;
        private Windows.CXClient.Controls.CXC0003 lblTypeOfDeposit;
        private Windows.CXClient.Controls.CXC0003 lblDepositCodeDesp;
        private Windows.CXClient.Controls.AceGridView dgvDep_TLFInformation;
        private Windows.CXClient.Controls.CXC0003 lblNameFortxtName;
        private Windows.CXClient.Controls.CXC0001 txtName;
        private Windows.CXClient.Controls.CXC0003 lblQuota;
        private Windows.CXClient.Controls.CXC0003 lblQuantity;
        private Windows.CXClient.Controls.CXC0004 txtAmount;
        private Windows.CXClient.Controls.CXC0004 txtAccumulateAmount;
        private Windows.CXClient.Controls.CXC0003 lblAmount;
        private Windows.CXClient.Controls.CXC0003 lblAccumulateAmount;
        private System.Windows.Forms.Button butAdd;
        private Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0004 txtTotalAccumulateAmount;
        private Windows.CXClient.Controls.CXC0004 txtQuantity;
        private Windows.CXClient.Controls.CXC0004 txtQuota;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
        private System.Windows.Forms.DataGridViewImageColumn colDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcSrNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcQuota;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcAccumulateAmount;
    }
}