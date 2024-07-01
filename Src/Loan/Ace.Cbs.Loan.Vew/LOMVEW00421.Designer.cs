namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00421
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00421));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBLType = new Ace.Windows.CXClient.Controls.CXC0001();
            this.cxC00037 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.cxC00036 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtBLDuration = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtBLNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtNRC = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtName = new Ace.Windows.CXClient.Controls.CXC0001();
            this.cxC00035 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00033 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00034 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvBLRepayHistory = new System.Windows.Forms.DataGridView();
            this.TermNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalLateDayWithDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBLRepayHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBLType);
            this.groupBox1.Controls.Add(this.cxC00037);
            this.groupBox1.Controls.Add(this.mtxtAccountNo);
            this.groupBox1.Controls.Add(this.cxC00036);
            this.groupBox1.Controls.Add(this.txtBLDuration);
            this.groupBox1.Controls.Add(this.txtBLNo);
            this.groupBox1.Controls.Add(this.txtNRC);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.cxC00035);
            this.groupBox1.Controls.Add(this.cxC00033);
            this.groupBox1.Controls.Add(this.cxC00032);
            this.groupBox1.Controls.Add(this.cxC00031);
            this.groupBox1.Controls.Add(this.cxC00034);
            this.groupBox1.Location = new System.Drawing.Point(4, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 186);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtBLType
            // 
            this.txtBLType.IsSendTabOnEnter = true;
            this.txtBLType.Location = new System.Drawing.Point(127, 129);
            this.txtBLType.MaxLength = 15;
            this.txtBLType.Name = "txtBLType";
            this.txtBLType.ReadOnly = true;
            this.txtBLType.Size = new System.Drawing.Size(180, 20);
            this.txtBLType.TabIndex = 106;
            this.txtBLType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cxC00037
            // 
            this.cxC00037.AutoSize = true;
            this.cxC00037.Location = new System.Drawing.Point(22, 132);
            this.cxC00037.Name = "cxC00037";
            this.cxC00037.Size = new System.Drawing.Size(112, 13);
            this.cxC00037.TabIndex = 107;
            this.cxC00037.Text = "Business Loan Type : ";
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(127, 26);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(179, 20);
            this.mtxtAccountNo.TabIndex = 93;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtxtAccountNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtxtAccountNo_KeyDown);
            // 
            // cxC00036
            // 
            this.cxC00036.AutoSize = true;
            this.cxC00036.Location = new System.Drawing.Point(312, 158);
            this.cxC00036.Name = "cxC00036";
            this.cxC00036.Size = new System.Drawing.Size(42, 13);
            this.cxC00036.TabIndex = 105;
            this.cxC00036.Text = "Months";
            // 
            // txtBLDuration
            // 
            this.txtBLDuration.IsSendTabOnEnter = true;
            this.txtBLDuration.Location = new System.Drawing.Point(126, 155);
            this.txtBLDuration.MaxLength = 15;
            this.txtBLDuration.Name = "txtBLDuration";
            this.txtBLDuration.ReadOnly = true;
            this.txtBLDuration.Size = new System.Drawing.Size(180, 20);
            this.txtBLDuration.TabIndex = 97;
            this.txtBLDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBLNo
            // 
            this.txtBLNo.IsSendTabOnEnter = true;
            this.txtBLNo.Location = new System.Drawing.Point(127, 104);
            this.txtBLNo.MaxLength = 15;
            this.txtBLNo.Name = "txtBLNo";
            this.txtBLNo.ReadOnly = true;
            this.txtBLNo.Size = new System.Drawing.Size(180, 20);
            this.txtBLNo.TabIndex = 96;
            this.txtBLNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNRC
            // 
            this.txtNRC.IsSendTabOnEnter = true;
            this.txtNRC.Location = new System.Drawing.Point(126, 78);
            this.txtNRC.MaxLength = 15;
            this.txtNRC.Name = "txtNRC";
            this.txtNRC.ReadOnly = true;
            this.txtNRC.Size = new System.Drawing.Size(180, 20);
            this.txtNRC.TabIndex = 95;
            this.txtNRC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtName
            // 
            this.txtName.IsSendTabOnEnter = true;
            this.txtName.Location = new System.Drawing.Point(127, 52);
            this.txtName.MaxLength = 15;
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(263, 20);
            this.txtName.TabIndex = 94;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cxC00035
            // 
            this.cxC00035.AutoSize = true;
            this.cxC00035.Location = new System.Drawing.Point(22, 158);
            this.cxC00035.Name = "cxC00035";
            this.cxC00035.Size = new System.Drawing.Size(81, 13);
            this.cxC00035.TabIndex = 102;
            this.cxC00035.Text = "Loans Period  : ";
            // 
            // cxC00033
            // 
            this.cxC00033.AutoSize = true;
            this.cxC00033.Location = new System.Drawing.Point(22, 107);
            this.cxC00033.Name = "cxC00033";
            this.cxC00033.Size = new System.Drawing.Size(102, 13);
            this.cxC00033.TabIndex = 101;
            this.cxC00033.Text = "Business Loan No : ";
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.Location = new System.Drawing.Point(22, 78);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(39, 13);
            this.cxC00032.TabIndex = 100;
            this.cxC00032.Text = "NRC : ";
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(22, 55);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(41, 13);
            this.cxC00031.TabIndex = 99;
            this.cxC00031.Text = "Name :";
            // 
            // cxC00034
            // 
            this.cxC00034.AutoSize = true;
            this.cxC00034.Location = new System.Drawing.Point(22, 29);
            this.cxC00034.Name = "cxC00034";
            this.cxC00034.Size = new System.Drawing.Size(67, 13);
            this.cxC00034.TabIndex = 98;
            this.cxC00034.Text = "Account No:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvBLRepayHistory);
            this.groupBox2.Location = new System.Drawing.Point(4, 212);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(486, 171);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dgvBLRepayHistory
            // 
            this.dgvBLRepayHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBLRepayHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TermNo,
            this.DueDate,
            this.TotalLateDayWithDue});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBLRepayHistory.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBLRepayHistory.Location = new System.Drawing.Point(6, 16);
            this.dgvBLRepayHistory.Name = "dgvBLRepayHistory";
            this.dgvBLRepayHistory.RowHeadersVisible = false;
            this.dgvBLRepayHistory.Size = new System.Drawing.Size(470, 150);
            this.dgvBLRepayHistory.TabIndex = 104;
            // 
            // TermNo
            // 
            this.TermNo.HeaderText = "Term No";
            this.TermNo.Name = "TermNo";
            this.TermNo.ReadOnly = true;
            // 
            // DueDate
            // 
            this.DueDate.HeaderText = "Due Date";
            this.DueDate.Name = "DueDate";
            this.DueDate.ReadOnly = true;
            this.DueDate.Width = 150;
            // 
            // TotalLateDayWithDue
            // 
            this.TotalLateDayWithDue.HeaderText = "Late Days";
            this.TotalLateDayWithDue.Name = "TotalLateDayWithDue";
            this.TotalLateDayWithDue.ReadOnly = true;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(501, 31);
            this.tsbCRUD.TabIndex = 103;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // LOMVEW00421
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 386);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LOMVEW00421";
            this.Text = "Business Loans Repayment History Enquiry";
            this.Load += new System.EventHandler(this.LOMVEW00421_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBLRepayHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Windows.CXClient.Controls.CXC0003 cxC00036;
        private Windows.CXClient.Controls.CXC0001 txtBLDuration;
        private Windows.CXClient.Controls.CXC0001 txtBLNo;
        private Windows.CXClient.Controls.CXC0001 txtNRC;
        private Windows.CXClient.Controls.CXC0001 txtName;
        private Windows.CXClient.Controls.CXC0003 cxC00035;
        private Windows.CXClient.Controls.CXC0003 cxC00033;
        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0003 cxC00034;
        private System.Windows.Forms.DataGridView dgvBLRepayHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn TermNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalLateDayWithDue;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0001 txtBLType;
        private Windows.CXClient.Controls.CXC0003 cxC00037;
    }
}