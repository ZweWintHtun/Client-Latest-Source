﻿namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00434
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
            this.dtpEndDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cxC00033 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboACTypes = new Ace.Windows.CXClient.Controls.CXC0002();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.dtpStartDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblToDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblFromDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.OptInternalCust = new System.Windows.Forms.RadioButton();
            this.OptExternalCust = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblBudgetYear = new Ace.Windows.CXClient.Controls.CXC0003();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboBranch = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.IsSendTabOnEnter = true;
            this.dtpEndDate.Location = new System.Drawing.Point(150, 39);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(115, 20);
            this.dtpEndDate.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cxC00033);
            this.groupBox1.Controls.Add(this.cboACTypes);
            this.groupBox1.Location = new System.Drawing.Point(7, 136);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 51);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Internal Customer";
            // 
            // cxC00033
            // 
            this.cxC00033.AutoSize = true;
            this.cxC00033.Location = new System.Drawing.Point(27, 22);
            this.cxC00033.Name = "cxC00033";
            this.cxC00033.Size = new System.Drawing.Size(80, 13);
            this.cxC00033.TabIndex = 145;
            this.cxC00033.Text = "Account Type :";
            // 
            // cboACTypes
            // 
            this.cboACTypes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboACTypes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboACTypes.DropDownHeight = 200;
            this.cboACTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboACTypes.FormattingEnabled = true;
            this.cboACTypes.IntegralHeight = false;
            this.cboACTypes.IsSendTabOnEnter = true;
            this.cboACTypes.ItemHeight = 13;
            this.cboACTypes.Location = new System.Drawing.Point(150, 19);
            this.cboACTypes.Name = "cboACTypes";
            this.cboACTypes.Size = new System.Drawing.Size(115, 21);
            this.cboACTypes.TabIndex = 3;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(495, 36);
            this.tsbCRUD.TabIndex = 4;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.IsSendTabOnEnter = true;
            this.dtpStartDate.Location = new System.Drawing.Point(150, 14);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(115, 20);
            this.dtpStartDate.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpEndDate);
            this.groupBox2.Controls.Add(this.dtpStartDate);
            this.groupBox2.Controls.Add(this.lblToDate);
            this.groupBox2.Controls.Add(this.lblFromDate);
            this.groupBox2.Location = new System.Drawing.Point(7, 184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(478, 68);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(25, 42);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(58, 13);
            this.lblToDate.TabIndex = 137;
            this.lblToDate.Text = "End Date :";
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(25, 14);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(61, 13);
            this.lblFromDate.TabIndex = 138;
            this.lblFromDate.Text = "Start Date :";
            // 
            // OptInternalCust
            // 
            this.OptInternalCust.AutoSize = true;
            this.OptInternalCust.Checked = true;
            this.OptInternalCust.Location = new System.Drawing.Point(33, 17);
            this.OptInternalCust.Name = "OptInternalCust";
            this.OptInternalCust.Size = new System.Drawing.Size(107, 17);
            this.OptInternalCust.TabIndex = 1;
            this.OptInternalCust.TabStop = true;
            this.OptInternalCust.Text = "Internal Customer";
            this.OptInternalCust.UseVisualStyleBackColor = true;
            this.OptInternalCust.CheckedChanged += new System.EventHandler(this.OptInternalCust_CheckedChanged);
            // 
            // OptExternalCust
            // 
            this.OptExternalCust.AutoSize = true;
            this.OptExternalCust.Location = new System.Drawing.Point(155, 17);
            this.OptExternalCust.Name = "OptExternalCust";
            this.OptExternalCust.Size = new System.Drawing.Size(110, 17);
            this.OptExternalCust.TabIndex = 2;
            this.OptExternalCust.Text = "External Customer";
            this.OptExternalCust.UseVisualStyleBackColor = true;
            this.OptExternalCust.CheckedChanged += new System.EventHandler(this.OptExternalCust_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.OptInternalCust);
            this.groupBox3.Controls.Add(this.OptExternalCust);
            this.groupBox3.Location = new System.Drawing.Point(7, 86);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(479, 49);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // lblBudgetYear
            // 
            this.lblBudgetYear.AutoSize = true;
            this.lblBudgetYear.ForeColor = System.Drawing.Color.Black;
            this.lblBudgetYear.Location = new System.Drawing.Point(398, 41);
            this.lblBudgetYear.Name = "lblBudgetYear";
            this.lblBudgetYear.Size = new System.Drawing.Size(0, 13);
            this.lblBudgetYear.TabIndex = 148;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cboBranch);
            this.groupBox4.Controls.Add(this.cxC00032);
            this.groupBox4.Location = new System.Drawing.Point(7, 38);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(479, 49);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
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
            this.cboBranch.Location = new System.Drawing.Point(155, 19);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(115, 21);
            this.cboBranch.TabIndex = 0;
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.Location = new System.Drawing.Point(30, 22);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(75, 13);
            this.cxC00032.TabIndex = 154;
            this.cxC00032.Text = "Branch Code :";
            // 
            // LOMVEW00434
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 254);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblBudgetYear);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LOMVEW00434";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Black List (History) Listing";
            this.Load += new System.EventHandler(this.LOMVEW00434_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0005 dtpEndDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private Windows.CXClient.Controls.CXC0003 cxC00033;
        private Windows.CXClient.Controls.CXC0002 cboACTypes;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0005 dtpStartDate;
        private System.Windows.Forms.GroupBox groupBox2;
        private Windows.CXClient.Controls.CXC0003 lblToDate;
        private Windows.CXClient.Controls.CXC0003 lblFromDate;
        private System.Windows.Forms.RadioButton OptInternalCust;
        private System.Windows.Forms.RadioButton OptExternalCust;
        private System.Windows.Forms.GroupBox groupBox3;
        private Windows.CXClient.Controls.CXC0003 lblBudgetYear;
        private System.Windows.Forms.GroupBox groupBox4;
        private Windows.CXClient.Controls.CXC0002 cboBranch;
        private Windows.CXClient.Controls.CXC0003 cxC00032;
    }
}