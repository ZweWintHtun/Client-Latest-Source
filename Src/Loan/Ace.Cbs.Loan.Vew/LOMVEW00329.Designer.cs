namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00329
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.LOMDTO00311BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvPLVrOstdListing = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00311BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // LOMDTO00311BindingSource
            // 
            this.LOMDTO00311BindingSource.DataSource = typeof(Ace.Cbs.Loan.Dmd.LOMDTO00311);
            // 
            // rpvPLVrOstdListing
            // 
            this.rpvPLVrOstdListing.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DSLOMRDLC00054";
            reportDataSource2.Value = this.LOMDTO00311BindingSource;
            this.rpvPLVrOstdListing.LocalReport.DataSources.Add(reportDataSource2);
            this.rpvPLVrOstdListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00054.rdlc";
            this.rpvPLVrOstdListing.Location = new System.Drawing.Point(0, 0);
            this.rpvPLVrOstdListing.Name = "rpvPLVrOstdListing";
            this.rpvPLVrOstdListing.Size = new System.Drawing.Size(605, 450);
            this.rpvPLVrOstdListing.TabIndex = 6;
            // 
            // LOMVEW00329
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 450);
            this.Controls.Add(this.rpvPLVrOstdListing);
            this.Name = "LOMVEW00329";
            this.Text = "";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LOMVEW00329_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00311BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvPLVrOstdListing;
        private System.Windows.Forms.BindingSource LOMDTO00311BindingSource;
    }
}