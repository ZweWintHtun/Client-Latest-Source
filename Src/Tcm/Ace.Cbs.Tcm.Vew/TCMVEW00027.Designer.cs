namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00027
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00027));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoSettlementDate = new System.Windows.Forms.RadioButton();
            this.rdoTransactionDate = new System.Windows.Forms.RadioButton();
            this.chkWithReserval = new System.Windows.Forms.CheckBox();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.dtpRequiredDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.lblRequiredDate = new System.Windows.Forms.Label();
            this.rdoSchedule = new System.Windows.Forms.RadioButton();
            this.rdoAbstract = new System.Windows.Forms.RadioButton();
            this.rdoScroll = new System.Windows.Forms.RadioButton();
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
            this.tsbCRUD.Size = new System.Drawing.Size(485, 31);
            this.tsbCRUD.TabIndex = 8;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoSettlementDate);
            this.groupBox1.Controls.Add(this.rdoTransactionDate);
            this.groupBox1.Location = new System.Drawing.Point(16, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 53);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // rdoSettlementDate
            // 
            this.rdoSettlementDate.AutoSize = true;
            this.rdoSettlementDate.Location = new System.Drawing.Point(119, 18);
            this.rdoSettlementDate.Name = "rdoSettlementDate";
            this.rdoSettlementDate.Size = new System.Drawing.Size(101, 17);
            this.rdoSettlementDate.TabIndex = 4;
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
            this.rdoTransactionDate.TabIndex = 3;
            this.rdoTransactionDate.TabStop = true;
            this.rdoTransactionDate.Text = "Transaction Date";
            this.rdoTransactionDate.UseVisualStyleBackColor = true;
            // 
            // chkWithReserval
            // 
            this.chkWithReserval.AutoSize = true;
            this.chkWithReserval.Location = new System.Drawing.Point(135, 189);
            this.chkWithReserval.Name = "chkWithReserval";
            this.chkWithReserval.Size = new System.Drawing.Size(93, 17);
            this.chkWithReserval.TabIndex = 7;
            this.chkWithReserval.Text = "With Reversal";
            this.chkWithReserval.UseVisualStyleBackColor = true;
            this.chkWithReserval.Visible = false;
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
            this.cboCurrency.Location = new System.Drawing.Point(135, 163);
            this.cboCurrency.Margin = new System.Windows.Forms.Padding(2);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 6;
            this.cboCurrency.Visible = false;
            // 
            // dtpRequiredDate
            // 
            this.dtpRequiredDate.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dtpRequiredDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpRequiredDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRequiredDate.IsSendTabOnEnter = true;
            this.dtpRequiredDate.Location = new System.Drawing.Point(135, 138);
            this.dtpRequiredDate.Name = "dtpRequiredDate";
            this.dtpRequiredDate.Size = new System.Drawing.Size(115, 20);
            this.dtpRequiredDate.TabIndex = 5;
            this.dtpRequiredDate.Value = new System.DateTime(2013, 7, 4, 0, 0, 0, 0);
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(13, 168);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 20;
            this.lblCurrency.Text = "Currency :";
            this.lblCurrency.Visible = false;
            // 
            // lblRequiredDate
            // 
            this.lblRequiredDate.AutoSize = true;
            this.lblRequiredDate.Location = new System.Drawing.Point(13, 141);
            this.lblRequiredDate.Name = "lblRequiredDate";
            this.lblRequiredDate.Size = new System.Drawing.Size(82, 13);
            this.lblRequiredDate.TabIndex = 19;
            this.lblRequiredDate.Text = "Required Date :";
            // 
            // rdoSchedule
            // 
            this.rdoSchedule.AutoSize = true;
            this.rdoSchedule.Checked = true;
            this.rdoSchedule.Location = new System.Drawing.Point(23, 53);
            this.rdoSchedule.Name = "rdoSchedule";
            this.rdoSchedule.Size = new System.Drawing.Size(70, 17);
            this.rdoSchedule.TabIndex = 0;
            this.rdoSchedule.TabStop = true;
            this.rdoSchedule.Text = "Schedule";
            this.rdoSchedule.UseVisualStyleBackColor = true;
            // 
            // rdoAbstract
            // 
            this.rdoAbstract.AutoSize = true;
            this.rdoAbstract.Location = new System.Drawing.Point(113, 53);
            this.rdoAbstract.Name = "rdoAbstract";
            this.rdoAbstract.Size = new System.Drawing.Size(64, 17);
            this.rdoAbstract.TabIndex = 1;
            this.rdoAbstract.Text = "Abstract";
            this.rdoAbstract.UseVisualStyleBackColor = true;
            // 
            // rdoScroll
            // 
            this.rdoScroll.AutoSize = true;
            this.rdoScroll.Location = new System.Drawing.Point(199, 53);
            this.rdoScroll.Name = "rdoScroll";
            this.rdoScroll.Size = new System.Drawing.Size(51, 17);
            this.rdoScroll.TabIndex = 2;
            this.rdoScroll.Text = "Scroll";
            this.rdoScroll.UseVisualStyleBackColor = true;
            this.rdoScroll.CheckedChanged += new System.EventHandler(this.rdoScroll_CheckedChanged);
            // 
            // TCMVEW00027
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 233);
            this.Controls.Add(this.rdoScroll);
            this.Controls.Add(this.rdoAbstract);
            this.Controls.Add(this.rdoSchedule);
            this.Controls.Add(this.chkWithReserval);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.dtpRequiredDate);
            this.Controls.Add(this.lblCurrency);
            this.Controls.Add(this.lblRequiredDate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TCMVEW00027";
            this.Text = "Daily Clearing";
            this.Load += new System.EventHandler(this.TCMVEW00027_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoSettlementDate;
        private System.Windows.Forms.RadioButton rdoTransactionDate;
        private System.Windows.Forms.CheckBox chkWithReserval;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0005 dtpRequiredDate;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.Label lblRequiredDate;
        private System.Windows.Forms.RadioButton rdoSchedule;
        private System.Windows.Forms.RadioButton rdoAbstract;
        private System.Windows.Forms.RadioButton rdoScroll;
    }
}