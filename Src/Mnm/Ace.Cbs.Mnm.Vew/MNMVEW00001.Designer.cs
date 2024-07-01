namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00001
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00001));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.grpBeforeDayClose = new System.Windows.Forms.GroupBox();
            this.lblProcessYear = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblProcessingYear = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblProcessMonth = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblProcessingMonth = new Ace.Windows.CXClient.Controls.CXC0003();
            this.btnProcess = new Ace.Windows.CXClient.Controls.CXC0007();
            this.grpPostingStatus = new System.Windows.Forms.GroupBox();
            this.pgbBeforeDayClose2 = new System.Windows.Forms.ProgressBar();
            this.pgbBeforeDayClose = new System.Windows.Forms.ProgressBar();
            this.tmrProgress = new System.Windows.Forms.Timer(this.components);
            this.tmrProgress2 = new System.Windows.Forms.Timer(this.components);
            this.grpBeforeDayClose.SuspendLayout();
            this.grpPostingStatus.SuspendLayout();
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
            this.tsbCRUD.Size = new System.Drawing.Size(509, 31);
            this.tsbCRUD.TabIndex = 7;
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // grpBeforeDayClose
            // 
            this.grpBeforeDayClose.Controls.Add(this.lblProcessYear);
            this.grpBeforeDayClose.Controls.Add(this.lblProcessingYear);
            this.grpBeforeDayClose.Controls.Add(this.lblProcessMonth);
            this.grpBeforeDayClose.Controls.Add(this.lblProcessingMonth);
            this.grpBeforeDayClose.Location = new System.Drawing.Point(27, 50);
            this.grpBeforeDayClose.Name = "grpBeforeDayClose";
            this.grpBeforeDayClose.Size = new System.Drawing.Size(372, 82);
            this.grpBeforeDayClose.TabIndex = 8;
            this.grpBeforeDayClose.TabStop = false;
            this.grpBeforeDayClose.Text = "Before DayClose :";
            // 
            // lblProcessYear
            // 
            this.lblProcessYear.AutoSize = true;
            this.lblProcessYear.Location = new System.Drawing.Point(159, 51);
            this.lblProcessYear.Name = "lblProcessYear";
            this.lblProcessYear.Size = new System.Drawing.Size(55, 13);
            this.lblProcessYear.TabIndex = 0;
            this.lblProcessYear.Text = "cxC00031";
            // 
            // lblProcessingYear
            // 
            this.lblProcessingYear.AutoSize = true;
            this.lblProcessingYear.Location = new System.Drawing.Point(41, 51);
            this.lblProcessingYear.Name = "lblProcessingYear";
            this.lblProcessingYear.Size = new System.Drawing.Size(90, 13);
            this.lblProcessingYear.TabIndex = 0;
            this.lblProcessingYear.Text = "Processing Year :";
            // 
            // lblProcessMonth
            // 
            this.lblProcessMonth.AutoSize = true;
            this.lblProcessMonth.Location = new System.Drawing.Point(159, 24);
            this.lblProcessMonth.Name = "lblProcessMonth";
            this.lblProcessMonth.Size = new System.Drawing.Size(55, 13);
            this.lblProcessMonth.TabIndex = 0;
            this.lblProcessMonth.Text = "cxC00031";
            // 
            // lblProcessingMonth
            // 
            this.lblProcessingMonth.AutoSize = true;
            this.lblProcessingMonth.Location = new System.Drawing.Point(41, 24);
            this.lblProcessingMonth.Name = "lblProcessingMonth";
            this.lblProcessingMonth.Size = new System.Drawing.Size(98, 13);
            this.lblProcessingMonth.TabIndex = 0;
            this.lblProcessingMonth.Text = "Processing Month :";
            // 
            // btnProcess
            // 
            this.btnProcess.Image = global::Ace.Cbs.Mnm.Vew.Properties.Resources.Custom_Icon_Design_Pretty_Office_3_Process_Accept;
            this.btnProcess.Location = new System.Drawing.Point(409, 56);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(87, 40);
            this.btnProcess.TabIndex = 59;
            this.btnProcess.Text = "&Process";
            this.btnProcess.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProcess.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // grpPostingStatus
            // 
            this.grpPostingStatus.Controls.Add(this.pgbBeforeDayClose2);
            this.grpPostingStatus.Controls.Add(this.pgbBeforeDayClose);
            this.grpPostingStatus.Location = new System.Drawing.Point(27, 151);
            this.grpPostingStatus.Name = "grpPostingStatus";
            this.grpPostingStatus.Size = new System.Drawing.Size(372, 57);
            this.grpPostingStatus.TabIndex = 61;
            this.grpPostingStatus.TabStop = false;
            this.grpPostingStatus.Text = "Posting Status:";
            // 
            // pgbBeforeDayClose2
            // 
            this.pgbBeforeDayClose2.Location = new System.Drawing.Point(18, 22);
            this.pgbBeforeDayClose2.MarqueeAnimationSpeed = 40;
            this.pgbBeforeDayClose2.Name = "pgbBeforeDayClose2";
            this.pgbBeforeDayClose2.Size = new System.Drawing.Size(345, 20);
            this.pgbBeforeDayClose2.TabIndex = 1;
            // 
            // pgbBeforeDayClose
            // 
            this.pgbBeforeDayClose.Location = new System.Drawing.Point(18, 22);
            this.pgbBeforeDayClose.MarqueeAnimationSpeed = 40;
            this.pgbBeforeDayClose.Name = "pgbBeforeDayClose";
            this.pgbBeforeDayClose.Size = new System.Drawing.Size(345, 20);
            this.pgbBeforeDayClose.TabIndex = 0;
            // 
            // tmrProgress
            // 
            this.tmrProgress.Interval = 30;
            this.tmrProgress.Tick += new System.EventHandler(this.tmrProgress_Tick);
            // 
            // tmrProgress2
            // 
            this.tmrProgress2.Interval = 30;
            // 
            // MNMVEW00001
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 233);
            this.Controls.Add(this.grpPostingStatus);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.grpBeforeDayClose);
            this.Controls.Add(this.tsbCRUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MNMVEW00001";
            this.Text = "Before DayClose";
            this.Load += new System.EventHandler(this.MNMVEW00001_Load);
            this.Move += new System.EventHandler(this.MNMVEW00001_Move);
            this.grpBeforeDayClose.ResumeLayout(false);
            this.grpBeforeDayClose.PerformLayout();
            this.grpPostingStatus.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox grpBeforeDayClose;
        private Windows.CXClient.Controls.CXC0003 lblProcessYear;
        private Windows.CXClient.Controls.CXC0003 lblProcessingYear;
        private Windows.CXClient.Controls.CXC0003 lblProcessMonth;
        private Windows.CXClient.Controls.CXC0003 lblProcessingMonth;
        private Windows.CXClient.Controls.CXC0007 btnProcess;
        private System.Windows.Forms.GroupBox grpPostingStatus;
        private System.Windows.Forms.ProgressBar pgbBeforeDayClose;
        private System.Windows.Forms.Timer tmrProgress;
        private System.Windows.Forms.Timer tmrProgress2;
        private System.Windows.Forms.ProgressBar pgbBeforeDayClose2;
    }
}