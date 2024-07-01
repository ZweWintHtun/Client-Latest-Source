namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00015
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00015));
            this.gvNPLReleaseVoucher = new Ace.Windows.CXClient.Controls.AceGridView();
            this.ColAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCRDR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblLoanNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAccountType = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblMakingDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtLoanNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtAccountType = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblUser = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblNPLReleaseVoucher = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblTodayDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblUserName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtMakingDate = new Ace.Windows.CXClient.Controls.CXC0001();
            ((System.ComponentModel.ISupportInitialize)(this.gvNPLReleaseVoucher)).BeginInit();
            this.SuspendLayout();
            // 
            // gvNPLReleaseVoucher
            // 
            this.gvNPLReleaseVoucher.AllowUserToAddRows = false;
            this.gvNPLReleaseVoucher.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvNPLReleaseVoucher.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvNPLReleaseVoucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvNPLReleaseVoucher.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColAccountNo,
            this.ColDescription,
            this.ColAmount,
            this.colCRDR});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvNPLReleaseVoucher.DefaultCellStyle = dataGridViewCellStyle5;
            this.gvNPLReleaseVoucher.EnableHeadersVisualStyles = false;
            this.gvNPLReleaseVoucher.IdTSList = null;
            this.gvNPLReleaseVoucher.IsEscapeKey = false;
            this.gvNPLReleaseVoucher.IsHeaderClick = false;
            this.gvNPLReleaseVoucher.Location = new System.Drawing.Point(14, 174);
            this.gvNPLReleaseVoucher.Name = "gvNPLReleaseVoucher";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvNPLReleaseVoucher.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gvNPLReleaseVoucher.RowHeadersWidth = 25;
            this.gvNPLReleaseVoucher.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvNPLReleaseVoucher.ShowSerialNo = false;
            this.gvNPLReleaseVoucher.Size = new System.Drawing.Size(559, 176);
            this.gvNPLReleaseVoucher.TabIndex = 7;
            // 
            // ColAccountNo
            // 
            this.ColAccountNo.DataPropertyName = "AcctNo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ColAccountNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColAccountNo.HeaderText = "Account";
            this.ColAccountNo.Name = "ColAccountNo";
            this.ColAccountNo.ReadOnly = true;
            this.ColAccountNo.Width = 130;
            // 
            // ColDescription
            // 
            this.ColDescription.DataPropertyName = "Narration";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ColDescription.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColDescription.HeaderText = "Description";
            this.ColDescription.Name = "ColDescription";
            this.ColDescription.Width = 180;
            // 
            // ColAmount
            // 
            this.ColAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ColAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColAmount.HeaderText = "Amount";
            this.ColAmount.Name = "ColAmount";
            this.ColAmount.ReadOnly = true;
            this.ColAmount.Width = 130;
            // 
            // colCRDR
            // 
            this.colCRDR.DataPropertyName = "AType";
            this.colCRDR.HeaderText = "CR/DR";
            this.colCRDR.Name = "colCRDR";
            this.colCRDR.Width = 70;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-2, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(597, 31);
            this.tsbCRUD.TabIndex = 2;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblLoanNo
            // 
            this.lblLoanNo.AutoSize = true;
            this.lblLoanNo.Location = new System.Drawing.Point(13, 46);
            this.lblLoanNo.Name = "lblLoanNo";
            this.lblLoanNo.Size = new System.Drawing.Size(57, 13);
            this.lblLoanNo.TabIndex = 0;
            this.lblLoanNo.Text = "Loan No. :";
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(13, 72);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(73, 13);
            this.cxC00031.TabIndex = 0;
            this.cxC00031.Text = "Account No. :";
            // 
            // lblAccountType
            // 
            this.lblAccountType.AutoSize = true;
            this.lblAccountType.Location = new System.Drawing.Point(13, 98);
            this.lblAccountType.Name = "lblAccountType";
            this.lblAccountType.Size = new System.Drawing.Size(80, 13);
            this.lblAccountType.TabIndex = 0;
            this.lblAccountType.Text = "Account Type :";
            // 
            // lblMakingDate
            // 
            this.lblMakingDate.AutoSize = true;
            this.lblMakingDate.Location = new System.Drawing.Point(13, 125);
            this.lblMakingDate.Name = "lblMakingDate";
            this.lblMakingDate.Size = new System.Drawing.Size(74, 13);
            this.lblMakingDate.TabIndex = 0;
            this.lblMakingDate.Text = "Making Date :";
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.Enabled = false;
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(100, 69);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 0;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtLoanNo
            // 
            this.txtLoanNo.IsSendTabOnEnter = true;
            this.txtLoanNo.Location = new System.Drawing.Point(100, 43);
            this.txtLoanNo.MaxLength = 15;
            this.txtLoanNo.Name = "txtLoanNo";
            this.txtLoanNo.Size = new System.Drawing.Size(121, 20);
            this.txtLoanNo.TabIndex = 1;
            this.txtLoanNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLoanNo_KeyPress);
            // 
            // txtAccountType
            // 
            this.txtAccountType.Enabled = false;
            this.txtAccountType.IsSendTabOnEnter = true;
            this.txtAccountType.Location = new System.Drawing.Point(100, 95);
            this.txtAccountType.Name = "txtAccountType";
            this.txtAccountType.Size = new System.Drawing.Size(141, 20);
            this.txtAccountType.TabIndex = 0;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblDate.Location = new System.Drawing.Point(319, 43);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(36, 13);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Date :";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblUser.Location = new System.Drawing.Point(319, 67);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(35, 13);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "User :";
            // 
            // lblNPLReleaseVoucher
            // 
            this.lblNPLReleaseVoucher.AutoSize = true;
            this.lblNPLReleaseVoucher.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblNPLReleaseVoucher.Location = new System.Drawing.Point(14, 156);
            this.lblNPLReleaseVoucher.Name = "lblNPLReleaseVoucher";
            this.lblNPLReleaseVoucher.Size = new System.Drawing.Size(119, 13);
            this.lblNPLReleaseVoucher.TabIndex = 0;
            this.lblNPLReleaseVoucher.Text = "NPL Release Voucher :";
            // 
            // lblTodayDate
            // 
            this.lblTodayDate.AutoSize = true;
            this.lblTodayDate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblTodayDate.Location = new System.Drawing.Point(361, 43);
            this.lblTodayDate.Name = "lblTodayDate";
            this.lblTodayDate.Size = new System.Drawing.Size(10, 13);
            this.lblTodayDate.TabIndex = 0;
            this.lblTodayDate.Text = "-";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblUserName.Location = new System.Drawing.Point(361, 67);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(10, 13);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "-";
            // 
            // txtMakingDate
            // 
            this.txtMakingDate.Enabled = false;
            this.txtMakingDate.IsSendTabOnEnter = true;
            this.txtMakingDate.Location = new System.Drawing.Point(100, 121);
            this.txtMakingDate.Name = "txtMakingDate";
            this.txtMakingDate.Size = new System.Drawing.Size(121, 20);
            this.txtMakingDate.TabIndex = 0;
            // 
            // LOMVEW00015
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 367);
            this.Controls.Add(this.txtMakingDate);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblTodayDate);
            this.Controls.Add(this.lblNPLReleaseVoucher);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtAccountType);
            this.Controls.Add(this.txtLoanNo);
            this.Controls.Add(this.mtxtAccountNo);
            this.Controls.Add(this.lblMakingDate);
            this.Controls.Add(this.lblAccountType);
            this.Controls.Add(this.cxC00031);
            this.Controls.Add(this.lblLoanNo);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.gvNPLReleaseVoucher);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LOMVEW00015";
            this.Text = "Non-Performance Loan Release ";
            this.Load += new System.EventHandler(this.LOMVEW00015_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LOMVEW00015_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gvNPLReleaseVoucher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.AceGridView gvNPLReleaseVoucher;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0003 lblLoanNo;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0003 lblAccountType;
        private Windows.CXClient.Controls.CXC0003 lblMakingDate;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Windows.CXClient.Controls.CXC0001 txtLoanNo;
        private Windows.CXClient.Controls.CXC0001 txtAccountType;
        private Windows.CXClient.Controls.CXC0003 lblDate;
        private Windows.CXClient.Controls.CXC0003 lblUser;
        private Windows.CXClient.Controls.CXC0003 lblNPLReleaseVoucher;
        private Windows.CXClient.Controls.CXC0003 lblTodayDate;
        private Windows.CXClient.Controls.CXC0003 lblUserName;
        private Windows.CXClient.Controls.CXC0001 txtMakingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCRDR;
    }
}