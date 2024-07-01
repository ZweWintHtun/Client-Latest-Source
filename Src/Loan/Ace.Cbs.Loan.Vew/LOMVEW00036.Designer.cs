namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00036
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00036));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gbTransactionType = new System.Windows.Forms.GroupBox();
            this.lbRegistration = new System.Windows.Forms.ListBox();
            this.butOk = new Ace.Windows.CXClient.Controls.CXC0007();
            this.gbTransactionType.SuspendLayout();
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
            this.tsbCRUD.Size = new System.Drawing.Size(483, 36);
            this.tsbCRUD.TabIndex = 4;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // gbTransactionType
            // 
            this.gbTransactionType.Controls.Add(this.lbRegistration);
            this.gbTransactionType.Location = new System.Drawing.Point(12, 42);
            this.gbTransactionType.Name = "gbTransactionType";
            this.gbTransactionType.Size = new System.Drawing.Size(245, 138);
            this.gbTransactionType.TabIndex = 5;
            this.gbTransactionType.TabStop = false;
            this.gbTransactionType.Text = "Loans Registration Type";
            // 
            // lbRegistration
            // 
            this.lbRegistration.FormattingEnabled = true;
            this.lbRegistration.Location = new System.Drawing.Point(9, 19);
            this.lbRegistration.Name = "lbRegistration";
            this.lbRegistration.Size = new System.Drawing.Size(224, 108);
            this.lbRegistration.TabIndex = 0;
            // 
            // butOk
            // 
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(204, 186);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(53, 24);
            this.butOk.TabIndex = 6;
            this.butOk.Text = "&Ok";
            this.butOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // LOMVEW00036
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 225);
            this.Controls.Add(this.gbTransactionType);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00036";
            this.Text = "LOMVEW00036";
            this.Load += new System.EventHandler(this.LOMVEW00036_Load);
            this.gbTransactionType.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox gbTransactionType;
        private Windows.CXClient.Controls.CXC0007 butOk;
        private System.Windows.Forms.ListBox lbRegistration;
    }
}