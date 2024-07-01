namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00103
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00103));
            this.LOMDTO00102BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvLSLoanListing = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00102BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rpvLSLoanListing
            // 
            reportDataSource1.Name = "DSLOMRDLC00019";
            reportDataSource1.Value = this.LOMDTO00102BindingSource;
            this.rpvLSLoanListing.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvLSLoanListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00019.rdlc";
            this.rpvLSLoanListing.Location = new System.Drawing.Point(1, 2);
            this.rpvLSLoanListing.Name = "rpvLSLoanListing";
            this.rpvLSLoanListing.Size = new System.Drawing.Size(768, 511);
            this.rpvLSLoanListing.TabIndex = 0;
            // 
            // LOMVEW00103
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 525);
            this.Controls.Add(this.rpvLSLoanListing);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00103";
            this.Text = "LOMVEW00103";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LOMVEW00103_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00102BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvLSLoanListing;
        private System.Windows.Forms.BindingSource LOMDTO00102BindingSource;
    }
}