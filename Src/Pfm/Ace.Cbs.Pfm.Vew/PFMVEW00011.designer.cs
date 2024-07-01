namespace Ace.Cbs.Pfm.Vew
{
    partial class frmPFMVEW00011
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPFMVEW00011));
            this.gpNames = new System.Windows.Forms.GroupBox();
            this.lstCustomer = new Ace.Windows.CXClient.Controls.CXC0011();
            this.cxcliC0011 = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ntxtCharges = new Ace.Windows.CXClient.Controls.CXC0004();
            this.ntxtNetBalance = new Ace.Windows.CXClient.Controls.CXC0004();
            this.ntxtBalance = new Ace.Windows.CXClient.Controls.CXC0004();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblCharges = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblNetBalance = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblBalance = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtCloseDate = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtChequeNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblChequeNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCloseDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gpNames.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpNames
            // 
            this.gpNames.Controls.Add(this.lstCustomer);
            this.gpNames.Location = new System.Drawing.Point(281, 37);
            this.gpNames.Name = "gpNames";
            this.gpNames.Size = new System.Drawing.Size(209, 194);
            this.gpNames.TabIndex = 1000;
            this.gpNames.TabStop = false;
            this.gpNames.Text = "Name(s)";
            // 
            // lstCustomer
            // 
            this.lstCustomer.Enabled = false;
            this.lstCustomer.FormattingEnabled = true;
            this.lstCustomer.Location = new System.Drawing.Point(6, 19);
            this.lstCustomer.Name = "lstCustomer";
            this.lstCustomer.Size = new System.Drawing.Size(197, 160);
            this.lstCustomer.TabIndex = 0;
            // 
            // cxcliC0011
            // 
            this.cxcliC0011.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cxcliC0011.BackColor = System.Drawing.Color.PowderBlue;
            this.cxcliC0011.Location = new System.Drawing.Point(0, 0);
            this.cxcliC0011.Name = "cxcliC0011";
            this.cxcliC0011.PrintButtonCauseValidation = true;
            this.cxcliC0011.Size = new System.Drawing.Size(518, 30);
            this.cxcliC0011.TabIndex = 4;
            this.cxcliC0011.SaveButtonClick += new System.EventHandler(this.cxcliC0011_SaveButtonClick);
            this.cxcliC0011.CancelButtonClick += new System.EventHandler(this.cxcliC0011_CancelButtonClick);
            this.cxcliC0011.ExitButtonClick += new System.EventHandler(this.cxcliC0011_ExitButtonClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ntxtCharges);
            this.groupBox1.Controls.Add(this.ntxtNetBalance);
            this.groupBox1.Controls.Add(this.ntxtBalance);
            this.groupBox1.Controls.Add(this.mtxtAccountNo);
            this.groupBox1.Controls.Add(this.lblCharges);
            this.groupBox1.Controls.Add(this.lblNetBalance);
            this.groupBox1.Controls.Add(this.lblBalance);
            this.groupBox1.Controls.Add(this.txtCloseDate);
            this.groupBox1.Controls.Add(this.txtChequeNo);
            this.groupBox1.Controls.Add(this.lblChequeNo);
            this.groupBox1.Controls.Add(this.lblCloseDate);
            this.groupBox1.Controls.Add(this.lblAccountNo);
            this.groupBox1.Location = new System.Drawing.Point(12, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 194);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // ntxtCharges
            // 
            this.ntxtCharges.DecimalPlaces = 2;
            this.ntxtCharges.IsSendTabOnEnter = true;
            this.ntxtCharges.IsUseFloatingPoint = true;
            this.ntxtCharges.Location = new System.Drawing.Point(107, 150);
            this.ntxtCharges.MaxLength = 18;
            this.ntxtCharges.Name = "ntxtCharges";
            this.ntxtCharges.Size = new System.Drawing.Size(111, 20);
            this.ntxtCharges.TabIndex = 3;
            this.ntxtCharges.Text = "0.00";
            this.ntxtCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntxtCharges.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // ntxtNetBalance
            // 
            this.ntxtNetBalance.BackColor = System.Drawing.SystemColors.Window;
            this.ntxtNetBalance.DecimalPlaces = 2;
            this.ntxtNetBalance.IsSendTabOnEnter = true;
            this.ntxtNetBalance.IsUseFloatingPoint = true;
            this.ntxtNetBalance.Location = new System.Drawing.Point(107, 124);
            this.ntxtNetBalance.MaxLength = 18;
            this.ntxtNetBalance.Name = "ntxtNetBalance";
            this.ntxtNetBalance.ReadOnly = true;
            this.ntxtNetBalance.Size = new System.Drawing.Size(111, 20);
            this.ntxtNetBalance.TabIndex = 41;
            this.ntxtNetBalance.TabStop = false;
            this.ntxtNetBalance.Text = "0.00";
            this.ntxtNetBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntxtNetBalance.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // ntxtBalance
            // 
            this.ntxtBalance.BackColor = System.Drawing.SystemColors.Window;
            this.ntxtBalance.DecimalPlaces = 2;
            this.ntxtBalance.IsSendTabOnEnter = true;
            this.ntxtBalance.IsUseFloatingPoint = true;
            this.ntxtBalance.Location = new System.Drawing.Point(107, 98);
            this.ntxtBalance.MaxLength = 18;
            this.ntxtBalance.Name = "ntxtBalance";
            this.ntxtBalance.ReadOnly = true;
            this.ntxtBalance.Size = new System.Drawing.Size(111, 20);
            this.ntxtBalance.TabIndex = 40;
            this.ntxtBalance.TabStop = false;
            this.ntxtBalance.Text = "0.00";
            this.ntxtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntxtBalance.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.HidePromptOnLeave = true;
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(107, 20);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 1;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblCharges
            // 
            this.lblCharges.AutoSize = true;
            this.lblCharges.Location = new System.Drawing.Point(16, 153);
            this.lblCharges.Name = "lblCharges";
            this.lblCharges.Size = new System.Drawing.Size(52, 13);
            this.lblCharges.TabIndex = 35;
            this.lblCharges.Text = "Charges :";
            // 
            // lblNetBalance
            // 
            this.lblNetBalance.AutoSize = true;
            this.lblNetBalance.Location = new System.Drawing.Point(16, 126);
            this.lblNetBalance.Name = "lblNetBalance";
            this.lblNetBalance.Size = new System.Drawing.Size(72, 13);
            this.lblNetBalance.TabIndex = 39;
            this.lblNetBalance.Text = "Net Balance :";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(16, 101);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(52, 13);
            this.lblBalance.TabIndex = 36;
            this.lblBalance.Text = "Balance :";
            // 
            // txtCloseDate
            // 
            this.txtCloseDate.BackColor = System.Drawing.SystemColors.Window;
            this.txtCloseDate.Enabled = false;
            this.txtCloseDate.IsSendTabOnEnter = true;
            this.txtCloseDate.Location = new System.Drawing.Point(107, 46);
            this.txtCloseDate.Name = "txtCloseDate";
            this.txtCloseDate.ReadOnly = true;
            this.txtCloseDate.Size = new System.Drawing.Size(117, 20);
            this.txtCloseDate.TabIndex = 42;
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.IsSendTabOnEnter = true;
            this.txtChequeNo.Location = new System.Drawing.Point(107, 72);
            this.txtChequeNo.MaxLength = 8;
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(58, 20);
            this.txtChequeNo.TabIndex = 2;
            this.txtChequeNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblChequeNo
            // 
            this.lblChequeNo.AutoSize = true;
            this.lblChequeNo.Location = new System.Drawing.Point(16, 75);
            this.lblChequeNo.Name = "lblChequeNo";
            this.lblChequeNo.Size = new System.Drawing.Size(70, 13);
            this.lblChequeNo.TabIndex = 38;
            this.lblChequeNo.Text = "Cheque No. :";
            // 
            // lblCloseDate
            // 
            this.lblCloseDate.AutoSize = true;
            this.lblCloseDate.Location = new System.Drawing.Point(16, 48);
            this.lblCloseDate.Name = "lblCloseDate";
            this.lblCloseDate.Size = new System.Drawing.Size(65, 13);
            this.lblCloseDate.TabIndex = 37;
            this.lblCloseDate.Text = "Close Date :";
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(16, 23);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(73, 13);
            this.lblAccountNo.TabIndex = 34;
            this.lblAccountNo.Text = "Account No. :";
            // 
            // frmPFMVEW00011
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 243);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cxcliC0011);
            this.Controls.Add(this.gpNames);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPFMVEW00011";
            this.Text = "Current Account Close Entry";
            this.Load += new System.EventHandler(this.frmPFMVEW00011_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPFMVEW00011_KeyDown);
            this.Move += new System.EventHandler(this.frmPFMVEW00011_Move);
            this.gpNames.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpNames;
        private Ace.Windows.CXClient.Controls.CXC0011 lstCustomer;
        private Windows.CXClient.Controls.CXCLIC001 cxcliC0011;
        private System.Windows.Forms.GroupBox groupBox1;
        private Windows.CXClient.Controls.CXC0004 ntxtCharges;
        private Windows.CXClient.Controls.CXC0004 ntxtNetBalance;
        private Windows.CXClient.Controls.CXC0004 ntxtBalance;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblCharges;
        private Windows.CXClient.Controls.CXC0003 lblNetBalance;
        private Windows.CXClient.Controls.CXC0003 lblBalance;
        private Windows.CXClient.Controls.CXC0001 txtCloseDate;
        private Windows.CXClient.Controls.CXC0001 txtChequeNo;
        private Windows.CXClient.Controls.CXC0003 lblChequeNo;
        private Windows.CXClient.Controls.CXC0003 lblCloseDate;
        private Windows.CXClient.Controls.CXC0003 lblAccountNo;
    }
}