namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00062
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00062));
            this.PFMDTO00028BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvReconsile = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00028BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PFMDTO00028BindingSource
            // 
            this.PFMDTO00028BindingSource.DataSource = typeof(Ace.Cbs.Pfm.Dmd.PFMDTO00028);
            // 
            // rpvReconsile
            // 
            this.rpvReconsile.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Reconsile_DataSet";
            reportDataSource1.Value = this.PFMDTO00028BindingSource;
            this.rpvReconsile.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvReconsile.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tcm.Vew.RDLC.TCMRDLC00017.rdlc";
            this.rpvReconsile.Location = new System.Drawing.Point(0, 0);
            this.rpvReconsile.Name = "rpvReconsile";
            this.rpvReconsile.Size = new System.Drawing.Size(792, 571);
            this.rpvReconsile.TabIndex = 0;
            // 
            // TCMVEW00062
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 571);
            this.Controls.Add(this.rpvReconsile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TCMVEW00062";
            this.Text = "Daily Reconsilation Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TCMVEW00062_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00028BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvReconsile;
        private System.Windows.Forms.BindingSource PFMDTO00028BindingSource;
    }
}