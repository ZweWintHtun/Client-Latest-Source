namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00098
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00098));
            this.MNMDTO00032BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvBalanceCertificate = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00032BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MNMDTO00032BindingSource
            // 
            this.MNMDTO00032BindingSource.DataSource = typeof(Ace.Cbs.Mnm.Dmd.DTO.MNMDTO00032);
            // 
            // rpvBalanceCertificate
            // 
            this.rpvBalanceCertificate.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "MNMDS00017";
            reportDataSource1.Value = this.MNMDTO00032BindingSource;
            this.rpvBalanceCertificate.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvBalanceCertificate.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00017.rdlc";
            this.rpvBalanceCertificate.Location = new System.Drawing.Point(0, 0);
            this.rpvBalanceCertificate.Name = "rpvBalanceCertificate";
            this.rpvBalanceCertificate.Size = new System.Drawing.Size(518, 425);
            this.rpvBalanceCertificate.TabIndex = 0;
            this.rpvBalanceCertificate.Load += new System.EventHandler(this.rpvBalanceCertificate_Load);
            // 
            // MNMVEW00098
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 425);
            this.Controls.Add(this.rpvBalanceCertificate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00098";
            this.Text = "Balance Certificate Listing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MNMVEW00098_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00032BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvBalanceCertificate;
        private System.Windows.Forms.BindingSource MNMDTO00032BindingSource;
    }
}