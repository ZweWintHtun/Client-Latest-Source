namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00080
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00080));
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.dgvDealer = new System.Windows.Forms.DataGridView();
            this.ColchkSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColDealerNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDealerAC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBusiness = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDphone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDaddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colemail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNRC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colfax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colcity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBusinessEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBusinessAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colcommission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearch = new Ace.Windows.CXClient.Controls.CXC0007();
            this.btnOK = new System.Windows.Forms.Button();
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtName = new Ace.Windows.CXClient.Controls.CXC0001();
            this.chkExactly2 = new Ace.Windows.CXClient.Controls.CXC0008();
            this.lblNRC = new Ace.Windows.CXClient.Controls.CXC0003();
            this.chkExactly1 = new Ace.Windows.CXClient.Controls.CXC0008();
            this.txtNRC = new Ace.Windows.CXClient.Controls.CXC0001();
            this.tlspCommon = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gbSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDealer)).BeginInit();
            this.SuspendLayout();
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cxC00031.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cxC00031.Location = new System.Drawing.Point(97, 28);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(10, 13);
            this.cxC00031.TabIndex = 0;
            this.cxC00031.Text = ":";
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.dgvDealer);
            this.gbSearch.Controls.Add(this.btnDelete);
            this.gbSearch.Controls.Add(this.btnSearch);
            this.gbSearch.Controls.Add(this.btnOK);
            this.gbSearch.Controls.Add(this.cxC00032);
            this.gbSearch.Controls.Add(this.cxC00031);
            this.gbSearch.Controls.Add(this.lblName);
            this.gbSearch.Controls.Add(this.txtName);
            this.gbSearch.Controls.Add(this.chkExactly2);
            this.gbSearch.Controls.Add(this.lblNRC);
            this.gbSearch.Controls.Add(this.chkExactly1);
            this.gbSearch.Controls.Add(this.txtNRC);
            this.gbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSearch.Location = new System.Drawing.Point(7, 39);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(862, 426);
            this.gbSearch.TabIndex = 5;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Search Information : ";
            // 
            // dgvDealer
            // 
            this.dgvDealer.AllowUserToAddRows = false;
            this.dgvDealer.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDealer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDealer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDealer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColchkSelect,
            this.ColDealerNo,
            this.ColDealerAC,
            this.ColDname,
            this.ColBusiness,
            this.ColDphone,
            this.ColDaddress,
            this.Colemail,
            this.ColNRC,
            this.Colfax,
            this.Colcity,
            this.ColBusinessEmail,
            this.ColBusinessAddress,
            this.Colcommission});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDealer.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDealer.Location = new System.Drawing.Point(11, 85);
            this.dgvDealer.Name = "dgvDealer";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDealer.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDealer.RowHeadersVisible = false;
            this.dgvDealer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDealer.Size = new System.Drawing.Size(839, 295);
            this.dgvDealer.TabIndex = 7;
            // 
            // ColchkSelect
            // 
            this.ColchkSelect.HeaderText = "Select";
            this.ColchkSelect.Name = "ColchkSelect";
            this.ColchkSelect.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColchkSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColchkSelect.Width = 50;
            // 
            // ColDealerNo
            // 
            this.ColDealerNo.HeaderText = "Dealer No";
            this.ColDealerNo.Name = "ColDealerNo";
            // 
            // ColDealerAC
            // 
            this.ColDealerAC.HeaderText = "Dealer Account No\t";
            this.ColDealerAC.Name = "ColDealerAC";
            // 
            // ColDname
            // 
            this.ColDname.HeaderText = "Dealer Name";
            this.ColDname.Name = "ColDname";
            // 
            // ColBusiness
            // 
            this.ColBusiness.HeaderText = "Business";
            this.ColBusiness.Name = "ColBusiness";
            // 
            // ColDphone
            // 
            this.ColDphone.HeaderText = "Dealer Phone";
            this.ColDphone.Name = "ColDphone";
            // 
            // ColDaddress
            // 
            this.ColDaddress.HeaderText = "Dealer Address";
            this.ColDaddress.Name = "ColDaddress";
            // 
            // Colemail
            // 
            this.Colemail.HeaderText = "Email";
            this.Colemail.Name = "Colemail";
            // 
            // ColNRC
            // 
            this.ColNRC.HeaderText = "NRC";
            this.ColNRC.Name = "ColNRC";
            // 
            // Colfax
            // 
            this.Colfax.HeaderText = "Fax";
            this.Colfax.Name = "Colfax";
            // 
            // Colcity
            // 
            this.Colcity.HeaderText = "City";
            this.Colcity.Name = "Colcity";
            // 
            // ColBusinessEmail
            // 
            this.ColBusinessEmail.HeaderText = "Business Email";
            this.ColBusinessEmail.Name = "ColBusinessEmail";
            // 
            // ColBusinessAddress
            // 
            this.ColBusinessAddress.HeaderText = "Business Address";
            this.ColBusinessAddress.Name = "ColBusinessAddress";
            // 
            // Colcommission
            // 
            this.Colcommission.HeaderText = "Commission";
            this.Colcommission.Name = "Colcommission";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(663, 386);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(76, 28);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSearch.Location = new System.Drawing.Point(774, 52);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(76, 28);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "&Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(745, 386);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(76, 28);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "Close";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cxC00032.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cxC00032.Location = new System.Drawing.Point(97, 56);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(10, 13);
            this.cxC00032.TabIndex = 0;
            this.cxC00032.Text = ":";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblName.Location = new System.Drawing.Point(16, 28);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.IsSendTabOnEnter = true;
            this.txtName.Location = new System.Drawing.Point(135, 24);
            this.txtName.MaxLength = 30;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(175, 20);
            this.txtName.TabIndex = 0;
            // 
            // chkExactly2
            // 
            this.chkExactly2.AutoSize = true;
            this.chkExactly2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExactly2.IsSendTabOnEnter = true;
            this.chkExactly2.Location = new System.Drawing.Point(316, 54);
            this.chkExactly2.Name = "chkExactly2";
            this.chkExactly2.Size = new System.Drawing.Size(60, 17);
            this.chkExactly2.TabIndex = 3;
            this.chkExactly2.Text = "Exactly";
            this.chkExactly2.UseVisualStyleBackColor = true;
            // 
            // lblNRC
            // 
            this.lblNRC.AutoSize = true;
            this.lblNRC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNRC.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNRC.Location = new System.Drawing.Point(16, 56);
            this.lblNRC.Name = "lblNRC";
            this.lblNRC.Size = new System.Drawing.Size(30, 13);
            this.lblNRC.TabIndex = 0;
            this.lblNRC.Text = "NRC";
            // 
            // chkExactly1
            // 
            this.chkExactly1.AutoSize = true;
            this.chkExactly1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExactly1.IsSendTabOnEnter = true;
            this.chkExactly1.Location = new System.Drawing.Point(316, 26);
            this.chkExactly1.Name = "chkExactly1";
            this.chkExactly1.Size = new System.Drawing.Size(60, 17);
            this.chkExactly1.TabIndex = 1;
            this.chkExactly1.Text = "Exactly";
            this.chkExactly1.UseVisualStyleBackColor = true;
            // 
            // txtNRC
            // 
            this.txtNRC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNRC.IsSendTabOnEnter = true;
            this.txtNRC.Location = new System.Drawing.Point(135, 52);
            this.txtNRC.MaxLength = 20;
            this.txtNRC.Name = "txtNRC";
            this.txtNRC.Size = new System.Drawing.Size(175, 20);
            this.txtNRC.TabIndex = 2;
            // 
            // tlspCommon
            // 
            this.tlspCommon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tlspCommon.BackColor = System.Drawing.Color.PowderBlue;
            this.tlspCommon.Location = new System.Drawing.Point(0, 2);
            this.tlspCommon.Name = "tlspCommon";
            this.tlspCommon.PrintButtonCauseValidation = true;
            this.tlspCommon.Size = new System.Drawing.Size(875, 30);
            this.tlspCommon.TabIndex = 6;
            this.tlspCommon.TabStop = false;
            this.tlspCommon.ExitButtonClick += new System.EventHandler(this.tlspCommon_ExitButtonClick);
            // 
            // LOMVEW00080
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 464);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.tlspCommon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00080";
            this.Text = "Dealer Information Edit";
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDealer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXC0007 btnSearch;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private System.Windows.Forms.GroupBox gbSearch;
        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private Windows.CXClient.Controls.CXC0003 lblName;
        private Windows.CXClient.Controls.CXC0001 txtName;
        private Windows.CXClient.Controls.CXC0008 chkExactly2;
        private Windows.CXClient.Controls.CXC0003 lblNRC;
        private Windows.CXClient.Controls.CXC0008 chkExactly1;
        private Windows.CXClient.Controls.CXC0001 txtNRC;
        private Windows.CXClient.Controls.CXCLIC001 tlspCommon;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvDealer;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColchkSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDealerNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDealerAC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDname;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBusiness;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDphone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDaddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colemail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNRC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colfax;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colcity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBusinessEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBusinessAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colcommission;
    }
}