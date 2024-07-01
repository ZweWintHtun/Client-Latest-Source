namespace Ace.Cbs.Sam.Vew
{
    partial class SAMVEW00049
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAMVEW00049));
            this.txtName = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gvSystemDefine = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colIsSelected = new Ace.Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn();
            this.colTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBranchCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtRecordCount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblRecordCount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.cboBranchNo = new Ace.Windows.CXClient.Controls.CXC0002();
            this.chkAllBranch = new Ace.Windows.CXClient.Controls.CXC0008();
            ((System.ComponentModel.ISupportInitialize)(this.gvSystemDefine)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.IsSendTabOnEnter = true;
            this.txtName.Location = new System.Drawing.Point(98, 43);
            this.txtName.MaxLength = 25;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(220, 20);
            this.txtName.TabIndex = 1;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 45);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name :";
            // 
            // gvSystemDefine
            // 
            this.gvSystemDefine.AllowUserToAddRows = false;
            this.gvSystemDefine.CausesValidation = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvSystemDefine.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvSystemDefine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSystemDefine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIsSelected,
            this.colTS,
            this.colName,
            this.ColBranchCode,
            this.colEdit});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvSystemDefine.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvSystemDefine.EnableHeadersVisualStyles = false;
            this.gvSystemDefine.IdTSList = null;
            this.gvSystemDefine.IsEscapeKey = false;
            this.gvSystemDefine.IsHeaderClick = false;
            this.gvSystemDefine.Location = new System.Drawing.Point(15, 98);
            this.gvSystemDefine.Name = "gvSystemDefine";
            this.gvSystemDefine.RowHeadersWidth = 25;
            this.gvSystemDefine.ShowSerialNo = false;
            this.gvSystemDefine.Size = new System.Drawing.Size(580, 410);
            this.gvSystemDefine.TabIndex = 0;
            this.gvSystemDefine.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVSys001_CellContentClick);
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
            this.colTS.HeaderText = "";
            this.colTS.Name = "colTS";
            this.colTS.Visible = false;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 300;
            // 
            // ColBranchCode
            // 
            this.ColBranchCode.DataPropertyName = "BranchCode";
            this.ColBranchCode.HeaderText = "BranchCode";
            this.ColBranchCode.Name = "ColBranchCode";
            this.ColBranchCode.Width = 150;
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
            this.txtRecordCount.Location = new System.Drawing.Point(98, 517);
            this.txtRecordCount.Name = "txtRecordCount";
            this.txtRecordCount.ReadOnly = true;
            this.txtRecordCount.Size = new System.Drawing.Size(57, 20);
            this.txtRecordCount.TabIndex = 4;
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
            this.lblRecordCount.Location = new System.Drawing.Point(12, 520);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(76, 13);
            this.lblRecordCount.TabIndex = 0;
            this.lblRecordCount.Text = "Record Count:";
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
            this.tsbCRUD.Size = new System.Drawing.Size(618, 31);
            this.tsbCRUD.TabIndex = 4;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.DeleteButtonClick += new System.EventHandler(this.tsbCRUD_DeleteButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // cboBranchNo
            // 
            this.cboBranchNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboBranchNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBranchNo.DropDownHeight = 200;
            this.cboBranchNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBranchNo.FormattingEnabled = true;
            this.cboBranchNo.IntegralHeight = false;
            this.cboBranchNo.IsSendTabOnEnter = true;
            this.cboBranchNo.Location = new System.Drawing.Point(98, 69);
            this.cboBranchNo.Name = "cboBranchNo";
            this.cboBranchNo.Size = new System.Drawing.Size(119, 21);
            this.cboBranchNo.TabIndex = 3;
            this.cboBranchNo.Validated += new System.EventHandler(this.cboBranchNo_Validated);
            // 
            // chkAllBranch
            // 
            this.chkAllBranch.AutoSize = true;
            this.chkAllBranch.IsSendTabOnEnter = true;
            this.chkAllBranch.Location = new System.Drawing.Point(233, 71);
            this.chkAllBranch.Name = "chkAllBranch";
            this.chkAllBranch.Size = new System.Drawing.Size(85, 17);
            this.chkAllBranch.TabIndex = 2;
            this.chkAllBranch.Text = "All Branches";
            this.chkAllBranch.UseVisualStyleBackColor = true;
            this.chkAllBranch.CheckedChanged += new System.EventHandler(this.chkAllBranch_CheckedChanged);
            // 
            // SAMVEW00049
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 557);
            this.Controls.Add(this.chkAllBranch);
            this.Controls.Add(this.cboBranchNo);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.txtRecordCount);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.gvSystemDefine);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SAMVEW00049";
            this.Text = "System Define Entry";
            this.Load += new System.EventHandler(this.SAMVEW00049_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvSystemDefine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0001 txtName;
        private Windows.CXClient.Controls.CXC0003 lblName;
        private Windows.CXClient.Controls.AceGridView gvSystemDefine;
        private Windows.CXClient.Controls.CXC0004 txtRecordCount;
        private Windows.CXClient.Controls.CXC0003 lblRecordCount;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0002 cboBranchNo;
        private Windows.CXClient.Controls.CXC0008 chkAllBranch;
        private Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn colIsSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBranchCode;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
    }
}