namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00050
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00050));
            this.LOMDTO00035BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvLDPListing = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00035BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rpvLDPListing
            // 
            this.rpvLDPListing.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSLOMRDLC00006";
            reportDataSource1.Value = this.LOMDTO00035BindingSource;
            this.rpvLDPListing.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvLDPListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00006.rdlc";
            this.rpvLDPListing.Location = new System.Drawing.Point(0, 0);
            this.rpvLDPListing.Name = "rpvLDPListing";
            this.rpvLDPListing.Size = new System.Drawing.Size(625, 470);
            this.rpvLDPListing.TabIndex = 0;
            // 
            // LOMVEW00050
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 470);
            this.Controls.Add(this.rpvLDPListing);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00050";
            this.Text = "Loans Daily Position Listing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LOMVEW00050_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00035BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvLDPListing;
        private System.Windows.Forms.BindingSource LOMDTO00035BindingSource;
    }
}