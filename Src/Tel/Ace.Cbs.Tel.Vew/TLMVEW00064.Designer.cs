namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00064
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00064));
            this.PFMDTO00042BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvDepositListingByAccountNo = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PFMDTO00042BindingSource
            // 
            this.PFMDTO00042BindingSource.DataMember = "PFMDTO00042";
            // 
            // rpvDepositListingByAccountNo
            // 
            this.rpvDepositListingByAccountNo.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DepositListingByAccountNo_DataSet";
            reportDataSource1.Value = this.PFMDTO00042BindingSource;
            this.rpvDepositListingByAccountNo.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvDepositListingByAccountNo.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tel.Vew.RDLC.TLMRDLC00022.rdlc";
            this.rpvDepositListingByAccountNo.Location = new System.Drawing.Point(0, 0);
            this.rpvDepositListingByAccountNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rpvDepositListingByAccountNo.Name = "rpvDepositListingByAccountNo";
            this.rpvDepositListingByAccountNo.Size = new System.Drawing.Size(581, 624);
            this.rpvDepositListingByAccountNo.TabIndex = 2;
            // 
            // TLMVEW00064
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 624);
            this.Controls.Add(this.rpvDepositListingByAccountNo);
            this.Font = new System.Drawing.Font("Zawgyi-One", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TLMVEW00064";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deposit Listing (By Account No)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TLMVEW00064_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvDepositListingByAccountNo;
        private System.Windows.Forms.BindingSource PFMDTO00042BindingSource;
    }
}