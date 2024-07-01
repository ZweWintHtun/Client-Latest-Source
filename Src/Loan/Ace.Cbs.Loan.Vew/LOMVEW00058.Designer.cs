namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00058
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00058));
            this.LOMDTO00057BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvServiceCharges = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00057BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // LOMDTO00057BindingSource
            // 
            this.LOMDTO00057BindingSource.DataSource = typeof(Ace.Cbs.Loan.Dmd.LOMDTO00057);
            // 
            // rpvServiceCharges
            // 
            this.rpvServiceCharges.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSLOMRDLC00010";
            reportDataSource1.Value = this.LOMDTO00057BindingSource;
            this.rpvServiceCharges.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvServiceCharges.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00010.rdlc";
            this.rpvServiceCharges.Location = new System.Drawing.Point(0, 0);
            this.rpvServiceCharges.Name = "rpvServiceCharges";
            this.rpvServiceCharges.Size = new System.Drawing.Size(625, 470);
            this.rpvServiceCharges.TabIndex = 0;
            // 
            // LOMVEW00058
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 470);
            this.Controls.Add(this.rpvServiceCharges);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00058";
            this.Text = "LOMVEW00058";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LOMVEW00058_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00057BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvServiceCharges;
        private System.Windows.Forms.BindingSource LOMDTO00057BindingSource;
    }
}