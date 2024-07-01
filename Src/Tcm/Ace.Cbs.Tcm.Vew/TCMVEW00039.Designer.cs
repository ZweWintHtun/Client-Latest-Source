namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00039
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00039));
            this.rdoIssuedCheque = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoStoppedCheque = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoPrintedCheque = new Ace.Windows.CXClient.Controls.CXC0009();
            this.cboRequiredType = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblRequiredType = new Ace.Windows.CXClient.Controls.CXC0003();
            this.dtpEndDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblAcctNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.grpChequeBookListing = new System.Windows.Forms.GroupBox();
            this.grpChequeBookListing.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdoIssuedCheque
            // 
            this.rdoIssuedCheque.AutoSize = true;
            this.rdoIssuedCheque.CausesValidation = false;
            this.rdoIssuedCheque.Checked = true;
            this.rdoIssuedCheque.IsSendTabOnEnter = true;
            this.rdoIssuedCheque.Location = new System.Drawing.Point(19, 27);
            this.rdoIssuedCheque.Name = "rdoIssuedCheque";
            this.rdoIssuedCheque.Size = new System.Drawing.Size(96, 17);
            this.rdoIssuedCheque.TabIndex = 2;
            this.rdoIssuedCheque.TabStop = true;
            this.rdoIssuedCheque.Text = "Issued Cheque";
            this.rdoIssuedCheque.UseVisualStyleBackColor = true;
            this.rdoIssuedCheque.CheckedChanged += new System.EventHandler(this.rdoChequeType_CheckedChanged);
            // 
            // rdoStoppedCheque
            // 
            this.rdoStoppedCheque.AutoSize = true;
            this.rdoStoppedCheque.CausesValidation = false;
            this.rdoStoppedCheque.IsSendTabOnEnter = true;
            this.rdoStoppedCheque.Location = new System.Drawing.Point(121, 27);
            this.rdoStoppedCheque.Name = "rdoStoppedCheque";
            this.rdoStoppedCheque.Size = new System.Drawing.Size(105, 17);
            this.rdoStoppedCheque.TabIndex = 3;
            this.rdoStoppedCheque.Text = "Stopped Cheque";
            this.rdoStoppedCheque.UseVisualStyleBackColor = true;
            this.rdoStoppedCheque.CheckedChanged += new System.EventHandler(this.rdoChequeType_CheckedChanged);
            // 
            // rdoPrintedCheque
            // 
            this.rdoPrintedCheque.AutoSize = true;
            this.rdoPrintedCheque.CausesValidation = false;
            this.rdoPrintedCheque.IsSendTabOnEnter = true;
            this.rdoPrintedCheque.Location = new System.Drawing.Point(232, 27);
            this.rdoPrintedCheque.Name = "rdoPrintedCheque";
            this.rdoPrintedCheque.Size = new System.Drawing.Size(98, 17);
            this.rdoPrintedCheque.TabIndex = 4;
            this.rdoPrintedCheque.Text = "Printed Cheque";
            this.rdoPrintedCheque.UseVisualStyleBackColor = true;
            this.rdoPrintedCheque.CheckedChanged += new System.EventHandler(this.rdoChequeType_CheckedChanged);
            // 
            // cboRequiredType
            // 
            this.cboRequiredType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboRequiredType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRequiredType.DropDownHeight = 200;
            this.cboRequiredType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRequiredType.FormattingEnabled = true;
            this.cboRequiredType.IntegralHeight = false;
            this.cboRequiredType.IsSendTabOnEnter = true;
            this.cboRequiredType.Items.AddRange(new object[] {
            "By Date",
            "By Account"});
            this.cboRequiredType.Location = new System.Drawing.Point(118, 109);
            this.cboRequiredType.Name = "cboRequiredType";
            this.cboRequiredType.Size = new System.Drawing.Size(115, 21);
            this.cboRequiredType.TabIndex = 5;
            this.cboRequiredType.SelectedIndexChanged += new System.EventHandler(this.cboRequiredType_SelectedIndexChanged);
            // 
            // lblRequiredType
            // 
            this.lblRequiredType.AutoSize = true;
            this.lblRequiredType.Location = new System.Drawing.Point(15, 109);
            this.lblRequiredType.Name = "lblRequiredType";
            this.lblRequiredType.Size = new System.Drawing.Size(83, 13);
            this.lblRequiredType.TabIndex = 5;
            this.lblRequiredType.Text = "Required Type :";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CausesValidation = false;
            this.dtpEndDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.IsSendTabOnEnter = true;
            this.dtpEndDate.Location = new System.Drawing.Point(118, 161);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(115, 20);
            this.dtpEndDate.TabIndex = 8;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(15, 161);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(58, 13);
            this.lblEndDate.TabIndex = 120;
            this.lblEndDate.Text = "End Date :";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CausesValidation = false;
            this.dtpStartDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.IsSendTabOnEnter = true;
            this.dtpStartDate.Location = new System.Drawing.Point(118, 137);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(115, 20);
            this.dtpStartDate.TabIndex = 7;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(15, 136);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(61, 13);
            this.lblStartDate.TabIndex = 118;
            this.lblStartDate.Text = "Start Date :";
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(118, 136);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 6;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblAcctNo
            // 
            this.lblAcctNo.AutoSize = true;
            this.lblAcctNo.Location = new System.Drawing.Point(15, 135);
            this.lblAcctNo.Name = "lblAcctNo";
            this.lblAcctNo.Size = new System.Drawing.Size(70, 13);
            this.lblAcctNo.TabIndex = 122;
            this.lblAcctNo.Text = "Account No :";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, -1);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(496, 31);
            this.tsbCRUD.TabIndex = 9;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // grpChequeBookListing
            // 
            this.grpChequeBookListing.Controls.Add(this.rdoIssuedCheque);
            this.grpChequeBookListing.Controls.Add(this.rdoStoppedCheque);
            this.grpChequeBookListing.Controls.Add(this.rdoPrintedCheque);
            this.grpChequeBookListing.Location = new System.Drawing.Point(18, 36);
            this.grpChequeBookListing.Name = "grpChequeBookListing";
            this.grpChequeBookListing.Size = new System.Drawing.Size(344, 64);
            this.grpChequeBookListing.TabIndex = 1;
            this.grpChequeBookListing.TabStop = false;
            this.grpChequeBookListing.Text = "Choose Type of Cheque :";
            // 
            // TCMVEW00039
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 218);
            this.Controls.Add(this.grpChequeBookListing);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.mtxtAccountNo);
            this.Controls.Add(this.lblAcctNo);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.cboRequiredType);
            this.Controls.Add(this.lblRequiredType);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TCMVEW00039";
            this.Text = "Cheque Listing";
            this.Load += new System.EventHandler(this.TCMVEW00039_Load);
            this.grpChequeBookListing.ResumeLayout(false);
            this.grpChequeBookListing.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0009 rdoIssuedCheque;
        private Windows.CXClient.Controls.CXC0009 rdoStoppedCheque;
        private Windows.CXClient.Controls.CXC0009 rdoPrintedCheque;
        private Windows.CXClient.Controls.CXC0002 cboRequiredType;
        private Windows.CXClient.Controls.CXC0003 lblRequiredType;
        private Windows.CXClient.Controls.CXC0005 dtpEndDate;
        private System.Windows.Forms.Label lblEndDate;
        private Windows.CXClient.Controls.CXC0005 dtpStartDate;
        private System.Windows.Forms.Label lblStartDate;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblAcctNo;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox grpChequeBookListing;
    }
}