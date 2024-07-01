namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00083
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
            this.rpvDomesticDebitVoucher = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvDomesticDebitVoucher
            // 
            this.rpvDomesticDebitVoucher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvDomesticDebitVoucher.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tel.Vew.RDLC.TLMRDLC00034.rdlc";
            this.rpvDomesticDebitVoucher.Location = new System.Drawing.Point(0, 0);
            this.rpvDomesticDebitVoucher.Name = "rpvDomesticDebitVoucher";
            this.rpvDomesticDebitVoucher.Size = new System.Drawing.Size(605, 450);
            this.rpvDomesticDebitVoucher.TabIndex = 10;
            // 
            // TLMVEW00083
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 450);
            this.Controls.Add(this.rpvDomesticDebitVoucher);
            this.Name = "TLMVEW00083";
            this.Text = "Domestic Debit Voucher";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TLMVEW00083_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvDomesticDebitVoucher;
    }
}