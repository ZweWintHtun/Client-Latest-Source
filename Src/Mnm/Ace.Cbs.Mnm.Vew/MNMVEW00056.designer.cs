namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00056
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00056));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.rdoBranch = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoCounter = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoVault = new Ace.Windows.CXClient.Controls.CXC0009();
            this.dtpEnterDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.cboCounterNo = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblEnterDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.chkBeforeEditing = new Ace.Windows.CXClient.Controls.CXC0008();
            this.grpCounterItem = new System.Windows.Forms.GroupBox();
            this.rdoAll = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoReceipt = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoPayment = new Ace.Windows.CXClient.Controls.CXC0009();
            this.chkItem = new Ace.Windows.CXClient.Controls.CXC0008();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.chkNonIssueableNote = new Ace.Windows.CXClient.Controls.CXC0008();
            this.dgvCashControl = new System.Windows.Forms.DataGridView();
            this.grpCounterItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashControl)).BeginInit();
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
            this.tsbCRUD.Size = new System.Drawing.Size(496, 31);
            this.tsbCRUD.TabIndex = 12;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // rdoBranch
            // 
            this.rdoBranch.AutoSize = true;
            this.rdoBranch.Checked = true;
            this.rdoBranch.IsSendTabOnEnter = true;
            this.rdoBranch.Location = new System.Drawing.Point(16, 48);
            this.rdoBranch.Name = "rdoBranch";
            this.rdoBranch.Size = new System.Drawing.Size(59, 17);
            this.rdoBranch.TabIndex = 0;
            this.rdoBranch.TabStop = true;
            this.rdoBranch.Text = "Branch";
            this.rdoBranch.UseVisualStyleBackColor = true;
            this.rdoBranch.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rdoCounter
            // 
            this.rdoCounter.AutoSize = true;
            this.rdoCounter.IsSendTabOnEnter = true;
            this.rdoCounter.Location = new System.Drawing.Point(198, 48);
            this.rdoCounter.Name = "rdoCounter";
            this.rdoCounter.Size = new System.Drawing.Size(62, 17);
            this.rdoCounter.TabIndex = 2;
            this.rdoCounter.Text = "Counter";
            this.rdoCounter.UseVisualStyleBackColor = true;
            this.rdoCounter.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rdoVault
            // 
            this.rdoVault.AutoSize = true;
            this.rdoVault.IsSendTabOnEnter = true;
            this.rdoVault.Location = new System.Drawing.Point(111, 48);
            this.rdoVault.Name = "rdoVault";
            this.rdoVault.Size = new System.Drawing.Size(49, 17);
            this.rdoVault.TabIndex = 1;
            this.rdoVault.Text = "Vault";
            this.rdoVault.UseVisualStyleBackColor = true;
            this.rdoVault.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // dtpEnterDate
            // 
            this.dtpEnterDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpEnterDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnterDate.IsSendTabOnEnter = true;
            this.dtpEnterDate.Location = new System.Drawing.Point(101, 131);
            this.dtpEnterDate.Name = "dtpEnterDate";
            this.dtpEnterDate.Size = new System.Drawing.Size(115, 20);
            this.dtpEnterDate.TabIndex = 5;
            // 
            // cboCounterNo
            // 
            this.cboCounterNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCounterNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCounterNo.Cursor = System.Windows.Forms.Cursors.Default;
            this.cboCounterNo.DropDownHeight = 200;
            this.cboCounterNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCounterNo.FormattingEnabled = true;
            this.cboCounterNo.IntegralHeight = false;
            this.cboCounterNo.IsSendTabOnEnter = true;
            this.cboCounterNo.Location = new System.Drawing.Point(101, 77);
            this.cboCounterNo.Name = "cboCounterNo";
            this.cboCounterNo.Size = new System.Drawing.Size(159, 21);
            this.cboCounterNo.TabIndex = 3;
            this.cboCounterNo.SelectedIndexChanged += new System.EventHandler(this.cboCounterNo_SelectedIndexChanged);
            // 
            // lblEnterDate
            // 
            this.lblEnterDate.AutoSize = true;
            this.lblEnterDate.Location = new System.Drawing.Point(13, 135);
            this.lblEnterDate.Name = "lblEnterDate";
            this.lblEnterDate.Size = new System.Drawing.Size(64, 13);
            this.lblEnterDate.TabIndex = 44;
            this.lblEnterDate.Text = "Enter Date :";
            // 
            // lblNo
            // 
            this.lblNo.AutoSize = true;
            this.lblNo.Location = new System.Drawing.Point(13, 80);
            this.lblNo.Name = "lblNo";
            this.lblNo.Size = new System.Drawing.Size(67, 13);
            this.lblNo.TabIndex = 43;
            this.lblNo.Text = "Branch No. :";
            // 
            // chkBeforeEditing
            // 
            this.chkBeforeEditing.AutoSize = true;
            this.chkBeforeEditing.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkBeforeEditing.IsSendTabOnEnter = true;
            this.chkBeforeEditing.Location = new System.Drawing.Point(101, 157);
            this.chkBeforeEditing.Name = "chkBeforeEditing";
            this.chkBeforeEditing.Size = new System.Drawing.Size(92, 17);
            this.chkBeforeEditing.TabIndex = 6;
            this.chkBeforeEditing.Text = "Before Editing";
            this.chkBeforeEditing.UseVisualStyleBackColor = true;
            // 
            // grpCounterItem
            // 
            this.grpCounterItem.Controls.Add(this.rdoAll);
            this.grpCounterItem.Controls.Add(this.rdoReceipt);
            this.grpCounterItem.Controls.Add(this.rdoPayment);
            this.grpCounterItem.Controls.Add(this.chkItem);
            this.grpCounterItem.Location = new System.Drawing.Point(16, 180);
            this.grpCounterItem.Name = "grpCounterItem";
            this.grpCounterItem.Size = new System.Drawing.Size(286, 75);
            this.grpCounterItem.TabIndex = 7;
            this.grpCounterItem.TabStop = false;
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.IsSendTabOnEnter = true;
            this.rdoAll.Location = new System.Drawing.Point(211, 41);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(36, 17);
            this.rdoAll.TabIndex = 11;
            this.rdoAll.Text = "All";
            this.rdoAll.UseVisualStyleBackColor = true;
            // 
            // rdoReceipt
            // 
            this.rdoReceipt.AutoSize = true;
            this.rdoReceipt.IsSendTabOnEnter = true;
            this.rdoReceipt.Location = new System.Drawing.Point(128, 40);
            this.rdoReceipt.Name = "rdoReceipt";
            this.rdoReceipt.Size = new System.Drawing.Size(62, 17);
            this.rdoReceipt.TabIndex = 10;
            this.rdoReceipt.Text = "Receipt";
            this.rdoReceipt.UseVisualStyleBackColor = true;
            // 
            // rdoPayment
            // 
            this.rdoPayment.AutoSize = true;
            this.rdoPayment.Checked = true;
            this.rdoPayment.IsSendTabOnEnter = true;
            this.rdoPayment.Location = new System.Drawing.Point(44, 41);
            this.rdoPayment.Name = "rdoPayment";
            this.rdoPayment.Size = new System.Drawing.Size(66, 17);
            this.rdoPayment.TabIndex = 9;
            this.rdoPayment.TabStop = true;
            this.rdoPayment.Text = "Payment";
            this.rdoPayment.UseVisualStyleBackColor = true;
            // 
            // chkItem
            // 
            this.chkItem.AutoSize = true;
            this.chkItem.IsSendTabOnEnter = true;
            this.chkItem.Location = new System.Drawing.Point(13, 13);
            this.chkItem.Name = "chkItem";
            this.chkItem.Size = new System.Drawing.Size(46, 17);
            this.chkItem.TabIndex = 8;
            this.chkItem.Text = "Item";
            this.chkItem.UseVisualStyleBackColor = true;
            this.chkItem.CheckedChanged += new System.EventHandler(this.chkItem_CheckedChanged);
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(13, 107);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(55, 13);
            this.cxC00031.TabIndex = 49;
            this.cxC00031.Text = "Currency :";
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
            this.cboCurrency.Location = new System.Drawing.Point(101, 104);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 4;
            // 
            // chkNonIssueableNote
            // 
            this.chkNonIssueableNote.AutoSize = true;
            this.chkNonIssueableNote.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkNonIssueableNote.IsSendTabOnEnter = true;
            this.chkNonIssueableNote.Location = new System.Drawing.Point(266, 79);
            this.chkNonIssueableNote.Name = "chkNonIssueableNote";
            this.chkNonIssueableNote.Size = new System.Drawing.Size(114, 17);
            this.chkNonIssueableNote.TabIndex = 50;
            this.chkNonIssueableNote.Text = "Non Issuable Note";
            this.chkNonIssueableNote.UseVisualStyleBackColor = true;
            this.chkNonIssueableNote.Visible = false;
            // 
            // dgvCashControl
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCashControl.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCashControl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCashControl.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCashControl.Location = new System.Drawing.Point(222, 130);
            this.dgvCashControl.Name = "dgvCashControl";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCashControl.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCashControl.Size = new System.Drawing.Size(25, 21);
            this.dgvCashControl.TabIndex = 51;
            this.dgvCashControl.Visible = false;
            // 
            // MNMVEW00056
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 266);
            this.Controls.Add(this.dgvCashControl);
            this.Controls.Add(this.chkNonIssueableNote);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.cxC00031);
            this.Controls.Add(this.grpCounterItem);
            this.Controls.Add(this.chkBeforeEditing);
            this.Controls.Add(this.dtpEnterDate);
            this.Controls.Add(this.cboCounterNo);
            this.Controls.Add(this.lblEnterDate);
            this.Controls.Add(this.lblNo);
            this.Controls.Add(this.rdoVault);
            this.Controls.Add(this.rdoCounter);
            this.Controls.Add(this.rdoBranch);
            this.Controls.Add(this.tsbCRUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MNMVEW00056";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cash Control Report";
            this.Load += new System.EventHandler(this.MNMVEW00056_Load);
            this.grpCounterItem.ResumeLayout(false);
            this.grpCounterItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0009 rdoBranch;
        private Windows.CXClient.Controls.CXC0009 rdoCounter;
        private Windows.CXClient.Controls.CXC0009 rdoVault;
        private Windows.CXClient.Controls.CXC0005 dtpEnterDate;
        private Windows.CXClient.Controls.CXC0002 cboCounterNo;
        private Windows.CXClient.Controls.CXC0003 lblEnterDate;
        private Windows.CXClient.Controls.CXC0003 lblNo;
        private Windows.CXClient.Controls.CXC0008 chkBeforeEditing;
        private System.Windows.Forms.GroupBox grpCounterItem;
        private Windows.CXClient.Controls.CXC0008 chkItem;
        private Windows.CXClient.Controls.CXC0009 rdoAll;
        private Windows.CXClient.Controls.CXC0009 rdoReceipt;
        private Windows.CXClient.Controls.CXC0009 rdoPayment;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0008 chkNonIssueableNote;
        private System.Windows.Forms.DataGridView dgvCashControl;
    }
}