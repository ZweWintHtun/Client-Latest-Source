﻿namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00061
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00061));
            this.dtpStartDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.lblFromDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.dtpEndDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblToDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cboBranch = new Ace.Windows.CXClient.Controls.CXC0002();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.SuspendLayout();
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.IsSendTabOnEnter = true;
            this.dtpStartDate.Location = new System.Drawing.Point(106, 48);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(115, 20);
            this.dtpStartDate.TabIndex = 66;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(12, 51);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(61, 13);
            this.lblFromDate.TabIndex = 71;
            this.lblFromDate.Text = "Start Date :";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.IsSendTabOnEnter = true;
            this.dtpEndDate.Location = new System.Drawing.Point(106, 76);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(115, 20);
            this.dtpEndDate.TabIndex = 67;
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.Location = new System.Drawing.Point(12, 106);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(58, 13);
            this.cxC00032.TabIndex = 72;
            this.cxC00032.Text = "Currency  :";
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(12, 79);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(58, 13);
            this.lblToDate.TabIndex = 70;
            this.lblToDate.Text = "End Date :";
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(12, 133);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(75, 13);
            this.cxC00031.TabIndex = 73;
            this.cxC00031.Text = "Branch Code :";
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
            this.cboCurrency.Location = new System.Drawing.Point(106, 102);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 68;
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
            this.cboBranch.Location = new System.Drawing.Point(106, 130);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(115, 21);
            this.cboBranch.TabIndex = 69;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(477, 36);
            this.tsbCRUD.TabIndex = 65;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(106, 161);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 75;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtxtAccountNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtAccountNo_KeyPress);
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(12, 164);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(73, 13);
            this.lblAccountNo.TabIndex = 74;
            this.lblAccountNo.Text = "Account No. :";
            // 
            // LOMVEW00061
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 195);
            this.Controls.Add(this.mtxtAccountNo);
            this.Controls.Add(this.lblAccountNo);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.cxC00032);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.cxC00031);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.cboBranch);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00061";
            this.Text = "LOMVEW00061";
            this.Load += new System.EventHandler(this.LOMVEW00061_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0005 dtpStartDate;
        private Windows.CXClient.Controls.CXC0003 lblFromDate;
        private Windows.CXClient.Controls.CXC0005 dtpEndDate;
        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private Windows.CXClient.Controls.CXC0003 lblToDate;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0002 cboBranch;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblAccountNo;
    }
}