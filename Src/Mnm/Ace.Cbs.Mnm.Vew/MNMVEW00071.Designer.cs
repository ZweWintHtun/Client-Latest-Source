namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00071
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00071));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblEndDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblStartDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.dtpEndDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.dtpStartDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.grpSortBy = new System.Windows.Forms.GroupBox();
            this.rdoOutstanding = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoWithdraw = new Ace.Windows.CXClient.Controls.CXC0009();
            this.gbWithdrawType = new System.Windows.Forms.GroupBox();
            this.rdoTransfer = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoCash = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoAllWithdraw = new Ace.Windows.CXClient.Controls.CXC0009();
            this.grpSortBy.SuspendLayout();
            this.gbWithdrawType.SuspendLayout();
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
            this.tsbCRUD.Size = new System.Drawing.Size(489, 31);
            this.tsbCRUD.TabIndex = 33;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(8, 70);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(73, 13);
            this.lblEndDate.TabIndex = 40;
            this.lblEndDate.Text = "End Date      :";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(8, 44);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(73, 13);
            this.lblStartDate.TabIndex = 41;
            this.lblStartDate.Text = "Start Date     :";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.IsSendTabOnEnter = true;
            this.dtpEndDate.Location = new System.Drawing.Point(104, 67);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(115, 20);
            this.dtpEndDate.TabIndex = 2;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.IsSendTabOnEnter = true;
            this.dtpStartDate.Location = new System.Drawing.Point(104, 41);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(115, 20);
            this.dtpStartDate.TabIndex = 1;
            // 
            // grpSortBy
            // 
            this.grpSortBy.Controls.Add(this.rdoOutstanding);
            this.grpSortBy.Controls.Add(this.rdoWithdraw);
            this.grpSortBy.Location = new System.Drawing.Point(12, 99);
            this.grpSortBy.Name = "grpSortBy";
            this.grpSortBy.Size = new System.Drawing.Size(249, 52);
            this.grpSortBy.TabIndex = 3;
            this.grpSortBy.TabStop = false;
            this.grpSortBy.Text = "Sort By :";
            // 
            // rdoOutstanding
            // 
            this.rdoOutstanding.AutoSize = true;
            this.rdoOutstanding.IsSendTabOnEnter = true;
            this.rdoOutstanding.Location = new System.Drawing.Point(125, 23);
            this.rdoOutstanding.Name = "rdoOutstanding";
            this.rdoOutstanding.Size = new System.Drawing.Size(82, 17);
            this.rdoOutstanding.TabIndex = 5;
            this.rdoOutstanding.Text = "Outstanding";
            this.rdoOutstanding.UseVisualStyleBackColor = true;
            this.rdoOutstanding.CheckedChanged += new System.EventHandler(this.cxC00092_CheckedChanged);
            // 
            // rdoWithdraw
            // 
            this.rdoWithdraw.AutoSize = true;
            this.rdoWithdraw.Checked = true;
            this.rdoWithdraw.IsSendTabOnEnter = true;
            this.rdoWithdraw.Location = new System.Drawing.Point(21, 23);
            this.rdoWithdraw.Name = "rdoWithdraw";
            this.rdoWithdraw.Size = new System.Drawing.Size(70, 17);
            this.rdoWithdraw.TabIndex = 4;
            this.rdoWithdraw.TabStop = true;
            this.rdoWithdraw.Text = "Withdraw";
            this.rdoWithdraw.UseVisualStyleBackColor = true;
            this.rdoWithdraw.CheckedChanged += new System.EventHandler(this.cxC00091_CheckedChanged);
            // 
            // gbWithdrawType
            // 
            this.gbWithdrawType.Controls.Add(this.rdoTransfer);
            this.gbWithdrawType.Controls.Add(this.rdoCash);
            this.gbWithdrawType.Controls.Add(this.rdoAllWithdraw);
            this.gbWithdrawType.Location = new System.Drawing.Point(12, 161);
            this.gbWithdrawType.Name = "gbWithdrawType";
            this.gbWithdrawType.Size = new System.Drawing.Size(249, 114);
            this.gbWithdrawType.TabIndex = 6;
            this.gbWithdrawType.TabStop = false;
            this.gbWithdrawType.Text = "Choose Withdraw Type :";
            // 
            // rdoTransfer
            // 
            this.rdoTransfer.AutoSize = true;
            this.rdoTransfer.IsSendTabOnEnter = true;
            this.rdoTransfer.Location = new System.Drawing.Point(21, 83);
            this.rdoTransfer.Name = "rdoTransfer";
            this.rdoTransfer.Size = new System.Drawing.Size(79, 17);
            this.rdoTransfer.TabIndex = 9;
            this.rdoTransfer.Text = "By Transfer";
            this.rdoTransfer.UseVisualStyleBackColor = true;
            // 
            // rdoCash
            // 
            this.rdoCash.AutoSize = true;
            this.rdoCash.IsSendTabOnEnter = true;
            this.rdoCash.Location = new System.Drawing.Point(21, 54);
            this.rdoCash.Name = "rdoCash";
            this.rdoCash.Size = new System.Drawing.Size(64, 17);
            this.rdoCash.TabIndex = 8;
            this.rdoCash.Text = "By Cash";
            this.rdoCash.UseVisualStyleBackColor = true;
            // 
            // rdoAllWithdraw
            // 
            this.rdoAllWithdraw.AutoSize = true;
            this.rdoAllWithdraw.Checked = true;
            this.rdoAllWithdraw.IsSendTabOnEnter = true;
            this.rdoAllWithdraw.Location = new System.Drawing.Point(21, 25);
            this.rdoAllWithdraw.Name = "rdoAllWithdraw";
            this.rdoAllWithdraw.Size = new System.Drawing.Size(84, 17);
            this.rdoAllWithdraw.TabIndex = 7;
            this.rdoAllWithdraw.TabStop = true;
            this.rdoAllWithdraw.Text = "All Withdraw\r\n";
            this.rdoAllWithdraw.UseVisualStyleBackColor = true;
            // 
            // MNMVEW00071
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 290);
            this.Controls.Add(this.gbWithdrawType);
            this.Controls.Add(this.grpSortBy);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.tsbCRUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MNMVEW00071";
            this.Text = "Saving Accrued Interest Listing";
            this.Load += new System.EventHandler(this.MNMVEW00071_Load);
            this.grpSortBy.ResumeLayout(false);
            this.grpSortBy.PerformLayout();
            this.gbWithdrawType.ResumeLayout(false);
            this.gbWithdrawType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0003 lblEndDate;
        private Windows.CXClient.Controls.CXC0003 lblStartDate;
        private Windows.CXClient.Controls.CXC0005 dtpEndDate;
        private Windows.CXClient.Controls.CXC0005 dtpStartDate;
        private System.Windows.Forms.GroupBox grpSortBy;
        private Windows.CXClient.Controls.CXC0009 rdoOutstanding;
        private Windows.CXClient.Controls.CXC0009 rdoWithdraw;
        private System.Windows.Forms.GroupBox gbWithdrawType;
        private Windows.CXClient.Controls.CXC0009 rdoTransfer;
        private Windows.CXClient.Controls.CXC0009 rdoCash;
        private Windows.CXClient.Controls.CXC0009 rdoAllWithdraw;
    }
}