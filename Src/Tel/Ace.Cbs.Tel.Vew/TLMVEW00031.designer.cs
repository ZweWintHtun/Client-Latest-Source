namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00031
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00031));
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblStartDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblEndDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.dtpEndDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.dtpStartDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.chkAllCustomers = new System.Windows.Forms.CheckBox();
            this.grpIBLDrRePassing = new System.Windows.Forms.GroupBox();
            this.chkWithReversal = new System.Windows.Forms.CheckBox();
            this.grpIBLDrRePassing.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(18, 63);
            this.lblAccountNo.MaximumSize = new System.Drawing.Size(200, 50);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(70, 13);
            this.lblAccountNo.TabIndex = 0;
            this.lblAccountNo.Text = "Account No :";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(18, 93);
            this.lblStartDate.MaximumSize = new System.Drawing.Size(200, 50);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(61, 13);
            this.lblStartDate.TabIndex = 0;
            this.lblStartDate.Text = "Start Date :";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(18, 125);
            this.lblEndDate.MaximumSize = new System.Drawing.Size(200, 50);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(58, 13);
            this.lblEndDate.TabIndex = 0;
            this.lblEndDate.Text = "End Date :";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(487, 31);
            this.tsbCRUD.TabIndex = 3;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dtpEndDate.CustomFormat = "dd/MM/yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.IsSendTabOnEnter = true;
            this.dtpEndDate.Location = new System.Drawing.Point(100, 121);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(115, 20);
            this.dtpEndDate.TabIndex = 3;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dtpStartDate.CustomFormat = "dd/MM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.IsSendTabOnEnter = true;
            this.dtpStartDate.Location = new System.Drawing.Point(100, 89);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(115, 20);
            this.dtpStartDate.TabIndex = 2;
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(100, 59);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 1;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // chkAllCustomers
            // 
            this.chkAllCustomers.AutoSize = true;
            this.chkAllCustomers.Checked = true;
            this.chkAllCustomers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllCustomers.Enabled = false;
            this.chkAllCustomers.Location = new System.Drawing.Point(21, 150);
            this.chkAllCustomers.Name = "chkAllCustomers";
            this.chkAllCustomers.Size = new System.Drawing.Size(89, 17);
            this.chkAllCustomers.TabIndex = 5;
            this.chkAllCustomers.Text = "All Customers";
            this.chkAllCustomers.UseVisualStyleBackColor = true;
            this.chkAllCustomers.Visible = false;
            // 
            // grpIBLDrRePassing
            // 
            this.grpIBLDrRePassing.Controls.Add(this.chkWithReversal);
            this.grpIBLDrRePassing.Location = new System.Drawing.Point(12, 37);
            this.grpIBLDrRePassing.Name = "grpIBLDrRePassing";
            this.grpIBLDrRePassing.Size = new System.Drawing.Size(462, 137);
            this.grpIBLDrRePassing.TabIndex = 7;
            this.grpIBLDrRePassing.TabStop = false;
            this.grpIBLDrRePassing.Text = "Bank Statement Listing By Date";
            // 
            // chkWithReversal
            // 
            this.chkWithReversal.AutoSize = true;
            this.chkWithReversal.Location = new System.Drawing.Point(114, 113);
            this.chkWithReversal.Name = "chkWithReversal";
            this.chkWithReversal.Size = new System.Drawing.Size(93, 17);
            this.chkWithReversal.TabIndex = 6;
            this.chkWithReversal.Text = "With Reversal";
            this.chkWithReversal.UseVisualStyleBackColor = true;
            // 
            // TLMVEW00031
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 186);
            this.Controls.Add(this.chkAllCustomers);
            this.Controls.Add(this.mtxtAccountNo);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.lblAccountNo);
            this.Controls.Add(this.grpIBLDrRePassing);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00031";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bank Statement Listing By Date";
            this.Load += new System.EventHandler(this.TLMVEW00031_Load);
            this.grpIBLDrRePassing.ResumeLayout(false);
            this.grpIBLDrRePassing.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ace.Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblStartDate;
        private Ace.Windows.CXClient.Controls.CXC0003 lblEndDate;
        private Ace.Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Ace.Windows.CXClient.Controls.CXC0005 dtpEndDate;
        private Ace.Windows.CXClient.Controls.CXC0005 dtpStartDate;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private System.Windows.Forms.CheckBox chkAllCustomers;
        private System.Windows.Forms.GroupBox grpIBLDrRePassing;
        private System.Windows.Forms.CheckBox chkWithReversal;
    }
}