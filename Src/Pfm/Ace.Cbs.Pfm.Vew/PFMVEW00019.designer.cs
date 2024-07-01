namespace Ace.Cbs.Pfm.Vew
{
    partial class frmPFMVEW00019
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPFMVEW00019));
            this.gbCompany = new System.Windows.Forms.GroupBox();
            this.mtxtFax = new System.Windows.Forms.TextBox();
            this.mtxtPhone = new System.Windows.Forms.TextBox();
            this.cboState = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cboTownship = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cboCity = new Ace.Windows.CXClient.Controls.CXC0002();
            this.gvCustomer = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colCustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNRC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.pbPhoto = new Ace.Windows.CXClient.Controls.CXC0010();
            this.label1 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtNoPersonSign = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblNoPersonSign = new Ace.Windows.CXClient.Controls.CXC0003();
            this.pbSignature = new Ace.Windows.CXClient.Controls.CXC0010();
            this.label15 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtIntroducedBy = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblIntroducedBy = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.butAddCustomer = new Ace.Windows.CXClient.Controls.CXC0007();
            this.txtEmail = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtAddress = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtNameOfFirm = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblCity = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAddress = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblState = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblEmail = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblTownship = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblPhone = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblFax = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblNameofFirm = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxcliC0011 = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gbCompany.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSignature)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCompany
            // 
            this.gbCompany.Controls.Add(this.mtxtFax);
            this.gbCompany.Controls.Add(this.mtxtPhone);
            this.gbCompany.Controls.Add(this.cboState);
            this.gbCompany.Controls.Add(this.cboTownship);
            this.gbCompany.Controls.Add(this.cboCity);
            this.gbCompany.Controls.Add(this.gvCustomer);
            this.gbCompany.Controls.Add(this.pbPhoto);
            this.gbCompany.Controls.Add(this.label1);
            this.gbCompany.Controls.Add(this.txtNoPersonSign);
            this.gbCompany.Controls.Add(this.lblNoPersonSign);
            this.gbCompany.Controls.Add(this.pbSignature);
            this.gbCompany.Controls.Add(this.label15);
            this.gbCompany.Controls.Add(this.txtIntroducedBy);
            this.gbCompany.Controls.Add(this.lblIntroducedBy);
            this.gbCompany.Controls.Add(this.cboCurrency);
            this.gbCompany.Controls.Add(this.lblCurrency);
            this.gbCompany.Controls.Add(this.butAddCustomer);
            this.gbCompany.Controls.Add(this.txtEmail);
            this.gbCompany.Controls.Add(this.txtAddress);
            this.gbCompany.Controls.Add(this.txtNameOfFirm);
            this.gbCompany.Controls.Add(this.lblCity);
            this.gbCompany.Controls.Add(this.lblAddress);
            this.gbCompany.Controls.Add(this.lblState);
            this.gbCompany.Controls.Add(this.lblEmail);
            this.gbCompany.Controls.Add(this.lblTownship);
            this.gbCompany.Controls.Add(this.lblPhone);
            this.gbCompany.Controls.Add(this.lblFax);
            this.gbCompany.Controls.Add(this.lblNameofFirm);
            this.gbCompany.Location = new System.Drawing.Point(11, 30);
            this.gbCompany.Name = "gbCompany";
            this.gbCompany.Size = new System.Drawing.Size(811, 595);
            this.gbCompany.TabIndex = 2;
            this.gbCompany.TabStop = false;
            // 
            // mtxtFax
            // 
            this.mtxtFax.Location = new System.Drawing.Point(484, 67);
            this.mtxtFax.MaxLength = 100;
            this.mtxtFax.Name = "mtxtFax";
            this.mtxtFax.Size = new System.Drawing.Size(176, 20);
            this.mtxtFax.TabIndex = 8;
            this.mtxtFax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtxtFax_KeyDown);
            this.mtxtFax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtFax_KeyPress);
            // 
            // mtxtPhone
            // 
            this.mtxtPhone.Location = new System.Drawing.Point(484, 41);
            this.mtxtPhone.MaxLength = 100;
            this.mtxtPhone.Name = "mtxtPhone";
            this.mtxtPhone.Size = new System.Drawing.Size(176, 20);
            this.mtxtPhone.TabIndex = 7;
            this.mtxtPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtxtPhone_KeyDown);
            this.mtxtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtPhone_KeyPress);
            // 
            // cboState
            // 
            this.cboState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboState.DropDownHeight = 200;
            this.cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboState.FormattingEnabled = true;
            this.cboState.IntegralHeight = false;
            this.cboState.IsSendTabOnEnter = true;
            this.cboState.Location = new System.Drawing.Point(484, 122);
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(141, 21);
            this.cboState.TabIndex = 10;
            // 
            // cboTownship
            // 
            this.cboTownship.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboTownship.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTownship.DropDownHeight = 200;
            this.cboTownship.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTownship.FormattingEnabled = true;
            this.cboTownship.IntegralHeight = false;
            this.cboTownship.IsSendTabOnEnter = true;
            this.cboTownship.Location = new System.Drawing.Point(484, 95);
            this.cboTownship.Name = "cboTownship";
            this.cboTownship.Size = new System.Drawing.Size(141, 21);
            this.cboTownship.TabIndex = 9;
            // 
            // cboCity
            // 
            this.cboCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCity.DropDownHeight = 200;
            this.cboCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCity.FormattingEnabled = true;
            this.cboCity.IntegralHeight = false;
            this.cboCity.IsSendTabOnEnter = true;
            this.cboCity.Location = new System.Drawing.Point(153, 143);
            this.cboCity.Name = "cboCity";
            this.cboCity.Size = new System.Drawing.Size(141, 21);
            this.cboCity.TabIndex = 5;
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
            this.colDelete});
            this.gvCustomer.EnableHeadersVisualStyles = false;
            this.gvCustomer.IdTSList = null;
            this.gvCustomer.IsEscapeKey = false;
            this.gvCustomer.IsHeaderClick = false;
            this.gvCustomer.Location = new System.Drawing.Point(7, 181);
            this.gvCustomer.Name = "gvCustomer";
            this.gvCustomer.RowHeadersWidth = 25;
            this.gvCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvCustomer.ShowSerialNo = false;
            this.gvCustomer.Size = new System.Drawing.Size(777, 206);
            this.gvCustomer.TabIndex = 57;
            this.gvCustomer.TabStop = false;
            this.gvCustomer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvCustomer_CellClick);
            // 
            // colCustomerId
            // 
            this.colCustomerId.DataPropertyName = "CustomerId";
            this.colCustomerId.HeaderText = "Customer Id";
            this.colCustomerId.Name = "colCustomerId";
            this.colCustomerId.ReadOnly = true;
            this.colCustomerId.Width = 200;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 350;
            // 
            // colNRC
            // 
            this.colNRC.DataPropertyName = "NRC";
            this.colNRC.HeaderText = "NRC";
            this.colNRC.Name = "colNRC";
            this.colNRC.ReadOnly = true;
            this.colNRC.Width = 150;
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
            // pbPhoto
            // 
            this.pbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPhoto.Location = new System.Drawing.Point(74, 422);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(163, 159);
            this.pbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPhoto.TabIndex = 56;
            this.pbPhoto.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 422);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Photo :";
            // 
            // txtNoPersonSign
            // 
            this.txtNoPersonSign.DecimalPlaces = 0;
            this.txtNoPersonSign.IsSendTabOnEnter = true;
            this.txtNoPersonSign.Location = new System.Drawing.Point(153, 393);
            this.txtNoPersonSign.MaxLength = 1;
            this.txtNoPersonSign.Name = "txtNoPersonSign";
            this.txtNoPersonSign.Size = new System.Drawing.Size(105, 20);
            this.txtNoPersonSign.TabIndex = 12;
            this.txtNoPersonSign.Text = "0";
            this.txtNoPersonSign.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNoPersonSign.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblNoPersonSign
            // 
            this.lblNoPersonSign.AutoSize = true;
            this.lblNoPersonSign.Location = new System.Drawing.Point(17, 396);
            this.lblNoPersonSign.Name = "lblNoPersonSign";
            this.lblNoPersonSign.Size = new System.Drawing.Size(114, 13);
            this.lblNoPersonSign.TabIndex = 0;
            this.lblNoPersonSign.Text = "No. of Person to Sign :";
            // 
            // pbSignature
            // 
            this.pbSignature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSignature.Location = new System.Drawing.Point(484, 422);
            this.pbSignature.Name = "pbSignature";
            this.pbSignature.Size = new System.Drawing.Size(280, 159);
            this.pbSignature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSignature.TabIndex = 45;
            this.pbSignature.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(373, 422);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(58, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Signature :";
            // 
            // txtIntroducedBy
            // 
            this.txtIntroducedBy.IsSendTabOnEnter = true;
            this.txtIntroducedBy.Location = new System.Drawing.Point(484, 16);
            this.txtIntroducedBy.MaxLength = 30;
            this.txtIntroducedBy.Name = "txtIntroducedBy";
            this.txtIntroducedBy.Size = new System.Drawing.Size(176, 20);
            this.txtIntroducedBy.TabIndex = 6;
            this.txtIntroducedBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIntroducedBy_KeyPress);
            // 
            // lblIntroducedBy
            // 
            this.lblIntroducedBy.AutoSize = true;
            this.lblIntroducedBy.Location = new System.Drawing.Point(373, 19);
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
            this.cboCurrency.Location = new System.Drawing.Point(153, 16);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 1;
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(17, 19);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 0;
            this.lblCurrency.Text = "Currency :";
            // 
            // butAddCustomer
            // 
            this.butAddCustomer.Image = ((System.Drawing.Image)(resources.GetObject("butAddCustomer.Image")));
            this.butAddCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAddCustomer.Location = new System.Drawing.Point(676, 150);
            this.butAddCustomer.Name = "butAddCustomer";
            this.butAddCustomer.Size = new System.Drawing.Size(97, 24);
            this.butAddCustomer.TabIndex = 11;
            this.butAddCustomer.Text = "&Add Customer";
            this.butAddCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butAddCustomer.UseVisualStyleBackColor = true;
            this.butAddCustomer.Click += new System.EventHandler(this.butAddCustomer_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtEmail.IsSendTabOnEnter = true;
            this.txtEmail.Location = new System.Drawing.Point(153, 69);
            this.txtEmail.MaxLength = 30;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(175, 20);
            this.txtEmail.TabIndex = 3;
            // 
            // txtAddress
            // 
            this.txtAddress.IsSendTabOnEnter = true;
            this.txtAddress.Location = new System.Drawing.Point(153, 95);
            this.txtAddress.MaxLength = 40;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(175, 42);
            this.txtAddress.TabIndex = 4;
            this.txtAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAddress_KeyPress);
            // 
            // txtNameOfFirm
            // 
            this.txtNameOfFirm.IsSendTabOnEnter = true;
            this.txtNameOfFirm.Location = new System.Drawing.Point(153, 43);
            this.txtNameOfFirm.MaxLength = 20;
            this.txtNameOfFirm.Name = "txtNameOfFirm";
            this.txtNameOfFirm.Size = new System.Drawing.Size(175, 20);
            this.txtNameOfFirm.TabIndex = 2;
            this.txtNameOfFirm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNameOfFirm_KeyPress);
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(17, 147);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(30, 13);
            this.lblCity.TabIndex = 0;
            this.lblCity.Text = "City :";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(16, 100);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(51, 13);
            this.lblAddress.TabIndex = 0;
            this.lblAddress.Text = "Address :";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(375, 125);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(38, 13);
            this.lblState.TabIndex = 40;
            this.lblState.Text = "State :";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(17, 74);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(42, 13);
            this.lblEmail.TabIndex = 0;
            this.lblEmail.Text = "E-Mail :";
            // 
            // lblTownship
            // 
            this.lblTownship.AutoSize = true;
            this.lblTownship.Location = new System.Drawing.Point(373, 97);
            this.lblTownship.Name = "lblTownship";
            this.lblTownship.Size = new System.Drawing.Size(59, 13);
            this.lblTownship.TabIndex = 0;
            this.lblTownship.Text = "Township :";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(375, 45);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(44, 13);
            this.lblPhone.TabIndex = 0;
            this.lblPhone.Text = "Phone :";
            // 
            // lblFax
            // 
            this.lblFax.AutoSize = true;
            this.lblFax.Location = new System.Drawing.Point(375, 71);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(30, 13);
            this.lblFax.TabIndex = 0;
            this.lblFax.Text = "Fax :";
            // 
            // lblNameofFirm
            // 
            this.lblNameofFirm.AutoSize = true;
            this.lblNameofFirm.Location = new System.Drawing.Point(17, 48);
            this.lblNameofFirm.Name = "lblNameofFirm";
            this.lblNameofFirm.Size = new System.Drawing.Size(75, 13);
            this.lblNameofFirm.TabIndex = 0;
            this.lblNameofFirm.Text = "Name of Firm :";
            // 
            // cxcliC0011
            // 
            this.cxcliC0011.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cxcliC0011.BackColor = System.Drawing.Color.PowderBlue;
            this.cxcliC0011.Location = new System.Drawing.Point(0, 0);
            this.cxcliC0011.Name = "cxcliC0011";
            this.cxcliC0011.PrintButtonCauseValidation = true;
            this.cxcliC0011.Size = new System.Drawing.Size(836, 30);
            this.cxcliC0011.TabIndex = 57;
            this.cxcliC0011.CancelButtonClick += new System.EventHandler(this.cxcliC0011_CancelButtonClick);
            this.cxcliC0011.PrintButtonClick += new System.EventHandler(this.cxcliC0011_PrintButtonClick);
            this.cxcliC0011.ExitButtonClick += new System.EventHandler(this.cxcliC0011_ExitButtonClick);
            // 
            // frmPFMVEW00019
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 636);
            this.Controls.Add(this.cxcliC0011);
            this.Controls.Add(this.gbCompany);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPFMVEW00019";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PFMVEW00019";
            this.Load += new System.EventHandler(this.frmPFMVEW00019_Load);
            this.gbCompany.ResumeLayout(false);
            this.gbCompany.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSignature)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCompany;
        private Ace.Windows.CXClient.Controls.CXC0010 pbPhoto;
        private Ace.Windows.CXClient.Controls.CXC0003 label1;
        private Ace.Windows.CXClient.Controls.CXC0004 txtNoPersonSign;
        private Ace.Windows.CXClient.Controls.CXC0003 lblNoPersonSign;
        private Ace.Windows.CXClient.Controls.CXC0010 pbSignature;
        private Ace.Windows.CXClient.Controls.CXC0003 label15;
        private Ace.Windows.CXClient.Controls.CXC0001 txtIntroducedBy;
        private Ace.Windows.CXClient.Controls.CXC0003 lblIntroducedBy;
        private Ace.Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Ace.Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Ace.Windows.CXClient.Controls.CXC0007 butAddCustomer;
        private Ace.Windows.CXClient.Controls.CXC0001 txtEmail;
        private Ace.Windows.CXClient.Controls.CXC0001 txtAddress;
        private Ace.Windows.CXClient.Controls.CXC0001 txtNameOfFirm;
        private Ace.Windows.CXClient.Controls.CXC0003 lblCity;
        private Ace.Windows.CXClient.Controls.CXC0003 lblAddress;
        private Ace.Windows.CXClient.Controls.CXC0003 lblState;
        private Ace.Windows.CXClient.Controls.CXC0003 lblEmail;
        private Ace.Windows.CXClient.Controls.CXC0003 lblTownship;
        private Ace.Windows.CXClient.Controls.CXC0003 lblPhone;
        private Ace.Windows.CXClient.Controls.CXC0003 lblFax;
        private Ace.Windows.CXClient.Controls.CXC0003 lblNameofFirm;
        private Windows.CXClient.Controls.CXCLIC001 cxcliC0011;
        private Windows.CXClient.Controls.AceGridView gvCustomer;
        private Ace.Windows.CXClient.Controls.CXC0002 cboCity;
        private Ace.Windows.CXClient.Controls.CXC0002 cboState;
        private Ace.Windows.CXClient.Controls.CXC0002 cboTownship;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNRC;
        private System.Windows.Forms.DataGridViewImageColumn colDelete;
        private System.Windows.Forms.TextBox mtxtPhone;
        private System.Windows.Forms.TextBox mtxtFax;

    }
}