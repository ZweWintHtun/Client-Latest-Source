namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00084
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.rpvTransferVoucherPrint = new Microsoft.Reporting.WinForms.ReportViewer();
            this.TLMDTO00038BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00038BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rpvTransferVoucherPrint
            // 
            this.rpvTransferVoucherPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSTLMDTO00038DR";
            reportDataSource1.Value = this.TLMDTO00038BindingSource;
            reportDataSource2.Name = "DSTLMDTO00038CR";
            reportDataSource2.Value = this.TLMDTO00038BindingSource;
            this.rpvTransferVoucherPrint.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvTransferVoucherPrint.LocalReport.DataSources.Add(reportDataSource2);
            this.rpvTransferVoucherPrint.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tel.Vew.RDLC.TLMRDLC00035.rdlc";
            this.rpvTransferVoucherPrint.Location = new System.Drawing.Point(0, 0);
            this.rpvTransferVoucherPrint.Name = "rpvTransferVoucherPrint";
            this.rpvTransferVoucherPrint.Size = new System.Drawing.Size(595, 436);
            this.rpvTransferVoucherPrint.TabIndex = 11;
            // 
            // TLMDTO00038BindingSource
            // 
            this.TLMDTO00038BindingSource.DataSource = typeof(Ace.Cbs.Tel.Dmd.TLMDTO00038);
            // 
            // TLMVEW00084
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 436);
            this.Controls.Add(this.rpvTransferVoucherPrint);
            this.Name = "TLMVEW00084";
            this.Text = "Transfer Voucher Printing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TLMVEW00084_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00038BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvTransferVoucherPrint;
        private System.Windows.Forms.BindingSource TLMDTO00038BindingSource;
    }
}