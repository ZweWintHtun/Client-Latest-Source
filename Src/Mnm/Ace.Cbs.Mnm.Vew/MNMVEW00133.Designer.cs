namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00133
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00133));
            this.PFMDTO00017BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvCurrentAccountCompany = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00017BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PFMDTO00017BindingSource
            // 
            this.PFMDTO00017BindingSource.DataSource = typeof(Ace.Cbs.Pfm.Dmd.PFMDTO00017);
            // 
            // rpvCurrentAccountCompany
            // 
            this.rpvCurrentAccountCompany.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "CurrentAccountCompany";
            reportDataSource1.Value = this.PFMDTO00017BindingSource;
            this.rpvCurrentAccountCompany.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvCurrentAccountCompany.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00053.rdlc";
            this.rpvCurrentAccountCompany.Location = new System.Drawing.Point(0, 0);
            this.rpvCurrentAccountCompany.Name = "rpvCurrentAccountCompany";
            this.rpvCurrentAccountCompany.Size = new System.Drawing.Size(588, 363);
            this.rpvCurrentAccountCompany.TabIndex = 0;
            // 
            // MNMVEW00133
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 363);
            this.Controls.Add(this.rpvCurrentAccountCompany);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00133";
            this.Text = "MNMVEW00133";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MNMVEW00133_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00017BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvCurrentAccountCompany;
        private System.Windows.Forms.BindingSource PFMDTO00017BindingSource;
    }
}