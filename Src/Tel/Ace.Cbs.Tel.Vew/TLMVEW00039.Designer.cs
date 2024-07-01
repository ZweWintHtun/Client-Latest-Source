namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00039
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00039));
            this.gbRemittanceListingByAmount = new System.Windows.Forms.GroupBox();
            this.ntxtEndAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.ntxtStartAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblEncashmentEndAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblEncashmentStartAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.dtpEncashmentEndDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.lblEncashmentEndDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.dtpEncashmentStartDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.lblEncashmentStartDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.rdoSettlementDate = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoTransactionDate = new Ace.Windows.CXClient.Controls.CXC0009();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gbRemittanceListingByAmount.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbRemittanceListingByAmount
            // 
            this.gbRemittanceListingByAmount.Controls.Add(this.ntxtEndAmount);
            this.gbRemittanceListingByAmount.Controls.Add(this.ntxtStartAmount);
            this.gbRemittanceListingByAmount.Controls.Add(this.lblEncashmentEndAmount);
            this.gbRemittanceListingByAmount.Controls.Add(this.lblEncashmentStartAmount);
            this.gbRemittanceListingByAmount.Controls.Add(this.dtpEncashmentEndDate);
            this.gbRemittanceListingByAmount.Controls.Add(this.lblEncashmentEndDate);
            this.gbRemittanceListingByAmount.Controls.Add(this.dtpEncashmentStartDate);
            this.gbRemittanceListingByAmount.Controls.Add(this.lblEncashmentStartDate);
            this.gbRemittanceListingByAmount.Controls.Add(this.rdoSettlementDate);
            this.gbRemittanceListingByAmount.Controls.Add(this.rdoTransactionDate);
            this.gbRemittanceListingByAmount.Location = new System.Drawing.Point(10, 41);
            this.gbRemittanceListingByAmount.Name = "gbRemittanceListingByAmount";
            this.gbRemittanceListingByAmount.Size = new System.Drawing.Size(299, 187);
            this.gbRemittanceListingByAmount.TabIndex = 8;
            this.gbRemittanceListingByAmount.TabStop = false;
            this.gbRemittanceListingByAmount.Text = " Remittance Listing (By Amount)";
            // 
            // ntxtEndAmount
            // 
            this.ntxtEndAmount.DecimalPlaces = 2;
            this.ntxtEndAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ntxtEndAmount.IsSendTabOnEnter = true;
            this.ntxtEndAmount.Location = new System.Drawing.Point(144, 150);
            this.ntxtEndAmount.MaxLength = 18;
            this.ntxtEndAmount.Name = "ntxtEndAmount";
            this.ntxtEndAmount.Size = new System.Drawing.Size(111, 20);
            this.ntxtEndAmount.TabIndex = 8;
            this.ntxtEndAmount.Text = "0.00";
            this.ntxtEndAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntxtEndAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.ntxtEndAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ntxtEndAmount_KeyDown);
            this.ntxtEndAmount.Leave += new System.EventHandler(this.ntxtEndAmount_Leave);
            // 
            // ntxtStartAmount
            // 
            this.ntxtStartAmount.DecimalPlaces = 2;
            this.ntxtStartAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ntxtStartAmount.IsSendTabOnEnter = true;
            this.ntxtStartAmount.Location = new System.Drawing.Point(144, 121);
            this.ntxtStartAmount.MaxLength = 18;
            this.ntxtStartAmount.Name = "ntxtStartAmount";
            this.ntxtStartAmount.Size = new System.Drawing.Size(111, 20);
            this.ntxtStartAmount.TabIndex = 7;
            this.ntxtStartAmount.Text = "0.00";
            this.ntxtStartAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntxtStartAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblEncashmentEndAmount
            // 
            this.lblEncashmentEndAmount.AutoSize = true;
            this.lblEncashmentEndAmount.Location = new System.Drawing.Point(20, 153);
            this.lblEncashmentEndAmount.Name = "lblEncashmentEndAmount";
            this.lblEncashmentEndAmount.Size = new System.Drawing.Size(71, 13);
            this.lblEncashmentEndAmount.TabIndex = 0;
            this.lblEncashmentEndAmount.Text = "End Amount :";
            // 
            // lblEncashmentStartAmount
            // 
            this.lblEncashmentStartAmount.AutoSize = true;
            this.lblEncashmentStartAmount.Location = new System.Drawing.Point(20, 124);
            this.lblEncashmentStartAmount.Name = "lblEncashmentStartAmount";
            this.lblEncashmentStartAmount.Size = new System.Drawing.Size(74, 13);
            this.lblEncashmentStartAmount.TabIndex = 0;
            this.lblEncashmentStartAmount.Text = "Start Amount :";
            // 
            // dtpEncashmentEndDate
            // 
            this.dtpEncashmentEndDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpEncashmentEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEncashmentEndDate.IsSendTabOnEnter = true;
            this.dtpEncashmentEndDate.Location = new System.Drawing.Point(144, 91);
            this.dtpEncashmentEndDate.Name = "dtpEncashmentEndDate";
            this.dtpEncashmentEndDate.Size = new System.Drawing.Size(115, 20);
            this.dtpEncashmentEndDate.TabIndex = 4;
            // 
            // lblEncashmentEndDate
            // 
            this.lblEncashmentEndDate.AutoSize = true;
            this.lblEncashmentEndDate.Location = new System.Drawing.Point(20, 95);
            this.lblEncashmentEndDate.Name = "lblEncashmentEndDate";
            this.lblEncashmentEndDate.Size = new System.Drawing.Size(58, 13);
            this.lblEncashmentEndDate.TabIndex = 0;
            this.lblEncashmentEndDate.Text = "End Date :";
            // 
            // dtpEncashmentStartDate
            // 
            this.dtpEncashmentStartDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpEncashmentStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEncashmentStartDate.IsSendTabOnEnter = true;
            this.dtpEncashmentStartDate.Location = new System.Drawing.Point(144, 60);
            this.dtpEncashmentStartDate.Name = "dtpEncashmentStartDate";
            this.dtpEncashmentStartDate.Size = new System.Drawing.Size(115, 20);
            this.dtpEncashmentStartDate.TabIndex = 3;
            // 
            // lblEncashmentStartDate
            // 
            this.lblEncashmentStartDate.AutoSize = true;
            this.lblEncashmentStartDate.Location = new System.Drawing.Point(20, 64);
            this.lblEncashmentStartDate.Name = "lblEncashmentStartDate";
            this.lblEncashmentStartDate.Size = new System.Drawing.Size(61, 13);
            this.lblEncashmentStartDate.TabIndex = 0;
            this.lblEncashmentStartDate.Text = "Start Date :";
            // 
            // rdoSettlementDate
            // 
            this.rdoSettlementDate.AutoSize = true;
            this.rdoSettlementDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSettlementDate.IsSendTabOnEnter = true;
            this.rdoSettlementDate.Location = new System.Drawing.Point(144, 29);
            this.rdoSettlementDate.Name = "rdoSettlementDate";
            this.rdoSettlementDate.Size = new System.Drawing.Size(101, 17);
            this.rdoSettlementDate.TabIndex = 2;
            this.rdoSettlementDate.Text = "Settlement Date";
            this.rdoSettlementDate.UseVisualStyleBackColor = true;
            // 
            // rdoTransactionDate
            // 
            this.rdoTransactionDate.AutoSize = true;
            this.rdoTransactionDate.Checked = true;
            this.rdoTransactionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoTransactionDate.IsSendTabOnEnter = true;
            this.rdoTransactionDate.Location = new System.Drawing.Point(23, 29);
            this.rdoTransactionDate.Name = "rdoTransactionDate";
            this.rdoTransactionDate.Size = new System.Drawing.Size(107, 17);
            this.rdoTransactionDate.TabIndex = 1;
            this.rdoTransactionDate.TabStop = true;
            this.rdoTransactionDate.Text = "Transaction Date";
            this.rdoTransactionDate.UseVisualStyleBackColor = true;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-3, -1);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(489, 31);
            this.tsbCRUD.TabIndex = 9;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // TLMVEW00039
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 239);
            this.Controls.Add(this.gbRemittanceListingByAmount);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00039";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TLMVEW00039";
            this.Load += new System.EventHandler(this.TLMVEW00039_Load);
            this.gbRemittanceListingByAmount.ResumeLayout(false);
            this.gbRemittanceListingByAmount.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbRemittanceListingByAmount;
        private Windows.CXClient.Controls.CXC0003 lblEncashmentEndAmount;
        private Windows.CXClient.Controls.CXC0003 lblEncashmentStartAmount;
        private Windows.CXClient.Controls.CXC0005 dtpEncashmentEndDate;
        private Windows.CXClient.Controls.CXC0003 lblEncashmentEndDate;
        private Windows.CXClient.Controls.CXC0005 dtpEncashmentStartDate;
        private Windows.CXClient.Controls.CXC0003 lblEncashmentStartDate;
        private Windows.CXClient.Controls.CXC0009 rdoSettlementDate;
        private Windows.CXClient.Controls.CXC0009 rdoTransactionDate;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0004 ntxtStartAmount;
        public Windows.CXClient.Controls.CXC0004 ntxtEndAmount;

    }
}