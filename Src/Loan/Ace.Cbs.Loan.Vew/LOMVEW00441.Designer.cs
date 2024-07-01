namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00441
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtWorkingCompanyName = new System.Windows.Forms.TextBox();
            this.lblWCN = new System.Windows.Forms.Label();
            this.mtxtAcctNo = new System.Windows.Forms.MaskedTextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAccountNo = new System.Windows.Forms.Label();
            this.dgvLateFeeInfo = new System.Windows.Forms.DataGridView();
            this.ColId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaymentTermNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrincipal_TOD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInterest_TOD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colODAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalLateDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalLateFee_PTOD_OnIntRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSelect_P_Int = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colTotalLateFee_PTOD_OnLateFeeRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSelect_P_Late = new Ace.Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn();
            this.colTotalLateFee_ITOD_OnLateFeeRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSelect_I_Late = new Ace.Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn();
            this.colTotalLateFeesAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLateFeeInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Margin = new System.Windows.Forms.Padding(5);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(1128, 44);
            this.tsbCRUD.TabIndex = 2;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtWorkingCompanyName);
            this.groupBox1.Controls.Add(this.lblWCN);
            this.groupBox1.Controls.Add(this.mtxtAcctNo);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.lblAccountNo);
            this.groupBox1.Location = new System.Drawing.Point(20, 53);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(693, 191);
            this.groupBox1.TabIndex = 155;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account Information";
            // 
            // txtWorkingCompanyName
            // 
            this.txtWorkingCompanyName.Enabled = false;
            this.txtWorkingCompanyName.Location = new System.Drawing.Point(223, 140);
            this.txtWorkingCompanyName.Margin = new System.Windows.Forms.Padding(4);
            this.txtWorkingCompanyName.Name = "txtWorkingCompanyName";
            this.txtWorkingCompanyName.Size = new System.Drawing.Size(416, 22);
            this.txtWorkingCompanyName.TabIndex = 5;
            // 
            // lblWCN
            // 
            this.lblWCN.AutoSize = true;
            this.lblWCN.Location = new System.Drawing.Point(40, 144);
            this.lblWCN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWCN.Name = "lblWCN";
            this.lblWCN.Size = new System.Drawing.Size(172, 17);
            this.lblWCN.TabIndex = 4;
            this.lblWCN.Text = "Working Company Name :";
            // 
            // mtxtAcctNo
            // 
            this.mtxtAcctNo.Location = new System.Drawing.Point(223, 30);
            this.mtxtAcctNo.Margin = new System.Windows.Forms.Padding(4);
            this.mtxtAcctNo.Name = "mtxtAcctNo";
            this.mtxtAcctNo.Size = new System.Drawing.Size(187, 22);
            this.mtxtAcctNo.TabIndex = 0;
            this.mtxtAcctNo.Enter += new System.EventHandler(this.mtxtAcctNo_Enter);
            this.mtxtAcctNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtAcctNo_KeyPress);
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(223, 73);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(416, 48);
            this.txtName.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(160, 76);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 17);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name :";
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(121, 33);
            this.lblAccountNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(89, 17);
            this.lblAccountNo.TabIndex = 1;
            this.lblAccountNo.Text = "Account No :";
            // 
            // dgvLateFeeInfo
            // 
            this.dgvLateFeeInfo.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLateFeeInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLateFeeInfo.ColumnHeadersHeight = 40;
            this.dgvLateFeeInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColId,
            this.colPaymentTermNo,
            this.colPrincipal_TOD,
            this.colInterest_TOD,
            this.colODAmount,
            this.colTotalLateDays,
            this.colTotalLateFee_PTOD_OnIntRate,
            this.colSelect_P_Int,
            this.colTotalLateFee_PTOD_OnLateFeeRate,
            this.colSelect_P_Late,
            this.colTotalLateFee_ITOD_OnLateFeeRate,
            this.colSelect_I_Late,
            this.colTotalLateFeesAmount,
            this.colSelect,
            this.Status});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLateFeeInfo.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvLateFeeInfo.Location = new System.Drawing.Point(20, 295);
            this.dgvLateFeeInfo.Margin = new System.Windows.Forms.Padding(4);
            this.dgvLateFeeInfo.Name = "dgvLateFeeInfo";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLateFeeInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvLateFeeInfo.RowHeadersVisible = false;
            this.dgvLateFeeInfo.RowHeadersWidth = 35;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLateFeeInfo.RowsDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvLateFeeInfo.RowTemplate.Height = 30;
            this.dgvLateFeeInfo.Size = new System.Drawing.Size(1094, 345);
            this.dgvLateFeeInfo.TabIndex = 134;
            this.dgvLateFeeInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLateFeeInfo_CellContentClick);
            this.dgvLateFeeInfo.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvLateFeeInfo_CurrentCellDirtyStateChanged);
            // 
            // ColId
            // 
            this.ColId.HeaderText = "Id";
            this.ColId.Name = "ColId";
            this.ColId.Visible = false;
            this.ColId.Width = 5;
            // 
            // colPaymentTermNo
            // 
            this.colPaymentTermNo.DataPropertyName = "Payment Term No";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colPaymentTermNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.colPaymentTermNo.FillWeight = 176.892F;
            this.colPaymentTermNo.HeaderText = "Payment Term No";
            this.colPaymentTermNo.Name = "colPaymentTermNo";
            this.colPaymentTermNo.ReadOnly = true;
            this.colPaymentTermNo.Width = 65;
            // 
            // colPrincipal_TOD
            // 
            this.colPrincipal_TOD.DataPropertyName = "Principal_TOD";
            this.colPrincipal_TOD.HeaderText = "TOD Principal ";
            this.colPrincipal_TOD.Name = "colPrincipal_TOD";
            this.colPrincipal_TOD.ReadOnly = true;
            this.colPrincipal_TOD.Width = 105;
            // 
            // colInterest_TOD
            // 
            this.colInterest_TOD.DataPropertyName = "Interest_TOD";
            this.colInterest_TOD.HeaderText = " TOD Interest";
            this.colInterest_TOD.Name = "colInterest_TOD";
            this.colInterest_TOD.ReadOnly = true;
            this.colInterest_TOD.Width = 105;
            // 
            // colODAmount
            // 
            this.colODAmount.DataPropertyName = "OD Amount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.NullValue = null;
            this.colODAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.colODAmount.FillWeight = 125.9388F;
            this.colODAmount.HeaderText = "OD Amount";
            this.colODAmount.Name = "colODAmount";
            this.colODAmount.ReadOnly = true;
            this.colODAmount.Width = 105;
            // 
            // colTotalLateDays
            // 
            this.colTotalLateDays.DataPropertyName = "Total Late Days";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colTotalLateDays.DefaultCellStyle = dataGridViewCellStyle4;
            this.colTotalLateDays.FillWeight = 18.53225F;
            this.colTotalLateDays.HeaderText = "Total Late Days";
            this.colTotalLateDays.Name = "colTotalLateDays";
            this.colTotalLateDays.ReadOnly = true;
            this.colTotalLateDays.Width = 70;
            // 
            // colTotalLateFee_PTOD_OnIntRate
            // 
            this.colTotalLateFee_PTOD_OnIntRate.DataPropertyName = "TotalLateFee_PTOD_OnIntRate";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.colTotalLateFee_PTOD_OnIntRate.DefaultCellStyle = dataGridViewCellStyle5;
            this.colTotalLateFee_PTOD_OnIntRate.HeaderText = "Interest on TOD Principal";
            this.colTotalLateFee_PTOD_OnIntRate.Name = "colTotalLateFee_PTOD_OnIntRate";
            this.colTotalLateFee_PTOD_OnIntRate.ReadOnly = true;
            // 
            // colSelect_P_Int
            // 
            this.colSelect_P_Int.DataPropertyName = "Select_P_Int";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.NullValue = false;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            this.colSelect_P_Int.DefaultCellStyle = dataGridViewCellStyle6;
            this.colSelect_P_Int.HeaderText = "Select ";
            this.colSelect_P_Int.Name = "colSelect_P_Int";
            this.colSelect_P_Int.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSelect_P_Int.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSelect_P_Int.Width = 45;
            // 
            // colTotalLateFee_PTOD_OnLateFeeRate
            // 
            this.colTotalLateFee_PTOD_OnLateFeeRate.DataPropertyName = "TotalLateFee_PTOD_OnLateFeeRate";
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.colTotalLateFee_PTOD_OnLateFeeRate.DefaultCellStyle = dataGridViewCellStyle7;
            this.colTotalLateFee_PTOD_OnLateFeeRate.HeaderText = "Late Fees on TOD Principal";
            this.colTotalLateFee_PTOD_OnLateFeeRate.Name = "colTotalLateFee_PTOD_OnLateFeeRate";
            this.colTotalLateFee_PTOD_OnLateFeeRate.ReadOnly = true;
            this.colTotalLateFee_PTOD_OnLateFeeRate.Width = 110;
            // 
            // colSelect_P_Late
            // 
            this.colSelect_P_Late.CheckBoxHeader = false;
            this.colSelect_P_Late.DataPropertyName = "Select_P_Late";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle8.NullValue = false;
            this.colSelect_P_Late.DefaultCellStyle = dataGridViewCellStyle8;
            this.colSelect_P_Late.HeaderText = "Select";
            this.colSelect_P_Late.Id = 0;
            this.colSelect_P_Late.Name = "colSelect_P_Late";
            this.colSelect_P_Late.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colSelect_P_Late.TS = null;
            this.colSelect_P_Late.Width = 45;
            // 
            // colTotalLateFee_ITOD_OnLateFeeRate
            // 
            this.colTotalLateFee_ITOD_OnLateFeeRate.DataPropertyName = "TotalLateFee_ITOD_OnLateFeeRate";
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.colTotalLateFee_ITOD_OnLateFeeRate.DefaultCellStyle = dataGridViewCellStyle9;
            this.colTotalLateFee_ITOD_OnLateFeeRate.HeaderText = "Late Fees on TOD Interest";
            this.colTotalLateFee_ITOD_OnLateFeeRate.Name = "colTotalLateFee_ITOD_OnLateFeeRate";
            this.colTotalLateFee_ITOD_OnLateFeeRate.ReadOnly = true;
            this.colTotalLateFee_ITOD_OnLateFeeRate.Width = 110;
            // 
            // colSelect_I_Late
            // 
            this.colSelect_I_Late.CheckBoxHeader = false;
            this.colSelect_I_Late.DataPropertyName = "Select_I_Late";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.NullValue = false;
            this.colSelect_I_Late.DefaultCellStyle = dataGridViewCellStyle10;
            this.colSelect_I_Late.HeaderText = "Select";
            this.colSelect_I_Late.Id = 0;
            this.colSelect_I_Late.Name = "colSelect_I_Late";
            this.colSelect_I_Late.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colSelect_I_Late.TS = null;
            this.colSelect_I_Late.Width = 45;
            // 
            // colTotalLateFeesAmount
            // 
            this.colTotalLateFeesAmount.DataPropertyName = "Total Late Fees Amount";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colTotalLateFeesAmount.DefaultCellStyle = dataGridViewCellStyle11;
            this.colTotalLateFeesAmount.FillWeight = 357.0591F;
            this.colTotalLateFeesAmount.HeaderText = "Total Late Fees Amount";
            this.colTotalLateFeesAmount.Name = "colTotalLateFeesAmount";
            this.colTotalLateFeesAmount.ReadOnly = true;
            this.colTotalLateFeesAmount.Width = 110;
            // 
            // colSelect
            // 
            this.colSelect.DataPropertyName = "Select";
            this.colSelect.FalseValue = "false";
            this.colSelect.FillWeight = 18.53225F;
            this.colSelect.HeaderText = "Select All";
            this.colSelect.Name = "colSelect";
            this.colSelect.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colSelect.TrueValue = "true";
            this.colSelect.Width = 48;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.Visible = false;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(993, 254);
            this.btnSelectAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(100, 33);
            this.btnSelectAll.TabIndex = 1;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // LOMVEW00441
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 655);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.dgvLateFeeInfo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsbCRUD);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LOMVEW00441";
            this.Text = "Late Fee Exception (Maker)";
            this.Load += new System.EventHandler(this.LOMVEW00441_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLateFeeInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtWorkingCompanyName;
        private System.Windows.Forms.Label lblWCN;
        private System.Windows.Forms.MaskedTextBox mtxtAcctNo;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAccountNo;
        private System.Windows.Forms.DataGridView dgvLateFeeInfo;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaymentTermNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrincipal_TOD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInterest_TOD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colODAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalLateDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalLateFee_PTOD_OnIntRate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect_P_Int;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalLateFee_PTOD_OnLateFeeRate;
        private Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn colSelect_P_Late;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalLateFee_ITOD_OnLateFeeRate;
        private Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn colSelect_I_Late;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalLateFeesAmount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}