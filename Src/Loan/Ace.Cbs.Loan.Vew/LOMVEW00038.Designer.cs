namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00038
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00038));
            this.LOMVIW00034BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LOMDTO00034BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvLoanRegistrationListing = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.LOMVIW00034BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00034BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // LOMVIW00034BindingSource
            // 
            this.LOMVIW00034BindingSource.DataSource = typeof(Ace.Cbs.Loan.Dmd.LOMVIW00034);
            // 
            // rpvLoanRegistrationListing
            // 
            this.rpvLoanRegistrationListing.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSLoanRegistration";
            reportDataSource1.Value = this.LOMVIW00034BindingSource;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.LOMDTO00034BindingSource;
            this.rpvLoanRegistrationListing.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvLoanRegistrationListing.LocalReport.DataSources.Add(reportDataSource2);
            this.rpvLoanRegistrationListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00002.rdlc";
            this.rpvLoanRegistrationListing.Location = new System.Drawing.Point(0, 0);
            this.rpvLoanRegistrationListing.Name = "rpvLoanRegistrationListing";
            this.rpvLoanRegistrationListing.Size = new System.Drawing.Size(578, 261);
            this.rpvLoanRegistrationListing.TabIndex = 0;
            // 
            // LOMVEW00038
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 261);
            this.Controls.Add(this.rpvLoanRegistrationListing);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LOMVEW00038";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Business Loans Registration Listing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LOMVEW00038_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LOMVIW00034BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00034BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvLoanRegistrationListing;
        private System.Windows.Forms.BindingSource LOMVIW00034BindingSource;
        private System.Windows.Forms.BindingSource LOMDTO00034BindingSource;
    }
}