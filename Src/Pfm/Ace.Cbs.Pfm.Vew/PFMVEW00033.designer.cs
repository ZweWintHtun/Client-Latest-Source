namespace Ace.Cbs.Pfm.Vew
{
    partial class frmPFMVEW00033
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPFMVEW00033));
            this.rpvCurrentAccountCompanyReport2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvCurrentAccountCompanyReport2
            // 
            this.rpvCurrentAccountCompanyReport2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvCurrentAccountCompanyReport2.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Pfm.Vew.RDLC.PFMRDLC00004.rdlc";
            this.rpvCurrentAccountCompanyReport2.Location = new System.Drawing.Point(0, 0);
            this.rpvCurrentAccountCompanyReport2.Name = "rpvCurrentAccountCompanyReport2";
            this.rpvCurrentAccountCompanyReport2.Size = new System.Drawing.Size(871, 570);
            this.rpvCurrentAccountCompanyReport2.TabIndex = 0;
            this.rpvCurrentAccountCompanyReport2.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage;
            // 
            // frmPFMVEW00033
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 570);
            this.Controls.Add(this.rpvCurrentAccountCompanyReport2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPFMVEW00033";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PFMVEW00033";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PFMVEW00033_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvCurrentAccountCompanyReport2;

    }
}