namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00324
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00324));
            this.LOMDTO00316BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvPLRepaymentListing = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00316BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // LOMDTO00316BindingSource
            // 
            this.LOMDTO00316BindingSource.DataSource = typeof(Ace.Cbs.Loan.Dmd.LOMDTO00316);
            // 
            // rpvPLRepaymentListing
            // 
            this.rpvPLRepaymentListing.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSLOMRDLC00045";
            reportDataSource1.Value = this.LOMDTO00316BindingSource;
            this.rpvPLRepaymentListing.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvPLRepaymentListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00045.rdlc";
            this.rpvPLRepaymentListing.Location = new System.Drawing.Point(0, 0);
            this.rpvPLRepaymentListing.Name = "rpvPLRepaymentListing";
            this.rpvPLRepaymentListing.Size = new System.Drawing.Size(605, 450);
            this.rpvPLRepaymentListing.TabIndex = 5;
            // 
            // LOMVEW00324
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 450);
            this.Controls.Add(this.rpvPLRepaymentListing);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00324";
            this.Text = "";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LOMVEW00324_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00316BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvPLRepaymentListing;
        private System.Windows.Forms.BindingSource LOMDTO00316BindingSource;
    }
}