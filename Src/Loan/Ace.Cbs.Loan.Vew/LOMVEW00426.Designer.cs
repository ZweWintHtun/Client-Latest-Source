namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00426
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00426));
            this.cboACType = new Ace.Windows.CXClient.Controls.CXC0002();
            this.label1 = new System.Windows.Forms.Label();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.butOk = new Ace.Windows.CXClient.Controls.CXC0007();
            this.SuspendLayout();
            // 
            // cboACType
            // 
            this.cboACType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboACType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboACType.DropDownHeight = 200;
            this.cboACType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboACType.FormattingEnabled = true;
            this.cboACType.IntegralHeight = false;
            this.cboACType.IsSendTabOnEnter = true;
            this.cboACType.Items.AddRange(new object[] {
            "Business Loan",
            "Dealer ",
            "Hirepurchase",
            "Personal Loan"});
            this.cboACType.Location = new System.Drawing.Point(127, 62);
            this.cboACType.Name = "cboACType";
            this.cboACType.Size = new System.Drawing.Size(124, 21);
            this.cboACType.TabIndex = 73;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 72;
            this.label1.Text = "Account Type :";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, -5);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(499, 31);
            this.tsbCRUD.TabIndex = 71;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // butOk
            // 
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(302, 94);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(53, 24);
            this.butOk.TabIndex = 70;
            this.butOk.Text = "&Ok";
            this.butOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // LOMVEW00426
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 128);
            this.Controls.Add(this.cboACType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.butOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LOMVEW00426";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Information Enquiry";
            this.Load += new System.EventHandler(this.LOMVEW00426_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0002 cboACType;
        private System.Windows.Forms.Label label1;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0007 butOk;
    }
}