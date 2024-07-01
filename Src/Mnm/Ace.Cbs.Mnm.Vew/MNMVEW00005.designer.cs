namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00005
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00005));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblPostingDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.dtpDailyPosting = new Ace.Windows.CXClient.Controls.CXC0005();
            this.btnPosting = new Ace.Windows.CXClient.Controls.CXC0007();
            this.progressBarPosting = new System.Windows.Forms.ProgressBar();
            this.grpBeforeDayClose = new System.Windows.Forms.GroupBox();
            this.grpPostingStatus = new System.Windows.Forms.GroupBox();
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
            this.tsbCRUD.Size = new System.Drawing.Size(510, 31);
            this.tsbCRUD.TabIndex = 3;
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblPostingDate
            // 
            this.lblPostingDate.AutoSize = true;
            this.lblPostingDate.Location = new System.Drawing.Point(68, 63);
            this.lblPostingDate.Name = "lblPostingDate";
            this.lblPostingDate.Size = new System.Drawing.Size(74, 13);
            this.lblPostingDate.TabIndex = 0;
            this.lblPostingDate.Text = "Posting Date :";
            // 
            // dtpDailyPosting
            // 
            this.dtpDailyPosting.CustomFormat = "dd/MMM/yyyy";
            this.dtpDailyPosting.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDailyPosting.IsSendTabOnEnter = true;
            this.dtpDailyPosting.Location = new System.Drawing.Point(156, 60);
            this.dtpDailyPosting.Name = "dtpDailyPosting";
            this.dtpDailyPosting.Size = new System.Drawing.Size(115, 20);
            this.dtpDailyPosting.TabIndex = 1;
            // 
            // btnPosting
            // 
            this.btnPosting.Image = global::Ace.Cbs.Mnm.Vew.Properties.Resources.Custom_Icon_Design_Pretty_Office_3_Process_Accept;
            this.btnPosting.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPosting.Location = new System.Drawing.Point(407, 43);
            this.btnPosting.Name = "btnPosting";
            this.btnPosting.Size = new System.Drawing.Size(87, 40);
            this.btnPosting.TabIndex = 4;
            this.btnPosting.Text = "&Posting";
            this.btnPosting.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPosting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPosting.UseVisualStyleBackColor = true;
            this.btnPosting.Click += new System.EventHandler(this.btnPosting_Click);
            // 
            // progressBarPosting
            // 
            this.progressBarPosting.Location = new System.Drawing.Point(69, 143);
            this.progressBarPosting.Name = "progressBarPosting";
            this.progressBarPosting.Size = new System.Drawing.Size(202, 23);
            this.progressBarPosting.TabIndex = 9;
            this.progressBarPosting.Value = 20;
            this.progressBarPosting.Visible = false;
            // 
            // grpBeforeDayClose
            // 
            this.grpBeforeDayClose.Location = new System.Drawing.Point(12, 37);
            this.grpBeforeDayClose.Name = "grpBeforeDayClose";
            this.grpBeforeDayClose.Size = new System.Drawing.Size(376, 69);
            this.grpBeforeDayClose.TabIndex = 12;
            this.grpBeforeDayClose.TabStop = false;
            this.grpBeforeDayClose.Text = "Daily Posting:";
            // 
            // grpPostingStatus
            // 
            this.grpPostingStatus.Location = new System.Drawing.Point(12, 114);
            this.grpPostingStatus.Name = "grpPostingStatus";
            this.grpPostingStatus.Size = new System.Drawing.Size(376, 73);
            this.grpPostingStatus.TabIndex = 62;
            this.grpPostingStatus.TabStop = false;
            this.grpPostingStatus.Text = "Posting Status:";
            // 
            // MNMVEW00005
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 199);
            this.Controls.Add(this.btnPosting);
            this.Controls.Add(this.progressBarPosting);
            this.Controls.Add(this.dtpDailyPosting);
            this.Controls.Add(this.lblPostingDate);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.grpBeforeDayClose);
            this.Controls.Add(this.grpPostingStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MNMVEW00005";
            this.Text = "Daily Posting";
            this.Load += new System.EventHandler(this.MNMVEW00005_Load);
            this.Move += new System.EventHandler(this.MNMVEW00005_Move);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0003 lblPostingDate;
        private Windows.CXClient.Controls.CXC0005 dtpDailyPosting;
        private Windows.CXClient.Controls.CXC0007 btnPosting;
        private System.Windows.Forms.ProgressBar progressBarPosting;
        private System.Windows.Forms.GroupBox grpBeforeDayClose;
        private System.Windows.Forms.GroupBox grpPostingStatus;

    }
}