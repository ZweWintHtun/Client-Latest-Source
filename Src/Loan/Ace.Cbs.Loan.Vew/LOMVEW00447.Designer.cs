namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00447
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
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.txtRecordCount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblRecordCount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gvStockGroupList = new Ace.Windows.CXClient.Controls.AceGridView();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.lblStockGroupCode = new System.Windows.Forms.Label();
            this.lblPrefixCode = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.cboGLCode = new Ace.Windows.CXClient.Controls.AceMultiColumnsComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.colIsSelected = new Ace.Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn();
            this.colTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colACode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvStockGroupList)).BeginInit();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, -2);
            this.tsbCRUD.Margin = new System.Windows.Forms.Padding(5);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(880, 44);
            this.tsbCRUD.TabIndex = 104;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.DeleteButtonClick += new System.EventHandler(this.tsbCRUD_DeleteButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // txtRecordCount
            // 
            this.txtRecordCount.DecimalPlaces = 0;
            this.txtRecordCount.IsSendTabOnEnter = true;
            this.txtRecordCount.Location = new System.Drawing.Point(122, 700);
            this.txtRecordCount.Margin = new System.Windows.Forms.Padding(4);
            this.txtRecordCount.Name = "txtRecordCount";
            this.txtRecordCount.ReadOnly = true;
            this.txtRecordCount.Size = new System.Drawing.Size(75, 22);
            this.txtRecordCount.TabIndex = 113;
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
            this.lblRecordCount.Location = new System.Drawing.Point(12, 703);
            this.lblRecordCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(99, 17);
            this.lblRecordCount.TabIndex = 112;
            this.lblRecordCount.Text = "Record Count:";
            // 
            // gvStockGroupList
            // 
            this.gvStockGroupList.AllowUserToAddRows = false;
            this.gvStockGroupList.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvStockGroupList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvStockGroupList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvStockGroupList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIsSelected,
            this.colTS,
            this.colProductCode,
            this.colDescription,
            this.colACode,
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
            this.gvStockGroupList.Location = new System.Drawing.Point(15, 204);
            this.gvStockGroupList.Margin = new System.Windows.Forms.Padding(4);
            this.gvStockGroupList.Name = "gvStockGroupList";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvStockGroupList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gvStockGroupList.RowHeadersWidth = 25;
            this.gvStockGroupList.ShowSerialNo = false;
            this.gvStockGroupList.Size = new System.Drawing.Size(842, 487);
            this.gvStockGroupList.TabIndex = 111;
            this.gvStockGroupList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvStockGroupList_CellContentClick);
            this.gvStockGroupList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvStockGroupList_CellFormatting);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(158, 96);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(443, 59);
            this.txtDescription.TabIndex = 110;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(20, 100);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(132, 17);
            this.lblDescription.TabIndex = 109;
            this.lblDescription.Text = "Product Description";
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(158, 61);
            this.txtProductCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(177, 22);
            this.txtProductCode.TabIndex = 106;
            // 
            // lblStockGroupCode
            // 
            this.lblStockGroupCode.AutoSize = true;
            this.lblStockGroupCode.Location = new System.Drawing.Point(20, 64);
            this.lblStockGroupCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStockGroupCode.Name = "lblStockGroupCode";
            this.lblStockGroupCode.Size = new System.Drawing.Size(94, 17);
            this.lblStockGroupCode.TabIndex = 107;
            this.lblStockGroupCode.Text = "Product Code";
            // 
            // lblPrefixCode
            // 
            this.lblPrefixCode.AutoSize = true;
            this.lblPrefixCode.Location = new System.Drawing.Point(20, 171);
            this.lblPrefixCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrefixCode.Name = "lblPrefixCode";
            this.lblPrefixCode.Size = new System.Drawing.Size(126, 17);
            this.lblPrefixCode.TabIndex = 105;
            this.lblPrefixCode.Text = "Related GL ACode";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::Ace.Cbs.Loan.Vew.Properties.Resources.Edit_Main;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 30;
            // 
            // cboGLCode
            // 
            this.cboGLCode.AutoComplete = false;
            this.cboGLCode.AutoDropdown = true;
            this.cboGLCode.BackColor = System.Drawing.SystemColors.Window;
            this.cboGLCode.BackColorEven = System.Drawing.Color.White;
            this.cboGLCode.BackColorOdd = System.Drawing.Color.White;
            this.cboGLCode.ColumnNames = "ACode,ACName";
            this.cboGLCode.ColumnWidthDefault = 300;
            this.cboGLCode.ColumnWidths = "50";
            this.cboGLCode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboGLCode.DropDownHeight = 250;
            this.cboGLCode.DropDownWidth = 100;
            this.cboGLCode.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGLCode.FormattingEnabled = true;
            this.cboGLCode.IntegralHeight = false;
            this.cboGLCode.ItemHeight = 18;
            this.cboGLCode.LinkedColumnIndex = 0;
            this.cboGLCode.LinkedTextBox = null;
            this.cboGLCode.Location = new System.Drawing.Point(158, 167);
            this.cboGLCode.Margin = new System.Windows.Forms.Padding(4);
            this.cboGLCode.MaxDropDownItems = 100;
            this.cboGLCode.Name = "cboGLCode";
            this.cboGLCode.Size = new System.Drawing.Size(177, 24);
            this.cboGLCode.TabIndex = 114;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(343, 171);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 115;
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
            // colProductCode
            // 
            this.colProductCode.DataPropertyName = "ProductCode";
            dataGridViewCellStyle2.NullValue = null;
            this.colProductCode.DefaultCellStyle = dataGridViewCellStyle2;
            this.colProductCode.HeaderText = "ProductCode";
            this.colProductCode.Name = "colProductCode";
            this.colProductCode.ReadOnly = true;
            this.colProductCode.Width = 150;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Product Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 400;
            // 
            // colACode
            // 
            this.colACode.DataPropertyName = "RelatedGLACode";
            this.colACode.HeaderText = "Related GL ACode";
            this.colACode.Name = "colACode";
            this.colACode.Width = 180;
            // 
            // colEdit
            // 
            this.colEdit.HeaderText = "";
            this.colEdit.Image = global::Ace.Cbs.Loan.Vew.Properties.Resources.Edit_Main;
            this.colEdit.Name = "colEdit";
            this.colEdit.Width = 35;
            // 
            // LOMVEW00447
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 730);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboGLCode);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.txtRecordCount);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.gvStockGroupList);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.lblStockGroupCode);
            this.Controls.Add(this.lblPrefixCode);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "LOMVEW00447";
            this.Text = "Personal Loan Product Code Entry";
            this.Load += new System.EventHandler(this.LOMVEW00447_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvStockGroupList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0004 txtRecordCount;
        private Windows.CXClient.Controls.CXC0003 lblRecordCount;
        private Windows.CXClient.Controls.AceGridView gvStockGroupList;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Label lblStockGroupCode;
        private System.Windows.Forms.Label lblPrefixCode;
        private Windows.CXClient.Controls.AceMultiColumnsComboBox cboGLCode;
        private System.Windows.Forms.Label label1;
        private Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn colIsSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colACode;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
    }
}