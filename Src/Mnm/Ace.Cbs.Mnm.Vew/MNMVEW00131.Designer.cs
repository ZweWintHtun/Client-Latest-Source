namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00131
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00131));
            this.MNMDTO00035BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rptFixedDuration = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00035BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MNMDTO00035BindingSource
            // 
            this.MNMDTO00035BindingSource.DataSource = typeof(Ace.Cbs.Mnm.Dmd.MNMDTO00035);
            // 
            // rptFixedDuration
            // 
            this.rptFixedDuration.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "FixedDurationDS";
            reportDataSource1.Value = this.MNMDTO00035BindingSource;
            this.rptFixedDuration.LocalReport.DataSources.Add(reportDataSource1);
            this.rptFixedDuration.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00051.rdlc";
            this.rptFixedDuration.Location = new System.Drawing.Point(0, 0);
            this.rptFixedDuration.Name = "rptFixedDuration";
            this.rptFixedDuration.Size = new System.Drawing.Size(482, 419);
            this.rptFixedDuration.TabIndex = 0;
            // 
            // MNMVEW00131
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 419);
            this.Controls.Add(this.rptFixedDuration);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00131";
            this.Text = "MNMVEW00131";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MNMVEW00131_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00035BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptFixedDuration;
        private System.Windows.Forms.BindingSource MNMDTO00035BindingSource;
    }
}