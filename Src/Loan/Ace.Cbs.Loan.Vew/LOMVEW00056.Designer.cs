namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00056
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00056));
            this.LOMDTO00054BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvODInterestListing = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00054BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // LOMDTO00054BindingSource
            // 
            this.LOMDTO00054BindingSource.DataSource = typeof(Ace.Cbs.Loan.Dmd.LOMDTO00054);
            // 
            // rpvODInterestListing
            // 
            reportDataSource1.Name = "DSLOMRDLC00009";
            reportDataSource1.Value = this.LOMDTO00054BindingSource;
            this.rpvODInterestListing.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvODInterestListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00009.rdlc";
            this.rpvODInterestListing.Location = new System.Drawing.Point(0, 0);
            this.rpvODInterestListing.Name = "rpvODInterestListing";
            this.rpvODInterestListing.Size = new System.Drawing.Size(618, 463);
            this.rpvODInterestListing.TabIndex = 0;
            // 
            // LOMVEW00056
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 460);
            this.Controls.Add(this.rpvODInterestListing);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00056";
            this.Text = "LOMVEW00056";
            this.Load += new System.EventHandler(this.LOMVEW00056_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00054BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvODInterestListing;
        private System.Windows.Forms.BindingSource LOMDTO00054BindingSource;
    }
}