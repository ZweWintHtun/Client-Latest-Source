namespace Ace.Cbs.CBM.Vew
{
    partial class CBMVEW00005
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CBMVEW00005));
            this.PFMDTO00042BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rptCashFlow = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rptFinancialStatement = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PFMDTO00042BindingSource
            // 
            this.PFMDTO00042BindingSource.DataSource = typeof(Ace.Cbs.Pfm.Dmd.PFMDTO00042);
            // 
            // rptCashFlow
            // 
            this.rptCashFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptCashFlow.Location = new System.Drawing.Point(0, 0);
            this.rptCashFlow.Name = "rptCashFlow";
            this.rptCashFlow.Size = new System.Drawing.Size(701, 413);
            this.rptCashFlow.TabIndex = 0;
            // 
            // rptFinancialStatement
            // 
            this.rptFinancialStatement.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "FinancialDS";
            reportDataSource1.Value = this.PFMDTO00042BindingSource;
            this.rptFinancialStatement.LocalReport.DataSources.Add(reportDataSource1);
            this.rptFinancialStatement.LocalReport.ReportEmbeddedResource = "Ace.Cbs.CBM.Vew.RDLC.CBMRDLC00005.rdlc";
            this.rptFinancialStatement.Location = new System.Drawing.Point(0, 0);
            this.rptFinancialStatement.Name = "rptFinancialStatement";
            this.rptFinancialStatement.Size = new System.Drawing.Size(610, 271);
            this.rptFinancialStatement.TabIndex = 0;
            // 
            // CBMVEW00005
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(610, 271);
            this.Controls.Add(this.rptFinancialStatement);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CBMVEW00005";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CBMVEW00005_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptCashFlow;
        private Microsoft.Reporting.WinForms.ReportViewer rptFinancialStatement;
        private System.Windows.Forms.BindingSource PFMDTO00042BindingSource;
    }
}