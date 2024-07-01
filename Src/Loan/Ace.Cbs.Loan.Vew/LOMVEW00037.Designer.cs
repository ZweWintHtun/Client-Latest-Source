namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00037
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00037));
            this.LOMDTO00035BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvODListing = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00035BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // LOMDTO00035BindingSource
            // 
            this.LOMDTO00035BindingSource.DataSource = typeof(Ace.Cbs.Loan.Dmd.LOMDTO00035);
            // 
            // rpvODListing
            // 
            this.rpvODListing.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSLOMRDLC00003";
            reportDataSource1.Value = this.LOMDTO00035BindingSource;
            this.rpvODListing.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvODListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00003.rdlc";
            this.rpvODListing.Location = new System.Drawing.Point(0, 0);
            this.rpvODListing.Name = "rpvODListing";
            this.rpvODListing.Size = new System.Drawing.Size(625, 470);
            this.rpvODListing.TabIndex = 1;
            // 
            // LOMVEW00037
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 470);
            this.Controls.Add(this.rpvODListing);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00037";
            this.Text = "";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LOMVEW00037_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00035BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvODListing;
        private System.Windows.Forms.BindingSource LOMDTO00035BindingSource;
    }
}