namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00065
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00065));
            this.PFMDTO00042BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvDepositListingByAccountType = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PFMDTO00042BindingSource
            // 
            this.PFMDTO00042BindingSource.DataMember = "PFMDTO00042";
            // 
            // rpvDepositListingByAccountType
            // 
            this.rpvDepositListingByAccountType.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DepositListingByAllandByCounterDTO_DataSet";
            reportDataSource1.Value = this.PFMDTO00042BindingSource;
            this.rpvDepositListingByAccountType.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvDepositListingByAccountType.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tel.Vew.RDLC.TLMRDLC00023.rdlc";
            this.rpvDepositListingByAccountType.Location = new System.Drawing.Point(0, 0);
            this.rpvDepositListingByAccountType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rpvDepositListingByAccountType.Name = "rpvDepositListingByAccountType";
            this.rpvDepositListingByAccountType.Size = new System.Drawing.Size(964, 624);
            this.rpvDepositListingByAccountType.TabIndex = 3;
            // 
            // TLMVEW00065
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 624);
            this.Controls.Add(this.rpvDepositListingByAccountType);
            this.Font = new System.Drawing.Font("Zawgyi-One", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TLMVEW00065";
            this.Text = "Deposit Listing By Account Type";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TLMVEW00065_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvDepositListingByAccountType;
        private System.Windows.Forms.BindingSource PFMDTO00042BindingSource;
    }
}