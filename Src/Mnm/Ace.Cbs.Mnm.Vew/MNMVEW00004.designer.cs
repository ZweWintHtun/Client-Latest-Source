namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00004
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00004));
            this.btnCalculate = new Ace.Windows.CXClient.Controls.CXC0007();
            this.lblRennewalEndDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblRenewalStartDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.mtxtRenewalStartDate = new Ace.Windows.CXClient.Controls.CXC0006();
            this.mtxtRenewalEndDate = new Ace.Windows.CXClient.Controls.CXC0006();
            this.grpBeforeDayClose = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // btnCalculate
            // 
            this.btnCalculate.Image = global::Ace.Cbs.Mnm.Vew.Properties.Resources.Custom_Icon_Design_Pretty_Office_3_Process_Accept;
            this.btnCalculate.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCalculate.Location = new System.Drawing.Point(186, 135);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(102, 40);
            this.btnCalculate.TabIndex = 1;
            this.btnCalculate.Text = "&Calculate";
            this.btnCalculate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCalculate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // lblRennewalEndDate
            // 
            this.lblRennewalEndDate.AutoSize = true;
            this.lblRennewalEndDate.Location = new System.Drawing.Point(68, 103);
            this.lblRennewalEndDate.Name = "lblRennewalEndDate";
            this.lblRennewalEndDate.Size = new System.Drawing.Size(106, 13);
            this.lblRennewalEndDate.TabIndex = 0;
            this.lblRennewalEndDate.Text = "Renewal End Date  :";
            // 
            // lblRenewalStartDate
            // 
            this.lblRenewalStartDate.AutoSize = true;
            this.lblRenewalStartDate.Location = new System.Drawing.Point(68, 70);
            this.lblRenewalStartDate.Name = "lblRenewalStartDate";
            this.lblRenewalStartDate.Size = new System.Drawing.Size(106, 13);
            this.lblRenewalStartDate.TabIndex = 0;
            this.lblRenewalStartDate.Text = "Renewal Start Date :";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(508, 31);
            this.tsbCRUD.TabIndex = 4;
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // mtxtRenewalStartDate
            // 
            this.mtxtRenewalStartDate.BackColor = System.Drawing.Color.White;
            this.mtxtRenewalStartDate.IsSendTabOnEnter = true;
            this.mtxtRenewalStartDate.Location = new System.Drawing.Point(186, 67);
            this.mtxtRenewalStartDate.Mask = "00/00/0000";
            this.mtxtRenewalStartDate.Name = "mtxtRenewalStartDate";
            this.mtxtRenewalStartDate.ReadOnly = true;
            this.mtxtRenewalStartDate.Size = new System.Drawing.Size(90, 20);
            this.mtxtRenewalStartDate.TabIndex = 2;
            this.mtxtRenewalStartDate.ValidatingType = typeof(System.DateTime);
            // 
            // mtxtRenewalEndDate
            // 
            this.mtxtRenewalEndDate.BackColor = System.Drawing.Color.White;
            this.mtxtRenewalEndDate.IsSendTabOnEnter = true;
            this.mtxtRenewalEndDate.Location = new System.Drawing.Point(186, 100);
            this.mtxtRenewalEndDate.Mask = "00/00/0000";
            this.mtxtRenewalEndDate.Name = "mtxtRenewalEndDate";
            this.mtxtRenewalEndDate.ReadOnly = true;
            this.mtxtRenewalEndDate.Size = new System.Drawing.Size(90, 20);
            this.mtxtRenewalEndDate.TabIndex = 5;
            this.mtxtRenewalEndDate.ValidatingType = typeof(System.DateTime);
            // 
            // grpBeforeDayClose
            // 
            this.grpBeforeDayClose.Location = new System.Drawing.Point(23, 37);
            this.grpBeforeDayClose.Name = "grpBeforeDayClose";
            this.grpBeforeDayClose.Size = new System.Drawing.Size(462, 164);
            this.grpBeforeDayClose.TabIndex = 9;
            this.grpBeforeDayClose.TabStop = false;
            this.grpBeforeDayClose.Text = "Fixed Deposit Auto Renewal :";
            // 
            // MNMVEW00004
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 221);
            this.Controls.Add(this.mtxtRenewalEndDate);
            this.Controls.Add(this.mtxtRenewalStartDate);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.lblRennewalEndDate);
            this.Controls.Add(this.lblRenewalStartDate);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.grpBeforeDayClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MNMVEW00004";
            this.Text = "Fixed Deposit Auto Renewal ";
            this.Load += new System.EventHandler(this.MNMVEW00004_Load);
            this.Move += new System.EventHandler(this.MNMVEW00004_Move);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0007 btnCalculate;
        private Windows.CXClient.Controls.CXC0003 lblRennewalEndDate;
        private Windows.CXClient.Controls.CXC0003 lblRenewalStartDate;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0006 mtxtRenewalStartDate;
        private Windows.CXClient.Controls.CXC0006 mtxtRenewalEndDate;
        private System.Windows.Forms.GroupBox grpBeforeDayClose;
    }
}