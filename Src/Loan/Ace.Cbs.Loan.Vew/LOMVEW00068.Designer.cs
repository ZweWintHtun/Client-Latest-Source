namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00068
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00068));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblPrefixCode = new System.Windows.Forms.Label();
            this.txtPrefixCode = new System.Windows.Forms.TextBox();
            this.lblStockGroupCode = new System.Windows.Forms.Label();
            this.txtStockGroupCode = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.gvStockGroupList = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colIsSelected = new Ace.Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn();
            this.colTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrefixCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGroupCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtRecordCount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblRecordCount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvStockGroupList)).BeginInit();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(637, 36);
            this.tsbCRUD.TabIndex = 48;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.DeleteButtonClick += new System.EventHandler(this.tsbCRUD_DeleteButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblPrefixCode
            // 
            this.lblPrefixCode.AutoSize = true;
            this.lblPrefixCode.Location = new System.Drawing.Point(16, 81);
            this.lblPrefixCode.Name = "lblPrefixCode";
            this.lblPrefixCode.Size = new System.Drawing.Size(61, 13);
            this.lblPrefixCode.TabIndex = 49;
            this.lblPrefixCode.Text = "Prefix Code";
            // 
            // txtPrefixCode
            // 
            this.txtPrefixCode.Location = new System.Drawing.Point(139, 78);
            this.txtPrefixCode.Name = "txtPrefixCode";
            this.txtPrefixCode.Size = new System.Drawing.Size(134, 20);
            this.txtPrefixCode.TabIndex = 52;
            this.txtPrefixCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_KeyPress);
            // 
            // lblStockGroupCode
            // 
            this.lblStockGroupCode.AutoSize = true;
            this.lblStockGroupCode.Location = new System.Drawing.Point(16, 54);
            this.lblStockGroupCode.Name = "lblStockGroupCode";
            this.lblStockGroupCode.Size = new System.Drawing.Size(95, 13);
            this.lblStockGroupCode.TabIndex = 51;
            this.lblStockGroupCode.Text = "Stock Group Code";
            // 
            // txtStockGroupCode
            // 
            this.txtStockGroupCode.Location = new System.Drawing.Point(139, 51);
            this.txtStockGroupCode.Name = "txtStockGroupCode";
            this.txtStockGroupCode.Size = new System.Drawing.Size(134, 20);
            this.txtStockGroupCode.TabIndex = 50;
            this.txtStockGroupCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_KeyPress);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(16, 108);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 53;
            this.lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(139, 105);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(216, 49);
            this.txtDescription.TabIndex = 54;
            this.txtDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_KeyPress);
            // 
            // gvStockGroupList
            // 
            this.gvStockGroupList.AllowUserToAddRows = false;
            this.gvStockGroupList.CausesValidation = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvStockGroupList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvStockGroupList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvStockGroupList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIsSelected,
            this.colTS,
            this.colPrefixCode,
            this.colGroupCode,
            this.colDescription,
            this.colEdit});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvStockGroupList.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvStockGroupList.EnableHeadersVisualStyles = false;
            this.gvStockGroupList.IdTSList = null;
            this.gvStockGroupList.IsEscapeKey = false;
            this.gvStockGroupList.IsHeaderClick = false;
            this.gvStockGroupList.Location = new System.Drawing.Point(12, 160);
            this.gvStockGroupList.Name = "gvStockGroupList";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvStockGroupList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gvStockGroupList.RowHeadersWidth = 25;
            this.gvStockGroupList.ShowSerialNo = false;
            this.gvStockGroupList.Size = new System.Drawing.Size(612, 396);
            this.gvStockGroupList.TabIndex = 101;
            this.gvStockGroupList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvStockGroupList_CellContentClick);
            this.gvStockGroupList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvStockGroupList_CellFormatting);
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
            // colPrefixCode
            // 
            this.colPrefixCode.DataPropertyName = "PreFix";
            this.colPrefixCode.HeaderText = "Prefix Code";
            this.colPrefixCode.Name = "colPrefixCode";
            // 
            // colGroupCode
            // 
            this.colGroupCode.DataPropertyName = "GroupCode";
            dataGridViewCellStyle2.NullValue = null;
            this.colGroupCode.DefaultCellStyle = dataGridViewCellStyle2;
            this.colGroupCode.HeaderText = "Group Code";
            this.colGroupCode.Name = "colGroupCode";
            this.colGroupCode.ReadOnly = true;
            this.colGroupCode.Width = 150;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 250;
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
            this.txtRecordCount.Location = new System.Drawing.Point(92, 562);
            this.txtRecordCount.Name = "txtRecordCount";
            this.txtRecordCount.ReadOnly = true;
            this.txtRecordCount.Size = new System.Drawing.Size(57, 20);
            this.txtRecordCount.TabIndex = 103;
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
            this.lblRecordCount.Location = new System.Drawing.Point(10, 565);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(76, 13);
            this.lblRecordCount.TabIndex = 102;
            this.lblRecordCount.Text = "Record Count:";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::Ace.Cbs.Loan.Vew.Properties.Resources.Edit_Main;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 30;
            // 
            // LOMVEW00068
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 589);
            this.Controls.Add(this.txtRecordCount);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.gvStockGroupList);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtStockGroupCode);
            this.Controls.Add(this.lblStockGroupCode);
            this.Controls.Add(this.txtPrefixCode);
            this.Controls.Add(this.lblPrefixCode);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00068";
            this.Text = "Hire Purchase Stock Group Entry";
            this.Load += new System.EventHandler(this.LOMVEW00068_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvStockGroupList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.Label lblPrefixCode;
        private System.Windows.Forms.TextBox txtPrefixCode;
        private System.Windows.Forms.Label lblStockGroupCode;
        private System.Windows.Forms.TextBox txtStockGroupCode;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private Windows.CXClient.Controls.AceGridView gvStockGroupList;
        private Windows.CXClient.Controls.CXC0004 txtRecordCount;
        private Windows.CXClient.Controls.CXC0003 lblRecordCount;
        private Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn colIsSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrefixCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGroupCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;

    }
}