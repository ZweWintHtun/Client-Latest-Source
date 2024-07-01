namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00335
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
            this.rpvHPContractPrint = new Microsoft.Reporting.WinForms.ReportViewer();
            this.LOMDTO00334BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00334BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rpvHPContractPrint
            // 
            this.rpvHPContractPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSLOMRDLC00075";
            reportDataSource1.Value = this.LOMDTO00334BindingSource;
            this.rpvHPContractPrint.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvHPContractPrint.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00075.rdlc";
            this.rpvHPContractPrint.Location = new System.Drawing.Point(0, 0);
            this.rpvHPContractPrint.Name = "rpvHPContractPrint";
            this.rpvHPContractPrint.Size = new System.Drawing.Size(605, 446);
            this.rpvHPContractPrint.TabIndex = 4;
            // 
            // LOMDTO00334BindingSource
            // 
            this.LOMDTO00334BindingSource.DataSource = typeof(Ace.Cbs.Loan.Dmd.LOMDTO00334);
            // 
            // LOMVEW00335
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 446);
            this.Controls.Add(this.rpvHPContractPrint);
            this.Name = "LOMVEW00335";
            this.Text = "Hire Purchase Contract Printing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LOMVEW00335_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00334BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvHPContractPrint;
        private System.Windows.Forms.BindingSource LOMDTO00334BindingSource;

    }
}