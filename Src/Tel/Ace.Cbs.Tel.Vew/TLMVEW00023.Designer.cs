namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00023
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00023));
            this.butOk = new Ace.Windows.CXClient.Controls.CXC0007();
            this.lbName = new Ace.Windows.CXClient.Controls.CXC0011();
            this.gbTransactionType = new System.Windows.Forms.GroupBox();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gbTransactionType.SuspendLayout();
            this.SuspendLayout();
            // 
            // butOk
            // 
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(177, 230);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(53, 24);
            this.butOk.TabIndex = 2;
            this.butOk.Text = "&Ok";
            this.butOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // lbName
            // 
            this.lbName.Items.AddRange(new object[] {
            "Deposit Listing By All",
            "Deposit Listing By Account Type",
            "Deposit Listing By Account No",
            "Deposit Listing By User No",
            "Deposit Listing By Grade",
            "Withdrawal Listing By All",
            "Withdrawal Listing By Account Type",
            "Withdrawal Listing By Account No",
            "Withdrawal Listing By User No",
            "Withdrawal Listing By Grade"});
            this.lbName.Location = new System.Drawing.Point(14, 19);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(203, 147);
            this.lbName.TabIndex = 1;
            // 
            // gbTransactionType
            // 
            this.gbTransactionType.Controls.Add(this.lbName);
            this.gbTransactionType.Location = new System.Drawing.Point(-3, 40);
            this.gbTransactionType.Name = "gbTransactionType";
            this.gbTransactionType.Size = new System.Drawing.Size(233, 178);
            this.gbTransactionType.TabIndex = 0;
            this.gbTransactionType.TabStop = false;
            this.gbTransactionType.Text = "Transaction Type";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(500, 31);
            this.tsbCRUD.TabIndex = 3;
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // TLMVEW00023
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 266);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.gbTransactionType);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00023";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transaction Listing";
            this.Load += new System.EventHandler(this.TLMVEW00023_Load);
            this.gbTransactionType.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXC0007 butOk;
        private Windows.CXClient.Controls.CXC0011 lbName;
        private System.Windows.Forms.GroupBox gbTransactionType;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
    }
}