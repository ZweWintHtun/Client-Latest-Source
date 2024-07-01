namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00015
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00015));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gpPOIssueInformation = new System.Windows.Forms.GroupBox();
            this.gvMultiPaymentOrderIssueInformation = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCharges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPONo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtCharges = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblCharges = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtTotalAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.butAdd = new Ace.Windows.CXClient.Controls.CXC0007();
            this.txtGroupNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblGroupNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblTotalAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gpPOIssueInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMultiPaymentOrderIssueInformation)).BeginInit();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(536, 31);
            this.tsbCRUD.TabIndex = 4;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // gpPOIssueInformation
            // 
            this.gpPOIssueInformation.Controls.Add(this.gvMultiPaymentOrderIssueInformation);
            this.gpPOIssueInformation.Controls.Add(this.txtCharges);
            this.gpPOIssueInformation.Controls.Add(this.lblCharges);
            this.gpPOIssueInformation.Controls.Add(this.txtTotalAmount);
            this.gpPOIssueInformation.Controls.Add(this.butAdd);
            this.gpPOIssueInformation.Controls.Add(this.txtGroupNo);
            this.gpPOIssueInformation.Controls.Add(this.txtAmount);
            this.gpPOIssueInformation.Controls.Add(this.lblGroupNo);
            this.gpPOIssueInformation.Controls.Add(this.lblTotalAmount);
            this.gpPOIssueInformation.Controls.Add(this.cboCurrency);
            this.gpPOIssueInformation.Controls.Add(this.lblAmount);
            this.gpPOIssueInformation.Controls.Add(this.lblCurrency);
            this.gpPOIssueInformation.Location = new System.Drawing.Point(13, 38);
            this.gpPOIssueInformation.Name = "gpPOIssueInformation";
            this.gpPOIssueInformation.Size = new System.Drawing.Size(505, 425);
            this.gpPOIssueInformation.TabIndex = 0;
            this.gpPOIssueInformation.TabStop = false;
            this.gpPOIssueInformation.Text = "PO Issue Information";
            // 
            // gvMultiPaymentOrderIssueInformation
            // 
            this.gvMultiPaymentOrderIssueInformation.AllowUserToAddRows = false;
            this.gvMultiPaymentOrderIssueInformation.AllowUserToDeleteRows = false;
            this.gvMultiPaymentOrderIssueInformation.CausesValidation = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gvMultiPaymentOrderIssueInformation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvMultiPaymentOrderIssueInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvMultiPaymentOrderIssueInformation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAmount,
            this.colCharges,
            this.colPONo,
            this.colEdit,
            this.colDelete});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvMultiPaymentOrderIssueInformation.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvMultiPaymentOrderIssueInformation.EnableHeadersVisualStyles = false;
            this.gvMultiPaymentOrderIssueInformation.IdTSList = null;
            this.gvMultiPaymentOrderIssueInformation.IsEscapeKey = false;
            this.gvMultiPaymentOrderIssueInformation.IsHeaderClick = false;
            this.gvMultiPaymentOrderIssueInformation.Location = new System.Drawing.Point(23, 197);
            this.gvMultiPaymentOrderIssueInformation.Name = "gvMultiPaymentOrderIssueInformation";
            this.gvMultiPaymentOrderIssueInformation.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvMultiPaymentOrderIssueInformation.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gvMultiPaymentOrderIssueInformation.RowHeadersWidth = 25;
            this.gvMultiPaymentOrderIssueInformation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvMultiPaymentOrderIssueInformation.ShowSerialNo = false;
            this.gvMultiPaymentOrderIssueInformation.Size = new System.Drawing.Size(458, 214);
            this.gvMultiPaymentOrderIssueInformation.TabIndex = 23;
            this.gvMultiPaymentOrderIssueInformation.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMultiPaymentOrderIssueInformation_CellClick);
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // colCharges
            // 
            this.colCharges.DataPropertyName = "Charges";
            this.colCharges.HeaderText = "Charges";
            this.colCharges.Name = "colCharges";
            this.colCharges.ReadOnly = true;
            // 
            // colPONo
            // 
            this.colPONo.DataPropertyName = "PONo";
            this.colPONo.HeaderText = "PO No.";
            this.colPONo.Name = "colPONo";
            this.colPONo.ReadOnly = true;
            this.colPONo.Width = 150;
            // 
            // colEdit
            // 
            this.colEdit.HeaderText = "";
            this.colEdit.Image = global::Ace.Cbs.Tel.Vew.Properties.Resources.edit;
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            this.colEdit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colEdit.ToolTipText = "Edit";
            this.colEdit.Width = 30;
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "";
            this.colDelete.Image = global::Ace.Cbs.Tel.Vew.Properties.Resources.Delete_Main;
            this.colDelete.Name = "colDelete";
            this.colDelete.ReadOnly = true;
            this.colDelete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDelete.ToolTipText = "Delete";
            this.colDelete.Width = 30;
            // 
            // txtCharges
            // 
            this.txtCharges.DecimalPlaces = 2;
            this.txtCharges.IsSendTabOnEnter = true;
            this.txtCharges.IsThousandSeperator = true;
            this.txtCharges.IsUseFloatingPoint = true;
            this.txtCharges.Location = new System.Drawing.Point(113, 115);
            this.txtCharges.Margin = new System.Windows.Forms.Padding(2);
            this.txtCharges.MaxLength = 18;
            this.txtCharges.Name = "txtCharges";
            this.txtCharges.ReadOnly = true;
            this.txtCharges.Size = new System.Drawing.Size(111, 20);
            this.txtCharges.TabIndex = 19;
            this.txtCharges.TabStop = false;
            this.txtCharges.Text = "0.00";
            this.txtCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCharges.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblCharges
            // 
            this.lblCharges.AutoSize = true;
            this.lblCharges.Location = new System.Drawing.Point(20, 118);
            this.lblCharges.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCharges.Name = "lblCharges";
            this.lblCharges.Size = new System.Drawing.Size(52, 13);
            this.lblCharges.TabIndex = 9;
            this.lblCharges.Text = "Charges :";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.DecimalPlaces = 2;
            this.txtTotalAmount.IsSendTabOnEnter = true;
            this.txtTotalAmount.IsThousandSeperator = true;
            this.txtTotalAmount.IsUseFloatingPoint = true;
            this.txtTotalAmount.Location = new System.Drawing.Point(113, 146);
            this.txtTotalAmount.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotalAmount.MaxLength = 18;
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(111, 20);
            this.txtTotalAmount.TabIndex = 20;
            this.txtTotalAmount.TabStop = false;
            this.txtTotalAmount.Text = "0.00";
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // butAdd
            // 
            this.butAdd.Enabled = false;
            this.butAdd.Image = ((System.Drawing.Image)(resources.GetObject("butAdd.Image")));
            this.butAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAdd.Location = new System.Drawing.Point(421, 162);
            this.butAdd.Margin = new System.Windows.Forms.Padding(2);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(60, 30);
            this.butAdd.TabIndex = 3;
            this.butAdd.Text = "&Add";
            this.butAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // txtGroupNo
            // 
            this.txtGroupNo.Enabled = false;
            this.txtGroupNo.IsSendTabOnEnter = true;
            this.txtGroupNo.Location = new System.Drawing.Point(113, 24);
            this.txtGroupNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtGroupNo.Name = "txtGroupNo";
            this.txtGroupNo.Size = new System.Drawing.Size(115, 20);
            this.txtGroupNo.TabIndex = 23;
            this.txtGroupNo.TabStop = false;
            // 
            // txtAmount
            // 
            this.txtAmount.DecimalPlaces = 2;
            this.txtAmount.IsSendTabOnEnter = true;
            this.txtAmount.IsThousandSeperator = true;
            this.txtAmount.IsUseFloatingPoint = true;
            this.txtAmount.Location = new System.Drawing.Point(113, 83);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(2);
            this.txtAmount.MaxLength = 18;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(111, 20);
            this.txtAmount.TabIndex = 2;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtAmount.Validated += new System.EventHandler(this.txtAmount_Validated);
            // 
            // lblGroupNo
            // 
            this.lblGroupNo.AutoSize = true;
            this.lblGroupNo.Location = new System.Drawing.Point(20, 27);
            this.lblGroupNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGroupNo.Name = "lblGroupNo";
            this.lblGroupNo.Size = new System.Drawing.Size(59, 13);
            this.lblGroupNo.TabIndex = 10;
            this.lblGroupNo.Text = "Group No :";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(20, 149);
            this.lblTotalAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(76, 13);
            this.lblTotalAmount.TabIndex = 11;
            this.lblTotalAmount.Text = "Total Amount :";
            // 
            // cboCurrency
            // 
            this.cboCurrency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCurrency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCurrency.DropDownHeight = 200;
            this.cboCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrency.FormattingEnabled = true;
            this.cboCurrency.IntegralHeight = false;
            this.cboCurrency.IsSendTabOnEnter = true;
            this.cboCurrency.Location = new System.Drawing.Point(113, 53);
            this.cboCurrency.Margin = new System.Windows.Forms.Padding(2);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 1;
            this.cboCurrency.Validated += new System.EventHandler(this.cboCurrency_Validated);
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(20, 86);
            this.lblAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(49, 13);
            this.lblAmount.TabIndex = 13;
            this.lblAmount.Text = "Amount :";
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(20, 56);
            this.lblCurrency.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 12;
            this.lblCurrency.Text = "Currency :";
            // 
            // TLMVEW00015
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 483);
            this.Controls.Add(this.gpPOIssueInformation);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TLMVEW00015";
            this.Text = "Payment Order Issue Entry";
            this.Load += new System.EventHandler(this.TLMVEW00015_Load);
            this.Move += new System.EventHandler(this.TLMVEW00015_Move);
            this.gpPOIssueInformation.ResumeLayout(false);
            this.gpPOIssueInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMultiPaymentOrderIssueInformation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox gpPOIssueInformation;
        private Windows.CXClient.Controls.CXC0004 txtCharges;
        private Windows.CXClient.Controls.CXC0003 lblCharges;
        private Windows.CXClient.Controls.CXC0004 txtTotalAmount;
        private Windows.CXClient.Controls.CXC0007 butAdd;
        private Windows.CXClient.Controls.CXC0006 txtGroupNo;
        private Windows.CXClient.Controls.CXC0004 txtAmount;
        private Windows.CXClient.Controls.CXC0003 lblGroupNo;
        private Windows.CXClient.Controls.CXC0003 lblTotalAmount;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0003 lblAmount;
        private Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Windows.CXClient.Controls.AceGridView gvMultiPaymentOrderIssueInformation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCharges;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPONo;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
        private System.Windows.Forms.DataGridViewImageColumn colDelete;
    }
}