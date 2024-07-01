namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00018
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00018));
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gvDenomination = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Symbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpDenomination = new System.Windows.Forms.GroupBox();
            this.txtTotalAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtAmount1 = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblAmount1 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblTotal = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCounterNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtCounterNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblTransactionDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            ((System.ComponentModel.ISupportInitialize)(this.gvDenomination)).BeginInit();
            this.gpDenomination.SuspendLayout();
            this.SuspendLayout();
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
            this.cboCurrency.Items.AddRange(new object[] {
            "KYT",
            "USD",
            "FEC",
            "SGD"});
            this.cboCurrency.Location = new System.Drawing.Point(82, 44);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 2;
            this.cboCurrency.SelectedIndexChanged += new System.EventHandler(this.cboCurrency_SelectedIndexChanged);
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(12, 44);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 1;
            this.lblCurrency.Text = "Currency :";
            // 
            // txtAmount
            // 
            this.txtAmount.DecimalPlaces = 2;
            this.txtAmount.IsSendTabOnEnter = true;
            this.txtAmount.IsThousandSeperator = true;
            this.txtAmount.IsUseFloatingPoint = true;
            this.txtAmount.Location = new System.Drawing.Point(82, 72);
            this.txtAmount.MaxLength = 18;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(111, 20);
            this.txtAmount.TabIndex = 5;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            this.txtAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyDown);
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(12, 72);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(49, 13);
            this.lblAmount.TabIndex = 6;
            this.lblAmount.Text = "Amount :";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-2, -2);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(581, 31);
            this.tsbCRUD.TabIndex = 7;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // gvDenomination
            // 
            this.gvDenomination.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvDenomination.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvDenomination.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDenomination.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDescription,
            this.Count,
            this.D1,
            this.D2,
            this.Symbol});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvDenomination.DefaultCellStyle = dataGridViewCellStyle4;
            this.gvDenomination.EnableHeadersVisualStyles = false;
            this.gvDenomination.IdTSList = null;
            this.gvDenomination.IsEscapeKey = false;
            this.gvDenomination.IsHeaderClick = false;
            this.gvDenomination.Location = new System.Drawing.Point(9, 18);
            this.gvDenomination.Name = "gvDenomination";
            this.gvDenomination.RowHeadersWidth = 25;
            this.gvDenomination.ShowSerialNo = false;
            this.gvDenomination.Size = new System.Drawing.Size(316, 479);
            this.gvDenomination.TabIndex = 1;
            this.gvDenomination.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvDenomination_CellEnter);
            this.gvDenomination.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvDenomination_CellValidated);
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colDescription.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 150;
            // 
            // Count
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.NullValue = "0";
            this.Count.DefaultCellStyle = dataGridViewCellStyle3;
            this.Count.FillWeight = 150F;
            this.Count.HeaderText = "Count";
            this.Count.Name = "Count";
            // 
            // D1
            // 
            this.D1.DataPropertyName = "D1";
            this.D1.HeaderText = "D1";
            this.D1.Name = "D1";
            this.D1.Visible = false;
            // 
            // D2
            // 
            this.D2.DataPropertyName = "D2";
            this.D2.HeaderText = "D2";
            this.D2.Name = "D2";
            this.D2.Visible = false;
            // 
            // Symbol
            // 
            this.Symbol.DataPropertyName = "Symbol";
            this.Symbol.HeaderText = "Symbol";
            this.Symbol.Name = "Symbol";
            this.Symbol.Visible = false;
            // 
            // gpDenomination
            // 
            this.gpDenomination.Controls.Add(this.gvDenomination);
            this.gpDenomination.Controls.Add(this.txtTotalAmount);
            this.gpDenomination.Controls.Add(this.txtAmount1);
            this.gpDenomination.Controls.Add(this.lblAmount1);
            this.gpDenomination.Controls.Add(this.lblTotal);
            this.gpDenomination.Location = new System.Drawing.Point(10, 96);
            this.gpDenomination.Name = "gpDenomination";
            this.gpDenomination.Size = new System.Drawing.Size(554, 507);
            this.gpDenomination.TabIndex = 8;
            this.gpDenomination.TabStop = false;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.DecimalPlaces = 2;
            this.txtTotalAmount.Enabled = false;
            this.txtTotalAmount.IsSendTabOnEnter = true;
            this.txtTotalAmount.IsThousandSeperator = true;
            this.txtTotalAmount.Location = new System.Drawing.Point(437, 46);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(100, 20);
            this.txtTotalAmount.TabIndex = 4;
            this.txtTotalAmount.Text = "0.00";
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtAmount1
            // 
            this.txtAmount1.DecimalPlaces = 2;
            this.txtAmount1.Enabled = false;
            this.txtAmount1.IsSendTabOnEnter = true;
            this.txtAmount1.IsThousandSeperator = true;
            this.txtAmount1.Location = new System.Drawing.Point(437, 19);
            this.txtAmount1.Name = "txtAmount1";
            this.txtAmount1.Size = new System.Drawing.Size(100, 20);
            this.txtAmount1.TabIndex = 3;
            this.txtAmount1.Text = "0.00";
            this.txtAmount1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount1.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblAmount1
            // 
            this.lblAmount1.AutoSize = true;
            this.lblAmount1.Location = new System.Drawing.Point(339, 21);
            this.lblAmount1.Name = "lblAmount1";
            this.lblAmount1.Size = new System.Drawing.Size(49, 13);
            this.lblAmount1.TabIndex = 0;
            this.lblAmount1.Text = "Amount :";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(339, 46);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(37, 13);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Total :";
            // 
            // lblCounterNo
            // 
            this.lblCounterNo.AutoSize = true;
            this.lblCounterNo.Location = new System.Drawing.Point(349, 77);
            this.lblCounterNo.Name = "lblCounterNo";
            this.lblCounterNo.Size = new System.Drawing.Size(67, 13);
            this.lblCounterNo.TabIndex = 9;
            this.lblCounterNo.Text = "Counter No :";
            // 
            // txtCounterNo
            // 
            this.txtCounterNo.Enabled = false;
            this.txtCounterNo.IsSendTabOnEnter = true;
            this.txtCounterNo.Location = new System.Drawing.Point(447, 74);
            this.txtCounterNo.Name = "txtCounterNo";
            this.txtCounterNo.Size = new System.Drawing.Size(100, 20);
            this.txtCounterNo.TabIndex = 10;
            // 
            // lblTransactionDate
            // 
            this.lblTransactionDate.AutoSize = true;
            this.lblTransactionDate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblTransactionDate.Location = new System.Drawing.Point(473, 47);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Size = new System.Drawing.Size(0, 13);
            this.lblTransactionDate.TabIndex = 12;
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.cxC00031.Location = new System.Drawing.Point(372, 47);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(95, 13);
            this.cxC00031.TabIndex = 11;
            this.cxC00031.Text = "Transaction Date :";
            // 
            // TCMVEW00018
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 613);
            this.Controls.Add(this.lblTransactionDate);
            this.Controls.Add(this.cxC00031);
            this.Controls.Add(this.lblCounterNo);
            this.Controls.Add(this.txtCounterNo);
            this.Controls.Add(this.gpDenomination);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.lblCurrency);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TCMVEW00018";
            this.Text = "Note Change Deposit Entry";
            this.Load += new System.EventHandler(this.TCMVEW00018_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvDenomination)).EndInit();
            this.gpDenomination.ResumeLayout(false);
            this.gpDenomination.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Windows.CXClient.Controls.CXC0004 txtAmount;
        private Windows.CXClient.Controls.CXC0003 lblAmount;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.AceGridView gvDenomination;
        private System.Windows.Forms.GroupBox gpDenomination;
        private Windows.CXClient.Controls.CXC0004 txtTotalAmount;
        private Windows.CXClient.Controls.CXC0004 txtAmount1;
        private Windows.CXClient.Controls.CXC0003 lblAmount1;
        private Windows.CXClient.Controls.CXC0003 lblTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn D1;
        private System.Windows.Forms.DataGridViewTextBoxColumn D2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Symbol;
        private Windows.CXClient.Controls.CXC0003 lblCounterNo;
        private Windows.CXClient.Controls.CXC0001 txtCounterNo;
        private Windows.CXClient.Controls.CXC0003 lblTransactionDate;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
    }
}