namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00053
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00053));
            this.PFMDTO00020BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvWithdrawalChequeReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00020BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PFMDTO00020BindingSource
            // 
            this.PFMDTO00020BindingSource.DataSource = typeof(Ace.Cbs.Pfm.Dmd.PFMDTO00020);
            // 
            // rpvWithdrawalChequeReportViewer
            // 
            this.rpvWithdrawalChequeReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "WithdrawalChequeDataSets";
            reportDataSource1.Value = this.PFMDTO00020BindingSource;
            this.rpvWithdrawalChequeReportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvWithdrawalChequeReportViewer.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tcm.Vew.RDLC.TCMRDLC00008.rdlc";
            this.rpvWithdrawalChequeReportViewer.Location = new System.Drawing.Point(0, 0);
            this.rpvWithdrawalChequeReportViewer.Name = "rpvWithdrawalChequeReportViewer";
            this.rpvWithdrawalChequeReportViewer.Size = new System.Drawing.Size(725, 390);
            this.rpvWithdrawalChequeReportViewer.TabIndex = 0;
            // 
            // TCMVEW00053
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 390);
            this.Controls.Add(this.rpvWithdrawalChequeReportViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TCMVEW00053";
            this.Text = "Withdrawal Cheque Listing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TCMVEW00053_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00020BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvWithdrawalChequeReportViewer;
        private System.Windows.Forms.BindingSource PFMDTO00020BindingSource;
    }
}