namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00041
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00041));
            this.gvDepositApprove = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colCashierEntryNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCounterNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDenomination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApprovedUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblPressSpaceBar = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblNoCashierEntryNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblTransactionDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00037 = new Ace.Windows.CXClient.Controls.CXC0003();
            ((System.ComponentModel.ISupportInitialize)(this.gvDepositApprove)).BeginInit();
            this.SuspendLayout();
            // 
            // gvDepositApprove
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvDepositApprove.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvDepositApprove.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDepositApprove.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCashierEntryNo,
            this.colCounterNo,
            this.colCurrency,
            this.colDenomination,
            this.colAmount,
            this.colApprovedUser,
            this.colIsSelected});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvDepositApprove.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvDepositApprove.EnableHeadersVisualStyles = false;
            this.gvDepositApprove.IdTSList = null;
            this.gvDepositApprove.IsEscapeKey = false;
            this.gvDepositApprove.IsHeaderClick = false;
            this.gvDepositApprove.Location = new System.Drawing.Point(12, 79);
            this.gvDepositApprove.Name = "gvDepositApprove";
            this.gvDepositApprove.RowHeadersWidth = 25;
            this.gvDepositApprove.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvDepositApprove.ShowSerialNo = false;
            this.gvDepositApprove.Size = new System.Drawing.Size(802, 217);
            this.gvDepositApprove.TabIndex = 1;
            this.gvDepositApprove.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvDepositApprove_KeyDown);
            // 
            // colCashierEntryNo
            // 
            this.colCashierEntryNo.DataPropertyName = "TlfEntryNo";
            this.colCashierEntryNo.HeaderText = "Cashier Entry No";
            this.colCashierEntryNo.Name = "colCashierEntryNo";
            this.colCashierEntryNo.ReadOnly = true;
            this.colCashierEntryNo.Width = 111;
            // 
            // colCounterNo
            // 
            this.colCounterNo.DataPropertyName = "CounterNo";
            this.colCounterNo.HeaderText = "Counter No.";
            this.colCounterNo.Name = "colCounterNo";
            this.colCounterNo.ReadOnly = true;
            this.colCounterNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCounterNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCounterNo.Width = 110;
            // 
            // colCurrency
            // 
            this.colCurrency.DataPropertyName = "Currency";
            this.colCurrency.HeaderText = "Currency";
            this.colCurrency.Name = "colCurrency";
            this.colCurrency.ReadOnly = true;
            this.colCurrency.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCurrency.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCurrency.Width = 111;
            // 
            // colDenomination
            // 
            this.colDenomination.DataPropertyName = "DenostringForCenterTable";
            this.colDenomination.HeaderText = "Denomination";
            this.colDenomination.Name = "colDenomination";
            this.colDenomination.ReadOnly = true;
            this.colDenomination.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDenomination.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDenomination.Width = 111;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "Amount";
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAmount.Width = 111;
            // 
            // colApprovedUser
            // 
            this.colApprovedUser.DataPropertyName = "UserNo";
            this.colApprovedUser.HeaderText = "Approved User";
            this.colApprovedUser.Name = "colApprovedUser";
            this.colApprovedUser.ReadOnly = true;
            this.colApprovedUser.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colApprovedUser.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colApprovedUser.Width = 110;
            // 
            // colIsSelected
            // 
            this.colIsSelected.DataPropertyName = "IsCheck";
            this.colIsSelected.HeaderText = "Approve";
            this.colIsSelected.Name = "colIsSelected";
            this.colIsSelected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsSelected.TrueValue = "True";
            this.colIsSelected.Width = 111;
            // 
            // lblPressSpaceBar
            // 
            this.lblPressSpaceBar.AutoSize = true;
            this.lblPressSpaceBar.CausesValidation = false;
            this.lblPressSpaceBar.ForeColor = System.Drawing.Color.Blue;
            this.lblPressSpaceBar.Location = new System.Drawing.Point(179, 49);
            this.lblPressSpaceBar.MaximumSize = new System.Drawing.Size(200, 50);
            this.lblPressSpaceBar.Name = "lblPressSpaceBar";
            this.lblPressSpaceBar.Size = new System.Drawing.Size(141, 13);
            this.lblPressSpaceBar.TabIndex = 0;
            this.lblPressSpaceBar.Text = "Press Space Bar to Approve";
            // 
            // lblNoCashierEntryNo
            // 
            this.lblNoCashierEntryNo.AutoSize = true;
            this.lblNoCashierEntryNo.ForeColor = System.Drawing.Color.Red;
            this.lblNoCashierEntryNo.Location = new System.Drawing.Point(12, 49);
            this.lblNoCashierEntryNo.MaximumSize = new System.Drawing.Size(200, 50);
            this.lblNoCashierEntryNo.Name = "lblNoCashierEntryNo";
            this.lblNoCashierEntryNo.Size = new System.Drawing.Size(150, 13);
            this.lblNoCashierEntryNo.TabIndex = 0;
            this.lblNoCashierEntryNo.Text = "No Cashier Entry No. to post...";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(829, 31);
            this.tsbCRUD.TabIndex = 3;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblTransactionDate
            // 
            this.lblTransactionDate.AutoSize = true;
            this.lblTransactionDate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblTransactionDate.Location = new System.Drawing.Point(734, 45);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Size = new System.Drawing.Size(0, 13);
            this.lblTransactionDate.TabIndex = 21;
            // 
            // cxC00037
            // 
            this.cxC00037.AutoSize = true;
            this.cxC00037.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.cxC00037.Location = new System.Drawing.Point(633, 45);
            this.cxC00037.Name = "cxC00037";
            this.cxC00037.Size = new System.Drawing.Size(95, 13);
            this.cxC00037.TabIndex = 20;
            this.cxC00037.Text = "Transaction Date :";
            // 
            // TLMVEW00041
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 303);
            this.Controls.Add(this.lblTransactionDate);
            this.Controls.Add(this.cxC00037);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.gvDepositApprove);
            this.Controls.Add(this.lblNoCashierEntryNo);
            this.Controls.Add(this.lblPressSpaceBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00041";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Center Table Deposit (Approve) Entry";
            this.Load += new System.EventHandler(this.TLMVEW00041_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvDepositApprove)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ace.Windows.CXClient.Controls.AceGridView gvDepositApprove;
        private Ace.Windows.CXClient.Controls.CXC0003 lblPressSpaceBar;
        private Ace.Windows.CXClient.Controls.CXC0003 lblNoCashierEntryNo;
        private Ace.Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCashierEntryNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCounterNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDenomination;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApprovedUser;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsSelected;
        private Windows.CXClient.Controls.CXC0003 lblTransactionDate;
        private Windows.CXClient.Controls.CXC0003 cxC00037;


    }
}