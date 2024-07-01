namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00117
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00117));
            this.MNMDTO00037BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvClosedAccount = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00037BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MNMDTO00037BindingSource
            // 
            this.MNMDTO00037BindingSource.DataSource = typeof(Ace.Cbs.Mnm.Dmd.MNMDTO00037);
            // 
            // rpvClosedAccount
            // 
            this.rpvClosedAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "MNMDS00037";
            reportDataSource1.Value = this.MNMDTO00037BindingSource;
            this.rpvClosedAccount.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvClosedAccount.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00037.rdlc";
            this.rpvClosedAccount.Location = new System.Drawing.Point(0, 0);
            this.rpvClosedAccount.Name = "rpvClosedAccount";
            this.rpvClosedAccount.Size = new System.Drawing.Size(660, 472);
            this.rpvClosedAccount.TabIndex = 0;
            this.rpvClosedAccount.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage;
            // 
            // MNMVEW00117
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 472);
            this.Controls.Add(this.rpvClosedAccount);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00117";
            this.Text = "MNMVEW00117";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MNMVEW00117_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00037BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvClosedAccount;
        private System.Windows.Forms.BindingSource MNMDTO00037BindingSource;
    }
}