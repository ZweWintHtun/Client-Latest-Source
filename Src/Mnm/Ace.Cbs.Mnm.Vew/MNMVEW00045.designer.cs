namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00045
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00045));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gbAccountCode = new System.Windows.Forms.GroupBox();
            this.rdoByCBMAccountCode = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoByGLAccountCode = new Ace.Windows.CXClient.Controls.CXC0009();
            this.dtpDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.lblEnterDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gbDate = new System.Windows.Forms.GroupBox();
            this.rdoSettlementDate = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoTransactionDate = new Ace.Windows.CXClient.Controls.CXC0009();
            this.chkWithReversal = new Ace.Windows.CXClient.Controls.CXC0008();
            this.rdoSourceCurrency = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoHomeCurrency = new Ace.Windows.CXClient.Controls.CXC0009();
            this.gbCurrency = new System.Windows.Forms.GroupBox();
            this.gbAccountCode.SuspendLayout();
            this.gbDate.SuspendLayout();
            this.gbCurrency.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-2, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(498, 31);
            this.tsbCRUD.TabIndex = 11;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
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
            this.cboCurrency.Location = new System.Drawing.Point(104, 43);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(121, 21);
            this.cboCurrency.TabIndex = 2;
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(7, 46);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 18;
            this.lblCurrency.Text = "Currency :";
            // 
            // gbAccountCode
            // 
            this.gbAccountCode.Controls.Add(this.rdoByCBMAccountCode);
            this.gbAccountCode.Controls.Add(this.rdoByGLAccountCode);
            this.gbAccountCode.Location = new System.Drawing.Point(13, 192);
            this.gbAccountCode.Name = "gbAccountCode";
            this.gbAccountCode.Size = new System.Drawing.Size(298, 54);
            this.gbAccountCode.TabIndex = 8;
            this.gbAccountCode.TabStop = false;
            // 
            // rdoByCBMAccountCode
            // 
            this.rdoByCBMAccountCode.AutoSize = true;
            this.rdoByCBMAccountCode.IsSendTabOnEnter = true;
            this.rdoByCBMAccountCode.Location = new System.Drawing.Point(137, 19);
            this.rdoByCBMAccountCode.Name = "rdoByCBMAccountCode";
            this.rdoByCBMAccountCode.Size = new System.Drawing.Size(134, 17);
            this.rdoByCBMAccountCode.TabIndex = 9;
            this.rdoByCBMAccountCode.Text = "By CBM Account Code";
            this.rdoByCBMAccountCode.UseVisualStyleBackColor = true;
            // 
            // rdoByGLAccountCode
            // 
            this.rdoByGLAccountCode.AutoSize = true;
            this.rdoByGLAccountCode.Checked = true;
            this.rdoByGLAccountCode.IsSendTabOnEnter = true;
            this.rdoByGLAccountCode.Location = new System.Drawing.Point(7, 19);
            this.rdoByGLAccountCode.Name = "rdoByGLAccountCode";
            this.rdoByGLAccountCode.Size = new System.Drawing.Size(125, 17);
            this.rdoByGLAccountCode.TabIndex = 8;
            this.rdoByGLAccountCode.TabStop = true;
            this.rdoByGLAccountCode.Text = "By GL Account Code";
            this.rdoByGLAccountCode.UseVisualStyleBackColor = true;
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.IsSendTabOnEnter = true;
            this.dtpDate.Location = new System.Drawing.Point(107, 44);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(121, 20);
            this.dtpDate.TabIndex = 7;
            this.dtpDate.Value = new System.DateTime(2014, 1, 9, 0, 0, 0, 0);
            // 
            // lblEnterDate
            // 
            this.lblEnterDate.AutoSize = true;
            this.lblEnterDate.Location = new System.Drawing.Point(10, 47);
            this.lblEnterDate.Name = "lblEnterDate";
            this.lblEnterDate.Size = new System.Drawing.Size(64, 13);
            this.lblEnterDate.TabIndex = 43;
            this.lblEnterDate.Text = "Enter Date :";
            // 
            // gbDate
            // 
            this.gbDate.Controls.Add(this.rdoSettlementDate);
            this.gbDate.Controls.Add(this.rdoTransactionDate);
            this.gbDate.Controls.Add(this.dtpDate);
            this.gbDate.Controls.Add(this.lblEnterDate);
            this.gbDate.Location = new System.Drawing.Point(13, 117);
            this.gbDate.Name = "gbDate";
            this.gbDate.Size = new System.Drawing.Size(298, 72);
            this.gbDate.TabIndex = 5;
            this.gbDate.TabStop = false;
            // 
            // rdoSettlementDate
            // 
            this.rdoSettlementDate.AutoSize = true;
            this.rdoSettlementDate.IsSendTabOnEnter = true;
            this.rdoSettlementDate.Location = new System.Drawing.Point(137, 18);
            this.rdoSettlementDate.Name = "rdoSettlementDate";
            this.rdoSettlementDate.Size = new System.Drawing.Size(101, 17);
            this.rdoSettlementDate.TabIndex = 6;
            this.rdoSettlementDate.Text = "Settlement Date";
            this.rdoSettlementDate.UseVisualStyleBackColor = true;
            // 
            // rdoTransactionDate
            // 
            this.rdoTransactionDate.AutoSize = true;
            this.rdoTransactionDate.Checked = true;
            this.rdoTransactionDate.IsSendTabOnEnter = true;
            this.rdoTransactionDate.Location = new System.Drawing.Point(7, 18);
            this.rdoTransactionDate.Name = "rdoTransactionDate";
            this.rdoTransactionDate.Size = new System.Drawing.Size(107, 17);
            this.rdoTransactionDate.TabIndex = 5;
            this.rdoTransactionDate.TabStop = true;
            this.rdoTransactionDate.Text = "Transaction Date";
            this.rdoTransactionDate.UseVisualStyleBackColor = true;
            // 
            // chkWithReversal
            // 
            this.chkWithReversal.AutoSize = true;
            this.chkWithReversal.IsSendTabOnEnter = true;
            this.chkWithReversal.Location = new System.Drawing.Point(13, 254);
            this.chkWithReversal.Name = "chkWithReversal";
            this.chkWithReversal.Size = new System.Drawing.Size(93, 17);
            this.chkWithReversal.TabIndex = 10;
            this.chkWithReversal.Text = "With Reversal";
            this.chkWithReversal.UseVisualStyleBackColor = true;
            // 
            // rdoSourceCurrency
            // 
            this.rdoSourceCurrency.AutoSize = true;
            this.rdoSourceCurrency.Checked = true;
            this.rdoSourceCurrency.IsSendTabOnEnter = true;
            this.rdoSourceCurrency.Location = new System.Drawing.Point(8, 17);
            this.rdoSourceCurrency.Name = "rdoSourceCurrency";
            this.rdoSourceCurrency.Size = new System.Drawing.Size(104, 17);
            this.rdoSourceCurrency.TabIndex = 0;
            this.rdoSourceCurrency.TabStop = true;
            this.rdoSourceCurrency.Text = "Source Currency";
            this.rdoSourceCurrency.UseVisualStyleBackColor = true;
            this.rdoSourceCurrency.CheckedChanged += new System.EventHandler(this.rdoSourceCurrency_CheckedChanged);
            // 
            // rdoHomeCurrency
            // 
            this.rdoHomeCurrency.AutoSize = true;
            this.rdoHomeCurrency.IsSendTabOnEnter = true;
            this.rdoHomeCurrency.Location = new System.Drawing.Point(132, 17);
            this.rdoHomeCurrency.Name = "rdoHomeCurrency";
            this.rdoHomeCurrency.Size = new System.Drawing.Size(98, 17);
            this.rdoHomeCurrency.TabIndex = 1;
            this.rdoHomeCurrency.Text = "Home Currency";
            this.rdoHomeCurrency.UseVisualStyleBackColor = true;
            // 
            // gbCurrency
            // 
            this.gbCurrency.Controls.Add(this.cboCurrency);
            this.gbCurrency.Controls.Add(this.rdoSourceCurrency);
            this.gbCurrency.Controls.Add(this.rdoHomeCurrency);
            this.gbCurrency.Controls.Add(this.lblCurrency);
            this.gbCurrency.Location = new System.Drawing.Point(13, 37);
            this.gbCurrency.Name = "gbCurrency";
            this.gbCurrency.Size = new System.Drawing.Size(298, 77);
            this.gbCurrency.TabIndex = 0;
            this.gbCurrency.TabStop = false;
            // 
            // MNMVEW00045
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 275);
            this.Controls.Add(this.gbCurrency);
            this.Controls.Add(this.chkWithReversal);
            this.Controls.Add(this.gbDate);
            this.Controls.Add(this.gbAccountCode);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00045";
            this.Text = "Trial Sheet Listing";
            this.Load += new System.EventHandler(this.MNMVEW00045_Load);
            this.gbAccountCode.ResumeLayout(false);
            this.gbAccountCode.PerformLayout();
            this.gbDate.ResumeLayout(false);
            this.gbDate.PerformLayout();
            this.gbCurrency.ResumeLayout(false);
            this.gbCurrency.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0003 lblCurrency;
        private System.Windows.Forms.GroupBox gbAccountCode;
        private Windows.CXClient.Controls.CXC0009 rdoByCBMAccountCode;
        private Windows.CXClient.Controls.CXC0009 rdoByGLAccountCode;
        private Windows.CXClient.Controls.CXC0005 dtpDate;
        private Windows.CXClient.Controls.CXC0003 lblEnterDate;
        private System.Windows.Forms.GroupBox gbDate;
        private Windows.CXClient.Controls.CXC0009 rdoSettlementDate;
        private Windows.CXClient.Controls.CXC0009 rdoTransactionDate;
        private Windows.CXClient.Controls.CXC0008 chkWithReversal;
        private Windows.CXClient.Controls.CXC0009 rdoSourceCurrency;
        private Windows.CXClient.Controls.CXC0009 rdoHomeCurrency;
        private System.Windows.Forms.GroupBox gbCurrency;
    }
}