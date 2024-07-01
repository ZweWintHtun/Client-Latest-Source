namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00076
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00076));
            this.MNMDTO00076BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvPOIR = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00076BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MNMDTO00076BindingSource
            // 
            this.MNMDTO00076BindingSource.DataSource = typeof(Ace.Cbs.Mnm.Dmd.MNMDTO00076);
            // 
            // rpvPOIR
            // 
            this.rpvPOIR.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "MNMDS00076";
            reportDataSource1.Value = this.MNMDTO00076BindingSource;
            this.rpvPOIR.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvPOIR.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00045.rdlc";
            this.rpvPOIR.Location = new System.Drawing.Point(0, 0);
            this.rpvPOIR.Name = "rpvPOIR";
            this.rpvPOIR.Size = new System.Drawing.Size(628, 356);
            this.rpvPOIR.TabIndex = 0;
            // 
            // MNMVEW00076
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 356);
            this.Controls.Add(this.rpvPOIR);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00076";
            this.Text = "Outstanding Listing for PO and IR";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MNMVEW00076_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00076BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvPOIR;
        private System.Windows.Forms.BindingSource MNMDTO00076BindingSource;

    }
}