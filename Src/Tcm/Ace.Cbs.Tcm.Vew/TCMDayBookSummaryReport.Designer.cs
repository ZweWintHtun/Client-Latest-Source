namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMDayBookSummaryReport
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
            this.PFMDTO00042BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvDayBookSummaryReport = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PFMDTO00042BindingSource
            // 
            this.PFMDTO00042BindingSource.DataSource = typeof(Ace.Cbs.Pfm.Dmd.PFMDTO00042);
            // 
            // rpvDayBookSummaryReport
            // 
            this.rpvDayBookSummaryReport.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DayBookSummaryDataSet";
            reportDataSource1.Value = this.PFMDTO00042BindingSource;
            this.rpvDayBookSummaryReport.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvDayBookSummaryReport.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tcm.Vew.RDLC.TCMDayBookSummaryReport.rdlc";
            this.rpvDayBookSummaryReport.Location = new System.Drawing.Point(0, 0);
            this.rpvDayBookSummaryReport.Name = "rpvDayBookSummaryReport";
            this.rpvDayBookSummaryReport.Size = new System.Drawing.Size(792, 571);
            this.rpvDayBookSummaryReport.TabIndex = 0;
            // 
            // TCMDayBookSummaryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 571);
            this.Controls.Add(this.rpvDayBookSummaryReport);
            this.Name = "TCMDayBookSummaryReport";
            this.Text = "TCMDayBookSummaryReport";
            this.Load += new System.EventHandler(this.TCMDayBookSummaryReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvDayBookSummaryReport;
        private System.Windows.Forms.BindingSource PFMDTO00042BindingSource;
    }
}