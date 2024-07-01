namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00068
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00068));
            this.PFMDTO00042BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvWithdrawByAccountNo = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PFMDTO00042BindingSource
            // 
            this.PFMDTO00042BindingSource.DataSource = typeof(Ace.Cbs.Pfm.Dmd.PFMDTO00042);
            // 
            // rpvWithdrawByAccountNo
            // 
            this.rpvWithdrawByAccountNo.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "WithdrawalListingByAccountNoDataSet";
            reportDataSource1.Value = this.PFMDTO00042BindingSource;
            this.rpvWithdrawByAccountNo.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvWithdrawByAccountNo.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tel.Vew.RDLC.TLMRDLC00026.rdlc";
            this.rpvWithdrawByAccountNo.Location = new System.Drawing.Point(0, 0);
            this.rpvWithdrawByAccountNo.Name = "rpvWithdrawByAccountNo";
            this.rpvWithdrawByAccountNo.Size = new System.Drawing.Size(710, 504);
            this.rpvWithdrawByAccountNo.TabIndex = 0;
            // 
            // TLMVEW00068
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 504);
            this.Controls.Add(this.rpvWithdrawByAccountNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00068";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TLMVEW00068_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvWithdrawByAccountNo;
        private System.Windows.Forms.BindingSource PFMDTO00042BindingSource;
    }
}