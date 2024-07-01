namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00058
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00058));
            this.TLMDTO00017BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvRemittanceListing = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00017BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TLMDTO00017BindingSource
            // 
            this.TLMDTO00017BindingSource.DataSource = typeof(Ace.Cbs.Tel.Dmd.TLMDTO00017);
            // 
            // rpvRemittanceListing
            // 
            this.rpvRemittanceListing.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rpvRemittanceListing.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DrawingEncashRemittanceDataSet";
            reportDataSource1.Value = this.TLMDTO00017BindingSource;
            this.rpvRemittanceListing.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvRemittanceListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tel.Vew.RDLC.TLMRDLC00016.rdlc";
            this.rpvRemittanceListing.Location = new System.Drawing.Point(0, 0);
            this.rpvRemittanceListing.Name = "rpvRemittanceListing";
            this.rpvRemittanceListing.Size = new System.Drawing.Size(727, 505);
            this.rpvRemittanceListing.TabIndex = 0;
            // 
            // TLMVEW00058
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 505);
            this.Controls.Add(this.rpvRemittanceListing);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00058";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TLMVEW00058_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00017BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvRemittanceListing;
        private System.Windows.Forms.BindingSource TLMDTO00017BindingSource;
    }
}