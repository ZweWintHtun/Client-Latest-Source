﻿namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00051
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00051));
            this.PFMDTO00042BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvCleanCashOD = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rpvCleanCashOD
            // 
            this.rpvCleanCashOD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "CleanCashDataset";
            reportDataSource1.Value = this.PFMDTO00042BindingSource;
            this.rpvCleanCashOD.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvCleanCashOD.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tcm.Vew.RDLC.TCMRDLC00006.rdlc";
            this.rpvCleanCashOD.Location = new System.Drawing.Point(0, 0);
            this.rpvCleanCashOD.Name = "rpvCleanCashOD";
            this.rpvCleanCashOD.Size = new System.Drawing.Size(660, 332);
            this.rpvCleanCashOD.TabIndex = 0;
            // 
            // TCMVEW00051
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 332);
            this.Controls.Add(this.rpvCleanCashOD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TCMVEW00051";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clean Cash Overdraft Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TCMCleanCashODReport_FormClosed);
            this.Load += new System.EventHandler(this.TCMCleanCashODReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvCleanCashOD;
        private System.Windows.Forms.BindingSource PFMDTO00042BindingSource;
    }
}