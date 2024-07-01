namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00075
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00075));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblProductType = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblSeasonType = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblUM = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblStartDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblEndDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblDeadLineDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gvAGLoansList = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colIsSelected = new Ace.Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn();
            this.colTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductDesp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeasonDesp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeasonCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUMDesp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUMCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeadLineDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeadLineMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtRecordCount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblRecordCount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00033 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboProductType = new System.Windows.Forms.ComboBox();
            this.cboSeasonType = new System.Windows.Forms.ComboBox();
            this.cboUM = new System.Windows.Forms.ComboBox();
            this.cboSMonth = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cboEMonth = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cboDMonth = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cboSDay = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cboEDay = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cboDDay = new Ace.Windows.CXClient.Controls.CXC0002();
            ((System.ComponentModel.ISupportInitialize)(this.gvAGLoansList)).BeginInit();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(958, 31);
            this.tsbCRUD.TabIndex = 106;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.DeleteButtonClick += new System.EventHandler(this.tsbCRUD_DeleteButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblProductType
            // 
            this.lblProductType.AutoSize = true;
            this.lblProductType.Location = new System.Drawing.Point(24, 47);
            this.lblProductType.Name = "lblProductType";
            this.lblProductType.Size = new System.Drawing.Size(77, 13);
            this.lblProductType.TabIndex = 108;
            this.lblProductType.Text = "Product Type :";
            // 
            // lblSeasonType
            // 
            this.lblSeasonType.AutoSize = true;
            this.lblSeasonType.Location = new System.Drawing.Point(24, 74);
            this.lblSeasonType.Name = "lblSeasonType";
            this.lblSeasonType.Size = new System.Drawing.Size(76, 13);
            this.lblSeasonType.TabIndex = 110;
            this.lblSeasonType.Text = "Season Type :";
            // 
            // lblUM
            // 
            this.lblUM.AutoSize = true;
            this.lblUM.Location = new System.Drawing.Point(24, 102);
            this.lblUM.Name = "lblUM";
            this.lblUM.Size = new System.Drawing.Size(30, 13);
            this.lblUM.TabIndex = 114;
            this.lblUM.Text = "UM :";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(24, 132);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(68, 13);
            this.lblStartDate.TabIndex = 115;
            this.lblStartDate.Text = "Start Month :";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(24, 159);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(68, 13);
            this.lblEndDate.TabIndex = 118;
            this.lblEndDate.Text = "End Month  :";
            // 
            // lblDeadLineDate
            // 
            this.lblDeadLineDate.AutoSize = true;
            this.lblDeadLineDate.Location = new System.Drawing.Point(24, 186);
            this.lblDeadLineDate.Name = "lblDeadLineDate";
            this.lblDeadLineDate.Size = new System.Drawing.Size(95, 13);
            this.lblDeadLineDate.TabIndex = 121;
            this.lblDeadLineDate.Text = "Dead Line Month :";
            // 
            // gvAGLoansList
            // 
            this.gvAGLoansList.AllowUserToAddRows = false;
            this.gvAGLoansList.CausesValidation = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvAGLoansList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvAGLoansList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAGLoansList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIsSelected,
            this.colTS,
            this.colProductDesp,
            this.colProductCode,
            this.colSeasonDesp,
            this.colSeasonCode,
            this.colUMDesp,
            this.colUMCode,
            this.colSDay,
            this.colSMonth,
            this.colEDay,
            this.colEMonth,
            this.colDeadLineDay,
            this.colDeadLineMonth,
            this.colEdit});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvAGLoansList.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvAGLoansList.EnableHeadersVisualStyles = false;
            this.gvAGLoansList.IdTSList = null;
            this.gvAGLoansList.IsEscapeKey = false;
            this.gvAGLoansList.IsHeaderClick = false;
            this.gvAGLoansList.Location = new System.Drawing.Point(12, 236);
            this.gvAGLoansList.Name = "gvAGLoansList";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvAGLoansList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gvAGLoansList.RowHeadersWidth = 25;
            this.gvAGLoansList.ShowSerialNo = false;
            this.gvAGLoansList.Size = new System.Drawing.Size(934, 296);
            this.gvAGLoansList.TabIndex = 124;
            this.gvAGLoansList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvAGLoansList_CellContentClick);
            this.gvAGLoansList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvAGLoansList_CellFormatting);
            // 
            // colIsSelected
            // 
            this.colIsSelected.CheckBoxHeader = false;
            this.colIsSelected.DataPropertyName = "IsCheck";
            this.colIsSelected.FalseValue = "false";
            this.colIsSelected.HeaderText = "";
            this.colIsSelected.Id = 0;
            this.colIsSelected.Name = "colIsSelected";
            this.colIsSelected.TrueValue = "true";
            this.colIsSelected.TS = null;
            this.colIsSelected.Width = 30;
            // 
            // colTS
            // 
            this.colTS.DataPropertyName = "TS";
            this.colTS.HeaderText = "TS";
            this.colTS.Name = "colTS";
            this.colTS.Visible = false;
            this.colTS.Width = 30;
            // 
            // colProductDesp
            // 
            this.colProductDesp.DataPropertyName = "ProductDesp";
            dataGridViewCellStyle2.NullValue = null;
            this.colProductDesp.DefaultCellStyle = dataGridViewCellStyle2;
            this.colProductDesp.HeaderText = "Product Type";
            this.colProductDesp.Name = "colProductDesp";
            this.colProductDesp.ReadOnly = true;
            this.colProductDesp.Width = 130;
            // 
            // colProductCode
            // 
            this.colProductCode.DataPropertyName = "ProductCode";
            this.colProductCode.HeaderText = "Product Code";
            this.colProductCode.Name = "colProductCode";
            this.colProductCode.Visible = false;
            // 
            // colSeasonDesp
            // 
            this.colSeasonDesp.DataPropertyName = "SeasonDesp";
            this.colSeasonDesp.HeaderText = "Season Type";
            this.colSeasonDesp.Name = "colSeasonDesp";
            this.colSeasonDesp.ReadOnly = true;
            // 
            // colSeasonCode
            // 
            this.colSeasonCode.DataPropertyName = "SeasonCode";
            this.colSeasonCode.HeaderText = "Season Code";
            this.colSeasonCode.Name = "colSeasonCode";
            this.colSeasonCode.Visible = false;
            // 
            // colUMDesp
            // 
            this.colUMDesp.DataPropertyName = "UMDesp";
            this.colUMDesp.HeaderText = "UM";
            this.colUMDesp.Name = "colUMDesp";
            // 
            // colUMCode
            // 
            this.colUMCode.DataPropertyName = "UMCode";
            this.colUMCode.HeaderText = "UM Code";
            this.colUMCode.Name = "colUMCode";
            this.colUMCode.Visible = false;
            // 
            // colSDay
            // 
            this.colSDay.DataPropertyName = "SDay";
            this.colSDay.HeaderText = "Start Day";
            this.colSDay.Name = "colSDay";
            this.colSDay.Width = 50;
            // 
            // colSMonth
            // 
            this.colSMonth.DataPropertyName = "SMonth";
            this.colSMonth.HeaderText = "Start Month";
            this.colSMonth.Name = "colSMonth";
            // 
            // colEDay
            // 
            this.colEDay.DataPropertyName = "EDay";
            this.colEDay.HeaderText = "End Day";
            this.colEDay.Name = "colEDay";
            // 
            // colEMonth
            // 
            this.colEMonth.DataPropertyName = "EMonth";
            this.colEMonth.HeaderText = "End Month";
            this.colEMonth.Name = "colEMonth";
            this.colEMonth.Width = 70;
            // 
            // colDeadLineDay
            // 
            this.colDeadLineDay.DataPropertyName = "DeadLineDay";
            this.colDeadLineDay.HeaderText = "DeadLine Day";
            this.colDeadLineDay.Name = "colDeadLineDay";
            this.colDeadLineDay.Width = 90;
            // 
            // colDeadLineMonth
            // 
            this.colDeadLineMonth.DataPropertyName = "DeadLineMonth";
            this.colDeadLineMonth.HeaderText = "DeadLine Month";
            this.colDeadLineMonth.Name = "colDeadLineMonth";
            // 
            // colEdit
            // 
            this.colEdit.HeaderText = "";
            this.colEdit.Image = global::Ace.Cbs.Loan.Vew.Properties.Resources.Edit_Main;
            this.colEdit.Name = "colEdit";
            this.colEdit.Width = 30;
            // 
            // txtRecordCount
            // 
            this.txtRecordCount.DecimalPlaces = 0;
            this.txtRecordCount.IsSendTabOnEnter = true;
            this.txtRecordCount.Location = new System.Drawing.Point(104, 538);
            this.txtRecordCount.Name = "txtRecordCount";
            this.txtRecordCount.ReadOnly = true;
            this.txtRecordCount.Size = new System.Drawing.Size(60, 20);
            this.txtRecordCount.TabIndex = 126;
            this.txtRecordCount.Text = "0";
            this.txtRecordCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRecordCount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Location = new System.Drawing.Point(25, 541);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(76, 13);
            this.lblRecordCount.TabIndex = 125;
            this.lblRecordCount.Text = "Record Count:";
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(288, 184);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(84, 13);
            this.cxC00031.TabIndex = 129;
            this.cxC00031.Text = "Dead Line Day :";
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.Location = new System.Drawing.Point(288, 157);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(54, 13);
            this.cxC00032.TabIndex = 128;
            this.cxC00032.Text = "End Day :";
            // 
            // cxC00033
            // 
            this.cxC00033.AutoSize = true;
            this.cxC00033.Location = new System.Drawing.Point(288, 130);
            this.cxC00033.Name = "cxC00033";
            this.cxC00033.Size = new System.Drawing.Size(54, 13);
            this.cxC00033.TabIndex = 127;
            this.cxC00033.Text = "Start Day:";
            // 
            // cboProductType
            // 
            this.cboProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProductType.FormattingEnabled = true;
            this.cboProductType.Location = new System.Drawing.Point(143, 44);
            this.cboProductType.Name = "cboProductType";
            this.cboProductType.Size = new System.Drawing.Size(170, 21);
            this.cboProductType.TabIndex = 0;
            // 
            // cboSeasonType
            // 
            this.cboSeasonType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSeasonType.FormattingEnabled = true;
            this.cboSeasonType.Location = new System.Drawing.Point(143, 71);
            this.cboSeasonType.Name = "cboSeasonType";
            this.cboSeasonType.Size = new System.Drawing.Size(170, 21);
            this.cboSeasonType.TabIndex = 138;
            // 
            // cboUM
            // 
            this.cboUM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUM.FormattingEnabled = true;
            this.cboUM.Location = new System.Drawing.Point(143, 98);
            this.cboUM.Name = "cboUM";
            this.cboUM.Size = new System.Drawing.Size(121, 21);
            this.cboUM.TabIndex = 140;
            // 
            // cboSMonth
            // 
            this.cboSMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboSMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSMonth.DropDownHeight = 200;
            this.cboSMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSMonth.FormattingEnabled = true;
            this.cboSMonth.IntegralHeight = false;
            this.cboSMonth.IsSendTabOnEnter = true;
            this.cboSMonth.Location = new System.Drawing.Point(143, 126);
            this.cboSMonth.Name = "cboSMonth";
            this.cboSMonth.Size = new System.Drawing.Size(121, 21);
            this.cboSMonth.TabIndex = 147;
            this.cboSMonth.SelectedIndexChanged += new System.EventHandler(this.cboSMonth_SelectedIndexChanged);
            // 
            // cboEMonth
            // 
            this.cboEMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboEMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEMonth.DropDownHeight = 200;
            this.cboEMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEMonth.FormattingEnabled = true;
            this.cboEMonth.IntegralHeight = false;
            this.cboEMonth.IsSendTabOnEnter = true;
            this.cboEMonth.Location = new System.Drawing.Point(143, 154);
            this.cboEMonth.Name = "cboEMonth";
            this.cboEMonth.Size = new System.Drawing.Size(121, 21);
            this.cboEMonth.TabIndex = 148;
            this.cboEMonth.SelectedIndexChanged += new System.EventHandler(this.cboEMonth_SelectedIndexChanged);
            // 
            // cboDMonth
            // 
            this.cboDMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboDMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDMonth.DropDownHeight = 200;
            this.cboDMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDMonth.FormattingEnabled = true;
            this.cboDMonth.IntegralHeight = false;
            this.cboDMonth.IsSendTabOnEnter = true;
            this.cboDMonth.Location = new System.Drawing.Point(143, 183);
            this.cboDMonth.Name = "cboDMonth";
            this.cboDMonth.Size = new System.Drawing.Size(121, 21);
            this.cboDMonth.TabIndex = 149;
            this.cboDMonth.SelectedIndexChanged += new System.EventHandler(this.cboDMonth_SelectedIndexChanged);
            // 
            // cboSDay
            // 
            this.cboSDay.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboSDay.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSDay.DropDownHeight = 200;
            this.cboSDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSDay.FormattingEnabled = true;
            this.cboSDay.IntegralHeight = false;
            this.cboSDay.IsSendTabOnEnter = true;
            this.cboSDay.Location = new System.Drawing.Point(378, 127);
            this.cboSDay.Name = "cboSDay";
            this.cboSDay.Size = new System.Drawing.Size(121, 21);
            this.cboSDay.TabIndex = 150;
            // 
            // cboEDay
            // 
            this.cboEDay.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboEDay.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEDay.DropDownHeight = 200;
            this.cboEDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEDay.FormattingEnabled = true;
            this.cboEDay.IntegralHeight = false;
            this.cboEDay.IsSendTabOnEnter = true;
            this.cboEDay.Location = new System.Drawing.Point(378, 155);
            this.cboEDay.Name = "cboEDay";
            this.cboEDay.Size = new System.Drawing.Size(121, 21);
            this.cboEDay.TabIndex = 151;
            // 
            // cboDDay
            // 
            this.cboDDay.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboDDay.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDDay.DropDownHeight = 200;
            this.cboDDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDDay.FormattingEnabled = true;
            this.cboDDay.IntegralHeight = false;
            this.cboDDay.IsSendTabOnEnter = true;
            this.cboDDay.Location = new System.Drawing.Point(378, 182);
            this.cboDDay.Name = "cboDDay";
            this.cboDDay.Size = new System.Drawing.Size(121, 21);
            this.cboDDay.TabIndex = 152;
            // 
            // LOMVEW00075
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 563);
            this.Controls.Add(this.cboDDay);
            this.Controls.Add(this.cboEDay);
            this.Controls.Add(this.cboSDay);
            this.Controls.Add(this.cboDMonth);
            this.Controls.Add(this.cboEMonth);
            this.Controls.Add(this.cboSMonth);
            this.Controls.Add(this.cboUM);
            this.Controls.Add(this.cboSeasonType);
            this.Controls.Add(this.cboProductType);
            this.Controls.Add(this.cxC00031);
            this.Controls.Add(this.cxC00032);
            this.Controls.Add(this.cxC00033);
            this.Controls.Add(this.txtRecordCount);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.gvAGLoansList);
            this.Controls.Add(this.lblDeadLineDate);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.lblUM);
            this.Controls.Add(this.lblSeasonType);
            this.Controls.Add(this.lblProductType);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LOMVEW00075";
            this.Text = "Agricultural Loans Druation Setup";
            this.Load += new System.EventHandler(this.LOMVEW00075_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvAGLoansList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0003 lblProductType;
        private Windows.CXClient.Controls.CXC0003 lblSeasonType;
        private Windows.CXClient.Controls.CXC0003 lblUM;
        private Windows.CXClient.Controls.CXC0003 lblStartDate;
        private Windows.CXClient.Controls.CXC0003 lblEndDate;
        private Windows.CXClient.Controls.CXC0003 lblDeadLineDate;
        private Windows.CXClient.Controls.AceGridView gvAGLoansList;
        private Windows.CXClient.Controls.CXC0004 txtRecordCount;
        private Windows.CXClient.Controls.CXC0003 lblRecordCount;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private Windows.CXClient.Controls.CXC0003 cxC00033;
        private System.Windows.Forms.ComboBox cboProductType;
        private System.Windows.Forms.ComboBox cboSeasonType;
        private System.Windows.Forms.ComboBox cboUM;
        private Windows.CXClient.Controls.CXC0002 cboSMonth;
        private Windows.CXClient.Controls.CXC0002 cboEMonth;
        private Windows.CXClient.Controls.CXC0002 cboDMonth;
        private Windows.CXClient.Controls.CXC0002 cboSDay;
        private Windows.CXClient.Controls.CXC0002 cboEDay;
        private Windows.CXClient.Controls.CXC0002 cboDDay;
        private Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn colIsSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductDesp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeasonDesp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeasonCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUMDesp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUMCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeadLineDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeadLineMonth;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
    }
}