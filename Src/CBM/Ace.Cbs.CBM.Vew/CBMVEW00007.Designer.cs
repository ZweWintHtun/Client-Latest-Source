namespace Ace.Cbs.CBM.Vew
{
    partial class CBMVEW00007
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CBMVEW00007));
            this.PFMDTO00042BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rptCashFlow = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rptLiquidityRatio = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PFMDTO00042BindingSource
            // 
            this.PFMDTO00042BindingSource.DataMember = "PFMDTO00042";
            // 
            // rptCashFlow
            // 
            this.rptCashFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptCashFlow.Location = new System.Drawing.Point(0, 0);
            this.rptCashFlow.Name = "rptCashFlow";
            this.rptCashFlow.Size = new System.Drawing.Size(701, 413);
            this.rptCashFlow.TabIndex = 0;
            // 
            // rptLiquidityRatio
            // 
            this.rptLiquidityRatio.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "CashFlowDS";
            reportDataSource1.Value = this.PFMDTO00042BindingSource;
            this.rptLiquidityRatio.LocalReport.DataSources.Add(reportDataSource1);
            this.rptLiquidityRatio.LocalReport.ReportEmbeddedResource = "Ace.Cbs.CBM.Vew.RDLC.CBMRDLC00007.rdlc";
            this.rptLiquidityRatio.Location = new System.Drawing.Point(0, 0);
            this.rptLiquidityRatio.Name = "rptLiquidityRatio";
            this.rptLiquidityRatio.Size = new System.Drawing.Size(610, 271);
            this.rptLiquidityRatio.TabIndex = 0;
            // 
            // CBMVEW00007
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(610, 271);
            this.Controls.Add(this.rptLiquidityRatio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CBMVEW00007";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CBMVEW00002_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptCashFlow;
        private Microsoft.Reporting.WinForms.ReportViewer rptLiquidityRatio;
        private System.Windows.Forms.BindingSource PFMDTO00042BindingSource;
    }
}