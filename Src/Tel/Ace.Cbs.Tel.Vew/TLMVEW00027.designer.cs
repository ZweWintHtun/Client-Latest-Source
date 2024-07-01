namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00027
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00027));
            this.lblStartDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblEndDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblEnterTellerNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.dtpEndDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.mtxtEnterTellerNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.dtpStartDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(12, 21);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(61, 13);
            this.lblStartDate.TabIndex = 0;
            this.lblStartDate.Text = "Start Date :";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(12, 51);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(58, 13);
            this.lblEndDate.TabIndex = 0;
            this.lblEndDate.Text = "End Date :";
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(12, 78);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(73, 13);
            this.lblAccountNo.TabIndex = 0;
            this.lblAccountNo.Text = "Account No. :";
            // 
            // lblEnterTellerNo
            // 
            this.lblEnterTellerNo.AutoSize = true;
            this.lblEnterTellerNo.Location = new System.Drawing.Point(12, 109);
            this.lblEnterTellerNo.Name = "lblEnterTellerNo";
            this.lblEnterTellerNo.Size = new System.Drawing.Size(55, 13);
            this.lblEnterTellerNo.TabIndex = 0;
            this.lblEnterTellerNo.Text = "User No. :";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-2, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(498, 31);
            this.tsbCRUD.TabIndex = 4;
            this.tsbCRUD.butPrint.TabIndex = 4;
            this.tsbCRUD.butCancel.TabIndex = 5;
            this.tsbCRUD.butExit.TabIndex = 6;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dtpEndDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.IsSendTabOnEnter = true;
            this.dtpEndDate.Location = new System.Drawing.Point(115, 45);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(115, 20);
            this.dtpEndDate.TabIndex = 1;
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.BackColor = System.Drawing.SystemColors.Window;
            this.mtxtAccountNo.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtxtAccountNo.HidePromptOnLeave = true;
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(115, 75);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 2;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // mtxtEnterTellerNo
            // 
            this.mtxtEnterTellerNo.BackColor = System.Drawing.SystemColors.Window;
            this.mtxtEnterTellerNo.HidePromptOnLeave = true;
            this.mtxtEnterTellerNo.IsSendTabOnEnter = true;
            this.mtxtEnterTellerNo.Location = new System.Drawing.Point(115, 106);
            this.mtxtEnterTellerNo.Name = "mtxtEnterTellerNo";
            this.mtxtEnterTellerNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtEnterTellerNo.TabIndex = 3;
            this.mtxtEnterTellerNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtEnterTellerNo_KeyPress);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dtpStartDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.IsSendTabOnEnter = true;
            this.dtpStartDate.Location = new System.Drawing.Point(115, 19);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(115, 20);
            this.dtpStartDate.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpStartDate);
            this.groupBox1.Controls.Add(this.mtxtEnterTellerNo);
            this.groupBox1.Controls.Add(this.lblStartDate);
            this.groupBox1.Controls.Add(this.mtxtAccountNo);
            this.groupBox1.Controls.Add(this.lblEndDate);
            this.groupBox1.Controls.Add(this.dtpEndDate);
            this.groupBox1.Controls.Add(this.lblAccountNo);
            this.groupBox1.Controls.Add(this.lblEnterTellerNo);
            this.groupBox1.Location = new System.Drawing.Point(16, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(462, 150);
            this.groupBox1.TabIndex = 70;
            this.groupBox1.TabStop = false;
            // 
            // TLMVEW00027
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 200);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00027";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.TLMVEW00027_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Ace.Windows.CXClient.Controls.CXC0003 lblStartDate;
        private Ace.Windows.CXClient.Controls.CXC0003 lblEndDate;
        private Ace.Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblEnterTellerNo;
        private Ace.Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Ace.Windows.CXClient.Controls.CXC0005 dtpEndDate;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Windows.CXClient.Controls.CXC0006 mtxtEnterTellerNo;
        private Windows.CXClient.Controls.CXC0005 dtpStartDate;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}