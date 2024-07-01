namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00046
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00046));
            this.rpvCashDeclerationReportViwer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvCashDeclerationReportViwer
            // 
            this.rpvCashDeclerationReportViwer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvCashDeclerationReportViwer.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tcm.Vew.RDLC.TCMRDLC00001.rdlc";
            this.rpvCashDeclerationReportViwer.Location = new System.Drawing.Point(0, 0);
            this.rpvCashDeclerationReportViwer.Name = "rpvCashDeclerationReportViwer";
            this.rpvCashDeclerationReportViwer.Size = new System.Drawing.Size(649, 430);
            this.rpvCashDeclerationReportViwer.TabIndex = 0;
            // 
            // TCMVEW00046
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 430);
            this.Controls.Add(this.rpvCashDeclerationReportViwer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TCMVEW00046";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TCMCashDeclarationReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TCMCashDeclerationReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvCashDeclerationReportViwer;
    }
}