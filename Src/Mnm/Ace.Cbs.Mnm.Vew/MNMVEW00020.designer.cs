namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00020
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00020));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.chkVIPCustomer = new Ace.Windows.CXClient.Controls.CXC0008();
            this.butAdd = new Ace.Windows.CXClient.Controls.CXC0007();
            this.gvPoIssueForTransfer = new Ace.Windows.CXClient.Controls.AceGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PONo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChequeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtTotal = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtCharges = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtCurrency = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblChequeNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblTotal = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCharges = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtChequeNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.mtxtPaymentOrderNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtYear = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblPaymentOrderNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            ((System.ComponentModel.ISupportInitialize)(this.gvPoIssueForTransfer)).BeginInit();
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
            this.tsbCRUD.Size = new System.Drawing.Size(795, 31);
            this.tsbCRUD.TabIndex = 11;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::Ace.Cbs.Mnm.Vew.Properties.Resources.Edit_Main;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ToolTipText = "Edit";
            this.dataGridViewImageColumn1.Width = 30;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::Ace.Cbs.Mnm.Vew.Properties.Resources.Delete_Main;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ToolTipText = "Delete";
            this.dataGridViewImageColumn2.Width = 30;
            // 
            // chkVIPCustomer
            // 
            this.chkVIPCustomer.AutoSize = true;
            this.chkVIPCustomer.IsSendTabOnEnter = true;
            this.chkVIPCustomer.Location = new System.Drawing.Point(30, 46);
            this.chkVIPCustomer.Name = "chkVIPCustomer";
            this.chkVIPCustomer.Size = new System.Drawing.Size(90, 17);
            this.chkVIPCustomer.TabIndex = 10;
            this.chkVIPCustomer.Text = "VIP Customer";
            this.chkVIPCustomer.UseVisualStyleBackColor = true;
            // 
            // butAdd
            // 
            this.butAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butAdd.Image = ((System.Drawing.Image)(resources.GetObject("butAdd.Image")));
            this.butAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAdd.Location = new System.Drawing.Point(705, 194);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(60, 30);
            this.butAdd.TabIndex = 8;
            this.butAdd.Text = "&Add";
            this.butAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
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
            this.dataGridViewTextBoxColumn1,
            this.PONo,
            this.dataGridViewTextBoxColumn3,
            this.colChequeNo,
            this.colCheque,
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
            this.gvPoIssueForTransfer.Location = new System.Drawing.Point(30, 236);
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
            this.gvPoIssueForTransfer.Size = new System.Drawing.Size(735, 248);
            this.gvPoIssueForTransfer.TabIndex = 9;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "AccountNo";
            this.dataGridViewTextBoxColumn1.HeaderText = "Account No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // PONo
            // 
            this.PONo.DataPropertyName = "PONo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PONo.DefaultCellStyle = dataGridViewCellStyle2;
            this.PONo.HeaderText = "PO No";
            this.PONo.Name = "PONo";
            this.PONo.ReadOnly = true;
            this.PONo.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "AdjustmentAmount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn3.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // colChequeNo
            // 
            this.colChequeNo.DataPropertyName = "CheckNo";
            this.colChequeNo.HeaderText = "ChequeNo.";
            this.colChequeNo.Name = "colChequeNo";
            this.colChequeNo.ReadOnly = true;
            this.colChequeNo.Width = 70;
            // 
            // colCheque
            // 
            this.colCheque.DataPropertyName = "Description";
            this.colCheque.HeaderText = "Description";
            this.colCheque.Name = "colCheque";
            this.colCheque.ReadOnly = true;
            this.colCheque.Width = 150;
            // 
            // colEdit
            // 
            this.colEdit.HeaderText = "";
            this.colEdit.Image = global::Ace.Cbs.Mnm.Vew.Properties.Resources.Edit_Main;
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            this.colEdit.ToolTipText = "Edit";
            this.colEdit.Width = 30;
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "";
            this.colDelete.Image = global::Ace.Cbs.Mnm.Vew.Properties.Resources.Delete_Main;
            this.colDelete.Name = "colDelete";
            this.colDelete.ReadOnly = true;
            this.colDelete.ToolTipText = "Delete";
            this.colDelete.Width = 30;
            // 
            // txtTotal
            // 
            this.txtTotal.DecimalPlaces = 2;
            this.txtTotal.IsSendTabOnEnter = true;
            this.txtTotal.Location = new System.Drawing.Point(144, 204);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(115, 20);
            this.txtTotal.TabIndex = 7;
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
            this.txtCharges.Location = new System.Drawing.Point(144, 178);
            this.txtCharges.Name = "txtCharges";
            this.txtCharges.Size = new System.Drawing.Size(115, 20);
            this.txtCharges.TabIndex = 6;
            this.txtCharges.Text = "0.00";
            this.txtCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCharges.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtAmount
            // 
            this.txtAmount.DecimalPlaces = 2;
            this.txtAmount.IsSendTabOnEnter = true;
            this.txtAmount.Location = new System.Drawing.Point(144, 152);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(115, 20);
            this.txtAmount.TabIndex = 5;
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
            this.txtCurrency.IsSendTabOnEnter = true;
            this.txtCurrency.Location = new System.Drawing.Point(291, 100);
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.Size = new System.Drawing.Size(64, 20);
            this.txtCurrency.TabIndex = 1;
            this.txtCurrency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblChequeNo
            // 
            this.lblChequeNo.AutoSize = true;
            this.lblChequeNo.Location = new System.Drawing.Point(27, 129);
            this.lblChequeNo.Name = "lblChequeNo";
            this.lblChequeNo.Size = new System.Drawing.Size(70, 13);
            this.lblChequeNo.TabIndex = 14;
            this.lblChequeNo.Text = "Cheque No. :";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(27, 207);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(40, 13);
            this.lblTotal.TabIndex = 17;
            this.lblTotal.Text = "Total : ";
            // 
            // lblCharges
            // 
            this.lblCharges.AutoSize = true;
            this.lblCharges.Location = new System.Drawing.Point(27, 181);
            this.lblCharges.Name = "lblCharges";
            this.lblCharges.Size = new System.Drawing.Size(55, 13);
            this.lblCharges.TabIndex = 16;
            this.lblCharges.Text = "Charges : ";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(27, 155);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(67, 13);
            this.lblAmount.TabIndex = 15;
            this.lblAmount.Text = "PO Amount :";
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.IsSendTabOnEnter = true;
            this.txtChequeNo.Location = new System.Drawing.Point(144, 126);
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(70, 20);
            this.txtChequeNo.TabIndex = 4;
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(27, 103);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(73, 13);
            this.lblAccountNo.TabIndex = 12;
            this.lblAccountNo.Text = "Account No. :";
            // 
            // mtxtPaymentOrderNo
            // 
            this.mtxtPaymentOrderNo.IsSendTabOnEnter = true;
            this.mtxtPaymentOrderNo.Location = new System.Drawing.Point(144, 74);
            this.mtxtPaymentOrderNo.Mask = "PO000/0000000000";
            this.mtxtPaymentOrderNo.Name = "mtxtPaymentOrderNo";
            this.mtxtPaymentOrderNo.Size = new System.Drawing.Size(115, 20);
            this.mtxtPaymentOrderNo.TabIndex = 2;
            // 
            // txtYear
            // 
            this.txtYear.BackColor = System.Drawing.SystemColors.Window;
            this.txtYear.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtYear.IsSendTabOnEnter = true;
            this.txtYear.Location = new System.Drawing.Point(266, 74);
            this.txtYear.Name = "txtYear";
            this.txtYear.ReadOnly = true;
            this.txtYear.Size = new System.Drawing.Size(65, 20);
            this.txtYear.TabIndex = 3;
            // 
            // lblPaymentOrderNo
            // 
            this.lblPaymentOrderNo.AutoSize = true;
            this.lblPaymentOrderNo.Location = new System.Drawing.Point(27, 77);
            this.lblPaymentOrderNo.Name = "lblPaymentOrderNo";
            this.lblPaymentOrderNo.Size = new System.Drawing.Size(100, 13);
            this.lblPaymentOrderNo.TabIndex = 13;
            this.lblPaymentOrderNo.Text = "Payment Order No.:";
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.BackColor = System.Drawing.SystemColors.Window;
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(144, 100);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 18;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // MNMVEW00020
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 530);
            this.Controls.Add(this.mtxtAccountNo);
            this.Controls.Add(this.chkVIPCustomer);
            this.Controls.Add(this.butAdd);
            this.Controls.Add(this.gvPoIssueForTransfer);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtCharges);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtCurrency);
            this.Controls.Add(this.lblChequeNo);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblCharges);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.txtChequeNo);
            this.Controls.Add(this.lblAccountNo);
            this.Controls.Add(this.mtxtPaymentOrderNo);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.lblPaymentOrderNo);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00020";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment Order Issue By Transfer";
            this.Load += new System.EventHandler(this.MNMVEW00020_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvPoIssueForTransfer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private Windows.CXClient.Controls.CXC0008 chkVIPCustomer;
        private Windows.CXClient.Controls.CXC0007 butAdd;
        private Windows.CXClient.Controls.AceGridView gvPoIssueForTransfer;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PONo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChequeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheque;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
        private System.Windows.Forms.DataGridViewImageColumn colDelete;
        private Windows.CXClient.Controls.CXC0004 txtTotal;
        private Windows.CXClient.Controls.CXC0004 txtCharges;
        private Windows.CXClient.Controls.CXC0004 txtAmount;
        private Windows.CXClient.Controls.CXC0001 txtCurrency;
        private Windows.CXClient.Controls.CXC0003 lblChequeNo;
        private Windows.CXClient.Controls.CXC0003 lblTotal;
        private Windows.CXClient.Controls.CXC0003 lblCharges;
        private Windows.CXClient.Controls.CXC0003 lblAmount;
        private Windows.CXClient.Controls.CXC0006 txtChequeNo;
        private Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Windows.CXClient.Controls.CXC0006 mtxtPaymentOrderNo;
        private Windows.CXClient.Controls.CXC0001 txtYear;
        private Windows.CXClient.Controls.CXC0003 lblPaymentOrderNo;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
    }
}