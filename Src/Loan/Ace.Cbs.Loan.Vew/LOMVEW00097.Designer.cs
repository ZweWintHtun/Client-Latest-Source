namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00097
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00097));
            this.LOMDTO00096BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvHPRegListing = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00096BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // LOMDTO00096BindingSource
            // 
            this.LOMDTO00096BindingSource.DataMember = "LOMDTO00096";
            // 
            // rpvHPRegListing
            // 
            this.rpvHPRegListing.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "HPRegListing";
            reportDataSource1.Value = this.LOMDTO00096BindingSource;
            this.rpvHPRegListing.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00016.rdlc";
            this.rpvHPRegListing.Location = new System.Drawing.Point(0, 0);
            this.rpvHPRegListing.Name = "rpvHPRegListing";
            this.rpvHPRegListing.Size = new System.Drawing.Size(802, 502);
            this.rpvHPRegListing.TabIndex = 0;
            // 
            // LOMVEW00097
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 502);
            this.Controls.Add(this.rpvHPRegListing);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00097";
            this.Text = "";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LOMVEW00097_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00096BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvHPRegListing;
        private System.Windows.Forms.BindingSource LOMDTO00096BindingSource;
    }
}