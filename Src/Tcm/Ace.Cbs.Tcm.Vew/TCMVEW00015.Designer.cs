namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00015
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00015));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gvDailyReconsile = new Ace.Windows.CXClient.Controls.AceGridView();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblBankHead = new System.Windows.Forms.Label();
            this.lblSystemStatus = new System.Windows.Forms.Label();
            this.lblSystemDate = new System.Windows.Forms.Label();
            this.lblBranchDescription = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.butReconsile = new System.Windows.Forms.Button();
            this.butShutDown = new System.Windows.Forms.Button();
            this.btnODCalculation = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNOPSign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCommunicationCharges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvDailyReconsile)).BeginInit();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-2, -2);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(802, 31);
            this.tsbCRUD.TabIndex = 9;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // gvDailyReconsile
            // 
            this.gvDailyReconsile.AllowUserToAddRows = false;
            this.gvDailyReconsile.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvDailyReconsile.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvDailyReconsile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDailyReconsile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.colCheque,
            this.colNOPSign,
            this.dataGridViewTextBoxColumn3,
            this.colCommunicationCharges,
            this.colStatus});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvDailyReconsile.DefaultCellStyle = dataGridViewCellStyle6;
            this.gvDailyReconsile.EnableHeadersVisualStyles = false;
            this.gvDailyReconsile.IdTSList = null;
            this.gvDailyReconsile.IsEscapeKey = false;
            this.gvDailyReconsile.IsHeaderClick = false;
            this.gvDailyReconsile.Location = new System.Drawing.Point(12, 56);
            this.gvDailyReconsile.Name = "gvDailyReconsile";
            this.gvDailyReconsile.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvDailyReconsile.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.gvDailyReconsile.RowHeadersWidth = 25;
            this.gvDailyReconsile.ShowSerialNo = true;
            this.gvDailyReconsile.Size = new System.Drawing.Size(692, 345);
            this.gvDailyReconsile.TabIndex = 16;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblStatus.Location = new System.Drawing.Point(187, 170);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(101, 13);
            this.lblStatus.TabIndex = 22;
            this.lblStatus.Text = "Need to Shut Down";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblDate.Location = new System.Drawing.Point(187, 135);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(98, 13);
            this.lblDate.TabIndex = 21;
            this.lblDate.Text = "11 November 2013";
            // 
            // lblBankHead
            // 
            this.lblBankHead.AutoSize = true;
            this.lblBankHead.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblBankHead.Location = new System.Drawing.Point(187, 98);
            this.lblBankHead.Name = "lblBankHead";
            this.lblBankHead.Size = new System.Drawing.Size(198, 13);
            this.lblBankHead.TabIndex = 20;
            this.lblBankHead.Text = "Asia Green Development Bank Ltd.(IBD)";
            // 
            // lblSystemStatus
            // 
            this.lblSystemStatus.AutoSize = true;
            this.lblSystemStatus.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblSystemStatus.Location = new System.Drawing.Point(19, 170);
            this.lblSystemStatus.Name = "lblSystemStatus";
            this.lblSystemStatus.Size = new System.Drawing.Size(74, 13);
            this.lblSystemStatus.TabIndex = 19;
            this.lblSystemStatus.Text = "System Status";
            // 
            // lblSystemDate
            // 
            this.lblSystemDate.AutoSize = true;
            this.lblSystemDate.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblSystemDate.Location = new System.Drawing.Point(19, 135);
            this.lblSystemDate.Name = "lblSystemDate";
            this.lblSystemDate.Size = new System.Drawing.Size(67, 13);
            this.lblSystemDate.TabIndex = 18;
            this.lblSystemDate.Text = "System Date";
            // 
            // lblBranchDescription
            // 
            this.lblBranchDescription.AutoSize = true;
            this.lblBranchDescription.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblBranchDescription.Location = new System.Drawing.Point(19, 101);
            this.lblBranchDescription.Name = "lblBranchDescription";
            this.lblBranchDescription.Size = new System.Drawing.Size(97, 13);
            this.lblBranchDescription.TabIndex = 17;
            this.lblBranchDescription.Text = "Branch Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(20, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "System Information";
            // 
            // butReconsile
            // 
            this.butReconsile.Image = ((System.Drawing.Image)(resources.GetObject("butReconsile.Image")));
            this.butReconsile.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.butReconsile.Location = new System.Drawing.Point(200, 212);
            this.butReconsile.Name = "butReconsile";
            this.butReconsile.Size = new System.Drawing.Size(74, 39);
            this.butReconsile.TabIndex = 24;
            this.butReconsile.Text = "Reconsile";
            this.butReconsile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butReconsile.UseVisualStyleBackColor = true;
            this.butReconsile.Click += new System.EventHandler(this.butReconsile_Click);
            // 
            // butShutDown
            // 
            this.butShutDown.Image = ((System.Drawing.Image)(resources.GetObject("butShutDown.Image")));
            this.butShutDown.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.butShutDown.Location = new System.Drawing.Point(715, 362);
            this.butShutDown.Name = "butShutDown";
            this.butShutDown.Size = new System.Drawing.Size(74, 39);
            this.butShutDown.TabIndex = 26;
            this.butShutDown.Text = "Shut Down";
            this.butShutDown.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butShutDown.UseVisualStyleBackColor = true;
            this.butShutDown.Click += new System.EventHandler(this.butShutDown_Click);
            // 
            // btnODCalculation
            // 
            this.btnODCalculation.Enabled = false;
            this.btnODCalculation.Image = ((System.Drawing.Image)(resources.GetObject("btnODCalculation.Image")));
            this.btnODCalculation.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnODCalculation.Location = new System.Drawing.Point(311, 212);
            this.btnODCalculation.Name = "btnODCalculation";
            this.btnODCalculation.Size = new System.Drawing.Size(95, 39);
            this.btnODCalculation.TabIndex = 27;
            this.btnODCalculation.Text = "OD Calculation";
            this.btnODCalculation.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnODCalculation.UseVisualStyleBackColor = true;
            this.btnODCalculation.Visible = false;
            this.btnODCalculation.Click += new System.EventHandler(this.btnODCalculation_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "AccountNo";
            this.dataGridViewTextBoxColumn1.HeaderText = "Account";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // colCheque
            // 
            this.colCheque.DataPropertyName = "CurrencyCode";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCheque.DefaultCellStyle = dataGridViewCellStyle2;
            this.colCheque.HeaderText = "Currency";
            this.colCheque.Name = "colCheque";
            this.colCheque.ReadOnly = true;
            this.colCheque.Width = 65;
            // 
            // colNOPSign
            // 
            this.colNOPSign.DataPropertyName = "GL";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colNOPSign.DefaultCellStyle = dataGridViewCellStyle3;
            this.colNOPSign.HeaderText = "General Ledger";
            this.colNOPSign.Name = "colNOPSign";
            this.colNOPSign.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Sub";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn3.HeaderText = "Subsidiary";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // colCommunicationCharges
            // 
            this.colCommunicationCharges.DataPropertyName = "Diff";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colCommunicationCharges.DefaultCellStyle = dataGridViewCellStyle5;
            this.colCommunicationCharges.HeaderText = "Difference (GL - Subsidiary)";
            this.colCommunicationCharges.Name = "colCommunicationCharges";
            this.colCommunicationCharges.ReadOnly = true;
            this.colCommunicationCharges.Width = 150;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Staus";
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // TCMVEW00015
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 421);
            this.Controls.Add(this.btnODCalculation);
            this.Controls.Add(this.butShutDown);
            this.Controls.Add(this.butReconsile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblBankHead);
            this.Controls.Add(this.lblSystemStatus);
            this.Controls.Add(this.lblSystemDate);
            this.Controls.Add(this.lblBranchDescription);
            this.Controls.Add(this.gvDailyReconsile);
            this.Controls.Add(this.tsbCRUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TCMVEW00015";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "System Shut Down";
            this.Load += new System.EventHandler(this.TCMVEW00015_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvDailyReconsile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.AceGridView gvDailyReconsile;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblBankHead;
        private System.Windows.Forms.Label lblSystemStatus;
        private System.Windows.Forms.Label lblSystemDate;
        private System.Windows.Forms.Label lblBranchDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butReconsile;
        private System.Windows.Forms.Button butShutDown;
        private System.Windows.Forms.Button btnODCalculation;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNOPSign;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCommunicationCharges;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    }
}