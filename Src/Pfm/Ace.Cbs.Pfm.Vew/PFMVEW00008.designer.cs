namespace Ace.Cbs.Pfm.Vew
{
    partial class frmPFMVEW00008
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPFMVEW00008));
            this.txtReference = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblReference = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblWithdrawal = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblDeposit = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblBalance = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblDate2 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.tlspCommon = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.mtxtWithdrawl = new Ace.Windows.CXClient.Controls.CXC0004();
            this.mtxtDeposit = new Ace.Windows.CXClient.Controls.CXC0004();
            this.mtxtBalance = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lbltodayDate = new System.Windows.Forms.Label();
            this.dtpDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.SuspendLayout();
            // 
            // txtReference
            // 
            this.txtReference.IsSendTabOnEnter = true;
            this.txtReference.Location = new System.Drawing.Point(144, 122);
            this.txtReference.MaxLength = 6;
            this.txtReference.Name = "txtReference";
            this.txtReference.Size = new System.Drawing.Size(128, 20);
            this.txtReference.TabIndex = 3;
            this.txtReference.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReference_KeyPress);
            // 
            // lblReference
            // 
            this.lblReference.AutoSize = true;
            this.lblReference.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReference.ForeColor = System.Drawing.Color.Black;
            this.lblReference.Location = new System.Drawing.Point(144, 98);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(74, 20);
            this.lblReference.TabIndex = 84;
            this.lblReference.Text = "Reference";
            // 
            // lblWithdrawal
            // 
            this.lblWithdrawal.AutoSize = true;
            this.lblWithdrawal.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWithdrawal.ForeColor = System.Drawing.Color.Black;
            this.lblWithdrawal.Location = new System.Drawing.Point(278, 98);
            this.lblWithdrawal.Name = "lblWithdrawal";
            this.lblWithdrawal.Size = new System.Drawing.Size(80, 20);
            this.lblWithdrawal.TabIndex = 82;
            this.lblWithdrawal.Text = "Withdrawal";
            // 
            // lblDeposit
            // 
            this.lblDeposit.AutoSize = true;
            this.lblDeposit.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeposit.ForeColor = System.Drawing.Color.Black;
            this.lblDeposit.Location = new System.Drawing.Point(407, 98);
            this.lblDeposit.Name = "lblDeposit";
            this.lblDeposit.Size = new System.Drawing.Size(57, 20);
            this.lblDeposit.TabIndex = 80;
            this.lblDeposit.Text = "Deposit";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.ForeColor = System.Drawing.Color.Black;
            this.lblBalance.Location = new System.Drawing.Point(536, 98);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(57, 20);
            this.lblBalance.TabIndex = 79;
            this.lblBalance.Text = "Balance";
            // 
            // lblDate2
            // 
            this.lblDate2.AutoSize = true;
            this.lblDate2.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate2.ForeColor = System.Drawing.Color.Black;
            this.lblDate2.Location = new System.Drawing.Point(20, 98);
            this.lblDate2.Name = "lblDate2";
            this.lblDate2.Size = new System.Drawing.Size(39, 20);
            this.lblDate2.TabIndex = 83;
            this.lblDate2.Text = "Date";
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(22, 59);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(73, 13);
            this.lblAccountNo.TabIndex = 81;
            this.lblAccountNo.Text = "Account No. :";
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.HidePromptOnLeave = true;
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(98, 55);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.ShortcutsEnabled = false;
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 1;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // tlspCommon
            // 
            this.tlspCommon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tlspCommon.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.tlspCommon.BackColor = System.Drawing.Color.PowderBlue;
            this.tlspCommon.CausesValidation = false;
            this.tlspCommon.Location = new System.Drawing.Point(-1, 0);
            this.tlspCommon.Name = "tlspCommon";
            this.tlspCommon.PrintButtonCauseValidation = true;
            this.tlspCommon.Size = new System.Drawing.Size(683, 30);
            this.tlspCommon.TabIndex = 7;
            this.tlspCommon.CancelButtonClick += new System.EventHandler(this.tlspCommon_CancelButtonClick);
            this.tlspCommon.PrintButtonClick += new System.EventHandler(this.tlspCommon_PrintButtonClick);
            this.tlspCommon.ExitButtonClick += new System.EventHandler(this.tlspCommon_ExitButtonClick);
            // 
            // mtxtWithdrawl
            // 
            this.mtxtWithdrawl.DecimalPlaces = 2;
            this.mtxtWithdrawl.IsSendTabOnEnter = true;
            this.mtxtWithdrawl.IsThousandSeperator = true;
            this.mtxtWithdrawl.IsUseFloatingPoint = true;
            this.mtxtWithdrawl.Location = new System.Drawing.Point(278, 122);
            this.mtxtWithdrawl.MaxLength = 15;
            this.mtxtWithdrawl.Name = "mtxtWithdrawl";
            this.mtxtWithdrawl.Size = new System.Drawing.Size(123, 20);
            this.mtxtWithdrawl.TabIndex = 4;
            this.mtxtWithdrawl.Text = "0.00";
            this.mtxtWithdrawl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mtxtWithdrawl.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.mtxtWithdrawl.Validated += new System.EventHandler(this.mtxtWithdrawl_Validated);
            // 
            // mtxtDeposit
            // 
            this.mtxtDeposit.DecimalPlaces = 2;
            this.mtxtDeposit.IsSendTabOnEnter = true;
            this.mtxtDeposit.IsThousandSeperator = true;
            this.mtxtDeposit.IsUseFloatingPoint = true;
            this.mtxtDeposit.Location = new System.Drawing.Point(407, 122);
            this.mtxtDeposit.MaxLength = 15;
            this.mtxtDeposit.Name = "mtxtDeposit";
            this.mtxtDeposit.Size = new System.Drawing.Size(123, 20);
            this.mtxtDeposit.TabIndex = 5;
            this.mtxtDeposit.Text = "0.00";
            this.mtxtDeposit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mtxtDeposit.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.mtxtDeposit.Validated += new System.EventHandler(this.mtxtDeposit_Validated);
            // 
            // mtxtBalance
            // 
            this.mtxtBalance.DecimalPlaces = 2;
            this.mtxtBalance.IsSendTabOnEnter = true;
            this.mtxtBalance.IsThousandSeperator = true;
            this.mtxtBalance.IsUseFloatingPoint = true;
            this.mtxtBalance.Location = new System.Drawing.Point(536, 122);
            this.mtxtBalance.MaxLength = 18;
            this.mtxtBalance.Name = "mtxtBalance";
            this.mtxtBalance.Size = new System.Drawing.Size(123, 20);
            this.mtxtBalance.TabIndex = 6;
            this.mtxtBalance.Text = "0.00";
            this.mtxtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mtxtBalance.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lbltodayDate
            // 
            this.lbltodayDate.AutoSize = true;
            this.lbltodayDate.Enabled = false;
            this.lbltodayDate.Location = new System.Drawing.Point(735, 37);
            this.lbltodayDate.Name = "lbltodayDate";
            this.lbltodayDate.Size = new System.Drawing.Size(0, 13);
            this.lbltodayDate.TabIndex = 85;
            // 
            // dtpDate
            // 
            this.dtpDate.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dtpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.IsSendTabOnEnter = true;
            this.dtpDate.Location = new System.Drawing.Point(23, 122);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpDate.Size = new System.Drawing.Size(115, 20);
            this.dtpDate.TabIndex = 86;
            this.dtpDate.Value = new System.DateTime(2014, 1, 8, 0, 0, 0, 0);
            // 
            // frmPFMVEW00008
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(680, 174);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lbltodayDate);
            this.Controls.Add(this.mtxtBalance);
            this.Controls.Add(this.mtxtDeposit);
            this.Controls.Add(this.mtxtWithdrawl);
            this.Controls.Add(this.tlspCommon);
            this.Controls.Add(this.txtReference);
            this.Controls.Add(this.lblReference);
            this.Controls.Add(this.lblWithdrawal);
            this.Controls.Add(this.lblDeposit);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.lblDate2);
            this.Controls.Add(this.lblAccountNo);
            this.Controls.Add(this.mtxtAccountNo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPFMVEW00008";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Passbook Transaction Print Entry";
            this.Load += new System.EventHandler(this.frmPFMVEW00008_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ace.Windows.CXClient.Controls.CXC0001 txtReference;
        private Ace.Windows.CXClient.Controls.CXC0003 lblReference;
        private Ace.Windows.CXClient.Controls.CXC0003 lblWithdrawal;
        private Ace.Windows.CXClient.Controls.CXC0003 lblDeposit;
        private Ace.Windows.CXClient.Controls.CXC0003 lblBalance;
        private Ace.Windows.CXClient.Controls.CXC0003 lblDate2;
        private Ace.Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Ace.Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Ace.Windows.CXClient.Controls.CXCLIC001 tlspCommon;
        private Ace.Windows.CXClient.Controls.CXC0004 mtxtWithdrawl;
        private Ace.Windows.CXClient.Controls.CXC0004 mtxtDeposit;
        private Ace.Windows.CXClient.Controls.CXC0004 mtxtBalance;
        private System.Windows.Forms.Label lbltodayDate;
        private Windows.CXClient.Controls.CXC0005 dtpDate;
    }
}