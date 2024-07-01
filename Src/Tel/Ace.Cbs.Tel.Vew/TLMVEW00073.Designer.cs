namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00073
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00073));
            this.rpvFixedBankStatementListing = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvFixedBankStatementListing
            // 
            this.rpvFixedBankStatementListing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvFixedBankStatementListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tel.Vew.RDLC.TLMRDLC00029.rdlc";
            this.rpvFixedBankStatementListing.Location = new System.Drawing.Point(0, 0);
            this.rpvFixedBankStatementListing.Name = "rpvFixedBankStatementListing";
            this.rpvFixedBankStatementListing.Size = new System.Drawing.Size(874, 511);
            this.rpvFixedBankStatementListing.TabIndex = 0;
            // 
            // TLMVEW00073
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 511);
            this.Controls.Add(this.rpvFixedBankStatementListing);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00073";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TLMVEW00073_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvFixedBankStatementListing;
    }
}