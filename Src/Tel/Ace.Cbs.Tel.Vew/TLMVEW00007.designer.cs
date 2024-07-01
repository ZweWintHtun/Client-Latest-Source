namespace Ace.Cbs.Tel.Vew
{
    partial class frmTLMVEW00007
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTLMVEW00007));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBudgetYear = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtCurrency = new Ace.Windows.CXClient.Controls.CXC0001();
            this.cboReceivedBank = new Ace.Windows.CXClient.Controls.CXC0002();
            this.mtxtReceivedAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtPaymentOrderNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtPaySlipNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00033 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00034 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00035 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00036 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-5, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(500, 31);
            this.tsbCRUD.TabIndex = 6;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBudgetYear);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.txtCurrency);
            this.groupBox1.Controls.Add(this.cboReceivedBank);
            this.groupBox1.Controls.Add(this.mtxtReceivedAccountNo);
            this.groupBox1.Controls.Add(this.txtPaymentOrderNo);
            this.groupBox1.Controls.Add(this.txtPaySlipNo);
            this.groupBox1.Controls.Add(this.cxC00031);
            this.groupBox1.Controls.Add(this.cxC00032);
            this.groupBox1.Controls.Add(this.cxC00033);
            this.groupBox1.Controls.Add(this.cxC00034);
            this.groupBox1.Controls.Add(this.cxC00035);
            this.groupBox1.Controls.Add(this.cxC00036);
            this.groupBox1.Location = new System.Drawing.Point(11, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(471, 207);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtBudgetYear
            // 
            this.txtBudgetYear.IsSendTabOnEnter = true;
            this.txtBudgetYear.Location = new System.Drawing.Point(277, 49);
            this.txtBudgetYear.MaxLength = 9;
            this.txtBudgetYear.Multiline = true;
            this.txtBudgetYear.Name = "txtBudgetYear";
            this.txtBudgetYear.Size = new System.Drawing.Size(63, 20);
            this.txtBudgetYear.TabIndex = 15;
            // 
            // txtAmount
            // 
            this.txtAmount.DecimalPlaces = 2;
            this.txtAmount.IsSendTabOnEnter = true;
            this.txtAmount.IsThousandSeperator = true;
            this.txtAmount.IsUseFloatingPoint = true;
            this.txtAmount.Location = new System.Drawing.Point(123, 166);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(111, 20);
            this.txtAmount.TabIndex = 14;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtCurrency
            // 
            this.txtCurrency.IsSendTabOnEnter = true;
            this.txtCurrency.Location = new System.Drawing.Point(123, 137);
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.Size = new System.Drawing.Size(83, 20);
            this.txtCurrency.TabIndex = 13;
            // 
            // cboReceivedBank
            // 
            this.cboReceivedBank.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboReceivedBank.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboReceivedBank.DropDownHeight = 200;
            this.cboReceivedBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReceivedBank.FormattingEnabled = true;
            this.cboReceivedBank.IntegralHeight = false;
            this.cboReceivedBank.IsSendTabOnEnter = true;
            this.cboReceivedBank.Location = new System.Drawing.Point(123, 108);
            this.cboReceivedBank.Name = "cboReceivedBank";
            this.cboReceivedBank.Size = new System.Drawing.Size(141, 21);
            this.cboReceivedBank.TabIndex = 12;
            // 
            // mtxtReceivedAccountNo
            // 
            this.mtxtReceivedAccountNo.IsSendTabOnEnter = true;
            this.mtxtReceivedAccountNo.Location = new System.Drawing.Point(123, 78);
            this.mtxtReceivedAccountNo.Name = "mtxtReceivedAccountNo";
            this.mtxtReceivedAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtReceivedAccountNo.TabIndex = 11;
            this.mtxtReceivedAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtPaymentOrderNo
            // 
            this.txtPaymentOrderNo.AcceptsTab = true;
            this.txtPaymentOrderNo.IsSendTabOnEnter = true;
            this.txtPaymentOrderNo.Location = new System.Drawing.Point(123, 49);
            this.txtPaymentOrderNo.MaxLength = 16;
            this.txtPaymentOrderNo.Name = "txtPaymentOrderNo";
            this.txtPaymentOrderNo.Size = new System.Drawing.Size(141, 20);
            this.txtPaymentOrderNo.TabIndex = 10;
            this.txtPaymentOrderNo.Text = "PO";
            // 
            // txtPaySlipNo
            // 
            this.txtPaySlipNo.IsSendTabOnEnter = true;
            this.txtPaySlipNo.Location = new System.Drawing.Point(123, 20);
            this.txtPaySlipNo.Name = "txtPaySlipNo";
            this.txtPaySlipNo.Size = new System.Drawing.Size(141, 20);
            this.txtPaySlipNo.TabIndex = 9;
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(19, 81);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(101, 13);
            this.cxC00031.TabIndex = 0;
            this.cxC00031.Text = "Received A/C No. :";
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.Location = new System.Drawing.Point(19, 111);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(87, 13);
            this.cxC00032.TabIndex = 0;
            this.cxC00032.Text = "Received Bank :";
            // 
            // cxC00033
            // 
            this.cxC00033.AutoSize = true;
            this.cxC00033.Location = new System.Drawing.Point(19, 52);
            this.cxC00033.Name = "cxC00033";
            this.cxC00033.Size = new System.Drawing.Size(48, 13);
            this.cxC00033.TabIndex = 0;
            this.cxC00033.Text = "PO No. :";
            // 
            // cxC00034
            // 
            this.cxC00034.AutoSize = true;
            this.cxC00034.Location = new System.Drawing.Point(19, 169);
            this.cxC00034.Name = "cxC00034";
            this.cxC00034.Size = new System.Drawing.Size(49, 13);
            this.cxC00034.TabIndex = 0;
            this.cxC00034.Text = "Amount :";
            // 
            // cxC00035
            // 
            this.cxC00035.AutoSize = true;
            this.cxC00035.Location = new System.Drawing.Point(19, 23);
            this.cxC00035.Name = "cxC00035";
            this.cxC00035.Size = new System.Drawing.Size(83, 13);
            this.cxC00035.TabIndex = 0;
            this.cxC00035.Text = "Pay In Slip No. :";
            // 
            // cxC00036
            // 
            this.cxC00036.AutoSize = true;
            this.cxC00036.Location = new System.Drawing.Point(19, 140);
            this.cxC00036.Name = "cxC00036";
            this.cxC00036.Size = new System.Drawing.Size(55, 13);
            this.cxC00036.TabIndex = 0;
            this.cxC00036.Text = "Currency :";
            // 
            // frmTLMVEW00007
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 250);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTLMVEW00007";
            this.Text = "Payment Order Receipt Entry";
            this.Load += new System.EventHandler(this.TLMVEW00007_Load);
            this.Move += new System.EventHandler(this.frmTLMVEW00007_Move);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Ace.Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox groupBox1;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private Windows.CXClient.Controls.CXC0003 cxC00033;
        private Windows.CXClient.Controls.CXC0003 cxC00034;
        private Windows.CXClient.Controls.CXC0003 cxC00035;
        private Windows.CXClient.Controls.CXC0003 cxC00036;
        private Windows.CXClient.Controls.CXC0006 txtPaySlipNo;
        private Windows.CXClient.Controls.CXC0002 cboReceivedBank;
        private Windows.CXClient.Controls.CXC0006 mtxtReceivedAccountNo;
        private Windows.CXClient.Controls.CXC0001 txtPaymentOrderNo;
        private Windows.CXClient.Controls.CXC0001 txtBudgetYear;
        private Windows.CXClient.Controls.CXC0004 txtAmount;
        private Windows.CXClient.Controls.CXC0001 txtCurrency;
    }
}