namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00002
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00002));
            this.rdoInternalRemittancePO = new System.Windows.Forms.RadioButton();
            this.lblAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtCurrency = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblPaymentOrderNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.mtxtAccountNo = new System.Windows.Forms.MaskedTextBox();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.txtBudgetYear = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoCustomerPO = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTransactionDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtPaymentOrderNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.cxC00037 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdoInternalRemittancePO
            // 
            this.rdoInternalRemittancePO.AutoSize = true;
            this.rdoInternalRemittancePO.Location = new System.Drawing.Point(118, 23);
            this.rdoInternalRemittancePO.Name = "rdoInternalRemittancePO";
            this.rdoInternalRemittancePO.Size = new System.Drawing.Size(135, 17);
            this.rdoInternalRemittancePO.TabIndex = 0;
            this.rdoInternalRemittancePO.Text = "Internal Remittance PO";
            this.rdoInternalRemittancePO.UseVisualStyleBackColor = true;
            this.rdoInternalRemittancePO.Visible = false;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(19, 221);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(49, 13);
            this.lblAmount.TabIndex = 26;
            this.lblAmount.Text = "Amount :";
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(19, 196);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 27;
            this.lblCurrency.Text = "Currency :";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(19, 147);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 13);
            this.lblName.TabIndex = 28;
            this.lblName.Text = "Name :";
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(19, 118);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(73, 13);
            this.lblAccountNo.TabIndex = 29;
            this.lblAccountNo.Text = "Account No. :";
            // 
            // txtAmount
            // 
            this.txtAmount.DecimalPlaces = 0;
            this.txtAmount.Enabled = false;
            this.txtAmount.IsSendTabOnEnter = true;
            this.txtAmount.Location = new System.Drawing.Point(139, 217);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(141, 20);
            this.txtAmount.TabIndex = 7;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtCurrency
            // 
            this.txtCurrency.DecimalPlaces = 0;
            this.txtCurrency.Enabled = false;
            this.txtCurrency.IsSendTabOnEnter = true;
            this.txtCurrency.Location = new System.Drawing.Point(139, 191);
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.ReadOnly = true;
            this.txtCurrency.Size = new System.Drawing.Size(63, 20);
            this.txtCurrency.TabIndex = 6;
            this.txtCurrency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCurrency.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblPaymentOrderNo
            // 
            this.lblPaymentOrderNo.AutoSize = true;
            this.lblPaymentOrderNo.Location = new System.Drawing.Point(19, 92);
            this.lblPaymentOrderNo.Name = "lblPaymentOrderNo";
            this.lblPaymentOrderNo.Size = new System.Drawing.Size(105, 13);
            this.lblPaymentOrderNo.TabIndex = 24;
            this.lblPaymentOrderNo.Text = "Dealer Payment No :";
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.Location = new System.Drawing.Point(139, 116);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 2;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtxtAccountNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtAccountNo_KeyPress);
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.CausesValidation = false;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, -1);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(496, 31);
            this.tsbCRUD.TabIndex = 3;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // txtBudgetYear
            // 
            this.txtBudgetYear.Enabled = false;
            this.txtBudgetYear.Location = new System.Drawing.Point(286, 90);
            this.txtBudgetYear.MaxLength = 9;
            this.txtBudgetYear.Name = "txtBudgetYear";
            this.txtBudgetYear.Size = new System.Drawing.Size(84, 20);
            this.txtBudgetYear.TabIndex = 3;
            this.txtBudgetYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(139, 142);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(231, 40);
            this.txtName.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoCustomerPO);
            this.groupBox1.Controls.Add(this.rdoInternalRemittancePO);
            this.groupBox1.Location = new System.Drawing.Point(22, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 54);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payment Order Type";
            // 
            // rdoCustomerPO
            // 
            this.rdoCustomerPO.AutoSize = true;
            this.rdoCustomerPO.Checked = true;
            this.rdoCustomerPO.Location = new System.Drawing.Point(50, 23);
            this.rdoCustomerPO.Name = "rdoCustomerPO";
            this.rdoCustomerPO.Size = new System.Drawing.Size(87, 17);
            this.rdoCustomerPO.TabIndex = 0;
            this.rdoCustomerPO.TabStop = true;
            this.rdoCustomerPO.Text = "Customer PO";
            this.rdoCustomerPO.UseVisualStyleBackColor = true;
            this.rdoCustomerPO.CheckedChanged += new System.EventHandler(this.rdoCustomerPO_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTransactionDate);
            this.groupBox2.Controls.Add(this.txtPaymentOrderNo);
            this.groupBox2.Controls.Add(this.cxC00037);
            this.groupBox2.Controls.Add(this.txtBudgetYear);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.txtCurrency);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.mtxtAccountNo);
            this.groupBox2.Controls.Add(this.txtAmount);
            this.groupBox2.Controls.Add(this.lblPaymentOrderNo);
            this.groupBox2.Controls.Add(this.lblAmount);
            this.groupBox2.Controls.Add(this.lblAccountNo);
            this.groupBox2.Controls.Add(this.lblName);
            this.groupBox2.Controls.Add(this.lblCurrency);
            this.groupBox2.Location = new System.Drawing.Point(12, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(470, 256);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // lblTransactionDate
            // 
            this.lblTransactionDate.AutoSize = true;
            this.lblTransactionDate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblTransactionDate.Location = new System.Drawing.Point(406, 22);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Size = new System.Drawing.Size(0, 13);
            this.lblTransactionDate.TabIndex = 16;
            // 
            // txtPaymentOrderNo
            // 
            this.txtPaymentOrderNo.IsSendTabOnEnter = true;
            this.txtPaymentOrderNo.Location = new System.Drawing.Point(139, 90);
            this.txtPaymentOrderNo.MaxLength = 16;
            this.txtPaymentOrderNo.Name = "txtPaymentOrderNo";
            this.txtPaymentOrderNo.Size = new System.Drawing.Size(141, 20);
            this.txtPaymentOrderNo.TabIndex = 1;
            this.txtPaymentOrderNo.Validated += new System.EventHandler(this.txtPaymentOrderNo_Validated);
            // 
            // cxC00037
            // 
            this.cxC00037.AutoSize = true;
            this.cxC00037.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.cxC00037.Location = new System.Drawing.Point(311, 22);
            this.cxC00037.Name = "cxC00037";
            this.cxC00037.Size = new System.Drawing.Size(95, 13);
            this.cxC00037.TabIndex = 15;
            this.cxC00037.Text = "Transaction Date :";
            // 
            // TCMVEW00002
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 304);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tsbCRUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TCMVEW00002";
            this.Text = "Payment to Dealer by Transfer (with other bank account)";
            this.Load += new System.EventHandler(this.TCMVEW00002_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TCMVEW00002_KeyDown);
            this.Move += new System.EventHandler(this.TCMVEW00002_Move);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoInternalRemittancePO;
        private System.Windows.Forms.MaskedTextBox mtxtAccountNo;
        private Windows.CXClient.Controls.CXC0004 txtAmount;
        private Windows.CXClient.Controls.CXC0004 txtCurrency;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0003 lblPaymentOrderNo;
        private Windows.CXClient.Controls.CXC0003 lblAmount;
        private Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Windows.CXClient.Controls.CXC0003 lblName;
        private Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private System.Windows.Forms.TextBox txtBudgetYear;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoCustomerPO;
        private System.Windows.Forms.GroupBox groupBox2;
        private Windows.CXClient.Controls.CXC0001 txtPaymentOrderNo;
        private Windows.CXClient.Controls.CXC0003 lblTransactionDate;
        private Windows.CXClient.Controls.CXC0003 cxC00037;
    }
}