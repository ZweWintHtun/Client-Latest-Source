namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00219
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00219));
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.TermNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPLRepayHistory = new System.Windows.Forms.DataGridView();
            this.DueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalLateDayWithDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.cxC00036 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtPLDuration = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtPLNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtNRC = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtName = new Ace.Windows.CXClient.Controls.CXC0001();
            this.cxC00035 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00033 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00034 = new Ace.Windows.CXClient.Controls.CXC0003();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPLRepayHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(119, 60);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(179, 20);
            this.mtxtAccountNo.TabIndex = 93;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtxtAccountNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtxtAccountNo_KeyDown);
            // 
            // TermNo
            // 
            this.TermNo.HeaderText = "Term No";
            this.TermNo.Name = "TermNo";
            this.TermNo.ReadOnly = true;
            // 
            // dgvPLRepayHistory
            // 
            this.dgvPLRepayHistory.AllowUserToAddRows = false;
            this.dgvPLRepayHistory.AllowUserToResizeColumns = false;
            this.dgvPLRepayHistory.AllowUserToResizeRows = false;
            this.dgvPLRepayHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPLRepayHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TermNo,
            this.DueDate,
            this.TotalLateDayWithDue});
            this.dgvPLRepayHistory.Location = new System.Drawing.Point(11, 244);
            this.dgvPLRepayHistory.Name = "dgvPLRepayHistory";
            this.dgvPLRepayHistory.ReadOnly = true;
            this.dgvPLRepayHistory.RowHeadersVisible = false;
            this.dgvPLRepayHistory.Size = new System.Drawing.Size(353, 150);
            this.dgvPLRepayHistory.TabIndex = 104;
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
            this.tsbCRUD.Location = new System.Drawing.Point(-3, -1);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(488, 31);
            this.tsbCRUD.TabIndex = 103;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            this.tsbCRUD.Load += new System.EventHandler(this.LOMVEW00219_Load);
            // 
            // cxC00036
            // 
            this.cxC00036.AutoSize = true;
            this.cxC00036.Location = new System.Drawing.Point(305, 198);
            this.cxC00036.Name = "cxC00036";
            this.cxC00036.Size = new System.Drawing.Size(42, 13);
            this.cxC00036.TabIndex = 105;
            this.cxC00036.Text = "Months";
            // 
            // txtPLDuration
            // 
            this.txtPLDuration.IsSendTabOnEnter = true;
            this.txtPLDuration.Location = new System.Drawing.Point(119, 195);
            this.txtPLDuration.MaxLength = 15;
            this.txtPLDuration.Name = "txtPLDuration";
            this.txtPLDuration.ReadOnly = true;
            this.txtPLDuration.Size = new System.Drawing.Size(180, 20);
            this.txtPLDuration.TabIndex = 97;
            this.txtPLDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPLNo
            // 
            this.txtPLNo.IsSendTabOnEnter = true;
            this.txtPLNo.Location = new System.Drawing.Point(119, 165);
            this.txtPLNo.MaxLength = 15;
            this.txtPLNo.Name = "txtPLNo";
            this.txtPLNo.ReadOnly = true;
            this.txtPLNo.Size = new System.Drawing.Size(180, 20);
            this.txtPLNo.TabIndex = 96;
            this.txtPLNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNRC
            // 
            this.txtNRC.IsSendTabOnEnter = true;
            this.txtNRC.Location = new System.Drawing.Point(119, 130);
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
            this.txtName.Location = new System.Drawing.Point(119, 95);
            this.txtName.MaxLength = 15;
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(180, 20);
            this.txtName.TabIndex = 94;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cxC00035
            // 
            this.cxC00035.AutoSize = true;
            this.cxC00035.Location = new System.Drawing.Point(24, 195);
            this.cxC00035.Name = "cxC00035";
            this.cxC00035.Size = new System.Drawing.Size(72, 13);
            this.cxC00035.TabIndex = 102;
            this.cxC00035.Text = "PL Duration : ";
            // 
            // cxC00033
            // 
            this.cxC00033.AutoSize = true;
            this.cxC00033.Location = new System.Drawing.Point(24, 165);
            this.cxC00033.Name = "cxC00033";
            this.cxC00033.Size = new System.Drawing.Size(46, 13);
            this.cxC00033.TabIndex = 101;
            this.cxC00033.Text = "PL No : ";
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.Location = new System.Drawing.Point(24, 130);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(39, 13);
            this.cxC00032.TabIndex = 100;
            this.cxC00032.Text = "NRC : ";
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(24, 95);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(41, 13);
            this.cxC00031.TabIndex = 99;
            this.cxC00031.Text = "Name :";
            // 
            // cxC00034
            // 
            this.cxC00034.AutoSize = true;
            this.cxC00034.Location = new System.Drawing.Point(24, 60);
            this.cxC00034.Name = "cxC00034";
            this.cxC00034.Size = new System.Drawing.Size(49, 13);
            this.cxC00034.TabIndex = 98;
            this.cxC00034.Text = "A/C No :";
            // 
            // LOMVEW00219
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 410);
            this.Controls.Add(this.mtxtAccountNo);
            this.Controls.Add(this.dgvPLRepayHistory);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.cxC00036);
            this.Controls.Add(this.txtPLDuration);
            this.Controls.Add(this.txtPLNo);
            this.Controls.Add(this.txtNRC);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cxC00035);
            this.Controls.Add(this.cxC00033);
            this.Controls.Add(this.cxC00032);
            this.Controls.Add(this.cxC00031);
            this.Controls.Add(this.cxC00034);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LOMVEW00219";
            this.Text = "Personal Loan Repayment History";
            this.Load += new System.EventHandler(this.LOMVEW00219_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPLRepayHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TermNo;
        private System.Windows.Forms.DataGridView dgvPLRepayHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalLateDayWithDue;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0003 cxC00036;
        private Windows.CXClient.Controls.CXC0001 txtPLDuration;
        private Windows.CXClient.Controls.CXC0001 txtPLNo;
        private Windows.CXClient.Controls.CXC0001 txtNRC;
        private Windows.CXClient.Controls.CXC0001 txtName;
        private Windows.CXClient.Controls.CXC0003 cxC00035;
        private Windows.CXClient.Controls.CXC0003 cxC00033;
        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0003 cxC00034;
    }
}