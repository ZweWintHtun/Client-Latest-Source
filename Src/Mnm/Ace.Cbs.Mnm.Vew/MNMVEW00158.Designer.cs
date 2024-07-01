namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00158
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00158));
            this.MNMDTO00071BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rptByWithdraw = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00071BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MNMDTO00071BindingSource
            // 
            this.MNMDTO00071BindingSource.DataSource = typeof(Ace.Cbs.Mnm.Dmd.MNMDTO00071);
            // 
            // rptByWithdraw
            // 
            this.rptByWithdraw.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "SavingAccruedWithdraw_DataSet";
            reportDataSource1.Value = this.MNMDTO00071BindingSource;
            this.rptByWithdraw.LocalReport.DataSources.Add(reportDataSource1);
            this.rptByWithdraw.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00072.rdlc";
            this.rptByWithdraw.Location = new System.Drawing.Point(0, 0);
            this.rptByWithdraw.Name = "rptByWithdraw";
            this.rptByWithdraw.Size = new System.Drawing.Size(555, 450);
            this.rptByWithdraw.TabIndex = 0;
            // 
            // MNMVEW00158
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 450);
            this.Controls.Add(this.rptByWithdraw);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00158";
            this.Text = "Saving Accrued Interest Listing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MNMVEW00158_FormClosing);
            this.Load += new System.EventHandler(this.MNMVEW00158_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00071BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptByWithdraw;
        private System.Windows.Forms.BindingSource MNMDTO00071BindingSource;
    }
}