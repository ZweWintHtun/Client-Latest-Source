namespace Ace.Cbs.Pfm.Vew
{
    partial class frmPFMVEW00022
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPFMVEW00022));
            this.rpvSavingWithdrawOnlineOfflineReport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvSavingWithdrawOnlineOfflineReport
            // 
            this.rpvSavingWithdrawOnlineOfflineReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvSavingWithdrawOnlineOfflineReport.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Pfm.Vew.RDLC.PFMRDLC00007.rdlc";
            this.rpvSavingWithdrawOnlineOfflineReport.Location = new System.Drawing.Point(0, 0);
            this.rpvSavingWithdrawOnlineOfflineReport.Name = "rpvSavingWithdrawOnlineOfflineReport";
            this.rpvSavingWithdrawOnlineOfflineReport.Size = new System.Drawing.Size(846, 581);
            this.rpvSavingWithdrawOnlineOfflineReport.TabIndex = 1;
            this.rpvSavingWithdrawOnlineOfflineReport.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage;
            this.rpvSavingWithdrawOnlineOfflineReport.ZoomPercent = 75;
            // 
            // frmPFMVEW00022
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 581);
            this.Controls.Add(this.rpvSavingWithdrawOnlineOfflineReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPFMVEW00022";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Saving Withdraw Report2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPFMVEW00022_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvSavingWithdrawOnlineOfflineReport;
    }
}