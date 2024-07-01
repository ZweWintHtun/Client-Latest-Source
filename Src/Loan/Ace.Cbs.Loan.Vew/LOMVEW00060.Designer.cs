namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00060
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00060));
            this.LOMDTO00059BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvODLimitChange = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00059BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // LOMDTO00059BindingSource
            // 
            this.LOMDTO00059BindingSource.DataSource = typeof(Ace.Cbs.Loan.Dmd.LOMDTO00059);
            // 
            // rpvODLimitChange
            // 
            this.rpvODLimitChange.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSLOMRDLC00011";
            reportDataSource1.Value = this.LOMDTO00059BindingSource;
            this.rpvODLimitChange.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvODLimitChange.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00011.rdlc";
            this.rpvODLimitChange.Location = new System.Drawing.Point(0, 0);
            this.rpvODLimitChange.Name = "rpvODLimitChange";
            this.rpvODLimitChange.Size = new System.Drawing.Size(625, 470);
            this.rpvODLimitChange.TabIndex = 0;
            // 
            // LOMVEW00060
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 470);
            this.Controls.Add(this.rpvODLimitChange);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00060";
            this.Text = "LOMVEW00060";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LOMVEW00060_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00059BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvODLimitChange;
        private System.Windows.Forms.BindingSource LOMDTO00059BindingSource;
    }
}