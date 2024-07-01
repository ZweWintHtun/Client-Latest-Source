namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00164
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00164));
            this.rpvFixedDepositCertificatePrinting = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvFixedDepositCertificatePrinting
            // 
            this.rpvFixedDepositCertificatePrinting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvFixedDepositCertificatePrinting.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00093.rdlc";
            this.rpvFixedDepositCertificatePrinting.Location = new System.Drawing.Point(0, 0);
            this.rpvFixedDepositCertificatePrinting.Name = "rpvFixedDepositCertificatePrinting";
            this.rpvFixedDepositCertificatePrinting.Size = new System.Drawing.Size(662, 476);
            this.rpvFixedDepositCertificatePrinting.TabIndex = 1;
            // 
            // MNMVEW00164
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 476);
            this.Controls.Add(this.rpvFixedDepositCertificatePrinting);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00164";
            this.Text = "Fixed Deposit Receipt ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MNMVEW00164_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvFixedDepositCertificatePrinting;
    }
}