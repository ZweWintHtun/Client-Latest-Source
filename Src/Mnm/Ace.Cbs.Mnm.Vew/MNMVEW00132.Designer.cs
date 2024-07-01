namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00132
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00132));
            this.PFMDTO00017BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvCurrentAccountPartnership = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00017BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PFMDTO00017BindingSource
            // 
            this.PFMDTO00017BindingSource.DataSource = typeof(Ace.Cbs.Pfm.Dmd.PFMDTO00017);
            // 
            // rpvCurrentAccountPartnership
            // 
            this.rpvCurrentAccountPartnership.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvCurrentAccountPartnership.DocumentMapWidth = 90;
            reportDataSource1.Name = "CurrentAccountPartnership";
            reportDataSource1.Value = this.PFMDTO00017BindingSource;
            this.rpvCurrentAccountPartnership.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvCurrentAccountPartnership.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00052.rdlc";
            this.rpvCurrentAccountPartnership.Location = new System.Drawing.Point(0, 0);
            this.rpvCurrentAccountPartnership.Name = "rpvCurrentAccountPartnership";
            this.rpvCurrentAccountPartnership.Size = new System.Drawing.Size(518, 354);
            this.rpvCurrentAccountPartnership.TabIndex = 0;
            // 
            // MNMVEW00132
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 354);
            this.Controls.Add(this.rpvCurrentAccountPartnership);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00132";
            this.Text = "MNMVEW00132";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MNMVEW00132_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00017BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvCurrentAccountPartnership;
        private System.Windows.Forms.BindingSource PFMDTO00017BindingSource;
    }
}