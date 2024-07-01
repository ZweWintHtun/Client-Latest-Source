namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00047
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00047));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.dtpDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.lblRequiredDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gvBalanceConfirmation = new Ace.Windows.CXClient.Controls.AceGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblTotalACDesc = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblSelectedACDesc = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblTotalAC = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblSelectedAC = new Ace.Windows.CXClient.Controls.CXC0003();
            this.grpFrame = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvBalanceConfirmation)).BeginInit();
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
            this.tsbCRUD.Size = new System.Drawing.Size(567, 31);
            this.tsbCRUD.TabIndex = 4;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.IsSendTabOnEnter = true;
            this.dtpDate.Location = new System.Drawing.Point(135, 57);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(115, 20);
            this.dtpDate.TabIndex = 1;
            this.dtpDate.Value = new System.DateTime(2013, 12, 28, 23, 7, 15, 0);
            this.dtpDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpDate_KeyDown);
            // 
            // lblRequiredDate
            // 
            this.lblRequiredDate.AutoSize = true;
            this.lblRequiredDate.Location = new System.Drawing.Point(29, 60);
            this.lblRequiredDate.Name = "lblRequiredDate";
            this.lblRequiredDate.Size = new System.Drawing.Size(82, 13);
            this.lblRequiredDate.TabIndex = 9;
            this.lblRequiredDate.Text = "Required Date :";
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(135, 84);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 2;
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(29, 86);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(73, 13);
            this.lblAccountNo.TabIndex = 31;
            this.lblAccountNo.Text = "Account No. :";
            // 
            // gvBalanceConfirmation
            // 
            this.gvBalanceConfirmation.AllowDrop = true;
            this.gvBalanceConfirmation.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvBalanceConfirmation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvBalanceConfirmation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvBalanceConfirmation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.colDescription,
            this.dataGridViewTextBoxColumn3});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvBalanceConfirmation.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvBalanceConfirmation.EnableHeadersVisualStyles = false;
            this.gvBalanceConfirmation.IdTSList = null;
            this.gvBalanceConfirmation.IsEscapeKey = false;
            this.gvBalanceConfirmation.IsHeaderClick = false;
            this.gvBalanceConfirmation.Location = new System.Drawing.Point(26, 116);
            this.gvBalanceConfirmation.Name = "gvBalanceConfirmation";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvBalanceConfirmation.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gvBalanceConfirmation.RowHeadersWidth = 25;
            this.gvBalanceConfirmation.ShowSerialNo = false;
            this.gvBalanceConfirmation.Size = new System.Drawing.Size(511, 175);
            this.gvBalanceConfirmation.TabIndex = 3;
            this.gvBalanceConfirmation.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvBalanceConfirmation_CellValueChanged);
            this.gvBalanceConfirmation.CurrentCellDirtyStateChanged += new System.EventHandler(this.gvBalanceConfirmation_CurrentCellDirtyStateChanged);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "AccountNo";
            this.dataGridViewTextBoxColumn2.HeaderText = "AccountNo";
            this.dataGridViewTextBoxColumn2.MaxInputLength = 15;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Name";
            this.colDescription.HeaderText = "Name";
            this.colDescription.MaxInputLength = 40;
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "IsCheck";
            this.dataGridViewTextBoxColumn3.HeaderText = "Select";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // lblTotalACDesc
            // 
            this.lblTotalACDesc.AutoSize = true;
            this.lblTotalACDesc.Location = new System.Drawing.Point(26, 306);
            this.lblTotalACDesc.Name = "lblTotalACDesc";
            this.lblTotalACDesc.Size = new System.Drawing.Size(99, 13);
            this.lblTotalACDesc.TabIndex = 34;
            this.lblTotalACDesc.Text = "Total A/C(S)          :";
            // 
            // lblSelectedACDesc
            // 
            this.lblSelectedACDesc.AutoSize = true;
            this.lblSelectedACDesc.Location = new System.Drawing.Point(269, 306);
            this.lblSelectedACDesc.Name = "lblSelectedACDesc";
            this.lblSelectedACDesc.Size = new System.Drawing.Size(117, 13);
            this.lblSelectedACDesc.TabIndex = 35;
            this.lblSelectedACDesc.Text = "Selected A/C(S)          :";
            // 
            // lblTotalAC
            // 
            this.lblTotalAC.AutoSize = true;
            this.lblTotalAC.BackColor = System.Drawing.Color.White;
            this.lblTotalAC.Enabled = false;
            this.lblTotalAC.Location = new System.Drawing.Point(143, 306);
            this.lblTotalAC.Name = "lblTotalAC";
            this.lblTotalAC.Size = new System.Drawing.Size(58, 13);
            this.lblTotalAC.TabIndex = 36;
            this.lblTotalAC.Text = "               0";
            // 
            // lblSelectedAC
            // 
            this.lblSelectedAC.AutoSize = true;
            this.lblSelectedAC.BackColor = System.Drawing.Color.White;
            this.lblSelectedAC.Enabled = false;
            this.lblSelectedAC.Location = new System.Drawing.Point(402, 306);
            this.lblSelectedAC.Name = "lblSelectedAC";
            this.lblSelectedAC.Size = new System.Drawing.Size(58, 13);
            this.lblSelectedAC.TabIndex = 37;
            this.lblSelectedAC.Text = "               0";
            // 
            // grpFrame
            // 
            this.grpFrame.Location = new System.Drawing.Point(12, 37);
            this.grpFrame.Name = "grpFrame";
            this.grpFrame.Size = new System.Drawing.Size(540, 303);
            this.grpFrame.TabIndex = 73;
            this.grpFrame.TabStop = false;
            // 
            // MNMVEW00047
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 352);
            this.Controls.Add(this.lblSelectedAC);
            this.Controls.Add(this.lblTotalAC);
            this.Controls.Add(this.lblSelectedACDesc);
            this.Controls.Add(this.lblTotalACDesc);
            this.Controls.Add(this.gvBalanceConfirmation);
            this.Controls.Add(this.mtxtAccountNo);
            this.Controls.Add(this.lblAccountNo);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblRequiredDate);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.grpFrame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MNMVEW00047";
            this.Text = "Balance Confirmation ";
            this.Load += new System.EventHandler(this.MNMVEW00047_Load);
            this.Move += new System.EventHandler(this.MNMVEW00047_Move);
            ((System.ComponentModel.ISupportInitialize)(this.gvBalanceConfirmation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0005 dtpDate;
        private Windows.CXClient.Controls.CXC0003 lblRequiredDate;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Windows.CXClient.Controls.AceGridView gvBalanceConfirmation;
        private Windows.CXClient.Controls.CXC0003 lblTotalACDesc;
        private Windows.CXClient.Controls.CXC0003 lblSelectedACDesc;
        private Windows.CXClient.Controls.CXC0003 lblTotalAC;
        private Windows.CXClient.Controls.CXC0003 lblSelectedAC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.GroupBox grpFrame;
    }
}