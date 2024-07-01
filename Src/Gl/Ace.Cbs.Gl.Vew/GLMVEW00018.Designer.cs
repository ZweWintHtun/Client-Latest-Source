namespace Ace.Cbs.Gl.Vew
{
    partial class GLMVEW00018
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GLMVEW00018));
            this.btnInsertRange = new Ace.Windows.CXClient.Controls.CXC0007();
            this.btnFind = new Ace.Windows.CXClient.Controls.CXC0007();
            this.btnDeleteRange = new Ace.Windows.CXClient.Controls.CXC0007();
            this.butDeleteLine = new Ace.Windows.CXClient.Controls.CXC0007();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gvFormatStyle = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colLineNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboAccountCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cboDepartment = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHide = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colAmountTotal = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colFormula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNormal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.butInsertLine = new Ace.Windows.CXClient.Controls.CXC0007();
            ((System.ComponentModel.ISupportInitialize)(this.gvFormatStyle)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInsertRange
            // 
            this.btnInsertRange.Location = new System.Drawing.Point(406, 287);
            this.btnInsertRange.Name = "btnInsertRange";
            this.btnInsertRange.Size = new System.Drawing.Size(89, 26);
            this.btnInsertRange.TabIndex = 20;
            this.btnInsertRange.Text = "Insert &Range";
            this.btnInsertRange.UseVisualStyleBackColor = true;
            this.btnInsertRange.Click += new System.EventHandler(this.btnInsertRange_Click);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(691, 287);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(89, 26);
            this.btnFind.TabIndex = 19;
            this.btnFind.Text = "&Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnDeleteRange
            // 
            this.btnDeleteRange.Location = new System.Drawing.Point(596, 287);
            this.btnDeleteRange.Name = "btnDeleteRange";
            this.btnDeleteRange.Size = new System.Drawing.Size(89, 26);
            this.btnDeleteRange.TabIndex = 18;
            this.btnDeleteRange.Text = "&Delete Range";
            this.btnDeleteRange.UseVisualStyleBackColor = true;
            this.btnDeleteRange.Click += new System.EventHandler(this.btnDeleteRange_Click);
            // 
            // butDeleteLine
            // 
            this.butDeleteLine.Location = new System.Drawing.Point(501, 287);
            this.butDeleteLine.Name = "butDeleteLine";
            this.butDeleteLine.Size = new System.Drawing.Size(89, 26);
            this.butDeleteLine.TabIndex = 17;
            this.butDeleteLine.Text = "Delete &Line";
            this.butDeleteLine.UseVisualStyleBackColor = true;
            this.butDeleteLine.Click += new System.EventHandler(this.butDeleteLine_Click);
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(796, 31);
            this.tsbCRUD.TabIndex = 15;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // gvFormatStyle
            // 
            this.gvFormatStyle.AllowDrop = true;
            this.gvFormatStyle.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvFormatStyle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvFormatStyle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvFormatStyle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLineNo,
            this.cboAccountCode,
            this.cboDepartment,
            this.colDescription,
            this.colHide,
            this.colAmountTotal,
            this.colFormula,
            this.colStatus,
            this.colNormal});
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
            this.gvFormatStyle.Location = new System.Drawing.Point(13, 38);
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
            this.gvFormatStyle.ShowSerialNo = false;
            this.gvFormatStyle.Size = new System.Drawing.Size(767, 243);
            this.gvFormatStyle.TabIndex = 16;
            this.gvFormatStyle.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvFormatStyle_CellClick);
            this.gvFormatStyle.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvFormatStyle_CellLeave);
            this.gvFormatStyle.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gvFormatStyle_DataError);
            // 
            // colLineNo
            // 
            this.colLineNo.DataPropertyName = "LineNo";
            this.colLineNo.HeaderText = "Line";
            this.colLineNo.Name = "colLineNo";
            this.colLineNo.Width = 50;
            // 
            // cboAccountCode
            // 
            this.cboAccountCode.DataPropertyName = "ACode";
            this.cboAccountCode.HeaderText = "Account";
            this.cboAccountCode.Name = "cboAccountCode";
            this.cboAccountCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // cboDepartment
            // 
            this.cboDepartment.DataPropertyName = "BranchCode";
            this.cboDepartment.HeaderText = "Dept";
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cboDepartment.Width = 50;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Description(English)";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 200;
            // 
            // colHide
            // 
            this.colHide.DataPropertyName = "ShowHide";
            this.colHide.HeaderText = "Hide";
            this.colHide.Items.AddRange(new object[] {
            "Y",
            "N"});
            this.colHide.Name = "colHide";
            this.colHide.Width = 50;
            // 
            // colAmountTotal
            // 
            this.colAmountTotal.DataPropertyName = "AmountTotal";
            this.colAmountTotal.HeaderText = "Column";
            this.colAmountTotal.Items.AddRange(new object[] {
            "Amount",
            "Total"});
            this.colAmountTotal.Name = "colAmountTotal";
            // 
            // colFormula
            // 
            this.colFormula.DataPropertyName = "Other";
            this.colFormula.HeaderText = "Formula";
            this.colFormula.Name = "colFormula";
            this.colFormula.ReadOnly = true;
            this.colFormula.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colFormula.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colFormula.Width = 150;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Visible = false;
            // 
            // colNormal
            // 
            this.colNormal.DataPropertyName = "Normal";
            this.colNormal.HeaderText = "";
            this.colNormal.Name = "colNormal";
            this.colNormal.Visible = false;
            // 
            // butInsertLine
            // 
            this.butInsertLine.Location = new System.Drawing.Point(311, 287);
            this.butInsertLine.Name = "butInsertLine";
            this.butInsertLine.Size = new System.Drawing.Size(89, 26);
            this.butInsertLine.TabIndex = 21;
            this.butInsertLine.Text = "&Insert Line";
            this.butInsertLine.UseVisualStyleBackColor = true;
            this.butInsertLine.Click += new System.EventHandler(this.butInsertLine_Click);
            // 
            // GLMVEW00018
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 326);
            this.Controls.Add(this.btnInsertRange);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnDeleteRange);
            this.Controls.Add(this.butDeleteLine);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.gvFormatStyle);
            this.Controls.Add(this.butInsertLine);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GLMVEW00018";
            this.Text = "Format And Formula Entry";
            this.Load += new System.EventHandler(this.GLMVEW00018_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvFormatStyle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXC0007 btnInsertRange;
        private Windows.CXClient.Controls.CXC0007 btnFind;
        private Windows.CXClient.Controls.CXC0007 btnDeleteRange;
        private Windows.CXClient.Controls.CXC0007 butDeleteLine;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.AceGridView gvFormatStyle;
        private Windows.CXClient.Controls.CXC0007 butInsertLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLineNo;
        private System.Windows.Forms.DataGridViewComboBoxColumn cboAccountCode;
        private System.Windows.Forms.DataGridViewComboBoxColumn cboDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewComboBoxColumn colHide;
        private System.Windows.Forms.DataGridViewComboBoxColumn colAmountTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFormula;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNormal;
    }
}