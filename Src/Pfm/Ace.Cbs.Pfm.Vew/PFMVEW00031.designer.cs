namespace Ace.Cbs.Pfm.Vew
{
    partial class frmPFMVEW00031
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPFMVEW00031));
            this.rpvSavingMinorReport2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvSavingMinorReport2
            // 
            this.rpvSavingMinorReport2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvSavingMinorReport2.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Pfm.Vew.RDLC.PFMRDLC00013.rdlc";
            this.rpvSavingMinorReport2.Location = new System.Drawing.Point(0, 0);
            this.rpvSavingMinorReport2.Name = "rpvSavingMinorReport2";
            this.rpvSavingMinorReport2.Size = new System.Drawing.Size(846, 746);
            this.rpvSavingMinorReport2.TabIndex = 1;
            this.rpvSavingMinorReport2.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage;
            // 
            // frmPFMVEW00031
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 746);
            this.Controls.Add(this.rpvSavingMinorReport2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPFMVEW00031";
            this.Text = "PFMVEW00031";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PFMVEW00031_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvSavingMinorReport2;

    }
}