namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00156
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00156));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboRequiredMonth = new Ace.Windows.CXClient.Controls.CXC0002();
            this.txtRequiredYear = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblRequiredMonth = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblRequiredYear = new Ace.Windows.CXClient.Controls.CXC0003();
            this.rdoSettlementDate = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoTransactionDate = new Ace.Windows.CXClient.Controls.CXC0009();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-2, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(496, 31);
            this.tsbCRUD.TabIndex = 4;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboRequiredMonth);
            this.groupBox1.Controls.Add(this.txtRequiredYear);
            this.groupBox1.Controls.Add(this.lblRequiredMonth);
            this.groupBox1.Controls.Add(this.lblRequiredYear);
            this.groupBox1.Controls.Add(this.rdoSettlementDate);
            this.groupBox1.Controls.Add(this.rdoTransactionDate);
            this.groupBox1.Location = new System.Drawing.Point(12, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 121);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cboRequiredMonth
            // 
            this.cboRequiredMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboRequiredMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRequiredMonth.DropDownHeight = 200;
            this.cboRequiredMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRequiredMonth.FormattingEnabled = true;
            this.cboRequiredMonth.IntegralHeight = false;
            this.cboRequiredMonth.IsSendTabOnEnter = true;
            this.cboRequiredMonth.Location = new System.Drawing.Point(139, 83);
            this.cboRequiredMonth.Name = "cboRequiredMonth";
            this.cboRequiredMonth.Size = new System.Drawing.Size(115, 21);
            this.cboRequiredMonth.TabIndex = 3;
            // 
            // txtRequiredYear
            // 
            this.txtRequiredYear.BackColor = System.Drawing.SystemColors.Window;
            this.txtRequiredYear.IsSendTabOnEnter = true;
            this.txtRequiredYear.Location = new System.Drawing.Point(139, 57);
            this.txtRequiredYear.Name = "txtRequiredYear";
            this.txtRequiredYear.Size = new System.Drawing.Size(115, 20);
            this.txtRequiredYear.TabIndex = 2;
            // 
            // lblRequiredMonth
            // 
            this.lblRequiredMonth.AutoSize = true;
            this.lblRequiredMonth.Location = new System.Drawing.Point(18, 87);
            this.lblRequiredMonth.Name = "lblRequiredMonth";
            this.lblRequiredMonth.Size = new System.Drawing.Size(89, 13);
            this.lblRequiredMonth.TabIndex = 0;
            this.lblRequiredMonth.Text = "Required Month :";
            // 
            // lblRequiredYear
            // 
            this.lblRequiredYear.AutoSize = true;
            this.lblRequiredYear.Location = new System.Drawing.Point(18, 57);
            this.lblRequiredYear.Name = "lblRequiredYear";
            this.lblRequiredYear.Size = new System.Drawing.Size(81, 13);
            this.lblRequiredYear.TabIndex = 0;
            this.lblRequiredYear.Text = "Required Year :";
            // 
            // rdoSettlementDate
            // 
            this.rdoSettlementDate.AutoSize = true;
            this.rdoSettlementDate.IsSendTabOnEnter = true;
            this.rdoSettlementDate.Location = new System.Drawing.Point(159, 23);
            this.rdoSettlementDate.Name = "rdoSettlementDate";
            this.rdoSettlementDate.Size = new System.Drawing.Size(101, 17);
            this.rdoSettlementDate.TabIndex = 1;
            this.rdoSettlementDate.TabStop = true;
            this.rdoSettlementDate.Text = "Settlement Date";
            this.rdoSettlementDate.UseVisualStyleBackColor = true;
            // 
            // rdoTransactionDate
            // 
            this.rdoTransactionDate.AutoSize = true;
            this.rdoTransactionDate.Checked = true;
            this.rdoTransactionDate.IsSendTabOnEnter = true;
            this.rdoTransactionDate.Location = new System.Drawing.Point(21, 23);
            this.rdoTransactionDate.Name = "rdoTransactionDate";
            this.rdoTransactionDate.Size = new System.Drawing.Size(107, 17);
            this.rdoTransactionDate.TabIndex = 1;
            this.rdoTransactionDate.TabStop = true;
            this.rdoTransactionDate.Text = "Transaction Date";
            this.rdoTransactionDate.UseVisualStyleBackColor = true;
            // 
            // MNMVEW00156
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 170);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsbCRUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MNMVEW00156";
            this.Text = "MNMVEW00156";
            this.Load += new System.EventHandler(this.MNMVEW00156_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox groupBox1;
        private Windows.CXClient.Controls.CXC0002 cboRequiredMonth;
        private Windows.CXClient.Controls.CXC0001 txtRequiredYear;
        private Windows.CXClient.Controls.CXC0003 lblRequiredMonth;
        private Windows.CXClient.Controls.CXC0003 lblRequiredYear;
        private Windows.CXClient.Controls.CXC0009 rdoSettlementDate;
        private Windows.CXClient.Controls.CXC0009 rdoTransactionDate;
    }
}