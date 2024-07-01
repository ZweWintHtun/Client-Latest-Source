namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00129
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00129));
            this.PFMDTO00029BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MNMDTO00010BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rptLinkAccountPriority = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00029BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00010BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PFMDTO00029BindingSource
            // 
            this.PFMDTO00029BindingSource.DataSource = typeof(Ace.Cbs.Pfm.Dmd.PFMDTO00029);
            // 
            // MNMDTO00010BindingSource
            // 
            this.MNMDTO00010BindingSource.DataSource = typeof(Ace.Cbs.Mnm.Dmd.MNMDTO00010);
            // 
            // rptLinkAccountPriority
            // 
            this.rptLinkAccountPriority.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "LinkAutoPriorityDS";
            reportDataSource1.Value = this.PFMDTO00029BindingSource;
            this.rptLinkAccountPriority.LocalReport.DataSources.Add(reportDataSource1);
            this.rptLinkAccountPriority.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00049.rdlc";
            this.rptLinkAccountPriority.Location = new System.Drawing.Point(0, 0);
            this.rptLinkAccountPriority.Name = "rptLinkAccountPriority";
            this.rptLinkAccountPriority.Size = new System.Drawing.Size(632, 408);
            this.rptLinkAccountPriority.TabIndex = 0;
            // 
            // MNMVEW00129
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 408);
            this.Controls.Add(this.rptLinkAccountPriority);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00129";
            this.Text = "MNMVEW00129";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MNMVEW00129_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00029BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00010BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptLinkAccountPriority;
        private System.Windows.Forms.BindingSource MNMDTO00010BindingSource;
        private System.Windows.Forms.BindingSource PFMDTO00029BindingSource;
    }
}