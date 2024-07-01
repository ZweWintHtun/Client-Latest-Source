namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00166
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00166));
            this.lblEntryNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUDD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblOriginalInfo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.colSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsSelected = new Ace.Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn();
            this.txtGroupNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblGroupNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtEntryNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtAcctno = new Ace.Windows.CXClient.Controls.CXC0001();
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtAmount = new Ace.Windows.CXClient.Controls.CXC0001();
            this.cxC00033 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtCheque = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtNarration = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblNarration = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gvReversal = new Ace.Windows.CXClient.Controls.AceGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTransactionDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00034 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblTransactionType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvReversal)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEntryNo
            // 
            this.lblEntryNo.AutoSize = true;
            this.lblEntryNo.Location = new System.Drawing.Point(13, 73);
            this.lblEntryNo.Name = "lblEntryNo";
            this.lblEntryNo.Size = new System.Drawing.Size(57, 13);
            this.lblEntryNo.TabIndex = 0;
            this.lblEntryNo.Text = "Entry No. :";
            // 
            // tsbCRUDD
            // 
            this.tsbCRUDD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUDD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUDD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUDD.Name = "tsbCRUDD";
            this.tsbCRUDD.PrintButtonCauseValidation = true;
            this.tsbCRUDD.Size = new System.Drawing.Size(502, 31);
            this.tsbCRUDD.TabIndex = 4;
            this.tsbCRUDD.SaveButtonClick += new System.EventHandler(this.tsbCRUDD_SaveButtonClick);
            this.tsbCRUDD.CancelButtonClick += new System.EventHandler(this.tsbCRUDD_CancelButtonClick);
            this.tsbCRUDD.ExitButtonClick += new System.EventHandler(this.tsbCRUDD_ExitButtonClick);
            // 
            // lblOriginalInfo
            // 
            this.lblOriginalInfo.AutoSize = true;
            this.lblOriginalInfo.Location = new System.Drawing.Point(13, 205);
            this.lblOriginalInfo.Name = "lblOriginalInfo";
            this.lblOriginalInfo.Size = new System.Drawing.Size(69, 13);
            this.lblOriginalInfo.TabIndex = 28;
            this.lblOriginalInfo.Text = "Transaction :";
            // 
            // colEdit
            // 
            this.colEdit.HeaderText = "";
            this.colEdit.Name = "colEdit";
            this.colEdit.Width = 30;
            // 
            // colSymbol
            // 
            this.colSymbol.DataPropertyName = "Symbol";
            this.colSymbol.HeaderText = "Symbol";
            this.colSymbol.Name = "colSymbol";
            this.colSymbol.ReadOnly = true;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 200;
            // 
            // colCode
            // 
            this.colCode.DataPropertyName = "Code";
            this.colCode.HeaderText = "Code";
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            this.colCode.Width = 150;
            // 
            // colTS
            // 
            this.colTS.DataPropertyName = "TS";
            this.colTS.HeaderText = "TS";
            this.colTS.Name = "colTS";
            this.colTS.ReadOnly = true;
            this.colTS.Visible = false;
            // 
            // colIsSelected
            // 
            this.colIsSelected.CheckBoxHeader = false;
            this.colIsSelected.DataPropertyName = "IsCheck";
            this.colIsSelected.FalseValue = "false";
            this.colIsSelected.HeaderText = "";
            this.colIsSelected.Id = 0;
            this.colIsSelected.Name = "colIsSelected";
            this.colIsSelected.TrueValue = "true";
            this.colIsSelected.TS = null;
            this.colIsSelected.Width = 30;
            // 
            // txtGroupNo
            // 
            this.txtGroupNo.IsSendTabOnEnter = true;
            this.txtGroupNo.Location = new System.Drawing.Point(93, 42);
            this.txtGroupNo.MaxLength = 11;
            this.txtGroupNo.Name = "txtGroupNo";
            this.txtGroupNo.Size = new System.Drawing.Size(141, 20);
            this.txtGroupNo.TabIndex = 0;
            this.txtGroupNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGroupNo_KeyPress);
            // 
            // lblGroupNo
            // 
            this.lblGroupNo.AutoSize = true;
            this.lblGroupNo.Location = new System.Drawing.Point(13, 45);
            this.lblGroupNo.Name = "lblGroupNo";
            this.lblGroupNo.Size = new System.Drawing.Size(62, 13);
            this.lblGroupNo.TabIndex = 0;
            this.lblGroupNo.Text = "Group No. :";
            // 
            // txtEntryNo
            // 
            this.txtEntryNo.IsSendTabOnEnter = true;
            this.txtEntryNo.Location = new System.Drawing.Point(93, 70);
            this.txtEntryNo.MaxLength = 13;
            this.txtEntryNo.Name = "txtEntryNo";
            this.txtEntryNo.Size = new System.Drawing.Size(141, 20);
            this.txtEntryNo.TabIndex = 1;
            this.txtEntryNo.Leave += new System.EventHandler(this.txtEntryNo_Leave);
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(13, 102);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(70, 13);
            this.cxC00031.TabIndex = 29;
            this.cxC00031.Text = "Account No :";
            // 
            // txtAcctno
            // 
            this.txtAcctno.Enabled = false;
            this.txtAcctno.IsSendTabOnEnter = true;
            this.txtAcctno.Location = new System.Drawing.Point(93, 99);
            this.txtAcctno.MaxLength = 40;
            this.txtAcctno.Name = "txtAcctno";
            this.txtAcctno.ReadOnly = true;
            this.txtAcctno.Size = new System.Drawing.Size(141, 20);
            this.txtAcctno.TabIndex = 30;
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.Location = new System.Drawing.Point(13, 131);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(49, 13);
            this.cxC00032.TabIndex = 31;
            this.cxC00032.Text = "Amount :";
            // 
            // txtAmount
            // 
            this.txtAmount.Enabled = false;
            this.txtAmount.IsSendTabOnEnter = true;
            this.txtAmount.Location = new System.Drawing.Point(93, 128);
            this.txtAmount.MaxLength = 40;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(141, 20);
            this.txtAmount.TabIndex = 32;
            // 
            // cxC00033
            // 
            this.cxC00033.AutoSize = true;
            this.cxC00033.Location = new System.Drawing.Point(287, 102);
            this.cxC00033.Name = "cxC00033";
            this.cxC00033.Size = new System.Drawing.Size(50, 13);
            this.cxC00033.TabIndex = 33;
            this.cxC00033.Text = "Cheque :";
            this.cxC00033.Visible = false;
            // 
            // txtCheque
            // 
            this.txtCheque.Enabled = false;
            this.txtCheque.IsSendTabOnEnter = true;
            this.txtCheque.Location = new System.Drawing.Point(346, 99);
            this.txtCheque.MaxLength = 40;
            this.txtCheque.Name = "txtCheque";
            this.txtCheque.ReadOnly = true;
            this.txtCheque.Size = new System.Drawing.Size(141, 20);
            this.txtCheque.TabIndex = 34;
            this.txtCheque.Visible = false;
            // 
            // txtNarration
            // 
            this.txtNarration.Enabled = false;
            this.txtNarration.IsSendTabOnEnter = true;
            this.txtNarration.Location = new System.Drawing.Point(93, 157);
            this.txtNarration.MaxLength = 100;
            this.txtNarration.Multiline = true;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.ReadOnly = true;
            this.txtNarration.Size = new System.Drawing.Size(394, 40);
            this.txtNarration.TabIndex = 1;
            // 
            // lblNarration
            // 
            this.lblNarration.AutoSize = true;
            this.lblNarration.Location = new System.Drawing.Point(13, 160);
            this.lblNarration.Name = "lblNarration";
            this.lblNarration.Size = new System.Drawing.Size(56, 13);
            this.lblNarration.TabIndex = 0;
            this.lblNarration.Text = "Narration :";
            // 
            // gvReversal
            // 
            this.gvReversal.AllowDrop = true;
            this.gvReversal.AllowUserToAddRows = false;
            this.gvReversal.AllowUserToDeleteRows = false;
            this.gvReversal.CausesValidation = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvReversal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvReversal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvReversal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvReversal.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvReversal.Enabled = false;
            this.gvReversal.EnableHeadersVisualStyles = false;
            this.gvReversal.IdTSList = null;
            this.gvReversal.IsEscapeKey = false;
            this.gvReversal.IsHeaderClick = false;
            this.gvReversal.Location = new System.Drawing.Point(16, 227);
            this.gvReversal.Name = "gvReversal";
            this.gvReversal.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvReversal.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gvReversal.RowHeadersWidth = 25;
            this.gvReversal.ShowSerialNo = false;
            this.gvReversal.Size = new System.Drawing.Size(471, 188);
            this.gvReversal.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Customer Names";
            this.dataGridViewTextBoxColumn2.HeaderText = "Customer Names";
            this.dataGridViewTextBoxColumn2.MaxInputLength = 15;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 250;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "NRC";
            this.dataGridViewTextBoxColumn3.HeaderText = "NRC";
            this.dataGridViewTextBoxColumn3.MaxInputLength = 30;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 180;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "TransactionCode";
            this.dataGridViewTextBoxColumn4.HeaderText = "TransactionCode";
            this.dataGridViewTextBoxColumn4.MaxInputLength = 5;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            this.dataGridViewTextBoxColumn4.Width = 190;
            // 
            // lblTransactionDate
            // 
            this.lblTransactionDate.AutoSize = true;
            this.lblTransactionDate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblTransactionDate.Location = new System.Drawing.Point(431, 42);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Size = new System.Drawing.Size(0, 13);
            this.lblTransactionDate.TabIndex = 36;
            // 
            // cxC00034
            // 
            this.cxC00034.AutoSize = true;
            this.cxC00034.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.cxC00034.Location = new System.Drawing.Point(333, 42);
            this.cxC00034.Name = "cxC00034";
            this.cxC00034.Size = new System.Drawing.Size(95, 13);
            this.cxC00034.TabIndex = 35;
            this.cxC00034.Text = "Transaction Date :";
            // 
            // lblTransactionType
            // 
            this.lblTransactionType.AutoSize = true;
            this.lblTransactionType.Location = new System.Drawing.Point(91, 205);
            this.lblTransactionType.Name = "lblTransactionType";
            this.lblTransactionType.Size = new System.Drawing.Size(0, 13);
            this.lblTransactionType.TabIndex = 37;
            // 
            // MNMVEW00166
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 436);
            this.Controls.Add(this.lblTransactionType);
            this.Controls.Add(this.lblTransactionDate);
            this.Controls.Add(this.cxC00034);
            this.Controls.Add(this.gvReversal);
            this.Controls.Add(this.cxC00033);
            this.Controls.Add(this.txtCheque);
            this.Controls.Add(this.cxC00032);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.cxC00031);
            this.Controls.Add(this.txtAcctno);
            this.Controls.Add(this.txtEntryNo);
            this.Controls.Add(this.txtGroupNo);
            this.Controls.Add(this.lblGroupNo);
            this.Controls.Add(this.lblOriginalInfo);
            this.Controls.Add(this.tsbCRUDD);
            this.Controls.Add(this.lblNarration);
            this.Controls.Add(this.lblEntryNo);
            this.Controls.Add(this.txtNarration);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MNMVEW00166";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Multiple Deposit And Withdraw Reversal  ";
            this.Load += new System.EventHandler(this.MNMVEW00166_Load);
            this.Move += new System.EventHandler(this.MNMVEW00166_Move);
            ((System.ComponentModel.ISupportInitialize)(this.gvReversal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0003 lblEntryNo;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUDD;
        private Windows.CXClient.Controls.CXC0003 lblOriginalInfo;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTS;
        private Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn colIsSelected;
       // private Windows.CXClient.Controls.AceGridView gvAccountType;
        private Windows.CXClient.Controls.CXC0001 txtGroupNo;
        private Windows.CXClient.Controls.CXC0003 lblGroupNo;
        private Windows.CXClient.Controls.CXC0001 txtEntryNo;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0001 txtAcctno;
        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private Windows.CXClient.Controls.CXC0001 txtAmount;
        private Windows.CXClient.Controls.CXC0003 cxC00033;
        private Windows.CXClient.Controls.CXC0001 txtCheque;
        private Windows.CXClient.Controls.CXC0001 txtNarration;
        private Windows.CXClient.Controls.CXC0003 lblNarration;
        private Windows.CXClient.Controls.AceGridView gvReversal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private Windows.CXClient.Controls.CXC0003 lblTransactionDate;
        private Windows.CXClient.Controls.CXC0003 cxC00034;
        private System.Windows.Forms.Label lblTransactionType;

    }
}