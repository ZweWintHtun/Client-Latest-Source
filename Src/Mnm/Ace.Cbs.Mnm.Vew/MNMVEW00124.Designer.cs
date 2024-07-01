namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00124
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00124));
            this.PFMDTO00042BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvInternalRemittanceListing = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rpvInternalRemittanceListing
            // 
            this.rpvInternalRemittanceListing.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "InternalRemittanceDataSet";
            reportDataSource1.Value = this.PFMDTO00042BindingSource;
            this.rpvInternalRemittanceListing.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvInternalRemittanceListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00044.rdlc";
            this.rpvInternalRemittanceListing.Location = new System.Drawing.Point(0, 0);
            this.rpvInternalRemittanceListing.Name = "rpvInternalRemittanceListing";
            this.rpvInternalRemittanceListing.Size = new System.Drawing.Size(703, 495);
            this.rpvInternalRemittanceListing.TabIndex = 0;
            // 
            // MNMVEW00124
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 495);
            this.Controls.Add(this.rpvInternalRemittanceListing);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00124";
            this.Text = "Internal Remittance Outstanding Listing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MNMVEW00124_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvInternalRemittanceListing;
        private System.Windows.Forms.BindingSource PFMDTO00042BindingSource;
    }
}