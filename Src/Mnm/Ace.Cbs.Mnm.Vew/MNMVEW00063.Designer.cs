namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00063
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00063));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblStartAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblEndAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.chkAllCurrency = new Ace.Windows.CXClient.Controls.CXC0008();
            this.txtEndAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtStartAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoSavingAccount = new System.Windows.Forms.RadioButton();
            this.rdoCurrentAccount = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
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
            this.tsbCRUD.Size = new System.Drawing.Size(494, 31);
            this.tsbCRUD.TabIndex = 9;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblStartAmount
            // 
            this.lblStartAmount.AutoSize = true;
            this.lblStartAmount.Location = new System.Drawing.Point(34, 115);
            this.lblStartAmount.Name = "lblStartAmount";
            this.lblStartAmount.Size = new System.Drawing.Size(74, 13);
            this.lblStartAmount.TabIndex = 11;
            this.lblStartAmount.Text = "Start Amount :";
            // 
            // lblEndAmount
            // 
            this.lblEndAmount.AutoSize = true;
            this.lblEndAmount.Location = new System.Drawing.Point(36, 142);
            this.lblEndAmount.Name = "lblEndAmount";
            this.lblEndAmount.Size = new System.Drawing.Size(71, 13);
            this.lblEndAmount.TabIndex = 11;
            this.lblEndAmount.Text = "End Amount :";
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(51, 204);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 13;
            this.lblCurrency.Text = "Currency :\r\n";
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
            this.cboCurrency.Location = new System.Drawing.Point(132, 200);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 6;
            // 
            // chkAllCurrency
            // 
            this.chkAllCurrency.AutoSize = true;
            this.chkAllCurrency.IsSendTabOnEnter = true;
            this.chkAllCurrency.Location = new System.Drawing.Point(135, 177);
            this.chkAllCurrency.Name = "chkAllCurrency";
            this.chkAllCurrency.Size = new System.Drawing.Size(112, 17);
            this.chkAllCurrency.TabIndex = 5;
            this.chkAllCurrency.Text = "All Currency Type.";
            this.chkAllCurrency.UseVisualStyleBackColor = true;
            this.chkAllCurrency.CheckedChanged += new System.EventHandler(this.chkAllCurrency_CheckedChanged);
            // 
            // txtEndAmount
            // 
            this.txtEndAmount.DecimalPlaces = 2;
            this.txtEndAmount.IsSendTabOnEnter = true;
            this.txtEndAmount.IsThousandSeperator = true;
            this.txtEndAmount.IsUseFloatingPoint = true;
            this.txtEndAmount.Location = new System.Drawing.Point(132, 139);
            this.txtEndAmount.MaxLength = 18;
            this.txtEndAmount.Name = "txtEndAmount";
            this.txtEndAmount.Size = new System.Drawing.Size(115, 20);
            this.txtEndAmount.TabIndex = 4;
            this.txtEndAmount.Text = "0.00";
            this.txtEndAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEndAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtStartAmount
            // 
            this.txtStartAmount.DecimalPlaces = 2;
            this.txtStartAmount.IsSendTabOnEnter = true;
            this.txtStartAmount.IsThousandSeperator = true;
            this.txtStartAmount.IsUseFloatingPoint = true;
            this.txtStartAmount.Location = new System.Drawing.Point(132, 113);
            this.txtStartAmount.MaxLength = 18;
            this.txtStartAmount.Name = "txtStartAmount";
            this.txtStartAmount.Size = new System.Drawing.Size(115, 20);
            this.txtStartAmount.TabIndex = 3;
            this.txtStartAmount.Text = "0.00";
            this.txtStartAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtStartAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoSavingAccount);
            this.groupBox1.Controls.Add(this.rdoCurrentAccount);
            this.groupBox1.Location = new System.Drawing.Point(20, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 55);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account Type";
            // 
            // rdoSavingAccount
            // 
            this.rdoSavingAccount.AutoSize = true;
            this.rdoSavingAccount.Location = new System.Drawing.Point(155, 27);
            this.rdoSavingAccount.Name = "rdoSavingAccount";
            this.rdoSavingAccount.Size = new System.Drawing.Size(101, 17);
            this.rdoSavingAccount.TabIndex = 2;
            this.rdoSavingAccount.Text = "Saving Account";
            this.rdoSavingAccount.UseVisualStyleBackColor = true;
            // 
            // rdoCurrentAccount
            // 
            this.rdoCurrentAccount.AutoSize = true;
            this.rdoCurrentAccount.Checked = true;
            this.rdoCurrentAccount.Location = new System.Drawing.Point(17, 27);
            this.rdoCurrentAccount.Name = "rdoCurrentAccount";
            this.rdoCurrentAccount.Size = new System.Drawing.Size(102, 17);
            this.rdoCurrentAccount.TabIndex = 1;
            this.rdoCurrentAccount.TabStop = true;
            this.rdoCurrentAccount.Text = "Current Account";
            this.rdoCurrentAccount.UseVisualStyleBackColor = true;
            // 
            // MNMVEW00063
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 238);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtStartAmount);
            this.Controls.Add(this.txtEndAmount);
            this.Controls.Add(this.chkAllCurrency);
            this.Controls.Add(this.lblCurrency);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.lblEndAmount);
            this.Controls.Add(this.lblStartAmount);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00063";
            this.Text = "Ledger Balance By Grade";
            this.Load += new System.EventHandler(this.MNMVEW00063_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0003 lblStartAmount;
        private Windows.CXClient.Controls.CXC0003 lblEndAmount;
        private Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0008 chkAllCurrency;
        private Windows.CXClient.Controls.CXC0004 txtEndAmount;
        private Windows.CXClient.Controls.CXC0004 txtStartAmount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoSavingAccount;
        private System.Windows.Forms.RadioButton rdoCurrentAccount;
    }
}