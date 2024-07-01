namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00006
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00006));
            this.dtpYearlyPosting = new Ace.Windows.CXClient.Controls.CXC0005();
            this.lblPostingDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.btnPosting = new Ace.Windows.CXClient.Controls.CXC0007();
            this.progressBarPosting = new System.Windows.Forms.ProgressBar();
            this.lblstatus = new System.Windows.Forms.Label();
            this.grpBeforeDayClose = new System.Windows.Forms.GroupBox();
            this.grpPostingStatus = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // dtpYearlyPosting
            // 
            this.dtpYearlyPosting.CustomFormat = "dd/MMM/yyyy";
            this.dtpYearlyPosting.Enabled = false;
            this.dtpYearlyPosting.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpYearlyPosting.IsSendTabOnEnter = true;
            this.dtpYearlyPosting.Location = new System.Drawing.Point(156, 62);
            this.dtpYearlyPosting.Name = "dtpYearlyPosting";
            this.dtpYearlyPosting.Size = new System.Drawing.Size(115, 20);
            this.dtpYearlyPosting.TabIndex = 1;
            // 
            // lblPostingDate
            // 
            this.lblPostingDate.AutoSize = true;
            this.lblPostingDate.Location = new System.Drawing.Point(68, 65);
            this.lblPostingDate.Name = "lblPostingDate";
            this.lblPostingDate.Size = new System.Drawing.Size(74, 13);
            this.lblPostingDate.TabIndex = 0;
            this.lblPostingDate.Text = "Posting Date :";
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
            this.tsbCRUD.TabIndex = 3;
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // btnPosting
            // 
            this.btnPosting.Image = global::Ace.Cbs.Mnm.Vew.Properties.Resources.Custom_Icon_Design_Pretty_Office_3_Process_Accept;
            this.btnPosting.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPosting.Location = new System.Drawing.Point(409, 45);
            this.btnPosting.Name = "btnPosting";
            this.btnPosting.Size = new System.Drawing.Size(87, 40);
            this.btnPosting.TabIndex = 2;
            this.btnPosting.Text = "&Posting";
            this.btnPosting.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPosting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPosting.UseVisualStyleBackColor = true;
            this.btnPosting.Click += new System.EventHandler(this.btnPosting_Click);
            // 
            // progressBarPosting
            // 
            this.progressBarPosting.Location = new System.Drawing.Point(71, 145);
            this.progressBarPosting.Name = "progressBarPosting";
            this.progressBarPosting.Size = new System.Drawing.Size(202, 23);
            this.progressBarPosting.TabIndex = 8;
            this.progressBarPosting.Value = 20;
            this.progressBarPosting.Visible = false;
            // 
            // lblstatus
            // 
            this.lblstatus.AutoSize = true;
            this.lblstatus.Location = new System.Drawing.Point(72, 182);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(35, 13);
            this.lblstatus.TabIndex = 7;
            this.lblstatus.Text = "label1";
            this.lblstatus.Visible = false;
            // 
            // grpBeforeDayClose
            // 
            this.grpBeforeDayClose.Location = new System.Drawing.Point(12, 38);
            this.grpBeforeDayClose.Name = "grpBeforeDayClose";
            this.grpBeforeDayClose.Size = new System.Drawing.Size(386, 71);
            this.grpBeforeDayClose.TabIndex = 12;
            this.grpBeforeDayClose.TabStop = false;
            this.grpBeforeDayClose.Text = "Yearly Posting:";
            // 
            // grpPostingStatus
            // 
            this.grpPostingStatus.Location = new System.Drawing.Point(12, 122);
            this.grpPostingStatus.Name = "grpPostingStatus";
            this.grpPostingStatus.Size = new System.Drawing.Size(386, 89);
            this.grpPostingStatus.TabIndex = 63;
            this.grpPostingStatus.TabStop = false;
            this.grpPostingStatus.Text = "Posting Status:";
            // 
            // MNMVEW00006
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 223);
            this.Controls.Add(this.btnPosting);
            this.Controls.Add(this.progressBarPosting);
            this.Controls.Add(this.lblstatus);
            this.Controls.Add(this.dtpYearlyPosting);
            this.Controls.Add(this.lblPostingDate);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.grpBeforeDayClose);
            this.Controls.Add(this.grpPostingStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MNMVEW00006";
            this.Text = "Yearly Posting";
            this.Load += new System.EventHandler(this.MNMVEW00006_Load);
            this.Move += new System.EventHandler(this.MNMVEW00006_Move);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0007 btnPosting;
        private Windows.CXClient.Controls.CXC0005 dtpYearlyPosting;
        private Windows.CXClient.Controls.CXC0003 lblPostingDate;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.ProgressBar progressBarPosting;
        private System.Windows.Forms.Label lblstatus;
        private System.Windows.Forms.GroupBox grpBeforeDayClose;
        private System.Windows.Forms.GroupBox grpPostingStatus;
    }
}