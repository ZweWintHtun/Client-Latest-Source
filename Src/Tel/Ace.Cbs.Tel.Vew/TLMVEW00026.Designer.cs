namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00026
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00026));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gbAccountType = new System.Windows.Forms.GroupBox();
            this.rdoPLAccount = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoDLAccount = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoHPAcount = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoBLAccount = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoFixedAccount = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoSavingAccount = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoCurrentAccout = new Ace.Windows.CXClient.Controls.CXC0009();
            this.lblMaximumAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblMinimumAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtMaximumAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtMinimumAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblStartDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblEndDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpEndDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.dtpStartDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.gbAccountType.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-3, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(492, 31);
            this.tsbCRUD.TabIndex = 8;
            this.tsbCRUD.butPrint.TabIndex = 8;
            this.tsbCRUD.butCancel.TabIndex = 9;
            this.tsbCRUD.butExit.TabIndex = 10;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // gbAccountType
            // 
            this.gbAccountType.Controls.Add(this.rdoPLAccount);
            this.gbAccountType.Controls.Add(this.rdoDLAccount);
            this.gbAccountType.Controls.Add(this.rdoHPAcount);
            this.gbAccountType.Controls.Add(this.rdoBLAccount);
            this.gbAccountType.Controls.Add(this.rdoFixedAccount);
            this.gbAccountType.Controls.Add(this.rdoSavingAccount);
            this.gbAccountType.Location = new System.Drawing.Point(24, 169);
            this.gbAccountType.Name = "gbAccountType";
            this.gbAccountType.Size = new System.Drawing.Size(444, 53);
            this.gbAccountType.TabIndex = 66;
            this.gbAccountType.TabStop = false;
            this.gbAccountType.Text = "Account Type";
            // 
            // rdoPLAccount
            // 
            this.rdoPLAccount.AutoSize = true;
            this.rdoPLAccount.Checked = true;
            this.rdoPLAccount.IsSendTabOnEnter = true;
            this.rdoPLAccount.Location = new System.Drawing.Point(212, 19);
            this.rdoPLAccount.Name = "rdoPLAccount";
            this.rdoPLAccount.Size = new System.Drawing.Size(98, 30);
            this.rdoPLAccount.TabIndex = 6;
            this.rdoPLAccount.TabStop = true;
            this.rdoPLAccount.Text = "Personal Loans\r\nAccount";
            this.rdoPLAccount.UseVisualStyleBackColor = true;
            this.rdoPLAccount.CheckedChanged += new System.EventHandler(this.rdoPLAccount_CheckedChanged);
            // 
            // rdoDLAccount
            // 
            this.rdoDLAccount.AutoSize = true;
            this.rdoDLAccount.Checked = true;
            this.rdoDLAccount.IsSendTabOnEnter = true;
            this.rdoDLAccount.Location = new System.Drawing.Point(321, 22);
            this.rdoDLAccount.Name = "rdoDLAccount";
            this.rdoDLAccount.Size = new System.Drawing.Size(99, 17);
            this.rdoDLAccount.TabIndex = 7;
            this.rdoDLAccount.TabStop = true;
            this.rdoDLAccount.Text = "Dealer Account";
            this.rdoDLAccount.UseVisualStyleBackColor = true;
            this.rdoDLAccount.CheckedChanged += new System.EventHandler(this.rdoDLAccount_CheckedChanged);
            // 
            // rdoHPAcount
            // 
            this.rdoHPAcount.AutoSize = true;
            this.rdoHPAcount.Checked = true;
            this.rdoHPAcount.IsSendTabOnEnter = true;
            this.rdoHPAcount.Location = new System.Drawing.Point(114, 19);
            this.rdoHPAcount.Name = "rdoHPAcount";
            this.rdoHPAcount.Size = new System.Drawing.Size(92, 30);
            this.rdoHPAcount.TabIndex = 5;
            this.rdoHPAcount.TabStop = true;
            this.rdoHPAcount.Text = "HirePurchase \r\nAccount";
            this.rdoHPAcount.UseVisualStyleBackColor = true;
            this.rdoHPAcount.CheckedChanged += new System.EventHandler(this.rdoHPAcount_CheckedChanged);
            // 
            // rdoBLAccount
            // 
            this.rdoBLAccount.AutoSize = true;
            this.rdoBLAccount.Checked = true;
            this.rdoBLAccount.IsSendTabOnEnter = true;
            this.rdoBLAccount.Location = new System.Drawing.Point(9, 19);
            this.rdoBLAccount.Name = "rdoBLAccount";
            this.rdoBLAccount.Size = new System.Drawing.Size(99, 30);
            this.rdoBLAccount.TabIndex = 4;
            this.rdoBLAccount.TabStop = true;
            this.rdoBLAccount.Text = "Business Loans\r\nAccount";
            this.rdoBLAccount.UseVisualStyleBackColor = true;
            this.rdoBLAccount.CheckedChanged += new System.EventHandler(this.rdoBLAccount_CheckedChanged);
            // 
            // rdoFixedAccount
            // 
            this.rdoFixedAccount.AutoSize = true;
            this.rdoFixedAccount.IsSendTabOnEnter = true;
            this.rdoFixedAccount.Location = new System.Drawing.Point(101, 41);
            this.rdoFixedAccount.Name = "rdoFixedAccount";
            this.rdoFixedAccount.Size = new System.Drawing.Size(93, 17);
            this.rdoFixedAccount.TabIndex = 2;
            this.rdoFixedAccount.Text = "Fixed Account";
            this.rdoFixedAccount.UseVisualStyleBackColor = true;
            this.rdoFixedAccount.Visible = false;
            this.rdoFixedAccount.CheckedChanged += new System.EventHandler(this.rdoFixedAccount_CheckedChanged);
            // 
            // rdoSavingAccount
            // 
            this.rdoSavingAccount.AutoSize = true;
            this.rdoSavingAccount.IsSendTabOnEnter = true;
            this.rdoSavingAccount.Location = new System.Drawing.Point(-6, 41);
            this.rdoSavingAccount.Name = "rdoSavingAccount";
            this.rdoSavingAccount.Size = new System.Drawing.Size(101, 17);
            this.rdoSavingAccount.TabIndex = 1;
            this.rdoSavingAccount.Text = "Saving Account";
            this.rdoSavingAccount.UseVisualStyleBackColor = true;
            this.rdoSavingAccount.Visible = false;
            this.rdoSavingAccount.CheckedChanged += new System.EventHandler(this.rdoSavingAccount_CheckedChanged);
            // 
            // rdoCurrentAccout
            // 
            this.rdoCurrentAccout.AutoSize = true;
            this.rdoCurrentAccout.Checked = true;
            this.rdoCurrentAccout.IsSendTabOnEnter = true;
            this.rdoCurrentAccout.Location = new System.Drawing.Point(237, 177);
            this.rdoCurrentAccout.Name = "rdoCurrentAccout";
            this.rdoCurrentAccout.Size = new System.Drawing.Size(102, 17);
            this.rdoCurrentAccout.TabIndex = 0;
            this.rdoCurrentAccout.TabStop = true;
            this.rdoCurrentAccout.Text = "Current Account";
            this.rdoCurrentAccout.UseVisualStyleBackColor = true;
            this.rdoCurrentAccout.Visible = false;
            this.rdoCurrentAccout.CheckedChanged += new System.EventHandler(this.rdoCurrentAccout_CheckedChanged);
            // 
            // lblMaximumAmount
            // 
            this.lblMaximumAmount.AutoSize = true;
            this.lblMaximumAmount.Location = new System.Drawing.Point(22, 100);
            this.lblMaximumAmount.Name = "lblMaximumAmount";
            this.lblMaximumAmount.Size = new System.Drawing.Size(96, 13);
            this.lblMaximumAmount.TabIndex = 65;
            this.lblMaximumAmount.Text = "Maximum Amount :";
            // 
            // lblMinimumAmount
            // 
            this.lblMinimumAmount.AutoSize = true;
            this.lblMinimumAmount.Location = new System.Drawing.Point(22, 75);
            this.lblMinimumAmount.Name = "lblMinimumAmount";
            this.lblMinimumAmount.Size = new System.Drawing.Size(93, 13);
            this.lblMinimumAmount.TabIndex = 64;
            this.lblMinimumAmount.Text = "Minimum Amount :";
            // 
            // txtMaximumAmount
            // 
            this.txtMaximumAmount.DecimalPlaces = 2;
            this.txtMaximumAmount.IsSendTabOnEnter = true;
            this.txtMaximumAmount.Location = new System.Drawing.Point(132, 97);
            this.txtMaximumAmount.Name = "txtMaximumAmount";
            this.txtMaximumAmount.Size = new System.Drawing.Size(111, 20);
            this.txtMaximumAmount.TabIndex = 3;
            this.txtMaximumAmount.Text = "0.00";
            this.txtMaximumAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMaximumAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtMinimumAmount
            // 
            this.txtMinimumAmount.DecimalPlaces = 2;
            this.txtMinimumAmount.IsSendTabOnEnter = true;
            this.txtMinimumAmount.Location = new System.Drawing.Point(132, 71);
            this.txtMinimumAmount.Name = "txtMinimumAmount";
            this.txtMinimumAmount.Size = new System.Drawing.Size(111, 20);
            this.txtMinimumAmount.TabIndex = 2;
            this.txtMinimumAmount.Text = "0.00";
            this.txtMinimumAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMinimumAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartDate.Location = new System.Drawing.Point(22, 23);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(61, 13);
            this.lblStartDate.TabIndex = 0;
            this.lblStartDate.Text = "Start Date :";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndDate.Location = new System.Drawing.Point(22, 49);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(58, 13);
            this.lblEndDate.TabIndex = 58;
            this.lblEndDate.Text = "End Date :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpEndDate);
            this.groupBox1.Controls.Add(this.dtpStartDate);
            this.groupBox1.Controls.Add(this.lblEndDate);
            this.groupBox1.Controls.Add(this.lblStartDate);
            this.groupBox1.Controls.Add(this.rdoCurrentAccout);
            this.groupBox1.Controls.Add(this.txtMinimumAmount);
            this.groupBox1.Controls.Add(this.lblMaximumAmount);
            this.groupBox1.Controls.Add(this.txtMaximumAmount);
            this.groupBox1.Controls.Add(this.lblMinimumAmount);
            this.groupBox1.Location = new System.Drawing.Point(12, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(462, 196);
            this.groupBox1.TabIndex = 69;
            this.groupBox1.TabStop = false;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.IsSendTabOnEnter = true;
            this.dtpEndDate.Location = new System.Drawing.Point(132, 45);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(115, 20);
            this.dtpEndDate.TabIndex = 1;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.IsSendTabOnEnter = true;
            this.dtpStartDate.Location = new System.Drawing.Point(132, 19);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(115, 20);
            this.dtpStartDate.TabIndex = 0;
            // 
            // TLMVEW00026
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 243);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.gbAccountType);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00026";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deposit Listing By Grade";
            this.Load += new System.EventHandler(this.TLMVEW00026_Load);
            this.gbAccountType.ResumeLayout(false);
            this.gbAccountType.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox gbAccountType;
        private Windows.CXClient.Controls.CXC0009 rdoFixedAccount;
        private Windows.CXClient.Controls.CXC0009 rdoSavingAccount;
        private Windows.CXClient.Controls.CXC0009 rdoCurrentAccout;
        private Windows.CXClient.Controls.CXC0003 lblMaximumAmount;
        private Windows.CXClient.Controls.CXC0003 lblMinimumAmount;
        private Windows.CXClient.Controls.CXC0004 txtMaximumAmount;
        private Windows.CXClient.Controls.CXC0004 txtMinimumAmount;
        private Windows.CXClient.Controls.CXC0003 lblStartDate;
        private Windows.CXClient.Controls.CXC0003 lblEndDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private Windows.CXClient.Controls.CXC0009 rdoDLAccount;
        private Windows.CXClient.Controls.CXC0009 rdoHPAcount;
        private Windows.CXClient.Controls.CXC0009 rdoBLAccount;
        private Windows.CXClient.Controls.CXC0009 rdoPLAccount;
        private Windows.CXClient.Controls.CXC0005 dtpStartDate;
        private Windows.CXClient.Controls.CXC0005 dtpEndDate;
    }
}