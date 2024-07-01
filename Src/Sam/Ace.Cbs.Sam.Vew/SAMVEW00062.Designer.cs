namespace Ace.Cbs.Sam.Vew
{
    partial class SAMVEW00062
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAMVEW00062));
            this.rptRmitRate = new Microsoft.Reporting.WinForms.ReportViewer();
            this.RmitRateDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.RmitRateDTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rptRmitRate
            // 
            this.rptRmitRate.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "RmitRate_DataSet";
            reportDataSource1.Value = null;
            this.rptRmitRate.LocalReport.DataSources.Add(reportDataSource1);
            this.rptRmitRate.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Sam.Vew.RDLC.SAMRDLC00008.rdlc";
            this.rptRmitRate.Location = new System.Drawing.Point(0, 0);
            this.rptRmitRate.Name = "rptRmitRate";
            this.rptRmitRate.Size = new System.Drawing.Size(566, 380);
            this.rptRmitRate.TabIndex = 0;
            // 
            // RmitRateDTOBindingSource
            // 
            this.RmitRateDTOBindingSource.DataSource = typeof(Ace.Cbs.Tel.Dmd.TLMDTO00032);
            // 
            // SAMVEW00062
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 380);
            this.Controls.Add(this.rptRmitRate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SAMVEW00062";
            this.Text = "Branch Information (Remittance Rate)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SAMVEW00062_FormClosing);
            this.Load += new System.EventHandler(this.SAMVEW00062_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RmitRateDTOBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptRmitRate;
        private System.Windows.Forms.BindingSource RmitRateDTOBindingSource;
    }
}