namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00119
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00119));
            this.MNMDTO00039BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvCustIDListing = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00039BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MNMDTO00039BindingSource
            // 
            this.MNMDTO00039BindingSource.DataSource = typeof(Ace.Cbs.Mnm.Dmd.MNMDTO00039);
            // 
            // rpvCustIDListing
            // 
            this.rpvCustIDListing.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "MNMDS00039";
            reportDataSource1.Value = this.MNMDTO00039BindingSource;
            this.rpvCustIDListing.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvCustIDListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00039.rdlc";
            this.rpvCustIDListing.Location = new System.Drawing.Point(0, 0);
            this.rpvCustIDListing.Name = "rpvCustIDListing";
            this.rpvCustIDListing.Size = new System.Drawing.Size(635, 480);
            this.rpvCustIDListing.TabIndex = 0;
            // 
            // MNMVEW00119
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 480);
            this.Controls.Add(this.rpvCustIDListing);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00119";
            this.Text = "MNMVEW00119";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MNMVEW00119_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00039BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvCustIDListing;
        private System.Windows.Forms.BindingSource MNMDTO00039BindingSource;
    }
}