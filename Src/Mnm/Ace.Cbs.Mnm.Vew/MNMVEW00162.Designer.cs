namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00162
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00162));
            this.TLMDTO00019BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvFixedInterestWithdrawListing = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00019BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TLMDTO00019BindingSource
            // 
            this.TLMDTO00019BindingSource.DataSource = typeof(Ace.Cbs.Tel.Dmd.TLMDTO00019);
            // 
            // rpvFixedInterestWithdrawListing
            // 
            this.rpvFixedInterestWithdrawListing.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "FixedDepositInterestWithdrawDataSet";
            reportDataSource1.Value = this.TLMDTO00019BindingSource;
            this.rpvFixedInterestWithdrawListing.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvFixedInterestWithdrawListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00090.rdlc";
            this.rpvFixedInterestWithdrawListing.Location = new System.Drawing.Point(0, 0);
            this.rpvFixedInterestWithdrawListing.Name = "rpvFixedInterestWithdrawListing";
            this.rpvFixedInterestWithdrawListing.Size = new System.Drawing.Size(727, 505);
            this.rpvFixedInterestWithdrawListing.TabIndex = 0;
            // 
            // MNMVEW00162
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 505);
            this.Controls.Add(this.rpvFixedInterestWithdrawListing);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00162";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fixed Interest Withdraw Listing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MNMVEW00162_FormClosing);
            this.Load += new System.EventHandler(this.MNMVEW00162_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00019BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvFixedInterestWithdrawListing;
        private System.Windows.Forms.BindingSource TLMDTO00019BindingSource;
    }
}