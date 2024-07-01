namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00012
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00012));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNewTotalODLimit = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtNewODLimit = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblNewTotalODLimit = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblNewODLimit = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDateShow = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtLoanNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtPresentODLimit = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtTotalODLimit = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtOverDraftAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.gbDescription = new System.Windows.Forms.GroupBox();
            this.lblName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblDescription = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblTotalODLimit = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblPresentODLimit = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblODAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAcountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblLoanNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbDescription.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNewTotalODLimit);
            this.groupBox1.Controls.Add(this.txtNewODLimit);
            this.groupBox1.Controls.Add(this.lblNewTotalODLimit);
            this.groupBox1.Controls.Add(this.lblNewODLimit);
            this.groupBox1.Location = new System.Drawing.Point(12, 177);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(490, 70);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enter New OverDraft Limit";
            // 
            // txtNewTotalODLimit
            // 
            this.txtNewTotalODLimit.DecimalPlaces = 2;
            this.txtNewTotalODLimit.Enabled = false;
            this.txtNewTotalODLimit.IsSendTabOnEnter = true;
            this.txtNewTotalODLimit.IsThousandSeperator = true;
            this.txtNewTotalODLimit.IsUseFloatingPoint = true;
            this.txtNewTotalODLimit.Location = new System.Drawing.Point(359, 23);
            this.txtNewTotalODLimit.MaxLength = 18;
            this.txtNewTotalODLimit.Name = "txtNewTotalODLimit";
            this.txtNewTotalODLimit.Size = new System.Drawing.Size(121, 20);
            this.txtNewTotalODLimit.TabIndex = 100;
            this.txtNewTotalODLimit.Text = "0.00";
            this.txtNewTotalODLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNewTotalODLimit.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtNewODLimit
            // 
            this.txtNewODLimit.DecimalPlaces = 2;
            this.txtNewODLimit.IsSendTabOnEnter = true;
            this.txtNewODLimit.IsThousandSeperator = true;
            this.txtNewODLimit.IsUseFloatingPoint = true;
            this.txtNewODLimit.Location = new System.Drawing.Point(109, 23);
            this.txtNewODLimit.MaxLength = 18;
            this.txtNewODLimit.Name = "txtNewODLimit";
            this.txtNewODLimit.Size = new System.Drawing.Size(121, 20);
            this.txtNewODLimit.TabIndex = 2;
            this.txtNewODLimit.Text = "0.00";
            this.txtNewODLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNewODLimit.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblNewTotalODLimit
            // 
            this.lblNewTotalODLimit.AutoSize = true;
            this.lblNewTotalODLimit.Location = new System.Drawing.Point(268, 26);
            this.lblNewTotalODLimit.Name = "lblNewTotalODLimit";
            this.lblNewTotalODLimit.Size = new System.Drawing.Size(85, 13);
            this.lblNewTotalODLimit.TabIndex = 0;
            this.lblNewTotalODLimit.Text = "Total O/D Limit :";
            // 
            // lblNewODLimit
            // 
            this.lblNewODLimit.AutoSize = true;
            this.lblNewODLimit.Location = new System.Drawing.Point(6, 26);
            this.lblNewODLimit.Name = "lblNewODLimit";
            this.lblNewODLimit.Size = new System.Drawing.Size(83, 13);
            this.lblNewODLimit.TabIndex = 0;
            this.lblNewODLimit.Text = "New O/D Limit :";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(515, 31);
            this.tsbCRUD.TabIndex = 6;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDateShow);
            this.groupBox2.Controls.Add(this.txtLoanNo);
            this.groupBox2.Controls.Add(this.txtPresentODLimit);
            this.groupBox2.Controls.Add(this.txtTotalODLimit);
            this.groupBox2.Controls.Add(this.txtOverDraftAmount);
            this.groupBox2.Controls.Add(this.lblDate);
            this.groupBox2.Controls.Add(this.mtxtAccountNo);
            this.groupBox2.Controls.Add(this.gbDescription);
            this.groupBox2.Controls.Add(this.lblTotalODLimit);
            this.groupBox2.Controls.Add(this.lblPresentODLimit);
            this.groupBox2.Controls.Add(this.lblODAmount);
            this.groupBox2.Controls.Add(this.lblAcountNo);
            this.groupBox2.Controls.Add(this.lblLoanNo);
            this.groupBox2.Location = new System.Drawing.Point(12, 37);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(490, 134);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // lblDateShow
            // 
            this.lblDateShow.AutoSize = true;
            this.lblDateShow.BackColor = System.Drawing.Color.White;
            this.lblDateShow.Location = new System.Drawing.Point(409, 16);
            this.lblDateShow.Name = "lblDateShow";
            this.lblDateShow.Size = new System.Drawing.Size(56, 13);
            this.lblDateShow.TabIndex = 18;
            this.lblDateShow.Text = "DateTime ";
            // 
            // txtLoanNo
            // 
            this.txtLoanNo.IsSendTabOnEnter = true;
            this.txtLoanNo.Location = new System.Drawing.Point(109, 20);
            this.txtLoanNo.MaxLength = 15;
            this.txtLoanNo.Name = "txtLoanNo";
            this.txtLoanNo.Size = new System.Drawing.Size(121, 20);
            this.txtLoanNo.TabIndex = 1;
            this.txtLoanNo.TextChanged += new System.EventHandler(this.txtLoanNo_TextChanged);
            this.txtLoanNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLoanNo_KeyPress);
            // 
            // txtPresentODLimit
            // 
            this.txtPresentODLimit.DecimalPlaces = 2;
            this.txtPresentODLimit.Enabled = false;
            this.txtPresentODLimit.IsSendTabOnEnter = true;
            this.txtPresentODLimit.IsThousandSeperator = true;
            this.txtPresentODLimit.IsUseFloatingPoint = true;
            this.txtPresentODLimit.Location = new System.Drawing.Point(109, 98);
            this.txtPresentODLimit.MaxLength = 18;
            this.txtPresentODLimit.Name = "txtPresentODLimit";
            this.txtPresentODLimit.Size = new System.Drawing.Size(121, 20);
            this.txtPresentODLimit.TabIndex = 0;
            this.txtPresentODLimit.Text = "0.00";
            this.txtPresentODLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPresentODLimit.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtPresentODLimit.Validating += new System.ComponentModel.CancelEventHandler(this.txtPresentODLimit_Validating);
            // 
            // txtTotalODLimit
            // 
            this.txtTotalODLimit.DecimalPlaces = 2;
            this.txtTotalODLimit.Enabled = false;
            this.txtTotalODLimit.IsSendTabOnEnter = true;
            this.txtTotalODLimit.IsThousandSeperator = true;
            this.txtTotalODLimit.IsUseFloatingPoint = true;
            this.txtTotalODLimit.Location = new System.Drawing.Point(359, 98);
            this.txtTotalODLimit.MaxLength = 18;
            this.txtTotalODLimit.Name = "txtTotalODLimit";
            this.txtTotalODLimit.Size = new System.Drawing.Size(121, 20);
            this.txtTotalODLimit.TabIndex = 200;
            this.txtTotalODLimit.Text = "0.00";
            this.txtTotalODLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalODLimit.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtOverDraftAmount
            // 
            this.txtOverDraftAmount.DecimalPlaces = 2;
            this.txtOverDraftAmount.Enabled = false;
            this.txtOverDraftAmount.IsSendTabOnEnter = true;
            this.txtOverDraftAmount.IsThousandSeperator = true;
            this.txtOverDraftAmount.IsUseFloatingPoint = true;
            this.txtOverDraftAmount.Location = new System.Drawing.Point(109, 72);
            this.txtOverDraftAmount.MaxLength = 18;
            this.txtOverDraftAmount.Name = "txtOverDraftAmount";
            this.txtOverDraftAmount.Size = new System.Drawing.Size(121, 20);
            this.txtOverDraftAmount.TabIndex = 0;
            this.txtOverDraftAmount.Text = "0.00";
            this.txtOverDraftAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOverDraftAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(358, 16);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(36, 13);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "Date :";
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.Enabled = false;
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(109, 46);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(121, 20);
            this.mtxtAccountNo.TabIndex = 0;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // gbDescription
            // 
            this.gbDescription.Controls.Add(this.lblName);
            this.gbDescription.Controls.Add(this.lblDescription);
            this.gbDescription.Location = new System.Drawing.Point(275, 34);
            this.gbDescription.Name = "gbDescription";
            this.gbDescription.Size = new System.Drawing.Size(209, 54);
            this.gbDescription.TabIndex = 7;
            this.gbDescription.TabStop = false;
            this.gbDescription.Text = "Name (s)";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(16, 17);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(24, 13);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "text";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(10, 25);
            this.lblDescription.MaximumSize = new System.Drawing.Size(200, 50);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(0, 13);
            this.lblDescription.TabIndex = 0;
            // 
            // lblTotalODLimit
            // 
            this.lblTotalODLimit.AutoSize = true;
            this.lblTotalODLimit.Location = new System.Drawing.Point(268, 101);
            this.lblTotalODLimit.Name = "lblTotalODLimit";
            this.lblTotalODLimit.Size = new System.Drawing.Size(85, 13);
            this.lblTotalODLimit.TabIndex = 0;
            this.lblTotalODLimit.Text = "Total O/D Limit :";
            // 
            // lblPresentODLimit
            // 
            this.lblPresentODLimit.AutoSize = true;
            this.lblPresentODLimit.Location = new System.Drawing.Point(7, 101);
            this.lblPresentODLimit.Name = "lblPresentODLimit";
            this.lblPresentODLimit.Size = new System.Drawing.Size(97, 13);
            this.lblPresentODLimit.TabIndex = 0;
            this.lblPresentODLimit.Text = "Present O/D Limit :";
            // 
            // lblODAmount
            // 
            this.lblODAmount.AutoSize = true;
            this.lblODAmount.Location = new System.Drawing.Point(7, 75);
            this.lblODAmount.Name = "lblODAmount";
            this.lblODAmount.Size = new System.Drawing.Size(96, 13);
            this.lblODAmount.TabIndex = 0;
            this.lblODAmount.Text = "Overdraft Amount :";
            // 
            // lblAcountNo
            // 
            this.lblAcountNo.AutoSize = true;
            this.lblAcountNo.Location = new System.Drawing.Point(6, 49);
            this.lblAcountNo.Name = "lblAcountNo";
            this.lblAcountNo.Size = new System.Drawing.Size(73, 13);
            this.lblAcountNo.TabIndex = 0;
            this.lblAcountNo.Text = "Account No. :";
            // 
            // lblLoanNo
            // 
            this.lblLoanNo.AutoSize = true;
            this.lblLoanNo.Location = new System.Drawing.Point(6, 23);
            this.lblLoanNo.Name = "lblLoanNo";
            this.lblLoanNo.Size = new System.Drawing.Size(57, 13);
            this.lblLoanNo.TabIndex = 0;
            this.lblLoanNo.Text = "Loan No. :";
            // 
            // LOMVEW00012
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 258);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00012";
            this.Text = "Overdraft Limit Change Entry";
            this.Load += new System.EventHandler(this.LOMVEW00012_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbDescription.ResumeLayout(false);
            this.gbDescription.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox groupBox2;
        private Windows.CXClient.Controls.CXC0003 lblNewTotalODLimit;
        private Windows.CXClient.Controls.CXC0003 lblNewODLimit;
        private Windows.CXClient.Controls.CXC0003 lblDate;
        private Windows.CXClient.Controls.CXC0003 lblTotalODLimit;
        private Windows.CXClient.Controls.CXC0003 lblPresentODLimit;
        private Windows.CXClient.Controls.CXC0003 lblODAmount;
        private Windows.CXClient.Controls.CXC0003 lblAcountNo;
        private Windows.CXClient.Controls.CXC0003 lblLoanNo;
        private System.Windows.Forms.GroupBox gbDescription;
        private Windows.CXClient.Controls.CXC0003 lblDescription;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Windows.CXClient.Controls.CXC0004 txtNewTotalODLimit;
        private Windows.CXClient.Controls.CXC0004 txtNewODLimit;
        private Windows.CXClient.Controls.CXC0004 txtPresentODLimit;
        private Windows.CXClient.Controls.CXC0004 txtTotalODLimit;
        private Windows.CXClient.Controls.CXC0004 txtOverDraftAmount;
        private Windows.CXClient.Controls.CXC0003 lblDateShow;
        private Windows.CXClient.Controls.CXC0001 txtLoanNo;
        private Windows.CXClient.Controls.CXC0003 lblName;

    }
}