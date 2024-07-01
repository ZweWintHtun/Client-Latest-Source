namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00340
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
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cxC00033 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtPlace = new System.Windows.Forms.TextBox();
            this.txtAmountVW = new Ace.Windows.CXClient.Controls.CXC0004();
            this.cxC00036 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00035 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtInsuranceDesp = new System.Windows.Forms.TextBox();
            this.cxC00037 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCutomerName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.chklstCompanyInfo = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // dtpPrintedDate
            // 
            this.dtpPrintedDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpPrintedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPrintedDate.IsSendTabOnEnter = true;
            this.dtpPrintedDate.Location = new System.Drawing.Point(114, 144);
            this.dtpPrintedDate.Name = "dtpPrintedDate";
            this.dtpPrintedDate.Size = new System.Drawing.Size(124, 20);
            this.dtpPrintedDate.TabIndex = 3;
            // 
            // cxC000316
            // 
            this.cxC000316.AutoSize = true;
            this.cxC000316.Location = new System.Drawing.Point(19, 150);
            this.cxC000316.Name = "cxC000316";
            this.cxC000316.Size = new System.Drawing.Size(36, 13);
            this.cxC000316.TabIndex = 0;
            this.cxC000316.Text = "Date :";
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.CausesValidation = false;
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(114, 106);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 2;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtxtAccountNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtAccountNo_KeyPress);
            this.mtxtAccountNo.Leave += new System.EventHandler(this.mtxtAccountNo_Leave);
            // 
            // lblAcctNo
            // 
            this.lblAcctNo.AutoSize = true;
            this.lblAcctNo.Location = new System.Drawing.Point(19, 109);
            this.lblAcctNo.Name = "lblAcctNo";
            this.lblAcctNo.Size = new System.Drawing.Size(73, 13);
            this.lblAcctNo.TabIndex = 0;
            this.lblAcctNo.Text = "Account No. :";
            // 
            // lblBudgetYear
            // 
            this.lblBudgetYear.AutoSize = true;
            this.lblBudgetYear.ForeColor = System.Drawing.Color.Black;
            this.lblBudgetYear.Location = new System.Drawing.Point(522, 51);
            this.lblBudgetYear.Name = "lblBudgetYear";
            this.lblBudgetYear.Size = new System.Drawing.Size(0, 13);
            this.lblBudgetYear.TabIndex = 547;
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.ForeColor = System.Drawing.Color.Black;
            this.cxC00031.Location = new System.Drawing.Point(444, 51);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(72, 13);
            this.cxC00031.TabIndex = 0;
            this.cxC00031.Text = "Budget Year :";
            // 
            // cxC00034
            // 
            this.cxC00034.AutoSize = true;
            this.cxC00034.Location = new System.Drawing.Point(19, 69);
            this.cxC00034.Name = "cxC00034";
            this.cxC00034.Size = new System.Drawing.Size(75, 13);
            this.cxC00034.TabIndex = 0;
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
            this.cboBranch.Location = new System.Drawing.Point(114, 66);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(115, 21);
            this.cboBranch.TabIndex = 1;
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
            this.tsbCRUD.Size = new System.Drawing.Size(602, 31);
            this.tsbCRUD.TabIndex = 14;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.Location = new System.Drawing.Point(19, 219);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(66, 13);
            this.cxC00032.TabIndex = 0;
            this.cxC00032.Text = "Description :";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(114, 214);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(476, 43);
            this.txtDescription.TabIndex = 5;
            // 
            // txtReference
            // 
            this.txtReference.Location = new System.Drawing.Point(114, 181);
            this.txtReference.Name = "txtReference";
            this.txtReference.Size = new System.Drawing.Size(476, 20);
            this.txtReference.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reference";
            // 
            // cxC00033
            // 
            this.cxC00033.AutoSize = true;
            this.cxC00033.Location = new System.Drawing.Point(19, 309);
            this.cxC00033.Name = "cxC00033";
            this.cxC00033.Size = new System.Drawing.Size(40, 13);
            this.cxC00033.TabIndex = 0;
            this.cxC00033.Text = "Place :";
            // 
            // txtPlace
            // 
            this.txtPlace.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlace.Location = new System.Drawing.Point(114, 304);
            this.txtPlace.Multiline = true;
            this.txtPlace.Name = "txtPlace";
            this.txtPlace.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPlace.Size = new System.Drawing.Size(476, 43);
            this.txtPlace.TabIndex = 7;
            // 
            // txtAmountVW
            // 
            this.txtAmountVW.DecimalPlaces = 0;
            this.txtAmountVW.IsSendTabOnEnter = true;
            this.txtAmountVW.IsThousandSeperator = true;
            this.txtAmountVW.Location = new System.Drawing.Point(114, 269);
            this.txtAmountVW.Name = "txtAmountVW";
            this.txtAmountVW.Size = new System.Drawing.Size(141, 20);
            this.txtAmountVW.TabIndex = 6;
            this.txtAmountVW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmountVW.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // cxC00036
            // 
            this.cxC00036.AutoSize = true;
            this.cxC00036.ForeColor = System.Drawing.Color.Blue;
            this.cxC00036.Location = new System.Drawing.Point(261, 272);
            this.cxC00036.Name = "cxC00036";
            this.cxC00036.Size = new System.Drawing.Size(45, 13);
            this.cxC00036.TabIndex = 561;
            this.cxC00036.Text = "( Kyats )";
            // 
            // cxC00035
            // 
            this.cxC00035.AutoSize = true;
            this.cxC00035.Location = new System.Drawing.Point(19, 272);
            this.cxC00035.Name = "cxC00035";
            this.cxC00035.Size = new System.Drawing.Size(49, 13);
            this.cxC00035.TabIndex = 0;
            this.cxC00035.Text = "Amount :";
            // 
            // txtInsuranceDesp
            // 
            this.txtInsuranceDesp.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInsuranceDesp.Location = new System.Drawing.Point(114, 363);
            this.txtInsuranceDesp.Multiline = true;
            this.txtInsuranceDesp.Name = "txtInsuranceDesp";
            this.txtInsuranceDesp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInsuranceDesp.Size = new System.Drawing.Size(476, 92);
            this.txtInsuranceDesp.TabIndex = 8;
            // 
            // cxC00037
            // 
            this.cxC00037.AutoSize = true;
            this.cxC00037.Location = new System.Drawing.Point(19, 368);
            this.cxC00037.Name = "cxC00037";
            this.cxC00037.Size = new System.Drawing.Size(89, 13);
            this.cxC00037.TabIndex = 0;
            this.cxC00037.Text = "Insurance Details";
            // 
            // lblCutomerName
            // 
            this.lblCutomerName.AutoSize = true;
            this.lblCutomerName.ForeColor = System.Drawing.Color.Black;
            this.lblCutomerName.Location = new System.Drawing.Point(261, 51);
            this.lblCutomerName.Name = "lblCutomerName";
            this.lblCutomerName.Size = new System.Drawing.Size(119, 13);
            this.lblCutomerName.TabIndex = 563;
            this.lblCutomerName.Text = "Please Select Customer";
            // 
            // chklstCompanyInfo
            // 
            this.chklstCompanyInfo.FormattingEnabled = true;
            this.chklstCompanyInfo.Location = new System.Drawing.Point(264, 71);
            this.chklstCompanyInfo.Name = "chklstCompanyInfo";
            this.chklstCompanyInfo.Size = new System.Drawing.Size(153, 94);
            this.chklstCompanyInfo.TabIndex = 562;
            // 
            // LOMVEW00340
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 479);
            this.Controls.Add(this.lblCutomerName);
            this.Controls.Add(this.chklstCompanyInfo);
            this.Controls.Add(this.cxC00037);
            this.Controls.Add(this.txtInsuranceDesp);
            this.Controls.Add(this.txtAmountVW);
            this.Controls.Add(this.cxC00036);
            this.Controls.Add(this.cxC00035);
            this.Controls.Add(this.cxC00033);
            this.Controls.Add(this.txtPlace);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtReference);
            this.Controls.Add(this.cxC00032);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.dtpPrintedDate);
            this.Controls.Add(this.cxC000316);
            this.Controls.Add(this.mtxtAccountNo);
            this.Controls.Add(this.lblAcctNo);
            this.Controls.Add(this.lblBudgetYear);
            this.Controls.Add(this.cxC00031);
            this.Controls.Add(this.cxC00034);
            this.Controls.Add(this.cboBranch);
            this.Controls.Add(this.tsbCRUD);
            this.Name = "LOMVEW00340";
            this.Text = "Business Loan ( Hypothecation  ) Contract Printing";
            this.Load += new System.EventHandler(this.LOMVEW00340_Load);
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
        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtReference;
        private System.Windows.Forms.Label label1;
        private Windows.CXClient.Controls.CXC0003 cxC00033;
        private System.Windows.Forms.TextBox txtPlace;
        private Windows.CXClient.Controls.CXC0004 txtAmountVW;
        private Windows.CXClient.Controls.CXC0003 cxC00036;
        private Windows.CXClient.Controls.CXC0003 cxC00035;
        private System.Windows.Forms.TextBox txtInsuranceDesp;
        private Windows.CXClient.Controls.CXC0003 cxC00037;
        private Windows.CXClient.Controls.CXC0003 lblCutomerName;
        private System.Windows.Forms.CheckedListBox chklstCompanyInfo;
    }
}