namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00040
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00040));
            this.chkWithReversal = new Ace.Windows.CXClient.Controls.CXC0008();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblRequiredDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gbSort = new System.Windows.Forms.GroupBox();
            this.rdoTime = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoAccountNo = new Ace.Windows.CXClient.Controls.CXC0009();
            this.dtpDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.gbSort.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkWithReversal
            // 
            this.chkWithReversal.AutoSize = true;
            this.chkWithReversal.IsSendTabOnEnter = true;
            this.chkWithReversal.Location = new System.Drawing.Point(17, 157);
            this.chkWithReversal.Name = "chkWithReversal";
            this.chkWithReversal.Size = new System.Drawing.Size(93, 17);
            this.chkWithReversal.TabIndex = 29;
            this.chkWithReversal.Text = "With Reversal";
            this.chkWithReversal.UseVisualStyleBackColor = true;
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
            this.cboCurrency.Location = new System.Drawing.Point(120, 68);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 28;
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(14, 73);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 41;
            this.lblCurrency.Text = "Currency :";
            // 
            // lblRequiredDate
            // 
            this.lblRequiredDate.AutoSize = true;
            this.lblRequiredDate.Location = new System.Drawing.Point(14, 45);
            this.lblRequiredDate.Name = "lblRequiredDate";
            this.lblRequiredDate.Size = new System.Drawing.Size(82, 13);
            this.lblRequiredDate.TabIndex = 40;
            this.lblRequiredDate.Text = "Required Date :";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(499, 31);
            this.tsbCRUD.TabIndex = 30;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // gbSort
            // 
            this.gbSort.Controls.Add(this.rdoTime);
            this.gbSort.Controls.Add(this.rdoAccountNo);
            this.gbSort.Location = new System.Drawing.Point(16, 95);
            this.gbSort.Name = "gbSort";
            this.gbSort.Size = new System.Drawing.Size(219, 50);
            this.gbSort.TabIndex = 31;
            this.gbSort.TabStop = false;
            this.gbSort.Text = "Sort By";
            // 
            // rdoTime
            // 
            this.rdoTime.AutoSize = true;
            this.rdoTime.IsSendTabOnEnter = true;
            this.rdoTime.Location = new System.Drawing.Point(126, 21);
            this.rdoTime.Name = "rdoTime";
            this.rdoTime.Size = new System.Drawing.Size(48, 17);
            this.rdoTime.TabIndex = 0;
            this.rdoTime.Text = "Time";
            this.rdoTime.UseVisualStyleBackColor = true;
            // 
            // rdoAccountNo
            // 
            this.rdoAccountNo.AutoSize = true;
            this.rdoAccountNo.Checked = true;
            this.rdoAccountNo.IsSendTabOnEnter = true;
            this.rdoAccountNo.Location = new System.Drawing.Point(19, 21);
            this.rdoAccountNo.Name = "rdoAccountNo";
            this.rdoAccountNo.Size = new System.Drawing.Size(82, 17);
            this.rdoAccountNo.TabIndex = 0;
            this.rdoAccountNo.TabStop = true;
            this.rdoAccountNo.Text = "Account No";
            this.rdoAccountNo.UseVisualStyleBackColor = true;
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.IsSendTabOnEnter = true;
            this.dtpDate.Location = new System.Drawing.Point(120, 42);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(115, 20);
            this.dtpDate.TabIndex = 27;
            // 
            // MNMVEW00040
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 188);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.gbSort);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.chkWithReversal);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.lblCurrency);
            this.Controls.Add(this.lblRequiredDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MNMVEW00040";
            this.Text = "Auto Link Debit Saving Vouncher Listing";
            this.Load += new System.EventHandler(this.MNMVEW00040_Load);
            this.Move += new System.EventHandler(this.MNMVEW00040_Move);
            this.gbSort.ResumeLayout(false);
            this.gbSort.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0008 chkWithReversal;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Windows.CXClient.Controls.CXC0003 lblRequiredDate;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox gbSort;
        private Windows.CXClient.Controls.CXC0009 rdoTime;
        private Windows.CXClient.Controls.CXC0009 rdoAccountNo;
        private Windows.CXClient.Controls.CXC0005 dtpDate;
    }
}