namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00331
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
            this.TLMDTO00018BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvBLVrOstdListing = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00018BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rpvBLVrOstdListing
            // 
            this.rpvBLVrOstdListing.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSLOMRDLC00056";
            reportDataSource1.Value = this.TLMDTO00018BindingSource;
            this.rpvBLVrOstdListing.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvBLVrOstdListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00056.rdlc";
            this.rpvBLVrOstdListing.Location = new System.Drawing.Point(0, 0);
            this.rpvBLVrOstdListing.Name = "rpvBLVrOstdListing";
            this.rpvBLVrOstdListing.Size = new System.Drawing.Size(605, 450);
            this.rpvBLVrOstdListing.TabIndex = 7;
            // 
            // LOMVEW00331
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 450);
            this.Controls.Add(this.rpvBLVrOstdListing);
            this.Name = "LOMVEW00331";
            this.Text = "";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LOMVEW00331_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00018BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvBLVrOstdListing;
        private System.Windows.Forms.BindingSource TLMDTO00018BindingSource;
    }
}