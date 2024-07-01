namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00137
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00137));
            this.TLMDTO00001BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvDailyEncashRemittance = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00001BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TLMDTO00001BindingSource
            // 
            this.TLMDTO00001BindingSource.DataSource = typeof(Ace.Cbs.Tel.Dmd.TLMDTO00001);
            // 
            // rpvDailyEncashRemittance
            // 
            this.rpvDailyEncashRemittance.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DailyEncashRemittanceDS";
            reportDataSource1.Value = this.TLMDTO00001BindingSource;
            this.rpvDailyEncashRemittance.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvDailyEncashRemittance.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00057.rdlc";
            this.rpvDailyEncashRemittance.Location = new System.Drawing.Point(0, 0);
            this.rpvDailyEncashRemittance.Name = "rpvDailyEncashRemittance";
            this.rpvDailyEncashRemittance.Size = new System.Drawing.Size(589, 380);
            this.rpvDailyEncashRemittance.TabIndex = 0;
            // 
            // MNMVEW00137
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 380);
            this.Controls.Add(this.rpvDailyEncashRemittance);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00137";
            this.Text = "Daily Encashment Remittance Listing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MNMVEW00137_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00001BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvDailyEncashRemittance;
        private System.Windows.Forms.BindingSource TLMDTO00001BindingSource;
    }
}