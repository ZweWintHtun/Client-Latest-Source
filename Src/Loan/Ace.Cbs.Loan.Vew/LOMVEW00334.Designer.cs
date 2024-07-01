namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00334
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
            this.dtpPrintedDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.cxC000316 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblAcctNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblBudgetYear = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00034 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboBranch = new Ace.Windows.CXClient.Controls.CXC0002();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00033 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00035 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtCarNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtCarBoardNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.cxC00036 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtNoOfProduct = new Ace.Windows.CXClient.Controls.CXC0006();
            this.chklstCompanyInfo = new System.Windows.Forms.CheckedListBox();
            this.lblCutomerName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.SuspendLayout();
            // 
            // dtpPrintedDate
            // 
            this.dtpPrintedDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpPrintedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPrintedDate.IsSendTabOnEnter = true;
            this.dtpPrintedDate.Location = new System.Drawing.Point(136, 133);
            this.dtpPrintedDate.Name = "dtpPrintedDate";
            this.dtpPrintedDate.Size = new System.Drawing.Size(124, 20);
            this.dtpPrintedDate.TabIndex = 3;
            // 
            // cxC000316
            // 
            this.cxC000316.AutoSize = true;
            this.cxC000316.Location = new System.Drawing.Point(28, 139);
            this.cxC000316.Name = "cxC000316";
            this.cxC000316.Size = new System.Drawing.Size(36, 13);
            this.cxC000316.TabIndex = 519;
            this.cxC000316.Text = "Date :";
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.CausesValidation = false;
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(136, 98);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 1;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtxtAccountNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtAccountNo_KeyPress);
            this.mtxtAccountNo.Leave += new System.EventHandler(this.mtxtAccountNo_Leave);
            // 
            // lblAcctNo
            // 
            this.lblAcctNo.AutoSize = true;
            this.lblAcctNo.Location = new System.Drawing.Point(28, 101);
            this.lblAcctNo.Name = "lblAcctNo";
            this.lblAcctNo.Size = new System.Drawing.Size(73, 13);
            this.lblAcctNo.TabIndex = 517;
            this.lblAcctNo.Text = "Account No. :";
            // 
            // lblBudgetYear
            // 
            this.lblBudgetYear.AutoSize = true;
            this.lblBudgetYear.ForeColor = System.Drawing.Color.Black;
            this.lblBudgetYear.Location = new System.Drawing.Point(362, 62);
            this.lblBudgetYear.Name = "lblBudgetYear";
            this.lblBudgetYear.Size = new System.Drawing.Size(0, 13);
            this.lblBudgetYear.TabIndex = 516;
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.ForeColor = System.Drawing.Color.Black;
            this.cxC00031.Location = new System.Drawing.Point(287, 60);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(72, 13);
            this.cxC00031.TabIndex = 515;
            this.cxC00031.Text = "Budget Year :";
            // 
            // cxC00034
            // 
            this.cxC00034.AutoSize = true;
            this.cxC00034.Location = new System.Drawing.Point(28, 63);
            this.cxC00034.Name = "cxC00034";
            this.cxC00034.Size = new System.Drawing.Size(75, 13);
            this.cxC00034.TabIndex = 514;
            this.cxC00034.Text = "Branch Code :";
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
            this.cboBranch.Location = new System.Drawing.Point(136, 60);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(115, 21);
            this.cboBranch.TabIndex = 0;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.CausesValidation = false;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(493, 31);
            this.tsbCRUD.TabIndex = 512;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // txtProductName
            // 
            this.txtProductName.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductName.Location = new System.Drawing.Point(136, 187);
            this.txtProductName.Multiline = true;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtProductName.Size = new System.Drawing.Size(326, 45);
            this.txtProductName.TabIndex = 4;
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cxC00032.Location = new System.Drawing.Point(28, 186);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(103, 18);
            this.cxC00032.TabIndex = 522;
            this.cxC00032.Text = "အမည္ႏွင့္အမ်ိဳးအစား";
            // 
            // cxC00033
            // 
            this.cxC00033.AutoSize = true;
            this.cxC00033.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cxC00033.Location = new System.Drawing.Point(28, 248);
            this.cxC00033.Name = "cxC00033";
            this.cxC00033.Size = new System.Drawing.Size(56, 18);
            this.cxC00033.TabIndex = 523;
            this.cxC00033.Text = "ကားနံပါတ္";
            // 
            // cxC00035
            // 
            this.cxC00035.AutoSize = true;
            this.cxC00035.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cxC00035.Location = new System.Drawing.Point(28, 286);
            this.cxC00035.Name = "cxC00035";
            this.cxC00035.Size = new System.Drawing.Size(89, 18);
            this.cxC00035.TabIndex = 524;
            this.cxC00035.Text = "ကားေဘာင္အမွတ္";
            // 
            // txtCarNo
            // 
            this.txtCarNo.CausesValidation = false;
            this.txtCarNo.Font = new System.Drawing.Font("Zawgyi-One", 8F);
            this.txtCarNo.IsSendTabOnEnter = true;
            this.txtCarNo.Location = new System.Drawing.Point(136, 246);
            this.txtCarNo.Name = "txtCarNo";
            this.txtCarNo.Size = new System.Drawing.Size(326, 25);
            this.txtCarNo.TabIndex = 5;
            this.txtCarNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtCarBoardNo
            // 
            this.txtCarBoardNo.CausesValidation = false;
            this.txtCarBoardNo.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCarBoardNo.IsSendTabOnEnter = true;
            this.txtCarBoardNo.Location = new System.Drawing.Point(136, 286);
            this.txtCarBoardNo.Name = "txtCarBoardNo";
            this.txtCarBoardNo.Size = new System.Drawing.Size(326, 25);
            this.txtCarBoardNo.TabIndex = 6;
            this.txtCarBoardNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // cxC00036
            // 
            this.cxC00036.AutoSize = true;
            this.cxC00036.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cxC00036.Location = new System.Drawing.Point(28, 323);
            this.cxC00036.Name = "cxC00036";
            this.cxC00036.Size = new System.Drawing.Size(68, 18);
            this.cxC00036.TabIndex = 527;
            this.cxC00036.Text = "အေရအတြက္";
            // 
            // txtNoOfProduct
            // 
            this.txtNoOfProduct.CausesValidation = false;
            this.txtNoOfProduct.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoOfProduct.IsSendTabOnEnter = true;
            this.txtNoOfProduct.Location = new System.Drawing.Point(136, 324);
            this.txtNoOfProduct.Name = "txtNoOfProduct";
            this.txtNoOfProduct.Size = new System.Drawing.Size(326, 25);
            this.txtNoOfProduct.TabIndex = 7;
            this.txtNoOfProduct.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtNoOfProduct.Leave += new System.EventHandler(this.txtNoOfProduct_Leave);
            // 
            // chklstCompanyInfo
            // 
            this.chklstCompanyInfo.FormattingEnabled = true;
            this.chklstCompanyInfo.Location = new System.Drawing.Point(290, 99);
            this.chklstCompanyInfo.Name = "chklstCompanyInfo";
            this.chklstCompanyInfo.Size = new System.Drawing.Size(175, 79);
            this.chklstCompanyInfo.TabIndex = 2;
            this.chklstCompanyInfo.Leave += new System.EventHandler(this.chklstCompanyInfo_Leave);
            // 
            // lblCutomerName
            // 
            this.lblCutomerName.AutoSize = true;
            this.lblCutomerName.ForeColor = System.Drawing.Color.Black;
            this.lblCutomerName.Location = new System.Drawing.Point(287, 79);
            this.lblCutomerName.Name = "lblCutomerName";
            this.lblCutomerName.Size = new System.Drawing.Size(119, 13);
            this.lblCutomerName.TabIndex = 530;
            this.lblCutomerName.Text = "Please Select Customer";
            // 
            // LOMVEW00334
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 376);
            this.Controls.Add(this.lblCutomerName);
            this.Controls.Add(this.chklstCompanyInfo);
            this.Controls.Add(this.txtNoOfProduct);
            this.Controls.Add(this.cxC00036);
            this.Controls.Add(this.txtCarBoardNo);
            this.Controls.Add(this.txtCarNo);
            this.Controls.Add(this.cxC00035);
            this.Controls.Add(this.cxC00033);
            this.Controls.Add(this.cxC00032);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.dtpPrintedDate);
            this.Controls.Add(this.cxC000316);
            this.Controls.Add(this.mtxtAccountNo);
            this.Controls.Add(this.lblAcctNo);
            this.Controls.Add(this.lblBudgetYear);
            this.Controls.Add(this.cxC00031);
            this.Controls.Add(this.cxC00034);
            this.Controls.Add(this.cboBranch);
            this.Controls.Add(this.tsbCRUD);
            this.Name = "LOMVEW00334";
            this.Text = "Hire Purchase Contract Printing";
            this.Load += new System.EventHandler(this.LOMVEW00334_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0005 dtpPrintedDate;
        private Windows.CXClient.Controls.CXC0003 cxC000316;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblAcctNo;
        private Windows.CXClient.Controls.CXC0003 lblBudgetYear;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0003 cxC00034;
        private Windows.CXClient.Controls.CXC0002 cboBranch;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.TextBox txtProductName;
        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private Windows.CXClient.Controls.CXC0003 cxC00033;
        private Windows.CXClient.Controls.CXC0003 cxC00035;
        private Windows.CXClient.Controls.CXC0006 txtCarNo;
        private Windows.CXClient.Controls.CXC0006 txtCarBoardNo;
        private Windows.CXClient.Controls.CXC0003 cxC00036;
        private Windows.CXClient.Controls.CXC0006 txtNoOfProduct;
        private System.Windows.Forms.CheckedListBox chklstCompanyInfo;
        private Windows.CXClient.Controls.CXC0003 lblCutomerName;
    }
}