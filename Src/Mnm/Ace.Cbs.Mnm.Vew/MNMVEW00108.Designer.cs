namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00108
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00108));
            this.rptFixedReceiptListing = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rptFixedReceiptListing
            // 
            this.rptFixedReceiptListing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptFixedReceiptListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00028.rdlc";
            this.rptFixedReceiptListing.Location = new System.Drawing.Point(0, 0);
            this.rptFixedReceiptListing.Name = "rptFixedReceiptListing";
            this.rptFixedReceiptListing.Size = new System.Drawing.Size(557, 469);
            this.rptFixedReceiptListing.TabIndex = 0;
            // 
            // MNMVEW00108
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 469);
            this.Controls.Add(this.rptFixedReceiptListing);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00108";
            this.Text = "MNMVEW00108";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MNMVEW00108_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptFixedReceiptListing;
    }
}