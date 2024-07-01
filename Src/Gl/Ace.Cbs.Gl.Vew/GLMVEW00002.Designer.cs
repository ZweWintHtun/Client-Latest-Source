namespace Ace.Cbs.Gl.Vew
{
    partial class GLMVEW00002
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GLMVEW00002));
            this.gvOpeningBalanceEntry = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colIsSelected = new Ace.Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn();
            this.colACCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeptCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConvertedAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblOutOfBalance = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtOutOfBalance = new Ace.Windows.CXClient.Controls.CXC0004();
            ((System.ComponentModel.ISupportInitialize)(this.gvOpeningBalanceEntry)).BeginInit();
            this.SuspendLayout();
            // 
            // gvOpeningBalanceEntry
            // 
            this.gvOpeningBalanceEntry.AllowUserToAddRows = false;
            this.gvOpeningBalanceEntry.AllowUserToDeleteRows = false;
            this.gvOpeningBalanceEntry.CausesValidation = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gvOpeningBalanceEntry.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvOpeningBalanceEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvOpeningBalanceEntry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIsSelected,
            this.colACCode,
            this.colDeptCode,
            this.colDescription,
            this.colCurrency,
            this.colAmount,
            this.colConvertedAmount});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvOpeningBalanceEntry.DefaultCellStyle = dataGridViewCellStyle4;
            this.gvOpeningBalanceEntry.EnableHeadersVisualStyles = false;
            this.gvOpeningBalanceEntry.IdTSList = null;
            this.gvOpeningBalanceEntry.IsEscapeKey = false;
            this.gvOpeningBalanceEntry.IsHeaderClick = false;
            this.gvOpeningBalanceEntry.Location = new System.Drawing.Point(13, 45);
            this.gvOpeningBalanceEntry.Name = "gvOpeningBalanceEntry";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvOpeningBalanceEntry.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gvOpeningBalanceEntry.RowHeadersWidth = 25;
            this.gvOpeningBalanceEntry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gvOpeningBalanceEntry.ShowSerialNo = false;
            this.gvOpeningBalanceEntry.Size = new System.Drawing.Size(852, 538);
            this.gvOpeningBalanceEntry.TabIndex = 25;
            this.gvOpeningBalanceEntry.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvOpeningBalanceEntry_CellValueChanged);
            this.gvOpeningBalanceEntry.CurrentCellDirtyStateChanged += new System.EventHandler(this.gvOpeningBalanceEntry_CurrentCellDirtyStateChanged);
            // 
            // colIsSelected
            // 
            this.colIsSelected.CheckBoxHeader = false;
            this.colIsSelected.DataPropertyName = "IsCheck";
            this.colIsSelected.HeaderText = "";
            this.colIsSelected.Id = 0;
            this.colIsSelected.Name = "colIsSelected";
            this.colIsSelected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsSelected.TS = null;
            this.colIsSelected.Width = 30;
            // 
            // colACCode
            // 
            this.colACCode.DataPropertyName = "ACode";
            this.colACCode.HeaderText = "Account Code";
            this.colACCode.Name = "colACCode";
            this.colACCode.ReadOnly = true;
            // 
            // colDeptCode
            // 
            this.colDeptCode.DataPropertyName = "DCODE";
            this.colDeptCode.HeaderText = "Branch Code";
            this.colDeptCode.Name = "colDeptCode";
            this.colDeptCode.ReadOnly = true;
            this.colDeptCode.Width = 80;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "ACNAME";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 200;
            // 
            // colCurrency
            // 
            this.colCurrency.DataPropertyName = "CUR";
            this.colCurrency.HeaderText = "Currency";
            this.colCurrency.Name = "colCurrency";
            this.colCurrency.ReadOnly = true;
            this.colCurrency.Width = 70;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "OBAL";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.Width = 150;
            // 
            // colConvertedAmount
            // 
            this.colConvertedAmount.DataPropertyName = "HOBAL";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colConvertedAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.colConvertedAmount.HeaderText = "Converted Amount";
            this.colConvertedAmount.Name = "colConvertedAmount";
            this.colConvertedAmount.Width = 150;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-3, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(882, 31);
            this.tsbCRUD.TabIndex = 26;
            this.tsbCRUD.EditButtonClick += new System.EventHandler(this.tsbCRUD_EditButtonClick);
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.DeleteButtonClick += new System.EventHandler(this.tsbCRUD_DeleteButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblOutOfBalance
            // 
            this.lblOutOfBalance.AutoSize = true;
            this.lblOutOfBalance.Location = new System.Drawing.Point(543, 593);
            this.lblOutOfBalance.Name = "lblOutOfBalance";
            this.lblOutOfBalance.Size = new System.Drawing.Size(86, 13);
            this.lblOutOfBalance.TabIndex = 27;
            this.lblOutOfBalance.Text = "Out Of Balance :";
            // 
            // txtOutOfBalance
            // 
            this.txtOutOfBalance.BackColor = System.Drawing.SystemColors.Window;
            this.txtOutOfBalance.DecimalPlaces = 2;
            this.txtOutOfBalance.IsSendTabOnEnter = true;
            this.txtOutOfBalance.Location = new System.Drawing.Point(635, 589);
            this.txtOutOfBalance.Name = "txtOutOfBalance";
            this.txtOutOfBalance.ReadOnly = true;
            this.txtOutOfBalance.Size = new System.Drawing.Size(137, 20);
            this.txtOutOfBalance.TabIndex = 29;
            this.txtOutOfBalance.Text = "0.00";
            this.txtOutOfBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOutOfBalance.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // GLMVEW00002
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 616);
            this.Controls.Add(this.txtOutOfBalance);
            this.Controls.Add(this.lblOutOfBalance);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.gvOpeningBalanceEntry);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GLMVEW00002";
            this.Text = "Opening Balance Entry";
            this.Load += new System.EventHandler(this.GLMVEW00002_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvOpeningBalanceEntry)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.AceGridView gvOpeningBalanceEntry;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0003 lblOutOfBalance;
        private Windows.CXClient.Controls.CXC0004 txtOutOfBalance;
        private Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn colIsSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colACCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeptCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConvertedAmount;

    }
}