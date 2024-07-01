namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00070
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00070));
            this.TLMDTO00004BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvTransactionReconsileReport = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00004BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TLMDTO00004BindingSource
            // 
            this.TLMDTO00004BindingSource.DataSource = typeof(Ace.Cbs.Tel.Dmd.TLMDTO00004);
            // 
            // rpvTransactionReconsileReport
            // 
            this.rpvTransactionReconsileReport.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "IBLTLFReconsileDataSet";
            reportDataSource1.Value = this.TLMDTO00004BindingSource;
            this.rpvTransactionReconsileReport.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvTransactionReconsileReport.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tel.Vew.RDLC.TLMRDLC00028.rdlc";
            this.rpvTransactionReconsileReport.Location = new System.Drawing.Point(0, 0);
            this.rpvTransactionReconsileReport.Name = "rpvTransactionReconsileReport";
            this.rpvTransactionReconsileReport.Size = new System.Drawing.Size(970, 658);
            this.rpvTransactionReconsileReport.TabIndex = 0;
            // 
            // TLMVEW00070
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 658);
            this.Controls.Add(this.rpvTransactionReconsileReport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00070";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remittance Reconcile Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TLMVEW00070_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00004BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvTransactionReconsileReport;
        private System.Windows.Forms.BindingSource TLMDTO00004BindingSource;

    }
}