namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00337
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
            this.rpvPLContractPrint = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvPLContractPrint
            // 
            this.rpvPLContractPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvPLContractPrint.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00076.rdlc";
            this.rpvPLContractPrint.Location = new System.Drawing.Point(0, 0);
            this.rpvPLContractPrint.Name = "rpvPLContractPrint";
            this.rpvPLContractPrint.Size = new System.Drawing.Size(605, 446);
            this.rpvPLContractPrint.TabIndex = 5;
            // 
            // LOMVEW00337
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 446);
            this.Controls.Add(this.rpvPLContractPrint);
            this.Name = "LOMVEW00337";
            this.Text = "Personal Loan Contract Printing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LOMVEW00337_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvPLContractPrint;
    }
}