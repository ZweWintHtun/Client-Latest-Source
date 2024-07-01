namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00061
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00061));
            this.TLMDTO00017BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvEncashmentRemittanceListingByBranch = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00017BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TLMDTO00017BindingSource
            // 
            this.TLMDTO00017BindingSource.DataMember = "TLMDTO00017";
            // 
            // rpvEncashmentRemittanceListingByBranch
            // 
            this.rpvEncashmentRemittanceListingByBranch.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "EncashRemittanceDataSet";
            reportDataSource1.Value = this.TLMDTO00017BindingSource;
            this.rpvEncashmentRemittanceListingByBranch.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvEncashmentRemittanceListingByBranch.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tel.Vew.RDLC.TLMRDLC00020.rdlc";
            this.rpvEncashmentRemittanceListingByBranch.Location = new System.Drawing.Point(0, 0);
            this.rpvEncashmentRemittanceListingByBranch.Name = "rpvEncashmentRemittanceListingByBranch";
            this.rpvEncashmentRemittanceListingByBranch.Size = new System.Drawing.Size(849, 559);
            this.rpvEncashmentRemittanceListingByBranch.TabIndex = 0;
            // 
            // TLMVEW00061
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 559);
            this.Controls.Add(this.rpvEncashmentRemittanceListingByBranch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00061";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TLMVEW00061_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00017BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvEncashmentRemittanceListingByBranch;
        private System.Windows.Forms.BindingSource TLMDTO00017BindingSource;
    }
}