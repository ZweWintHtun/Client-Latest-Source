namespace Ace.Cbs.Pfm.Vew
{
    partial class PFMVEW00018
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PFMVEW00018));
            this.txtIntroducedBy = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblIntroducedBy = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.gbAccountJointInformation = new System.Windows.Forms.GroupBox();
            this.gvCustomer = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colCustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNRC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNationality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtNoPersonSign = new Ace.Windows.CXClient.Controls.CXC0004();
            this.gbJoinType = new System.Windows.Forms.GroupBox();
            this.rdoTypeB = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoTypeA = new Ace.Windows.CXClient.Controls.CXC0009();
            this.lblNoOfPersonToSign = new Ace.Windows.CXClient.Controls.CXC0003();
            this.pbSignature = new Ace.Windows.CXClient.Controls.CXC0010();
            this.pbPhoto = new Ace.Windows.CXClient.Controls.CXC0010();
            this.lblSignature = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblPhoto = new Ace.Windows.CXClient.Controls.CXC0003();
            this.butAddCustomers = new Ace.Windows.CXClient.Controls.CXC0007();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxcliC0011 = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gbAccountJointInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).BeginInit();
            this.gbJoinType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSignature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIntroducedBy
            // 
            this.txtIntroducedBy.IsSendTabOnEnter = true;
            this.txtIntroducedBy.Location = new System.Drawing.Point(112, 47);
            this.txtIntroducedBy.MaxLength = 30;
            this.txtIntroducedBy.Name = "txtIntroducedBy";
            this.txtIntroducedBy.Size = new System.Drawing.Size(175, 20);
            this.txtIntroducedBy.TabIndex = 1;
            // 
            // lblIntroducedBy
            // 
            this.lblIntroducedBy.AutoSize = true;
            this.lblIntroducedBy.Location = new System.Drawing.Point(10, 50);
            this.lblIntroducedBy.Name = "lblIntroducedBy";
            this.lblIntroducedBy.Size = new System.Drawing.Size(79, 13);
            this.lblIntroducedBy.TabIndex = 0;
            this.lblIntroducedBy.Text = "Introduced By :";
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
            this.cboCurrency.Location = new System.Drawing.Point(112, 16);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 0;
            // 
            // gbAccountJointInformation
            // 
            this.gbAccountJointInformation.Controls.Add(this.gvCustomer);
            this.gbAccountJointInformation.Controls.Add(this.txtNoPersonSign);
            this.gbAccountJointInformation.Controls.Add(this.gbJoinType);
            this.gbAccountJointInformation.Controls.Add(this.lblNoOfPersonToSign);
            this.gbAccountJointInformation.Controls.Add(this.pbSignature);
            this.gbAccountJointInformation.Controls.Add(this.pbPhoto);
            this.gbAccountJointInformation.Controls.Add(this.lblSignature);
            this.gbAccountJointInformation.Controls.Add(this.lblPhoto);
            this.gbAccountJointInformation.Controls.Add(this.butAddCustomers);
            this.gbAccountJointInformation.Controls.Add(this.txtIntroducedBy);
            this.gbAccountJointInformation.Controls.Add(this.lblIntroducedBy);
            this.gbAccountJointInformation.Controls.Add(this.cboCurrency);
            this.gbAccountJointInformation.Controls.Add(this.lblCurrency);
            this.gbAccountJointInformation.Location = new System.Drawing.Point(9, 32);
            this.gbAccountJointInformation.Name = "gbAccountJointInformation";
            this.gbAccountJointInformation.Size = new System.Drawing.Size(743, 462);
            this.gbAccountJointInformation.TabIndex = 1;
            this.gbAccountJointInformation.TabStop = false;
            // 
            // gvCustomer
            // 
            this.gvCustomer.AllowUserToAddRows = false;
            this.gvCustomer.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gvCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCustomerId,
            this.colName,
            this.colNRC,
            this.colNationality,
            this.colDelete});
            this.gvCustomer.EnableHeadersVisualStyles = false;
            this.gvCustomer.IdTSList = null;
            this.gvCustomer.IsEscapeKey = false;
            this.gvCustomer.IsHeaderClick = false;
            this.gvCustomer.Location = new System.Drawing.Point(13, 73);
            this.gvCustomer.Name = "gvCustomer";
            this.gvCustomer.RowHeadersWidth = 25;
            this.gvCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvCustomer.ShowSerialNo = false;
            this.gvCustomer.Size = new System.Drawing.Size(707, 146);
            this.gvCustomer.TabIndex = 116;
            this.gvCustomer.TabStop = false;
            this.gvCustomer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvCustomer_CellClick);
            // 
            // colCustomerId
            // 
            this.colCustomerId.DataPropertyName = "CustomerId";
            this.colCustomerId.HeaderText = "Customer Id";
            this.colCustomerId.Name = "colCustomerId";
            this.colCustomerId.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 200;
            // 
            // colNRC
            // 
            this.colNRC.DataPropertyName = "NRC";
            this.colNRC.HeaderText = "NRC";
            this.colNRC.Name = "colNRC";
            this.colNRC.ReadOnly = true;
            this.colNRC.Width = 150;
            // 
            // colNationality
            // 
            this.colNationality.DataPropertyName = "Nationality";
            this.colNationality.HeaderText = "Nationality";
            this.colNationality.Name = "colNationality";
            this.colNationality.ReadOnly = true;
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "";
            this.colDelete.Image = global::Ace.Cbs.Pfm.Vew.Properties.Resources.cancel_01;
            this.colDelete.Name = "colDelete";
            this.colDelete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDelete.ToolTipText = "Delete";
            this.colDelete.Width = 30;
            // 
            // txtNoPersonSign
            // 
            this.txtNoPersonSign.DecimalPlaces = 0;
            this.txtNoPersonSign.IsSendTabOnEnter = true;
            this.txtNoPersonSign.Location = new System.Drawing.Point(137, 237);
            this.txtNoPersonSign.MaxLength = 1;
            this.txtNoPersonSign.Name = "txtNoPersonSign";
            this.txtNoPersonSign.Size = new System.Drawing.Size(105, 20);
            this.txtNoPersonSign.TabIndex = 3;
            this.txtNoPersonSign.Text = "0";
            this.txtNoPersonSign.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNoPersonSign.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // gbJoinType
            // 
            this.gbJoinType.Controls.Add(this.rdoTypeB);
            this.gbJoinType.Controls.Add(this.rdoTypeA);
            this.gbJoinType.Location = new System.Drawing.Point(519, 237);
            this.gbJoinType.Name = "gbJoinType";
            this.gbJoinType.Size = new System.Drawing.Size(200, 43);
            this.gbJoinType.TabIndex = 4;
            this.gbJoinType.TabStop = false;
            this.gbJoinType.Text = "Joint Type";
            // 
            // rdoTypeB
            // 
            this.rdoTypeB.AutoSize = true;
            this.rdoTypeB.IsSendTabOnEnter = true;
            this.rdoTypeB.Location = new System.Drawing.Point(123, 17);
            this.rdoTypeB.Name = "rdoTypeB";
            this.rdoTypeB.Size = new System.Drawing.Size(59, 17);
            this.rdoTypeB.TabIndex = 9;
            this.rdoTypeB.Text = "Type B";
            this.rdoTypeB.UseVisualStyleBackColor = true;
            // 
            // rdoTypeA
            // 
            this.rdoTypeA.AutoSize = true;
            this.rdoTypeA.Checked = true;
            this.rdoTypeA.IsSendTabOnEnter = true;
            this.rdoTypeA.Location = new System.Drawing.Point(11, 17);
            this.rdoTypeA.Name = "rdoTypeA";
            this.rdoTypeA.Size = new System.Drawing.Size(59, 17);
            this.rdoTypeA.TabIndex = 8;
            this.rdoTypeA.TabStop = true;
            this.rdoTypeA.Text = "Type A";
            this.rdoTypeA.UseVisualStyleBackColor = true;
            // 
            // lblNoOfPersonToSign
            // 
            this.lblNoOfPersonToSign.AutoSize = true;
            this.lblNoOfPersonToSign.Location = new System.Drawing.Point(10, 240);
            this.lblNoOfPersonToSign.Name = "lblNoOfPersonToSign";
            this.lblNoOfPersonToSign.Size = new System.Drawing.Size(116, 13);
            this.lblNoOfPersonToSign.TabIndex = 6;
            this.lblNoOfPersonToSign.Text = "No. Of Person to Sign :";
            // 
            // pbSignature
            // 
            this.pbSignature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSignature.Location = new System.Drawing.Point(439, 289);
            this.pbSignature.Name = "pbSignature";
            this.pbSignature.Size = new System.Drawing.Size(280, 159);
            this.pbSignature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSignature.TabIndex = 75;
            this.pbSignature.TabStop = false;
            // 
            // pbPhoto
            // 
            this.pbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPhoto.Location = new System.Drawing.Point(101, 289);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(163, 159);
            this.pbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPhoto.TabIndex = 73;
            this.pbPhoto.TabStop = false;
            // 
            // lblSignature
            // 
            this.lblSignature.AutoSize = true;
            this.lblSignature.Location = new System.Drawing.Point(334, 289);
            this.lblSignature.Name = "lblSignature";
            this.lblSignature.Size = new System.Drawing.Size(58, 13);
            this.lblSignature.TabIndex = 0;
            this.lblSignature.Text = "Signature :";
            // 
            // lblPhoto
            // 
            this.lblPhoto.AutoSize = true;
            this.lblPhoto.Location = new System.Drawing.Point(10, 289);
            this.lblPhoto.Name = "lblPhoto";
            this.lblPhoto.Size = new System.Drawing.Size(41, 13);
            this.lblPhoto.TabIndex = 0;
            this.lblPhoto.Text = "Photo :";
            // 
            // butAddCustomers
            // 
            this.butAddCustomers.Image = ((System.Drawing.Image)(resources.GetObject("butAddCustomers.Image")));
            this.butAddCustomers.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.butAddCustomers.Location = new System.Drawing.Point(623, 43);
            this.butAddCustomers.Name = "butAddCustomers";
            this.butAddCustomers.Size = new System.Drawing.Size(97, 24);
            this.butAddCustomers.TabIndex = 2;
            this.butAddCustomers.Text = "&Add Customer";
            this.butAddCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butAddCustomers.UseVisualStyleBackColor = true;
            this.butAddCustomers.Click += new System.EventHandler(this.butAddCustomers_Click);
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(10, 19);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 0;
            this.lblCurrency.Text = "Currency :";
            // 
            // cxcliC0011
            // 
            this.cxcliC0011.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cxcliC0011.BackColor = System.Drawing.Color.PowderBlue;
            this.cxcliC0011.Location = new System.Drawing.Point(-2, 0);
            this.cxcliC0011.Name = "cxcliC0011";
            this.cxcliC0011.PrintButtonCauseValidation = true;
            this.cxcliC0011.Size = new System.Drawing.Size(832, 30);
            this.cxcliC0011.TabIndex = 2;
            this.cxcliC0011.CancelButtonClick += new System.EventHandler(this.cxcliC0011_CancelButtonClick);
            this.cxcliC0011.PrintButtonClick += new System.EventHandler(this.cxcliC0011_PrintButtonClick);
            this.cxcliC0011.ExitButtonClick += new System.EventHandler(this.cxcliC0011_ExitButtonClick);
            // 
            // PFMVEW00018
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 506);
            this.Controls.Add(this.cxcliC0011);
            this.Controls.Add(this.gbAccountJointInformation);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PFMVEW00018";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PFMVEW00018";
            this.Load += new System.EventHandler(this.PFMVEW00018_Load);
            this.gbAccountJointInformation.ResumeLayout(false);
            this.gbAccountJointInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).EndInit();
            this.gbJoinType.ResumeLayout(false);
            this.gbJoinType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSignature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
                
        private Ace.Windows.CXClient.Controls.CXC0001 txtIntroducedBy;
        private Ace.Windows.CXClient.Controls.CXC0003 lblIntroducedBy;
        private Ace.Windows.CXClient.Controls.CXC0002 cboCurrency;
        private System.Windows.Forms.GroupBox gbAccountJointInformation;
        private Ace.Windows.CXClient.Controls.CXC0004 txtNoPersonSign;
        private System.Windows.Forms.GroupBox gbJoinType;
        private Ace.Windows.CXClient.Controls.CXC0009 rdoTypeB;
        private Ace.Windows.CXClient.Controls.CXC0009 rdoTypeA;
        private Ace.Windows.CXClient.Controls.CXC0003 lblNoOfPersonToSign;
        private Ace.Windows.CXClient.Controls.CXC0010 pbSignature;
        private Ace.Windows.CXClient.Controls.CXC0010 pbPhoto;
        private Ace.Windows.CXClient.Controls.CXC0003 lblSignature;
        private Ace.Windows.CXClient.Controls.CXC0003 lblPhoto;
        private Ace.Windows.CXClient.Controls.CXC0007 butAddCustomers;
        private Ace.Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Ace.Windows.CXClient.Controls.CXCLIC001 cxcliC0011;
        private Windows.CXClient.Controls.AceGridView gvCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNRC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNationality;
        private System.Windows.Forms.DataGridViewImageColumn colDelete;
    }
}