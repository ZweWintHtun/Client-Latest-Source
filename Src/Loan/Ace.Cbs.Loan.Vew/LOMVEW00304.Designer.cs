namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00304
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00304));
            this.LOMVIW00303BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvFLOSTReport = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.LOMVIW00303BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // LOMVIW00303BindingSource
            // 
            this.LOMVIW00303BindingSource.DataSource = typeof(Ace.Cbs.Loan.Dmd.LOMVIW00303);
            // 
            // rpvFLOSTReport
            // 
            this.rpvFLOSTReport.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSLOMRDLC00020";
            reportDataSource1.Value = this.LOMVIW00303BindingSource;
            this.rpvFLOSTReport.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvFLOSTReport.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00020.rdlc";
            this.rpvFLOSTReport.Location = new System.Drawing.Point(0, 0);
            this.rpvFLOSTReport.Name = "rpvFLOSTReport";
            this.rpvFLOSTReport.Size = new System.Drawing.Size(615, 460);
            this.rpvFLOSTReport.TabIndex = 0;
            // 
            // LOMVEW00304
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 460);
            this.Controls.Add(this.rpvFLOSTReport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00304";
            this.Text = "Seasonal Loan Outstanding Register Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LOMVEW00304_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LOMVIW00303BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvFLOSTReport;
        private System.Windows.Forms.BindingSource LOMVIW00303BindingSource;
    }
}