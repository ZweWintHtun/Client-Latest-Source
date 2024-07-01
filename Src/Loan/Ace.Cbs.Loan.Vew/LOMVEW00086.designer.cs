namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00086
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00086));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.grpLoanRecord = new System.Windows.Forms.GroupBox();
            this.txtRefundAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtSanctionAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtAcre = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtPopulation = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtTotalGroup = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtSuspendAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.butContinue = new System.Windows.Forms.Button();
            this.grdBusinessType = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBusinessType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtFinancialYear = new Ace.Windows.CXClient.Controls.CXC0001();
            this.dtpRefundDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.dtpDeliverDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.dtpSuspendDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.cboBusinessType = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cxC00039 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtLoanVrNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.cxC00038 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtRefundVrNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.cxC00037 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00036 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00035 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00034 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00033 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboTownship = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblTownship = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboVillageGroup = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblVillageGroup = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblLoanNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.grpLoanRecord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBusinessType)).BeginInit();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(592, 31);
            this.tsbCRUD.TabIndex = 0;
            this.tsbCRUD.EditButtonClick += new System.EventHandler(this.tsbCRUD_EditButtonClick);
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.DeleteButtonClick += new System.EventHandler(this.tsbCRUD_DeleteButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // grpLoanRecord
            // 
            this.grpLoanRecord.Controls.Add(this.txtRefundAmount);
            this.grpLoanRecord.Controls.Add(this.txtSanctionAmount);
            this.grpLoanRecord.Controls.Add(this.txtAcre);
            this.grpLoanRecord.Controls.Add(this.txtPopulation);
            this.grpLoanRecord.Controls.Add(this.txtTotalGroup);
            this.grpLoanRecord.Controls.Add(this.txtSuspendAmount);
            this.grpLoanRecord.Controls.Add(this.butContinue);
            this.grpLoanRecord.Controls.Add(this.grdBusinessType);
            this.grpLoanRecord.Controls.Add(this.txtFinancialYear);
            this.grpLoanRecord.Controls.Add(this.dtpRefundDate);
            this.grpLoanRecord.Controls.Add(this.dtpDeliverDate);
            this.grpLoanRecord.Controls.Add(this.dtpSuspendDate);
            this.grpLoanRecord.Controls.Add(this.cboBusinessType);
            this.grpLoanRecord.Controls.Add(this.cxC00039);
            this.grpLoanRecord.Controls.Add(this.txtLoanVrNo);
            this.grpLoanRecord.Controls.Add(this.cxC00038);
            this.grpLoanRecord.Controls.Add(this.txtRefundVrNo);
            this.grpLoanRecord.Controls.Add(this.cxC00037);
            this.grpLoanRecord.Controls.Add(this.cxC00036);
            this.grpLoanRecord.Controls.Add(this.cxC00035);
            this.grpLoanRecord.Controls.Add(this.cxC00034);
            this.grpLoanRecord.Controls.Add(this.cxC00033);
            this.grpLoanRecord.Controls.Add(this.cxC00032);
            this.grpLoanRecord.Controls.Add(this.cxC00031);
            this.grpLoanRecord.Controls.Add(this.cboTownship);
            this.grpLoanRecord.Controls.Add(this.lblTownship);
            this.grpLoanRecord.Controls.Add(this.cboVillageGroup);
            this.grpLoanRecord.Controls.Add(this.lblVillageGroup);
            this.grpLoanRecord.Controls.Add(this.lblCurrency);
            this.grpLoanRecord.Controls.Add(this.lblAccountNo);
            this.grpLoanRecord.Controls.Add(this.lblName);
            this.grpLoanRecord.Controls.Add(this.lblLoanNo);
            this.grpLoanRecord.Location = new System.Drawing.Point(9, 36);
            this.grpLoanRecord.Name = "grpLoanRecord";
            this.grpLoanRecord.Size = new System.Drawing.Size(575, 434);
            this.grpLoanRecord.TabIndex = 1;
            this.grpLoanRecord.TabStop = false;
            this.grpLoanRecord.Text = "Loan Record Entry";
            // 
            // txtRefundAmount
            // 
            this.txtRefundAmount.DecimalPlaces = 2;
            this.txtRefundAmount.IsSendTabOnEnter = true;
            this.txtRefundAmount.IsThousandSeperator = true;
            this.txtRefundAmount.Location = new System.Drawing.Point(426, 145);
            this.txtRefundAmount.Name = "txtRefundAmount";
            this.txtRefundAmount.Size = new System.Drawing.Size(141, 20);
            this.txtRefundAmount.TabIndex = 13;
            this.txtRefundAmount.Text = "0.00";
            this.txtRefundAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRefundAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtSanctionAmount
            // 
            this.txtSanctionAmount.DecimalPlaces = 2;
            this.txtSanctionAmount.IsSendTabOnEnter = true;
            this.txtSanctionAmount.IsThousandSeperator = true;
            this.txtSanctionAmount.Location = new System.Drawing.Point(426, 94);
            this.txtSanctionAmount.Name = "txtSanctionAmount";
            this.txtSanctionAmount.Size = new System.Drawing.Size(141, 20);
            this.txtSanctionAmount.TabIndex = 11;
            this.txtSanctionAmount.Text = "0.00";
            this.txtSanctionAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSanctionAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtAcre
            // 
            this.txtAcre.DecimalPlaces = 2;
            this.txtAcre.IsSendTabOnEnter = true;
            this.txtAcre.IsThousandSeperator = true;
            this.txtAcre.Location = new System.Drawing.Point(426, 69);
            this.txtAcre.Name = "txtAcre";
            this.txtAcre.Size = new System.Drawing.Size(141, 20);
            this.txtAcre.TabIndex = 10;
            this.txtAcre.Text = "0.00";
            this.txtAcre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAcre.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtPopulation
            // 
            this.txtPopulation.DecimalPlaces = 2;
            this.txtPopulation.IsSendTabOnEnter = true;
            this.txtPopulation.IsThousandSeperator = true;
            this.txtPopulation.Location = new System.Drawing.Point(426, 43);
            this.txtPopulation.Name = "txtPopulation";
            this.txtPopulation.Size = new System.Drawing.Size(141, 20);
            this.txtPopulation.TabIndex = 9;
            this.txtPopulation.Text = "0.00";
            this.txtPopulation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPopulation.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtTotalGroup
            // 
            this.txtTotalGroup.DecimalPlaces = 2;
            this.txtTotalGroup.IsSendTabOnEnter = true;
            this.txtTotalGroup.IsThousandSeperator = true;
            this.txtTotalGroup.Location = new System.Drawing.Point(426, 18);
            this.txtTotalGroup.Name = "txtTotalGroup";
            this.txtTotalGroup.Size = new System.Drawing.Size(141, 20);
            this.txtTotalGroup.TabIndex = 8;
            this.txtTotalGroup.Text = "0.00";
            this.txtTotalGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalGroup.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtSuspendAmount
            // 
            this.txtSuspendAmount.DecimalPlaces = 2;
            this.txtSuspendAmount.IsSendTabOnEnter = true;
            this.txtSuspendAmount.IsThousandSeperator = true;
            this.txtSuspendAmount.Location = new System.Drawing.Point(139, 177);
            this.txtSuspendAmount.Name = "txtSuspendAmount";
            this.txtSuspendAmount.Size = new System.Drawing.Size(141, 20);
            this.txtSuspendAmount.TabIndex = 6;
            this.txtSuspendAmount.Text = "0.00";
            this.txtSuspendAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSuspendAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // butContinue
            // 
            this.butContinue.Location = new System.Drawing.Point(491, 236);
            this.butContinue.Name = "butContinue";
            this.butContinue.Size = new System.Drawing.Size(76, 30);
            this.butContinue.TabIndex = 15;
            this.butContinue.Text = "&Continue";
            this.butContinue.UseVisualStyleBackColor = true;
            this.butContinue.Click += new System.EventHandler(this.butContinue_Click);
            // 
            // grdBusinessType
            // 
            this.grdBusinessType.AllowUserToDeleteRows = false;
            this.grdBusinessType.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grdBusinessType.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdBusinessType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdBusinessType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colBusinessType,
            this.colTotal,
            this.colDelete});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdBusinessType.DefaultCellStyle = dataGridViewCellStyle4;
            this.grdBusinessType.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdBusinessType.EnableHeadersVisualStyles = false;
            this.grdBusinessType.IdTSList = null;
            this.grdBusinessType.IsEscapeKey = false;
            this.grdBusinessType.IsHeaderClick = false;
            this.grdBusinessType.Location = new System.Drawing.Point(11, 274);
            this.grdBusinessType.Name = "grdBusinessType";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdBusinessType.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdBusinessType.RowHeadersWidth = 29;
            this.grdBusinessType.ShowSerialNo = true;
            this.grdBusinessType.Size = new System.Drawing.Size(556, 150);
            this.grdBusinessType.TabIndex = 16;
            this.grdBusinessType.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdBusinessType_CellContentClick);
            this.grdBusinessType.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdBusinessType_CellLeave);
            this.grdBusinessType.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdBusinessType_EditingControlShowing);
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Column1";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colBusinessType
            // 
            this.colBusinessType.DataPropertyName = "BusinessType";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colBusinessType.DefaultCellStyle = dataGridViewCellStyle2;
            this.colBusinessType.HeaderText = "Business Type";
            this.colBusinessType.Name = "colBusinessType";
            this.colBusinessType.Width = 150;
            // 
            // colTotal
            // 
            this.colTotal.DataPropertyName = "UM";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.colTotal.DefaultCellStyle = dataGridViewCellStyle3;
            this.colTotal.HeaderText = "Acre/Unit";
            this.colTotal.MaxInputLength = 50;
            this.colTotal.Name = "colTotal";
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "Delete";
            this.colDelete.Name = "colDelete";
            // 
            // txtFinancialYear
            // 
            this.txtFinancialYear.Enabled = false;
            this.txtFinancialYear.IsSendTabOnEnter = true;
            this.txtFinancialYear.Location = new System.Drawing.Point(139, 98);
            this.txtFinancialYear.Name = "txtFinancialYear";
            this.txtFinancialYear.Size = new System.Drawing.Size(141, 20);
            this.txtFinancialYear.TabIndex = 3;
            // 
            // dtpRefundDate
            // 
            this.dtpRefundDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpRefundDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRefundDate.IsSendTabOnEnter = true;
            this.dtpRefundDate.Location = new System.Drawing.Point(426, 119);
            this.dtpRefundDate.Name = "dtpRefundDate";
            this.dtpRefundDate.Size = new System.Drawing.Size(141, 20);
            this.dtpRefundDate.TabIndex = 12;
            // 
            // dtpDeliverDate
            // 
            this.dtpDeliverDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpDeliverDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDeliverDate.IsSendTabOnEnter = true;
            this.dtpDeliverDate.Location = new System.Drawing.Point(139, 203);
            this.dtpDeliverDate.Name = "dtpDeliverDate";
            this.dtpDeliverDate.Size = new System.Drawing.Size(141, 20);
            this.dtpDeliverDate.TabIndex = 7;
            // 
            // dtpSuspendDate
            // 
            this.dtpSuspendDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpSuspendDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSuspendDate.IsSendTabOnEnter = true;
            this.dtpSuspendDate.Location = new System.Drawing.Point(139, 151);
            this.dtpSuspendDate.Name = "dtpSuspendDate";
            this.dtpSuspendDate.Size = new System.Drawing.Size(141, 20);
            this.dtpSuspendDate.TabIndex = 5;
            // 
            // cboBusinessType
            // 
            this.cboBusinessType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboBusinessType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBusinessType.DropDownHeight = 200;
            this.cboBusinessType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBusinessType.FormattingEnabled = true;
            this.cboBusinessType.IntegralHeight = false;
            this.cboBusinessType.IsSendTabOnEnter = true;
            this.cboBusinessType.Location = new System.Drawing.Point(139, 125);
            this.cboBusinessType.Name = "cboBusinessType";
            this.cboBusinessType.Size = new System.Drawing.Size(141, 21);
            this.cboBusinessType.TabIndex = 4;
            // 
            // cxC00039
            // 
            this.cxC00039.AutoSize = true;
            this.cxC00039.Location = new System.Drawing.Point(9, 21);
            this.cxC00039.Name = "cxC00039";
            this.cxC00039.Size = new System.Drawing.Size(100, 13);
            this.cxC00039.TabIndex = 32;
            this.cxC00039.Text = "Loan Vouncher No:";
            // 
            // txtLoanVrNo
            // 
            this.txtLoanVrNo.IsSendTabOnEnter = true;
            this.txtLoanVrNo.Location = new System.Drawing.Point(139, 17);
            this.txtLoanVrNo.Name = "txtLoanVrNo";
            this.txtLoanVrNo.Size = new System.Drawing.Size(141, 20);
            this.txtLoanVrNo.TabIndex = 0;
            this.txtLoanVrNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLoanVrNo_KeyDown);
            // 
            // cxC00038
            // 
            this.cxC00038.AutoSize = true;
            this.cxC00038.Location = new System.Drawing.Point(298, 177);
            this.cxC00038.Name = "cxC00038";
            this.cxC00038.Size = new System.Drawing.Size(75, 13);
            this.cxC00038.TabIndex = 30;
            this.cxC00038.Text = "Refund Vr No:";
            // 
            // txtRefundVrNo
            // 
            this.txtRefundVrNo.IsSendTabOnEnter = true;
            this.txtRefundVrNo.Location = new System.Drawing.Point(426, 173);
            this.txtRefundVrNo.Name = "txtRefundVrNo";
            this.txtRefundVrNo.Size = new System.Drawing.Size(141, 20);
            this.txtRefundVrNo.TabIndex = 14;
            this.txtRefundVrNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRefundVrNo_KeyPress);
            // 
            // cxC00037
            // 
            this.cxC00037.AutoSize = true;
            this.cxC00037.Location = new System.Drawing.Point(298, 149);
            this.cxC00037.Name = "cxC00037";
            this.cxC00037.Size = new System.Drawing.Size(84, 13);
            this.cxC00037.TabIndex = 28;
            this.cxC00037.Text = "Refund Amount:";
            // 
            // cxC00036
            // 
            this.cxC00036.AutoSize = true;
            this.cxC00036.Location = new System.Drawing.Point(298, 123);
            this.cxC00036.Name = "cxC00036";
            this.cxC00036.Size = new System.Drawing.Size(71, 13);
            this.cxC00036.TabIndex = 26;
            this.cxC00036.Text = "Refund Date:";
            // 
            // cxC00035
            // 
            this.cxC00035.AutoSize = true;
            this.cxC00035.Location = new System.Drawing.Point(298, 98);
            this.cxC00035.Name = "cxC00035";
            this.cxC00035.Size = new System.Drawing.Size(91, 13);
            this.cxC00035.TabIndex = 24;
            this.cxC00035.Text = "Sanction Amount:";
            // 
            // cxC00034
            // 
            this.cxC00034.AutoSize = true;
            this.cxC00034.Location = new System.Drawing.Point(298, 71);
            this.cxC00034.Name = "cxC00034";
            this.cxC00034.Size = new System.Drawing.Size(32, 13);
            this.cxC00034.TabIndex = 22;
            this.cxC00034.Text = "Acre:";
            // 
            // cxC00033
            // 
            this.cxC00033.AutoSize = true;
            this.cxC00033.Location = new System.Drawing.Point(298, 46);
            this.cxC00033.Name = "cxC00033";
            this.cxC00033.Size = new System.Drawing.Size(60, 13);
            this.cxC00033.TabIndex = 20;
            this.cxC00033.Text = "Population:";
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.Location = new System.Drawing.Point(298, 20);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(66, 13);
            this.cxC00032.TabIndex = 18;
            this.cxC00032.Text = "Total Group:";
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(9, 207);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(69, 13);
            this.cxC00031.TabIndex = 16;
            this.cxC00031.Text = "Deliver Date:";
            // 
            // cboTownship
            // 
            this.cboTownship.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboTownship.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTownship.DropDownHeight = 200;
            this.cboTownship.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTownship.FormattingEnabled = true;
            this.cboTownship.IntegralHeight = false;
            this.cboTownship.IsSendTabOnEnter = true;
            this.cboTownship.Location = new System.Drawing.Point(139, 44);
            this.cboTownship.Name = "cboTownship";
            this.cboTownship.Size = new System.Drawing.Size(141, 21);
            this.cboTownship.TabIndex = 1;
            // 
            // lblTownship
            // 
            this.lblTownship.AutoSize = true;
            this.lblTownship.Location = new System.Drawing.Point(8, 48);
            this.lblTownship.Name = "lblTownship";
            this.lblTownship.Size = new System.Drawing.Size(59, 13);
            this.lblTownship.TabIndex = 14;
            this.lblTownship.Text = "Township :";
            // 
            // cboVillageGroup
            // 
            this.cboVillageGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboVillageGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboVillageGroup.DropDownHeight = 200;
            this.cboVillageGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVillageGroup.FormattingEnabled = true;
            this.cboVillageGroup.IntegralHeight = false;
            this.cboVillageGroup.IsSendTabOnEnter = true;
            this.cboVillageGroup.Location = new System.Drawing.Point(139, 71);
            this.cboVillageGroup.Name = "cboVillageGroup";
            this.cboVillageGroup.Size = new System.Drawing.Size(141, 21);
            this.cboVillageGroup.TabIndex = 2;
            // 
            // lblVillageGroup
            // 
            this.lblVillageGroup.AutoSize = true;
            this.lblVillageGroup.Location = new System.Drawing.Point(8, 75);
            this.lblVillageGroup.Name = "lblVillageGroup";
            this.lblVillageGroup.Size = new System.Drawing.Size(76, 13);
            this.lblVillageGroup.TabIndex = 12;
            this.lblVillageGroup.Text = "Village Group :";
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(8, 102);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(77, 13);
            this.lblCurrency.TabIndex = 4;
            this.lblCurrency.Text = "Financial Year:";
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(9, 155);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(78, 13);
            this.lblAccountNo.TabIndex = 6;
            this.lblAccountNo.Text = "Suspend Date:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(9, 181);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(91, 13);
            this.lblName.TabIndex = 10;
            this.lblName.Text = "Suspend Amount:";
            // 
            // lblLoanNo
            // 
            this.lblLoanNo.AutoSize = true;
            this.lblLoanNo.Location = new System.Drawing.Point(9, 129);
            this.lblLoanNo.Name = "lblLoanNo";
            this.lblLoanNo.Size = new System.Drawing.Size(46, 13);
            this.lblLoanNo.TabIndex = 2;
            this.lblLoanNo.Text = "Season:";
            // 
            // LOMVEW00086
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 474);
            this.Controls.Add(this.grpLoanRecord);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00086";
            this.Text = "Loan Record Entry";
            this.Load += new System.EventHandler(this.LOMORM00086_Load);
            this.grpLoanRecord.ResumeLayout(false);
            this.grpLoanRecord.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBusinessType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox grpLoanRecord;
        private Windows.CXClient.Controls.CXC0002 cboTownship;
        private Windows.CXClient.Controls.CXC0002 cboVillageGroup;
        private Windows.CXClient.Controls.CXC0003 lblVillageGroup;
        private Windows.CXClient.Controls.CXC0003 lblTownship;
        private Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Windows.CXClient.Controls.CXC0003 lblName;
        private Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblLoanNo;
        private Windows.CXClient.Controls.CXC0003 cxC00039;
        private Windows.CXClient.Controls.CXC0001 txtLoanVrNo;
        private Windows.CXClient.Controls.CXC0003 cxC00038;
        private Windows.CXClient.Controls.CXC0001 txtRefundVrNo;
        private Windows.CXClient.Controls.CXC0003 cxC00037;
        private Windows.CXClient.Controls.CXC0003 cxC00036;
        private Windows.CXClient.Controls.CXC0003 cxC00035;
        private Windows.CXClient.Controls.CXC0003 cxC00034;
        private Windows.CXClient.Controls.CXC0003 cxC00033;
        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0002 cboBusinessType;
        private Windows.CXClient.Controls.CXC0005 dtpDeliverDate;
        private Windows.CXClient.Controls.CXC0005 dtpSuspendDate;
        private Windows.CXClient.Controls.CXC0005 dtpRefundDate;
        private Windows.CXClient.Controls.CXC0001 txtFinancialYear;
        private Windows.CXClient.Controls.AceGridView grdBusinessType;
        private System.Windows.Forms.Button butContinue;
        private Windows.CXClient.Controls.CXC0004 txtSuspendAmount;
        private Windows.CXClient.Controls.CXC0004 txtTotalGroup;
        private Windows.CXClient.Controls.CXC0004 txtPopulation;
        private Windows.CXClient.Controls.CXC0004 txtAcre;
        private Windows.CXClient.Controls.CXC0004 txtSanctionAmount;
        private Windows.CXClient.Controls.CXC0004 txtRefundAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewComboBoxColumn colBusinessType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewImageColumn colDelete;
    }
}