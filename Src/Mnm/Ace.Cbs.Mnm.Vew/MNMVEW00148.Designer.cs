namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00148
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00148));
            this.PFMDTO00042BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvPORegisterEncashListing = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rpvPORegisterEncashListing
            // 
            this.rpvPORegisterEncashListing.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "PORegisterEncashDataSet";
            reportDataSource1.Value = this.PFMDTO00042BindingSource;
            this.rpvPORegisterEncashListing.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvPORegisterEncashListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00084.rdlc";
            this.rpvPORegisterEncashListing.Location = new System.Drawing.Point(0, 0);
            this.rpvPORegisterEncashListing.Name = "rpvPORegisterEncashListing";
            this.rpvPORegisterEncashListing.Size = new System.Drawing.Size(499, 419);
            this.rpvPORegisterEncashListing.TabIndex = 0;
            // 
            // MNMVEW00148
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 419);
            this.Controls.Add(this.rpvPORegisterEncashListing);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00148";
            this.Text = "PO Register(Encash) Listing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MNMVEW00148_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvPORegisterEncashListing;
        private System.Windows.Forms.BindingSource PFMDTO00042BindingSource;
    }
}