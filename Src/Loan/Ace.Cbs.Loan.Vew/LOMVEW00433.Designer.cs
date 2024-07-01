namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00433
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
            this.cxC00033 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboUser = new Ace.Windows.CXClient.Controls.CXC0002();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Select = new Ace.Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn();
            this.OptEntryUser = new System.Windows.Forms.RadioButton();
            this.OptApproveUser = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.optBoth = new System.Windows.Forms.RadioButton();
            this.lblBudgetYear = new Ace.Windows.CXClient.Controls.CXC0003();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cxC00033
            // 
            this.cxC00033.AutoSize = true;
            this.cxC00033.Location = new System.Drawing.Point(28, 19);
            this.cxC00033.Name = "cxC00033";
            this.cxC00033.Size = new System.Drawing.Size(66, 13);
            this.cxC00033.TabIndex = 145;
            this.cxC00033.Text = "User Name :";
            // 
            // cboUser
            // 
            this.cboUser.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboUser.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboUser.DropDownHeight = 200;
            this.cboUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUser.FormattingEnabled = true;
            this.cboUser.IntegralHeight = false;
            this.cboUser.IsSendTabOnEnter = true;
            this.cboUser.ItemHeight = 13;
            this.cboUser.Location = new System.Drawing.Point(109, 16);
            this.cboUser.Name = "cboUser";
            this.cboUser.Size = new System.Drawing.Size(206, 21);
            this.cboUser.TabIndex = 8;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(525, 36);
            this.tsbCRUD.TabIndex = 147;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.DeleteButtonClick += new System.EventHandler(this.tsbCRUD_DeleteButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvUser);
            this.groupBox2.Location = new System.Drawing.Point(3, 114);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(506, 184);
            this.groupBox2.TabIndex = 150;
            this.groupBox2.TabStop = false;
            // 
            // dgvUser
            // 
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.UserName1,
            this.UserType,
            this.Id,
            this.Select});
            this.dgvUser.Location = new System.Drawing.Point(6, 15);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.RowHeadersVisible = false;
            this.dgvUser.Size = new System.Drawing.Size(493, 163);
            this.dgvUser.TabIndex = 152;
            // 
            // No
            // 
            this.No.DataPropertyName = "No";
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.Width = 30;
            // 
            // UserName1
            // 
            this.UserName1.DataPropertyName = "UserName";
            this.UserName1.HeaderText = "User Name";
            this.UserName1.Name = "UserName1";
            this.UserName1.Width = 230;
            // 
            // UserType
            // 
            this.UserType.DataPropertyName = "UserType";
            this.UserType.HeaderText = "User Type";
            this.UserType.Name = "UserType";
            this.UserType.Width = 170;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            this.Id.Width = 20;
            // 
            // Select
            // 
            this.Select.CheckBoxHeader = false;
            this.Select.DataPropertyName = "Select";
            this.Select.FalseValue = "false";
            this.Select.HeaderText = "";
            this.Select.Id = 0;
            this.Select.Name = "Select";
            this.Select.TrueValue = "true";
            this.Select.TS = null;
            this.Select.Width = 50;
            // 
            // OptEntryUser
            // 
            this.OptEntryUser.AutoSize = true;
            this.OptEntryUser.Checked = true;
            this.OptEntryUser.Location = new System.Drawing.Point(69, 46);
            this.OptEntryUser.Name = "OptEntryUser";
            this.OptEntryUser.Size = new System.Drawing.Size(74, 17);
            this.OptEntryUser.TabIndex = 6;
            this.OptEntryUser.TabStop = true;
            this.OptEntryUser.Text = "Entry User";
            this.OptEntryUser.UseVisualStyleBackColor = true;
            this.OptEntryUser.CheckedChanged += new System.EventHandler(this.OptEntryUser_CheckedChanged);
            // 
            // OptApproveUser
            // 
            this.OptApproveUser.AutoSize = true;
            this.OptApproveUser.Location = new System.Drawing.Point(151, 48);
            this.OptApproveUser.Name = "OptApproveUser";
            this.OptApproveUser.Size = new System.Drawing.Size(90, 17);
            this.OptApproveUser.TabIndex = 7;
            this.OptApproveUser.Text = "Approve User";
            this.OptApproveUser.UseVisualStyleBackColor = true;
            this.OptApproveUser.CheckedChanged += new System.EventHandler(this.OptApproveUser_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.optBoth);
            this.groupBox3.Controls.Add(this.cxC00033);
            this.groupBox3.Controls.Add(this.OptEntryUser);
            this.groupBox3.Controls.Add(this.cboUser);
            this.groupBox3.Controls.Add(this.OptApproveUser);
            this.groupBox3.Location = new System.Drawing.Point(6, 36);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(504, 78);
            this.groupBox3.TabIndex = 151;
            this.groupBox3.TabStop = false;
            // 
            // optBoth
            // 
            this.optBoth.AutoSize = true;
            this.optBoth.Location = new System.Drawing.Point(251, 47);
            this.optBoth.Name = "optBoth";
            this.optBoth.Size = new System.Drawing.Size(47, 17);
            this.optBoth.TabIndex = 146;
            this.optBoth.Text = "Both";
            this.optBoth.UseVisualStyleBackColor = true;
            this.optBoth.CheckedChanged += new System.EventHandler(this.optBoth_CheckedChanged);
            // 
            // lblBudgetYear
            // 
            this.lblBudgetYear.AutoSize = true;
            this.lblBudgetYear.ForeColor = System.Drawing.Color.Black;
            this.lblBudgetYear.Location = new System.Drawing.Point(397, 38);
            this.lblBudgetYear.Name = "lblBudgetYear";
            this.lblBudgetYear.Size = new System.Drawing.Size(0, 13);
            this.lblBudgetYear.TabIndex = 148;
            // 
            // LOMVEW00433
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 301);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblBudgetYear);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LOMVEW00433";
            this.Text = "Maker/Checker Entry";
            this.Load += new System.EventHandler(this.LOMVEW00433_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0003 cxC00033;
        private Windows.CXClient.Controls.CXC0002 cboUser;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.RadioButton OptEntryUser;
        private System.Windows.Forms.RadioButton OptApproveUser;
        private System.Windows.Forms.GroupBox groupBox3;
        private Windows.CXClient.Controls.CXC0003 lblBudgetYear;
        private System.Windows.Forms.RadioButton optBoth;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn Select;
    }
}