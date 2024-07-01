namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00048
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00048));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gbAccountCode = new System.Windows.Forms.GroupBox();
            this.rdoSettlementDate = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoTransactionDate = new Ace.Windows.CXClient.Controls.CXC0009();
            this.txtYear = new Ace.Windows.CXClient.Controls.CXC0004();
            this.cboMonth = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblRequireMonth = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblRequireYear = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gbAccountCode.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(492, 31);
            this.tsbCRUD.TabIndex = 16;
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // gbAccountCode
            // 
            this.gbAccountCode.Controls.Add(this.rdoSettlementDate);
            this.gbAccountCode.Controls.Add(this.rdoTransactionDate);
            this.gbAccountCode.Location = new System.Drawing.Point(12, 37);
            this.gbAccountCode.Name = "gbAccountCode";
            this.gbAccountCode.Size = new System.Drawing.Size(298, 37);
            this.gbAccountCode.TabIndex = 55;
            this.gbAccountCode.TabStop = false;
            // 
            // rdoSettlementDate
            // 
            this.rdoSettlementDate.AutoSize = true;
            this.rdoSettlementDate.IsSendTabOnEnter = true;
            this.rdoSettlementDate.Location = new System.Drawing.Point(145, 14);
            this.rdoSettlementDate.Name = "rdoSettlementDate";
            this.rdoSettlementDate.Size = new System.Drawing.Size(101, 17);
            this.rdoSettlementDate.TabIndex = 0;
            this.rdoSettlementDate.Text = "Settlement Date";
            this.rdoSettlementDate.UseVisualStyleBackColor = true;
            // 
            // rdoTransactionDate
            // 
            this.rdoTransactionDate.AutoSize = true;
            this.rdoTransactionDate.Checked = true;
            this.rdoTransactionDate.IsSendTabOnEnter = true;
            this.rdoTransactionDate.Location = new System.Drawing.Point(6, 14);
            this.rdoTransactionDate.Name = "rdoTransactionDate";
            this.rdoTransactionDate.Size = new System.Drawing.Size(107, 17);
            this.rdoTransactionDate.TabIndex = 0;
            this.rdoTransactionDate.TabStop = true;
            this.rdoTransactionDate.Text = "Transaction Date";
            this.rdoTransactionDate.UseVisualStyleBackColor = true;
            // 
            // txtYear
            // 
            this.txtYear.DecimalPlaces = 0;
            this.txtYear.IsSendTabOnEnter = true;
            this.txtYear.Location = new System.Drawing.Point(111, 91);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(100, 20);
            this.txtYear.TabIndex = 59;
            this.txtYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtYear.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // cboMonth
            // 
            this.cboMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMonth.DropDownHeight = 200;
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.IntegralHeight = false;
            this.cboMonth.IsSendTabOnEnter = true;
            this.cboMonth.Location = new System.Drawing.Point(111, 117);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(121, 21);
            this.cboMonth.TabIndex = 58;
            // 
            // lblRequireMonth
            // 
            this.lblRequireMonth.AutoSize = true;
            this.lblRequireMonth.Location = new System.Drawing.Point(14, 120);
            this.lblRequireMonth.Name = "lblRequireMonth";
            this.lblRequireMonth.Size = new System.Drawing.Size(83, 13);
            this.lblRequireMonth.TabIndex = 57;
            this.lblRequireMonth.Text = "Require Month :";
            // 
            // lblRequireYear
            // 
            this.lblRequireYear.AutoSize = true;
            this.lblRequireYear.Location = new System.Drawing.Point(14, 94);
            this.lblRequireYear.Name = "lblRequireYear";
            this.lblRequireYear.Size = new System.Drawing.Size(75, 13);
            this.lblRequireYear.TabIndex = 56;
            this.lblRequireYear.Text = "Require Year :";
            // 
            // MNMVEW00048
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 170);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.cboMonth);
            this.Controls.Add(this.lblRequireMonth);
            this.Controls.Add(this.lblRequireYear);
            this.Controls.Add(this.gbAccountCode);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00048";
            this.Text = "Drawing Remittance / Encash Remittance";
            this.gbAccountCode.ResumeLayout(false);
            this.gbAccountCode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox gbAccountCode;
        private Windows.CXClient.Controls.CXC0009 rdoSettlementDate;
        private Windows.CXClient.Controls.CXC0009 rdoTransactionDate;
        private Windows.CXClient.Controls.CXC0004 txtYear;
        private Windows.CXClient.Controls.CXC0002 cboMonth;
        private Windows.CXClient.Controls.CXC0003 lblRequireMonth;
        private Windows.CXClient.Controls.CXC0003 lblRequireYear;
    }
}