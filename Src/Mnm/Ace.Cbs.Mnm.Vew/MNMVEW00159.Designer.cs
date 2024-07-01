namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00159
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00159));
            this.MNMDTO00071BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rptSavingAccruedOutstanding = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00071BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MNMDTO00071BindingSource
            // 
            this.MNMDTO00071BindingSource.DataSource = typeof(Ace.Cbs.Mnm.Dmd.MNMDTO00071);
            // 
            // rptSavingAccruedOutstanding
            // 
            this.rptSavingAccruedOutstanding.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "SavingAccruedOutstanding_DataSet";
            reportDataSource1.Value = this.MNMDTO00071BindingSource;
            this.rptSavingAccruedOutstanding.LocalReport.DataSources.Add(reportDataSource1);
            this.rptSavingAccruedOutstanding.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00071.rdlc";
            this.rptSavingAccruedOutstanding.Location = new System.Drawing.Point(0, 0);
            this.rptSavingAccruedOutstanding.Name = "rptSavingAccruedOutstanding";
            this.rptSavingAccruedOutstanding.Size = new System.Drawing.Size(742, 441);
            this.rptSavingAccruedOutstanding.TabIndex = 0;
            // 
            // MNMVEW00159
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 441);
            this.Controls.Add(this.rptSavingAccruedOutstanding);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00159";
            this.Text = "Saving Accrued Interest Listing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MNMVEW00159_FormClosing);
            this.Load += new System.EventHandler(this.MNMVEW00159_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00071BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptSavingAccruedOutstanding;
        private System.Windows.Forms.BindingSource MNMDTO00071BindingSource;
    }
}