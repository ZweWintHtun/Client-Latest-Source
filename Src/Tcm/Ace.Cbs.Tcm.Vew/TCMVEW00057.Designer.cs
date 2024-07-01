namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00057
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00057));
            this.PFMDTO00042BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvClearingDeliveredReverse = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rpvClearingDeliveredReverse
            // 
            this.rpvClearingDeliveredReverse.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "PFMDTO00042_DataSet";
            reportDataSource1.Value = this.PFMDTO00042BindingSource;
            this.rpvClearingDeliveredReverse.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvClearingDeliveredReverse.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tcm.Vew.RDLC.TCMRDLC00012.rdlc";
            this.rpvClearingDeliveredReverse.Location = new System.Drawing.Point(0, 0);
            this.rpvClearingDeliveredReverse.Name = "rpvClearingDeliveredReverse";
            this.rpvClearingDeliveredReverse.Size = new System.Drawing.Size(610, 538);
            this.rpvClearingDeliveredReverse.TabIndex = 0;
            // 
            // TCMVEW00057
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 538);
            this.Controls.Add(this.rpvClearingDeliveredReverse);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TCMVEW00057";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TCMVEW00057";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TCMVEW00057_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvClearingDeliveredReverse;
        private System.Windows.Forms.BindingSource PFMDTO00042BindingSource;
    }
}