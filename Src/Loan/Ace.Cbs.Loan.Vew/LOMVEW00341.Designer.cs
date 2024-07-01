namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00341
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
            this.rpvBLHPContractPrint = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvBLHPContractPrint
            // 
            this.rpvBLHPContractPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvBLHPContractPrint.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00078.rdlc";
            this.rpvBLHPContractPrint.Location = new System.Drawing.Point(0, 0);
            this.rpvBLHPContractPrint.Name = "rpvBLHPContractPrint";
            this.rpvBLHPContractPrint.Size = new System.Drawing.Size(605, 446);
            this.rpvBLHPContractPrint.TabIndex = 7;
            // 
            // LOMVEW00341
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 446);
            this.Controls.Add(this.rpvBLHPContractPrint);
            this.Name = "LOMVEW00341";
            this.Text = "Business Loan ( Hypothication ) Contract Printing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LOMVEW00341_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvBLHPContractPrint;
    }
}