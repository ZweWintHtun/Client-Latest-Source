namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00118
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00118));
            this.PFMDTO00029BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rptLinkAC = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00029BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PFMDTO00029BindingSource
            // 
            this.PFMDTO00029BindingSource.DataSource = typeof(Ace.Cbs.Pfm.Dmd.PFMDTO00029);
            // 
            // rptLinkAC
            // 
            this.rptLinkAC.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "LinkACinfoDS";
            reportDataSource1.Value = this.PFMDTO00029BindingSource;
            this.rptLinkAC.LocalReport.DataSources.Add(reportDataSource1);
            this.rptLinkAC.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00038.rdlc";
            this.rptLinkAC.Location = new System.Drawing.Point(0, 0);
            this.rptLinkAC.Name = "rptLinkAC";
            this.rptLinkAC.Size = new System.Drawing.Size(646, 482);
            this.rptLinkAC.TabIndex = 0;
            // 
            // MNMVEW00118
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 482);
            this.Controls.Add(this.rptLinkAC);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00118";
            this.Text = "MNMVEW00118";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MNMVEW00118_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00029BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptLinkAC;
        private System.Windows.Forms.BindingSource PFMDTO00029BindingSource;
    }
}