namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00066
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00066));
            this.rpvWithdrawal = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvWithdrawal
            // 
            this.rpvWithdrawal.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "WithdrawalListingAllDataSet";
            reportDataSource1.Value = null;
            this.rpvWithdrawal.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvWithdrawal.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tel.Vew.RDLC.TLMRDLC00024.rdlc";
            this.rpvWithdrawal.Location = new System.Drawing.Point(0, 0);
            this.rpvWithdrawal.Name = "rpvWithdrawal";
            this.rpvWithdrawal.Size = new System.Drawing.Size(770, 505);
            this.rpvWithdrawal.TabIndex = 0;
            // 
            // TLMVEW00066
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 505);
            this.Controls.Add(this.rpvWithdrawal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00066";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TLMVEW00066_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvWithdrawal;
    }
}