namespace Ace.Cbs.Tel.Vew
{
	partial class frmTLMVEW00024
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTLMVEW00024));
            this.lblAccountType = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboAccountType = new Ace.Windows.CXClient.Controls.CXC0002();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.butContinue = new Ace.Windows.CXClient.Controls.CXC0007();
            this.SuspendLayout();
            // 
            // lblAccountType
            // 
            this.lblAccountType.AutoSize = true;
            this.lblAccountType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAccountType.Location = new System.Drawing.Point(17, 53);
            this.lblAccountType.Name = "lblAccountType";
            this.lblAccountType.Size = new System.Drawing.Size(80, 13);
            this.lblAccountType.TabIndex = 0;
            this.lblAccountType.Text = "Account Type :";
            // 
            // cboAccountType
            // 
            this.cboAccountType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboAccountType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAccountType.DropDownHeight = 200;
            this.cboAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccountType.FormattingEnabled = true;
            this.cboAccountType.IntegralHeight = false;
            this.cboAccountType.IsSendTabOnEnter = true;
            this.cboAccountType.Items.AddRange(new object[] {
            "Current Account",
            "Saving Account",
            "Fixed Deposit Account"});
            this.cboAccountType.Location = new System.Drawing.Point(111, 50);
            this.cboAccountType.Name = "cboAccountType";
            this.cboAccountType.Size = new System.Drawing.Size(217, 21);
            this.cboAccountType.TabIndex = 1;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-3, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(499, 31);
            this.tsbCRUD.TabIndex = 3;
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // butContinue
            // 
            this.butContinue.Image = ((System.Drawing.Image)(resources.GetObject("butContinue.Image")));
            this.butContinue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butContinue.Location = new System.Drawing.Point(176, 86);
            this.butContinue.Name = "butContinue";
            this.butContinue.Size = new System.Drawing.Size(76, 24);
            this.butContinue.TabIndex = 2;
            this.butContinue.Text = "&Continue";
            this.butContinue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butContinue.UseVisualStyleBackColor = true;
            this.butContinue.Click += new System.EventHandler(this.butContinue_Click);
            // 
            // frmTLMVEW00024
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 131);
            this.Controls.Add(this.butContinue);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.cboAccountType);
            this.Controls.Add(this.lblAccountType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTLMVEW00024";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.TLMVEW00024_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private Ace.Windows.CXClient.Controls.CXC0003 lblAccountType;
        private Ace.Windows.CXClient.Controls.CXC0002 cboAccountType;
        private Ace.Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Ace.Windows.CXClient.Controls.CXC0007 butContinue;
	}
}