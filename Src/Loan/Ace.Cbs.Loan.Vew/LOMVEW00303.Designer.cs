namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00303
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00303));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.cboTownship = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cboVillageGroup = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblVillageGroup = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblTownship = new Ace.Windows.CXClient.Controls.CXC0003();
            this.dtpDueDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.cxC000316 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblBudgetYear = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00033 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cboBranch = new Ace.Windows.CXClient.Controls.CXC0002();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.CausesValidation = false;
            this.tsbCRUD.Location = new System.Drawing.Point(-2, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(497, 31);
            this.tsbCRUD.TabIndex = 9;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // cboTownship
            // 
            this.cboTownship.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboTownship.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTownship.DropDownHeight = 200;
            this.cboTownship.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTownship.FormattingEnabled = true;
            this.cboTownship.IntegralHeight = false;
            this.cboTownship.IsSendTabOnEnter = true;
            this.cboTownship.Location = new System.Drawing.Point(110, 151);
            this.cboTownship.Name = "cboTownship";
            this.cboTownship.Size = new System.Drawing.Size(163, 21);
            this.cboTownship.TabIndex = 19;
            // 
            // cboVillageGroup
            // 
            this.cboVillageGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboVillageGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboVillageGroup.DropDownHeight = 200;
            this.cboVillageGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVillageGroup.FormattingEnabled = true;
            this.cboVillageGroup.IntegralHeight = false;
            this.cboVillageGroup.IsSendTabOnEnter = true;
            this.cboVillageGroup.Location = new System.Drawing.Point(110, 123);
            this.cboVillageGroup.Name = "cboVillageGroup";
            this.cboVillageGroup.Size = new System.Drawing.Size(163, 21);
            this.cboVillageGroup.TabIndex = 18;
            // 
            // lblVillageGroup
            // 
            this.lblVillageGroup.AutoSize = true;
            this.lblVillageGroup.Location = new System.Drawing.Point(25, 126);
            this.lblVillageGroup.Name = "lblVillageGroup";
            this.lblVillageGroup.Size = new System.Drawing.Size(76, 13);
            this.lblVillageGroup.TabIndex = 17;
            this.lblVillageGroup.Text = "Village Group :";
            // 
            // lblTownship
            // 
            this.lblTownship.AutoSize = true;
            this.lblTownship.Location = new System.Drawing.Point(25, 154);
            this.lblTownship.Name = "lblTownship";
            this.lblTownship.Size = new System.Drawing.Size(59, 13);
            this.lblTownship.TabIndex = 16;
            this.lblTownship.Text = "Township :";
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDueDate.IsSendTabOnEnter = true;
            this.dtpDueDate.Location = new System.Drawing.Point(110, 182);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(124, 20);
            this.dtpDueDate.TabIndex = 21;
            // 
            // cxC000316
            // 
            this.cxC000316.AutoSize = true;
            this.cxC000316.Location = new System.Drawing.Point(26, 185);
            this.cxC000316.Name = "cxC000316";
            this.cxC000316.Size = new System.Drawing.Size(59, 13);
            this.cxC000316.TabIndex = 20;
            this.cxC000316.Text = "Due Date :";
            // 
            // lblBudgetYear
            // 
            this.lblBudgetYear.AutoSize = true;
            this.lblBudgetYear.ForeColor = System.Drawing.Color.Black;
            this.lblBudgetYear.Location = new System.Drawing.Point(409, 44);
            this.lblBudgetYear.Name = "lblBudgetYear";
            this.lblBudgetYear.Size = new System.Drawing.Size(0, 13);
            this.lblBudgetYear.TabIndex = 22;
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.ForeColor = System.Drawing.Color.Black;
            this.cxC00031.Location = new System.Drawing.Point(332, 44);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(72, 13);
            this.cxC00031.TabIndex = 23;
            this.cxC00031.Text = "Budget Year :";
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.Location = new System.Drawing.Point(26, 66);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(58, 13);
            this.cxC00032.TabIndex = 67;
            this.cxC00032.Text = "Currency  :";
            // 
            // cxC00033
            // 
            this.cxC00033.AutoSize = true;
            this.cxC00033.Location = new System.Drawing.Point(25, 96);
            this.cxC00033.Name = "cxC00033";
            this.cxC00033.Size = new System.Drawing.Size(75, 13);
            this.cxC00033.TabIndex = 68;
            this.cxC00033.Text = "Branch Code :";
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
            this.cboCurrency.Location = new System.Drawing.Point(110, 63);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 65;
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
            this.cboBranch.Location = new System.Drawing.Point(110, 93);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(115, 21);
            this.cboBranch.TabIndex = 66;
            // 
            // LOMVEW00303
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 226);
            this.Controls.Add(this.cxC00032);
            this.Controls.Add(this.cxC00033);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.cboBranch);
            this.Controls.Add(this.cxC00031);
            this.Controls.Add(this.lblBudgetYear);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.cxC000316);
            this.Controls.Add(this.cboTownship);
            this.Controls.Add(this.cboVillageGroup);
            this.Controls.Add(this.lblVillageGroup);
            this.Controls.Add(this.lblTownship);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00303";
            this.Text = "Seasonal Loan Outstanding Register Report";
            this.Load += new System.EventHandler(this.LOMVEW00303_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0002 cboTownship;
        private Windows.CXClient.Controls.CXC0002 cboVillageGroup;
        private Windows.CXClient.Controls.CXC0003 lblVillageGroup;
        private Windows.CXClient.Controls.CXC0003 lblTownship;
        private Windows.CXClient.Controls.CXC0005 dtpDueDate;
        private Windows.CXClient.Controls.CXC0003 cxC000316;
        private Windows.CXClient.Controls.CXC0003 lblBudgetYear;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private Windows.CXClient.Controls.CXC0003 cxC00033;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0002 cboBranch;
    }
}