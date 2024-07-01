namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00014
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00014));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblLoanNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtLoanNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtAdvanceType = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblNPLUser = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtIntRateUnused = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblSanctionAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtIntRateUsed = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblIntRateUnused = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAdvanceType = new Ace.Windows.CXClient.Controls.CXC0003();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtSanctionAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblIntRateUsed = new Ace.Windows.CXClient.Controls.CXC0003();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, -1);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(483, 31);
            this.tsbCRUD.TabIndex = 2;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblLoanNo);
            this.groupBox1.Controls.Add(this.txtLoanNo);
            this.groupBox1.Controls.Add(this.txtAdvanceType);
            this.groupBox1.Controls.Add(this.lblNPLUser);
            this.groupBox1.Controls.Add(this.txtIntRateUnused);
            this.groupBox1.Controls.Add(this.lblAccountNo);
            this.groupBox1.Controls.Add(this.lblSanctionAmount);
            this.groupBox1.Controls.Add(this.txtIntRateUsed);
            this.groupBox1.Controls.Add(this.lblIntRateUnused);
            this.groupBox1.Controls.Add(this.lblAdvanceType);
            this.groupBox1.Controls.Add(this.mtxtAccountNo);
            this.groupBox1.Controls.Add(this.txtSanctionAmount);
            this.groupBox1.Controls.Add(this.lblIntRateUsed);
            this.groupBox1.Location = new System.Drawing.Point(7, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 222);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblLoanNo
            // 
            this.lblLoanNo.AutoSize = true;
            this.lblLoanNo.Location = new System.Drawing.Point(16, 24);
            this.lblLoanNo.Name = "lblLoanNo";
            this.lblLoanNo.Size = new System.Drawing.Size(57, 13);
            this.lblLoanNo.TabIndex = 41;
            this.lblLoanNo.Text = "Loan No. :";
            // 
            // txtLoanNo
            // 
            this.txtLoanNo.IsSendTabOnEnter = true;
            this.txtLoanNo.Location = new System.Drawing.Point(116, 21);
            this.txtLoanNo.MaxLength = 15;
            this.txtLoanNo.Name = "txtLoanNo";
            this.txtLoanNo.Size = new System.Drawing.Size(121, 20);
            this.txtLoanNo.TabIndex = 1;
            this.txtLoanNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLoanNo_KeyPress);
            // 
            // txtAdvanceType
            // 
            this.txtAdvanceType.Enabled = false;
            this.txtAdvanceType.IsSendTabOnEnter = true;
            this.txtAdvanceType.Location = new System.Drawing.Point(116, 73);
            this.txtAdvanceType.Name = "txtAdvanceType";
            this.txtAdvanceType.Size = new System.Drawing.Size(141, 20);
            this.txtAdvanceType.TabIndex = 42;
            // 
            // lblNPLUser
            // 
            this.lblNPLUser.AutoSize = true;
            this.lblNPLUser.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblNPLUser.Location = new System.Drawing.Point(16, 187);
            this.lblNPLUser.Name = "lblNPLUser";
            this.lblNPLUser.Size = new System.Drawing.Size(46, 13);
            this.lblNPLUser.TabIndex = 0;
            this.lblNPLUser.Tag = "0";
            this.lblNPLUser.Text = "UserID :";
            // 
            // txtIntRateUnused
            // 
            this.txtIntRateUnused.DecimalPlaces = 0;
            this.txtIntRateUnused.Enabled = false;
            this.txtIntRateUnused.IsSendTabOnEnter = true;
            this.txtIntRateUnused.Location = new System.Drawing.Point(116, 151);
            this.txtIntRateUnused.Name = "txtIntRateUnused";
            this.txtIntRateUnused.Size = new System.Drawing.Size(141, 20);
            this.txtIntRateUnused.TabIndex = 44;
            this.txtIntRateUnused.Text = "0.00";
            this.txtIntRateUnused.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIntRateUnused.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(16, 50);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(73, 13);
            this.lblAccountNo.TabIndex = 43;
            this.lblAccountNo.Text = "Account No. :";
            // 
            // lblSanctionAmount
            // 
            this.lblSanctionAmount.AutoSize = true;
            this.lblSanctionAmount.Location = new System.Drawing.Point(16, 102);
            this.lblSanctionAmount.Name = "lblSanctionAmount";
            this.lblSanctionAmount.Size = new System.Drawing.Size(94, 13);
            this.lblSanctionAmount.TabIndex = 40;
            this.lblSanctionAmount.Text = "Sanction Amount :";
            // 
            // txtIntRateUsed
            // 
            this.txtIntRateUsed.DecimalPlaces = 0;
            this.txtIntRateUsed.Enabled = false;
            this.txtIntRateUsed.IsSendTabOnEnter = true;
            this.txtIntRateUsed.Location = new System.Drawing.Point(116, 125);
            this.txtIntRateUsed.Name = "txtIntRateUsed";
            this.txtIntRateUsed.Size = new System.Drawing.Size(141, 20);
            this.txtIntRateUsed.TabIndex = 36;
            this.txtIntRateUsed.Text = "0.00";
            this.txtIntRateUsed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIntRateUsed.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblIntRateUnused
            // 
            this.lblIntRateUnused.AutoSize = true;
            this.lblIntRateUnused.Location = new System.Drawing.Point(16, 154);
            this.lblIntRateUnused.Name = "lblIntRateUnused";
            this.lblIntRateUnused.Size = new System.Drawing.Size(94, 13);
            this.lblIntRateUnused.TabIndex = 35;
            this.lblIntRateUnused.Text = "Int.Rate(Unused) :";
            // 
            // lblAdvanceType
            // 
            this.lblAdvanceType.AutoSize = true;
            this.lblAdvanceType.Location = new System.Drawing.Point(16, 76);
            this.lblAdvanceType.Name = "lblAdvanceType";
            this.lblAdvanceType.Size = new System.Drawing.Size(83, 13);
            this.lblAdvanceType.TabIndex = 34;
            this.lblAdvanceType.Text = "Advance Type :";
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.Enabled = false;
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(116, 47);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 39;
            // 
            // txtSanctionAmount
            // 
            this.txtSanctionAmount.DecimalPlaces = 0;
            this.txtSanctionAmount.Enabled = false;
            this.txtSanctionAmount.IsSendTabOnEnter = true;
            this.txtSanctionAmount.Location = new System.Drawing.Point(116, 99);
            this.txtSanctionAmount.Name = "txtSanctionAmount";
            this.txtSanctionAmount.Size = new System.Drawing.Size(141, 20);
            this.txtSanctionAmount.TabIndex = 38;
            this.txtSanctionAmount.Text = "0.00";
            this.txtSanctionAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSanctionAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblIntRateUsed
            // 
            this.lblIntRateUsed.AutoSize = true;
            this.lblIntRateUsed.Location = new System.Drawing.Point(16, 128);
            this.lblIntRateUsed.Name = "lblIntRateUsed";
            this.lblIntRateUsed.Size = new System.Drawing.Size(82, 13);
            this.lblIntRateUsed.TabIndex = 37;
            this.lblIntRateUsed.Text = "Int.Rate(Used) :";
            // 
            // LOMVEW00014
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(479, 267);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsbCRUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LOMVEW00014";
            this.Text = "Non_Performance Loan Entry";
            this.Load += new System.EventHandler(this.LOMVEW00014_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LOMVEW00014_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox groupBox1;
        private Windows.CXClient.Controls.CXC0003 lblLoanNo;
        private Windows.CXClient.Controls.CXC0001 txtLoanNo;
        private Windows.CXClient.Controls.CXC0001 txtAdvanceType;
        private Windows.CXClient.Controls.CXC0003 lblNPLUser;
        private Windows.CXClient.Controls.CXC0004 txtIntRateUnused;
        private Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblSanctionAmount;
        private Windows.CXClient.Controls.CXC0004 txtIntRateUsed;
        private Windows.CXClient.Controls.CXC0003 lblIntRateUnused;
        private Windows.CXClient.Controls.CXC0003 lblAdvanceType;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Windows.CXClient.Controls.CXC0004 txtSanctionAmount;
        private Windows.CXClient.Controls.CXC0003 lblIntRateUsed;
    }
}