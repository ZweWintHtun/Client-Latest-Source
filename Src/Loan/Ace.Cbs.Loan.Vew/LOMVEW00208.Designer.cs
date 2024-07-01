namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00208
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00208));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.txtHPNo = new System.Windows.Forms.TextBox();
            this.txtStartTerm = new System.Windows.Forms.TextBox();
            this.txtEndTerm = new System.Windows.Forms.TextBox();
            this.txtLateFeesAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblCR = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblDR = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAmt = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCAmt = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAcctNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCAcctNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00038 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00036 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00035 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblTransactionDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00033 = new Ace.Windows.CXClient.Controls.CXC0003();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-3, -1);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(485, 31);
            this.tsbCRUD.TabIndex = 46;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // txtHPNo
            // 
            this.txtHPNo.Location = new System.Drawing.Point(153, 57);
            this.txtHPNo.MaxLength = 15;
            this.txtHPNo.Name = "txtHPNo";
            this.txtHPNo.Size = new System.Drawing.Size(180, 20);
            this.txtHPNo.TabIndex = 47;
            this.txtHPNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHPNo_KeyPress);
            this.txtHPNo.Leave += new System.EventHandler(this.txtHPNo_Leave);
            // 
            // txtStartTerm
            // 
            this.txtStartTerm.Location = new System.Drawing.Point(153, 96);
            this.txtStartTerm.Name = "txtStartTerm";
            this.txtStartTerm.ReadOnly = true;
            this.txtStartTerm.Size = new System.Drawing.Size(60, 20);
            this.txtStartTerm.TabIndex = 100;
            this.txtStartTerm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStartTerm_KeyPress);
            // 
            // txtEndTerm
            // 
            this.txtEndTerm.Location = new System.Drawing.Point(273, 96);
            this.txtEndTerm.Name = "txtEndTerm";
            this.txtEndTerm.Size = new System.Drawing.Size(60, 20);
            this.txtEndTerm.TabIndex = 101;
            this.txtEndTerm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEndTerm_KeyPress);
            this.txtEndTerm.Leave += new System.EventHandler(this.txtEndTerm_Leave);
            // 
            // txtLateFeesAmount
            // 
            this.txtLateFeesAmount.Location = new System.Drawing.Point(153, 133);
            this.txtLateFeesAmount.Name = "txtLateFeesAmount";
            this.txtLateFeesAmount.ReadOnly = true;
            this.txtLateFeesAmount.Size = new System.Drawing.Size(180, 20);
            this.txtLateFeesAmount.TabIndex = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Hire Purchase No :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Start From Term :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "To Term";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 54;
            this.label4.Text = "Late Fees Amount :";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblCR);
            this.groupBox2.Controls.Add(this.lblDR);
            this.groupBox2.Controls.Add(this.lblAmt);
            this.groupBox2.Controls.Add(this.lblCAmt);
            this.groupBox2.Controls.Add(this.lblAcctNo);
            this.groupBox2.Controls.Add(this.lblCAcctNo);
            this.groupBox2.Controls.Add(this.cxC00038);
            this.groupBox2.Controls.Add(this.cxC00036);
            this.groupBox2.Controls.Add(this.cxC00035);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(18, 182);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(430, 134);
            this.groupBox2.TabIndex = 67;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Late Fees Repayment Voucher";
            // 
            // lblCR
            // 
            this.lblCR.AutoSize = true;
            this.lblCR.Location = new System.Drawing.Point(361, 101);
            this.lblCR.Name = "lblCR";
            this.lblCR.Size = new System.Drawing.Size(0, 13);
            this.lblCR.TabIndex = 74;
            // 
            // lblDR
            // 
            this.lblDR.AutoSize = true;
            this.lblDR.Location = new System.Drawing.Point(361, 65);
            this.lblDR.Name = "lblDR";
            this.lblDR.Size = new System.Drawing.Size(0, 13);
            this.lblDR.TabIndex = 73;
            // 
            // lblAmt
            // 
            this.lblAmt.AutoSize = true;
            this.lblAmt.Location = new System.Drawing.Point(196, 101);
            this.lblAmt.Name = "lblAmt";
            this.lblAmt.Size = new System.Drawing.Size(0, 13);
            this.lblAmt.TabIndex = 72;
            // 
            // lblCAmt
            // 
            this.lblCAmt.AutoSize = true;
            this.lblCAmt.Location = new System.Drawing.Point(196, 65);
            this.lblCAmt.Name = "lblCAmt";
            this.lblCAmt.Size = new System.Drawing.Size(0, 13);
            this.lblCAmt.TabIndex = 71;
            // 
            // lblAcctNo
            // 
            this.lblAcctNo.AutoSize = true;
            this.lblAcctNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcctNo.Location = new System.Drawing.Point(18, 101);
            this.lblAcctNo.Name = "lblAcctNo";
            this.lblAcctNo.Size = new System.Drawing.Size(0, 13);
            this.lblAcctNo.TabIndex = 70;
            // 
            // lblCAcctNo
            // 
            this.lblCAcctNo.AutoSize = true;
            this.lblCAcctNo.Location = new System.Drawing.Point(18, 65);
            this.lblCAcctNo.Name = "lblCAcctNo";
            this.lblCAcctNo.Size = new System.Drawing.Size(0, 13);
            this.lblCAcctNo.TabIndex = 69;
            // 
            // cxC00038
            // 
            this.cxC00038.AutoSize = true;
            this.cxC00038.Location = new System.Drawing.Point(361, 28);
            this.cxC00038.Name = "cxC00038";
            this.cxC00038.Size = new System.Drawing.Size(48, 13);
            this.cxC00038.TabIndex = 68;
            this.cxC00038.Text = "DR/CR";
            // 
            // cxC00036
            // 
            this.cxC00036.AutoSize = true;
            this.cxC00036.Location = new System.Drawing.Point(196, 28);
            this.cxC00036.Name = "cxC00036";
            this.cxC00036.Size = new System.Drawing.Size(49, 13);
            this.cxC00036.TabIndex = 67;
            this.cxC00036.Text = "Amount";
            // 
            // cxC00035
            // 
            this.cxC00035.AutoSize = true;
            this.cxC00035.Location = new System.Drawing.Point(18, 28);
            this.cxC00035.Name = "cxC00035";
            this.cxC00035.Size = new System.Drawing.Size(74, 13);
            this.cxC00035.TabIndex = 66;
            this.cxC00035.Text = "Account No";
            // 
            // lblTransactionDate
            // 
            this.lblTransactionDate.AutoSize = true;
            this.lblTransactionDate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblTransactionDate.Location = new System.Drawing.Point(406, 36);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Size = new System.Drawing.Size(0, 13);
            this.lblTransactionDate.TabIndex = 103;
            // 
            // cxC00033
            // 
            this.cxC00033.AutoSize = true;
            this.cxC00033.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.cxC00033.Location = new System.Drawing.Point(305, 36);
            this.cxC00033.Name = "cxC00033";
            this.cxC00033.Size = new System.Drawing.Size(95, 13);
            this.cxC00033.TabIndex = 102;
            this.cxC00033.Text = "Transaction Date :";
            // 
            // LOMVEW00208
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 332);
            this.Controls.Add(this.lblTransactionDate);
            this.Controls.Add(this.cxC00033);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLateFeesAmount);
            this.Controls.Add(this.txtEndTerm);
            this.Controls.Add(this.txtStartTerm);
            this.Controls.Add(this.txtHPNo);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00208";
            this.Text = "HP Late Fees Repayment";
            this.Load += new System.EventHandler(this.LOMVEW00208_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.TextBox txtHPNo;
        private System.Windows.Forms.TextBox txtStartTerm;
        private System.Windows.Forms.TextBox txtEndTerm;
        private System.Windows.Forms.TextBox txtLateFeesAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Windows.CXClient.Controls.CXC0003 lblCR;
        private Windows.CXClient.Controls.CXC0003 lblDR;
        private Windows.CXClient.Controls.CXC0003 lblAmt;
        private Windows.CXClient.Controls.CXC0003 lblCAmt;
        private Windows.CXClient.Controls.CXC0003 lblAcctNo;
        private Windows.CXClient.Controls.CXC0003 lblCAcctNo;
        private Windows.CXClient.Controls.CXC0003 cxC00038;
        private Windows.CXClient.Controls.CXC0003 cxC00036;
        private Windows.CXClient.Controls.CXC0003 cxC00035;
        private Windows.CXClient.Controls.CXC0003 lblTransactionDate;
        private Windows.CXClient.Controls.CXC0003 cxC00033;
    }
}