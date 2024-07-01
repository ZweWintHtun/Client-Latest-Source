namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00064
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00064));
            this.TLMDTO00018BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvInsurance = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00018BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TLMDTO00018BindingSource
            // 
            this.TLMDTO00018BindingSource.DataSource = typeof(Ace.Cbs.Tel.Dmd.TLMDTO00018);
            // 
            // rpvInsurance
            // 
            this.rpvInsurance.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Loan_DataSet";
            reportDataSource1.Value = this.TLMDTO00018BindingSource;
            this.rpvInsurance.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvInsurance.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tcm.Vew.RDLC.TCMRDLC00018.rdlc";
            this.rpvInsurance.Location = new System.Drawing.Point(0, 0);
            this.rpvInsurance.Name = "rpvInsurance";
            this.rpvInsurance.Size = new System.Drawing.Size(790, 569);
            this.rpvInsurance.TabIndex = 1;
            // 
            // TCMVEW00064
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 569);
            this.Controls.Add(this.rpvInsurance);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TCMVEW00064";
            this.RightToLeftLayout = true;
            this.Text = "Insurance Expired Loans Listing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TCMVEW00064_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00018BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvInsurance;
        private System.Windows.Forms.BindingSource TLMDTO00018BindingSource;
    }
}