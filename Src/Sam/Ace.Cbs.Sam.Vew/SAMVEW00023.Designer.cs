namespace Ace.Cbs.Sam.Vew
{
    partial class SAMVEW00023
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAMVEW00023));
            this.lblRequiredMonth = new Ace.Windows.CXClient.Controls.CXC0003();
            this.dtpRequiredMonth = new Ace.Windows.CXClient.Controls.CXC0005();
            this.lblRate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtRate = new Ace.Windows.CXClient.Controls.CXC0004();
            this.gvRateSetup = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colIsSelected = new Ace.Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn();
            this.colTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrevRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRequireMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtRecordCount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblRecordCount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.txtCode = new Ace.Windows.CXClient.Controls.CXC0001();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtDescription = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblDescription = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtDuration = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblDuration = new Ace.Windows.CXClient.Controls.CXC0003();
            this.chkLastModify = new Ace.Windows.CXClient.Controls.CXC0008();
            ((System.ComponentModel.ISupportInitialize)(this.gvRateSetup)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRequiredMonth
            // 
            this.lblRequiredMonth.AutoSize = true;
            this.lblRequiredMonth.Location = new System.Drawing.Point(12, 113);
            this.lblRequiredMonth.Name = "lblRequiredMonth";
            this.lblRequiredMonth.Size = new System.Drawing.Size(92, 13);
            this.lblRequiredMonth.TabIndex = 0;
            this.lblRequiredMonth.Text = "Required Month : ";
            // 
            // dtpRequiredMonth
            // 
            this.dtpRequiredMonth.CustomFormat = "dd/MMM/yyyy";
            this.dtpRequiredMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRequiredMonth.IsSendTabOnEnter = true;
            this.dtpRequiredMonth.Location = new System.Drawing.Point(111, 113);
            this.dtpRequiredMonth.Name = "dtpRequiredMonth";
            this.dtpRequiredMonth.Size = new System.Drawing.Size(115, 20);
            this.dtpRequiredMonth.TabIndex = 3;
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Location = new System.Drawing.Point(13, 142);
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
            this.txtRate.Location = new System.Drawing.Point(111, 139);
            this.txtRate.MaxLength = 5;
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(115, 20);
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
            // gvRateSetup
            // 
            this.gvRateSetup.AllowUserToAddRows = false;
            this.gvRateSetup.CausesValidation = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvRateSetup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvRateSetup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvRateSetup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIsSelected,
            this.colTS,
            this.colCode,
            this.colDescription,
            this.colPrevRate,
            this.colRequireMonth,
            this.colDuration,
            this.colEdit});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvRateSetup.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvRateSetup.EnableHeadersVisualStyles = false;
            this.gvRateSetup.IdTSList = null;
            this.gvRateSetup.IsEscapeKey = false;
            this.gvRateSetup.IsHeaderClick = false;
            this.gvRateSetup.Location = new System.Drawing.Point(16, 192);
            this.gvRateSetup.Name = "gvRateSetup";
            this.gvRateSetup.RowHeadersWidth = 25;
            this.gvRateSetup.ShowSerialNo = false;
            this.gvRateSetup.Size = new System.Drawing.Size(810, 340);
            this.gvRateSetup.TabIndex = 8;
            this.gvRateSetup.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVRateFile_CellContentClick);
            this.gvRateSetup.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgVRateFileEntry_CellFormatting);
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
            // 
            // colCode
            // 
            this.colCode.DataPropertyName = "Code";
            this.colCode.HeaderText = "Code";
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            this.colCode.Width = 150;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 200;
            // 
            // colPrevRate
            // 
            this.colPrevRate.DataPropertyName = "Rate";
            this.colPrevRate.HeaderText = "Rate";
            this.colPrevRate.Name = "colPrevRate";
            this.colPrevRate.ReadOnly = true;
            // 
            // colRequireMonth
            // 
            this.colRequireMonth.DataPropertyName = "DATE_TIME";
            this.colRequireMonth.HeaderText = "Required Month ";
            this.colRequireMonth.Name = "colRequireMonth";
            this.colRequireMonth.ReadOnly = true;
            this.colRequireMonth.Width = 150;
            // 
            // colDuration
            // 
            this.colDuration.DataPropertyName = "Duration";
            this.colDuration.HeaderText = "Duration";
            this.colDuration.Name = "colDuration";
            this.colDuration.ReadOnly = true;
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
            this.txtRecordCount.Location = new System.Drawing.Point(111, 538);
            this.txtRecordCount.MaxLength = 5;
            this.txtRecordCount.Name = "txtRecordCount";
            this.txtRecordCount.ReadOnly = true;
            this.txtRecordCount.Size = new System.Drawing.Size(57, 20);
            this.txtRecordCount.TabIndex = 7;
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
            this.lblRecordCount.Location = new System.Drawing.Point(13, 541);
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
            this.tsbCRUD.Location = new System.Drawing.Point(1, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(847, 31);
            this.tsbCRUD.TabIndex = 7;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.DeleteButtonClick += new System.EventHandler(this.tsbCRUD_DeleteButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // txtCode
            // 
            this.txtCode.IsSendTabOnEnter = true;
            this.txtCode.Location = new System.Drawing.Point(111, 39);
            this.txtCode.MaxLength = 15;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(141, 20);
            this.txtCode.TabIndex = 1;
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCode_KeyPress);
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(13, 42);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(41, 13);
            this.cxC00031.TabIndex = 0;
            this.cxC00031.Text = "Code : ";
            // 
            // txtDescription
            // 
            this.txtDescription.IsSendTabOnEnter = true;
            this.txtDescription.Location = new System.Drawing.Point(111, 65);
            this.txtDescription.MaxLength = 40;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(175, 42);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescription_KeyPress);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(13, 68);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(66, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Description :";
            // 
            // txtDuration
            // 
            this.txtDuration.DecimalPlaces = 0;
            this.txtDuration.IsSendTabOnEnter = true;
            this.txtDuration.Location = new System.Drawing.Point(111, 167);
            this.txtDuration.Margin = new System.Windows.Forms.Padding(2);
            this.txtDuration.MaxLength = 5;
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(115, 20);
            this.txtDuration.TabIndex = 5;
            this.txtDuration.Text = "0";
            this.txtDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDuration.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDuration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDuration_KeyPress);
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(13, 167);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(89, 13);
            this.lblDuration.TabIndex = 0;
            this.lblDuration.Text = "Duration(Month) :";
            // 
            // chkLastModify
            // 
            this.chkLastModify.AutoSize = true;
            this.chkLastModify.Enabled = false;
            this.chkLastModify.IsSendTabOnEnter = true;
            this.chkLastModify.Location = new System.Drawing.Point(251, 169);
            this.chkLastModify.Name = "chkLastModify";
            this.chkLastModify.Size = new System.Drawing.Size(80, 17);
            this.chkLastModify.TabIndex = 6;
            this.chkLastModify.Text = "Last Modify";
            this.chkLastModify.UseVisualStyleBackColor = true;
            this.chkLastModify.Visible = false;
            // 
            // SAMVEW00023
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 563);
            this.Controls.Add(this.chkLastModify);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.cxC00031);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.txtRecordCount);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.gvRateSetup);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.lblRate);
            this.Controls.Add(this.dtpRequiredMonth);
            this.Controls.Add(this.lblRequiredMonth);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SAMVEW00023";
            this.Text = "Rate Setup Entry";
            this.Load += new System.EventHandler(this.SAMVEW00023_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvRateSetup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0003 lblRequiredMonth;
        private Windows.CXClient.Controls.CXC0005 dtpRequiredMonth;
        private Windows.CXClient.Controls.CXC0003 lblRate;
        private Windows.CXClient.Controls.CXC0004 txtRate;
        private Windows.CXClient.Controls.AceGridView gvRateSetup;
        private Windows.CXClient.Controls.CXC0004 txtRecordCount;
        private Windows.CXClient.Controls.CXC0003 lblRecordCount;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0001 txtCode;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0001 txtDescription;
        private Windows.CXClient.Controls.CXC0003 lblDescription;
        private Windows.CXClient.Controls.CXC0004 txtDuration;
        private Windows.CXClient.Controls.CXC0003 lblDuration;
        private Windows.CXClient.Controls.CXC0008 chkLastModify;
        private Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn colIsSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrevRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequireMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDuration;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
    }
}