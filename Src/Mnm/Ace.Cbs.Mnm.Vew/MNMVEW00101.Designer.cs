namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00101
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00101));
            this.pFMDTO00001BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvCustomerLedger = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.pFMDTO00001BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pFMDTO00001BindingSource
            // 
            this.pFMDTO00001BindingSource.DataSource = typeof(Ace.Cbs.Pfm.Dmd.PFMDTO00001);
            // 
            // rpvCustomerLedger
            // 
            this.rpvCustomerLedger.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "SubLedgerCustomerDataSet";
            reportDataSource1.Value = this.pFMDTO00001BindingSource;
            this.rpvCustomerLedger.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvCustomerLedger.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00021.rdlc";
            this.rpvCustomerLedger.Location = new System.Drawing.Point(0, 0);
            this.rpvCustomerLedger.Name = "rpvCustomerLedger";
            this.rpvCustomerLedger.Size = new System.Drawing.Size(661, 488);
            this.rpvCustomerLedger.TabIndex = 0;
            // 
            // MNMVEW00101
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 488);
            this.Controls.Add(this.rpvCustomerLedger);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MNMVEW00101";
            this.Text = "Sub Ledger (Customer) Listing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MNMVEW00101_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pFMDTO00001BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvCustomerLedger;
        private System.Windows.Forms.BindingSource pFMDTO00001BindingSource;
    }
}