namespace Ace.Cbs.Tel.Vew
{
	partial class TLMVEW00032
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00032));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.dtpRequiredDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.lblRequiredDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.SuspendLayout();
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
            this.tsbCRUD.TabIndex = 2;
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // dtpRequiredDate
            // 
            this.dtpRequiredDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpRequiredDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRequiredDate.IsSendTabOnEnter = true;
            this.dtpRequiredDate.Location = new System.Drawing.Point(100, 54);
            this.dtpRequiredDate.Name = "dtpRequiredDate";
            this.dtpRequiredDate.Size = new System.Drawing.Size(115, 20);
            this.dtpRequiredDate.TabIndex = 1;
            // 
            // lblRequiredDate
            // 
            this.lblRequiredDate.AutoSize = true;
            this.lblRequiredDate.Location = new System.Drawing.Point(12, 58);
            this.lblRequiredDate.MaximumSize = new System.Drawing.Size(200, 50);
            this.lblRequiredDate.Name = "lblRequiredDate";
            this.lblRequiredDate.Size = new System.Drawing.Size(82, 13);
            this.lblRequiredDate.TabIndex = 0;
            this.lblRequiredDate.Text = "Required Date :";
            // 
            // TLMVEW00032
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 123);
            this.Controls.Add(this.dtpRequiredDate);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.lblRequiredDate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00032";
            this.Text = "IBL Remittance Test Key Listing (By Date)";
            this.Load += new System.EventHandler(this.TLMVEW00032_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private Ace.Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Ace.Windows.CXClient.Controls.CXC0005 dtpRequiredDate;
        private Windows.CXClient.Controls.CXC0003 lblRequiredDate;
	}
}