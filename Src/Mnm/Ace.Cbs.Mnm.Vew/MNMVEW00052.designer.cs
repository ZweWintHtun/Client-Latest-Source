namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00052
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00052));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblStartPeriod = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblEndPeriod = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gvSubledgerCustomer = new Ace.Windows.CXClient.Controls.AceGridView();
            this.AccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblSelectedAC = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblTotalAC = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblSelectedACDesc = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblTotalACDesc = new Ace.Windows.CXClient.Controls.CXC0003();
            this.dtpStartDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.dtpEndDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.grpFrame = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvSubledgerCustomer)).BeginInit();
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
            this.tsbCRUD.Size = new System.Drawing.Size(511, 31);
            this.tsbCRUD.TabIndex = 4;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblStartPeriod
            // 
            this.lblStartPeriod.AutoSize = true;
            this.lblStartPeriod.Location = new System.Drawing.Point(38, 57);
            this.lblStartPeriod.Name = "lblStartPeriod";
            this.lblStartPeriod.Size = new System.Drawing.Size(86, 13);
            this.lblStartPeriod.TabIndex = 34;
            this.lblStartPeriod.Text = "Start Period       :";
            // 
            // lblEndPeriod
            // 
            this.lblEndPeriod.AutoSize = true;
            this.lblEndPeriod.Location = new System.Drawing.Point(38, 84);
            this.lblEndPeriod.Name = "lblEndPeriod";
            this.lblEndPeriod.Size = new System.Drawing.Size(86, 13);
            this.lblEndPeriod.TabIndex = 36;
            this.lblEndPeriod.Text = "End Period        :";
            // 
            // gvSubledgerCustomer
            // 
            this.gvSubledgerCustomer.AllowDrop = true;
            this.gvSubledgerCustomer.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvSubledgerCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvSubledgerCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSubledgerCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AccountNo,
            this.colDescription,
            this.colSelect});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvSubledgerCustomer.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvSubledgerCustomer.EnableHeadersVisualStyles = false;
            this.gvSubledgerCustomer.IdTSList = null;
            this.gvSubledgerCustomer.IsEscapeKey = false;
            this.gvSubledgerCustomer.IsHeaderClick = false;
            this.gvSubledgerCustomer.Location = new System.Drawing.Point(15, 123);
            this.gvSubledgerCustomer.Name = "gvSubledgerCustomer";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvSubledgerCustomer.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gvSubledgerCustomer.RowHeadersWidth = 25;
            this.gvSubledgerCustomer.ShowSerialNo = false;
            this.gvSubledgerCustomer.Size = new System.Drawing.Size(488, 210);
            this.gvSubledgerCustomer.TabIndex = 5;
            this.gvSubledgerCustomer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvSubledgerCustomer_CellContentClick);
            // 
            // AccountNo
            // 
            this.AccountNo.DataPropertyName = "AccountNo";
            this.AccountNo.HeaderText = "AccountNo";
            this.AccountNo.MaxInputLength = 15;
            this.AccountNo.Name = "AccountNo";
            this.AccountNo.ReadOnly = true;
            this.AccountNo.Width = 160;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Name";
            this.colDescription.HeaderText = "Name";
            this.colDescription.MaxInputLength = 40;
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 210;
            // 
            // colSelect
            // 
            this.colSelect.DataPropertyName = "IsCheck";
            this.colSelect.HeaderText = "Select";
            this.colSelect.Name = "colSelect";
            this.colSelect.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSelect.Width = 50;
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(130, 107);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 3;
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(38, 111);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(88, 13);
            this.lblAccountNo.TabIndex = 66;
            this.lblAccountNo.Text = "Account No.      :";
            // 
            // lblSelectedAC
            // 
            this.lblSelectedAC.AutoSize = true;
            this.lblSelectedAC.BackColor = System.Drawing.Color.White;
            this.lblSelectedAC.Enabled = false;
            this.lblSelectedAC.Location = new System.Drawing.Point(382, 343);
            this.lblSelectedAC.Name = "lblSelectedAC";
            this.lblSelectedAC.Size = new System.Drawing.Size(58, 13);
            this.lblSelectedAC.TabIndex = 71;
            this.lblSelectedAC.Text = "               0";
            this.lblSelectedAC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalAC
            // 
            this.lblTotalAC.AutoSize = true;
            this.lblTotalAC.BackColor = System.Drawing.Color.White;
            this.lblTotalAC.Enabled = false;
            this.lblTotalAC.Location = new System.Drawing.Point(118, 343);
            this.lblTotalAC.Name = "lblTotalAC";
            this.lblTotalAC.Size = new System.Drawing.Size(58, 13);
            this.lblTotalAC.TabIndex = 70;
            this.lblTotalAC.Text = "               0";
            // 
            // lblSelectedACDesc
            // 
            this.lblSelectedACDesc.AutoSize = true;
            this.lblSelectedACDesc.Location = new System.Drawing.Point(251, 343);
            this.lblSelectedACDesc.Name = "lblSelectedACDesc";
            this.lblSelectedACDesc.Size = new System.Drawing.Size(117, 13);
            this.lblSelectedACDesc.TabIndex = 69;
            this.lblSelectedACDesc.Text = "Selected A/C(S)          :";
            // 
            // lblTotalACDesc
            // 
            this.lblTotalACDesc.AutoSize = true;
            this.lblTotalACDesc.Location = new System.Drawing.Point(13, 343);
            this.lblTotalACDesc.Name = "lblTotalACDesc";
            this.lblTotalACDesc.Size = new System.Drawing.Size(99, 13);
            this.lblTotalACDesc.TabIndex = 68;
            this.lblTotalACDesc.Text = "Total A/C(S)          :";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.IsSendTabOnEnter = true;
            this.dtpStartDate.Location = new System.Drawing.Point(130, 53);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(115, 20);
            this.dtpStartDate.TabIndex = 1;
            this.dtpStartDate.Value = new System.DateTime(2014, 1, 9, 0, 0, 0, 0);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.IsSendTabOnEnter = true;
            this.dtpEndDate.Location = new System.Drawing.Point(130, 80);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(115, 20);
            this.dtpEndDate.TabIndex = 2;
            this.dtpEndDate.Value = new System.DateTime(2014, 1, 9, 0, 0, 0, 0);
            // 
            // grpFrame
            // 
            this.grpFrame.Location = new System.Drawing.Point(12, 37);
            this.grpFrame.Name = "grpFrame";
            this.grpFrame.Size = new System.Drawing.Size(486, 112);
            this.grpFrame.TabIndex = 72;
            this.grpFrame.TabStop = false;
            // 
            // MNMVEW00052
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 371);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblSelectedAC);
            this.Controls.Add(this.lblTotalAC);
            this.Controls.Add(this.lblSelectedACDesc);
            this.Controls.Add(this.lblTotalACDesc);
            this.Controls.Add(this.mtxtAccountNo);
            this.Controls.Add(this.lblAccountNo);
            this.Controls.Add(this.gvSubledgerCustomer);
            this.Controls.Add(this.lblEndPeriod);
            this.Controls.Add(this.lblStartPeriod);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.grpFrame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MNMVEW00052";
            this.Text = "Sub-Ledger (Customer)";
            this.Load += new System.EventHandler(this.MNMVEW00052_Load);
            this.Move += new System.EventHandler(this.MNMVEW00052_Move);
            ((System.ComponentModel.ISupportInitialize)(this.gvSubledgerCustomer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0003 lblStartPeriod;
        private Windows.CXClient.Controls.CXC0003 lblEndPeriod;
        private Windows.CXClient.Controls.AceGridView gvSubledgerCustomer;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblSelectedAC;
        private Windows.CXClient.Controls.CXC0003 lblTotalAC;
        private Windows.CXClient.Controls.CXC0003 lblSelectedACDesc;
        private Windows.CXClient.Controls.CXC0003 lblTotalACDesc;
        private Windows.CXClient.Controls.CXC0005 dtpStartDate;
        private Windows.CXClient.Controls.CXC0005 dtpEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.GroupBox grpFrame;
    }
}