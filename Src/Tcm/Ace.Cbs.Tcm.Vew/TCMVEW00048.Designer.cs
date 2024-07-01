namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00048
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00048));
            this.PFMDTO00042BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rvpClearingScheduleReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PFMDTO00042BindingSource
            // 
            this.PFMDTO00042BindingSource.DataSource = typeof(Ace.Cbs.Pfm.Dmd.PFMDTO00042);
            // 
            // rvpClearingScheduleReportViewer
            // 
            this.rvpClearingScheduleReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "ClearingScheduleDataSet";
            reportDataSource1.Value = this.PFMDTO00042BindingSource;
            this.rvpClearingScheduleReportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.rvpClearingScheduleReportViewer.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tcm.Vew.RDLC.TCMRDLC00003.rdlc";
            this.rvpClearingScheduleReportViewer.Location = new System.Drawing.Point(0, 0);
            this.rvpClearingScheduleReportViewer.Name = "rvpClearingScheduleReportViewer";
            this.rvpClearingScheduleReportViewer.Size = new System.Drawing.Size(754, 444);
            this.rvpClearingScheduleReportViewer.TabIndex = 0;
            // 
            // TCMVEW00048
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 444);
            this.Controls.Add(this.rvpClearingScheduleReportViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TCMVEW00048";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Daily Closing Clearing Schedule Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TCMScheduleReport_FormClosed);
            this.Load += new System.EventHandler(this.TCMScheduleReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvpClearingScheduleReportViewer;
        private System.Windows.Forms.BindingSource PFMDTO00042BindingSource;
    }
}