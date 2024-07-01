namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00413
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00413));
            this.rpvLoans = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvLoans
            // 
            this.rpvLoans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvLoans.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00042.rdlc";
            this.rpvLoans.Location = new System.Drawing.Point(0, 0);
            this.rpvLoans.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rpvLoans.Name = "rpvLoans";
            this.rpvLoans.Size = new System.Drawing.Size(1295, 642);
            this.rpvLoans.TabIndex = 0;
            // 
            // LOMVEW00413
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 642);
            this.Controls.Add(this.rpvLoans);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LOMVEW00413";
            this.Text = "Business Loans Schedule Listing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LOMVEW00413_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvLoans;
    }
}