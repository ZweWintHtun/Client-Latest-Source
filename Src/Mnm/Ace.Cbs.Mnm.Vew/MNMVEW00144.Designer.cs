namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00144
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00144));
            this.PFMDTO00042BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvAutoLinkDebitListing = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rpvAutoLinkDebitListing
            // 
            this.rpvAutoLinkDebitListing.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "AutoLinkDebitCreditListingDataSet";
            reportDataSource1.Value = this.PFMDTO00042BindingSource;
            this.rpvAutoLinkDebitListing.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvAutoLinkDebitListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00083.rdlc";
            this.rpvAutoLinkDebitListing.Location = new System.Drawing.Point(0, 0);
            this.rpvAutoLinkDebitListing.Name = "rpvAutoLinkDebitListing";
            this.rpvAutoLinkDebitListing.Size = new System.Drawing.Size(496, 322);
            this.rpvAutoLinkDebitListing.TabIndex = 0;
            // 
            // MNMVEW00144
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 322);
            this.Controls.Add(this.rpvAutoLinkDebitListing);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00144";
            this.Text = "Auto Link Debit Listing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MNMVEW00144_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvAutoLinkDebitListing;
        private System.Windows.Forms.BindingSource PFMDTO00042BindingSource;
    }
}