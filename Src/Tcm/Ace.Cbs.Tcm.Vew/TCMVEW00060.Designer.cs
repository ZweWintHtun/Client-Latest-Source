namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00060
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00060));
            this.TCMDTO00027BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvScrollReport = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.TCMDTO00027BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TCMDTO00027BindingSource
            // 
            this.TCMDTO00027BindingSource.DataSource = typeof(Ace.Cbs.Tcm.Dmd.TCMDTO00027);
            // 
            // rpvScrollReport
            // 
            this.rpvScrollReport.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "ClearingScrollDataset";
            reportDataSource1.Value = this.TCMDTO00027BindingSource;
            this.rpvScrollReport.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvScrollReport.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tcm.Vew.RDLC.TCMRDLC00015.rdlc";
            this.rpvScrollReport.Location = new System.Drawing.Point(0, 0);
            this.rpvScrollReport.Name = "rpvScrollReport";
            this.rpvScrollReport.Size = new System.Drawing.Size(672, 375);
            this.rpvScrollReport.TabIndex = 0;
            // 
            // TCMVEW00060
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 375);
            this.Controls.Add(this.rpvScrollReport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TCMVEW00060";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Daily Closing Clearing Scroll Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TCMScrollReport_FormClosed);
            this.Load += new System.EventHandler(this.TCMScrollReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TCMDTO00027BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvScrollReport;
        private System.Windows.Forms.BindingSource TCMDTO00027BindingSource;
    }
}