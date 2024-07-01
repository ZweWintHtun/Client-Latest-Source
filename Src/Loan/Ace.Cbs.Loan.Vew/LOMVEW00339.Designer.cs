namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00339
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
            this.rpvBLPGContractPrint = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvBLPGContractPrint
            // 
            this.rpvBLPGContractPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvBLPGContractPrint.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00077.rdlc";
            this.rpvBLPGContractPrint.Location = new System.Drawing.Point(0, 0);
            this.rpvBLPGContractPrint.Name = "rpvBLPGContractPrint";
            this.rpvBLPGContractPrint.Size = new System.Drawing.Size(605, 446);
            this.rpvBLPGContractPrint.TabIndex = 6;
            // 
            // LOMVEW00339
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 446);
            this.Controls.Add(this.rpvBLPGContractPrint);
            this.Name = "LOMVEW00339";
            this.Text = "Business Loan ( Personal Guarantee ) Contract Printing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LOMVEW00339_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvBLPGContractPrint;
    }
}