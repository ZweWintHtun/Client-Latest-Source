namespace Ace.Cbs.Pfm.Vew
{
    partial class frmPFMVEW00034
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPFMVEW00034));
            this.rpvSavingCorganizationr2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvSavingCorganizationr2
            // 
            this.rpvSavingCorganizationr2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvSavingCorganizationr2.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Pfm.Vew.RDLC.PFMRDLC00009.rdlc";
            this.rpvSavingCorganizationr2.Location = new System.Drawing.Point(0, 0);
            this.rpvSavingCorganizationr2.Name = "rpvSavingCorganizationr2";
            this.rpvSavingCorganizationr2.Size = new System.Drawing.Size(811, 539);
            this.rpvSavingCorganizationr2.TabIndex = 0;
            this.rpvSavingCorganizationr2.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage;
            // 
            // frmPFMVEW00034
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 539);
            this.Controls.Add(this.rpvSavingCorganizationr2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPFMVEW00034";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PFMVEW00034";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PFMVEW00034_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvSavingCorganizationr2;
    }
}