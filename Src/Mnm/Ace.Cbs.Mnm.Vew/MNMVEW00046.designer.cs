namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00046
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00046));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblRequireYear = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblRequireMonth = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboMonth = new Ace.Windows.CXClient.Controls.CXC0002();
            this.txtYear = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtRecordCount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblRecordCount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblSelectedAccount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtSelectedAccount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtCurrentDate = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gvAccount = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colCheck = new Ace.Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn();
            this.colTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpFrame = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvAccount)).BeginInit();
            this.grpFrame.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-3, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(533, 31);
            this.tsbCRUD.TabIndex = 5;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblRequireYear
            // 
            this.lblRequireYear.AutoSize = true;
            this.lblRequireYear.Location = new System.Drawing.Point(28, 50);
            this.lblRequireYear.Name = "lblRequireYear";
            this.lblRequireYear.Size = new System.Drawing.Size(81, 13);
            this.lblRequireYear.TabIndex = 0;
            this.lblRequireYear.Text = "Required Year :";
            // 
            // lblRequireMonth
            // 
            this.lblRequireMonth.AutoSize = true;
            this.lblRequireMonth.Location = new System.Drawing.Point(28, 76);
            this.lblRequireMonth.Name = "lblRequireMonth";
            this.lblRequireMonth.Size = new System.Drawing.Size(89, 13);
            this.lblRequireMonth.TabIndex = 0;
            this.lblRequireMonth.Text = "Required Month :";
            // 
            // cboMonth
            // 
            this.cboMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMonth.DisplayMember = "1";
            this.cboMonth.DropDownHeight = 200;
            this.cboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.IntegralHeight = false;
            this.cboMonth.IsSendTabOnEnter = true;
            this.cboMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cboMonth.Location = new System.Drawing.Point(125, 73);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(121, 21);
            this.cboMonth.TabIndex = 3;
            this.cboMonth.SelectedIndexChanged += new System.EventHandler(this.cboMonth_SelectedIndexChanged);
            this.cboMonth.Leave += new System.EventHandler(this.cboMonth_Leave);
            // 
            // txtYear
            // 
            this.txtYear.DecimalPlaces = 0;
            this.txtYear.IsSendTabOnEnter = true;
            this.txtYear.Location = new System.Drawing.Point(125, 47);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(100, 20);
            this.txtYear.TabIndex = 2;
            this.txtYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtYear.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtRecordCount
            // 
            this.txtRecordCount.DecimalPlaces = 0;
            this.txtRecordCount.IsSendTabOnEnter = true;
            this.txtRecordCount.Location = new System.Drawing.Point(132, 387);
            this.txtRecordCount.Name = "txtRecordCount";
            this.txtRecordCount.ReadOnly = true;
            this.txtRecordCount.Size = new System.Drawing.Size(57, 20);
            this.txtRecordCount.TabIndex = 39;
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
            this.lblRecordCount.Location = new System.Drawing.Point(27, 390);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(88, 13);
            this.lblRecordCount.TabIndex = 38;
            this.lblRecordCount.Text = "Total Account(s):";
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(28, 24);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(73, 13);
            this.lblAccountNo.TabIndex = 0;
            this.lblAccountNo.Text = "Account No. :";
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.CausesValidation = false;
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(125, 21);
            this.mtxtAccountNo.Mask = "999-999-999999999";
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 1;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblSelectedAccount
            // 
            this.lblSelectedAccount.AutoSize = true;
            this.lblSelectedAccount.Location = new System.Drawing.Point(297, 390);
            this.lblSelectedAccount.Name = "lblSelectedAccount";
            this.lblSelectedAccount.Size = new System.Drawing.Size(106, 13);
            this.lblSelectedAccount.TabIndex = 38;
            this.lblSelectedAccount.Text = "Selected Account(s):";
            // 
            // txtSelectedAccount
            // 
            this.txtSelectedAccount.DecimalPlaces = 0;
            this.txtSelectedAccount.IsSendTabOnEnter = true;
            this.txtSelectedAccount.Location = new System.Drawing.Point(410, 386);
            this.txtSelectedAccount.Name = "txtSelectedAccount";
            this.txtSelectedAccount.ReadOnly = true;
            this.txtSelectedAccount.Size = new System.Drawing.Size(57, 20);
            this.txtSelectedAccount.TabIndex = 39;
            this.txtSelectedAccount.Text = "0";
            this.txtSelectedAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSelectedAccount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtCurrentDate
            // 
            this.txtCurrentDate.DecimalPlaces = 0;
            this.txtCurrentDate.IsSendTabOnEnter = true;
            this.txtCurrentDate.Location = new System.Drawing.Point(376, 20);
            this.txtCurrentDate.Name = "txtCurrentDate";
            this.txtCurrentDate.ReadOnly = true;
            this.txtCurrentDate.Size = new System.Drawing.Size(102, 20);
            this.txtCurrentDate.TabIndex = 0;
            this.txtCurrentDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCurrentDate.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(334, 23);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(36, 13);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Date :";
            // 
            // gvAccount
            // 
            this.gvAccount.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvAccount.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAccount.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.colTS,
            this.colAccountNo,
            this.colName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvAccount.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvAccount.EnableHeadersVisualStyles = false;
            this.gvAccount.IdTSList = null;
            this.gvAccount.IsEscapeKey = false;
            this.gvAccount.IsHeaderClick = false;
            this.gvAccount.Location = new System.Drawing.Point(25, 101);
            this.gvAccount.Name = "gvAccount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvAccount.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gvAccount.RowHeadersWidth = 25;
            this.gvAccount.ShowSerialNo = false;
            this.gvAccount.Size = new System.Drawing.Size(454, 279);
            this.gvAccount.TabIndex = 4;
            this.gvAccount.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvAccount_CellValueChanged);
            this.gvAccount.CurrentCellDirtyStateChanged += new System.EventHandler(this.gvAccount_CurrentCellDirtyStateChanged);
            // 
            // colCheck
            // 
            this.colCheck.CheckBoxHeader = false;
            this.colCheck.DataPropertyName = "IsCheck";
            this.colCheck.FalseValue = "false";
            this.colCheck.HeaderText = "";
            this.colCheck.Id = 0;
            this.colCheck.Name = "colCheck";
            this.colCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCheck.TrueValue = "true";
            this.colCheck.TS = null;
            this.colCheck.Width = 30;
            // 
            // colTS
            // 
            this.colTS.DataPropertyName = "TS";
            this.colTS.HeaderText = "TS";
            this.colTS.Name = "colTS";
            this.colTS.Visible = false;
            // 
            // colAccountNo
            // 
            this.colAccountNo.DataPropertyName = "AccountNo";
            this.colAccountNo.HeaderText = "Account No";
            this.colAccountNo.Name = "colAccountNo";
            this.colAccountNo.ReadOnly = true;
            this.colAccountNo.Width = 150;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 200;
            // 
            // grpFrame
            // 
            this.grpFrame.Controls.Add(this.gvAccount);
            this.grpFrame.Controls.Add(this.cboMonth);
            this.grpFrame.Controls.Add(this.lblDate);
            this.grpFrame.Controls.Add(this.lblRequireYear);
            this.grpFrame.Controls.Add(this.txtCurrentDate);
            this.grpFrame.Controls.Add(this.lblAccountNo);
            this.grpFrame.Controls.Add(this.mtxtAccountNo);
            this.grpFrame.Controls.Add(this.lblRequireMonth);
            this.grpFrame.Controls.Add(this.txtSelectedAccount);
            this.grpFrame.Controls.Add(this.txtYear);
            this.grpFrame.Controls.Add(this.lblSelectedAccount);
            this.grpFrame.Controls.Add(this.lblRecordCount);
            this.grpFrame.Controls.Add(this.txtRecordCount);
            this.grpFrame.Location = new System.Drawing.Point(10, 37);
            this.grpFrame.Name = "grpFrame";
            this.grpFrame.Size = new System.Drawing.Size(505, 419);
            this.grpFrame.TabIndex = 0;
            this.grpFrame.TabStop = false;
            // 
            // MNMVEW00046
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 468);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.grpFrame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MNMVEW00046";
            this.Text = "Bank Statement Listing";
            this.Load += new System.EventHandler(this.MNMVEW00046_Load);
            this.Move += new System.EventHandler(this.MNMVEW00046_Move);
            ((System.ComponentModel.ISupportInitialize)(this.gvAccount)).EndInit();
            this.grpFrame.ResumeLayout(false);
            this.grpFrame.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0003 lblRequireYear;
        private Windows.CXClient.Controls.CXC0003 lblRequireMonth;
        private Windows.CXClient.Controls.CXC0002 cboMonth;
        private Windows.CXClient.Controls.CXC0004 txtYear;
        private Windows.CXClient.Controls.CXC0004 txtRecordCount;
        private Windows.CXClient.Controls.CXC0003 lblRecordCount;
        private Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblSelectedAccount;
        private Windows.CXClient.Controls.CXC0004 txtSelectedAccount;
        private Windows.CXClient.Controls.CXC0004 txtCurrentDate;
        private Windows.CXClient.Controls.CXC0003 lblDate;
        private Windows.CXClient.Controls.AceGridView gvAccount;
        private Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.GroupBox grpFrame;
    }
}