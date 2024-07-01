namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00038
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00038));
            this.rdoTransactionDate = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoSettlementDate = new Ace.Windows.CXClient.Controls.CXC0009();
            this.lblStartDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblEndDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.dtpStartDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.dtpEndDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.gbBranch = new System.Windows.Forms.GroupBox();
            this.rdoAllBranches = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoByBranch = new Ace.Windows.CXClient.Controls.CXC0009();
            this.cboBranchNo = new Ace.Windows.CXClient.Controls.CXC0002();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gbBranch.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdoTransactionDate
            // 
            this.rdoTransactionDate.AutoSize = true;
            this.rdoTransactionDate.Checked = true;
            this.rdoTransactionDate.IsSendTabOnEnter = true;
            this.rdoTransactionDate.Location = new System.Drawing.Point(19, 51);
            this.rdoTransactionDate.Name = "rdoTransactionDate";
            this.rdoTransactionDate.Size = new System.Drawing.Size(107, 17);
            this.rdoTransactionDate.TabIndex = 0;
            this.rdoTransactionDate.TabStop = true;
            this.rdoTransactionDate.Text = "Transaction Date";
            this.rdoTransactionDate.UseVisualStyleBackColor = true;
            // 
            // rdoSettlementDate
            // 
            this.rdoSettlementDate.AutoSize = true;
            this.rdoSettlementDate.IsSendTabOnEnter = true;
            this.rdoSettlementDate.Location = new System.Drawing.Point(138, 51);
            this.rdoSettlementDate.Name = "rdoSettlementDate";
            this.rdoSettlementDate.Size = new System.Drawing.Size(101, 17);
            this.rdoSettlementDate.TabIndex = 1;
            this.rdoSettlementDate.Text = "Settlement Date";
            this.rdoSettlementDate.UseVisualStyleBackColor = true;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(17, 85);
            this.lblStartDate.MaximumSize = new System.Drawing.Size(200, 50);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(61, 13);
            this.lblStartDate.TabIndex = 2;
            this.lblStartDate.Text = "Start Date :";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(17, 118);
            this.lblEndDate.MaximumSize = new System.Drawing.Size(200, 50);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(58, 13);
            this.lblEndDate.TabIndex = 4;
            this.lblEndDate.Text = "End Date :";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.IsSendTabOnEnter = true;
            this.dtpStartDate.Location = new System.Drawing.Point(138, 81);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(115, 20);
            this.dtpStartDate.TabIndex = 3;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.IsSendTabOnEnter = true;
            this.dtpEndDate.Location = new System.Drawing.Point(138, 113);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(115, 20);
            this.dtpEndDate.TabIndex = 5;
            // 
            // gbBranch
            // 
            this.gbBranch.Controls.Add(this.rdoAllBranches);
            this.gbBranch.Controls.Add(this.rdoByBranch);
            this.gbBranch.Location = new System.Drawing.Point(12, 140);
            this.gbBranch.Name = "gbBranch";
            this.gbBranch.Size = new System.Drawing.Size(106, 61);
            this.gbBranch.TabIndex = 8;
            this.gbBranch.TabStop = false;
            // 
            // rdoAllBranches
            // 
            this.rdoAllBranches.AutoSize = true;
            this.rdoAllBranches.IsSendTabOnEnter = true;
            this.rdoAllBranches.Location = new System.Drawing.Point(7, 38);
            this.rdoAllBranches.Name = "rdoAllBranches";
            this.rdoAllBranches.Size = new System.Drawing.Size(84, 17);
            this.rdoAllBranches.TabIndex = 1;
            this.rdoAllBranches.Text = "All Branches";
            this.rdoAllBranches.UseVisualStyleBackColor = true;
            this.rdoAllBranches.CheckedChanged += new System.EventHandler(this.rdoAllBranches_CheckedChanged);
            // 
            // rdoByBranch
            // 
            this.rdoByBranch.AutoSize = true;
            this.rdoByBranch.IsSendTabOnEnter = true;
            this.rdoByBranch.Location = new System.Drawing.Point(7, 14);
            this.rdoByBranch.Name = "rdoByBranch";
            this.rdoByBranch.Size = new System.Drawing.Size(74, 17);
            this.rdoByBranch.TabIndex = 0;
            this.rdoByBranch.Text = "By Branch";
            this.rdoByBranch.UseVisualStyleBackColor = true;
            this.rdoByBranch.CheckedChanged += new System.EventHandler(this.rdoByBranch_CheckedChanged);
            // 
            // cboBranchNo
            // 
            this.cboBranchNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboBranchNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBranchNo.DropDownHeight = 200;
            this.cboBranchNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBranchNo.Enabled = false;
            this.cboBranchNo.FormattingEnabled = true;
            this.cboBranchNo.IntegralHeight = false;
            this.cboBranchNo.IsSendTabOnEnter = true;
            this.cboBranchNo.Location = new System.Drawing.Point(138, 146);
            this.cboBranchNo.MaximumSize = new System.Drawing.Size(141, 0);
            this.cboBranchNo.Name = "cboBranchNo";
            this.cboBranchNo.Size = new System.Drawing.Size(115, 21);
            this.cboBranchNo.TabIndex = 6;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(500, 31);
            this.tsbCRUD.TabIndex = 59;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // TLMVEW00038
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 216);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.cboBranchNo);
            this.Controls.Add(this.gbBranch);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.rdoSettlementDate);
            this.Controls.Add(this.rdoTransactionDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00038";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.TLMVEW00038_Load);
            this.gbBranch.ResumeLayout(false);
            this.gbBranch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ace.Windows.CXClient.Controls.CXC0009 rdoTransactionDate;
        private Ace.Windows.CXClient.Controls.CXC0009 rdoSettlementDate;
        private Ace.Windows.CXClient.Controls.CXC0003 lblStartDate;
        private Ace.Windows.CXClient.Controls.CXC0003 lblEndDate;
        private Ace.Windows.CXClient.Controls.CXC0005 dtpStartDate;
        private Ace.Windows.CXClient.Controls.CXC0005 dtpEndDate;
        private System.Windows.Forms.GroupBox gbBranch;
        private Ace.Windows.CXClient.Controls.CXC0009 rdoAllBranches;
        private Ace.Windows.CXClient.Controls.CXC0009 rdoByBranch;
        private Ace.Windows.CXClient.Controls.CXC0002 cboBranchNo;
        private Ace.Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
    }
}