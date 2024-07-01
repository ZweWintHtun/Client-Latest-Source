namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00160
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00160));
            this.TLMDTO00001BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvDrawingEncashRemittance = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00001BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TLMDTO00001BindingSource
            // 
            this.TLMDTO00001BindingSource.DataSource = typeof(Ace.Cbs.Tel.Dmd.TLMDTO00001);
            // 
            // rpvDrawingEncashRemittance
            // 
            this.rpvDrawingEncashRemittance.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "EncashRemittanceClosingDataSet";
            reportDataSource1.Value = this.TLMDTO00001BindingSource;
            this.rpvDrawingEncashRemittance.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvDrawingEncashRemittance.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00017.rdlc";
            this.rpvDrawingEncashRemittance.Location = new System.Drawing.Point(0, 0);
            this.rpvDrawingEncashRemittance.Name = "rpvDrawingEncashRemittance";
            this.rpvDrawingEncashRemittance.Size = new System.Drawing.Size(727, 505);
            this.rpvDrawingEncashRemittance.TabIndex = 0;
            // 
            // MNMVEW00160
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 505);
            this.Controls.Add(this.rpvDrawingEncashRemittance);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00160";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MNMVEW00160";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MNMVEW00160_FormClosing);
            this.Load += new System.EventHandler(this.MNMVEW00160_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00001BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvDrawingEncashRemittance;
        private System.Windows.Forms.BindingSource TLMDTO00001BindingSource;
    }
}