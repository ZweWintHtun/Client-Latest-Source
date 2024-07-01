namespace Ace.Cbs.Tel.Vew
{
	partial class TLMVEW00072
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00072));
            this.lblAccountNo = new System.Windows.Forms.Label();
            this.mtxtAccountNo = new System.Windows.Forms.MaskedTextBox();
            this.gvPrintRemainTransaction = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWithdraw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeposit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            ((System.ComponentModel.ISupportInitialize)(this.gvPrintRemainTransaction)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(15, 41);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(67, 13);
            this.lblAccountNo.TabIndex = 0;
            this.lblAccountNo.Text = "Account No:";
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.Location = new System.Drawing.Point(105, 38);
            this.mtxtAccountNo.Mask = "999-999-999999999";
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(126, 20);
            this.mtxtAccountNo.TabIndex = 1;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtxtAccountNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtxtAccountNo_KeyDown);
            // 
            // gvPrintRemainTransaction
            // 
            this.gvPrintRemainTransaction.AllowDrop = true;
            this.gvPrintRemainTransaction.AllowUserToAddRows = false;
            this.gvPrintRemainTransaction.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvPrintRemainTransaction.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gvPrintRemainTransaction.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvPrintRemainTransaction.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvPrintRemainTransaction.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate,
            this.colWithdraw,
            this.colDeposit,
            this.colReference,
            this.colBalance});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvPrintRemainTransaction.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvPrintRemainTransaction.EnableHeadersVisualStyles = false;
            this.gvPrintRemainTransaction.IdTSList = null;
            this.gvPrintRemainTransaction.IsEscapeKey = false;
            this.gvPrintRemainTransaction.IsHeaderClick = false;
            this.gvPrintRemainTransaction.Location = new System.Drawing.Point(15, 71);
            this.gvPrintRemainTransaction.Name = "gvPrintRemainTransaction";
            this.gvPrintRemainTransaction.ReadOnly = true;
            this.gvPrintRemainTransaction.RowHeadersWidth = 25;
            this.gvPrintRemainTransaction.ShowSerialNo = true;
            this.gvPrintRemainTransaction.Size = new System.Drawing.Size(609, 300);
            this.gvPrintRemainTransaction.TabIndex = 11;
            this.gvPrintRemainTransaction.TabStop = false;
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "DATE_TIME";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.colDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // colWithdraw
            // 
            this.colWithdraw.DataPropertyName = "Debit";
            this.colWithdraw.HeaderText = "Withdraw";
            this.colWithdraw.Name = "colWithdraw";
            this.colWithdraw.ReadOnly = true;
            // 
            // colDeposit
            // 
            this.colDeposit.DataPropertyName = "Credit";
            this.colDeposit.HeaderText = "Deposit";
            this.colDeposit.Name = "colDeposit";
            this.colDeposit.ReadOnly = true;
            // 
            // colReference
            // 
            this.colReference.DataPropertyName = "Reference";
            this.colReference.HeaderText = "Reference";
            this.colReference.Name = "colReference";
            this.colReference.ReadOnly = true;
            // 
            // colBalance
            // 
            this.colBalance.DataPropertyName = "Balance";
            this.colBalance.HeaderText = "Balance";
            this.colBalance.Name = "colBalance";
            this.colBalance.ReadOnly = true;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, -5);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(1060, 31);
            this.tsbCRUD.TabIndex = 74;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // TLMVEW00072
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 383);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.gvPrintRemainTransaction);
            this.Controls.Add(this.mtxtAccountNo);
            this.Controls.Add(this.lblAccountNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TLMVEW00072";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print Remain Transaction";
            this.Load += new System.EventHandler(this.TLMVEW00072_Load);
            this.Move += new System.EventHandler(this.TLMVEW00072_Move);
            ((System.ComponentModel.ISupportInitialize)(this.gvPrintRemainTransaction)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Label lblAccountNo;
        private System.Windows.Forms.MaskedTextBox mtxtAccountNo;
        private Windows.CXClient.Controls.AceGridView gvPrintRemainTransaction;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWithdraw;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeposit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReference;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBalance;
	}
}