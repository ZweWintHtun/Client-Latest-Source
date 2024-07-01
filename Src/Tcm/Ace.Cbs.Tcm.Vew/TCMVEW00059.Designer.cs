namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00059
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00059));
            this.PFMDTO00011BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PFMDTO00042BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvChequeListReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00011BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PFMDTO00011BindingSource
            // 
            this.PFMDTO00011BindingSource.DataSource = typeof(Ace.Cbs.Pfm.Dmd.PFMDTO00011);
            // 
            // PFMDTO00042BindingSource
            // 
            this.PFMDTO00042BindingSource.DataSource = typeof(Ace.Cbs.Pfm.Dmd.PFMDTO00042);
            // 
            // rpvChequeListReportViewer
            // 
            this.rpvChequeListReportViewer.BackColor = System.Drawing.SystemColors.Window;
            this.rpvChequeListReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rpvChequeListReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvChequeListReportViewer.DocumentMapWidth = 10;
            reportDataSource1.Name = "ChequeListDataSets";
            reportDataSource1.Value = this.PFMDTO00011BindingSource;
            this.rpvChequeListReportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvChequeListReportViewer.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tcm.Vew.RDLC.TCMRDLC00014.rdlc";
            this.rpvChequeListReportViewer.Location = new System.Drawing.Point(0, 0);
            this.rpvChequeListReportViewer.Margin = new System.Windows.Forms.Padding(0);
            this.rpvChequeListReportViewer.Name = "rpvChequeListReportViewer";
            this.rpvChequeListReportViewer.Size = new System.Drawing.Size(873, 443);
            this.rpvChequeListReportViewer.TabIndex = 0;
            // 
            // TCMVEW00059
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 443);
            this.Controls.Add(this.rpvChequeListReportViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TCMVEW00059";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TCMVEW00059";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TCMVEW00059_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00011BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvChequeListReportViewer;
        private System.Windows.Forms.BindingSource PFMDTO00011BindingSource;
        private System.Windows.Forms.BindingSource PFMDTO00042BindingSource;
    }
}