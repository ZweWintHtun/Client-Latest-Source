namespace Ace.Cbs.Tel.Vew
{
    partial class frmTLMVEW00009
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTLMVEW00009));
            this.lblAcctNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblDuration = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblReceiptNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtDuration = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.cboReceiptNo = new Ace.Windows.CXClient.Controls.CXC0002();
            this.gvCustomer = new Ace.Windows.CXClient.Controls.AceGridView();
            this.ColCustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNRC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.pbSignature = new Ace.Windows.CXClient.Controls.CXC0010();
            this.lblSignature = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblPhoto = new Ace.Windows.CXClient.Controls.CXC0003();
            this.pbPhoto = new Ace.Windows.CXClient.Controls.CXC0010();
            this.gbFixedDepositDeposit = new System.Windows.Forms.GroupBox();
            this.lblTransactionDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSignature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            this.gbFixedDepositDeposit.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAcctNo
            // 
            this.lblAcctNo.AutoSize = true;
            this.lblAcctNo.Location = new System.Drawing.Point(12, 23);
            this.lblAcctNo.Name = "lblAcctNo";
            this.lblAcctNo.Size = new System.Drawing.Size(70, 13);
            this.lblAcctNo.TabIndex = 0;
            this.lblAcctNo.Text = "Account No :";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(12, 51);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(53, 13);
            this.lblDuration.TabIndex = 0;
            this.lblDuration.Text = "Duration :";
            // 
            // lblReceiptNo
            // 
            this.lblReceiptNo.AutoSize = true;
            this.lblReceiptNo.Location = new System.Drawing.Point(279, 23);
            this.lblReceiptNo.Name = "lblReceiptNo";
            this.lblReceiptNo.Size = new System.Drawing.Size(67, 13);
            this.lblReceiptNo.TabIndex = 0;
            this.lblReceiptNo.Text = "Receipt No :";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(279, 52);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(49, 13);
            this.lblAmount.TabIndex = 0;
            this.lblAmount.Text = "Amount :";
            // 
            // txtDuration
            // 
            this.txtDuration.IsSendTabOnEnter = true;
            this.txtDuration.Location = new System.Drawing.Point(109, 48);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.ReadOnly = true;
            this.txtDuration.Size = new System.Drawing.Size(141, 20);
            this.txtDuration.TabIndex = 4;
            // 
            // txtAmount
            // 
            this.txtAmount.DecimalPlaces = 2;
            this.txtAmount.IsSendTabOnEnter = true;
            this.txtAmount.Location = new System.Drawing.Point(359, 49);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(141, 20);
            this.txtAmount.TabIndex = 5;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(109, 20);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 1;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // cboReceiptNo
            // 
            this.cboReceiptNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboReceiptNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboReceiptNo.DropDownHeight = 200;
            this.cboReceiptNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReceiptNo.FormattingEnabled = true;
            this.cboReceiptNo.IntegralHeight = false;
            this.cboReceiptNo.IsSendTabOnEnter = false;
            this.cboReceiptNo.Location = new System.Drawing.Point(359, 20);
            this.cboReceiptNo.Name = "cboReceiptNo";
            this.cboReceiptNo.Size = new System.Drawing.Size(141, 21);
            this.cboReceiptNo.TabIndex = 2;
            this.cboReceiptNo.SelectedIndexChanged += new System.EventHandler(this.cboReceiptNo_SelectedIndexChanged);
            // 
            // gvCustomer
            // 
            this.gvCustomer.AllowUserToAddRows = false;
            this.gvCustomer.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCustomerID,
            this.ColName,
            this.ColNRC});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvCustomer.DefaultCellStyle = dataGridViewCellStyle5;
            this.gvCustomer.EnableHeadersVisualStyles = false;
            this.gvCustomer.IdTSList = null;
            this.gvCustomer.IsEscapeKey = false;
            this.gvCustomer.IsHeaderClick = false;
            this.gvCustomer.Location = new System.Drawing.Point(15, 83);
            this.gvCustomer.Name = "gvCustomer";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvCustomer.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gvCustomer.RowHeadersWidth = 25;
            this.gvCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvCustomer.ShowSerialNo = false;
            this.gvCustomer.Size = new System.Drawing.Size(668, 176);
            this.gvCustomer.TabIndex = 6;
            this.gvCustomer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvCustomer_CellClick);
            // 
            // ColCustomerID
            // 
            this.ColCustomerID.DataPropertyName = "CustomerId";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ColCustomerID.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColCustomerID.HeaderText = "Customer ID";
            this.ColCustomerID.Name = "ColCustomerID";
            this.ColCustomerID.ReadOnly = true;
            this.ColCustomerID.Width = 140;
            // 
            // ColName
            // 
            this.ColName.DataPropertyName = "Name";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ColName.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColName.HeaderText = "Name";
            this.ColName.Name = "ColName";
            this.ColName.Width = 250;
            // 
            // ColNRC
            // 
            this.ColNRC.DataPropertyName = "NRC";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ColNRC.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColNRC.HeaderText = "NRC No";
            this.ColNRC.Name = "ColNRC";
            this.ColNRC.ReadOnly = true;
            this.ColNRC.Width = 250;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(861, 31);
            this.tsbCRUD.TabIndex = 3;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // pbSignature
            // 
            this.pbSignature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSignature.Location = new System.Drawing.Point(359, 276);
            this.pbSignature.Name = "pbSignature";
            this.pbSignature.Size = new System.Drawing.Size(324, 159);
            this.pbSignature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSignature.TabIndex = 60;
            this.pbSignature.TabStop = false;
            this.pbSignature.Tag = "7";
            // 
            // lblSignature
            // 
            this.lblSignature.AutoSize = true;
            this.lblSignature.Location = new System.Drawing.Point(279, 276);
            this.lblSignature.Name = "lblSignature";
            this.lblSignature.Size = new System.Drawing.Size(58, 13);
            this.lblSignature.TabIndex = 0;
            this.lblSignature.Text = "Signature :";
            // 
            // lblPhoto
            // 
            this.lblPhoto.AutoSize = true;
            this.lblPhoto.Location = new System.Drawing.Point(12, 276);
            this.lblPhoto.Name = "lblPhoto";
            this.lblPhoto.Size = new System.Drawing.Size(41, 13);
            this.lblPhoto.TabIndex = 0;
            this.lblPhoto.Text = "Photo :";
            // 
            // pbPhoto
            // 
            this.pbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPhoto.Location = new System.Drawing.Point(62, 276);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(163, 159);
            this.pbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPhoto.TabIndex = 58;
            this.pbPhoto.TabStop = false;
            this.pbPhoto.Tag = "6";
            // 
            // gbFixedDepositDeposit
            // 
            this.gbFixedDepositDeposit.Controls.Add(this.lblTransactionDate);
            this.gbFixedDepositDeposit.Controls.Add(this.cxC00031);
            this.gbFixedDepositDeposit.Controls.Add(this.pbSignature);
            this.gbFixedDepositDeposit.Controls.Add(this.cboReceiptNo);
            this.gbFixedDepositDeposit.Controls.Add(this.gvCustomer);
            this.gbFixedDepositDeposit.Controls.Add(this.mtxtAccountNo);
            this.gbFixedDepositDeposit.Controls.Add(this.lblSignature);
            this.gbFixedDepositDeposit.Controls.Add(this.txtAmount);
            this.gbFixedDepositDeposit.Controls.Add(this.pbPhoto);
            this.gbFixedDepositDeposit.Controls.Add(this.txtDuration);
            this.gbFixedDepositDeposit.Controls.Add(this.lblPhoto);
            this.gbFixedDepositDeposit.Controls.Add(this.lblAmount);
            this.gbFixedDepositDeposit.Controls.Add(this.lblAcctNo);
            this.gbFixedDepositDeposit.Controls.Add(this.lblReceiptNo);
            this.gbFixedDepositDeposit.Controls.Add(this.lblDuration);
            this.gbFixedDepositDeposit.Location = new System.Drawing.Point(12, 37);
            this.gbFixedDepositDeposit.Name = "gbFixedDepositDeposit";
            this.gbFixedDepositDeposit.Size = new System.Drawing.Size(798, 524);
            this.gbFixedDepositDeposit.TabIndex = 0;
            this.gbFixedDepositDeposit.TabStop = false;
            // 
            // lblTransactionDate
            // 
            this.lblTransactionDate.AutoSize = true;
            this.lblTransactionDate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblTransactionDate.Location = new System.Drawing.Point(703, 23);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Size = new System.Drawing.Size(89, 13);
            this.lblTransactionDate.TabIndex = 62;
            this.lblTransactionDate.Text = "Transaction Date";
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.cxC00031.Location = new System.Drawing.Point(602, 23);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(95, 13);
            this.cxC00031.TabIndex = 61;
            this.cxC00031.Text = "Transaction Date :";
            // 
            // frmTLMVEW00009
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 573);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.gbFixedDepositDeposit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTLMVEW00009";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fixed Deposit Deposit Entry";
            this.Load += new System.EventHandler(this.TLMVEW00009_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSignature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            this.gbFixedDepositDeposit.ResumeLayout(false);
            this.gbFixedDepositDeposit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Ace.Windows.CXClient.Controls.CXC0003 lblAcctNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblDuration;
        private Ace.Windows.CXClient.Controls.CXC0003 lblReceiptNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblAmount;
        private Ace.Windows.CXClient.Controls.CXC0001 txtDuration;
        private Ace.Windows.CXClient.Controls.CXC0004 txtAmount;
        private Ace.Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Ace.Windows.CXClient.Controls.CXC0002 cboReceiptNo;
        private Ace.Windows.CXClient.Controls.AceGridView gvCustomer;
        private Ace.Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Ace.Windows.CXClient.Controls.CXC0010 pbSignature;
        private Ace.Windows.CXClient.Controls.CXC0003 lblSignature;
        private Ace.Windows.CXClient.Controls.CXC0003 lblPhoto;
        private Ace.Windows.CXClient.Controls.CXC0010 pbPhoto;
        private System.Windows.Forms.GroupBox gbFixedDepositDeposit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNRC;
        private Windows.CXClient.Controls.CXC0003 lblTransactionDate;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
    }
}