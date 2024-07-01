namespace Ace.Cbs.Sam.Vew
{
    partial class SAMVEW00052
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAMVEW00052));
            this.txtCode = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblCode = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtRecordCount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblRecordCount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtDescription = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblDescription = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblNarration = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtNarration = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtStatus = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtPBReference = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtRVReference = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblStatus = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblPBReference = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblRVReference = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gvTransactionType = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colIsSelected = new Ace.Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn();
            this.colTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNarration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPBReference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRVReference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            ((System.ComponentModel.ISupportInitialize)(this.gvTransactionType)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCode
            // 
            this.txtCode.IsSendTabOnEnter = true;
            this.txtCode.Location = new System.Drawing.Point(96, 42);
            this.txtCode.MaxLength = 20;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(141, 20);
            this.txtCode.TabIndex = 1;
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCode_KeyPress);
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(11, 45);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(38, 13);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Code :";
            // 
            // txtRecordCount
            // 
            this.txtRecordCount.DecimalPlaces = 0;
            this.txtRecordCount.IsSendTabOnEnter = true;
            this.txtRecordCount.Location = new System.Drawing.Point(96, 538);
            this.txtRecordCount.Name = "txtRecordCount";
            this.txtRecordCount.ReadOnly = true;
            this.txtRecordCount.Size = new System.Drawing.Size(55, 20);
            this.txtRecordCount.TabIndex = 9;
            this.txtRecordCount.Text = "0";
            this.txtRecordCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRecordCount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Location = new System.Drawing.Point(11, 541);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(76, 13);
            this.lblRecordCount.TabIndex = 0;
            this.lblRecordCount.Text = "Record Count:";
            // 
            // txtDescription
            // 
            this.txtDescription.IsSendTabOnEnter = true;
            this.txtDescription.Location = new System.Drawing.Point(96, 68);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(175, 42);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescription_KeyPress);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(11, 71);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(66, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Description :";
            // 
            // lblNarration
            // 
            this.lblNarration.AutoSize = true;
            this.lblNarration.Location = new System.Drawing.Point(12, 119);
            this.lblNarration.Name = "lblNarration";
            this.lblNarration.Size = new System.Drawing.Size(56, 13);
            this.lblNarration.TabIndex = 0;
            this.lblNarration.Text = "Narration :";
            // 
            // txtNarration
            // 
            this.txtNarration.IsSendTabOnEnter = true;
            this.txtNarration.Location = new System.Drawing.Point(96, 116);
            this.txtNarration.MaxLength = 200;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(175, 20);
            this.txtNarration.TabIndex = 3;
            // 
            // txtStatus
            // 
            this.txtStatus.IsSendTabOnEnter = true;
            this.txtStatus.Location = new System.Drawing.Point(96, 142);
            this.txtStatus.MaxLength = 10;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(141, 20);
            this.txtStatus.TabIndex = 4;
            this.txtStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStatus_KeyPress);
            // 
            // txtPBReference
            // 
            this.txtPBReference.IsSendTabOnEnter = true;
            this.txtPBReference.Location = new System.Drawing.Point(96, 168);
            this.txtPBReference.MaxLength = 20;
            this.txtPBReference.Name = "txtPBReference";
            this.txtPBReference.Size = new System.Drawing.Size(141, 20);
            this.txtPBReference.TabIndex = 5;
            this.txtPBReference.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPBReference_KeyPress);
            // 
            // txtRVReference
            // 
            this.txtRVReference.IsSendTabOnEnter = true;
            this.txtRVReference.Location = new System.Drawing.Point(96, 194);
            this.txtRVReference.MaxLength = 20;
            this.txtRVReference.Name = "txtRVReference";
            this.txtRVReference.Size = new System.Drawing.Size(141, 20);
            this.txtRVReference.TabIndex = 6;
            this.txtRVReference.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRVReference_KeyPress);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 145);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(43, 13);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Status :";
            // 
            // lblPBReference
            // 
            this.lblPBReference.AutoSize = true;
            this.lblPBReference.Location = new System.Drawing.Point(13, 171);
            this.lblPBReference.Name = "lblPBReference";
            this.lblPBReference.Size = new System.Drawing.Size(77, 13);
            this.lblPBReference.TabIndex = 0;
            this.lblPBReference.Text = "PBReference :";
            // 
            // lblRVReference
            // 
            this.lblRVReference.AutoSize = true;
            this.lblRVReference.Location = new System.Drawing.Point(13, 197);
            this.lblRVReference.Name = "lblRVReference";
            this.lblRVReference.Size = new System.Drawing.Size(78, 13);
            this.lblRVReference.TabIndex = 0;
            this.lblRVReference.Text = "RVReference :";
            // 
            // gvTransactionType
            // 
            this.gvTransactionType.AllowUserToAddRows = false;
            this.gvTransactionType.CausesValidation = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvTransactionType.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvTransactionType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTransactionType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIsSelected,
            this.colTS,
            this.colCode,
            this.colDescription,
            this.colNarration,
            this.colStatus,
            this.colPBReference,
            this.colRVReference,
            this.colEdit});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvTransactionType.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvTransactionType.EnableHeadersVisualStyles = false;
            this.gvTransactionType.IdTSList = null;
            this.gvTransactionType.IsEscapeKey = false;
            this.gvTransactionType.IsHeaderClick = false;
            this.gvTransactionType.Location = new System.Drawing.Point(15, 224);
            this.gvTransactionType.Name = "gvTransactionType";
            this.gvTransactionType.RowHeadersWidth = 25;
            this.gvTransactionType.ShowSerialNo = false;
            this.gvTransactionType.Size = new System.Drawing.Size(807, 308);
            this.gvTransactionType.TabIndex = 8;
            this.gvTransactionType.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVTranType_CellContentClick);
            // 
            // colIsSelected
            // 
            this.colIsSelected.CheckBoxHeader = false;
            this.colIsSelected.DataPropertyName = "IsCheck";
            this.colIsSelected.FalseValue = "false";
            this.colIsSelected.HeaderText = "";
            this.colIsSelected.Id = 0;
            this.colIsSelected.Name = "colIsSelected";
            this.colIsSelected.TrueValue = "true";
            this.colIsSelected.TS = null;
            this.colIsSelected.Width = 30;
            // 
            // colTS
            // 
            this.colTS.DataPropertyName = "TS";
            this.colTS.HeaderText = "";
            this.colTS.Name = "colTS";
            this.colTS.Visible = false;
            this.colTS.Width = 30;
            // 
            // colCode
            // 
            this.colCode.DataPropertyName = "TransactionCode";
            this.colCode.HeaderText = "Code";
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 200;
            // 
            // colNarration
            // 
            this.colNarration.DataPropertyName = "Narration";
            this.colNarration.HeaderText = "Narration";
            this.colNarration.Name = "colNarration";
            this.colNarration.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 70;
            // 
            // colPBReference
            // 
            this.colPBReference.DataPropertyName = "PBReference";
            this.colPBReference.HeaderText = "PBReference";
            this.colPBReference.Name = "colPBReference";
            this.colPBReference.ReadOnly = true;
            // 
            // colRVReference
            // 
            this.colRVReference.DataPropertyName = "RVReference";
            this.colRVReference.HeaderText = "RVReference";
            this.colRVReference.Name = "colRVReference";
            this.colRVReference.ReadOnly = true;
            // 
            // colEdit
            // 
            this.colEdit.HeaderText = "";
            this.colEdit.Image = global::Ace.Cbs.Sam.Vew.Properties.Resources.Edit_Main;
            this.colEdit.Name = "colEdit";
            this.colEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEdit.Width = 30;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.CausesValidation = false;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(848, 31);
            this.tsbCRUD.TabIndex = 10;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.DeleteButtonClick += new System.EventHandler(this.tsbCRUD_DeleteButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // SAMVEW00052
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 563);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.gvTransactionType);
            this.Controls.Add(this.lblRVReference);
            this.Controls.Add(this.lblPBReference);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtRVReference);
            this.Controls.Add(this.txtPBReference);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtNarration);
            this.Controls.Add(this.lblNarration);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtRecordCount);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.txtCode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SAMVEW00052";
            this.Text = "Transaction Type Entry";
            this.Load += new System.EventHandler(this.SAMVEW00052_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvTransactionType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0001 txtCode;
        private Windows.CXClient.Controls.CXC0003 lblCode;
        private Windows.CXClient.Controls.CXC0004 txtRecordCount;
        private Windows.CXClient.Controls.CXC0003 lblRecordCount;
        private Windows.CXClient.Controls.CXC0001 txtDescription;
        private Windows.CXClient.Controls.CXC0003 lblDescription;
        private Windows.CXClient.Controls.CXC0003 lblNarration;
        private Windows.CXClient.Controls.CXC0001 txtNarration;
        private Windows.CXClient.Controls.CXC0001 txtStatus;
        private Windows.CXClient.Controls.CXC0001 txtPBReference;
        private Windows.CXClient.Controls.CXC0001 txtRVReference;
        private Windows.CXClient.Controls.CXC0003 lblStatus;
        private Windows.CXClient.Controls.CXC0003 lblPBReference;
        private Windows.CXClient.Controls.CXC0003 lblRVReference;
        private Windows.CXClient.Controls.AceGridView gvTransactionType;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn colIsSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNarration;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPBReference;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRVReference;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
    }
}