namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00113
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00113));
            this.MNMDTO00007BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvSavingInterest = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00007BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MNMDTO00007BindingSource
            // 
            this.MNMDTO00007BindingSource.DataSource = typeof(Ace.Cbs.Mnm.Dmd.MNMDTO00007);
            // 
            // rpvSavingInterest
            // 
            this.rpvSavingInterest.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "MNMDS00019";
            reportDataSource1.Value = this.MNMDTO00007BindingSource;
            this.rpvSavingInterest.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvSavingInterest.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00033.rdlc";
            this.rpvSavingInterest.Location = new System.Drawing.Point(0, 0);
            this.rpvSavingInterest.Name = "rpvSavingInterest";
            this.rpvSavingInterest.Size = new System.Drawing.Size(648, 494);
            this.rpvSavingInterest.TabIndex = 0;
            // 
            // MNMVEW00113
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 494);
            this.Controls.Add(this.rpvSavingInterest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00113";
            this.Text = "Saving Interest Listing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MNMVEW00113_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00007BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvSavingInterest;
        private System.Windows.Forms.BindingSource MNMDTO00007BindingSource;
    }
}