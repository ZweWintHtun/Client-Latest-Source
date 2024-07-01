namespace Ace.Cbs.Tel.Vew
{
    partial class frmTLMVEW00017
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTLMVEW00017));
            this.gvDrawingRemittance = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colIsSelected = new Ace.Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn();
            this.colRegisterNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBranchNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFromNRC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIBLCharges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToNRC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.lblConnectTimeOut = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblProcessInterval = new Ace.Windows.CXClient.Controls.CXC0003();
            this.butPause = new Ace.Windows.CXClient.Controls.CXC0007();
            this.butClearLog = new Ace.Windows.CXClient.Controls.CXC0007();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gbPaymentDetail = new System.Windows.Forms.GroupBox();
            this.pnlLog = new System.Windows.Forms.Panel();
            this.butOK = new Ace.Windows.CXClient.Controls.CXC0007();
            this.chkShowOnly = new Ace.Windows.CXClient.Controls.CXC0008();
            this.gbLog = new System.Windows.Forms.GroupBox();
            this.lbLog = new Ace.Windows.CXClient.Controls.CXC0011();
            this.txtProcessInterval = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtConnectTimeOutSeconds = new Ace.Windows.CXClient.Controls.CXC0004();
            this.butLog = new Ace.Windows.CXClient.Controls.CXC0007();
            this.butProcess = new Ace.Windows.CXClient.Controls.CXC0007();
            this.butRefresh = new Ace.Windows.CXClient.Controls.CXC0007();
            this.lblsourcebr = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblSourceBranch = new Ace.Windows.CXClient.Controls.CXC0003();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.timerConnectTimeOut = new System.Windows.Forms.Timer(this.components);
            this.timerProcessInterval = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gvDrawingRemittance)).BeginInit();
            this.gbPaymentDetail.SuspendLayout();
            this.pnlLog.SuspendLayout();
            this.gbLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvDrawingRemittance
            // 
            this.gvDrawingRemittance.AllowDrop = true;
            this.gvDrawingRemittance.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvDrawingRemittance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvDrawingRemittance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDrawingRemittance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIsSelected,
            this.colRegisterNo,
            this.colBranchNo,
            this.colAccountNo,
            this.colAmount,
            this.colName,
            this.colFromNRC,
            this.colComission,
            this.colIBLCharges,
            this.colToAccountNo,
            this.colToName,
            this.colToNRC,
            this.colToAddress});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvDrawingRemittance.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvDrawingRemittance.EnableHeadersVisualStyles = false;
            this.gvDrawingRemittance.IdTSList = null;
            this.gvDrawingRemittance.IsEscapeKey = false;
            this.gvDrawingRemittance.IsHeaderClick = false;
            this.gvDrawingRemittance.Location = new System.Drawing.Point(15, 21);
            this.gvDrawingRemittance.Name = "gvDrawingRemittance";
            this.gvDrawingRemittance.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvDrawingRemittance.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gvDrawingRemittance.RowHeadersWidth = 25;
            this.gvDrawingRemittance.ShowSerialNo = false;
            this.gvDrawingRemittance.Size = new System.Drawing.Size(771, 302);
            this.gvDrawingRemittance.TabIndex = 56;
            this.gvDrawingRemittance.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvDrawingRemittance_CellContentClick);
            this.gvDrawingRemittance.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvDrawingRemittance_CellContentDoubleClick);
            // 
            // colIsSelected
            // 
            this.colIsSelected.CheckBoxHeader = false;
            this.colIsSelected.DataPropertyName = "IsChecked";
            this.colIsSelected.FalseValue = "false";
            this.colIsSelected.HeaderText = "";
            this.colIsSelected.Id = 0;
            this.colIsSelected.Name = "colIsSelected";
            this.colIsSelected.ReadOnly = true;
            this.colIsSelected.TrueValue = "true";
            this.colIsSelected.TS = null;
            this.colIsSelected.Width = 30;
            // 
            // colRegisterNo
            // 
            this.colRegisterNo.DataPropertyName = "RegisterNo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colRegisterNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.colRegisterNo.HeaderText = "Register No";
            this.colRegisterNo.Name = "colRegisterNo";
            this.colRegisterNo.ReadOnly = true;
            // 
            // colBranchNo
            // 
            this.colBranchNo.DataPropertyName = "Dbank";
            this.colBranchNo.HeaderText = "Branch No";
            this.colBranchNo.Name = "colBranchNo";
            this.colBranchNo.ReadOnly = true;
            // 
            // colAccountNo
            // 
            this.colAccountNo.DataPropertyName = "AccountNo";
            this.colAccountNo.HeaderText = "AccountNo";
            this.colAccountNo.Name = "colAccountNo";
            this.colAccountNo.ReadOnly = true;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "Amount";
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "From Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colFromNRC
            // 
            this.colFromNRC.DataPropertyName = "NRC";
            this.colFromNRC.HeaderText = "From NRC No";
            this.colFromNRC.Name = "colFromNRC";
            this.colFromNRC.ReadOnly = true;
            // 
            // colComission
            // 
            this.colComission.DataPropertyName = "Commission";
            this.colComission.HeaderText = "Comission";
            this.colComission.Name = "colComission";
            this.colComission.ReadOnly = true;
            // 
            // colIBLCharges
            // 
            this.colIBLCharges.DataPropertyName = "TlxCharges";
            this.colIBLCharges.HeaderText = "IBL Charges";
            this.colIBLCharges.Name = "colIBLCharges";
            this.colIBLCharges.ReadOnly = true;
            // 
            // colToAccountNo
            // 
            this.colToAccountNo.DataPropertyName = "ToAccountNo";
            this.colToAccountNo.HeaderText = "To Account No";
            this.colToAccountNo.Name = "colToAccountNo";
            this.colToAccountNo.ReadOnly = true;
            this.colToAccountNo.Visible = false;
            this.colToAccountNo.Width = 150;
            // 
            // colToName
            // 
            this.colToName.DataPropertyName = "ToName";
            this.colToName.HeaderText = "To Name";
            this.colToName.Name = "colToName";
            this.colToName.ReadOnly = true;
            // 
            // colToNRC
            // 
            this.colToNRC.DataPropertyName = "ToNRC";
            this.colToNRC.HeaderText = "To NRC";
            this.colToNRC.Name = "colToNRC";
            this.colToNRC.ReadOnly = true;
            // 
            // colToAddress
            // 
            this.colToAddress.DataPropertyName = "ToAddress";
            this.colToAddress.HeaderText = "To Address";
            this.colToAddress.Name = "colToAddress";
            this.colToAddress.ReadOnly = true;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(78, 27);
            this.toolStripLabel1.Text = "                       ";
            // 
            // lblConnectTimeOut
            // 
            this.lblConnectTimeOut.BackColor = System.Drawing.SystemColors.Control;
            this.lblConnectTimeOut.Location = new System.Drawing.Point(12, 333);
            this.lblConnectTimeOut.Name = "lblConnectTimeOut";
            this.lblConnectTimeOut.Size = new System.Drawing.Size(200, 17);
            this.lblConnectTimeOut.TabIndex = 0;
            this.lblConnectTimeOut.Text = "Connection Time Out (By Seconds) :";
            // 
            // lblProcessInterval
            // 
            this.lblProcessInterval.BackColor = System.Drawing.SystemColors.Control;
            this.lblProcessInterval.Location = new System.Drawing.Point(247, 333);
            this.lblProcessInterval.Name = "lblProcessInterval";
            this.lblProcessInterval.Size = new System.Drawing.Size(103, 17);
            this.lblProcessInterval.TabIndex = 0;
            this.lblProcessInterval.Text = "Process Interval :";
            // 
            // butPause
            // 
            this.butPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butPause.Location = new System.Drawing.Point(524, 330);
            this.butPause.Name = "butPause";
            this.butPause.Size = new System.Drawing.Size(75, 32);
            this.butPause.TabIndex = 4;
            this.butPause.Text = "Pa&use";
            this.butPause.UseVisualStyleBackColor = true;
            this.butPause.Click += new System.EventHandler(this.butPause_Click);
            // 
            // butClearLog
            // 
            this.butClearLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butClearLog.Location = new System.Drawing.Point(704, 330);
            this.butClearLog.Name = "butClearLog";
            this.butClearLog.Size = new System.Drawing.Size(82, 32);
            this.butClearLog.TabIndex = 6;
            this.butClearLog.Text = "&ClearLog";
            this.butClearLog.UseVisualStyleBackColor = true;
            this.butClearLog.Click += new System.EventHandler(this.butClearLog_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn1.HeaderText = "Register No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Branch No";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "To Account No";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "To Name";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "To NRC";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "To Address";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "From Name";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "From NRC No";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "AccountNo";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "Comission";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "IBL Charges";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(641, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 35;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(821, 31);
            this.tsbCRUD.TabIndex = 57;
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // gbPaymentDetail
            // 
            this.gbPaymentDetail.Controls.Add(this.pnlLog);
            this.gbPaymentDetail.Controls.Add(this.txtProcessInterval);
            this.gbPaymentDetail.Controls.Add(this.txtConnectTimeOutSeconds);
            this.gbPaymentDetail.Controls.Add(this.gvDrawingRemittance);
            this.gbPaymentDetail.Controls.Add(this.butLog);
            this.gbPaymentDetail.Controls.Add(this.butClearLog);
            this.gbPaymentDetail.Controls.Add(this.butProcess);
            this.gbPaymentDetail.Controls.Add(this.lblConnectTimeOut);
            this.gbPaymentDetail.Controls.Add(this.butRefresh);
            this.gbPaymentDetail.Controls.Add(this.lblProcessInterval);
            this.gbPaymentDetail.Controls.Add(this.butPause);
            this.gbPaymentDetail.Location = new System.Drawing.Point(7, 71);
            this.gbPaymentDetail.Name = "gbPaymentDetail";
            this.gbPaymentDetail.Size = new System.Drawing.Size(805, 401);
            this.gbPaymentDetail.TabIndex = 0;
            this.gbPaymentDetail.TabStop = false;
            // 
            // pnlLog
            // 
            this.pnlLog.Controls.Add(this.butOK);
            this.pnlLog.Controls.Add(this.chkShowOnly);
            this.pnlLog.Controls.Add(this.gbLog);
            this.pnlLog.Location = new System.Drawing.Point(249, 104);
            this.pnlLog.Name = "pnlLog";
            this.pnlLog.Size = new System.Drawing.Size(306, 167);
            this.pnlLog.TabIndex = 58;
            // 
            // butOK
            // 
            this.butOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butOK.Location = new System.Drawing.Point(208, 128);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(75, 28);
            this.butOK.TabIndex = 59;
            this.butOK.Text = "OK";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // chkShowOnly
            // 
            this.chkShowOnly.AutoSize = true;
            this.chkShowOnly.IsSendTabOnEnter = true;
            this.chkShowOnly.Location = new System.Drawing.Point(18, 128);
            this.chkShowOnly.Name = "chkShowOnly";
            this.chkShowOnly.Size = new System.Drawing.Size(172, 17);
            this.chkShowOnly.TabIndex = 9;
            this.chkShowOnly.Text = "Show Only Failed Transactions";
            this.chkShowOnly.UseVisualStyleBackColor = true;
            this.chkShowOnly.CheckedChanged += new System.EventHandler(this.chkShowOnly_CheckedChanged);
            // 
            // gbLog
            // 
            this.gbLog.Controls.Add(this.lbLog);
            this.gbLog.Location = new System.Drawing.Point(18, 13);
            this.gbLog.Name = "gbLog";
            this.gbLog.Size = new System.Drawing.Size(242, 103);
            this.gbLog.TabIndex = 0;
            this.gbLog.TabStop = false;
            this.gbLog.Text = "Transaction Log";
            // 
            // lbLog
            // 
            this.lbLog.FormattingEnabled = true;
            this.lbLog.Location = new System.Drawing.Point(16, 19);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(208, 69);
            this.lbLog.TabIndex = 8;
            // 
            // txtProcessInterval
            // 
            this.txtProcessInterval.DecimalPlaces = 0;
            this.txtProcessInterval.IsSendTabOnEnter = true;
            this.txtProcessInterval.Location = new System.Drawing.Point(340, 329);
            this.txtProcessInterval.Name = "txtProcessInterval";
            this.txtProcessInterval.Size = new System.Drawing.Size(34, 20);
            this.txtProcessInterval.TabIndex = 2;
            this.txtProcessInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtProcessInterval.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtProcessInterval.TextChanged += new System.EventHandler(this.txtProcessInterval_TextChanged);
            this.txtProcessInterval.Validated += new System.EventHandler(this.txtProcessInterval_Validated);
            // 
            // txtConnectTimeOutSeconds
            // 
            this.txtConnectTimeOutSeconds.DecimalPlaces = 0;
            this.txtConnectTimeOutSeconds.IsSendTabOnEnter = true;
            this.txtConnectTimeOutSeconds.Location = new System.Drawing.Point(194, 330);
            this.txtConnectTimeOutSeconds.Name = "txtConnectTimeOutSeconds";
            this.txtConnectTimeOutSeconds.Size = new System.Drawing.Size(34, 20);
            this.txtConnectTimeOutSeconds.TabIndex = 1;
            this.txtConnectTimeOutSeconds.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtConnectTimeOutSeconds.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtConnectTimeOutSeconds.TextChanged += new System.EventHandler(this.txtConnectTimeOutSeconds_TextChanged);
            this.txtConnectTimeOutSeconds.Validated += new System.EventHandler(this.txtConnectTimeOutSeconds_Validated);
            // 
            // butLog
            // 
            this.butLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLog.Image = global::Ace.Cbs.Tel.Vew.Properties.Resources.Log_Out_16x16;
            this.butLog.Location = new System.Drawing.Point(614, 366);
            this.butLog.Name = "butLog";
            this.butLog.Size = new System.Drawing.Size(75, 30);
            this.butLog.TabIndex = 8;
            this.butLog.Text = "&Log";
            this.butLog.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.butLog.UseVisualStyleBackColor = true;
            this.butLog.Click += new System.EventHandler(this.butLog_Click);
            // 
            // butProcess
            // 
            this.butProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butProcess.Location = new System.Drawing.Point(524, 365);
            this.butProcess.Name = "butProcess";
            this.butProcess.Size = new System.Drawing.Size(75, 30);
            this.butProcess.TabIndex = 7;
            this.butProcess.Text = "&Process";
            this.butProcess.UseVisualStyleBackColor = true;
            this.butProcess.Click += new System.EventHandler(this.butProcess_Click);
            // 
            // butRefresh
            // 
            this.butRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butRefresh.Image = global::Ace.Cbs.Tel.Vew.Properties.Resources.refresh;
            this.butRefresh.Location = new System.Drawing.Point(614, 330);
            this.butRefresh.Name = "butRefresh";
            this.butRefresh.Size = new System.Drawing.Size(84, 32);
            this.butRefresh.TabIndex = 5;
            this.butRefresh.Text = "Re&fresh";
            this.butRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.butRefresh.UseVisualStyleBackColor = true;
            this.butRefresh.Click += new System.EventHandler(this.butRefresh_Click);
            // 
            // lblsourcebr
            // 
            this.lblsourcebr.AutoSize = true;
            this.lblsourcebr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsourcebr.Location = new System.Drawing.Point(634, 51);
            this.lblsourcebr.Name = "lblsourcebr";
            this.lblsourcebr.Size = new System.Drawing.Size(69, 13);
            this.lblsourcebr.TabIndex = 60;
            this.lblsourcebr.Text = "lblsourcebr";
            // 
            // lblSourceBranch
            // 
            this.lblSourceBranch.AutoSize = true;
            this.lblSourceBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSourceBranch.Location = new System.Drawing.Point(534, 51);
            this.lblSourceBranch.Name = "lblSourceBranch";
            this.lblSourceBranch.Size = new System.Drawing.Size(99, 13);
            this.lblSourceBranch.TabIndex = 59;
            this.lblSourceBranch.Text = "Source Branch :";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Enabled = false;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(61, 27);
            this.toolStripButton1.Text = "&First";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Enabled = false;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(80, 27);
            this.toolStripButton2.Text = "&Previous";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Enabled = false;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(61, 27);
            this.toolStripButton3.Text = "Ne&xt";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Enabled = false;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(59, 27);
            this.toolStripButton4.Text = "&Last";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.Enabled = false;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(58, 27);
            this.toolStripButton6.Text = "&New";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Enabled = false;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(56, 27);
            this.toolStripButton5.Text = "&Edit";
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.Enabled = false;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(60, 27);
            this.toolStripButton8.Text = "&Save";
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.Enabled = false;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(69, 27);
            this.toolStripButton7.Text = "&Delete";
            // 
            // toolStripButton10
            // 
            this.toolStripButton10.Enabled = false;
            this.toolStripButton10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton10.Image")));
            this.toolStripButton10.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.Size = new System.Drawing.Size(72, 27);
            this.toolStripButton10.Text = "&Cancel";
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
            this.toolStripButton9.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(53, 27);
            this.toolStripButton9.Text = "E&xit";
            this.toolStripButton9.Click += new System.EventHandler(this.toolStripButton9_Click);
            // 
            // timerConnectTimeOut
            // 
            this.timerConnectTimeOut.Tick += new System.EventHandler(this.timerConnectTimeOut_Tick);
            // 
            // timerProcessInterval
            // 
            this.timerProcessInterval.Tick += new System.EventHandler(this.timerProcessInterval_Tick);
            // 
            // frmTLMVEW00017
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 490);
            this.Controls.Add(this.lblsourcebr);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.lblSourceBranch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbPaymentDetail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTLMVEW00017";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.TLMVEW00017_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvDrawingRemittance)).EndInit();
            this.gbPaymentDetail.ResumeLayout(false);
            this.gbPaymentDetail.PerformLayout();
            this.pnlLog.ResumeLayout(false);
            this.pnlLog.PerformLayout();
            this.gbLog.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // private Ace.Windows.CXClient.Controls.CXC0003 label1;
        //  private Ace.Windows.CXClient.Controls.CXC0003 label2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton10;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        // private Ace.Windows.CXClient.Controls.CXC0004 txtConnectTimeOutSeconds;
        // private Ace.Windows.CXClient.Controls.CXC0004 txtProcessInterval;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private Ace.Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox gbPaymentDetail;
        private Windows.CXClient.Controls.AceGridView gvDrawingRemittance;
        private Ace.Windows.CXClient.Controls.CXC0003 lblConnectTimeOut;
        private Ace.Windows.CXClient.Controls.CXC0003 lblProcessInterval;
        private Ace.Windows.CXClient.Controls.CXC0003 label1;
        private Ace.Windows.CXClient.Controls.CXC0007 butPause;
        private Ace.Windows.CXClient.Controls.CXC0007 butRefresh;
        private Ace.Windows.CXClient.Controls.CXC0007 butLog;
        private Ace.Windows.CXClient.Controls.CXC0007 butProcess;
        private Ace.Windows.CXClient.Controls.CXC0007 butClearLog;
        private Windows.CXClient.Controls.CXC0004 txtProcessInterval;
        private Windows.CXClient.Controls.CXC0004 txtConnectTimeOutSeconds;
        private System.Windows.Forms.Timer timerConnectTimeOut;
        private System.Windows.Forms.Timer timerProcessInterval;
        private System.Windows.Forms.Panel pnlLog;
        private Windows.CXClient.Controls.CXC0007 butOK;
        private Windows.CXClient.Controls.CXC0008 chkShowOnly;
        private System.Windows.Forms.GroupBox gbLog;
        private Windows.CXClient.Controls.CXC0011 lbLog;
        private Windows.CXClient.Controls.CXC0003 lblsourcebr;
        private Windows.CXClient.Controls.CXC0003 lblSourceBranch;
        private Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn colIsSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegisterNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBranchNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFromNRC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComission;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIBLCharges;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToNRC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToAddress;
        //private System.Windows.Forms.TextBox txtConnectTimeOutSeconds;
        //private System.Windows.Forms.TextBox txtProcessInterval;
    }
}