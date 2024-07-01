namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00005
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00005));
            this.lblEntryNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCounterNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblTo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.txtCounterNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtEntryNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.ntxtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblToName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTransactionDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEntryNo
            // 
            this.lblEntryNo.AutoSize = true;
            this.lblEntryNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntryNo.Location = new System.Drawing.Point(26, 21);
            this.lblEntryNo.Name = "lblEntryNo";
            this.lblEntryNo.Size = new System.Drawing.Size(57, 13);
            this.lblEntryNo.TabIndex = 0;
            this.lblEntryNo.Text = "Entry No : ";
            // 
            // lblCounterNo
            // 
            this.lblCounterNo.AutoSize = true;
            this.lblCounterNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCounterNo.Location = new System.Drawing.Point(26, 52);
            this.lblCounterNo.Name = "lblCounterNo";
            this.lblCounterNo.Size = new System.Drawing.Size(67, 13);
            this.lblCounterNo.TabIndex = 0;
            this.lblCounterNo.Text = "Counter No :";
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrency.Location = new System.Drawing.Point(26, 84);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 0;
            this.lblCurrency.Text = "Currency :";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(26, 117);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(49, 13);
            this.lblAmount.TabIndex = 0;
            this.lblAmount.Text = "Amount :";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(26, 144);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(26, 13);
            this.lblTo.TabIndex = 0;
            this.lblTo.Text = "To :";
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
            this.cboCurrency.Location = new System.Drawing.Point(109, 81);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 3;
            // 
            // txtCounterNo
            // 
            this.txtCounterNo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtCounterNo.Enabled = false;
            this.txtCounterNo.IsSendTabOnEnter = true;
            this.txtCounterNo.Location = new System.Drawing.Point(109, 49);
            this.txtCounterNo.Name = "txtCounterNo";
            this.txtCounterNo.Size = new System.Drawing.Size(141, 20);
            this.txtCounterNo.TabIndex = 2;
            // 
            // txtEntryNo
            // 
            this.txtEntryNo.IsSendTabOnEnter = true;
            this.txtEntryNo.Location = new System.Drawing.Point(109, 18);
            this.txtEntryNo.Name = "txtEntryNo";
            this.txtEntryNo.Size = new System.Drawing.Size(141, 20);
            this.txtEntryNo.TabIndex = 1;
            // 
            // ntxtAmount
            // 
            this.ntxtAmount.DecimalPlaces = 2;
            this.ntxtAmount.IsSendTabOnEnter = true;
            this.ntxtAmount.IsThousandSeperator = true;
            this.ntxtAmount.IsUseFloatingPoint = true;
            this.ntxtAmount.Location = new System.Drawing.Point(109, 114);
            this.ntxtAmount.Name = "ntxtAmount";
            this.ntxtAmount.Size = new System.Drawing.Size(111, 20);
            this.ntxtAmount.TabIndex = 4;
            this.ntxtAmount.Text = "0.00";
            this.ntxtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntxtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(833, 31);
            this.tsbCRUD.TabIndex = 5;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblToName
            // 
            this.lblToName.AutoSize = true;
            this.lblToName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToName.Location = new System.Drawing.Point(106, 144);
            this.lblToName.Name = "lblToName";
            this.lblToName.Size = new System.Drawing.Size(68, 13);
            this.lblToName.TabIndex = 0;
            this.lblToName.Text = "Center Table";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCounterNo);
            this.groupBox1.Controls.Add(this.lblEntryNo);
            this.groupBox1.Controls.Add(this.ntxtAmount);
            this.groupBox1.Controls.Add(this.lblCounterNo);
            this.groupBox1.Controls.Add(this.lblToName);
            this.groupBox1.Controls.Add(this.lblCurrency);
            this.groupBox1.Controls.Add(this.lblTo);
            this.groupBox1.Controls.Add(this.txtEntryNo);
            this.groupBox1.Controls.Add(this.lblAmount);
            this.groupBox1.Controls.Add(this.cboCurrency);
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 168);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // lblTransactionDate
            // 
            this.lblTransactionDate.AutoSize = true;
            this.lblTransactionDate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblTransactionDate.Location = new System.Drawing.Point(420, 44);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Size = new System.Drawing.Size(0, 13);
            this.lblTransactionDate.TabIndex = 8;
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.cxC00031.Location = new System.Drawing.Point(319, 44);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(95, 13);
            this.cxC00031.TabIndex = 7;
            this.cxC00031.Text = "Transaction Date :";
            // 
            // TLMVEW00005
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 212);
            this.Controls.Add(this.lblTransactionDate);
            this.Controls.Add(this.cxC00031);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsbCRUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00005";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Counter Withdrawal Entry";
            this.Load += new System.EventHandler(this.TLMVEW00005_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ace.Windows.CXClient.Controls.CXC0003 lblEntryNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblCounterNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Ace.Windows.CXClient.Controls.CXC0006 txtEntryNo;
        private Ace.Windows.CXClient.Controls.CXC0006 txtCounterNo;
        private Ace.Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Ace.Windows.CXClient.Controls.CXC0003 lblAmount;
        private Ace.Windows.CXClient.Controls.CXC0003 lblTo;
        private Ace.Windows.CXClient.Controls.CXC0004 ntxtAmount;
        private Ace.Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Ace.Windows.CXClient.Controls.CXC0003 lblToName;
        private System.Windows.Forms.GroupBox groupBox1;
        private Windows.CXClient.Controls.CXC0003 lblTransactionDate;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
    }
}