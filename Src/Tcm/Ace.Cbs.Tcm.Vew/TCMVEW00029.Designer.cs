namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00029
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00029));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoSettlementDate = new System.Windows.Forms.RadioButton();
            this.rdoTransactionDate = new System.Windows.Forms.RadioButton();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblRequiredDate = new System.Windows.Forms.Label();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.dtpRequiredDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.gpSorting = new System.Windows.Forms.GroupBox();
            this.rdoAccountNo = new System.Windows.Forms.RadioButton();
            this.rdoTime = new System.Windows.Forms.RadioButton();
            this.chkWithReserval = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.gpSorting.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoSettlementDate);
            this.groupBox1.Controls.Add(this.rdoTransactionDate);
            this.groupBox1.Location = new System.Drawing.Point(19, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 53);
            this.groupBox1.TabIndex = 9999;
            this.groupBox1.TabStop = false;
            // 
            // rdoSettlementDate
            // 
            this.rdoSettlementDate.AutoSize = true;
            this.rdoSettlementDate.Location = new System.Drawing.Point(146, 18);
            this.rdoSettlementDate.Name = "rdoSettlementDate";
            this.rdoSettlementDate.Size = new System.Drawing.Size(101, 17);
            this.rdoSettlementDate.TabIndex = 1;
            this.rdoSettlementDate.TabStop = true;
            this.rdoSettlementDate.Text = "Settlement Date";
            this.rdoSettlementDate.UseVisualStyleBackColor = true;
            // 
            // rdoTransactionDate
            // 
            this.rdoTransactionDate.AutoSize = true;
            this.rdoTransactionDate.Checked = true;
            this.rdoTransactionDate.Location = new System.Drawing.Point(7, 18);
            this.rdoTransactionDate.Name = "rdoTransactionDate";
            this.rdoTransactionDate.Size = new System.Drawing.Size(107, 17);
            this.rdoTransactionDate.TabIndex = 0;
            this.rdoTransactionDate.TabStop = true;
            this.rdoTransactionDate.Text = "Transaction Date";
            this.rdoTransactionDate.UseVisualStyleBackColor = true;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(496, 31);
            this.tsbCRUD.TabIndex = 7;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblRequiredDate
            // 
            this.lblRequiredDate.AutoSize = true;
            this.lblRequiredDate.Location = new System.Drawing.Point(17, 104);
            this.lblRequiredDate.Name = "lblRequiredDate";
            this.lblRequiredDate.Size = new System.Drawing.Size(82, 13);
            this.lblRequiredDate.TabIndex = 14;
            this.lblRequiredDate.Text = "Required Date :";
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(17, 128);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 15;
            this.lblCurrency.Text = "Currency :";
            // 
            // dtpRequiredDate
            // 
            this.dtpRequiredDate.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dtpRequiredDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpRequiredDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRequiredDate.IsSendTabOnEnter = true;
            this.dtpRequiredDate.Location = new System.Drawing.Point(112, 100);
            this.dtpRequiredDate.Name = "dtpRequiredDate";
            this.dtpRequiredDate.Size = new System.Drawing.Size(115, 20);
            this.dtpRequiredDate.TabIndex = 2;
            this.dtpRequiredDate.Value = new System.DateTime(2013, 7, 4, 0, 0, 0, 0);
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
            this.cboCurrency.Location = new System.Drawing.Point(112, 125);
            this.cboCurrency.Margin = new System.Windows.Forms.Padding(2);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 3;
            // 
            // gpSorting
            // 
            this.gpSorting.Controls.Add(this.rdoAccountNo);
            this.gpSorting.Controls.Add(this.rdoTime);
            this.gpSorting.Location = new System.Drawing.Point(20, 175);
            this.gpSorting.Name = "gpSorting";
            this.gpSorting.Size = new System.Drawing.Size(285, 75);
            this.gpSorting.TabIndex = 16;
            this.gpSorting.TabStop = false;
            this.gpSorting.Text = "Sort By";
            // 
            // rdoAccountNo
            // 
            this.rdoAccountNo.AutoSize = true;
            this.rdoAccountNo.Location = new System.Drawing.Point(29, 45);
            this.rdoAccountNo.Name = "rdoAccountNo";
            this.rdoAccountNo.Size = new System.Drawing.Size(85, 17);
            this.rdoAccountNo.TabIndex = 6;
            this.rdoAccountNo.TabStop = true;
            this.rdoAccountNo.Text = "Account No.";
            this.rdoAccountNo.UseVisualStyleBackColor = true;
            // 
            // rdoTime
            // 
            this.rdoTime.AutoSize = true;
            this.rdoTime.Checked = true;
            this.rdoTime.Location = new System.Drawing.Point(29, 22);
            this.rdoTime.Name = "rdoTime";
            this.rdoTime.Size = new System.Drawing.Size(48, 17);
            this.rdoTime.TabIndex = 5;
            this.rdoTime.TabStop = true;
            this.rdoTime.Text = "Time";
            this.rdoTime.UseVisualStyleBackColor = true;
            // 
            // chkWithReserval
            // 
            this.chkWithReserval.AutoSize = true;
            this.chkWithReserval.Location = new System.Drawing.Point(112, 151);
            this.chkWithReserval.Name = "chkWithReserval";
            this.chkWithReserval.Size = new System.Drawing.Size(93, 17);
            this.chkWithReserval.TabIndex = 4;
            this.chkWithReserval.Text = "With Reversal";
            this.chkWithReserval.UseVisualStyleBackColor = true;
            // 
            // TCMVEW00029
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 271);
            this.Controls.Add(this.chkWithReserval);
            this.Controls.Add(this.gpSorting);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.dtpRequiredDate);
            this.Controls.Add(this.lblCurrency);
            this.Controls.Add(this.lblRequiredDate);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TCMVEW00029";
            this.Text = "Overdraft Day Book ";
            this.Load += new System.EventHandler(this.TCMVEW00029_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpSorting.ResumeLayout(false);
            this.gpSorting.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.RadioButton rdoSettlementDate;
        private System.Windows.Forms.RadioButton rdoTransactionDate;
        private System.Windows.Forms.Label lblRequiredDate;
        private System.Windows.Forms.Label lblCurrency;
        private Windows.CXClient.Controls.CXC0005 dtpRequiredDate;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private System.Windows.Forms.GroupBox gpSorting;
        private System.Windows.Forms.RadioButton rdoAccountNo;
        private System.Windows.Forms.RadioButton rdoTime;
        private System.Windows.Forms.CheckBox chkWithReserval;
    }
}