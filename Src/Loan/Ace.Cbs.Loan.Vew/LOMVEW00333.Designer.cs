namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00333
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
            this.LOMDTO00311BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvPLLFOstdListing = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00311BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rpvPLLFOstdListing
            // 
            this.rpvPLLFOstdListing.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSLOMRDLC00057";
            reportDataSource1.Value = this.LOMDTO00311BindingSource;
            this.rpvPLLFOstdListing.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvPLLFOstdListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00057.rdlc";
            this.rpvPLLFOstdListing.Location = new System.Drawing.Point(0, 0);
            this.rpvPLLFOstdListing.Name = "rpvPLLFOstdListing";
            this.rpvPLLFOstdListing.Size = new System.Drawing.Size(605, 450);
            this.rpvPLLFOstdListing.TabIndex = 8;
            // 
            // LOMVEW00333
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 450);
            this.Controls.Add(this.rpvPLLFOstdListing);
            this.Name = "LOMVEW00333";
            this.Text = "";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LOMVEW00333_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00311BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvPLLFOstdListing;
        private System.Windows.Forms.BindingSource LOMDTO00311BindingSource;
    }
}