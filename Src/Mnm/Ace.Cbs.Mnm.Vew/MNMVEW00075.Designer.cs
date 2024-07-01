﻿namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00075
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00075));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblEndDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.grpSortBy = new System.Windows.Forms.GroupBox();
            this.rdoSettlementDate = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoTransactionDate = new Ace.Windows.CXClient.Controls.CXC0009();
            this.lblStartDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.dtpStartDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.dtpEndDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.lblRequiredYear = new Ace.Windows.CXClient.Controls.CXC0003();
            this.grpSortBy.SuspendLayout();
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
            this.tsbCRUD.Size = new System.Drawing.Size(496, 31);
            this.tsbCRUD.TabIndex = 46;
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(9, 139);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(58, 13);
            this.lblEndDate.TabIndex = 55;
            this.lblEndDate.Text = "End Date :";
            // 
            // grpSortBy
            // 
            this.grpSortBy.Controls.Add(this.rdoSettlementDate);
            this.grpSortBy.Controls.Add(this.rdoTransactionDate);
            this.grpSortBy.Location = new System.Drawing.Point(8, 39);
            this.grpSortBy.Name = "grpSortBy";
            this.grpSortBy.Size = new System.Drawing.Size(265, 59);
            this.grpSortBy.TabIndex = 52;
            this.grpSortBy.TabStop = false;
            this.grpSortBy.Text = "Sort By :";
            // 
            // rdoSettlementDate
            // 
            this.rdoSettlementDate.AutoSize = true;
            this.rdoSettlementDate.IsSendTabOnEnter = true;
            this.rdoSettlementDate.Location = new System.Drawing.Point(141, 27);
            this.rdoSettlementDate.Name = "rdoSettlementDate";
            this.rdoSettlementDate.Size = new System.Drawing.Size(104, 17);
            this.rdoSettlementDate.TabIndex = 0;
            this.rdoSettlementDate.Text = "Settlement Date ";
            this.rdoSettlementDate.UseVisualStyleBackColor = true;
            // 
            // rdoTransactionDate
            // 
            this.rdoTransactionDate.AutoSize = true;
            this.rdoTransactionDate.Checked = true;
            this.rdoTransactionDate.IsSendTabOnEnter = true;
            this.rdoTransactionDate.Location = new System.Drawing.Point(20, 27);
            this.rdoTransactionDate.Name = "rdoTransactionDate";
            this.rdoTransactionDate.Size = new System.Drawing.Size(107, 17);
            this.rdoTransactionDate.TabIndex = 0;
            this.rdoTransactionDate.TabStop = true;
            this.rdoTransactionDate.Text = "Transaction Date";
            this.rdoTransactionDate.UseVisualStyleBackColor = true;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(9, 113);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(61, 13);
            this.lblStartDate.TabIndex = 56;
            this.lblStartDate.Text = "Start Date :";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.IsSendTabOnEnter = true;
            this.dtpStartDate.Location = new System.Drawing.Point(97, 110);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(115, 20);
            this.dtpStartDate.TabIndex = 54;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.IsSendTabOnEnter = true;
            this.dtpEndDate.Location = new System.Drawing.Point(97, 136);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(115, 20);
            this.dtpEndDate.TabIndex = 53;
            // 
            // lblRequiredYear
            // 
            this.lblRequiredYear.AutoSize = true;
            this.lblRequiredYear.Location = new System.Drawing.Point(25, 79);
            this.lblRequiredYear.Name = "lblRequiredYear";
            this.lblRequiredYear.Size = new System.Drawing.Size(94, 13);
            this.lblRequiredYear.TabIndex = 50;
            this.lblRequiredYear.Text = "Required &Date     :";
            // 
            // MNMVEW00075
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 184);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.grpSortBy);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.lblRequiredYear);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00075";
            this.Text = "Internal Remittance";
            this.Load += new System.EventHandler(this.MNMVEW00075_Load);
            this.grpSortBy.ResumeLayout(false);
            this.grpSortBy.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0003 lblEndDate;
        private System.Windows.Forms.GroupBox grpSortBy;
        private Windows.CXClient.Controls.CXC0009 rdoSettlementDate;
        private Windows.CXClient.Controls.CXC0009 rdoTransactionDate;
        private Windows.CXClient.Controls.CXC0003 lblStartDate;
        private Windows.CXClient.Controls.CXC0005 dtpStartDate;
        private Windows.CXClient.Controls.CXC0005 dtpEndDate;
        private Windows.CXClient.Controls.CXC0003 lblRequiredYear;
    }
}