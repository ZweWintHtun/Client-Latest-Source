namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00033
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00033));
            this.LOMDTO00013BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvLegalAccountReport = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00013BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rpvLegalAccountReport
            // 
            this.rpvLegalAccountReport.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "LegalSueCaseByAccountNoDataSet";
            reportDataSource1.Value = this.LOMDTO00013BindingSource;
            this.rpvLegalAccountReport.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvLegalAccountReport.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00001.rdlc";
            this.rpvLegalAccountReport.Location = new System.Drawing.Point(0, 0);
            this.rpvLegalAccountReport.Name = "rpvLegalAccountReport";
            this.rpvLegalAccountReport.Size = new System.Drawing.Size(588, 271);
            this.rpvLegalAccountReport.TabIndex = 0;
            // 
            // LOMVEW00033
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 271);
            this.Controls.Add(this.rpvLegalAccountReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LOMVEW00033";
            this.Text = "Enquiry By Legal Sue Case Account Number";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LOMVEW00033_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00013BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvLegalAccountReport;
        private System.Windows.Forms.BindingSource LOMDTO00013BindingSource;

    }
}