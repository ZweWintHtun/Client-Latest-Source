namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00069
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00069));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.rdoAllAccount = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoExcessAccount = new Ace.Windows.CXClient.Controls.CXC0009();
            this.grpSortBy = new System.Windows.Forms.GroupBox();
            this.grpSortBy.SuspendLayout();
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
            this.tsbCRUD.Size = new System.Drawing.Size(487, 31);
            this.tsbCRUD.TabIndex = 27;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // rdoAllAccount
            // 
            this.rdoAllAccount.AutoSize = true;
            this.rdoAllAccount.IsSendTabOnEnter = true;
            this.rdoAllAccount.Location = new System.Drawing.Point(30, 26);
            this.rdoAllAccount.Name = "rdoAllAccount";
            this.rdoAllAccount.Size = new System.Drawing.Size(79, 17);
            this.rdoAllAccount.TabIndex = 29;
            this.rdoAllAccount.TabStop = true;
            this.rdoAllAccount.Text = "All Account";
            this.rdoAllAccount.UseVisualStyleBackColor = true;
            // 
            // rdoExcessAccount
            // 
            this.rdoExcessAccount.AutoSize = true;
            this.rdoExcessAccount.IsSendTabOnEnter = true;
            this.rdoExcessAccount.Location = new System.Drawing.Point(30, 50);
            this.rdoExcessAccount.Name = "rdoExcessAccount";
            this.rdoExcessAccount.Size = new System.Drawing.Size(102, 17);
            this.rdoExcessAccount.TabIndex = 30;
            this.rdoExcessAccount.TabStop = true;
            this.rdoExcessAccount.Text = "Excess Account";
            this.rdoExcessAccount.UseVisualStyleBackColor = true;
            // 
            // grpSortBy
            // 
            this.grpSortBy.Controls.Add(this.rdoAllAccount);
            this.grpSortBy.Controls.Add(this.rdoExcessAccount);
            this.grpSortBy.Location = new System.Drawing.Point(17, 45);
            this.grpSortBy.Name = "grpSortBy";
            this.grpSortBy.Size = new System.Drawing.Size(212, 83);
            this.grpSortBy.TabIndex = 31;
            this.grpSortBy.TabStop = false;
            this.grpSortBy.Text = "Sort By :";
            // 
            // MNMVEW00069
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 141);
            this.Controls.Add(this.grpSortBy);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00069";
            this.Text = "Link Account Listing";
            this.Load += new System.EventHandler(this.MNMVEW00069_Load);
            this.grpSortBy.ResumeLayout(false);
            this.grpSortBy.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0009 rdoAllAccount;
        private Windows.CXClient.Controls.CXC0009 rdoExcessAccount;
        private System.Windows.Forms.GroupBox grpSortBy;
    }
}