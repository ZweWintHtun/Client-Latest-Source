namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00145
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
            this.rpvAutoLinkCreditListing = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvAutoLinkCreditListing
            // 
            this.rpvAutoLinkCreditListing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvAutoLinkCreditListing.Location = new System.Drawing.Point(0, 0);
            this.rpvAutoLinkCreditListing.Name = "rpvAutoLinkCreditListing";
            this.rpvAutoLinkCreditListing.Size = new System.Drawing.Size(292, 271);
            this.rpvAutoLinkCreditListing.TabIndex = 0;
            // 
            // MNMVEW00145
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 271);
            this.Controls.Add(this.rpvAutoLinkCreditListing);
            this.Name = "MNMVEW00145";
            this.Text = "Auto Link Credit Listing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MNMVEW00145_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvAutoLinkCreditListing;
    }
}