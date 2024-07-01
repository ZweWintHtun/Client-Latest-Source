namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00152
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00152));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.grpRenewalStatus = new System.Windows.Forms.GroupBox();
            this.rdoAll = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoPrincipleAndInterest = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoOnlyPrinciple = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoNotAuto = new Ace.Windows.CXClient.Controls.CXC0009();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblStartDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.dtpStartDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.lblEndDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.dtpEndDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.grpRenewalStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, -2);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(495, 31);
            this.tsbCRUD.TabIndex = 10;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // grpRenewalStatus
            // 
            this.grpRenewalStatus.Controls.Add(this.rdoAll);
            this.grpRenewalStatus.Controls.Add(this.rdoPrincipleAndInterest);
            this.grpRenewalStatus.Controls.Add(this.rdoOnlyPrinciple);
            this.grpRenewalStatus.Controls.Add(this.rdoNotAuto);
            this.grpRenewalStatus.Location = new System.Drawing.Point(28, 45);
            this.grpRenewalStatus.Name = "grpRenewalStatus";
            this.grpRenewalStatus.Size = new System.Drawing.Size(279, 94);
            this.grpRenewalStatus.TabIndex = 11;
            this.grpRenewalStatus.TabStop = false;
            this.grpRenewalStatus.Text = "Renewal Status :";
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Checked = true;
            this.rdoAll.IsSendTabOnEnter = true;
            this.rdoAll.Location = new System.Drawing.Point(167, 57);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(36, 17);
            this.rdoAll.TabIndex = 8;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "All";
            this.rdoAll.UseVisualStyleBackColor = true;
            // 
            // rdoPrincipleAndInterest
            // 
            this.rdoPrincipleAndInterest.AutoSize = true;
            this.rdoPrincipleAndInterest.IsSendTabOnEnter = true;
            this.rdoPrincipleAndInterest.Location = new System.Drawing.Point(21, 27);
            this.rdoPrincipleAndInterest.Name = "rdoPrincipleAndInterest";
            this.rdoPrincipleAndInterest.Size = new System.Drawing.Size(125, 17);
            this.rdoPrincipleAndInterest.TabIndex = 5;
            this.rdoPrincipleAndInterest.Text = "Principle And Interest";
            this.rdoPrincipleAndInterest.UseVisualStyleBackColor = true;
            // 
            // rdoOnlyPrinciple
            // 
            this.rdoOnlyPrinciple.AutoSize = true;
            this.rdoOnlyPrinciple.IsSendTabOnEnter = true;
            this.rdoOnlyPrinciple.Location = new System.Drawing.Point(167, 27);
            this.rdoOnlyPrinciple.Name = "rdoOnlyPrinciple";
            this.rdoOnlyPrinciple.Size = new System.Drawing.Size(89, 17);
            this.rdoOnlyPrinciple.TabIndex = 6;
            this.rdoOnlyPrinciple.Text = "Only Principle";
            this.rdoOnlyPrinciple.UseVisualStyleBackColor = true;
            // 
            // rdoNotAuto
            // 
            this.rdoNotAuto.AutoSize = true;
            this.rdoNotAuto.IsSendTabOnEnter = true;
            this.rdoNotAuto.Location = new System.Drawing.Point(21, 57);
            this.rdoNotAuto.Name = "rdoNotAuto";
            this.rdoNotAuto.Size = new System.Drawing.Size(112, 17);
            this.rdoNotAuto.TabIndex = 7;
            this.rdoNotAuto.Text = "Not Auto Renewal";
            this.rdoNotAuto.UseVisualStyleBackColor = true;
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(46, 151);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 81;
            this.lblCurrency.Text = "Currency :";
            // 
            // cboCurrency
            // 
            this.cboCurrency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCurrency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCurrency.DropDownHeight = 200;
            this.cboCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrency.FormattingEnabled = true;
            this.cboCurrency.IntegralHeight = false;
            this.cboCurrency.IsSendTabOnEnter = true;
            this.cboCurrency.Location = new System.Drawing.Point(149, 151);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(121, 21);
            this.cboCurrency.TabIndex = 82;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(46, 177);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(61, 13);
            this.lblStartDate.TabIndex = 83;
            this.lblStartDate.Text = "Start Date :";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.IsSendTabOnEnter = true;
            this.dtpStartDate.Location = new System.Drawing.Point(149, 178);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(121, 20);
            this.dtpStartDate.TabIndex = 84;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(46, 205);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(58, 13);
            this.lblEndDate.TabIndex = 85;
            this.lblEndDate.Text = "End Date :";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.IsSendTabOnEnter = true;
            this.dtpEndDate.Location = new System.Drawing.Point(149, 205);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(121, 20);
            this.dtpEndDate.TabIndex = 86;
            // 
            // MNMVEW00152
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 233);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.lblCurrency);
            this.Controls.Add(this.grpRenewalStatus);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00152";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fixed Auto Renewal Status Listing";
            this.Load += new System.EventHandler(this.MNMVEW00152_Load);
            this.grpRenewalStatus.ResumeLayout(false);
            this.grpRenewalStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox grpRenewalStatus;
        private Windows.CXClient.Controls.CXC0009 rdoAll;
        private Windows.CXClient.Controls.CXC0009 rdoPrincipleAndInterest;
        private Windows.CXClient.Controls.CXC0009 rdoOnlyPrinciple;
        private Windows.CXClient.Controls.CXC0009 rdoNotAuto;
        private Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0003 lblStartDate;
        private Windows.CXClient.Controls.CXC0005 dtpStartDate;
        private Windows.CXClient.Controls.CXC0003 lblEndDate;
        private Windows.CXClient.Controls.CXC0005 dtpEndDate;
    }
}