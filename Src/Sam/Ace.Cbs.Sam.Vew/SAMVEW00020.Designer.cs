namespace Ace.Cbs.Sam.Vew
{
    partial class SAMVEW00020
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAMVEW00020));
            this.cboBranchCode = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblBranchCode = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtServerName = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtIPAddress = new Ace.Windows.CXClient.Controls.CXC0001();
            this.rdoNewSystem = new Ace.Windows.CXClient.Controls.CXC0009();
            this.cxC00091 = new Ace.Windows.CXClient.Controls.CXC0009();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoOldSystem = new Ace.Windows.CXClient.Controls.CXC0009();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoIPStar = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoVsat = new Ace.Windows.CXClient.Controls.CXC0009();
            this.gvBranchServer = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colIsSelected = new Ace.Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn();
            this.colTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBranchCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colServerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDBName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSystem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colISP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblRecordCount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtRecordCount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.txtDBName = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblDBName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvBranchServer)).BeginInit();
            this.SuspendLayout();
            // 
            // cboBranchCode
            // 
            this.cboBranchCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboBranchCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBranchCode.DropDownHeight = 200;
            this.cboBranchCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBranchCode.FormattingEnabled = true;
            this.cboBranchCode.IntegralHeight = false;
            this.cboBranchCode.IsSendTabOnEnter = true;
            this.cboBranchCode.Location = new System.Drawing.Point(106, 41);
            this.cboBranchCode.Name = "cboBranchCode";
            this.cboBranchCode.Size = new System.Drawing.Size(141, 21);
            this.cboBranchCode.TabIndex = 1;
            // 
            // lblBranchCode
            // 
            this.lblBranchCode.AutoSize = true;
            this.lblBranchCode.Location = new System.Drawing.Point(12, 44);
            this.lblBranchCode.Name = "lblBranchCode";
            this.lblBranchCode.Size = new System.Drawing.Size(72, 13);
            this.lblBranchCode.TabIndex = 0;
            this.lblBranchCode.Text = "BranchCode :";
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(12, 72);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(75, 13);
            this.cxC00031.TabIndex = 0;
            this.cxC00031.Text = "Server Name :";
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.Location = new System.Drawing.Point(12, 99);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(64, 13);
            this.cxC00032.TabIndex = 0;
            this.cxC00032.Text = "IP Address :";
            // 
            // txtServerName
            // 
            this.txtServerName.IsSendTabOnEnter = true;
            this.txtServerName.Location = new System.Drawing.Point(106, 69);
            this.txtServerName.MaxLength = 15;
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(141, 20);
            this.txtServerName.TabIndex = 2;
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.IsSendTabOnEnter = true;
            this.txtIPAddress.Location = new System.Drawing.Point(106, 95);
            this.txtIPAddress.MaxLength = 15;
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(141, 20);
            this.txtIPAddress.TabIndex = 3;
            // 
            // rdoNewSystem
            // 
            this.rdoNewSystem.AutoSize = true;
            this.rdoNewSystem.Checked = true;
            this.rdoNewSystem.IsSendTabOnEnter = true;
            this.rdoNewSystem.Location = new System.Drawing.Point(12, 27);
            this.rdoNewSystem.Name = "rdoNewSystem";
            this.rdoNewSystem.Size = new System.Drawing.Size(84, 17);
            this.rdoNewSystem.TabIndex = 7;
            this.rdoNewSystem.TabStop = true;
            this.rdoNewSystem.Text = "New System";
            this.rdoNewSystem.UseVisualStyleBackColor = true;
            // 
            // cxC00091
            // 
            this.cxC00091.AutoSize = true;
            this.cxC00091.IsSendTabOnEnter = true;
            this.cxC00091.Location = new System.Drawing.Point(-131, 36);
            this.cxC00091.Name = "cxC00091";
            this.cxC00091.Size = new System.Drawing.Size(73, 17);
            this.cxC00091.TabIndex = 7;
            this.cxC00091.Text = "cxC00091";
            this.cxC00091.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoOldSystem);
            this.groupBox1.Controls.Add(this.cxC00091);
            this.groupBox1.Controls.Add(this.rdoNewSystem);
            this.groupBox1.Location = new System.Drawing.Point(16, 149);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(196, 56);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose System";
            // 
            // rdoOldSystem
            // 
            this.rdoOldSystem.AutoSize = true;
            this.rdoOldSystem.IsSendTabOnEnter = true;
            this.rdoOldSystem.Location = new System.Drawing.Point(112, 27);
            this.rdoOldSystem.Name = "rdoOldSystem";
            this.rdoOldSystem.Size = new System.Drawing.Size(78, 17);
            this.rdoOldSystem.TabIndex = 7;
            this.rdoOldSystem.Text = "Old System";
            this.rdoOldSystem.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoIPStar);
            this.groupBox2.Controls.Add(this.rdoVsat);
            this.groupBox2.Location = new System.Drawing.Point(235, 148);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(145, 56);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Choose ISP";
            // 
            // rdoIPStar
            // 
            this.rdoIPStar.AutoSize = true;
            this.rdoIPStar.IsSendTabOnEnter = true;
            this.rdoIPStar.Location = new System.Drawing.Point(77, 27);
            this.rdoIPStar.Name = "rdoIPStar";
            this.rdoIPStar.Size = new System.Drawing.Size(54, 17);
            this.rdoIPStar.TabIndex = 9;
            this.rdoIPStar.Text = "IPStar";
            this.rdoIPStar.UseVisualStyleBackColor = true;
            // 
            // rdoVsat
            // 
            this.rdoVsat.AutoSize = true;
            this.rdoVsat.Checked = true;
            this.rdoVsat.IsSendTabOnEnter = true;
            this.rdoVsat.Location = new System.Drawing.Point(12, 27);
            this.rdoVsat.Name = "rdoVsat";
            this.rdoVsat.Size = new System.Drawing.Size(46, 17);
            this.rdoVsat.TabIndex = 9;
            this.rdoVsat.TabStop = true;
            this.rdoVsat.Text = "Vsat";
            this.rdoVsat.UseVisualStyleBackColor = true;
            // 
            // gvBranchServer
            // 
            this.gvBranchServer.AllowUserToAddRows = false;
            this.gvBranchServer.CausesValidation = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvBranchServer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvBranchServer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvBranchServer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIsSelected,
            this.colTS,
            this.colBranchCode,
            this.colServerName,
            this.colDBName,
            this.colIPAddress,
            this.colSystem,
            this.colISP,
            this.colEdit});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvBranchServer.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvBranchServer.EnableHeadersVisualStyles = false;
            this.gvBranchServer.IdTSList = null;
            this.gvBranchServer.IsEscapeKey = false;
            this.gvBranchServer.IsHeaderClick = false;
            this.gvBranchServer.Location = new System.Drawing.Point(15, 210);
            this.gvBranchServer.Name = "gvBranchServer";
            this.gvBranchServer.RowHeadersWidth = 25;
            this.gvBranchServer.ShowSerialNo = false;
            this.gvBranchServer.Size = new System.Drawing.Size(770, 350);
            this.gvBranchServer.TabIndex = 11;
            this.gvBranchServer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVSERVERLOG_CellContentClick);
            // 
            // colIsSelected
            // 
            this.colIsSelected.CheckBoxHeader = false;
            this.colIsSelected.DataPropertyName = "IsCheck";
            this.colIsSelected.FalseValue = "False";
            this.colIsSelected.HeaderText = "";
            this.colIsSelected.Id = 0;
            this.colIsSelected.Name = "colIsSelected";
            this.colIsSelected.TrueValue = "True";
            this.colIsSelected.TS = null;
            this.colIsSelected.Width = 30;
            // 
            // colTS
            // 
            this.colTS.DataPropertyName = "TS";
            this.colTS.HeaderText = "";
            this.colTS.Name = "colTS";
            this.colTS.Visible = false;
            this.colTS.Width = 50;
            // 
            // colBranchCode
            // 
            this.colBranchCode.DataPropertyName = "BranchNo";
            this.colBranchCode.HeaderText = "BranchCode";
            this.colBranchCode.Name = "colBranchCode";
            this.colBranchCode.ReadOnly = true;
            // 
            // colServerName
            // 
            this.colServerName.DataPropertyName = "Servername";
            this.colServerName.HeaderText = "ServerName";
            this.colServerName.Name = "colServerName";
            this.colServerName.ReadOnly = true;
            this.colServerName.Width = 150;
            // 
            // colDBName
            // 
            this.colDBName.DataPropertyName = "DBName";
            this.colDBName.HeaderText = "DBName";
            this.colDBName.Name = "colDBName";
            this.colDBName.ReadOnly = true;
            this.colDBName.Width = 110;
            // 
            // colIPAddress
            // 
            this.colIPAddress.DataPropertyName = "IPAddress";
            this.colIPAddress.HeaderText = "IP Address";
            this.colIPAddress.Name = "colIPAddress";
            this.colIPAddress.ReadOnly = true;
            this.colIPAddress.Width = 150;
            // 
            // colSystem
            // 
            this.colSystem.DataPropertyName = "Version";
            this.colSystem.HeaderText = "System";
            this.colSystem.Name = "colSystem";
            this.colSystem.ReadOnly = true;
            this.colSystem.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colISP
            // 
            this.colISP.DataPropertyName = "ISPname";
            this.colISP.HeaderText = "ISP ";
            this.colISP.Name = "colISP";
            this.colISP.ReadOnly = true;
            this.colISP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colISP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colISP.Width = 50;
            // 
            // colEdit
            // 
            this.colEdit.HeaderText = "";
            this.colEdit.Image = global::Ace.Cbs.Sam.Vew.Properties.Resources.Edit_Main;
            this.colEdit.Name = "colEdit";
            this.colEdit.Width = 30;
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Location = new System.Drawing.Point(12, 568);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(76, 13);
            this.lblRecordCount.TabIndex = 0;
            this.lblRecordCount.Text = "Record Count:";
            // 
            // txtRecordCount
            // 
            this.txtRecordCount.DecimalPlaces = 0;
            this.txtRecordCount.IsSendTabOnEnter = true;
            this.txtRecordCount.Location = new System.Drawing.Point(108, 565);
            this.txtRecordCount.Name = "txtRecordCount";
            this.txtRecordCount.ReadOnly = true;
            this.txtRecordCount.Size = new System.Drawing.Size(57, 20);
            this.txtRecordCount.TabIndex = 12;
            this.txtRecordCount.Text = "0";
            this.txtRecordCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRecordCount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::Ace.Cbs.Sam.Vew.Properties.Resources.Edit_Main;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 30;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(819, 31);
            this.tsbCRUD.TabIndex = 10;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.DeleteButtonClick += new System.EventHandler(this.tsbCRUD_DeleteButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // txtDBName
            // 
            this.txtDBName.IsSendTabOnEnter = true;
            this.txtDBName.Location = new System.Drawing.Point(106, 121);
            this.txtDBName.MaxLength = 10;
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(141, 20);
            this.txtDBName.TabIndex = 4;
            // 
            // lblDBName
            // 
            this.lblDBName.AutoSize = true;
            this.lblDBName.Location = new System.Drawing.Point(12, 124);
            this.lblDBName.Name = "lblDBName";
            this.lblDBName.Size = new System.Drawing.Size(56, 13);
            this.lblDBName.TabIndex = 0;
            this.lblDBName.Text = "DBName :";
            // 
            // SAMVEW00020
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 593);
            this.Controls.Add(this.lblDBName);
            this.Controls.Add(this.txtDBName);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.txtRecordCount);
            this.Controls.Add(this.gvBranchServer);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtIPAddress);
            this.Controls.Add(this.txtServerName);
            this.Controls.Add(this.cxC00032);
            this.Controls.Add(this.cxC00031);
            this.Controls.Add(this.lblBranchCode);
            this.Controls.Add(this.cboBranchCode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SAMVEW00020";
            this.Text = "Branch Servers Setup Entry";
            this.Load += new System.EventHandler(this.SAMVEW00020_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvBranchServer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0002 cboBranchCode;
        private Windows.CXClient.Controls.CXC0003 lblBranchCode;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private Windows.CXClient.Controls.CXC0001 txtServerName;
        private Windows.CXClient.Controls.CXC0001 txtIPAddress;
        private Windows.CXClient.Controls.CXC0009 rdoNewSystem;
        private Windows.CXClient.Controls.CXC0009 cxC00091;
        private System.Windows.Forms.GroupBox groupBox1;
        private Windows.CXClient.Controls.CXC0009 rdoOldSystem;
        private System.Windows.Forms.GroupBox groupBox2;
        private Windows.CXClient.Controls.CXC0009 rdoIPStar;
        private Windows.CXClient.Controls.CXC0009 rdoVsat;
        private Windows.CXClient.Controls.AceGridView gvBranchServer;
        private Windows.CXClient.Controls.CXC0003 lblRecordCount;
        private Windows.CXClient.Controls.CXC0004 txtRecordCount;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0001 txtDBName;
        private Windows.CXClient.Controls.CXC0003 lblDBName;
        private Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn colIsSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBranchCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colServerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDBName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIPAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSystem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colISP;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
    }
}