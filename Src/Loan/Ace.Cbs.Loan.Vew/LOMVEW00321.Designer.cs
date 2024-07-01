namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00321
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00321));
            this.LOMVIW00316BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvPLODACListing = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.LOMVIW00316BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // LOMVIW00316BindingSource
            // 
            this.LOMVIW00316BindingSource.DataSource = typeof(Ace.Cbs.Loan.Dmd.LOMVIW00316);
            // 
            // rpvPLODACListing
            // 
            this.rpvPLODACListing.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSLOMRDLC00036";
            reportDataSource1.Value = this.LOMVIW00316BindingSource;
            this.rpvPLODACListing.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvPLODACListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00036.rdlc";
            this.rpvPLODACListing.Location = new System.Drawing.Point(0, 0);
            this.rpvPLODACListing.Name = "rpvPLODACListing";
            this.rpvPLODACListing.Size = new System.Drawing.Size(605, 450);
            this.rpvPLODACListing.TabIndex = 5;
            // 
            // LOMVEW00321
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 450);
            this.Controls.Add(this.rpvPLODACListing);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00321";
            this.Text = "";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LOMVEW00321_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LOMVIW00316BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvPLODACListing;
        private System.Windows.Forms.BindingSource LOMVIW00316BindingSource;
    }
}