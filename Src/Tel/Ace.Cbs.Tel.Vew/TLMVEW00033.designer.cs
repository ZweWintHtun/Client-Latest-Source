namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00033
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00033));
            this.lblActiveBranch = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gvBranch = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colBranchCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBranchName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsSelected = new Ace.Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.butReconcile = new Ace.Windows.CXClient.Controls.CXC0007();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gbIBLReconcile = new System.Windows.Forms.GroupBox();
            this.dtpRequiredDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.gbType = new System.Windows.Forms.GroupBox();
            this.rdoDrawing = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoEncash = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoTransaction = new Ace.Windows.CXClient.Controls.CXC0009();
            this.lblSourceBranch = new Ace.Windows.CXClient.Controls.CXC0003();
            ((System.ComponentModel.ISupportInitialize)(this.gvBranch)).BeginInit();
            this.gbIBLReconcile.SuspendLayout();
            this.gbType.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblActiveBranch
            // 
            this.lblActiveBranch.AutoSize = true;
            this.lblActiveBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveBranch.Location = new System.Drawing.Point(26, 31);
            this.lblActiveBranch.Name = "lblActiveBranch";
            this.lblActiveBranch.Size = new System.Drawing.Size(108, 13);
            this.lblActiveBranch.TabIndex = 0;
            this.lblActiveBranch.Text = "Active Branch  is ";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(25, 66);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(42, 13);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Date :";
            // 
            // gvBranch
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvBranch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvBranch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvBranch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBranchCode,
            this.colBranchName,
            this.colIsSelected,
            this.colStatus});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvBranch.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvBranch.EnableHeadersVisualStyles = false;
            this.gvBranch.IdTSList = null;
            this.gvBranch.IsEscapeKey = false;
            this.gvBranch.IsHeaderClick = false;
            this.gvBranch.Location = new System.Drawing.Point(29, 175);
            this.gvBranch.Name = "gvBranch";
            this.gvBranch.RowHeadersWidth = 25;
            this.gvBranch.ShowSerialNo = false;
            this.gvBranch.Size = new System.Drawing.Size(730, 334);
            this.gvBranch.TabIndex = 5;
            // 
            // colBranchCode
            // 
            this.colBranchCode.DataPropertyName = "BranchCode";
            this.colBranchCode.Frozen = true;
            this.colBranchCode.HeaderText = "Branch Code";
            this.colBranchCode.Name = "colBranchCode";
            // 
            // colBranchName
            // 
            this.colBranchName.DataPropertyName = "BranchDescription";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.colBranchName.DefaultCellStyle = dataGridViewCellStyle2;
            this.colBranchName.HeaderText = "Branch Name";
            this.colBranchName.Name = "colBranchName";
            this.colBranchName.Width = 300;
            // 
            // colIsSelected
            // 
            this.colIsSelected.CheckBoxHeader = false;
            this.colIsSelected.DataPropertyName = "IsCheck";
            this.colIsSelected.HeaderText = "";
            this.colIsSelected.Id = 0;
            this.colIsSelected.Name = "colIsSelected";
            this.colIsSelected.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colIsSelected.TrueValue = "True";
            this.colIsSelected.TS = null;
            this.colIsSelected.Width = 70;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Width = 200;
            // 
            // butReconcile
            // 
            this.butReconcile.Location = new System.Drawing.Point(669, 515);
            this.butReconcile.Name = "butReconcile";
            this.butReconcile.Size = new System.Drawing.Size(90, 33);
            this.butReconcile.TabIndex = 6;
            this.butReconcile.Text = "Reconcile";
            this.butReconcile.UseVisualStyleBackColor = true;
            this.butReconcile.Click += new System.EventHandler(this.butReconcile_Click);
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-2, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(827, 31);
            this.tsbCRUD.TabIndex = 8;
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // gbIBLReconcile
            // 
            this.gbIBLReconcile.Controls.Add(this.dtpRequiredDate);
            this.gbIBLReconcile.Controls.Add(this.gbType);
            this.gbIBLReconcile.Controls.Add(this.lblSourceBranch);
            this.gbIBLReconcile.Controls.Add(this.lblDate);
            this.gbIBLReconcile.Controls.Add(this.gvBranch);
            this.gbIBLReconcile.Controls.Add(this.butReconcile);
            this.gbIBLReconcile.Controls.Add(this.lblActiveBranch);
            this.gbIBLReconcile.Location = new System.Drawing.Point(12, 37);
            this.gbIBLReconcile.Name = "gbIBLReconcile";
            this.gbIBLReconcile.Size = new System.Drawing.Size(781, 566);
            this.gbIBLReconcile.TabIndex = 0;
            this.gbIBLReconcile.TabStop = false;
            // 
            // dtpRequiredDate
            // 
            this.dtpRequiredDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpRequiredDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRequiredDate.IsSendTabOnEnter = true;
            this.dtpRequiredDate.Location = new System.Drawing.Point(89, 62);
            this.dtpRequiredDate.Name = "dtpRequiredDate";
            this.dtpRequiredDate.Size = new System.Drawing.Size(115, 20);
            this.dtpRequiredDate.TabIndex = 9;
            // 
            // gbType
            // 
            this.gbType.Controls.Add(this.rdoDrawing);
            this.gbType.Controls.Add(this.rdoEncash);
            this.gbType.Controls.Add(this.rdoTransaction);
            this.gbType.Location = new System.Drawing.Point(29, 101);
            this.gbType.Name = "gbType";
            this.gbType.Size = new System.Drawing.Size(353, 56);
            this.gbType.TabIndex = 8;
            this.gbType.TabStop = false;
            this.gbType.Text = "Type";
            // 
            // rdoDrawing
            // 
            this.rdoDrawing.AutoSize = true;
            this.rdoDrawing.Checked = true;
            this.rdoDrawing.IsSendTabOnEnter = true;
            this.rdoDrawing.Location = new System.Drawing.Point(29, 23);
            this.rdoDrawing.Name = "rdoDrawing";
            this.rdoDrawing.Size = new System.Drawing.Size(64, 17);
            this.rdoDrawing.TabIndex = 2;
            this.rdoDrawing.TabStop = true;
            this.rdoDrawing.Text = "Drawing";
            this.rdoDrawing.UseVisualStyleBackColor = true;
            this.rdoDrawing.CheckedChanged += new System.EventHandler(this.rdoDrawing_CheckedChanged);
            // 
            // rdoEncash
            // 
            this.rdoEncash.AutoSize = true;
            this.rdoEncash.IsSendTabOnEnter = true;
            this.rdoEncash.Location = new System.Drawing.Point(136, 23);
            this.rdoEncash.Name = "rdoEncash";
            this.rdoEncash.Size = new System.Drawing.Size(61, 17);
            this.rdoEncash.TabIndex = 3;
            this.rdoEncash.Text = "Encash";
            this.rdoEncash.UseVisualStyleBackColor = true;
            this.rdoEncash.CheckedChanged += new System.EventHandler(this.rdoEncash_CheckedChanged);
            // 
            // rdoTransaction
            // 
            this.rdoTransaction.AutoSize = true;
            this.rdoTransaction.IsSendTabOnEnter = true;
            this.rdoTransaction.Location = new System.Drawing.Point(236, 23);
            this.rdoTransaction.Name = "rdoTransaction";
            this.rdoTransaction.Size = new System.Drawing.Size(81, 17);
            this.rdoTransaction.TabIndex = 4;
            this.rdoTransaction.Text = "Transaction";
            this.rdoTransaction.UseVisualStyleBackColor = true;
            this.rdoTransaction.CheckedChanged += new System.EventHandler(this.rdoTransaction_CheckedChanged);
            // 
            // lblSourceBranch
            // 
            this.lblSourceBranch.AutoSize = true;
            this.lblSourceBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSourceBranch.Location = new System.Drawing.Point(130, 31);
            this.lblSourceBranch.Name = "lblSourceBranch";
            this.lblSourceBranch.Size = new System.Drawing.Size(87, 13);
            this.lblSourceBranch.TabIndex = 7;
            this.lblSourceBranch.Text = "SourceBranch";
            // 
            // TLMVEW00033
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 622);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.gbIBLReconcile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00033";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IBL Reconcile";
            this.Load += new System.EventHandler(this.TLMVEW00033_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvBranch)).EndInit();
            this.gbIBLReconcile.ResumeLayout(false);
            this.gbIBLReconcile.PerformLayout();
            this.gbType.ResumeLayout(false);
            this.gbType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Ace.Windows.CXClient.Controls.CXC0003 lblActiveBranch;
        private Ace.Windows.CXClient.Controls.CXC0003 lblDate;
        private Ace.Windows.CXClient.Controls.AceGridView gvBranch;
        private Ace.Windows.CXClient.Controls.CXC0007 butReconcile;
   
        private Ace.Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox gbIBLReconcile;
        private Windows.CXClient.Controls.CXC0003 lblSourceBranch;
        private System.Windows.Forms.GroupBox gbType;
        private Windows.CXClient.Controls.CXC0009 rdoDrawing;
        private Windows.CXClient.Controls.CXC0009 rdoEncash;
        private Windows.CXClient.Controls.CXC0009 rdoTransaction;
        private Windows.CXClient.Controls.CXC0005 dtpRequiredDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBranchCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBranchName;
        private Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn colIsSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    }
}