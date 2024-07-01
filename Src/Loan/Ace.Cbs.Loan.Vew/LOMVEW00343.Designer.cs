namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00343
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
            this.rpvBLLBContractPrint = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvBLLBContractPrint
            // 
            this.rpvBLLBContractPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvBLLBContractPrint.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00079.rdlc";
            this.rpvBLLBContractPrint.Location = new System.Drawing.Point(0, 0);
            this.rpvBLLBContractPrint.Name = "rpvBLLBContractPrint";
            this.rpvBLLBContractPrint.Size = new System.Drawing.Size(605, 446);
            this.rpvBLLBContractPrint.TabIndex = 7;
            // 
            // LOMVEW00343
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 446);
            this.Controls.Add(this.rpvBLLBContractPrint);
            this.Name = "LOMVEW00343";
            this.Text = "Business Loan ( Land & Building ) Contract Printing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LOMVEW00343_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvBLLBContractPrint;
    }
}