namespace Ace.Cbs.Pfm.Vew
{
    partial class frmPFMVEW00024
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPFMVEW00024));
            this.rpvSavingWithdrawReport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvSavingWithdrawReport
            // 
            this.rpvSavingWithdrawReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvSavingWithdrawReport.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Pfm.Vew.RDLC.PFMRDLC00005.rdlc";
            this.rpvSavingWithdrawReport.Location = new System.Drawing.Point(0, 0);
            this.rpvSavingWithdrawReport.Name = "rpvSavingWithdrawReport";
            this.rpvSavingWithdrawReport.Size = new System.Drawing.Size(855, 541);
            this.rpvSavingWithdrawReport.TabIndex = 1;
            this.rpvSavingWithdrawReport.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage;
            this.rpvSavingWithdrawReport.ZoomPercent = 75;
            // 
            // frmPFMVEW00024
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 541);
            this.Controls.Add(this.rpvSavingWithdrawReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPFMVEW00024";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Saving Online Withdraw Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPFMVEW00024_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvSavingWithdrawReport;
    }
}