namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00006
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00006));
            this.gbName = new System.Windows.Forms.GroupBox();
            this.lvName = new System.Windows.Forms.ListView();
            this.lblPayInSlipNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblOtherBank = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblChequeNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAmt = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtPaySlip = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cboOtherBank = new Ace.Windows.CXClient.Controls.CXC0002();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblReceiptAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mtxtReceiptAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtChequeNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblBankDescription = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gbName.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbName
            // 
            this.gbName.Controls.Add(this.lvName);
            this.gbName.Location = new System.Drawing.Point(320, 25);
            this.gbName.Name = "gbName";
            this.gbName.Size = new System.Drawing.Size(221, 146);
            this.gbName.TabIndex = 8;
            this.gbName.TabStop = false;
            this.gbName.Text = "Name(s)";
            // 
            // lvName
            // 
            this.lvName.CausesValidation = false;
            this.lvName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvName.Location = new System.Drawing.Point(3, 16);
            this.lvName.Name = "lvName";
            this.lvName.Size = new System.Drawing.Size(215, 127);
            this.lvName.TabIndex = 9;
            this.lvName.TabStop = false;
            this.lvName.UseCompatibleStateImageBehavior = false;
            this.lvName.View = System.Windows.Forms.View.List;
            // 
            // lblPayInSlipNo
            // 
            this.lblPayInSlipNo.AutoSize = true;
            this.lblPayInSlipNo.Location = new System.Drawing.Point(25, 53);
            this.lblPayInSlipNo.Name = "lblPayInSlipNo";
            this.lblPayInSlipNo.Size = new System.Drawing.Size(77, 13);
            this.lblPayInSlipNo.TabIndex = 0;
            this.lblPayInSlipNo.Text = "Pay In Slip No:";
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(25, 79);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(67, 13);
            this.lblAccountNo.TabIndex = 0;
            this.lblAccountNo.Text = "Account No:";
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(25, 115);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(52, 13);
            this.lblCurrency.TabIndex = 0;
            this.lblCurrency.Text = "Currency:";
            // 
            // lblOtherBank
            // 
            this.lblOtherBank.AutoSize = true;
            this.lblOtherBank.Location = new System.Drawing.Point(13, 174);
            this.lblOtherBank.Name = "lblOtherBank";
            this.lblOtherBank.Size = new System.Drawing.Size(84, 13);
            this.lblOtherBank.TabIndex = 0;
            this.lblOtherBank.Text = "Received Bank:";
            // 
            // lblChequeNo
            // 
            this.lblChequeNo.AutoSize = true;
            this.lblChequeNo.Location = new System.Drawing.Point(25, 145);
            this.lblChequeNo.Name = "lblChequeNo";
            this.lblChequeNo.Size = new System.Drawing.Size(64, 13);
            this.lblChequeNo.TabIndex = 0;
            this.lblChequeNo.Text = "Cheque No:";
            // 
            // lblAmt
            // 
            this.lblAmt.AutoSize = true;
            this.lblAmt.Location = new System.Drawing.Point(13, 226);
            this.lblAmt.Name = "lblAmt";
            this.lblAmt.Size = new System.Drawing.Size(46, 13);
            this.lblAmt.TabIndex = 0;
            this.lblAmt.Text = "Amount:";
            // 
            // txtPaySlip
            // 
            this.txtPaySlip.CausesValidation = false;
            this.txtPaySlip.IsSendTabOnEnter = true;
            this.txtPaySlip.Location = new System.Drawing.Point(141, 12);
            this.txtPaySlip.Name = "txtPaySlip";
            this.txtPaySlip.Size = new System.Drawing.Size(141, 20);
            this.txtPaySlip.TabIndex = 1;
            this.txtPaySlip.TabStop = false;
            // 
            // txtAmount
            // 
            this.txtAmount.DecimalPlaces = 2;
            this.txtAmount.IsSendTabOnEnter = true;
            this.txtAmount.Location = new System.Drawing.Point(141, 222);
            this.txtAmount.MaxLength = 13;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 7;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(141, 42);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 2;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtxtAccountNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtAccountNo_KeyPress);
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
            this.cboCurrency.Location = new System.Drawing.Point(141, 73);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 3;
            // 
            // cboOtherBank
            // 
            this.cboOtherBank.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboOtherBank.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboOtherBank.DropDownHeight = 200;
            this.cboOtherBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOtherBank.FormattingEnabled = true;
            this.cboOtherBank.IntegralHeight = false;
            this.cboOtherBank.IsSendTabOnEnter = true;
            this.cboOtherBank.Location = new System.Drawing.Point(141, 170);
            this.cboOtherBank.Name = "cboOtherBank";
            this.cboOtherBank.Size = new System.Drawing.Size(141, 21);
            this.cboOtherBank.TabIndex = 6;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.CausesValidation = false;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(592, 31);
            this.tsbCRUD.TabIndex = 10;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblReceiptAccountNo
            // 
            this.lblReceiptAccountNo.AutoSize = true;
            this.lblReceiptAccountNo.Location = new System.Drawing.Point(13, 143);
            this.lblReceiptAccountNo.Name = "lblReceiptAccountNo";
            this.lblReceiptAccountNo.Size = new System.Drawing.Size(107, 13);
            this.lblReceiptAccountNo.TabIndex = 0;
            this.lblReceiptAccountNo.Text = "Receipt Account No:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mtxtReceiptAccountNo);
            this.groupBox1.Controls.Add(this.lblAmt);
            this.groupBox1.Controls.Add(this.txtChequeNo);
            this.groupBox1.Controls.Add(this.lblBankDescription);
            this.groupBox1.Controls.Add(this.lblOtherBank);
            this.groupBox1.Controls.Add(this.lblReceiptAccountNo);
            this.groupBox1.Controls.Add(this.txtPaySlip);
            this.groupBox1.Controls.Add(this.mtxtAccountNo);
            this.groupBox1.Controls.Add(this.cboCurrency);
            this.groupBox1.Controls.Add(this.cboOtherBank);
            this.groupBox1.Controls.Add(this.gbName);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Location = new System.Drawing.Point(12, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(556, 252);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // mtxtReceiptAccountNo
            // 
            this.mtxtReceiptAccountNo.IsSendTabOnEnter = true;
            this.mtxtReceiptAccountNo.Location = new System.Drawing.Point(141, 140);
            this.mtxtReceiptAccountNo.Name = "mtxtReceiptAccountNo";
            this.mtxtReceiptAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtReceiptAccountNo.TabIndex = 5;
            this.mtxtReceiptAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtxtReceiptAccountNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtReceiptAccountNo_KeyPress);
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.IsSendTabOnEnter = true;
            this.txtChequeNo.Location = new System.Drawing.Point(142, 108);
            this.txtChequeNo.Mask = "999999999";
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(115, 20);
            this.txtChequeNo.TabIndex = 4;
            // 
            // lblBankDescription
            // 
            this.lblBankDescription.Location = new System.Drawing.Point(139, 196);
            this.lblBankDescription.Name = "lblBankDescription";
            this.lblBankDescription.Size = new System.Drawing.Size(387, 20);
            this.lblBankDescription.TabIndex = 58;
            this.lblBankDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TLMVEW00006
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 298);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.lblChequeNo);
            this.Controls.Add(this.lblCurrency);
            this.Controls.Add(this.lblAccountNo);
            this.Controls.Add(this.lblPayInSlipNo);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TLMVEW00006";
            this.Load += new System.EventHandler(this.TLMVEW00006_Load);
            this.Move += new System.EventHandler(this.TLMVEW00006_Move);
            this.gbName.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbName;
        private Ace.Windows.CXClient.Controls.CXC0003 lblPayInSlipNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Ace.Windows.CXClient.Controls.CXC0003 lblOtherBank;
        private Ace.Windows.CXClient.Controls.CXC0003 lblChequeNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblAmt;
        private Ace.Windows.CXClient.Controls.CXC0006 txtPaySlip;
        private Ace.Windows.CXClient.Controls.CXC0004 txtAmount;
        private Ace.Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Ace.Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Ace.Windows.CXClient.Controls.CXC0002 cboOtherBank;
        private Ace.Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Ace.Windows.CXClient.Controls.CXC0003 lblReceiptAccountNo;
        private System.Windows.Forms.ListView lvName;
        private System.Windows.Forms.GroupBox groupBox1;
        private Windows.CXClient.Controls.CXC0003 lblBankDescription;
        private Windows.CXClient.Controls.CXC0006 txtChequeNo;
        private Windows.CXClient.Controls.CXC0006 mtxtReceiptAccountNo;
    }
}