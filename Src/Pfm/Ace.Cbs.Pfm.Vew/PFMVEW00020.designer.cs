namespace Ace.Cbs.Pfm.Vew
{
    partial class frmPFMVEW00020
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPFMVEW00020));
            this.gboSavingACWithdrawPrinting = new System.Windows.Forms.GroupBox();
            this.butContinue = new Ace.Windows.CXClient.Controls.CXC0007();
            this.cboTransactionType = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblTransactionType = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxcliC0011 = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gboSavingACWithdrawPrinting.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboSavingACWithdrawPrinting
            // 
            this.gboSavingACWithdrawPrinting.Controls.Add(this.butContinue);
            this.gboSavingACWithdrawPrinting.Controls.Add(this.cboTransactionType);
            this.gboSavingACWithdrawPrinting.Controls.Add(this.lblTransactionType);
            this.gboSavingACWithdrawPrinting.Location = new System.Drawing.Point(11, 34);
            this.gboSavingACWithdrawPrinting.Name = "gboSavingACWithdrawPrinting";
            this.gboSavingACWithdrawPrinting.Size = new System.Drawing.Size(275, 108);
            this.gboSavingACWithdrawPrinting.TabIndex = 1;
            this.gboSavingACWithdrawPrinting.TabStop = false;
            this.gboSavingACWithdrawPrinting.Text = "Saving Account Withdrawal Form Printing";
            // 
            // butContinue
            // 
            this.butContinue.Image = ((System.Drawing.Image)(resources.GetObject("butContinue.Image")));
            this.butContinue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butContinue.Location = new System.Drawing.Point(187, 73);
            this.butContinue.Name = "butContinue";
            this.butContinue.Size = new System.Drawing.Size(76, 24);
            this.butContinue.TabIndex = 2;
            this.butContinue.Text = "Contin&ue";
            this.butContinue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butContinue.UseVisualStyleBackColor = true;
            this.butContinue.Click += new System.EventHandler(this.butContinue_Click);
            // 
            // cboTransactionType
            // 
            this.cboTransactionType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboTransactionType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTransactionType.DropDownHeight = 200;
            this.cboTransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransactionType.FormattingEnabled = true;
            this.cboTransactionType.IntegralHeight = false;
            this.cboTransactionType.IsSendTabOnEnter = true;
            this.cboTransactionType.Items.AddRange(new object[] {
            "Withdrawal Form",
            "Withdrawal (Online) Form"});
            this.cboTransactionType.Location = new System.Drawing.Point(122, 36);
            this.cboTransactionType.Name = "cboTransactionType";
            this.cboTransactionType.Size = new System.Drawing.Size(141, 21);
            this.cboTransactionType.TabIndex = 1;
            this.cboTransactionType.TabStop = false;
            // 
            // lblTransactionType
            // 
            this.lblTransactionType.AutoSize = true;
            this.lblTransactionType.Location = new System.Drawing.Point(4, 39);
            this.lblTransactionType.Name = "lblTransactionType";
            this.lblTransactionType.Size = new System.Drawing.Size(99, 13);
            this.lblTransactionType.TabIndex = 0;
            this.lblTransactionType.Text = "Transaction Type  :";
            // 
            // cxcliC0011
            // 
            this.cxcliC0011.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cxcliC0011.BackColor = System.Drawing.Color.PowderBlue;
            this.cxcliC0011.Location = new System.Drawing.Point(-1, 0);
            this.cxcliC0011.Name = "cxcliC0011";
            this.cxcliC0011.PrintButtonCauseValidation = true;
            this.cxcliC0011.Size = new System.Drawing.Size(494, 30);
            this.cxcliC0011.TabIndex = 2;
            this.cxcliC0011.CancelButtonClick += new System.EventHandler(this.cxcliC0011_CancelButtonClick);
            this.cxcliC0011.ExitButtonClick += new System.EventHandler(this.cxcliC0011_ExitButtonClick);
            // 
            // frmPFMVEW00020
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 152);
            this.Controls.Add(this.cxcliC0011);
            this.Controls.Add(this.gboSavingACWithdrawPrinting);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPFMVEW00020";
            this.Text = "Saving A/C Withdraw Form Printing";
            this.Load += new System.EventHandler(this.frmPFMVEW00020_Load);
            this.Move += new System.EventHandler(this.frmPFMVEW00020_Move);
            this.gboSavingACWithdrawPrinting.ResumeLayout(false);
            this.gboSavingACWithdrawPrinting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboSavingACWithdrawPrinting;
        private Ace.Windows.CXClient.Controls.CXC0007 butContinue;
        private Ace.Windows.CXClient.Controls.CXC0002 cboTransactionType;
        private Ace.Windows.CXClient.Controls.CXC0003 lblTransactionType;
        private Ace.Windows.CXClient.Controls.CXCLIC001 cxcliC0011;
    }
}