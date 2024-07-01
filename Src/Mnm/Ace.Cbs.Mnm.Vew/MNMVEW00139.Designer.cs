namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00139
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00139));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblEntryNo = new System.Windows.Forms.Label();
            this.lblNRCNo = new System.Windows.Forms.Label();
            this.lblAccountType = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblNarration = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtEntryNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtNRCNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtAccountType = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtNarration = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtIndividualAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtMultiAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.gvCashDenoEditInformation = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNRC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNarration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtName = new Ace.Windows.CXClient.Controls.CXC0001();
            this.grpFrame = new System.Windows.Forms.GroupBox();
            this.lblTransactionDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00034 = new Ace.Windows.CXClient.Controls.CXC0003();
            ((System.ComponentModel.ISupportInitialize)(this.gvCashDenoEditInformation)).BeginInit();
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
            this.tsbCRUD.Size = new System.Drawing.Size(616, 31);
            this.tsbCRUD.TabIndex = 2;
            this.tsbCRUD.EditButtonClick += new System.EventHandler(this.tsbCRUD_EditButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblEntryNo
            // 
            this.lblEntryNo.AutoSize = true;
            this.lblEntryNo.Location = new System.Drawing.Point(29, 90);
            this.lblEntryNo.Name = "lblEntryNo";
            this.lblEntryNo.Size = new System.Drawing.Size(54, 13);
            this.lblEntryNo.TabIndex = 6;
            this.lblEntryNo.Text = "Entry No :";
            // 
            // lblNRCNo
            // 
            this.lblNRCNo.AutoSize = true;
            this.lblNRCNo.Location = new System.Drawing.Point(29, 154);
            this.lblNRCNo.Name = "lblNRCNo";
            this.lblNRCNo.Size = new System.Drawing.Size(53, 13);
            this.lblNRCNo.TabIndex = 7;
            this.lblNRCNo.Text = "NRC No :";
            // 
            // lblAccountType
            // 
            this.lblAccountType.AutoSize = true;
            this.lblAccountType.Location = new System.Drawing.Point(329, 90);
            this.lblAccountType.Name = "lblAccountType";
            this.lblAccountType.Size = new System.Drawing.Size(80, 13);
            this.lblAccountType.TabIndex = 8;
            this.lblAccountType.Text = "Account Type :";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(29, 122);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 13);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "Name :";
            // 
            // lblNarration
            // 
            this.lblNarration.AutoSize = true;
            this.lblNarration.Location = new System.Drawing.Point(330, 122);
            this.lblNarration.Name = "lblNarration";
            this.lblNarration.Size = new System.Drawing.Size(56, 13);
            this.lblNarration.TabIndex = 10;
            this.lblNarration.Text = "Narration :";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(330, 154);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(49, 13);
            this.lblAmount.TabIndex = 11;
            this.lblAmount.Text = "Amount :";
            // 
            // txtEntryNo
            // 
            this.txtEntryNo.IsSendTabOnEnter = true;
            this.txtEntryNo.Location = new System.Drawing.Point(89, 87);
            this.txtEntryNo.Name = "txtEntryNo";
            this.txtEntryNo.Size = new System.Drawing.Size(124, 20);
            this.txtEntryNo.TabIndex = 1;
            // 
            // txtNRCNo
            // 
            this.txtNRCNo.IsSendTabOnEnter = true;
            this.txtNRCNo.Location = new System.Drawing.Point(89, 151);
            this.txtNRCNo.Name = "txtNRCNo";
            this.txtNRCNo.ReadOnly = true;
            this.txtNRCNo.Size = new System.Drawing.Size(175, 20);
            this.txtNRCNo.TabIndex = 14;
            this.txtNRCNo.TabStop = false;
            // 
            // txtAccountType
            // 
            this.txtAccountType.IsSendTabOnEnter = true;
            this.txtAccountType.Location = new System.Drawing.Point(416, 87);
            this.txtAccountType.Name = "txtAccountType";
            this.txtAccountType.ReadOnly = true;
            this.txtAccountType.Size = new System.Drawing.Size(124, 20);
            this.txtAccountType.TabIndex = 15;
            this.txtAccountType.TabStop = false;
            // 
            // txtNarration
            // 
            this.txtNarration.IsSendTabOnEnter = true;
            this.txtNarration.Location = new System.Drawing.Point(416, 119);
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.ReadOnly = true;
            this.txtNarration.Size = new System.Drawing.Size(124, 20);
            this.txtNarration.TabIndex = 16;
            this.txtNarration.TabStop = false;
            // 
            // txtIndividualAmount
            // 
            this.txtIndividualAmount.DecimalPlaces = 2;
            this.txtIndividualAmount.IsSendTabOnEnter = true;
            this.txtIndividualAmount.IsThousandSeperator = true;
            this.txtIndividualAmount.IsUseFloatingPoint = true;
            this.txtIndividualAmount.Location = new System.Drawing.Point(416, 151);
            this.txtIndividualAmount.Name = "txtIndividualAmount";
            this.txtIndividualAmount.ReadOnly = true;
            this.txtIndividualAmount.Size = new System.Drawing.Size(124, 20);
            this.txtIndividualAmount.TabIndex = 17;
            this.txtIndividualAmount.TabStop = false;
            this.txtIndividualAmount.Text = "0.00";
            this.txtIndividualAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIndividualAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtMultiAmount
            // 
            this.txtMultiAmount.DecimalPlaces = 2;
            this.txtMultiAmount.IsSendTabOnEnter = true;
            this.txtMultiAmount.IsThousandSeperator = true;
            this.txtMultiAmount.IsUseFloatingPoint = true;
            this.txtMultiAmount.Location = new System.Drawing.Point(417, 87);
            this.txtMultiAmount.Name = "txtMultiAmount";
            this.txtMultiAmount.ReadOnly = true;
            this.txtMultiAmount.Size = new System.Drawing.Size(111, 20);
            this.txtMultiAmount.TabIndex = 18;
            this.txtMultiAmount.Text = "0.00";
            this.txtMultiAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMultiAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // gvCashDenoEditInformation
            // 
            this.gvCashDenoEditInformation.AllowUserToAddRows = false;
            this.gvCashDenoEditInformation.AllowUserToDeleteRows = false;
            this.gvCashDenoEditInformation.CausesValidation = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gvCashDenoEditInformation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvCashDenoEditInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCashDenoEditInformation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAccountNo,
            this.colName,
            this.colNRC,
            this.colNarration,
            this.colAmount});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvCashDenoEditInformation.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvCashDenoEditInformation.EnableHeadersVisualStyles = false;
            this.gvCashDenoEditInformation.IdTSList = null;
            this.gvCashDenoEditInformation.IsEscapeKey = false;
            this.gvCashDenoEditInformation.IsHeaderClick = false;
            this.gvCashDenoEditInformation.Location = new System.Drawing.Point(15, 119);
            this.gvCashDenoEditInformation.Name = "gvCashDenoEditInformation";
            this.gvCashDenoEditInformation.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvCashDenoEditInformation.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gvCashDenoEditInformation.RowHeadersWidth = 25;
            this.gvCashDenoEditInformation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvCashDenoEditInformation.ShowSerialNo = false;
            this.gvCashDenoEditInformation.Size = new System.Drawing.Size(586, 141);
            this.gvCashDenoEditInformation.TabIndex = 24;
            // 
            // colAccountNo
            // 
            this.colAccountNo.DataPropertyName = "AccountNo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colAccountNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.colAccountNo.HeaderText = "Account No.";
            this.colAccountNo.Name = "colAccountNo";
            this.colAccountNo.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colNRC
            // 
            this.colNRC.DataPropertyName = "NRC";
            this.colNRC.HeaderText = "NRC";
            this.colNRC.Name = "colNRC";
            this.colNRC.ReadOnly = true;
            this.colNRC.Width = 150;
            // 
            // colNarration
            // 
            this.colNarration.DataPropertyName = "Narration";
            this.colNarration.HeaderText = "Narration";
            this.colNarration.Name = "colNarration";
            this.colNarration.ReadOnly = true;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "Amount";
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // txtName
            // 
            this.txtName.IsSendTabOnEnter = true;
            this.txtName.Location = new System.Drawing.Point(89, 119);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(175, 20);
            this.txtName.TabIndex = 25;
            this.txtName.TabStop = false;
            // 
            // grpFrame
            // 
            this.grpFrame.Location = new System.Drawing.Point(12, 70);
            this.grpFrame.Name = "grpFrame";
            this.grpFrame.Size = new System.Drawing.Size(589, 119);
            this.grpFrame.TabIndex = 62;
            this.grpFrame.TabStop = false;
            // 
            // lblTransactionDate
            // 
            this.lblTransactionDate.AutoSize = true;
            this.lblTransactionDate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblTransactionDate.Location = new System.Drawing.Point(534, 44);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Size = new System.Drawing.Size(0, 13);
            this.lblTransactionDate.TabIndex = 64;
            // 
            // cxC00034
            // 
            this.cxC00034.AutoSize = true;
            this.cxC00034.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.cxC00034.Location = new System.Drawing.Point(433, 44);
            this.cxC00034.Name = "cxC00034";
            this.cxC00034.Size = new System.Drawing.Size(95, 13);
            this.cxC00034.TabIndex = 63;
            this.cxC00034.Text = "Transaction Date :";
            // 
            // MNMVEW00139
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 277);
            this.Controls.Add(this.lblTransactionDate);
            this.Controls.Add(this.cxC00034);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtIndividualAmount);
            this.Controls.Add(this.txtNarration);
            this.Controls.Add(this.txtAccountType);
            this.Controls.Add(this.txtNRCNo);
            this.Controls.Add(this.txtEntryNo);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblNarration);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblAccountType);
            this.Controls.Add(this.lblNRCNo);
            this.Controls.Add(this.lblEntryNo);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.txtMultiAmount);
            this.Controls.Add(this.gvCashDenoEditInformation);
            this.Controls.Add(this.grpFrame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MNMVEW00139";
            this.Text = "MNMVEW000139";
            this.Load += new System.EventHandler(this.MNMVEW00139_Load);
            this.Move += new System.EventHandler(this.MNMVEW00139_Move);
            ((System.ComponentModel.ISupportInitialize)(this.gvCashDenoEditInformation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.Label lblEntryNo;
        private System.Windows.Forms.Label lblNRCNo;
        private System.Windows.Forms.Label lblAccountType;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblNarration;
        private System.Windows.Forms.Label lblAmount;
        private Windows.CXClient.Controls.CXC0001 txtEntryNo;
        private Windows.CXClient.Controls.CXC0001 txtNRCNo;
        private Windows.CXClient.Controls.CXC0001 txtAccountType;
        private Windows.CXClient.Controls.CXC0001 txtNarration;
        private Windows.CXClient.Controls.CXC0004 txtIndividualAmount;
        private Windows.CXClient.Controls.CXC0004 txtMultiAmount;
        private Windows.CXClient.Controls.AceGridView gvCashDenoEditInformation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNRC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNarration;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private Windows.CXClient.Controls.CXC0001 txtName;
        private System.Windows.Forms.GroupBox grpFrame;
        private Windows.CXClient.Controls.CXC0003 lblTransactionDate;
        private Windows.CXClient.Controls.CXC0003 cxC00034;
    }
}