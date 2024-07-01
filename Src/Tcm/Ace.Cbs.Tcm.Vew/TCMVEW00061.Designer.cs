namespace Ace.Cbs.Tcm.Vew
{
	partial class TCMVEW00061
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00061));
            this.TLMDTO00001BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvPOPrinting = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00001BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TLMDTO00001BindingSource
            // 
            this.TLMDTO00001BindingSource.DataSource = typeof(Ace.Cbs.Tel.Dmd.TLMDTO00001);
            // 
            // rpvPOPrinting
            // 
            this.rpvPOPrinting.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "POPrintingDataSet";
            reportDataSource1.Value = this.TLMDTO00001BindingSource;
            this.rpvPOPrinting.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvPOPrinting.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tcm.Vew.RDLC.TCMRDLC00016.rdlc";
            this.rpvPOPrinting.Location = new System.Drawing.Point(0, 0);
            this.rpvPOPrinting.Name = "rpvPOPrinting";
            this.rpvPOPrinting.Size = new System.Drawing.Size(770, 459);
            this.rpvPOPrinting.TabIndex = 0;
            // 
            // TCMVEW00061
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 459);
            this.Controls.Add(this.rpvPOPrinting);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TCMVEW00061";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TCMVEW00061_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00001BindingSource)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvPOPrinting;
        private System.Windows.Forms.BindingSource TLMDTO00001BindingSource;





    }
}