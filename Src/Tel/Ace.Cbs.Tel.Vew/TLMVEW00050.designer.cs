namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00050
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00050));
            this.TLMDTO00037BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvIBLRemittanceTestKeyListing = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00037BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TLMDTO00037BindingSource
            // 
            this.TLMDTO00037BindingSource.DataSource = typeof(Ace.Cbs.Tel.Dmd.TLMDTO00037);
            // 
            // rpvIBLRemittanceTestKeyListing
            // 
            this.rpvIBLRemittanceTestKeyListing.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "IBLTestKeyListingDataSet";
            reportDataSource1.Value = this.TLMDTO00037BindingSource;
            this.rpvIBLRemittanceTestKeyListing.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvIBLRemittanceTestKeyListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tel.Vew.RDLC.TLMRDLC00008.rdlc";
            this.rpvIBLRemittanceTestKeyListing.Location = new System.Drawing.Point(0, 0);
            this.rpvIBLRemittanceTestKeyListing.Name = "rpvIBLRemittanceTestKeyListing";
            this.rpvIBLRemittanceTestKeyListing.Size = new System.Drawing.Size(626, 487);
            this.rpvIBLRemittanceTestKeyListing.TabIndex = 0;
            // 
            // TLMVEW00050
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 487);
            this.Controls.Add(this.rpvIBLRemittanceTestKeyListing);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00050";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TLMVEW00050_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00037BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvIBLRemittanceTestKeyListing;
        private System.Windows.Forms.BindingSource TLMDTO00037BindingSource;
    }
}