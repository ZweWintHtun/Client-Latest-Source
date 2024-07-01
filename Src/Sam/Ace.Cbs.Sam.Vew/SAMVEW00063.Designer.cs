namespace Ace.Cbs.Sam.Vew
{
    partial class SAMVEW00063
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAMVEW00063));
            this.SAMDTO00056BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvInterestRateList = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.SAMDTO00056BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // SAMDTO00056BindingSource
            // 
            this.SAMDTO00056BindingSource.DataMember = "SAMDTO00056";
            // 
            // rpvInterestRateList
            // 
            this.rpvInterestRateList.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "InterestRateFileDataSet";
            reportDataSource1.Value = this.SAMDTO00056BindingSource;
            reportDataSource2.Name = "IntRateFileDataSet";
            reportDataSource2.Value = this.SAMDTO00056BindingSource;
            this.rpvInterestRateList.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvInterestRateList.LocalReport.DataSources.Add(reportDataSource2);
            this.rpvInterestRateList.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Sam.Vew.RDLC.SAMRDLC00009.rdlc";
            this.rpvInterestRateList.Location = new System.Drawing.Point(0, 0);
            this.rpvInterestRateList.Name = "rpvInterestRateList";
            this.rpvInterestRateList.Size = new System.Drawing.Size(733, 386);
            this.rpvInterestRateList.TabIndex = 0;
            // 
            // SAMVEW00063
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 386);
            this.Controls.Add(this.rpvInterestRateList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SAMVEW00063";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAMVEW00063";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SAMVEW00063_FormClosing);
            this.Load += new System.EventHandler(this.SAMVEW00063_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SAMDTO00056BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvInterestRateList;
        private System.Windows.Forms.BindingSource SAMDTO00056BindingSource;

    }
}