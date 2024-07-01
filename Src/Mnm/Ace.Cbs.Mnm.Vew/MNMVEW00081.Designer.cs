namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00081
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00081));
            this.MNMDTO00081BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvMNMVEW00081 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00081BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MNMDTO00081BindingSource
            // 
            this.MNMDTO00081BindingSource.DataSource = typeof(Ace.Cbs.Mnm.Dmd.MNMDTO00081);
            // 
            // rpvMNMVEW00081
            // 
            this.rpvMNMVEW00081.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "MNMDS00081";
            reportDataSource1.Value = this.MNMDTO00081BindingSource;
            this.rpvMNMVEW00081.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvMNMVEW00081.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00081.rdlc";
            this.rpvMNMVEW00081.Location = new System.Drawing.Point(0, 0);
            this.rpvMNMVEW00081.Name = "rpvMNMVEW00081";
            this.rpvMNMVEW00081.Size = new System.Drawing.Size(771, 482);
            this.rpvMNMVEW00081.TabIndex = 0;
            // 
            // MNMVEW00081
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 482);
            this.Controls.Add(this.rpvMNMVEW00081);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00081";
            this.Text = "MNMVEW00081";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MNMVEW00081_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00081BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvMNMVEW00081;
        private System.Windows.Forms.BindingSource MNMDTO00081BindingSource;
    }
}