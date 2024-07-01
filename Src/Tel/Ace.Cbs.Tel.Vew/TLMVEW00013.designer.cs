namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00013
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00013));
            this.gpAccountInformation = new System.Windows.Forms.GroupBox();
            this.gvCustomer = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colCustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pbSignature = new Ace.Windows.CXClient.Controls.CXC0010();
            this.txtDate = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblSignature = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtVoucherNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblPhoto = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtJointType = new Ace.Windows.CXClient.Controls.CXC0001();
            this.pbPhoto = new Ace.Windows.CXClient.Controls.CXC0010();
            this.txtTotalAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.cboReceiptNo = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblReceiptNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblJointType = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblTotalAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblRegisterDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblVoucherNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtNoOfPerson = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtInterestAfterTax = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtDuration = new Ace.Windows.CXClient.Controls.CXC0001();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblNoOfPerson = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblRegisterDuration = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAvailableInterest = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gpAccountInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSignature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // gpAccountInformation
            // 
            this.gpAccountInformation.Controls.Add(this.gvCustomer);
            this.gpAccountInformation.Controls.Add(this.pbSignature);
            this.gpAccountInformation.Controls.Add(this.txtDate);
            this.gpAccountInformation.Controls.Add(this.lblSignature);
            this.gpAccountInformation.Controls.Add(this.txtVoucherNo);
            this.gpAccountInformation.Controls.Add(this.lblPhoto);
            this.gpAccountInformation.Controls.Add(this.txtJointType);
            this.gpAccountInformation.Controls.Add(this.pbPhoto);
            this.gpAccountInformation.Controls.Add(this.txtTotalAmount);
            this.gpAccountInformation.Controls.Add(this.cboReceiptNo);
            this.gpAccountInformation.Controls.Add(this.lblReceiptNo);
            this.gpAccountInformation.Controls.Add(this.lblJointType);
            this.gpAccountInformation.Controls.Add(this.lblTotalAmount);
            this.gpAccountInformation.Controls.Add(this.lblRegisterDate);
            this.gpAccountInformation.Controls.Add(this.lblVoucherNo);
            this.gpAccountInformation.Controls.Add(this.txtNoOfPerson);
            this.gpAccountInformation.Controls.Add(this.txtInterestAfterTax);
            this.gpAccountInformation.Controls.Add(this.txtAmount);
            this.gpAccountInformation.Controls.Add(this.txtDuration);
            this.gpAccountInformation.Controls.Add(this.mtxtAccountNo);
            this.gpAccountInformation.Controls.Add(this.lblNoOfPerson);
            this.gpAccountInformation.Controls.Add(this.lblRegisterDuration);
            this.gpAccountInformation.Controls.Add(this.lblAmount);
            this.gpAccountInformation.Controls.Add(this.lblAvailableInterest);
            this.gpAccountInformation.Controls.Add(this.lblAccountNo);
            this.gpAccountInformation.Location = new System.Drawing.Point(8, 34);
            this.gpAccountInformation.Name = "gpAccountInformation";
            this.gpAccountInformation.Size = new System.Drawing.Size(774, 527);
            this.gpAccountInformation.TabIndex = 0;
            this.gpAccountInformation.TabStop = false;
            // 
            // gvCustomer
            // 
            this.gvCustomer.AllowDrop = true;
            this.gvCustomer.AllowUserToAddRows = false;
            this.gvCustomer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCustomerId,
            this.CustomerName,
            this.NRC});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvCustomer.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvCustomer.EnableHeadersVisualStyles = false;
            this.gvCustomer.IdTSList = null;
            this.gvCustomer.IsEscapeKey = false;
            this.gvCustomer.IsHeaderClick = false;
            this.gvCustomer.Location = new System.Drawing.Point(11, 165);
            this.gvCustomer.Name = "gvCustomer";
            this.gvCustomer.ReadOnly = true;
            this.gvCustomer.RowHeadersWidth = 25;
            this.gvCustomer.ShowSerialNo = false;
            this.gvCustomer.Size = new System.Drawing.Size(587, 160);
            this.gvCustomer.TabIndex = 10;
            this.gvCustomer.TabStop = false;
            this.gvCustomer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvCustomer_CellClick);
            // 
            // colCustomerId
            // 
            this.colCustomerId.DataPropertyName = "CustomerId";
            this.colCustomerId.HeaderText = "CustomerId";
            this.colCustomerId.Name = "colCustomerId";
            this.colCustomerId.ReadOnly = true;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "Name";
            this.CustomerName.HeaderText = "Customer Name";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.Width = 250;
            // 
            // NRC
            // 
            this.NRC.DataPropertyName = "NRC";
            this.NRC.HeaderText = "NRC";
            this.NRC.Name = "NRC";
            this.NRC.ReadOnly = true;
            this.NRC.Width = 200;
            // 
            // pbSignature
            // 
            this.pbSignature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSignature.Location = new System.Drawing.Point(338, 339);
            this.pbSignature.Name = "pbSignature";
            this.pbSignature.Size = new System.Drawing.Size(260, 159);
            this.pbSignature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSignature.TabIndex = 50;
            this.pbSignature.TabStop = false;
            // 
            // txtDate
            // 
            this.txtDate.IsSendTabOnEnter = true;
            this.txtDate.Location = new System.Drawing.Point(457, 73);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(111, 20);
            this.txtDate.TabIndex = 7;
            // 
            // lblSignature
            // 
            this.lblSignature.AutoSize = true;
            this.lblSignature.Location = new System.Drawing.Point(274, 339);
            this.lblSignature.Name = "lblSignature";
            this.lblSignature.Size = new System.Drawing.Size(58, 13);
            this.lblSignature.TabIndex = 0;
            this.lblSignature.Text = "Signature :";
            // 
            // txtVoucherNo
            // 
            this.txtVoucherNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVoucherNo.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtVoucherNo.IsSendTabOnEnter = true;
            this.txtVoucherNo.Location = new System.Drawing.Point(457, 17);
            this.txtVoucherNo.Mask = "999-999-9999999";
            this.txtVoucherNo.Name = "txtVoucherNo";
            this.txtVoucherNo.Size = new System.Drawing.Size(102, 20);
            this.txtVoucherNo.TabIndex = 11;
            // 
            // lblPhoto
            // 
            this.lblPhoto.AutoSize = true;
            this.lblPhoto.Location = new System.Drawing.Point(11, 339);
            this.lblPhoto.Name = "lblPhoto";
            this.lblPhoto.Size = new System.Drawing.Size(41, 13);
            this.lblPhoto.TabIndex = 0;
            this.lblPhoto.Text = "Photo :";
            // 
            // txtJointType
            // 
            this.txtJointType.IsSendTabOnEnter = true;
            this.txtJointType.Location = new System.Drawing.Point(457, 129);
            this.txtJointType.Name = "txtJointType";
            this.txtJointType.Size = new System.Drawing.Size(58, 20);
            this.txtJointType.TabIndex = 9;
            // 
            // pbPhoto
            // 
            this.pbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPhoto.Location = new System.Drawing.Point(57, 339);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(163, 159);
            this.pbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPhoto.TabIndex = 48;
            this.pbPhoto.TabStop = false;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.DecimalPlaces = 2;
            this.txtTotalAmount.IsSendTabOnEnter = true;
            this.txtTotalAmount.Location = new System.Drawing.Point(457, 101);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(111, 20);
            this.txtTotalAmount.TabIndex = 8;
            this.txtTotalAmount.Text = "0.00";
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // cboReceiptNo
            // 
            this.cboReceiptNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboReceiptNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboReceiptNo.DropDownHeight = 200;
            this.cboReceiptNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReceiptNo.FormattingEnabled = true;
            this.cboReceiptNo.IntegralHeight = false;
            this.cboReceiptNo.IsSendTabOnEnter = true;
            this.cboReceiptNo.Location = new System.Drawing.Point(457, 45);
            this.cboReceiptNo.Name = "cboReceiptNo";
            this.cboReceiptNo.Size = new System.Drawing.Size(141, 21);
            this.cboReceiptNo.TabIndex = 2;
            this.cboReceiptNo.SelectedIndexChanged += new System.EventHandler(this.cboReceiptNo_SelectedIndexChanged);
            // 
            // lblReceiptNo
            // 
            this.lblReceiptNo.AutoSize = true;
            this.lblReceiptNo.Location = new System.Drawing.Point(369, 48);
            this.lblReceiptNo.Name = "lblReceiptNo";
            this.lblReceiptNo.Size = new System.Drawing.Size(67, 13);
            this.lblReceiptNo.TabIndex = 0;
            this.lblReceiptNo.Text = "Receipt No :";
            // 
            // lblJointType
            // 
            this.lblJointType.AutoSize = true;
            this.lblJointType.Location = new System.Drawing.Point(369, 132);
            this.lblJointType.Name = "lblJointType";
            this.lblJointType.Size = new System.Drawing.Size(59, 13);
            this.lblJointType.TabIndex = 0;
            this.lblJointType.Text = "JointType :";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(369, 104);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(76, 13);
            this.lblTotalAmount.TabIndex = 0;
            this.lblTotalAmount.Text = "Total Amount :";
            // 
            // lblRegisterDate
            // 
            this.lblRegisterDate.AutoSize = true;
            this.lblRegisterDate.Location = new System.Drawing.Point(369, 76);
            this.lblRegisterDate.Name = "lblRegisterDate";
            this.lblRegisterDate.Size = new System.Drawing.Size(78, 13);
            this.lblRegisterDate.TabIndex = 0;
            this.lblRegisterDate.Text = "Register Date :";
            // 
            // lblVoucherNo
            // 
            this.lblVoucherNo.AutoSize = true;
            this.lblVoucherNo.Location = new System.Drawing.Point(369, 20);
            this.lblVoucherNo.Name = "lblVoucherNo";
            this.lblVoucherNo.Size = new System.Drawing.Size(70, 13);
            this.lblVoucherNo.TabIndex = 0;
            this.lblVoucherNo.Text = "Voucher No :";
            // 
            // txtNoOfPerson
            // 
            this.txtNoOfPerson.DecimalPlaces = 0;
            this.txtNoOfPerson.IsSendTabOnEnter = true;
            this.txtNoOfPerson.Location = new System.Drawing.Point(160, 129);
            this.txtNoOfPerson.Name = "txtNoOfPerson";
            this.txtNoOfPerson.Size = new System.Drawing.Size(97, 20);
            this.txtNoOfPerson.TabIndex = 6;
            this.txtNoOfPerson.Text = "0";
            this.txtNoOfPerson.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNoOfPerson.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtInterestAfterTax
            // 
            this.txtInterestAfterTax.DecimalPlaces = 2;
            this.txtInterestAfterTax.IsSendTabOnEnter = true;
            this.txtInterestAfterTax.Location = new System.Drawing.Point(160, 101);
            this.txtInterestAfterTax.Name = "txtInterestAfterTax";
            this.txtInterestAfterTax.Size = new System.Drawing.Size(111, 20);
            this.txtInterestAfterTax.TabIndex = 5;
            this.txtInterestAfterTax.Text = "0.00";
            this.txtInterestAfterTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInterestAfterTax.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtAmount
            // 
            this.txtAmount.DecimalPlaces = 2;
            this.txtAmount.IsSendTabOnEnter = true;
            this.txtAmount.Location = new System.Drawing.Point(160, 73);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(111, 20);
            this.txtAmount.TabIndex = 4;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtDuration
            // 
            this.txtDuration.IsSendTabOnEnter = true;
            this.txtDuration.Location = new System.Drawing.Point(160, 45);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(111, 20);
            this.txtDuration.TabIndex = 3;
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(160, 17);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 1;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblNoOfPerson
            // 
            this.lblNoOfPerson.AutoSize = true;
            this.lblNoOfPerson.Location = new System.Drawing.Point(12, 132);
            this.lblNoOfPerson.Name = "lblNoOfPerson";
            this.lblNoOfPerson.Size = new System.Drawing.Size(75, 13);
            this.lblNoOfPerson.TabIndex = 0;
            this.lblNoOfPerson.Text = "No of Person :";
            // 
            // lblRegisterDuration
            // 
            this.lblRegisterDuration.AutoSize = true;
            this.lblRegisterDuration.Location = new System.Drawing.Point(12, 48);
            this.lblRegisterDuration.Name = "lblRegisterDuration";
            this.lblRegisterDuration.Size = new System.Drawing.Size(95, 13);
            this.lblRegisterDuration.TabIndex = 0;
            this.lblRegisterDuration.Text = "Register Duration :";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(12, 76);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(49, 13);
            this.lblAmount.TabIndex = 0;
            this.lblAmount.Text = "Amount :";
            // 
            // lblAvailableInterest
            // 
            this.lblAvailableInterest.AutoSize = true;
            this.lblAvailableInterest.Location = new System.Drawing.Point(12, 104);
            this.lblAvailableInterest.Name = "lblAvailableInterest";
            this.lblAvailableInterest.Size = new System.Drawing.Size(141, 13);
            this.lblAvailableInterest.TabIndex = 0;
            this.lblAvailableInterest.Text = "Avaliable Interest (after tax) :";
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(12, 20);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(70, 13);
            this.lblAccountNo.TabIndex = 0;
            this.lblAccountNo.Text = "Account No :";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(798, 31);
            this.tsbCRUD.TabIndex = 12;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // TLMVEW00013
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 573);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.gpAccountInformation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00013";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fixed Deposit Withdrawal Entry";
            this.Load += new System.EventHandler(this.TLMVEW00013_Load);
            this.gpAccountInformation.ResumeLayout(false);
            this.gpAccountInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSignature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpAccountInformation;
        private Ace.Windows.CXClient.Controls.CXC0003 lblRegisterDuration;
        private Ace.Windows.CXClient.Controls.CXC0003 lblAmount;
        private Ace.Windows.CXClient.Controls.CXC0003 lblAvailableInterest;
        private Ace.Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblNoOfPerson;
        private Ace.Windows.CXClient.Controls.CXC0004 txtAmount;
        private Ace.Windows.CXClient.Controls.CXC0003 lblReceiptNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblJointType;
        private Ace.Windows.CXClient.Controls.CXC0003 lblTotalAmount;
        private Ace.Windows.CXClient.Controls.CXC0003 lblRegisterDate;
        private Ace.Windows.CXClient.Controls.CXC0003 lblVoucherNo;
        private Ace.Windows.CXClient.Controls.CXC0004 txtNoOfPerson;
        private Ace.Windows.CXClient.Controls.CXC0004 txtInterestAfterTax;
        private Ace.Windows.CXClient.Controls.CXC0004 txtTotalAmount;
        private Ace.Windows.CXClient.Controls.AceGridView gvCustomer;
        private Ace.Windows.CXClient.Controls.CXC0003 lblPhoto;
        private Ace.Windows.CXClient.Controls.CXC0010 pbPhoto;
        private Ace.Windows.CXClient.Controls.CXC0003 lblSignature;
        private Ace.Windows.CXClient.Controls.CXC0010 pbSignature;
        private Ace.Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Ace.Windows.CXClient.Controls.CXC0001 txtDuration;
        private Ace.Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Ace.Windows.CXClient.Controls.CXC0002 cboReceiptNo;
        private Ace.Windows.CXClient.Controls.CXC0001 txtJointType;
        private Ace.Windows.CXClient.Controls.CXC0006 txtVoucherNo;
        private Ace.Windows.CXClient.Controls.CXC0001 txtDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRC;
        // private System.Windows.Forms.DataGridViewTextBoxColumn CustomerId;

    }
}