﻿namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00115
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00115));
            this.PFMDTO00042BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvFixedDepositInterest = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PFMDTO00042BindingSource
            // 
            this.PFMDTO00042BindingSource.DataSource = typeof(Ace.Cbs.Pfm.Dmd.PFMDTO00042);
            // 
            // rpvFixedDepositInterest
            // 
            this.rpvFixedDepositInterest.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "FixedDepositInterestDataSet";
            reportDataSource1.Value = this.PFMDTO00042BindingSource;
            this.rpvFixedDepositInterest.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvFixedDepositInterest.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00035.rdlc";
            this.rpvFixedDepositInterest.Location = new System.Drawing.Point(0, 0);
            this.rpvFixedDepositInterest.Name = "rpvFixedDepositInterest";
            this.rpvFixedDepositInterest.Size = new System.Drawing.Size(631, 482);
            this.rpvFixedDepositInterest.TabIndex = 0;
            // 
            // MNMVEW00115
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 482);
            this.Controls.Add(this.rpvFixedDepositInterest);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00115";
            this.Text = "Fixed Deposit Interest Listing";
            this.Load += new System.EventHandler(this.MNMVEW00115_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvFixedDepositInterest;
        private System.Windows.Forms.BindingSource PFMDTO00042BindingSource;
    }
}