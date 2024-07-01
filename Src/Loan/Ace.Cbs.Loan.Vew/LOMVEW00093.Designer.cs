namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00093
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00093));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.dtpStartDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.lblFromDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.dtpEndDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.lblToDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cboBranch = new Ace.Windows.CXClient.Controls.CXC0002();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.rdoSeasonType = new System.Windows.Forms.RadioButton();
            this.rdoCropType = new System.Windows.Forms.RadioButton();
            this.cboCropType = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblCropType = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboSeasonType = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblSeasonType = new Ace.Windows.CXClient.Controls.CXC0003();
            this.pnlRadio = new System.Windows.Forms.Panel();
            this.pnlDefault = new System.Windows.Forms.Panel();
            this.pnlCondition = new System.Windows.Forms.Panel();
            this.pnlRadio.SuspendLayout();
            this.pnlDefault.SuspendLayout();
            this.pnlCondition.SuspendLayout();
            this.SuspendLayout();
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
            this.tsbCRUD.TabIndex = 16;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.IsSendTabOnEnter = true;
            this.dtpStartDate.Location = new System.Drawing.Point(92, 9);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(115, 20);
            this.dtpStartDate.TabIndex = 2;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(12, 15);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(61, 13);
            this.lblFromDate.TabIndex = 1;
            this.lblFromDate.Text = "Start Date :";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.IsSendTabOnEnter = true;
            this.dtpEndDate.Location = new System.Drawing.Point(92, 41);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(115, 20);
            this.dtpEndDate.TabIndex = 4;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(12, 47);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(58, 13);
            this.lblToDate.TabIndex = 3;
            this.lblToDate.Text = "End Date :";
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.Location = new System.Drawing.Point(12, 76);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(58, 13);
            this.cxC00032.TabIndex = 8;
            this.cxC00032.Text = "Currency  :";
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(12, 108);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(75, 13);
            this.cxC00031.TabIndex = 10;
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
            this.cboCurrency.Location = new System.Drawing.Point(92, 73);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(124, 21);
            this.cboCurrency.TabIndex = 9;
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
            this.cboBranch.Location = new System.Drawing.Point(92, 105);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(124, 21);
            this.cboBranch.TabIndex = 11;
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Location = new System.Drawing.Point(7, 6);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(36, 17);
            this.rdoAll.TabIndex = 5;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "All";
            this.rdoAll.UseVisualStyleBackColor = true;
            this.rdoAll.Click += new System.EventHandler(this.rdoAll_Click);
            // 
            // rdoSeasonType
            // 
            this.rdoSeasonType.AutoSize = true;
            this.rdoSeasonType.Location = new System.Drawing.Point(49, 6);
            this.rdoSeasonType.Name = "rdoSeasonType";
            this.rdoSeasonType.Size = new System.Drawing.Size(103, 17);
            this.rdoSeasonType.TabIndex = 6;
            this.rdoSeasonType.TabStop = true;
            this.rdoSeasonType.Text = "By Season Type";
            this.rdoSeasonType.UseVisualStyleBackColor = true;
            this.rdoSeasonType.Click += new System.EventHandler(this.rdoSeasonType_Click);
            // 
            // rdoCropType
            // 
            this.rdoCropType.AutoSize = true;
            this.rdoCropType.Location = new System.Drawing.Point(158, 6);
            this.rdoCropType.Name = "rdoCropType";
            this.rdoCropType.Size = new System.Drawing.Size(89, 17);
            this.rdoCropType.TabIndex = 7;
            this.rdoCropType.TabStop = true;
            this.rdoCropType.Text = "By Crop Type";
            this.rdoCropType.UseVisualStyleBackColor = true;
            this.rdoCropType.Click += new System.EventHandler(this.rdoCropType_Click);
            // 
            // cboCropType
            // 
            this.cboCropType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCropType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCropType.DropDownHeight = 200;
            this.cboCropType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCropType.FormattingEnabled = true;
            this.cboCropType.IntegralHeight = false;
            this.cboCropType.IsSendTabOnEnter = true;
            this.cboCropType.Location = new System.Drawing.Point(92, 6);
            this.cboCropType.Name = "cboCropType";
            this.cboCropType.Size = new System.Drawing.Size(124, 21);
            this.cboCropType.TabIndex = 15;
            // 
            // lblCropType
            // 
            this.lblCropType.AutoSize = true;
            this.lblCropType.Location = new System.Drawing.Point(12, 9);
            this.lblCropType.Name = "lblCropType";
            this.lblCropType.Size = new System.Drawing.Size(62, 13);
            this.lblCropType.TabIndex = 14;
            this.lblCropType.Text = "Crop Type :";
            // 
            // cboSeasonType
            // 
            this.cboSeasonType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboSeasonType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSeasonType.DropDownHeight = 200;
            this.cboSeasonType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSeasonType.FormattingEnabled = true;
            this.cboSeasonType.IntegralHeight = false;
            this.cboSeasonType.IsSendTabOnEnter = true;
            this.cboSeasonType.Location = new System.Drawing.Point(92, 6);
            this.cboSeasonType.Name = "cboSeasonType";
            this.cboSeasonType.Size = new System.Drawing.Size(124, 21);
            this.cboSeasonType.TabIndex = 13;
            // 
            // lblSeasonType
            // 
            this.lblSeasonType.AutoSize = true;
            this.lblSeasonType.Location = new System.Drawing.Point(12, 9);
            this.lblSeasonType.Name = "lblSeasonType";
            this.lblSeasonType.Size = new System.Drawing.Size(76, 13);
            this.lblSeasonType.TabIndex = 12;
            this.lblSeasonType.Text = "Season Type :";
            // 
            // pnlRadio
            // 
            this.pnlRadio.Controls.Add(this.rdoCropType);
            this.pnlRadio.Controls.Add(this.rdoAll);
            this.pnlRadio.Controls.Add(this.rdoSeasonType);
            this.pnlRadio.Location = new System.Drawing.Point(12, 42);
            this.pnlRadio.Name = "pnlRadio";
            this.pnlRadio.Size = new System.Drawing.Size(453, 36);
            this.pnlRadio.TabIndex = 17;
            // 
            // pnlDefault
            // 
            this.pnlDefault.Controls.Add(this.dtpStartDate);
            this.pnlDefault.Controls.Add(this.dtpEndDate);
            this.pnlDefault.Controls.Add(this.cboBranch);
            this.pnlDefault.Controls.Add(this.cboCurrency);
            this.pnlDefault.Controls.Add(this.lblFromDate);
            this.pnlDefault.Controls.Add(this.lblToDate);
            this.pnlDefault.Controls.Add(this.cxC00032);
            this.pnlDefault.Controls.Add(this.cxC00031);
            this.pnlDefault.Location = new System.Drawing.Point(12, 78);
            this.pnlDefault.Name = "pnlDefault";
            this.pnlDefault.Size = new System.Drawing.Size(453, 135);
            this.pnlDefault.TabIndex = 18;
            // 
            // pnlCondition
            // 
            this.pnlCondition.Controls.Add(this.cboCropType);
            this.pnlCondition.Controls.Add(this.lblCropType);
            this.pnlCondition.Controls.Add(this.cboSeasonType);
            this.pnlCondition.Controls.Add(this.lblSeasonType);
            this.pnlCondition.Location = new System.Drawing.Point(12, 213);
            this.pnlCondition.Name = "pnlCondition";
            this.pnlCondition.Size = new System.Drawing.Size(453, 39);
            this.pnlCondition.TabIndex = 19;
            // 
            // LOMVEW00093
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 261);
            this.Controls.Add(this.pnlCondition);
            this.Controls.Add(this.pnlDefault);
            this.Controls.Add(this.pnlRadio);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00093";
            this.Text = "LOMVEW00093";
            this.Load += new System.EventHandler(this.LOMVEW00093_Load);
            this.pnlRadio.ResumeLayout(false);
            this.pnlRadio.PerformLayout();
            this.pnlDefault.ResumeLayout(false);
            this.pnlDefault.PerformLayout();
            this.pnlCondition.ResumeLayout(false);
            this.pnlCondition.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0005 dtpStartDate;
        private Windows.CXClient.Controls.CXC0003 lblFromDate;
        private Windows.CXClient.Controls.CXC0005 dtpEndDate;
        private Windows.CXClient.Controls.CXC0003 lblToDate;
        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0002 cboBranch;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.RadioButton rdoSeasonType;
        private System.Windows.Forms.RadioButton rdoCropType;
        private Windows.CXClient.Controls.CXC0002 cboCropType;
        private Windows.CXClient.Controls.CXC0003 lblCropType;
        private Windows.CXClient.Controls.CXC0002 cboSeasonType;
        private Windows.CXClient.Controls.CXC0003 lblSeasonType;
        private System.Windows.Forms.Panel pnlRadio;
        private System.Windows.Forms.Panel pnlDefault;
        private System.Windows.Forms.Panel pnlCondition;
    }
}