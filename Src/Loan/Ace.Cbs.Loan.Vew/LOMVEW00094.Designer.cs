namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00094
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00094));
            this.LOMDTO00078BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvAgriLoanListing = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00078BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // LOMDTO00078BindingSource
            // 
            this.LOMDTO00078BindingSource.DataSource = typeof(Ace.Cbs.Loan.Dmd.LOMDTO00078);
            // 
            // rpvAgriLoanListing
            // 
            this.rpvAgriLoanListing.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSLOMRDLC00015";
            reportDataSource1.Value = this.LOMDTO00078BindingSource;
            this.rpvAgriLoanListing.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvAgriLoanListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00015.rdlc";
            this.rpvAgriLoanListing.Location = new System.Drawing.Point(0, 0);
            this.rpvAgriLoanListing.Name = "rpvAgriLoanListing";
            this.rpvAgriLoanListing.Size = new System.Drawing.Size(615, 460);
            this.rpvAgriLoanListing.TabIndex = 3;
            // 
            // LOMVEW00094
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 460);
            this.Controls.Add(this.rpvAgriLoanListing);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00094";
            this.Text = "LOMVEW00094";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LOMVEW00094_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00078BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvAgriLoanListing;
        private System.Windows.Forms.BindingSource LOMDTO00078BindingSource;
    }
}