namespace Ace.Cbs.Gl.Vew
{
    partial class GLMVEW00027
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblStartDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.dtpRequiredDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.grpSortBy = new System.Windows.Forms.GroupBox();
            this.dgvData2 = new System.Windows.Forms.DataGridView();
            this.dgvData1 = new System.Windows.Forms.DataGridView();
            this.rdoGeneralReturn = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoIncomeAndExpenditure = new Ace.Windows.CXClient.Controls.CXC0009();
            this.gpBranchInfo = new System.Windows.Forms.GroupBox();
            this.chkBranch = new Ace.Windows.CXClient.Controls.CXC0008();
            this.lblBranchNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboBranchNo = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblBranch = new Ace.Windows.CXClient.Controls.CXC0003();
            this.grpSortBy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData1)).BeginInit();
            this.gpBranchInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-2, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(497, 31);
            this.tsbCRUD.TabIndex = 6;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(17, 69);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(92, 13);
            this.lblStartDate.TabIndex = 46;
            this.lblStartDate.Text = "Required Month  :";
            // 
            // dtpRequiredDate
            // 
            this.dtpRequiredDate.CustomFormat = "MMM/yyyy";
            this.dtpRequiredDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRequiredDate.IsSendTabOnEnter = true;
            this.dtpRequiredDate.Location = new System.Drawing.Point(115, 63);
            this.dtpRequiredDate.Name = "dtpRequiredDate";
            this.dtpRequiredDate.Size = new System.Drawing.Size(115, 20);
            this.dtpRequiredDate.TabIndex = 5;
            // 
            // grpSortBy
            // 
            this.grpSortBy.Controls.Add(this.dgvData2);
            this.grpSortBy.Controls.Add(this.dgvData1);
            this.grpSortBy.Controls.Add(this.lblStartDate);
            this.grpSortBy.Controls.Add(this.rdoGeneralReturn);
            this.grpSortBy.Controls.Add(this.dtpRequiredDate);
            this.grpSortBy.Controls.Add(this.rdoIncomeAndExpenditure);
            this.grpSortBy.Location = new System.Drawing.Point(8, 122);
            this.grpSortBy.Name = "grpSortBy";
            this.grpSortBy.Size = new System.Drawing.Size(464, 98);
            this.grpSortBy.TabIndex = 43;
            this.grpSortBy.TabStop = false;
            this.grpSortBy.Text = "Monthly Posting Reports:";
            // 
            // dgvData2
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData2.Location = new System.Drawing.Point(357, 50);
            this.dgvData2.Name = "dgvData2";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData2.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvData2.Size = new System.Drawing.Size(101, 44);
            this.dgvData2.TabIndex = 48;
            this.dgvData2.Visible = false;
            // 
            // dgvData1
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvData1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvData1.Location = new System.Drawing.Point(248, 50);
            this.dgvData1.Name = "dgvData1";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvData1.Size = new System.Drawing.Size(103, 44);
            this.dgvData1.TabIndex = 47;
            this.dgvData1.Visible = false;
            // 
            // rdoGeneralReturn
            // 
            this.rdoGeneralReturn.AutoSize = true;
            this.rdoGeneralReturn.IsSendTabOnEnter = true;
            this.rdoGeneralReturn.Location = new System.Drawing.Point(199, 27);
            this.rdoGeneralReturn.Name = "rdoGeneralReturn";
            this.rdoGeneralReturn.Size = new System.Drawing.Size(97, 17);
            this.rdoGeneralReturn.TabIndex = 4;
            this.rdoGeneralReturn.Text = "General Return";
            this.rdoGeneralReturn.UseVisualStyleBackColor = true;
            this.rdoGeneralReturn.Click += new System.EventHandler(this.rdoGeneralReturn_Click);
            // 
            // rdoIncomeAndExpenditure
            // 
            this.rdoIncomeAndExpenditure.AutoSize = true;
            this.rdoIncomeAndExpenditure.Checked = true;
            this.rdoIncomeAndExpenditure.IsSendTabOnEnter = true;
            this.rdoIncomeAndExpenditure.Location = new System.Drawing.Point(20, 27);
            this.rdoIncomeAndExpenditure.Name = "rdoIncomeAndExpenditure";
            this.rdoIncomeAndExpenditure.Size = new System.Drawing.Size(141, 17);
            this.rdoIncomeAndExpenditure.TabIndex = 3;
            this.rdoIncomeAndExpenditure.TabStop = true;
            this.rdoIncomeAndExpenditure.Text = "Income And Expenditure";
            this.rdoIncomeAndExpenditure.UseVisualStyleBackColor = true;
            this.rdoIncomeAndExpenditure.Click += new System.EventHandler(this.rdoIncomeAndExpenditure_Click);
            // 
            // gpBranchInfo
            // 
            this.gpBranchInfo.Controls.Add(this.chkBranch);
            this.gpBranchInfo.Controls.Add(this.lblBranchNo);
            this.gpBranchInfo.Controls.Add(this.cboBranchNo);
            this.gpBranchInfo.Controls.Add(this.lblBranch);
            this.gpBranchInfo.Location = new System.Drawing.Point(8, 37);
            this.gpBranchInfo.Name = "gpBranchInfo";
            this.gpBranchInfo.Size = new System.Drawing.Size(464, 81);
            this.gpBranchInfo.TabIndex = 72;
            this.gpBranchInfo.TabStop = false;
            this.gpBranchInfo.Text = "Branch";
            // 
            // chkBranch
            // 
            this.chkBranch.AutoSize = true;
            this.chkBranch.IsSendTabOnEnter = true;
            this.chkBranch.Location = new System.Drawing.Point(30, 20);
            this.chkBranch.Name = "chkBranch";
            this.chkBranch.Size = new System.Drawing.Size(77, 17);
            this.chkBranch.TabIndex = 1;
            this.chkBranch.Text = "All Branch.";
            this.chkBranch.UseVisualStyleBackColor = true;
            this.chkBranch.Visible = false;
            this.chkBranch.CheckedChanged += new System.EventHandler(this.chkBranch_CheckedChanged);
            // 
            // lblBranchNo
            // 
            this.lblBranchNo.AutoSize = true;
            this.lblBranchNo.Location = new System.Drawing.Point(113, 46);
            this.lblBranchNo.Name = "lblBranchNo";
            this.lblBranchNo.Size = new System.Drawing.Size(65, 13);
            this.lblBranchNo.TabIndex = 17;
            this.lblBranchNo.Text = "lblBranchNo";
            this.lblBranchNo.Visible = false;
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
            this.cboBranchNo.Location = new System.Drawing.Point(116, 43);
            this.cboBranchNo.Name = "cboBranchNo";
            this.cboBranchNo.Size = new System.Drawing.Size(141, 21);
            this.cboBranchNo.TabIndex = 2;
            this.cboBranchNo.Visible = false;
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Location = new System.Drawing.Point(27, 45);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(87, 13);
            this.lblBranch.TabIndex = 0;
            this.lblBranch.Text = "Source Branch : ";
            // 
            // GLMVEW00027
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 230);
            this.Controls.Add(this.gpBranchInfo);
            this.Controls.Add(this.grpSortBy);
            this.Controls.Add(this.tsbCRUD);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GLMVEW00027";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monthly Posting Reports";
            this.Load += new System.EventHandler(this.GLMVEW00027_Load);
            this.grpSortBy.ResumeLayout(false);
            this.grpSortBy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData1)).EndInit();
            this.gpBranchInfo.ResumeLayout(false);
            this.gpBranchInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0003 lblStartDate;
        private Windows.CXClient.Controls.CXC0005 dtpRequiredDate;
        private System.Windows.Forms.GroupBox grpSortBy;
        private Windows.CXClient.Controls.CXC0009 rdoGeneralReturn;
        private Windows.CXClient.Controls.CXC0009 rdoIncomeAndExpenditure;
        private System.Windows.Forms.DataGridView dgvData1;
        private System.Windows.Forms.DataGridView dgvData2;
        private System.Windows.Forms.GroupBox gpBranchInfo;
        private Windows.CXClient.Controls.CXC0008 chkBranch;
        private Windows.CXClient.Controls.CXC0003 lblBranchNo;
        private Windows.CXClient.Controls.CXC0002 cboBranchNo;
        private Windows.CXClient.Controls.CXC0003 lblBranch;
    }
}