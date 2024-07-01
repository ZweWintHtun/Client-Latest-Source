namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00246
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00246));
            this.mtxtAcctno = new Ace.Windows.CXClient.Controls.CXC0006();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvHPList = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDealerName = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtDealerBName = new Ace.Windows.CXClient.Controls.CXC0001();
            this.dtpStartDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.lblFromDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblToDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.dtpEndDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.cxC00033 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboBranch = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblHPCount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.ColchkSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColHPNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProductGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLoanAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotalPrincipal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotalInterest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHPList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // mtxtAcctno
            // 
            this.mtxtAcctno.IsSendTabOnEnter = true;
            this.mtxtAcctno.Location = new System.Drawing.Point(160, 115);
            this.mtxtAcctno.Name = "mtxtAcctno";
            this.mtxtAcctno.Size = new System.Drawing.Size(182, 20);
            this.mtxtAcctno.TabIndex = 28;
            this.mtxtAcctno.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtxtAcctno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtxtAcctno_KeyDown);
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-2, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(849, 42);
            this.tsbCRUD.TabIndex = 49;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Dealer Account No :";
            // 
            // dgvHPList
            // 
            this.dgvHPList.AllowUserToAddRows = false;
            this.dgvHPList.AllowUserToDeleteRows = false;
            this.dgvHPList.AllowUserToResizeRows = false;
            this.dgvHPList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHPList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColchkSelect,
            this.ColNo,
            this.ColHPNo,
            this.ColAccountNo,
            this.ColProductGroup,
            this.ColProductName,
            this.ColLoanAmount,
            this.ColDuration,
            this.ColTotalPrincipal,
            this.ColTotalInterest});
            this.dgvHPList.Location = new System.Drawing.Point(12, 231);
            this.dgvHPList.Name = "dgvHPList";
            this.dgvHPList.RowHeadersVisible = false;
            this.dgvHPList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHPList.Size = new System.Drawing.Size(822, 225);
            this.dgvHPList.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Dealer Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "Business Name :";
            // 
            // txtDealerName
            // 
            this.txtDealerName.IsSendTabOnEnter = true;
            this.txtDealerName.Location = new System.Drawing.Point(160, 145);
            this.txtDealerName.MaxLength = 15;
            this.txtDealerName.Name = "txtDealerName";
            this.txtDealerName.ReadOnly = true;
            this.txtDealerName.Size = new System.Drawing.Size(182, 20);
            this.txtDealerName.TabIndex = 100;
            // 
            // txtDealerBName
            // 
            this.txtDealerBName.IsSendTabOnEnter = true;
            this.txtDealerBName.Location = new System.Drawing.Point(160, 175);
            this.txtDealerBName.MaxLength = 15;
            this.txtDealerBName.Multiline = true;
            this.txtDealerBName.Name = "txtDealerBName";
            this.txtDealerBName.ReadOnly = true;
            this.txtDealerBName.Size = new System.Drawing.Size(182, 40);
            this.txtDealerBName.TabIndex = 101;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.IsSendTabOnEnter = true;
            this.dtpStartDate.Location = new System.Drawing.Point(160, 84);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(182, 20);
            this.dtpStartDate.TabIndex = 129;
            this.dtpStartDate.Leave += new System.EventHandler(this.dtpStartDate_Leave);
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(40, 90);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(61, 13);
            this.lblFromDate.TabIndex = 130;
            this.lblFromDate.Text = "Start Date :";
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cxC00031.Location = new System.Drawing.Point(12, 468);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(109, 13);
            this.cxC00031.TabIndex = 131;
            this.cxC00031.Text = "Total HP Count = ";
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(40, 90);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(58, 13);
            this.lblToDate.TabIndex = 147;
            this.lblToDate.Text = "End Date :";
            this.lblToDate.Visible = false;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.IsSendTabOnEnter = true;
            this.dtpEndDate.Location = new System.Drawing.Point(160, 84);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(182, 20);
            this.dtpEndDate.TabIndex = 146;
            this.dtpEndDate.Visible = false;
            // 
            // cxC00033
            // 
            this.cxC00033.AutoSize = true;
            this.cxC00033.Location = new System.Drawing.Point(370, 115);
            this.cxC00033.Name = "cxC00033";
            this.cxC00033.Size = new System.Drawing.Size(55, 13);
            this.cxC00033.TabIndex = 150;
            this.cxC00033.Text = "Currency :";
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.Location = new System.Drawing.Point(370, 85);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(75, 13);
            this.cxC00032.TabIndex = 148;
            this.cxC00032.Text = "Branch Code :";
            // 
            // cboBranch
            // 
            this.cboBranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBranch.DropDownHeight = 200;
            this.cboBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBranch.FormattingEnabled = true;
            this.cboBranch.IntegralHeight = false;
            this.cboBranch.IsSendTabOnEnter = true;
            this.cboBranch.Location = new System.Drawing.Point(465, 85);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(124, 21);
            this.cboBranch.TabIndex = 149;
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
            this.cboCurrency.Location = new System.Drawing.Point(465, 114);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(124, 21);
            this.cboCurrency.TabIndex = 151;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblHPCount
            // 
            this.lblHPCount.AutoSize = true;
            this.lblHPCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHPCount.Location = new System.Drawing.Point(126, 468);
            this.lblHPCount.Name = "lblHPCount";
            this.lblHPCount.Size = new System.Drawing.Size(0, 13);
            this.lblHPCount.TabIndex = 152;
            // 
            // ColchkSelect
            // 
            this.ColchkSelect.HeaderText = "Select";
            this.ColchkSelect.Name = "ColchkSelect";
            this.ColchkSelect.Width = 50;
            // 
            // ColNo
            // 
            this.ColNo.HeaderText = "No";
            this.ColNo.Name = "ColNo";
            this.ColNo.ReadOnly = true;
            this.ColNo.Width = 50;
            // 
            // ColHPNo
            // 
            this.ColHPNo.HeaderText = "HP No";
            this.ColHPNo.Name = "ColHPNo";
            this.ColHPNo.ReadOnly = true;
            // 
            // ColAccountNo
            // 
            this.ColAccountNo.HeaderText = "Account No";
            this.ColAccountNo.Name = "ColAccountNo";
            this.ColAccountNo.ReadOnly = true;
            // 
            // ColProductGroup
            // 
            this.ColProductGroup.HeaderText = "Product Group";
            this.ColProductGroup.Name = "ColProductGroup";
            this.ColProductGroup.ReadOnly = true;
            // 
            // ColProductName
            // 
            this.ColProductName.HeaderText = "Product Name";
            this.ColProductName.Name = "ColProductName";
            this.ColProductName.ReadOnly = true;
            // 
            // ColLoanAmount
            // 
            this.ColLoanAmount.HeaderText = "Loan Amount";
            this.ColLoanAmount.Name = "ColLoanAmount";
            this.ColLoanAmount.ReadOnly = true;
            // 
            // ColDuration
            // 
            this.ColDuration.HeaderText = "Term";
            this.ColDuration.Name = "ColDuration";
            this.ColDuration.ReadOnly = true;
            this.ColDuration.Width = 50;
            // 
            // ColTotalPrincipal
            // 
            this.ColTotalPrincipal.HeaderText = "Total Principal";
            this.ColTotalPrincipal.Name = "ColTotalPrincipal";
            this.ColTotalPrincipal.ReadOnly = true;
            // 
            // ColTotalInterest
            // 
            this.ColTotalInterest.HeaderText = "Total Interest";
            this.ColTotalInterest.Name = "ColTotalInterest";
            this.ColTotalInterest.ReadOnly = true;
            // 
            // LOMVEW00246
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 492);
            this.Controls.Add(this.lblHPCount);
            this.Controls.Add(this.cxC00033);
            this.Controls.Add(this.cxC00032);
            this.Controls.Add(this.cboBranch);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.cxC00031);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.txtDealerBName);
            this.Controls.Add(this.txtDealerName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvHPList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.mtxtAcctno);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LOMVEW00246";
            this.Text = "Hire Purchase Interest Pre-payment By Dealer";
            this.Load += new System.EventHandler(this.LOMVEW00246_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHPList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0006 mtxtAcctno;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvHPList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Windows.CXClient.Controls.CXC0001 txtDealerName;
        private Windows.CXClient.Controls.CXC0001 txtDealerBName;
        private Windows.CXClient.Controls.CXC0005 dtpStartDate;
        private Windows.CXClient.Controls.CXC0003 lblFromDate;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0003 lblToDate;
        private Windows.CXClient.Controls.CXC0005 dtpEndDate;
        private Windows.CXClient.Controls.CXC0003 cxC00033;
        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private Windows.CXClient.Controls.CXC0002 cboBranch;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Windows.CXClient.Controls.CXC0003 lblHPCount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColchkSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColHPNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProductGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLoanAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotalPrincipal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotalInterest;
    }
}