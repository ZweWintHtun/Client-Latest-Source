namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00028
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00028));
            this.chkReversalTransaction = new Ace.Windows.CXClient.Controls.CXC0008();
            this.rdoHomeTransaction = new Ace.Windows.CXClient.Controls.CXC0009();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.label2 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.dtpEndDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.dtpStartDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.rdoActiveTransaction = new Ace.Windows.CXClient.Controls.CXC0009();
            this.lblBranchName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.label4 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gbTransaction = new System.Windows.Forms.GroupBox();
            this.cboBranchNo = new Ace.Windows.CXClient.Controls.AceMultiColumnsComboBox();
            this.cboTransactionType = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblTransactionType = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gbTransaction.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkReversalTransaction
            // 
            this.chkReversalTransaction.AutoSize = true;
            this.chkReversalTransaction.IsSendTabOnEnter = true;
            this.chkReversalTransaction.Location = new System.Drawing.Point(30, 193);
            this.chkReversalTransaction.Name = "chkReversalTransaction";
            this.chkReversalTransaction.Size = new System.Drawing.Size(165, 17);
            this.chkReversalTransaction.TabIndex = 90;
            this.chkReversalTransaction.Text = "Include Reversal Transaction";
            this.chkReversalTransaction.UseVisualStyleBackColor = true;
            // 
            // rdoHomeTransaction
            // 
            this.rdoHomeTransaction.AutoSize = true;
            this.rdoHomeTransaction.Checked = true;
            this.rdoHomeTransaction.IsSendTabOnEnter = true;
            this.rdoHomeTransaction.Location = new System.Drawing.Point(30, 27);
            this.rdoHomeTransaction.Name = "rdoHomeTransaction";
            this.rdoHomeTransaction.Size = new System.Drawing.Size(117, 17);
            this.rdoHomeTransaction.TabIndex = 84;
            this.rdoHomeTransaction.TabStop = true;
            this.rdoHomeTransaction.Text = "Home Transactions";
            this.rdoHomeTransaction.UseVisualStyleBackColor = true;
            this.rdoHomeTransaction.Click += new System.EventHandler(this.rdoHomeTransaction_Click);
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-2, -1);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(499, 31);
            this.tsbCRUD.TabIndex = 93;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 80;
            this.label2.Text = "End Date :";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.IsSendTabOnEnter = true;
            this.dtpEndDate.Location = new System.Drawing.Point(153, 155);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(115, 20);
            this.dtpEndDate.TabIndex = 88;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.IsSendTabOnEnter = true;
            this.dtpStartDate.Location = new System.Drawing.Point(153, 125);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(115, 20);
            this.dtpStartDate.TabIndex = 89;
            // 
            // rdoActiveTransaction
            // 
            this.rdoActiveTransaction.AutoSize = true;
            this.rdoActiveTransaction.IsSendTabOnEnter = true;
            this.rdoActiveTransaction.Location = new System.Drawing.Point(153, 27);
            this.rdoActiveTransaction.Name = "rdoActiveTransaction";
            this.rdoActiveTransaction.Size = new System.Drawing.Size(119, 17);
            this.rdoActiveTransaction.TabIndex = 85;
            this.rdoActiveTransaction.Text = "Active Transactions";
            this.rdoActiveTransaction.UseVisualStyleBackColor = true;
            this.rdoActiveTransaction.Click += new System.EventHandler(this.rdoActiveTransaction_Click);
            // 
            // lblBranchName
            // 
            this.lblBranchName.AutoSize = true;
            this.lblBranchName.Location = new System.Drawing.Point(27, 98);
            this.lblBranchName.Name = "lblBranchName";
            this.lblBranchName.Size = new System.Drawing.Size(78, 13);
            this.lblBranchName.TabIndex = 83;
            this.lblBranchName.Text = "Branch Name :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 79;
            this.label4.Text = "Start Date :";
            // 
            // gbTransaction
            // 
            this.gbTransaction.Controls.Add(this.cboBranchNo);
            this.gbTransaction.Controls.Add(this.chkReversalTransaction);
            this.gbTransaction.Controls.Add(this.rdoHomeTransaction);
            this.gbTransaction.Controls.Add(this.label2);
            this.gbTransaction.Controls.Add(this.dtpEndDate);
            this.gbTransaction.Controls.Add(this.dtpStartDate);
            this.gbTransaction.Controls.Add(this.rdoActiveTransaction);
            this.gbTransaction.Controls.Add(this.lblBranchName);
            this.gbTransaction.Controls.Add(this.label4);
            this.gbTransaction.Controls.Add(this.cboTransactionType);
            this.gbTransaction.Controls.Add(this.lblTransactionType);
            this.gbTransaction.Location = new System.Drawing.Point(11, 37);
            this.gbTransaction.Name = "gbTransaction";
            this.gbTransaction.Size = new System.Drawing.Size(337, 240);
            this.gbTransaction.TabIndex = 94;
            this.gbTransaction.TabStop = false;
            // 
            // cboBranchNo
            // 
            this.cboBranchNo.AutoComplete = false;
            this.cboBranchNo.AutoDropdown = false;
            this.cboBranchNo.BackColorEven = System.Drawing.Color.White;
            this.cboBranchNo.BackColorOdd = System.Drawing.Color.White;
            this.cboBranchNo.ColumnNames = "";
            this.cboBranchNo.ColumnWidthDefault = 150;
            this.cboBranchNo.ColumnWidths = "25,200";
            this.cboBranchNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboBranchNo.FormattingEnabled = true;
            this.cboBranchNo.LinkedColumnIndex = 0;
            this.cboBranchNo.LinkedTextBox = null;
            this.cboBranchNo.Location = new System.Drawing.Point(153, 95);
            this.cboBranchNo.Name = "cboBranchNo";
            this.cboBranchNo.Size = new System.Drawing.Size(115, 21);
            this.cboBranchNo.TabIndex = 92;
            // 
            // cboTransactionType
            // 
            this.cboTransactionType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboTransactionType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTransactionType.DropDownHeight = 200;
            this.cboTransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransactionType.FormattingEnabled = true;
            this.cboTransactionType.IntegralHeight = false;
            this.cboTransactionType.IsSendTabOnEnter = true;
            this.cboTransactionType.Items.AddRange(new object[] {
            "Deposit",
            "Withdraw",
            "Enquiry",
            "Transfer Credit",
            "Transfer Debit",
            "Without Enquiry"});
            this.cboTransactionType.Location = new System.Drawing.Point(153, 63);
            this.cboTransactionType.MaximumSize = new System.Drawing.Size(115, 0);
            this.cboTransactionType.Name = "cboTransactionType";
            this.cboTransactionType.Size = new System.Drawing.Size(115, 21);
            this.cboTransactionType.TabIndex = 86;
            // 
            // lblTransactionType
            // 
            this.lblTransactionType.AutoSize = true;
            this.lblTransactionType.Location = new System.Drawing.Point(27, 66);
            this.lblTransactionType.Name = "lblTransactionType";
            this.lblTransactionType.Size = new System.Drawing.Size(96, 13);
            this.lblTransactionType.TabIndex = 81;
            this.lblTransactionType.Text = "Transaction Type :";
            // 
            // TLMVEW00028
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 288);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.gbTransaction);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00028";
            this.Text = "TLMVEW00028";
            this.Load += new System.EventHandler(this.TLMVEW00028_Load);
            this.gbTransaction.ResumeLayout(false);
            this.gbTransaction.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXC0008 chkReversalTransaction;
        private Windows.CXClient.Controls.CXC0009 rdoHomeTransaction;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0003 label2;
        private Windows.CXClient.Controls.CXC0005 dtpEndDate;
        private Windows.CXClient.Controls.CXC0005 dtpStartDate;
        private Windows.CXClient.Controls.CXC0009 rdoActiveTransaction;
        private Windows.CXClient.Controls.CXC0003 lblBranchName;
        private Windows.CXClient.Controls.CXC0003 label4;
        private System.Windows.Forms.GroupBox gbTransaction;
        private Windows.CXClient.Controls.CXC0002 cboTransactionType;
        private Windows.CXClient.Controls.CXC0003 lblTransactionType;
        private Windows.CXClient.Controls.AceMultiColumnsComboBox cboBranchNo;
    }
}