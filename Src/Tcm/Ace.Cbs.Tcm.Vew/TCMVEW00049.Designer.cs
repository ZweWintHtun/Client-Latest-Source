namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00049
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00049));
            this.TCMDTO00027BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PFMDTO00042BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvAbstractReport = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.TCMDTO00027BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TCMDTO00027BindingSource
            // 
            this.TCMDTO00027BindingSource.DataSource = typeof(Ace.Cbs.Tcm.Dmd.TCMDTO00027);
            // 
            // PFMDTO00042BindingSource
            // 
            this.PFMDTO00042BindingSource.DataSource = typeof(Ace.Cbs.Pfm.Dmd.PFMDTO00042);
            // 
            // rpvAbstractReport
            // 
            this.rpvAbstractReport.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "ClearingAbstractDataset";
            reportDataSource1.Value = this.TCMDTO00027BindingSource;
            this.rpvAbstractReport.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvAbstractReport.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tcm.Vew.RDLC.TCMRDLC00004.rdlc";
            this.rpvAbstractReport.Location = new System.Drawing.Point(0, 0);
            this.rpvAbstractReport.Name = "rpvAbstractReport";
            this.rpvAbstractReport.Size = new System.Drawing.Size(779, 376);
            this.rpvAbstractReport.TabIndex = 0;
            // 
            // TCMVEW00049
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 376);
            this.Controls.Add(this.rpvAbstractReport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TCMVEW00049";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Daily Closing Clearing Abstract Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TCMAbstractReport_FormClosed);
            this.Load += new System.EventHandler(this.TCMAbstractReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TCMDTO00027BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvAbstractReport;
        private System.Windows.Forms.BindingSource PFMDTO00042BindingSource;
        private System.Windows.Forms.BindingSource TCMDTO00027BindingSource;
    }
}