namespace Ace.Cbs.Pfm.Vew
{
    partial class frmPFMVEW00014
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPFMVEW00014));
            this.txtEndSerialNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.gbAccountInformation = new System.Windows.Forms.GroupBox();
            this.txtRemark = new Ace.Windows.CXClient.Controls.CXC0001();
            this.gvCustomer = new Ace.Windows.CXClient.Controls.AceGridView();
            this.ColCustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNRC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblRemark = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblEndSerialNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtStartSerialNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblStartSerialNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtChequeBookNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblChequeBookNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxcliC0011 = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gbAccountInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEndSerialNo
            // 
            this.txtEndSerialNo.IsSendTabOnEnter = true;
            this.txtEndSerialNo.Location = new System.Drawing.Point(410, 40);
            this.txtEndSerialNo.MaxLength = 8;
            this.txtEndSerialNo.Name = "txtEndSerialNo";
            this.txtEndSerialNo.Size = new System.Drawing.Size(58, 20);
            this.txtEndSerialNo.TabIndex = 3;
            this.txtEndSerialNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEndSerialNo_KeyPress);
            this.txtEndSerialNo.Validated += new System.EventHandler(this.txtEndSerialNo_Validated);
            // 
            // gbAccountInformation
            // 
            this.gbAccountInformation.Controls.Add(this.txtRemark);
            this.gbAccountInformation.Controls.Add(this.gvCustomer);
            this.gbAccountInformation.Controls.Add(this.txtEndSerialNo);
            this.gbAccountInformation.Controls.Add(this.mtxtAccountNo);
            this.gbAccountInformation.Controls.Add(this.lblRemark);
            this.gbAccountInformation.Controls.Add(this.lblEndSerialNo);
            this.gbAccountInformation.Controls.Add(this.txtStartSerialNo);
            this.gbAccountInformation.Controls.Add(this.lblAccountNo);
            this.gbAccountInformation.Controls.Add(this.lblStartSerialNo);
            this.gbAccountInformation.Controls.Add(this.txtChequeBookNo);
            this.gbAccountInformation.Controls.Add(this.lblChequeBookNo);
            this.gbAccountInformation.Location = new System.Drawing.Point(12, 35);
            this.gbAccountInformation.Name = "gbAccountInformation";
            this.gbAccountInformation.Size = new System.Drawing.Size(547, 331);
            this.gbAccountInformation.TabIndex = 0;
            this.gbAccountInformation.TabStop = false;
            // 
            // txtRemark
            // 
            this.txtRemark.IsSendTabOnEnter = true;
            this.txtRemark.Location = new System.Drawing.Point(103, 67);
            this.txtRemark.MaxLength = 40;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(175, 60);
            this.txtRemark.TabIndex = 4;
            // 
            // gvCustomer
            // 
            this.gvCustomer.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gvCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCustomerID,
            this.ColName,
            this.ColNRC});
            this.gvCustomer.EnableHeadersVisualStyles = false;
            this.gvCustomer.IdTSList = null;
            this.gvCustomer.IsEscapeKey = false;
            this.gvCustomer.IsHeaderClick = false;
            this.gvCustomer.Location = new System.Drawing.Point(11, 132);
            this.gvCustomer.Name = "gvCustomer";
            this.gvCustomer.ReadOnly = true;
            this.gvCustomer.RowHeadersWidth = 25;
            this.gvCustomer.ShowSerialNo = false;
            this.gvCustomer.Size = new System.Drawing.Size(524, 190);
            this.gvCustomer.TabIndex = 6;
            // 
            // ColCustomerID
            // 
            this.ColCustomerID.DataPropertyName = "CustomerId";
            this.ColCustomerID.HeaderText = "Customer ID";
            this.ColCustomerID.Name = "ColCustomerID";
            this.ColCustomerID.ReadOnly = true;
            this.ColCustomerID.Width = 120;
            // 
            // ColName
            // 
            this.ColName.DataPropertyName = "Name";
            this.ColName.HeaderText = "Name";
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            this.ColName.Width = 175;
            // 
            // ColNRC
            // 
            this.ColNRC.DataPropertyName = "NRC";
            this.ColNRC.HeaderText = "NRC";
            this.ColNRC.Name = "ColNRC";
            this.ColNRC.ReadOnly = true;
            this.ColNRC.Width = 175;
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtxtAccountNo.HidePromptOnLeave = true;
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(103, 15);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 0;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(8, 69);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(50, 13);
            this.lblRemark.TabIndex = 0;
            this.lblRemark.Text = "Remark :";
            // 
            // lblEndSerialNo
            // 
            this.lblEndSerialNo.AutoSize = true;
            this.lblEndSerialNo.Location = new System.Drawing.Point(298, 43);
            this.lblEndSerialNo.Name = "lblEndSerialNo";
            this.lblEndSerialNo.Size = new System.Drawing.Size(78, 13);
            this.lblEndSerialNo.TabIndex = 0;
            this.lblEndSerialNo.Text = "End Serial No :";
            // 
            // txtStartSerialNo
            // 
            this.txtStartSerialNo.IsSendTabOnEnter = true;
            this.txtStartSerialNo.Location = new System.Drawing.Point(103, 41);
            this.txtStartSerialNo.MaxLength = 8;
            this.txtStartSerialNo.Name = "txtStartSerialNo";
            this.txtStartSerialNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStartSerialNo.Size = new System.Drawing.Size(58, 20);
            this.txtStartSerialNo.TabIndex = 2;
            this.txtStartSerialNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStartSerialNo_KeyPress);
            this.txtStartSerialNo.Validated += new System.EventHandler(this.txtStartSerialNo_Validated);
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(8, 17);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(70, 13);
            this.lblAccountNo.TabIndex = 0;
            this.lblAccountNo.Text = "Account No :";
            // 
            // lblStartSerialNo
            // 
            this.lblStartSerialNo.AutoSize = true;
            this.lblStartSerialNo.Location = new System.Drawing.Point(8, 43);
            this.lblStartSerialNo.Name = "lblStartSerialNo";
            this.lblStartSerialNo.Size = new System.Drawing.Size(81, 13);
            this.lblStartSerialNo.TabIndex = 0;
            this.lblStartSerialNo.Text = "Start Serial No :";
            // 
            // txtChequeBookNo
            // 
            this.txtChequeBookNo.IsSendTabOnEnter = true;
            this.txtChequeBookNo.Location = new System.Drawing.Point(410, 15);
            this.txtChequeBookNo.MaxLength = 7;
            this.txtChequeBookNo.Name = "txtChequeBookNo";
            this.txtChequeBookNo.Size = new System.Drawing.Size(58, 20);
            this.txtChequeBookNo.TabIndex = 1;
            this.txtChequeBookNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChequeBookNo_KeyPress);
            this.txtChequeBookNo.Validated += new System.EventHandler(this.txtChequeBookNo_Validated);
            // 
            // lblChequeBookNo
            // 
            this.lblChequeBookNo.AutoSize = true;
            this.lblChequeBookNo.Location = new System.Drawing.Point(298, 17);
            this.lblChequeBookNo.Name = "lblChequeBookNo";
            this.lblChequeBookNo.Size = new System.Drawing.Size(95, 13);
            this.lblChequeBookNo.TabIndex = 0;
            this.lblChequeBookNo.Text = "Cheque Book No :";
            // 
            // cxcliC0011
            // 
            this.cxcliC0011.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cxcliC0011.BackColor = System.Drawing.Color.PowderBlue;
            this.cxcliC0011.Location = new System.Drawing.Point(-1, 0);
            this.cxcliC0011.Name = "cxcliC0011";
            this.cxcliC0011.PrintButtonCauseValidation = true;
            this.cxcliC0011.Size = new System.Drawing.Size(571, 30);
            this.cxcliC0011.TabIndex = 5;
            this.cxcliC0011.SaveButtonClick += new System.EventHandler(this.cxcliC0011_SaveButtonClick);
            this.cxcliC0011.CancelButtonClick += new System.EventHandler(this.cxcliC0011_CancelButtonClick);
            this.cxcliC0011.ExitButtonClick += new System.EventHandler(this.cxcliC0011_ExitButtonClick);
            // 
            // frmPFMVEW00014
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(568, 378);
            this.Controls.Add(this.cxcliC0011);
            this.Controls.Add(this.gbAccountInformation);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPFMVEW00014";
            this.Text = "Stop Cheque Entry";
            this.Load += new System.EventHandler(this.frmPFMVEW00014_Load);
            this.Move += new System.EventHandler(this.frmPFMVEW00014_Move);
            this.gbAccountInformation.ResumeLayout(false);
            this.gbAccountInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Ace.Windows.CXClient.Controls.CXC0001 txtEndSerialNo;
        private System.Windows.Forms.GroupBox gbAccountInformation;
        private Ace.Windows.CXClient.Controls.CXC0001 txtRemark;
        private Ace.Windows.CXClient.Controls.AceGridView gvCustomer;
        private Ace.Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblRemark;
        private Ace.Windows.CXClient.Controls.CXC0003 lblEndSerialNo;
        private Ace.Windows.CXClient.Controls.CXC0001 txtStartSerialNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblStartSerialNo;
        private Ace.Windows.CXClient.Controls.CXC0001 txtChequeBookNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblChequeBookNo;
        private Windows.CXClient.Controls.CXCLIC001 cxcliC0011;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNRC;

    }
}