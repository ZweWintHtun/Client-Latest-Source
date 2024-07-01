namespace Ace.Cbs.Gl.Vew
{
    partial class GLMVEW00011
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GLMVEW00011));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.grpSelection = new System.Windows.Forms.GroupBox();
            this.rdoBySourceCurrency = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoByHomeCurrency = new Ace.Windows.CXClient.Controls.CXC0009();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.grpReportFormatType = new System.Windows.Forms.GroupBox();
            this.rdoMonthlyFigures = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoBudgetedAndActualFigures = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoActualFigures = new Ace.Windows.CXClient.Controls.CXC0009();
            this.lblRequiredMonth = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtRequiredMonth = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblStartDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblEndDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.dtpStartDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.dtpEndDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.lblReportHeading = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtReportHeading = new Ace.Windows.CXClient.Controls.CXC0001();
            this.gvFormatStyle = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colFormatCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpSelection.SuspendLayout();
            this.grpReportFormatType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvFormatStyle)).BeginInit();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, -1);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(519, 31);
            this.tsbCRUD.TabIndex = 9;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // grpSelection
            // 
            this.grpSelection.Controls.Add(this.rdoBySourceCurrency);
            this.grpSelection.Controls.Add(this.rdoByHomeCurrency);
            this.grpSelection.Location = new System.Drawing.Point(12, 37);
            this.grpSelection.Name = "grpSelection";
            this.grpSelection.Size = new System.Drawing.Size(268, 61);
            this.grpSelection.TabIndex = 1;
            this.grpSelection.TabStop = false;
            this.grpSelection.Text = "Select the required type to view Report.";
            // 
            // rdoBySourceCurrency
            // 
            this.rdoBySourceCurrency.AutoSize = true;
            this.rdoBySourceCurrency.IsSendTabOnEnter = true;
            this.rdoBySourceCurrency.Location = new System.Drawing.Point(138, 24);
            this.rdoBySourceCurrency.Name = "rdoBySourceCurrency";
            this.rdoBySourceCurrency.Size = new System.Drawing.Size(119, 17);
            this.rdoBySourceCurrency.TabIndex = 5;
            this.rdoBySourceCurrency.Text = "By Source Currency";
            this.rdoBySourceCurrency.UseVisualStyleBackColor = true;
            this.rdoBySourceCurrency.CheckedChanged += new System.EventHandler(this.rdoBySourceCurrency_CheckedChanged);
            // 
            // rdoByHomeCurrency
            // 
            this.rdoByHomeCurrency.AutoSize = true;
            this.rdoByHomeCurrency.Checked = true;
            this.rdoByHomeCurrency.IsSendTabOnEnter = true;
            this.rdoByHomeCurrency.Location = new System.Drawing.Point(9, 24);
            this.rdoByHomeCurrency.Name = "rdoByHomeCurrency";
            this.rdoByHomeCurrency.Size = new System.Drawing.Size(113, 17);
            this.rdoByHomeCurrency.TabIndex = 4;
            this.rdoByHomeCurrency.TabStop = true;
            this.rdoByHomeCurrency.Text = "By Home Currency";
            this.rdoByHomeCurrency.UseVisualStyleBackColor = true;
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
            this.cboCurrency.Location = new System.Drawing.Point(89, 107);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 2;
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(18, 110);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 9;
            this.lblCurrency.Text = "Currency :";
            // 
            // grpReportFormatType
            // 
            this.grpReportFormatType.Controls.Add(this.rdoMonthlyFigures);
            this.grpReportFormatType.Controls.Add(this.rdoBudgetedAndActualFigures);
            this.grpReportFormatType.Controls.Add(this.rdoActualFigures);
            this.grpReportFormatType.Location = new System.Drawing.Point(21, 143);
            this.grpReportFormatType.Name = "grpReportFormatType";
            this.grpReportFormatType.Size = new System.Drawing.Size(177, 108);
            this.grpReportFormatType.TabIndex = 3;
            this.grpReportFormatType.TabStop = false;
            this.grpReportFormatType.Text = "Select Report Format";
            // 
            // rdoMonthlyFigures
            // 
            this.rdoMonthlyFigures.AutoSize = true;
            this.rdoMonthlyFigures.IsSendTabOnEnter = true;
            this.rdoMonthlyFigures.Location = new System.Drawing.Point(9, 72);
            this.rdoMonthlyFigures.Name = "rdoMonthlyFigures";
            this.rdoMonthlyFigures.Size = new System.Drawing.Size(99, 17);
            this.rdoMonthlyFigures.TabIndex = 7;
            this.rdoMonthlyFigures.Text = "Monthly Figures";
            this.rdoMonthlyFigures.UseVisualStyleBackColor = true;
            // 
            // rdoBudgetedAndActualFigures
            // 
            this.rdoBudgetedAndActualFigures.AutoSize = true;
            this.rdoBudgetedAndActualFigures.IsSendTabOnEnter = true;
            this.rdoBudgetedAndActualFigures.Location = new System.Drawing.Point(9, 46);
            this.rdoBudgetedAndActualFigures.Name = "rdoBudgetedAndActualFigures";
            this.rdoBudgetedAndActualFigures.Size = new System.Drawing.Size(162, 17);
            this.rdoBudgetedAndActualFigures.TabIndex = 6;
            this.rdoBudgetedAndActualFigures.Text = "Budgeted and Actual Figures";
            this.rdoBudgetedAndActualFigures.UseVisualStyleBackColor = true;
            // 
            // rdoActualFigures
            // 
            this.rdoActualFigures.AutoSize = true;
            this.rdoActualFigures.Checked = true;
            this.rdoActualFigures.IsSendTabOnEnter = true;
            this.rdoActualFigures.Location = new System.Drawing.Point(9, 20);
            this.rdoActualFigures.Name = "rdoActualFigures";
            this.rdoActualFigures.Size = new System.Drawing.Size(92, 17);
            this.rdoActualFigures.TabIndex = 5;
            this.rdoActualFigures.TabStop = true;
            this.rdoActualFigures.Text = "Actual Figures";
            this.rdoActualFigures.UseVisualStyleBackColor = true;
            // 
            // lblRequiredMonth
            // 
            this.lblRequiredMonth.AutoSize = true;
            this.lblRequiredMonth.Location = new System.Drawing.Point(208, 163);
            this.lblRequiredMonth.Name = "lblRequiredMonth";
            this.lblRequiredMonth.Size = new System.Drawing.Size(89, 13);
            this.lblRequiredMonth.TabIndex = 13;
            this.lblRequiredMonth.Text = "Required Month :";
            // 
            // txtRequiredMonth
            // 
            this.txtRequiredMonth.IsSendTabOnEnter = true;
            this.txtRequiredMonth.Location = new System.Drawing.Point(303, 160);
            this.txtRequiredMonth.MaxLength = 20;
            this.txtRequiredMonth.Name = "txtRequiredMonth";
            this.txtRequiredMonth.Size = new System.Drawing.Size(115, 20);
            this.txtRequiredMonth.TabIndex = 4;
            this.txtRequiredMonth.Enter += new System.EventHandler(this.txtRequiredMonth_Enter);
            this.txtRequiredMonth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRequiredMonth_KeyDown);
            this.txtRequiredMonth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRequiredMonth_KeyPress);
            this.txtRequiredMonth.Leave += new System.EventHandler(this.txtRequiredMonth_Leave);
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(208, 192);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(61, 13);
            this.lblStartDate.TabIndex = 15;
            this.lblStartDate.Text = "Start Date :";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(208, 218);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(58, 13);
            this.lblEndDate.TabIndex = 16;
            this.lblEndDate.Text = "End Date :";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.IsSendTabOnEnter = true;
            this.dtpStartDate.Location = new System.Drawing.Point(303, 186);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(115, 20);
            this.dtpStartDate.TabIndex = 5;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.IsSendTabOnEnter = true;
            this.dtpEndDate.Location = new System.Drawing.Point(303, 212);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(115, 20);
            this.dtpEndDate.TabIndex = 6;
            // 
            // lblReportHeading
            // 
            this.lblReportHeading.AutoSize = true;
            this.lblReportHeading.Location = new System.Drawing.Point(27, 266);
            this.lblReportHeading.Name = "lblReportHeading";
            this.lblReportHeading.Size = new System.Drawing.Size(88, 13);
            this.lblReportHeading.TabIndex = 19;
            this.lblReportHeading.Text = "Report Heading :";
            // 
            // txtReportHeading
            // 
            this.txtReportHeading.IsSendTabOnEnter = true;
            this.txtReportHeading.Location = new System.Drawing.Point(121, 263);
            this.txtReportHeading.MaxLength = 20;
            this.txtReportHeading.Multiline = true;
            this.txtReportHeading.Name = "txtReportHeading";
            this.txtReportHeading.Size = new System.Drawing.Size(297, 20);
            this.txtReportHeading.TabIndex = 7;
            // 
            // gvFormatStyle
            // 
            this.gvFormatStyle.AllowDrop = true;
            this.gvFormatStyle.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvFormatStyle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvFormatStyle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvFormatStyle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFormatCode,
            this.colDescription});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvFormatStyle.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvFormatStyle.EnableHeadersVisualStyles = false;
            this.gvFormatStyle.IdTSList = null;
            this.gvFormatStyle.IsEscapeKey = false;
            this.gvFormatStyle.IsHeaderClick = false;
            this.gvFormatStyle.Location = new System.Drawing.Point(12, 303);
            this.gvFormatStyle.Name = "gvFormatStyle";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvFormatStyle.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gvFormatStyle.RowHeadersWidth = 25;
            this.gvFormatStyle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvFormatStyle.ShowSerialNo = false;
            this.gvFormatStyle.Size = new System.Drawing.Size(452, 175);
            this.gvFormatStyle.TabIndex = 8;
            // 
            // colFormatCode
            // 
            this.colFormatCode.DataPropertyName = "FormatType";
            this.colFormatCode.HeaderText = "Format Code";
            this.colFormatCode.Name = "colFormatCode";
            this.colFormatCode.ReadOnly = true;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "FormatName";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 300;
            // 
            // GLMVEW00011
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 495);
            this.Controls.Add(this.gvFormatStyle);
            this.Controls.Add(this.txtReportHeading);
            this.Controls.Add(this.lblReportHeading);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.txtRequiredMonth);
            this.Controls.Add(this.lblRequiredMonth);
            this.Controls.Add(this.grpReportFormatType);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.lblCurrency);
            this.Controls.Add(this.grpSelection);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GLMVEW00011";
            this.Text = "Report Statement";
            this.Load += new System.EventHandler(this.GLVEW00011_Load);
            this.grpSelection.ResumeLayout(false);
            this.grpSelection.PerformLayout();
            this.grpReportFormatType.ResumeLayout(false);
            this.grpReportFormatType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvFormatStyle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox grpSelection;
        private Windows.CXClient.Controls.CXC0009 rdoBySourceCurrency;
        private Windows.CXClient.Controls.CXC0009 rdoByHomeCurrency;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0003 lblCurrency;
        private System.Windows.Forms.GroupBox grpReportFormatType;
        private Windows.CXClient.Controls.CXC0009 rdoMonthlyFigures;
        private Windows.CXClient.Controls.CXC0009 rdoBudgetedAndActualFigures;
        private Windows.CXClient.Controls.CXC0009 rdoActualFigures;
        private Windows.CXClient.Controls.CXC0003 lblRequiredMonth;
        private Windows.CXClient.Controls.CXC0001 txtRequiredMonth;
        private Windows.CXClient.Controls.CXC0003 lblStartDate;
        private Windows.CXClient.Controls.CXC0003 lblEndDate;
        private Windows.CXClient.Controls.CXC0005 dtpStartDate;
        private Windows.CXClient.Controls.CXC0005 dtpEndDate;
        private Windows.CXClient.Controls.CXC0003 lblReportHeading;
        private Windows.CXClient.Controls.CXC0001 txtReportHeading;
        private Windows.CXClient.Controls.AceGridView gvFormatStyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFormatCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
    }
}