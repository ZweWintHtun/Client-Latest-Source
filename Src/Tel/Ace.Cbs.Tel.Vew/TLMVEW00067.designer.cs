﻿namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00067
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00067));
            this.PFMDTO00042BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvWithdrawalCounterNo = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PFMDTO00042BindingSource
            // 
            this.PFMDTO00042BindingSource.DataSource = typeof(Ace.Cbs.Pfm.Dmd.PFMDTO00042);
            // 
            // rpvWithdrawalCounterNo
            // 
            this.rpvWithdrawalCounterNo.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "WithdrawalListingByCounterNoDataSet";
            reportDataSource1.Value = this.PFMDTO00042BindingSource;
            this.rpvWithdrawalCounterNo.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvWithdrawalCounterNo.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tel.Vew.RDLC.TLMRDLC00025.rdlc";
            this.rpvWithdrawalCounterNo.Location = new System.Drawing.Point(0, 0);
            this.rpvWithdrawalCounterNo.Name = "rpvWithdrawalCounterNo";
            this.rpvWithdrawalCounterNo.Size = new System.Drawing.Size(874, 410);
            this.rpvWithdrawalCounterNo.TabIndex = 0;
            // 
            // TLMVEW00067
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 410);
            this.Controls.Add(this.rpvWithdrawalCounterNo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00067";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TLMVEW00067_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvWithdrawalCounterNo;
        private System.Windows.Forms.BindingSource PFMDTO00042BindingSource;
    }
}