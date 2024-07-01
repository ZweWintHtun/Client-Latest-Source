namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00336
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
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.dtpPrintedDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.cxC000316 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblAcctNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblBudgetYear = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00034 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboBranch = new Ace.Windows.CXClient.Controls.CXC0002();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.SuspendLayout();
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.Location = new System.Drawing.Point(51, 184);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(44, 13);
            this.cxC00032.TabIndex = 533;
            this.cxC00032.Text = "Reason";
            // 
            // txtReason
            // 
            this.txtReason.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReason.Location = new System.Drawing.Point(136, 181);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReason.Size = new System.Drawing.Size(295, 54);
            this.txtReason.TabIndex = 532;
            // 
            // dtpPrintedDate
            // 
            this.dtpPrintedDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpPrintedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPrintedDate.IsSendTabOnEnter = true;
            this.dtpPrintedDate.Location = new System.Drawing.Point(136, 144);
            this.dtpPrintedDate.Name = "dtpPrintedDate";
            this.dtpPrintedDate.Size = new System.Drawing.Size(124, 20);
            this.dtpPrintedDate.TabIndex = 531;
            // 
            // cxC000316
            // 
            this.cxC000316.AutoSize = true;
            this.cxC000316.Location = new System.Drawing.Point(51, 150);
            this.cxC000316.Name = "cxC000316";
            this.cxC000316.Size = new System.Drawing.Size(36, 13);
            this.cxC000316.TabIndex = 530;
            this.cxC000316.Text = "Date :";
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.CausesValidation = false;
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(136, 109);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 529;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtxtAccountNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtAccountNo_KeyPress);
            this.mtxtAccountNo.Leave += new System.EventHandler(this.mtxtAccountNo_Leave);
            // 
            // lblAcctNo
            // 
            this.lblAcctNo.AutoSize = true;
            this.lblAcctNo.Location = new System.Drawing.Point(51, 112);
            this.lblAcctNo.Name = "lblAcctNo";
            this.lblAcctNo.Size = new System.Drawing.Size(73, 13);
            this.lblAcctNo.TabIndex = 528;
            this.lblAcctNo.Text = "Account No. :";
            // 
            // lblBudgetYear
            // 
            this.lblBudgetYear.AutoSize = true;
            this.lblBudgetYear.ForeColor = System.Drawing.Color.Black;
            this.lblBudgetYear.Location = new System.Drawing.Point(376, 43);
            this.lblBudgetYear.Name = "lblBudgetYear";
            this.lblBudgetYear.Size = new System.Drawing.Size(0, 13);
            this.lblBudgetYear.TabIndex = 527;
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.ForeColor = System.Drawing.Color.Black;
            this.cxC00031.Location = new System.Drawing.Point(298, 43);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(72, 13);
            this.cxC00031.TabIndex = 526;
            this.cxC00031.Text = "Budget Year :";
            // 
            // cxC00034
            // 
            this.cxC00034.AutoSize = true;
            this.cxC00034.Location = new System.Drawing.Point(51, 74);
            this.cxC00034.Name = "cxC00034";
            this.cxC00034.Size = new System.Drawing.Size(75, 13);
            this.cxC00034.TabIndex = 525;
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
            this.cboBranch.Location = new System.Drawing.Point(136, 71);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(115, 21);
            this.cboBranch.TabIndex = 524;
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
            this.tsbCRUD.Size = new System.Drawing.Size(482, 31);
            this.tsbCRUD.TabIndex = 523;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // LOMVEW00336
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 255);
            this.Controls.Add(this.cxC00032);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.dtpPrintedDate);
            this.Controls.Add(this.cxC000316);
            this.Controls.Add(this.mtxtAccountNo);
            this.Controls.Add(this.lblAcctNo);
            this.Controls.Add(this.lblBudgetYear);
            this.Controls.Add(this.cxC00031);
            this.Controls.Add(this.cxC00034);
            this.Controls.Add(this.cboBranch);
            this.Controls.Add(this.tsbCRUD);
            this.Name = "LOMVEW00336";
            this.Text = "Personal Loan Contract Printing";
            this.Load += new System.EventHandler(this.LOMVEW00336_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private System.Windows.Forms.TextBox txtReason;
        private Windows.CXClient.Controls.CXC0005 dtpPrintedDate;
        private Windows.CXClient.Controls.CXC0003 cxC000316;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblAcctNo;
        private Windows.CXClient.Controls.CXC0003 lblBudgetYear;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0003 cxC00034;
        private Windows.CXClient.Controls.CXC0002 cboBranch;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
    }
}