namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00019
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00019));
            this.gpDenomination = new System.Windows.Forms.GroupBox();
            this.gvDenomination = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Symbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotalAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtAmount1 = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblAmount1 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblTotal = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtDepositEntryNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblDepositEntryNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtWithdrawEntryNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblWithdrawEntryNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblCounterNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtCounterNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.gpDenomination.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDenomination)).BeginInit();
            this.SuspendLayout();
            // 
            // gpDenomination
            // 
            this.gpDenomination.Controls.Add(this.gvDenomination);
            this.gpDenomination.Controls.Add(this.txtTotalAmount);
            this.gpDenomination.Controls.Add(this.txtAmount1);
            this.gpDenomination.Controls.Add(this.lblAmount1);
            this.gpDenomination.Controls.Add(this.lblTotal);
            this.gpDenomination.Location = new System.Drawing.Point(10, 132);
            this.gpDenomination.Name = "gpDenomination";
            this.gpDenomination.Size = new System.Drawing.Size(554, 507);
            this.gpDenomination.TabIndex = 29;
            this.gpDenomination.TabStop = false;
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
            // txtTotalAmount
            // 
            this.txtTotalAmount.DecimalPlaces = 2;
            this.txtTotalAmount.Enabled = false;
            this.txtTotalAmount.IsSendTabOnEnter = true;
            this.txtTotalAmount.IsThousandSeperator = true;
            this.txtTotalAmount.Location = new System.Drawing.Point(444, 46);
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
            this.txtAmount1.Location = new System.Drawing.Point(444, 19);
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
            this.lblAmount1.Location = new System.Drawing.Point(346, 21);
            this.lblAmount1.Name = "lblAmount1";
            this.lblAmount1.Size = new System.Drawing.Size(49, 13);
            this.lblAmount1.TabIndex = 0;
            this.lblAmount1.Text = "Amount :";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(346, 46);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(37, 13);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Total :";
            // 
            // txtAmount
            // 
            this.txtAmount.DecimalPlaces = 2;
            this.txtAmount.Enabled = false;
            this.txtAmount.IsSendTabOnEnter = true;
            this.txtAmount.IsThousandSeperator = true;
            this.txtAmount.Location = new System.Drawing.Point(124, 104);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 31;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(12, 104);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(49, 13);
            this.lblAmount.TabIndex = 30;
            this.lblAmount.Text = "Amount :";
            // 
            // txtDepositEntryNo
            // 
            this.txtDepositEntryNo.Enabled = false;
            this.txtDepositEntryNo.IsSendTabOnEnter = true;
            this.txtDepositEntryNo.Location = new System.Drawing.Point(124, 46);
            this.txtDepositEntryNo.Name = "txtDepositEntryNo";
            this.txtDepositEntryNo.Size = new System.Drawing.Size(141, 20);
            this.txtDepositEntryNo.TabIndex = 33;
            // 
            // lblDepositEntryNo
            // 
            this.lblDepositEntryNo.AutoSize = true;
            this.lblDepositEntryNo.Location = new System.Drawing.Point(12, 49);
            this.lblDepositEntryNo.Name = "lblDepositEntryNo";
            this.lblDepositEntryNo.Size = new System.Drawing.Size(93, 13);
            this.lblDepositEntryNo.TabIndex = 32;
            this.lblDepositEntryNo.Text = "Deposit Entry No :";
            // 
            // txtWithdrawEntryNo
            // 
            this.txtWithdrawEntryNo.Enabled = false;
            this.txtWithdrawEntryNo.IsSendTabOnEnter = true;
            this.txtWithdrawEntryNo.Location = new System.Drawing.Point(124, 76);
            this.txtWithdrawEntryNo.Name = "txtWithdrawEntryNo";
            this.txtWithdrawEntryNo.Size = new System.Drawing.Size(141, 20);
            this.txtWithdrawEntryNo.TabIndex = 35;
            // 
            // lblWithdrawEntryNo
            // 
            this.lblWithdrawEntryNo.AutoSize = true;
            this.lblWithdrawEntryNo.Location = new System.Drawing.Point(12, 76);
            this.lblWithdrawEntryNo.Name = "lblWithdrawEntryNo";
            this.lblWithdrawEntryNo.Size = new System.Drawing.Size(102, 13);
            this.lblWithdrawEntryNo.TabIndex = 34;
            this.lblWithdrawEntryNo.Text = "Withdraw Entry No :";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-2, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(581, 31);
            this.tsbCRUD.TabIndex = 36;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            this.tsbCRUD.Load += new System.EventHandler(this.TCMVEW00019_Load);
            // 
            // lblCounterNo
            // 
            this.lblCounterNo.AutoSize = true;
            this.lblCounterNo.Location = new System.Drawing.Point(356, 49);
            this.lblCounterNo.Name = "lblCounterNo";
            this.lblCounterNo.Size = new System.Drawing.Size(67, 13);
            this.lblCounterNo.TabIndex = 37;
            this.lblCounterNo.Text = "Counter No :";
            // 
            // txtCounterNo
            // 
            this.txtCounterNo.Enabled = false;
            this.txtCounterNo.IsSendTabOnEnter = true;
            this.txtCounterNo.Location = new System.Drawing.Point(454, 46);
            this.txtCounterNo.Name = "txtCounterNo";
            this.txtCounterNo.Size = new System.Drawing.Size(100, 20);
            this.txtCounterNo.TabIndex = 38;
            // 
            // TCMVEW00019
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 649);
            this.Controls.Add(this.lblCounterNo);
            this.Controls.Add(this.txtCounterNo);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.txtWithdrawEntryNo);
            this.Controls.Add(this.lblWithdrawEntryNo);
            this.Controls.Add(this.txtDepositEntryNo);
            this.Controls.Add(this.lblDepositEntryNo);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.gpDenomination);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TCMVEW00019";
            this.Text = "Note Change Withdrawal Entry";
            this.Load += new System.EventHandler(this.TCMVEW00019_Load);
            this.gpDenomination.ResumeLayout(false);
            this.gpDenomination.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDenomination)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

      
       
       
        private System.Windows.Forms.GroupBox gpDenomination;
        private Windows.CXClient.Controls.AceGridView gvDenomination;
        private Windows.CXClient.Controls.CXC0004 txtTotalAmount;
        private Windows.CXClient.Controls.CXC0004 txtAmount1;
        private Windows.CXClient.Controls.CXC0003 lblAmount1;
        private Windows.CXClient.Controls.CXC0003 lblTotal;
        private Windows.CXClient.Controls.CXC0004 txtAmount;
        private Windows.CXClient.Controls.CXC0003 lblAmount;
        private Windows.CXClient.Controls.CXC0006 txtDepositEntryNo;
        private Windows.CXClient.Controls.CXC0003 lblDepositEntryNo;
        private Windows.CXClient.Controls.CXC0006 txtWithdrawEntryNo;
        private Windows.CXClient.Controls.CXC0003 lblWithdrawEntryNo;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn D1;
        private System.Windows.Forms.DataGridViewTextBoxColumn D2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Symbol;
        private Windows.CXClient.Controls.CXC0003 lblCounterNo;
        private Windows.CXClient.Controls.CXC0001 txtCounterNo;
        
    }
}