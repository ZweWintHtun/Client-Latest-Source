namespace Ace.Cbs.Tel.Vew
{
	partial class TLMVEW00069
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00069));
            this.rpvRemittanceReconsileReport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvRemittanceReconsileReport
            // 
            this.rpvRemittanceReconsileReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvRemittanceReconsileReport.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tel.Vew.RDLC.TLMRDLC00027.rdlc";
            this.rpvRemittanceReconsileReport.Location = new System.Drawing.Point(0, 0);
            this.rpvRemittanceReconsileReport.Name = "rpvRemittanceReconsileReport";
            this.rpvRemittanceReconsileReport.Size = new System.Drawing.Size(972, 462);
            this.rpvRemittanceReconsileReport.TabIndex = 0;
            this.rpvRemittanceReconsileReport.Load += new System.EventHandler(this.rvIBLReconsileReport_Load);
            // 
            // TLMVEW00069
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 462);
            this.Controls.Add(this.rpvRemittanceReconsileReport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00069";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IBL Reconcile Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

		}

		#endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvRemittanceReconsileReport;
	}
}