namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00101
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00101));
            this.LOMDTO00102BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvAGLoanListing = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00102BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rpvAGLoanListing
            // 
            this.rpvAGLoanListing.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSLOMRDLC00018";
            reportDataSource1.Value = this.LOMDTO00102BindingSource;
            this.rpvAGLoanListing.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvAGLoanListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00018.rdlc";
            this.rpvAGLoanListing.Location = new System.Drawing.Point(0, 0);
            this.rpvAGLoanListing.Name = "rpvAGLoanListing";
            this.rpvAGLoanListing.Size = new System.Drawing.Size(784, 563);
            this.rpvAGLoanListing.TabIndex = 0;
            // 
            // LOMVEW00101
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 563);
            this.Controls.Add(this.rpvAGLoanListing);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00101";
            this.Text = "AGRICULTURAL  LOAN Report Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LOMVEW00101_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00102BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvAGLoanListing;
        private System.Windows.Forms.BindingSource LOMDTO00102BindingSource;
    }
}