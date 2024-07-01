namespace Ace.Cbs.Pfm.Vew
{
    partial class frmPFMVEW00028
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPFMVEW00028));
            this.rpvPFMVEW0028 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvPFMVEW0028
            // 
            this.rpvPFMVEW0028.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvPFMVEW0028.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Pfm.Vew.RDLC.PFMRDLC00012.rdlc";
            this.rpvPFMVEW0028.Location = new System.Drawing.Point(0, 0);
            this.rpvPFMVEW0028.Name = "rpvPFMVEW0028";
            this.rpvPFMVEW0028.Size = new System.Drawing.Size(846, 748);
            this.rpvPFMVEW0028.TabIndex = 1;
            this.rpvPFMVEW0028.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage;
            // 
            // frmPFMVEW00028
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 748);
            this.Controls.Add(this.rpvPFMVEW0028);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPFMVEW00028";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Current Account Joint Report 3";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPFMVEW00028_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvPFMVEW0028;
    }
}