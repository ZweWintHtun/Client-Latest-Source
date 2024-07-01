namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00102
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00102));
            this.MNMDTO00035BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvSubByTransaction = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00035BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MNMDTO00035BindingSource
            // 
            this.MNMDTO00035BindingSource.DataSource = typeof(Ace.Cbs.Mnm.Dmd.MNMDTO00035);
            // 
            // rpvSubByTransaction
            // 
            this.rpvSubByTransaction.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "MNMDS00022";
            reportDataSource1.Value = this.MNMDTO00035BindingSource;
            this.rpvSubByTransaction.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvSubByTransaction.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00022.rdlc";
            this.rpvSubByTransaction.Location = new System.Drawing.Point(0, 0);
            this.rpvSubByTransaction.Name = "rpvSubByTransaction";
            this.rpvSubByTransaction.Size = new System.Drawing.Size(661, 569);
            this.rpvSubByTransaction.TabIndex = 0;
            // 
            // MNMVEW00102
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 569);
            this.Controls.Add(this.rpvSubByTransaction);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MNMVEW00102";
            this.Text = "Sub Ledger by Transaction Listing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MNMVEW00102_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00035BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvSubByTransaction;
        private System.Windows.Forms.BindingSource MNMDTO00035BindingSource;
    }
}