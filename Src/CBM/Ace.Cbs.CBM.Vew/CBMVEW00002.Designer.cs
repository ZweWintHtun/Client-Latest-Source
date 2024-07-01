namespace Ace.Cbs.CBM.Vew
{
    partial class CBMVEW00002
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CBMVEW00002));
            this.rptCashFlow = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rptCash_Flow = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rptCashFlow
            // 
            this.rptCashFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptCashFlow.Location = new System.Drawing.Point(0, 0);
            this.rptCashFlow.Name = "rptCashFlow";
            this.rptCashFlow.Size = new System.Drawing.Size(701, 413);
            this.rptCashFlow.TabIndex = 0;
            // 
            // rptCash_Flow
            // 
            this.rptCash_Flow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptCash_Flow.LocalReport.ReportEmbeddedResource = "Ace.Cbs.CBM.Vew.RDLC.CBMRDLC00002.rdlc";
            this.rptCash_Flow.Location = new System.Drawing.Point(0, 0);
            this.rptCash_Flow.Name = "rptCash_Flow";
            this.rptCash_Flow.Size = new System.Drawing.Size(610, 271);
            this.rptCash_Flow.TabIndex = 0;
            // 
            // CBMVEW00002
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(610, 271);
            this.Controls.Add(this.rptCash_Flow);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CBMVEW00002";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CBMVEW00002_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptCashFlow;
        private Microsoft.Reporting.WinForms.ReportViewer rptCash_Flow;
    }
}