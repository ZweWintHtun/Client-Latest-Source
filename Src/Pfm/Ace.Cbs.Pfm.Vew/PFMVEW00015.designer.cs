namespace Ace.Cbs.Pfm.Vew
{
    partial class frmPFMVEW00015
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPFMVEW00015));
            this.txtStartChequeNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblEndChequeNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtEndChequeNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblChequeBookNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblStartChequeNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblBranchNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtChequeBookNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tlspCommon = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.txtBranchNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.SuspendLayout();
            // 
            // txtStartChequeNo
            // 
            this.txtStartChequeNo.IsSendTabOnEnter = true;
            this.txtStartChequeNo.Location = new System.Drawing.Point(128, 115);
            this.txtStartChequeNo.MaxLength = 8;
            this.txtStartChequeNo.Name = "txtStartChequeNo";
            this.txtStartChequeNo.Size = new System.Drawing.Size(58, 20);
            this.txtStartChequeNo.TabIndex = 3;
            this.txtStartChequeNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStartChequeNo_KeyPress);
            this.txtStartChequeNo.Validated += new System.EventHandler(this.txtStartChequeNo_Validated);
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.HidePromptOnLeave = true;
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(128, 37);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 0;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblEndChequeNo
            // 
            this.lblEndChequeNo.AutoSize = true;
            this.lblEndChequeNo.Location = new System.Drawing.Point(26, 144);
            this.lblEndChequeNo.Name = "lblEndChequeNo";
            this.lblEndChequeNo.Size = new System.Drawing.Size(89, 13);
            this.lblEndChequeNo.TabIndex = 14;
            this.lblEndChequeNo.Text = "End Cheque No :";
            // 
            // txtEndChequeNo
            // 
            this.txtEndChequeNo.IsSendTabOnEnter = true;
            this.txtEndChequeNo.Location = new System.Drawing.Point(128, 141);
            this.txtEndChequeNo.MaxLength = 8;
            this.txtEndChequeNo.Name = "txtEndChequeNo";
            this.txtEndChequeNo.Size = new System.Drawing.Size(58, 20);
            this.txtEndChequeNo.TabIndex = 4;
            this.txtEndChequeNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEndChequeNo_KeyPress);
            this.txtEndChequeNo.Validated += new System.EventHandler(this.txtEndChequeNo_Validated);
            // 
            // lblChequeBookNo
            // 
            this.lblChequeBookNo.AutoSize = true;
            this.lblChequeBookNo.Location = new System.Drawing.Point(26, 66);
            this.lblChequeBookNo.Name = "lblChequeBookNo";
            this.lblChequeBookNo.Size = new System.Drawing.Size(89, 13);
            this.lblChequeBookNo.TabIndex = 16;
            this.lblChequeBookNo.Text = "Check Book No :";
            // 
            // lblStartChequeNo
            // 
            this.lblStartChequeNo.AutoSize = true;
            this.lblStartChequeNo.Location = new System.Drawing.Point(26, 118);
            this.lblStartChequeNo.Name = "lblStartChequeNo";
            this.lblStartChequeNo.Size = new System.Drawing.Size(92, 13);
            this.lblStartChequeNo.TabIndex = 12;
            this.lblStartChequeNo.Text = "Start Cheque No :";
            // 
            // lblBranchNo
            // 
            this.lblBranchNo.AutoSize = true;
            this.lblBranchNo.Location = new System.Drawing.Point(26, 92);
            this.lblBranchNo.Name = "lblBranchNo";
            this.lblBranchNo.Size = new System.Drawing.Size(64, 13);
            this.lblBranchNo.TabIndex = 13;
            this.lblBranchNo.Text = "Branch No :";
            // 
            // txtChequeBookNo
            // 
            this.txtChequeBookNo.IsSendTabOnEnter = true;
            this.txtChequeBookNo.Location = new System.Drawing.Point(128, 63);
            this.txtChequeBookNo.MaxLength = 7;
            this.txtChequeBookNo.Name = "txtChequeBookNo";
            this.txtChequeBookNo.Size = new System.Drawing.Size(58, 20);
            this.txtChequeBookNo.TabIndex = 1;
            this.txtChequeBookNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChequeBookNo_KeyPress);
            this.txtChequeBookNo.Validated += new System.EventHandler(this.txtChequeBookNo_Validated);
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(26, 40);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(73, 13);
            this.lblAccountNo.TabIndex = 11;
            this.lblAccountNo.Text = "Account No. :";
            // 
            // tlspCommon
            // 
            this.tlspCommon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tlspCommon.BackColor = System.Drawing.Color.PowderBlue;
            this.tlspCommon.Location = new System.Drawing.Point(-2, -2);
            this.tlspCommon.Name = "tlspCommon";
            this.tlspCommon.PrintButtonCauseValidation = true;
            this.tlspCommon.Size = new System.Drawing.Size(497, 30);
            this.tlspCommon.TabIndex = 5;
            this.tlspCommon.CancelButtonClick += new System.EventHandler(this.tlspCommon_CancelButtonClick);
            this.tlspCommon.PrintButtonClick += new System.EventHandler(this.tlspCommon_PrintButtonClick);
            this.tlspCommon.ExitButtonClick += new System.EventHandler(this.tlspCommon_ExitButtonClick);
            // 
            // txtBranchNo
            // 
            this.txtBranchNo.HidePromptOnLeave = true;
            this.txtBranchNo.IsSendTabOnEnter = true;
            this.txtBranchNo.Location = new System.Drawing.Point(128, 89);
            this.txtBranchNo.Mask = "999-999";
            this.txtBranchNo.Name = "txtBranchNo";
            this.txtBranchNo.Size = new System.Drawing.Size(100, 20);
            this.txtBranchNo.TabIndex = 2;
            this.txtBranchNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // frmPFMVEW00015
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 185);
            this.Controls.Add(this.txtBranchNo);
            this.Controls.Add(this.tlspCommon);
            this.Controls.Add(this.txtStartChequeNo);
            this.Controls.Add(this.mtxtAccountNo);
            this.Controls.Add(this.lblEndChequeNo);
            this.Controls.Add(this.txtEndChequeNo);
            this.Controls.Add(this.lblChequeBookNo);
            this.Controls.Add(this.lblStartChequeNo);
            this.Controls.Add(this.lblBranchNo);
            this.Controls.Add(this.txtChequeBookNo);
            this.Controls.Add(this.lblAccountNo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPFMVEW00015";
            this.Text = "Cheque Printing";
            this.Load += new System.EventHandler(this.frmPFMVEW00015_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ace.Windows.CXClient.Controls.CXC0001 txtStartChequeNo;
        private Ace.Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblEndChequeNo;
        private Ace.Windows.CXClient.Controls.CXC0001 txtEndChequeNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblChequeBookNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblStartChequeNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblBranchNo;
        private Ace.Windows.CXClient.Controls.CXC0001 txtChequeBookNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Windows.CXClient.Controls.CXCLIC001 tlspCommon;
        private Ace.Windows.CXClient.Controls.CXC0006 txtBranchNo;
    }
}