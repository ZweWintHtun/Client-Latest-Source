namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00104
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00104));
            this.gbRepayment = new System.Windows.Forms.GroupBox();
            this.txtTotalAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtPenalties = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtInterest = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtRepaymentAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtLoanNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtOutstanding = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtAcctNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblRepaymentAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblVrNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblRepaymentNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblTotalOutstanding = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gbRepayment.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbRepayment
            // 
            this.gbRepayment.Controls.Add(this.txtTotalAmount);
            this.gbRepayment.Controls.Add(this.txtPenalties);
            this.gbRepayment.Controls.Add(this.txtInterest);
            this.gbRepayment.Controls.Add(this.txtRepaymentAmount);
            this.gbRepayment.Controls.Add(this.txtLoanNo);
            this.gbRepayment.Controls.Add(this.txtOutstanding);
            this.gbRepayment.Controls.Add(this.txtAcctNo);
            this.gbRepayment.Controls.Add(this.cxC00032);
            this.gbRepayment.Controls.Add(this.lblRepaymentAmount);
            this.gbRepayment.Controls.Add(this.lblVrNo);
            this.gbRepayment.Controls.Add(this.cxC00031);
            this.gbRepayment.Controls.Add(this.lblRepaymentNo);
            this.gbRepayment.Controls.Add(this.lblAccountNo);
            this.gbRepayment.Controls.Add(this.lblTotalOutstanding);
            this.gbRepayment.Location = new System.Drawing.Point(3, 42);
            this.gbRepayment.Name = "gbRepayment";
            this.gbRepayment.Size = new System.Drawing.Size(335, 188);
            this.gbRepayment.TabIndex = 9;
            this.gbRepayment.TabStop = false;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.DecimalPlaces = 2;
            this.txtTotalAmount.IsSendTabOnEnter = true;
            this.txtTotalAmount.IsThousandSeperator = true;
            this.txtTotalAmount.Location = new System.Drawing.Point(141, 156);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(141, 20);
            this.txtTotalAmount.TabIndex = 24;
            this.txtTotalAmount.Text = "0.00";
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtPenalties
            // 
            this.txtPenalties.DecimalPlaces = 2;
            this.txtPenalties.IsSendTabOnEnter = true;
            this.txtPenalties.IsThousandSeperator = true;
            this.txtPenalties.Location = new System.Drawing.Point(141, 133);
            this.txtPenalties.Name = "txtPenalties";
            this.txtPenalties.Size = new System.Drawing.Size(141, 20);
            this.txtPenalties.TabIndex = 23;
            this.txtPenalties.Text = "0.00";
            this.txtPenalties.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPenalties.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtPenalties.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPenalties_KeyDown);
            // 
            // txtInterest
            // 
            this.txtInterest.DecimalPlaces = 2;
            this.txtInterest.IsSendTabOnEnter = true;
            this.txtInterest.IsThousandSeperator = true;
            this.txtInterest.Location = new System.Drawing.Point(141, 110);
            this.txtInterest.Name = "txtInterest";
            this.txtInterest.Size = new System.Drawing.Size(141, 20);
            this.txtInterest.TabIndex = 22;
            this.txtInterest.Text = "0.00";
            this.txtInterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInterest.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtInterest.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInterest_KeyDown);
            // 
            // txtRepaymentAmount
            // 
            this.txtRepaymentAmount.DecimalPlaces = 2;
            this.txtRepaymentAmount.IsSendTabOnEnter = true;
            this.txtRepaymentAmount.IsThousandSeperator = true;
            this.txtRepaymentAmount.Location = new System.Drawing.Point(141, 86);
            this.txtRepaymentAmount.Name = "txtRepaymentAmount";
            this.txtRepaymentAmount.Size = new System.Drawing.Size(141, 20);
            this.txtRepaymentAmount.TabIndex = 21;
            this.txtRepaymentAmount.Text = "0.00";
            this.txtRepaymentAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRepaymentAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtLoanNo
            // 
            this.txtLoanNo.IsSendTabOnEnter = true;
            this.txtLoanNo.Location = new System.Drawing.Point(141, 14);
            this.txtLoanNo.MaxLength = 15;
            this.txtLoanNo.Name = "txtLoanNo";
            this.txtLoanNo.Size = new System.Drawing.Size(121, 20);
            this.txtLoanNo.TabIndex = 20;
            this.txtLoanNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLoanNo_KeyPress);
            // 
            // txtOutstanding
            // 
            this.txtOutstanding.Enabled = false;
            this.txtOutstanding.IsSendTabOnEnter = true;
            this.txtOutstanding.Location = new System.Drawing.Point(141, 62);
            this.txtOutstanding.Name = "txtOutstanding";
            this.txtOutstanding.ReadOnly = true;
            this.txtOutstanding.Size = new System.Drawing.Size(141, 20);
            this.txtOutstanding.TabIndex = 18;
            // 
            // txtAcctNo
            // 
            this.txtAcctNo.Enabled = false;
            this.txtAcctNo.IsSendTabOnEnter = true;
            this.txtAcctNo.Location = new System.Drawing.Point(141, 38);
            this.txtAcctNo.Name = "txtAcctNo";
            this.txtAcctNo.ReadOnly = true;
            this.txtAcctNo.Size = new System.Drawing.Size(141, 20);
            this.txtAcctNo.TabIndex = 17;
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.Location = new System.Drawing.Point(15, 114);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(48, 13);
            this.cxC00032.TabIndex = 11;
            this.cxC00032.Text = "Interest :";
            // 
            // lblRepaymentAmount
            // 
            this.lblRepaymentAmount.AutoSize = true;
            this.lblRepaymentAmount.Location = new System.Drawing.Point(16, 162);
            this.lblRepaymentAmount.Name = "lblRepaymentAmount";
            this.lblRepaymentAmount.Size = new System.Drawing.Size(79, 13);
            this.lblRepaymentAmount.TabIndex = 9;
            this.lblRepaymentAmount.Text = "Total Amount  :";
            // 
            // lblVrNo
            // 
            this.lblVrNo.AutoSize = true;
            this.lblVrNo.Location = new System.Drawing.Point(16, 42);
            this.lblVrNo.Name = "lblVrNo";
            this.lblVrNo.Size = new System.Drawing.Size(70, 13);
            this.lblVrNo.TabIndex = 3;
            this.lblVrNo.Text = "Account No :";
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(15, 66);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(97, 13);
            this.cxC00031.TabIndex = 0;
            this.cxC00031.Text = "Total Outstanding :";
            // 
            // lblRepaymentNo
            // 
            this.lblRepaymentNo.AutoSize = true;
            this.lblRepaymentNo.Location = new System.Drawing.Point(15, 18);
            this.lblRepaymentNo.Name = "lblRepaymentNo";
            this.lblRepaymentNo.Size = new System.Drawing.Size(54, 13);
            this.lblRepaymentNo.TabIndex = 0;
            this.lblRepaymentNo.Text = "Loan No :";
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(15, 90);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(67, 13);
            this.lblAccountNo.TabIndex = 0;
            this.lblAccountNo.Text = "Repayment :";
            // 
            // lblTotalOutstanding
            // 
            this.lblTotalOutstanding.AutoSize = true;
            this.lblTotalOutstanding.Location = new System.Drawing.Point(15, 138);
            this.lblTotalOutstanding.Name = "lblTotalOutstanding";
            this.lblTotalOutstanding.Size = new System.Drawing.Size(59, 13);
            this.lblTotalOutstanding.TabIndex = 0;
            this.lblTotalOutstanding.Text = "Penalties  :";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-2, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(532, 31);
            this.tsbCRUD.TabIndex = 8;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // LOMVEW00104
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 237);
            this.Controls.Add(this.gbRepayment);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LOMVEW00104";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOMVEW00104";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.LOMVEW00104_Load);
            this.gbRepayment.ResumeLayout(false);
            this.gbRepayment.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbRepayment;
        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private Windows.CXClient.Controls.CXC0003 lblRepaymentAmount;
        private Windows.CXClient.Controls.CXC0003 lblVrNo;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0003 lblRepaymentNo;
        private Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblTotalOutstanding;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0001 txtAcctNo;
        private Windows.CXClient.Controls.CXC0001 txtOutstanding;
        private Windows.CXClient.Controls.CXC0001 txtLoanNo;
        private Windows.CXClient.Controls.CXC0004 txtRepaymentAmount;
        private Windows.CXClient.Controls.CXC0004 txtInterest;
        private Windows.CXClient.Controls.CXC0004 txtPenalties;
        private Windows.CXClient.Controls.CXC0004 txtTotalAmount;
    }
}