namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00062
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00062));
            this.grpSort = new System.Windows.Forms.GroupBox();
            this.rdoAmount = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoAccountNo = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.chkAllCurrency = new Ace.Windows.CXClient.Controls.CXC0008();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.grpSort.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSort
            // 
            this.grpSort.Controls.Add(this.rdoAmount);
            this.grpSort.Controls.Add(this.rdoAccountNo);
            this.grpSort.Location = new System.Drawing.Point(12, 37);
            this.grpSort.Name = "grpSort";
            this.grpSort.Size = new System.Drawing.Size(225, 67);
            this.grpSort.TabIndex = 9;
            this.grpSort.TabStop = false;
            this.grpSort.Text = "Sort By :";
            // 
            // rdoAmount
            // 
            this.rdoAmount.AutoSize = true;
            this.rdoAmount.IsSendTabOnEnter = true;
            this.rdoAmount.Location = new System.Drawing.Point(64, 41);
            this.rdoAmount.Name = "rdoAmount";
            this.rdoAmount.Size = new System.Drawing.Size(61, 17);
            this.rdoAmount.TabIndex = 10;
            this.rdoAmount.Text = "Amount";
            this.rdoAmount.UseVisualStyleBackColor = true;
            this.rdoAmount.CheckedChanged += new System.EventHandler(this.cxC00091_CheckedChanged);
            // 
            // rdoAccountNo
            // 
            this.rdoAccountNo.AutoSize = true;
            this.rdoAccountNo.Checked = true;
            this.rdoAccountNo.IsSendTabOnEnter = true;
            this.rdoAccountNo.Location = new System.Drawing.Point(64, 17);
            this.rdoAccountNo.Name = "rdoAccountNo";
            this.rdoAccountNo.Size = new System.Drawing.Size(85, 17);
            this.rdoAccountNo.TabIndex = 10;
            this.rdoAccountNo.TabStop = true;
            this.rdoAccountNo.Text = "Account No.";
            this.rdoAccountNo.UseVisualStyleBackColor = true;
            this.rdoAccountNo.CheckedChanged += new System.EventHandler(this.cxC00091_CheckedChanged);
            // 
            // rdoCurrency
            // 
            this.rdoCurrency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.rdoCurrency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.rdoCurrency.DropDownHeight = 200;
            this.rdoCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rdoCurrency.FormattingEnabled = true;
            this.rdoCurrency.IntegralHeight = false;
            this.rdoCurrency.IsSendTabOnEnter = true;
            this.rdoCurrency.Location = new System.Drawing.Point(99, 110);
            this.rdoCurrency.Name = "rdoCurrency";
            this.rdoCurrency.Size = new System.Drawing.Size(100, 21);
            this.rdoCurrency.TabIndex = 10;
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(9, 113);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(61, 13);
            this.lblCurrency.TabIndex = 11;
            this.lblCurrency.Text = "Currency   :\r\n";
            // 
            // chkAllCurrency
            // 
            this.chkAllCurrency.AutoSize = true;
            this.chkAllCurrency.IsSendTabOnEnter = true;
            this.chkAllCurrency.Location = new System.Drawing.Point(99, 137);
            this.chkAllCurrency.Name = "chkAllCurrency";
            this.chkAllCurrency.Size = new System.Drawing.Size(112, 17);
            this.chkAllCurrency.TabIndex = 12;
            this.chkAllCurrency.Text = "All Currency Type.";
            this.chkAllCurrency.UseVisualStyleBackColor = true;
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
            this.tsbCRUD.TabIndex = 8;
            this.tsbCRUD.EditButtonClick += new System.EventHandler(this.tsbCRUD_EditButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // MNMVEW00062
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 171);
            this.Controls.Add(this.chkAllCurrency);
            this.Controls.Add(this.lblCurrency);
            this.Controls.Add(this.rdoCurrency);
            this.Controls.Add(this.grpSort);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00062";
            this.Text = "Ledger Balance By Account Type";
            this.Load += new System.EventHandler(this.MNMVEW00062_Load);
            this.grpSort.ResumeLayout(false);
            this.grpSort.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSort;
        private Windows.CXClient.Controls.CXC0009 rdoAccountNo;
        private Windows.CXClient.Controls.CXC0009 rdoAmount;
        private Windows.CXClient.Controls.CXC0002 rdoCurrency;
        private Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Windows.CXClient.Controls.CXC0008 chkAllCurrency;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
    }
}