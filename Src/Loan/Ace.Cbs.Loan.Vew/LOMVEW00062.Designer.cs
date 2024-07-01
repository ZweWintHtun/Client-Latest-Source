namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00062
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00062));
            this.LOMDTO00059BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvODLimitChangeByAcctNo = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00059BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // LOMDTO00059BindingSource
            // 
            this.LOMDTO00059BindingSource.DataSource = typeof(Ace.Cbs.Loan.Dmd.LOMDTO00059);
            // 
            // rpvODLimitChangeByAcctNo
            // 
            this.rpvODLimitChangeByAcctNo.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSLOMRDLC00012";
            reportDataSource1.Value = this.LOMDTO00059BindingSource;
            this.rpvODLimitChangeByAcctNo.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvODLimitChangeByAcctNo.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00012.rdlc";
            this.rpvODLimitChangeByAcctNo.Location = new System.Drawing.Point(0, 0);
            this.rpvODLimitChangeByAcctNo.Name = "rpvODLimitChangeByAcctNo";
            this.rpvODLimitChangeByAcctNo.Size = new System.Drawing.Size(615, 460);
            this.rpvODLimitChangeByAcctNo.TabIndex = 0;
            // 
            // LOMVEW00062
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 460);
            this.Controls.Add(this.rpvODLimitChangeByAcctNo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00062";
            this.Text = "LOMVEW00062";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LOMVEW00062_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00059BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvODLimitChangeByAcctNo;
        private System.Windows.Forms.BindingSource LOMDTO00059BindingSource;
    }
}