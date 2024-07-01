namespace Ace.Cbs.Pfm.Vew
{
    partial class frmPFMVEW00016
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPFMVEW00016));
            this.gboAccountOpeingFormPrinting = new System.Windows.Forms.GroupBox();
            this.rdoSavingAccount = new Ace.Windows.CXClient.Controls.CXC0009();
            this.butContinue = new Ace.Windows.CXClient.Controls.CXC0007();
            this.rdoCurrentAccount = new Ace.Windows.CXClient.Controls.CXC0009();
            this.cboFormType = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblFormType = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tlspCommon = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gboAccountOpeingFormPrinting.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboAccountOpeingFormPrinting
            // 
            this.gboAccountOpeingFormPrinting.Controls.Add(this.rdoSavingAccount);
            this.gboAccountOpeingFormPrinting.Controls.Add(this.butContinue);
            this.gboAccountOpeingFormPrinting.Controls.Add(this.rdoCurrentAccount);
            this.gboAccountOpeingFormPrinting.Controls.Add(this.cboFormType);
            this.gboAccountOpeingFormPrinting.Controls.Add(this.lblFormType);
            this.gboAccountOpeingFormPrinting.Location = new System.Drawing.Point(23, 40);
            this.gboAccountOpeingFormPrinting.Name = "gboAccountOpeingFormPrinting";
            this.gboAccountOpeingFormPrinting.Size = new System.Drawing.Size(289, 145);
            this.gboAccountOpeingFormPrinting.TabIndex = 4;
            this.gboAccountOpeingFormPrinting.TabStop = false;
            this.gboAccountOpeingFormPrinting.Text = "Account Opening Form Printing";
            // 
            // rdoSavingAccount
            // 
            this.rdoSavingAccount.AutoSize = true;
            this.rdoSavingAccount.IsSendTabOnEnter = true;
            this.rdoSavingAccount.Location = new System.Drawing.Point(161, 32);
            this.rdoSavingAccount.Name = "rdoSavingAccount";
            this.rdoSavingAccount.Size = new System.Drawing.Size(101, 17);
            this.rdoSavingAccount.TabIndex = 1;
            this.rdoSavingAccount.Text = "Saving Account";
            this.rdoSavingAccount.UseVisualStyleBackColor = true;
            this.rdoSavingAccount.CheckedChanged += new System.EventHandler(this.rdoSavingAccount_CheckedChanged);
            // 
            // butContinue
            // 
            this.butContinue.Image = ((System.Drawing.Image)(resources.GetObject("butContinue.Image")));
            this.butContinue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butContinue.Location = new System.Drawing.Point(186, 100);
            this.butContinue.Name = "butContinue";
            this.butContinue.Size = new System.Drawing.Size(76, 24);
            this.butContinue.TabIndex = 3;
            this.butContinue.Text = "Contin&ue";
            this.butContinue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butContinue.UseVisualStyleBackColor = true;
            this.butContinue.Click += new System.EventHandler(this.butContinue_Click);
            // 
            // rdoCurrentAccount
            // 
            this.rdoCurrentAccount.AutoSize = true;
            this.rdoCurrentAccount.IsSendTabOnEnter = true;
            this.rdoCurrentAccount.Location = new System.Drawing.Point(27, 32);
            this.rdoCurrentAccount.Name = "rdoCurrentAccount";
            this.rdoCurrentAccount.Size = new System.Drawing.Size(102, 17);
            this.rdoCurrentAccount.TabIndex = 0;
            this.rdoCurrentAccount.Text = "Current Account";
            this.rdoCurrentAccount.UseVisualStyleBackColor = true;
            this.rdoCurrentAccount.CheckedChanged += new System.EventHandler(this.rdoCurrentAccount_CheckedChanged);
            // 
            // cboFormType
            // 
            this.cboFormType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboFormType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFormType.DropDownHeight = 200;
            this.cboFormType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormType.FormattingEnabled = true;
            this.cboFormType.IntegralHeight = false;
            this.cboFormType.IsSendTabOnEnter = true;
            this.cboFormType.Location = new System.Drawing.Point(121, 64);
            this.cboFormType.Name = "cboFormType";
            this.cboFormType.Size = new System.Drawing.Size(141, 21);
            this.cboFormType.TabIndex = 2;
            // 
            // lblFormType
            // 
            this.lblFormType.AutoSize = true;
            this.lblFormType.Location = new System.Drawing.Point(24, 67);
            this.lblFormType.Name = "lblFormType";
            this.lblFormType.Size = new System.Drawing.Size(66, 13);
            this.lblFormType.TabIndex = 1;
            this.lblFormType.Text = "Form Type  :";
            // 
            // tlspCommon
            // 
            this.tlspCommon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tlspCommon.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.tlspCommon.BackColor = System.Drawing.Color.PowderBlue;
            this.tlspCommon.Location = new System.Drawing.Point(-1, -1);
            this.tlspCommon.Name = "tlspCommon";
            this.tlspCommon.PrintButtonCauseValidation = true;
            this.tlspCommon.Size = new System.Drawing.Size(498, 30);
            this.tlspCommon.TabIndex = 2;
            this.tlspCommon.CancelButtonClick += new System.EventHandler(this.tlspCommon_CancelButtonClick);
            this.tlspCommon.ExitButtonClick += new System.EventHandler(this.tlspCommon_ExitButtonClick);
            // 
            // frmPFMVEW00016
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 206);
            this.Controls.Add(this.tlspCommon);
            this.Controls.Add(this.gboAccountOpeingFormPrinting);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPFMVEW00016";
            this.Text = "Account Opening Form Printing";
            this.Load += new System.EventHandler(this.frmPFMVEW00016_Load);
            this.gboAccountOpeingFormPrinting.ResumeLayout(false);
            this.gboAccountOpeingFormPrinting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboAccountOpeingFormPrinting;
        private Ace.Windows.CXClient.Controls.CXC0007 butContinue;
        private Ace.Windows.CXClient.Controls.CXC0002 cboFormType;
        private Ace.Windows.CXClient.Controls.CXC0003 lblFormType;
        private Ace.Windows.CXClient.Controls.CXC0009 rdoSavingAccount;
        private Ace.Windows.CXClient.Controls.CXC0009 rdoCurrentAccount;
        private Windows.CXClient.Controls.CXCLIC001 tlspCommon;
    }
}