namespace Ace.Cbs.Sam.Vew
{
    partial class SAMVEW00022
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAMVEW00022));
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblStartAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtStartAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblendamount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtEndAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblRate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtRate = new Ace.Windows.CXClient.Controls.CXC0004();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtFixedAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.gvPoRate = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colIsSelected = new Ace.Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn();
            this.colTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colstartamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFixedAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtRecordCount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblRecordCount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            ((System.ComponentModel.ISupportInitialize)(this.gvPoRate)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(13, 42);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 0;
            this.lblCurrency.Text = "Currency :";
            // 
            // cboCurrency
            // 
            this.cboCurrency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCurrency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCurrency.DropDownHeight = 200;
            this.cboCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrency.FormattingEnabled = true;
            this.cboCurrency.IntegralHeight = false;
            this.cboCurrency.IsSendTabOnEnter = true;
            this.cboCurrency.Location = new System.Drawing.Point(103, 39);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(121, 21);
            this.cboCurrency.TabIndex = 1;
            // 
            // lblStartAmount
            // 
            this.lblStartAmount.AutoSize = true;
            this.lblStartAmount.Location = new System.Drawing.Point(13, 69);
            this.lblStartAmount.Name = "lblStartAmount";
            this.lblStartAmount.Size = new System.Drawing.Size(74, 13);
            this.lblStartAmount.TabIndex = 0;
            this.lblStartAmount.Text = "Start Amount :";
            // 
            // txtStartAmount
            // 
            this.txtStartAmount.DecimalPlaces = 2;
            this.txtStartAmount.IsSendTabOnEnter = true;
            this.txtStartAmount.IsUseFloatingPoint = true;
            this.txtStartAmount.Location = new System.Drawing.Point(103, 66);
            this.txtStartAmount.MaxLength = 10;
            this.txtStartAmount.Name = "txtStartAmount";
            this.txtStartAmount.Size = new System.Drawing.Size(121, 20);
            this.txtStartAmount.TabIndex = 2;
            this.txtStartAmount.Text = "0.00";
            this.txtStartAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtStartAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtStartAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStartAmount_KeyPress);
            // 
            // lblendamount
            // 
            this.lblendamount.AutoSize = true;
            this.lblendamount.Location = new System.Drawing.Point(13, 95);
            this.lblendamount.Name = "lblendamount";
            this.lblendamount.Size = new System.Drawing.Size(71, 13);
            this.lblendamount.TabIndex = 0;
            this.lblendamount.Text = "End Amount :";
            // 
            // txtEndAmount
            // 
            this.txtEndAmount.DecimalPlaces = 2;
            this.txtEndAmount.IsSendTabOnEnter = true;
            this.txtEndAmount.IsUseFloatingPoint = true;
            this.txtEndAmount.Location = new System.Drawing.Point(103, 92);
            this.txtEndAmount.MaxLength = 10;
            this.txtEndAmount.Name = "txtEndAmount";
            this.txtEndAmount.Size = new System.Drawing.Size(121, 20);
            this.txtEndAmount.TabIndex = 3;
            this.txtEndAmount.Text = "0.00";
            this.txtEndAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEndAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtEndAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEndAmount_KeyPress);
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Location = new System.Drawing.Point(13, 123);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(53, 13);
            this.lblRate.TabIndex = 0;
            this.lblRate.Text = "Rate (%) :";
            // 
            // txtRate
            // 
            this.txtRate.DecimalPlaces = 2;
            this.txtRate.IsSendTabOnEnter = true;
            this.txtRate.IsUseFloatingPoint = true;
            this.txtRate.Location = new System.Drawing.Point(103, 118);
            this.txtRate.MaxLength = 5;
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(121, 20);
            this.txtRate.TabIndex = 4;
            this.txtRate.Text = "0.00";
            this.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRate.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRate_KeyPress);
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(13, 147);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(77, 13);
            this.cxC00031.TabIndex = 0;
            this.cxC00031.Text = "Fixed Amount :";
            // 
            // txtFixedAmount
            // 
            this.txtFixedAmount.DecimalPlaces = 2;
            this.txtFixedAmount.IsSendTabOnEnter = true;
            this.txtFixedAmount.IsUseFloatingPoint = true;
            this.txtFixedAmount.Location = new System.Drawing.Point(103, 144);
            this.txtFixedAmount.MaxLength = 10;
            this.txtFixedAmount.Name = "txtFixedAmount";
            this.txtFixedAmount.Size = new System.Drawing.Size(121, 20);
            this.txtFixedAmount.TabIndex = 5;
            this.txtFixedAmount.Text = "0.00";
            this.txtFixedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFixedAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtFixedAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFixedAmount_KeyPress);
            // 
            // gvPoRate
            // 
            this.gvPoRate.AllowUserToAddRows = false;
            this.gvPoRate.CausesValidation = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvPoRate.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvPoRate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPoRate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIsSelected,
            this.colTS,
            this.colCurrency,
            this.colstartamount,
            this.colEndAmount,
            this.colRate,
            this.colId,
            this.colFixedAmount,
            this.colEdit});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvPoRate.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvPoRate.EnableHeadersVisualStyles = false;
            this.gvPoRate.IdTSList = null;
            this.gvPoRate.IsEscapeKey = false;
            this.gvPoRate.IsHeaderClick = false;
            this.gvPoRate.Location = new System.Drawing.Point(13, 170);
            this.gvPoRate.Name = "gvPoRate";
            this.gvPoRate.RowHeadersWidth = 25;
            this.gvPoRate.ShowSerialNo = false;
            this.gvPoRate.Size = new System.Drawing.Size(764, 350);
            this.gvPoRate.TabIndex = 7;
            this.gvPoRate.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVPORate_CellContentClick);
            this.gvPoRate.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgVPORateEntry_CellFormatting);
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
            // colTS
            // 
            this.colTS.DataPropertyName = "TS";
            this.colTS.HeaderText = "TS";
            this.colTS.Name = "colTS";
            this.colTS.ReadOnly = true;
            this.colTS.Visible = false;
            // 
            // colCurrency
            // 
            this.colCurrency.DataPropertyName = "Currency";
            this.colCurrency.HeaderText = "Currency";
            this.colCurrency.Name = "colCurrency";
            this.colCurrency.ReadOnly = true;
            // 
            // colstartamount
            // 
            this.colstartamount.DataPropertyName = "StartNo";
            this.colstartamount.HeaderText = "Start Amount";
            this.colstartamount.Name = "colstartamount";
            this.colstartamount.ReadOnly = true;
            this.colstartamount.Width = 150;
            // 
            // colEndAmount
            // 
            this.colEndAmount.DataPropertyName = "EndNo";
            this.colEndAmount.HeaderText = "End Amount";
            this.colEndAmount.Name = "colEndAmount";
            this.colEndAmount.ReadOnly = true;
            this.colEndAmount.Width = 150;
            // 
            // colRate
            // 
            this.colRate.DataPropertyName = "Rate";
            this.colRate.HeaderText = "Rate";
            this.colRate.Name = "colRate";
            this.colRate.ReadOnly = true;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = false;
            // 
            // colFixedAmount
            // 
            this.colFixedAmount.DataPropertyName = "FixAmount";
            this.colFixedAmount.HeaderText = "Fixed Amount";
            this.colFixedAmount.Name = "colFixedAmount";
            this.colFixedAmount.ReadOnly = true;
            this.colFixedAmount.Width = 150;
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
            this.txtRecordCount.Location = new System.Drawing.Point(102, 527);
            this.txtRecordCount.MaxLength = 5;
            this.txtRecordCount.Name = "txtRecordCount";
            this.txtRecordCount.ReadOnly = true;
            this.txtRecordCount.Size = new System.Drawing.Size(57, 20);
            this.txtRecordCount.TabIndex = 8;
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
            this.lblRecordCount.Location = new System.Drawing.Point(12, 530);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(79, 13);
            this.lblRecordCount.TabIndex = 0;
            this.lblRecordCount.Text = "Record Count :";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.CausesValidation = false;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(829, 31);
            this.tsbCRUD.TabIndex = 6;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.DeleteButtonClick += new System.EventHandler(this.tsbCRUD_DeleteButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // SAMVEW00022
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 563);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.txtRecordCount);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.gvPoRate);
            this.Controls.Add(this.txtFixedAmount);
            this.Controls.Add(this.cxC00031);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.lblRate);
            this.Controls.Add(this.txtEndAmount);
            this.Controls.Add(this.lblendamount);
            this.Controls.Add(this.txtStartAmount);
            this.Controls.Add(this.lblStartAmount);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.lblCurrency);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SAMVEW00022";
            this.Text = "PO Rate Setup Entry";
            this.Load += new System.EventHandler(this.SAMVEW00022_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvPoRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0003 lblStartAmount;
        private Windows.CXClient.Controls.CXC0004 txtStartAmount;
        private Windows.CXClient.Controls.CXC0003 lblendamount;
        private Windows.CXClient.Controls.CXC0004 txtEndAmount;
        private Windows.CXClient.Controls.CXC0003 lblRate;
        private Windows.CXClient.Controls.CXC0004 txtRate;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0004 txtFixedAmount;
        private Windows.CXClient.Controls.AceGridView gvPoRate;
        private Windows.CXClient.Controls.CXC0004 txtRecordCount;
        private Windows.CXClient.Controls.CXC0003 lblRecordCount;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn colIsSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn colstartamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFixedAmount;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
    }
}