namespace Ace.Cbs.Gl.Vew
{
    partial class GLMVEW00014
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GLMVEW00014));
            this.MNMDTO00037BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvOLSTotalListing = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00037BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MNMDTO00037BindingSource
            // 
            this.MNMDTO00037BindingSource.DataSource = typeof(Ace.Cbs.Mnm.Dmd.MNMDTO00037);
            // 
            // rpvOLSTotalListing
            // 
            this.rpvOLSTotalListing.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "GLMDS00014";
            reportDataSource1.Value = this.MNMDTO00037BindingSource;
            this.rpvOLSTotalListing.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvOLSTotalListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Gl.Vew.RDLC.GLMRDLC00002.rdlc";
            this.rpvOLSTotalListing.Location = new System.Drawing.Point(0, 0);
            this.rpvOLSTotalListing.Name = "rpvOLSTotalListing";
            this.rpvOLSTotalListing.Size = new System.Drawing.Size(642, 271);
            this.rpvOLSTotalListing.TabIndex = 0;
            // 
            // GLMVEW00014
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 271);
            this.Controls.Add(this.rpvOLSTotalListing);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GLMVEW00014";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OLS Total Listing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GLMVEW00014_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00037BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvOLSTotalListing;
        private System.Windows.Forms.BindingSource MNMDTO00037BindingSource;
    }
}