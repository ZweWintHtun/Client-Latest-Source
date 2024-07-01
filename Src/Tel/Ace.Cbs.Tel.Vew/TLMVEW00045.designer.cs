namespace Ace.Cbs.Tel.Vew
{
    partial class frmTLMVEW00045
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTLMVEW00045));
            this.TLMDTO00016BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvListingForPaymentOrderOutstandingNormal = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00016BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TLMDTO00016BindingSource
            // 
            this.TLMDTO00016BindingSource.DataMember = "TLMDTO00016";
            // 
            // rpvListingForPaymentOrderOutstandingNormal
            // 
            this.rpvListingForPaymentOrderOutstandingNormal.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "POOutstandingReportDataSet";
            reportDataSource1.Value = this.TLMDTO00016BindingSource;
            this.rpvListingForPaymentOrderOutstandingNormal.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvListingForPaymentOrderOutstandingNormal.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tel.Vew.RDLC.TLMRDLC00003.rdlc";
            this.rpvListingForPaymentOrderOutstandingNormal.Location = new System.Drawing.Point(0, 0);
            this.rpvListingForPaymentOrderOutstandingNormal.Name = "rpvListingForPaymentOrderOutstandingNormal";
            this.rpvListingForPaymentOrderOutstandingNormal.Size = new System.Drawing.Size(733, 386);
            this.rpvListingForPaymentOrderOutstandingNormal.TabIndex = 0;
            // 
            // frmTLMVEW00045
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 386);
            this.Controls.Add(this.rpvListingForPaymentOrderOutstandingNormal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTLMVEW00045";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TLMVEW00045_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00016BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource TLMDTO00016BindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer rpvListingForPaymentOrderOutstandingNormal;







    }
}