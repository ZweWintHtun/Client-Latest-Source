namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00048
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00048));
            this.TLMDTO00004BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvHomeIncome = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00004BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rpvHomeIncome
            // 
            this.rpvHomeIncome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvHomeIncome.Font = new System.Drawing.Font("Zawgyi-One", 8F);
            reportDataSource1.Name = "IBLHomeIncomeReportDataSet";
            reportDataSource1.Value = this.TLMDTO00004BindingSource;
            this.rpvHomeIncome.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvHomeIncome.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tel.Vew.RDLC.TLMRDLC00006.rdlc";
            this.rpvHomeIncome.Location = new System.Drawing.Point(0, 0);
            this.rpvHomeIncome.Name = "rpvHomeIncome";
            this.rpvHomeIncome.Size = new System.Drawing.Size(964, 451);
            this.rpvHomeIncome.TabIndex = 0;
            // 
            // TLMVEW00048
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 451);
            this.Controls.Add(this.rpvHomeIncome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00048";
            this.Text = "Income Listing for Home Transactions Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TLMVEW00048_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00004BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvHomeIncome;
        private System.Windows.Forms.BindingSource TLMDTO00004BindingSource;


    }
}