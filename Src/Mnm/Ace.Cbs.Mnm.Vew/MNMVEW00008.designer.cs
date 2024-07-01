namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00008
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00008));
            this.txtNarration = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblEntryNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblNarration = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblOriginalInfo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.mtxtEntryNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.gvCashVoucher = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colAccountTypeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTransactionDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            ((System.ComponentModel.ISupportInitialize)(this.gvCashVoucher)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNarration
            // 
            this.txtNarration.IsSendTabOnEnter = true;
            this.txtNarration.Location = new System.Drawing.Point(93, 72);
            this.txtNarration.MaxLength = 30;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(141, 20);
            this.txtNarration.TabIndex = 0;
            // 
            // lblEntryNo
            // 
            this.lblEntryNo.AutoSize = true;
            this.lblEntryNo.Location = new System.Drawing.Point(12, 45);
            this.lblEntryNo.Name = "lblEntryNo";
            this.lblEntryNo.Size = new System.Drawing.Size(57, 13);
            this.lblEntryNo.TabIndex = 0;
            this.lblEntryNo.Text = "Entry No. :";
            // 
            // lblNarration
            // 
            this.lblNarration.AutoSize = true;
            this.lblNarration.Location = new System.Drawing.Point(12, 72);
            this.lblNarration.Name = "lblNarration";
            this.lblNarration.Size = new System.Drawing.Size(56, 13);
            this.lblNarration.TabIndex = 0;
            this.lblNarration.Text = "Narration :";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(511, 31);
            this.tsbCRUD.butSave.TabIndex = 2;
            this.tsbCRUD.butCancel.TabIndex = 3;
            this.tsbCRUD.butExit.TabIndex = 4;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblOriginalInfo
            // 
            this.lblOriginalInfo.AutoSize = true;
            this.lblOriginalInfo.Location = new System.Drawing.Point(13, 108);
            this.lblOriginalInfo.Name = "lblOriginalInfo";
            this.lblOriginalInfo.Size = new System.Drawing.Size(103, 13);
            this.lblOriginalInfo.TabIndex = 12;
            this.lblOriginalInfo.Text = "Original Information :";
            // 
            // mtxtEntryNo
            // 
            this.mtxtEntryNo.IsSendTabOnEnter = true;
            this.mtxtEntryNo.Location = new System.Drawing.Point(93, 42);
            this.mtxtEntryNo.Name = "mtxtEntryNo";
            this.mtxtEntryNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtEntryNo.TabIndex = 6;
            // 
            // gvCashVoucher
            // 
            this.gvCashVoucher.AllowUserToAddRows = false;
            this.gvCashVoucher.AllowUserToOrderColumns = true;
            this.gvCashVoucher.CausesValidation = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvCashVoucher.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvCashVoucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCashVoucher.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAccountTypeCode,
            this.dataGridViewTextBoxColumn1,
            this.colAccountTypeId,
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvCashVoucher.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvCashVoucher.EnableHeadersVisualStyles = false;
            this.gvCashVoucher.IdTSList = null;
            this.gvCashVoucher.IsEscapeKey = false;
            this.gvCashVoucher.IsHeaderClick = false;
            this.gvCashVoucher.Location = new System.Drawing.Point(16, 127);
            this.gvCashVoucher.Name = "gvCashVoucher";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvCashVoucher.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gvCashVoucher.RowHeadersWidth = 25;
            this.gvCashVoucher.ShowSerialNo = false;
            this.gvCashVoucher.Size = new System.Drawing.Size(472, 165);
            this.gvCashVoucher.TabIndex = 1;
            // 
            // colAccountTypeCode
            // 
            this.colAccountTypeCode.DataPropertyName = "AccountNo";
            this.colAccountTypeCode.HeaderText = "AccountNo";
            this.colAccountTypeCode.MaxInputLength = 15;
            this.colAccountTypeCode.Name = "colAccountTypeCode";
            this.colAccountTypeCode.ReadOnly = true;
            this.colAccountTypeCode.Width = 140;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Amount";
            this.dataGridViewTextBoxColumn1.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 140;
            // 
            // colAccountTypeId
            // 
            this.colAccountTypeId.DataPropertyName = "TransactionCode";
            this.colAccountTypeId.HeaderText = "Debit/Credit";
            this.colAccountTypeId.MaxInputLength = 10;
            this.colAccountTypeId.Name = "colAccountTypeId";
            this.colAccountTypeId.Width = 120;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "TS";
            this.dataGridViewTextBoxColumn4.HeaderText = "TS";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // lblTransactionDate
            // 
            this.lblTransactionDate.AutoSize = true;
            this.lblTransactionDate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblTransactionDate.Location = new System.Drawing.Point(409, 44);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Size = new System.Drawing.Size(0, 13);
            this.lblTransactionDate.TabIndex = 16;
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.cxC00031.Location = new System.Drawing.Point(308, 44);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(95, 13);
            this.cxC00031.TabIndex = 15;
            this.cxC00031.Text = "Transaction Date :";
            // 
            // MNMVEW00008
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 311);
            this.Controls.Add(this.lblTransactionDate);
            this.Controls.Add(this.cxC00031);
            this.Controls.Add(this.gvCashVoucher);
            this.Controls.Add(this.mtxtEntryNo);
            this.Controls.Add(this.lblOriginalInfo);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.lblNarration);
            this.Controls.Add(this.lblEntryNo);
            this.Controls.Add(this.txtNarration);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MNMVEW00008";
            this.Text = "Cash Voucher Reversal";
            this.Load += new System.EventHandler(this.MNMVEW00008_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormName_KeyDown);
            this.Move += new System.EventHandler(this.MNMVEW00008_Move);
            ((System.ComponentModel.ISupportInitialize)(this.gvCashVoucher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0001 txtNarration;
        private Windows.CXClient.Controls.CXC0003 lblEntryNo;
        private Windows.CXClient.Controls.CXC0003 lblNarration;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0003 lblOriginalInfo;
        private Windows.CXClient.Controls.CXC0006 mtxtEntryNo;
        private Windows.CXClient.Controls.AceGridView gvCashVoucher;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountTypeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private Windows.CXClient.Controls.CXC0003 lblTransactionDate;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
    }
}