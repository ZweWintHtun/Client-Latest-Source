namespace Ace.Cbs.Sam.Vew
{
    partial class SAMVEW00017
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAMVEW00017));
            this.lblZoneType = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblBranchCode = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAccountCode = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtAccountCode = new Ace.Windows.CXClient.Controls.CXC0001();
            this.gvZoneCode = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colIsSelected = new Ace.Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn();
            this.colTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colZoneType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBranchCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtRecordCount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblRecordCount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.cboBranchCode = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cboZoneType = new Ace.Windows.CXClient.Controls.CXC0002();
            ((System.ComponentModel.ISupportInitialize)(this.gvZoneCode)).BeginInit();
            this.SuspendLayout();
            // 
            // lblZoneType
            // 
            this.lblZoneType.AutoSize = true;
            this.lblZoneType.Location = new System.Drawing.Point(12, 48);
            this.lblZoneType.Name = "lblZoneType";
            this.lblZoneType.Size = new System.Drawing.Size(65, 13);
            this.lblZoneType.TabIndex = 0;
            this.lblZoneType.Text = "Zone Type :";
            // 
            // lblBranchCode
            // 
            this.lblBranchCode.AutoSize = true;
            this.lblBranchCode.Location = new System.Drawing.Point(12, 76);
            this.lblBranchCode.Name = "lblBranchCode";
            this.lblBranchCode.Size = new System.Drawing.Size(75, 13);
            this.lblBranchCode.TabIndex = 0;
            this.lblBranchCode.Text = "Branch Code :";
            // 
            // lblAccountCode
            // 
            this.lblAccountCode.AutoSize = true;
            this.lblAccountCode.Location = new System.Drawing.Point(12, 102);
            this.lblAccountCode.Name = "lblAccountCode";
            this.lblAccountCode.Size = new System.Drawing.Size(81, 13);
            this.lblAccountCode.TabIndex = 0;
            this.lblAccountCode.Text = "Account Code :";
            // 
            // txtAccountCode
            // 
            this.txtAccountCode.IsSendTabOnEnter = true;
            this.txtAccountCode.Location = new System.Drawing.Point(105, 98);
            this.txtAccountCode.MaxLength = 6;
            this.txtAccountCode.Name = "txtAccountCode";
            this.txtAccountCode.Size = new System.Drawing.Size(141, 20);
            this.txtAccountCode.TabIndex = 3;
            this.txtAccountCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAccountCode_KeyPress);
            // 
            // gvZoneCode
            // 
            this.gvZoneCode.AllowUserToAddRows = false;
            this.gvZoneCode.CausesValidation = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvZoneCode.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvZoneCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvZoneCode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIsSelected,
            this.colTS,
            this.colZoneType,
            this.colBranchCode,
            this.colAccountCode,
            this.colEdit});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvZoneCode.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvZoneCode.EnableHeadersVisualStyles = false;
            this.gvZoneCode.IdTSList = null;
            this.gvZoneCode.IsEscapeKey = false;
            this.gvZoneCode.IsHeaderClick = false;
            this.gvZoneCode.Location = new System.Drawing.Point(15, 124);
            this.gvZoneCode.Name = "gvZoneCode";
            this.gvZoneCode.RowHeadersWidth = 25;
            this.gvZoneCode.ShowSerialNo = false;
            this.gvZoneCode.Size = new System.Drawing.Size(580, 410);
            this.gvZoneCode.TabIndex = 5;
            this.gvZoneCode.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVZone_CellContentClick);
            this.gvZoneCode.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgVZoneEntry_CellFormatting);
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
            this.colTS.Visible = false;
            // 
            // colZoneType
            // 
            this.colZoneType.DataPropertyName = "ZoneDescription";
            this.colZoneType.HeaderText = "Zone Type";
            this.colZoneType.Name = "colZoneType";
            this.colZoneType.ReadOnly = true;
            this.colZoneType.Width = 150;
            // 
            // colBranchCode
            // 
            this.colBranchCode.DataPropertyName = "BranchCode";
            this.colBranchCode.HeaderText = "Branch Code";
            this.colBranchCode.Name = "colBranchCode";
            this.colBranchCode.ReadOnly = true;
            this.colBranchCode.Width = 150;
            // 
            // colAccountCode
            // 
            this.colAccountCode.DataPropertyName = "AccountCode";
            this.colAccountCode.HeaderText = "Account Code";
            this.colAccountCode.Name = "colAccountCode";
            this.colAccountCode.ReadOnly = true;
            this.colAccountCode.Width = 150;
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
            this.txtRecordCount.Location = new System.Drawing.Point(105, 538);
            this.txtRecordCount.MaxLength = 5;
            this.txtRecordCount.Name = "txtRecordCount";
            this.txtRecordCount.ReadOnly = true;
            this.txtRecordCount.Size = new System.Drawing.Size(57, 20);
            this.txtRecordCount.TabIndex = 6;
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
            this.lblRecordCount.Location = new System.Drawing.Point(12, 541);
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
            this.tsbCRUD.Size = new System.Drawing.Size(785, 31);
            this.tsbCRUD.TabIndex = 4;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.DeleteButtonClick += new System.EventHandler(this.tsbCRUD_DeleteButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
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
            this.cboBranchCode.Location = new System.Drawing.Point(105, 71);
            this.cboBranchCode.Name = "cboBranchCode";
            this.cboBranchCode.Size = new System.Drawing.Size(141, 21);
            this.cboBranchCode.TabIndex = 2;
            // 
            // cboZoneType
            // 
            this.cboZoneType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboZoneType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboZoneType.DropDownHeight = 200;
            this.cboZoneType.FormattingEnabled = true;
            this.cboZoneType.IntegralHeight = false;
            this.cboZoneType.IsSendTabOnEnter = true;
            this.cboZoneType.Location = new System.Drawing.Point(105, 45);
            this.cboZoneType.Name = "cboZoneType";
            this.cboZoneType.Size = new System.Drawing.Size(141, 21);
            this.cboZoneType.TabIndex = 1;
            // 
            // SAMVEW00017
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 563);
            this.Controls.Add(this.cboZoneType);
            this.Controls.Add(this.cboBranchCode);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.txtRecordCount);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.gvZoneCode);
            this.Controls.Add(this.txtAccountCode);
            this.Controls.Add(this.lblAccountCode);
            this.Controls.Add(this.lblBranchCode);
            this.Controls.Add(this.lblZoneType);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SAMVEW00017";
            this.Text = "Zone Code Entry";
            this.Load += new System.EventHandler(this.SAMVEW00017_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvZoneCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0003 lblZoneType;
        private Windows.CXClient.Controls.CXC0003 lblBranchCode;
        private Windows.CXClient.Controls.CXC0003 lblAccountCode;
        private Windows.CXClient.Controls.CXC0001 txtAccountCode;
        private Windows.CXClient.Controls.AceGridView gvZoneCode;
        private Windows.CXClient.Controls.CXC0004 txtRecordCount;
        private Windows.CXClient.Controls.CXC0003 lblRecordCount;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0002 cboBranchCode;
        private Windows.CXClient.Controls.CXC0002 cboZoneType;
        private Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn colIsSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colZoneType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBranchCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountCode;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
    }
}