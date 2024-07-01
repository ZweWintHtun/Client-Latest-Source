namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00409
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00409));
            this.LOMDTO00405BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvBL = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00405BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // LOMDTO00405BindingSource
            // 
            this.LOMDTO00405BindingSource.DataSource = typeof(Ace.Cbs.Loan.Dmd.LOMDTO00405);
            // 
            // rpvBL
            // 
            this.rpvBL.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSLOMRDLC00040";
            reportDataSource1.Value = this.LOMDTO00405BindingSource;
            this.rpvBL.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvBL.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00040.rdlc";
            this.rpvBL.Location = new System.Drawing.Point(0, 0);
            this.rpvBL.Name = "rpvBL";
            this.rpvBL.Size = new System.Drawing.Size(818, 312);
            this.rpvBL.TabIndex = 0;
            // 
            // LOMVEW00409
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 312);
            this.Controls.Add(this.rpvBL);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LOMVEW00409";
            this.Text = "Business Loans Information Listing By Grade";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LOMVEW00409_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00405BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvBL;
        private System.Windows.Forms.BindingSource LOMDTO00405BindingSource;
    }
}