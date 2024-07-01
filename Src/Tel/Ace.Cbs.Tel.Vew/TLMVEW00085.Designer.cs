namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00085
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
            this.rpvLoanDepositPrint = new Microsoft.Reporting.WinForms.ReportViewer();
            this.TLMDTO00038BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00038BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rpvLoanDepositPrint
            // 
            this.rpvLoanDepositPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSTLMRDLC00036";
            reportDataSource1.Value = this.TLMDTO00038BindingSource;
            this.rpvLoanDepositPrint.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvLoanDepositPrint.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tel.Vew.RDLC.TLMRDLC00036.rdlc";
            this.rpvLoanDepositPrint.Location = new System.Drawing.Point(0, 0);
            this.rpvLoanDepositPrint.Name = "rpvLoanDepositPrint";
            this.rpvLoanDepositPrint.Size = new System.Drawing.Size(595, 436);
            this.rpvLoanDepositPrint.TabIndex = 12;
            // 
            // TLMDTO00038BindingSource
            // 
            this.TLMDTO00038BindingSource.DataSource = typeof(Ace.Cbs.Tel.Dmd.TLMDTO00038);
            // 
            // TLMVEW00085
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 436);
            this.Controls.Add(this.rpvLoanDepositPrint);
            this.Name = "TLMVEW00085";
            this.Text = "Loan Deposit Voucher Printing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TLMVEW00085_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00038BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvLoanDepositPrint;
        private System.Windows.Forms.BindingSource TLMDTO00038BindingSource;
    }
}