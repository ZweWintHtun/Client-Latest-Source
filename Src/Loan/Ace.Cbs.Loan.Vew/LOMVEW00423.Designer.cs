namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00423
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
            this.lblLoanGroup = new Ace.Windows.CXClient.Controls.CXC0003();
            this.OptByBLType = new System.Windows.Forms.RadioButton();
            this.cxC00033 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OptALL = new System.Windows.Forms.RadioButton();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cboBranch = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gpBranch = new System.Windows.Forms.GroupBox();
            this.optBranch = new System.Windows.Forms.RadioButton();
            this.optBAll = new System.Windows.Forms.RadioButton();
            this.cboLGroup = new Ace.Windows.CXClient.Controls.CXC0002();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gpBranch.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLoanGroup
            // 
            this.lblLoanGroup.AutoSize = true;
            this.lblLoanGroup.Location = new System.Drawing.Point(24, 201);
            this.lblLoanGroup.Name = "lblLoanGroup";
            this.lblLoanGroup.Size = new System.Drawing.Size(69, 13);
            this.lblLoanGroup.TabIndex = 88;
            this.lblLoanGroup.Text = "Loan Group :";
            // 
            // OptByBLType
            // 
            this.OptByBLType.AutoSize = true;
            this.OptByBLType.Location = new System.Drawing.Point(147, 19);
            this.OptByBLType.Name = "OptByBLType";
            this.OptByBLType.Size = new System.Drawing.Size(101, 17);
            this.OptByBLType.TabIndex = 1;
            this.OptByBLType.Text = "By Loans Group";
            this.OptByBLType.UseVisualStyleBackColor = true;
            this.OptByBLType.CheckedChanged += new System.EventHandler(this.OptByBLType_CheckedChanged);
            // 
            // cxC00033
            // 
            this.cxC00033.AutoSize = true;
            this.cxC00033.Location = new System.Drawing.Point(24, 174);
            this.cxC00033.Name = "cxC00033";
            this.cxC00033.Size = new System.Drawing.Size(55, 13);
            this.cxC00033.TabIndex = 85;
            this.cxC00033.Text = "Currency :";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.OptByBLType);
            this.groupBox1.Controls.Add(this.OptALL);
            this.groupBox1.Location = new System.Drawing.Point(5, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 55);
            this.groupBox1.TabIndex = 87;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search By:";
            // 
            // OptALL
            // 
            this.OptALL.AutoSize = true;
            this.OptALL.Checked = true;
            this.OptALL.Location = new System.Drawing.Point(33, 19);
            this.OptALL.Name = "OptALL";
            this.OptALL.Size = new System.Drawing.Size(36, 17);
            this.OptALL.TabIndex = 0;
            this.OptALL.TabStop = true;
            this.OptALL.Text = "All";
            this.OptALL.UseVisualStyleBackColor = true;
            this.OptALL.CheckedChanged += new System.EventHandler(this.OptALL_CheckedChanged);
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
            this.cboCurrency.Location = new System.Drawing.Point(124, 171);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 86;
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
            this.cboBranch.Location = new System.Drawing.Point(119, 42);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(115, 21);
            this.cboBranch.TabIndex = 84;
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(19, 42);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(75, 13);
            this.cxC00031.TabIndex = 83;
            this.cxC00031.Text = "Branch Code :";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(495, 31);
            this.tsbCRUD.TabIndex = 82;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // gpBranch
            // 
            this.gpBranch.Controls.Add(this.optBranch);
            this.gpBranch.Controls.Add(this.optBAll);
            this.gpBranch.Controls.Add(this.cboBranch);
            this.gpBranch.Controls.Add(this.cxC00031);
            this.gpBranch.Location = new System.Drawing.Point(5, 94);
            this.gpBranch.Name = "gpBranch";
            this.gpBranch.Size = new System.Drawing.Size(481, 71);
            this.gpBranch.TabIndex = 90;
            this.gpBranch.TabStop = false;
            this.gpBranch.Text = "Branch :";
            // 
            // optBranch
            // 
            this.optBranch.AutoSize = true;
            this.optBranch.Location = new System.Drawing.Point(147, 19);
            this.optBranch.Name = "optBranch";
            this.optBranch.Size = new System.Drawing.Size(87, 17);
            this.optBranch.TabIndex = 1;
            this.optBranch.Text = "Branch Code";
            this.optBranch.UseVisualStyleBackColor = true;
            this.optBranch.CheckedChanged += new System.EventHandler(this.optBranch_CheckedChanged);
            // 
            // optBAll
            // 
            this.optBAll.AutoSize = true;
            this.optBAll.Checked = true;
            this.optBAll.Location = new System.Drawing.Point(33, 19);
            this.optBAll.Name = "optBAll";
            this.optBAll.Size = new System.Drawing.Size(36, 17);
            this.optBAll.TabIndex = 0;
            this.optBAll.TabStop = true;
            this.optBAll.Text = "All";
            this.optBAll.UseVisualStyleBackColor = true;
            this.optBAll.CheckedChanged += new System.EventHandler(this.opBAll_CheckedChanged);
            // 
            // cboLGroup
            // 
            this.cboLGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboLGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboLGroup.DropDownHeight = 200;
            this.cboLGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLGroup.FormattingEnabled = true;
            this.cboLGroup.IntegralHeight = false;
            this.cboLGroup.IsSendTabOnEnter = true;
            this.cboLGroup.Location = new System.Drawing.Point(124, 198);
            this.cboLGroup.Name = "cboLGroup";
            this.cboLGroup.Size = new System.Drawing.Size(115, 21);
            this.cboLGroup.TabIndex = 91;
            // 
            // LOMVEW00423
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 229);
            this.Controls.Add(this.cboLGroup);
            this.Controls.Add(this.gpBranch);
            this.Controls.Add(this.lblLoanGroup);
            this.Controls.Add(this.cxC00033);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.tsbCRUD);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LOMVEW00423";
            this.Text = "Business Loan Daily Position Report";
            this.Load += new System.EventHandler(this.LOMVEW00423_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpBranch.ResumeLayout(false);
            this.gpBranch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0003 lblLoanGroup;
        private System.Windows.Forms.RadioButton OptByBLType;
        private Windows.CXClient.Controls.CXC0003 cxC00033;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton OptALL;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0002 cboBranch;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox gpBranch;
        private System.Windows.Forms.RadioButton optBranch;
        private System.Windows.Forms.RadioButton optBAll;
        private Windows.CXClient.Controls.CXC0002 cboLGroup;
    }
}