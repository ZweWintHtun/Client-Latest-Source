namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00009
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00009));
            this.lblInterestAmount = new System.Windows.Forms.Label();
            this.lblMonthYear = new System.Windows.Forms.Label();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.txtInterestMonth1 = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtInterestMonth2 = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtInterestMonth3 = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtInterestTotal = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblMonth1 = new System.Windows.Forms.Label();
            this.lblMonth2 = new System.Windows.Forms.Label();
            this.lblMonth3 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.grpFooter = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLoansNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtDateTime = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblRate = new System.Windows.Forms.Label();
            this.txtRate = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtInterestOfLastDate = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblInterestofLastDate = new System.Windows.Forms.Label();
            this.lblAccountNo = new System.Windows.Forms.Label();
            this.lblLoansNo = new System.Windows.Forms.Label();
            this.lblOverdraftLimit = new System.Windows.Forms.Label();
            this.lblLastCalculateDate = new System.Windows.Forms.Label();
            this.txtLastCalculateDate = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtOverdraftLimit = new Ace.Windows.CXClient.Controls.CXC0004();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.grpFooter.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInterestAmount
            // 
            this.lblInterestAmount.AutoSize = true;
            this.lblInterestAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInterestAmount.Location = new System.Drawing.Point(163, 16);
            this.lblInterestAmount.Name = "lblInterestAmount";
            this.lblInterestAmount.Size = new System.Drawing.Size(96, 13);
            this.lblInterestAmount.TabIndex = 0;
            this.lblInterestAmount.Text = "Interest Amount";
            // 
            // lblMonthYear
            // 
            this.lblMonthYear.AutoSize = true;
            this.lblMonthYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonthYear.Location = new System.Drawing.Point(17, 16);
            this.lblMonthYear.Name = "lblMonthYear";
            this.lblMonthYear.Size = new System.Drawing.Size(82, 13);
            this.lblMonthYear.TabIndex = 0;
            this.lblMonthYear.Text = "Month / Year";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, -1);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(543, 31);
            this.tsbCRUD.TabIndex = 6;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // txtInterestMonth1
            // 
            this.txtInterestMonth1.DecimalPlaces = 2;
            this.txtInterestMonth1.IsSendTabOnEnter = true;
            this.txtInterestMonth1.Location = new System.Drawing.Point(166, 41);
            this.txtInterestMonth1.Name = "txtInterestMonth1";
            this.txtInterestMonth1.Size = new System.Drawing.Size(121, 20);
            this.txtInterestMonth1.TabIndex = 3;
            this.txtInterestMonth1.Text = "0.00";
            this.txtInterestMonth1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInterestMonth1.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtInterestMonth1.Leave += new System.EventHandler(this.txtInterestMonth1_Leave);
            // 
            // txtInterestMonth2
            // 
            this.txtInterestMonth2.DecimalPlaces = 2;
            this.txtInterestMonth2.IsSendTabOnEnter = true;
            this.txtInterestMonth2.Location = new System.Drawing.Point(166, 67);
            this.txtInterestMonth2.Name = "txtInterestMonth2";
            this.txtInterestMonth2.Size = new System.Drawing.Size(121, 20);
            this.txtInterestMonth2.TabIndex = 4;
            this.txtInterestMonth2.Text = "0.00";
            this.txtInterestMonth2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInterestMonth2.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtInterestMonth2.Leave += new System.EventHandler(this.txtInterestMonth2_Leave);
            // 
            // txtInterestMonth3
            // 
            this.txtInterestMonth3.DecimalPlaces = 2;
            this.txtInterestMonth3.IsSendTabOnEnter = true;
            this.txtInterestMonth3.Location = new System.Drawing.Point(166, 93);
            this.txtInterestMonth3.Name = "txtInterestMonth3";
            this.txtInterestMonth3.Size = new System.Drawing.Size(121, 20);
            this.txtInterestMonth3.TabIndex = 5;
            this.txtInterestMonth3.Text = "0.00";
            this.txtInterestMonth3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInterestMonth3.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtInterestMonth3.Leave += new System.EventHandler(this.txtInterestMonth3_Leave);
            // 
            // txtInterestTotal
            // 
            this.txtInterestTotal.DecimalPlaces = 2;
            this.txtInterestTotal.Enabled = false;
            this.txtInterestTotal.IsSendTabOnEnter = true;
            this.txtInterestTotal.Location = new System.Drawing.Point(166, 119);
            this.txtInterestTotal.Name = "txtInterestTotal";
            this.txtInterestTotal.ReadOnly = true;
            this.txtInterestTotal.Size = new System.Drawing.Size(121, 20);
            this.txtInterestTotal.TabIndex = 0;
            this.txtInterestTotal.Text = "0.00";
            this.txtInterestTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInterestTotal.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblMonth1
            // 
            this.lblMonth1.AutoSize = true;
            this.lblMonth1.Location = new System.Drawing.Point(17, 46);
            this.lblMonth1.Name = "lblMonth1";
            this.lblMonth1.Size = new System.Drawing.Size(43, 13);
            this.lblMonth1.TabIndex = 0;
            this.lblMonth1.Text = "Month1";
            // 
            // lblMonth2
            // 
            this.lblMonth2.AutoSize = true;
            this.lblMonth2.Location = new System.Drawing.Point(17, 73);
            this.lblMonth2.Name = "lblMonth2";
            this.lblMonth2.Size = new System.Drawing.Size(43, 13);
            this.lblMonth2.TabIndex = 0;
            this.lblMonth2.Text = "Month2";
            // 
            // lblMonth3
            // 
            this.lblMonth3.AutoSize = true;
            this.lblMonth3.Location = new System.Drawing.Point(17, 98);
            this.lblMonth3.Name = "lblMonth3";
            this.lblMonth3.Size = new System.Drawing.Size(43, 13);
            this.lblMonth3.TabIndex = 0;
            this.lblMonth3.Text = "Month3";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(17, 124);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(31, 13);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Total";
            // 
            // grpFooter
            // 
            this.grpFooter.Controls.Add(this.lblInterestAmount);
            this.grpFooter.Controls.Add(this.txtInterestTotal);
            this.grpFooter.Controls.Add(this.lblTotal);
            this.grpFooter.Controls.Add(this.txtInterestMonth3);
            this.grpFooter.Controls.Add(this.lblMonthYear);
            this.grpFooter.Controls.Add(this.lblMonth3);
            this.grpFooter.Controls.Add(this.txtInterestMonth1);
            this.grpFooter.Controls.Add(this.lblMonth2);
            this.grpFooter.Controls.Add(this.lblMonth1);
            this.grpFooter.Controls.Add(this.txtInterestMonth2);
            this.grpFooter.Location = new System.Drawing.Point(12, 176);
            this.grpFooter.Name = "grpFooter";
            this.grpFooter.Size = new System.Drawing.Size(516, 155);
            this.grpFooter.TabIndex = 3;
            this.grpFooter.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLoansNo);
            this.groupBox1.Controls.Add(this.txtDateTime);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.lblRate);
            this.groupBox1.Controls.Add(this.txtRate);
            this.groupBox1.Controls.Add(this.txtInterestOfLastDate);
            this.groupBox1.Controls.Add(this.lblInterestofLastDate);
            this.groupBox1.Controls.Add(this.lblAccountNo);
            this.groupBox1.Controls.Add(this.lblLoansNo);
            this.groupBox1.Controls.Add(this.lblOverdraftLimit);
            this.groupBox1.Controls.Add(this.lblLastCalculateDate);
            this.groupBox1.Controls.Add(this.txtLastCalculateDate);
            this.groupBox1.Controls.Add(this.txtOverdraftLimit);
            this.groupBox1.Controls.Add(this.mtxtAccountNo);
            this.groupBox1.Location = new System.Drawing.Point(12, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(516, 134);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtLoansNo
            // 
            this.txtLoansNo.IsSendTabOnEnter = true;
            this.txtLoansNo.Location = new System.Drawing.Point(166, 19);
            this.txtLoansNo.MaxLength = 15;
            this.txtLoansNo.Name = "txtLoansNo";
            this.txtLoansNo.Size = new System.Drawing.Size(121, 20);
            this.txtLoansNo.TabIndex = 1;
            this.txtLoansNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLoansNo_KeyPress);
            // 
            // txtDateTime
            // 
            this.txtDateTime.AutoSize = true;
            this.txtDateTime.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.txtDateTime.Location = new System.Drawing.Point(429, 24);
            this.txtDateTime.Name = "txtDateTime";
            this.txtDateTime.Size = new System.Drawing.Size(10, 13);
            this.txtDateTime.TabIndex = 0;
            this.txtDateTime.Text = "-";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblDate.Location = new System.Drawing.Point(384, 24);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(36, 13);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Date :";
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Location = new System.Drawing.Point(369, 71);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(36, 13);
            this.lblRate.TabIndex = 0;
            this.lblRate.Text = "Rate :";
            // 
            // txtRate
            // 
            this.txtRate.DecimalPlaces = 2;
            this.txtRate.Enabled = false;
            this.txtRate.IsSendTabOnEnter = true;
            this.txtRate.Location = new System.Drawing.Point(426, 71);
            this.txtRate.Name = "txtRate";
            this.txtRate.ReadOnly = true;
            this.txtRate.Size = new System.Drawing.Size(70, 20);
            this.txtRate.TabIndex = 4;
            this.txtRate.Text = "0.00";
            this.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRate.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtInterestOfLastDate
            // 
            this.txtInterestOfLastDate.DecimalPlaces = 2;
            this.txtInterestOfLastDate.IsSendTabOnEnter = true;
            this.txtInterestOfLastDate.Location = new System.Drawing.Point(426, 97);
            this.txtInterestOfLastDate.Name = "txtInterestOfLastDate";
            this.txtInterestOfLastDate.Size = new System.Drawing.Size(70, 20);
            this.txtInterestOfLastDate.TabIndex = 3;
            this.txtInterestOfLastDate.Text = "0.00";
            this.txtInterestOfLastDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInterestOfLastDate.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblInterestofLastDate
            // 
            this.lblInterestofLastDate.AutoSize = true;
            this.lblInterestofLastDate.Location = new System.Drawing.Point(306, 99);
            this.lblInterestofLastDate.Name = "lblInterestofLastDate";
            this.lblInterestofLastDate.Size = new System.Drawing.Size(103, 13);
            this.lblInterestofLastDate.TabIndex = 0;
            this.lblInterestofLastDate.Text = "Interest of Last Date";
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(17, 48);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(73, 13);
            this.lblAccountNo.TabIndex = 0;
            this.lblAccountNo.Text = "Account No. :";
            // 
            // lblLoansNo
            // 
            this.lblLoansNo.AutoSize = true;
            this.lblLoansNo.Location = new System.Drawing.Point(17, 22);
            this.lblLoansNo.Name = "lblLoansNo";
            this.lblLoansNo.Size = new System.Drawing.Size(62, 13);
            this.lblLoansNo.TabIndex = 0;
            this.lblLoansNo.Text = "Loans No. :";
            // 
            // lblOverdraftLimit
            // 
            this.lblOverdraftLimit.AutoSize = true;
            this.lblOverdraftLimit.Location = new System.Drawing.Point(17, 78);
            this.lblOverdraftLimit.Name = "lblOverdraftLimit";
            this.lblOverdraftLimit.Size = new System.Drawing.Size(81, 13);
            this.lblOverdraftLimit.TabIndex = 0;
            this.lblOverdraftLimit.Text = "Overdraft Limit :";
            // 
            // lblLastCalculateDate
            // 
            this.lblLastCalculateDate.AutoSize = true;
            this.lblLastCalculateDate.Location = new System.Drawing.Point(17, 103);
            this.lblLastCalculateDate.Name = "lblLastCalculateDate";
            this.lblLastCalculateDate.Size = new System.Drawing.Size(106, 13);
            this.lblLastCalculateDate.TabIndex = 0;
            this.lblLastCalculateDate.Text = "Last Calculate Date :";
            // 
            // txtLastCalculateDate
            // 
            this.txtLastCalculateDate.Enabled = false;
            this.txtLastCalculateDate.IsSendTabOnEnter = true;
            this.txtLastCalculateDate.Location = new System.Drawing.Point(166, 99);
            this.txtLastCalculateDate.Name = "txtLastCalculateDate";
            this.txtLastCalculateDate.ReadOnly = true;
            this.txtLastCalculateDate.Size = new System.Drawing.Size(121, 20);
            this.txtLastCalculateDate.TabIndex = 0;
            // 
            // txtOverdraftLimit
            // 
            this.txtOverdraftLimit.DecimalPlaces = 2;
            this.txtOverdraftLimit.Enabled = false;
            this.txtOverdraftLimit.IsSendTabOnEnter = true;
            this.txtOverdraftLimit.Location = new System.Drawing.Point(166, 73);
            this.txtOverdraftLimit.Name = "txtOverdraftLimit";
            this.txtOverdraftLimit.ReadOnly = true;
            this.txtOverdraftLimit.Size = new System.Drawing.Size(121, 20);
            this.txtOverdraftLimit.TabIndex = 0;
            this.txtOverdraftLimit.Text = "0.00";
            this.txtOverdraftLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOverdraftLimit.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(166, 45);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 2;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // TCMVEW00009
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 346);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.grpFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TCMVEW00009";
            this.Load += new System.EventHandler(this.TCMVEW00009_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TCMVEW00009_KeyDown);
            this.Move += new System.EventHandler(this.TCMVEW00009_Move);
            this.grpFooter.ResumeLayout(false);
            this.grpFooter.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblInterestAmount;
        private System.Windows.Forms.Label lblMonthYear;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0004 txtInterestMonth1;
        private Windows.CXClient.Controls.CXC0004 txtInterestMonth2;
        private Windows.CXClient.Controls.CXC0004 txtInterestMonth3;
        private Windows.CXClient.Controls.CXC0004 txtInterestTotal;
        private System.Windows.Forms.Label lblMonth1;
        private System.Windows.Forms.Label lblMonth2;
        private System.Windows.Forms.Label lblMonth3;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.GroupBox grpFooter;
        private System.Windows.Forms.GroupBox groupBox1;
        private Windows.CXClient.Controls.CXC0003 lblDate;
        private System.Windows.Forms.Label lblRate;
        private Windows.CXClient.Controls.CXC0004 txtRate;
        private Windows.CXClient.Controls.CXC0004 txtInterestOfLastDate;
        private System.Windows.Forms.Label lblInterestofLastDate;
        private System.Windows.Forms.Label lblAccountNo;
        private System.Windows.Forms.Label lblLoansNo;
        private System.Windows.Forms.Label lblOverdraftLimit;
        private System.Windows.Forms.Label lblLastCalculateDate;
        private Windows.CXClient.Controls.CXC0001 txtLastCalculateDate;
        private Windows.CXClient.Controls.CXC0004 txtOverdraftLimit;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Windows.CXClient.Controls.CXC0003 txtDateTime;
        private Windows.CXClient.Controls.CXC0001 txtLoansNo;


    }
}