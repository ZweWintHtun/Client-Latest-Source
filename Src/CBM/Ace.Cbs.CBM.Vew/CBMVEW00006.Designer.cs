namespace Ace.Cbs.CBM.Vew
{
    partial class CBMVEW00006
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CBMVEW00006));
            this.PFMDTO00042BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rptCashFlow = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rptDailyImprovement = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PFMDTO00042BindingSource
            // 
            this.PFMDTO00042BindingSource.DataSource = typeof(Ace.Cbs.Pfm.Dmd.PFMDTO00042);
            // 
            // rptCashFlow
            // 
            this.rptCashFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptCashFlow.Location = new System.Drawing.Point(0, 0);
            this.rptCashFlow.Name = "rptCashFlow";
            this.rptCashFlow.Size = new System.Drawing.Size(701, 413);
            this.rptCashFlow.TabIndex = 0;
            // 
            // rptDailyImprovement
            // 
            this.rptDailyImprovement.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DailyImprovementDS";
            reportDataSource1.Value = this.PFMDTO00042BindingSource;
            this.rptDailyImprovement.LocalReport.DataSources.Add(reportDataSource1);
            this.rptDailyImprovement.LocalReport.ReportEmbeddedResource = "Ace.Cbs.CBM.Vew.RDLC.CBMRDLC00006.rdlc";
            this.rptDailyImprovement.Location = new System.Drawing.Point(0, 0);
            this.rptDailyImprovement.Name = "rptDailyImprovement";
            this.rptDailyImprovement.Size = new System.Drawing.Size(610, 271);
            this.rptDailyImprovement.TabIndex = 0;
            // 
            // CBMVEW00006
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(610, 271);
            this.Controls.Add(this.rptDailyImprovement);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CBMVEW00006";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CBMVEW00004_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptCashFlow;
        private Microsoft.Reporting.WinForms.ReportViewer rptDailyImprovement;
        private System.Windows.Forms.BindingSource PFMDTO00042BindingSource;
    }
}