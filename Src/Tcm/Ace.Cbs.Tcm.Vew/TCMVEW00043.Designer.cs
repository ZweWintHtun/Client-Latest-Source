namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00043
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00043));
            this.gvClearingPosting = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colSlipNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFixedReceiptNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceiveBank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChequeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblTotalCheque = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblReturnCheque = new Ace.Windows.CXClient.Controls.CXC0003();
            this.ntxtTotalCheques = new Ace.Windows.CXClient.Controls.CXC0004();
            this.ntxtReturnCheques = new Ace.Windows.CXClient.Controls.CXC0004();
            this.butPosting = new Ace.Windows.CXClient.Controls.CXC0007();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblNoCheque = new Ace.Windows.CXClient.Controls.CXC0003();
            ((System.ComponentModel.ISupportInitialize)(this.gvClearingPosting)).BeginInit();
            this.SuspendLayout();
            // 
            // gvClearingPosting
            // 
            this.gvClearingPosting.AllowUserToAddRows = false;
            this.gvClearingPosting.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gvClearingPosting.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvClearingPosting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvClearingPosting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSlipNo,
            this.colAccountNo,
            this.colFixedReceiptNo,
            this.colReceiveBank,
            this.colChequeNo,
            this.colAmount,
            this.colIsSelected});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvClearingPosting.DefaultCellStyle = dataGridViewCellStyle5;
            this.gvClearingPosting.EnableHeadersVisualStyles = false;
            this.gvClearingPosting.IdTSList = null;
            this.gvClearingPosting.IsEscapeKey = false;
            this.gvClearingPosting.IsHeaderClick = false;
            this.gvClearingPosting.Location = new System.Drawing.Point(12, 49);
            this.gvClearingPosting.Name = "gvClearingPosting";
            this.gvClearingPosting.RowHeadersWidth = 25;
            this.gvClearingPosting.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvClearingPosting.ShowSerialNo = true;
            this.gvClearingPosting.Size = new System.Drawing.Size(829, 355);
            this.gvClearingPosting.TabIndex = 52;
            this.gvClearingPosting.TabStop = false;
            this.gvClearingPosting.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvClearingPosting_CellContentClick);
            // 
            // colSlipNo
            // 
            this.colSlipNo.DataPropertyName = "Eno";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSlipNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.colSlipNo.HeaderText = "Slip No.";
            this.colSlipNo.Name = "colSlipNo";
            this.colSlipNo.ReadOnly = true;
            this.colSlipNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colSlipNo.Width = 110;
            // 
            // colAccountNo
            // 
            this.colAccountNo.DataPropertyName = "AccountNo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.colAccountNo.DefaultCellStyle = dataGridViewCellStyle3;
            this.colAccountNo.HeaderText = "Account No.";
            this.colAccountNo.Name = "colAccountNo";
            this.colAccountNo.ReadOnly = true;
            this.colAccountNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colAccountNo.Width = 150;
            // 
            // colFixedReceiptNo
            // 
            this.colFixedReceiptNo.DataPropertyName = "ReceiptNo";
            this.colFixedReceiptNo.HeaderText = "Fixed Receipt No.";
            this.colFixedReceiptNo.Name = "colFixedReceiptNo";
            this.colFixedReceiptNo.ReadOnly = true;
            this.colFixedReceiptNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colReceiveBank
            // 
            this.colReceiveBank.DataPropertyName = "OtherBank";
            this.colReceiveBank.HeaderText = "Receive Bank";
            this.colReceiveBank.Name = "colReceiveBank";
            this.colReceiveBank.ReadOnly = true;
            this.colReceiveBank.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colChequeNo
            // 
            this.colChequeNo.DataPropertyName = "OtherBankChq";
            this.colChequeNo.HeaderText = "Cheque No.";
            this.colChequeNo.Name = "colChequeNo";
            this.colChequeNo.ReadOnly = true;
            this.colChequeNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colAmount.Width = 150;
            // 
            // colIsSelected
            // 
            this.colIsSelected.DataPropertyName = "IsCheck";
            this.colIsSelected.HeaderText = "Returned";
            this.colIsSelected.Name = "colIsSelected";
            this.colIsSelected.ReadOnly = true;
            this.colIsSelected.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colIsSelected.Width = 90;
            // 
            // lblTotalCheque
            // 
            this.lblTotalCheque.AutoSize = true;
            this.lblTotalCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCheque.Location = new System.Drawing.Point(583, 419);
            this.lblTotalCheque.Name = "lblTotalCheque";
            this.lblTotalCheque.Size = new System.Drawing.Size(109, 13);
            this.lblTotalCheque.TabIndex = 53;
            this.lblTotalCheque.Text = "Total Cheque (s) :";
            // 
            // lblReturnCheque
            // 
            this.lblReturnCheque.AutoSize = true;
            this.lblReturnCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturnCheque.Location = new System.Drawing.Point(583, 446);
            this.lblReturnCheque.Name = "lblReturnCheque";
            this.lblReturnCheque.Size = new System.Drawing.Size(118, 13);
            this.lblReturnCheque.TabIndex = 54;
            this.lblReturnCheque.Text = "Return Cheque (s) :";
            // 
            // ntxtTotalCheques
            // 
            this.ntxtTotalCheques.DecimalPlaces = 2;
            this.ntxtTotalCheques.Enabled = false;
            this.ntxtTotalCheques.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ntxtTotalCheques.IsSendTabOnEnter = true;
            this.ntxtTotalCheques.Location = new System.Drawing.Point(727, 416);
            this.ntxtTotalCheques.MaxLength = 18;
            this.ntxtTotalCheques.Name = "ntxtTotalCheques";
            this.ntxtTotalCheques.Size = new System.Drawing.Size(88, 20);
            this.ntxtTotalCheques.TabIndex = 55;
            this.ntxtTotalCheques.Text = "0.00";
            this.ntxtTotalCheques.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntxtTotalCheques.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // ntxtReturnCheques
            // 
            this.ntxtReturnCheques.DecimalPlaces = 2;
            this.ntxtReturnCheques.Enabled = false;
            this.ntxtReturnCheques.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ntxtReturnCheques.IsSendTabOnEnter = true;
            this.ntxtReturnCheques.Location = new System.Drawing.Point(727, 443);
            this.ntxtReturnCheques.MaxLength = 18;
            this.ntxtReturnCheques.Name = "ntxtReturnCheques";
            this.ntxtReturnCheques.Size = new System.Drawing.Size(88, 20);
            this.ntxtReturnCheques.TabIndex = 56;
            this.ntxtReturnCheques.Text = "0.00";
            this.ntxtReturnCheques.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntxtReturnCheques.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // butPosting
            // 
            this.butPosting.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butPosting.Image = global::Ace.Cbs.Tcm.Vew.Properties.Resources.PostingOK;
            this.butPosting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butPosting.Location = new System.Drawing.Point(586, 474);
            this.butPosting.Name = "butPosting";
            this.butPosting.Size = new System.Drawing.Size(77, 43);
            this.butPosting.TabIndex = 57;
            this.butPosting.Text = "&Posting";
            this.butPosting.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butPosting.UseVisualStyleBackColor = true;
            this.butPosting.Click += new System.EventHandler(this.butPosting_Click);
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(860, 33);
            this.tsbCRUD.TabIndex = 58;
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblNoCheque
            // 
            this.lblNoCheque.AutoSize = true;
            this.lblNoCheque.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoCheque.Location = new System.Drawing.Point(28, 86);
            this.lblNoCheque.Name = "lblNoCheque";
            this.lblNoCheque.Size = new System.Drawing.Size(149, 20);
            this.lblNoCheque.TabIndex = 59;
            this.lblNoCheque.Text = "No. Cheque To Post :";
            // 
            // TCMVEW00043
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 529);
            this.Controls.Add(this.lblNoCheque);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.butPosting);
            this.Controls.Add(this.ntxtReturnCheques);
            this.Controls.Add(this.ntxtTotalCheques);
            this.Controls.Add(this.lblReturnCheque);
            this.Controls.Add(this.lblTotalCheque);
            this.Controls.Add(this.gvClearingPosting);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TCMVEW00043";
            this.Text = "Clearing Delivered Posting";
            this.Load += new System.EventHandler(this.TCMVEW00043_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvClearingPosting)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.AceGridView gvClearingPosting;
        private Windows.CXClient.Controls.CXC0003 lblTotalCheque;
        private Windows.CXClient.Controls.CXC0003 lblReturnCheque;
        private Windows.CXClient.Controls.CXC0004 ntxtTotalCheques;
        private Windows.CXClient.Controls.CXC0004 ntxtReturnCheques;
        private Windows.CXClient.Controls.CXC0007 butPosting;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0003 lblNoCheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSlipNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFixedReceiptNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceiveBank;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChequeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsSelected;
    }
}