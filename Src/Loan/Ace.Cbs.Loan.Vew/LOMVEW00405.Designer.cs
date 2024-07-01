namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00405
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00405));
            this.dtpStartDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.lblFromDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.dtpEndDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblToDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cboBranch = new Ace.Windows.CXClient.Controls.CXC0002();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblBudgetYear = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00034 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cxC00033 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00035 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboBLTypes = new Ace.Windows.CXClient.Controls.CXC0002();
            this.OptByBLTypes = new System.Windows.Forms.RadioButton();
            this.cboIntPaidStatus = new Ace.Windows.CXClient.Controls.CXC0002();
            this.OptAll = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.IsSendTabOnEnter = true;
            this.dtpStartDate.Location = new System.Drawing.Point(165, 56);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(115, 20);
            this.dtpStartDate.TabIndex = 0;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(40, 56);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(61, 13);
            this.lblFromDate.TabIndex = 53;
            this.lblFromDate.Text = "Start Date :";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.IsSendTabOnEnter = true;
            this.dtpEndDate.Location = new System.Drawing.Point(165, 81);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(115, 20);
            this.dtpEndDate.TabIndex = 1;
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.Location = new System.Drawing.Point(40, 111);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(58, 13);
            this.cxC00032.TabIndex = 54;
            this.cxC00032.Text = "Currency  :";
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(40, 84);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(58, 13);
            this.lblToDate.TabIndex = 52;
            this.lblToDate.Text = "End Date :";
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(40, 138);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(75, 13);
            this.cxC00031.TabIndex = 55;
            this.cxC00031.Text = "Branch Code :";
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
            this.cboCurrency.Location = new System.Drawing.Point(165, 107);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 2;
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
            this.cboBranch.Location = new System.Drawing.Point(165, 135);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(115, 21);
            this.cboBranch.TabIndex = 3;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-4, -3);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(486, 39);
            this.tsbCRUD.TabIndex = 47;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblBudgetYear
            // 
            this.lblBudgetYear.AutoSize = true;
            this.lblBudgetYear.ForeColor = System.Drawing.Color.Black;
            this.lblBudgetYear.Location = new System.Drawing.Point(394, 39);
            this.lblBudgetYear.Name = "lblBudgetYear";
            this.lblBudgetYear.Size = new System.Drawing.Size(0, 13);
            this.lblBudgetYear.TabIndex = 115;
            // 
            // cxC00034
            // 
            this.cxC00034.ForeColor = System.Drawing.Color.Black;
            this.cxC00034.Location = new System.Drawing.Point(286, 39);
            this.cxC00034.Name = "cxC00034";
            this.cxC00034.Size = new System.Drawing.Size(196, 20);
            this.cxC00034.TabIndex = 114;
            this.cxC00034.Text = "Budget Year :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cxC00033);
            this.groupBox1.Controls.Add(this.cxC00035);
            this.groupBox1.Controls.Add(this.cboBLTypes);
            this.groupBox1.Controls.Add(this.OptByBLTypes);
            this.groupBox1.Controls.Add(this.cboIntPaidStatus);
            this.groupBox1.Controls.Add(this.OptAll);
            this.groupBox1.Location = new System.Drawing.Point(12, 162);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(466, 124);
            this.groupBox1.TabIndex = 131;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Business Loans Types";
            // 
            // cxC00033
            // 
            this.cxC00033.AutoSize = true;
            this.cxC00033.Location = new System.Drawing.Point(30, 61);
            this.cxC00033.Name = "cxC00033";
            this.cxC00033.Size = new System.Drawing.Size(114, 13);
            this.cxC00033.TabIndex = 145;
            this.cxC00033.Text = "Business Loans Type :";
            // 
            // cxC00035
            // 
            this.cxC00035.AutoSize = true;
            this.cxC00035.Location = new System.Drawing.Point(30, 88);
            this.cxC00035.Name = "cxC00035";
            this.cxC00035.Size = new System.Drawing.Size(105, 13);
            this.cxC00035.TabIndex = 143;
            this.cxC00035.Text = "Interest Paid Status :";
            // 
            // cboBLTypes
            // 
            this.cboBLTypes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboBLTypes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBLTypes.DropDownHeight = 200;
            this.cboBLTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBLTypes.FormattingEnabled = true;
            this.cboBLTypes.IntegralHeight = false;
            this.cboBLTypes.IsSendTabOnEnter = true;
            this.cboBLTypes.ItemHeight = 13;
            this.cboBLTypes.Location = new System.Drawing.Point(153, 58);
            this.cboBLTypes.Name = "cboBLTypes";
            this.cboBLTypes.Size = new System.Drawing.Size(115, 21);
            this.cboBLTypes.TabIndex = 8;
            // 
            // OptByBLTypes
            // 
            this.OptByBLTypes.AutoSize = true;
            this.OptByBLTypes.Location = new System.Drawing.Point(153, 25);
            this.OptByBLTypes.Name = "OptByBLTypes";
            this.OptByBLTypes.Size = new System.Drawing.Size(126, 17);
            this.OptByBLTypes.TabIndex = 7;
            this.OptByBLTypes.Text = "Business Loans Type";
            this.OptByBLTypes.UseVisualStyleBackColor = true;
            this.OptByBLTypes.Click += new System.EventHandler(this.OptByBLTypes_Click);
            // 
            // cboIntPaidStatus
            // 
            this.cboIntPaidStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboIntPaidStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboIntPaidStatus.DropDownHeight = 200;
            this.cboIntPaidStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIntPaidStatus.FormattingEnabled = true;
            this.cboIntPaidStatus.IntegralHeight = false;
            this.cboIntPaidStatus.IsSendTabOnEnter = true;
            this.cboIntPaidStatus.Items.AddRange(new object[] {
            "All",
            "Paid",
            "Absent",
            "Need To Pay"});
            this.cboIntPaidStatus.Location = new System.Drawing.Point(153, 85);
            this.cboIntPaidStatus.Name = "cboIntPaidStatus";
            this.cboIntPaidStatus.Size = new System.Drawing.Size(115, 21);
            this.cboIntPaidStatus.TabIndex = 144;
            this.cboIntPaidStatus.SelectedIndexChanged += new System.EventHandler(this.cboIntPaidStatus_SelectedIndexChanged);
            // 
            // OptAll
            // 
            this.OptAll.AutoSize = true;
            this.OptAll.Checked = true;
            this.OptAll.Location = new System.Drawing.Point(36, 25);
            this.OptAll.Name = "OptAll";
            this.OptAll.Size = new System.Drawing.Size(36, 17);
            this.OptAll.TabIndex = 6;
            this.OptAll.TabStop = true;
            this.OptAll.Text = "All";
            this.OptAll.UseVisualStyleBackColor = true;
            this.OptAll.Click += new System.EventHandler(this.OptAll_Click);
            // 
            // LOMVEW00405
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 289);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblBudgetYear);
            this.Controls.Add(this.cxC00034);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.cxC00032);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.cxC00031);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.cboBranch);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LOMVEW00405";
            this.Text = "Business Loans Interest Due Pre Listing";
            this.Load += new System.EventHandler(this.LOMVEW00405_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0005 dtpStartDate;
        private Windows.CXClient.Controls.CXC0003 lblFromDate;
        private Windows.CXClient.Controls.CXC0005 dtpEndDate;
        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private Windows.CXClient.Controls.CXC0003 lblToDate;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0002 cboBranch;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0003 lblBudgetYear;
        private Windows.CXClient.Controls.CXC0003 cxC00034;
        private System.Windows.Forms.GroupBox groupBox1;
        private Windows.CXClient.Controls.CXC0002 cboBLTypes;
        private System.Windows.Forms.RadioButton OptByBLTypes;
        private System.Windows.Forms.RadioButton OptAll;
        private Windows.CXClient.Controls.CXC0003 cxC00035;
        private Windows.CXClient.Controls.CXC0002 cboIntPaidStatus;
        private Windows.CXClient.Controls.CXC0003 cxC00033;
    }
}