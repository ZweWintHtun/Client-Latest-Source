namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00141
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00141));
            this.PFMDTO00042BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvComingInterestDataSet = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PFMDTO00042BindingSource
            // 
            this.PFMDTO00042BindingSource.DataSource = typeof(Ace.Cbs.Pfm.Dmd.PFMDTO00042);
            // 
            // rpvComingInterestDataSet
            // 
            this.rpvComingInterestDataSet.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "ComingInterestDataSet";
            reportDataSource1.Value = this.PFMDTO00042BindingSource;
            this.rpvComingInterestDataSet.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvComingInterestDataSet.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00059.rdlc";
            this.rpvComingInterestDataSet.Location = new System.Drawing.Point(0, 0);
            this.rpvComingInterestDataSet.Name = "rpvComingInterestDataSet";
            this.rpvComingInterestDataSet.Size = new System.Drawing.Size(794, 573);
            this.rpvComingInterestDataSet.TabIndex = 0;
            // 
            // MNMVEW00141
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 573);
            this.Controls.Add(this.rpvComingInterestDataSet);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00141";
            this.Text = "Coming Interest Listing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MNMVEW00141_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvComingInterestDataSet;
        private System.Windows.Forms.BindingSource PFMDTO00042BindingSource;
    }
}