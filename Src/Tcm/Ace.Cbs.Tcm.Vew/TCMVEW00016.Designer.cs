namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00016
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00016));
            this.lblCurrentSettlementDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.dtpCurrentSettlementDate = new System.Windows.Forms.DateTimePicker();
            this.dtpNextSettlementDate = new System.Windows.Forms.DateTimePicker();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.pgbStatus = new System.Windows.Forms.ProgressBar();
            this.gbStatus = new System.Windows.Forms.GroupBox();
            this.lblNextSettlementDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.butProcess = new Ace.Windows.CXClient.Controls.CXC0007();
            this.gbStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCurrentSettlementDate
            // 
            this.lblCurrentSettlementDate.AutoSize = true;
            this.lblCurrentSettlementDate.Location = new System.Drawing.Point(15, 58);
            this.lblCurrentSettlementDate.Name = "lblCurrentSettlementDate";
            this.lblCurrentSettlementDate.Size = new System.Drawing.Size(156, 13);
            this.lblCurrentSettlementDate.TabIndex = 0;
            this.lblCurrentSettlementDate.Text = "Cash Current  Settlement Date :";
            // 
            // dtpCurrentSettlementDate
            // 
            this.dtpCurrentSettlementDate.CustomFormat = "dd/MM/yyyy";
            this.dtpCurrentSettlementDate.Enabled = false;
            this.dtpCurrentSettlementDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCurrentSettlementDate.Location = new System.Drawing.Point(182, 52);
            this.dtpCurrentSettlementDate.Name = "dtpCurrentSettlementDate";
            this.dtpCurrentSettlementDate.Size = new System.Drawing.Size(142, 20);
            this.dtpCurrentSettlementDate.TabIndex = 1;
            // 
            // dtpNextSettlementDate
            // 
            this.dtpNextSettlementDate.CustomFormat = "dd/MM/yyyy";
            this.dtpNextSettlementDate.Enabled = false;
            this.dtpNextSettlementDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNextSettlementDate.Location = new System.Drawing.Point(182, 78);
            this.dtpNextSettlementDate.Name = "dtpNextSettlementDate";
            this.dtpNextSettlementDate.Size = new System.Drawing.Size(142, 20);
            this.dtpNextSettlementDate.TabIndex = 2;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(560, 31);
            this.tsbCRUD.TabIndex = 6;
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // pgbStatus
            // 
            this.pgbStatus.Location = new System.Drawing.Point(3, 16);
            this.pgbStatus.Name = "pgbStatus";
            this.pgbStatus.Size = new System.Drawing.Size(523, 25);
            this.pgbStatus.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgbStatus.TabIndex = 5;
            // 
            // gbStatus
            // 
            this.gbStatus.Controls.Add(this.pgbStatus);
            this.gbStatus.Location = new System.Drawing.Point(12, 141);
            this.gbStatus.Name = "gbStatus";
            this.gbStatus.Size = new System.Drawing.Size(529, 50);
            this.gbStatus.TabIndex = 4;
            this.gbStatus.TabStop = false;
            this.gbStatus.Visible = false;
            // 
            // lblNextSettlementDate
            // 
            this.lblNextSettlementDate.AutoSize = true;
            this.lblNextSettlementDate.Location = new System.Drawing.Point(15, 84);
            this.lblNextSettlementDate.Name = "lblNextSettlementDate";
            this.lblNextSettlementDate.Size = new System.Drawing.Size(144, 13);
            this.lblNextSettlementDate.TabIndex = 0;
            this.lblNextSettlementDate.Text = "Cash Next  Settlement Date :";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // butProcess
            // 
            this.butProcess.Image = global::Ace.Cbs.Tcm.Vew.Properties.Resources.Custom_Icon_Design_Pretty_Office_3_Process_Accept_005;
            this.butProcess.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butProcess.Location = new System.Drawing.Point(183, 104);
            this.butProcess.Name = "butProcess";
            this.butProcess.Size = new System.Drawing.Size(84, 31);
            this.butProcess.TabIndex = 3;
            this.butProcess.Text = "Process";
            this.butProcess.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butProcess.UseVisualStyleBackColor = true;
            this.butProcess.Click += new System.EventHandler(this.butProcess_Click);
            // 
            // TCMVEW00016
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 194);
            this.Controls.Add(this.butProcess);
            this.Controls.Add(this.gbStatus);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.dtpNextSettlementDate);
            this.Controls.Add(this.dtpCurrentSettlementDate);
            this.Controls.Add(this.lblNextSettlementDate);
            this.Controls.Add(this.lblCurrentSettlementDate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TCMVEW00016";
            this.Text = " Cash Closing ";
            this.Load += new System.EventHandler(this.TCMVEW00016_Load);
            this.gbStatus.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0003 lblCurrentSettlementDate;
        private System.Windows.Forms.DateTimePicker dtpCurrentSettlementDate;
        private System.Windows.Forms.DateTimePicker dtpNextSettlementDate;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.ProgressBar pgbStatus;
        private System.Windows.Forms.GroupBox gbStatus;
        private Windows.CXClient.Controls.CXC0003 lblNextSettlementDate;
        private Ace.Windows.CXClient.Controls.CXC0007 butProcess;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}