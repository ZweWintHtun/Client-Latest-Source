namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00034
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00034));
            this.gVRemittanceDrawingStatusDetail = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colHostBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDuplicate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSuccess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblRemittanceDrawingStatus = new Ace.Windows.CXClient.Controls.CXC0003();
            ((System.ComponentModel.ISupportInitialize)(this.gVRemittanceDrawingStatusDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // gVRemittanceDrawingStatusDetail
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gVRemittanceDrawingStatusDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gVRemittanceDrawingStatusDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gVRemittanceDrawingStatusDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHostBranch,
            this.colDuplicate,
            this.colSuccess,
            this.colFail,
            this.colStatus});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gVRemittanceDrawingStatusDetail.DefaultCellStyle = dataGridViewCellStyle2;
            this.gVRemittanceDrawingStatusDetail.EnableHeadersVisualStyles = false;
            this.gVRemittanceDrawingStatusDetail.IdTSList = null;
            this.gVRemittanceDrawingStatusDetail.IsEscapeKey = false;
            this.gVRemittanceDrawingStatusDetail.IsHeaderClick = false;
            this.gVRemittanceDrawingStatusDetail.Location = new System.Drawing.Point(15, 75);
            this.gVRemittanceDrawingStatusDetail.Name = "gVRemittanceDrawingStatusDetail";
            this.gVRemittanceDrawingStatusDetail.RowHeadersWidth = 25;
            this.gVRemittanceDrawingStatusDetail.ShowSerialNo = false;
            this.gVRemittanceDrawingStatusDetail.Size = new System.Drawing.Size(561, 174);
            this.gVRemittanceDrawingStatusDetail.TabIndex = 1;
            // 
            // colHostBranch
            // 
            this.colHostBranch.DataPropertyName = "BranchCode";
            this.colHostBranch.HeaderText = "Host Branch";
            this.colHostBranch.Name = "colHostBranch";
            this.colHostBranch.ReadOnly = true;
            // 
            // colDuplicate
            // 
            this.colDuplicate.DataPropertyName = "DupNo";
            this.colDuplicate.HeaderText = "Duplicate";
            this.colDuplicate.Name = "colDuplicate";
            this.colDuplicate.ReadOnly = true;
            // 
            // colSuccess
            // 
            this.colSuccess.DataPropertyName = "AgRno";
            this.colSuccess.HeaderText = "Success";
            this.colSuccess.Name = "colSuccess";
            this.colSuccess.ReadOnly = true;
            // 
            // colFail
            // 
            this.colFail.DataPropertyName = "DagRno";
            this.colFail.HeaderText = "Fail";
            this.colFail.Name = "colFail";
            this.colFail.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(595, 31);
            this.tsbCRUD.TabIndex = 58;
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblRemittanceDrawingStatus
            // 
            this.lblRemittanceDrawingStatus.AutoSize = true;
            this.lblRemittanceDrawingStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemittanceDrawingStatus.Location = new System.Drawing.Point(176, 45);
            this.lblRemittanceDrawingStatus.Name = "lblRemittanceDrawingStatus";
            this.lblRemittanceDrawingStatus.Size = new System.Drawing.Size(84, 15);
            this.lblRemittanceDrawingStatus.TabIndex = 63;
            this.lblRemittanceDrawingStatus.Text = "Remittance ";
            // 
            // TLMVEW00034
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 277);
            this.Controls.Add(this.lblRemittanceDrawingStatus);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.gVRemittanceDrawingStatusDetail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TLMVEW00034";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.TLMVEW00034_Load);
            this.Move += new System.EventHandler(this.TLMVEW00034_Move);
            ((System.ComponentModel.ISupportInitialize)(this.gVRemittanceDrawingStatusDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ace.Windows.CXClient.Controls.AceGridView gVRemittanceDrawingStatusDetail;
        private Ace.Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Ace.Windows.CXClient.Controls.CXC0003 lblRemittanceDrawingStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHostBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDuplicate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSuccess;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    }
}