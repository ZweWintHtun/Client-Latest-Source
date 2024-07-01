namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00070
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbGiftCheque = new System.Windows.Forms.GroupBox();
            this.txtToName = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtFromName = new Ace.Windows.CXClient.Controls.CXC0001();
            this.gvGiftChequeIssueTransfer = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colAcctNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFromName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGCNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtTotal = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtToal = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtChequeNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.cxC00035 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtCharges = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblCharges = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtGiftChequeNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblGiftChequeNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblToName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblFromName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.chkVIP = new Ace.Windows.CXClient.Controls.CXC0008();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gbGiftCheque.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvGiftChequeIssueTransfer)).BeginInit();
            this.SuspendLayout();
            // 
            // gbGiftCheque
            // 
            this.gbGiftCheque.Controls.Add(this.txtToName);
            this.gbGiftCheque.Controls.Add(this.txtFromName);
            this.gbGiftCheque.Controls.Add(this.gvGiftChequeIssueTransfer);
            this.gbGiftCheque.Controls.Add(this.txtTotal);
            this.gbGiftCheque.Controls.Add(this.txtToal);
            this.gbGiftCheque.Controls.Add(this.txtChequeNo);
            this.gbGiftCheque.Controls.Add(this.cxC00035);
            this.gbGiftCheque.Controls.Add(this.txtCharges);
            this.gbGiftCheque.Controls.Add(this.lblCharges);
            this.gbGiftCheque.Controls.Add(this.txtGiftChequeNo);
            this.gbGiftCheque.Controls.Add(this.lblGiftChequeNo);
            this.gbGiftCheque.Controls.Add(this.txtAmount);
            this.gbGiftCheque.Controls.Add(this.lblAmount);
            this.gbGiftCheque.Controls.Add(this.lblToName);
            this.gbGiftCheque.Controls.Add(this.lblFromName);
            this.gbGiftCheque.Controls.Add(this.mtxtAccountNo);
            this.gbGiftCheque.Controls.Add(this.chkVIP);
            this.gbGiftCheque.Controls.Add(this.lblAccountNo);
            this.gbGiftCheque.Location = new System.Drawing.Point(12, 41);
            this.gbGiftCheque.Name = "gbGiftCheque";
            this.gbGiftCheque.Size = new System.Drawing.Size(709, 333);
            this.gbGiftCheque.TabIndex = 0;
            this.gbGiftCheque.TabStop = false;
            this.gbGiftCheque.Text = "Gift Cheque Issue By Transfer Infomation";
            // 
            // txtToName
            // 
            this.txtToName.IsSendTabOnEnter = true;
            this.txtToName.Location = new System.Drawing.Point(484, 73);
            this.txtToName.Name = "txtToName";
            this.txtToName.Size = new System.Drawing.Size(158, 20);
            this.txtToName.TabIndex = 4;
            // 
            // txtFromName
            // 
            this.txtFromName.BackColor = System.Drawing.SystemColors.Window;
            this.txtFromName.IsSendTabOnEnter = true;
            this.txtFromName.Location = new System.Drawing.Point(124, 73);
            this.txtFromName.Name = "txtFromName";
            this.txtFromName.ReadOnly = true;
            this.txtFromName.Size = new System.Drawing.Size(158, 20);
            this.txtFromName.TabIndex = 3;
            // 
            // gvGiftChequeIssueTransfer
            // 
            this.gvGiftChequeIssueTransfer.AllowUserToAddRows = false;
            this.gvGiftChequeIssueTransfer.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvGiftChequeIssueTransfer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvGiftChequeIssueTransfer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvGiftChequeIssueTransfer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAcctNo,
            this.colFromName,
            this.colTotalAmount,
            this.colGCNo,
            this.colId,
            this.colEdit,
            this.colDelete});
            this.gvGiftChequeIssueTransfer.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvGiftChequeIssueTransfer.DefaultCellStyle = dataGridViewCellStyle4;
            this.gvGiftChequeIssueTransfer.EnableHeadersVisualStyles = false;
            this.gvGiftChequeIssueTransfer.IdTSList = null;
            this.gvGiftChequeIssueTransfer.IsEscapeKey = false;
            this.gvGiftChequeIssueTransfer.IsHeaderClick = false;
            this.gvGiftChequeIssueTransfer.Location = new System.Drawing.Point(9, 186);
            this.gvGiftChequeIssueTransfer.Name = "gvGiftChequeIssueTransfer";
            this.gvGiftChequeIssueTransfer.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvGiftChequeIssueTransfer.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gvGiftChequeIssueTransfer.RowHeadersWidth = 25;
            this.gvGiftChequeIssueTransfer.ShowSerialNo = true;
            this.gvGiftChequeIssueTransfer.Size = new System.Drawing.Size(688, 133);
            this.gvGiftChequeIssueTransfer.TabIndex = 12;
            // 
            // colAcctNo
            // 
            this.colAcctNo.DataPropertyName = "ACCTNO";
            this.colAcctNo.HeaderText = "Account No";
            this.colAcctNo.Name = "colAcctNo";
            this.colAcctNo.ReadOnly = true;
            this.colAcctNo.Width = 150;
            // 
            // colFromName
            // 
            this.colFromName.DataPropertyName = "Name";
            this.colFromName.HeaderText = "Description";
            this.colFromName.Name = "colFromName";
            this.colFromName.ReadOnly = true;
            this.colFromName.Width = 200;
            // 
            // colTotalAmount
            // 
            this.colTotalAmount.DataPropertyName = "TotalAMOUNT";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colTotalAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.colTotalAmount.HeaderText = "Amount";
            this.colTotalAmount.Name = "colTotalAmount";
            this.colTotalAmount.ReadOnly = true;
            // 
            // colGCNo
            // 
            this.colGCNo.DataPropertyName = "GCNO";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colGCNo.DefaultCellStyle = dataGridViewCellStyle3;
            this.colGCNo.HeaderText = "Gift Cheque No";
            this.colGCNo.Name = "colGCNo";
            this.colGCNo.ReadOnly = true;
            this.colGCNo.Width = 150;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            this.colId.Width = 10;
            // 
            // colEdit
            // 
            this.colEdit.HeaderText = "";
            this.colEdit.Image = global::Ace.Cbs.Tcm.Vew.Properties.Resources.edit;
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            this.colEdit.ToolTipText = "Edit";
            this.colEdit.Width = 30;
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "";
            this.colDelete.Image = global::Ace.Cbs.Tcm.Vew.Properties.Resources.Delete_Main;
            this.colDelete.Name = "colDelete";
            this.colDelete.ReadOnly = true;
            this.colDelete.ToolTipText = "Delete";
            this.colDelete.Width = 30;
            // 
            // txtTotal
            // 
            this.txtTotal.AutoSize = true;
            this.txtTotal.Location = new System.Drawing.Point(405, 125);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(37, 13);
            this.txtTotal.TabIndex = 21;
            this.txtTotal.Text = "Total :";
            // 
            // txtToal
            // 
            this.txtToal.BackColor = System.Drawing.SystemColors.Window;
            this.txtToal.DecimalPlaces = 2;
            this.txtToal.IsSendTabOnEnter = true;
            this.txtToal.IsThousandSeperator = true;
            this.txtToal.IsUseFloatingPoint = true;
            this.txtToal.Location = new System.Drawing.Point(484, 122);
            this.txtToal.Margin = new System.Windows.Forms.Padding(2);
            this.txtToal.MaxLength = 18;
            this.txtToal.Name = "txtToal";
            this.txtToal.ReadOnly = true;
            this.txtToal.Size = new System.Drawing.Size(111, 20);
            this.txtToal.TabIndex = 9;
            this.txtToal.Text = "0.00";
            this.txtToal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtToal.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.IsSendTabOnEnter = true;
            this.txtChequeNo.Location = new System.Drawing.Point(124, 149);
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(115, 20);
            this.txtChequeNo.TabIndex = 10;
            this.txtChequeNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // cxC00035
            // 
            this.cxC00035.AutoSize = true;
            this.cxC00035.Location = new System.Drawing.Point(21, 152);
            this.cxC00035.Name = "cxC00035";
            this.cxC00035.Size = new System.Drawing.Size(67, 13);
            this.cxC00035.TabIndex = 17;
            this.cxC00035.Text = "Cheque No :";
            // 
            // txtCharges
            // 
            this.txtCharges.BackColor = System.Drawing.SystemColors.Window;
            this.txtCharges.DecimalPlaces = 2;
            this.txtCharges.IsSendTabOnEnter = true;
            this.txtCharges.IsThousandSeperator = true;
            this.txtCharges.IsUseFloatingPoint = true;
            this.txtCharges.Location = new System.Drawing.Point(484, 98);
            this.txtCharges.Margin = new System.Windows.Forms.Padding(2);
            this.txtCharges.MaxLength = 18;
            this.txtCharges.Name = "txtCharges";
            this.txtCharges.ReadOnly = true;
            this.txtCharges.Size = new System.Drawing.Size(111, 20);
            this.txtCharges.TabIndex = 6;
            this.txtCharges.Text = "0.00";
            this.txtCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCharges.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblCharges
            // 
            this.lblCharges.AutoSize = true;
            this.lblCharges.Location = new System.Drawing.Point(405, 101);
            this.lblCharges.Name = "lblCharges";
            this.lblCharges.Size = new System.Drawing.Size(52, 13);
            this.lblCharges.TabIndex = 15;
            this.lblCharges.Text = "Charges :";
            // 
            // txtGiftChequeNo
            // 
            this.txtGiftChequeNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtGiftChequeNo.IsSendTabOnEnter = true;
            this.txtGiftChequeNo.Location = new System.Drawing.Point(124, 123);
            this.txtGiftChequeNo.Name = "txtGiftChequeNo";
            this.txtGiftChequeNo.ReadOnly = true;
            this.txtGiftChequeNo.Size = new System.Drawing.Size(115, 20);
            this.txtGiftChequeNo.TabIndex = 7;
            this.txtGiftChequeNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblGiftChequeNo
            // 
            this.lblGiftChequeNo.AutoSize = true;
            this.lblGiftChequeNo.Location = new System.Drawing.Point(21, 126);
            this.lblGiftChequeNo.Name = "lblGiftChequeNo";
            this.lblGiftChequeNo.Size = new System.Drawing.Size(86, 13);
            this.lblGiftChequeNo.TabIndex = 13;
            this.lblGiftChequeNo.Text = "Gift Cheque No :";
            // 
            // txtAmount
            // 
            this.txtAmount.DecimalPlaces = 2;
            this.txtAmount.IsSendTabOnEnter = true;
            this.txtAmount.IsThousandSeperator = true;
            this.txtAmount.IsUseFloatingPoint = true;
            this.txtAmount.Location = new System.Drawing.Point(124, 98);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(2);
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
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(22, 102);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(49, 13);
            this.lblAmount.TabIndex = 11;
            this.lblAmount.Text = "Amount :";
            // 
            // lblToName
            // 
            this.lblToName.AutoSize = true;
            this.lblToName.Location = new System.Drawing.Point(405, 76);
            this.lblToName.Name = "lblToName";
            this.lblToName.Size = new System.Drawing.Size(26, 13);
            this.lblToName.TabIndex = 9;
            this.lblToName.Text = "To :";
            // 
            // lblFromName
            // 
            this.lblFromName.AutoSize = true;
            this.lblFromName.Location = new System.Drawing.Point(21, 78);
            this.lblFromName.Name = "lblFromName";
            this.lblFromName.Size = new System.Drawing.Size(36, 13);
            this.lblFromName.TabIndex = 7;
            this.lblFromName.Text = "From :";
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.BackColor = System.Drawing.SystemColors.Window;
            this.mtxtAccountNo.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtxtAccountNo.HidePromptOnLeave = true;
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(124, 47);
            this.mtxtAccountNo.Mask = "&&&-&&&-&&&&&&&&&";
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 2;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // chkVIP
            // 
            this.chkVIP.AutoSize = true;
            this.chkVIP.IsSendTabOnEnter = true;
            this.chkVIP.Location = new System.Drawing.Point(24, 21);
            this.chkVIP.Name = "chkVIP";
            this.chkVIP.Size = new System.Drawing.Size(90, 17);
            this.chkVIP.TabIndex = 1;
            this.chkVIP.Text = "VIP Customer";
            this.chkVIP.UseVisualStyleBackColor = true;
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(21, 50);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(70, 13);
            this.lblAccountNo.TabIndex = 4;
            this.lblAccountNo.Text = "Account No :";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, -1);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(732, 31);
            this.tsbCRUD.TabIndex = 7;
            // 
            // TCMVEW00070
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 382);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.gbGiftCheque);
            this.Name = "TCMVEW00070";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TCMVEW00070_Load);
            this.gbGiftCheque.ResumeLayout(false);
            this.gbGiftCheque.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvGiftChequeIssueTransfer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbGiftCheque;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Windows.CXClient.Controls.CXC0008 chkVIP;
        private Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblFromName;
        private Windows.CXClient.Controls.CXC0003 lblToName;
        private Windows.CXClient.Controls.CXC0003 lblAmount;
        private Windows.CXClient.Controls.CXC0004 txtAmount;
        private Windows.CXClient.Controls.CXC0006 txtGiftChequeNo;
        private Windows.CXClient.Controls.CXC0003 lblGiftChequeNo;
        private Windows.CXClient.Controls.CXC0004 txtCharges;
        private Windows.CXClient.Controls.CXC0003 lblCharges;
        private Windows.CXClient.Controls.CXC0006 txtChequeNo;
        private Windows.CXClient.Controls.CXC0003 cxC00035;
        private Windows.CXClient.Controls.CXC0003 txtTotal;
        private Windows.CXClient.Controls.CXC0004 txtToal;
        private Windows.CXClient.Controls.AceGridView gvGiftChequeIssueTransfer;
        private Windows.CXClient.Controls.CXC0001 txtToName;
        private Windows.CXClient.Controls.CXC0001 txtFromName;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAcctNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFromName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGCNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
        private System.Windows.Forms.DataGridViewImageColumn colDelete;
    }
}