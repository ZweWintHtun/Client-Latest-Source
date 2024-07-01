namespace Ace.Cbs.Sam.Vew
{
    partial class SAMVEW00051
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAMVEW00051));
            this.lblFromCurrencyCode = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblToCurrencyCode = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblExchangeDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblRateType = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblExchangeRate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblDenoRate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboCur = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cboToCur = new Ace.Windows.CXClient.Controls.CXC0002();
            this.dtpRDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.cboRateType = new Ace.Windows.CXClient.Controls.CXC0002();
            this.gvCurrencyRate = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colIsSelected = new Ace.Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFromCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExchangeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRateType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExchangeRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDenoRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtRecordCount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblRecordCount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.txtRate = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtDenoRate = new Ace.Windows.CXClient.Controls.CXC0001();
            ((System.ComponentModel.ISupportInitialize)(this.gvCurrencyRate)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFromCurrencyCode
            // 
            this.lblFromCurrencyCode.AutoSize = true;
            this.lblFromCurrencyCode.Location = new System.Drawing.Point(13, 43);
            this.lblFromCurrencyCode.Name = "lblFromCurrencyCode";
            this.lblFromCurrencyCode.Size = new System.Drawing.Size(109, 13);
            this.lblFromCurrencyCode.TabIndex = 7;
            this.lblFromCurrencyCode.Text = "From Currency Code :";
            // 
            // lblToCurrencyCode
            // 
            this.lblToCurrencyCode.AutoSize = true;
            this.lblToCurrencyCode.Location = new System.Drawing.Point(13, 70);
            this.lblToCurrencyCode.Name = "lblToCurrencyCode";
            this.lblToCurrencyCode.Size = new System.Drawing.Size(99, 13);
            this.lblToCurrencyCode.TabIndex = 8;
            this.lblToCurrencyCode.Text = "To Currency Code :";
            // 
            // lblExchangeDate
            // 
            this.lblExchangeDate.AutoSize = true;
            this.lblExchangeDate.Location = new System.Drawing.Point(13, 98);
            this.lblExchangeDate.Name = "lblExchangeDate";
            this.lblExchangeDate.Size = new System.Drawing.Size(87, 13);
            this.lblExchangeDate.TabIndex = 9;
            this.lblExchangeDate.Text = "Exchange Date :";
            // 
            // lblRateType
            // 
            this.lblRateType.AutoSize = true;
            this.lblRateType.Location = new System.Drawing.Point(13, 124);
            this.lblRateType.Name = "lblRateType";
            this.lblRateType.Size = new System.Drawing.Size(63, 13);
            this.lblRateType.TabIndex = 10;
            this.lblRateType.Text = "Rate Type :";
            // 
            // lblExchangeRate
            // 
            this.lblExchangeRate.AutoSize = true;
            this.lblExchangeRate.Location = new System.Drawing.Point(13, 151);
            this.lblExchangeRate.Name = "lblExchangeRate";
            this.lblExchangeRate.Size = new System.Drawing.Size(87, 13);
            this.lblExchangeRate.TabIndex = 11;
            this.lblExchangeRate.Text = "Exchange Rate :";
            // 
            // lblDenoRate
            // 
            this.lblDenoRate.AutoSize = true;
            this.lblDenoRate.Location = new System.Drawing.Point(13, 177);
            this.lblDenoRate.Name = "lblDenoRate";
            this.lblDenoRate.Size = new System.Drawing.Size(65, 13);
            this.lblDenoRate.TabIndex = 12;
            this.lblDenoRate.Text = "Deno Rate :";
            // 
            // cboCur
            // 
            this.cboCur.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCur.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCur.DropDownHeight = 200;
            this.cboCur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCur.FormattingEnabled = true;
            this.cboCur.IntegralHeight = false;
            this.cboCur.IsSendTabOnEnter = true;
            this.cboCur.Location = new System.Drawing.Point(128, 40);
            this.cboCur.Name = "cboCur";
            this.cboCur.Size = new System.Drawing.Size(121, 21);
            this.cboCur.TabIndex = 1;
            // 
            // cboToCur
            // 
            this.cboToCur.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboToCur.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboToCur.DropDownHeight = 200;
            this.cboToCur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboToCur.FormattingEnabled = true;
            this.cboToCur.IntegralHeight = false;
            this.cboToCur.IsSendTabOnEnter = true;
            this.cboToCur.Location = new System.Drawing.Point(128, 67);
            this.cboToCur.Name = "cboToCur";
            this.cboToCur.Size = new System.Drawing.Size(121, 21);
            this.cboToCur.TabIndex = 2;
            // 
            // dtpRDate
            // 
            this.dtpRDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpRDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRDate.IsSendTabOnEnter = true;
            this.dtpRDate.Location = new System.Drawing.Point(128, 94);
            this.dtpRDate.Name = "dtpRDate";
            this.dtpRDate.Size = new System.Drawing.Size(121, 20);
            this.dtpRDate.TabIndex = 3;
            // 
            // cboRateType
            // 
            this.cboRateType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboRateType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRateType.DropDownHeight = 200;
            this.cboRateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRateType.FormattingEnabled = true;
            this.cboRateType.IntegralHeight = false;
            this.cboRateType.IsSendTabOnEnter = true;
            this.cboRateType.Location = new System.Drawing.Point(128, 121);
            this.cboRateType.Name = "cboRateType";
            this.cboRateType.Size = new System.Drawing.Size(121, 21);
            this.cboRateType.TabIndex = 4;
            // 
            // gvCurrencyRate
            // 
            this.gvCurrencyRate.AllowUserToAddRows = false;
            this.gvCurrencyRate.CausesValidation = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvCurrencyRate.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvCurrencyRate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCurrencyRate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIsSelected,
            this.colId,
            this.colTS,
            this.colFromCurrency,
            this.colToCurrency,
            this.colExchangeDate,
            this.colRateType,
            this.colExchangeRate,
            this.colDenoRate,
            this.colEdit});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvCurrencyRate.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvCurrencyRate.EnableHeadersVisualStyles = false;
            this.gvCurrencyRate.IdTSList = null;
            this.gvCurrencyRate.IsEscapeKey = false;
            this.gvCurrencyRate.IsHeaderClick = false;
            this.gvCurrencyRate.Location = new System.Drawing.Point(16, 200);
            this.gvCurrencyRate.Name = "gvCurrencyRate";
            this.gvCurrencyRate.RowHeadersWidth = 25;
            this.gvCurrencyRate.ShowSerialNo = false;
            this.gvCurrencyRate.Size = new System.Drawing.Size(773, 327);
            this.gvCurrencyRate.TabIndex = 8;
            this.gvCurrencyRate.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVRateInfo_CellContentClick);
            this.gvCurrencyRate.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgVRateInfoEntry_CellFormatting);
            // 
            // colIsSelected
            // 
            this.colIsSelected.CheckBoxHeader = false;
            this.colIsSelected.DataPropertyName = "IsCheck";
            this.colIsSelected.FalseValue = "false";
            this.colIsSelected.HeaderText = "";
            this.colIsSelected.Id = 0;
            this.colIsSelected.Name = "colIsSelected";
            this.colIsSelected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsSelected.TrueValue = "true";
            this.colIsSelected.TS = null;
            this.colIsSelected.Width = 30;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = false;
            // 
            // colTS
            // 
            this.colTS.HeaderText = "";
            this.colTS.Name = "colTS";
            this.colTS.Visible = false;
            // 
            // colFromCurrency
            // 
            this.colFromCurrency.DataPropertyName = "CurrencyCode";
            this.colFromCurrency.HeaderText = "From Currency";
            this.colFromCurrency.Name = "colFromCurrency";
            this.colFromCurrency.ReadOnly = true;
            // 
            // colToCurrency
            // 
            this.colToCurrency.DataPropertyName = "ToCurrencyCode";
            this.colToCurrency.HeaderText = "To Currency";
            this.colToCurrency.Name = "colToCurrency";
            this.colToCurrency.ReadOnly = true;
            // 
            // colExchangeDate
            // 
            this.colExchangeDate.DataPropertyName = "RegisterDate";
            this.colExchangeDate.HeaderText = "Exchange Date";
            this.colExchangeDate.Name = "colExchangeDate";
            this.colExchangeDate.ReadOnly = true;
            this.colExchangeDate.Width = 150;
            // 
            // colRateType
            // 
            this.colRateType.DataPropertyName = "RateType";
            this.colRateType.HeaderText = "Rate Type";
            this.colRateType.Name = "colRateType";
            this.colRateType.ReadOnly = true;
            // 
            // colExchangeRate
            // 
            this.colExchangeRate.DataPropertyName = "Rate";
            this.colExchangeRate.HeaderText = "Exchange Rate";
            this.colExchangeRate.Name = "colExchangeRate";
            this.colExchangeRate.ReadOnly = true;
            // 
            // colDenoRate
            // 
            this.colDenoRate.DataPropertyName = "DenoRate";
            this.colDenoRate.HeaderText = "Deno Rate";
            this.colDenoRate.Name = "colDenoRate";
            this.colDenoRate.ReadOnly = true;
            // 
            // colEdit
            // 
            this.colEdit.HeaderText = "";
            this.colEdit.Image = global::Ace.Cbs.Sam.Vew.Properties.Resources.Edit_Main;
            this.colEdit.Name = "colEdit";
            this.colEdit.Width = 30;
            // 
            // txtRecordCount
            // 
            this.txtRecordCount.DecimalPlaces = 0;
            this.txtRecordCount.IsSendTabOnEnter = true;
            this.txtRecordCount.Location = new System.Drawing.Point(127, 532);
            this.txtRecordCount.Name = "txtRecordCount";
            this.txtRecordCount.ReadOnly = true;
            this.txtRecordCount.Size = new System.Drawing.Size(57, 20);
            this.txtRecordCount.TabIndex = 9;
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
            this.lblRecordCount.Location = new System.Drawing.Point(12, 535);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(76, 13);
            this.lblRecordCount.TabIndex = 21;
            this.lblRecordCount.Text = "Record Count:";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.CausesValidation = false;
            this.tsbCRUD.Location = new System.Drawing.Point(-2, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(830, 31);
            this.tsbCRUD.TabIndex = 7;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.DeleteButtonClick += new System.EventHandler(this.tsbCRUD_DeleteButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // txtRate
            // 
            this.txtRate.DecimalPlaces = 7;
            this.txtRate.IsSendTabOnEnter = true;
            this.txtRate.IsUseFloatingPoint = true;
            this.txtRate.Location = new System.Drawing.Point(128, 148);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(121, 20);
            this.txtRate.TabIndex = 5;
            this.txtRate.Text = "0.0000000";
            this.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRate.Value = new decimal(new int[] {
            0,
            0,
            0,
            458752});
            this.txtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRate_KeyPress);
            // 
            // txtDenoRate
            // 
            this.txtDenoRate.IsSendTabOnEnter = true;
            this.txtDenoRate.Location = new System.Drawing.Point(128, 174);
            this.txtDenoRate.Name = "txtDenoRate";
            this.txtDenoRate.Size = new System.Drawing.Size(121, 20);
            this.txtDenoRate.TabIndex = 6;
            this.txtDenoRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDenoRate_KeyPress);
            // 
            // SAMVEW00051
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 563);
            this.Controls.Add(this.txtDenoRate);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.txtRecordCount);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.gvCurrencyRate);
            this.Controls.Add(this.cboRateType);
            this.Controls.Add(this.dtpRDate);
            this.Controls.Add(this.cboToCur);
            this.Controls.Add(this.cboCur);
            this.Controls.Add(this.lblDenoRate);
            this.Controls.Add(this.lblExchangeRate);
            this.Controls.Add(this.lblRateType);
            this.Controls.Add(this.lblExchangeDate);
            this.Controls.Add(this.lblToCurrencyCode);
            this.Controls.Add(this.lblFromCurrencyCode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SAMVEW00051";
            this.Text = "Currency Rate Setup Entry";
            this.Load += new System.EventHandler(this.SAMVEW00051_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvCurrencyRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0003 lblFromCurrencyCode;
        private Windows.CXClient.Controls.CXC0003 lblToCurrencyCode;
        private Windows.CXClient.Controls.CXC0003 lblExchangeDate;
        private Windows.CXClient.Controls.CXC0003 lblRateType;
        private Windows.CXClient.Controls.CXC0003 lblExchangeRate;
        private Windows.CXClient.Controls.CXC0003 lblDenoRate;
        private Windows.CXClient.Controls.CXC0002 cboCur;
        private Windows.CXClient.Controls.CXC0002 cboToCur;
        private Windows.CXClient.Controls.CXC0005 dtpRDate;
        private Windows.CXClient.Controls.CXC0002 cboRateType;
        private Windows.CXClient.Controls.AceGridView gvCurrencyRate;
        private Windows.CXClient.Controls.CXC0004 txtRecordCount;
        private Windows.CXClient.Controls.CXC0003 lblRecordCount;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0004 txtRate;
        private Windows.CXClient.Controls.CXC0001 txtDenoRate;
        private Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn colIsSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFromCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExchangeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRateType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExchangeRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDenoRate;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
    }
}