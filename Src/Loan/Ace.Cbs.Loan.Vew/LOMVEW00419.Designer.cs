namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00419
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00419));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblAcctNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.dtpStartDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.dtpEndDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.cxC00035 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00034 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboBranch = new Ace.Windows.CXClient.Controls.CXC0002();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.OptByAcctNo = new System.Windows.Forms.RadioButton();
            this.OptAll = new System.Windows.Forms.RadioButton();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mtxtAccountNo);
            this.groupBox1.Controls.Add(this.lblAcctNo);
            this.groupBox1.Controls.Add(this.dtpStartDate);
            this.groupBox1.Controls.Add(this.dtpEndDate);
            this.groupBox1.Controls.Add(this.cxC00035);
            this.groupBox1.Controls.Add(this.cxC00032);
            this.groupBox1.Controls.Add(this.cxC00034);
            this.groupBox1.Controls.Add(this.cboBranch);
            this.groupBox1.Location = new System.Drawing.Point(1, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 127);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(144, 14);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(181, 20);
            this.mtxtAccountNo.TabIndex = 87;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblAcctNo
            // 
            this.lblAcctNo.AutoSize = true;
            this.lblAcctNo.Location = new System.Drawing.Point(31, 17);
            this.lblAcctNo.Name = "lblAcctNo";
            this.lblAcctNo.Size = new System.Drawing.Size(70, 13);
            this.lblAcctNo.TabIndex = 86;
            this.lblAcctNo.Text = "Account No :";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.IsSendTabOnEnter = true;
            this.dtpStartDate.Location = new System.Drawing.Point(144, 41);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(115, 20);
            this.dtpStartDate.TabIndex = 79;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.IsSendTabOnEnter = true;
            this.dtpEndDate.Location = new System.Drawing.Point(144, 67);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(115, 20);
            this.dtpEndDate.TabIndex = 80;
            // 
            // cxC00035
            // 
            this.cxC00035.AutoSize = true;
            this.cxC00035.Location = new System.Drawing.Point(29, 67);
            this.cxC00035.Name = "cxC00035";
            this.cxC00035.Size = new System.Drawing.Size(58, 13);
            this.cxC00035.TabIndex = 85;
            this.cxC00035.Text = "End Date :";
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.Location = new System.Drawing.Point(29, 96);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(75, 13);
            this.cxC00032.TabIndex = 82;
            this.cxC00032.Text = "Branch Code :";
            // 
            // cxC00034
            // 
            this.cxC00034.AutoSize = true;
            this.cxC00034.Location = new System.Drawing.Point(29, 41);
            this.cxC00034.Name = "cxC00034";
            this.cxC00034.Size = new System.Drawing.Size(64, 13);
            this.cxC00034.TabIndex = 84;
            this.cxC00034.Text = "Start Date : ";
            // 
            // cboBranch
            // 
            this.cboBranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBranch.DropDownHeight = 200;
            this.cboBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBranch.FormattingEnabled = true;
            this.cboBranch.IntegralHeight = false;
            this.cboBranch.IsSendTabOnEnter = true;
            this.cboBranch.Location = new System.Drawing.Point(144, 93);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(115, 21);
            this.cboBranch.TabIndex = 83;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.OptByAcctNo);
            this.groupBox2.Controls.Add(this.OptAll);
            this.groupBox2.Location = new System.Drawing.Point(0, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(485, 46);
            this.groupBox2.TabIndex = 81;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search By :";
            // 
            // OptByAcctNo
            // 
            this.OptByAcctNo.AutoSize = true;
            this.OptByAcctNo.Location = new System.Drawing.Point(166, 20);
            this.OptByAcctNo.Name = "OptByAcctNo";
            this.OptByAcctNo.Size = new System.Drawing.Size(97, 17);
            this.OptByAcctNo.TabIndex = 1;
            this.OptByAcctNo.Text = "By Account No";
            this.OptByAcctNo.UseVisualStyleBackColor = true;
            this.OptByAcctNo.Click += new System.EventHandler(this.OptByAcctNo_Click);
            // 
            // OptAll
            // 
            this.OptAll.AutoSize = true;
            this.OptAll.Checked = true;
            this.OptAll.Location = new System.Drawing.Point(66, 20);
            this.OptAll.Name = "OptAll";
            this.OptAll.Size = new System.Drawing.Size(36, 17);
            this.OptAll.TabIndex = 0;
            this.OptAll.TabStop = true;
            this.OptAll.Text = "All";
            this.OptAll.UseVisualStyleBackColor = true;
            this.OptAll.Click += new System.EventHandler(this.OptAll_Click);
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, -2);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(488, 31);
            this.tsbCRUD.TabIndex = 78;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // LOMVEW00419
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 201);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LOMVEW00419";
            this.Text = "Business Loans Repayment History Listing";
            this.Load += new System.EventHandler(this.LOMVEW00419_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblAcctNo;
        private Windows.CXClient.Controls.CXC0003 cxC00035;
        private Windows.CXClient.Controls.CXC0003 cxC00034;
        private Windows.CXClient.Controls.CXC0002 cboBranch;
        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton OptByAcctNo;
        private System.Windows.Forms.RadioButton OptAll;
        private Windows.CXClient.Controls.CXC0005 dtpStartDate;
        private Windows.CXClient.Controls.CXC0005 dtpEndDate;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.ErrorProvider errorProvider1;

    }
}