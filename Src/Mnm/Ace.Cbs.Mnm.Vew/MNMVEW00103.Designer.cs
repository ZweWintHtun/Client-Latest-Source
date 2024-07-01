namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00103
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00103));
            this.MNMDTO00054BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvSubLedgerDomestic = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00054BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MNMDTO00054BindingSource
            // 
            this.MNMDTO00054BindingSource.DataSource = typeof(Ace.Cbs.Mnm.Dmd.MNMDTO00054);
            // 
            // rpvSubLedgerDomestic
            // 
            this.rpvSubLedgerDomestic.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "SubLedgerDomestic";
            reportDataSource1.Value = this.MNMDTO00054BindingSource;
            this.rpvSubLedgerDomestic.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvSubLedgerDomestic.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00023.rdlc";
            this.rpvSubLedgerDomestic.Location = new System.Drawing.Point(0, 0);
            this.rpvSubLedgerDomestic.Name = "rpvSubLedgerDomestic";
            this.rpvSubLedgerDomestic.Size = new System.Drawing.Size(698, 552);
            this.rpvSubLedgerDomestic.TabIndex = 0;
            // 
            // MNMVEW00103
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 552);
            this.Controls.Add(this.rpvSubLedgerDomestic);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MNMVEW00103";
            this.Text = "Sub Ledger (Domestic) Listing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MNMVEW00103_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00054BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvSubLedgerDomestic;


        private System.Windows.Forms.BindingSource MNMDTO00054BindingSource;

       // private System.Windows.Forms.BindingSource pFMDTO00042BindingSource;


    }
}