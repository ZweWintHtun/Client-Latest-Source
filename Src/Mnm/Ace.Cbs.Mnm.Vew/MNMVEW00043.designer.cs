namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00043
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00043));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtYear = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblRequireMonth = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblRequireYear = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gbAccountCode = new System.Windows.Forms.GroupBox();
            this.rdoByCBMAccountCode = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoByGLAccountCode = new Ace.Windows.CXClient.Controls.CXC0009();
            this.chkByHomeCurrency = new Ace.Windows.CXClient.Controls.CXC0008();
            this.txtMonth = new Ace.Windows.CXClient.Controls.CXC0004();
            this.rdoHomeCurrency = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoSourceCurrency = new Ace.Windows.CXClient.Controls.CXC0009();
            this.grpBranch = new System.Windows.Forms.GroupBox();
            this.cboBranch = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.chkBranch = new Ace.Windows.CXClient.Controls.CXC0008();
            this.grpCurrencyInfo = new System.Windows.Forms.GroupBox();
            this.gbAccountCode.SuspendLayout();
            this.grpBranch.SuspendLayout();
            this.grpCurrencyInfo.SuspendLayout();
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
            this.tsbCRUD.Size = new System.Drawing.Size(540, 31);
            this.tsbCRUD.TabIndex = 14;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick_1);
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
            this.cboCurrency.Location = new System.Drawing.Point(74, 47);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(121, 21);
            this.cboCurrency.TabIndex = 3;
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(13, 50);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 12;
            this.lblCurrency.Text = "Currency :";
            // 
            // txtYear
            // 
            this.txtYear.DecimalPlaces = 0;
            this.txtYear.IsSendTabOnEnter = true;
            this.txtYear.Location = new System.Drawing.Point(131, 125);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(100, 20);
            this.txtYear.TabIndex = 7;
            this.txtYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtYear.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblRequireMonth
            // 
            this.lblRequireMonth.AutoSize = true;
            this.lblRequireMonth.Location = new System.Drawing.Point(27, 155);
            this.lblRequireMonth.Name = "lblRequireMonth";
            this.lblRequireMonth.Size = new System.Drawing.Size(83, 13);
            this.lblRequireMonth.TabIndex = 38;
            this.lblRequireMonth.Text = "Require Month :";
            // 
            // lblRequireYear
            // 
            this.lblRequireYear.AutoSize = true;
            this.lblRequireYear.Location = new System.Drawing.Point(27, 128);
            this.lblRequireYear.Name = "lblRequireYear";
            this.lblRequireYear.Size = new System.Drawing.Size(72, 13);
            this.lblRequireYear.TabIndex = 37;
            this.lblRequireYear.Text = "Budget Year :";
            // 
            // gbAccountCode
            // 
            this.gbAccountCode.Controls.Add(this.rdoByCBMAccountCode);
            this.gbAccountCode.Controls.Add(this.rdoByGLAccountCode);
            this.gbAccountCode.Location = new System.Drawing.Point(245, 121);
            this.gbAccountCode.Name = "gbAccountCode";
            this.gbAccountCode.Size = new System.Drawing.Size(279, 51);
            this.gbAccountCode.TabIndex = 9;
            this.gbAccountCode.TabStop = false;
            this.gbAccountCode.Visible = false;
            // 
            // rdoByCBMAccountCode
            // 
            this.rdoByCBMAccountCode.AutoSize = true;
            this.rdoByCBMAccountCode.IsSendTabOnEnter = true;
            this.rdoByCBMAccountCode.Location = new System.Drawing.Point(139, 18);
            this.rdoByCBMAccountCode.Name = "rdoByCBMAccountCode";
            this.rdoByCBMAccountCode.Size = new System.Drawing.Size(134, 17);
            this.rdoByCBMAccountCode.TabIndex = 11;
            this.rdoByCBMAccountCode.Text = "By CBM Account Code";
            this.rdoByCBMAccountCode.UseVisualStyleBackColor = true;
            // 
            // rdoByGLAccountCode
            // 
            this.rdoByGLAccountCode.AutoSize = true;
            this.rdoByGLAccountCode.Checked = true;
            this.rdoByGLAccountCode.IsSendTabOnEnter = true;
            this.rdoByGLAccountCode.Location = new System.Drawing.Point(6, 18);
            this.rdoByGLAccountCode.Name = "rdoByGLAccountCode";
            this.rdoByGLAccountCode.Size = new System.Drawing.Size(125, 17);
            this.rdoByGLAccountCode.TabIndex = 10;
            this.rdoByGLAccountCode.TabStop = true;
            this.rdoByGLAccountCode.Text = "By GL Account Code";
            this.rdoByGLAccountCode.UseVisualStyleBackColor = true;
            // 
            // chkByHomeCurrency
            // 
            this.chkByHomeCurrency.AutoSize = true;
            this.chkByHomeCurrency.IsSendTabOnEnter = true;
            this.chkByHomeCurrency.Location = new System.Drawing.Point(16, 61);
            this.chkByHomeCurrency.Name = "chkByHomeCurrency";
            this.chkByHomeCurrency.Size = new System.Drawing.Size(114, 17);
            this.chkByHomeCurrency.TabIndex = 6;
            this.chkByHomeCurrency.Text = "By Home Currency";
            this.chkByHomeCurrency.UseVisualStyleBackColor = true;
            this.chkByHomeCurrency.Visible = false;
            // 
            // txtMonth
            // 
            this.txtMonth.DecimalPlaces = 0;
            this.txtMonth.IsSendTabOnEnter = true;
            this.txtMonth.Location = new System.Drawing.Point(131, 151);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(100, 20);
            this.txtMonth.TabIndex = 8;
            this.txtMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMonth.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // rdoHomeCurrency
            // 
            this.rdoHomeCurrency.AutoSize = true;
            this.rdoHomeCurrency.IsSendTabOnEnter = true;
            this.rdoHomeCurrency.Location = new System.Drawing.Point(140, 18);
            this.rdoHomeCurrency.Name = "rdoHomeCurrency";
            this.rdoHomeCurrency.Size = new System.Drawing.Size(98, 17);
            this.rdoHomeCurrency.TabIndex = 2;
            this.rdoHomeCurrency.Text = "Home Currency";
            this.rdoHomeCurrency.UseVisualStyleBackColor = true;
            this.rdoHomeCurrency.CheckedChanged += new System.EventHandler(this.chkHomeCurrency_CheckedChanged);
            // 
            // rdoSourceCurrency
            // 
            this.rdoSourceCurrency.AutoSize = true;
            this.rdoSourceCurrency.Checked = true;
            this.rdoSourceCurrency.IsSendTabOnEnter = true;
            this.rdoSourceCurrency.Location = new System.Drawing.Point(16, 18);
            this.rdoSourceCurrency.Name = "rdoSourceCurrency";
            this.rdoSourceCurrency.Size = new System.Drawing.Size(104, 17);
            this.rdoSourceCurrency.TabIndex = 1;
            this.rdoSourceCurrency.TabStop = true;
            this.rdoSourceCurrency.Text = "Source Currency";
            this.rdoSourceCurrency.UseVisualStyleBackColor = true;
            this.rdoSourceCurrency.CheckedChanged += new System.EventHandler(this.chkSourceCurrency_CheckedChanged);
            // 
            // grpBranch
            // 
            this.grpBranch.Controls.Add(this.cboBranch);
            this.grpBranch.Controls.Add(this.cxC00031);
            this.grpBranch.Controls.Add(this.chkBranch);
            this.grpBranch.Location = new System.Drawing.Point(12, 37);
            this.grpBranch.Name = "grpBranch";
            this.grpBranch.Size = new System.Drawing.Size(238, 78);
            this.grpBranch.TabIndex = 10;
            this.grpBranch.TabStop = false;
            this.grpBranch.Text = "Branch";
            this.grpBranch.Visible = false;
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
            this.cboBranch.Location = new System.Drawing.Point(97, 46);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(121, 21);
            this.cboBranch.TabIndex = 13;
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(15, 50);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(75, 13);
            this.cxC00031.TabIndex = 42;
            this.cxC00031.Text = "Branch Code :";
            // 
            // chkBranch
            // 
            this.chkBranch.AutoSize = true;
            this.chkBranch.IsSendTabOnEnter = true;
            this.chkBranch.Location = new System.Drawing.Point(18, 19);
            this.chkBranch.Name = "chkBranch";
            this.chkBranch.Size = new System.Drawing.Size(77, 17);
            this.chkBranch.TabIndex = 12;
            this.chkBranch.Text = "All Branch.";
            this.chkBranch.UseVisualStyleBackColor = true;
            this.chkBranch.CheckedChanged += new System.EventHandler(this.chkBranch_CheckedChanged);
            // 
            // grpCurrencyInfo
            // 
            this.grpCurrencyInfo.Controls.Add(this.rdoSourceCurrency);
            this.grpCurrencyInfo.Controls.Add(this.rdoHomeCurrency);
            this.grpCurrencyInfo.Controls.Add(this.lblCurrency);
            this.grpCurrencyInfo.Controls.Add(this.cboCurrency);
            this.grpCurrencyInfo.Controls.Add(this.chkByHomeCurrency);
            this.grpCurrencyInfo.Location = new System.Drawing.Point(263, 37);
            this.grpCurrencyInfo.Name = "grpCurrencyInfo";
            this.grpCurrencyInfo.Size = new System.Drawing.Size(259, 78);
            this.grpCurrencyInfo.TabIndex = 43;
            this.grpCurrencyInfo.TabStop = false;
            this.grpCurrencyInfo.Text = "Currency";
            // 
            // MNMVEW00043
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 189);
            this.Controls.Add(this.grpCurrencyInfo);
            this.Controls.Add(this.grpBranch);
            this.Controls.Add(this.txtMonth);
            this.Controls.Add(this.gbAccountCode);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.lblRequireMonth);
            this.Controls.Add(this.lblRequireYear);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00043";
            this.Text = "Trial Balance Detail Listing";
            this.Load += new System.EventHandler(this.MNMVEW00043_Load);
            this.gbAccountCode.ResumeLayout(false);
            this.gbAccountCode.PerformLayout();
            this.grpBranch.ResumeLayout(false);
            this.grpBranch.PerformLayout();
            this.grpCurrencyInfo.ResumeLayout(false);
            this.grpCurrencyInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Windows.CXClient.Controls.CXC0004 txtYear;
        private Windows.CXClient.Controls.CXC0003 lblRequireMonth;
        private Windows.CXClient.Controls.CXC0003 lblRequireYear;
        private System.Windows.Forms.GroupBox gbAccountCode;
        private Windows.CXClient.Controls.CXC0009 rdoByCBMAccountCode;
        private Windows.CXClient.Controls.CXC0009 rdoByGLAccountCode;
        private Windows.CXClient.Controls.CXC0008 chkByHomeCurrency;
        private Windows.CXClient.Controls.CXC0004 txtMonth;
        private Windows.CXClient.Controls.CXC0009 rdoHomeCurrency;
        private Windows.CXClient.Controls.CXC0009 rdoSourceCurrency;
        private System.Windows.Forms.GroupBox grpBranch;
        private Windows.CXClient.Controls.CXC0002 cboBranch;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0008 chkBranch;
        private System.Windows.Forms.GroupBox grpCurrencyInfo;
    }
}