namespace Ace.Cbs.Pfm.Vew
{
    partial class frmPFMVEW00005
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPFMVEW00005));
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.gvCustomer = new System.Windows.Forms.DataGridView();
            this.CustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNationality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDOB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Occupation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FatherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Township = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtName = new Ace.Windows.CXClient.Controls.CXC0001();
            this.chkExactly2 = new Ace.Windows.CXClient.Controls.CXC0008();
            this.lblNRC = new Ace.Windows.CXClient.Controls.CXC0003();
            this.chkExactly3 = new Ace.Windows.CXClient.Controls.CXC0008();
            this.lblFatherName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.chkExactly1 = new Ace.Windows.CXClient.Controls.CXC0008();
            this.txtNRC = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtFatherName = new Ace.Windows.CXClient.Controls.CXC0001();
            this.tlspCommon = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.butSearch = new Ace.Windows.CXClient.Controls.CXC0007();
            this.gbSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.butSearch);
            this.gbSearch.Controls.Add(this.gvCustomer);
            this.gbSearch.Controls.Add(this.lblName);
            this.gbSearch.Controls.Add(this.txtName);
            this.gbSearch.Controls.Add(this.chkExactly2);
            this.gbSearch.Controls.Add(this.lblNRC);
            this.gbSearch.Controls.Add(this.chkExactly3);
            this.gbSearch.Controls.Add(this.lblFatherName);
            this.gbSearch.Controls.Add(this.chkExactly1);
            this.gbSearch.Controls.Add(this.txtNRC);
            this.gbSearch.Controls.Add(this.txtFatherName);
            this.gbSearch.Location = new System.Drawing.Point(11, 39);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(851, 405);
            this.gbSearch.TabIndex = 2;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Search Information : ";
            // 
            // gvCustomer
            // 
            this.gvCustomer.AllowUserToAddRows = false;
            this.gvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerID,
            this.colNationality,
            this.NRC,
            this.ColName,
            this.colDOB,
            this.Occupation,
            this.FatherName,
            this.colGender,
            this.Address,
            this.Township,
            this.City,
            this.State,
            this.Phone,
            this.Fax,
            this.Email});
            this.gvCustomer.Location = new System.Drawing.Point(10, 118);
            this.gvCustomer.Name = "gvCustomer";
            this.gvCustomer.ReadOnly = true;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvCustomer.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gvCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvCustomer.Size = new System.Drawing.Size(829, 281);
            this.gvCustomer.TabIndex = 7;
            this.gvCustomer.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvCustomer_CellContentDoubleClick);
            this.gvCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvCustomer_KeyDown);
            // 
            // CustomerID
            // 
            this.CustomerID.DataPropertyName = "CustomerId";
            this.CustomerID.HeaderText = "Customer ID";
            this.CustomerID.Name = "CustomerID";
            this.CustomerID.ReadOnly = true;
            // 
            // colNationality
            // 
            this.colNationality.DataPropertyName = "Nationality";
            this.colNationality.HeaderText = "Nationality";
            this.colNationality.Name = "colNationality";
            this.colNationality.ReadOnly = true;
            this.colNationality.Visible = false;
            // 
            // NRC
            // 
            this.NRC.DataPropertyName = "NRC";
            this.NRC.HeaderText = "NRC";
            this.NRC.Name = "NRC";
            this.NRC.ReadOnly = true;
            // 
            // ColName
            // 
            this.ColName.DataPropertyName = "Name";
            this.ColName.HeaderText = "Name";
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            // 
            // colDOB
            // 
            this.colDOB.DataPropertyName = "DateOfBirth";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            dataGridViewCellStyle1.NullValue = null;
            this.colDOB.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDOB.HeaderText = "Date of Birth";
            this.colDOB.Name = "colDOB";
            this.colDOB.ReadOnly = true;
            // 
            // Occupation
            // 
            this.Occupation.DataPropertyName = "OccupationDesp";
            this.Occupation.HeaderText = "Occupation";
            this.Occupation.Name = "Occupation";
            this.Occupation.ReadOnly = true;
            // 
            // FatherName
            // 
            this.FatherName.DataPropertyName = "FatherName";
            this.FatherName.HeaderText = "Father Name";
            this.FatherName.Name = "FatherName";
            this.FatherName.ReadOnly = true;
            // 
            // colGender
            // 
            this.colGender.DataPropertyName = "Gender";
            this.colGender.HeaderText = "Gender";
            this.colGender.Name = "colGender";
            this.colGender.ReadOnly = true;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            // 
            // Township
            // 
            this.Township.DataPropertyName = "TownshipDesp";
            this.Township.HeaderText = "Township";
            this.Township.Name = "Township";
            this.Township.ReadOnly = true;
            // 
            // City
            // 
            this.City.DataPropertyName = "CityDesp";
            this.City.HeaderText = "City";
            this.City.Name = "City";
            this.City.ReadOnly = true;
            // 
            // State
            // 
            this.State.DataPropertyName = "StateDesp";
            this.State.HeaderText = "State";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            // 
            // Phone
            // 
            this.Phone.DataPropertyName = "PhoneNo";
            this.Phone.HeaderText = "Phone";
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            // 
            // Fax
            // 
            this.Fax.DataPropertyName = "FaxNo";
            this.Fax.HeaderText = "Fax";
            this.Fax.Name = "Fax";
            this.Fax.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblName.Location = new System.Drawing.Point(23, 37);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name :";
            // 
            // txtName
            // 
            this.txtName.IsSendTabOnEnter = true;
            this.txtName.Location = new System.Drawing.Point(134, 34);
            this.txtName.MaxLength = 30;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(175, 20);
            this.txtName.TabIndex = 1;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // chkExactly2
            // 
            this.chkExactly2.AutoSize = true;
            this.chkExactly2.IsSendTabOnEnter = true;
            this.chkExactly2.Location = new System.Drawing.Point(324, 62);
            this.chkExactly2.Name = "chkExactly2";
            this.chkExactly2.Size = new System.Drawing.Size(60, 17);
            this.chkExactly2.TabIndex = 4;
            this.chkExactly2.Text = "Exactly";
            this.chkExactly2.UseVisualStyleBackColor = true;
            this.chkExactly2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkExactly2_KeyDown);
            // 
            // lblNRC
            // 
            this.lblNRC.AutoSize = true;
            this.lblNRC.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNRC.Location = new System.Drawing.Point(23, 63);
            this.lblNRC.Name = "lblNRC";
            this.lblNRC.Size = new System.Drawing.Size(36, 13);
            this.lblNRC.TabIndex = 0;
            this.lblNRC.Text = "NRC :";
            // 
            // chkExactly3
            // 
            this.chkExactly3.AutoSize = true;
            this.chkExactly3.IsSendTabOnEnter = true;
            this.chkExactly3.Location = new System.Drawing.Point(324, 90);
            this.chkExactly3.Name = "chkExactly3";
            this.chkExactly3.Size = new System.Drawing.Size(60, 17);
            this.chkExactly3.TabIndex = 6;
            this.chkExactly3.Text = "Exactly";
            this.chkExactly3.UseVisualStyleBackColor = true;
            this.chkExactly3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkExactly3_KeyDown);
            // 
            // lblFatherName
            // 
            this.lblFatherName.AutoSize = true;
            this.lblFatherName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFatherName.Location = new System.Drawing.Point(23, 91);
            this.lblFatherName.Name = "lblFatherName";
            this.lblFatherName.Size = new System.Drawing.Size(81, 13);
            this.lblFatherName.TabIndex = 0;
            this.lblFatherName.Text = "Father\'s Name :";
            // 
            // chkExactly1
            // 
            this.chkExactly1.AutoSize = true;
            this.chkExactly1.IsSendTabOnEnter = true;
            this.chkExactly1.Location = new System.Drawing.Point(324, 36);
            this.chkExactly1.Name = "chkExactly1";
            this.chkExactly1.Size = new System.Drawing.Size(60, 17);
            this.chkExactly1.TabIndex = 2;
            this.chkExactly1.Text = "Exactly";
            this.chkExactly1.UseVisualStyleBackColor = true;
            this.chkExactly1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkExactly1_KeyDown);
            // 
            // txtNRC
            // 
            this.txtNRC.IsSendTabOnEnter = true;
            this.txtNRC.Location = new System.Drawing.Point(134, 60);
            this.txtNRC.MaxLength = 20;
            this.txtNRC.Name = "txtNRC";
            this.txtNRC.Size = new System.Drawing.Size(175, 20);
            this.txtNRC.TabIndex = 3;
            this.txtNRC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNRC_KeyDown);
            this.txtNRC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNRC_KeyPress);
            // 
            // txtFatherName
            // 
            this.txtFatherName.IsSendTabOnEnter = true;
            this.txtFatherName.Location = new System.Drawing.Point(134, 88);
            this.txtFatherName.MaxLength = 20;
            this.txtFatherName.Name = "txtFatherName";
            this.txtFatherName.Size = new System.Drawing.Size(175, 20);
            this.txtFatherName.TabIndex = 5;
            this.txtFatherName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFatherName_KeyDown);
            this.txtFatherName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFatherName_KeyPress);
            // 
            // tlspCommon
            // 
            this.tlspCommon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tlspCommon.BackColor = System.Drawing.Color.PowderBlue;
            this.tlspCommon.Location = new System.Drawing.Point(-1, -1);
            this.tlspCommon.Name = "tlspCommon";
            this.tlspCommon.PrintButtonCauseValidation = true;
            this.tlspCommon.Size = new System.Drawing.Size(875, 30);
            this.tlspCommon.TabIndex = 3;
            this.tlspCommon.NewButtonClick += new System.EventHandler(this.tlspCommon_NewButtonClick);
            this.tlspCommon.CancelButtonClick += new System.EventHandler(this.tlspCommon_CancelButtonClick);
            this.tlspCommon.ExitButtonClick += new System.EventHandler(this.tlspCommon_ExitButtonClick);
            // 
            // butSearch
            // 
            this.butSearch.Image = ((System.Drawing.Image)(resources.GetObject("butSearch.Image")));
            this.butSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.butSearch.Location = new System.Drawing.Point(763, 84);
            this.butSearch.Name = "butSearch";
            this.butSearch.Size = new System.Drawing.Size(76, 28);
            this.butSearch.TabIndex = 7;
            this.butSearch.Text = "&Search";
            this.butSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butSearch.UseVisualStyleBackColor = true;
            this.butSearch.Click += new System.EventHandler(this.butSearch_Click);
            // 
            // frmPFMVEW00005
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 452);
            this.Controls.Add(this.tlspCommon);
            this.Controls.Add(this.gbSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPFMVEW00005";
            this.Text = "CustomerId Search";
            this.Load += new System.EventHandler(this.PFMVEW00005_Load);
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSearch;
        private Ace.Windows.CXClient.Controls.CXC0007 butSearch;
        private System.Windows.Forms.DataGridView gvCustomer;
        private Ace.Windows.CXClient.Controls.CXC0003 lblName;
        private Ace.Windows.CXClient.Controls.CXC0001 txtName;
        private Ace.Windows.CXClient.Controls.CXC0008 chkExactly2;
        private Ace.Windows.CXClient.Controls.CXC0003 lblNRC;
        private Ace.Windows.CXClient.Controls.CXC0008 chkExactly3;
        private Ace.Windows.CXClient.Controls.CXC0003 lblFatherName;
        private Ace.Windows.CXClient.Controls.CXC0008 chkExactly1;
        private Ace.Windows.CXClient.Controls.CXC0001 txtNRC;
        private Ace.Windows.CXClient.Controls.CXC0001 txtFatherName;
        private Ace.Windows.CXClient.Controls.CXCLIC001 tlspCommon;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNationality;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDOB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Occupation;
        private System.Windows.Forms.DataGridViewTextBoxColumn FatherName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Township;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fax;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
    }
}