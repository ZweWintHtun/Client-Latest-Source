namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00126
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00126));
            this.TLMDTO00017BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvDailyDrawingRemittance = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00017BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TLMDTO00017BindingSource
            // 
            this.TLMDTO00017BindingSource.DataSource = typeof(Ace.Cbs.Tel.Dmd.TLMDTO00017);
            // 
            // rpvDailyDrawingRemittance
            // 
            this.rpvDailyDrawingRemittance.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DailyDrawingRemittanceDS";
            reportDataSource1.Value = this.TLMDTO00017BindingSource;
            this.rpvDailyDrawingRemittance.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvDailyDrawingRemittance.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00046.rdlc";
            this.rpvDailyDrawingRemittance.Location = new System.Drawing.Point(0, 0);
            this.rpvDailyDrawingRemittance.Name = "rpvDailyDrawingRemittance";
            this.rpvDailyDrawingRemittance.Size = new System.Drawing.Size(702, 486);
            this.rpvDailyDrawingRemittance.TabIndex = 0;
            // 
            // MNMVEW00126
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 486);
            this.Controls.Add(this.rpvDailyDrawingRemittance);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00126";
            this.Text = "Daily Drawing Remittance Listing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MNMVEW00126_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00017BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvDailyDrawingRemittance;
        private System.Windows.Forms.BindingSource TLMDTO00017BindingSource;
    }
}