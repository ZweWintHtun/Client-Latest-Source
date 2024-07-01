namespace Ace.Cbs.Sam.Vew
{
    partial class SAMVEW00002
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAMVEW00002));
            this.lblSymbol = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblDescription = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCode = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAccountSign = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAccountType = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboAccountType = new Ace.Windows.CXClient.Controls.CXC0002();
            this.txtSymbol = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtDescription = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtCode = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtAccountSign = new Ace.Windows.CXClient.Controls.CXC0001();
            this.dgVSubAccountType = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colIsSelected = new Ace.Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn();
            this.colAccountTypeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountSign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtRecordCount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblRecordCount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsdCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            ((System.ComponentModel.ISupportInitialize)(this.dgVSubAccountType)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSymbol
            // 
            this.lblSymbol.AutoSize = true;
            this.lblSymbol.Location = new System.Drawing.Point(9, 169);
            this.lblSymbol.Name = "lblSymbol";
            this.lblSymbol.Size = new System.Drawing.Size(47, 13);
            this.lblSymbol.TabIndex = 0;
            this.lblSymbol.Text = "Symbol :";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(9, 97);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(66, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Description :";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(9, 71);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(38, 13);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Code :";
            // 
            // lblAccountSign
            // 
            this.lblAccountSign.AutoSize = true;
            this.lblAccountSign.Location = new System.Drawing.Point(9, 145);
            this.lblAccountSign.Name = "lblAccountSign";
            this.lblAccountSign.Size = new System.Drawing.Size(77, 13);
            this.lblAccountSign.TabIndex = 0;
            this.lblAccountSign.Text = "Account Sign :";
            // 
            // lblAccountType
            // 
            this.lblAccountType.AutoSize = true;
            this.lblAccountType.Location = new System.Drawing.Point(9, 44);
            this.lblAccountType.Name = "lblAccountType";
            this.lblAccountType.Size = new System.Drawing.Size(80, 13);
            this.lblAccountType.TabIndex = 0;
            this.lblAccountType.Text = "Account Type :";
            // 
            // cboAccountType
            // 
            this.cboAccountType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboAccountType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAccountType.DropDownHeight = 200;
            this.cboAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccountType.FormattingEnabled = true;
            this.cboAccountType.IntegralHeight = false;
            this.cboAccountType.IsSendTabOnEnter = true;
            this.cboAccountType.Location = new System.Drawing.Point(108, 41);
            this.cboAccountType.Name = "cboAccountType";
            this.cboAccountType.Size = new System.Drawing.Size(141, 21);
            this.cboAccountType.TabIndex = 1;
            // 
            // txtSymbol
            // 
            this.txtSymbol.IsSendTabOnEnter = true;
            this.txtSymbol.Location = new System.Drawing.Point(108, 166);
            this.txtSymbol.MaxLength = 5;
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.Size = new System.Drawing.Size(57, 20);
            this.txtSymbol.TabIndex = 5;
            this.txtSymbol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSymbol_KeyPress);
            // 
            // txtDescription
            // 
            this.txtDescription.IsSendTabOnEnter = true;
            this.txtDescription.Location = new System.Drawing.Point(108, 94);
            this.txtDescription.MaxLength = 40;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(175, 42);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescription_KeyPress);
            // 
            // txtCode
            // 
            this.txtCode.IsSendTabOnEnter = true;
            this.txtCode.Location = new System.Drawing.Point(108, 68);
            this.txtCode.MaxLength = 11;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(141, 20);
            this.txtCode.TabIndex = 2;
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCode_KeyPress);
            // 
            // txtAccountSign
            // 
            this.txtAccountSign.IsSendTabOnEnter = true;
            this.txtAccountSign.Location = new System.Drawing.Point(108, 142);
            this.txtAccountSign.MaxLength = 5;
            this.txtAccountSign.Name = "txtAccountSign";
            this.txtAccountSign.Size = new System.Drawing.Size(57, 20);
            this.txtAccountSign.TabIndex = 4;
            this.txtAccountSign.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAccountSign_KeyPress);
            // 
            // dgVSubAccountType
            // 
            this.dgVSubAccountType.AllowUserToAddRows = false;
            this.dgVSubAccountType.AllowUserToOrderColumns = true;
            this.dgVSubAccountType.CausesValidation = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgVSubAccountType.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgVSubAccountType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVSubAccountType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIsSelected,
            this.colAccountTypeCode,
            this.colCode,
            this.colAccountTypeId,
            this.colDescription,
            this.colAccountSign,
            this.colSymbol,
            this.colTS,
            this.colEdit});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgVSubAccountType.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgVSubAccountType.EnableHeadersVisualStyles = false;
            this.dgVSubAccountType.IdTSList = null;
            this.dgVSubAccountType.IsEscapeKey = false;
            this.dgVSubAccountType.IsHeaderClick = false;
            this.dgVSubAccountType.Location = new System.Drawing.Point(12, 192);
            this.dgVSubAccountType.Name = "dgVSubAccountType";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgVSubAccountType.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgVSubAccountType.RowHeadersWidth = 25;
            this.dgVSubAccountType.ShowSerialNo = false;
            this.dgVSubAccountType.Size = new System.Drawing.Size(813, 410);
            this.dgVSubAccountType.TabIndex = 7;
            this.dgVSubAccountType.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVSubAccountType_CellContentClick);
            this.dgVSubAccountType.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgVSubAccountTypeEntry_CellFormatting);
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
            // colAccountTypeCode
            // 
            this.colAccountTypeCode.DataPropertyName = "AccountTypeCode";
            this.colAccountTypeCode.HeaderText = "Account Type Code";
            this.colAccountTypeCode.Name = "colAccountTypeCode";
            this.colAccountTypeCode.ReadOnly = true;
            this.colAccountTypeCode.Width = 150;
            // 
            // colCode
            // 
            this.colCode.DataPropertyName = "Code";
            this.colCode.HeaderText = "Code";
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            this.colCode.Width = 150;
            // 
            // colAccountTypeId
            // 
            this.colAccountTypeId.DataPropertyName = "AccountTypeId";
            this.colAccountTypeId.HeaderText = "Account Type Id";
            this.colAccountTypeId.Name = "colAccountTypeId";
            this.colAccountTypeId.Visible = false;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 200;
            // 
            // colAccountSign
            // 
            this.colAccountSign.DataPropertyName = "AccountSignature";
            this.colAccountSign.HeaderText = "Account Sign";
            this.colAccountSign.Name = "colAccountSign";
            this.colAccountSign.ReadOnly = true;
            // 
            // colSymbol
            // 
            this.colSymbol.DataPropertyName = "Symbol";
            this.colSymbol.HeaderText = "Symbol";
            this.colSymbol.Name = "colSymbol";
            this.colSymbol.ReadOnly = true;
            // 
            // colTS
            // 
            this.colTS.DataPropertyName = "TS";
            this.colTS.HeaderText = "TS";
            this.colTS.Name = "colTS";
            this.colTS.ReadOnly = true;
            this.colTS.Visible = false;
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
            this.txtRecordCount.Location = new System.Drawing.Point(108, 610);
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
            this.lblRecordCount.Location = new System.Drawing.Point(9, 613);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(79, 13);
            this.lblRecordCount.TabIndex = 0;
            this.lblRecordCount.Text = "Record Count :";
            // 
            // tsdCRUD
            // 
            this.tsdCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsdCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsdCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsdCRUD.Name = "tsdCRUD";
            this.tsdCRUD.PrintButtonCauseValidation = true;
            this.tsdCRUD.Size = new System.Drawing.Size(841, 31);
            this.tsdCRUD.TabIndex = 6;
            this.tsdCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsdCRUD.DeleteButtonClick += new System.EventHandler(this.tsbCRUD_DeleteButtonClick);
            this.tsdCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsdCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // SAMVEW00002
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 639);
            this.Controls.Add(this.tsdCRUD);
            this.Controls.Add(this.txtRecordCount);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.dgVSubAccountType);
            this.Controls.Add(this.txtAccountSign);
            this.Controls.Add(this.txtSymbol);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.cboAccountType);
            this.Controls.Add(this.lblSymbol);
            this.Controls.Add(this.lblAccountSign);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblAccountType);
            this.Controls.Add(this.lblCode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SAMVEW00002";
            this.Text = "Sub Account Type Entry";
            this.Load += new System.EventHandler(this.SAMVEW00002_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgVSubAccountType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0003 lblSymbol;
        private Windows.CXClient.Controls.CXC0003 lblDescription;
        private Windows.CXClient.Controls.CXC0003 lblCode;
        private Windows.CXClient.Controls.CXC0003 lblAccountSign;
        private Windows.CXClient.Controls.CXC0003 lblAccountType;
        private Windows.CXClient.Controls.CXC0002 cboAccountType;
        private Windows.CXClient.Controls.CXC0001 txtSymbol;
        private Windows.CXClient.Controls.CXC0001 txtDescription;
        private Windows.CXClient.Controls.CXC0001 txtCode;
        private Windows.CXClient.Controls.CXC0001 txtAccountSign;
        private Windows.CXClient.Controls.AceGridView dgVSubAccountType;
        private Windows.CXClient.Controls.CXC0004 txtRecordCount;
        private Windows.CXClient.Controls.CXC0003 lblRecordCount;
        private Windows.CXClient.Controls.CXCLIC001 tsdCRUD;
        private Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn colIsSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountTypeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountSign;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTS;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
    }
}