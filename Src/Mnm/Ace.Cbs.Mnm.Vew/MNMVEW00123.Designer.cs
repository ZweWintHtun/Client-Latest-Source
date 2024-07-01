namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00123
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00123));
            this.PFMDTO00042BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvPOWithdrawalListing = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PFMDTO00042BindingSource
            // 
            this.PFMDTO00042BindingSource.DataSource = typeof(Ace.Cbs.Pfm.Dmd.PFMDTO00042);
            // 
            // rpvPOWithdrawalListing
            // 
            this.rpvPOWithdrawalListing.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "POWithdrawalDataSet";
            reportDataSource1.Value = this.PFMDTO00042BindingSource;
            this.rpvPOWithdrawalListing.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvPOWithdrawalListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00043.rdlc";
            this.rpvPOWithdrawalListing.Location = new System.Drawing.Point(0, 0);
            this.rpvPOWithdrawalListing.Name = "rpvPOWithdrawalListing";
            this.rpvPOWithdrawalListing.Size = new System.Drawing.Size(673, 477);
            this.rpvPOWithdrawalListing.TabIndex = 0;
            // 
            // MNMVEW00123
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 477);
            this.Controls.Add(this.rpvPOWithdrawalListing);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00123";
            this.Text = "Payment Order Withdrawal Listing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MNMVEW00123_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvPOWithdrawalListing;
        private System.Windows.Forms.BindingSource PFMDTO00042BindingSource;
    }
}