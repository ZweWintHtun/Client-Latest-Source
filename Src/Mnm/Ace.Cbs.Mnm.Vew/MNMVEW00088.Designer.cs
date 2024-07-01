namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00088
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00088));
            this.PFMDTO00029BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvAutoLinkSchdule = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00029BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PFMDTO00029BindingSource
            // 
            this.PFMDTO00029BindingSource.DataSource = typeof(Ace.Cbs.Pfm.Dmd.PFMDTO00029);
            // 
            // rpvAutoLinkSchdule
            // 
            this.rpvAutoLinkSchdule.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "AutoLinkScheduleDataSet";
            reportDataSource1.Value = this.PFMDTO00029BindingSource;
            this.rpvAutoLinkSchdule.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvAutoLinkSchdule.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00008.rdlc";
            this.rpvAutoLinkSchdule.Location = new System.Drawing.Point(0, 0);
            this.rpvAutoLinkSchdule.Name = "rpvAutoLinkSchdule";
            this.rpvAutoLinkSchdule.Size = new System.Drawing.Size(724, 538);
            this.rpvAutoLinkSchdule.TabIndex = 0;
            // 
            // MNMVEW00088
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 538);
            this.Controls.Add(this.rpvAutoLinkSchdule);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00088";
            this.Text = "Auto Link Schedule ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MNMVEW00088_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00029BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvAutoLinkSchdule;
        private System.Windows.Forms.BindingSource PFMDTO00029BindingSource;
    }
}