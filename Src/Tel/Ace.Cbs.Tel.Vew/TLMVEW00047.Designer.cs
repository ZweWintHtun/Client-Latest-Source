namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00047
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00047));
            this.TLMDTO00004BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvOnlineTransaction = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00004BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TLMDTO00004BindingSource
            // 
            this.TLMDTO00004BindingSource.DataSource = typeof(Ace.Cbs.Tel.Dmd.TLMDTO00004);
            // 
            // rpvOnlineTransaction
            // 
            this.rpvOnlineTransaction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvOnlineTransaction.Font = new System.Drawing.Font("Zawgyi-One", 8F);
            reportDataSource1.Name = "IBLHomeIncomeReportDataSet";
            reportDataSource1.Value = this.TLMDTO00004BindingSource;
            this.rpvOnlineTransaction.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvOnlineTransaction.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tel.Vew.RDLC.TLMRDLC00005.rdlc";
            this.rpvOnlineTransaction.Location = new System.Drawing.Point(0, 0);
            this.rpvOnlineTransaction.Name = "rpvOnlineTransaction";
            this.rpvOnlineTransaction.Size = new System.Drawing.Size(985, 451);
            this.rpvOnlineTransaction.TabIndex = 1;
            // 
            // TLMVEW00047
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 451);
            this.Controls.Add(this.rpvOnlineTransaction);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00047";
            this.Text = "Online Transaction Listing Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TLMVEW00047_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00004BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvOnlineTransaction;
        private System.Windows.Forms.BindingSource TLMDTO00004BindingSource;
    }
}