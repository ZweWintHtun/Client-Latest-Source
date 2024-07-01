namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00411
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00411));
            this.LOMDTO00405BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvLoans = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00405BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // LOMDTO00405BindingSource
            // 
            this.LOMDTO00405BindingSource.DataSource = typeof(Ace.Cbs.Loan.Dmd.LOMDTO00405);
            // 
            // rpvLoans
            // 
            this.rpvLoans.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSLOMRDLC00041";
            reportDataSource1.Value = this.LOMDTO00405BindingSource;
            this.rpvLoans.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvLoans.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00041.rdlc";
            this.rpvLoans.Location = new System.Drawing.Point(0, 0);
            this.rpvLoans.Name = "rpvLoans";
            this.rpvLoans.Size = new System.Drawing.Size(558, 263);
            this.rpvLoans.TabIndex = 0;
            // 
            // LOMVEW00411
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 263);
            this.Controls.Add(this.rpvLoans);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LOMVEW00411";
            this.Text = "Business Loans Service Charges Listing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LOMVEW00411_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00405BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvLoans;
        private System.Windows.Forms.BindingSource LOMDTO00405BindingSource;
    }
}