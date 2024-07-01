namespace Ace.Cbs.Gl.Vew
{
    partial class GLMVEW00013
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GLMVEW00013));
            this.GLMDTO00013BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvCOAListing = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.GLMDTO00013BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // GLMDTO00013BindingSource
            // 
            this.GLMDTO00013BindingSource.DataSource = typeof(Ace.Cbs.Gl.Dmd.GLMDTO00013);
            // 
            // rpvCOAListing
            // 
            this.rpvCOAListing.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "GLMDS00013";
            reportDataSource1.Value = this.GLMDTO00013BindingSource;
            this.rpvCOAListing.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvCOAListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Gl.Vew.RDLC.GLMRDLC00013.rdlc";
            this.rpvCOAListing.Location = new System.Drawing.Point(0, 0);
            this.rpvCOAListing.Name = "rpvCOAListing";
            this.rpvCOAListing.Size = new System.Drawing.Size(649, 266);
            this.rpvCOAListing.TabIndex = 0;
            // 
            // GLMVEW00013
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 266);
            this.Controls.Add(this.rpvCOAListing);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GLMVEW00013";
            this.Text = "Charge of Account Listing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GLMVEW00013_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GLMDTO00013BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvCOAListing;
        private System.Windows.Forms.BindingSource GLMDTO00013BindingSource;
    }
}