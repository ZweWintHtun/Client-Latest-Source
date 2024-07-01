namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00002
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00002));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblProcessingYear = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblProcessingMonth = new Ace.Windows.CXClient.Controls.CXC0003();
            this.grpAfterDayClose = new System.Windows.Forms.GroupBox();
            this.lblProcessMonth = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblProcessYear = new Ace.Windows.CXClient.Controls.CXC0003();
            this.pgbAfterDayClose = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblProcess = new Ace.Windows.CXClient.Controls.CXC0007();
            this.grpAfterDayClose.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.tsbCRUD.TabIndex = 6;
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblProcessingYear
            // 
            this.lblProcessingYear.AutoSize = true;
            this.lblProcessingYear.Location = new System.Drawing.Point(40, 25);
            this.lblProcessingYear.Name = "lblProcessingYear";
            this.lblProcessingYear.Size = new System.Drawing.Size(90, 13);
            this.lblProcessingYear.TabIndex = 8;
            this.lblProcessingYear.Text = "Processing Year :";
            this.lblProcessingYear.Click += new System.EventHandler(this.lblProcessingYear_Click);
            // 
            // lblProcessingMonth
            // 
            this.lblProcessingMonth.AutoSize = true;
            this.lblProcessingMonth.Location = new System.Drawing.Point(40, 49);
            this.lblProcessingMonth.Name = "lblProcessingMonth";
            this.lblProcessingMonth.Size = new System.Drawing.Size(98, 13);
            this.lblProcessingMonth.TabIndex = 9;
            this.lblProcessingMonth.Text = "Processing Month :";
            // 
            // grpAfterDayClose
            // 
            this.grpAfterDayClose.Controls.Add(this.lblProcessMonth);
            this.grpAfterDayClose.Controls.Add(this.lblProcessYear);
            this.grpAfterDayClose.Controls.Add(this.lblProcessingMonth);
            this.grpAfterDayClose.Controls.Add(this.lblProcessingYear);
            this.grpAfterDayClose.Location = new System.Drawing.Point(27, 50);
            this.grpAfterDayClose.Name = "grpAfterDayClose";
            this.grpAfterDayClose.Size = new System.Drawing.Size(372, 82);
            this.grpAfterDayClose.TabIndex = 10;
            this.grpAfterDayClose.TabStop = false;
            this.grpAfterDayClose.Text = "After Day Close";
            this.grpAfterDayClose.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblProcessMonth
            // 
            this.lblProcessMonth.AutoSize = true;
            this.lblProcessMonth.Location = new System.Drawing.Point(158, 49);
            this.lblProcessMonth.Name = "lblProcessMonth";
            this.lblProcessMonth.Size = new System.Drawing.Size(55, 13);
            this.lblProcessMonth.TabIndex = 11;
            this.lblProcessMonth.Text = "cxC00032";
            // 
            // lblProcessYear
            // 
            this.lblProcessYear.AutoSize = true;
            this.lblProcessYear.Location = new System.Drawing.Point(158, 25);
            this.lblProcessYear.Name = "lblProcessYear";
            this.lblProcessYear.Size = new System.Drawing.Size(55, 13);
            this.lblProcessYear.TabIndex = 10;
            this.lblProcessYear.Text = "cxC00031";
            // 
            // pgbAfterDayClose
            // 
            this.pgbAfterDayClose.Location = new System.Drawing.Point(14, 22);
            this.pgbAfterDayClose.MarqueeAnimationSpeed = 40;
            this.pgbAfterDayClose.Name = "pgbAfterDayClose";
            this.pgbAfterDayClose.Size = new System.Drawing.Size(345, 20);
            this.pgbAfterDayClose.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pgbAfterDayClose);
            this.groupBox1.Location = new System.Drawing.Point(27, 151);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 57);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Processing After Day Close";
            // 
            // lblProcess
            // 
            this.lblProcess.Image = global::Ace.Cbs.Mnm.Vew.Properties.Resources.Custom_Icon_Design_Pretty_Office_3_Process_Accept;
            this.lblProcess.Location = new System.Drawing.Point(409, 56);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(87, 40);
            this.lblProcess.TabIndex = 11;
            this.lblProcess.Text = "&Process";
            this.lblProcess.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblProcess.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.lblProcess.UseVisualStyleBackColor = true;
            this.lblProcess.Click += new System.EventHandler(this.lblProcess_Click_1);
            // 
            // MNMVEW00002
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 233);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblProcess);
            this.Controls.Add(this.grpAfterDayClose);
            this.Controls.Add(this.tsbCRUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MNMVEW00002";
            this.Text = "After DayClose";
            this.Load += new System.EventHandler(this.MNMVEW00002_Load);
            this.Move += new System.EventHandler(this.MNMVEW00002_Move);
            this.grpAfterDayClose.ResumeLayout(false);
            this.grpAfterDayClose.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0003 lblProcessingYear;
        private Windows.CXClient.Controls.CXC0003 lblProcessingMonth;
        private System.Windows.Forms.GroupBox grpAfterDayClose;
        private Windows.CXClient.Controls.CXC0003 lblProcessMonth;
        private Windows.CXClient.Controls.CXC0003 lblProcessYear;
        private Windows.CXClient.Controls.CXC0007 lblProcess;
        private System.Windows.Forms.ProgressBar pgbAfterDayClose;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}