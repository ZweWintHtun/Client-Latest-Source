namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00011
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00011));
            this.gvDenomination = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Symbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCounterNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblCounterNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtRefundAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtTotalAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblRefund = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblTotal = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gpDenomination = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvDenomination)).BeginInit();
            this.gpDenomination.SuspendLayout();
            this.SuspendLayout();
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvDenomination.DefaultCellStyle = dataGridViewCellStyle5;
            this.gvDenomination.EnableHeadersVisualStyles = false;
            this.gvDenomination.IdTSList = null;
            this.gvDenomination.IsEscapeKey = false;
            this.gvDenomination.IsHeaderClick = false;
            this.gvDenomination.Location = new System.Drawing.Point(6, 13);
            this.gvDenomination.Name = "gvDenomination";
            this.gvDenomination.RowHeadersWidth = 25;
            this.gvDenomination.ShowSerialNo = false;
            this.gvDenomination.Size = new System.Drawing.Size(316, 479);
            this.gvDenomination.TabIndex = 1;
            this.gvDenomination.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvDenomination_CellEnter);
            this.gvDenomination.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvDenomination_CellValidated);
            this.gvDenomination.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gvDenomination_CellValidating);
            this.gvDenomination.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gvDenomination_EditingControlShowing);
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colDescription.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 144;
            // 
            // Count
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.NullValue = "0";
            this.Count.DefaultCellStyle = dataGridViewCellStyle3;
            this.Count.FillWeight = 150F;
            this.Count.HeaderText = "Count";
            this.Count.Name = "Count";
            this.Count.Width = 145;
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
            dataGridViewCellStyle4.NullValue = "0";
            this.D2.DefaultCellStyle = dataGridViewCellStyle4;
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
            // txtCounterNo
            // 
            this.txtCounterNo.IsSendTabOnEnter = true;
            this.txtCounterNo.Location = new System.Drawing.Point(444, 16);
            this.txtCounterNo.Name = "txtCounterNo";
            this.txtCounterNo.Size = new System.Drawing.Size(100, 20);
            this.txtCounterNo.TabIndex = 2;
            // 
            // lblCounterNo
            // 
            this.lblCounterNo.AutoSize = true;
            this.lblCounterNo.Location = new System.Drawing.Point(346, 19);
            this.lblCounterNo.Name = "lblCounterNo";
            this.lblCounterNo.Size = new System.Drawing.Size(67, 13);
            this.lblCounterNo.TabIndex = 0;
            this.lblCounterNo.Text = "Counter No :";
            // 
            // txtRefundAmount
            // 
            this.txtRefundAmount.DecimalPlaces = 2;
            this.txtRefundAmount.IsSendTabOnEnter = true;
            this.txtRefundAmount.IsThousandSeperator = true;
            this.txtRefundAmount.Location = new System.Drawing.Point(444, 109);
            this.txtRefundAmount.Name = "txtRefundAmount";
            this.txtRefundAmount.Size = new System.Drawing.Size(100, 20);
            this.txtRefundAmount.TabIndex = 5;
            this.txtRefundAmount.Text = "0.00";
            this.txtRefundAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRefundAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.DecimalPlaces = 2;
            this.txtTotalAmount.IsSendTabOnEnter = true;
            this.txtTotalAmount.IsThousandSeperator = true;
            this.txtTotalAmount.Location = new System.Drawing.Point(444, 81);
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
            // txtAmount
            // 
            this.txtAmount.DecimalPlaces = 2;
            this.txtAmount.IsSendTabOnEnter = true;
            this.txtAmount.IsThousandSeperator = true;
            this.txtAmount.Location = new System.Drawing.Point(444, 53);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 3;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblRefund
            // 
            this.lblRefund.AutoSize = true;
            this.lblRefund.Location = new System.Drawing.Point(346, 112);
            this.lblRefund.Name = "lblRefund";
            this.lblRefund.Size = new System.Drawing.Size(48, 13);
            this.lblRefund.TabIndex = 0;
            this.lblRefund.Text = "Refund :";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(346, 84);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(37, 13);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Total :";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(346, 56);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(49, 13);
            this.lblAmount.TabIndex = 0;
            this.lblAmount.Text = "Amount :";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(578, 31);
            this.tsbCRUD.TabIndex = 6;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // gpDenomination
            // 
            this.gpDenomination.Controls.Add(this.txtRefundAmount);
            this.gpDenomination.Controls.Add(this.gvDenomination);
            this.gpDenomination.Controls.Add(this.lblCounterNo);
            this.gpDenomination.Controls.Add(this.txtTotalAmount);
            this.gpDenomination.Controls.Add(this.lblRefund);
            this.gpDenomination.Controls.Add(this.txtCounterNo);
            this.gpDenomination.Controls.Add(this.txtAmount);
            this.gpDenomination.Controls.Add(this.lblAmount);
            this.gpDenomination.Controls.Add(this.lblTotal);
            this.gpDenomination.Location = new System.Drawing.Point(12, 37);
            this.gpDenomination.Name = "gpDenomination";
            this.gpDenomination.Size = new System.Drawing.Size(554, 497);
            this.gpDenomination.TabIndex = 0;
            this.gpDenomination.TabStop = false;
            // 
            // TLMVEW00011
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 539);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.gpDenomination);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00011";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Denomination Entry";
            this.Load += new System.EventHandler(this.TLMVEW00011_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvDenomination)).EndInit();
            this.gpDenomination.ResumeLayout(false);
            this.gpDenomination.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Ace.Windows.CXClient.Controls.AceGridView gvDenomination;
        private Ace.Windows.CXClient.Controls.CXC0001 txtCounterNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblCounterNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblRefund;
        private Ace.Windows.CXClient.Controls.CXC0003 lblTotal;
        private Ace.Windows.CXClient.Controls.CXC0003 lblAmount;
        private Ace.Windows.CXClient.Controls.CXC0004 txtRefundAmount;
        private Ace.Windows.CXClient.Controls.CXC0004 txtTotalAmount;
        private Ace.Windows.CXClient.Controls.CXC0004 txtAmount;
        private Ace.Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox gpDenomination;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn D1;
        private System.Windows.Forms.DataGridViewTextBoxColumn D2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Symbol;
    }
}