namespace Ace.Cbs.Pfm.Vew
{
    partial class frmPFMVEW00021
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPFMVEW00021));
            this.gboWithdrawal = new System.Windows.Forms.GroupBox();
            this.txtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtNRC = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtName = new Ace.Windows.CXClient.Controls.CXC0001();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.butAddtoList = new Ace.Windows.CXClient.Controls.CXC0007();
            this.lblOLSAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gvSavingWithdrawal = new System.Windows.Forms.DataGridView();
            this.ColDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.SrNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOLSACNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mtxtOLSAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblNRC = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxcliC0011 = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gboWithdrawal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSavingWithdrawal)).BeginInit();
            this.SuspendLayout();
            // 
            // gboWithdrawal
            // 
            this.gboWithdrawal.Controls.Add(this.txtAmount);
            this.gboWithdrawal.Controls.Add(this.txtNRC);
            this.gboWithdrawal.Controls.Add(this.txtName);
            this.gboWithdrawal.Controls.Add(this.mtxtAccountNo);
            this.gboWithdrawal.Controls.Add(this.butAddtoList);
            this.gboWithdrawal.Controls.Add(this.lblOLSAccountNo);
            this.gboWithdrawal.Controls.Add(this.gvSavingWithdrawal);
            this.gboWithdrawal.Controls.Add(this.mtxtOLSAccountNo);
            this.gboWithdrawal.Controls.Add(this.lblAccountNo);
            this.gboWithdrawal.Controls.Add(this.lblAmount);
            this.gboWithdrawal.Controls.Add(this.lblName);
            this.gboWithdrawal.Controls.Add(this.lblNRC);
            this.gboWithdrawal.Location = new System.Drawing.Point(10, 37);
            this.gboWithdrawal.Name = "gboWithdrawal";
            this.gboWithdrawal.Size = new System.Drawing.Size(720, 353);
            this.gboWithdrawal.TabIndex = 1;
            this.gboWithdrawal.TabStop = false;
            // 
            // txtAmount
            // 
            this.txtAmount.DecimalPlaces = 2;
            this.txtAmount.IsSendTabOnEnter = true;
            this.txtAmount.Location = new System.Drawing.Point(94, 120);
            this.txtAmount.MaxLength = 18;
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
            // txtNRC
            // 
            this.txtNRC.BackColor = System.Drawing.SystemColors.Window;
            this.txtNRC.IsSendTabOnEnter = true;
            this.txtNRC.Location = new System.Drawing.Point(94, 95);
            this.txtNRC.MaxLength = 20;
            this.txtNRC.Name = "txtNRC";
            this.txtNRC.Size = new System.Drawing.Size(175, 20);
            this.txtNRC.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.Window;
            this.txtName.IsSendTabOnEnter = true;
            this.txtName.Location = new System.Drawing.Point(94, 69);
            this.txtName.MaxLength = 30;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(175, 20);
            this.txtName.TabIndex = 2;
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.ForeColor = System.Drawing.Color.Black;
            this.mtxtAccountNo.HidePromptOnLeave = true;
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(94, 43);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 1;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtxtAccountNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // butAddtoList
            // 
            this.butAddtoList.Image = ((System.Drawing.Image)(resources.GetObject("butAddtoList.Image")));
            this.butAddtoList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAddtoList.Location = new System.Drawing.Point(615, 117);
            this.butAddtoList.Name = "butAddtoList";
            this.butAddtoList.Size = new System.Drawing.Size(89, 24);
            this.butAddtoList.TabIndex = 7;
            this.butAddtoList.Text = "&Add to List";
            this.butAddtoList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butAddtoList.UseVisualStyleBackColor = true;
            this.butAddtoList.Click += new System.EventHandler(this.butAddtoList_Click);
            // 
            // lblOLSAccountNo
            // 
            this.lblOLSAccountNo.AutoSize = true;
            this.lblOLSAccountNo.Location = new System.Drawing.Point(14, 20);
            this.lblOLSAccountNo.Name = "lblOLSAccountNo";
            this.lblOLSAccountNo.Size = new System.Drawing.Size(75, 13);
            this.lblOLSAccountNo.TabIndex = 0;
            this.lblOLSAccountNo.Text = "OLS A/C NO :";
            // 
            // gvSavingWithdrawal
            // 
            this.gvSavingWithdrawal.AllowUserToAddRows = false;
            this.gvSavingWithdrawal.AllowUserToDeleteRows = false;
            this.gvSavingWithdrawal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gvSavingWithdrawal.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gvSavingWithdrawal.CausesValidation = false;
            this.gvSavingWithdrawal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSavingWithdrawal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColDelete,
            this.SrNo,
            this.colOLSACNo,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.gvSavingWithdrawal.Location = new System.Drawing.Point(17, 156);
            this.gvSavingWithdrawal.Name = "gvSavingWithdrawal";
            this.gvSavingWithdrawal.ReadOnly = true;
            this.gvSavingWithdrawal.Size = new System.Drawing.Size(687, 174);
            this.gvSavingWithdrawal.TabIndex = 0;
            this.gvSavingWithdrawal.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvSavingWithdrawal_CellContentClick);
            // 
            // ColDelete
            // 
            this.ColDelete.HeaderText = "";
            this.ColDelete.Image = global::Ace.Cbs.Pfm.Vew.Properties.Resources.cancel_01;
            this.ColDelete.Name = "ColDelete";
            this.ColDelete.ReadOnly = true;
            this.ColDelete.Width = 5;
            // 
            // SrNo
            // 
            this.SrNo.DataPropertyName = "SrNo";
            this.SrNo.HeaderText = "Sr No.";
            this.SrNo.Name = "SrNo";
            this.SrNo.ReadOnly = true;
            this.SrNo.Width = 62;
            // 
            // colOLSACNo
            // 
            this.colOLSACNo.DataPropertyName = "OLSACNo";
            this.colOLSACNo.HeaderText = "OLS A/C No";
            this.colOLSACNo.Name = "colOLSACNo";
            this.colOLSACNo.ReadOnly = true;
            this.colOLSACNo.Width = 92;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "AccountNo";
            this.dataGridViewTextBoxColumn2.HeaderText = "Account No";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 89;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn3.HeaderText = "Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "NRC";
            this.dataGridViewTextBoxColumn4.HeaderText = "NRC No";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 72;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Amount";
            this.dataGridViewTextBoxColumn5.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 68;
            // 
            // mtxtOLSAccountNo
            // 
            this.mtxtOLSAccountNo.HidePromptOnLeave = true;
            this.mtxtOLSAccountNo.IsSendTabOnEnter = true;
            this.mtxtOLSAccountNo.Location = new System.Drawing.Point(95, 17);
            this.mtxtOLSAccountNo.Name = "mtxtOLSAccountNo";
            this.mtxtOLSAccountNo.Size = new System.Drawing.Size(50, 20);
            this.mtxtOLSAccountNo.TabIndex = 0;
            this.mtxtOLSAccountNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(14, 46);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(70, 13);
            this.lblAccountNo.TabIndex = 0;
            this.lblAccountNo.Text = "Account No :";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(14, 124);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(49, 13);
            this.lblAmount.TabIndex = 0;
            this.lblAmount.Text = "Amount :";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(14, 72);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name :";
            // 
            // lblNRC
            // 
            this.lblNRC.AutoSize = true;
            this.lblNRC.Location = new System.Drawing.Point(14, 98);
            this.lblNRC.Name = "lblNRC";
            this.lblNRC.Size = new System.Drawing.Size(36, 13);
            this.lblNRC.TabIndex = 0;
            this.lblNRC.Text = "NRC :";
            // 
            // cxcliC0011
            // 
            this.cxcliC0011.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cxcliC0011.BackColor = System.Drawing.Color.PowderBlue;
            this.cxcliC0011.Location = new System.Drawing.Point(0, 0);
            this.cxcliC0011.Name = "cxcliC0011";
            this.cxcliC0011.PrintButtonCauseValidation = true;
            this.cxcliC0011.Size = new System.Drawing.Size(751, 30);
            this.cxcliC0011.TabIndex = 2;
            this.cxcliC0011.CancelButtonClick += new System.EventHandler(this.cxcliC0011_CancelButtonClick);
            this.cxcliC0011.PrintButtonClick += new System.EventHandler(this.cxcliC0011_PrintButtonClick);
            this.cxcliC0011.ExitButtonClick += new System.EventHandler(this.cxcliC0011_ExitButtonClick);
            // 
            // frmPFMVEW00021
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 402);
            this.Controls.Add(this.cxcliC0011);
            this.Controls.Add(this.gboWithdrawal);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPFMVEW00021";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PFMVEW00021";
            this.Load += new System.EventHandler(this.PFMVEW00021_Load);
            this.gboWithdrawal.ResumeLayout(false);
            this.gboWithdrawal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSavingWithdrawal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboWithdrawal;
        private Ace.Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Ace.Windows.CXClient.Controls.CXC0007 butAddtoList;
        private Ace.Windows.CXClient.Controls.CXC0003 lblOLSAccountNo;
        private System.Windows.Forms.DataGridView gvSavingWithdrawal;
        private System.Windows.Forms.DataGridViewTextBoxColumn OLSACNO;
        private Ace.Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblAmount;
        private Ace.Windows.CXClient.Controls.CXC0003 lblName;
        private Ace.Windows.CXClient.Controls.CXC0003 lblNRC;
        private Ace.Windows.CXClient.Controls.CXCLIC001 cxcliC0011;
        private Ace.Windows.CXClient.Controls.CXC0001 txtName;
        private Ace.Windows.CXClient.Controls.CXC0006 mtxtOLSAccountNo;
        private Ace.Windows.CXClient.Controls.CXC0004 txtAmount;
        private Ace.Windows.CXClient.Controls.CXC0001 txtNRC;
        private System.Windows.Forms.DataGridViewImageColumn ColDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn SrNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOLSACNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}