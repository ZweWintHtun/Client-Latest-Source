namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00157
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00157));
            this.TLMDTO00017BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvDrawingEncashRemittance = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00017BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TLMDTO00017BindingSource
            // 
            this.TLMDTO00017BindingSource.DataSource = typeof(Ace.Cbs.Tel.Dmd.TLMDTO00017);
            // 
            // rpvDrawingEncashRemittance
            // 
            this.rpvDrawingEncashRemittance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rpvDrawingEncashRemittance.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DrawingRemittanceClosingDataSet";
            reportDataSource1.Value = this.TLMDTO00017BindingSource;
            this.rpvDrawingEncashRemittance.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvDrawingEncashRemittance.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00016.rdlc";
            this.rpvDrawingEncashRemittance.Location = new System.Drawing.Point(0, 0);
            this.rpvDrawingEncashRemittance.Name = "rpvDrawingEncashRemittance";
            this.rpvDrawingEncashRemittance.Size = new System.Drawing.Size(727, 505);
            this.rpvDrawingEncashRemittance.TabIndex = 1;
            // 
            // MNMVEW00157
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 505);
            this.Controls.Add(this.rpvDrawingEncashRemittance);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00157";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MNMVEW00157";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MNMVEW00157_FormClosing);
            this.Load += new System.EventHandler(this.MNMVEW00157_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00017BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvDrawingEncashRemittance;
        private System.Windows.Forms.BindingSource TLMDTO00017BindingSource;
    }
}