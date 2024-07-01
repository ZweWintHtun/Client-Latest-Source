namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00071
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00071));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTodayDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grpAfterDayClose = new System.Windows.Forms.GroupBox();
            this.rdoAfterBackup = new System.Windows.Forms.RadioButton();
            this.rdoBeforeBackup = new System.Windows.Forms.RadioButton();
            this.rdoDailyBackup = new System.Windows.Forms.RadioButton();
            this.rdoImmediateBackup = new System.Windows.Forms.RadioButton();
            this.btnBackupNow = new Ace.Windows.CXClient.Controls.CXC0007();
            this.grpAfterDayClose.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-4, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(480, 31);
            this.tsbCRUD.TabIndex = 7;
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(337, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Date :";
            // 
            // lblTodayDate
            // 
            this.lblTodayDate.AutoSize = true;
            this.lblTodayDate.Location = new System.Drawing.Point(378, 46);
            this.lblTodayDate.Name = "lblTodayDate";
            this.lblTodayDate.Size = new System.Drawing.Size(0, 13);
            this.lblTodayDate.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Ready to Backup ..........";
            // 
            // grpAfterDayClose
            // 
            this.grpAfterDayClose.Controls.Add(this.rdoAfterBackup);
            this.grpAfterDayClose.Controls.Add(this.rdoBeforeBackup);
            this.grpAfterDayClose.Controls.Add(this.rdoDailyBackup);
            this.grpAfterDayClose.Controls.Add(this.rdoImmediateBackup);
            this.grpAfterDayClose.Location = new System.Drawing.Point(12, 99);
            this.grpAfterDayClose.Name = "grpAfterDayClose";
            this.grpAfterDayClose.Size = new System.Drawing.Size(450, 108);
            this.grpAfterDayClose.TabIndex = 11;
            this.grpAfterDayClose.TabStop = false;
            this.grpAfterDayClose.Text = "Select the Backup Device !";
            // 
            // rdoAfterBackup
            // 
            this.rdoAfterBackup.AutoSize = true;
            this.rdoAfterBackup.Location = new System.Drawing.Point(252, 68);
            this.rdoAfterBackup.Name = "rdoAfterBackup";
            this.rdoAfterBackup.Size = new System.Drawing.Size(87, 17);
            this.rdoAfterBackup.TabIndex = 3;
            this.rdoAfterBackup.TabStop = true;
            this.rdoAfterBackup.Text = "After Backup";
            this.rdoAfterBackup.UseVisualStyleBackColor = true;
            // 
            // rdoBeforeBackup
            // 
            this.rdoBeforeBackup.AutoSize = true;
            this.rdoBeforeBackup.Location = new System.Drawing.Point(252, 33);
            this.rdoBeforeBackup.Name = "rdoBeforeBackup";
            this.rdoBeforeBackup.Size = new System.Drawing.Size(96, 17);
            this.rdoBeforeBackup.TabIndex = 2;
            this.rdoBeforeBackup.TabStop = true;
            this.rdoBeforeBackup.Text = "Before Backup";
            this.rdoBeforeBackup.UseVisualStyleBackColor = true;
            // 
            // rdoDailyBackup
            // 
            this.rdoDailyBackup.AutoSize = true;
            this.rdoDailyBackup.Location = new System.Drawing.Point(91, 68);
            this.rdoDailyBackup.Name = "rdoDailyBackup";
            this.rdoDailyBackup.Size = new System.Drawing.Size(88, 17);
            this.rdoDailyBackup.TabIndex = 1;
            this.rdoDailyBackup.TabStop = true;
            this.rdoDailyBackup.Text = "Daily Backup";
            this.rdoDailyBackup.UseVisualStyleBackColor = true;
            // 
            // rdoImmediateBackup
            // 
            this.rdoImmediateBackup.AutoSize = true;
            this.rdoImmediateBackup.Location = new System.Drawing.Point(91, 33);
            this.rdoImmediateBackup.Name = "rdoImmediateBackup";
            this.rdoImmediateBackup.Size = new System.Drawing.Size(120, 17);
            this.rdoImmediateBackup.TabIndex = 0;
            this.rdoImmediateBackup.TabStop = true;
            this.rdoImmediateBackup.Text = "Immediately Backup";
            this.rdoImmediateBackup.UseVisualStyleBackColor = true;
            // 
            // btnBackupNow
            // 
            this.btnBackupNow.Image = global::Ace.Cbs.Tcm.Vew.Properties.Resources.Custom_Icon_Design_Pretty_Office_3_Process_Accept;
            this.btnBackupNow.Location = new System.Drawing.Point(340, 213);
            this.btnBackupNow.Name = "btnBackupNow";
            this.btnBackupNow.Size = new System.Drawing.Size(122, 40);
            this.btnBackupNow.TabIndex = 12;
            this.btnBackupNow.Text = "&Backup Now";
            this.btnBackupNow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBackupNow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBackupNow.UseVisualStyleBackColor = true;
            this.btnBackupNow.Click += new System.EventHandler(this.btnBackupNow_Click);
            // 
            // TCMVEW00071
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 282);
            this.Controls.Add(this.btnBackupNow);
            this.Controls.Add(this.grpAfterDayClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTodayDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tsbCRUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TCMVEW00071";
            this.Text = "Database Backup Process";
            this.Load += new System.EventHandler(this.TCMVEW00071_Load);
            this.grpAfterDayClose.ResumeLayout(false);
            this.grpAfterDayClose.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTodayDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpAfterDayClose;
        private Windows.CXClient.Controls.CXC0007 btnBackupNow;
        private System.Windows.Forms.RadioButton rdoAfterBackup;
        private System.Windows.Forms.RadioButton rdoBeforeBackup;
        private System.Windows.Forms.RadioButton rdoDailyBackup;
        private System.Windows.Forms.RadioButton rdoImmediateBackup;
    }
}