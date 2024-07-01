namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00315
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00315));
            this.LOMDTO00314BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvExpiredLandLeaseListing = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00314BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // LOMDTO00314BindingSource
            // 
            this.LOMDTO00314BindingSource.DataSource = typeof(Ace.Cbs.Loan.Dmd.LOMDTO00314);
            // 
            // rpvExpiredLandLeaseListing
            // 
            this.rpvExpiredLandLeaseListing.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSLOMRDLC00030";
            reportDataSource1.Value = this.LOMDTO00314BindingSource;
            this.rpvExpiredLandLeaseListing.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvExpiredLandLeaseListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00030.rdlc";
            this.rpvExpiredLandLeaseListing.Location = new System.Drawing.Point(0, 0);
            this.rpvExpiredLandLeaseListing.Name = "rpvExpiredLandLeaseListing";
            this.rpvExpiredLandLeaseListing.Size = new System.Drawing.Size(615, 460);
            this.rpvExpiredLandLeaseListing.TabIndex = 2;
            // 
            // LOMVEW00315
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 460);
            this.Controls.Add(this.rpvExpiredLandLeaseListing);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00315";
            this.Text = "Business Loans Lands Leasing And Expire Listing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LOMVEW00315_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00314BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvExpiredLandLeaseListing;
        private System.Windows.Forms.BindingSource LOMDTO00314BindingSource;
    }
}