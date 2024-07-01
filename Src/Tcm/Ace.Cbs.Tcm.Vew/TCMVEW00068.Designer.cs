namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00068
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00068));
            this.butcutoff = new Ace.Windows.CXClient.Controls.CXC0007();
            this.dtpNextSettlementDate = new System.Windows.Forms.DateTimePicker();
            this.dtpCurrentSettlementDate = new System.Windows.Forms.DateTimePicker();
            this.lblNextSettlementDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCurrentSettlementDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.grpBeforeDayClose = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // butcutoff
            // 
            this.butcutoff.Image = global::Ace.Cbs.Tcm.Vew.Properties.Resources.Custom_Icon_Design_Pretty_Office_3_Process_Accept_005;
            this.butcutoff.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butcutoff.Location = new System.Drawing.Point(175, 106);
            this.butcutoff.Name = "butcutoff";
            this.butcutoff.Size = new System.Drawing.Size(84, 31);
            this.butcutoff.TabIndex = 8;
            this.butcutoff.Text = "Cut Off";
            this.butcutoff.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butcutoff.UseVisualStyleBackColor = true;
            this.butcutoff.Click += new System.EventHandler(this.butcutoff_Click);
            // 
            // dtpNextSettlementDate
            // 
            this.dtpNextSettlementDate.CustomFormat = "dd/MM/yyyy";
            this.dtpNextSettlementDate.Enabled = false;
            this.dtpNextSettlementDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNextSettlementDate.Location = new System.Drawing.Point(175, 80);
            this.dtpNextSettlementDate.Name = "dtpNextSettlementDate";
            this.dtpNextSettlementDate.Size = new System.Drawing.Size(142, 20);
            this.dtpNextSettlementDate.TabIndex = 7;
            // 
            // dtpCurrentSettlementDate
            // 
            this.dtpCurrentSettlementDate.CustomFormat = "dd/MM/yyyy";
            this.dtpCurrentSettlementDate.Enabled = false;
            this.dtpCurrentSettlementDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCurrentSettlementDate.Location = new System.Drawing.Point(175, 54);
            this.dtpCurrentSettlementDate.Name = "dtpCurrentSettlementDate";
            this.dtpCurrentSettlementDate.Size = new System.Drawing.Size(142, 20);
            this.dtpCurrentSettlementDate.TabIndex = 6;
            // 
            // lblNextSettlementDate
            // 
            this.lblNextSettlementDate.AutoSize = true;
            this.lblNextSettlementDate.Location = new System.Drawing.Point(34, 86);
            this.lblNextSettlementDate.Name = "lblNextSettlementDate";
            this.lblNextSettlementDate.Size = new System.Drawing.Size(114, 13);
            this.lblNextSettlementDate.TabIndex = 4;
            this.lblNextSettlementDate.Text = "Next Settlement Date :";
            // 
            // lblCurrentSettlementDate
            // 
            this.lblCurrentSettlementDate.AutoSize = true;
            this.lblCurrentSettlementDate.Location = new System.Drawing.Point(34, 60);
            this.lblCurrentSettlementDate.Name = "lblCurrentSettlementDate";
            this.lblCurrentSettlementDate.Size = new System.Drawing.Size(126, 13);
            this.lblCurrentSettlementDate.TabIndex = 5;
            this.lblCurrentSettlementDate.Text = "Current Settlement Date :";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(495, 31);
            this.tsbCRUD.TabIndex = 9;
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // grpBeforeDayClose
            // 
            this.grpBeforeDayClose.Location = new System.Drawing.Point(10, 34);
            this.grpBeforeDayClose.Name = "grpBeforeDayClose";
            this.grpBeforeDayClose.Size = new System.Drawing.Size(473, 115);
            this.grpBeforeDayClose.TabIndex = 10;
            this.grpBeforeDayClose.TabStop = false;
            this.grpBeforeDayClose.Text = "System Cut Off:";
            // 
            // TCMVEW00068
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 159);
            this.Controls.Add(this.butcutoff);
            this.Controls.Add(this.dtpNextSettlementDate);
            this.Controls.Add(this.dtpCurrentSettlementDate);
            this.Controls.Add(this.lblNextSettlementDate);
            this.Controls.Add(this.lblCurrentSettlementDate);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.grpBeforeDayClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TCMVEW00068";
            this.Text = "Cut Off ";
            this.Load += new System.EventHandler(this.TCMVEW00068_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0007 butcutoff;
        private System.Windows.Forms.DateTimePicker dtpNextSettlementDate;
        private System.Windows.Forms.DateTimePicker dtpCurrentSettlementDate;
        private Windows.CXClient.Controls.CXC0003 lblNextSettlementDate;
        private Windows.CXClient.Controls.CXC0003 lblCurrentSettlementDate;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox grpBeforeDayClose;

    }
}