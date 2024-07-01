namespace Ace.Cbs.Gl.Vew
{
    partial class GLMVEW00023
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
            this.progressBarPosting = new System.Windows.Forms.ProgressBar();
            this.dtpMonthlyPosting = new Ace.Windows.CXClient.Controls.CXC0005();
            this.lblPostingDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.grpBeforeDayClose = new System.Windows.Forms.GroupBox();
            this.grpPostingStatus = new System.Windows.Forms.GroupBox();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.btnPosting = new Ace.Windows.CXClient.Controls.CXC0007();
            this.gpBranchInfo = new System.Windows.Forms.GroupBox();
            this.chkBranch = new Ace.Windows.CXClient.Controls.CXC0008();
            this.lblBranchNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboBranchNo = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblBranch = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gpBranchInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBarPosting
            // 
            this.progressBarPosting.Location = new System.Drawing.Point(70, 228);
            this.progressBarPosting.Name = "progressBarPosting";
            this.progressBarPosting.Size = new System.Drawing.Size(202, 23);
            this.progressBarPosting.TabIndex = 67;
            this.progressBarPosting.Value = 20;
            this.progressBarPosting.Visible = false;
            // 
            // dtpMonthlyPosting
            // 
            this.dtpMonthlyPosting.CustomFormat = "MMM/yyyy";
            this.dtpMonthlyPosting.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonthlyPosting.IsSendTabOnEnter = true;
            this.dtpMonthlyPosting.Location = new System.Drawing.Point(157, 155);
            this.dtpMonthlyPosting.Name = "dtpMonthlyPosting";
            this.dtpMonthlyPosting.Size = new System.Drawing.Size(115, 20);
            this.dtpMonthlyPosting.TabIndex = 64;
            // 
            // lblPostingDate
            // 
            this.lblPostingDate.AutoSize = true;
            this.lblPostingDate.Location = new System.Drawing.Point(69, 158);
            this.lblPostingDate.Name = "lblPostingDate";
            this.lblPostingDate.Size = new System.Drawing.Size(74, 13);
            this.lblPostingDate.TabIndex = 63;
            this.lblPostingDate.Text = "Posting Date :";
            // 
            // grpBeforeDayClose
            // 
            this.grpBeforeDayClose.Location = new System.Drawing.Point(13, 126);
            this.grpBeforeDayClose.Name = "grpBeforeDayClose";
            this.grpBeforeDayClose.Size = new System.Drawing.Size(376, 69);
            this.grpBeforeDayClose.TabIndex = 68;
            this.grpBeforeDayClose.TabStop = false;
            this.grpBeforeDayClose.Text = "Daily Posting:";
            // 
            // grpPostingStatus
            // 
            this.grpPostingStatus.Location = new System.Drawing.Point(13, 200);
            this.grpPostingStatus.Name = "grpPostingStatus";
            this.grpPostingStatus.Size = new System.Drawing.Size(376, 73);
            this.grpPostingStatus.TabIndex = 69;
            this.grpPostingStatus.TabStop = false;
            this.grpPostingStatus.Text = "Posting Status:";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-7, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(510, 31);
            this.tsbCRUD.TabIndex = 70;
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // btnPosting
            // 
            this.btnPosting.Image = global::Ace.Cbs.Gl.Vew.Properties.Resources.Custom_Icon_Design_Pretty_Office_3_Process_Accept;
            this.btnPosting.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPosting.Location = new System.Drawing.Point(399, 227);
            this.btnPosting.Name = "btnPosting";
            this.btnPosting.Size = new System.Drawing.Size(87, 40);
            this.btnPosting.TabIndex = 66;
            this.btnPosting.Text = "&Posting";
            this.btnPosting.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPosting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPosting.UseVisualStyleBackColor = true;
            this.btnPosting.Click += new System.EventHandler(this.btnPosting_Click);
            // 
            // gpBranchInfo
            // 
            this.gpBranchInfo.Controls.Add(this.chkBranch);
            this.gpBranchInfo.Controls.Add(this.lblBranchNo);
            this.gpBranchInfo.Controls.Add(this.cboBranchNo);
            this.gpBranchInfo.Controls.Add(this.lblBranch);
            this.gpBranchInfo.Location = new System.Drawing.Point(13, 37);
            this.gpBranchInfo.Name = "gpBranchInfo";
            this.gpBranchInfo.Size = new System.Drawing.Size(376, 81);
            this.gpBranchInfo.TabIndex = 71;
            this.gpBranchInfo.TabStop = false;
            this.gpBranchInfo.Text = "Branch";
            // 
            // chkBranch
            // 
            this.chkBranch.AutoSize = true;
            this.chkBranch.IsSendTabOnEnter = true;
            this.chkBranch.Location = new System.Drawing.Point(30, 20);
            this.chkBranch.Name = "chkBranch";
            this.chkBranch.Size = new System.Drawing.Size(77, 17);
            this.chkBranch.TabIndex = 1;
            this.chkBranch.Text = "All Branch.";
            this.chkBranch.UseVisualStyleBackColor = true;
            this.chkBranch.Visible = false;
            this.chkBranch.CheckedChanged += new System.EventHandler(this.chkBranch_CheckedChanged);
            // 
            // lblBranchNo
            // 
            this.lblBranchNo.AutoSize = true;
            this.lblBranchNo.Location = new System.Drawing.Point(113, 46);
            this.lblBranchNo.Name = "lblBranchNo";
            this.lblBranchNo.Size = new System.Drawing.Size(65, 13);
            this.lblBranchNo.TabIndex = 17;
            this.lblBranchNo.Text = "lblBranchNo";
            this.lblBranchNo.Visible = false;
            // 
            // cboBranchNo
            // 
            this.cboBranchNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboBranchNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBranchNo.DropDownHeight = 200;
            this.cboBranchNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBranchNo.FormattingEnabled = true;
            this.cboBranchNo.IntegralHeight = false;
            this.cboBranchNo.IsSendTabOnEnter = true;
            this.cboBranchNo.Location = new System.Drawing.Point(116, 43);
            this.cboBranchNo.Name = "cboBranchNo";
            this.cboBranchNo.Size = new System.Drawing.Size(141, 21);
            this.cboBranchNo.TabIndex = 2;
            this.cboBranchNo.Visible = false;
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Location = new System.Drawing.Point(27, 45);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(87, 13);
            this.lblBranch.TabIndex = 0;
            this.lblBranch.Text = "Source Branch : ";
            // 
            // GLMVEW00023
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 279);
            this.Controls.Add(this.gpBranchInfo);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.btnPosting);
            this.Controls.Add(this.progressBarPosting);
            this.Controls.Add(this.dtpMonthlyPosting);
            this.Controls.Add(this.lblPostingDate);
            this.Controls.Add(this.grpBeforeDayClose);
            this.Controls.Add(this.grpPostingStatus);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GLMVEW00023";
            this.Text = "Monthly Posting";
            this.Load += new System.EventHandler(this.GLMVEW00023_Load);
            this.Move += new System.EventHandler(this.GLMVEW00023_Move);
            this.gpBranchInfo.ResumeLayout(false);
            this.gpBranchInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0007 btnPosting;
        private System.Windows.Forms.ProgressBar progressBarPosting;
        private Windows.CXClient.Controls.CXC0005 dtpMonthlyPosting;
        private Windows.CXClient.Controls.CXC0003 lblPostingDate;
        private System.Windows.Forms.GroupBox grpBeforeDayClose;
        private System.Windows.Forms.GroupBox grpPostingStatus;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox gpBranchInfo;
        private Windows.CXClient.Controls.CXC0008 chkBranch;
        private Windows.CXClient.Controls.CXC0003 lblBranchNo;
        private Windows.CXClient.Controls.CXC0002 cboBranchNo;
        private Windows.CXClient.Controls.CXC0003 lblBranch;
    }
}