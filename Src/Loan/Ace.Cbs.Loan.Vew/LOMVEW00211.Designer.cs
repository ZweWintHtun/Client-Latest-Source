﻿namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00211
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00211));
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OptByProductType = new System.Windows.Forms.RadioButton();
            this.OptALL = new System.Windows.Forms.RadioButton();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cxC00033 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboProductGroup = new Ace.Windows.CXClient.Controls.CXC0002();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cboBranch = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.dtpStartDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.lblFromDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.dtpEndDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.lblToDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.Location = new System.Drawing.Point(22, 220);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(77, 13);
            this.cxC00032.TabIndex = 90;
            this.cxC00032.Text = "Product Type :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.OptByProductType);
            this.groupBox1.Controls.Add(this.OptALL);
            this.groupBox1.Location = new System.Drawing.Point(19, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 59);
            this.groupBox1.TabIndex = 89;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search By:";
            // 
            // OptByProductType
            // 
            this.OptByProductType.AutoSize = true;
            this.OptByProductType.Location = new System.Drawing.Point(147, 19);
            this.OptByProductType.Name = "OptByProductType";
            this.OptByProductType.Size = new System.Drawing.Size(104, 17);
            this.OptByProductType.TabIndex = 1;
            this.OptByProductType.Text = "By Product Type";
            this.OptByProductType.UseVisualStyleBackColor = true;
            this.OptByProductType.Click += new System.EventHandler(this.OptByProductType_Click);
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
            this.OptALL.Click += new System.EventHandler(this.OptALL_Click);
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
            this.cboCurrency.Location = new System.Drawing.Point(116, 190);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 88;
            // 
            // cxC00033
            // 
            this.cxC00033.AutoSize = true;
            this.cxC00033.Location = new System.Drawing.Point(22, 190);
            this.cxC00033.Name = "cxC00033";
            this.cxC00033.Size = new System.Drawing.Size(55, 13);
            this.cxC00033.TabIndex = 87;
            this.cxC00033.Text = "Currency :";
            // 
            // cboProductGroup
            // 
            this.cboProductGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboProductGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboProductGroup.DropDownHeight = 200;
            this.cboProductGroup.FormattingEnabled = true;
            this.cboProductGroup.IntegralHeight = false;
            this.cboProductGroup.IsSendTabOnEnter = true;
            this.cboProductGroup.Location = new System.Drawing.Point(116, 220);
            this.cboProductGroup.Name = "cboProductGroup";
            this.cboProductGroup.Size = new System.Drawing.Size(115, 21);
            this.cboProductGroup.TabIndex = 91;
            this.cboProductGroup.SelectedIndexChanged += new System.EventHandler(this.cboProductGroup_SelectedIndexChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
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
            this.cboBranch.Location = new System.Drawing.Point(116, 160);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(115, 21);
            this.cboBranch.TabIndex = 86;
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(22, 163);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(75, 13);
            this.cxC00031.TabIndex = 85;
            this.cxC00031.Text = "Branch Code :";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, -2);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(482, 31);
            this.tsbCRUD.TabIndex = 84;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.IsSendTabOnEnter = true;
            this.dtpStartDate.Location = new System.Drawing.Point(116, 102);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(115, 20);
            this.dtpStartDate.TabIndex = 80;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(22, 105);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(61, 13);
            this.lblFromDate.TabIndex = 83;
            this.lblFromDate.Text = "Start Date :";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.IsSendTabOnEnter = true;
            this.dtpEndDate.Location = new System.Drawing.Point(116, 130);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(115, 20);
            this.dtpEndDate.TabIndex = 81;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(22, 133);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(58, 13);
            this.lblToDate.TabIndex = 82;
            this.lblToDate.Text = "End Date :";
            // 
            // LOMVEW00211
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 262);
            this.Controls.Add(this.cxC00032);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.cxC00033);
            this.Controls.Add(this.cboProductGroup);
            this.Controls.Add(this.cboBranch);
            this.Controls.Add(this.cxC00031);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.lblToDate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00211";
            this.Text = "HP Payment Listing";
            this.Load += new System.EventHandler(this.LOMVEW00211_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton OptByProductType;
        private System.Windows.Forms.RadioButton OptALL;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0003 cxC00033;
        private Windows.CXClient.Controls.CXC0002 cboProductGroup;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Windows.CXClient.Controls.CXC0002 cboBranch;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0005 dtpStartDate;
        private Windows.CXClient.Controls.CXC0003 lblFromDate;
        private Windows.CXClient.Controls.CXC0005 dtpEndDate;
        private Windows.CXClient.Controls.CXC0003 lblToDate;

    }
}