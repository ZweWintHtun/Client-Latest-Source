namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00043
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00043));
            this.TLMDTO00045BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DenoOutstandingDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvDenoOutstandingReport = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00045BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DenoOutstandingDTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TLMDTO00045BindingSource
            // 
            this.TLMDTO00045BindingSource.DataMember = "TLMDTO00045";
            // 
            // DenoOutstandingDTOBindingSource
            // 
            this.DenoOutstandingDTOBindingSource.DataMember = "DenoOutstandingDTO";
            // 
            // rpvDenoOutstandingReport
            // 
            this.rpvDenoOutstandingReport.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DenoOutstandingReportDataSet";
            reportDataSource1.Value = this.TLMDTO00045BindingSource;
            this.rpvDenoOutstandingReport.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvDenoOutstandingReport.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tel.Vew.RDLC.TLMRDLC00001.rdlc";
            this.rpvDenoOutstandingReport.Location = new System.Drawing.Point(0, 0);
            this.rpvDenoOutstandingReport.Name = "rpvDenoOutstandingReport";
            this.rpvDenoOutstandingReport.Size = new System.Drawing.Size(1016, 483);
            this.rpvDenoOutstandingReport.TabIndex = 1;
            // 
            // TLMVEW00043
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 483);
            this.Controls.Add(this.rpvDenoOutstandingReport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00043";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TLMVEW00043";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TLMVEW00043_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00045BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DenoOutstandingDTOBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvDenoOutstandingReport;
        private System.Windows.Forms.BindingSource DenoOutstandingDTOBindingSource;
        private System.Windows.Forms.BindingSource TLMDTO00045BindingSource;
    }
}