namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00104
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00104));
            this.PFMDTO00001BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvSubLedgerSpecific = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00001BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PFMDTO00001BindingSource
            // 
            this.PFMDTO00001BindingSource.DataSource = typeof(Ace.Cbs.Pfm.Dmd.PFMDTO00001);
            // 
            // rpvSubLedgerSpecific
            // 
            this.rpvSubLedgerSpecific.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "SubLedgerSpecificDataSet";
            reportDataSource1.Value = this.PFMDTO00001BindingSource;
            this.rpvSubLedgerSpecific.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvSubLedgerSpecific.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00024.rdlc";
            this.rpvSubLedgerSpecific.Location = new System.Drawing.Point(0, 0);
            this.rpvSubLedgerSpecific.Name = "rpvSubLedgerSpecific";
            this.rpvSubLedgerSpecific.Size = new System.Drawing.Size(601, 493);
            this.rpvSubLedgerSpecific.TabIndex = 0;
            // 
            // MNMVEW00104
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 493);
            this.Controls.Add(this.rpvSubLedgerSpecific);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MNMVEW00104";
            this.Text = "Sub Ledger Sheet for (Customer) A/C Specific ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MNMVEW00104_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00001BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource PFMDTO00001BindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer rpvSubLedgerSpecific;
    }
}