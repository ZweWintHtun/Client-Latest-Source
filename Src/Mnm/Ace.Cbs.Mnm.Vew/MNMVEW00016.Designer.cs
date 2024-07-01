namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00016
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00016));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblGroupNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.grpPORefundReversal = new System.Windows.Forms.GroupBox();
            this.rdoMultiPO = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoSinglePO = new Ace.Windows.CXClient.Controls.CXC0009();
            this.lblAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblPaymentOrderNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtGroupNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtBudgetYear = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtCurrency = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.mtxtCreditedAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblCreditedAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtName = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtPaymentOrderNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTransactionDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00034 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblBudgetYear = new System.Windows.Forms.Label();
            this.grpPORefundReversal.SuspendLayout();
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
            this.tsbCRUD.Size = new System.Drawing.Size(512, 31);
            this.tsbCRUD.TabIndex = 4;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblGroupNo
            // 
            this.lblGroupNo.AutoSize = true;
            this.lblGroupNo.Location = new System.Drawing.Point(33, 131);
            this.lblGroupNo.Name = "lblGroupNo";
            this.lblGroupNo.Size = new System.Drawing.Size(62, 13);
            this.lblGroupNo.TabIndex = 0;
            this.lblGroupNo.Text = "Group No. :";
            // 
            // grpPORefundReversal
            // 
            this.grpPORefundReversal.Controls.Add(this.rdoMultiPO);
            this.grpPORefundReversal.Controls.Add(this.rdoSinglePO);
            this.grpPORefundReversal.Location = new System.Drawing.Point(13, 45);
            this.grpPORefundReversal.Name = "grpPORefundReversal";
            this.grpPORefundReversal.Size = new System.Drawing.Size(263, 56);
            this.grpPORefundReversal.TabIndex = 0;
            this.grpPORefundReversal.TabStop = false;
            this.grpPORefundReversal.Text = "Choose PO To Reverse(Cash/Transfer)";
            // 
            // rdoMultiPO
            // 
            this.rdoMultiPO.AutoSize = true;
            this.rdoMultiPO.IsSendTabOnEnter = true;
            this.rdoMultiPO.Location = new System.Drawing.Point(154, 24);
            this.rdoMultiPO.Name = "rdoMultiPO";
            this.rdoMultiPO.Size = new System.Drawing.Size(65, 17);
            this.rdoMultiPO.TabIndex = 2;
            this.rdoMultiPO.Text = "Multi PO";
            this.rdoMultiPO.UseVisualStyleBackColor = true;
            this.rdoMultiPO.CheckedChanged += new System.EventHandler(this.rdoMultiPO_CheckedChanged);
            // 
            // rdoSinglePO
            // 
            this.rdoSinglePO.AutoSize = true;
            this.rdoSinglePO.IsSendTabOnEnter = true;
            this.rdoSinglePO.Location = new System.Drawing.Point(43, 24);
            this.rdoSinglePO.Name = "rdoSinglePO";
            this.rdoSinglePO.Size = new System.Drawing.Size(72, 17);
            this.rdoSinglePO.TabIndex = 1;
            this.rdoSinglePO.Text = "Single PO";
            this.rdoSinglePO.UseVisualStyleBackColor = true;
            this.rdoSinglePO.CheckedChanged += new System.EventHandler(this.rdoSinglePO_CheckedChanged);
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(33, 214);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(49, 13);
            this.lblAmount.TabIndex = 0;
            this.lblAmount.Text = "Amount :";
            // 
            // lblPaymentOrderNo
            // 
            this.lblPaymentOrderNo.AutoSize = true;
            this.lblPaymentOrderNo.Location = new System.Drawing.Point(33, 160);
            this.lblPaymentOrderNo.Name = "lblPaymentOrderNo";
            this.lblPaymentOrderNo.Size = new System.Drawing.Size(100, 13);
            this.lblPaymentOrderNo.TabIndex = 0;
            this.lblPaymentOrderNo.Text = "Payment Order No.:";
            // 
            // txtGroupNo
            // 
            this.txtGroupNo.IsSendTabOnEnter = true;
            this.txtGroupNo.Location = new System.Drawing.Point(154, 128);
            this.txtGroupNo.Name = "txtGroupNo";
            this.txtGroupNo.Size = new System.Drawing.Size(141, 20);
            this.txtGroupNo.TabIndex = 1;
            this.txtGroupNo.TabStop = false;
            this.txtGroupNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtGroupNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGroupNo_KeyPress);
            // 
            // txtBudgetYear
            // 
            this.txtBudgetYear.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtBudgetYear.Enabled = false;
            this.txtBudgetYear.IsSendTabOnEnter = true;
            this.txtBudgetYear.Location = new System.Drawing.Point(419, 71);
            this.txtBudgetYear.Name = "txtBudgetYear";
            this.txtBudgetYear.Size = new System.Drawing.Size(77, 20);
            this.txtBudgetYear.TabIndex = 3;
            // 
            // txtCurrency
            // 
            this.txtCurrency.IsSendTabOnEnter = true;
            this.txtCurrency.Location = new System.Drawing.Point(154, 181);
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.ReadOnly = true;
            this.txtCurrency.Size = new System.Drawing.Size(115, 20);
            this.txtCurrency.TabIndex = 4;
            // 
            // txtAmount
            // 
            this.txtAmount.DecimalPlaces = 2;
            this.txtAmount.IsSendTabOnEnter = true;
            this.txtAmount.Location = new System.Drawing.Point(154, 207);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(115, 20);
            this.txtAmount.TabIndex = 5;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // mtxtCreditedAccountNo
            // 
            this.mtxtCreditedAccountNo.IsSendTabOnEnter = true;
            this.mtxtCreditedAccountNo.Location = new System.Drawing.Point(154, 233);
            this.mtxtCreditedAccountNo.Name = "mtxtCreditedAccountNo";
            this.mtxtCreditedAccountNo.ReadOnly = true;
            this.mtxtCreditedAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtCreditedAccountNo.TabIndex = 6;
            this.mtxtCreditedAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblCreditedAccountNo
            // 
            this.lblCreditedAccountNo.AutoSize = true;
            this.lblCreditedAccountNo.Location = new System.Drawing.Point(33, 236);
            this.lblCreditedAccountNo.Name = "lblCreditedAccountNo";
            this.lblCreditedAccountNo.Size = new System.Drawing.Size(115, 13);
            this.lblCreditedAccountNo.TabIndex = 72;
            this.lblCreditedAccountNo.Text = "Credited Account No. :";
            // 
            // txtName
            // 
            this.txtName.IsSendTabOnEnter = true;
            this.txtName.Location = new System.Drawing.Point(154, 259);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(141, 20);
            this.txtName.TabIndex = 7;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(33, 262);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 13);
            this.lblName.TabIndex = 74;
            this.lblName.Text = "Name :";
            // 
            // txtPaymentOrderNo
            // 
            this.txtPaymentOrderNo.IsSendTabOnEnter = true;
            this.txtPaymentOrderNo.Location = new System.Drawing.Point(154, 154);
            this.txtPaymentOrderNo.MaxLength = 16;
            this.txtPaymentOrderNo.Name = "txtPaymentOrderNo";
            this.txtPaymentOrderNo.Size = new System.Drawing.Size(141, 20);
            this.txtPaymentOrderNo.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(13, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 188);
            this.groupBox1.TabIndex = 75;
            this.groupBox1.TabStop = false;
            // 
            // lblTransactionDate
            // 
            this.lblTransactionDate.AutoSize = true;
            this.lblTransactionDate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblTransactionDate.Location = new System.Drawing.Point(423, 45);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Size = new System.Drawing.Size(0, 13);
            this.lblTransactionDate.TabIndex = 77;
            // 
            // cxC00034
            // 
            this.cxC00034.AutoSize = true;
            this.cxC00034.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.cxC00034.Location = new System.Drawing.Point(325, 45);
            this.cxC00034.Name = "cxC00034";
            this.cxC00034.Size = new System.Drawing.Size(95, 13);
            this.cxC00034.TabIndex = 76;
            this.cxC00034.Text = "Transaction Date :";
            // 
            // lblBudgetYear
            // 
            this.lblBudgetYear.AutoSize = true;
            this.lblBudgetYear.Location = new System.Drawing.Point(325, 71);
            this.lblBudgetYear.Name = "lblBudgetYear";
            this.lblBudgetYear.Size = new System.Drawing.Size(72, 13);
            this.lblBudgetYear.TabIndex = 78;
            this.lblBudgetYear.Text = "Budget Year :";
            // 
            // MNMVEW00016
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 307);
            this.Controls.Add(this.lblBudgetYear);
            this.Controls.Add(this.lblTransactionDate);
            this.Controls.Add(this.cxC00034);
            this.Controls.Add(this.txtPaymentOrderNo);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.mtxtCreditedAccountNo);
            this.Controls.Add(this.lblCreditedAccountNo);
            this.Controls.Add(this.txtCurrency);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtBudgetYear);
            this.Controls.Add(this.txtGroupNo);
            this.Controls.Add(this.lblGroupNo);
            this.Controls.Add(this.grpPORefundReversal);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblPaymentOrderNo);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MNMVEW00016";
            this.Text = "PO Refund Reversal";
            this.Load += new System.EventHandler(this.MNMVEW00016_Load);
            this.Move += new System.EventHandler(this.MNMVEW00016_Move);
            this.grpPORefundReversal.ResumeLayout(false);
            this.grpPORefundReversal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0003 lblGroupNo;
        private System.Windows.Forms.GroupBox grpPORefundReversal;
        private Windows.CXClient.Controls.CXC0009 rdoMultiPO;
        private Windows.CXClient.Controls.CXC0009 rdoSinglePO;
        private Windows.CXClient.Controls.CXC0003 lblAmount;
        private Windows.CXClient.Controls.CXC0003 lblPaymentOrderNo;
        private Windows.CXClient.Controls.CXC0006 txtGroupNo;
        private Windows.CXClient.Controls.CXC0006 txtBudgetYear;
        private Windows.CXClient.Controls.CXC0001 txtCurrency;
        private Windows.CXClient.Controls.CXC0004 txtAmount;
        private Windows.CXClient.Controls.CXC0006 mtxtCreditedAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblCreditedAccountNo;
        private Windows.CXClient.Controls.CXC0001 txtName;
        private Windows.CXClient.Controls.CXC0003 lblName;
        private Windows.CXClient.Controls.CXC0001 txtPaymentOrderNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private Windows.CXClient.Controls.CXC0003 lblTransactionDate;
        private Windows.CXClient.Controls.CXC0003 cxC00034;
        private System.Windows.Forms.Label lblBudgetYear;
    }
}