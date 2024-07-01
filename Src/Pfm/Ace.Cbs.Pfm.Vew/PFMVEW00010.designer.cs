namespace Ace.Cbs.Pfm.Vew
{
    partial class frmPFMVEW00010
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPFMVEW00010));
            this.gpNames = new System.Windows.Forms.GroupBox();
            this.lstCustomer = new Ace.Windows.CXClient.Controls.CXC0011();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtCloseDate = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtNewBalance = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtTotalInterestAmount = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtCharges = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtTax = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtBalance = new Ace.Windows.CXClient.Controls.CXC0001();
            this.gpInterestAmount = new System.Windows.Forms.GroupBox();
            this.txtAfterTax = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtBeforeTax = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblNewBalance = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblTotalInterestAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCharges = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblTax = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblBalance = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAfterTax = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblBeforeTax = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCloseDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxcliC0012 = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gpNames.SuspendLayout();
            this.gpInterestAmount.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpNames
            // 
            this.gpNames.Controls.Add(this.lstCustomer);
            this.gpNames.Location = new System.Drawing.Point(481, 40);
            this.gpNames.Name = "gpNames";
            this.gpNames.Size = new System.Drawing.Size(205, 213);
            this.gpNames.TabIndex = 16;
            this.gpNames.TabStop = false;
            this.gpNames.Text = "Name(s)";
            // 
            // lstCustomer
            // 
            this.lstCustomer.FormattingEnabled = true;
            this.lstCustomer.Location = new System.Drawing.Point(6, 20);
            this.lstCustomer.Name = "lstCustomer";
            this.lstCustomer.Size = new System.Drawing.Size(184, 186);
            this.lstCustomer.TabIndex = 0;
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.HidePromptOnLeave = true;
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(105, 44);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 11;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtCloseDate
            // 
            this.txtCloseDate.BackColor = System.Drawing.SystemColors.Window;
            this.txtCloseDate.Enabled = false;
            this.txtCloseDate.IsSendTabOnEnter = true;
            this.txtCloseDate.Location = new System.Drawing.Point(105, 70);
            this.txtCloseDate.Name = "txtCloseDate";
            this.txtCloseDate.ReadOnly = true;
            this.txtCloseDate.Size = new System.Drawing.Size(100, 20);
            this.txtCloseDate.TabIndex = 14;
            // 
            // txtNewBalance
            // 
            this.txtNewBalance.BackColor = System.Drawing.SystemColors.Window;
            this.txtNewBalance.IsSendTabOnEnter = true;
            this.txtNewBalance.Location = new System.Drawing.Point(340, 106);
            this.txtNewBalance.MaxLength = 18;
            this.txtNewBalance.Name = "txtNewBalance";
            this.txtNewBalance.ReadOnly = true;
            this.txtNewBalance.Size = new System.Drawing.Size(111, 20);
            this.txtNewBalance.TabIndex = 8;
            this.txtNewBalance.Text = ".00";
            this.txtNewBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalInterestAmount
            // 
            this.txtTotalInterestAmount.BackColor = System.Drawing.SystemColors.Window;
            this.txtTotalInterestAmount.IsSendTabOnEnter = true;
            this.txtTotalInterestAmount.Location = new System.Drawing.Point(340, 80);
            this.txtTotalInterestAmount.MaxLength = 18;
            this.txtTotalInterestAmount.Name = "txtTotalInterestAmount";
            this.txtTotalInterestAmount.ReadOnly = true;
            this.txtTotalInterestAmount.Size = new System.Drawing.Size(111, 20);
            this.txtTotalInterestAmount.TabIndex = 7;
            this.txtTotalInterestAmount.Text = ".00";
            this.txtTotalInterestAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCharges
            // 
            this.txtCharges.BackColor = System.Drawing.SystemColors.Window;
            this.txtCharges.IsSendTabOnEnter = true;
            this.txtCharges.Location = new System.Drawing.Point(340, 54);
            this.txtCharges.MaxLength = 18;
            this.txtCharges.Name = "txtCharges";
            this.txtCharges.ReadOnly = true;
            this.txtCharges.Size = new System.Drawing.Size(111, 20);
            this.txtCharges.TabIndex = 6;
            this.txtCharges.Text = ".00";
            this.txtCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTax
            // 
            this.txtTax.BackColor = System.Drawing.SystemColors.Window;
            this.txtTax.IsSendTabOnEnter = true;
            this.txtTax.Location = new System.Drawing.Point(340, 28);
            this.txtTax.MaxLength = 18;
            this.txtTax.Name = "txtTax";
            this.txtTax.ReadOnly = true;
            this.txtTax.Size = new System.Drawing.Size(111, 20);
            this.txtTax.TabIndex = 5;
            this.txtTax.Text = ".00";
            this.txtTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBalance
            // 
            this.txtBalance.BackColor = System.Drawing.SystemColors.Window;
            this.txtBalance.IsSendTabOnEnter = true;
            this.txtBalance.Location = new System.Drawing.Point(82, 80);
            this.txtBalance.MaxLength = 18;
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.Size = new System.Drawing.Size(111, 20);
            this.txtBalance.TabIndex = 4;
            this.txtBalance.Text = ".00";
            this.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gpInterestAmount
            // 
            this.gpInterestAmount.Controls.Add(this.txtNewBalance);
            this.gpInterestAmount.Controls.Add(this.txtTotalInterestAmount);
            this.gpInterestAmount.Controls.Add(this.txtCharges);
            this.gpInterestAmount.Controls.Add(this.txtTax);
            this.gpInterestAmount.Controls.Add(this.txtBalance);
            this.gpInterestAmount.Controls.Add(this.txtAfterTax);
            this.gpInterestAmount.Controls.Add(this.txtBeforeTax);
            this.gpInterestAmount.Controls.Add(this.lblNewBalance);
            this.gpInterestAmount.Controls.Add(this.lblTotalInterestAmount);
            this.gpInterestAmount.Controls.Add(this.lblCharges);
            this.gpInterestAmount.Controls.Add(this.lblTax);
            this.gpInterestAmount.Controls.Add(this.lblBalance);
            this.gpInterestAmount.Controls.Add(this.lblAfterTax);
            this.gpInterestAmount.Controls.Add(this.lblBeforeTax);
            this.gpInterestAmount.Location = new System.Drawing.Point(11, 105);
            this.gpInterestAmount.Name = "gpInterestAmount";
            this.gpInterestAmount.Size = new System.Drawing.Size(465, 148);
            this.gpInterestAmount.TabIndex = 15;
            this.gpInterestAmount.TabStop = false;
            this.gpInterestAmount.Text = "Interest Amount";
            // 
            // txtAfterTax
            // 
            this.txtAfterTax.BackColor = System.Drawing.SystemColors.Window;
            this.txtAfterTax.IsSendTabOnEnter = true;
            this.txtAfterTax.Location = new System.Drawing.Point(82, 54);
            this.txtAfterTax.MaxLength = 18;
            this.txtAfterTax.Name = "txtAfterTax";
            this.txtAfterTax.ReadOnly = true;
            this.txtAfterTax.Size = new System.Drawing.Size(111, 20);
            this.txtAfterTax.TabIndex = 3;
            this.txtAfterTax.Text = ".00";
            this.txtAfterTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBeforeTax
            // 
            this.txtBeforeTax.BackColor = System.Drawing.SystemColors.Window;
            this.txtBeforeTax.IsSendTabOnEnter = true;
            this.txtBeforeTax.Location = new System.Drawing.Point(82, 28);
            this.txtBeforeTax.MaxLength = 18;
            this.txtBeforeTax.Name = "txtBeforeTax";
            this.txtBeforeTax.ReadOnly = true;
            this.txtBeforeTax.Size = new System.Drawing.Size(111, 20);
            this.txtBeforeTax.TabIndex = 2;
            this.txtBeforeTax.Text = ".00";
            this.txtBeforeTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNewBalance
            // 
            this.lblNewBalance.AutoSize = true;
            this.lblNewBalance.Location = new System.Drawing.Point(223, 109);
            this.lblNewBalance.Name = "lblNewBalance";
            this.lblNewBalance.Size = new System.Drawing.Size(106, 13);
            this.lblNewBalance.TabIndex = 2;
            this.lblNewBalance.Text = "New Balance (Last) :";
            // 
            // lblTotalInterestAmount
            // 
            this.lblTotalInterestAmount.AutoSize = true;
            this.lblTotalInterestAmount.Location = new System.Drawing.Point(223, 83);
            this.lblTotalInterestAmount.Name = "lblTotalInterestAmount";
            this.lblTotalInterestAmount.Size = new System.Drawing.Size(114, 13);
            this.lblTotalInterestAmount.TabIndex = 2;
            this.lblTotalInterestAmount.Text = "Total Interest Amount :";
            // 
            // lblCharges
            // 
            this.lblCharges.AutoSize = true;
            this.lblCharges.Location = new System.Drawing.Point(223, 57);
            this.lblCharges.Name = "lblCharges";
            this.lblCharges.Size = new System.Drawing.Size(52, 13);
            this.lblCharges.TabIndex = 2;
            this.lblCharges.Text = "Charges :";
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.Location = new System.Drawing.Point(223, 31);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(31, 13);
            this.lblTax.TabIndex = 2;
            this.lblTax.Text = "Tax :";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(15, 83);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(52, 13);
            this.lblBalance.TabIndex = 2;
            this.lblBalance.Text = "Balance :";
            // 
            // lblAfterTax
            // 
            this.lblAfterTax.AutoSize = true;
            this.lblAfterTax.Location = new System.Drawing.Point(15, 57);
            this.lblAfterTax.Name = "lblAfterTax";
            this.lblAfterTax.Size = new System.Drawing.Size(53, 13);
            this.lblAfterTax.TabIndex = 2;
            this.lblAfterTax.Text = "AfterTax :";
            // 
            // lblBeforeTax
            // 
            this.lblBeforeTax.AutoSize = true;
            this.lblBeforeTax.Location = new System.Drawing.Point(15, 31);
            this.lblBeforeTax.Name = "lblBeforeTax";
            this.lblBeforeTax.Size = new System.Drawing.Size(65, 13);
            this.lblBeforeTax.TabIndex = 2;
            this.lblBeforeTax.Text = "Before Tax :";
            // 
            // lblCloseDate
            // 
            this.lblCloseDate.AutoSize = true;
            this.lblCloseDate.Location = new System.Drawing.Point(26, 73);
            this.lblCloseDate.Name = "lblCloseDate";
            this.lblCloseDate.Size = new System.Drawing.Size(65, 13);
            this.lblCloseDate.TabIndex = 12;
            this.lblCloseDate.Text = "Close Date :";
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(26, 47);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(73, 13);
            this.lblAccountNo.TabIndex = 13;
            this.lblAccountNo.Text = "Account No. :";
            // 
            // cxcliC0012
            // 
            this.cxcliC0012.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cxcliC0012.BackColor = System.Drawing.Color.PowderBlue;
            this.cxcliC0012.Location = new System.Drawing.Point(-1, 0);
            this.cxcliC0012.Name = "cxcliC0012";
            this.cxcliC0012.PrintButtonCauseValidation = true;
            this.cxcliC0012.Size = new System.Drawing.Size(698, 30);
            this.cxcliC0012.TabIndex = 17;
            this.cxcliC0012.SaveButtonClick += new System.EventHandler(this.cxcliC0012_SaveButtonClick);
            this.cxcliC0012.CancelButtonClick += new System.EventHandler(this.cxcliC0012_CancelButtonClick);
            this.cxcliC0012.ExitButtonClick += new System.EventHandler(this.cxcliC0012_ExitButtonClick);
            // 
            // frmPFMVEW00010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 265);
            this.Controls.Add(this.cxcliC0012);
            this.Controls.Add(this.gpNames);
            this.Controls.Add(this.mtxtAccountNo);
            this.Controls.Add(this.txtCloseDate);
            this.Controls.Add(this.gpInterestAmount);
            this.Controls.Add(this.lblCloseDate);
            this.Controls.Add(this.lblAccountNo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPFMVEW00010";
            this.Text = "Saving Account Close Entry";
            this.Load += new System.EventHandler(this.frmPFMVEW00010_Load);
            this.Move += new System.EventHandler(this.frmPFMVEW00010_Move);
            this.gpNames.ResumeLayout(false);
            this.gpInterestAmount.ResumeLayout(false);
            this.gpInterestAmount.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpNames;
        private Ace.Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Ace.Windows.CXClient.Controls.CXC0001 txtCloseDate;
        private Ace.Windows.CXClient.Controls.CXC0001 txtNewBalance;
        private Ace.Windows.CXClient.Controls.CXC0001 txtTotalInterestAmount;
        private Ace.Windows.CXClient.Controls.CXC0001 txtCharges;
        private Ace.Windows.CXClient.Controls.CXC0001 txtTax;
        private Ace.Windows.CXClient.Controls.CXC0001 txtBalance;
        private System.Windows.Forms.GroupBox gpInterestAmount;
        private Ace.Windows.CXClient.Controls.CXC0001 txtAfterTax;
        private Ace.Windows.CXClient.Controls.CXC0001 txtBeforeTax;
        private Ace.Windows.CXClient.Controls.CXC0003 lblNewBalance;
        private Ace.Windows.CXClient.Controls.CXC0003 lblTotalInterestAmount;
        private Ace.Windows.CXClient.Controls.CXC0003 lblCharges;
        private Ace.Windows.CXClient.Controls.CXC0003 lblTax;
        private Ace.Windows.CXClient.Controls.CXC0003 lblBalance;
        private Ace.Windows.CXClient.Controls.CXC0003 lblAfterTax;
        private Ace.Windows.CXClient.Controls.CXC0003 lblBeforeTax;
        private Ace.Windows.CXClient.Controls.CXC0003 lblCloseDate;
        private Ace.Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Ace.Windows.CXClient.Controls.CXC0011 lstCustomer;
        private Windows.CXClient.Controls.CXCLIC001 cxcliC0012;
    }
}