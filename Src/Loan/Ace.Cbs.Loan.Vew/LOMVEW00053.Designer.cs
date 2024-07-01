namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00053
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00053));
            this.LOMDTO00021BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvLoansInterestListing = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00021BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // LOMDTO00021BindingSource
            // 
            this.LOMDTO00021BindingSource.DataSource = typeof(Ace.Cbs.Loan.Dmd.LOMDTO00021);
            // 
            // rpvLoansInterestListing
            // 
            this.rpvLoansInterestListing.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSLOMRDLC00008";
            reportDataSource1.Value = this.LOMDTO00021BindingSource;
            this.rpvLoansInterestListing.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvLoansInterestListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00008.rdlc";
            this.rpvLoansInterestListing.Location = new System.Drawing.Point(0, 0);
            this.rpvLoansInterestListing.Name = "rpvLoansInterestListing";
            this.rpvLoansInterestListing.Size = new System.Drawing.Size(615, 460);
            this.rpvLoansInterestListing.TabIndex = 0;
            // 
            // LOMVEW00053
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 460);
            this.Controls.Add(this.rpvLoansInterestListing);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00053";
            this.Text = "Loan Interest Listing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LOMVEW00053_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00021BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvLoansInterestListing;
        private System.Windows.Forms.BindingSource LOMDTO00021BindingSource;
    }
}