namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00105
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00105));
            this.MNMDTO00039BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvFixedDepositCertificatePrinting = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00039BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MNMDTO00039BindingSource
            // 
            this.MNMDTO00039BindingSource.DataSource = typeof(Ace.Cbs.Mnm.Dmd.MNMDTO00039);
            // 
            // rpvFixedDepositCertificatePrinting
            // 
            this.rpvFixedDepositCertificatePrinting.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "CertificateDataSet";
            reportDataSource1.Value = this.MNMDTO00039BindingSource;
            this.rpvFixedDepositCertificatePrinting.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvFixedDepositCertificatePrinting.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00025.rdlc";
            this.rpvFixedDepositCertificatePrinting.Location = new System.Drawing.Point(0, 0);
            this.rpvFixedDepositCertificatePrinting.Name = "rpvFixedDepositCertificatePrinting";
            this.rpvFixedDepositCertificatePrinting.ShowPrintButton = false;
            this.rpvFixedDepositCertificatePrinting.Size = new System.Drawing.Size(662, 476);
            this.rpvFixedDepositCertificatePrinting.TabIndex = 0;
            // 
            // MNMVEW00105
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(662, 476);
            this.Controls.Add(this.rpvFixedDepositCertificatePrinting);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00105";
            this.Text = "Fixed Deposit Receipt ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MNMVEW00105_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00039BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvFixedDepositCertificatePrinting;
        private System.Windows.Forms.BindingSource MNMDTO00039BindingSource;
    }
}