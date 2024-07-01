namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00039
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00039));
            this.lbRegistration = new Ace.Windows.CXClient.Controls.CXC0011();
            this.gbTransactionType = new System.Windows.Forms.GroupBox();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.butOk = new Ace.Windows.CXClient.Controls.CXC0007();
            this.gbTransactionType.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbRegistration
            // 
            this.lbRegistration.Items.AddRange(new object[] {
            "Land and Building",
            "Personal Guarantee",
            "Pledge",
            "Hypothecation",
            "Gold and Jewellery",
            "CNG"});
            this.lbRegistration.Location = new System.Drawing.Point(15, 19);
            this.lbRegistration.Name = "lbRegistration";
            this.lbRegistration.Size = new System.Drawing.Size(203, 95);
            this.lbRegistration.TabIndex = 1;
            // 
            // gbTransactionType
            // 
            this.gbTransactionType.Controls.Add(this.lbRegistration);
            this.gbTransactionType.Location = new System.Drawing.Point(7, 43);
            this.gbTransactionType.Name = "gbTransactionType";
            this.gbTransactionType.Size = new System.Drawing.Size(233, 128);
            this.gbTransactionType.TabIndex = 8;
            this.gbTransactionType.TabStop = false;
            this.gbTransactionType.Text = "Loans Registration Type";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-3, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(480, 36);
            this.tsbCRUD.TabIndex = 7;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // butOk
            // 
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(187, 177);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(53, 24);
            this.butOk.TabIndex = 9;
            this.butOk.Text = "&Ok";
            this.butOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // LOMVEW00039
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 203);
            this.Controls.Add(this.gbTransactionType);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00039";
            this.Text = "LOMVEW00039";
            this.Load += new System.EventHandler(this.LOMVEW00039_Load);
            this.gbTransactionType.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXC0011 lbRegistration;
        private System.Windows.Forms.GroupBox gbTransactionType;
        private Windows.CXClient.Controls.CXC0007 butOk;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
    }
}