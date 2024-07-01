namespace Ace.Cbs.Pfm.Vew
{
    partial class frmPFMVEW00078
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPFMVEW00078));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtNRCNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.cboNationalityCode = new Ace.Windows.CXClient.Controls.CXC0002();
            this.gvSolidarityLendingEntry = new System.Windows.Forms.GroupBox();
            this.chkLeader = new System.Windows.Forms.CheckBox();
            this.butAddMember = new Ace.Windows.CXClient.Controls.CXC0007();
            this.txtAddress = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblAddress = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboVillage = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblVillage = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboTownshipCode = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cboStateCode = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblCustNRC = new Ace.Windows.CXClient.Controls.CXC0003();
            this.rdoOther = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoNRC = new Ace.Windows.CXClient.Controls.CXC0009();
            this.txtGroupNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtNRC = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtName = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtFatherName = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblFather = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblGroupNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCustOtherNRC = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gbNRC = new System.Windows.Forms.GroupBox();
            this.tlspCommon = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gvSolidarityLending = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsNRC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNRCNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFatherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVillageCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVillageName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.gvSolidarityLendingEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSolidarityLending)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNRCNo
            // 
            this.txtNRCNo.IsSendTabOnEnter = true;
            this.txtNRCNo.Location = new System.Drawing.Point(291, 145);
            this.txtNRCNo.MaxLength = 6;
            this.txtNRCNo.Name = "txtNRCNo";
            this.txtNRCNo.Size = new System.Drawing.Size(89, 20);
            this.txtNRCNo.TabIndex = 6;
            this.txtNRCNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNRCNo_KeyPress);
            // 
            // cboNationalityCode
            // 
            this.cboNationalityCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboNationalityCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboNationalityCode.DropDownHeight = 200;
            this.cboNationalityCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNationalityCode.FormattingEnabled = true;
            this.cboNationalityCode.IntegralHeight = false;
            this.cboNationalityCode.IsSendTabOnEnter = true;
            this.cboNationalityCode.Items.AddRange(new object[] {
            "(E)",
            "(N)",
            "(P)",
            "(T)"});
            this.cboNationalityCode.Location = new System.Drawing.Point(245, 145);
            this.cboNationalityCode.Name = "cboNationalityCode";
            this.cboNationalityCode.Size = new System.Drawing.Size(40, 21);
            this.cboNationalityCode.TabIndex = 5;
            // 
            // gvSolidarityLendingEntry
            // 
            this.gvSolidarityLendingEntry.Controls.Add(this.chkLeader);
            this.gvSolidarityLendingEntry.Controls.Add(this.butAddMember);
            this.gvSolidarityLendingEntry.Controls.Add(this.txtAddress);
            this.gvSolidarityLendingEntry.Controls.Add(this.lblAddress);
            this.gvSolidarityLendingEntry.Controls.Add(this.cboVillage);
            this.gvSolidarityLendingEntry.Controls.Add(this.lblVillage);
            this.gvSolidarityLendingEntry.Controls.Add(this.txtNRCNo);
            this.gvSolidarityLendingEntry.Controls.Add(this.cboNationalityCode);
            this.gvSolidarityLendingEntry.Controls.Add(this.cboTownshipCode);
            this.gvSolidarityLendingEntry.Controls.Add(this.cboStateCode);
            this.gvSolidarityLendingEntry.Controls.Add(this.lblCustNRC);
            this.gvSolidarityLendingEntry.Controls.Add(this.rdoOther);
            this.gvSolidarityLendingEntry.Controls.Add(this.rdoNRC);
            this.gvSolidarityLendingEntry.Controls.Add(this.txtGroupNo);
            this.gvSolidarityLendingEntry.Controls.Add(this.txtNRC);
            this.gvSolidarityLendingEntry.Controls.Add(this.txtName);
            this.gvSolidarityLendingEntry.Controls.Add(this.txtFatherName);
            this.gvSolidarityLendingEntry.Controls.Add(this.lblName);
            this.gvSolidarityLendingEntry.Controls.Add(this.lblFather);
            this.gvSolidarityLendingEntry.Controls.Add(this.lblGroupNo);
            this.gvSolidarityLendingEntry.Controls.Add(this.lblCustOtherNRC);
            this.gvSolidarityLendingEntry.Controls.Add(this.gbNRC);
            this.gvSolidarityLendingEntry.Location = new System.Drawing.Point(12, 40);
            this.gvSolidarityLendingEntry.Name = "gvSolidarityLendingEntry";
            this.gvSolidarityLendingEntry.Size = new System.Drawing.Size(945, 203);
            this.gvSolidarityLendingEntry.TabIndex = 26;
            this.gvSolidarityLendingEntry.TabStop = false;
            this.gvSolidarityLendingEntry.Text = "Solidarity Lending  :";
            // 
            // chkLeader
            // 
            this.chkLeader.AutoSize = true;
            this.chkLeader.Location = new System.Drawing.Point(280, 82);
            this.chkLeader.Name = "chkLeader";
            this.chkLeader.Size = new System.Drawing.Size(59, 17);
            this.chkLeader.TabIndex = 100003;
            this.chkLeader.Text = "Leader";
            this.chkLeader.UseVisualStyleBackColor = true;
            this.chkLeader.CheckedChanged += new System.EventHandler(this.chkLeader_CheckedChanged);
            // 
            // butAddMember
            // 
            this.butAddMember.Image = ((System.Drawing.Image)(resources.GetObject("butAddMember.Image")));
            this.butAddMember.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAddMember.Location = new System.Drawing.Point(834, 169);
            this.butAddMember.Name = "butAddMember";
            this.butAddMember.Size = new System.Drawing.Size(97, 24);
            this.butAddMember.TabIndex = 11;
            this.butAddMember.Text = "&Add Customer";
            this.butAddMember.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butAddMember.UseVisualStyleBackColor = true;
            this.butAddMember.Click += new System.EventHandler(this.butAddMember_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.IsSendTabOnEnter = true;
            this.txtAddress.Location = new System.Drawing.Point(659, 107);
            this.txtAddress.MaxLength = 200;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(272, 38);
            this.txtAddress.TabIndex = 10;
            this.txtAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAddress_KeyPress);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(510, 115);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(51, 13);
            this.lblAddress.TabIndex = 100002;
            this.lblAddress.Text = "Address :";
            // 
            // cboVillage
            // 
            this.cboVillage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboVillage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboVillage.DropDownHeight = 200;
            this.cboVillage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVillage.FormattingEnabled = true;
            this.cboVillage.IntegralHeight = false;
            this.cboVillage.IsSendTabOnEnter = true;
            this.cboVillage.Location = new System.Drawing.Point(660, 80);
            this.cboVillage.Name = "cboVillage";
            this.cboVillage.Size = new System.Drawing.Size(141, 21);
            this.cboVillage.TabIndex = 9;
            // 
            // lblVillage
            // 
            this.lblVillage.AutoSize = true;
            this.lblVillage.Location = new System.Drawing.Point(508, 86);
            this.lblVillage.Name = "lblVillage";
            this.lblVillage.Size = new System.Drawing.Size(44, 13);
            this.lblVillage.TabIndex = 100000;
            this.lblVillage.Text = "Village :";
            // 
            // cboTownshipCode
            // 
            this.cboTownshipCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboTownshipCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTownshipCode.DropDownHeight = 200;
            this.cboTownshipCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTownshipCode.FormattingEnabled = true;
            this.cboTownshipCode.IntegralHeight = false;
            this.cboTownshipCode.IsSendTabOnEnter = true;
            this.cboTownshipCode.Location = new System.Drawing.Point(145, 145);
            this.cboTownshipCode.Name = "cboTownshipCode";
            this.cboTownshipCode.Size = new System.Drawing.Size(94, 21);
            this.cboTownshipCode.TabIndex = 4;
            this.cboTownshipCode.TabIndexChanged += new System.EventHandler(this.cboTownshipCode_TabIndexChanged);
            // 
            // cboStateCode
            // 
            this.cboStateCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboStateCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboStateCode.DropDownHeight = 200;
            this.cboStateCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStateCode.FormattingEnabled = true;
            this.cboStateCode.IntegralHeight = false;
            this.cboStateCode.IsSendTabOnEnter = true;
            this.cboStateCode.Location = new System.Drawing.Point(98, 145);
            this.cboStateCode.MaxDropDownItems = 15;
            this.cboStateCode.Name = "cboStateCode";
            this.cboStateCode.Size = new System.Drawing.Size(40, 21);
            this.cboStateCode.TabIndex = 3;
            this.cboStateCode.SelectedIndexChanged += new System.EventHandler(this.cboStateCode_SelectedIndexChanged);
            // 
            // lblCustNRC
            // 
            this.lblCustNRC.AutoSize = true;
            this.lblCustNRC.Location = new System.Drawing.Point(15, 148);
            this.lblCustNRC.Name = "lblCustNRC";
            this.lblCustNRC.Size = new System.Drawing.Size(36, 13);
            this.lblCustNRC.TabIndex = 0;
            this.lblCustNRC.Text = "NRC :";
            // 
            // rdoOther
            // 
            this.rdoOther.AutoSize = true;
            this.rdoOther.IsSendTabOnEnter = true;
            this.rdoOther.Location = new System.Drawing.Point(204, 116);
            this.rdoOther.Name = "rdoOther";
            this.rdoOther.Size = new System.Drawing.Size(57, 17);
            this.rdoOther.TabIndex = 2;
            this.rdoOther.Text = "Other :";
            this.rdoOther.UseVisualStyleBackColor = true;
            this.rdoOther.CheckedChanged += new System.EventHandler(this.rdoOther_CheckedChanged);
            // 
            // rdoNRC
            // 
            this.rdoNRC.AutoSize = true;
            this.rdoNRC.Checked = true;
            this.rdoNRC.IsSendTabOnEnter = true;
            this.rdoNRC.Location = new System.Drawing.Point(126, 117);
            this.rdoNRC.Name = "rdoNRC";
            this.rdoNRC.Size = new System.Drawing.Size(54, 17);
            this.rdoNRC.TabIndex = 1;
            this.rdoNRC.TabStop = true;
            this.rdoNRC.Text = "NRC :";
            this.rdoNRC.UseVisualStyleBackColor = true;
            this.rdoNRC.CheckedChanged += new System.EventHandler(this.rdoNRC_CheckedChanged);
            // 
            // txtGroupNo
            // 
            this.txtGroupNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtGroupNo.Enabled = false;
            this.txtGroupNo.HidePromptOnLeave = true;
            this.txtGroupNo.IsSendTabOnEnter = true;
            this.txtGroupNo.Location = new System.Drawing.Point(98, 54);
            this.txtGroupNo.Name = "txtGroupNo";
            this.txtGroupNo.Size = new System.Drawing.Size(115, 20);
            this.txtGroupNo.TabIndex = 99999;
            this.txtGroupNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtGroupNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGroupNo_KeyDown);
            // 
            // txtNRC
            // 
            this.txtNRC.IsSendTabOnEnter = true;
            this.txtNRC.Location = new System.Drawing.Point(98, 172);
            this.txtNRC.MaxLength = 20;
            this.txtNRC.Name = "txtNRC";
            this.txtNRC.Size = new System.Drawing.Size(176, 20);
            this.txtNRC.TabIndex = 7;
            this.txtNRC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNRC_KeyPress);
            // 
            // txtName
            // 
            this.txtName.IsSendTabOnEnter = true;
            this.txtName.Location = new System.Drawing.Point(99, 79);
            this.txtName.MaxLength = 30;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(175, 20);
            this.txtName.TabIndex = 0;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // txtFatherName
            // 
            this.txtFatherName.IsSendTabOnEnter = true;
            this.txtFatherName.Location = new System.Drawing.Point(659, 54);
            this.txtFatherName.MaxLength = 20;
            this.txtFatherName.Name = "txtFatherName";
            this.txtFatherName.Size = new System.Drawing.Size(175, 20);
            this.txtFatherName.TabIndex = 8;
            this.txtFatherName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFatherName_KeyPress);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(15, 83);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name :";
            // 
            // lblFather
            // 
            this.lblFather.AutoSize = true;
            this.lblFather.Location = new System.Drawing.Point(506, 57);
            this.lblFather.Name = "lblFather";
            this.lblFather.Size = new System.Drawing.Size(81, 13);
            this.lblFather.TabIndex = 0;
            this.lblFather.Text = "Father\'s Name :";
            // 
            // lblGroupNo
            // 
            this.lblGroupNo.AutoSize = true;
            this.lblGroupNo.Location = new System.Drawing.Point(15, 57);
            this.lblGroupNo.Name = "lblGroupNo";
            this.lblGroupNo.Size = new System.Drawing.Size(59, 13);
            this.lblGroupNo.TabIndex = 0;
            this.lblGroupNo.Text = "Group No :";
            // 
            // lblCustOtherNRC
            // 
            this.lblCustOtherNRC.AutoSize = true;
            this.lblCustOtherNRC.Location = new System.Drawing.Point(15, 175);
            this.lblCustOtherNRC.Name = "lblCustOtherNRC";
            this.lblCustOtherNRC.Size = new System.Drawing.Size(39, 13);
            this.lblCustOtherNRC.TabIndex = 0;
            this.lblCustOtherNRC.Text = "Other :";
            // 
            // gbNRC
            // 
            this.gbNRC.Location = new System.Drawing.Point(96, 102);
            this.gbNRC.Name = "gbNRC";
            this.gbNRC.Size = new System.Drawing.Size(189, 38);
            this.gbNRC.TabIndex = 5;
            this.gbNRC.TabStop = false;
            this.gbNRC.Text = "NRC : ";
            // 
            // tlspCommon
            // 
            this.tlspCommon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tlspCommon.BackColor = System.Drawing.Color.PowderBlue;
            this.tlspCommon.Location = new System.Drawing.Point(0, 0);
            this.tlspCommon.Name = "tlspCommon";
            this.tlspCommon.PrintButtonCauseValidation = true;
            this.tlspCommon.Size = new System.Drawing.Size(1005, 34);
            this.tlspCommon.TabIndex = 2;
            this.tlspCommon.EditButtonClick += new System.EventHandler(this.tlspCommon_EditButtonClick);
            this.tlspCommon.SaveButtonClick += new System.EventHandler(this.tlspCommon_SaveButtonClick);
            this.tlspCommon.DeleteButtonClick += new System.EventHandler(this.tlspCommon_DeleteButtonClick);
            this.tlspCommon.CancelButtonClick += new System.EventHandler(this.tlspCommon_CancelButtonClick);
            this.tlspCommon.ExitButtonClick += new System.EventHandler(this.tlspCommon_ExitButtonClick);
            // 
            // gvSolidarityLending
            // 
            this.gvSolidarityLending.AllowUserToAddRows = false;
            this.gvSolidarityLending.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvSolidarityLending.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvSolidarityLending.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSolidarityLending.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo,
            this.colTS,
            this.colType,
            this.colName,
            this.colIsNRC,
            this.colNRCNo,
            this.colFatherName,
            this.colVillageCode,
            this.colVillageName,
            this.colAddress,
            this.colEdit,
            this.colDelete});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvSolidarityLending.DefaultCellStyle = dataGridViewCellStyle10;
            this.gvSolidarityLending.EnableHeadersVisualStyles = false;
            this.gvSolidarityLending.IdTSList = null;
            this.gvSolidarityLending.IsEscapeKey = false;
            this.gvSolidarityLending.IsHeaderClick = false;
            this.gvSolidarityLending.Location = new System.Drawing.Point(12, 260);
            this.gvSolidarityLending.Name = "gvSolidarityLending";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvSolidarityLending.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.gvSolidarityLending.RowHeadersWidth = 25;
            this.gvSolidarityLending.ShowSerialNo = false;
            this.gvSolidarityLending.Size = new System.Drawing.Size(945, 257);
            this.gvSolidarityLending.TabIndex = 0;
            this.gvSolidarityLending.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvSolidarityLending_CellContentClick);
            // 
            // colNo
            // 
            this.colNo.DataPropertyName = "Id";
            this.colNo.HeaderText = "No.";
            this.colNo.Name = "colNo";
            this.colNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colNo.Visible = false;
            this.colNo.Width = 30;
            // 
            // colTS
            // 
            this.colTS.DataPropertyName = "TS";
            this.colTS.HeaderText = "TS";
            this.colTS.Name = "colTS";
            this.colTS.Visible = false;
            this.colTS.Width = 30;
            // 
            // colType
            // 
            this.colType.DataPropertyName = "MemberType";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colType.DefaultCellStyle = dataGridViewCellStyle2;
            this.colType.HeaderText = "Member Type";
            this.colType.Name = "colType";
            // 
            // colName
            // 
            this.colName.DataPropertyName = "NameOnly";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = null;
            this.colName.DefaultCellStyle = dataGridViewCellStyle3;
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 150;
            // 
            // colIsNRC
            // 
            this.colIsNRC.DataPropertyName = "IsNRC";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colIsNRC.DefaultCellStyle = dataGridViewCellStyle4;
            this.colIsNRC.HeaderText = "Is NRC";
            this.colIsNRC.Name = "colIsNRC";
            this.colIsNRC.ReadOnly = true;
            // 
            // colNRCNo
            // 
            this.colNRCNo.DataPropertyName = "NRCNo";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colNRCNo.DefaultCellStyle = dataGridViewCellStyle5;
            this.colNRCNo.HeaderText = "NRC No";
            this.colNRCNo.Name = "colNRCNo";
            this.colNRCNo.ReadOnly = true;
            this.colNRCNo.Width = 150;
            // 
            // colFatherName
            // 
            this.colFatherName.DataPropertyName = "FatherName";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colFatherName.DefaultCellStyle = dataGridViewCellStyle6;
            this.colFatherName.HeaderText = "Father\'s Name";
            this.colFatherName.Name = "colFatherName";
            this.colFatherName.ReadOnly = true;
            this.colFatherName.Width = 150;
            // 
            // colVillageCode
            // 
            this.colVillageCode.DataPropertyName = "VillageCode";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colVillageCode.DefaultCellStyle = dataGridViewCellStyle7;
            this.colVillageCode.HeaderText = "Village ";
            this.colVillageCode.Name = "colVillageCode";
            this.colVillageCode.ReadOnly = true;
            this.colVillageCode.Visible = false;
            this.colVillageCode.Width = 30;
            // 
            // colVillageName
            // 
            this.colVillageName.DataPropertyName = "Desp";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colVillageName.DefaultCellStyle = dataGridViewCellStyle8;
            this.colVillageName.HeaderText = "Village";
            this.colVillageName.Name = "colVillageName";
            // 
            // colAddress
            // 
            this.colAddress.DataPropertyName = "Address";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colAddress.DefaultCellStyle = dataGridViewCellStyle9;
            this.colAddress.HeaderText = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.ReadOnly = true;
            this.colAddress.Width = 200;
            // 
            // colEdit
            // 
            this.colEdit.HeaderText = "";
            this.colEdit.Name = "colEdit";
            this.colEdit.Width = 30;
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
            // frmPFMVEW00078
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 533);
            this.Controls.Add(this.gvSolidarityLending);
            this.Controls.Add(this.gvSolidarityLendingEntry);
            this.Controls.Add(this.tlspCommon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPFMVEW00078";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solidarity Lending Entry";
            this.Load += new System.EventHandler(this.PFMVEW00078_Load);
            this.gvSolidarityLendingEntry.ResumeLayout(false);
            this.gvSolidarityLendingEntry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSolidarityLending)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXC0001 txtNRCNo;
        private Windows.CXClient.Controls.CXC0002 cboNationalityCode;
        private System.Windows.Forms.GroupBox gvSolidarityLendingEntry;
        private Windows.CXClient.Controls.CXC0002 cboTownshipCode;
        private Windows.CXClient.Controls.CXC0002 cboStateCode;
        private Windows.CXClient.Controls.CXC0003 lblCustNRC;
        private Windows.CXClient.Controls.CXC0009 rdoOther;
        private Windows.CXClient.Controls.CXC0009 rdoNRC;
        private Windows.CXClient.Controls.CXC0006 txtGroupNo;
        private Windows.CXClient.Controls.CXC0001 txtNRC;
        private Windows.CXClient.Controls.CXC0001 txtName;
        private Windows.CXClient.Controls.CXC0001 txtFatherName;
        private Windows.CXClient.Controls.CXC0003 lblName;
        private Windows.CXClient.Controls.CXC0003 lblFather;
        private Windows.CXClient.Controls.CXC0003 lblGroupNo;
        private Windows.CXClient.Controls.CXC0003 lblCustOtherNRC;
        private System.Windows.Forms.GroupBox gbNRC;
        private Windows.CXClient.Controls.CXCLIC001 tlspCommon;
        private Windows.CXClient.Controls.CXC0002 cboVillage;
        private Windows.CXClient.Controls.CXC0003 lblVillage;
        private Windows.CXClient.Controls.CXC0001 txtAddress;
        private Windows.CXClient.Controls.CXC0003 lblAddress;
        private Windows.CXClient.Controls.AceGridView gvSolidarityLending;
        private Windows.CXClient.Controls.CXC0007 butAddMember;
        private System.Windows.Forms.CheckBox chkLeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsNRC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNRCNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFatherName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVillageCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVillageName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
        private System.Windows.Forms.DataGridViewImageColumn colDelete;
    }
}