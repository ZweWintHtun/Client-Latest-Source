namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00425
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00425));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OptByCompanyName = new System.Windows.Forms.RadioButton();
            this.OptName = new System.Windows.Forms.RadioButton();
            this.chkNRCExactly = new Ace.Windows.CXClient.Controls.CXC0008();
            this.btnSearch = new Ace.Windows.CXClient.Controls.CXC0007();
            this.chkNameExactly = new System.Windows.Forms.CheckBox();
            this.txtNRC = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvCustomerInfo = new System.Windows.Forms.DataGridView();
            this.colCustID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNRC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlspCommon = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.OptByCompanyName);
            this.groupBox1.Controls.Add(this.OptName);
            this.groupBox1.Controls.Add(this.chkNRCExactly);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.chkNameExactly);
            this.groupBox1.Controls.Add(this.txtNRC);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Location = new System.Drawing.Point(12, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1053, 132);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search By ";
            // 
            // OptByCompanyName
            // 
            this.OptByCompanyName.AutoSize = true;
            this.OptByCompanyName.Location = new System.Drawing.Point(151, 32);
            this.OptByCompanyName.Name = "OptByCompanyName";
            this.OptByCompanyName.Size = new System.Drawing.Size(100, 17);
            this.OptByCompanyName.TabIndex = 10;
            this.OptByCompanyName.Text = "Company Name";
            this.OptByCompanyName.UseVisualStyleBackColor = true;
            this.OptByCompanyName.CheckedChanged += new System.EventHandler(this.OptByCompanyName_CheckedChanged);
            // 
            // OptName
            // 
            this.OptName.AutoSize = true;
            this.OptName.Checked = true;
            this.OptName.Location = new System.Drawing.Point(37, 32);
            this.OptName.Name = "OptName";
            this.OptName.Size = new System.Drawing.Size(53, 17);
            this.OptName.TabIndex = 9;
            this.OptName.TabStop = true;
            this.OptName.Text = "Name";
            this.OptName.UseVisualStyleBackColor = true;
            this.OptName.CheckedChanged += new System.EventHandler(this.OptName_CheckedChanged);
            // 
            // chkNRCExactly
            // 
            this.chkNRCExactly.AutoSize = true;
            this.chkNRCExactly.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNRCExactly.IsSendTabOnEnter = true;
            this.chkNRCExactly.Location = new System.Drawing.Point(328, 102);
            this.chkNRCExactly.Name = "chkNRCExactly";
            this.chkNRCExactly.Size = new System.Drawing.Size(60, 17);
            this.chkNRCExactly.TabIndex = 8;
            this.chkNRCExactly.Text = "Exactly";
            this.chkNRCExactly.UseVisualStyleBackColor = true;
            this.chkNRCExactly.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSearch.Location = new System.Drawing.Point(427, 92);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(76, 28);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "&Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // chkNameExactly
            // 
            this.chkNameExactly.AutoSize = true;
            this.chkNameExactly.Location = new System.Drawing.Point(328, 72);
            this.chkNameExactly.Name = "chkNameExactly";
            this.chkNameExactly.Size = new System.Drawing.Size(60, 17);
            this.chkNameExactly.TabIndex = 1;
            this.chkNameExactly.Text = "Exactly";
            this.chkNameExactly.UseVisualStyleBackColor = true;
            // 
            // txtNRC
            // 
            this.txtNRC.Location = new System.Drawing.Point(109, 100);
            this.txtNRC.Name = "txtNRC";
            this.txtNRC.Size = new System.Drawing.Size(213, 20);
            this.txtNRC.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(109, 69);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(213, 20);
            this.txtName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "NRC :";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(18, 72);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvCustomerInfo);
            this.groupBox2.Location = new System.Drawing.Point(10, 174);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1055, 281);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Customer Information";
            // 
            // dgvCustomerInfo
            // 
            this.dgvCustomerInfo.AllowUserToAddRows = false;
            this.dgvCustomerInfo.AllowUserToDeleteRows = false;
            this.dgvCustomerInfo.AllowUserToResizeRows = false;
            this.dgvCustomerInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCustID,
            this.colAC,
            this.colName,
            this.colNRC,
            this.colOcc,
            this.colPhone,
            this.colAddress});
            this.dgvCustomerInfo.Location = new System.Drawing.Point(13, 27);
            this.dgvCustomerInfo.Name = "dgvCustomerInfo";
            this.dgvCustomerInfo.RowHeadersVisible = false;
            this.dgvCustomerInfo.Size = new System.Drawing.Size(1032, 246);
            this.dgvCustomerInfo.TabIndex = 2;
            // 
            // colCustID
            // 
            this.colCustID.HeaderText = "CustomerID";
            this.colCustID.Name = "colCustID";
            this.colCustID.Width = 90;
            // 
            // colAC
            // 
            this.colAC.HeaderText = "AccountNo";
            this.colAC.Name = "colAC";
            this.colAC.Width = 110;
            // 
            // colName
            // 
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.Width = 180;
            // 
            // colNRC
            // 
            this.colNRC.HeaderText = "NRC";
            this.colNRC.Name = "colNRC";
            this.colNRC.Width = 120;
            // 
            // colOcc
            // 
            this.colOcc.HeaderText = "Occupation";
            this.colOcc.Name = "colOcc";
            // 
            // colPhone
            // 
            this.colPhone.HeaderText = "Phone";
            this.colPhone.Name = "colPhone";
            // 
            // colAddress
            // 
            this.colAddress.HeaderText = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.Width = 350;
            // 
            // tlspCommon
            // 
            this.tlspCommon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tlspCommon.BackColor = System.Drawing.Color.PowderBlue;
            this.tlspCommon.Location = new System.Drawing.Point(-2, 0);
            this.tlspCommon.Name = "tlspCommon";
            this.tlspCommon.PrintButtonCauseValidation = true;
            this.tlspCommon.Size = new System.Drawing.Size(1075, 30);
            this.tlspCommon.TabIndex = 9;
            this.tlspCommon.TabStop = false;
            this.tlspCommon.CancelButtonClick += new System.EventHandler(this.tlspCommon_CancelButtonClick);
            this.tlspCommon.ExitButtonClick += new System.EventHandler(this.tlspCommon_ExitButtonClick);
            // 
            // LOMVEW00425
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 460);
            this.Controls.Add(this.tlspCommon);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LOMVEW00425";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Business Loans Account Information Enquiry";
            this.Load += new System.EventHandler(this.LOMVEW00425_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkNameExactly;
        private System.Windows.Forms.TextBox txtNRC;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvCustomerInfo;
        private Windows.CXClient.Controls.CXC0007 btnSearch;
        private Windows.CXClient.Controls.CXCLIC001 tlspCommon;
        private Windows.CXClient.Controls.CXC0008 chkNRCExactly;
        private System.Windows.Forms.RadioButton OptByCompanyName;
        private System.Windows.Forms.RadioButton OptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNRC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOcc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
    }
}