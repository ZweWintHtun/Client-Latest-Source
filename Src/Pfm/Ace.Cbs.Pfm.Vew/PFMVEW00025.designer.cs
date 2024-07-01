namespace Ace.Cbs.Pfm.Vew
{
    partial class frmPFMVEW00025
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPFMVEW00025));
            this.rpvCurrentAccountIndividual = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvCurrentAccountIndividual
            // 
            this.rpvCurrentAccountIndividual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvCurrentAccountIndividual.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Pfm.Vew.RDLC.PFMRDLC00002.rdlc";
            this.rpvCurrentAccountIndividual.Location = new System.Drawing.Point(0, 0);
            this.rpvCurrentAccountIndividual.Name = "rpvCurrentAccountIndividual";
            this.rpvCurrentAccountIndividual.Size = new System.Drawing.Size(846, 746);
            this.rpvCurrentAccountIndividual.TabIndex = 0;
            this.rpvCurrentAccountIndividual.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage;
            // 
            // frmPFMVEW00025
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 746);
            this.Controls.Add(this.rpvCurrentAccountIndividual);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPFMVEW00025";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PFMVEW00025";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PFMVEW00025_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvCurrentAccountIndividual;

    }
}