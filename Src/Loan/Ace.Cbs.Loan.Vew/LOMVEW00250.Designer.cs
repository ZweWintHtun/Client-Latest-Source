namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00250
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00250));
            this.dtpStartDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblFromDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblToDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.dtpEndDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.cxC00033 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboBranch = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OptTransfer = new System.Windows.Forms.RadioButton();
            this.OptCash = new System.Windows.Forms.RadioButton();
            this.cxC00035 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboOrderBy = new Ace.Windows.CXClient.Controls.CXC0002();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.cboVoucherType = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cxC00034 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.IsSendTabOnEnter = true;
            this.dtpStartDate.Location = new System.Drawing.Point(161, 134);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(149, 20);
            this.dtpStartDate.TabIndex = 187;
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
            this.cboCurrency.Location = new System.Drawing.Point(161, 213);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(149, 21);
            this.cboCurrency.TabIndex = 186;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(48, 140);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(61, 13);
            this.lblFromDate.TabIndex = 190;
            this.lblFromDate.Text = "Start Date :";
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(48, 166);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(58, 13);
            this.lblToDate.TabIndex = 189;
            this.lblToDate.Text = "End Date :";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.IsSendTabOnEnter = true;
            this.dtpEndDate.Location = new System.Drawing.Point(161, 160);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(149, 20);
            this.dtpEndDate.TabIndex = 188;
            // 
            // cxC00033
            // 
            this.cxC00033.AutoSize = true;
            this.cxC00033.Location = new System.Drawing.Point(48, 216);
            this.cxC00033.Name = "cxC00033";
            this.cxC00033.Size = new System.Drawing.Size(55, 13);
            this.cxC00033.TabIndex = 185;
            this.cxC00033.Text = "Currency :";
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
            this.cboBranch.Location = new System.Drawing.Point(161, 186);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(149, 21);
            this.cboBranch.TabIndex = 184;
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(48, 189);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(75, 13);
            this.cxC00031.TabIndex = 183;
            this.cxC00031.Text = "Branch Code :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.OptTransfer);
            this.groupBox1.Controls.Add(this.OptCash);
            this.groupBox1.Location = new System.Drawing.Point(6, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(505, 64);
            this.groupBox1.TabIndex = 191;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "By Transaction Type";
            // 
            // OptTransfer
            // 
            this.OptTransfer.AutoSize = true;
            this.OptTransfer.Location = new System.Drawing.Point(167, 23);
            this.OptTransfer.Name = "OptTransfer";
            this.OptTransfer.Size = new System.Drawing.Size(64, 17);
            this.OptTransfer.TabIndex = 1;
            this.OptTransfer.TabStop = true;
            this.OptTransfer.Text = "Transfer";
            this.OptTransfer.UseVisualStyleBackColor = true;
            this.OptTransfer.CheckedChanged += new System.EventHandler(this.OptTransfer_CheckedChanged);
            // 
            // OptCash
            // 
            this.OptCash.AutoSize = true;
            this.OptCash.Location = new System.Drawing.Point(58, 23);
            this.OptCash.Name = "OptCash";
            this.OptCash.Size = new System.Drawing.Size(49, 17);
            this.OptCash.TabIndex = 0;
            this.OptCash.TabStop = true;
            this.OptCash.Text = "Cash";
            this.OptCash.UseVisualStyleBackColor = true;
            this.OptCash.CheckedChanged += new System.EventHandler(this.OptCash_CheckedChanged);
            // 
            // cxC00035
            // 
            this.cxC00035.AutoSize = true;
            this.cxC00035.Location = new System.Drawing.Point(48, 111);
            this.cxC00035.Name = "cxC00035";
            this.cxC00035.Size = new System.Drawing.Size(80, 13);
            this.cxC00035.TabIndex = 195;
            this.cxC00035.Text = "Voucher Type :";
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.Location = new System.Drawing.Point(48, 243);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(54, 13);
            this.cxC00032.TabIndex = 197;
            this.cxC00032.Text = "Order By :";
            // 
            // cboOrderBy
            // 
            this.cboOrderBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboOrderBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboOrderBy.DropDownHeight = 200;
            this.cboOrderBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrderBy.FormattingEnabled = true;
            this.cboOrderBy.IntegralHeight = false;
            this.cboOrderBy.IsSendTabOnEnter = true;
            this.cboOrderBy.Items.AddRange(new object[] {
            "Entry No",
            "Account No",
            "Date Time",
            "Entered User"});
            this.cboOrderBy.Location = new System.Drawing.Point(161, 240);
            this.cboOrderBy.Name = "cboOrderBy";
            this.cboOrderBy.Size = new System.Drawing.Size(149, 21);
            this.cboOrderBy.TabIndex = 198;
            this.cboOrderBy.SelectedIndexChanged += new System.EventHandler(this.cboOrderBy_SelectedIndexChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-4, -1);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(525, 35);
            this.tsbCRUD.TabIndex = 199;
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // cboVoucherType
            // 
            this.cboVoucherType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboVoucherType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboVoucherType.DropDownHeight = 200;
            this.cboVoucherType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVoucherType.FormattingEnabled = true;
            this.cboVoucherType.IntegralHeight = false;
            this.cboVoucherType.IsSendTabOnEnter = true;
            this.cboVoucherType.Items.AddRange(new object[] {
            "Credit",
            "Debit"});
            this.cboVoucherType.Location = new System.Drawing.Point(161, 108);
            this.cboVoucherType.Name = "cboVoucherType";
            this.cboVoucherType.Size = new System.Drawing.Size(149, 21);
            this.cboVoucherType.TabIndex = 200;
            this.cboVoucherType.SelectedIndexChanged += new System.EventHandler(this.cboVoucherType_SelectedIndexChanged);
            // 
            // cxC00034
            // 
            this.cxC00034.AutoSize = true;
            this.cxC00034.Location = new System.Drawing.Point(48, 140);
            this.cxC00034.Name = "cxC00034";
            this.cxC00034.Size = new System.Drawing.Size(61, 13);
            this.cxC00034.TabIndex = 190;
            this.cxC00034.Text = "Start Date :";
            // 
            // LOMVEW00250
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 297);
            this.Controls.Add(this.cboVoucherType);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.cboOrderBy);
            this.Controls.Add(this.cxC00032);
            this.Controls.Add(this.cxC00035);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.cxC00034);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.cxC00033);
            this.Controls.Add(this.cboBranch);
            this.Controls.Add(this.cxC00031);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00250";
            this.Text = "Transaction Listing";
            this.Load += new System.EventHandler(this.LOMVEW00250_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0005 dtpStartDate;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0003 lblFromDate;
        private Windows.CXClient.Controls.CXC0003 lblToDate;
        private Windows.CXClient.Controls.CXC0005 dtpEndDate;
        private Windows.CXClient.Controls.CXC0003 cxC00033;
        private Windows.CXClient.Controls.CXC0002 cboBranch;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton OptTransfer;
        private System.Windows.Forms.RadioButton OptCash;
        private Windows.CXClient.Controls.CXC0003 cxC00035;
        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private Windows.CXClient.Controls.CXC0002 cboOrderBy;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0002 cboVoucherType;
        private Windows.CXClient.Controls.CXC0003 cxC00034;
    }
}