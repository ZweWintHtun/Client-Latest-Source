namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00064
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00064));
            this.LOMDTO00013BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvNonPerformanceLoansCase = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00013BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // LOMDTO00013BindingSource
            // 
            this.LOMDTO00013BindingSource.DataSource = typeof(Ace.Cbs.Loan.Dmd.LOMDTO00013);
            // 
            // rpvNonPerformanceLoansCase
            // 
            this.rpvNonPerformanceLoansCase.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSLOMRDLC00013";
            reportDataSource1.Value = this.LOMDTO00013BindingSource;
            this.rpvNonPerformanceLoansCase.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvNonPerformanceLoansCase.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00013.rdlc";
            this.rpvNonPerformanceLoansCase.Location = new System.Drawing.Point(0, 0);
            this.rpvNonPerformanceLoansCase.Name = "rpvNonPerformanceLoansCase";
            this.rpvNonPerformanceLoansCase.Size = new System.Drawing.Size(625, 470);
            this.rpvNonPerformanceLoansCase.TabIndex = 0;
            // 
            // LOMVEW00064
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 470);
            this.Controls.Add(this.rpvNonPerformanceLoansCase);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00064";
            this.Text = "LOMVEW00064";
            this.Load += new System.EventHandler(this.LOMVEW00064_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00013BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvNonPerformanceLoansCase;
        private System.Windows.Forms.BindingSource LOMDTO00013BindingSource;
    }
}