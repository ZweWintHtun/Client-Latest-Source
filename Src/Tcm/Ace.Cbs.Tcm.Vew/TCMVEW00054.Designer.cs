namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00054
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00054));
            this.PFMDTO00042BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvDeliveredCheque = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PFMDTO00042BindingSource
            // 
            this.PFMDTO00042BindingSource.DataSource = typeof(Ace.Cbs.Pfm.Dmd.PFMDTO00042);
            // 
            // rpvDeliveredCheque
            // 
            this.rpvDeliveredCheque.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "PFMDTO00042_DataSet";
            reportDataSource1.Value = this.PFMDTO00042BindingSource;
            this.rpvDeliveredCheque.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvDeliveredCheque.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tcm.Vew.RDLC.TCMRDLC00009.rdlc";
            this.rpvDeliveredCheque.Location = new System.Drawing.Point(0, 0);
            this.rpvDeliveredCheque.Name = "rpvDeliveredCheque";
            this.rpvDeliveredCheque.Size = new System.Drawing.Size(689, 481);
            this.rpvDeliveredCheque.TabIndex = 0;
            // 
            // TCMVEW00054
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 481);
            this.Controls.Add(this.rpvDeliveredCheque);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TCMVEW00054";
            this.Text = "Delivered Cheque Listing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TCMVEW00054_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvDeliveredCheque;
        private System.Windows.Forms.BindingSource PFMDTO00042BindingSource;
    }
}