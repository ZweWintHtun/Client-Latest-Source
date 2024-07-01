namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00003
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00003));
            this.gbPOIssueByTransfer = new System.Windows.Forms.GroupBox();
            this.txtTotal = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtCharges = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtPoAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtChequeNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.chkVIP = new Ace.Windows.CXClient.Controls.CXC0008();
            this.txtCurrency = new Ace.Windows.CXClient.Controls.CXC0004();
            this.gvPoIssueForTransfer = new Ace.Windows.CXClient.Controls.AceGridView();
            this.PONo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRowId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.butAdd = new Ace.Windows.CXClient.Controls.CXC0007();
            this.lblTotal = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCharges = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblPoAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.label3 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.gbPOIssueByTransfer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPoIssueForTransfer)).BeginInit();
            this.SuspendLayout();
            // 
            // gbPOIssueByTransfer
            // 
            this.gbPOIssueByTransfer.Controls.Add(this.txtTotal);
            this.gbPOIssueByTransfer.Controls.Add(this.txtCharges);
            this.gbPOIssueByTransfer.Controls.Add(this.txtPoAmount);
            this.gbPOIssueByTransfer.Controls.Add(this.txtChequeNo);
            this.gbPOIssueByTransfer.Controls.Add(this.mtxtAccountNo);
            this.gbPOIssueByTransfer.Controls.Add(this.chkVIP);
            this.gbPOIssueByTransfer.Controls.Add(this.txtCurrency);
            this.gbPOIssueByTransfer.Controls.Add(this.gvPoIssueForTransfer);
            this.gbPOIssueByTransfer.Controls.Add(this.butAdd);
            this.gbPOIssueByTransfer.Controls.Add(this.lblTotal);
            this.gbPOIssueByTransfer.Controls.Add(this.lblCharges);
            this.gbPOIssueByTransfer.Controls.Add(this.lblPoAmount);
            this.gbPOIssueByTransfer.Controls.Add(this.lblCurrency);
            this.gbPOIssueByTransfer.Controls.Add(this.label3);
            this.gbPOIssueByTransfer.Controls.Add(this.lblAccountNo);
            this.gbPOIssueByTransfer.Location = new System.Drawing.Point(12, 35);
            this.gbPOIssueByTransfer.Name = "gbPOIssueByTransfer";
            this.gbPOIssueByTransfer.Size = new System.Drawing.Size(617, 475);
            this.gbPOIssueByTransfer.TabIndex = 0;
            this.gbPOIssueByTransfer.TabStop = false;
            // 
            // txtTotal
            // 
            this.txtTotal.DecimalPlaces = 2;
            this.txtTotal.IsSendTabOnEnter = true;
            this.txtTotal.IsThousandSeperator = true;
            this.txtTotal.IsUseFloatingPoint = true;
            this.txtTotal.Location = new System.Drawing.Point(109, 177);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotal.MaxLength = 18;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(111, 20);
            this.txtTotal.TabIndex = 25;
            this.txtTotal.Text = "0.00";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotal.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtCharges
            // 
            this.txtCharges.DecimalPlaces = 2;
            this.txtCharges.IsSendTabOnEnter = true;
            this.txtCharges.IsThousandSeperator = true;
            this.txtCharges.IsUseFloatingPoint = true;
            this.txtCharges.Location = new System.Drawing.Point(109, 149);
            this.txtCharges.Margin = new System.Windows.Forms.Padding(2);
            this.txtCharges.MaxLength = 18;
            this.txtCharges.Name = "txtCharges";
            this.txtCharges.ReadOnly = true;
            this.txtCharges.Size = new System.Drawing.Size(111, 20);
            this.txtCharges.TabIndex = 24;
            this.txtCharges.Text = "0.00";
            this.txtCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCharges.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtPoAmount
            // 
            this.txtPoAmount.DecimalPlaces = 2;
            this.txtPoAmount.IsSendTabOnEnter = true;
            this.txtPoAmount.IsThousandSeperator = true;
            this.txtPoAmount.IsUseFloatingPoint = true;
            this.txtPoAmount.Location = new System.Drawing.Point(109, 125);
            this.txtPoAmount.Margin = new System.Windows.Forms.Padding(2);
            this.txtPoAmount.MaxLength = 18;
            this.txtPoAmount.Name = "txtPoAmount";
            this.txtPoAmount.Size = new System.Drawing.Size(111, 20);
            this.txtPoAmount.TabIndex = 5;
            this.txtPoAmount.Text = "0.00";
            this.txtPoAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPoAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.IsSendTabOnEnter = true;
            this.txtChequeNo.Location = new System.Drawing.Point(109, 101);
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(115, 20);
            this.txtChequeNo.TabIndex = 4;
            this.txtChequeNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.BackColor = System.Drawing.SystemColors.Window;
            this.mtxtAccountNo.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtxtAccountNo.HidePromptOnLeave = true;
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(109, 47);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 3;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // chkVIP
            // 
            this.chkVIP.AutoSize = true;
            this.chkVIP.IsSendTabOnEnter = true;
            this.chkVIP.Location = new System.Drawing.Point(9, 19);
            this.chkVIP.Name = "chkVIP";
            this.chkVIP.Size = new System.Drawing.Size(90, 17);
            this.chkVIP.TabIndex = 2;
            this.chkVIP.Text = "VIP Customer";
            this.chkVIP.UseVisualStyleBackColor = true;
            // 
            // txtCurrency
            // 
            this.txtCurrency.DecimalPlaces = 0;
            this.txtCurrency.Enabled = false;
            this.txtCurrency.IsSendTabOnEnter = true;
            this.txtCurrency.Location = new System.Drawing.Point(109, 73);
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.ReadOnly = true;
            this.txtCurrency.Size = new System.Drawing.Size(111, 20);
            this.txtCurrency.TabIndex = 3;
            this.txtCurrency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCurrency.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // gvPoIssueForTransfer
            // 
            this.gvPoIssueForTransfer.AllowUserToAddRows = false;
            this.gvPoIssueForTransfer.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvPoIssueForTransfer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvPoIssueForTransfer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPoIssueForTransfer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PONo,
            this.dataGridViewTextBoxColumn1,
            this.colCheque,
            this.dataGridViewTextBoxColumn3,
            this.colRowId,
            this.colEdit,
            this.colDelete});
            this.gvPoIssueForTransfer.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvPoIssueForTransfer.DefaultCellStyle = dataGridViewCellStyle4;
            this.gvPoIssueForTransfer.EnableHeadersVisualStyles = false;
            this.gvPoIssueForTransfer.IdTSList = null;
            this.gvPoIssueForTransfer.IsEscapeKey = false;
            this.gvPoIssueForTransfer.IsHeaderClick = false;
            this.gvPoIssueForTransfer.Location = new System.Drawing.Point(9, 203);
            this.gvPoIssueForTransfer.Name = "gvPoIssueForTransfer";
            this.gvPoIssueForTransfer.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvPoIssueForTransfer.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gvPoIssueForTransfer.RowHeadersWidth = 25;
            this.gvPoIssueForTransfer.ShowSerialNo = true;
            this.gvPoIssueForTransfer.Size = new System.Drawing.Size(597, 264);
            this.gvPoIssueForTransfer.TabIndex = 9;
            this.gvPoIssueForTransfer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvPoIssueForTransfer_CellClick);
            // 
            // PONo
            // 
            this.PONo.DataPropertyName = "PONo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PONo.DefaultCellStyle = dataGridViewCellStyle2;
            this.PONo.HeaderText = "PO No";
            this.PONo.Name = "PONo";
            this.PONo.ReadOnly = true;
            this.PONo.Width = 120;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "AccountNo";
            this.dataGridViewTextBoxColumn1.HeaderText = "Account No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // colCheque
            // 
            this.colCheque.DataPropertyName = "Description";
            this.colCheque.HeaderText = "Description";
            this.colCheque.Name = "colCheque";
            this.colCheque.ReadOnly = true;
            this.colCheque.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "AdjustmentAmount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn3.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 120;
            // 
            // colRowId
            // 
            this.colRowId.HeaderText = "Id";
            this.colRowId.Name = "colRowId";
            this.colRowId.ReadOnly = true;
            this.colRowId.Visible = false;
            this.colRowId.Width = 10;
            // 
            // colEdit
            // 
            this.colEdit.HeaderText = "";
            this.colEdit.Image = global::Ace.Cbs.Tcm.Vew.Properties.Resources.edit;
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            this.colEdit.ToolTipText = "Edit";
            this.colEdit.Width = 30;
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "";
            this.colDelete.Image = global::Ace.Cbs.Tcm.Vew.Properties.Resources.Delete_Main;
            this.colDelete.Name = "colDelete";
            this.colDelete.ReadOnly = true;
            this.colDelete.ToolTipText = "Delete";
            this.colDelete.Width = 30;
            // 
            // butAdd
            // 
            this.butAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butAdd.Image = ((System.Drawing.Image)(resources.GetObject("butAdd.Image")));
            this.butAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAdd.Location = new System.Drawing.Point(546, 167);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(60, 30);
            this.butAdd.TabIndex = 6;
            this.butAdd.Text = "&Add";
            this.butAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(6, 180);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(76, 13);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "Total Amount :";
            // 
            // lblCharges
            // 
            this.lblCharges.AutoSize = true;
            this.lblCharges.Location = new System.Drawing.Point(6, 154);
            this.lblCharges.Name = "lblCharges";
            this.lblCharges.Size = new System.Drawing.Size(52, 13);
            this.lblCharges.TabIndex = 0;
            this.lblCharges.Text = "Charges :";
            // 
            // lblPoAmount
            // 
            this.lblPoAmount.AutoSize = true;
            this.lblPoAmount.Location = new System.Drawing.Point(6, 128);
            this.lblPoAmount.Name = "lblPoAmount";
            this.lblPoAmount.Size = new System.Drawing.Size(67, 13);
            this.lblPoAmount.TabIndex = 0;
            this.lblPoAmount.Text = "PO Amount :";
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(6, 76);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 0;
            this.lblCurrency.Text = "Currency :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Cheque No. :";
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(6, 50);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(73, 13);
            this.lblAccountNo.TabIndex = 0;
            this.lblAccountNo.Text = "Account No. :";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.CausesValidation = false;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, -2);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(647, 31);
            this.tsbCRUD.TabIndex = 7;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::Ace.Cbs.Tcm.Vew.Properties.Resources.Edit_Main;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.ToolTipText = "Edit";
            this.dataGridViewImageColumn1.Width = 30;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::Ace.Cbs.Tcm.Vew.Properties.Resources.Delete_Main;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.ToolTipText = "Delete";
            this.dataGridViewImageColumn2.Width = 30;
            // 
            // TCMVEW00003
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 520);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.gbPOIssueByTransfer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TCMVEW00003";
            this.Load += new System.EventHandler(this.TCMVEW00003_Load_1);
            this.Move += new System.EventHandler(this.TCMVEW00003_Move);
            this.gbPOIssueByTransfer.ResumeLayout(false);
            this.gbPOIssueByTransfer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPoIssueForTransfer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPOIssueByTransfer;
        private Windows.CXClient.Controls.CXC0003 lblTotal;
        private Windows.CXClient.Controls.CXC0003 lblCharges;
        private Windows.CXClient.Controls.CXC0003 lblPoAmount;
        private Windows.CXClient.Controls.CXC0003 label3;
        private Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Windows.CXClient.Controls.AceGridView gvPoIssueForTransfer;
        private Windows.CXClient.Controls.CXC0004 txtCurrency;
        private Ace.Windows.CXClient.Controls.CXC0007 butAdd;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Windows.CXClient.Controls.CXC0008 chkVIP;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Windows.CXClient.Controls.CXC0006 txtChequeNo;
        private Windows.CXClient.Controls.CXC0004 txtPoAmount;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private Windows.CXClient.Controls.CXC0004 txtCharges;
        private Windows.CXClient.Controls.CXC0004 txtTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn PONo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRowId;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
        private System.Windows.Forms.DataGridViewImageColumn colDelete;
    }
}