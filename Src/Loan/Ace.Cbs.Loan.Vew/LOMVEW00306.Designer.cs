namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00306
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00306));
            this.LOMDTO00305BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvFLOSTReportBYWD = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00305BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rpvFLOSTReportBYWD
            // 
            this.rpvFLOSTReportBYWD.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSLOMRDLC00023";
            reportDataSource1.Value = this.LOMDTO00305BindingSource;
            this.rpvFLOSTReportBYWD.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvFLOSTReportBYWD.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00023.rdlc";
            this.rpvFLOSTReportBYWD.Location = new System.Drawing.Point(0, 0);
            this.rpvFLOSTReportBYWD.Name = "rpvFLOSTReportBYWD";
            this.rpvFLOSTReportBYWD.Size = new System.Drawing.Size(615, 460);
            this.rpvFLOSTReportBYWD.TabIndex = 0;
            // 
            // LOMVEW00306
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 460);
            this.Controls.Add(this.rpvFLOSTReportBYWD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00306";
            this.Text = "Seasonal Loan Individual Outstanding Reports By Withdraw Date";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LOMVEW00306_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00305BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvFLOSTReportBYWD;
        private System.Windows.Forms.BindingSource LOMDTO00305BindingSource;

    }
}