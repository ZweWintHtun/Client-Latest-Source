namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00310
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00310));
            this.rpvFLTotalDailyIncome = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvFLTotalDailyIncome
            // 
            this.rpvFLTotalDailyIncome.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSLOMRDLC00024";
            reportDataSource1.Value = null;
            this.rpvFLTotalDailyIncome.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvFLTotalDailyIncome.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00024.rdlc";
            this.rpvFLTotalDailyIncome.Location = new System.Drawing.Point(0, 0);
            this.rpvFLTotalDailyIncome.Name = "rpvFLTotalDailyIncome";
            this.rpvFLTotalDailyIncome.Size = new System.Drawing.Size(615, 460);
            this.rpvFLTotalDailyIncome.TabIndex = 2;
            // 
            // LOMVEW00310
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 460);
            this.Controls.Add(this.rpvFLTotalDailyIncome);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00310";
            this.Text = "";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvFLTotalDailyIncome;
    }
}