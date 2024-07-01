namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00017
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00017));
            this.lblEntryNo = new System.Windows.Forms.Label();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.txtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtCurrency = new Ace.Windows.CXClient.Controls.CXC0006();
            this.gbOnlineDenoIncomeEntry = new System.Windows.Forms.GroupBox();
            this.cboEntryNo = new Ace.Windows.CXClient.Controls.CXC0002();
            this.gvMultiPaymentOrderIssueInformation = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCommission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCommunicationCharges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbOnlineDenoIncomeEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMultiPaymentOrderIssueInformation)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEntryNo
            // 
            this.lblEntryNo.AutoSize = true;
            this.lblEntryNo.Location = new System.Drawing.Point(6, 45);
            this.lblEntryNo.Name = "lblEntryNo";
            this.lblEntryNo.Size = new System.Drawing.Size(54, 13);
            this.lblEntryNo.TabIndex = 99;
            this.lblEntryNo.Text = "Entry No :";
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(6, 86);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 99;
            this.lblCurrency.Text = "Currency :";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(6, 127);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(49, 13);
            this.lblAmount.TabIndex = 99;
            this.lblAmount.Text = "Amount :";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(593, 31);
            this.tsbCRUD.TabIndex = 1;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // txtAmount
            // 
            this.txtAmount.DecimalPlaces = 2;
            this.txtAmount.IsSendTabOnEnter = true;
            this.txtAmount.IsThousandSeperator = true;
            this.txtAmount.IsUseFloatingPoint = true;
            this.txtAmount.Location = new System.Drawing.Point(77, 124);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(2);
            this.txtAmount.MaxLength = 18;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(115, 20);
            this.txtAmount.TabIndex = 3;
            this.txtAmount.TabStop = false;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtCurrency
            // 
            this.txtCurrency.Enabled = false;
            this.txtCurrency.IsSendTabOnEnter = true;
            this.txtCurrency.Location = new System.Drawing.Point(77, 83);
            this.txtCurrency.Margin = new System.Windows.Forms.Padding(2);
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.ReadOnly = true;
            this.txtCurrency.Size = new System.Drawing.Size(115, 20);
            this.txtCurrency.TabIndex = 2;
            this.txtCurrency.TabStop = false;
            this.txtCurrency.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // gbOnlineDenoIncomeEntry
            // 
            this.gbOnlineDenoIncomeEntry.Controls.Add(this.cboEntryNo);
            this.gbOnlineDenoIncomeEntry.Controls.Add(this.gvMultiPaymentOrderIssueInformation);
            this.gbOnlineDenoIncomeEntry.Controls.Add(this.lblEntryNo);
            this.gbOnlineDenoIncomeEntry.Controls.Add(this.txtCurrency);
            this.gbOnlineDenoIncomeEntry.Controls.Add(this.lblCurrency);
            this.gbOnlineDenoIncomeEntry.Controls.Add(this.txtAmount);
            this.gbOnlineDenoIncomeEntry.Controls.Add(this.lblAmount);
            this.gbOnlineDenoIncomeEntry.Location = new System.Drawing.Point(13, 38);
            this.gbOnlineDenoIncomeEntry.Name = "gbOnlineDenoIncomeEntry";
            this.gbOnlineDenoIncomeEntry.Size = new System.Drawing.Size(567, 521);
            this.gbOnlineDenoIncomeEntry.TabIndex = 25;
            this.gbOnlineDenoIncomeEntry.TabStop = false;
            this.gbOnlineDenoIncomeEntry.Text = "Online Denomination Income Information";
            // 
            // cboEntryNo
            // 
            this.cboEntryNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboEntryNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEntryNo.DropDownHeight = 200;
            this.cboEntryNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEntryNo.FormattingEnabled = true;
            this.cboEntryNo.IntegralHeight = false;
            this.cboEntryNo.IsSendTabOnEnter = true;
            this.cboEntryNo.Location = new System.Drawing.Point(77, 42);
            this.cboEntryNo.Margin = new System.Windows.Forms.Padding(2);
            this.cboEntryNo.Name = "cboEntryNo";
            this.cboEntryNo.Size = new System.Drawing.Size(115, 21);
            this.cboEntryNo.TabIndex = 100;
            this.cboEntryNo.SelectedIndexChanged += new System.EventHandler(this.cboEntryNo_SelectedIndexChanged);
            // 
            // gvMultiPaymentOrderIssueInformation
            // 
            this.gvMultiPaymentOrderIssueInformation.AllowUserToAddRows = false;
            this.gvMultiPaymentOrderIssueInformation.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvMultiPaymentOrderIssueInformation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvMultiPaymentOrderIssueInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvMultiPaymentOrderIssueInformation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAccountNo,
            this.colCommission,
            this.colCommunicationCharges});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvMultiPaymentOrderIssueInformation.DefaultCellStyle = dataGridViewCellStyle4;
            this.gvMultiPaymentOrderIssueInformation.EnableHeadersVisualStyles = false;
            this.gvMultiPaymentOrderIssueInformation.IdTSList = null;
            this.gvMultiPaymentOrderIssueInformation.IsEscapeKey = false;
            this.gvMultiPaymentOrderIssueInformation.IsHeaderClick = false;
            this.gvMultiPaymentOrderIssueInformation.Location = new System.Drawing.Point(9, 169);
            this.gvMultiPaymentOrderIssueInformation.Name = "gvMultiPaymentOrderIssueInformation";
            this.gvMultiPaymentOrderIssueInformation.RowHeadersWidth = 25;
            this.gvMultiPaymentOrderIssueInformation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvMultiPaymentOrderIssueInformation.ShowSerialNo = true;
            this.gvMultiPaymentOrderIssueInformation.Size = new System.Drawing.Size(393, 346);
            this.gvMultiPaymentOrderIssueInformation.TabIndex = 4;
            this.gvMultiPaymentOrderIssueInformation.TabStop = false;
            // 
            // colAccountNo
            // 
            this.colAccountNo.DataPropertyName = "AccountType";
            this.colAccountNo.HeaderText = "Account No.";
            this.colAccountNo.Name = "colAccountNo";
            // 
            // colCommission
            // 
            this.colCommission.DataPropertyName = "IncomeCharges";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colCommission.DefaultCellStyle = dataGridViewCellStyle2;
            this.colCommission.HeaderText = "Commission";
            this.colCommission.Name = "colCommission";
            // 
            // colCommunicationCharges
            // 
            this.colCommunicationCharges.DataPropertyName = "CommunicationCharges";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colCommunicationCharges.DefaultCellStyle = dataGridViewCellStyle3;
            this.colCommunicationCharges.HeaderText = "Communication Charges";
            this.colCommunicationCharges.Name = "colCommunicationCharges";
            this.colCommunicationCharges.Width = 150;
            // 
            // TCMVEW00017
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 571);
            this.Controls.Add(this.gbOnlineDenoIncomeEntry);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TCMVEW00017";
            this.Text = "Online Deno Income Entry";
            this.Load += new System.EventHandler(this.TCMVEW00017_Load);
            this.gbOnlineDenoIncomeEntry.ResumeLayout(false);
            this.gbOnlineDenoIncomeEntry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMultiPaymentOrderIssueInformation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblEntryNo;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.Label lblAmount;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0004 txtAmount;
        private Windows.CXClient.Controls.CXC0006 txtCurrency;
        private System.Windows.Forms.GroupBox gbOnlineDenoIncomeEntry;
        private Windows.CXClient.Controls.AceGridView gvMultiPaymentOrderIssueInformation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCommission;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCommunicationCharges;
        private Windows.CXClient.Controls.CXC0002 cboEntryNo;
    }
}