namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00077
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00077));
            this.txtRecordCount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblRecordCount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gvLSProductTypeItemList = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colIsSelected = new Ace.Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn();
            this.colTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductDesp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLSBusinessDesp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLSBusinessCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUMDesp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUMCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDurationMonths = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboProductType = new System.Windows.Forms.ComboBox();
            this.cboLSBusinessType = new System.Windows.Forms.ComboBox();
            this.cboUMCode = new System.Windows.Forms.ComboBox();
            this.txtDurationMonths = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvLSProductTypeItemList)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRecordCount
            // 
            this.txtRecordCount.DecimalPlaces = 0;
            this.txtRecordCount.IsSendTabOnEnter = true;
            this.txtRecordCount.Location = new System.Drawing.Point(94, 573);
            this.txtRecordCount.Name = "txtRecordCount";
            this.txtRecordCount.ReadOnly = true;
            this.txtRecordCount.Size = new System.Drawing.Size(57, 20);
            this.txtRecordCount.TabIndex = 132;
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
            this.lblRecordCount.Location = new System.Drawing.Point(12, 576);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(76, 13);
            this.lblRecordCount.TabIndex = 131;
            this.lblRecordCount.Text = "Record Count:";
            // 
            // gvLSProductTypeItemList
            // 
            this.gvLSProductTypeItemList.AllowUserToAddRows = false;
            this.gvLSProductTypeItemList.CausesValidation = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvLSProductTypeItemList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvLSProductTypeItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvLSProductTypeItemList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIsSelected,
            this.colTS,
            this.colProductDesp,
            this.colProductCode,
            this.colLSBusinessDesp,
            this.colLSBusinessCode,
            this.colUMDesp,
            this.colUMCode,
            this.colDurationMonths,
            this.colEdit});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvLSProductTypeItemList.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvLSProductTypeItemList.EnableHeadersVisualStyles = false;
            this.gvLSProductTypeItemList.IdTSList = null;
            this.gvLSProductTypeItemList.IsEscapeKey = false;
            this.gvLSProductTypeItemList.IsHeaderClick = false;
            this.gvLSProductTypeItemList.Location = new System.Drawing.Point(13, 168);
            this.gvLSProductTypeItemList.Name = "gvLSProductTypeItemList";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvLSProductTypeItemList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gvLSProductTypeItemList.RowHeadersWidth = 25;
            this.gvLSProductTypeItemList.ShowSerialNo = false;
            this.gvLSProductTypeItemList.Size = new System.Drawing.Size(603, 396);
            this.gvLSProductTypeItemList.TabIndex = 126;
            this.gvLSProductTypeItemList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvLSProductTypeItemList_CellContentClick);
            this.gvLSProductTypeItemList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvLSProductTypeItemList_CellFormatting);
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
            this.colProductDesp.Width = 120;
            // 
            // colProductCode
            // 
            this.colProductCode.DataPropertyName = "ProductCode";
            this.colProductCode.HeaderText = "Product Code";
            this.colProductCode.Name = "colProductCode";
            this.colProductCode.Visible = false;
            // 
            // colLSBusinessDesp
            // 
            this.colLSBusinessDesp.DataPropertyName = "LSBusinessDesp";
            this.colLSBusinessDesp.HeaderText = "Livestock Type";
            this.colLSBusinessDesp.Name = "colLSBusinessDesp";
            this.colLSBusinessDesp.ReadOnly = true;
            this.colLSBusinessDesp.Width = 120;
            // 
            // colLSBusinessCode
            // 
            this.colLSBusinessCode.DataPropertyName = "LSBusinessCode";
            this.colLSBusinessCode.HeaderText = "LSBusinessCode";
            this.colLSBusinessCode.Name = "colLSBusinessCode";
            this.colLSBusinessCode.Visible = false;
            // 
            // colUMDesp
            // 
            this.colUMDesp.DataPropertyName = "UMDesp";
            this.colUMDesp.HeaderText = "UM";
            this.colUMDesp.Name = "colUMDesp";
            this.colUMDesp.Width = 120;
            // 
            // colUMCode
            // 
            this.colUMCode.DataPropertyName = "UMCode";
            this.colUMCode.HeaderText = "UMCode";
            this.colUMCode.Name = "colUMCode";
            this.colUMCode.Visible = false;
            // 
            // colDurationMonths
            // 
            this.colDurationMonths.DataPropertyName = "DurationMonths";
            this.colDurationMonths.HeaderText = "Duration Month";
            this.colDurationMonths.Name = "colDurationMonths";
            // 
            // colEdit
            // 
            this.colEdit.HeaderText = "";
            this.colEdit.Image = global::Ace.Cbs.Loan.Vew.Properties.Resources.Edit_Main;
            this.colEdit.Name = "colEdit";
            this.colEdit.Width = 30;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(631, 36);
            this.tsbCRUD.TabIndex = 125;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.DeleteButtonClick += new System.EventHandler(this.tsbCRUD_DeleteButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 133;
            this.label1.Text = "Product Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 134;
            this.label2.Text = "Livestock Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 135;
            this.label3.Text = "UM";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 136;
            this.label4.Text = "Duration Month";
            // 
            // cboProductType
            // 
            this.cboProductType.FormattingEnabled = true;
            this.cboProductType.Location = new System.Drawing.Point(109, 45);
            this.cboProductType.Name = "cboProductType";
            this.cboProductType.Size = new System.Drawing.Size(121, 21);
            this.cboProductType.TabIndex = 137;
            // 
            // cboLSBusinessType
            // 
            this.cboLSBusinessType.FormattingEnabled = true;
            this.cboLSBusinessType.Location = new System.Drawing.Point(109, 74);
            this.cboLSBusinessType.Name = "cboLSBusinessType";
            this.cboLSBusinessType.Size = new System.Drawing.Size(121, 21);
            this.cboLSBusinessType.TabIndex = 138;
            // 
            // cboUMCode
            // 
            this.cboUMCode.FormattingEnabled = true;
            this.cboUMCode.Location = new System.Drawing.Point(109, 102);
            this.cboUMCode.Name = "cboUMCode";
            this.cboUMCode.Size = new System.Drawing.Size(121, 21);
            this.cboUMCode.TabIndex = 139;
            // 
            // txtDurationMonths
            // 
            this.txtDurationMonths.Location = new System.Drawing.Point(109, 131);
            this.txtDurationMonths.Name = "txtDurationMonths";
            this.txtDurationMonths.Size = new System.Drawing.Size(100, 20);
            this.txtDurationMonths.TabIndex = 140;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(215, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 141;
            this.label5.Text = "(Months)";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::Ace.Cbs.Loan.Vew.Properties.Resources.Edit_Main;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 30;
            // 
            // LOMVEW00077
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 598);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDurationMonths);
            this.Controls.Add(this.cboUMCode);
            this.Controls.Add(this.cboLSBusinessType);
            this.Controls.Add(this.cboProductType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRecordCount);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.gvLSProductTypeItemList);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00077";
            this.Text = "Livestock Product Type Item Setup";
            this.Load += new System.EventHandler(this.LOMVEW00077_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvLSProductTypeItemList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0004 txtRecordCount;
        private Windows.CXClient.Controls.CXC0003 lblRecordCount;
        private Windows.CXClient.Controls.AceGridView gvLSProductTypeItemList;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboProductType;
        private System.Windows.Forms.ComboBox cboLSBusinessType;
        private System.Windows.Forms.ComboBox cboUMCode;
        private System.Windows.Forms.TextBox txtDurationMonths;
        private System.Windows.Forms.Label label5;
        private Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn colIsSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductDesp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLSBusinessDesp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLSBusinessCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUMDesp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUMCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDurationMonths;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
    }
}